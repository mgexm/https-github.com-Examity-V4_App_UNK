using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using BusinessEntities;
using Telerik.Web.UI;
using System.Data;
using System.IO;
using SecureProctor;
using System.Configuration;
using System.Text;
using System.Net.Mail;

namespace SecureProctor.Auditor
{
    public partial class TestSummaryReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCourseDetails();
            }
        }

        protected void LoadCourseDetails()
        {
            try
            {
                BEAdmin objBEAdmin = new BEAdmin();
                BAdmin objBAdmin = new BAdmin();

                objBAdmin.BGetAllCourseDetails(objBEAdmin);

                if (objBEAdmin.DtResult.Rows.Count > 0)
                {
                    rcbCourses.DataSource = objBEAdmin.DtResult;
                    rcbCourses.DataTextField = "CourseName";
                    rcbCourses.DataValueField = "CourseID";
                    rcbCourses.DataBind();
                }
                gvReports.DataSource = new object[] { };
                gvReports.DataBind();

            }
            catch (Exception Ex)
            {
                ErrorHandlers.ErrorLog.WriteError(Ex);
            }
        }

        //for populating the grid
        protected void LoadSummaryReport(string ids)
        {
            try
            {
                BEAdmin objBEAdmin = new BEAdmin();
                BAdmin objBAdmin = new BAdmin();

                objBEAdmin.strCourseID = ids;
                objBEAdmin.IntUserID = 0; //for admin
                objBAdmin.BGetExamSummaryReportDetails(objBEAdmin);

                gvReports.DataSource = objBEAdmin.DtResult;
                gvReports.DataBind();

                ViewState["gvReports"] = objBEAdmin.DtResult;
            }
            catch (Exception Ex)
            {
                ErrorHandlers.ErrorLog.WriteError(Ex);
            }
        }

        protected string GetCourseIds()
        {
            string ClientIds = "'0',";

            try
            {
                if (rcbCourses.CheckedItems.Count != rcbCourses.Items.Count)
                {
                    foreach (RadComboBoxItem chkClient in rcbCourses.CheckedItems)
                    {
                        if (chkClient.Checked)
                        {
                            ClientIds = ClientIds + "'" + chkClient.Value + "',";
                        }
                    }
                }
                ClientIds = ClientIds.Substring(0, ClientIds.Length - 1);
            }
            catch (Exception Ex)
            {
                ErrorHandlers.ErrorLog.WriteError(Ex);
            }

            return ClientIds;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string ids = GetCourseIds();
            LoadSummaryReport(ids);
        }

        protected void ddlClients_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {

        }

        protected void gvReports_ItemCommand(object sender, GridCommandEventArgs e)
        {
            //GridDataItem item = e.Item as GridDataItem;
            //string courseId = item.GetDataKeyValue("CourseID").ToString();
            //string examId = item.GetDataKeyValue("ExamID").ToString();

            //if (e.CommandName == "scheduled")
            //{                   
            //    Response.Redirect("AppointmentDetails.aspx?sch="+AppSecurity.Encrypt("true")+"&cid="+AppSecurity.Encrypt(courseId)+"&eid="+AppSecurity.Encrypt(examId),false);
            //}
            //else if (e.CommandName == "unscheduled")
            //{
            //    Response.Redirect("AppointmentDetails.aspx?sch=" + AppSecurity.Encrypt("false") + "&cid=" + AppSecurity.Encrypt(courseId) + "&eid=" + AppSecurity.Encrypt(examId), false);
            //}
        }

        protected void hplnkScheduledAppointments_Click(object sender, EventArgs e)
        {
            LinkButton lnkSch = (LinkButton)sender;
            string[] ids = lnkSch.CommandArgument.ToString().Split(',');
            string courseId = ids[0];
            string examId = ids[1];
            string URL = "AppointmentDetails.aspx?sch=" + AppSecurity.Encrypt("true") + "&cid=" + AppSecurity.Encrypt(courseId) + "&eid=" + AppSecurity.Encrypt(examId);


            ScriptManager.RegisterStartupScript(up, up.GetType(), "alert", "window.open('" + URL + "','_newtab');", true);

            //Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('"+URL+"','_newtab');", true);

            //Response.Redirect("AppointmentDetails.aspx?sch=" + AppSecurity.Encrypt("true") + "&cid=" + AppSecurity.Encrypt(courseId) + "&eid=" + AppSecurity.Encrypt(examId), false);



        }

        protected void hplnkUnScheduledAppointments_Click(object sender, EventArgs e)
        {
            LinkButton lnkSch = (LinkButton)sender;
            string[] ids = lnkSch.CommandArgument.ToString().Split(',');
            string courseId = ids[0];
            string examId = ids[1];
            string URL = "AppointmentDetails.aspx?sch=" + AppSecurity.Encrypt("false") + "&cid=" + AppSecurity.Encrypt(courseId) + "&eid=" + AppSecurity.Encrypt(examId);
            ScriptManager.RegisterStartupScript(up, up.GetType(), "alert", "window.open('" + URL + "','_newtab');", true);

            // Response.Redirect("AppointmentDetails.aspx?sch=" + AppSecurity.Encrypt("false") + "&cid=" + AppSecurity.Encrypt(courseId) + "&eid=" + AppSecurity.Encrypt(examId), false);
        }

        protected void gvReports_PageIndexChanged(object sender, GridPageChangedEventArgs e)
        {
            gvReports.CurrentPageIndex = e.NewPageIndex;
            DataTable dt = (DataTable)ViewState["gvReports"];
            gvReports.DataSource = dt;
            gvReports.DataBind();
        }

        protected void gvReports_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            try
            {
                //string ids = GetCourseIds();
                //LoadSummaryReport(ids);
            }
            catch (Exception Ex)
            {
                ErrorHandlers.ErrorLog.WriteError(Ex);
            }
        }

        protected void gvReports_PageSizeChanged(object sender, GridPageSizeChangedEventArgs e)
        {
            DataTable dt = (DataTable)ViewState["gvReports"];
            gvReports.DataSource = dt;
            gvReports.DataBind();
        }

        protected void gvReports_ItemDataBound(object sender, GridItemEventArgs e)
        {
            GridDataItem item = e.Item as GridDataItem;
            if (item != null)
            {
                //Scheduled Appointments
                LinkButton lnkBtnSch = item.FindControl("hplnkScheduledAppointments") as LinkButton;

                if (lnkBtnSch != null)
                {
                    if (lnkBtnSch.Text == "0")
                    {
                        lnkBtnSch.Font.Underline = false;
                        lnkBtnSch.ForeColor = System.Drawing.Color.Black;
                        lnkBtnSch.Enabled = false;
                    }
                }

                //UnScheduled Appointments
                LinkButton lnkBtnUnSch = item.FindControl("hplnkUnScheduledAppointments") as LinkButton;

                if (lnkBtnUnSch != null)
                {
                    if (lnkBtnUnSch.Text == "0")
                    {
                        lnkBtnUnSch.Font.Underline = false;
                        lnkBtnUnSch.ForeColor = System.Drawing.Color.Black;
                        lnkBtnUnSch.Enabled = false;
                    }
                }
            }

        }

        //Export Grid Data
        protected void BtnExportToExcel_Click(object sender, EventArgs e)
        {
            GenerateReport();
        }

        public void GenerateReport()
        {
            BEAdmin objBEAdmin = new BEAdmin();
            BAdmin objBAdmin = new BAdmin();
            objBEAdmin.strCourseID = GetCourseIds();
            objBEAdmin.IntUserID = 0;
            objBAdmin.BGetExamSummaryReportDetails(objBEAdmin);

            DataTable objDt = objBEAdmin.DtResult;



            objDt.AcceptChanges();
            objDt.Columns.Remove("CourseID");
            objDt.Columns.Remove("ExamID");


            objDt.Columns["CourseName"].ColumnName = "Course Name";
            objDt.Columns["Instructor Name"].ColumnName = "Instructor Name";
            objDt.Columns["ExamName"].ColumnName = "Exam Name";
            objDt.Columns["ExamStartDate"].ColumnName = "Exam Start Date";
            objDt.Columns["ExamEndDate"].ColumnName = "Exam End Date";
            objDt.Columns["StudentsEnrolled"].ColumnName = "Total Students";
            objDt.Columns["ScheduledAppointments"].ColumnName = "Scheduled Appointments";
            objDt.Columns["Unscheduledappointments"].ColumnName = "Unscheduled Appointments";


            string Examsummary = Server.MapPath(ConfigurationManager.AppSettings["Reports"].ToString()) + '\\' + "Schedule status" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss").Replace("/", "-").Replace(":", "-") + ".xls";
            if (File.Exists(Examsummary))
                File.Delete(Examsummary);
            FileInfo rptFileName = new FileInfo(Examsummary);

            //  this.DeleteHistoricFiles();

            ExcelSheetGenerator objExcel = new ExcelSheetGenerator();
            objExcel.GenerateReport(objDt, rptFileName, " Schedule status ", "UserName");

            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

            Response.AppendHeader("Content-Disposition", "attachment; filename=" + "Schedulestatus" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss").Replace("/", "-") + ".xlsx");


            Response.TransmitFile(rptFileName.ToString());
            Response.End();
        }

        protected void DeleteHistoricFiles()
        {
            try
            {
                string path = ConfigurationManager.AppSettings["Reports"].ToString();
                DirectoryInfo drInfo = new DirectoryInfo(path);
                foreach (FileInfo fileReport in drInfo.GetFiles())
                {
                    string strFileDate = fileReport.FullName.ToString().Substring(fileReport.FullName.ToString().IndexOf("ExamCount_") + 9, 10);
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


        protected void btnExportOptions_Click(object sender, ImageClickEventArgs e)
        {

            windowExportOptions.VisibleOnPageLoad = true;

        }

        public void SendEmail()
        {
            lblResult.Text = "";
            BEAdmin objBEAdmin = new BEAdmin();
            BAdmin objBAdmin = new BAdmin();
            objBEAdmin.strCourseID = GetCourseIds();
            objBEAdmin.IntUserID = 0;
            objBAdmin.BGetExamSummaryReportDetails(objBEAdmin);

            DataTable objDt = objBEAdmin.DtResult;



            objDt.AcceptChanges();
            objDt.Columns.Remove("CourseID");
            objDt.Columns.Remove("ExamID");


            objDt.Columns["CourseName"].ColumnName = "Course Name";
            objDt.Columns["Instructor Name"].ColumnName = "Instructor Name";
            objDt.Columns["ExamName"].ColumnName = "Exam Name";
            objDt.Columns["ExamStartDate"].ColumnName = "Exam Start Date";
            objDt.Columns["ExamEndDate"].ColumnName = "Exam End Date";
            objDt.Columns["StudentsEnrolled"].ColumnName = "Total Students";
            objDt.Columns["ScheduledAppointments"].ColumnName = "Scheduled Appointments";
            objDt.Columns["Unscheduledappointments"].ColumnName = "Unscheduled Appointments";


            FileInfo rptFileName = new FileInfo(Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["Reports"].ToString()) + @"\Schedule status from_" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss").Replace("/", "-").Replace(":", "-") + ".xls");
            // If any file exists in this directory having name 'Sample1.xlsx', then delete it
            if (rptFileName.Exists)
            {
                rptFileName.Delete(); // ensures we create a new workbook
                rptFileName = new FileInfo(Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["Reports"].ToString()) + @"\Schedule status from_" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss").Replace("/", "-").Replace(":", "-") + ".xls");
            }

            ExcelSheetGenerator objExcel = new ExcelSheetGenerator();
            objExcel.GenerateReport(objDt, rptFileName, "Schedule status _", "UserName");
            string ToEmail = txtEmail.Text;

            System.Net.Mail.MailMessage email = new System.Net.Mail.MailMessage();
            StringBuilder body = new StringBuilder();
            email.From = new MailAddress("donotreply@examity.com");
            email.To.Add(ToEmail.Replace(" ", ""));
            email.Subject = "Schedule status";
            body.Append("<table style='font-family:Helvetica;font-size:9pt;width:600px;'>");
            body.Append(@"<tr><td>Hi,<br/><br/>Please find the enclosed Schedule status report.
<br/><br/><br/>Thank you,<br/>Examity.<br/><b>***DO NOT REPLY TO THIS EMAIL***</b></td></tr>");
            body.Append("</table>");
            // Attachment goes here
            Attachment attachment = new Attachment(rptFileName.ToString());
            attachment.Name = "Schedule status" + ".xlsx";
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

        protected void btnSendMail_Click(object sender, EventArgs e)
        {

            SendEmail();


        }
    }
}