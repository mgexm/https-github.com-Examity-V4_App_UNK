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


namespace SecureProctor.Provider
{
    public partial class AppointmentScheduleReport : BaseClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCourseDetails();
                rcbExams.Enabled = false;
                string ids = GetExamIds();
                LoadSummaryReport(ids);
                btnSearch.Attributes.Add("onclick", "return ValidateCourseAndExam('" + rcbCourses.ClientID.ToString() + "','" + rcbExams.ClientID.ToString() + "');");

            }
        }

        protected void LoadCourseDetails()
        {
            try
            {
                BEProvider objBEProvider = new BEProvider();
                BProvider objBProvider = new BProvider();
                objBEProvider.IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID]);

                objBProvider.BGetAllCourseDetails(objBEProvider);
                if (objBEProvider.DtResult.Rows.Count > 0)
                {
                    rcbCourses.DataSource = objBEProvider.DtResult;
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
                objBEAdmin.IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID]);
                objBAdmin.BGetAppointmentScheduleReportDetails(objBEAdmin);

                gvReports.DataSource = objBEAdmin.DtResult;
                gvReports.DataBind();

                ViewState["gvReports"] = objBEAdmin.DtResult;
            }
            catch (Exception Ex)
            {
                ErrorHandlers.ErrorLog.WriteError(Ex);
            }
        }

        protected void LoadSummaryReportSort(string ids)
        {
            try
            {
                BEAdmin objBEAdmin = new BEAdmin();
                BAdmin objBAdmin = new BAdmin();

                objBEAdmin.strCourseID = ids;
                objBEAdmin.IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID]);
                objBAdmin.BGetAppointmentScheduleReportDetails(objBEAdmin);

                gvReports.DataSource = objBEAdmin.DtResult;


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
                if (rcbCourses.CheckedItems.Count <= rcbCourses.Items.Count)
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
            string ids = GetExamIds();
            LoadSummaryReport(ids);
        }




        protected void gvReports_PageIndexChanged(object sender, GridPageChangedEventArgs e)
        {
            gvReports.CurrentPageIndex = e.NewPageIndex;
            DataTable dt = (DataTable)ViewState["gvReports"];
            gvReports.DataSource = dt;
            gvReports.DataBind();
        }



        protected void gvReports_PageSizeChanged(object sender, GridPageSizeChangedEventArgs e)
        {
            DataTable dt = (DataTable)ViewState["gvReports"];
            gvReports.DataSource = dt;
            gvReports.DataBind();
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

            objBEAdmin.strCourseID = GetExamIds();
            objBEAdmin.IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID]);
            objBAdmin.BGetAppointmentScheduleReportDetails(objBEAdmin);

            DataTable objDt = objBEAdmin.DtResult;


            objDt.Columns["ExamID"].ColumnName = "Exam ID";
            objDt.Columns["StudentFirstName"].ColumnName = "Student First Name";
            objDt.Columns["StudentLastName"].ColumnName = "Student Last Name";
            objDt.Columns["EmailAddress"].ColumnName = "Email Address";
            objDt.Columns["CourseName"].ColumnName = "Course Name";
            objDt.Columns["ExamName"].ColumnName = "Exam Name";
            objDt.Columns["InstructorName"].ColumnName = "Instructor Name";
            objDt.Columns["AppointmentCreationDate"].ColumnName = "Appointment Creation Date [EST]";
            objDt.Columns["AppointmentDate"].ColumnName = "Appointment Date [EST]";
            objDt.Columns["ExamDuration"].ColumnName = "Exam Duration";
            objDt.Columns["FairExamLevel"].ColumnName = "Fair ExamLevel";
            objDt.Columns["StatusName"].ColumnName = "Status";

            objDt.Columns.Remove("CourseID");


            string Examsummary = Server.MapPath(ConfigurationManager.AppSettings["Reports"].ToString()) + '\\' + "Schedule details" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss").Replace("/", "-").Replace(":", "-") + ".xls";
            if (File.Exists(Examsummary))
                File.Delete(Examsummary);
            FileInfo rptFileName = new FileInfo(Examsummary);

            //  this.DeleteHistoricFiles();

            ExcelSheetGenerator objExcel = new ExcelSheetGenerator();
            objExcel.GenerateReport(objDt, rptFileName, " Schedule details", "UserName");

            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

            Response.AppendHeader("Content-Disposition", "attachment; filename=" + "Schedule details" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss").Replace("/", "-") + ".xlsx");


            Response.TransmitFile(rptFileName.ToString());
            Response.End();
        }






        protected void rcbCourses_ItemChecked(object sender, RadComboBoxItemEventArgs e)
        {
            string ids = GetCourseIds();
            BEAdmin objBEAdmin = new BEAdmin();
            BAdmin objBAdmin = new BAdmin();
            objBEAdmin.strCourseID = ids;

            if (ids != "'0'")
            {
                objBAdmin.BGetAllExamDetails(objBEAdmin);

                if (objBEAdmin.DtResult.Rows.Count > 0)
                {
                    rcbExams.DataSource = objBEAdmin.DtResult;
                    rcbExams.DataTextField = "ExamName";
                    rcbExams.DataValueField = "ExamID";
                    rcbExams.DataBind();
                }
            }
            else
            {

                rcbExams.DataSource = new object[] { };
                rcbExams.DataBind();

            }
            gvReports.DataSource = new object[] { };
            gvReports.DataBind();
        }


        public string GetExamIds()
        {
            string ClientIds = "'0',";

            try
            {
                //if (rcbCourses.CheckedItems.Count != rcbCourses.Items.Count)
                //{
                if (rcbExams.CheckedItems.Count <= rcbExams.Items.Count)
                {
                    foreach (RadComboBoxItem chkClient in rcbExams.CheckedItems)
                    {
                        if (chkClient.Checked)
                        {
                            ClientIds = ClientIds + "'" + chkClient.Value + "',";
                        }
                    }
                    // }

                }



                ClientIds = ClientIds.Substring(0, ClientIds.Length - 1);
            }
            catch (Exception Ex)
            {
                ErrorHandlers.ErrorLog.WriteError(Ex);
            }

            return ClientIds;
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

            objBEAdmin.strCourseID = GetExamIds();
            objBEAdmin.IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID]);
            objBAdmin.BGetAppointmentScheduleReportDetails(objBEAdmin);

            DataTable objDt = objBEAdmin.DtResult;


            objDt.Columns["ExamID"].ColumnName = "Exam ID";
            objDt.Columns["StudentFirstName"].ColumnName = "Student First Name";
            objDt.Columns["StudentLastName"].ColumnName = "Student Last Name";
            objDt.Columns["EmailAddress"].ColumnName = "Email Address";
            objDt.Columns["CourseName"].ColumnName = "Course Name";
            objDt.Columns["ExamName"].ColumnName = "Exam Name";
            objDt.Columns["InstructorName"].ColumnName = "Instructor Name";
            objDt.Columns["AppointmentCreationDate"].ColumnName = "Appointment Creation Date [EST]";
            objDt.Columns["AppointmentDate"].ColumnName = "Appointment Date [EST]";
            objDt.Columns["ExamDuration"].ColumnName = "Exam Duration";
            objDt.Columns["FairExamLevel"].ColumnName = "Fair ExamLevel";
            objDt.Columns["StatusName"].ColumnName = "Status";

            objDt.Columns.Remove("CourseID");



            FileInfo rptFileName = new FileInfo(Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["Reports"].ToString()) + @"\Schedule details from_" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss").Replace("/", "-").Replace(":", "-") + ".xls");
            // If any file exists in this directory having name 'Sample1.xlsx', then delete it
            if (rptFileName.Exists)
            {
                rptFileName.Delete(); // ensures we create a new workbook
                rptFileName = new FileInfo(Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["Reports"].ToString()) + @"\Schedule details from_" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss").Replace("/", "-").Replace(":", "-") + ".xls");
            }

            ExcelSheetGenerator objExcel = new ExcelSheetGenerator();
            objExcel.GenerateReport(objDt, rptFileName, "Schedule details Report_", "UserName");
            string ToEmail = txtEmail.Text;

            System.Net.Mail.MailMessage email = new System.Net.Mail.MailMessage();
            StringBuilder body = new StringBuilder();
            email.From = new MailAddress("donotreply@examity.com");
            email.To.Add(ToEmail.Replace(" ", ""));
            email.Subject = "Schedule details";
            body.Append("<table style='font-family:Helvetica;font-size:9pt;width:600px;'>");
            body.Append(@"<tr><td>Hi,<br/><br/>Please find the enclosed Schedule details report.
<br/><br/><br/>Thank you,<br/>Examity.<br/><b>***DO NOT REPLY TO THIS EMAIL***</b></td></tr>");
            body.Append("</table>");
            // Attachment goes here
            Attachment attachment = new Attachment(rptFileName.ToString());
            attachment.Name = "Schedule details" + ".xlsx";
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

        protected void rcbCourses_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {

            string ids = GetCourseIds();
            BEAdmin objBEAdmin = new BEAdmin();
            BAdmin objBAdmin = new BAdmin();
            objBEAdmin.strCourseID = ids;

            if (ids != "'0'")
            {
                rcbExams.Enabled = true;
                if (rcbCourses.CheckedItems.Count > 0)
                {
                    objBAdmin.BGetAllExamDetails(objBEAdmin);

                    if (objBEAdmin.DtResult.Rows.Count > 0)
                    {
                        rcbExams.DataSource = objBEAdmin.DtResult;
                        rcbExams.DataTextField = "ExamName";
                        rcbExams.DataValueField = "ExamID";
                        rcbExams.DataBind();
                    }

                    else
                    {

                        rcbExams.DataSource = new object[] { };
                        rcbExams.DataBind();

                    }

                    if (rcbCourses.CheckedItems.Count == 1)
                    {
                        rcbExams.Enabled = true;

                    }
                    else
                    {
                        foreach (RadComboBoxItem itm in rcbExams.Items)
                        {
                            itm.Checked = true;
                        }

                        rcbExams.Enabled = false;
                    }

                }
                else
                {

                    rcbExams.DataSource = new object[] { };
                    rcbExams.DataBind();
                    rcbExams.Enabled = false;

                }

                //if (rcbCourses.CheckedItems.Count == 0)
                //{

                //    rcbExams.DataSource = new object[] { };
                //    rcbExams.DataBind();
                //    rcbExams.Enabled = false;
                //}

            }
            else
            {
                rcbExams.DataSource = new object[] { };
                rcbExams.DataBind();
                rcbExams.Enabled = false;
            }
        }

        protected void gvReports_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            try
            {
                string ids = GetExamIds();
                LoadSummaryReportSort(ids);
            }
            catch (Exception Ex)
            {
                ErrorHandlers.ErrorLog.WriteError(Ex);
            }
        }
    }
}