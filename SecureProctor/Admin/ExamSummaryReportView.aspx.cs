using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using BusinessEntities;
using Telerik.Web.UI;
using System.Data;

namespace SecureProctor.Admin
{
    public partial class ExamSummaryReportView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCourseDetails();
            }
        }

        protected void LoadCourseDetails()
        {
            try
            {
                BEAdmin objBEAdmin = new BEAdmin();
                BAdmin objBAdmin = new BAdmin();

                objBAdmin.BGetAllCourseDetails(objBEAdmin);

                rcbCourses.DataSource = objBEAdmin.DtResult;
                rcbCourses.DataTextField = "CourseName";
                rcbCourses.DataValueField = "CourseID";
                rcbCourses.DataBind();
            }
            catch (Exception Ex)
            {
                ErrorHandlers.ErrorLog.WriteError(Ex);
            }
        }

        //for populating the grid
        protected void LoadSummaryReport(string ids)
        {
            try
            {
                BEAdmin objBEAdmin = new BEAdmin();
                BAdmin objBAdmin = new BAdmin();

                objBEAdmin.strCourseID = ids;
                objBAdmin.BGetExamSummaryReportDetails(objBEAdmin);

                gvReports.DataSource = objBEAdmin.DtResult;
                gvReports.DataBind();

                ViewState["gvReports"] = objBEAdmin.DtResult;
            }
            catch (Exception Ex)
            {
                ErrorHandlers.ErrorLog.WriteError(Ex);
            }
        }

        protected string GetCourseIds()
        {
            string ClientIds = "0,";
            
            try
            {
                if (rcbCourses.CheckedItems.Count != rcbCourses.Items.Count)
                {
                    foreach (RadComboBoxItem chkClient in rcbCourses.CheckedItems)
                    {
                        if (chkClient.Checked)
                        {
                            ClientIds = ClientIds + chkClient.Value + ",";
                        }
                    }
                }
                ClientIds = ClientIds.Substring(0, ClientIds.Length - 1);
            }
            catch (Exception Ex)
            {
                ErrorHandlers.ErrorLog.WriteError(Ex);
            }

            return ClientIds;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string ids = GetCourseIds();
            LoadSummaryReport(ids);
        }

        protected void ddlClients_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {

        }

        protected void gvReports_ItemCommand(object sender, GridCommandEventArgs e)
        {
            //GridDataItem item = e.Item as GridDataItem;
            //string courseId = item.GetDataKeyValue("CourseID").ToString();
            //string examId = item.GetDataKeyValue("ExamID").ToString();

            //if (e.CommandName == "scheduled")
            //{                   
            //    Response.Redirect("AppointmentDetails.aspx?sch="+AppSecurity.Encrypt("true")+"&cid="+AppSecurity.Encrypt(courseId)+"&eid="+AppSecurity.Encrypt(examId),false);
            //}
            //else if (e.CommandName == "unscheduled")
            //{
            //    Response.Redirect("AppointmentDetails.aspx?sch=" + AppSecurity.Encrypt("false") + "&cid=" + AppSecurity.Encrypt(courseId) + "&eid=" + AppSecurity.Encrypt(examId), false);
            //}
        }

        protected void hplnkScheduledAppointments_Click(object sender, EventArgs e)
        {
            LinkButton lnkSch = (LinkButton)sender;
            string[] ids = lnkSch.CommandArgument.ToString().Split(',');
            string courseId = ids[0];
            string examId = ids[1];

            Response.Redirect("AppointmentDetails.aspx?sch=" + AppSecurity.Encrypt("true") + "&cid=" + AppSecurity.Encrypt(courseId) + "&eid=" + AppSecurity.Encrypt(examId), false);
        }

        protected void hplnkUnScheduledAppointments_Click(object sender, EventArgs e)
        {
            LinkButton lnkSch = (LinkButton)sender;
            string[] ids = lnkSch.CommandArgument.ToString().Split(',');
            string courseId = ids[0];
            string examId = ids[1];

            Response.Redirect("AppointmentDetails.aspx?sch=" + AppSecurity.Encrypt("false") + "&cid=" + AppSecurity.Encrypt(courseId) + "&eid=" + AppSecurity.Encrypt(examId), false);
        }

        protected void gvReports_PageIndexChanged(object sender, GridPageChangedEventArgs e)
        {
            gvReports.CurrentPageIndex = e.NewPageIndex;
            DataTable dt = (DataTable)ViewState["gvReports"];
            gvReports.DataSource = dt;
            gvReports.DataBind();
        }

        protected void gvReports_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            try
            {
                //string ids = GetCourseIds();
                //LoadSummaryReport(ids);
            }
            catch (Exception Ex)
            {
                ErrorHandlers.ErrorLog.WriteError(Ex);
            }
        }

        protected void gvReports_PageSizeChanged(object sender, GridPageSizeChangedEventArgs e)
        {   
            DataTable dt = (DataTable)ViewState["gvReports"];
            gvReports.DataSource = dt;
            gvReports.DataBind();
        }

        protected void gvReports_ItemDataBound(object sender, GridItemEventArgs e)
        {
            GridDataItem item = e.Item as GridDataItem;
            if (item != null)
            {
                //Scheduled Appointments
                LinkButton lnkBtnSch = item.FindControl("hplnkScheduledAppointments") as LinkButton;

                if (lnkBtnSch != null)
                {
                    if (lnkBtnSch.Text == "0")
                    {
                        lnkBtnSch.Font.Underline = false;
                        lnkBtnSch.ForeColor = System.Drawing.Color.Black;
                        lnkBtnSch.Enabled = false;
                    }
                }

                //UnScheduled Appointments
                LinkButton lnkBtnUnSch = item.FindControl("hplnkUnScheduledAppointments") as LinkButton;

                if (lnkBtnUnSch != null)
                {
                    if (lnkBtnUnSch.Text == "0")
                    {
                        lnkBtnUnSch.Font.Underline = false;
                        lnkBtnUnSch.ForeColor = System.Drawing.Color.Black;
                        lnkBtnUnSch.Enabled = false;
                    }
                }
            }
            
        }
    }
}