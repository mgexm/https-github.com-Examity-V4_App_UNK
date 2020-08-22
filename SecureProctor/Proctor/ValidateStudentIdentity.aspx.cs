using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessEntities;
using BLL;
using Telerik.Web.UI;
using Telerik.Web.UI.Skins;

namespace SecureProctor.Proctor
{
    public partial class ValidateStudentIdentity : BaseClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Page.Title = EnumPageTitles.APPNAME + EnumPageTitles.PROCTOR_VALIDATESTUDENTIDENTITY;
                ((LinkButton)this.Page.Master.FindControl("lnkValidate")).CssClass = "main_menu_active";
                //calDate.SelectedDate = DateTime.Now;
                BECommon objBECommon = new BECommon();
                BCommon objBCommon = new BCommon();
                objBECommon.iTimeZoneID = Convert.ToInt32(Session["TimeZoneID"]);
                objBCommon.BGetTimeDelay(objBECommon);
                calDate.SelectedDate = DateTime.UtcNow.AddMinutes(objBECommon.IntResult);
            }
        }
        protected void btnBlockedDates_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("BlockedDates.aspx");
        }
        protected void gvStudentExams_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
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
                BEProctor objBEProctor = new BEProctor();
                BProctor objBProctor = new BProctor();
                objBEProctor.StrDate = calDate.SelectedDate.ToShortDateString();
                objBEProctor.dtDate = calDate.SelectedDate;
                objBEProctor.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID]);
                objBProctor.BGetProctorExams(objBEProctor);
                gvStudentExams.DataSource = objBEProctor.DtResult;
                objBEProctor = null;
                objBProctor = null;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        protected void gvStudentExams_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "VIEWFIRSTSTUDENT")
            {
                LinkButton lnkStudentFirstName = (LinkButton)e.Item.FindControl("lnkStudentFirstName");
                int StudentID = int.Parse(lnkStudentFirstName.CommandArgument.ToString());

                //Response.Redirect("ScheduleExam.aspx?TransID=" + AppSecurity.Encrypt(e.CommandArgument.ToString()), false);
                Response.Redirect("ViewUserDetails.aspx?Type=V&" + AppSecurity.Encrypt("StudentID=" + StudentID), false);
            }
            else if (e.CommandName == "VIEWLASTSTUDENT")
            {
                LinkButton lnkStudentLastName = (LinkButton)e.Item.FindControl("lnkStudentLastName");
                int StudentID = int.Parse(lnkStudentLastName.CommandArgument.ToString());

                //Response.Redirect("ScheduleExam.aspx?TransID=" + AppSecurity.Encrypt(e.CommandArgument.ToString()), false);
                Response.Redirect("ViewUserDetails.aspx?Type=V&" + AppSecurity.Encrypt("StudentID=" + StudentID), false);
            }
            else if (e.CommandName == "VIEWEXAM")
            {
                string ExamTransID = e.CommandArgument.ToString();
                string[] strSplit = ExamTransID.Split('-');
                BEProctor objBEProctor = new BEProctor();
                BProctor objBProctor = new BProctor();

                objBEProctor.IntTransID = Convert.ToInt64(strSplit[0].ToString());

                //objBProctor.BGetStudentValidationStatus(objBEProctor);
                Response.Redirect("ProctorExamView.aspx?TransID=" + AppSecurity.Encrypt(strSplit[0].ToString()));

                //if (objBEProctor.strOTSessionID != string.Empty && objBEProctor.strStatus != "1")
                //{
                //    //if (objBEProctor.strStatus == "1")
                //    //NextPage = "IdentityVerification.aspx";
                //    lblError.Text = "";
                //    lblError.Visible = false;
                //    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                //    sb.Append("var win = window.open('ExamView.aspx?TransID=" + AppSecurity.Encrypt(strSplit[0].ToString()) + "&OTSessionID=" + AppSecurity.Encrypt(objBEProctor.strOTSessionID) + "','_blank','width='+screen.width+',height='+screen.height+',fullscreen=yes,resizable=no,toolbar=no,menubar=no,location=no');");

                //    sb.Append("if (win == null || typeof(win) == 'undefined' || win.test == 'undefined')alert('The popup was blocked. You must allow popups to use this site.');");
                //    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowSuccess", sb.ToString(), true);
                //    objBEProctor = null;
                //    objBProctor = null;
                //}
                //else
                //{
                //    lblError.Text = "Student has no active sessions for this exam.";
                //    lblError.Visible = true;
                //}
            }

            else if (e.CommandName == "VIEWEXAMDETAILS")
            {

                LinkButton lnkExamName = (LinkButton)e.Item.FindControl("lnkExamName");
                int ExamID = int.Parse(lnkExamName.CommandArgument.ToString());
                ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(760/2);var Mtop = (screen.height/2)-(700/2);window.open('ExamDetails.aspx?TransID=" + AppSecurity.Encrypt(lnkExamName.CommandArgument.ToString()) + "', null, 'height=400,width=800,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);


                //Response.Redirect("ViewUserDetails.aspx?Type=V&" + AppSecurity.Encrypt("StudentID=" + StudentID), false);

            }
        }

        protected void calDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // DateTime selecteddate= calDate.SelectedDate;
                gvStudentExams.Rebind();
            }
            catch
            {
            }
        }


        protected void gvStudentExams_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem item = e.Item as GridDataItem;
                ImageButton lnkStatus = item.FindControl("btnWebcam") as ImageButton;
                //lnkStatus.ImageUrl = "~/Images/webcam_blue.png";

            }
        }
    }
}
