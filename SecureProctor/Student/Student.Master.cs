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
    public partial class Student : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                lnkHome.Focus();

            if (Session[BaseClass.EnumPageSessions.USERID] != null)
                lblUser.Text = Session["UserName"].ToString();
            else
                Response.Redirect(BaseClass.EnumAppPage.LOGIN);


            if (Session["RoleID"].ToString() != "6")
           
                    Response.Redirect(BaseClass.EnumAppPage.ERRORMESSAGE, true);


            //lblDate.Text = "Date: " + CommonFunctions.GetTime(DateTime.UtcNow,Session["TimeZone"].ToString()).ToString();
            BECommon objBECommon = new BECommon();
            BCommon objBCommon = new BCommon();
            objBECommon.iTimeZoneID = Convert.ToInt32(Session["TimeZoneID"].ToString());
            objBCommon.BGetTimeDelay(objBECommon);
            //lblDate.Text = "Date: " + CommonFunctions.GetTime(DateTime.UtcNow, Session["TimeZone"].ToString()).ToString();
            //lblDate.Text = "Date: " + DateTime.UtcNow.AddMinutes(objBECommon.IntResult).ToString();
            //lbtnTimeZone.Text = "[ " + Session["TimeZone"].ToString() + " ]";
            string[] strtimezone = Session["TimeZone"].ToString().Split('(');
            lbtnTimeZone.Text = strtimezone[0].ToString() + ":" + DateTime.UtcNow.AddMinutes(objBECommon.IntResult).ToString("MM/dd/yyyy hh:mm tt");
            //lblTimeZone.Text = "[ <b>Time Zone : </b>" + Session["TimeZone"].ToString() + " ]";
            // lbtnTimeZone.Text = strtimezone[0].ToString();

            //lblDate.Text = DateTime.UtcNow.AddMinutes(objBECommon.IntResult).ToString("MM/dd/yyyy hh:mm:ss tt");
            BEStudent objBEStudent = new BEStudent();
            BStudent objBStudent = new BStudent();
            objBEStudent.IntUserID = Convert.ToInt32(Session[SecureProctor.BaseClass.EnumPageSessions.USERID].ToString());
            objBEStudent.IntProviderID = 0;
            objBEStudent.strExamName = string.Empty;
            objBStudent.BGetStudentTransactions(objBEStudent);
            if (objBEStudent.DtResult.Rows.Count > 0)
            {
                if (Convert.ToBoolean(objBEStudent.DtResult.Rows[0]["StudentUploadFeature"]) == false)
                {
                    lnkUploadfiles.Visible = false;
                }
                else
                {
                    lnkUploadfiles.Visible = true;

                }

            }
            if (this.Page.GetType().Name.ToString() == "student_myprofile_aspx")
            {
                ((Label)this.FindControl("StudentContent").FindControl("lblHeader1")).Focus();
            }
            else if (this.Page.GetType().Name.ToString() == "student_scheduleexam_aspx" || this.Page.GetType().Name.ToString() == "student_examtools_aspx" || this.Page.GetType().Name.ToString() == "student_examuploadfiles_aspx")
            {
                ((Image)this.FindControl("StudentContent").FindControl("imgHead")).Focus();
            }
            else if (this.Page.GetType().Name.ToString() == "student_myexams_aspx" || this.Page.GetType().Name.ToString() == "student_startanexam_aspx" || this.Page.GetType().Name.ToString() == "student_examprocess_aspx")
            {
                ((Image)this.FindControl("StudentContent").FindControl("imgHead")).Focus();
            }
            
        }

        protected void lnkTab_Click(object sender, EventArgs e)
        {
            LinkButton lnk = (LinkButton)sender;

            switch (lnk.CommandName.ToString())
            {
                case "HOME":
                    Response.Redirect(BaseClass.EnumAppPage.STUDENT_HOME);
                    break;
                case "MYEXAMS":
                    Response.Redirect(BaseClass.EnumAppPage.STUDENT_MYEXAMS);
                    break;
                case "SCHEDULEANEXAM":
                    //Response.Redirect("ScheduleStep1.aspx");
                    Response.Redirect(BaseClass.EnumAppPage.STUDENT_SCHEDULE);
                    break;
                case "RESCHEDULEANEXAM":
                    Response.Redirect(BaseClass.EnumAppPage.STUDENT_RESCHEDULE);
                    break;
                case "UPLOADFILES":
                    Response.Redirect(BaseClass.EnumAppPage.STUDENT_EamTools);
                    break;
                case "STARTANEXAM":
                    Response.Redirect(BaseClass.EnumAppPage.STUDENT_STARTEXAM);
                    break;
                case "REPORTS":
                    Response.Redirect(BaseClass.EnumAppPage.STUDENT_REPORTS);
                    break;
                case "MYPROFILE":
                    Response.Redirect(BaseClass.EnumAppPage.STUDENT_MYPROFILE);
                    break;
                case "LOGOUT":
                    Session.Abandon();
                    Response.Redirect(BaseClass.EnumAppPage.COMMON_LOGOUT);
                    break;
            }
        }

        protected void lbtnTimeZone_Click(object sender, EventArgs e)
        {
            Response.Redirect(BaseClass.EnumAppPage.STUDENT_MYPROFILE.ToString());
        }
    }
}
