using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessEntities;
using BLL;
using Telerik.Web.UI;
using System.Data;
using System.Collections.Generic;


namespace SecureProctor.Student
{
    public partial class StartAnExam : BaseClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Page.Title = EnumPageTitles.APPNAME + EnumPageTitles.STUDENT_STARTEXAM;
                ((LinkButton)this.Page.Master.FindControl("lnkStart")).CssClass = "main_menu_active";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "NotSaved", "document.getElementById('" + imgHead.ClientID.ToString() + "').focus();", true);
            }
        }
        int intTabCount = 14;
        protected void gvStartExam_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            try
            {
                this.LoadData();
                this.DisplayStepsVisibility();
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        protected void LoadData()
        {
            try
            {
                BEStudent objBEStudent = new BEStudent();
                BStudent objBStudent = new BStudent();
                objBEStudent.IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID].ToString());
                objBEStudent.IntProviderID = 0;
                objBStudent.BGetStudentTodayExams(objBEStudent);
                if (objBEStudent.DtResult.Rows.Count > 0)
                {
                    ViewState["SecurityLevels"] = objBEStudent.DtResult;
                    gvStartExam.DataSource = objBEStudent.DtResult;
                    gvStartExam.Visible = true;                    
                    objBEStudent = null;
                    objBStudent = null;
                }

                else
                {

                    lblMsg.Visible = true;
                    lblMsg.Text = "You do not have any exams scheduled. <a href='ScheduleAnExam.aspx'><u><font color='blue'>Schedule an exam</font></u></a> and it will show up here.";
                    gvStartExam.DataSource = new object[] { };
                    gvStartExam.Visible = false;
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

    

        protected void gvStartExam_ItemCommand(object sender, GridCommandEventArgs e)
        {
            string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
            if (commandArgs[1].ToString() == "5") // LEVEL AA
            {
                if (commandArgs[2].ToString() != "1")
                {
                    Session["isexamiFACE"] = "0";
                    Response.Redirect("Systemreadiness.aspx?TransID=" + AppSecurity.Encrypt(commandArgs[0].ToString()), false);
                }
                else
                {
                        Session["isexamiFACE"] = "0";
                        Response.Redirect("Systemreadiness.aspx?TransID=" + AppSecurity.Encrypt(commandArgs[0].ToString()), false);
                }
            }
            else 
            {
                BEStudent objBEStudent = new BEStudent();
                BStudent objBStudent = new BStudent();
                objBEStudent.IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID].ToString());
                objBEStudent.IntTransID = Convert.ToInt64(commandArgs[0].ToString());
                objBStudent.BCheckExamStartTime(objBEStudent);
                if (objBEStudent.DtResult != null && objBEStudent.DtResult.Rows.Count > 0)
                {
                    if (Convert.ToInt32(objBEStudent.DtResult.Rows[0]["Result"]) == 1)
                    {
                        objBStudent.BSetStudentStartExamFlag(objBEStudent);
                        if (Convert.ToBoolean(objBEStudent.DtResult.Rows[0]["isexamiFACE"]) == true)
                        {
                            Session["isexamiFACE"] = "1";
                            this.CaptureOsAndBrowser(Convert.ToInt64(commandArgs[0].ToString()));
                            Response.Redirect("Systemreadiness.aspx?TransID=" + AppSecurity.Encrypt(commandArgs[0].ToString()), false);
                        }
                        else if (Convert.ToBoolean(objBEStudent.DtResult.Rows[0]["ExamiKey"]) == true)
                        {
                            Session["isexamiFACE"] = "0";
                            this.CaptureOsAndBrowser(Convert.ToInt64(commandArgs[0].ToString()));
                            Response.Redirect("StudentExamProcess.aspx?TransID=" + AppSecurity.Encrypt(commandArgs[0].ToString()) + "&&ExamiKEY=" + AppSecurity.Encrypt("1"), false);
                        }
                        else
                        {
                            Session["isexamiFACE"] = "0";
                            this.CaptureOsAndBrowser(Convert.ToInt64(commandArgs[0].ToString()));
                            Response.Redirect("StudentExamProcess.aspx?TransID=" + AppSecurity.Encrypt(commandArgs[0].ToString()) + "&&ExamiKEY=" + AppSecurity.Encrypt("0"), false);
                        }

                        tderror.Visible = false;
                    }
                    else
                    {
                        tderror.Visible = true;
                        lblError.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + Resources.ResMessages.Student_checkStartTime + "</font>";
                    }
                }
            }
        }
        public string setButtonDisplay(string LockDownBrowser)
        {
            if (bool.Parse(LockDownBrowser))
                return " hide";
            else
                return "";
        }
        public string setShowButtonDisplay(string LockDownBrowser)
        {
            if (bool.Parse(LockDownBrowser))
                return "";
            else
                return "hide";
        }
        protected void gvStartExam_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem item = (GridDataItem)e.Item;
                DataRowView drv = (DataRowView)item.DataItem;
                
                #region GridControlTabIndex
                item["TransID"].TabIndex = (short)(intTabCount++);
                item["CourseName"].TabIndex = (short)(intTabCount++);
                item["ExamName"].TabIndex = (short)(intTabCount++);
                item["Date"].TabIndex = (short)(intTabCount++);
                item["Time"].TabIndex = (short)(intTabCount++);
                ImageButton ImgImageButton1 = (ImageButton)item.FindControl("lnkStartExam");
                ImgImageButton1.TabIndex = (short)(intTabCount++);
                #endregion

                //here we are displaying the proctoring and without proctoring data in the same grid based on this action condition
                int intAction =Convert.ToInt32( drv["Examsecurity"].ToString());
                ImageButton lnkActionButton = (ImageButton)item.FindControl("lnkAction");
                lnkActionButton.TabIndex = (short)(intTabCount++);
                if (intAction != 1 && intAction != 3 && intAction != 4)
                {
                    lnkActionButton.Attributes.Add("onclick", "return handleGridStartExam();");
                }

                //Is examiFACE EXAM
                //int IsexamiFace = Convert.ToInt32(drv["IsexamiFACE"].ToString());

                //if (intAction == 5)//Without Proctor
                //{
                //    lnkActionButton.Text = "Auto authentication";
                //    lnkActionButton.CommandName = "StartAAExam";
                //}
                //else if (IsexamiFace==1)
                //{
                //    lnkActionButton.Text = "Auto-proctor";
                //    lnkActionButton.CommandName = "StartExam";
                //}
                //else 
                //{
                //    lnkActionButton.Text = "Connect to proctor";
                //    lnkActionButton.CommandName = "StartExam";
                //}
            }
        }
       
        protected void CaptureOsAndBrowser(Int64 intTransID)
        {
            BEStudent objBEStudent = new BEStudent();
            BStudent objBStudent = new BStudent();
            objBEStudent.IntTransID = intTransID;
            try
            {
                if (Request.UserAgent.IndexOf("Edge") > -1)
                {
                    objBEStudent.strBrowser = "IE Edge";
                    objBEStudent.strBrowserVersion = "";
                }
                else
                {
                    objBEStudent.strBrowser = Request.Browser.Browser.ToString();
                    objBEStudent.strBrowserVersion = Request.Browser.Version.ToString();
                }
                var varOS = Request.UserAgent;
                if (varOS.Contains("Mac OS"))
                    objBEStudent.strOS = "Mac OS";
                else if (varOS.Contains("Windows"))
                    objBEStudent.strOS = "Windows";
                else
                    objBEStudent.strOS = string.Empty;
            }
            catch
            {
                objBEStudent.strBrowser = "N/A";
                objBEStudent.strBrowserVersion = "N/A";
                objBEStudent.strOS = "N/A";
            }
            objBStudent.BCaptureOSAndBrowser(objBEStudent);
            objBEStudent = null;
            objBStudent = null;
        }

        protected void DisplayStepsVisibility()
        {
            DataTable dt = (DataTable)ViewState["SecurityLevels"];

            List<int> li = new List<int>();
            if (dt != null)
            {

                foreach (DataRow row in dt.Rows)
                {
                    int secLevel = Convert.ToInt32(row["Examsecurity"]);
                    li.Add(secLevel);
                }

                if (li.Contains(2) || li.Contains(5) || li.Contains(6))
                {
                    step1ID.Visible = true;
                }
                else
                {
                    step1ID.Visible = false;
                    step2Legend.InnerText = " ";
                }
            }
            else
            {
                step1ID.Visible = false;
                step2Legend.Visible = false;
            }
        }
    }
}