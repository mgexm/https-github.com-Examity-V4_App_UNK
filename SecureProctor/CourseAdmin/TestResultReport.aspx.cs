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
using System.IO;
using SecureProctor;
using System.Configuration;

namespace SecureProctor.CourseAdmin
{
    public partial class TestResultReport : BaseClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                BECommon objBECommon = new BECommon();
                BCommon objBCommon = new BCommon();
                objBECommon.iTimeZoneID = Convert.ToInt32(Session["TimeZoneID"]);
                objBCommon.BGetTimeDelay(objBECommon);
                txtFromDate.SelectedDate = DateTime.UtcNow.AddMinutes(objBECommon.IntResult);
                txtToDate.SelectedDate = DateTime.UtcNow.AddMinutes(objBECommon.IntResult);
                LoadCourseDetails();
                gvReports.DataSource = new object[] { };
                gvReports.DataBind();

            }
        }

        protected void LoadCourseDetails()
        {
            try
            {
                BEProvider objBEProvider = new BEProvider();
                BProvider objBProvider = new BProvider();
                objBEProvider.IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID]);

                objBProvider.BGetAllCourseDetails(objBEProvider);
                if (objBEProvider.DtResult.Rows.Count > 0)
                {
                    rcbCourses.DataSource = objBEProvider.DtResult;
                    rcbCourses.DataTextField = "CourseName";
                    rcbCourses.DataValueField = "CourseID";
                    rcbCourses.DataBind();
                }
                gvReports.DataSource = new object[] { };
                gvReports.DataBind();

            }
            catch (Exception Ex)
            {
                ErrorHandlers.ErrorLog.WriteError(Ex);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string ids = GetCourseIds();
            this.LoadTestResultReport(ids);
        }
        protected string GetCourseIds()
        {
            string ClientIds = "'0',";

            try
            {
                if (rcbCourses.CheckedItems.Count != rcbCourses.Items.Count)
                {
                    foreach (RadComboBoxItem chkClient in rcbCourses.CheckedItems)
                    {
                        if (chkClient.Checked)
                        {
                            ClientIds = ClientIds + "'" + chkClient.Value + "',";
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
        protected void BtnExportToExcel_Click(object sender, EventArgs e)
        {

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
                string ids = GetCourseIds();
                LoadTestResultReport(ids);
            }
            catch (Exception Ex)
            {
                ErrorHandlers.ErrorLog.WriteError(Ex);
            }
        }

        protected void gvReports_PageSizeChanged(object sender, GridPageSizeChangedEventArgs e)
        {

        }

        protected void gvReports_ItemDataBound(object sender, GridItemEventArgs e)
        {



        }

        protected void gvReports_ItemCommand(object sender, GridCommandEventArgs e)
        {

        }


        protected void LoadTestResultReport(string ids)
        {

            BEAdmin objBEAdmin = new BEAdmin();
            BAdmin objBAdmin = new BAdmin();
            objBEAdmin.strCourseID = ids;
            objBEAdmin.strExamStartDate = txtFromDate.SelectedDate.Value;
            objBEAdmin.strExamEndDate = txtToDate.SelectedDate.Value;



            objBEAdmin.IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID]);
            objBAdmin.BGetTestResultReportDetails(objBEAdmin);

            gvReports.DataSource = objBEAdmin.DtResult;
            gvReports.DataBind();
            ViewState["gvReports"] = objBEAdmin.DtResult;

        }

    }
}