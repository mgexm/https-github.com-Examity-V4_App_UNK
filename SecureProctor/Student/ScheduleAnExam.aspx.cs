using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using BusinessEntities;
using BLL;
using Telerik.Web.UI.Calendar;
using System.Web.UI.HtmlControls;

namespace SecureProctor.Student
{
    public partial class ScheduleAnExam : BaseClass, IPostBackEventHandler
    {
        #region GlobalDeclaration
        string[] strDivControls = { "div_1200AM", "div_1230AM", "div_0100AM", "div_0130AM", "div_0200AM", "div_0230AM", "div_0300AM", "div_0330AM", "div_0400AM", "div_0430AM", "div_0500AM", "div_0530AM", "div_0600AM", "div_0630AM", "div_0700AM", "div_0730AM", "div_0800AM", "div_0830AM", "div_0900AM", "div_0930AM", "div_1000AM", "div_1030AM", "div_1100AM", "div_1130AM", "div_1200PM", "div_1230PM", "div_0100PM", "div_0130PM", "div_0200PM", "div_0230PM", "div_0300PM", "div_0330PM", "div_0400PM", "div_0430PM", "div_0500PM", "div_0530PM", "div_0600PM", "div_0630PM", "div_0700PM", "div_0730PM", "div_0800PM", "div_0830PM", "div_0900PM", "div_0930PM", "div_1000PM", "div_1030PM", "div_1100PM", "div_1130PM" };
        string[] strDivValues = { "00:00:00", "00:30:00", "01:00:00", "01:30:00", "02:00:00", "02:30:00", "03:00:00", "03:30:00", "04:00:00", "04:30:00", "05:00:00", "05:30:00", "06:00:00", "06:30:00", "07:00:00", "07:30:00", "08:00:00", "08:30:00", "09:00:00", "09:30:00", "10:00:00", "10:30:00", "11:00:00", "11:30:00", "12:00:00", "12:30:00", "13:00:00", "13:30:00", "14:00:00", "14:30:00", "15:00:00", "15:30:00", "16:00:00", "16:30:00", "17:00:00", "17:30:00", "18:00:00", "18:30:00", "19:00:00", "19:30:00", "20:00:00", "20:30:00", "21:00:00", "21:30:00", "22:00:00", "22:30:00", "23:00:00", "23:30:00" };

        #endregion
        #region PageLoad
        protected void Page_Load(object sender, EventArgs e)
        {
            trMessage.Visible = false;
            if (!IsPostBack)
            {
                this.Page.Title = EnumPageTitles.APPNAME + EnumPageTitles.STUDENT_SCHEDULE;
                ((LinkButton)this.Page.Master.FindControl("lnkSchedule")).CssClass = "main_menu_active";
                BindAttributes();
                this.BindInstructors();
                if (Request.QueryString["ExamID"] != null)
                {
                    if (Request.QueryString["Type"] != null)
                    {
                        if (Request.QueryString["Type"].ToString() == "Reschedule")
                        {
                            this.BindReschduleExamDetails();
                            this.BindRescheduleValuesOnLoad();
                        }
                        else
                            this.BindReschduleExamDetails();
                    }
                    else
                    {//AA Exams
                        BECommon objBEStudent2 = new BECommon();

                        objBEStudent2.IntExamID1 = Convert.ToInt64(AppSecurity.Decrypt(Request.QueryString["ExamID"].ToString()));
                        new BCommon().BGetAAPaymentData(objBEStudent2);

                        if (objBEStudent2.IntResult == 0)
                        {
                            this.BindReschduleExamDetails();
                        }
                        else
                        {
                            this.BindReschduleExamDetails();
                        }


                    }
                    lblInstructor.Visible = true;
                    lblCourse.Visible = true;
                    lblExam.Visible = true;
                }
                else
                {
                    lblInstructor.Visible = false;
                    lblCourse.Visible = false;
                    lblExam.Visible = false;
                }


            }
            this.CheckMyProfile();

        }
        #endregion
        #region ResetDropDowns
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
            lblStartDate.Text = string.Empty;
            lblEndDate.Text = string.Empty;
            trNonProctor.Visible = false;
            trWithProctor.Visible = false;
            ViewState["Time"] = null;
        }
        #endregion
        #region BindDropDowns
        protected void BindInstructors()
        {
            lblStartDate.Text = string.Empty;
            lblEndDate.Text = string.Empty;
            lblExamDuration.Text = string.Empty;
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
        protected void drpInstructor_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            this.BindCourse();
        }
        protected void BindCourse()
        {
            lblStartDate.Text = string.Empty;
            lblEndDate.Text = string.Empty;
            lblExamDuration.Text = string.Empty;
            trNonProctor.Visible = false;
            trWithProctor.Visible = false;
            trRescheduleOrCancel.Visible = false;
            trOndemand.Visible = false;

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
        protected void drpCourse_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {

            this.BindExams();
        }
        protected void BindExams()
        {
            lblStartDate.Text = string.Empty;
            lblEndDate.Text = string.Empty;
            lblExamDuration.Text = string.Empty;
            trNonProctor.Visible = false;
            trWithProctor.Visible = false;
            trOndemand.Visible = false;

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
        protected void drpExam_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            ViewState["Time"] = null;
            this.BindScheduleValues(1);
        }
        #endregion
        #region BindBookedExamSlots
        protected void BindBookedExamSlosts()
        {
            BECommon objBECommon = new BECommon { IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID]) };
            new BCommon().BBind_GetBookedExamSlots(objBECommon);

            if (objBECommon.DtResult != null)
            {
                if (objBECommon.DtResult.Rows.Count > 0)
                {
                    string strStartTime = string.Empty;
                    int intIndex = 0;
                    for (int i = 0; i < objBECommon.DtResult.Rows.Count; i++)
                    {
                        if (calSchedular.SelectedDate.ToString("MM-dd-yyyy") == Convert.ToDateTime(objBECommon.DtResult.Rows[i]["StartDate"].ToString()).ToString("MM-dd-yyyy"))
                        {
                            strStartTime = Convert.ToDateTime(objBECommon.DtResult.Rows[i]["StartDate"].ToString()).ToString("hhmmtt").ToString();

                            for (int j = 0; j < strDivControls.Length; j++)
                            {
                                if (strDivControls[j].ToString() == "div_" + strStartTime)
                                {
                                    intIndex = j;
                                }
                            }
                            if (this.Page.Master.FindControl("StudentContent").FindControl("trWithProctor").FindControl("div_" + strStartTime) != null)
                            {
                                if (objBECommon.DtResult.Rows[i]["Description"].ToString() == "1")
                                {
                                    ((HtmlGenericControl)this.Page.Master.FindControl("StudentContent").FindControl("trWithProctor").FindControl("div_" + strStartTime)).Attributes.Add("class", "cal-SlotBooked");
                                    ((HiddenField)this.Page.Master.FindControl("StudentContent").FindControl("trWithProctor").FindControl("hd_" + strStartTime)).Value = "cal-SlotBooked";
                                }
                                else
                                {
                                    ((HtmlGenericControl)this.Page.Master.FindControl("StudentContent").FindControl("trWithProctor").FindControl("div_" + strStartTime)).Attributes.Add("class", "cal-SlotAlreadyBooked");
                                    ((HiddenField)this.Page.Master.FindControl("StudentContent").FindControl("trWithProctor").FindControl("hd_" + strStartTime)).Value = "cal-SlotAlreadyBooked";

                                }
                                ((HtmlGenericControl)this.Page.Master.FindControl("StudentContent").FindControl("trWithProctor").FindControl("div_" + strStartTime)).Attributes.Add("onmouseover", "ddrivetip('" + this.GetToolTipText(objBECommon.DtResult.Rows[i]["ScheduleID"].ToString(), objBECommon.DtResult.Rows[i]["CourseName"].ToString(), objBECommon.DtResult.Rows[i]["ExamName"].ToString(), objBECommon.DtResult.Rows[i]["status"].ToString()) + "');");
                                ((HtmlGenericControl)this.Page.Master.FindControl("StudentContent").FindControl("trWithProctor").FindControl("div_" + strStartTime)).Attributes.Add("onmouseout", "hideddrivetip();");

                                if (objBECommon.DtResult.Rows[i]["Duration"] != null)
                                {
                                    int intLoopCount = (Convert.ToInt32(objBECommon.DtResult.Rows[i]["Duration"].ToString()) / 30) - 1;
                                    for (int k = 0; k < intLoopCount; k++)
                                    {
                                        intIndex++;
                                        if (intIndex < 48)
                                        {
                                            if (this.Page.Master.FindControl("StudentContent").FindControl("trWithProctor").FindControl(strDivControls[intIndex].ToString()) != null)
                                            {
                                                if (objBECommon.DtResult.Rows[i]["Description"].ToString() == "1")
                                                {
                                                    ((HtmlGenericControl)this.Page.Master.FindControl("StudentContent").FindControl("trWithProctor").FindControl(strDivControls[intIndex].ToString())).Attributes.Add("class", "cal-SlotBooked");
                                                }
                                                else
                                                {
                                                    ((HtmlGenericControl)this.Page.Master.FindControl("StudentContent").FindControl("trWithProctor").FindControl(strDivControls[intIndex].ToString())).Attributes.Add("class", "cal-SlotAlreadyBooked");
                                                }

                                                //((HiddenField)this.Page.Master.FindControl("StudentContent").FindControl("trWithProctor").FindControl(strDivControls[intIndex].ToString().Replace("div_", "hd_"))).Value = "cal-SlotAvailable";
                                                ((HtmlGenericControl)this.Page.Master.FindControl("StudentContent").FindControl("trWithProctor").FindControl(strDivControls[intIndex].ToString())).Attributes.Add("onmouseover", "ddrivetip('" + this.GetToolTipText(objBECommon.DtResult.Rows[0]["ScheduleID"].ToString(), objBECommon.DtResult.Rows[0]["CourseName"].ToString(), objBECommon.DtResult.Rows[0]["ExamName"].ToString(), objBECommon.DtResult.Rows[i]["status"].ToString()) + "');");
                                                ((HtmlGenericControl)this.Page.Master.FindControl("StudentContent").FindControl("trWithProctor").FindControl(strDivControls[intIndex].ToString())).Attributes.Add("onmouseout", "hideddrivetip();");
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        protected string GetToolTipText(string strTransID, string strCourseName, string strExamName, string strStatus)
        {
            System.Text.StringBuilder stbToolTip = new System.Text.StringBuilder();
            stbToolTip.Append("<table cellpadding=\"3\" cellspacing=\"3\">");
            stbToolTip.Append("<tr>");
            stbToolTip.Append("<td align=\"left\" valign=\"top\" width=\"80px\"><b>Exam ID</b></td>");
            stbToolTip.Append("<td align=\"left\" valign=\"top\">:</td>");
            stbToolTip.Append("<td align=\"left\"  valign=\"top\">" + strTransID + "</td>");
            stbToolTip.Append("</tr>");
            stbToolTip.Append("<tr>");
            stbToolTip.Append("<td align=\"left\"  valign=\"top\" width=\"80px\"><b>Course Name</b></td>");
            stbToolTip.Append("<td align=\"left\" valign=\"top\">:</td>");
            stbToolTip.Append("<td align=\"left\"  valign=\"top\">" + strCourseName + "</td>");
            stbToolTip.Append("</tr>");
            stbToolTip.Append("<tr>");
            stbToolTip.Append("<td align=\"left\"  valign=\"top\" width=\"80px\"><b>Exam Name</b></td>");
            stbToolTip.Append("<td align=\"left\" valign=\"top\">:</td>");
            stbToolTip.Append("<td align=\"left\"  valign=\"top\">" + strExamName + "</td>");
            stbToolTip.Append("</tr>");
            stbToolTip.Append("<tr>");
            stbToolTip.Append("<td align=\"left\"  valign=\"top\" width=\"80px\"><b>Exam Status</b></td>");
            stbToolTip.Append("<td align=\"left\" valign=\"top\">:</td>");
            stbToolTip.Append("<td align=\"left\"  valign=\"top\">" + strStatus + "</td>");
            stbToolTip.Append("</tr>");
            stbToolTip.Append("</table>");
            return stbToolTip.ToString();
        }
        #endregion
        #region TimePicker Methods
        protected void BindAttributes()
        {
            for (int i = 0; i < strDivControls.Length; i++)
            {
                if (this.Page.Master.FindControl("StudentContent").FindControl("trWithProctor").FindControl(strDivControls[i].ToString()) != null)
                {
                    ((HtmlGenericControl)this.Page.Master.FindControl("StudentContent").FindControl("trWithProctor").FindControl(strDivControls[i].ToString())).Attributes.Add("onClick", ClientScript.GetPostBackEventReference(this, strDivValues[i].ToString()));
                }
            }
        }
        public void setDefaultStyles()
        {
            foreach (string str in strDivControls)
            {
                if (this.Page.Master.FindControl("StudentContent").FindControl("trWithProctor").FindControl(str) != null)
                {
                    ((HtmlGenericControl)this.Page.Master.FindControl("StudentContent").FindControl("trWithProctor").FindControl(str)).Attributes.Add("class", "cal-SlotNotAvailable");
                    ((HiddenField)this.Page.Master.FindControl("StudentContent").FindControl("trWithProctor").FindControl(str.Replace("div_", "hd_"))).Value = "cal-SlotNotAvailable";
                    ((HtmlGenericControl)this.Page.Master.FindControl("StudentContent").FindControl("trWithProctor").FindControl(str)).Attributes.Remove("onmouseover");
                    ((HtmlGenericControl)this.Page.Master.FindControl("StudentContent").FindControl("trWithProctor").FindControl(str)).Attributes.Remove("onmouseout");
                }
            }
        }
        public int GetSlotIndex(string strSlot)
        {
            int intSlotIndex = Array.FindIndex(strDivControls, item => item == strSlot);
            return intSlotIndex;
        }
        public void RaisePostBackEvent(string eventArgument)
        {
            if (!string.IsNullOrEmpty(eventArgument))
            {
                this.BindTimeSlots(0);
                string str = string.Empty;
                for (int j = 0; j < strDivValues.Length; j++)
                {
                    if (strDivValues[j].ToString() == eventArgument)
                    {
                        str = strDivControls[j].ToString();
                    }
                }
                if (this.Page.Master.FindControl("StudentContent").FindControl("trWithProctor").FindControl(str) != null)
                {
                    if (((HiddenField)this.Page.Master.FindControl("StudentContent").FindControl("trWithProctor").FindControl(str.Replace("div_", "hd_"))).Value == "cal-SlotAvailable")
                    {
                        ((HtmlGenericControl)this.Page.Master.FindControl("StudentContent").FindControl("trWithProctor").FindControl(str)).Attributes.Add("class", "cal-SlotSelected");
                        ViewState["Time"] = eventArgument;
                    }
                    else
                    {
                        ViewState["Time"] = null;
                    }
                }
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
        #region SetExamFeeSettings
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
        #endregion
        #region SchedulingMethods
        protected void BindScheduleValues(int isfromexamdrop)
        {
            trMessage.Visible = false;
            btnSchedule.Text = "Schedule";
            trRescheduleOrCancel.Visible = false;
            trNonProctorReschedule.Visible = false;
            if (drpInstructor.SelectedValue.ToString() != "-1" && drpCourse.SelectedValue.ToString() != "-1" && drpExam.SelectedValue.ToString() != "-1")
            {
                int Result = 0;
                BECommon objBEStudent = new BECommon { IntExamID = Convert.ToInt32(drpExam.SelectedValue), IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID]) };
                new BCommon().BGetExamDetails(objBEStudent);
                if (objBEStudent.DtResult != null && objBEStudent.DtResult.Rows.Count > 0)
                {
                    lblStartDate.Text = objBEStudent.DtResult.Rows[0]["ExamStartDate"].ToString() + "  " + "<b>-</b>";
                    lblEndDate.Text = objBEStudent.DtResult.Rows[0]["ExamEndDate"].ToString();
                    lblExamDuration.Text = objBEStudent.DtResult.Rows[0]["ExamDuration"].ToString() + " " + "Minutes";
                    //if (Convert.ToInt32(objBEStudent.DtResult.Rows[0]["ExamSecurity"]) == 1)
                    //{
                    //    #region NonProctorFlow
                    //    trNonProctor.Visible = true;
                    //    trWithProctor.Visible = false;
                    //    trOndemand.Visible = false;
                    //    trMessage.Visible = true;
                    //    lblMessage.Text = "<font color='Blue' size='5px'>" + "You will be authenticated, without a live proctor. Start by clicking the “Schedule” button and follow the instructions." + "</font>";
                    //    Result = PLexamvalidations();
                    //    if (Result == 0)
                    //    {
                    //        if (objBEStudent.DtResult.Rows[0]["ExamStartDate"].ToString() == "--" || objBEStudent.DtResult.Rows[0]["ExamEndDate"].ToString() == "--")
                    //        {

                    //            trMessage.Visible = true;
                    //            lblMessage.Text = "<font color='Blue'>" + Resources.ResMessages.StartDateAndEndDateIsEmpty + "</font>";
                    //            trNonProctor.Visible = false;
                    //            trNonProctorReschedule.Visible = false;
                    //        }
                    //    }
                    //    else
                    //    {
                    //        this.ShowExamPLExistsValidation(Result);
                    //    }
                    //    #endregion
                    //}
                    //else
                    {
                        #region ProctorFlow
                        trOndemand.Visible = true;
                        trMessage.Visible = false;
                        Result = CheckForSameExamExistsOrNot();

                        if (Convert.ToInt32(objBEStudent.DtResult.Rows[0]["examiFACE"].ToString()) == 1 || Convert.ToInt32(objBEStudent.DtResult.Rows[0]["ExamSecurity"]) == 1)
                        {
                            if (isfromexamdrop == 1)
                            {
                                btnOnDemand.Checked = true;
                                btnOnDemand.ToggleStates[0].Selected = true;
                                //btnOnDemand.SelectedToggleState.Value = "ON";
                            }
                            //else
                            //{

                            //    btnOnDemand.Checked = false;
                            //    btnOnDemand.ToggleStates[0].Selected = false;
                            //}
                        }
                        else
                        {
                            if (isfromexamdrop == 1)
                            {
                                btnOnDemand.Checked = false;
                                btnOnDemand.ToggleStates[1].Selected = false;
                                //btnOnDemand.SelectedToggleState.Value = "ON";
                            }
                        }
                        

                        if (Result == 0)
                            //Proctor Flow : Start
                            if (objBEStudent.DtResult.Rows[0]["ExamStartDate"].ToString() == "--" || objBEStudent.DtResult.Rows[0]["ExamEndDate"].ToString() == "--")
                            {
                                trMessage.Visible = true;
                                lblMessage.Text = "<font color='Blue'>" + Resources.ResMessages.StartDateAndEndDateIsEmpty + "</font>";
                                trNonProctor.Visible = false;
                                trWithProctor.Visible = false;
                                trNonProctorReschedule.Visible = false;
                            }
                            else
                            {
                                trWithProctor.Visible = true;
                                trNonProctor.Visible = false;
                                trNonProctorReschedule.Visible = false;
                                if (btnOnDemand.SelectedToggleState.Value == "ON")
                                {
                                    if (this.GetUserCurrentTime().Date <= Convert.ToDateTime(objBEStudent.DtResult.Rows[0]["ExamStartDate"].ToString()).Date)
                                    {
                                        calSchedular.RangeMinDate = Convert.ToDateTime(objBEStudent.DtResult.Rows[0]["ExamStartDate"].ToString());
                                        calSchedular.SelectedDate = Convert.ToDateTime(objBEStudent.DtResult.Rows[0]["ExamStartDate"].ToString());
                                    }
                                    else
                                    {
                                        calSchedular.RangeMinDate = this.GetUserCurrentTime();
                                        calSchedular.SelectedDate = this.GetUserCurrentTime();
                                    }
                                }
                                else
                                {
                                    if (this.GetUserCurrentTime().AddDays(1) <= Convert.ToDateTime(objBEStudent.DtResult.Rows[0]["ExamStartDate"].ToString()))
                                    {
                                        calSchedular.RangeMinDate = Convert.ToDateTime(objBEStudent.DtResult.Rows[0]["ExamStartDate"].ToString());
                                        calSchedular.SelectedDate = Convert.ToDateTime(objBEStudent.DtResult.Rows[0]["ExamStartDate"].ToString());
                                    }
                                    else
                                    {
                                        calSchedular.RangeMinDate = this.GetUserCurrentTime().AddDays(1);
                                        calSchedular.SelectedDate = this.GetUserCurrentTime().AddDays(1);
                                    }
                                }
                                calSchedular.RangeMaxDate = Convert.ToDateTime(objBEStudent.DtResult.Rows[0]["ExamEndDate"].ToString());
                                this.setDefaultStyles();
                                this.BindTimeSlots(1);
                            }
                        //Proctor Flow : End                            
                        else
                        {
                            this.ShowExamExistsValidation(Result);
                        }
                        #endregion
                    }
                }
            }
            else
            {

            }
        }
        protected int CheckForSameExamExistsOrNot()
        {
            int intResult = 0;

            BStudent objBStudent = new BStudent();
            BEStudent objBEStudent = new BEStudent();
            objBEStudent.IntExamID = Convert.ToInt32(drpExam.SelectedValue.ToString());
            objBEStudent.IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID]);
            objBStudent.BValidateStudentExam(objBEStudent);
            intResult = objBEStudent.IntResult;
            hdTransactionID.Value = objBEStudent.IntTransID.ToString();
            hdExamDate.Value = objBEStudent.strExamDate;
            objBEStudent = null;
            objBStudent = null;
            return intResult;
        }


        protected int PLexamvalidations()
        {
            int intResult = 0;
            BStudent objBStudent = new BStudent();
            BEStudent objBEStudent = new BEStudent();
            BECommon objBECommon = new BECommon();
            BCommon objBCommon = new BCommon();
            objBECommon.iTimeZoneID = Convert.ToInt32(Session["TimeZoneID"].ToString());
            objBCommon.BGetTimeDelay(objBECommon);
            objBEStudent.IntExamID = Convert.ToInt32(drpExam.SelectedValue.ToString());
            objBEStudent.IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID]);
            objBEStudent.dtExam = DateTime.UtcNow.AddMinutes(objBECommon.IntResult);
            objBStudent.BValidatePLExam(objBEStudent);
            intResult = objBEStudent.IntResult;
            objBEStudent = null;
            objBStudent = null;
            return intResult;


        }
        protected void ShowExamExistsValidation(int Result)
        {
            trOndemand.Visible = false;
            trWithProctor.Visible = false;
            trNonProctor.Visible = false;
            trNonProctorReschedule.Visible = false;

            if (Result == 1)
            {
                BEStudent objBEStudent = new BEStudent();
                objBEStudent.IntExamID = Convert.ToInt32(drpExam.SelectedValue);
                objBEStudent.IntCourseID = Convert.ToInt32(drpCourse.SelectedValue);
                objBEStudent.IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID]);
                new BStudent().BGetExamScheduledDate(objBEStudent);
                if (objBEStudent.DtResult != null && objBEStudent.DtResult.Rows.Count > 0)
                {
                    //lblMessage.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + "\"" + drpCourse.SelectedItem.Text.ToString() + "- " + drpExam.SelectedItem.Text.ToString() + "\" " + Resources.ResMessages.Student_ExamAlreadyExists + " " + objBEStudent.DtResult.Rows[0]["ExamDate"].ToString() + " at " + objBEStudent.DtResult.Rows[0]["Time"].ToString() + "</font>";
                    lblMessage.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + Resources.ResMessages.Student_AnAppointment + " " + drpExam.SelectedItem.Text.ToString() + " on " + " " + objBEStudent.DtResult.Rows[0]["ExamDate"].ToString() + " at " + objBEStudent.DtResult.Rows[0]["Time"].ToString() + "." + " " + Resources.ResMessages.Student_AreyouSure + "</font>";
                    trMessage.Visible = true;
                }
                else
                {
                    lblMessage.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + drpCourse.SelectedItem.Text.ToString() + "- " + drpExam.SelectedItem.Text.ToString() + Resources.ResMessages.Student_ExamAlreadyExistsElse + "</font>";
                    trMessage.Visible = true;
                }
                trRescheduleOrCancel.Visible = true;


            }
            else if (Result == 2)
            {
                lblMessage.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + "\"" + Resources.ResMessages.Student_AnAppointmentForthesame + " " + "Progress" + "." + Resources.ResMessages.Student_YouCantSchedule + "</font>";
                trMessage.Visible = true;

            }



            else if (Result == 3)
            {
                BEStudent obj = new BEStudent();
                obj.IntExamID = Convert.ToInt32(drpExam.SelectedValue);
                obj.IntTransID = 0;
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
                lblMessage.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + "You can take the exam between" + " " + StartDate + " and " + EndDate + "</font>";


                trMessage.Visible = true;
                trWithProctor.Visible = false;

            }


        }
        public void ScheduleAppointment(string strTime)
        {
            BEStudent objBEStudent = new BEStudent()
            {
                IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID]),
                IntCourseID = int.Parse(drpCourse.SelectedValue),
                IntExamID = int.Parse(drpExam.SelectedValue),
                dtExam = Convert.ToDateTime(calSchedular.SelectedDate.ToString("MM-dd-yyyy") + " " + strTime)
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
        }
        protected void ShowAlert_ScheduleExam_Create(BEStudent objBEStudent)
        {
            if (objBEStudent.DsResult != null)
            {
                if (Convert.ToInt32(objBEStudent.DsResult.Tables[0].Rows[0]["Result"]) == 1)
                {
                    BEStudent obj = new BEStudent();
                    obj.IntExamID = Convert.ToInt32(drpExam.SelectedValue);
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
                    trMessage.Visible = true;
                    lblMessage.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + "\"" + drpCourse.SelectedItem.Text.ToString() + "- " + drpExam.SelectedItem.Text.ToString() + "\"" + Resources.ResMessages.Schedule_ExamStartEndDateValidation + " " + StartDate + " and " + EndDate + "</font>";
                }
                else if (Convert.ToInt32(objBEStudent.DsResult.Tables[0].Rows[0]["Result"]) == 2)
                {
                    trMessage.Visible = true;
                    lblMessage.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + Resources.ResMessages.Schedule_24hoursValidation + "</font>";
                }
                else if (Convert.ToInt32(objBEStudent.DsResult.Tables[0].Rows[0]["Result"]) == 3)
                {
                    lblMessage.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + Resources.ResMessages.Schedule_PriorDateValidation + "</font>";
                    trMessage.Visible = true;
                }
                else if (Convert.ToInt32(objBEStudent.DsResult.Tables[0].Rows[0]["Result"]) == 4)
                {
                    string TransactionID = "";
                    string BeforeEncriptTransID = objBEStudent.DsResult.Tables[0].Rows[0]["ID"].ToString();
                    TransactionID = AppSecurity.Encrypt(objBEStudent.DsResult.Tables[0].Rows[0]["ID"].ToString());
                    lblMessage.Text = "<img src='../Images/yes.png' align='middle'/>&nbsp;<font color='#00C000'>" + Resources.ResMessages.Schedule_Confirmation + " " + objBEStudent.DsResult.Tables[0].Rows[0]["ID"] + Resources.ResMessages.Schedule_Confirmation1 + "</font>";
                    trMessage.Visible = true;
                    try
                    {
                        BEMail objBEMail = new BEMail();
                        BMail objBMail = new BMail();
                        objBEMail.IntUserID = 0;
                        objBEMail.IntTransID = Convert.ToInt64(objBEStudent.DsResult.Tables[0].Rows[0]["ID"]);
                        objBEMail.StrTemplateName = BaseClass.EnumEmails.StudentExamReceipt.ToString();
                        objBMail.BSendEmail(objBEMail);
                    }
                    catch (Exception )
                    {
                    }
                    this.LogPayments(Convert.ToInt64(objBEStudent.DsResult.Tables[0].Rows[0]["ID"].ToString()), objBEStudent.decExamFee + objBEStudent.PerHourFee, objBEStudent.decOnDemandFee, EnumPayment.ExamType_Scheduled);
                    Response.Redirect("PLConfirmation.aspx?TransID=" + TransactionID + "&Type=" + AppSecurity.Encrypt("0"));
                }
                else if (Convert.ToInt32(objBEStudent.DsResult.Tables[0].Rows[0]["Result"]) == 5)
                {
                    lblMessage.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + Resources.ResMessages.Schedule_TimeWindowValidation + "</font>";
                    trMessage.Visible = true;
                }
                else if (Convert.ToInt32(objBEStudent.DsResult.Tables[0].Rows[0]["Result"]) == 6)
                {
                    objBEStudent.IntExamID = Convert.ToInt32(drpExam.SelectedValue);
                    objBEStudent.IntCourseID = Convert.ToInt32(drpCourse.SelectedValue);
                    objBEStudent.IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID]);
                    new BStudent().BGetExamScheduledDate(objBEStudent);
                    if (objBEStudent.DtResult != null && objBEStudent.DtResult.Rows.Count > 0)
                    {
                        lblMessage.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + "\"" + drpCourse.SelectedItem.Text.ToString() + "- " + drpExam.SelectedItem.Text.ToString() + "\" " + Resources.ResMessages.Student_ExamAlreadyExists + " " + objBEStudent.DtResult.Rows[0]["ExamDate"].ToString() + " at " + objBEStudent.DtResult.Rows[0]["Time"].ToString() + "</font>";
                        trMessage.Visible = true;
                    }
                    else
                    {
                        lblMessage.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + "\"" + drpCourse.SelectedItem.Text.ToString() + "- " + drpExam.SelectedItem.Text.ToString() + "\"" + Resources.ResMessages.Student_ExamAlreadyExistsElse + "</font>";
                        trMessage.Visible = true;
                    }
                }

                else if (Convert.ToInt32(objBEStudent.DsResult.Tables[0].Rows[0]["Result"]) == 7)
                {
                    lblMessage.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + Resources.ResMessages.Schedule_OndemandValidation + "</font>";
                    trMessage.Visible = true;
                }
            }
        }
        protected void ShowAlert_ScheduleExam_Validate(int intResult)
        {
            if (intResult == 1)
            {
                BEStudent obj = new BEStudent();
                obj.IntExamID = Convert.ToInt32(drpExam.SelectedValue);
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
                lblMessage.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + "\"" + drpCourse.SelectedItem.Text.ToString() + "- " + drpExam.SelectedItem.Text.ToString() + "\"" + Resources.ResMessages.Schedule_ExamStartEndDateValidation + " " + StartDate + " and " + EndDate + "</font>";
                trMessage.Visible = true;
            }
            else if (intResult == 2)
            {
                lblMessage.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + Resources.ResMessages.Schedule_24hoursValidation + "</font>";
                trMessage.Visible = true;
            }
            else if (intResult == 3)
            {
                lblMessage.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + Resources.ResMessages.Schedule_PriorDateValidation + "</font>";
                trMessage.Visible = true;
            }
            else if (intResult == 5)
            {
                lblMessage.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + Resources.ResMessages.Schedule_TimeWindowValidation + "</font>";
                trMessage.Visible = true;
            }
            else if (intResult == 6)
            {
                BEStudent objBEStudent = new BEStudent();
                objBEStudent.IntExamID = Convert.ToInt32(drpExam.SelectedValue);
                objBEStudent.IntCourseID = Convert.ToInt32(drpCourse.SelectedValue);

                objBEStudent.IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID]);
                new BStudent().BGetExamScheduledDate(objBEStudent);
                if (objBEStudent.DtResult != null && objBEStudent.DtResult.Rows.Count > 0)
                {
                    lblMessage.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + "\"" + drpCourse.SelectedItem.Text.ToString() + "- " + drpExam.SelectedItem.Text.ToString() + "\" " + Resources.ResMessages.Student_ExamAlreadyExists + " " + objBEStudent.DtResult.Rows[0]["ExamDate"].ToString() + " at " + objBEStudent.DtResult.Rows[0]["Time"].ToString() + "</font>";
                    trMessage.Visible = true;
                }
                else
                {
                    lblMessage.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + "\"" + drpCourse.SelectedItem.Text.ToString() + "- " + drpExam.SelectedItem.Text.ToString() + "\"" + Resources.ResMessages.Student_ExamAlreadyExistsElse + "</font>";
                    trMessage.Visible = true;
                }
            }
            else if (intResult == 7)
            {
                lblMessage.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + Resources.ResMessages.Schedule_OndemandValidation + "</font>";
                trMessage.Visible = true;
            }

        }
        #endregion
        #region ReschedulingMethods
        protected void BindReschduleExamDetails()
        {
            BEStudent objBEStudent = new BEStudent();
            BStudent objBStudent = new BStudent();
            objBEStudent.IntTransID = Convert.ToInt64(AppSecurity.Decrypt(Request.QueryString["ExamID"].ToString()));
            objBStudent.BGetExamValues(objBEStudent);
            //drpInstructor.SelectedValue = objBEStudent.IntProviderID.ToString();
            //BindCourse();
            //drpCourse.SelectedValue = objBEStudent.IntCourseID.ToString();
            //BindExams();
            //drpExam.SelectedValue = objBEStudent.IntExamID.ToString();
            trRescheduleOrCancel.Visible = true;
            trNonProctorReschedule.Visible = false;
            // trRescheduleMsg.Visible = true;
            trNonProctor.Visible = false;
            trWithProctor.Visible = false;
            trMessage.Visible = true;
            lblInstructor.Text = objBEStudent.strUserName;
            lblCourse.Text = objBEStudent.strCourseName;
            lblExam.Text = objBEStudent.strExamName;
            hdExamID.Value = objBEStudent.IntExamID.ToString();
            if (objBEStudent.DtResult != null && objBEStudent.DtResult.Rows.Count > 0)
            {
                lblStartDate.Text = objBEStudent.DtResult.Rows[0]["ExamStartDate"].ToString() + "  " + "<b>-</b>";
                lblEndDate.Text = objBEStudent.DtResult.Rows[0]["ExamEndDate"].ToString();
                lblExamDuration.Text = objBEStudent.DtResult.Rows[0]["ExamDuration"].ToString() + " " + "Minutes";
                lblMessage.Text = "<font color='Blue' size='5px'>" + "Do you want to reschedule or cancel the existing appointment that is scheduled on  " + objBEStudent.DtResult.Rows[0]["ExamDate"].ToString() + "  " + "at" + "  " + objBEStudent.DtResult.Rows[0]["ExamTime"].ToString() + "?" + "</font>"; ;
            }
            drpInstructor.Visible = false;
            drpCourse.Visible = false;
            drpExam.Visible = false;
            lblInstructor.Visible = true;
            lblCourse.Visible = true;
            lblExam.Visible = true;
        }
        protected int GetExamID()
        {
            int intExamID = 0;
            try
            {
                BEStudent objBEStudent = new BEStudent();
                BStudent objBStudent = new BStudent();
                objBEStudent.IntTransID = Convert.ToInt64(AppSecurity.Decrypt(Request.QueryString["ExamID"].ToString()));
                objBStudent.BGetExamValues(objBEStudent);
                intExamID = objBEStudent.IntExamID;
            }
            catch
            {
            }
            return intExamID;
        }
        protected void BindRescheduleValues()
        {
            trMessage.Visible = false;
            btnSchedule.Text = "Reschedule";
            trRescheduleOrCancel.Visible = false;
            BECommon objBEStudent = new BECommon { IntExamID = Convert.ToInt32(this.GetExamID()), IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID]) };
            new BCommon().BGetExamDetails(objBEStudent);
            if (objBEStudent.DtResult != null && objBEStudent.DtResult.Rows.Count > 0)
            {
                lblStartDate.Text = objBEStudent.DtResult.Rows[0]["ExamStartDate"].ToString() + "  " + "<b>-</b>";
                lblEndDate.Text = objBEStudent.DtResult.Rows[0]["ExamEndDate"].ToString();
                lblExamDuration.Text = objBEStudent.DtResult.Rows[0]["ExamDuration"].ToString() + " " + "Minutes";
                trOndemand.Visible = true;
                #region ProctorFlow
                //Proctor Flow : Start
                if (objBEStudent.DtResult.Rows[0]["ExamStartDate"].ToString() == "--" || objBEStudent.DtResult.Rows[0]["ExamEndDate"].ToString() == "--")
                {
                    trMessage.Visible = true;
                    lblMessage.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + Resources.ResMessages.StartDateAndEndDateIsEmpty + "</font>";
                }
                else
                {
                    trWithProctor.Visible = true;
                    trNonProctor.Visible = false;
                    if (btnOnDemand.SelectedToggleState.Value == "ON")
                    {
                        if (this.GetUserCurrentTime().Date <= Convert.ToDateTime(objBEStudent.DtResult.Rows[0]["ExamStartDate"].ToString()).Date)
                        {
                            calSchedular.RangeMinDate = Convert.ToDateTime(objBEStudent.DtResult.Rows[0]["ExamStartDate"].ToString());
                            calSchedular.SelectedDate = Convert.ToDateTime(objBEStudent.DtResult.Rows[0]["ExamStartDate"].ToString());
                        }
                        else
                        {
                            calSchedular.RangeMinDate = GetUserCurrentTime();
                            calSchedular.SelectedDate = GetUserCurrentTime();
                        }
                    }
                    else
                    {
                        if (this.GetUserCurrentTime().AddDays(1).Date <= Convert.ToDateTime(objBEStudent.DtResult.Rows[0]["ExamStartDate"].ToString()).Date)
                        {
                            calSchedular.RangeMinDate = Convert.ToDateTime(objBEStudent.DtResult.Rows[0]["ExamStartDate"].ToString());
                            calSchedular.SelectedDate = Convert.ToDateTime(objBEStudent.DtResult.Rows[0]["ExamStartDate"].ToString());
                        }
                        else
                        {
                            calSchedular.RangeMinDate = GetUserCurrentTime().AddDays(1);
                            calSchedular.SelectedDate = GetUserCurrentTime().AddDays(1);
                        }
                    }
                    calSchedular.RangeMaxDate = Convert.ToDateTime(objBEStudent.DtResult.Rows[0]["ExamEndDate"].ToString());
                    this.setDefaultStyles();
                    this.BindTimeSlots(1);
                }
                //Proctor Flow : End
                #endregion
            }
        }
        protected void BindRescheduleValuesOnLoad()
        {
            trMessage.Visible = false;
            btnSchedule.Text = "Reschedule";
            trRescheduleOrCancel.Visible = false;
            BECommon objBEStudent = new BECommon { IntExamID = Convert.ToInt32(this.GetExamID()), IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID]) };
            new BCommon().BGetExamDetails(objBEStudent);
            if (objBEStudent.DtResult != null && objBEStudent.DtResult.Rows.Count > 0)
            {

                lblStartDate.Text = objBEStudent.DtResult.Rows[0]["ExamStartDate"].ToString() + "  " + "<b>-</b>";
                lblEndDate.Text = objBEStudent.DtResult.Rows[0]["ExamEndDate"].ToString();
                lblExamDuration.Text = objBEStudent.DtResult.Rows[0]["ExamDuration"].ToString() + " " + "Minutes";
                trOndemand.Visible = true;
                #region ProctorFlow
                //Proctor Flow : Start
                if (objBEStudent.DtResult.Rows[0]["ExamStartDate"].ToString() == "--" || objBEStudent.DtResult.Rows[0]["ExamEndDate"].ToString() == "--")
                {
                    trMessage.Visible = true;
                    lblMessage.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + Resources.ResMessages.StartDateAndEndDateIsEmpty + "</font>";
                }
                else
                {
                    if (Convert.ToInt32(objBEStudent.DtResult.Rows[0]["examiFACE"].ToString()) == 1 || Convert.ToInt32(objBEStudent.DtResult.Rows[0]["ExamSecurity"]) == 1)
                    {
                        btnOnDemand.Checked = true;
                        btnOnDemand.ToggleStates[0].Selected = true;
                    }
                    trWithProctor.Visible = true;
                    trNonProctor.Visible = false;
                    if (btnOnDemand.SelectedToggleState.Value == "ON")
                    {
                        if (this.GetUserCurrentTime().Date <= Convert.ToDateTime(objBEStudent.DtResult.Rows[0]["ExamStartDate"].ToString()).Date)
                        {
                            calSchedular.RangeMinDate = Convert.ToDateTime(objBEStudent.DtResult.Rows[0]["ExamStartDate"].ToString());
                            calSchedular.SelectedDate = Convert.ToDateTime(objBEStudent.DtResult.Rows[0]["ExamStartDate"].ToString());
                        }
                        else
                        {
                            calSchedular.RangeMinDate = this.GetUserCurrentTime();
                            calSchedular.SelectedDate = this.GetUserCurrentTime();
                        }
                    }
                    else
                    {
                        if (this.GetUserCurrentTime().AddDays(1).Date <= Convert.ToDateTime(objBEStudent.DtResult.Rows[0]["ExamStartDate"].ToString()).Date)
                        {
                            calSchedular.RangeMinDate = Convert.ToDateTime(objBEStudent.DtResult.Rows[0]["ExamStartDate"].ToString());
                            calSchedular.SelectedDate = Convert.ToDateTime(objBEStudent.DtResult.Rows[0]["ExamStartDate"].ToString());
                        }
                        else
                        {
                            calSchedular.RangeMinDate = GetUserCurrentTime().AddDays(1);
                            calSchedular.SelectedDate = GetUserCurrentTime().AddDays(1);
                        }
                    }
                    if (Request.QueryString["ExamDate"] != null)
                    {
                        calSchedular.SelectedDate = Convert.ToDateTime(AppSecurity.Decrypt(Request.QueryString["ExamDate"].ToString()).Replace("EC", "/").Trim());
                        if (Convert.ToDateTime(AppSecurity.Decrypt(Request.QueryString["ExamDate"].ToString()).Replace("EC", "/").Trim()) < calSchedular.RangeMinDate)
                            calSchedular.RangeMinDate = Convert.ToDateTime(AppSecurity.Decrypt(Request.QueryString["ExamDate"].ToString()).Replace("EC", "/").Trim());
                    }
                    calSchedular.RangeMaxDate = Convert.ToDateTime(objBEStudent.DtResult.Rows[0]["ExamEndDate"].ToString());
                    this.setDefaultStyles();
                    this.BindTimeSlots(1);
                }
                //Proctor Flow : End
                #endregion
            }
        }

        protected void BindRescheduleValuesOnLoadNonProctor()
        {
            trMessage.Visible = false;
            //btnSchedule.Text = "Reschedule";
            trNonProctorReschedule.Visible = true;
            BECommon objBEStudent = new BECommon { IntExamID = Convert.ToInt32(this.GetExamID()), IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID]) };
            new BCommon().BGetExamDetails(objBEStudent);
            if (objBEStudent.DtResult != null && objBEStudent.DtResult.Rows.Count > 0)
            {
                lblStartDate.Text = objBEStudent.DtResult.Rows[0]["ExamStartDate"].ToString() + "  " + "<b>-</b>";
                lblEndDate.Text = objBEStudent.DtResult.Rows[0]["ExamEndDate"].ToString();
                lblExamDuration.Text = objBEStudent.DtResult.Rows[0]["ExamDuration"].ToString() + " " + "Minutes";
                trOndemand.Visible = true;
                #region ProctorFlow
                //Proctor Flow : Start
                if (objBEStudent.DtResult.Rows[0]["ExamStartDate"].ToString() == "--" || objBEStudent.DtResult.Rows[0]["ExamEndDate"].ToString() == "--")
                {
                    trMessage.Visible = true;
                    lblMessage.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + Resources.ResMessages.StartDateAndEndDateIsEmpty + "</font>";
                }
                else
                {
                    trWithProctor.Visible = false;
                    trNonProctor.Visible = true;
                    if (btnOnDemand.SelectedToggleState.Value == "ON")
                    {
                        if (this.GetUserCurrentTime().Date <= Convert.ToDateTime(objBEStudent.DtResult.Rows[0]["ExamStartDate"].ToString()).Date)
                        {
                            calSchedular.RangeMinDate = Convert.ToDateTime(objBEStudent.DtResult.Rows[0]["ExamStartDate"].ToString());
                            calSchedular.SelectedDate = Convert.ToDateTime(objBEStudent.DtResult.Rows[0]["ExamStartDate"].ToString());
                        }
                        else
                        {
                            calSchedular.RangeMinDate = this.GetUserCurrentTime();
                            calSchedular.SelectedDate = this.GetUserCurrentTime();
                        }
                    }
                    else
                    {
                        if (this.GetUserCurrentTime().AddDays(1).Date <= Convert.ToDateTime(objBEStudent.DtResult.Rows[0]["ExamStartDate"].ToString()).Date)
                        {
                            calSchedular.RangeMinDate = Convert.ToDateTime(objBEStudent.DtResult.Rows[0]["ExamStartDate"].ToString());
                            calSchedular.SelectedDate = Convert.ToDateTime(objBEStudent.DtResult.Rows[0]["ExamStartDate"].ToString());
                        }
                        else
                        {
                            calSchedular.RangeMinDate = GetUserCurrentTime().AddDays(1);
                            calSchedular.SelectedDate = GetUserCurrentTime().AddDays(1);
                        }
                    }
                    if (Request.QueryString["ExamDate"] != null)
                    {
                        calSchedular.SelectedDate = Convert.ToDateTime(AppSecurity.Decrypt(Request.QueryString["ExamDate"].ToString()).Replace("EC", "/").Trim());
                        if (Convert.ToDateTime(AppSecurity.Decrypt(Request.QueryString["ExamDate"].ToString()).Replace("EC", "/").Trim()) < calSchedular.RangeMinDate)
                            calSchedular.RangeMinDate = Convert.ToDateTime(AppSecurity.Decrypt(Request.QueryString["ExamDate"].ToString()).Replace("EC", "/").Trim());
                    }
                    calSchedular.RangeMaxDate = Convert.ToDateTime(objBEStudent.DtResult.Rows[0]["ExamEndDate"].ToString());
                    this.setDefaultStyles();
                    this.BindTimeSlots(1);
                }
                //Proctor Flow : End
                #endregion
            }
        }

        protected void ReScheduleAppointment(string strTime)
        {
            trRescheduleOrCancel.Visible = false;
            BEStudent objBEStudent = new BEStudent()
            {
                IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID]),
                IntScheduleID = Convert.ToInt64(AppSecurity.Decrypt(Request.QueryString["ExamID"].ToString())),
                dtExam = Convert.ToDateTime(calSchedular.SelectedDate.ToString("MM-dd-yyyy") + " " + strTime),
                strDescription = "1",
                IntExamID = Convert.ToInt32(this.GetExamID())
            };
            this.SetExamFeeSettings(objBEStudent.IntScheduleID, "TRANSID");
            Int64 intTransID = Convert.ToInt64(AppSecurity.Decrypt(Request.QueryString["ExamID"].ToString()));
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
                    lblMessage.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + Resources.ResMessages.Reschedule_ExamStartEndDateValidation + " " + StartDate + " and " + EndDate + "</font>";
                    trMessage.Visible = true;
                }
                else if (Convert.ToInt32(objBEStudent.DsResult.Tables[0].Rows[0]["Result"]) == 2)
                {
                    lblMessage.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + Resources.ResMessages.Reschedule_24hoursValidation + "</font>";
                    trMessage.Visible = true;
                }
                else if (Convert.ToInt32(objBEStudent.DsResult.Tables[0].Rows[0]["Result"]) == 3)
                {
                    lblMessage.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + Resources.ResMessages.Reschedule_PriorDateValidation + "</font>";
                    trMessage.Visible = true;
                }
                else if (Convert.ToInt32(objBEStudent.DsResult.Tables[0].Rows[0]["Result"]) == 4)
                {
                    string TransactionID = "";
                    string BeforeEncriptTransID = objBEStudent.IntScheduleID.ToString();
                    TransactionID = AppSecurity.Encrypt(objBEStudent.IntScheduleID.ToString());
                    lblMessage.Text = "<img src='../Images/yes.png' align='middle'/>&nbsp;<font color='#00C000'>" + Resources.ResMessages.Reschedule_Confirmation + " " + objBEStudent.IntScheduleID.ToString() + Resources.ResMessages.Reschedule_Confirmation1 + "</font>";
                    trMessage.Visible = true;
                    //if (Session["Isproctorless"] != null)
                    //{
                    //    if (Session["Isproctorless"].ToString() == "1")
                    //    {
                    //        BStudent objBStudent = new BStudent();
                    //        objBEStudent.IntTransID = Convert.ToInt32(BeforeEncriptTransID);
                    //        objBEStudent.IntResult = 1;
                    //        objBStudent.BUpdateNonProctorExamStatus(objBEStudent);
                    //        System.Web.HttpContext.Current.Response.Redirect("~/Student/Captureimage.aspx?TransID=" + TransactionID, false);
                    //    }
                    //}
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
                    this.LogPayments(Convert.ToInt64(objBEStudent.IntScheduleID), objBEStudent.decExamFee + objBEStudent.PerHourFee, objBEStudent.decOnDemandFee, EnumPayment.ExamType_Rescheduled);
                    Response.Redirect("PLConfirmation.aspx?TransID=" + TransactionID + "&Type=" + AppSecurity.Encrypt("1"));
                }
                else if (Convert.ToInt32(objBEStudent.DsResult.Tables[0].Rows[0]["Result"]) == 5)
                {
                    lblMessage.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + Resources.ResMessages.Reschedule_TimeWindowValidation + "</font>";
                    trMessage.Visible = true;
                }
                else if (Convert.ToInt32(objBEStudent.DsResult.Tables[0].Rows[0]["Result"]) == 6)
                {
                    lblMessage.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + Resources.ResMessages.Reschedule_ExamProgressValidation + "</font>";
                    trMessage.Visible = true;
                }

                else if (Convert.ToInt32(objBEStudent.DsResult.Tables[0].Rows[0]["Result"]) == 7)
                {
                    lblMessage.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + Resources.ResMessages.Schedule_OndemandValidation + "</font>";
                    trMessage.Visible = true;
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
                lblMessage.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + Resources.ResMessages.Reschedule_ExamStartEndDateValidation + " " + StartDate + " and " + EndDate + "</font>";
                trMessage.Visible = true;
            }
            else if (intResult == 2)
            {
                lblMessage.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + Resources.ResMessages.Reschedule_24hoursValidation + "</font>";
                trMessage.Visible = true;
            }
            else if (intResult == 3)
            {
                lblMessage.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + Resources.ResMessages.Reschedule_PriorDateValidation + "</font>";
                trMessage.Visible = true;
            }
            else if (intResult == 5)
            {
                lblMessage.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + Resources.ResMessages.Reschedule_TimeWindowValidation + "</font>";
                trMessage.Visible = true;
            }
            else if (intResult == 6)
            {
                lblMessage.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + Resources.ResMessages.Reschedule_ExamProgressValidation + "</font>";
                trMessage.Visible = true;
            }
            else if (intResult == 7)
            {
                lblMessage.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + Resources.ResMessages.ReSchedule_OndemandValidation + "</font>";
                trMessage.Visible = true;
            }

        }
        #endregion
        #region ButtonEvents
        protected void btnOnDemand_Click(object sender, EventArgs e)
        {
            ViewState["Time"] = null;
            if (Request.QueryString["ExamID"] == null)
            {
                this.BindScheduleValues(0);
            }
            else
            {
                this.BindRescheduleValues();
            }
        }
        protected void btnSchedule_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["ExamID"] == null)
            {
                if (ViewState["Time"] != null)
                {

                    this.ScheduleAppointment(ViewState["Time"].ToString());



                }
                else
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "MyScript", "ShowAlert('Please select Time');", true);


            }
            else
            {
                if (ViewState["Time"] != null)
                {

                    this.ReScheduleAppointment(ViewState["Time"].ToString());

                }
                else
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "MyScript", "ShowAlert('Please select Time');", true);
            }
        }
        protected void btnReschedule_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["ExamID"] == null)
            {
                if (hdTransactionID.Value.ToString().Length != 0)
                    Response.Redirect("ScheduleAnExam.aspx?ExamID=" + AppSecurity.Encrypt(hdTransactionID.Value.ToString()) + "&Type=Reschedule&ExamDate=" + AppSecurity.Encrypt(hdExamDate.Value.ToString().Replace("/", "EC").Trim()), false);
                else
                    Response.Redirect("ScheduleAnExam.aspx");
            }
            else
            {
                this.BindRescheduleValuesOnLoad();

            }

        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["ExamID"] != null)
            {
                DeleteAppointment(Convert.ToInt64(AppSecurity.Decrypt(Request.QueryString["ExamID"].ToString())));
            }
            else if (hdTransactionID.Value != null)
            {
                if (hdTransactionID.Value.Length != 0)
                {
                    DeleteAppointment(Convert.ToInt64(hdTransactionID.Value.ToString()));
                }
            }

        }
        protected void DeleteAppointment(Int64 intTransID)
        {
            try
            {
                trMessage.Visible = true;
                lblMessage.Text = string.Empty;
                BEStudent objBEStudent = new BEStudent();
                objBEStudent.IntTransID = intTransID;
                objBEStudent.IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID]);
                BStudent objBStudent = new BStudent();
                objBStudent.BDeleteAppointment(objBEStudent);

                if (objBEStudent.DtResult.Rows.Count > 0 && objBEStudent.DtResult != null)
                {

                    if (Convert.ToInt32(objBEStudent.DtResult.Rows[0]["Result"]) != 1)
                    {
                        trMessage.Visible = true;
                        lblMessage.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + Resources.ResMessages.AppointmentDelete + "</font>";
                    }

                    else
                    {
                        try
                        {
                            BEMail objBEMail = new BEMail();
                            BMail objBMail = new BMail();
                            objBEMail.IntUserID = 0;
                            objBEMail.IntTransID = intTransID;
                            objBEMail.StrTemplateName = BaseClass.EnumEmails.ExamCancelConfirmation.ToString();
                            objBMail.BSendEmail(objBEMail);
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }

                        Response.Redirect("ExamCancelConfirmation.aspx?TransID=" + AppSecurity.Encrypt(intTransID.ToString()).ToString());
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region CalendarSelectedChange
        protected void calSchedular_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewState["Time"] = null;
            this.setDefaultStyles();
            BindTimeSlots(1);
        }
        #endregion
        #region PaymentMethods
        protected void ProcessPayment_Schedule(BEStudent objBEStudent)
        {
            objBEStudent.strCourseName = drpCourse.SelectedItem.Text.ToString();
            objBEStudent.strExamName = drpExam.SelectedItem.Text.ToString();
            Session["BESTUDENT"] = objBEStudent;
            Session["ExamId"] = objBEStudent.IntExamID;
            Response.Redirect("PaymentProcess.aspx");
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
        #endregion
        #region TimeSlotMethods
        protected void BGetAvailableTimeSlotsTable_Reset()
        {
            BECommon objBECommon = new BECommon();
            BCommon objBCommon = new BCommon();
            objBECommon.IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID]);
            if (btnOnDemand.SelectedToggleState.Value == "ON")
                objBECommon.intOndemand = 1;
            else
                objBECommon.intOndemand = 0;
            objBECommon.dtExam = calSchedular.SelectedDate;
            if (drpExam.SelectedValue.ToString() != "-1" && Request.QueryString["ExamID"] == null)
                objBECommon.IntExamID = Convert.ToInt32(drpExam.SelectedValue.ToString());
            else if (Request.QueryString["ExamID"] != null)
            {
                try
                {
                    objBECommon.IntExamID = Convert.ToInt32(hdExamID.Value.ToString());
                }
                catch
                {
                    objBECommon.IntExamID = 0;
                }
            }
            else
                objBECommon.IntExamID = 0; 
            objBCommon.BGetAvailableTimeSlots(objBECommon);
            Session["TIMESLOTS"] = objBECommon.DtResult;
            objBECommon = null;
            objBCommon = null;
        }
        protected System.Data.DataTable BGetAvailableTimeSlotsTable()
        {
            System.Data.DataTable dtResult = new System.Data.DataTable();
            if (Session["TIMESLOTS"] != null)
                dtResult = (System.Data.DataTable)Session["TIMESLOTS"];
            else
            {
                this.BGetAvailableTimeSlotsTable_Reset();
                dtResult = (System.Data.DataTable)Session["TIMESLOTS"];
            }
            return dtResult;
        }
        protected void GetBlockedSlotsTable_Reset()
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
        protected System.Data.DataSet GetBlockedSlotsTable()
        {
            if (Session["DSSLOTS"] == null)
                this.GetBlockedSlotsTable_Reset();
            return (System.Data.DataSet)Session["DSSLOTS"];
        }
        protected void BindTimeSlots(int intResetStatus)
        {
            System.Data.DataTable dtResult = null;
            System.Data.DataSet dsResult = null;

            if (intResetStatus == 1)
            {
                this.BGetAvailableTimeSlotsTable_Reset();
                this.GetBlockedSlotsTable_Reset();
            }

            dtResult = this.BGetAvailableTimeSlotsTable();
            dsResult = this.GetBlockedSlotsTable();

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
                this.setDefaultStyles();
            }
            else
            {
                for (int intI = 0; intI < dtResult.Rows.Count; intI++)
                {
                    if (calSchedular.SelectedDate <= calSchedular.RangeMaxDate)
                    {
                        if (calSchedular.SelectedDate.Date >= Convert.ToDateTime(dtResult.Rows[intI]["ExamSlot"]).Date)
                        {
                            if (this.Page.Master.FindControl("StudentContent").FindControl("trWithProctor").FindControl("div_" + dtResult.Rows[intI]["ExamSlot1"].ToString().Replace("00 AM", "AM").Replace("00 PM", "PM").Replace(":", "").Replace(" ", "")) != null)
                            {
                                ((HtmlGenericControl)this.Page.Master.FindControl("StudentContent").FindControl("trWithProctor").FindControl("div_" + dtResult.Rows[intI]["ExamSlot1"].ToString().Replace("00 AM", "AM").Replace("00 PM", "PM").Replace(":", "").Replace(" ", ""))).Attributes.Add("class", "cal-SlotAvailable");
                                ((HiddenField)this.Page.Master.FindControl("StudentContent").FindControl("trWithProctor").FindControl("hd_" + dtResult.Rows[intI]["ExamSlot1"].ToString().Replace("00 AM", "AM").Replace("00 PM", "PM").Replace(":", "").Replace(" ", ""))).Value = "cal-SlotAvailable";
                            }
                        }
                    }
                }
            }
            dtResult = null;
            dsResult = null;
            #region BlockSlots Before Start Time
            try
            {
                string[] strStartDate = lblStartDate.Text.Trim().ToString().Split(' ');
                if (Convert.ToDateTime(strStartDate[0]).ToString("MM/dd/yyyy") == calSchedular.SelectedDate.ToString("MM/dd/yyyy"))
                {
                    string strControlToFind = "div_";
                    if (strStartDate[1].Length == 4)
                        strControlToFind = strControlToFind + "0" + strStartDate[1].ToString().Replace(":", "") + strStartDate[2].ToString();
                    else
                        strControlToFind = strControlToFind + strStartDate[1].ToString().Replace(":", "") + strStartDate[2].ToString();

                    for (int i = this.GetSlotIndex(strControlToFind) - 1; i >= 0; i--)
                    {
                        ((HtmlGenericControl)this.Page.Master.FindControl("StudentContent").FindControl("trWithProctor").FindControl(strDivControls[i].ToString())).Attributes.Add("class", "cal-SlotNotAvailable");
                        ((HiddenField)this.Page.Master.FindControl("StudentContent").FindControl("trWithProctor").FindControl(strDivControls[i].Replace("div_", "hd_").ToString().Replace("00 AM", "AM").Replace("00 PM", "PM").Replace(":", "").Replace(" ", ""))).Value = "cal-SlotNotAvailable";
                    }
                }
            }
            catch
            {
            }
            #endregion

            #region BlockSlots After End Time
            try
            {
                string[] strEndDate = lblEndDate.Text.Trim().ToString().Split(' ');
                if (Convert.ToDateTime(strEndDate[0]).ToString("MM/dd/yyyy") == calSchedular.SelectedDate.ToString("MM/dd/yyyy"))
                {
                    //Logic to replace 29 with 30 and 59 with 00
                    string[] minutes = strEndDate[1].Split(':');
                    if (minutes[1] == "29")
                        strEndDate[1] = minutes[0].ToString() + ":" + "30";
                    if (minutes[1] == "59")
                    {
                        int Hours = Convert.ToInt32(minutes[0]) + 1;

                        if (Hours == 12)
                        {
                            strEndDate[1] = Hours.ToString() + ":" + "00";
                            if (strEndDate[2].ToString() == "AM")
                                strEndDate[2] = "PM";
                            else if (strEndDate[2].ToString() == "PM")
                            {
                                // strEndDate[2] = "AM";
                                strEndDate[1] = "11" + ":" + "30";
                                //strEndDate[0] = Convert.ToDateTime(strEndDate[0]).AddDays(1).ToString("MM/dd/yyyy");
                            }

                        }

                        else if (Hours == 13)
                        {
                            strEndDate[1] = "01" + ":" + "00";


                        }
                        else
                        {
                            strEndDate[1] = Hours.ToString() + ":" + "00";

                        }



                    }
                    string strControlToFind = "div_";
                    if (strEndDate[1].Length == 4)
                        strControlToFind = strControlToFind + "0" + strEndDate[1].ToString().Replace(":", "") + strEndDate[2].ToString();
                    else
                        strControlToFind = strControlToFind + strEndDate[1].ToString().Replace(":", "") + strEndDate[2].ToString();


                    for (int i = this.GetSlotIndex(strControlToFind); i < 48; i++)
                    {
                        ((HtmlGenericControl)this.Page.Master.FindControl("StudentContent").FindControl("trWithProctor").FindControl(strDivControls[i].ToString())).Attributes.Add("class", "cal-SlotNotAvailable");
                        ((HiddenField)this.Page.Master.FindControl("StudentContent").FindControl("trWithProctor").FindControl(strDivControls[i].Replace("div_", "hd_").ToString().Replace("00 AM", "AM").Replace("00 PM", "PM").Replace(":", "").Replace(" ", ""))).Value = "cal-SlotNotAvailable";
                    }
                    //Logic to replace 29 with 30 and 59 with 00  end
                }


            }

            catch
            {
            }
            #endregion



            this.BindBookedExamSlosts();
        }
        #endregion
        #region NonProctor Methods
        protected void ShowExamPLExistsValidation(int Result)
        {
            if (Result == 1)
            {
                BEStudent objBEStudent = new BEStudent();
                objBEStudent.IntExamID = Convert.ToInt32(drpExam.SelectedValue);
                objBEStudent.IntCourseID = Convert.ToInt32(drpCourse.SelectedValue);
                objBEStudent.IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID]);
                new BStudent().BGetExamScheduledDate(objBEStudent);
                if (objBEStudent.DtResult != null && objBEStudent.DtResult.Rows.Count > 0)
                {
                    //lblMessage.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + "\"" + drpCourse.SelectedItem.Text.ToString() + "- " + drpExam.SelectedItem.Text.ToString() + "\" " + Resources.ResMessages.Student_ExamAlreadyExists + " " + objBEStudent.DtResult.Rows[0]["ExamDate"].ToString() + " at " + objBEStudent.DtResult.Rows[0]["Time"].ToString() + "</font>";
                    // lblMessage.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + Resources.ResMessages.Student_AnAppointment + " " + drpExam.SelectedItem.Text.ToString() + " on " + " " + objBEStudent.DtResult.Rows[0]["ExamDate"].ToString() + " at " + objBEStudent.DtResult.Rows[0]["Time"].ToString() + "." + " " + Resources.ResMessages.Student_AreyouSure + "</font>";

                    lblMessage.Text = "<font color='Blue' size='5px'>" + "Do you want to reschedule or cancel the existing appointment that is scheduled on  " + objBEStudent.DtResult.Rows[0]["ExamDate"].ToString() + "  " + "at" + "  " + objBEStudent.DtResult.Rows[0]["Time"].ToString() + "?" + "</font>"; ;
                    trMessage.Visible = true;
                    trNonProctor.Visible = false;
                    trNonProctorReschedule.Visible = true;
                }
                else
                {
                    //lblMessage.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + drpCourse.SelectedItem.Text.ToString() + "- " + drpExam.SelectedItem.Text.ToString() + "\"" + Resources.ResMessages.Student_ExamAlreadyExistsElse +" " + Resources.ResMessages.Student_AreyouSure +"</font>";
                    lblMessage.Text = "<font color='Blue' size='5px'>" + "Do you want to reschedule or cancel the existing appointment?" + "</font>";


                    trMessage.Visible = true;
                    trNonProctor.Visible = false;
                    trNonProctorReschedule.Visible = true;
                }

            }
            else if (Result == 2)
            {
                lblMessage.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + Resources.ResMessages.Student_AnAppointmentForthesame + " " + "Progress" + "." + Resources.ResMessages.Student_YouCantSchedule + "</font>";
                trMessage.Visible = true;
                trNonProctor.Visible = false;
                trNonProctorReschedule.Visible = false;

            }

            else if (Result == 3)
            {
                BEStudent obj = new BEStudent();
                obj.IntExamID = Convert.ToInt32(drpExam.SelectedValue);
                obj.IntTransID = 0;
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
                lblMessage.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + "You can take the exam between" + " " + StartDate + " and " + EndDate + "</font>";


                trMessage.Visible = true;
                trNonProctor.Visible = false;
                trNonProctorReschedule.Visible = false;

            }


        }
        //protected void btnTakeTest_Click(object sender, EventArgs e)
        //{
        //    BECommon objBEStudent2 = new BECommon();
        //    objBEStudent2.strCourseName = drpCourse.SelectedItem.Text.ToString();
        //    objBEStudent2.strExamName = drpExam.SelectedItem.Text.ToString();
        //    Session["ExamId"] = drpExam.SelectedValue.ToString();
        //    Session["Flowcheck"] = null;
        //    Session["NonProctorExam"] = null;
        //    Session["Isproctorless"] = null;

        //    if (drpInstructor.SelectedValue.ToString() != "-1" && drpCourse.SelectedValue.ToString() != "-1" && drpExam.SelectedValue.ToString() != "-1")
        //    {
        //        BEStudent objBEstudent = new BEStudent();
        //        objBEstudent.IntExamID = Convert.ToInt32(drpExam.SelectedValue);
        //        objBEstudent.IntCourseID = Convert.ToInt32(drpCourse.SelectedValue);
        //        objBEstudent.IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID]);
        //        objBEstudent.strCourseName = drpCourse.SelectedItem.Text.ToString();
        //        objBEstudent.strExamName = drpExam.SelectedItem.Text.ToString();

        //        if (btnOnDemand.SelectedToggleState.Value == "ON")
        //            objBEstudent.intOndemand = 1;
        //        else
        //            objBEstudent.intOndemand = 0;

        //        BECommon objBECommon = new BECommon();
        //        BCommon objBCommon = new BCommon();
        //        objBECommon.iTimeZoneID = Convert.ToInt32(Session["TimeZoneID"].ToString());
        //        objBCommon.BGetTimeDelay(objBECommon);
        //        objBEstudent.dtExam = DateTime.UtcNow.AddMinutes(objBECommon.IntResult);
        //        Session["Flowcheck"] = 1;
        //        Session["NonProctorExam"] = objBEstudent;
        //    }
        //    //Response.Redirect(BaseClass.EnumAppPage.STUDENT_SYSTEMREADINESS);
        //    Response.Redirect(HttpContext.Current.Request.Url.AbsoluteUri.Replace("https", "http").Replace("ScheduleAnExam.aspx", "Systemreadiness.aspx"));


        //}


        protected void btnTakeTest_Click(object sender, EventArgs e)
        {


            if (drpInstructor.SelectedValue.ToString() != "-1" && drpCourse.SelectedValue.ToString() != "-1" && drpExam.SelectedValue.ToString() != "-1")
            {
                this.SetExamFeeSettings(Convert.ToInt32(drpExam.SelectedValue), "EXAMID");
                BEStudent objBEStudent = new BEStudent();
                objBEStudent.IntExamID = Convert.ToInt32(drpExam.SelectedValue);
                objBEStudent.IntCourseID = Convert.ToInt32(drpCourse.SelectedValue);
                objBEStudent.IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID]);
                objBEStudent.strCourseName = drpCourse.SelectedItem.Text.ToString();
                objBEStudent.strExamName = drpExam.SelectedItem.Text.ToString();

                BECommon objBECommon = new BECommon();
                BCommon objBCommon = new BCommon();
                objBECommon.iTimeZoneID = Convert.ToInt32(Session["TimeZoneID"].ToString());
                objBCommon.BGetTimeDelay(objBECommon);
                objBEStudent.dtExam = DateTime.UtcNow.AddMinutes(objBECommon.IntResult);

                //unversity pay
                if (Session[EnumPayment.PaidBY_ExamFee].ToString() == EnumPayment.PaidBy_University)
                {
                    new BStudent().BStudent_AAScheduleExam(objBEStudent);
                    this.LogPayments(objBEStudent.IntTransID, objBEStudent.decExamFee + objBEStudent.PerHourFee, objBEStudent.decOnDemandFee, EnumPayment.ExamType_Scheduled);

                    try
                    {
                        BEMail objBEMail = new BEMail();
                        BMail objBMail = new BMail();
                        objBEMail.IntUserID = 0;
                        objBEMail.IntTransID = objBEStudent.IntTransID;
                        objBEMail.StrTemplateName = BaseClass.EnumEmails.StudentExamReceipt.ToString();
                        objBMail.BSendEmail(objBEMail);
                    }
                    catch (Exception )
                    {
                    }



                    Response.Redirect("PLConfirmation.aspx?TransID=" + AppSecurity.Encrypt(objBEStudent.IntTransID.ToString()) + "&Type=" + AppSecurity.Encrypt("0"));

                }
                //student pay
                else if (Session[EnumPayment.PaidBY_ExamFee].ToString() == EnumPayment.PaidBy_Student)
                {
                    Session["Isproctorless"] = 1;

                    new BStudent().BStudent_AAScheduleStudentPayExam(objBEStudent);
                    ProcessPayment_Schedule(objBEStudent);
                }



                //Session["Flowcheck"] = 1;
                //Session["NonProctorExam"] = objBEstudent;






            }
            //Response.Redirect(BaseClass.EnumAppPage.STUDENT_SYSTEMREADINESS);
            //Response.Redirect(HttpContext.Current.Request.Url.AbsoluteUri.Replace("https", "http").Replace("ScheduleAnExam.aspx", "Systemreadiness.aspx"));


        }
        #endregion


        protected void CheckMyProfile()
        {
            BEStudent objBEStudent = new BEStudent();
            BStudent objBStudent = new BStudent();
            objBEStudent.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID]);
            objBStudent.BValidateUploadandQuestions(objBEStudent);
            if (objBEStudent.DsResult != null && objBEStudent.DsResult.Tables.Count > 0 && objBEStudent.DsResult.Tables[0].Rows.Count > 0)
            {
                bool isExamikeyUser = Convert.ToBoolean(objBEStudent.DsResult.Tables[0].Rows[0]["IsExamiKeyUser"].ToString());

                if (Convert.ToInt32(objBEStudent.DsResult.Tables[0].Rows[0]["PhotoCheck"]) == 1 && Convert.ToInt32(objBEStudent.DsResult.Tables[0].Rows[0]["QuestionsCheck"]) == 1 && Convert.ToInt32(objBEStudent.DsResult.Tables[0].Rows[0]["TimeZoneCheck"]) == 1)
                {
                    if (isExamikeyUser)
                    {
                        if (Convert.ToInt32(objBEStudent.DsResult.Tables[0].Rows[0]["ExamiKEY"]) == 1)
                        {
                            tblContent.Visible = true;
                            trProfileMsg.Visible = false;
                            lblMyprofile.Text = string.Empty;
                        }
                        else
                        {
                            tblContent.Visible = false;
                            trProfileMsg.Visible = true;
                            lblMyprofile.Text = Resources.ResMessages.Student_MyProfileCheck;
                        }
                    }
                }
                else
                {
                    tblContent.Visible = false;
                    trProfileMsg.Visible = true;
                    lblMyprofile.Text = Resources.ResMessages.Student_MyProfileCheck;

                }

            }
            else
            {
                tblContent.Visible = false;
                trProfileMsg.Visible = true;
                lblMyprofile.Text = Resources.ResMessages.Student_MyProfileCheck;
            }
        }


        protected void AAReschedule(Int64 TransID)
        {
            int Result = 0;
            #region NonProctorFlow
            trNonProctor.Visible = false;
            trWithProctor.Visible = false;
            trOndemand.Visible = false;
            trMessage.Visible = true;
            trRescheduleOrCancel.Visible = false;
            lblMessage.Text = "<font color='Blue' size='5px'>" + "You will be authenticated, without a live proctor. Start by clicking the “Schedule” button and follow the instructions." + "</font>";
            Result = PLRescheduleexamvalidations(TransID);

            this.ShowExamRescheduleLExistsValidation(Result, TransID);

            #endregion


        }






        protected int PLRescheduleexamvalidations(Int64 TransID)
        {
            int intResult = 0;
            BStudent objBStudent = new BStudent();
            BEStudent objBEStudent = new BEStudent();
            BECommon objBECommon = new BECommon();
            BCommon objBCommon = new BCommon();
            objBECommon.iTimeZoneID = Convert.ToInt32(Session["TimeZoneID"].ToString());
            objBCommon.BGetTimeDelay(objBECommon);
            objBEStudent.IntTransID = TransID;
            //objBEStudent.IntTransID = Convert.ToInt32(AppSecurity.Decrypt(Request.QueryString["ExamID"].ToString()));

            objBEStudent.IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID]);
            objBEStudent.dtExam = DateTime.UtcNow.AddMinutes(objBECommon.IntResult);
            objBStudent.BValidateReschedulePLExam(objBEStudent);
            intResult = objBEStudent.IntResult;
            objBEStudent = null;
            objBStudent = null;
            return intResult;


        }


        protected void ShowExamRescheduleLExistsValidation(int Result, Int64 TransID)
        {

            if (Result == 0)
            {
                BEStudent objBEStudent = new BEStudent();
                trNonProctorReschedule.Visible = false;
                BECommon objBECommon = new BECommon();
                BCommon objBCommon = new BCommon();
                objBECommon.iTimeZoneID = Convert.ToInt32(Session["TimeZoneID"].ToString());
                objBCommon.BGetTimeDelay(objBECommon);
                objBEStudent.IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID]);
                objBEStudent.IntTransID = TransID;
                //objBEStudent.IntTransID = Convert.ToInt32(AppSecurity.Decrypt(Request.QueryString["ExamID"].ToString()));
                objBEStudent.dtExam = DateTime.UtcNow.AddMinutes(objBECommon.IntResult);
                new BStudent().BStudent_UpdateAAExamReschedule(objBEStudent);

                try
                {
                    BEMail objBEMail = new BEMail();
                    BMail objBMail = new BMail();
                    objBEMail.IntUserID = 0;
                    //objBEMail.IntTransID = Convert.ToInt32(AppSecurity.Decrypt(Request.QueryString["ExamID"].ToString()));
                    objBEMail.IntTransID = TransID;
                    objBEMail.StrTemplateName = BaseClass.EnumEmails.ReScheduleConfirmation.ToString();
                    objBMail.BSendEmail(objBEMail);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                //Response.Redirect("PLConfirmation.aspx?TransID=" + AppSecurity.Encrypt(objBEStudent.IntTransID.ToString()) + "&Type=" + AppSecurity.Encrypt("0"));
                //here we are adding for auto authentication too
                Response.Redirect("PLConfirmation.aspx?TransID=" + AppSecurity.Encrypt(objBEStudent.IntTransID.ToString()) + "&Type=" + AppSecurity.Encrypt("1"));


                //this.SetExamFeeSettings(Convert.ToInt32(AppSecurity.Decrypt(Request.QueryString["ExamID"].ToString())), "TRANSID");
                //BEStudent objBEStudent = new BEStudent();
                //objBEStudent.IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID]);
                //objBEStudent.IntTransID = Convert.ToInt32(AppSecurity.Decrypt(Request.QueryString["ExamID"].ToString()));
                //new BStudent().BStudent_AAGetExamDetails(objBEStudent);

                //if(objBEStudent.DtResult.Rows.Count>0)

                //{
                //     objBEStudent.IntExamID =Convert.ToInt32(objBEStudent.DtResult.Rows[0]["ExamID"]); 
                //     objBEStudent.IntCourseID =Convert.ToInt32(objBEStudent.DtResult.Rows[0]["CourseID"]); 
                //     objBEStudent.strCourseName = objBEStudent.DtResult.Rows[0]["CourseName"].ToString();
                //      objBEStudent.strExamName = objBEStudent.DtResult.Rows[0]["ExamName"].ToString();
                //}

                //BECommon objBECommon = new BECommon();
                //BCommon objBCommon = new BCommon();
                //objBECommon.iTimeZoneID = Convert.ToInt32(Session["TimeZoneID"].ToString());
                //objBCommon.BGetTimeDelay(objBECommon);
                //objBEStudent.dtExam = DateTime.UtcNow.AddMinutes(objBECommon.IntResult);

                //unversity pay
                //if (Session[EnumPayment.PaidBY_ExamFee].ToString() == EnumPayment.PaidBy_University)
                //{
                //    new BStudent().BStudent_AAScheduleExam(objBEStudent);
                //    this.LogPayments(objBEStudent.IntTransID, objBEStudent.decExamFee + objBEStudent.PerHourFee, objBEStudent.decOnDemandFee, EnumPayment.ExamType_Scheduled);
                //    Response.Redirect("PLConfirmation.aspx?TransID=" + AppSecurity.Encrypt(objBEStudent.IntTransID.ToString()) + "&Type=" + AppSecurity.Encrypt("0"));

                //}
                ////student pay
                //else if (Session[EnumPayment.PaidBY_ExamFee].ToString() == EnumPayment.PaidBy_Student)
                //{
                //    Session["Isproctorless"] = 1;

                //    new BStudent().BStudent_AAScheduleStudentPayExam(objBEStudent);
                //    ProcessPayment_Schedule(objBEStudent);
                //}


            }
            else if (Result == 2)
            {
                lblMessage.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + Resources.ResMessages.Student_AnAppointmentForthesame + " " + "Progress" + "." + Resources.ResMessages.Student_YouCantSchedule + "</font>";
                trMessage.Visible = true;
                trNonProctor.Visible = false;
                trNonProctorReschedule.Visible = true;

            }

            else if (Result == 3)
            {
                BEStudent obj = new BEStudent();
                obj.IntExamID = Convert.ToInt32(drpExam.SelectedValue);
                obj.IntTransID = 0;
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
                lblMessage.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + "You can take the exam between" + " " + StartDate + " and " + EndDate + "</font>";


                trMessage.Visible = true;
                trNonProctor.Visible = false;
                trNonProctorReschedule.Visible = true;

            }


        }

        protected void btnNonProctorReschedule_Click(object sender, EventArgs e)
        {
            

            if (Request.QueryString["ExamID"] == null)
            {
                if (hdTransactionID.Value.ToString().Length != 0)
                    Response.Redirect("ScheduleAnExam.aspx?ExamID=" + AppSecurity.Encrypt(hdTransactionID.Value.ToString()) + "&Type=Reschedule&ExamDate=" + AppSecurity.Encrypt(hdExamDate.Value.ToString().Replace("/", "EC").Trim()), false);
                else
                    Response.Redirect("ScheduleAnExam.aspx");
            }
            else
            {
                this.BindRescheduleValuesOnLoad();

            }



        }

        protected void btnNonProctorCancel_Click(object sender, EventArgs e)
        {
            Int64 transid;
            if (Request.QueryString["ExamID"] != null)
            {
                transid = Convert.ToInt64(AppSecurity.Decrypt(Request.QueryString["ExamID"].ToString()));
                DeleteAAAppointment(transid);

            }
            else
            {
                BEStudent objBEStudent = new BEStudent();
                BStudent objBStudent = new BStudent();
                objBEStudent.IntExamID = Convert.ToInt32(drpExam.SelectedValue);
                objBEStudent.IntCourseID = Convert.ToInt32(drpCourse.SelectedValue);
                objBEStudent.IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID]);
                objBEStudent.strCourseName = drpCourse.SelectedItem.Text.ToString();
                objBStudent.BGetTransID(objBEStudent);
                if (objBEStudent.IntTransID != 0)
                    DeleteAAAppointment(objBEStudent.IntTransID);
                else
                    Response.Redirect("MyExams.aspx", false);

            }
            //DeleteAAAppointment(Convert.ToInt32(AppSecurity.Decrypt(Request.QueryString["ExamID"].ToString())));
        }


        protected void BindAAReschduleExamDetails()
        {
            BEStudent objBEStudent = new BEStudent();
            BStudent objBStudent = new BStudent();
            objBEStudent.IntTransID = Convert.ToInt64(AppSecurity.Decrypt(Request.QueryString["ExamID"].ToString()));
            objBStudent.BGetExamValues(objBEStudent);
            trNonProctorReschedule.Visible = true;
            trRescheduleOrCancel.Visible = false;
            trNonProctor.Visible = false;
            trWithProctor.Visible = false;
            trMessage.Visible = true;
            lblInstructor.Text = objBEStudent.strUserName;
            lblCourse.Text = objBEStudent.strCourseName;
            lblExam.Text = objBEStudent.strExamName;
            if (objBEStudent.DtResult != null && objBEStudent.DtResult.Rows.Count > 0)
            {
                lblStartDate.Text = objBEStudent.DtResult.Rows[0]["ExamStartDate"].ToString() + "  " + "<b>-</b>";
                lblEndDate.Text = objBEStudent.DtResult.Rows[0]["ExamEndDate"].ToString();
                lblExamDuration.Text = objBEStudent.DtResult.Rows[0]["ExamDuration"].ToString() + " " + "Minutes";
                lblMessage.Text = "<font color='Blue' size='5px'>" + "Do you want to reschedule or cancel the existing appointment that is scheduled on  " + objBEStudent.DtResult.Rows[0]["ExamDate"].ToString() + "  " + "at" + "  " + objBEStudent.DtResult.Rows[0]["ExamTime"].ToString() + "?" + "</font>"; ;
            }
            drpInstructor.Visible = false;
            drpCourse.Visible = false;
            drpExam.Visible = false;
            lblInstructor.Visible = true;
            lblCourse.Visible = true;
            lblExam.Visible = true;
        }


        protected void DeleteAAAppointment(Int64 intTransID)
        {
            try
            {
                trMessage.Visible = true;
                lblMessage.Text = string.Empty;
                BEStudent objBEStudent = new BEStudent();
                objBEStudent.IntTransID = intTransID;
                objBEStudent.IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID]);
                BStudent objBStudent = new BStudent();
                objBStudent.BDeleteAAAppointment(objBEStudent);

                if (objBEStudent.DtResult.Rows.Count > 0 && objBEStudent.DtResult != null)
                {

                    if (Convert.ToInt32(objBEStudent.DtResult.Rows[0]["Result"]) != 1)
                    {
                        trMessage.Visible = true;
                        lblMessage.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + Resources.ResMessages.AppointmentDelete + "</font>";
                    }

                    else
                    {
                        try
                        {
                            BEMail objBEMail = new BEMail();
                            BMail objBMail = new BMail();
                            objBEMail.IntUserID = 0;
                            objBEMail.IntTransID = intTransID;
                            objBEMail.StrTemplateName = BaseClass.EnumEmails.ExamCancelConfirmation.ToString();
                            objBMail.BSendEmail(objBEMail);
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }

                        Response.Redirect("ExamCancelConfirmation.aspx?TransID=" + AppSecurity.Encrypt(intTransID.ToString()).ToString());
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

