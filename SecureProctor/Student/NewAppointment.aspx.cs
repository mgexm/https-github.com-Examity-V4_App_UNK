using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessEntities;
using BLL;

namespace SecureProctor.Student
{
    public partial class NewAppointment : System.Web.UI.Page
    {
        #region PageLoad
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["SCHEDULEDETAILS"] != null)
                {
                    string[] str = Session["SCHEDULEDETAILS"].ToString().Split('^');
                    this.GetExamDetails(Convert.ToInt32(AppSecurity.Decrypt(str[0].ToString())),str[1].ToString());
                }
            }
        }
        #endregion
        #region GetExamDetails
        protected void GetExamDetails(int ExamID,string Slot)
        {
            try
            {
                BEStudent objBEStudent = new BEStudent();
                BStudent objBStudent = new BStudent();
                objBEStudent.IntFlag = 1;
                objBEStudent.IntExamID = ExamID;
                objBStudent.BGetCourseDetailsByExamID(objBEStudent);
                if (objBEStudent.DtResult != null)
                {
                    lblCourseName.Text = objBEStudent.DtResult.Rows[0]["CourseName"].ToString() + " [" + objBEStudent.DtResult.Rows[0]["CourseID"].ToString() + "]";
                    lblExamName.Text = objBEStudent.DtResult.Rows[0]["ExamName"].ToString();
                    lblDuration.Text = objBEStudent.DtResult.Rows[0]["ExamDuration"].ToString() + " " + "Minutes"; ;
                    lblSlot.Text = Slot;
                }
                else
                {
                    
                }
            }
            catch
            {
            }
        }
        #endregion
        #region ScheduleExam
        protected void btnSchedule_Click(object sender, EventArgs e)
        {
            //#region NewAppointment
            //Appointment aptToInsert = GetBasicAppointmentFromForm();
            //BEStudent objBEStudent = new BEStudent()
            //{
            //    IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID]),
            //    IntCourseID = int.Parse(drpCourse.SelectedValue),
            //    IntExamID = int.Parse(drpExam.SelectedValue),
            //    dtExam = aptToInsert.Start
            //};

            //if (Session[EnumPayment.PaidBY_ExamFee] != null && Session[EnumPayment.PaidBY_OndeMand] != null)
            //{
            //    if (btnOnDemand.SelectedToggleState.Value == "ON")
            //    {
            //        DateTime Appointmentdate = objBEStudent.dtExam;

            //        if (Session[EnumPayment.PaidBY_ExamFee].ToString() == EnumPayment.PaidBy_University && Session[EnumPayment.PaidBY_ExamFee].ToString() == EnumPayment.PaidBy_University)
            //        {
            //            objBEStudent.intOndemand = 1;
            //            new BStudent().BStudent_ScheduleExam(objBEStudent);
            //            this.ShowAlert_ScheduleExam_Create(objBEStudent);
            //        }
            //        else if (Session[EnumPayment.PaidBY_ExamFee].ToString() == EnumPayment.PaidBy_University && Session[EnumPayment.PaidBY_ExamFee].ToString() == EnumPayment.PaidBy_Student)
            //        {
            //            objBEStudent.intOndemand = 1;
            //            new BStudent().BStudent_ValidateExam(objBEStudent);
            //            if (objBEStudent.IntResult == 4)
            //                this.ProcessPayment_Schedule(objBEStudent);
            //            else
            //                this.ShowAlert_ScheduleExam_Validate(objBEStudent.IntResult);
            //        }
            //        else if (Session[EnumPayment.PaidBY_ExamFee].ToString() == EnumPayment.PaidBy_Student && Session[EnumPayment.PaidBY_ExamFee].ToString() == EnumPayment.PaidBy_University)
            //        {
            //            objBEStudent.intOndemand = 1;
            //            new BStudent().BStudent_ValidateExam(objBEStudent);
            //            if (objBEStudent.IntResult == 4)
            //                this.ProcessPayment_Schedule(objBEStudent);
            //            else
            //                this.ShowAlert_ScheduleExam_Validate(objBEStudent.IntResult);
            //        }
            //        else if (Session[EnumPayment.PaidBY_ExamFee].ToString() == EnumPayment.PaidBy_Student && Session[EnumPayment.PaidBY_ExamFee].ToString() == EnumPayment.PaidBy_Student)
            //        {
            //            objBEStudent.intOndemand = 1;
            //            new BStudent().BStudent_ValidateExam(objBEStudent);
            //            if (objBEStudent.IntResult == 4)
            //                this.ProcessPayment_Schedule(objBEStudent);
            //            else
            //                this.ShowAlert_ScheduleExam_Validate(objBEStudent.IntResult);
            //        }
            //    }
            //    else if (btnOnDemand.SelectedToggleState.Value == "OFF")
            //    {
            //        if (Session[EnumPayment.PaidBY_ExamFee].ToString() == EnumPayment.PaidBy_University)
            //        {
            //            objBEStudent.intOndemand = 0;
            //            new BStudent().BStudent_ScheduleExam(objBEStudent);
            //            this.ShowAlert_ScheduleExam_Create(objBEStudent);
            //        }
            //        else if (Session[EnumPayment.PaidBY_ExamFee].ToString() == EnumPayment.PaidBy_Student)
            //        {
            //            objBEStudent.intOndemand = 0;
            //            new BStudent().BStudent_ValidateExam(objBEStudent);
            //            if (objBEStudent.IntResult == 4)
            //                this.ProcessPayment_Schedule(objBEStudent);
            //            else
            //                this.ShowAlert_ScheduleExam_Validate(objBEStudent.IntResult);
            //        }
            //    }
            //}
            //else
            //{
            //    new BStudent().BStudent_ScheduleExam(objBEStudent);
            //    this.ShowAlert_ScheduleExam_Create(objBEStudent);
            //}
            //#endregion
        }
        #endregion
    }
}