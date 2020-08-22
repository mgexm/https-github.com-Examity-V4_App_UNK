using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using BusinessEntities;

namespace SecureProctor.CourseAdmin
{
    public partial class ReportsView : BaseClass
    {
        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BECommon objBECommon = new BECommon();
                BCommon objBCommon = new BCommon();
                objBECommon.iTimeZoneID = Convert.ToInt32(Session["TimeZoneID"].ToString());
                objBCommon.BGetTimeDelay(objBECommon);
                dtpstartdate.SelectedDate = DateTime.UtcNow.AddMinutes(objBECommon.IntResult);
                dtpEnddate.SelectedDate = DateTime.UtcNow.AddMinutes(objBECommon.IntResult);

            }

            this.Page.Title = EnumPageTitles.APPNAME + EnumPageTitles.EXAMPROVIDER_EXAMPROVIDERREPORTS;
            ((LinkButton)this.Page.Master.FindControl("lnkReports")).CssClass = "main_menu_active";

            if (Request.QueryString != null && Request.QueryString.ToString() != null)
            {

                int intReportID = Convert.ToInt32(AppSecurity.Decrypt(Request.QueryString["ReportID"].ToString()));
                int intTypeID = Convert.ToInt32(AppSecurity.Decrypt(Request.QueryString["ReportTypeID"].ToString()));


                if (intTypeID == 1)
                {
                    trSearchCriteria1.Visible = true;
                    // trSearchCriteria2.Visible = false;
                }
                else
                {
                    trSearchCriteria1.Visible = false;
                    // trSearchCriteria2.Visible = true;
                }
            }
        }

        protected void gvReports_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            try
            {
                this.GetReportsData();

            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        protected void BtnExportToExcel_Click(object sender, ImageClickEventArgs e)
        {
            ConfigureExport();
            gvReports.ExportSettings.ExportOnlyData = true;
            gvReports.MasterTableView.ExportToExcel();
        }

        protected void BtnExportToPdf_Click(object sender, ImageClickEventArgs e)
        {
            ConfigureExport();
            gvReports.MasterTableView.ExportToPdf();
        }

        protected void btnReports_Click(object sender, EventArgs e)
        {
            gvReports.Rebind();
        }

        #endregion

        #region Methods

        public void ConfigureExport()
        {
            gvReports.ExportSettings.ExportOnlyData = true;
            gvReports.ExportSettings.IgnorePaging = true;
            gvReports.ExportSettings.OpenInNewWindow = true;
        }

        protected void GetReportsData()
        {
            try
            {
                int intReportType = Convert.ToInt32(AppSecurity.Decrypt(Request.QueryString["ReportTypeID"].ToString()));
                BECommon objBECommon = new BECommon();
                BCommon objBCommon = new BCommon();
                objBECommon.IntRoleID = Convert.ToInt32(Session["RoleID"]);
                if (intReportType == 1)
                {
                    if (dtpstartdate.SelectedDate != null)
                        objBECommon.DateStartDate = Convert.ToDateTime(dtpstartdate.SelectedDate);
                    if (dtpEnddate.SelectedDate != null)
                        objBECommon.DateEndDate = Convert.ToDateTime(dtpEnddate.SelectedDate);
                }
                else
                {
                    objBECommon.strCourseName = txtCourseName.Text.ToString();
                    objBECommon.strExamName = txtExamName.Text.ToString();
                    objBECommon.StrFirstName = txtFirstName.Text.ToString();
                    objBECommon.StrLastName = txtLastName.Text.ToString();
                }
                objBECommon.iReportID = Convert.ToInt32(AppSecurity.Decrypt(Request.QueryString["ReportID"].ToString()));
                objBECommon.IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID]);
                objBECommon.intReportTypeID = intReportType;
                objBCommon.BGetSelectedReport(objBECommon);
                if (objBECommon.DtResult != null && objBECommon.DtResult.Rows.Count > 0)
                {
                    gvReports.DataSource = objBECommon.DtResult;
                    trExportButtons.Visible = true;
                    trGridView.Visible = true;
                }
                else
                {
                    gvReports.DataSource = new Object[0];
                    trExportButtons.Visible = false;
                    trGridView.Visible = true;
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        #endregion
    }
}