using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Configuration;
using System.Globalization;
using BLL;
using BusinessEntities;


namespace SecureProctor.Admin
{
    public partial class LaunchTimeReportDetails : BaseClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //SetMenuActive("HyperLink4", "hyp4");
            if (!IsPostBack)
            {
                string strFirstDate = DecryptQueryString("FirstDate");
                string strlastDate = DecryptQueryString("lastDate");
                DateTime firstDate;
                DateTime lastDate;


                if (strFirstDate != string.Empty & strFirstDate != string.Empty)
                {
                    DateTime dtFirstDate = Convert.ToDateTime(strFirstDate);
                    txtFromDate.SelectedDate = dtFirstDate;
                    firstDate = GetFirstDateOfWeek(txtFromDate.SelectedDate.Value, DayOfWeek.Monday);
                    lastDate = GetLastDateOfWeek(txtFromDate.SelectedDate.Value, DayOfWeek.Sunday);
                    lblfirstdate.Text = firstDate.ToString("MM/dd/yyyy");
                    lblLastDate.Text = lastDate.ToString("MM/dd/yyyy");

                }
                else
                {
                    txtFromDate.SelectedDate = DateTime.Now;

                    firstDate = GetFirstDateOfWeek(txtFromDate.SelectedDate.Value, DayOfWeek.Monday);
                    lastDate = GetLastDateOfWeek(txtFromDate.SelectedDate.Value, DayOfWeek.Sunday);

                    lblfirstdate.Text = firstDate.ToString("MM/dd/yyyy");
                    lblLastDate.Text = lastDate.ToString("MM/dd/yyyy");


                }
                gvStatusDetails.Rebind();

            }
        }
        protected string DecryptQueryString(string key)
        {
            string[] Queries;
            string retValue = string.Empty;
            if (Request.QueryString.Count > 0)
            {
                Queries = System.Web.HttpUtility.UrlDecode(AppSecurity.Decrypt(System.Web.HttpUtility.UrlDecode(Request.QueryString.ToString()))).Split('|');

                //  Queries = System.Web.HttpUtility.UrlDecode(AppSecurity.Decrypt(System.Web.HttpUtility.UrlDecode(Request.QueryString.ToString()))).Split('|');
                foreach (string str in Queries)
                    if (str.Split('=')[0] == key)
                        retValue = str.Split('=')[1];
            }
            return retValue;
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
        protected void lnkGraph_Click(object sender, EventArgs e)
        {
            Response.Redirect("LaunchTimeReport.aspx?" + AppSecurity.Encrypt(System.Web.HttpUtility.UrlEncode("FirstDate=" + lblfirstdate.Text + "|lastDate=" + lblLastDate.Text)));
        }
        protected void btnExport_Click(object sender, EventArgs e)
        {
            GenerateReport();
        }
        protected void btnExportOptions_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            if (gvStatusDetails.Items.Count > 0)
            {
                chkSendMail.Checked = false;
                windowExportOptions.VisibleOnPageLoad = true;
            }
            else { RadAjaxManager1.ResponseScripts.Add("alert('Empty data cannot be exported');"); }
        }
        protected void btnleftarrow_Click(object sender, EventArgs e)
        {
            DateTime dtnextday = Convert.ToDateTime(lblfirstdate.Text);

            DateTime firstDate = GetFirstDateOfWeek(dtnextday.AddDays(-1), DayOfWeek.Monday);
            DateTime lastDate = GetLastDateOfWeek(dtnextday.AddDays(-1), DayOfWeek.Sunday);
            txtFromDate.SelectedDate = firstDate;

            lblfirstdate.Text = firstDate.ToString("MM/dd/yyyy");
            lblLastDate.Text = lastDate.ToString("MM/dd/yyyy");
            gvStatusDetails.Rebind();

        }
        protected void txtFromDate_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
        {
            DateTime dt = (DateTime)txtFromDate.SelectedDate;
            CultureInfo c = txtFromDate.Calendar.CultureInfo;
            int weeknumber = c.Calendar.GetWeekOfYear(dt, c.DateTimeFormat.CalendarWeekRule, c.DateTimeFormat.FirstDayOfWeek);

            DateTime firstDate = GetFirstDateOfWeek(txtFromDate.SelectedDate.Value, DayOfWeek.Monday);
            DateTime lastDate = GetLastDateOfWeek(txtFromDate.SelectedDate.Value, DayOfWeek.Sunday);

            lblfirstdate.Text = firstDate.ToString("MM/dd/yyyy");
            lblLastDate.Text = lastDate.ToString("MM/dd/yyyy");
            gvStatusDetails.Rebind();

        }
        protected void btnrightarrow_Click(object sender, EventArgs e)
        {
            DateTime dtnextday = Convert.ToDateTime(lblLastDate.Text);

            DateTime firstDate = GetFirstDateOfWeek(dtnextday.AddDays(1), DayOfWeek.Monday);
            DateTime lastDate = GetLastDateOfWeek(dtnextday.AddDays(1), DayOfWeek.Sunday);
            txtFromDate.SelectedDate = firstDate;

            lblfirstdate.Text = firstDate.ToString("MM/dd/yyyy");
            lblLastDate.Text = lastDate.ToString("MM/dd/yyyy");
            gvStatusDetails.Rebind();
        }
        protected void gvStatusDetails_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            DateTime firstDate = GetFirstDateOfWeek(txtFromDate.SelectedDate.Value, DayOfWeek.Monday);
            DateTime lastDate = GetLastDateOfWeek(txtFromDate.SelectedDate.Value, DayOfWeek.Sunday);

            BEReports objBEReports = new BEReports();
            BReports objBReports = new BReports();

            objBEReports.StartDate = firstDate;
            objBEReports.EndDate = lastDate;
            objBReports.BGETLAUNCHTIMEREPORT(objBEReports);
            DataTable objDt = objBEReports.dsResult.Tables[0];
            gvStatusDetails.DataSource = objDt;
        }

        public void GenerateReport()
        {



            DateTime firstDate = GetFirstDateOfWeek(txtFromDate.SelectedDate.Value, DayOfWeek.Monday);
            DateTime lastDate = GetLastDateOfWeek(txtFromDate.SelectedDate.Value, DayOfWeek.Sunday);

            BEReports objBEReports = new BEReports();
            BReports objBReports = new BReports();

            objBEReports.StartDate = firstDate;
            objBEReports.EndDate = lastDate;
            objBReports.BGETLAUNCHTIMEREPORT(objBEReports);
            DataTable objDt = objBEReports.dsResult.Tables[0];

            objDt.Columns.Remove("LaunchTimeIn");
            objDt.Columns.Remove("ExamDate");

            objDt.Columns["ID"].ColumnName = "Exam ID";
            objDt.Columns["StudentName"].ColumnName = "Student name";
            objDt.Columns["Coursename"].ColumnName = "Course name";
            objDt.Columns["Examname"].ColumnName = "Exam name";
            objDt.Columns["Authenticationstarted"].ColumnName = "Authentication start time";
            objDt.Columns["Authenticationended"].ColumnName = "Exam start time";
            objDt.Columns["Launchtime"].ColumnName = "Launch time";

            // DataRow dr1;

            // dr1 = objDt.NewRow();      
            //// dr1[5] = "Average launch time";
            // dr1[6] = objBEReports.dsResult.Tables[2].Rows[0]["TotalAVG"].ToString();
            // objDt.Rows.Add(dr1);
            //PendingatAuditor

            // Access Your DataTable

            FileInfo rptFileName = new FileInfo(Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["Reports"].ToString()) + @"\launch time report from_" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss").Replace("/", "-").Replace(":", "-") + ".xls");
            // If any file exists in this directory having name 'Sample1.xlsx', then delete it
            if (rptFileName.Exists)
            {
                rptFileName.Delete(); // ensures we create a new workbook
                rptFileName = new FileInfo(Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["Reports"].ToString()) + @"\launch time report from_" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss").Replace("/", "-").Replace(":", "-") + ".xls");
            }
            this.DeleteHistoricFiles();
            
            ExcelSheetGenerator objExcel = new ExcelSheetGenerator();
            objExcel.GenerateReport(objDt, rptFileName, "Launch Time Report", "UserName");
            string ToEmail = txtEmail.Text;
            if (chkSendMail.Checked)
            {

                MailMessage email = new MailMessage();
                StringBuilder body = new StringBuilder();
                email.From = new MailAddress("donotreply@examity.com");
                email.To.Add(ToEmail.Replace(" ", ""));
                email.Subject = "launch time report from " + firstDate.ToString("MMM - dd") + " - " + lastDate.ToString("MMM - dd");
                body.Append("<table style='font-family:Helvetica;font-size:9pt;width:600px;'>");
                body.Append(@"<tr><td>Hi,<br/><br/>Please find the enclosed attachment report for  launch time report from " + firstDate.ToString("MMM - dd") + " - " + lastDate.ToString("MMM - dd") + @".
<br/><br/><br/><p style='font-size:10px;'>This is a post-only mailing. Replies to this message are not monitored or answered.</p></td></tr>");
                body.Append("</table>");
                // Attachment goes here
                Attachment attachment = new Attachment(rptFileName.ToString());
                attachment.Name = "launch time report from" + firstDate.ToString("MMM - dd") + " - " + lastDate.ToString("MMM - dd") + ".xlsx";
                email.Attachments.Add(attachment);	//add the attachment

                email.Body = body.ToString();
                email.IsBodyHtml = true;
                SmtpClient obj = new SmtpClient
                {
                    Host = ConfigurationManager.AppSettings["smtpServer"],
                    Port = Convert.ToInt32(ConfigurationManager.AppSettings["smtpPort"]),
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["smtpUser"].ToString(), ConfigurationManager.AppSettings["Reportspassword"].ToString())
                };
                obj.Send(email);
                Response.Redirect(Request.Url.AbsoluteUri);
            }
            else
            {
                // Response.ContentType = "application/octet-stream";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AppendHeader("Content-Disposition", "attachment; filename=\"" + "launch time report from " + firstDate.ToString("MMM - dd") + " - " + lastDate.ToString("MMM - dd") + "" + ".xlsx");
                Response.TransmitFile(rptFileName.ToString());
                Response.End();
            }
        }
        protected void DeleteHistoricFiles()
        {
            try
            {

                DirectoryInfo drInfo = new DirectoryInfo(Server.MapPath("Reports"));
                foreach (FileInfo fileReport in drInfo.GetFiles())
                {
                    string strFileDate = fileReport.FullName.ToString().Substring(fileReport.FullName.ToString().IndexOf("launch time report_") + 13, 14);
                    if (DateTime.Compare(Convert.ToDateTime(strFileDate), Convert.ToDateTime(DateTime.Now.ToString("MM/dd/yyyy"))) < 0)
                    {
                        fileReport.Delete();
                    }

                }
            }
            catch
            {
            }
        }
    }
}