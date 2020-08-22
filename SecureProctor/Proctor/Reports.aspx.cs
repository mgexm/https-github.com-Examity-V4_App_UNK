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

namespace SecureProctor.Proctor
{
    public partial class Reports : BaseClass, IPostBackEventHandler
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Page.Title = EnumPageTitles.APPNAME + EnumPageTitles.Proctor_ProctorReports;
                ((LinkButton)this.Page.Master.FindControl("lnkReport")).CssClass = "main_menu_active";
                divExamstatusreport.Attributes["onClick"] = ClientScript.GetPostBackEventReference(this, "Examstatusreport");
            }            
        }

        public void RaisePostBackEvent(string eventArgument)
        {

            if (!string.IsNullOrEmpty(eventArgument))
            {
                if (eventArgument == "Examstatusreport" || eventArgument == "Completedexamsreport" || eventArgument == "Unattendedexamsreport" || eventArgument == "Cancelledexamsreport" || eventArgument == "Incompleteexamsreport" || eventArgument == "Violationsdetailreport" || eventArgument == "Violationssummaryreport")
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
                case "Examstatusreport":
                    //hdValue.Value = "1-2";
                    //intTypeID = 2;
                    //((System.Web.UI.HtmlControls.HtmlGenericControl)this.Page.Master.FindControl("ExamProviderContent").FindControl("divDistinctstudentsreport")).Attributes.Add("class", "tab_s_active");
                    Response.Redirect("ReportsView.aspx?ReportID=" + AppSecurity.Encrypt("2") + "&ReportTypeID=" + AppSecurity.Encrypt("2"));
                    break;
                //case "Completedexamsreport":
                //    Response.Redirect("ReportsView.aspx?ReportID=" + AppSecurity.Encrypt("2") +"&ReportTypeID=" + AppSecurity.Encrypt("1"));
                //    //hdValue.Value = "2-1";
                //    //intTypeID = 1;
                //    //((System.Web.UI.HtmlControls.HtmlGenericControl)this.Page.Master.FindControl("ExamProviderContent").FindControl("divCompletedexamsreport")).Attributes.Add("class", "tab_s_active");
                //    break;
                //case "Unattendedexamsreport":
                //    Response.Redirect("ReportsView.aspx?ReportID=" + AppSecurity.Encrypt("3") +"&ReportTypeID=" + AppSecurity.Encrypt("1"));
                //    //hdValue.Value = "3-1";
                //    //intTypeID = 1;
                //    //((System.Web.UI.HtmlControls.HtmlGenericControl)this.Page.Master.FindControl("ExamProviderContent").FindControl("divUnattendedexamsreport")).Attributes.Add("class", "tab_s_active");
                //    break;
                //case "Cancelledexamsreport":
                //    Response.Redirect("ReportsView.aspx?ReportID=" + AppSecurity.Encrypt("4") +"&ReportTypeID=" + AppSecurity.Encrypt("1"));
                //    //hdValue.Value = "4-1";
                //    //intTypeID = 1;
                //    //((System.Web.UI.HtmlControls.HtmlGenericControl)this.Page.Master.FindControl("ExamProviderContent").FindControl("divCancelledexamsreport")).Attributes.Add("class", "tab_s_active");
                //    break;
                //case "Incompleteexamsreport":
                //    Response.Redirect("ReportsView.aspx?ReportID=" + AppSecurity.Encrypt("5") +"&ReportTypeID=" + AppSecurity.Encrypt("1"));
                //    //hdValue.Value = "5-1";
                //    //intTypeID = 1;
                //    //((System.Web.UI.HtmlControls.HtmlGenericControl)this.Page.Master.FindControl("ExamProviderContent").FindControl("divIncompleteexamsreport")).Attributes.Add("class", "tab_s_active");
                //    break;
                //case "Violationsdetailreport":
                //    Response.Redirect("ReportsView.aspx?ReportID=" + AppSecurity.Encrypt("6") +"&ReportTypeID=" + AppSecurity.Encrypt("2"));
                //    //hdValue.Value = "6-2";
                //    //intTypeID = 2;
                //    //((System.Web.UI.HtmlControls.HtmlGenericControl)this.Page.Master.FindControl("ExamProviderContent").FindControl("divViolationsdetailreport")).Attributes.Add("class", "tab_s_active");
                //    break;
                //case "Violationssummaryreport":
                //    Response.Redirect("ReportsView.aspx?ReportID=" + AppSecurity.Encrypt("7") + "&ReportTypeID=" + AppSecurity.Encrypt("2"));
                //    //hdValue.Value = "7-2";
                //    //intTypeID = 2;
                //    //((System.Web.UI.HtmlControls.HtmlGenericControl)this.Page.Master.FindControl("ExamProviderContent").FindControl("divViolationssummaryreport")).Attributes.Add("class", "tab_s_active");
                //    break;
            }

        }
        protected void ResetTabStyles()
        {
            divExamstatusreport.Attributes.Add("class", "tab_s");
            //divCompletedexamsreport.Attributes.Add("class", "tab_s");
            //divUnattendedexamsreport.Attributes.Add("class", "tab_s");
            //divCancelledexamsreport.Attributes.Add("class", "tab_s");
            //divIncompleteexamsreport.Attributes.Add("class", "tab_s");
            //divViolationsdetailreport.Attributes.Add("class", "tab_s");
            //divViolationssummaryreport.Attributes.Add("class", "tab_s");
        }
    }
}