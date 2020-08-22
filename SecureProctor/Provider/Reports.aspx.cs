using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using CarlosAg.ExcelXmlWriter;
using System.Data;
using BLL;
using BusinessEntities;
using System.Data.SqlClient;
using System.Configuration;

namespace SecureProctor.Provider
{
    public partial class Reports : BaseClass, IPostBackEventHandler
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Page.Title = EnumPageTitles.APPNAME + EnumPageTitles.EXAMPROVIDER_EXAMPROVIDERREPORTS;
                ((LinkButton)this.Page.Master.FindControl("lnkReports")).CssClass = "main_menu_active";

                divTestSummaryReport.Attributes["onClick"] = ClientScript.GetPostBackEventReference(this, "TestSummaryReport");
                divTestResultReport.Attributes["onClick"] = ClientScript.GetPostBackEventReference(this, "TestResultReport");
                divAppointmentScheduleReport.Attributes["onClick"] = ClientScript.GetPostBackEventReference(this, "AppointmentScheduleReport");

            }

        }

        public void RaisePostBackEvent(string eventArgument)
        {

            if (!string.IsNullOrEmpty(eventArgument))
            {
                if (eventArgument == "TestSummaryReport" || eventArgument == "TestResultReport" || eventArgument == "AppointmentScheduleReport")
                {
                    Div_Click(eventArgument);
                }
            }
        }
        protected void Div_Click(string strReportType)
        {
            switch (strReportType)
            {


                case "TestSummaryReport":


                    Response.Redirect("TestSummaryReport.aspx");

                    break;

                case "TestResultReport":


                    Response.Redirect("TestResultReport.aspx");

                    break;
                case "AppointmentScheduleReport":


                    Response.Redirect("AppointmentScheduleReport.aspx");

                    break;


            }

        }
        protected void ResetTabStyles()
        {
          //  divExamstatusreport.Attributes.Add("class", "tab_s");
          //  divStudentScheduleExam.Attributes.Add("class", "tab_s");
            divTestSummaryReport.Attributes.Add("class", "tab_s");
        }
        


    }
}
