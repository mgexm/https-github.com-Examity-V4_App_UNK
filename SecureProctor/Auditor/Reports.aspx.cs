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

namespace SecureProctor.Auditor
{
    public partial class Reports : BaseClass, IPostBackEventHandler
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Page.Title = EnumPageTitles.APPNAME + EnumPageTitles.Auditor_AuditorREPORTS;
            ((LinkButton)this.Page.Master.FindControl("lnkReports")).CssClass = "main_menu_active";
            //divExamstatusreport.Attributes["onClick"] = ClientScript.GetPostBackEventReference(this, "Examstatusreport");
            //divBillingReport.Attributes["onClick"] = ClientScript.GetPostBackEventReference(this, "Billingreport");
            divTestSummaryReport.Attributes["onClick"] = ClientScript.GetPostBackEventReference(this, "TestSummaryReport");
            divTestResultReport.Attributes["onClick"] = ClientScript.GetPostBackEventReference(this, "TestResultReport");
            divAppointmentScheduleReport.Attributes["onClick"] = ClientScript.GetPostBackEventReference(this, "AppointmentScheduleReport");
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
            // int intTypeID = 0;
            //this.ResetTabStyles();
            //  trGridView.Visible = false;
            switch (strReportType)
            {
                case "Examstatusreport":
                    //hdValue.Value = "1-2";
                    //intTypeID = 2;
                    //((System.Web.UI.HtmlControls.HtmlGenericControl)this.Page.Master.FindControl("ExamProviderContent").FindControl("divDistinctstudentsreport")).Attributes.Add("class", "tab_s_active");
                    Response.Redirect("AuditorReportsView.aspx?ReportID=" + AppSecurity.Encrypt("3") + "&ReportTypeID=" + AppSecurity.Encrypt("2"));
                    break;
                case "Billingreport":
                    //hdValue.Value = "1-2";
                    //intTypeID = 2;
                    //((System.Web.UI.HtmlControls.HtmlGenericControl)this.Page.Master.FindControl("ExamProviderContent").FindControl("divDistinctstudentsreport")).Attributes.Add("class", "tab_s_active");


                    Response.Redirect("AuditorReportsView.aspx?ReportID=" + AppSecurity.Encrypt("3") + "&ReportTypeID=" + AppSecurity.Encrypt("3"));

                    break;

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
           // divTestsummaryreport.Attributes.Add("class", "tab_s");
            
        }
    }
}