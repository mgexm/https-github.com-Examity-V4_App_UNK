using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessEntities;
using BLL;

namespace SecureProctor.Student
{
    public partial class ScheduleExamDetailsConfirmation : BaseClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    //    BEStudent objBEStudent;
                    //    if (Request.QueryString["Type"].ToString() == "Schedule" && Session["Student_Exam"] != null)
                    //    {
                    //        this.Page.Title = EnumPageTitles.APPNAME + EnumPageTitles.STUDENT_SCHEDULEDetails;
                    //        ((LinkButton)this.Page.Master.FindControl("lnkSchedule")).CssClass = "main_menu_active";
                    //        img.Src = "../Images/ImgScheduleexam.png";
                    //        imgCalc.Visible = false;
                    //        imgStickyNotes.Visible = false;
                    //        lblTools.Visible = false;
                    //        objBEStudent = (BEStudent)Session["Student_Exam"];
                    //        lblTransactionID.Text = "N/A";
                    //        lblStudentName.Text = Session["UserName"].ToString().Replace("[ Student ]", "");
                    //        lblCourseName.Text = objBEStudent.strCourseName;
                    //        lblExamName.Text = objBEStudent.strExamName;
                    //        string[] str = Request.QueryString["ScheduleDetails"].ToString().Split(' ');
                    //        lblSlot.Text = str[1].ToString() + " " + str[2].ToString();
                    //        lblDAte.Text = str[0].ToString();
                    //        lblHead.Text = "Selected Exam Details";

                    //        BStudent objBStudent = new BStudent();
                    //        objBStudent.BGetRules(objBEStudent);
                    //        if (objBEStudent.DsResult.Tables[0].Rows.Count > 0)
                    //        {
                    //            gvStudentRules.DataSource = objBEStudent.DsResult.Tables[0];
                    //            gvStudentRules.DataBind();
                    //        }
                    //        else
                    //        {
                    //            gvStudentRules.DataSource = null;
                    //            gvStudentRules.DataBind();
                    //        }
                    //        bool noTools = false;
                    //        if (objBEStudent.DsResult.Tables[1].Rows.Count > 0)
                    //        {
                    //            noTools = true;
                    //            for (int i = 0; i < objBEStudent.DsResult.Tables[1].Rows.Count; i++)
                    //            {
                    //                if (objBEStudent.DsResult.Tables[1].Rows[i]["ToolID"].ToString() == "101")
                    //                    imgCalc.Visible = true;
                    //                if (objBEStudent.DsResult.Tables[1].Rows[i]["ToolID"].ToString() == "102")
                    //                    imgStickyNotes.Visible = true;
                    //            }
                    //        }
                    //        if (noTools == false)
                    //            lblTools.Visible = true;
                    //        trButtons.Visible = true;
                    //        trMessage.Visible = false;
                    //    }
                    //    else if (Request.QueryString["Type"].ToString() == "Schedule" && Session["Student_ReExam"] != null)
                    //    {
                    //        imgCalc.Visible = false;
                    //        imgStickyNotes.Visible = false;
                    //        lblTools.Visible = false;
                    //        this.Page.Title = EnumPageTitles.APPNAME + EnumPageTitles.STUDENT_RESCHEDULE;
                    //        ((LinkButton)this.Page.Master.FindControl("lnkReschedule")).CssClass = "main_menu_active";
                    //        img.Src = "../Images/ImgReschedule.png";

                    //        objBEStudent = (BEStudent)Session["Student_ReExam"];
                    //        lblTransactionID.Text = objBEStudent.IntTransID.ToString();
                    //        lblStudentName.Text = Session["UserName"].ToString().Replace("[ Student ]", "");
                    //        lblCourseName.Text = objBEStudent.DtResult.Rows[0]["CourseName"].ToString();
                    //        lblExamName.Text = objBEStudent.DtResult.Rows[0]["ExamName"].ToString();
                    //        string[] str = Request.QueryString["ScheduleDetails"].ToString().Split(' ');
                    //        lblSlot.Text = str[1].ToString() + " " + str[2].ToString();
                    //        lblDAte.Text = str[0].ToString();
                    //        lblHead.Text = "ReScheduled Exam Details";
                    //        BStudent objBStudent = new BStudent();
                    //        objBStudent.BGetRules(objBEStudent);

                    //        if (objBEStudent.DsResult.Tables[0].Rows.Count > 0)
                    //        {
                    //            gvStudentRules.DataSource = objBEStudent.DsResult.Tables[0];
                    //            gvStudentRules.DataBind();
                    //        }
                    //        else
                    //        {
                    //            gvStudentRules.DataSource = null;
                    //            gvStudentRules.DataBind();
                    //        }
                    //        bool noTools = false;
                    //        if (objBEStudent.DsResult.Tables[1].Rows.Count > 0)
                    //        {
                    //            noTools = true;
                    //            for (int i = 0; i < objBEStudent.DsResult.Tables[1].Rows.Count; i++)
                    //            {
                    //                if (objBEStudent.DsResult.Tables[1].Rows[i]["ToolID"].ToString() == "101")
                    //                    imgCalc.Visible = true;
                    //                if (objBEStudent.DsResult.Tables[1].Rows[i]["ToolID"].ToString() == "102")
                    //                    imgStickyNotes.Visible = true;
                    //            }
                    //        }
                    //        if (noTools == false)
                    //            lblTools.Visible = true;
                    //        trButtons.Visible = true;
                    //        trMessage.Visible = false;
                    //    }
                }
            }
            catch (Exception )
            {
                // ErrorLog.WriteError(Ex);
            }
        }

        protected void setExamDetails()
        {
            BEStudent objBEStudent;
            if (Request.QueryString["Type"].ToString() == "Schedule" && Session["Student_Exam"] != null)
            {
                this.Page.Title = EnumPageTitles.APPNAME + EnumPageTitles.STUDENT_SCHEDULEDetails;
                ((LinkButton)this.Page.Master.FindControl("lnkSchedule")).CssClass = "main_menu_active";
                img.Src = "../Images/ImgScheduleExam1.png";
                imgCalc.Visible = false;
                imgStickyNotes.Visible = false;
                lblTools.Visible = false;
                objBEStudent = (BEStudent)Session["Student_Exam"];
                lblTransactionID.Text = "N/A";
                lblStudentName.Text = Session["UserName"].ToString().Replace("[ Student ]", "");
                lblCourseName.Text = objBEStudent.strCourseName;
                lblExamName.Text = objBEStudent.strExamName;
                string[] str = Request.QueryString["ScheduleDetails"].ToString().Split(' ');
                lblSlot.Text = str[1].ToString() + " " + str[2].ToString();
                lblDAte.Text = str[0].ToString();
                lblHead.Text = "Selected Exam Details";

                BStudent objBStudent = new BStudent();
                objBStudent.BGetRules(objBEStudent);
                if (objBEStudent.DsResult.Tables[0].Rows.Count > 0)
                {
                    gvStudentRules.DataSource = objBEStudent.DsResult.Tables[0];
                   // gvStudentRules.Rebind();
                }
                else
                {
                    gvStudentRules.DataSource = new object[] { };
                    // gvStudentRules.DataBind();
                }
                bool noTools = false;
                if (objBEStudent.DsResult.Tables[1].Rows.Count > 0)
                {
                    noTools = true;
                    for (int i = 0; i < objBEStudent.DsResult.Tables[1].Rows.Count; i++)
                    {
                        if (objBEStudent.DsResult.Tables[1].Rows[i]["ToolID"].ToString() == "101")
                            imgCalc.Visible = true;
                        if (objBEStudent.DsResult.Tables[1].Rows[i]["ToolID"].ToString() == "102")
                            imgStickyNotes.Visible = true;
                    }
                }
                if (noTools == false)
                    lblTools.Visible = true;
                trButtons.Visible = true;
                trMessage.Visible = false;
            }
            else if (Request.QueryString["Type"].ToString() == "Schedule" && Session["Student_ReExam"] != null)
            {
                imgCalc.Visible = false;
                imgStickyNotes.Visible = false;
                lblTools.Visible = false;
                this.Page.Title = EnumPageTitles.APPNAME + EnumPageTitles.STUDENT_RESCHEDULE;
                ((LinkButton)this.Page.Master.FindControl("lnkReschedule")).CssClass = "main_menu_active";
                img.Src = "../Images/ImgReschedule.png";

                objBEStudent = (BEStudent)Session["Student_ReExam"];
                lblTransactionID.Text = objBEStudent.IntTransID.ToString();
                lblStudentName.Text = Session["UserName"].ToString().Replace("[ Student ]", "");
                lblCourseName.Text = objBEStudent.DtResult.Rows[0]["CourseName"].ToString();
                lblExamName.Text = objBEStudent.DtResult.Rows[0]["ExamName"].ToString();
                string[] str = Request.QueryString["ScheduleDetails"].ToString().Split(' ');
                lblSlot.Text = str[1].ToString() + " " + str[2].ToString();
                lblDAte.Text = str[0].ToString();
                lblHead.Text = "ReScheduled Exam Details";
                BStudent objBStudent = new BStudent();
                objBStudent.BGetRules(objBEStudent);

                if (objBEStudent.DsResult.Tables[0].Rows.Count > 0)
                {
                    gvStudentRules.DataSource = objBEStudent.DsResult.Tables[0];
                    // gvStudentRules.Rebind();
                }
                else
                {
                    gvStudentRules.DataSource = new object[] { };

                }
                bool noTools = false;
                if (objBEStudent.DsResult.Tables[1].Rows.Count > 0)
                {
                    noTools = true;
                    for (int i = 0; i < objBEStudent.DsResult.Tables[1].Rows.Count; i++)
                    {
                        if (objBEStudent.DsResult.Tables[1].Rows[i]["ToolID"].ToString() == "101")
                            imgCalc.Visible = true;
                        if (objBEStudent.DsResult.Tables[1].Rows[i]["ToolID"].ToString() == "102")
                            imgStickyNotes.Visible = true;
                    }
                }
                if (noTools == false)
                    lblTools.Visible = true;
                trButtons.Visible = true;
                trMessage.Visible = false;
            }
        }

        protected void gvStudentRules_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            try
            {
                setExamDetails();
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["Student_Exam"] != null && Request.QueryString["Type"] == "Schedule")
                {

                    BStudent objBStudent = new BStudent();
                    BEStudent objBEStudent = (BEStudent)Session["Student_Exam"];
                    objBEStudent.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID].ToString());
                    objBEStudent.strUserName = Session["EmailID"].ToString();
                    objBEStudent.dtExam = Convert.ToDateTime(lblDAte.Text.ToString() + " " + lblSlot.Text.ToString());
                    objBEStudent.strTimeZone = Session["SchTime"].ToString();
                    objBStudent.BScheduleAnExam(objBEStudent);
                    trButtons.Visible = false;
                    trMessage.Visible = true;
                    Session["TimeZoneID"] = Session["SchTime"].ToString();
                    switch (Session["SchTime"].ToString())
                    {
                        case "1": Session["TimeZone"] = "CT";
                            break;
                        case "2": Session["TimeZone"] = "ET";
                            break;
                        case "3": Session["TimeZone"] = "PT";
                            break;
                        case "4": Session["TimeZone"] = "MT";
                            break;
                    }
                    LinkButton lblTzone = this.Master.FindControl("lbtnTimeZone") as LinkButton;
                    lblTzone.Text = "[ " + Session["TimeZone"].ToString() + " ]";
                    //lblMsg.Text = "Your Exam is Scheduled Successfully. An email has been sent to you providing instructions";
                    lblMsg.Text = Resources.ResMessages.Student_ExamdetConfirmSchedule;
                    lblTransactionID.Text = objBEStudent.IntTransID.ToString();
                    //try
                    //{
                    //    EmailMsg obj = new EmailMsg();
                    //    obj.StudentExamReceipt(Convert.ToInt32(objBEStudent.IntTransID.ToString()), objBEStudent.IntUserID, objBEStudent.strUserName);
                    //    obj = null;
                    //}
                    //catch
                    //{
                    //}

                    try
                    {

                        BEMail objBEMail = new BEMail();
                        BMail objBMail = new BMail();
                        objBEMail.IntUserID = 0;
                        objBEMail.IntTransID = objBEStudent.IntTransID;
                        objBEMail.StrTemplateName = BaseClass.EnumEmails.StudentExamReceipt.ToString();

                        //objBMail.BSendEmail(objBEMail);
                        //objBEMail.StrTemplateName = BaseClass.EnumEmails.ExamConfirmationProctorFYI.ToString();

                        objBMail.BSendEmail(objBEMail);


                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                else if (Session["Student_ReExam"] != null && Request.QueryString["Type"] == "Schedule")
                {
                    BStudent objBStudent = new BStudent();
                    BEStudent objBEStudent = (BEStudent)Session["Student_ReExam"];
                    objBEStudent.dtExam = Convert.ToDateTime(Request.QueryString["ScheduleDetails"].ToString());
                    objBEStudent.IntTransID = Convert.ToInt64(lblTransactionID.Text.Trim().ToString());
                    objBEStudent.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID].ToString());
                    objBEStudent.strUserName = Session["EmailID"].ToString();
                    objBEStudent.strTimeZone = Session["SchTime"].ToString();
                    objBStudent.BReScheduleAnExam(objBEStudent);
                    trButtons.Visible = false;
                    trMessage.Visible = true;
                    Session["TimeZoneID"] = Session["SchTime"].ToString();
                    switch (Session["SchTime"].ToString())
                    {
                        case "1": Session["TimeZone"] = "CT";
                            break;
                        case "2": Session["TimeZone"] = "ET";
                            break;
                        case "3": Session["TimeZone"] = "PT";
                            break;
                        case "4": Session["TimeZone"] = "MT";
                            break;
                    }
                    LinkButton lblTzone = this.Master.FindControl("lbtnTimeZone") as LinkButton;
                    lblTzone.Text = "[ " + Session["TimeZone"].ToString() + " ]";
                    //lblMsg.Text = "Your Exam is ReScheduled Successfully. An email has been sent to you providing instructions";
                    lblMsg.Text = Resources.ResMessages.Student_ExamdetConfirmReSchedule;

                    try
                    {

                        BEMail objBEMail = new BEMail();
                        BMail objBMail = new BMail();
                        objBEMail.IntUserID = 0;
                        objBEMail.IntTransID = Convert.ToInt64(lblTransactionID.Text.Trim().ToString()); 
                        objBEMail.StrTemplateName = BaseClass.EnumEmails.ReScheduleConfirmation.ToString();

                        //objBMail.BSendEmail(objBEMail);
                        //objBEMail.StrTemplateName = BaseClass.EnumEmails.ReScheduleConfirmationProctorFYI.ToString();

                        objBMail.BSendEmail(objBEMail);

                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    //try
                    //{
                    //    EmailMsg obj = new EmailMsg();
                    //    obj.StudentExamRescheduleReceipt(Convert.ToInt32(AppSecurity.Decrypt(Request.QueryString["ReTransID"].ToString())), objBEStudent.IntUserID, objBEStudent.strUserName);
                    //    obj = null;
                    //}
                    //catch
                    //{
                    //}
                }

            }
            catch (Exception )
            {
                //  ErrorLog.WriteError(Ex);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //if (Request.QueryString["Type"].ToString() == "Schedule")
            //    Response.Redirect("ScheduleExam.aspx?Type=Schedule");
            //else
            //    Response.Redirect("ScheduleExam.aspx?TransID=" + Request.QueryString["ReTransID"].ToString());
            if (Request.QueryString["Type"].ToString() == "Schedule" && Session["Student_Exam"] != null)
            {
                Response.Redirect("ScheduleExam.aspx?Type=Schedule");
            }
            else if (Request.QueryString["Type"].ToString() == "Schedule" && Session["Student_ReExam"] != null)
            {
                if (lblTransactionID.Text != "" && lblTransactionID.Text != "N/A")
                {
                    Response.Redirect("ScheduleExam.aspx?TransID=" + AppSecurity.Encrypt(lblTransactionID.Text.ToString()));
                }
            }
        }
    }
}
