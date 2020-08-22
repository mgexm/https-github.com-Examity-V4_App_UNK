using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessEntities;
using BLL;
using Telerik.Web.UI;
using System.Data;

namespace SecureProctor.Student
{
    public partial class RescheduleExam : BaseClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Page.Title = EnumPageTitles.APPNAME + EnumPageTitles.STUDENT_RESCHEDULE;
            ((LinkButton)this.Page.Master.FindControl("lnkReschedule")).CssClass = "main_menu_active";
        }

        protected void gvReschedule_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
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
                BEStudent objBEStudent = new BEStudent();
                BStudent objBStudent = new BStudent();
                objBEStudent.IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID].ToString());
                objBStudent.BGetStudentGetPendingExams(objBEStudent);
                gvReschedule.DataSource = objBEStudent.DtResult;
                objBEStudent = null;
                objBStudent = null;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        protected void gvReschedule_ItemCommand(object sender, GridCommandEventArgs e)
        {

            if (e.CommandName == "ReSchedule")
            {

                Response.Redirect("ScheduleExam.aspx?TransID=" + AppSecurity.Encrypt(e.CommandArgument.ToString()), false);
            }

            if (e.CommandName == "Canel")
            {

                Response.Redirect("ExamCancelConfirmation.aspx?TransID=" + AppSecurity.Encrypt(e.CommandArgument.ToString()), false);

            }

        }

    }

}