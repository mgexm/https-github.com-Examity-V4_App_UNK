using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using BLL;
using System.IO;

namespace SecureProctor.Admin
{
    public partial class AllResponsesReport : BaseClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {         

            if (!IsPostBack)
            {
               

                //if any dates in tabs selected the same dates should be displayed in all the tabs
                if (Request.QueryString["fdate"] != null && Request.QueryString["ldate"] != null)
                {
                    rdpFromDate.SelectedDate =Convert.ToDateTime(AppSecurity.Decrypt(Request.QueryString["fdate"].ToString()));
                    rdpToDate.SelectedDate = Convert.ToDateTime(AppSecurity.Decrypt(Request.QueryString["ldate"].ToString()));
                }
                else
                {
                    DateTime firstDate = GetFirstDateOfWeek(DateTime.Now, DayOfWeek.Monday);
                    DateTime lastDate = GetLastDateOfWeek(DateTime.Now, DayOfWeek.Sunday);
                    //for date controls default population with the current date
                    rdpFromDate.SelectedDate = firstDate;
                    rdpToDate.SelectedDate = lastDate;
                }


                //for date controls default population with the current date
             //   rdpFromDate.SelectedDate = firstDate;
              //  rdpToDate.SelectedDate = lastDate;
            }
        }
        public static DateTime GetFirstDateOfWeek(DateTime dayInWeek, DayOfWeek firstDay)
        {
            DateTime firstDayInWeek = dayInWeek.Date;
            while (firstDayInWeek.DayOfWeek != firstDay)
                firstDayInWeek = firstDayInWeek.AddDays(-1);

            return firstDayInWeek;
        }
        public static DateTime GetLastDateOfWeek(DateTime dayInWeek, DayOfWeek firstDay)
        {
            DateTime lastDayInWeek = dayInWeek.Date;
            while (lastDayInWeek.DayOfWeek != firstDay)
                lastDayInWeek = lastDayInWeek.AddDays(1);

            return lastDayInWeek;
        }
        protected void gReport_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        { 
            int clientID = 0;
            SurveyBL objSurvey = new SurveyBL();
            clientID = objSurvey.GetPortalClientId();

            int examId = 0;
            if (!string.IsNullOrEmpty(txtExamID.Text))
                examId = Convert.ToInt32(txtExamID.Text);

            SurveyBL objBl = new SurveyBL();
            DataSet ds = null;
            if (rdpFromDate.SelectedDate != null && rdpToDate.SelectedDate!=null)
            ds = objBl.GetSurveyIndividualReport(clientID.ToString(), txtStudentName.Text, examId, rdpFromDate.SelectedDate.Value, rdpToDate.SelectedDate.Value);
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                    gReport.DataSource = ds.Tables[0];
                else
                    gReport.DataSource = new object[0];
            }
            else
                gReport.DataSource = new object[0];
            objBl = null;

        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            gReport.Rebind();
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {            
           GenerateReport();
        }
        public void GenerateReport()
        {
            int clientID = 0;
            SurveyBL objSurvey = new SurveyBL();
            clientID = objSurvey.GetPortalClientId();


            int examId = 0;
            if (!string.IsNullOrEmpty(txtExamID.Text))
                examId = Convert.ToInt32(txtExamID.Text);

            SurveyBL objBl = new SurveyBL();
            DataSet ds = objBl.GetSurveyIndividualReport(clientID.ToString(), txtStudentName.Text, examId, rdpFromDate.SelectedDate.Value, rdpToDate.SelectedDate.Value);




            FileInfo rptFileName = new FileInfo(Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["Reports"].ToString()) + @"\ Individual Responses from_" + rdpFromDate.SelectedDate.Value.ToString("MM/dd/yyyy HH:mm:ss").Replace("/", "-").Replace(":", "-") + ".xls");
            // If any file exists in this directory having name 'Sample1.xlsx', then delete it
            if (rptFileName.Exists)
            {
                rptFileName.Delete(); // ensures we create a new workbook
                rptFileName = new FileInfo(Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["Reports"].ToString()) + @"\ Individual Responses from_" + rdpFromDate.SelectedDate.Value.ToString("MM/dd/yyyy HH:mm:ss").Replace("/", "-").Replace(":", "-") + ".xls");
            }
           // this.DeleteHistoricFiles();
            
            if (ds != null & ds.Tables.Count > 0)
            {
                ExcelSheetGenerator objExcel = new ExcelSheetGenerator();
                objExcel.GenerateReport(ds.Tables[0], rptFileName, "Individual Responses", "UserName");
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AppendHeader("Content-Disposition", "attachment; filename=\"" + "Individual Responses Report From -" + rdpFromDate.SelectedDate.Value.ToString("MM/dd/yyyy").Replace("/", "-").Replace(":", "-") + " " + rdpToDate.SelectedDate.Value.ToString("MM/dd/yyyy").Replace("/", "-").Replace(":", "-") + "" + ".xlsx");
                Response.TransmitFile(rptFileName.ToString());
                Response.End();
                gReport.DataSource = ds.Tables[0];
            }
            else
                 gReport.DataSource = new object[0];

           
            
            
        }

        protected void lnkQuestionSummary_Click(object sender, EventArgs e)
        {
            string fdate=string.Empty, ldate = string.Empty;
            if (rdpFromDate.SelectedDate!=null)
            fdate = rdpFromDate.SelectedDate.Value.ToString("MM/dd/yyyy");
            if (rdpToDate.SelectedDate!=null)
            ldate = rdpToDate.SelectedDate.Value.ToString("MM/dd/yyyy");
            Response.Redirect("QuestionSummaries.aspx?fdate=" + AppSecurity.Encrypt(fdate) + "&ldate=" + AppSecurity.Encrypt(ldate));
        }

        protected void lnkAll_Click(object sender, EventArgs e)
        {
            string fdate = string.Empty, ldate = string.Empty;
            if (rdpFromDate.SelectedDate != null)
            fdate = rdpFromDate.SelectedDate.Value.ToString("MM/dd/yyyy");
            if (rdpToDate.SelectedDate != null)
            ldate = rdpToDate.SelectedDate.Value.ToString("MM/dd/yyyy");
            Response.Redirect("Surveydetails.aspx?fdate=" + AppSecurity.Encrypt(fdate) + "&ldate=" + AppSecurity.Encrypt(ldate));
        }
    }
}