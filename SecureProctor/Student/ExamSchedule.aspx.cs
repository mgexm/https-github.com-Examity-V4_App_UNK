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
    public partial class ExamSchedule : BaseClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Page.Title = EnumPageTitles.APPNAME + EnumPageTitles.STUDENT_SCHEDULE;
            ((LinkButton)this.Page.Master.FindControl("lnkSchedule")).CssClass = "main_menu_active";
            if (!IsPostBack)
            {
                calScheduleDate.SelectedDate = GetUserCurrentTime().AddHours(48);
                this.BindExamScheduler();
                Session["BESTUDENT"] = null;
                if (Request.QueryString["ExamDate"] != null)
                {
                    DateTime dt = Convert.ToDateTime(AppSecurity.Decrypt(Request.QueryString["ExamDate"].ToString()).Replace("EC", "/"));
                    if (dt < GetUserCurrentTime().AddDays(2))
                    {
                        calScheduleDate.MinDate = dt;
                    }
                    calScheduleDate.SelectedDate = dt;
                    BindExamScheduler();
                }
                else
                {
                    setCalScheduler();
                    calScheduleDate.SelectedDate = GetUserCurrentTime().AddHours(48);
                    BindExamScheduler();
                }               
                Session["update"] = Server.UrlEncode(System.DateTime.Now.ToString());
                this.Bind_GetBookedExamSlots();
                this.GetSlotsTable_Reset();
                this.BGetAvaialbleTimeSlots_Reset();
            }
            else
                this.Bind_GetBookedExamSlots();
            this.CheckMyProfile();
        }
        #region setCalScheduler
        public void setCalScheduler()
        {
            if (btnOnDemand.SelectedToggleState.Value == "ON")
            {
                calScheduleDate.MinDate = DateTime.Parse(GetUserCurrentTime().ToShortDateString());
            }
            else
            {
                calScheduleDate.MinDate = DateTime.Parse(GetUserCurrentTime().AddDays(2).ToShortDateString());
            }
        }
        #endregion
        #region BindExamScheduler
        protected void BindExamScheduler()
        {
            ExamScheduler_Morning.SelectedDate = Convert.ToDateTime(calScheduleDate.SelectedDate);
            ExamScheduler_Noon.SelectedDate = Convert.ToDateTime(calScheduleDate.SelectedDate);
            ExamScheduler_Night.SelectedDate = Convert.ToDateTime(calScheduleDate.SelectedDate);
        }
        #endregion
        #region CheckMyProfile
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
        #endregion
        #region Bind_GetBookedExamSlots
        protected void Bind_GetBookedExamSlots()
        {
            BECommon objBECommon = new BECommon { IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID]) };
            new BCommon().BBind_GetBookedExamSlots(objBECommon);

            if (objBECommon.DtResult != null)
            {
                ExamScheduler_Morning.DataSource = objBECommon.DtResult;
                ExamScheduler_Morning.DataBind();
                ExamScheduler_Noon.DataSource = objBECommon.DtResult;
                ExamScheduler_Noon.DataBind();
                ExamScheduler_Night.DataSource = objBECommon.DtResult;
                ExamScheduler_Night.DataBind();
            }
        }
        #endregion
        #region GetUserCurrentTime
        public DateTime GetUserCurrentTime()
        {
            BECommon objBECommon = new BECommon();
            BCommon objBCommon = new BCommon();
            objBECommon.iTimeZoneID = Convert.ToInt32(Session["TimeZoneID"]);
            objBCommon.BGetTimeDelay(objBECommon);
            return DateTime.Parse(DateTime.UtcNow.AddMinutes(objBECommon.IntResult).ToString("MM/dd/yyyy HH:mm tt"));
        }
        #endregion
        #region ButtonEvents
        protected void btnOnDemand_Click(object sender, EventArgs e)
        {

        }
        protected void ImgPrevDate_Click(object sender, ImageClickEventArgs e)
        {
            calScheduleDate.SelectedDate = Convert.ToDateTime(calScheduleDate.SelectedDate).AddDays(-1);
        }

        protected void ImgNextDate_Click(object sender, ImageClickEventArgs e)
        {
            calScheduleDate.SelectedDate = Convert.ToDateTime(calScheduleDate.SelectedDate).AddDays(1);
        }
        protected void calScheduleDate_SelectedDateChanged(object sender, SelectedDateChangedEventArgs e)
        {
            this.BindExamScheduler();
            this.BGetAvaialbleTimeSlots_Reset();
            this.GetSlotsTable_Reset();  
        }
        #endregion       
        #region GetSlotsTable_Reset
        protected void GetSlotsTable_Reset()
        {
            try
            {
                BEProctor objBEProctor = new BEProctor();
                BProctor objBProctor = new BProctor();
                objBEProctor.StrDate = Convert.ToDateTime(calScheduleDate.SelectedDate).ToString("MM/dd/yyyy").Replace("-", "/").ToString();
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
        #endregion
        #region BGetAvaialbleTimeSlots_Reset
        protected void BGetAvaialbleTimeSlots_Reset()
        {
            BECommon objBECommon = new BECommon();
            BCommon objBCommon = new BCommon();
            objBECommon.IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID]);
            if (btnOnDemand.SelectedToggleState.Value == "ON")
                objBECommon.intOndemand = 1;
            else
                objBECommon.intOndemand = 0;
            objBECommon.dtExam = Convert.ToDateTime(Convert.ToDateTime(calScheduleDate.SelectedDate).ToString("MM/dd/yyyy").Replace("-", "/").ToString());           
            objBCommon.BGetAvailableTimeSlots(objBECommon);
            Session["TIMESLOTS"] = objBECommon.DtResult;
            objBECommon = null;
            objBCommon = null;
        }
        #endregion
        #region GetSlotStatus
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
        #endregion
        #region RadEvents
        protected void RadScheduler_AppointmentDataBound(object sender, SchedulerEventArgs e)
        {
            if (e.Appointment.Description.ToString() == "1")
            {
                e.Appointment.BackColor = System.Drawing.Color.FromArgb(56, 192, 54);
            }
            else if (e.Appointment.Description.ToString() == "3")
                e.Appointment.BackColor = System.Drawing.Color.FromArgb(233, 233, 233);
            else
                e.Appointment.BackColor = System.Drawing.Color.Orange;
        }
        protected void ExamScheduler_TimeSlotCreated(object sender, TimeSlotCreatedEventArgs e)
        {
            if (this.GetSlotStaus(e.TimeSlot.Start.ToString("MM/dd/yyyy HH:mm:ss")))
            {
                e.TimeSlot.CssClass += "Disabled";
            }
        }
        protected void ExamScheduler_Morning_FormCreating(object sender, SchedulerFormCreatingEventArgs e)
        {

        }
        protected void ExamScheduler_Noon_FormCreating(object sender, SchedulerFormCreatingEventArgs e)
        {

        }
        protected void ExamScheduler_Night_FormCreating(object sender, SchedulerFormCreatingEventArgs e)
        {

        }
        #endregion
    }
}