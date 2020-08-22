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
    public partial class ScheduleExam : BaseClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Page.Title = EnumPageTitles.APPNAME + EnumPageTitles.STUDENT_SCHEDULE;
                ((LinkButton)this.Page.Master.FindControl("lnkSchedule")).CssClass = "main_menu_active";
                if (this.SetAccessibility())
                {
                    if (Session["ACCESSIBILITY"] != null)
                    {
                        if (Session["ACCESSIBILITY"].ToString() == "ON")
                        {
                            btnAccessibility.ToggleStates[0].Selected = true;
                            pnlAccessibility.Visible = true;
                        }
                        else
                        {
                            btnAccessibility.ToggleStates[1].Selected = true;
                            pnlAccessibility.Visible = true;
                        }
                    }
                    else
                    {
                        Session["ACCESSIBILITY"] = "OFF";
                        btnAccessibility.ToggleStates[1].Selected = true;
                        pnlAccessibility.Visible = true;
                    }
                }
                else
                {
                    Session["ACCESSIBILITY"] = "OFF";
                    btnAccessibility.ToggleStates[1].Selected = true;
                    pnlAccessibility.Visible = false;
                }
            }
            if (Session["ACCESSIBILITY"].ToString() == "OFF")
            {
                #region AccessibilityOFF
                pnlSchedule_Accessibility_On.Visible = false;
                pnlSchedule_Accessibility_Off.Visible = true;
                if (!IsPostBack)
                {
                    Session["BESTUDENT"] = null;
                    if (Request.QueryString["ExamDate"] != null)
                    {
                        DateTime dt = Convert.ToDateTime(AppSecurity.Decrypt(Request.QueryString["ExamDate"].ToString()).Replace("EC", "/"));
                        if (dt < GetUserCurrentTime().AddDays(1))
                        {
                            calSchedular.RangeMinDate = dt;
                            StartTime.MinDate = dt;
                        }
                        calSchedular.SelectedDate = dt;
                        ExamScheduler.SelectedDate = dt;
                    }
                    else
                    {
                        setCalScheduler();
                        calSchedular.SelectedDate = GetUserCurrentTime().AddHours(24);
                        ExamScheduler.SelectedDate = GetUserCurrentTime().AddHours(24);
                    }
                    StartTime.SelectedDate = calSchedular.SelectedDate;
                    Session["update"] = Server.UrlEncode(System.DateTime.Now.ToString());
                   // this.BindCourse();
                    this.Bind_GetBookedExamSlots();
                    this.GetSlotsTable_Reset();
                    this.BGetAvaialbleTimeSlots_Reset();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "NotSaved", "document.getElementById('" + imgHead.ClientID.ToString() + "').focus();", true);
                }
                #endregion
            }
            else
            {
                #region AccessibilityON
                if (!IsPostBack)
                {
                    pnlSchedule_Accessibility_On.Visible = true;
                    pnlSchedule_Accessibility_Off.Visible = false;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "NotSaved", "document.getElementById('" + imgHead.ClientID.ToString() + "').focus();", true);
                    this.CheckForExamType();
                }
                #endregion
            }
            this.CheckMyProfile();
        }
        protected void Page_PreRender(object obj, EventArgs e)
        {
            ViewState["update"] = Session["update"];
        }
        protected void btnOnDemand_Click(object sender, EventArgs e)
        {
            if (btnOnDemand.SelectedToggleState.Value == "ON")
            {
                btnOnDemand1.ToggleStates[0].Selected = true;
            }
            else
            {
                btnOnDemand1.ToggleStates[1].Selected = true;
            }
            setCalScheduler();
            int AddHours = 0;
            if (btnOnDemand.SelectedToggleState.Value == "ON")
            {
                calSchedular.SelectedDate = GetUserCurrentTime();
                StartTime.SelectedDate = GetUserCurrentTime().Date;
                ExamScheduler.SelectedDate = GetUserCurrentTime();
            }
            else
            {
                //AddHours = 48;
                AddHours = 24;
                calSchedular.SelectedDate = GetUserCurrentTime().AddHours(AddHours);
                StartTime.SelectedDate = GetUserCurrentTime().AddHours(AddHours).Date;
                ExamScheduler.SelectedDate = GetUserCurrentTime().AddHours(AddHours);
            }
            this.GetSlotsTable_Reset();
            this.BGetAvaialbleTimeSlots_Reset();
            BindTimeSlots();
            calSchedular.RangeMinDate = DateTime.Parse(GetUserCurrentTime().AddHours(AddHours).ToShortDateString());
            StartTime.MinDate = DateTime.Parse(GetUserCurrentTime().AddHours(AddHours).ToShortDateString());
            validateSelectedDate();
            this.Bind_GetBookedExamSlots();
        }
        protected void calNavigationChanged(object sender, DefaultViewChangedEventArgs e)
        {
            DateTime dt = calSchedular.FocusedDate;
            ExamScheduler.SelectedDate = dt;
            lblError.Text = string.Empty;
            lblMsg.Text = string.Empty;
            lblMsg1.Text = string.Empty;
        }
        protected void BindCourse()
        {

            if (drpInstructor.SelectedIndex == 0)
            {
                drpCourse.Items.Clear();
                drpExam.Items.Clear();
                drpCourse.Items.Add(new RadComboBoxItem("--Select course--", "-1"));
                drpExam.Items.Add(new RadComboBoxItem("--Select exam--", "-1"));
                drpCourse.DataSource = null;
                drpCourse.DataBind();
                drpExam.DataSource = null;
                drpExam.DataBind();
                lblSubjectValue.Text = string.Empty;
            }
            else
            {
                drpCourse.Items.Clear();
                drpExam.Items.Clear();
                drpCourse.AppendDataBoundItems = true;
                drpExam.Items.Add(new RadComboBoxItem("--Select exam--", "-1"));

                BECommon objBECommon = new BECommon { IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID]), IntProviderID = Convert.ToInt32(drpInstructor.SelectedValue) };
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
                    RadComboBoxItem rdItem = new RadComboBoxItem("--Select exam--", "-1");
                    drpExam.Items.Add(rdItem);
                    drpCourse.DataSource = null;
                    drpCourse.DataBind();
                }
            }
        }

        protected void BindExams()
        {
            if (drpCourse.SelectedValue.ToString() != "-1")
            {
                BECommon objBEStudent = new BECommon
                {
                    IntCourseID = Convert.ToInt32(drpCourse.SelectedValue),
                    IntExamID = 0,
                    IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID])
                };
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


        protected void GetInstructors()
        {
            BECommon objBECommon = new BECommon { IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID]) };
            new BCommon().BGetInstructors(objBECommon);
            if (objBECommon.DtResult.Rows.Count > 0)
            {
                this.ResetDropDowns();
                drpInstructor.DataSource = objBECommon.DtResult;
                drpInstructor.DataTextField = "ProviderName";
                drpInstructor.DataValueField = "ExamProviderID";
                drpInstructor.DataBind();


            }
            else
            {
                this.ResetDropDowns();

            }

        }

        protected void ResetDropDowns()
        {
            drpInstructor.Items.Clear();
            drpCourse.Items.Clear();
            drpExam.Items.Clear();
            drpCourse.AppendDataBoundItems = true;
            drpExam.AppendDataBoundItems = true;
            drpInstructor.AppendDataBoundItems = true;
            drpInstructor.Items.Add(new RadComboBoxItem("--Select Instructor--", "-1"));
            drpCourse.Items.Add(new RadComboBoxItem("--Select course--", "-1"));
            RadComboBoxItem rdItem = new RadComboBoxItem("--Select exam--", "-1");
            drpExam.Items.Add(rdItem);
            lblSubjectValue.Text = string.Empty;



        }
        protected void drpCourse_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            this.BindExams();
        }

        protected void drpInstructor_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            this.BindCourse();
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
            // lblStartValue.Text = calSchedular.SelectedDate.ToString();
            lblStartValue.Text = StartTime.SelectedDate.Value.ToString();
            lblStudentNameValue.Text = Session["UserName"].ToString().Replace("[ Student ]", "");
            BEStudent objBEStudent = new BEStudent();
            if (EditedAppointment == null)
            {
                objBEStudent.IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID]);
                objBEStudent.IntCourseID = int.Parse(drpCourse.SelectedValue);
                objBEStudent.IntExamID = int.Parse(drpExam.SelectedValue);
                objBEStudent.dtExam = StartTime.SelectedDate.Value;
                BStudent objBStudent = new BStudent();
                objBStudent.BCheckExamBoundaries(objBEStudent);
                if (objBEStudent.DsResult != null && objBEStudent.DsResult.Tables.Count > 0 && objBEStudent.DsResult.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToInt32(objBEStudent.DsResult.Tables[0].Rows[0][0]) == 0)
                    {
                        btnSchedule_Reschedule.Visible = false;
                        //lblExamError.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + "\"" + drpCourse.SelectedItem.Text.ToString() + "- " + drpExam.SelectedItem.Text.ToString() + "\"" + Resources.ResMessages.Schedule_ExamStartEndDateValidation + " " + objBEStudent.DsResult.Tables[0].Rows[0][1].ToString() + " and " + objBEStudent.DsResult.Tables[0].Rows[0][2].ToString() + "</font>";
                        lblExamError.Text = "Exam can be scheduled between  " + objBEStudent.DsResult.Tables[0].Rows[0][1].ToString() + " and " + objBEStudent.DsResult.Tables[0].Rows[0][2].ToString();
                    }
                    else
                    {
                        btnSchedule_Reschedule.Visible = true;
                        lblExamError.Text = string.Empty;
                    }
                }
                else
                {
                    btnSchedule_Reschedule.Visible = true;
                    lblExamError.Text = string.Empty;
                }

            }
            else
            {
                objBEStudent.IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID]);
                objBEStudent.dtExam = StartTime.SelectedDate.Value;
                objBEStudent.IntTransID = Convert.ToInt64(ViewState["EditedAppointmentID"]);
                BStudent objBStudent = new BStudent();
                objBStudent.BCheckExamBoundariesReschedule(objBEStudent);
                if (objBEStudent.DsResult != null && objBEStudent.DsResult.Tables.Count > 0 && objBEStudent.DsResult.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToInt32(objBEStudent.DsResult.Tables[0].Rows[0][0]) == 0)
                    {
                        btnSchedule_Reschedule.Visible = false;
                        //lblExamError.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + "\"" + drpCourse.SelectedItem.Text.ToString() + "- " + drpExam.SelectedItem.Text.ToString() + "\"" + Resources.ResMessages.Schedule_ExamStartEndDateValidation + " " + objBEStudent.DsResult.Tables[0].Rows[0][1].ToString() + " and " + objBEStudent.DsResult.Tables[0].Rows[0][2].ToString() + "</font>";
                        lblExamError.Text = "Exam can be Rescheduled between  " + objBEStudent.DsResult.Tables[0].Rows[0][1].ToString() + " and " + objBEStudent.DsResult.Tables[0].Rows[0][2].ToString();
                    }
                    else
                    {
                        btnSchedule_Reschedule.Visible = true;
                        lblExamError.Text = string.Empty;
                    }
                }
                else
                {
                    btnSchedule_Reschedule.Visible = true;
                    lblExamError.Text = string.Empty;
                }

            }
        }
        protected void SetExamFeeSettings(Int64 intID, String strType)
        {
            BEStudent objBEStudent = new BEStudent();
            BStudent objBStudent = new BStudent();
            objBEStudent.IntExamID1 = intID;
            objBEStudent.IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID]);
            if (strType == "EXAMID")
                objBStudent.BGetExamFeeSettingsByExamID(objBEStudent);
            else
                objBStudent.BGetExamFeeSettingsByTransID(objBEStudent);
            Session[EnumPayment.PaidBY_ExamFee] = objBEStudent.intExamFeePaidBy.ToString();
            Session[EnumPayment.PaidBY_OndeMand] = objBEStudent.intOndemandPaidBy.ToString();
            objBEStudent = null;
            objBStudent = null;
        }
        protected void Schedule_Reschedule_Click(object sender, EventArgs e)
        {
            if (Session["update"].ToString() == ViewState["update"].ToString())
            {

                if (EditedAppointment == null)
                {
                    #region NewAppointment
                    Appointment aptToInsert = GetBasicAppointmentFromForm();
                    BEStudent objBEStudent = new BEStudent()
                    {
                        IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID]),
                        IntCourseID = int.Parse(drpCourse.SelectedValue),
                        IntExamID = int.Parse(drpExam.SelectedValue),
                        dtExam = aptToInsert.Start
                    };
                    this.SetExamFeeSettings(int.Parse(drpExam.SelectedValue), "EXAMID");
                    if (Session[EnumPayment.PaidBY_ExamFee] != null && Session[EnumPayment.PaidBY_OndeMand] != null)
                    {
                        if (btnOnDemand.SelectedToggleState.Value == "ON")
                        {
                            #region If On-demand is ON

                            DateTime Appointmentdate = objBEStudent.dtExam;

                            if (Session[EnumPayment.PaidBY_ExamFee].ToString() == EnumPayment.PaidBy_University && Session[EnumPayment.PaidBY_OndeMand].ToString() == EnumPayment.PaidBy_University)
                            {
                                objBEStudent.intOndemand = 1;
                                new BStudent().BStudent_ScheduleExam(objBEStudent);
                                this.ShowAlert_ScheduleExam_Create(objBEStudent);
                            }
                            else if (Session[EnumPayment.PaidBY_ExamFee].ToString() == EnumPayment.PaidBy_University && Session[EnumPayment.PaidBY_OndeMand].ToString() == EnumPayment.PaidBy_Student)
                            {
                                objBEStudent.intOndemand = 1;
                                new BStudent().BStudent_ValidateExam(objBEStudent);
                                if (objBEStudent.IntResult == 4)
                                    this.ProcessPayment_Schedule(objBEStudent);
                                else
                                    this.ShowAlert_ScheduleExam_Validate(objBEStudent.IntResult);
                            }
                            else if (Session[EnumPayment.PaidBY_ExamFee].ToString() == EnumPayment.PaidBy_Student && Session[EnumPayment.PaidBY_OndeMand].ToString() == EnumPayment.PaidBy_University)
                            {
                                objBEStudent.intOndemand = 1;
                                new BStudent().BStudent_ValidateExam(objBEStudent);
                                if (objBEStudent.IntResult == 4)
                                    this.ProcessPayment_Schedule(objBEStudent);
                                else
                                    this.ShowAlert_ScheduleExam_Validate(objBEStudent.IntResult);
                            }
                            else if (Session[EnumPayment.PaidBY_ExamFee].ToString() == EnumPayment.PaidBy_Student && Session[EnumPayment.PaidBY_OndeMand].ToString() == EnumPayment.PaidBy_Student)
                            {
                                objBEStudent.intOndemand = 1;
                                new BStudent().BStudent_ValidateExam(objBEStudent);
                                if (objBEStudent.IntResult == 4)
                                    this.ProcessPayment_Schedule(objBEStudent);
                                else
                                    this.ShowAlert_ScheduleExam_Validate(objBEStudent.IntResult);
                            }
                            #endregion
                        }
                        else if (btnOnDemand.SelectedToggleState.Value == "OFF")
                        {
                            #region If On-demand is OFF
                            if (Session[EnumPayment.PaidBY_ExamFee].ToString() == EnumPayment.PaidBy_University)
                            {
                                objBEStudent.intOndemand = 0;
                                new BStudent().BStudent_ScheduleExam(objBEStudent);
                                this.ShowAlert_ScheduleExam_Create(objBEStudent);
                            }
                            else if (Session[EnumPayment.PaidBY_ExamFee].ToString() == EnumPayment.PaidBy_Student)
                            {
                                objBEStudent.intOndemand = 0;
                                new BStudent().BStudent_ValidateExam(objBEStudent);
                                if (objBEStudent.IntResult == 4)
                                    this.ProcessPayment_Schedule(objBEStudent);
                                else
                                    this.ShowAlert_ScheduleExam_Validate(objBEStudent.IntResult);
                            }
                            #endregion
                        }
                    }
                    else
                    {
                        #region If the Payment is not configured
                        new BStudent().BStudent_ScheduleExam(objBEStudent);
                        this.ShowAlert_ScheduleExam_Create(objBEStudent);
                        #endregion
                    }
                    #endregion
                }
                else
                {
                    #region EditAppointment

                    Appointment aptOriginal = EditedAppointment;
                    Appointment aptToUpdate = GetAppointmentFromForm(aptOriginal.Clone());
                    BEStudent objBEStudent = new BEStudent()
                    {
                        IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID]),
                        IntScheduleID = Convert.ToInt32(aptToUpdate.ID.ToString()),
                        dtExam = aptToUpdate.Start,
                        strDescription = aptToUpdate.Description
                    };
                    this.SetExamFeeSettings(objBEStudent.IntScheduleID, "TRANSID");
                    Int64 intTransID = Convert.ToInt64(aptToUpdate.ID.ToString());
                    if (Session[EnumPayment.PaidBY_ExamFee] != null && Session[EnumPayment.PaidBY_OndeMand] != null)
                    {
                        if (btnOnDemand.SelectedToggleState.Value == "ON")
                        {
                            #region If On-demand is ON
                            if (Session[EnumPayment.PaidBY_ExamFee].ToString() == EnumPayment.PaidBy_University && Session[EnumPayment.PaidBY_OndeMand].ToString() == EnumPayment.PaidBy_University)
                            {
                                objBEStudent.intOndemand = 1;
                                new BStudent().BStudent_UpdateScheduleExam(objBEStudent);
                                this.ShowAlert_ScheduleExam_Update(objBEStudent);
                            }
                            else if (Session[EnumPayment.PaidBY_ExamFee].ToString() == EnumPayment.PaidBy_University && Session[EnumPayment.PaidBY_OndeMand].ToString() == EnumPayment.PaidBy_Student)
                            {
                                objBEStudent.intOndemand = 1;
                                new BStudent().BStudent_ValidateRescheduledExam(objBEStudent);
                                if (objBEStudent.IntResult == 4)
                                {
                                    if (objBEStudent.decAmount != 0)
                                        this.ProcessPayment_Schedule(objBEStudent);
                                    else
                                    {
                                        new BStudent().BStudent_ReScheduleExamOnDemand(objBEStudent);
                                        this.ShowAlert_ScheduleExam_Update(objBEStudent);
                                    }
                                }
                                else
                                    this.ShowAlert_ReScheduleExam_Validate(objBEStudent.IntResult, intTransID);
                            }
                            else if (Session[EnumPayment.PaidBY_ExamFee].ToString() == EnumPayment.PaidBy_Student && Session[EnumPayment.PaidBY_ExamFee].ToString() == EnumPayment.PaidBy_University)
                            {
                                objBEStudent.intOndemand = 1;
                                new BStudent().BStudent_ValidateRescheduledExam(objBEStudent);
                                if (objBEStudent.IntResult == 4)
                                {
                                    if (objBEStudent.decAmount != 0)
                                        this.ProcessPayment_Schedule(objBEStudent);
                                    else
                                    {
                                        new BStudent().BStudent_ReScheduleExamOnDemand(objBEStudent);
                                        this.ShowAlert_ScheduleExam_Update(objBEStudent);
                                    }
                                }
                                else
                                    this.ShowAlert_ReScheduleExam_Validate(objBEStudent.IntResult, intTransID);
                            }
                            else if (Session[EnumPayment.PaidBY_ExamFee].ToString() == EnumPayment.PaidBy_Student && Session[EnumPayment.PaidBY_ExamFee].ToString() == EnumPayment.PaidBy_Student)
                            {
                                objBEStudent.intOndemand = 1;
                                new BStudent().BStudent_ValidateRescheduledExam(objBEStudent);
                                if (objBEStudent.IntResult == 4)
                                {
                                    if (objBEStudent.decAmount != 0)
                                        this.ProcessPayment_Schedule(objBEStudent);
                                    else
                                    {
                                        new BStudent().BStudent_ReScheduleExamOnDemand(objBEStudent);
                                        this.ShowAlert_ScheduleExam_Update(objBEStudent);
                                    }
                                }
                                else
                                    this.ShowAlert_ReScheduleExam_Validate(objBEStudent.IntResult, intTransID);
                            }
                            #endregion
                        }
                        else if (btnOnDemand.SelectedToggleState.Value == "OFF")
                        {
                            #region If On-demand is OFF
                            if (Session[EnumPayment.PaidBY_ExamFee].ToString() == EnumPayment.PaidBy_University)
                            {
                                objBEStudent.intOndemand = 0;
                                new BStudent().BStudent_UpdateScheduleExam(objBEStudent);
                                this.ShowAlert_ScheduleExam_Update(objBEStudent);
                            }
                            else if (Session[EnumPayment.PaidBY_ExamFee].ToString() == EnumPayment.PaidBy_Student)
                            {
                                objBEStudent.intOndemand = 0;
                                new BStudent().BStudent_ValidateRescheduledExam(objBEStudent);
                                if (objBEStudent.IntResult == 4)
                                {
                                    if (objBEStudent.decAmount != 0)
                                        this.ProcessPayment_Schedule(objBEStudent);
                                    else
                                    {
                                        new BStudent().BStudent_ReScheduleExamOnDemand(objBEStudent);
                                        this.ShowAlert_ScheduleExam_Update(objBEStudent);
                                    }
                                }
                                else
                                    this.ShowAlert_ReScheduleExam_Validate(objBEStudent.IntResult, intTransID);
                            }
                            #endregion
                        }
                    }
                    else
                    {
                        #region If the Payment is not configured
                        new BStudent().BStudent_UpdateScheduleExam(objBEStudent);
                        this.ShowAlert_ScheduleExam_Update(objBEStudent);
                        #endregion
                    }
                    #endregion
                }
                lblCourse.Text = string.Empty;
                EditedAppointmentID = "";
                Bind_GetBookedExamSlots();
                Session["update"] = Server.UrlEncode(System.DateTime.Now.ToString());
            }
            else
            {
                lblMsg.Text = string.Empty;
                lblMsg1.Text = string.Empty;
            }
            this.Bind_GetBookedExamSlots();
        }
        protected void LogPayments(Int64 intTransID, decimal decExamFee, decimal decOnDemandFee, string strType)
        {
            if (strType == EnumPayment.ExamType_Scheduled)
            {
                BEStudent objBEStudent = new BEStudent();
                objBEStudent.IntTransID = intTransID;
                objBEStudent.decExamFee = decExamFee;
                objBEStudent.decOnDemandFee = decOnDemandFee;
                objBEStudent.intExamFeePaidBy = Convert.ToInt32(Session[EnumPayment.PaidBY_ExamFee].ToString());
                objBEStudent.intOndemandPaidBy = Convert.ToInt32(Session[EnumPayment.PaidBY_OndeMand].ToString());
                new BStudent().BSetPaymentDetails_Scheduled(objBEStudent);
            }
            else
            {
                BEStudent objBEStudent = new BEStudent();
                objBEStudent.IntTransID = intTransID;
                objBEStudent.decExamFee = decExamFee;
                objBEStudent.decOnDemandFee = decOnDemandFee;
                objBEStudent.intExamFeePaidBy = Convert.ToInt32(Session[EnumPayment.PaidBY_ExamFee].ToString());
                objBEStudent.intOndemandPaidBy = Convert.ToInt32(Session[EnumPayment.PaidBY_OndeMand].ToString());
                new BStudent().BSetPaymentDetails_Recheduled(objBEStudent);
            }
        }
        protected void ShowAlert_ScheduleExam_Create(BEStudent objBEStudent)
        {
            if (objBEStudent.DsResult != null)
            {
                if (Convert.ToInt32(objBEStudent.DsResult.Tables[0].Rows[0]["Result"]) == 1)
                {
                    BEStudent obj = new BEStudent();
                    if (btnAccessibility.SelectedToggleState.Value == "OFF")
                        obj.IntExamID = Convert.ToInt32(drpExam.SelectedValue);
                    else
                        obj.IntExamID = Convert.ToInt32(ddlExams.SelectedValue);
                    obj.IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID]);
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
                    if (btnAccessibility.SelectedToggleState.Value == "OFF")
                        lblMsg.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + "\"" + drpCourse.SelectedItem.Text.ToString() + "- " + drpExam.SelectedItem.Text.ToString() + "\"" + Resources.ResMessages.Schedule_ExamStartEndDateValidation + " " + StartDate + " and " + EndDate + "</font>";
                    else
                    {
                        lblMsg1.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + "\"" + ddlCourses.SelectedItem.Text.ToString() + "- " + ddlExams.SelectedItem.Text.ToString() + "\"" + Resources.ResMessages.Schedule_ExamStartEndDateValidation + " " + StartDate + " and " + EndDate + "</font>";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "NotSaved", "document.getElementById('" + lblMsg1.ClientID.ToString() + "').focus();", true);
                    }
                }
                else if (Convert.ToInt32(objBEStudent.DsResult.Tables[0].Rows[0]["Result"]) == 2)
                {
                    if (btnAccessibility.SelectedToggleState.Value == "OFF")
                        lblMsg.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + Resources.ResMessages.Schedule_24hoursValidation + "</font>";
                    else
                    {
                        lblMsg1.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + Resources.ResMessages.Schedule_24hoursValidation + "</font>";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "NotSaved", "document.getElementById('" + lblMsg1.ClientID.ToString() + "').focus();", true);
                    }
                }
                else if (Convert.ToInt32(objBEStudent.DsResult.Tables[0].Rows[0]["Result"]) == 3)
                {
                    if (btnAccessibility.SelectedToggleState.Value == "OFF")
                        lblMsg.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + Resources.ResMessages.Schedule_PriorDateValidation + "</font>";
                    else
                    {
                        lblMsg1.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + Resources.ResMessages.Schedule_PriorDateValidation + "</font>";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "NotSaved", "document.getElementById('" + lblMsg1.ClientID.ToString() + "').focus();", true);
                    }
                }
                else if (Convert.ToInt32(objBEStudent.DsResult.Tables[0].Rows[0]["Result"]) == 4)
                {
                    if (btnAccessibility.SelectedToggleState.Value == "OFF")
                        lblMsg.Text = "<img src='../Images/yes.png' align='middle'/>&nbsp;<font color='#00C000'>" + Resources.ResMessages.Schedule_Confirmation + " " + objBEStudent.DsResult.Tables[0].Rows[0]["ID"] + Resources.ResMessages.Schedule_Confirmation1 + "</font>";
                    else
                    {
                        lblMsg1.Text = "<img src='../Images/yes.png' align='middle'/>&nbsp;<font color='#00C000'>" + Resources.ResMessages.Schedule_Confirmation + " " + objBEStudent.DsResult.Tables[0].Rows[0]["ID"] + Resources.ResMessages.Schedule_Confirmation1 + "</font>";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "NotSaved", "document.getElementById('" + lblMsg1.ClientID.ToString() + "').focus();", true);
                    }
                    try
                    {
                        BEMail objBEMail = new BEMail();
                        BMail objBMail = new BMail();
                        objBEMail.IntUserID = 0;
                        objBEMail.IntTransID = Convert.ToInt64(objBEStudent.DsResult.Tables[0].Rows[0]["ID"]);
                        objBEMail.StrTemplateName = BaseClass.EnumEmails.StudentExamReceipt.ToString();
                        objBMail.BSendEmail(objBEMail);
                    }
                    catch (Exception ex)
                    {
                    }
                    this.LogPayments(Convert.ToInt32(objBEStudent.DsResult.Tables[0].Rows[0]["ID"].ToString()), objBEStudent.decExamFee + objBEStudent.PerHourFee, objBEStudent.decOnDemandFee, EnumPayment.ExamType_Scheduled);
                }
                else if (Convert.ToInt32(objBEStudent.DsResult.Tables[0].Rows[0]["Result"]) == 5)
                {
                    if (btnAccessibility.SelectedToggleState.Value == "OFF")
                        lblMsg.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + Resources.ResMessages.Schedule_TimeWindowValidation + "</font>";
                    else
                    {
                        lblMsg1.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + Resources.ResMessages.Schedule_TimeWindowValidation + "</font>";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "NotSaved", "document.getElementById('" + lblMsg1.ClientID.ToString() + "').focus();", true);
                    }
                }
                else if (Convert.ToInt32(objBEStudent.DsResult.Tables[0].Rows[0]["Result"]) == 6)
                {
                    if (btnAccessibility.SelectedToggleState.Value == "OFF")
                    {
                        objBEStudent.IntExamID = Convert.ToInt32(drpExam.SelectedValue);
                        objBEStudent.IntCourseID = Convert.ToInt32(drpCourse.SelectedValue);
                    }
                    else
                    {
                        objBEStudent.IntExamID = Convert.ToInt32(ddlExams.SelectedValue);
                        objBEStudent.IntCourseID = Convert.ToInt32(ddlCourses.SelectedValue);
                    }
                    objBEStudent.IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID]);
                    new BStudent().BGetExamScheduledDate(objBEStudent);
                    if (objBEStudent.DtResult != null && objBEStudent.DtResult.Rows.Count > 0)
                    {
                        if (btnAccessibility.SelectedToggleState.Value == "OFF")
                            lblMsg.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + "\"" + drpCourse.SelectedItem.Text.ToString() + "- " + drpExam.SelectedItem.Text.ToString() + "\" " + Resources.ResMessages.Student_ExamAlreadyExists + " " + objBEStudent.DtResult.Rows[0]["ExamDate"].ToString() + " at " + objBEStudent.DtResult.Rows[0]["Time"].ToString() + "</font>";
                        else
                        {
                            lblMsg1.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + "\"" + ddlCourses.SelectedItem.Text.ToString() + "- " + ddlExams.SelectedItem.Text.ToString() + "\" " + Resources.ResMessages.Student_ExamAlreadyExists + " " + objBEStudent.DtResult.Rows[0]["ExamDate"].ToString() + " at " + objBEStudent.DtResult.Rows[0]["Time"].ToString() + "</font>";
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "NotSaved", "document.getElementById('" + lblMsg1.ClientID.ToString() + "').focus();", true);
                        }
                    }
                    else
                    {
                        if (btnAccessibility.SelectedToggleState.Value == "OFF")
                            lblMsg.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + "\"" + drpCourse.SelectedItem.Text.ToString() + "- " + drpExam.SelectedItem.Text.ToString() + "\"" + Resources.ResMessages.Student_ExamAlreadyExistsElse + "</font>";
                        else
                        {
                            lblMsg1.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + "\"" + ddlCourses.SelectedItem.Text.ToString() + "- " + ddlExams.SelectedItem.Text.ToString() + "\"" + Resources.ResMessages.Student_ExamAlreadyExistsElse + "</font>";
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "NotSaved", "document.getElementById('" + lblMsg1.ClientID.ToString() + "').focus();", true);
                        }
                    }
                }

                else if (Convert.ToInt32(objBEStudent.DsResult.Tables[0].Rows[0]["Result"]) == 7)
                {
                    if (btnAccessibility.SelectedToggleState.Value == "OFF")
                        lblMsg.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + Resources.ResMessages.Schedule_OndemandValidation + "</font>";
                    else
                    {
                        lblMsg1.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + Resources.ResMessages.Schedule_OndemandValidation + "</font>";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "NotSaved", "document.getElementById('" + lblMsg1.ClientID.ToString() + "').focus();", true);
                    }
                }
            }
        }
        protected void ShowAlert_ScheduleExam_Update(BEStudent objBEStudent)
        {
            if (objBEStudent.DsResult != null)
            {
                if (Convert.ToInt32(objBEStudent.DsResult.Tables[0].Rows[0]["Result"]) == 1)
                {
                    BEStudent obj = new BEStudent();
                    obj.IntExamID = 0;
                    obj.IntTransID = Convert.ToInt64(objBEStudent.IntScheduleID);
                    obj.IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID]);
                    BStudent obj1 = new BStudent();
                    obj1.BGetExamStartEndDates(obj);
                    string StartDate = string.Empty;
                    string EndDate = string.Empty;
                    if (obj.DtResult != null && obj.DtResult.Rows.Count > 0)
                    {
                        StartDate = obj.DtResult.Rows[0]["ExamStartDate"].ToString();
                        EndDate = obj.DtResult.Rows[0]["ExamEndDate"].ToString();
                    }
                    if (btnAccessibility.SelectedToggleState.Value == "OFF")
                        lblMsg.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + Resources.ResMessages.Reschedule_ExamStartEndDateValidation + " " + StartDate + " and " + EndDate + "</font>";
                    else
                    {
                        lblMsg1.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + Resources.ResMessages.Reschedule_ExamStartEndDateValidation + " " + StartDate + " and " + EndDate + "</font>";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "NotSaved", "document.getElementById('" + lblMsg1.ClientID.ToString() + "').focus();", true);
                    }
                }
                else if (Convert.ToInt32(objBEStudent.DsResult.Tables[0].Rows[0]["Result"]) == 2)
                {
                    if (btnAccessibility.SelectedToggleState.Value == "OFF")
                        lblMsg.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + Resources.ResMessages.Reschedule_24hoursValidation + "</font>";
                    else
                    {
                        lblMsg1.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + Resources.ResMessages.Reschedule_24hoursValidation + "</font>";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "NotSaved", "document.getElementById('" + lblMsg1.ClientID.ToString() + "').focus();", true);
                    }
                }
                else if (Convert.ToInt32(objBEStudent.DsResult.Tables[0].Rows[0]["Result"]) == 3)
                {
                    if (btnAccessibility.SelectedToggleState.Value == "OFF")
                        lblMsg.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + Resources.ResMessages.Reschedule_PriorDateValidation + "</font>";
                    else
                    {
                        lblMsg1.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + Resources.ResMessages.Reschedule_PriorDateValidation + "</font>";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "NotSaved", "document.getElementById('" + lblMsg1.ClientID.ToString() + "').focus();", true);
                    }
                }
                else if (Convert.ToInt32(objBEStudent.DsResult.Tables[0].Rows[0]["Result"]) == 4)
                {
                    if (btnAccessibility.SelectedToggleState.Value == "OFF")
                        lblMsg.Text = "<img src='../Images/yes.png' align='middle'/>&nbsp;<font color='#00C000'>" + Resources.ResMessages.Reschedule_Confirmation + " " + objBEStudent.IntScheduleID.ToString() + Resources.ResMessages.Reschedule_Confirmation1 + "</font>";
                    else
                    {
                        lblMsg1.Text = "<img src='../Images/yes.png' align='middle'/>&nbsp;<font color='#00C000'>" + Resources.ResMessages.Reschedule_Confirmation + " " + objBEStudent.IntScheduleID.ToString() + Resources.ResMessages.Reschedule_Confirmation1 + "</font>";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "NotSaved", "document.getElementById('" + lblMsg1.ClientID.ToString() + "').focus();", true);
                    }
                    try
                    {
                        BEMail objBEMail = new BEMail();
                        BMail objBMail = new BMail();
                        objBEMail.IntUserID = 0;
                        objBEMail.IntTransID = Convert.ToInt64(objBEStudent.IntScheduleID);
                        objBEMail.StrTemplateName = BaseClass.EnumEmails.ReScheduleConfirmation.ToString();
                        objBMail.BSendEmail(objBEMail);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    this.LogPayments(Convert.ToInt32(objBEStudent.IntScheduleID), objBEStudent.decExamFee + objBEStudent.PerHourFee, objBEStudent.decOnDemandFee, EnumPayment.ExamType_Rescheduled);
                }
                else if (Convert.ToInt32(objBEStudent.DsResult.Tables[0].Rows[0]["Result"]) == 5)
                {
                    if (btnAccessibility.SelectedToggleState.Value == "OFF")
                        lblMsg.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + Resources.ResMessages.Reschedule_TimeWindowValidation + "</font>";
                    else
                    {
                        lblMsg1.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + Resources.ResMessages.Reschedule_TimeWindowValidation + "</font>";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "NotSaved", "document.getElementById('" + lblMsg1.ClientID.ToString() + "').focus();", true);
                    }
                }
                else if (Convert.ToInt32(objBEStudent.DsResult.Tables[0].Rows[0]["Result"]) == 6)
                {
                    if (btnAccessibility.SelectedToggleState.Value == "OFF")
                        lblMsg.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + Resources.ResMessages.Reschedule_ExamProgressValidation + "</font>";
                    else
                    {
                        lblMsg1.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + Resources.ResMessages.Reschedule_ExamProgressValidation + "</font>";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "NotSaved", "document.getElementById('" + lblMsg1.ClientID.ToString() + "').focus();", true);
                    }
                }

                else if (Convert.ToInt32(objBEStudent.DsResult.Tables[0].Rows[0]["Result"]) == 7)
                {
                    if (btnAccessibility.SelectedToggleState.Value == "OFF")
                        lblMsg.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + Resources.ResMessages.Schedule_OndemandValidation + "</font>";
                    else
                    {
                        lblMsg1.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + Resources.ResMessages.Schedule_OndemandValidation + "</font>";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "NotSaved", "document.getElementById('" + lblMsg1.ClientID.ToString() + "').focus();", true);
                    }
                }


            }
        }
        protected void ShowAlert_ScheduleExam_Validate(int intResult)
        {
            if (intResult == 1)
            {
                BEStudent obj = new BEStudent();
                if (btnAccessibility.SelectedToggleState.Value == "OFF")
                    obj.IntExamID = Convert.ToInt32(drpExam.SelectedValue);
                else
                    obj.IntExamID = Convert.ToInt32(ddlExams.SelectedValue);
                obj.IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID]);
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
                if (btnAccessibility.SelectedToggleState.Value == "OFF")
                    lblMsg.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + "\"" + drpCourse.SelectedItem.Text.ToString() + "- " + drpExam.SelectedItem.Text.ToString() + "\"" + Resources.ResMessages.Schedule_ExamStartEndDateValidation + " " + StartDate + " and " + EndDate + "</font>";
                else
                {
                    lblMsg1.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + "\"" + ddlCourses.SelectedItem.Text.ToString() + "- " + ddlExams.SelectedItem.Text.ToString() + "\"" + Resources.ResMessages.Schedule_ExamStartEndDateValidation + " " + StartDate + " and " + EndDate + "</font>";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "NotSaved", "document.getElementById('" + lblMsg1.ClientID.ToString() + "').focus();", true);
                }
            }
            else if (intResult == 2)
            {
                if (btnAccessibility.SelectedToggleState.Value == "OFF")
                    lblMsg.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + Resources.ResMessages.Schedule_24hoursValidation + "</font>";
                else
                {
                    lblMsg1.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + Resources.ResMessages.Schedule_24hoursValidation + "</font>";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "NotSaved", "document.getElementById('" + lblMsg1.ClientID.ToString() + "').focus();", true);
                }
            }
            else if (intResult == 3)
            {
                if (btnAccessibility.SelectedToggleState.Value == "OFF")
                    lblMsg.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + Resources.ResMessages.Schedule_PriorDateValidation + "</font>";
                else
                {
                    lblMsg1.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + Resources.ResMessages.Schedule_PriorDateValidation + "</font>";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "NotSaved", "document.getElementById('" + lblMsg1.ClientID.ToString() + "').focus();", true);
                }
            }
            else if (intResult == 5)
            {
                if (btnAccessibility.SelectedToggleState.Value == "OFF")
                    lblMsg.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + Resources.ResMessages.Schedule_TimeWindowValidation + "</font>";
                else
                {
                    lblMsg1.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + Resources.ResMessages.Schedule_TimeWindowValidation + "</font>";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "NotSaved", "document.getElementById('" + lblMsg1.ClientID.ToString() + "').focus();", true);
                }
            }
            else if (intResult == 6)
            {
                BEStudent objBEStudent = new BEStudent();
                if (btnAccessibility.SelectedToggleState.Value == "OFF")
                {
                    objBEStudent.IntExamID = Convert.ToInt32(drpExam.SelectedValue);
                    objBEStudent.IntCourseID = Convert.ToInt32(drpCourse.SelectedValue);
                }
                else
                {
                    objBEStudent.IntExamID = Convert.ToInt32(ddlExams.SelectedValue);
                    objBEStudent.IntCourseID = Convert.ToInt32(ddlCourses.SelectedValue);
                }
                objBEStudent.IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID]);
                new BStudent().BGetExamScheduledDate(objBEStudent);
                if (objBEStudent.DtResult != null && objBEStudent.DtResult.Rows.Count > 0)
                {
                    if (btnAccessibility.SelectedToggleState.Value == "OFF")
                        lblMsg.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + "\"" + drpCourse.SelectedItem.Text.ToString() + "- " + drpExam.SelectedItem.Text.ToString() + "\" " + Resources.ResMessages.Student_ExamAlreadyExists + " " + objBEStudent.DtResult.Rows[0]["ExamDate"].ToString() + " at " + objBEStudent.DtResult.Rows[0]["Time"].ToString() + "</font>";
                    else
                    {
                        lblMsg1.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + "\"" + ddlCourses.SelectedItem.Text.ToString() + "- " + ddlExams.SelectedItem.Text.ToString() + "\" " + Resources.ResMessages.Student_ExamAlreadyExists + " " + objBEStudent.DtResult.Rows[0]["ExamDate"].ToString() + " at " + objBEStudent.DtResult.Rows[0]["Time"].ToString() + "</font>";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "NotSaved", "document.getElementById('" + lblMsg1.ClientID.ToString() + "').focus();", true);
                    }
                }
                else
                {
                    if (btnAccessibility.SelectedToggleState.Value == "OFF")
                        lblMsg.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + "\"" + drpCourse.SelectedItem.Text.ToString() + "- " + drpExam.SelectedItem.Text.ToString() + "\"" + Resources.ResMessages.Student_ExamAlreadyExistsElse + "</font>";
                    else
                    {
                        lblMsg1.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + "\"" + ddlCourses.SelectedItem.Text.ToString() + "- " + ddlExams.SelectedItem.Text.ToString() + "\"" + Resources.ResMessages.Student_ExamAlreadyExistsElse + "</font>";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "NotSaved", "document.getElementById('" + lblMsg1.ClientID.ToString() + "').focus();", true);
                    }
                }
            }
            else if (intResult == 7)
            {
                if (btnAccessibility.SelectedToggleState.Value == "OFF")
                    lblMsg.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + Resources.ResMessages.Schedule_OndemandValidation + "</font>";
                else
                {
                    lblMsg1.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + Resources.ResMessages.Schedule_OndemandValidation + "</font>";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "NotSaved", "document.getElementById('" + lblMsg1.ClientID.ToString() + "').focus();", true);
                }
            }

        }
        protected void ShowAlert_ReScheduleExam_Validate(int intResult, Int64 intTransID)
        {
            if (intResult == 1)
            {
                BEStudent obj = new BEStudent();
                obj.IntExamID = 0;
                obj.IntTransID = intTransID;
                obj.IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID]);
                BStudent obj1 = new BStudent();
                obj1.BGetExamStartEndDates(obj);
                string StartDate = string.Empty;
                string EndDate = string.Empty;
                if (obj.DtResult != null && obj.DtResult.Rows.Count > 0)
                {
                    StartDate = obj.DtResult.Rows[0]["ExamStartDate"].ToString();
                    EndDate = obj.DtResult.Rows[0]["ExamEndDate"].ToString();
                }
                if (btnAccessibility.SelectedToggleState.Value == "OFF")
                    lblMsg.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + Resources.ResMessages.Reschedule_ExamStartEndDateValidation + " " + StartDate + " and " + EndDate + "</font>";
                else
                {
                    lblMsg1.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + Resources.ResMessages.Reschedule_ExamStartEndDateValidation + " " + StartDate + " and " + EndDate + "</font>";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "NotSaved", "document.getElementById('" + lblMsg1.ClientID.ToString() + "').focus();", true);
                }
            }
            else if (intResult == 2)
            {
                if (btnAccessibility.SelectedToggleState.Value == "OFF")
                    lblMsg.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + Resources.ResMessages.Reschedule_24hoursValidation + "</font>";
                else
                {
                    lblMsg1.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + Resources.ResMessages.Reschedule_24hoursValidation + "</font>";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "NotSaved", "document.getElementById('" + lblMsg1.ClientID.ToString() + "').focus();", true);
                }
            }
            else if (intResult == 3)
            {
                if (btnAccessibility.SelectedToggleState.Value == "OFF")
                    lblMsg.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + Resources.ResMessages.Reschedule_PriorDateValidation + "</font>";
                else
                {
                    lblMsg1.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + Resources.ResMessages.Reschedule_PriorDateValidation + "</font>";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "NotSaved", "document.getElementById('" + lblMsg1.ClientID.ToString() + "').focus();", true);
                }
            }
            else if (intResult == 5)
            {
                if (btnAccessibility.SelectedToggleState.Value == "OFF")
                    lblMsg.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + Resources.ResMessages.Reschedule_TimeWindowValidation + "</font>";
                else
                {
                    lblMsg1.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + Resources.ResMessages.Reschedule_TimeWindowValidation + "</font>";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "NotSaved", "document.getElementById('" + lblMsg1.ClientID.ToString() + "').focus();", true);
                }
            }
            else if (intResult == 6)
            {
                if (btnAccessibility.SelectedToggleState.Value == "OFF")
                    lblMsg.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + Resources.ResMessages.Reschedule_ExamProgressValidation + "</font>";
                else
                {
                    lblMsg1.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + Resources.ResMessages.Reschedule_ExamProgressValidation + "</font>";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "NotSaved", "document.getElementById('" + lblMsg1.ClientID.ToString() + "').focus();", true);
                }
            }
            else if (intResult == 7)
            {
                if (btnAccessibility.SelectedToggleState.Value == "OFF")
                    lblMsg.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + Resources.ResMessages.ReSchedule_OndemandValidation + "</font>";
                else
                {
                    lblMsg1.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + Resources.ResMessages.ReSchedule_OndemandValidation + "</font>";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "NotSaved", "document.getElementById('" + lblMsg1.ClientID.ToString() + "').focus();", true);
                }
            }


        }
        protected void ProcessPayment_Schedule(BEStudent objBEStudent)
        {
            if (btnAccessibility.SelectedToggleState.Value == "OFF")
            {
                objBEStudent.strCourseName = drpCourse.SelectedItem.Text.ToString();
                objBEStudent.strExamName = drpExam.SelectedItem.Text.ToString();
            }
            else
            {
                if (Request.QueryString["ExamID"] == null)
                {
                    objBEStudent.strCourseName = ddlCourses.SelectedItem.Text.ToString();
                    objBEStudent.strExamName = ddlExams.SelectedItem.Text.ToString();
                }
                else
                {
                    objBEStudent.strCourseName = lblAccessibilityCourseName.Text.ToString();
                    objBEStudent.strExamName = lblAccessibilityExamName.Text.ToString();
                }
            }
            Session["BESTUDENT"] = objBEStudent;
            Response.Redirect("PaymentProcess.aspx");
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
                lblExam.Text = str1[0].ToString();
                lblInstructor.Text = str1[1].ToString();
               
                BEStudent obj = new BEStudent();
                obj.IntExamID = 0;
                obj.IntTransID = Convert.ToInt64(appointmentToEdit.ID.ToString());
                obj.IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID]);
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
                lblMsg1.Text = string.Empty;
                Int64 iID = Convert.ToInt32(e.Appointment.ID);
                BEStudent objBEStudent = new BEStudent();
                objBEStudent.IntTransID = iID;
                objBEStudent.IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID]);
                BStudent objBStudent = new BStudent();
                objBStudent.BDeleteAppointment(objBEStudent);
                this.BGetAvaialbleTimeSlots_Reset();
                Bind_GetBookedExamSlots();

                if (objBEStudent.DtResult.Rows.Count > 0 && objBEStudent.DtResult != null)
                {

                    if (Convert.ToInt32(objBEStudent.DtResult.Rows[0]["Result"]) != 1)
                    {
                        if (btnAccessibility.SelectedToggleState.Value == "OFF")
                            lblMsg.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + Resources.ResMessages.AppointmentDelete + "</font>";
                        else
                        {
                            lblMsg1.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + Resources.ResMessages.AppointmentDelete + "</font>";
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "NotSaved", "document.getElementById('" + lblMsg1.ClientID.ToString() + "').focus();", true);
                        }
                    }

                    else
                    {
                        if (btnAccessibility.SelectedToggleState.Value == "OFF")
                            if (objBEStudent.DtResult.Rows[0]["CancelledWithIn24Hours"] != null)
                            {
                                if (objBEStudent.DtResult.Rows[0]["CancelledWithIn24Hours"].ToString() == "1")
                                    lblMsg.Text = "<img src='../Images/yes.png'align='middle'/>&nbsp;<font color='#00C000'>" + "Exam (Exam ID: " + iID + ")</br>" + Resources.ResMessages.AppointmentDeleteSuccess_LessThan24Hours + "</font>";
                                else
                                    lblMsg.Text = "<img src='../Images/yes.png'align='middle'/>&nbsp;<font color='#00C000'>" + "Exam (Exam ID: " + iID + ")" + Resources.ResMessages.AppointmentDeleteSuccess + "</font>";
                            }
                            else
                                lblMsg.Text = "<img src='../Images/yes.png'align='middle'/>&nbsp;<font color='#00C000'>" + "Exam (Exam ID: " + iID + ")" + Resources.ResMessages.AppointmentDeleteSuccess + "</font>";
                        else
                        {
                            if (objBEStudent.DtResult.Rows[0]["CancelledWithIn24Hours"] != null)
                            {
                                if (objBEStudent.DtResult.Rows[0]["CancelledWithIn24Hours"].ToString() == "1")
                                    lblMsg.Text = "<img src='../Images/yes.png'align='middle'/>&nbsp;<font color='#00C000'>" + "Exam (Exam ID: " + iID + ")</br>" + Resources.ResMessages.AppointmentDeleteSuccess_LessThan24Hours + "</font>";
                                else
                                    lblMsg.Text = "<img src='../Images/yes.png'align='middle'/>&nbsp;<font color='#00C000'>" + "Exam (Exam ID: " + iID + ")" + Resources.ResMessages.AppointmentDeleteSuccess + "</font>";
                            }
                            else
                                lblMsg1.Text = "<img src='../Images/yes.png'align='middle'/>&nbsp;<font color='#00C000'>" + "Exam (Exam ID: " + iID + ")" + Resources.ResMessages.AppointmentDeleteSuccess + "</font>";
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "NotSaved", "document.getElementById('" + lblMsg1.ClientID.ToString() + "').focus();", true);
                        }
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
        protected void CheckMyProfile()
        {
            BEStudent objBEStudent = new BEStudent();
            BStudent objBStudent = new BStudent();
            objBEStudent.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID]);
            objBStudent.BValidateUploadandQuestions(objBEStudent);
            if (objBEStudent.DsResult != null && objBEStudent.DsResult.Tables.Count > 0 && objBEStudent.DsResult.Tables[0].Rows.Count > 0)
            {

                if (Convert.ToInt32(objBEStudent.DsResult.Tables[0].Rows[0]["PhotoCheck"]) == 1 && Convert.ToInt32(objBEStudent.DsResult.Tables[0].Rows[0]["QuestionsCheck"]) == 1 && Convert.ToInt32(objBEStudent.DsResult.Tables[0].Rows[0]["TimeZoneCheck"]) == 1)
                {
                    tblContent.Visible = true;
                    tblMyProfile.Visible = false;
                    lblMyprofile.Text = string.Empty;
                }
                else
                {
                    tblContent.Visible = false;
                    tblMyProfile.Visible = true;
                    lblMyprofile.Text = Resources.ResMessages.Student_MyProfileCheck;

                }

            }
            else
            {
                tblContent.Visible = false;
            }
        }
        protected void drpExam_IndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (drpCourse.SelectedValue.ToString() != "-1" && drpExam.SelectedValue.ToString() != "-1")
            {
                BECommon objBEStudent = new BECommon { IntCourseID = Convert.ToInt32(drpCourse.SelectedValue), IntExamID = Convert.ToInt32(drpExam.SelectedValue), IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID]) };
                new BCommon().BBindExam(objBEStudent);
                if (objBEStudent.DtResult.Rows.Count > 0)
                {
                    lblSubjectValue.Text = objBEStudent.DtResult.Rows[0]["ExamDuration"].ToString() + " " + "Minutes";
                    btnProceed.Enabled = true;
                    trError.Visible = false;
                   
                    //this.BindTimeSlots();
                    validateSelectedDate();
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
        protected void ExamScheduler_FormCreating(object sender, SchedulerFormCreatingEventArgs e)
        {
            if (Session["ACCESSIBILITY"].ToString() == "OFF")
            {
                lblMsg.Text = string.Empty;
                lblMsg1.Text = string.Empty;
                if (e.Mode == SchedulerFormMode.Insert || e.Mode == SchedulerFormMode.Edit || e.Mode == SchedulerFormMode.AdvancedEdit || e.Mode == SchedulerFormMode.AdvancedInsert)
                {
                    EditedAppointment = e.Appointment;
                    e.Cancel = true;
                }
                if (e.Mode == SchedulerFormMode.Insert || e.Mode == SchedulerFormMode.AdvancedInsert)
                {
                    this.GetInstructors();
                    drpInstructor.SelectedValue = "-1";
                    drpCourse.SelectedValue = "-1";
                    drpExam.SelectedValue = "-1";
                    lblSubjectValue.Text = "";
                    this.BindCourse();
                    lblExam.Visible = false;
                    lblCourse.Visible = false;
                    lblInstructor.Visible = false;
                    drpCourse.Visible = true;
                    drpExam.Visible = true;
                    drpInstructor.Visible = true;
                    PanelDockConfirm.Visible = false;
                    PanelDock.Visible = true;
                    btnSchedule_Reschedule.Text = "Confirm";
                    RadDock1.Title = "Schedule Exam";

                    var appointmentToEdit = ExamScheduler.PrepareToEdit(e.Appointment, ExamScheduler.EditingRecurringSeries);
                    if (!GetSlotStaus(appointmentToEdit.Start.ToString("MM/dd/yyyy HH:mm:ss")))
                    {
                        ScriptManager.RegisterStartupScript(Page, GetType(), "formScript", "Sys.Application.add_load(openForm);", true);
                        GetEditForm(appointmentToEdit);
                        BindTimeSlots();
                    }
                    trRescheduleWarningMessage.Visible = false; //Task_Id=41//
                }
                if (e.Mode == SchedulerFormMode.Edit || e.Mode == SchedulerFormMode.AdvancedEdit)
                {
                    ResetDropDowns();
                    drpCourse.Visible = false;
                    drpExam.Visible = false;
                    drpInstructor.Visible = false;
                    lblExam.Visible = true;
                    lblCourse.Visible = true;
                    lblInstructor.Visible = true;
                    PanelDockConfirm.Visible = false;
                    PanelDock.Visible = true;
                    btnSchedule_Reschedule.Text = "Confirm";
                    RadDock1.Title = "Reschedule Exam";

                    var appointmentToEdit = ExamScheduler.PrepareToEdit(e.Appointment, ExamScheduler.EditingRecurringSeries);
                    ScriptManager.RegisterStartupScript(Page, GetType(), "formScript", "Sys.Application.add_load(openForm);", true);
                    GetEditForm(appointmentToEdit);
                    BindTimeSlots();
                    trRescheduleWarningMessage.Visible = true; //Task_Id=41//
                }
                validateSelectedDate();
            }
        }
        protected void ExamScheduler_TimeSlotCreated(object sender, TimeSlotCreatedEventArgs e)
        {
            if (Session["ACCESSIBILITY"].ToString() == "OFF")
            {
                if (this.GetSlotStaus(e.TimeSlot.Start.ToString("MM/dd/yyyy HH:mm:ss")))
                {
                    e.TimeSlot.CssClass += "Disabled";
                }
            }
        }
        protected void calSchedular_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (calSchedular.SelectedDate.Date.ToShortDateString() != "1/1/0001")
            {
                ExamScheduler.SelectedDate = calSchedular.SelectedDate;
                if (StartTime.SelectedDate.Value.ToShortDateString() != "1/1/0001")
                    StartTime.SelectedDate = DateTime.Parse(calSchedular.SelectedDate.ToShortDateString() + " " + StartTime.SelectedDate.Value.ToShortTimeString());
                else
                    StartTime.SelectedDate = calSchedular.SelectedDate;
                setCalScheduler();
                this.BGetAvaialbleTimeSlots_Reset();
            }
            else
            {
                calSchedular.SelectedDate = ExamScheduler.SelectedDate;
                StartTime.SelectedDate = calSchedular.SelectedDate;
            }

            this.GetSlotsTable_Reset();
            BindTimeSlots();
            validateSelectedDate();
            this.Bind_GetBookedExamSlots();
        }
        protected System.Data.DataTable BGetAvailableTimeSlotsTable()
        {
            System.Data.DataTable dtResult = new System.Data.DataTable();
            //Below code commented by Manoj to bind the time slots on selected date time changed
            if (Session["TIMESLOTS"] != null)
                dtResult = (System.Data.DataTable)Session["TIMESLOTS"];
            else
            {
                this.BGetAvaialbleTimeSlots_Reset();
                dtResult = (System.Data.DataTable)Session["TIMESLOTS"];
            }
            return dtResult;
        }
        protected void BGetAvaialbleTimeSlots_Reset()
        {
            BECommon objBECommon = new BECommon();
            BCommon objBCommon = new BCommon();
            objBECommon.IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID]);
            if (btnOnDemand.SelectedToggleState.Value == "ON")
                objBECommon.intOndemand = 1;
            else
                objBECommon.intOndemand = 0;
            objBECommon.dtExam = StartTime.SelectedDate.Value;
            //objBECommon.dtExam = calSchedular.SelectedDate;
            objBCommon.BGetAvailableTimeSlots(objBECommon);
            Session["TIMESLOTS"] = objBECommon.DtResult;
            objBECommon = null;
            objBCommon = null;
        }
        protected void BindTimeSlots()
        {
            System.Data.DataTable dtResult = BGetAvailableTimeSlotsTable();
            System.Data.DataSet dsResult = this.GetSlotsTable();

            bool skip = false;
            if (dsResult.Tables[0].Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in dsResult.Tables[0].Rows)
                {
                    if (DateTime.Parse(dr["Slot"].ToString()).ToShortDateString() == DateTime.Parse(dtResult.Rows[0]["ExamSlot"].ToString()).ToShortDateString())
                    {
                        skip = true;
                    }
                }
            }

            if (skip)
            {
                DateTime[] dtTimeArray = new DateTime[0];
                SharedTimeView.CustomTimeValues = dtTimeArray;
                dtTimeArray = null;
            }
            else
            {
                //System.Data.DataRow[] dr = dtResult.Select();
                //DateTime[] dtTimeArray = Array.ConvertAll(dr, DataRowToString);
                //SharedTimeView.CustomTimeValues = dtTimeArray;
                //dtTimeArray = null;
                //dr = null;
                DateTime[] dtTimeArray = new DateTime[dtResult.Rows.Count];
                for (int intI = 0; intI < dtResult.Rows.Count; intI++)
                {
                    dtTimeArray[intI] = Convert.ToDateTime(dtResult.Rows[intI]["ExamSlot"].ToString());

                }
                SharedTimeView.CustomTimeValues = dtTimeArray;
                dtTimeArray = null;
            }
            dtResult = null;
            dsResult = null;
        }
        public DateTime DataRowToString(System.Data.DataRow dr)
        {
            return Convert.ToDateTime(dr["ExamSlot"].ToString());
        }
        //FOR SLOTS BLOCKING - START
        protected bool GetSlotStaus(string strDate)
        {
            bool boolStatus = false;

            System.Data.DataSet dsResult = this.GetSlotsTable();
            if (dsResult.Tables[0].Rows.Count > 0)
            {
                boolStatus = true;
            }
            else if (dsResult.Tables[1].Rows.Count > 0)
            {
                System.Data.DataRow[] Result = dsResult.Tables[1].Select("Slot = '" + Convert.ToDateTime(strDate).ToString("MM/dd/yyyy HH:mm:ss").Replace("-", "/") + "'");
                if (Result.Length == 0)
                    boolStatus = false;
                else
                    boolStatus = true;
            }
            if (boolStatus == false)
            {
                System.Data.DataTable dtResult = this.BGetAvailableTimeSlotsTable();
                System.Data.DataRow[] Result = dtResult.Select("ExamSlot = '" + Convert.ToDateTime(strDate).ToString("MM/dd/yyyy hh:mm:ss tt").Replace("-", "/") + "'");
                if (Result.Length != 0)
                    boolStatus = false;
                else
                    boolStatus = true;
            }
            dsResult = null;
            return boolStatus;

            // true :  block
            // false : unblock
        }
        protected System.Data.DataSet GetSlotsTable()
        {
            if (Session["DSSLOTS"] == null)
                this.GetSlotsTable_Reset();
            return (System.Data.DataSet)Session["DSSLOTS"];
        }
        protected void GetSlotsTable_Reset()
        {
            try
            {
                BEProctor objBEProctor = new BEProctor();
                BProctor objBProctor = new BProctor();
                objBEProctor.StrDate = Convert.ToDateTime(calSchedular.SelectedDate).ToString("MM/dd/yyyy").Replace("-", "/").ToString();
                objBEProctor.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID].ToString());
                objBProctor.BGetBlockedDatesForSelectedDate(objBEProctor);
                Session["DSSLOTS"] = objBEProctor.DsResult;
                objBEProctor = null;
                objBProctor = null;
            }
            catch
            {
            }
        }
        //FOR SLOTS BLOCKING - END
        public void setCalScheduler()
        {
            if (btnOnDemand.SelectedToggleState.Value == "ON")
            {
                calSchedular.RangeMinDate = DateTime.Parse(GetUserCurrentTime().ToShortDateString());
                StartTime.MinDate = DateTime.Parse(GetUserCurrentTime().ToShortDateString());
            }
            else
            {
                calSchedular.RangeMinDate = DateTime.Parse(GetUserCurrentTime().AddDays(1).ToShortDateString());
                StartTime.MinDate = DateTime.Parse(GetUserCurrentTime().AddDays(1).ToShortDateString());
            }
        }
        protected void StartTime_SelectedDateChanged(object sender, SelectedDateChangedEventArgs e)
        {
            calSchedular.SelectedDate = StartTime.SelectedDate.Value;
            ExamScheduler.SelectedDate = calSchedular.SelectedDate;
            this.BGetAvaialbleTimeSlots_Reset();
            this.GetSlotsTable_Reset();
            BindTimeSlots();
            validateSelectedDate();
        }
        public void validateSelectedDate()
        {
            trError.Visible = false;          
            lblError.Text = string.Empty;
            lblMsg.Text = string.Empty;
            lblMsg1.Text = string.Empty;
            btnProceed.Visible = true;
            bool validDate = false;
            DateTime[] dtArray = (DateTime[])SharedTimeView.CustomTimeValues;
            if (dtArray != null)
            {
                if (dtArray.Length > 0)
                {
                    foreach (DateTime dt in dtArray)
                    {
                        if (dt == StartTime.SelectedDate.Value || validDate)
                            validDate = true;
                    }
                }
            }
            if (!validDate)
            {
                trError.Visible = true;
                lblError.Text = GetGlobalResourceObject("ResMessages", "Slot_Unavailable").ToString();
                btnProceed.Visible = false;
            }
            else
                lblError.Text = string.Empty;
        }
        public DateTime GetUserCurrentTime()
        {
            BECommon objBECommon = new BECommon();
            BCommon objBCommon = new BCommon();
            objBECommon.iTimeZoneID = Convert.ToInt32(Session["TimeZoneID"]);
            objBCommon.BGetTimeDelay(objBECommon);
            return DateTime.Parse(DateTime.UtcNow.AddMinutes(objBECommon.IntResult).ToString("MM/dd/yyyy HH:mm tt"));
        }
        protected void RadScheduler1_NavigationComplete(object sender, SchedulerNavigationCompleteEventArgs e)
        {
            lblMsg.Text = string.Empty;
            lblMsg1.Text = string.Empty;
        }
        protected void ExamScheduler_NavigationComplete(object sender, SchedulerNavigationCompleteEventArgs e)
        {
            if (e.Command.ToString() == "NavigateToNextPeriod" || e.Command.ToString() == "NavigateToPreviousPeriod")
                this.BindCalendar();
        }
        protected void BindCalendar()
        {
            try
            {
                calSchedular.SelectedDate = ExamScheduler.SelectedDate;
                StartTime.SelectedDate = calSchedular.SelectedDate;
                this.BGetAvaialbleTimeSlots_Reset();
                this.GetSlotsTable_Reset();
                BindTimeSlots();
                validateSelectedDate();
            }
            catch
            {

            }
        }
        //Accessibility Code :  Start
        protected void btnAccessibility_Click(object sender, EventArgs e)
        {
            BEStudent objBEStudent = new BEStudent();
            BStudent objBStudent = new BStudent();
            objBEStudent.IntStudentID = Convert.ToInt32(Session[EnumPageSessions.USERID].ToString());
            if (btnAccessibility.SelectedToggleState.Value == "ON")
                objBEStudent.IntResult = 1;
            else
                objBEStudent.IntResult = 0;
            objBStudent.BUpdateAccessibility(objBEStudent);
            objBEStudent = null;
            objBStudent = null;

            if (btnAccessibility.SelectedToggleState.Value == "ON")
            {
                Session["ACCESSIBILITY"] = "ON";
                pnlSchedule_Accessibility_On.Visible = true;
                pnlSchedule_Accessibility_Off.Visible = false;
                #region AccessibilityON
                this.CheckForExamType();
                #endregion
            }
            else
            {
                Session["ACCESSIBILITY"] = "OFF";
                pnlSchedule_Accessibility_On.Visible = false;
                pnlSchedule_Accessibility_Off.Visible = true;
                #region AccessibilityOFF
                Session["BESTUDENT"] = null;
                if (Request.QueryString["ExamDate"] != null)
                {
                    DateTime dt = Convert.ToDateTime(AppSecurity.Decrypt(Request.QueryString["ExamDate"].ToString()).Replace("EC", "/"));
                    if (dt < GetUserCurrentTime().AddDays(1))
                    {
                        calSchedular.RangeMinDate = dt;
                        StartTime.MinDate = dt;
                    }
                    calSchedular.SelectedDate = dt;
                    ExamScheduler.SelectedDate = dt;
                }
                else
                {
                    setCalScheduler();
                    calSchedular.SelectedDate = GetUserCurrentTime().AddHours(24);
                    ExamScheduler.SelectedDate = GetUserCurrentTime().AddHours(24);
                }
                StartTime.SelectedDate = calSchedular.SelectedDate;
                Session["update"] = Server.UrlEncode(System.DateTime.Now.ToString());
                this.BindCourse();
                this.Bind_GetBookedExamSlots();
                this.GetSlotsTable_Reset();
                this.BGetAvaialbleTimeSlots_Reset();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "NotSaved", "document.getElementById('" + imgHead.ClientID.ToString() + "').focus();", true);

                #endregion
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "NotSaved", "document.getElementById('" + btnAccessibility.ClientID.ToString() + "').focus();", true);
        }
        protected bool SetAccessibility()
        {
            bool boolAccessibility = false;
            BEStudent objBEStudent = new BEStudent();
            BStudent objBStudent = new BStudent();
            objBEStudent.IntStudentID = Convert.ToInt32(Session[EnumPageSessions.USERID].ToString());
            objBStudent.BGetAccessibility(objBEStudent);
            if (objBEStudent.IntResult == 1)
                boolAccessibility = true;
            else
                boolAccessibility = false;
            if (objBEStudent.IntFlag == 1)
                Session["ACCESSIBILITY"] = "ON";
            else
                Session["ACCESSIBILITY"] = "OFF";
            return boolAccessibility;
        }
        protected void BindCourse_Accessibility()
        {
            ddlCourses.Items.Clear();
            ddlCourses.Items.Clear();
            ddlCourses.AppendDataBoundItems = true;
            ddlExams.Items.Add(new RadComboBoxItem("--Select exam--", "-1"));

            BECommon objBECommon = new BECommon { IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID]) };
            new BCommon().BBindCourse_Accessibility(objBECommon);

            if (objBECommon.DtResult.Rows.Count > 0)
            {
                ddlCourses.Items.Add(new RadComboBoxItem("--Select course--", "-1"));
                ddlCourses.DataSource = objBECommon.DtResult;
                ddlCourses.DataTextField = "CourseName";
                ddlCourses.DataValueField = "CourseID";
                ddlCourses.DataBind();
            }
            else
            {
                ddlCourses.Items.Clear();
                ddlExams.Items.Clear();
                ddlCourses.AppendDataBoundItems = true;
                ddlExams.AppendDataBoundItems = true;
                ddlCourses.Items.Add(new RadComboBoxItem("--Select course--", "-1"));
                RadComboBoxItem rdItem = new RadComboBoxItem("--Select exam--", "-1");
                drpExam.Items.Add(rdItem);
                ddlCourses.DataSource = null;
                ddlCourses.DataBind();
            }
        }
        protected void BindExams_Accessibility()
        {
            if (ddlCourses.SelectedValue.ToString() != "-1")
            {
                BECommon objBEStudent = new BECommon
                {
                    IntCourseID = Convert.ToInt32(ddlCourses.SelectedValue),
                    IntExamID = 0,
                    IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID])
                };
                new BCommon().BBindExam_Accessibility(objBEStudent);
                if (objBEStudent.DtResult.Rows.Count > 0)
                {
                    ddlExams.Items.Clear();
                    RadComboBoxItem rdItem = new RadComboBoxItem("--Select exam--", "-1");
                    ddlExams.Items.Add(rdItem);
                    ddlExams.AppendDataBoundItems = true;
                    ddlExams.DataSource = objBEStudent.DtResult;
                    ddlExams.DataTextField = "ExamName";
                    ddlExams.DataValueField = "ExamID";
                    ddlExams.DataBind();
                }
                else
                {
                    ddlExams.Items.Clear();
                    ddlExams.AppendDataBoundItems = true;
                    ddlExams.Items.Add(new RadComboBoxItem("--Select exam--", "-1"));
                    ddlExams.DataSource = null;
                    ddlExams.DataBind();
                }
            }
            else
            {
                ddlExams.Items.Clear();
                ddlExams.AppendDataBoundItems = true;
                ddlExams.Items.Add(new RadComboBoxItem("--Select exam--", "-1"));
                ddlExams.DataSource = null;
                ddlExams.DataBind();
            }
        }
        protected void ddlCourses_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            this.BindExams_Accessibility();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Saved", "document.getElementById('" + lblE1.ClientID.ToString() + "').focus();", true);
        }
        protected void ddlExams_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            try
            {
                this.BindDates(1, ddlYear, 0, 0);
                ddlYear.SelectedIndex = 0;
                this.BindDates(2, ddlMonth, Convert.ToInt32(ddlYear.SelectedValue.ToString()), 0);
                ddlMonth.SelectedIndex = 0;
                this.BindDates(3, ddlDay, Convert.ToInt32(ddlYear.SelectedValue.ToString()), Convert.ToInt32(ddlMonth.SelectedValue.ToString()));
                ddlDay.SelectedIndex = 0;
                Session["TIMESLOTS1"] = null;
                this.BindTimeSlots_AccessibilityON();
            }
            catch
            {
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Saved", "document.getElementById('" + lblY1.ClientID.ToString() + "').focus();", true);
        }
        protected void BindDates(int intType, RadComboBox ddlCmg, int intYear, int intMonth)
        {
            BEStudent objBEStudent = new BEStudent();
            BStudent objBStudent = new BStudent();
            if (Request.QueryString["ExamID"] == null)
                objBEStudent.IntExamID = Convert.ToInt32(ddlExams.SelectedValue.ToString());
            else
                objBEStudent.IntExamID = Convert.ToInt32(hdAccessibilityExamID.Value.ToString());
            objBEStudent.intYear = intYear;
            objBEStudent.intMonth = intMonth;
            objBEStudent.IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID]);
            objBEStudent.IntType = intType;
            if (btnOnDemand1.SelectedToggleState.Value == "OFF")
                objBEStudent.intOndemand = 0;
            else
                objBEStudent.intOndemand = 1;
            objBStudent.BGetExamTimes(objBEStudent);
            ddlCmg.Items.Clear();
            RadComboBoxItem rdList;
            for (int i = objBEStudent.intStart; i <= objBEStudent.intEnd; i++)
            {
                rdList = new RadComboBoxItem();
                if (intType == 2)
                    rdList.Text = this.GetMonthName(i);
                else
                    rdList.Text = i.ToString();
                rdList.Value = i.ToString();
                ddlCmg.Items.Add(rdList);
            }
        }
        protected string GetMonthName(int intMonth)
        {
            string strMonth = string.Empty;
            switch (intMonth)
            {
                case 1:
                    strMonth = "January";
                    break;
                case 2:
                    strMonth = "February";
                    break;
                case 3:
                    strMonth = "March";
                    break;
                case 4:
                    strMonth = "April";
                    break;
                case 5:
                    strMonth = "May";
                    break;
                case 6:
                    strMonth = "June";
                    break;
                case 7:
                    strMonth = "July";
                    break;
                case 8:
                    strMonth = "August";
                    break;
                case 9:
                    strMonth = "September";
                    break;
                case 10:
                    strMonth = "October";
                    break;
                case 11:
                    strMonth = "November";
                    break;
                case 12:
                    strMonth = "December";
                    break;
            }
            return strMonth;
        }
        protected void ddlYear_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            try
            {
                this.BindDates(2, ddlMonth, Convert.ToInt32(ddlYear.SelectedValue.ToString()), 0);
                ddlMonth.SelectedIndex = 0;
                this.BindDates(3, ddlDay, Convert.ToInt32(ddlYear.SelectedValue.ToString()), Convert.ToInt32(ddlMonth.SelectedValue.ToString()));
                ddlDay.SelectedIndex = 0;
                Session["TIMESLOTS1"] = null;
                this.BindTimeSlots_AccessibilityON();
            }
            catch
            {
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Saved", "document.getElementById('" + lblM1.ClientID.ToString() + "').focus();", true);
        }
        protected void ddlMonth_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            try
            {
                this.BindDates(3, ddlDay, Convert.ToInt32(ddlYear.SelectedValue.ToString()), Convert.ToInt32(ddlMonth.SelectedValue.ToString()));
                ddlDay.SelectedIndex = 0;
                Session["TIMESLOTS1"] = null;
                this.BindTimeSlots_AccessibilityON();
            }
            catch
            {
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Saved", "document.getElementById('" + lblD1.ClientID.ToString() + "').focus();", true);
        }
        protected void ddlDay_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            Session["TIMESLOTS1"] = null;
            this.BindTimeSlots_AccessibilityON();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Saved", "document.getElementById('" + lblT1.ClientID.ToString() + "').focus();", true);
        }
        protected void BindTimeSlots_AccessibilityON()
        {
            try
            {
                ddlTime.Enabled = true;
                System.Data.DataTable dtResult = BGetAvailableTimeSlotsTable_AccessibilityON();
                System.Data.DataSet dsResult = this.GetSlotsTable();

                bool skip = false;
                if (dsResult.Tables[0].Rows.Count > 0)
                {
                    foreach (System.Data.DataRow dr in dsResult.Tables[0].Rows)
                    {
                        if (DateTime.Parse(dr["Slot"].ToString()).ToShortDateString() == DateTime.Parse(dtResult.Rows[0]["ExamSlot"].ToString()).ToShortDateString())
                        {
                            skip = true;
                        }
                    }
                }
                if (skip)
                {
                    ddlTime.Items.Clear();
                    ddlTime.Items.Add(new RadComboBoxItem("--Select Time--", "-1"));
                }
                else
                {
                    ddlTime.Items.Clear();
                    ddlTime.DataSource = dtResult;
                    ddlTime.DataTextField = "ExamSlot1";
                    ddlTime.DataValueField = "ID";
                    ddlTime.DataBind();
                }
                dtResult = null;
                dsResult = null;
            }
            catch
            {
                ddlTime.Items.Clear();
                ddlTime.Enabled = false;
            }
        }
        protected System.Data.DataTable BGetAvailableTimeSlotsTable_AccessibilityON()
        {
            System.Data.DataTable dtResult = new System.Data.DataTable();
            //Below code commented by Manoj to bind the time slots on selected date time changed
            if (Session["TIMESLOTS1"] != null)
                dtResult = (System.Data.DataTable)Session["TIMESLOTS1"];
            else
            {
                this.BGetAvaialbleTimeSlots_Reset_AccessibilityON();
                dtResult = (System.Data.DataTable)Session["TIMESLOTS1"];
            }
            return dtResult;
        }
        protected void BGetAvaialbleTimeSlots_Reset_AccessibilityON()
        {
            BECommon objBECommon = new BECommon();
            BCommon objBCommon = new BCommon();
            objBECommon.IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID]);
            if (btnOnDemand1.SelectedToggleState.Value == "ON")
                objBECommon.intOndemand = 1;
            else
                objBECommon.intOndemand = 0;
            objBECommon.dtExam = Convert.ToDateTime(ddlMonth.SelectedValue.ToString() + "-" + ddlDay.SelectedValue.ToString() + "-" + ddlYear.SelectedValue.ToString());
            objBCommon.BGetAvailableTimeSlots(objBECommon);
            Session["TIMESLOTS1"] = objBECommon.DtResult;
            objBECommon = null;
            objBCommon = null;
        }
        protected void btnOnDemand1_Click(object sender, EventArgs e)
        {
            if (btnOnDemand1.SelectedToggleState.Value == "ON")
            {
                btnOnDemand.ToggleStates[0].Selected = true;
            }
            else
            {
                btnOnDemand.ToggleStates[1].Selected = true;
            }
            try
            {
                this.BindDates(3, ddlDay, Convert.ToInt32(ddlYear.SelectedValue.ToString()), Convert.ToInt32(ddlMonth.SelectedValue.ToString()));
                Session["TIMESLOTS1"] = null;
                this.BindTimeSlots_AccessibilityON();
            }
            catch
            {

            }

            ScriptManager.RegisterStartupScript(this, this.GetType(), "NotSaved", "document.getElementById('" + btnOnDemand1.ClientID.ToString() + "').focus();", true);
        }
        protected void ScheduleExam_AccessibilityON()
        {
            if (Request.QueryString["ExamID"] == null)
            {
                #region NewAppointment
                BEStudent objBEStudent = new BEStudent()
                {
                    IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID]),
                    IntCourseID = int.Parse(ddlCourses.SelectedValue),
                    IntExamID = int.Parse(ddlExams.SelectedValue),
                    dtExam = Convert.ToDateTime(ddlMonth.SelectedValue.ToString() + "-" + ddlDay.SelectedValue.ToString() + "-" + ddlYear.SelectedValue.ToString() + " " + ddlTime.SelectedItem.Text.ToString())
                };
                this.SetExamFeeSettings(int.Parse(ddlExams.SelectedValue), "EXAMID");
                if (Session[EnumPayment.PaidBY_ExamFee] != null && Session[EnumPayment.PaidBY_OndeMand] != null)
                {
                    if (btnOnDemand.SelectedToggleState.Value == "ON")
                    {
                        #region If On-demand is ON

                        DateTime Appointmentdate = objBEStudent.dtExam;

                        if (Session[EnumPayment.PaidBY_ExamFee].ToString() == EnumPayment.PaidBy_University && Session[EnumPayment.PaidBY_OndeMand].ToString() == EnumPayment.PaidBy_University)
                        {
                            objBEStudent.intOndemand = 1;
                            new BStudent().BStudent_ScheduleExam(objBEStudent);
                            this.ShowAlert_ScheduleExam_Create(objBEStudent);
                        }
                        else if (Session[EnumPayment.PaidBY_ExamFee].ToString() == EnumPayment.PaidBy_University && Session[EnumPayment.PaidBY_OndeMand].ToString() == EnumPayment.PaidBy_Student)
                        {
                            objBEStudent.intOndemand = 1;
                            new BStudent().BStudent_ValidateExam(objBEStudent);
                            if (objBEStudent.IntResult == 4)
                                this.ProcessPayment_Schedule(objBEStudent);
                            else
                                this.ShowAlert_ScheduleExam_Validate(objBEStudent.IntResult);
                        }
                        else if (Session[EnumPayment.PaidBY_ExamFee].ToString() == EnumPayment.PaidBy_Student && Session[EnumPayment.PaidBY_OndeMand].ToString() == EnumPayment.PaidBy_University)
                        {
                            objBEStudent.intOndemand = 1;
                            new BStudent().BStudent_ValidateExam(objBEStudent);
                            if (objBEStudent.IntResult == 4)
                                this.ProcessPayment_Schedule(objBEStudent);
                            else
                                this.ShowAlert_ScheduleExam_Validate(objBEStudent.IntResult);
                        }
                        else if (Session[EnumPayment.PaidBY_ExamFee].ToString() == EnumPayment.PaidBy_Student && Session[EnumPayment.PaidBY_OndeMand].ToString() == EnumPayment.PaidBy_Student)
                        {
                            objBEStudent.intOndemand = 1;
                            new BStudent().BStudent_ValidateExam(objBEStudent);
                            if (objBEStudent.IntResult == 4)
                                this.ProcessPayment_Schedule(objBEStudent);
                            else
                                this.ShowAlert_ScheduleExam_Validate(objBEStudent.IntResult);
                        }
                        #endregion
                    }
                    else if (btnOnDemand.SelectedToggleState.Value == "OFF")
                    {
                        #region If On-demand is OFF
                        if (Session[EnumPayment.PaidBY_ExamFee].ToString() == EnumPayment.PaidBy_University)
                        {
                            objBEStudent.intOndemand = 0;
                            new BStudent().BStudent_ScheduleExam(objBEStudent);
                            this.ShowAlert_ScheduleExam_Create(objBEStudent);
                        }
                        else if (Session[EnumPayment.PaidBY_ExamFee].ToString() == EnumPayment.PaidBy_Student)
                        {
                            objBEStudent.intOndemand = 0;
                            new BStudent().BStudent_ValidateExam(objBEStudent);
                            if (objBEStudent.IntResult == 4)
                                this.ProcessPayment_Schedule(objBEStudent);
                            else
                                this.ShowAlert_ScheduleExam_Validate(objBEStudent.IntResult);
                        }
                        #endregion
                    }
                }
                else
                {
                    #region If the Payment is not configured
                    new BStudent().BStudent_ScheduleExam(objBEStudent);
                    this.ShowAlert_ScheduleExam_Create(objBEStudent);
                    #endregion
                }
                #endregion
            }
            else
            {
                #region EditAppointment
                BEStudent objBEStudent = new BEStudent()
                {
                    IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID]),
                    IntScheduleID = Convert.ToInt32(AppSecurity.Decrypt(Request.QueryString["ExamID"].ToString())),
                    dtExam = Convert.ToDateTime(ddlMonth.SelectedValue.ToString() + "-" + ddlDay.SelectedValue.ToString() + "-" + ddlYear.SelectedValue.ToString() + " " + ddlTime.SelectedItem.Text.ToString())
                };
                Int64 intTransID = Convert.ToInt64(AppSecurity.Decrypt(Request.QueryString["ExamID"].ToString()));
                this.SetExamFeeSettings(intTransID, "TRANSID");
                if (Session[EnumPayment.PaidBY_ExamFee] != null && Session[EnumPayment.PaidBY_OndeMand] != null)
                {
                    if (btnOnDemand.SelectedToggleState.Value == "ON")
                    {
                        #region If On-demand is ON
                        if (Session[EnumPayment.PaidBY_ExamFee].ToString() == EnumPayment.PaidBy_University && Session[EnumPayment.PaidBY_OndeMand].ToString() == EnumPayment.PaidBy_University)
                        {
                            objBEStudent.intOndemand = 1;
                            new BStudent().BStudent_UpdateScheduleExam(objBEStudent);
                            this.ShowAlert_ScheduleExam_Update(objBEStudent);
                        }
                        else if (Session[EnumPayment.PaidBY_ExamFee].ToString() == EnumPayment.PaidBy_University && Session[EnumPayment.PaidBY_OndeMand].ToString() == EnumPayment.PaidBy_Student)
                        {
                            objBEStudent.intOndemand = 1;
                            new BStudent().BStudent_ValidateRescheduledExam(objBEStudent);
                            if (objBEStudent.IntResult == 4)
                            {
                                if (objBEStudent.decAmount != 0)
                                    this.ProcessPayment_Schedule(objBEStudent);
                                else
                                {
                                    new BStudent().BStudent_ReScheduleExamOnDemand(objBEStudent);
                                    this.ShowAlert_ScheduleExam_Update(objBEStudent);
                                }
                            }
                            else
                                this.ShowAlert_ReScheduleExam_Validate(objBEStudent.IntResult, intTransID);
                        }
                        else if (Session[EnumPayment.PaidBY_ExamFee].ToString() == EnumPayment.PaidBy_Student && Session[EnumPayment.PaidBY_ExamFee].ToString() == EnumPayment.PaidBy_University)
                        {
                            objBEStudent.intOndemand = 1;
                            new BStudent().BStudent_ValidateRescheduledExam(objBEStudent);
                            if (objBEStudent.IntResult == 4)
                            {
                                if (objBEStudent.decAmount != 0)
                                    this.ProcessPayment_Schedule(objBEStudent);
                                else
                                {
                                    new BStudent().BStudent_ReScheduleExamOnDemand(objBEStudent);
                                    this.ShowAlert_ScheduleExam_Update(objBEStudent);
                                }
                            }
                            else
                                this.ShowAlert_ReScheduleExam_Validate(objBEStudent.IntResult, intTransID);
                        }
                        else if (Session[EnumPayment.PaidBY_ExamFee].ToString() == EnumPayment.PaidBy_Student && Session[EnumPayment.PaidBY_ExamFee].ToString() == EnumPayment.PaidBy_Student)
                        {
                            objBEStudent.intOndemand = 1;
                            new BStudent().BStudent_ValidateRescheduledExam(objBEStudent);
                            if (objBEStudent.IntResult == 4)
                            {
                                if (objBEStudent.decAmount != 0)
                                    this.ProcessPayment_Schedule(objBEStudent);
                                else
                                {
                                    new BStudent().BStudent_ReScheduleExamOnDemand(objBEStudent);
                                    this.ShowAlert_ScheduleExam_Update(objBEStudent);
                                }
                            }
                            else
                                this.ShowAlert_ReScheduleExam_Validate(objBEStudent.IntResult, intTransID);
                        }
                        #endregion
                    }
                    else if (btnOnDemand.SelectedToggleState.Value == "OFF")
                    {
                        #region If On-demand is OFF
                        if (Session[EnumPayment.PaidBY_ExamFee].ToString() == EnumPayment.PaidBy_University)
                        {
                            objBEStudent.intOndemand = 0;
                            new BStudent().BStudent_UpdateScheduleExam(objBEStudent);
                            this.ShowAlert_ScheduleExam_Update(objBEStudent);
                        }
                        else if (Session[EnumPayment.PaidBY_ExamFee].ToString() == EnumPayment.PaidBy_Student)
                        {
                            objBEStudent.intOndemand = 0;
                            new BStudent().BStudent_ValidateRescheduledExam(objBEStudent);
                            if (objBEStudent.IntResult == 4)
                            {
                                if (objBEStudent.decAmount != 0)
                                    this.ProcessPayment_Schedule(objBEStudent);
                                else
                                {
                                    new BStudent().BStudent_ReScheduleExamOnDemand(objBEStudent);
                                    this.ShowAlert_ScheduleExam_Update(objBEStudent);
                                }
                            }
                            else
                                this.ShowAlert_ReScheduleExam_Validate(objBEStudent.IntResult, intTransID);
                        }
                        #endregion
                    }
                }
                else
                {
                    #region If the Payment is not configured
                    new BStudent().BStudent_UpdateScheduleExam(objBEStudent);
                    this.ShowAlert_ScheduleExam_Update(objBEStudent);
                    #endregion
                }
                #endregion
            }
        }
        protected void btnScheduleExam_Click(object sender, EventArgs e)
        {
            try
            {
                this.ScheduleExam_AccessibilityON();
            }
            catch
            {
                lblMsg1.Text = "Please select the valid values";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "NotSaved", "document.getElementById('" + lblMsg1.ClientID.ToString() + "').focus();", true);
            }
        }
        protected void CheckForExamType()
        {
            if (Request.QueryString["ExamID"] != null)
            {
                BEStudent objBEStudent = new BEStudent();
                BStudent objBStudent = new BStudent();
                objBEStudent.IntTransID = Convert.ToInt64(AppSecurity.Decrypt(Request.QueryString["ExamID"].ToString()));
                objBStudent.BGetCourseAndExamDetails(objBEStudent);
                if (objBEStudent.DtResult != null)
                {
                    if (objBEStudent.DtResult.Rows.Count > 0)
                    {
                        ddlCourses.Visible = false;
                        lblAccessibilityCourseName.Visible = true;
                        ddlExams.Visible = false;
                        lblAccessibilityExamName.Visible = true;
                        lblAccessibilityCourseName.Text = objBEStudent.DtResult.Rows[0]["CourseName"].ToString();
                        lblAccessibilityExamName.Text = objBEStudent.DtResult.Rows[0]["ExamName"].ToString();
                        hdAccessibilityCourseID.Value = objBEStudent.DtResult.Rows[0]["CourseID"].ToString();
                        hdAccessibilityExamID.Value = objBEStudent.DtResult.Rows[0]["ExamID"].ToString();
                        try
                        {
                            this.BindDates(1, ddlYear, 0, 0);
                            ddlYear.SelectedIndex = 0;
                            this.BindDates(2, ddlMonth, Convert.ToInt32(ddlYear.SelectedValue.ToString()), 0);
                            ddlMonth.SelectedIndex = 0;
                            this.BindDates(3, ddlDay, Convert.ToInt32(ddlYear.SelectedValue.ToString()), Convert.ToInt32(ddlMonth.SelectedValue.ToString()));
                            ddlDay.SelectedIndex = 0;
                            Session["TIMESLOTS1"] = null;
                            this.BindTimeSlots_AccessibilityON();
                            btnScheduleExam.Text = "Reschedule";
                        }
                        catch
                        {
                        }
                    }
                }
                else
                {
                    ddlCourses.Visible = true;
                    lblAccessibilityCourseName.Visible = false;
                    ddlExams.Visible = true;
                    lblAccessibilityExamName.Visible = false;
                    btnScheduleExam.Text = "Schedule";
                }
            }
            else
            {
                this.BindCourse_Accessibility();
                ddlCourses.Visible = true;
                lblAccessibilityCourseName.Visible = false;
                ddlExams.Visible = true;
                lblAccessibilityExamName.Visible = false;
                btnScheduleExam.Text = "Schedule";
            }
        }
        //Accessibility Code : End
    }
}

