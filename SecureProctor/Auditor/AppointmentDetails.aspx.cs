using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using BusinessEntities;
using System.Data;
using System.IO;
using System.Configuration;
using System.Text;
using System.Net.Mail;

namespace SecureProctor.Auditor
{
    public partial class AppointmentDetails : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int courseId = 0, examId = 0;
                string appStatus = string.Empty;

                if (Request.QueryString["cid"] != null)
                    courseId = Convert.ToInt32(AppSecurity.Decrypt(Request.QueryString["cid"].ToString()));

                if (Request.QueryString["eid"] != null)
                    examId = Convert.ToInt32(AppSecurity.Decrypt(Request.QueryString["eid"].ToString()));

                if (Request.QueryString["sch"] != null)
                    appStatus = AppSecurity.Decrypt(Request.QueryString["sch"].ToString());

                if (appStatus == "true")
                    lblAppHeader.Text = "Scheduled Appointments";
                else if (appStatus == "false")
                    lblAppHeader.Text = "Unscheduled Appointments";

                //here we are loading the grid
                LoadAppointments(courseId, examId, appStatus);
            }
        }

        protected void LoadAppointments(int courseId, int examId, string type)
        {
            BAdmin objBAdmin = new BAdmin();
            BEAdmin objBEAdmin = new BEAdmin();
            objBEAdmin.IntCourseID = courseId;
            objBEAdmin.IntExamID = examId;

            if (type == "true")
                objBEAdmin.IntType = 1; //for scheduled appointments
            else if (type == "false")
                objBEAdmin.IntType = 0; //for unscheduled appointments

            objBAdmin.BGetAdminAppointmentDetails(objBEAdmin);

            //Scheduled Appoinments
            if (type == "true")
            {
                if (objBEAdmin.DtResult.Rows.Count > 0)
                    gvExamStatus.DataSource = objBEAdmin.DtResult;
                else
                    gvExamStatus.DataSource = new string[] { };
            }//UnScheduled Appointments
            else
            {
                if (objBEAdmin.DtResult.Rows.Count > 0)
                    rgvUnScheduledAppointments.DataSource = objBEAdmin.DtResult;
                else
                    rgvUnScheduledAppointments.DataSource = new string[] { };
            }
        }

        //Export the grid
        protected void BtnExportToExcel_Click(object sender, EventArgs e)
        {
            int courseId = 0, examId = 0;
            string appStatus = string.Empty;


            if (Request.QueryString["cid"] != null)
                courseId = Convert.ToInt32(AppSecurity.Decrypt(Request.QueryString["cid"].ToString()));

            if (Request.QueryString["eid"] != null)
                examId = Convert.ToInt32(AppSecurity.Decrypt(Request.QueryString["eid"].ToString()));

            if (Request.QueryString["sch"] != null)
                appStatus = AppSecurity.Decrypt(Request.QueryString["sch"].ToString());

            GenerateReport(courseId, examId, appStatus, 0);
        }

        public void GenerateReport(int courseId, int examId, string type, int Mail)
        {
            BAdmin objBAdmin = new BAdmin();
            BEAdmin objBEAdmin = new BEAdmin();
            objBEAdmin.IntCourseID = courseId;
            objBEAdmin.IntExamID = examId;

            if (type == "true")
                objBEAdmin.IntType = 1; //for scheduled appointments
            else if (type == "false")
                objBEAdmin.IntType = 0; //for unscheduled appointments

            objBAdmin.BGetAdminAppointmentDetails(objBEAdmin);

            //Scheduled Appoinments
            if (type == "true")
            {
                ScheduledReport(objBEAdmin.DtResult, Mail);
            }//UnScheduled Appointments
            else
            {
                UnScheduledReport(objBEAdmin.DtResult, Mail);
            }
        }

        //Scheduled Report
        private void ScheduledReport(DataTable dtSch, int mail)
        {
            lblResult.Text = "";
            DataTable objDt = dtSch;
            objDt.Merge(dtSch);

            objDt.AcceptChanges();
            objDt.Columns.Remove("UserID");
            objDt.Columns.Remove("row_number");

            objDt.Columns["TransID"].ColumnName = "Exam ID";
            objDt.Columns["coursename"].ColumnName = "Course Name";
            objDt.Columns["Instructor name"].ColumnName = "Instructor Name";
            objDt.Columns["ExamName"].ColumnName = "Exam Name";
            objDt.Columns["FirstName"].ColumnName = "Student First Name";
            objDt.Columns["LastName"].ColumnName = "Student Last Name";
            objDt.Columns["EmailAddress"].ColumnName = "Email Address";
            objDt.Columns["ExamDate"].ColumnName = "Exam Appointment";
            objDt.Columns["Status"].ColumnName = "Status";


            string Examsummary = Server.MapPath(ConfigurationManager.AppSettings["Reports"].ToString()) + '\\' + "ScheduledAppointmentReport" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss").Replace("/", "-").Replace(":", "-") + ".xls";
            if (File.Exists(Examsummary))
                File.Delete(Examsummary);
            FileInfo rptFileName = new FileInfo(Examsummary);

            //  this.DeleteHistoricFiles();
            if (mail == 0)
            {

                ExcelSheetGenerator objExcel = new ExcelSheetGenerator();
                objExcel.GenerateReport(objDt, rptFileName, " ScheduleAppointment Report ", "UserName");
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + "ScheduledAppointmentReport" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss").Replace("/", "-") + ".xlsx");


                Response.TransmitFile(rptFileName.ToString());
                Response.End();
            }
            else if (mail == 1)
            {

                ExcelSheetGenerator objExcel = new ExcelSheetGenerator();
                objExcel.GenerateReport(objDt, rptFileName, "Scheduled Appointment details _", "UserName");
                string ToEmail = txtEmail.Text;

                System.Net.Mail.MailMessage email = new System.Net.Mail.MailMessage();
                StringBuilder body = new StringBuilder();
                email.From = new MailAddress("donotreply@examity.com");
                email.To.Add(ToEmail.Replace(" ", ""));
                email.Subject = "Scheduled appointment details";
                body.Append("<table style='font-family:Helvetica;font-size:9pt;width:600px;'>");
                body.Append(@"<tr><td>Hi,<br/><br/>Please find the enclosed scheduled appointment details report
<br/><br/><br/>Thank you,<br/>Examity.<br/><b>***DO NOT REPLY TO THIS EMAIL***</b></td></tr>");
                body.Append("</table>");
                // Attachment goes here
                Attachment attachment = new Attachment(rptFileName.ToString());
                attachment.Name = "Scheduled appointment details" + ".xlsx";
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
                lblResult.Text = "<font color='Blue' size='4px'>" + "Report emailed sucessfully." + "</font>";
            }
        }

        //UnScheduled Report
        private void UnScheduledReport(DataTable dtUnSch, int mail)
        {
            lblResult.Text = "";
            DataTable objDt = dtUnSch;
            objDt.Merge(dtUnSch);

            objDt.AcceptChanges();
            // objDt.Columns.Remove("UserID");
            // objDt.Columns.Remove("row_number");

            objDt.Columns["CourseName"].ColumnName = "Course Name";
            objDt.Columns["InstructorName"].ColumnName = "Instructor Name";
            objDt.Columns["ExamName"].ColumnName = "Exam Name";
            objDt.Columns["FirstName"].ColumnName = "Student First Name";
            objDt.Columns["LastName"].ColumnName = "Student Last Name";
            objDt.Columns["EmailAddress"].ColumnName = "Email Address";

            string Examsummary = Server.MapPath(ConfigurationManager.AppSettings["Reports"].ToString()) + '\\' + "UnscheduledAppointmentReport" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss").Replace("/", "-").Replace(":", "-") + ".xls";
            if (File.Exists(Examsummary))
                File.Delete(Examsummary);
            FileInfo rptFileName = new FileInfo(Examsummary);

            //  this.DeleteHistoricFiles();
            if (mail == 0)
            {
                ExcelSheetGenerator objExcel = new ExcelSheetGenerator();
                objExcel.GenerateReport(objDt, rptFileName, " UnscheduleAppointment Report ", "UserName");
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + "UnscheduledAppointmentReport" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss").Replace("/", "-") + ".xlsx");
                Response.TransmitFile(rptFileName.ToString());
                Response.End();
            }

            else if (mail == 1)
            {
                ExcelSheetGenerator objExcel = new ExcelSheetGenerator();
                objExcel.GenerateReport(objDt, rptFileName, "Unscheduled Appointment details _", "UserName");
                string ToEmail = txtEmail.Text;

                System.Net.Mail.MailMessage email = new System.Net.Mail.MailMessage();
                StringBuilder body = new StringBuilder();
                email.From = new MailAddress("donotreply@examity.com");
                email.To.Add(ToEmail.Replace(" ", ""));
                email.Subject = "Unscheduled appointment details";
                body.Append("<table style='font-family:Helvetica;font-size:9pt;width:600px;'>");
                body.Append(@"<tr><td>Hi,<br/><br/>Please find the enclosed unscheduled appointment details report.
<br/><br/><br/>Thank you,<br/>Examity.<br/><b>***DO NOT REPLY TO THIS EMAIL***</b></td></tr>");
                body.Append("</table>");
                // Attachment goes here
                Attachment attachment = new Attachment(rptFileName.ToString());
                attachment.Name = "Unscheduled appointment details" + ".xlsx";
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
                lblResult.Text = "<font color='Blue' size='4px'>" + "Report emailed sucessfully." + "</font>";


            }
        }



        protected void btnExportOptions_Click(object sender, ImageClickEventArgs e)
        {

            windowExportOptions.VisibleOnPageLoad = true;

        }

        public void SendEmail()
        {
            int courseId = 0, examId = 0;
            string appStatus = string.Empty;


            if (Request.QueryString["cid"] != null)
                courseId = Convert.ToInt32(AppSecurity.Decrypt(Request.QueryString["cid"].ToString()));

            if (Request.QueryString["eid"] != null)
                examId = Convert.ToInt32(AppSecurity.Decrypt(Request.QueryString["eid"].ToString()));

            if (Request.QueryString["sch"] != null)
                appStatus = AppSecurity.Decrypt(Request.QueryString["sch"].ToString());

            GenerateReport(courseId, examId, appStatus, 1);




        }

        protected void btnSendMail_Click(object sender, EventArgs e)
        {

            SendEmail();


        }
    }
}