using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using BusinessEntities;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Text;
using System.IO;
using Telerik.Web.UI;
using System.Configuration;
using System.Net;

namespace SecureProctor.Proctor
{
    public partial class ViewExamScreens : BaseClass
    {
        string streamingurl;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Page.Title = EnumPageTitles.APPNAME + EnumPageTitles.EXAMPROVIDER_VIEW_STUDENT_EXAM;
            ((LinkButton)this.Page.Master.FindControl("lnkExamStatus")).CssClass = "main_menu_active";
            if (!IsPostBack)
            {


                if (Request.QueryString["TransID"] != null)
                {
                    Session[BaseClass.EnumPageSessions.TransID] = Request.QueryString["TransID"].ToString();
                }
                else
                    Session[BaseClass.EnumPageSessions.TransID] = null;

                // tdDesktop.InnerHtml = getPlayer("Desktop");
                tdDesktop.InnerHtml = getPlayer("Desktop");
                this.BindExamDetails();
                // GetURL();


            }

            this.GetStudentUploadFileStatus();
            if (ddlAlerts.Items.Count > 0)
            {
                if (ddlAlerts.SelectedItem.Text.ToUpper() == "OTHER")
                {
                    // txtComments.Visible = true;
                    RequiredFieldValidator11.Visible = true;
                    //RequiredFieldValidator11.ValidationGroup = string.Empty;
                }
                else
                {
                    //  txtComments.Visible = false;
                    RequiredFieldValidator11.Visible = false;
                }
            }
            else
            {
                txtComments.Visible = false;
                RequiredFieldValidator11.Visible = false;

            }

            if (Request.QueryString["TransID"] != null)
            {
                this.getExamFileUploadStatus();

            }
            //
        }
        protected void GetURL()
        {

            string clientname = ConfigurationManager.AppSettings["clientname"];
            string transid = AppSecurity.Decrypt(Request.QueryString["TransID"].ToString());
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(ConfigurationManager.AppSettings["RackServiceURL"] + transid + "/" + clientname);
            request.Method = "GET";
            WebResponse response = request.GetResponse();
            Stream str = response.GetResponseStream();
            StreamReader reader = new StreamReader(str);

            string responseFromServer = reader.ReadToEnd();
            Console.WriteLine(responseFromServer);
            reader.Close();
            response.Close();
            streamingurl = responseFromServer.ToString();
        }

        protected void getExamFileUploadStatus()
        {

            BECommon objBECommon = new BECommon();
            BCommon objBCommon = new BCommon();
            objBECommon.IntTransID = Convert.ToInt64(AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()));
            objBCommon.BgetExamFileUploadStatus(objBECommon);

            if (objBECommon.DsResult.Tables[0].Rows != null && objBECommon.DsResult.Tables[0].Rows.Count > 0 && objBECommon.DsResult.Tables[1].Rows != null && objBECommon.DsResult.Tables[1].Rows.Count > 0)
            {
                if (objBECommon.DsResult.Tables[0].Rows[0][0].Equals(true) && objBECommon.DsResult.Tables[1].Rows[0][0].Equals(true))
                {
                    ucUploadFiles.Visible = true;

                }
                else
                    ucUploadFiles.Visible = false;

            }
        }

        protected void GetStudentUploadFileStatus()
        {

            BECommon objBECommon = new BECommon();
            BCommon objBCommon = new BCommon();
            objBCommon.BGetStudentUploadFileStatus(objBECommon);

            if (objBECommon.DtResult != null && objBECommon.DtResult.Rows.Count > 0)
            {
                if (objBECommon.DtResult.Rows[0][0].Equals(true))
                    ucUploadFiles.Visible = true;
                else
                    ucUploadFiles.Visible = false;

            }
        }


        #region BindExamDetails
        protected void BindExamDetails()
        {
            try
            {
                BECommon objBECommon = new BECommon();
                BCommon objBCommon = new BCommon();

                if (Request.QueryString["TransID"] != null)
                {

                    objBECommon.IntTransID = Convert.ToInt64(AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()));
                    objBECommon.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID]);
                    objBCommon.BGetStudentExamDetails(objBECommon);

                    if (objBECommon.DsResult != null)
                    {
                        if (objBECommon.DsResult.Tables[0].Rows.Count > 0)
                        {
                            ViewState[BaseClass.EnumPageSessions.TransID] = AppSecurity.Decrypt(Request.QueryString["TransID"].ToString());
                            gvexamdetails.DataSource = objBECommon.DsResult.Tables[0];
                            if (Convert.ToBoolean(objBECommon.DsResult.Tables[0].Rows[0]["ExamiKey"]) == true)
                            {
                                lblKeyScore.Text = objBECommon.DsResult.Tables[0].Rows[0]["Examikeyscore"].ToString() + "%";
                                lblKeyScore.Visible = true;
                                lblKeyScoretext.Visible = true;
                            }
                            else
                            {
                                lblKeyScore.Visible = false;
                                lblKeyScoretext.Visible = false;
                            }

                            // string strTotalPath = "~/Student/Student_Identity/" + objBECommon.DsResult.Tables[0].Rows[0]["PhotoIdentity"].ToString().Substring(3).ToString();
                            img.ImageUrl = new AppSecurity().ImageToBase64(objBECommon.DsResult.Tables[0].Rows[0]["PhotoIdentity"].ToString().Substring(3).ToString());

                            // img.ImageUrl = strTotalPath;

                            img.ImageAlign = ImageAlign.Top;



                        }


                        if (objBECommon.DsResult.Tables[5].Rows.Count > 0)
                        {
                            lblExamLevel.Text = objBECommon.DsResult.Tables[5].Rows[0]["Level"].ToString();

                        }

                        if (objBECommon.DsResult.Tables[6].Rows.Count > 0)
                        {

                            if (Convert.ToInt32(objBECommon.DsResult.Tables[6].Rows[0]["secirtyType"]) == 5)
                            {
                                if (Convert.ToInt32(objBECommon.DsResult.Tables[6].Rows[0]["IsexamiFACE"]) == 1)
                                {
                                    tbAutoProctor.Visible = true;
                                }
                                else
                                {
                                    tbAutoProctor.Visible = false;
                                }
                                tdDesktop.Visible = false;
                                trNonProctorImages.Visible = true;
                                trExamLevel.Visible = false;
                                trVideoPlayer.Visible = false;
                                if (objBECommon.DsResult.Tables[6].Rows[0]["studentImageTimeStamp"] != DBNull.Value)
                                    lblPic1TimeStamp.Text = objBECommon.DsResult.Tables[6].Rows[0]["studentImageTimeStamp"].ToString();
                                else
                                    lblPic1TimeStamp.Text = string.Empty;

                                if (objBECommon.DsResult.Tables[6].Rows[0]["studentIDImageTimeStamp"] != DBNull.Value)

                                    lblPic2TimeStamp.Text = objBECommon.DsResult.Tables[6].Rows[0]["studentIDImageTimeStamp"].ToString();
                                else
                                    lblPic2TimeStamp.Text = string.Empty;

                                if (objBECommon.DsResult.Tables[6].Rows[0]["StudentImage"].ToString() != "" && objBECommon.DsResult.Tables[6].Rows[0]["StudentImage"] != null)
                                    imgPLExamPic.Src = "data:image/png;base64," + Convert.ToBase64String(objBECommon.DsResult.Tables[6].Rows[0]["StudentImage"] as byte[]);
                                else
                                    imgPLExamPic.Src = "~/Images/noimage.jpg";
                                if (objBECommon.DsResult.Tables[6].Rows[0]["StudentIDImage"].ToString() != "" && objBECommon.DsResult.Tables[6].Rows[0]["StudentIDImage"] != null)
                                    imgPLExamPic1.Src = "data:image/png;base64," + Convert.ToBase64String(objBECommon.DsResult.Tables[6].Rows[0]["StudentIDImage"] as byte[]);
                                else
                                    imgPLExamPic1.Src = "~/Images/noimage.jpg";

                            }
                            else
                            {
                                if (Convert.ToInt32(objBECommon.DsResult.Tables[6].Rows[0]["IsexamiFACE"]) == 1)
                                {
                                    tbAutoProctor.Visible = true;
                                }
                                else
                                {
                                    tbAutoProctor.Visible = false;
                                }
                                trNonProctorImages.Visible = false;
                                tdDesktop.Visible = true;
                                trExamLevel.Visible = true;
                                trVideoPlayer.Visible = true;

                            }

                        }



                    }

                }

            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public string getStreamURL(string StreamType)
        {
            if (StreamType == "Voice")
                return System.Configuration.ConfigurationManager.AppSettings["Streams_Path"].ToString() + "Voice/" + AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()) + ".wav";
            else
                return System.Configuration.ConfigurationManager.AppSettings["Streams_Path"].ToString() + StreamType + "/" + AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()) + ".avi";
        }
        public string getPlayer(string StreamType)
        {

            StringBuilder strMediaPlayer = new StringBuilder();
            //string path = System.Configuration.ConfigurationManager.AppSettings["Streams_Path"].ToString() + AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()) + ".mp4";
            // GetURL();
            string path = streamingurl;
            strMediaPlayer.AppendLine("<video id='myvideo' width='880' height='600' controls>");
            strMediaPlayer.AppendLine("<source type='video/mp4' src=" + path + ">");
            strMediaPlayer.AppendLine("</video>");
            return strMediaPlayer.ToString();
        }

        public System.Drawing.Image getImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            System.Drawing.Image returnImage = System.Drawing.Image.FromStream(ms);
            return returnImage;

        }
        #endregion

        protected void BindAlerts()
        {
            try
            {

                BECommon objBEComon = new BECommon();
                BCommon objBCommon = new BCommon();
                objBEComon.intRoleID = Convert.ToInt32(Session["RoleID"].ToString());
                objBEComon.intAlertID = 4;
                objBCommon.BGetAlerts(objBEComon);
                ddlAlerts.DataSource = objBEComon.DtResult;
                ddlAlerts.DataValueField = "AlertID";
                ddlAlerts.DataTextField = "AlertText";
                ddlAlerts.DataBind();
            }
            catch
            {
            }
        }

        //protected void gvStudentNotes_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        //{
        //    try
        //    {

        //        this.BindExamDetails();
        //    }
        //    catch (Exception Ex)
        //    {
        //        throw Ex;
        //    }
        //}

        protected void gvComments_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            try
            {
                this.LoadData();
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
                //if (Session[BaseClass.EnumPageSessions.TransID] != null)
                //{
                //    gvComments.DataSource = null;
                //    BCommon objBCommon = new BCommon();
                //    BECommon objBECommon = new BECommon();
                //    objBECommon.IntTransID = Convert.ToInt32(AppSecurity.Decrypt(Session[BaseClass.EnumPageSessions.TransID].ToString()));
                //    objBCommon.BGetTransactionComments(objBECommon);
                //    if(objBECommon.DtResult!=null && objBECommon.DtResult.Rows.Count>0)
                //    gvComments.DataSource = objBECommon.DtResult;
                //    else
                //        gvComments.DataSource = new object[] { };
                //}
                if (Session[BaseClass.EnumPageSessions.TransID] != null)
                {

                    BCommon objBCommon = new BCommon();
                    BECommon objBECommon = new BECommon();
                    objBECommon.IntTransID = Convert.ToInt64(AppSecurity.Decrypt(Session[BaseClass.EnumPageSessions.TransID].ToString()));
                    objBECommon.IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID]);
                    objBCommon.BGetTransactionComments(objBECommon);
                    if (objBECommon.DtResult != null && objBECommon.DtResult.Rows.Count > 0)
                    {
                        gvComments.DataSource = objBECommon.DtResult;

                    }
                    else
                        gvComments.DataSource = new object[] { };

                    ViewState["ALERTS"] = objBECommon.DtResult;

                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        protected void btnAddComments_Click(object sender, EventArgs e)
        {
            try
            {
                BCommon objBCommon = new BCommon();
                BECommon objBECommon = new BECommon();
                objBECommon.IntTransID = Convert.ToInt64(AppSecurity.Decrypt(Session[BaseClass.EnumPageSessions.TransID].ToString()));
                objBECommon.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID].ToString());
                objBECommon.StrComments = txtComments.Text.ToString();
                //objBECommon.StrddlComments = getSelectFlag().ToString();
                objBECommon.StrddlComments = ddlFlags.SelectedValue.ToString();
                objBECommon.intAlertID = Convert.ToInt32(ddlAlerts.SelectedValue.ToString());
                objBCommon.BAddComments(objBECommon);
                objBECommon = null;
                objBECommon = null;
                txtComments.Text = string.Empty;
                gvComments.Rebind();
                ddlFlags.SelectedValue = "-1";
                // txtComments.Visible = false;
                ddlAlerts.Items.Clear();

            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        protected void ddlAlerts_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (ddlAlerts.SelectedItem.Text.ToString().ToUpper() == "OTHER")
            {
                //txtComments.Text = string.Empty;
                //txtComments.Visible = true;
                RequiredFieldValidator11.Enabled = true;
                RequiredFieldValidator11.ValidationGroup = "Add";
            }
            else
            {
                //txtComments.Visible = false;
                //txtComments.Text = string.Empty;
                RequiredFieldValidator11.Enabled = false;
                RequiredFieldValidator11.ValidationGroup = string.Empty;
            }
        }

        protected void ddlFlags_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {

            if (!string.IsNullOrEmpty(ddlFlags.SelectedValue.ToString()))
            {
                BECommon objBEComon = new BECommon();
                BCommon objBCommon = new BCommon();
                objBEComon.intRoleID = Convert.ToInt32(Session["RoleID"].ToString());
                objBEComon.intAlertID = Convert.ToInt32(ddlFlags.SelectedValue.ToString());
                objBCommon.BGetAlerts(objBEComon);
                ddlAlerts.DataSource = objBEComon.DtResult;
                ddlAlerts.DataValueField = "AlertID";
                ddlAlerts.DataTextField = "AlertText";
                ddlAlerts.DataBind();
                txtComments.Visible = true;
            }
            else
            {
                txtComments.Visible = false;
                ddlAlerts.Items.Clear();
            }

            //if (ddlFlags.SelectedIndex == 0)
            //{
            //    txtComments.Visible = false;
            //}
        }

        /*
        protected int getSelectFlag()
        {
            int i = 1;
            if (rdGreen.Checked == true)
                i = 1;
            else if (rdOrange.Checked == true)
                i = 2;
            else if (rdRed.Checked == true)
                i = 3;
            else if (rdAlert.Checked == true)
                i = 4;
            return i;
        }
        
        
        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtComments.Text = string.Empty;
        }
        */

        protected void btnBack_Click(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["Type"] == "ExamStatus")
                {
                    Response.Redirect("~/Proctor/ExamStatus.aspx", false);

                }
                if (Request.QueryString["Type"] == "View")
                {

                    Response.Redirect("ViewUserDetails.aspx?Type=E&" + AppSecurity.Encrypt("StudentID=" + Session[BaseClass.EnumPageSessions.StudentID].ToString()), false);
                }
            }
            catch (Exception Ex)
            {
                //ErrorLog.WriteError(Ex);
            }
        }

        protected void gvComments_EditCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {

            if (e.CommandName == "EDIT")
            {
                DataTable objDT = (DataTable)ViewState["ALERTS"];
                gvComments.DataSource = objDT;
                gvComments.DataBind();
            }

        }

        protected void gvComments_DeleteCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            DataTable objDT = (DataTable)ViewState["ALERTS"];
            if (e.CommandName == "DELETE")
            {
                for (int i = 0; i < objDT.Rows.Count; i++)
                {
                    if (e.CommandArgument.ToString() == objDT.Rows[i][0].ToString())
                    {
                        objDT.Rows.RemoveAt(i);
                        objDT.AcceptChanges();
                        BECommon objBECommon = new BECommon();
                        BCommon objBCommon = new BCommon();
                        objBECommon.IntTransID = Convert.ToInt64(AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()));
                        objBECommon.intTypeID = 0;
                        objBECommon.intCommentID = Convert.ToInt32(e.CommandArgument);
                        objBECommon.StrComments = string.Empty;
                        objBCommon.BDeleteUpdateAlerts(objBECommon);


                    }
                    ViewState["ALERTS"] = objDT;
                    gvComments.DataSource = objDT;
                    gvComments.DataBind();
                }


            }
        }



        protected void gvComments_UpdateCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName.ToString().ToUpper() == "UPDATE")
            {
                Telerik.Web.UI.RadTextBox txt = (Telerik.Web.UI.RadTextBox)e.Item.FindControl("txtRuleDescription");
                DataTable objDT = (DataTable)ViewState["ALERTS"];

                BECommon objBECommon = new BECommon();
                BCommon objBCommon = new BCommon();
                objBECommon.IntTransID = Convert.ToInt64(AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()));
                objBECommon.intTypeID = 1;
                objBECommon.intCommentID = Convert.ToInt32(e.CommandArgument);
                objBECommon.StrComments = txt.Text.Trim();
                objBCommon.BDeleteUpdateAlerts(objBECommon);
                ViewState["ALERTS"] = objDT;
                gvComments.DataSource = objDT;
                gvComments.DataBind();
                LoadData();
            }
        }

        protected void gvComments_CancelCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName.ToString().ToUpper() == "CANCEL")
            {
                DataTable objDT = (DataTable)ViewState["ALERTS"];
                gvComments.DataSource = objDT;
                gvComments.DataBind();
            }

        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtComments.Text = string.Empty;
        }

        public string isAllowAttemptsFeatured()
        {
            BECommon objBECommon = new BECommon();
            BCommon objBCommon = new BCommon();

            objBCommon.BGetClientDetails(objBECommon);

            return objBECommon.DsResult.Tables[0].Rows[0]["MaxAttemptsFeatured"].ToString();
        }

        protected void gvexamdetails_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {

            this.BindExamDetails();

        }

        protected void lnkscdule_Click(object sender, EventArgs e)
        {
            BECommon objBECommon = new BECommon();
            BCommon objBCommon = new BCommon();

            objBECommon.IntTransID = Convert.ToInt64(AppSecurity.Decrypt(Session[BaseClass.EnumPageSessions.TransID].ToString()));
            objBECommon.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID].ToString());

            objBCommon.BReenableschedulestatus(objBECommon);
            gvexamdetails.Rebind();



        }

        protected void lnkdownload_Click(object sender, EventArgs e)
        {
            BECommon objBECommon = new BECommon();
            BCommon objBCommon = new BCommon();

            objBECommon.IntTransID = Convert.ToInt64(AppSecurity.Decrypt(Session[BaseClass.EnumPageSessions.TransID].ToString()));
            objBECommon.IntstatusFlag = 1;
            objBCommon.BReenableBeginExamstatus(objBECommon);

        }

        protected void lnklaunch_Click(object sender, EventArgs e)
        {
            BECommon objBECommon = new BECommon();
            BCommon objBCommon = new BCommon();

            objBECommon.IntTransID = Convert.ToInt64(AppSecurity.Decrypt(Session[BaseClass.EnumPageSessions.TransID].ToString()));
            objBECommon.IntstatusFlag = 3;
            objBCommon.BReenableBeginExamstatus(objBECommon);
        }

        protected void lnkbeginexam_Click(object sender, EventArgs e)
        {
            BECommon objBECommon = new BECommon();
            BCommon objBCommon = new BCommon();

            objBECommon.IntTransID = Convert.ToInt64(AppSecurity.Decrypt(Session[BaseClass.EnumPageSessions.TransID].ToString()));
            objBECommon.IntstatusFlag = 3;

            objBCommon.BReenableBeginExamstatus(objBECommon);

        }

    }
}
