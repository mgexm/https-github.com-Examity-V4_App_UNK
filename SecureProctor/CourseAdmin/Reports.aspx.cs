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

namespace SecureProctor.CourseAdmin
{
    public partial class Reports : BaseClass, IPostBackEventHandler
    {
        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Page.Title = EnumPageTitles.APPNAME + EnumPageTitles.EXAMPROVIDER_EXAMPROVIDERREPORTS;
                ((LinkButton)this.Page.Master.FindControl("lnkReports")).CssClass = "main_menu_active";
                divTestSummaryReport.Attributes["onClick"] = ClientScript.GetPostBackEventReference(this, "TestSummaryReport");
                divTestResultReport.Attributes["onClick"] = ClientScript.GetPostBackEventReference(this, "TestResultReport");

                //divExamstatusreport.Attributes["onClick"] = ClientScript.GetPostBackEventReference(this, "Examstatusreport");
                //divStudentScheduleExam.Attributes["onClick"] = ClientScript.GetPostBackEventReference(this, "Studentscheduleexamreport");


            }

        }

        #endregion

        #region Methods

        public void RaisePostBackEvent(string eventArgument)
        {

            if (!string.IsNullOrEmpty(eventArgument))
            {
                //if (eventArgument == "Examstatusreport" || eventArgument == "Studentscheduleexamreport" || eventArgument == "Unattendedexamsreport" || eventArgument == "Cancelledexamsreport" || eventArgument == "Incompleteexamsreport" || eventArgument == "Violationsdetailreport" || eventArgument == "Violationssummaryreport")
                //{
                //    Div_Click(eventArgument);
                //}

                if (eventArgument == "TestSummaryReport" || eventArgument == "TestResultReport")
                {
                    Div_Click(eventArgument);
                }
            }
        }

        protected void Div_Click(string strReportType)
        {
            // int intTypeID = 0;
            this.ResetTabStyles();
            //  trGridView.Visible = false;
            switch (strReportType)
            {
            

                case "TestSummaryReport":
                    //hdValue.Value = "1-2";
                    //intTypeID = 2;
                    //((System.Web.UI.HtmlControls.HtmlGenericControl)this.Page.Master.FindControl("ExamProviderContent").FindControl("divDistinctstudentsreport")).Attributes.Add("class", "tab_s_active");


                    Response.Redirect("TestSummaryReport.aspx");

                    break;
                case "TestResultReport":


                    Response.Redirect("TestResultReport.aspx");

                    break;

            }

        }

        protected void ResetTabStyles()
        {
            divExamstatusreport.Attributes.Add("class", "tab_s");
            divStudentScheduleExam.Attributes.Add("class", "tab_s");
            divTestSummaryReport.Attributes.Add("class", "tab_s");
        }

        #endregion
    }
}