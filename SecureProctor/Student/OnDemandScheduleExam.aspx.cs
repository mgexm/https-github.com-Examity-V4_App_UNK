using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using BusinessEntities;
using BLL;
using Telerik.Web.UI.Calendar;

namespace SecureProctor.Student
{
    public partial class OnDemandScheduleExam : BaseClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Page.Title = EnumPageTitles.APPNAME + EnumPageTitles.STUDENT_SCHEDULE;
            ((LinkButton)this.Page.Master.FindControl("lnkSchedule")).CssClass = "main_menu_active";
            if (!IsPostBack)
            {
                if (Request.QueryString["ExamDate"] != null)
                {
                    calSchedular.SelectedDate = Convert.ToDateTime(AppSecurity.Decrypt(Request.QueryString["ExamDate"].ToString()).Replace("EC", "/"));
                    ExamScheduler.SelectedDate = Convert.ToDateTime(AppSecurity.Decrypt(Request.QueryString["ExamDate"].ToString()).Replace("EC", "/"));
                }
                else
                    calSchedular.SelectedDate = DateTime.Now;
                    Session["update"] = Server.UrlEncode(System.DateTime.Now.ToString());
                    //calSchedular.SelectedDate = DateTime.Now;
                    this.BindCourse();
                    this.Bind_GetBookedExamSlots();
            }
            else
                this.Bind_GetBookedExamSlots();
        }

        protected void Page_PreRender(object obj, EventArgs e)
        {
            ViewState["update"] = Session["update"];
        }

        protected void calSchedular_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (calSchedular.SelectedDate.Date.ToShortDateString() != "1/1/0001")
                ExamScheduler.SelectedDate = calSchedular.SelectedDate;
            lblError.Text = string.Empty;
            lblMsg.Text = string.Empty;
        }

        protected void calNavigationChanged(object sender, DefaultViewChangedEventArgs e)
        {
            DateTime dt = calSchedular.FocusedDate;
            ExamScheduler.SelectedDate = dt;
            lblError.Text = string.Empty;
            lblMsg.Text = string.Empty;
        }

        protected void BindCourse()
        {
            drpCourse.Items.Clear();
            drpExam.Items.Clear();
            drpCourse.AppendDataBoundItems = true;
            drpExam.Items.Add(new RadComboBoxItem("--Select exam--", "-1"));

            BECommon objBECommon = new BECommon { IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID]) };
            new BCommon().BBindCourse(objBECommon);

            if (objBECommon.DtResult.Rows.Count > 0)
            {
                drpCourse.Items.Add(new RadComboBoxItem("--Select course--", "-1"));
                drpCourse.DataSource = objBECommon.DtResult;
                drpCourse.DataTextField = "CourseName";
                drpCourse.DataValueField = "CourseID";
                drpCourse.DataBind();
            }
            else
            {
                drpCourse.Items.Clear();
                drpExam.Items.Clear();
                drpCourse.AppendDataBoundItems = true;
                drpExam.AppendDataBoundItems = true;
                drpCourse.Items.Add(new RadComboBoxItem("--Select course--", "-1"));
                drpCourse.DataSource = null;
                drpCourse.DataBind();
            }
        }

        protected void BindExams()
        {
            if (drpCourse.SelectedValue.ToString() != "-1")
            {
                BECommon objBEStudent = new BECommon { IntCourseID = Convert.ToInt32(drpCourse.SelectedValue), IntExamID = 0 };
                new BCommon().BBindExam(objBEStudent);
                if (objBEStudent.DtResult.Rows.Count > 0)
                {
                    drpExam.Items.Clear();
                    RadComboBoxItem rdItem = new RadComboBoxItem("--Select exam--", "-1");
                    drpExam.Items.Add(rdItem);
                    drpExam.AppendDataBoundItems = true;
                    drpExam.DataSource = objBEStudent.DtResult;
                    drpExam.DataTextField = "ExamName";
                    drpExam.DataValueField = "ExamID";
                    drpExam.DataBind();
                }
                else
                {
                    drpExam.Items.Clear();
                    drpExam.AppendDataBoundItems = true;
                    drpExam.Items.Add(new RadComboBoxItem("--Select exam--", "-1"));
                    drpExam.DataSource = null;
                    drpExam.DataBind();
                }
            }
            else
            {
                drpExam.Items.Clear();
                drpExam.AppendDataBoundItems = true;
                drpExam.Items.Add(new RadComboBoxItem("--Select exam--", "-1"));
                drpExam.DataSource = null;
                drpExam.DataBind();
            }
        }

        protected void drpCourse_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            this.BindExams();
        }

        protected void drpExam_IndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (drpCourse.SelectedValue.ToString() != "-1" && drpExam.SelectedValue.ToString() != "-1")
            {
                BECommon objBEStudent = new BECommon { IntCourseID = Convert.ToInt32(drpCourse.SelectedValue), IntExamID = Convert.ToInt32(drpExam.SelectedValue) };
                new BCommon().BBindExam(objBEStudent);
                if (objBEStudent.DtResult.Rows.Count > 0)
                {
                    // Session["ExamID"] = objBEStudent.DtResult.Rows[0]["ExamID"];
                    //Session["ExamName"] = objBEStudent.DtResult.Rows[0]["ExamName"];
                    lblSubjectValue.Text = objBEStudent.DtResult.Rows[0]["ExamDuration"].ToString() + " " + "Minutes";
                    btnProceed.Enabled = true;
                    trError.Visible = false;
                }
            }
            else
            {
                drpExam.Items.Clear();
                RadComboBoxItem rdItem = new RadComboBoxItem("--Select exam--", "-1");
                drpExam.Items.Add(rdItem);
                drpExam.AppendDataBoundItems = true;
                drpExam.DataSource = null;
                drpExam.DataBind();
            }

        }

        protected void Bind_GetBookedExamSlots()
        {
            BECommon objBECommon = new BECommon { IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID]) };
            new BCommon().BBind_GetBookedExamSlots(objBECommon);

            if (objBECommon.DtResult != null)
            {
                ExamScheduler.DataSource = objBECommon.DtResult;
                ExamScheduler.DataBind();
                //ExamScheduler.SelectedDate = System.DateTime.Today;
            }
        }

        protected void Schedule_Reschedule_Proceed_Click(object sender, EventArgs e)
        {
            PanelDock.Visible = false;
            PanelDockConfirm.Visible = true;

            ////if (lblExamIDValue.Text != string.Empty)
            ////{
            ////    tr1.Visible = true;
            ////    lblCExamValue.Text = lblExamIDValue.Text;

            ////}
            ////else
            ////{

            ////    tr1.Visible = false;
            ////}

            if (lblCourse.Text != string.Empty)
            {
                lblCoursevalue.Text = lblCourse.Text;
            }
            else
            {
                lblCoursevalue.Text = drpCourse.SelectedItem.Text;
            }

            if (lblExam.Text != string.Empty)
            {
                lblExamnamevalue.Text = lblExam.Text;
            }
            else
            {
                lblExamnamevalue.Text = drpExam.SelectedItem.Text;
            }
            //lblSubjectValue1.Text = lblSubjectValue.Text;
            lblStartValue.Text = StartTime.SelectedDate.Value.ToString();
            //lblDescriptionValue.Text = txtDescription.Text;
            lblStudentNameValue.Text = Session["UserName"].ToString().Replace("[ Student ]", "");
        }


        protected void Schedule_Reschedule_Click(object sender, EventArgs e)
        {
            if (Session["update"].ToString() == ViewState["update"].ToString())
            {
                if (EditedAppointment == null)
                {
                    Appointment aptToInsert = GetBasicAppointmentFromForm();
                    BEStudent objBEStudent = new BEStudent()
                    {
                        IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID]),
                        IntCourseID = int.Parse(drpCourse.SelectedValue),
                        IntExamID = int.Parse(drpExam.SelectedValue),
                        dtExam = aptToInsert.Start
                    };

                    TimeSpan ts = objBEStudent.dtExam - DateTime.Now;
                    int hours = ts.Hours;
                    objBEStudent.intHours = hours;
                    new BStudent().BStudent_GetAmountForDemandSchedule(objBEStudent);
                    decimal amount = objBEStudent.decAmount;

                    Session["StudentExamDetails"] = objBEStudent;
                    Response.Redirect("NewPayment.aspx?Type=F&" + "ExamFeeAmount=" + amount, false);
                    
                    new BStudent().BStudent_OnDemandScheduleExam(objBEStudent);

                    if (objBEStudent.DsResult != null)
                    {
                        if (Convert.ToInt32(objBEStudent.DsResult.Tables[0].Rows[0]["Result"]) == 1)
                        {
                            BEStudent obj = new BEStudent();
                            obj.IntExamID = Convert.ToInt32(drpExam.SelectedValue);
                            obj.IntTransID = 0;
                            BStudent obj1 = new BStudent();
                            obj1.BGetExamStartEndDates(obj);
                            string StartDate = string.Empty;
                            string EndDate = string.Empty;
                            if (obj.DtResult != null && obj.DtResult.Rows.Count > 0)
                            {
                                StartDate = obj.DtResult.Rows[0]["ExamStartDate"].ToString();
                                EndDate = obj.DtResult.Rows[0]["ExamEndDate"].ToString();

                            }
                            lblMsg.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + "\"" + drpCourse.SelectedItem.Text.ToString() + "- " + drpExam.SelectedItem.Text.ToString() + "\"" + Resources.ResMessages.Schedule_ExamStartEndDateValidation + " " + StartDate + " and " + EndDate + "</font>";
                        }
                        else if (Convert.ToInt32(objBEStudent.DsResult.Tables[0].Rows[0]["Result"]) == 2)
                        {
                            lblMsg.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + Resources.ResMessages.Schedule_24hoursValidation + "</font>";
                        }
                        else if (Convert.ToInt32(objBEStudent.DsResult.Tables[0].Rows[0]["Result"]) == 3)
                        {
                            lblMsg.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + Resources.ResMessages.Schedule_PriorDateValidation + "</font>";
                        }
                        else if (Convert.ToInt32(objBEStudent.DsResult.Tables[0].Rows[0]["Result"]) == 4)
                        {
                            lblMsg.Text = "<img src='../Images/yes.png' align='middle'/>&nbsp;<font color='#00C000'>" + Resources.ResMessages.Schedule_Confirmation + " " + objBEStudent.DsResult.Tables[0].Rows[0]["ID"] + Resources.ResMessages.Schedule_Confirmation1 + "</font>";
                        }
                        else if (Convert.ToInt32(objBEStudent.DsResult.Tables[0].Rows[0]["Result"]) == 5)
                        {
                            lblMsg.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + Resources.ResMessages.Schedule_TimeWindowValidation + "</font>";
                        }
                        else if (Convert.ToInt32(objBEStudent.DsResult.Tables[0].Rows[0]["Result"]) == 6)
                        {
                            objBEStudent.IntExamID = Convert.ToInt32(drpExam.SelectedValue);
                            objBEStudent.IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID]);
                            objBEStudent.IntCourseID = Convert.ToInt32(drpCourse.SelectedValue);
                            new BStudent().BGetExamScheduledDate(objBEStudent);
                            if (objBEStudent.DtResult != null && objBEStudent.DtResult.Rows.Count > 0)
                            {
                                lblMsg.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + "\"" + drpCourse.SelectedItem.Text.ToString() + "- " + drpExam.SelectedItem.Text.ToString() + "\" " + Resources.ResMessages.Student_ExamAlreadyExists + " " + objBEStudent.DtResult.Rows[0]["ExamDate"].ToString() + " at " + objBEStudent.DtResult.Rows[0]["Time"].ToString() + "</font>";
                            }
                            else
                            {
                                lblMsg.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + "\"" + drpCourse.SelectedItem.Text.ToString() + "- " + drpExam.SelectedItem.Text.ToString() + "\"" + Resources.ResMessages.Student_ExamAlreadyExistsElse + "</font>";
                            }
                        }
                    }

                    try
                    {
                        BEMail objBEMail = new BEMail();
                        BMail objBMail = new BMail();
                        objBEMail.IntUserID = 0;
                        objBEMail.IntTransID = Convert.ToInt64(objBEStudent.DsResult.Tables[0].Rows[0]["ID"]);
                        objBEMail.StrTemplateName = BaseClass.EnumEmails.StudentExamReceipt.ToString();

                        //objBMail.BSendEmail(objBEMail);
                        //objBEMail.StrTemplateName = BaseClass.EnumEmails.ExamConfirmationProctorFYI.ToString();
                        // objBMail.BSendEmail(objBEMail);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                else
                {
                    Appointment aptOriginal = EditedAppointment;
                    Appointment aptToUpdate = GetAppointmentFromForm(aptOriginal.Clone());
                    BEStudent objBEStudent = new BEStudent()
                    {
                        IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID]),
                        IntScheduleID = Convert.ToInt32(aptToUpdate.ID.ToString()),
                        dtExam = aptToUpdate.Start,
                        strDescription = aptToUpdate.Description
                    };
                    new BStudent().BStudent_UpdateScheduleExam(objBEStudent);
                    if (objBEStudent.DsResult != null)
                    {

                        if (Convert.ToInt32(objBEStudent.DsResult.Tables[0].Rows[0]["Result"]) == 1)
                        {

                            BEStudent obj = new BEStudent();
                            obj.IntExamID = 0;
                            obj.IntTransID = Convert.ToInt64(aptToUpdate.ID.ToString());
                            BStudent obj1 = new BStudent();
                            obj1.BGetExamStartEndDates(obj);
                            string StartDate = string.Empty;
                            string EndDate = string.Empty;
                            if (obj.DtResult != null && obj.DtResult.Rows.Count > 0)
                            {
                                StartDate = obj.DtResult.Rows[0]["ExamStartDate"].ToString();
                                EndDate = obj.DtResult.Rows[0]["ExamEndDate"].ToString();

                            }

                            lblMsg.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + Resources.ResMessages.Reschedule_ExamStartEndDateValidation + " " + StartDate + " and " + EndDate + "</font>";

                            //lblMsg.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'><b>" + Resources.ResMessages.Reschedule_ExamStartEndDateValidation + "</b></font>";
                        }
                        else if (Convert.ToInt32(objBEStudent.DsResult.Tables[0].Rows[0]["Result"]) == 2)
                        {
                            lblMsg.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + Resources.ResMessages.Reschedule_24hoursValidation + "</font>";
                        }
                        else if (Convert.ToInt32(objBEStudent.DsResult.Tables[0].Rows[0]["Result"]) == 3)
                        {
                            lblMsg.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + Resources.ResMessages.Reschedule_PriorDateValidation + "</font>";
                        }
                        else if (Convert.ToInt32(objBEStudent.DsResult.Tables[0].Rows[0]["Result"]) == 4)
                        {
                            // lblMsg.Text = "<img src='../Images/yes.png' align='middle'/>&nbsp;<font color='#00C000'><b>" + Resources.ResMessages.Reschedule_Confirmation + "</b></font>";
                            lblMsg.Text = "<img src='../Images/yes.png' align='middle'/>&nbsp;<font color='#00C000'>" + Resources.ResMessages.Reschedule_Confirmation + " " + aptToUpdate.ID.ToString() + Resources.ResMessages.Reschedule_Confirmation1 + "</font>";
                        }
                        else if (Convert.ToInt32(objBEStudent.DsResult.Tables[0].Rows[0]["Result"]) == 5)
                        {
                            lblMsg.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + Resources.ResMessages.Reschedule_TimeWindowValidation + "</font>";
                        }
                        else if (Convert.ToInt32(objBEStudent.DsResult.Tables[0].Rows[0]["Result"]) == 6)
                        {
                            lblMsg.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + Resources.ResMessages.Reschedule_ExamProgressValidation + "</font>";
                        }
                    }

                    try
                    {
                        BEMail objBEMail = new BEMail();
                        BMail objBMail = new BMail();
                        objBEMail.IntUserID = 0;
                        objBEMail.IntTransID = Convert.ToInt64(aptToUpdate.ID.ToString());
                        objBEMail.StrTemplateName = BaseClass.EnumEmails.ReScheduleConfirmation.ToString();

                        //objBMail.BSendEmail(objBEMail);
                        //objBEMail.StrTemplateName = BaseClass.EnumEmails.ReScheduleConfirmationProctorFYI.ToString();

                        objBMail.BSendEmail(objBEMail);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }

                lblCourse.Text = string.Empty;
                //lblExam.Text = string.Empty;
                EditedAppointmentID = "";
                Bind_GetBookedExamSlots();
                Session["update"] = Server.UrlEncode(System.DateTime.Now.ToString());
            }
            else
                lblMsg.Text = string.Empty;
        }



        protected void ExamScheduler_FormCreating(object sender, SchedulerFormCreatingEventArgs e)
        {
            lblMsg.Text = string.Empty;
            if (e.Mode == SchedulerFormMode.Insert || e.Mode == SchedulerFormMode.Edit || e.Mode == SchedulerFormMode.AdvancedEdit || e.Mode == SchedulerFormMode.AdvancedInsert)
            {
                EditedAppointment = e.Appointment;
                e.Cancel = true;
            }
            if (e.Mode == SchedulerFormMode.Insert || e.Mode == SchedulerFormMode.AdvancedInsert)
            {
                drpCourse.SelectedValue = "-1";
                drpExam.SelectedValue = "-1";
                lblSubjectValue.Text = "";
                // txtDescription.Text = string.Empty;
                lblExam.Visible = false;
                lblCourse.Visible = false;
                drpCourse.Visible = true;
                drpExam.Visible = true;
                PanelDockConfirm.Visible = false;
                PanelDock.Visible = true;
                btnSchedule_Reschedule.Text = "Confirm";
                RadDock1.Title = "Schedule Exam";
            }
            if (e.Mode == SchedulerFormMode.Edit || e.Mode == SchedulerFormMode.AdvancedEdit)
            {
                drpCourse.Visible = false;
                drpExam.Visible = false;
                lblExam.Visible = true;
                lblCourse.Visible = true;
                PanelDockConfirm.Visible = false;
                PanelDock.Visible = true;
                btnSchedule_Reschedule.Text = "Confirm";
                RadDock1.Title = "Reschedule Exam";
            }

            var appointmentToEdit = ExamScheduler.PrepareToEdit(e.Appointment, ExamScheduler.EditingRecurringSeries);
            ScriptManager.RegisterStartupScript(Page, GetType(), "formScript", "Sys.Application.add_load(openForm);", true);
            GetEditForm(appointmentToEdit);
        }

        Appointment EditedAppointment
        {
            get
            {
                return (EditedAppointmentID != null) ? ExamScheduler.Appointments.FindByID(EditedAppointmentID) : null;
            }
            set
            {
                EditedAppointmentID = value.ID;
            }
        }

        private object EditedAppointmentID
        {
            get { return ViewState["EditedAppointmentID"]; }
            set { ViewState["EditedAppointmentID"] = value; }
        }

        private Appointment GetBasicAppointmentFromForm()
        {
            return GetAppointmentFromForm(null);
        }

        private void GetEditForm(Appointment editedAppointment)
        {
            Appointment appointmentToEdit = ExamScheduler.PrepareToEdit(editedAppointment, ExamScheduler.EditingRecurringSeries);

            if (editedAppointment.ID == null)
            {
                StartTime.SelectedDate = ExamScheduler.UtcToDisplay(appointmentToEdit.Start);
            }
            else
            {
                string[] str = appointmentToEdit.Subject.Split('[');
                lblCourse.Text = str[0].ToString();
                string[] str1 = str[1].Split(']');
                lblExam.Text = str[1].Substring(0, str[1].Length - 1).ToString();
                lblExam.Text = str1[0].ToString();
                // lblSubjectValue.Text = str[0].ToString() + " [ " + str1[0].ToString() + " ] ";
                BEStudent obj = new BEStudent();
                obj.IntExamID = 0;
                obj.IntTransID = Convert.ToInt64(appointmentToEdit.ID.ToString());
                BStudent obj1 = new BStudent();
                obj1.BGetExamStartEndDates(obj);

                if (obj.DtResult != null && obj.DtResult.Rows.Count > 0)
                {
                    lblSubjectValue.Text = obj.DtResult.Rows[0]["ExamMins"].ToString() + " minutes";

                }
                lblExamIDValue.Text = appointmentToEdit.ID.ToString();
                //txtDescription.Text = appointmentToEdit.Description;
                StartTime.SelectedDate = ExamScheduler.UtcToDisplay(appointmentToEdit.Start);
            }
        }

        private Appointment GetAppointmentFromForm(Appointment apt)
        {
            if (apt == null)
                apt = new Appointment();
            DateTime start = ExamScheduler.DisplayToUtc(StartTime.SelectedDate.Value);
            //DateTime end = start.AddMinutes(90);
            // apt.Subject = lblSubjectValue.Text;
            //apt.Description = txtDescription.Text;
            apt.Start = start;
            // apt.End = end;
            return apt;
        }

        protected void RadScheduler1_AppointmentDataBound(object sender, SchedulerEventArgs e)
        {
            if (e.Appointment.Description.ToString() == "1")
                e.Appointment.BackColor = System.Drawing.Color.LightGreen;
            else if (e.Appointment.Description.ToString() == "3")
                e.Appointment.BackColor = System.Drawing.Color.LightBlue;
            else
                e.Appointment.BackColor = System.Drawing.Color.Orange;
        }

        protected void RadScheduler1_AppointmentDelete(object sender, SchedulerCancelEventArgs e)
        {
            try
            {
                lblMsg.Text = string.Empty;
                int iID = Convert.ToInt32(e.Appointment.ID);
                BEStudent objBEStudent = new BEStudent();
                objBEStudent.IntTransID = iID;
                objBEStudent.IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID]);
                BStudent objBStudent = new BStudent();
                objBStudent.BDeleteAppointment(objBEStudent);
                Bind_GetBookedExamSlots();

                if (objBEStudent.DtResult.Rows.Count > 0 && objBEStudent.DtResult != null)
                {

                    if (Convert.ToInt32(objBEStudent.DtResult.Rows[0]["Result"]) != 1)
                    {
                        lblMsg.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + Resources.ResMessages.AppointmentDelete + "</font>";
                    }

                    else
                    {
                        lblMsg.Text = "<img src='../Images/yes.png'align='middle'/>&nbsp;<font color='#00C000'>" + "Exam (Exam ID: " + iID + ")" + Resources.ResMessages.AppointmentDeleteSuccess + "</font>";
                        try
                        {
                            BEMail objBEMail = new BEMail();
                            BMail objBMail = new BMail();
                            objBEMail.IntUserID = 0;
                            objBEMail.IntTransID = Convert.ToInt64(iID.ToString());
                            objBEMail.StrTemplateName = BaseClass.EnumEmails.ExamCancelConfirmation.ToString();

                            objBMail.BSendEmail(objBEMail);
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}