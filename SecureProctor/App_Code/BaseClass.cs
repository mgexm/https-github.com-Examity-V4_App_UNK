using System;
using BusinessEntities;
using BLL;

namespace SecureProctor
{
    public class BaseClass : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (Session[BaseClass.EnumPageSessions.USERID] == null || Session[BaseClass.EnumPageSessions.USERID].ToString() == "")
                //Response.Redirect("../AdminLogin.aspx");    //?ReturnUrl=" + Request.Url.AbsolutePath.ToString());
                Response.Redirect("../Logout.aspx?id=" + "0");
            //if (Session[BaseClass.EnumPageSessions.THEMENAME] != null)
            //    Page.Theme = Session[BaseClass.EnumPageSessions.THEMENAME].ToString();
            //else
            //    Page.Theme = BaseClass.EnumPageSessions.THEME_STANDARD;
        }

        public struct EnumAppUserRoles
        {
            public const int ExamProvidor = 3;
            public const int Auditor = 4;
            public const int Proctor = 5;
            public const int Student = 6;
        }
        public struct EnumPageSessions
        {
            public const string THEMENAME = "THEMENAME";
            public const string THEME_STANDARD = "Standard";
            public const string EXAMID = "ExamID";

            public const string StudentID = "StudentID";
            public const string COURSEID = "CourseID";
            public const string DATATABLE = "DataTable";
            public const string CURRENTPAGE = "CurrentPage";
            public const string SORTTYPE = "SortType";
            public const string SORTCOLUMN = "SortColumn";
            public const string DATASET = "DataSet";
            public const string USERID = "UserID";
            public const string LOGINTYPE = "LoginType";
            public const string CurrentPage = "CurrentPage";
            public const string SortType = "SortType";
            public const string SortColumn = "SortColumn";
            public const string SortTypeDsc = "SortTypeDsc";
            public const string ScheduleID = "ScheduleID";
            public const string StudentList = "StudentList";
            public const string TransID = "TransID";
        }

        public struct EnumPageTitles
        {
            public const string Auditor_EditComments = "Edit Comments";
            public const string Student_UploadFile = "Student Upload";
            public const string PROCTOR_ADD_PROCTOR = "Add Proctor";
            public const string Proctor_ProctorReports = "Proctor Reports";
            public const string Auditor_AuditorREPORTS = "Auditor Reports";
            public const string Admin_AdminREPORTS = "Admin Reports";
            public const string ADMIN_DELETESTUDENTEXAMENROLLMENT = "Delete Enrollment";
            public const string ADMIN_COURSEDETAILS_ADD_COURSE = "Add Course";
            public const string ADMIN_EDITSTUDENTEXAMENROLLMENT = "Edit Enroll Student";
            public const string ADMIN_EDITCOURSE_EDITCOURSE = "Edit Course";
            public const string ADMIN_RESETSTUDENT = "Reset Student";
            public const string ADMIN_ENROLLSTUDENT = "Enroll Student";
            public const string ADMIN_DELETESTUDENT = "Delete Student";
            public const string ADMIN_EDITSTUDENT = "Edit Student";
            public const string ADMIN_STUDENT = "Student";
            public const string ADMIN_COURSEDETAILS_EDIT_EXAM = "Edit Exam";
            public const string ADMIN_COURSEDETAILS_VIEW_EXAM = "View Exam";
            public const string ADMIN_COURSEDETAILS_DELETE_EXAM = "Delete Exam";
            public const string ADMIN_DELETECOURSE_DELETECOURSE = "Delete Course";
            public const string EXAMPROVIDER_DELETESTUDENTEXAMENROLLMENT = "Delete Enrollment";
            public const string EXAMPROVIDER_ENROLLSTUDENT = "Enroll Student";
            public const string EXAMPROVIDER_ADDSTUDENT = "Add Student";
            public const string EXAMPROVIDER_DELETESTUDENT = "Delete Student";
            public const string EXAMPROVIDER_EDITSTUDENT = "Edit Student";
            public const string Deletedeletedetails = "Deletedeletedetails";
            public const string STUDENT_SYSTEMREADINESS = "System readiness";
            public const string Viewstudentdetails = "Viewstudentdetails";
            public const string Editstudentdetails = "Editstudentdetails";
            public const string ADMIN_VIEWCOURSE = "Courses/Exams";
            public const string ADMIN_ENTOLLSTUDENT = "ENROLLSTUDENT";
            public const string Admin_STUDENTREGISTRATION = "STUDENT REGISTRATION";
            public const string ADMIN_REPORTS = "Reports";
            public const string AUDITOR_StudentLookUp = "Student Look Up";
            public const string MYPROFILE = "My Profile";
            public const string ViewExamDetails = "View Exam Details";
            public const string ADMIN_EXAMPROVIDERREPORTS = "Admin Reports";
            public const string ExamDetails = "Exam Details";
            //public const string APPNAME = "Secure Proctor :: ";
            public const string APPNAME = "Examity :: ";
            public const string LOGIN = "Login";
            public const string HOME = "Home";
            public const string MYEXAMS = "My Exams";
            public const string RESCHEDULE_CANCEL = @"Reschedule/Cancel";
            public const string UPLOADFILES = "Upload";
            public const string STUDENT_LOGIN = "Student Login";
            public const string PROCTOR_LOGIN = "Proctor Login";
            public const string AUDITOR_LOGIN = "Auditor Login";
            public const string PROVIDER_LOGIN = "Exam Provider Login";
            public const string FORGOTPASSWORD = "Forgot Password";
            public const string STUDENT_REGISTRATION = "Student Registration";
            public const string STUDENT_SCHEDULE = "Schedule Exam";
            public const string STUDENT_SCHEDULEDetails = "Scheduled Exam Details";
            public const string STUDENT_RESCHEDULE = "Reschedule Exam";
            public const string STUDENT_STARTEXAM = "Start Exam";
            public const string STUDENT_VALIDATESTUDENT = "Validate Student";
            public const string STUDENT_PREREQUISITES = "Pre-Requisites";
            public const string STUDENT_VALIDATEIDENTITY = "Identity Verification";
            public const string STUDENT_EXAMCONFIGURATION = "Exam Configuration";
            public const string STUDENT_CURRENTEXAM = "Start Exam";
            public const string PROCTOR_EXAMSTATUS = "Exam Status";
            public const string PROCTOR_CONFIRMATION = "Proctor Confirmation";
            public const string CHANGEPASSWORD = "Change Password";
            public const string STUDENT_REPORTS = "Reports";
            public const string PROCTOR_VALIDATESTUDENTIDENTITY = "Validate Student Identity";
            public const string PROCTOR_REPORTS = "Reports";
            public const string AUDITOR_INBOX = "Inbox";
            public const string AUDITOR_PROCESSEDEXAMREQUESTS = "Processed Exam Request";
            public const string AUDITOR_REPORTS = "Auditor Reports";
            public const string AUDITOR_CONFIRMATION = "Auditor Confirmation";
            public const string EXAMPROVIDER_EXAMDETAILS = "Exam Details";
            public const string EXAMPROVIDER_COURSEDETAILS = "Courses/Exams";
            public const string EXAMPROVIDER_EXAMPROVIDERREPORTS = "Instructor Reports";
            public const string EXAMPROVIDER_EXAMLOOKUP = "Exam Lookup";
            public const string EXAMPROVIDER_STUDENTREGISTRATION = "Student Registration";
            public const string EXAMPROVIDER_VIEW_STUDENT_EXAM = "View Student Exam";
            public const string EXAMPROVIDER_ENTOLLSTUDENT = "Enroll student";
            public const string EXAMPROVIDER_VIEWSTUDENT = "View student";
            public const string EXAMPROVIDER_COURSEDETAILS_ADD_COURSE = "Add Course";
            public const string EXAMPROVIDER_EDITCOURSE_EDITCOURSE = "Edit Course";
            public const string EXAMPROVIDER_DELETECOURSE_DELETECOURSE = "Delete Course";
            public const string EXAMPROVIDER_COURSEDETAILS_ADD_EXAM = "Add Exam";
            public const string EXAMPROVIDER_COURSEDETAILS_VIEW_EXAM = "View Exam";
            public const string EXAMPROVIDER_COURSEDETAILS_DELETE_EXAM = "Delete Exam";
            public const string EXAMPROVIDER_COURSEDETAILS_EDIT_EXAM = "Edit Exam";
            public const string CHANGETIMEZONE = "Change Timezone";
            public const string AUTOPROC_INBOX = "Auto Proctor Inbox";
            //--------------------------------For CourseAdmin ------------------
            public const string COURSEADMIN_EXAMDETAILS = "Exam Details";
            public const string COURSEADMIN_COURSEDETAILS = "Courses/Exams";
            public const string COURSEADMIN_EXAMPROVIDERREPORTS = "Instructor Reports";
            public const string COURSEADMIN_EXAMLOOKUP = "Exam Lookup";
            public const string COURSEADMIN_STUDENTREGISTRATION = "Student Registration";
            public const string COURSEADMIN_VIEW_STUDENT_EXAM = "View Student Exam";
            public const string COURSEADMIN_ENTOLLSTUDENT = "Enroll student";
            public const string COURSEADMIN_VIEWSTUDENT = "View student";
            public const string COURSEADMIN_COURSEDETAILS_ADD_COURSE = "Add Course";
            public const string COURSEADMIN_EDITCOURSE_EDITCOURSE = "Edit Course";
            public const string COURSEADMIN_DELETECOURSE_DELETECOURSE = "Delete Course";
            public const string COURSEADMIN_COURSEDETAILS_ADD_EXAM = "Add Exam";
            public const string COURSEADMIN_COURSEDETAILS_VIEW_EXAM = "View Exam";
            public const string COURSEADMIN_COURSEDETAILS_DELETE_EXAM = "Delete Exam";
            public const string COURSEADMIN_COURSEDETAILS_EDIT_EXAM = "Edit Exam";
            public const string COURSEADMIN_ENROLLSTUDENT = "Enroll Student";
            public const string COURSEADMIN_ADDSTUDENT = "Add Student";
            public const string COURSEADMIN_DELETESTUDENT = "Delete Student";
            public const string COURSEADMIN_EDITSTUDENT = "Edit Student";
            public const string COURSEADMIN_COURSESTUDENTS = "Courses/Students";
            //.....................................courseAdmin end......................

        }

        public struct EnumAppPage
        {

            public const string ERRORMESSAGE = "../Errors/SSOErrorPage.aspx?ErrorId=" + "404";
            public const string COMMON_CHANGETIMEZONE = "~/ChangeTimeZone.aspx";
            //public const string COMMON_LOGOUT = "~/AdminLogin.aspx";
             public const string COMMON_LOGOUT = "~/Logout.aspx?id=" + "1";
            public const string STUDENT_TESTDRIVE = "Test Drive";
            public const string STUDENT_HOME = "~/Student/Home.aspx";
            public const string STUDENT_REGISTRATION = "~/Student/Registration.aspx";
            public const string STUDENT_MYEXAMS = "~/Student/MyExams.aspx";
            //public const string STUDENT_SCHEDULE = "~/Student/ScheduleStep1.aspx";
            public const string STUDENT_SCHEDULE = "~/Student/ScheduleAnExam.aspx";
            public const string STUDENT_RESCHEDULE = "~/Student/RescheduleExam.aspx";
            public const string STUDENT_STARTEXAM = "~/Student/StartAnExam.aspx";
            public const string STUDENT_MYPROFILE = "~/Student/MyProfile.aspx";
            public const string STUDENT_REPORTS = "~/Student/Reports.aspx";
            public const string STUDENT_ONDEMANDSCHEDULE = "~/Student/NewPayment.aspx";
            public const string STUDENT_EamTools = "~/Student/ExamTools.aspx";
            public const string STUDENT_UPLOADFILES = "~/Student/ExamUploadFiles.aspx";
            public const string STUDENT_SYSTEMREADINESS = "~/Student/systemreadiness.aspx";
            public const string PROCTOR_HOME = "~/proctor/Home.aspx";
            public const string PROCTOR_VALIDATE = "~/proctor/ValidateStudentIdentity.aspx";
            public const string PROCTOR_STUDENTLOOKUP = "~/proctor/ExamStatus.aspx";
            public const string PROCTOR_REPORTS = "~/proctor/Reports.aspx";
            public const string PROCTOR_MYPROFILE = "~/proctor/MyProfile.aspx";
            public const string PROCTOR_STUDENTS = "~/proctor/Students.aspx";
            public const string PROCTOR_AUTOVALIDATE = "~/proctor/AutoProctorInbox.aspx";
            public const string PROCTOR_AUTOPROCTORINBOX = "~/proctor/AutoProctorInbox.aspx";

            public const string AUDITOR_HOME = "~/Auditor/Home.aspx";
            public const string AUDITOR_INBOX = "~/Auditor/Inbox.aspx";
            public const string AUDITOR_PROCESSEDEXAMREQUESTS = "~/Auditor/ProcessedExamRequests.aspx";
            public const string AUDITOR_REPORTS = "~/Auditor/Reports.aspx";
            public const string AUDITOR_STUDENTLOOKUP = "~/Auditor/StudentLookup.aspx";
            public const string AUDITOR_MYPROFILE = "~/Auditor/MyProfile.aspx";

            public const string PROVIDER_HOME = "~/Provider/Home.aspx";
            public const string PROVIDER_EXAMDETAILS = "~/Provider/ExamDetails.aspx";
            public const string PROVIDER_COURSEDETAILS = "~/Provider/CourseDetails.aspx";
            public const string PROVIDER_EXAMSTATUS = "~/Provider/ExamStatus.aspx";
            // public const string PROVIDER_ENROLLSTUDENT = "~/Provider/EnrollStudent.aspx";
            public const string PROVIDER_ENROLLSTUDENT = "~/Provider/Students.aspx";
            public const string PROVIDER_COURSESTUDENTS = "~/Provider/CourseStudents.aspx";
            public const string PROVIDER_VIEWSTUDENT = "~/Provider/Students.aspx";
            public const string PROVIDER_MYPROFILE = "~/Provider/MyProfile.aspx";
            public const string PROVIDER_REPORTS = "~/Provider/Reports.aspx";

            public const string LOGIN = "~/Login.aspx";
            public const string ChangePassword = "~/ChangePassword.aspx";
            public const string FORGOTPASSWORD = "~/ForgotPassword.aspx";
            public const string CHANGEPASSWORD = "~/ChangePassword.aspx";

            public const string ADMIN_STUDENTS = "~/Admin//Students.aspx";
            public const string ADMIN_HOME = "~/Admin//Home.aspx";
            public const string ADMIN_VIEWSTUDENT = "~/Admin//ViewStudent.aspx";
            public const string ADMIN_VIEWCOURSE = "~/Admin//CourseDetails.aspx";
            //public const string ADMIN_VIEWCOURSE = "~/Admin//CourseExamDetails.aspx";
            public const string ADMIN_MYPROFILE = "~/Admin//MyProfile.aspx";
            // public const string ADMIN_ENROLLSTUDENT = "~/Admin//AdminEnrollStudent.aspx";
            public const string ADMIN_ENROLLSTUDENT = "~/Admin//ViewStudent.aspx";
            public const string ADMIN_COURSESTUDENTS = "~/Admin//CourseStudents.aspx";
            public const string ADMIN_EXAMSTATUS = "~/Admin//AdminExamStatus.aspx";
            public const string ADMIN_EXAMDETAILS = "~/Admin/ExamDetails.aspx";
            public const string ADMIN_REPORTS = "~/Admin/AdminReports.aspx";
            public const string ADMIN_INSTRUCTOR = "~/Admin/AdminInstructor.aspx";
            //---------------For COURSEADMIN.........
            public const string COURSEADMIN_HOME = "~/CourseAdmin/Home.aspx";
            public const string COURSEADMIN_EXAMDETAILS = "~/CourseAdmin/ExamDetails.aspx";
            public const string COURSEADMIN_COURSEDETAILS = "~/CourseAdmin/CourseDetails.aspx";
            public const string COURSEADMIN_EXAMSTATUS = "~/CourseAdmin/ExamStatus.aspx";
            public const string COURSEADMIN_ENROLLSTUDENT = "~/CourseAdmin/Students.aspx";
            public const string COURSEADMIN_VIEWSTUDENT = "~/CourseAdmin/Students.aspx";
            public const string COURSEADMIN_MYPROFILE = "~/CourseAdmin/MyProfile.aspx";
            public const string COURSEADMIN_REPORTS = "~/CourseAdmin/Reports.aspx";
            public const string COURSEADMIN_COURSESTUDENTS = "~/CourseAdmin/CourseStudents.aspx";
            //..................CourseAdmin end..................
        }

        public struct EnumTransactionStatus
        {
            public const string Exam_Scheduled = "1";
            public const string Exam_In_progress = "2";
            public const string Exam_Completed = "3";
            public const string Exam_Cancelled = "4";
            public const string Approved_By_Proctor = "5";
            public const string Approved_By_Auditor = "6";
            public const string Rejected_By_Auditor = "7";
            public const string Video_In_Progress = "8";
            public const string Video_Completed = "9";
        }

        public struct EnumEmails
        {
            public const string ForgotPassword = "ForgotPassword";
            public const string ChangePassword = "ChangePassword";
            public const string StudentExamReceipt = "StudentExamReceipt";
            public const string ExamConfirmationProctorFYI = "ExamConfirmationProctorFYI";
            public const string StudentRegistrationConfirmation = "StudentRegistrationConfirmation";
            public const string ExamCancelConfirmation = "ExamCancelConfirmation";
            public const string ReScheduleConfirmation = "ReScheduleConfirmation";
            public const string ReScheduleConfirmationProctorFYI = "ReScheduleConfirmationProctorFYI";
            public const string ExamCompletedConfirmation = "ExamCompletedConfirmation";
            public const string ExamApprovalConfirmation = "ExamApprovalConfirmation";
            // public const string ExamRejectConfirmationbyAuditor = "ExamRejectConfirmationbyAuditor ";
            public const string ExamApprovedbyAuditor = "ExamApprovalConfirmationbyAuditor";
            public const string ExamRejectedbyAuditor = "ExamRejectConfirmationbyAuditor";
            public const string ExamRejectedbyAuditorFYI = "ExamRejectedbyAuditorFYI";
            public const string ExamApprovedbyAuditorFYI = "ExamApprovedbyAuditorFYI";


        }


        public struct EnumPayment
        {
            public const string PaidBY_ExamFee = "ExamFee";
            public const string PaidBY_OndeMand = "OnDemand";

            public const string PaidBy_University = "1";
            public const string PaidBy_Student = "2";

            public const string ExamType_Scheduled = "Scheduled";
            public const string ExamType_Rescheduled = "Rescheduled";

        }

        public string isLockDownBrowserFeatured()
        {
            BECommon objBECommon = new BECommon();
            BCommon objBCommon = new BCommon();

            objBCommon.BGetClientDetails(objBECommon);

            return objBECommon.DsResult.Tables[0].Rows[0]["LockdownBrowser"].ToString();
        }

        public string isExamLevelFee()
        {
            BECommon objBECommon = new BECommon();
            BCommon objBCommon = new BCommon();

            objBCommon.BGetClientDetails(objBECommon);

            if (objBECommon.DsResult.Tables[0].Rows[0]["ExamLevelSetting_UserEdit"] != null)
                return objBECommon.DsResult.Tables[0].Rows[0]["ExamLevelSetting_UserEdit"].ToString();
            else
                return "False";
        }
    }
}