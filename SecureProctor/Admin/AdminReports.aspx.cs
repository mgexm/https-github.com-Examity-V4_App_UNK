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

namespace SecureProctor.Admin
{
    public partial class AdminReports : BaseClass, IPostBackEventHandler
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Page.Title = EnumPageTitles.APPNAME + EnumPageTitles.ADMIN_EXAMPROVIDERREPORTS;
                ((LinkButton)this.Page.Master.FindControl("lnkReports")).CssClass = "main_menu_active";
                //this.BindReportTypes();

                //divExamstatusreport.Attributes["onClick"] = ClientScript.GetPostBackEventReference(this, "Examstatusreport");
                //divStudentScheduleExam.Attributes["onClick"] = ClientScript.GetPostBackEventReference(this, "Studentscheduleexamreport");

                //divBillingReport.Attributes["onClick"] = ClientScript.GetPostBackEventReference(this, "Billingreport");
                divTestSummaryReport.Attributes["onClick"] = ClientScript.GetPostBackEventReference(this, "TestSummaryReport");
                divTestResultReport.Attributes["onClick"] = ClientScript.GetPostBackEventReference(this, "TestResultReport");
                divAppointmentScheduleReport.Attributes["onClick"] = ClientScript.GetPostBackEventReference(this, "AppointmentScheduleReport");

            }

        }

        public void RaisePostBackEvent(string eventArgument)
        {

            if (!string.IsNullOrEmpty(eventArgument))
            {
                //if (eventArgument == "Examstatusreport" || eventArgument == "Studentscheduleexamreport" || eventArgument == "Unattendedexamsreport" || eventArgument == "Cancelledexamsreport" || eventArgument == "Incompleteexamsreport" || eventArgument == "Violationsdetailreport" || eventArgument == "Violationssummaryreport" || eventArgument == "Billingreport")
                //{
                //    Div_Click(eventArgument);
                //}

                if (eventArgument == "TestSummaryReport" || eventArgument == "TestResultReport" || eventArgument == "AppointmentScheduleReport")
                {
                    Div_Click(eventArgument);
                }
            }
        }
        protected void Div_Click(string strReportType)
        {
            // int intTypeID = 0;

            //  trGridView.Visible = false;
            switch (strReportType)
            {
                case "Examstatusreport":
                    //hdValue.Value = "1-2";
                    //intTypeID = 2;
                    //((System.Web.UI.HtmlControls.HtmlGenericControl)this.Page.Master.FindControl("ExamProviderContent").FindControl("divDistinctstudentsreport")).Attributes.Add("class", "tab_s_active");


                    Response.Redirect("AdminReportsView.aspx?ReportID=" + AppSecurity.Encrypt("1") + "&ReportTypeID=" + AppSecurity.Encrypt("2"));

                    break;



                case "Studentscheduleexamreport":
                    //hdValue.Value = "1-2";
                    //intTypeID = 2;
                    //((System.Web.UI.HtmlControls.HtmlGenericControl)this.Page.Master.FindControl("ExamProviderContent").FindControl("divDistinctstudentsreport")).Attributes.Add("class", "tab_s_active");


                    Response.Redirect("AdminReportsView.aspx?ReportID=" + AppSecurity.Encrypt("2") + "&ReportTypeID=" + AppSecurity.Encrypt("1"));
                    //Response.Redirect("ExamSummaryReportView.aspx");

                    break;

                case "Billingreport":
                    //hdValue.Value = "1-2";
                    //intTypeID = 2;
                    //((System.Web.UI.HtmlControls.HtmlGenericControl)this.Page.Master.FindControl("ExamProviderContent").FindControl("divDistinctstudentsreport")).Attributes.Add("class", "tab_s_active");


                    Response.Redirect("AdminReportsView.aspx?ReportID=" + AppSecurity.Encrypt("3") + "&ReportTypeID=" + AppSecurity.Encrypt("3"));

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
            //divExamstatusreport.Attributes.Add("class", "tab_s");
            //divStudentScheduleExam.Attributes.Add("class", "tab_s");
            //divTestSummaryReport.Attributes.Add("class", "tab_s");

        }
    }
}