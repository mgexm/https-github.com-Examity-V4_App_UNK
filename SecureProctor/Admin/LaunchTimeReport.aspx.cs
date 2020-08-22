using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web.Mail;
using System.Web.UI.HtmlControls;
using BLL;
using BusinessEntities;
using SecureProctor;
using System.Web.Services;

namespace SecureProctor.Admin
{
    public partial class LaunchTimeReport : BaseClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //SetMenuActive("HyperLink4", "hyp4");
            Page.Header.DataBind();   
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


                BEReports objBEReports = new BEReports();
                BReports objBReports = new BReports();

                objBEReports.StartDate = firstDate;
                objBEReports.EndDate = lastDate;
                objBReports.BGETLAUNCHTIMEREPORT(objBEReports);
                DataTable objDt = objBEReports.dsResult.Tables[1];

                rptLaunchTime.DataSource = objDt;
                rptLaunchTime.DataBind();

                gvStatusDetails.DataSource = objDt;
                gvStatusDetails.DataBind();

                lblMsg.Text = "Average launch time between " + firstDate.ToString("dd  MMM") + " - " + lastDate.ToString("dd  MMM") + " - ";
                lblMsgval.Text = objBEReports.dsResult.Tables[2].Rows[0]["TotalAVG"].ToString();
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
        protected void txtFromDate_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
        {

            DateTime dt = (DateTime)txtFromDate.SelectedDate;
            CultureInfo c = txtFromDate.Calendar.CultureInfo;
            int weeknumber = c.Calendar.GetWeekOfYear(dt, c.DateTimeFormat.CalendarWeekRule, c.DateTimeFormat.FirstDayOfWeek);

            DateTime firstDate = GetFirstDateOfWeek(txtFromDate.SelectedDate.Value, DayOfWeek.Monday);
            DateTime lastDate = GetLastDateOfWeek(txtFromDate.SelectedDate.Value, DayOfWeek.Sunday);

            lblfirstdate.Text = firstDate.ToString("MM/dd/yyyy");
            lblLastDate.Text = lastDate.ToString("MM/dd/yyyy");

            BEReports objBEReports = new BEReports();
            BReports objBReports = new BReports();

            objBEReports.StartDate = firstDate;
            objBEReports.EndDate = lastDate;
            objBReports.BGETLAUNCHTIMEREPORT(objBEReports);
            DataTable objDt = objBEReports.dsResult.Tables[1];
            rptLaunchTime.DataSource = objDt;
            rptLaunchTime.DataBind();
            gvStatusDetails.DataSource = objDt;
            gvStatusDetails.DataBind();

            lblMsg.Text = "Average launch time between " + firstDate.ToString("dd  MMM") + " - " + lastDate.ToString("dd  MMM") + " - ";
            lblMsgval.Text = objBEReports.dsResult.Tables[2].Rows[0]["TotalAVG"].ToString();

        }
        protected void btnleftarrow_Click(object sender, EventArgs e)
        {
            DateTime dtnextday = Convert.ToDateTime(lblfirstdate.Text);

            DateTime firstDate = GetFirstDateOfWeek(dtnextday.AddDays(-1), DayOfWeek.Monday);
            DateTime lastDate = GetLastDateOfWeek(dtnextday.AddDays(-1), DayOfWeek.Sunday);
            txtFromDate.SelectedDate = firstDate;

            lblfirstdate.Text = firstDate.ToString("MM/dd/yyyy");
            lblLastDate.Text = lastDate.ToString("MM/dd/yyyy");

            BEReports objBEReports = new BEReports();
            BReports objBReports = new BReports();

            objBEReports.StartDate = firstDate;
            objBEReports.EndDate = lastDate;
            objBReports.BGETLAUNCHTIMEREPORT(objBEReports);
            DataTable objDt = objBEReports.dsResult.Tables[1];
            rptLaunchTime.DataSource = objDt;
            rptLaunchTime.DataBind();
            gvStatusDetails.DataSource = objDt;
            gvStatusDetails.DataBind();

            lblMsg.Text = "Average launch time between " + firstDate.ToString("dd  MMM") + " - " + lastDate.ToString("dd  MMM") + " - ";
            lblMsgval.Text = objBEReports.dsResult.Tables[2].Rows[0]["TotalAVG"].ToString();
        }
        protected void btnrightarrow_Click(object sender, EventArgs e)
        {
            DateTime dtnextday = Convert.ToDateTime(lblLastDate.Text);

            DateTime firstDate = GetFirstDateOfWeek(dtnextday.AddDays(1), DayOfWeek.Monday);
            DateTime lastDate = GetLastDateOfWeek(dtnextday.AddDays(1), DayOfWeek.Sunday);
            txtFromDate.SelectedDate = firstDate;

            lblfirstdate.Text = firstDate.ToString("MM/dd/yyyy");
            lblLastDate.Text = lastDate.ToString("MM/dd/yyyy");



            BEReports objBEReports = new BEReports();
            BReports objBReports = new BReports();

            objBEReports.StartDate = firstDate;
            objBEReports.EndDate = lastDate;
            objBReports.BGETLAUNCHTIMEREPORT(objBEReports);
            DataTable objDt = objBEReports.dsResult.Tables[1];
            rptLaunchTime.DataSource = objDt;
            rptLaunchTime.DataBind();
            gvStatusDetails.DataSource = objDt;
            gvStatusDetails.DataBind();

            lblMsg.Text = "Average launch time between " + firstDate.ToString("dd  MMM") + " - " + lastDate.ToString("dd  MMM") + " - ";
            lblMsgval.Text = objBEReports.dsResult.Tables[2].Rows[0]["TotalAVG"].ToString();
        }
        protected void lnkDetails_Click(object sender, EventArgs e)
        {
            Response.Redirect("LaunchTimeReportDetails.aspx?" + AppSecurity.Encrypt(System.Web.HttpUtility.UrlEncode("FirstDate=" + lblfirstdate.Text + "|lastDate=" + lblLastDate.Text)));
        }

        protected void btnExportOptions_Click(object sender, ImageClickEventArgs e)
        {
            btnExport.Visible = true;
            btnSendMail.Visible = true;
            btnExaportAverage.Visible = false;
            btnAverageSendMail.Visible = false;
            windowExportOptions.VisibleOnPageLoad = true;
            rdlexcel.Visible = false;
            rdlpdf.Visible = true;
        }

        protected void btnAverageExportOptions_Click(object sender, ImageClickEventArgs e)
        {
            btnExport.Visible = false;
            btnSendMail.Visible = false;
            btnExaportAverage.Visible = true;
            btnAverageSendMail.Visible = true;
            windowExportOptions.VisibleOnPageLoad = true;
            rdlexcel.Visible = true;
            rdlpdf.Visible = false;
        }
        protected void btnExaportAverage_Click(object sender, EventArgs e)
        {
            GenerateReport();
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
            DataTable objDt = objBEReports.dsResult.Tables[1];


            DataTable objDt1 = new DataTable();
            objDt1.Columns.Add("Date");
            // objDt1.Columns.Add("Average Time");

            DataColumn colDecimal = new DataColumn("Average Time");
            //colDecimal.DataType = System.Type.GetType("System.Decimal");
            objDt1.Columns.Add(colDecimal);

            foreach (DataRow dr in objDt.Rows)
            {
                DataRow objDr = objDt1.NewRow();
                DateTime dtdate = Convert.ToDateTime(dr["ScheduleDate"].ToString());

                objDr["Date"] = Convert.ToString(dtdate.ToString("dd-MMM"));
                objDr["Average Time"] = dr["AverageLaunchtime"].ToString();
                objDt1.Rows.Add(objDr);
                objDt1.AcceptChanges();
            }


            FileInfo rptFileName = new FileInfo(Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["Reports"].ToString()) + @"\ launch time report from_" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss").Replace("/", "-").Replace(":", "-") + ".xls");
            // If any file exists in this directory having name 'Sample1.xlsx', then delete it
            if (rptFileName.Exists)
            {
                rptFileName.Delete(); // ensures we create a new workbook
                rptFileName = new FileInfo(Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["Reports"].ToString()) + @"\ launch time report from_" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss").Replace("/", "-").Replace(":", "-") + ".xls");
            }

            ExcelSheetGenerator objExcel = new ExcelSheetGenerator();
            objExcel.GenerateReport(objDt1, rptFileName, "Launch Time Report", "UserName");
            string ToEmail = txtEmail.Text;
            if (chkSendMail.Checked)
            {

                System.Net.Mail.MailMessage email = new System.Net.Mail.MailMessage();
                StringBuilder body = new StringBuilder();
                email.From = new MailAddress("donotreply@examity.com");
                email.To.Add(ToEmail.Replace(" ", ""));
                email.Subject = "Launch time report from " + firstDate.ToString("MMM - dd") + " - " + lastDate.ToString("MMM - dd");
                body.Append("<table style='font-family:Helvetica;font-size:9pt;width:600px;'>");
                body.Append(@"<tr><td>Hi,<br/><br/>Please find the enclosed attachment report for  launch time report from " + firstDate.ToString("MMM - dd") + " - " + lastDate.ToString("MMM - dd") + @".
<br/><br/><br/><p style='font-size:10px;'>This is a post-only mailing. Replies to this message are not monitored or answered.</p></td></tr>");
                body.Append("</table>");
                // Attachment goes here
                Attachment attachment = new Attachment(rptFileName.ToString());
                attachment.Name = " launch time report from" + firstDate.ToString("MMM - dd") + " - " + lastDate.ToString("MMM - dd") + ".xlsx";
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
                Response.AppendHeader("Content-Disposition", "attachment; filename=\"" + " launch time report from " + firstDate.ToString("MMM - dd") + " - " + lastDate.ToString("MMM - dd") + "" + ".xlsx");
                Response.TransmitFile(rptFileName.ToString());
                Response.End();
            }
        }





    }
}