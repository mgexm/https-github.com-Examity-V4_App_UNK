using System;

namespace DAL
{
    public class StoredProcedures
    {

        public const string USP_USER_ValidateUser = "USP_Login_ValidateUser";
        public const string USP_Common_GetProviders = "USP_Common_GetProviders";
        public const string USP_GetClientDetails = "USP_GetClientDetails";

        //Email Stored Procedures
        public const string USP_SendEmail = "USP_SendEmail";

        //Global Declarations
        internal const int Precision = 4;
        internal const int Scale = 2;

        //common
        public const string USP_provider_EnrollStudentCourse = "USP_provider_EnrollStudentCourse";
        public const string USP_Provider_GetStudentsDetails = "USP_Provider_GetStudentsDetails";
        public const string USP_CourseAdmin_GetStudentsDetails = "USP_CourseAdmin_GetStudentsDetails";
        public const string USP_CourseAdmin_EnrollStudentCourse = "USP_CourseAdmin_EnrollStudentCourse";
        public const string USP_Common_GetLMSSettings = "USP_Common_GetLMSSettings";
        public const string USP_Common_UpdateTimeZone = "USP_Common_UpdateTimeZone";
        public const string USP_Auditor_GetProviderDetails = "USP_Auditor_GetProviderDetails";
        public const string USP_Common_GetTimeZoneList = "USP_Common_GetTimeZoneList";
        public const string USP_Common_GetProfileDetails = "USP_Common_GetProfileDetails";
        public const string USP_Common_getStudentExamDetails = "USP_Common_getStudentExamDetails";
        public const string USP_Common_GetStudentCourseDetails = "USP_Common_GetStudentCourseDetails";
        public const string USP_Common_ViewStudentDetails = "USP_Common_ViewStudentDetails";
        public const string USP_Common_AddComments = "USP_Common_AddComments";
        public const string USP_Common_GetExamTools = "USP_Common_GetExamTools";
        public const string USP_Common_GetSelectedStudentDetails = "USP_Common_GetSelectedStudentDetails";
        public const string USP_Common_GetNotesAndRules = "USP_Common_GetNotesAndRules";
        public const string USP_Common_GetSeletedNotesAndRules = "USP_Common_GetSeletedNotesAndRules";
        public const string USP_Common_ExamRules_GetStandardAndAdditionalRules = "USP_ExamRules_GetStandardAndAdditionalRules";
        public const string USP_Common_ExamRules_GetSpecialAdditionalRules = "USP_ExamRules_GetSpecialAdditionalRules";//08nov2016
        public const string USP_Common_ExamRules_GetExamRules = "USP_ExamRules_GetExamRules";
        public const string USP_Common_GetStudentUploadFileStatus = "USP_Common_GetStudentUploadFileStatus";
        public const string USP_Common_getExamFileUploadStatus = "USP_Common_getExamFileUploadStatus";
        public const string USP_Common_GetSSOStatus = "USP_Common_GetSSOStatus";
        public const string USP_Common_GetPorviderTimeDelay = "USP_Common_GetPorviderTimeDelay";
        public const string USP_CanvasLogin = "USP_CanvasLogin";
        public const string USP_LMSLogin = "USP_LMSLogin";
        public const string USP_Common_ValidateTimeZone = "USP_Common_ValidateTimeZone";
        public const string USP_Common_GetAdditionalFeeperhour = "USP_Common_GetAdditionalFeeperhour";
        public const string USP_Common_getInstructors = "USP_Common_getInstructors";
        public const string USP_Admin_GETBILLINGDETAILS = "USP_Admin_GETBILLINGDETAILS";
        public const string USP_Proctor_GetAutoProctorProviderDetails = "USP_Proctor_GetAutoProctorProviderDetails";

        public const string USP_Admin_PaymentMode = "USP_Admin_PaymentMode";
        public const string USP_Admin_GetClientContactDetails = "USP_Admin_GetClientContactDetails";
        //Start
        public const string SearchStudentDetails = "USP_Proctor_SearchStudentDetails";
        public const string USP_STUDENT_UpdateTimeZone = "USP_STUDENT_UpdateTimeZone";
        public const string USP_STUDENT_UpdateUserLoginFlag = "USP_Login_UpdateUserLoginFlag";

        public const string USP_USER_ForgotPassword = "USP_UserForgotPassword";
        public const string USP_USER_ChangePassword = "USP_USER_ChangePassword";
       // public const string spPasswordExists = "spPasswordExists";

        public const string UPS_STUDENT_GetStudentTransactions = "USP_GetStudentExams";
        public const string USP_STUDENT_GetGenderList = "USP_STUDENT_GETGENDERLIST";
        public const string USP_STUDENT_GetSecurityQuestions = "USP_STUDENT_GetAllSecurityQuestions";

        public const string USP_STUDENT_GetCourseDetails = "USP_STUDENT_GETCOURSEDETAILS";
        public const string USP_STUDENT_GetExamScheduledDate = "USP_STUDENT_GetExamScheduledDate";

        public const string USP_STUDENT_StudentRegistartion = "USP_StudentRegistration";

        public const string USP_STUDENT_GetUserName = "USP_STUDENT_GetUserName";
        public const string USP_Student_CheckExamBoundaries = "USP_Student_CheckExamBoundaries";
        public const string USP_Student_CheckExamBoundariesReschedule = "USP_Student_CheckExamBoundariesReschedule";
        public const string USP_AUDITOR_GetStudentCourseDetails = "USP_AUDITOR_GetStudentCourseDetails";



        public const string USP_Student_GetRules = "USP_Student_GetRules";
        public const string USP_STUDENT_GetExamStartEndDates = "USP_STUDENT_GetExamStartEndDates";
        public const string USP_Student_DeleteUploadedFile = "USP_Student_DeleteUploadedFile";
        public const string USP_Student_CheckExamStartTime = "USP_Student_CheckExamStartTime";
        public const string USP_Student_MyProfile_ValidatePictureandSecurityQuestions = "USP_Student_MyProfile_ValidatePictureandSecurityQuestions";
        //End




        public const string USP_USER_CHANGEPASSWORD = "USP_User_ChangePassword";
        public const string USP_USER_FORGOTPASSWORD = "USP_User_ForgotPassword";

        public const string USP_Student_GetAllCourses = "USP_Student_GetAllCourses";
        public const string USP_Student_GetAllCourses_Accessibility = "USP_Student_GetAllCourses_Accessibility";
        public const string USP_Student_GetStudentCourses = "USP_Student_GetStudentCourses";
        public const string USP_Student_GetExams = "USP_Student_GetExams";
        public const string USP_Student_GetExamSlots = "USP_Student_GetExamSlots";
        public const string USP_USER_UserForgotPassword = "USP_UserForgotPassword";

        //student

        public const string USP_GetStudentUploadFiles = "USP_GetStudentUploadFiles";

        public const string USP_STUDENT_GetTimeZone = "USP_STUDENT_GetTimeZone";
        public const string USP_Student_UpdateSecurityQuestions = "USP_Student_UpdateSecurityQuestions";

        public const string USP_Student_getSelectedSecurityQuestion = "USP_Student_getSelectedSecurityQuestion";

        public const string USP_Student_UpdatePhotoIdentity = "USP_Student_UpdatePhotoIdentity";

        public const string USP_STUDENT_DeleteAppointment = "USP_STUDENT_DeleteAppointment";

        public const string USP_Student_StudentRescheduleExam = "USP_Student_RescheduleExam";
        public const string USP_Student_SaveUploadFiles = "USP_Student_SaveUploadFiles";

        public const string USP_ReScheduleExam = "USP_ReScheduleExam";
        public const string USP_Student_GetExamLink = "USP_Student_GetExamLink";

        public const string USP_OpenTok_SaveSession = "USP_OpenTok_SaveSession";
        public const string USP_OpenTok_GetSession = "USP_OpenTok_GetSession";
        public const string USP_OpenTok_SaveArchiveID = "USP_OpenTok_SaveArchiveID";
        public const string USP_OpenTok_GetArchiveID = "USP_OpenTok_GetArchiveID";


        public const string USP_Proctor_ValidateStudentIdentity = "USP_Proctor_ValidateStudentIdentity";



        public const string USP_Student_Start_scheduleExam = "USP_Student_Start_scheduleExam";

        public const string USP_CancelExam = "USP_CancelExam";

        public const string USP_GetSecurityQeustionsAndAsnwers = "USP_GetSecurityQeustionsAndAsnwers";

        public const string USP_ValidateStudentSecurityQuestions = "USP_ValidateStudentSecurityQuestions";
        public const string USP_RandomSecurityQuestionsValidation = "USP_RandomSecurityQuestionsValidation";

        public const string USP_ScheduleExam = "USP_ScheduleExam";

        public const string USP_Student_getPhotoIdentity = "USP_Student_getPhotoIdentity";

        public const string USP_Service_GetExamDetails = "USP_Service_GetExamDetails";

        public const string USP_Student_UpdateExamStatus = "USP_Student_UpdateExamStatus";
        public const string USP_GetProviderCourses = "USP_GetProviderCourses";
        public const string USP_GetIdentityValidation = "USP_GetIdentityValidation";
        public const string USP_Student_GetExamSessionID = "USP_GetExamSessionID";
        public const string USP_Student_GetExamsForCourse = "USP_Student_GetExamsForCourse";
        public const string USP_Student_GetExamsForCourse_Accessibility = "USP_Student_GetExamsForCourse_Accessibility";
        public const string USP_GetExamDetailsByTransID = "USP_GetExamDetailsByTransID";

        // new schedular sps

        /*  EXAM FEE CALCULATION ALGORITHMS : INTERNAL SP'S         
            USP_Student_Algorithm_Schedule_ExamFee
            USP_Student_Algorithm_Schedule_OnDemandFee
            USP_Student_Reschedule_ExamFeeCalc
            USP_Student_Algorithm_Schedule_TotalFee         
         */

        public const string USP_Student_USP_GetExamFeeSettingsByExamID = "USP_Student_USP_GetExamFeeSettingsByExamID";
        public const string USP_Student_USP_GetExamFeeSettingsByTransID = "USP_Student_USP_GetExamFeeSettingsByTransID";

        public const string USP_Student_ScheduleExam = "USP_Student_ScheduleExam";//Payment Alg Calling SP
        public const string USP_Student_ReScheduleExam = "USP_Student_ExamReschedule";//Payment Alg Calling SP
        public const string USP_Student_ScheduleExam_Validate = "USP_Student_ScheduleExam_Validate";//Payment Alg Calling SP       
        public const string USP_Student_ExamReschedule_Validate = "USP_Student_ExamReschedule_Validate";//Payment Alg Calling SP 

        public const string USP_Student_ReScheduleExam_OnDemand = "USP_Student_ReScheduleExam_OnDemand";
        public const string USP_Student_ScheduleExam_OnDemand = "USP_Student_ScheduleExam_OnDemand";
        public const string USP_Student_GetBookedExamSlots = "USP_Student_GetBookedExamSlots";




        public const string USP_Student_OnDemandScheduleExam = "USP_Student_OnDemandScheduleExam";
        public const string USP_Student_GetAmountForDemandSchedule = "USP_Student_GetAmountForDemandSchedule";
        public const string USP_GetRandomSecurityQuestion = "USP_GetRandomSecurityQuestion";


        //Proctor

        public const string USP_Proctor_GetMeetingID = "USP_Proctor_GetMeetingID";
        public const string USP_Common_GetProctors = "USP_Common_GetProctors";
        public const string USP_Proctor_UpdateProctor = "USP_Proctor_UpdateProctor";
        public const string USP_Proctor_GetExamDetails = "USP_Proctor_GetExamDetails";
        public const string USP_Proctor_GetTimerExamStatus = "USP_Proctor_GetTimerExamStatus";
        public const string USP_Proctor_GetProctorExamLookUp = "USP_Proctor_GetProctorExamLookUp";

        public const string USP_Proctor_GetExamStatus = "USP_Proctor_GetExamStatus";

        public const string USP_GetComments = "USP_GetComments";

        public const string USP_UpdateAuditorFlag = "USP_UpdateAuditorFlag";
        public const string USP_Proctor_ApproveExam = "USP_Proctor_ApproveExam";

        public const string USP_Add_AuditorComments1 = "USP_Add_AuditorComments1";
        public const string USP_GetStudentValidationStatus = "USP_GetStudentValidationStatus";
        public const string USP_SaveIdentityValidation = "USP_SaveIdentityValidation";

        public const string USP_GetExamTransactionStatus = "USP_GetExamTransactionStatus";

        public const string USP_Proctor_UpdateScreenshotDetails = "USP_Proctor_UpdateScreenshotDetails";
        public const string USP_Proctor_GetProctorReviewDetails = "USP_Proctor_GetProctorReviewDetails";
        public const string USP_Proctor_CheckStudentIdentity = "USP_Proctor_CheckStudentIdentity";
        public const string USP_Proctor_DeleteUploadFile = "USP_Proctor_DeleteUploadFile";
        public const string USP_Proctor_ResetExamSession = "USP_Proctor_ResetExamSession";

        //Auditor

        public const string USP_Auditor_CheckEmailForApproval = "USP_Auditor_CheckEmailForApproval";
        public const string USP_AuditorCheckVideoLink = "USP_AuditorCheckVideoLink";
        public const string USP_Auditor_Inbox = "USP_Auditor_Inbox";
        public const string USP_Proctor_AutoProctorInbox = "USP_Proctor_AutoProctorInbox";

        public const string USP_Auditor_Approve_Reject_Inbox = "USP_Auditor_InboxApproveOrReject";

        public const string USP_Proctor_AutoProcInboxApprove_Reject = "USP_Proctor_AutoProcInboxApproveOrReject";

        public const string USP_Auditor_Approve_Inbox = "USP_Auditor_InboxApprove";

        public const string USP_Proctor_AutoProcInboxApprove = "USP_Proctor_AutoProcInboxApprove";

        public const string USP_Auditor_ProcessedExamRequest = "USP_Auditor_ProcessedExamRequest";

        public const string USP_Auditor_GetCommentTypes = "USP_Auditor_GetCommentTypes";

        //Exam Provider

        public const string USP_PROVIDER_GETALLSTUDENTS = "USP_PROVIDER_GETALLSTUDENTS";

        public const string USP_Provider_GetStudents_Filtered = "USP_Provider_GetStudents_Filtered";
        public const string USP_Provider_DeleteEnrollStudent = "USP_Provider_DeleteEnrollStudent";

        public const string USP_Provider_GetEnrollStudentDetails = "USP_Provider_GetEnrollStudentDetails";

        public const string USP_Provider_UpdateStudentStatus = "USP_Provider_UpdateStudentStatus";

        public const string USP_provider_EnrollStudent = "USP_provider_EnrollStudent";
        public const string USP_Provider_GetProviderCourses = "USP_Provider_GetProviderCourses";

        public const string USP_Provider_GetStudentName = "USP_Provider_GetStudentName";

        public const string USP_Provider_GetStudentEnrollments = "USP_Provider_GetStudentEnrollments";

        public const string USP_Provider_AddStudent = "USP_Provider_AddStudent";

        public const string USP_Provider_GetStudentDetails = "USP_Provider_GetStudentDetails";

        public const string USP_Provider_GetStudentsNotInCourse = "USP_Provider_GetStudentsNotInCourse";
        public const string USP_Provider_GetEnrolledStudents = "USP_Provider_GetEnrolledStudents";
        public const string USP_Provider_GetCourseDetailsbyProvider = "USP_Provider_GetCourseDetailsbyProvider";


        public const string USP_Provider_GetStudentExamTransactions = "USP_Provider_GetStudentExamTransactions";
        public const string USP_Provider_DeleteCourse = "USP_Provider_DeleteCourse";
        public const string USP_Provider_GetStudents = "USP_Provider_GetStudents";
        public const string USP_Provider_GetExams = "USP_Provider_GetExams";
        public const string USP_GETEXAMTOOLS = "USP_GETEXAMTOOLS";
        public const string USP_Provider_GetSelectedCourseDetails = "USP_Provider_GetSelectedCourseDetails";
        public const string USP_Provider_AddCourse = "USP_Provider_AddCourse";
        public const string USP_Provider_GetSecurityLevelDesc = "USP_Provider_GetSecurityLevelDesc";
        public const string USP_Provider_ExamLevel = "USP_Provider_ExamLevel";
        public const string USP_ExamProvider_DeleteUploadFile = "USP_EXAMPROVIDER_DELETEUPLOADFILE";
        public const string USP_Provider_CheckForExamExistence = "USP_Provider_CheckForExamExistence";
        public const string USP_ExamProvider_GetExamStatus = "USP_ExamProvider_GetExamStatus";
        public const string USP_Provider_SaveExamDetails = "USP_Provider_SaveExamDetails";
        public const string USP_Provider_GetSelectedExamDetails = "USP_Provider_GetSelectedExamDetails";
        public const string USP_Provider_DeleteExam = "USP_Provider_DeleteExam";
        public const string USP_Provider_CheckForUpdateExamExistence = "USP_Provider_CheckForUpdateExamExistence";



        public const string USP_Provider_UpdateExamDetails = "USP_Provider_UpdateExamDetails";

        public const string USP_ExamProvider_GetExistingExams = "USP_ExamProvider_GetExistingExams";

        public const string USP_ExamProvider_SaveExamDetails = "USP_SAVEEXAMDETAILS";

        public const string USP_ExamProvider_SaveStudentDetails = "USP_ExamProvider_SaveStudentDetails";

        public const string USP_GetStudents = "USP_GetStudents";

        public const string USP_GetStudent_EnrollMents = "USP_GetStudent_EnrollMents";

        public const string USP_GetAvailableTimeSlots = "USP_GetAvailableTimeSlots";

        public const string USP_Auditor_ViewStudentDetails = "USP_Proctor_ViewStudentDetails";
        public const string USP_ExamProvider_ViewExamDetails = "USP_ExamProvider_ViewExamDetails";
        public const string USP_ExamProvider_UpdateExamDetails = "USP_ExamProvider_UpdateExamDetails";
        public const string USP_GetEditStudentDetails = "USP_GetEditStudentDetails";
        public const string USP_Provider_UpdateCourseDetails = "USP_Provider_UpdateCourseDetails";

        public const string USP_GetUpdateStudentDetails = "USP_GetUpdateStudentDetails";

        public const string USP_GetDeleteStudentDetails = "USP_GetDeleteStudentDetails";
        public const string USP_STUDENT_GetGenderList1 = "USP_STUDENT_GetGenderList1";


        public const string checkuserlogin = "checkuserlogin";

        public const string UpdateLoginStatus = "spUpdateLoginStatus";

        public const string checkproctorlogin = "checkproctorlogin";
        public const string USP_DeleteStudent = "USP_DeleteStudent";
        public const string usp_getStudentExamDetails = "usp_getStudentExamDetails";

        public const string USP_Reports_Student = "USP_Reports_Student";

        public const string USP_Common_GetEmailIDs = "USP_Common_GetEmailIDs";

        public const string USP_Common_GetEnrollStudentDetails = "USP_Common_GetEnrollStudentDetails";

        public const string USP_Common_GetGenderList = "USP_Common_GetGenderList";

        public const string USP_GetExamTime = "USP_GetExamTime";

        public const string USP_Examprovider_GetStudentAndCourses = "USP_Examprovider_GetStudentAndCourses";

        public const string USP_Examprovider_EnroolStudent = "USP_Examprovider_EnroolStudent";

        public const string USP_EP_CheckForExam = "USP_EP_CheckForExam";

        public const string USP_EXAMPROVIDER_DeleteExam = "USP_EXAMPROVIDER_DeleteExam";

        public const string USP_EXAMPROVIDER_UpdateStudentStatus = "USP_EXAMPROVIDER_UpdateStudentStatus";

        public const string USP_EXAMPROVIDER_DeleteEnrollStudent = "USP_EXAMPROVIDER_DeleteEnrollStudent";

        public const string USP_SetExamTime = "USP_SetExamTime";

        public const string USP_Student_GetExamSlots1 = "USP_Student_GetExamSlots1";

        public const string usp_setExamComplete = "usp_setExamComplete";
        public const string USP_ExamProvider_CreateCourse = "USP_ExamProvider_CreateCourse";
        public const string USP_Admin_CreateCourse = "USP_Admin_CreateCourse";
        public const string USP_ExamProvider_UpdateCourse = "USP_ExamProvider_UpdateCourse";
        // ADMIN
        public const string USP_Admin_AddInstructor = "USP_Admin_AddInstructor";
        public const string USP_Admin_GetInstructors = "USP_Admin_GetInstructors";

        public const string USP_Admin_GetExams = "USP_Admin_GetExams";
        public const string USP_Admin_AddCourse = "USP_Admin_AddCourse";
        public const string USP_Admin_GetExamProviders = "USP_Admin_GetExamProviders";
        public const string USP_Admin_GetSelectedCourseDetails = "USP_Admin_GetSelectedCourseDetails";
        public const string USP_Admin_UpdateCourseDetails = "USP_Admin_UpdateCourseDetails";
        public const string USP_Admin_GetSelectedExamDetails = "USP_Admin_GetSelectedExamDetails";
        public const string USP_Admin_UpdateCourse = "USP_Admin_UpdateCourse";
        public const string USP_Admin_DeleteExam = "USP_Admin_DeleteExam";
        public const string USP_Admin_ExamLevel = "USP_Admin_ExamLevel";
        public const string USP_Admin_UpdateExamDetails = "USP_Admin_UpdateExamDetails";
        public const string USP_Admin_DeleteUploadFile = "USP_Admin_DeleteUploadFile";
        public const string USP_Admin_GetSecurityLevelDesc = "USP_Admin_GetSecurityLevelDesc";
        public const string USP_Admin_CheckForExamExistence = "USP_Admin_CheckForExamExistence";
        public const string USP_Admin_CheckForUpdateExamExistence = "USP_Admin_CheckForUpdateExamExistence";
        public const string USP_Admin_SaveExamDetails = "USP_Admin_SaveExamDetails";
        //public const string USP_ExamProvider_GetCourses = "USP_ExamProvider_GetCourses";
        public const string USP_Provider_GetCourses = "USP_Provider_GetCourses";

        public const string USP_Admin_GetCourses_CourseStudents = "USP_Admin_GetCourses_CourseStudents";
        public const string USP_Admin_GetCourseDetailsbyProvider = "USP_Admin_GetCourseDetailsbyProvider";
        public const string USP_Admin_GetEnrolledStudents = "USP_Admin_GetEnrolledStudents";
        public const string USP_Admin_GetStudentsNotInCourse = "USP_Admin_GetStudentsByCourse";
        public const string USP_Admin_GetStudentsDetails = "USP_Admin_GetStudentsDetails";

        public const string USP_ADMIN_GetCourseDetails = "USP_ADMIN_GetCourseDetails";

        public const string USP_ADMIN_GetViewStudentDetails = "USP_ADMIN_GetViewStudentDetails";

        public const string USP_ADMIN_GetExistingExamDetails = "USP_ADMIN_GetExistingExamDetails";

        public const string USP_Admin_GetAllCourses = "USP_Admin_GetAllCourses";

        public const string USP_ADMIN_EP_CheckForExam = "USP_ADMIN_EP_CheckForExam";

        public const string USP_ADMIN_SAVEEXAMDETAILS = "USP_ADMIN_SAVEEXAMDETAILS";
        public const string USP_Admin_GetExamStatus = "USP_Admin_GetExamStatus";

        public const string USP_Admin_GetProviderCourses = "USP_Admin_GetProviderCourses";

        public const string USP_Admin_EnrolStudent = "USP_Admin_EnrolStudent";

        public const string USP_Admin_EnrolStudentCourse = "USP_Admin_EnrolStudentCourse";

        public const string USP_Admin_GetCourses = "USP_Admin_GetCourses";

        //15july2015
        public const string USP_Admin_GetAllCourseDetails = "USP_Admin_GetAllCourses";
        public const string USP_Admin_GetAllExamDetails = "USP_Admin_GetAllExams";
        public const string USP_Provider_GetInstructorCourseDetails = "USP_Provider_GetInstructorCourseDetails";
        public const string usp_GetExamSummaryReport = "usp_GetExamSummaryReport";
        public const string USP_Admin_GetExamSummaryReport = "USP_Admin_GetExamSummaryReport";

        public const string USP_Admin_GetEnrollMents = "USP_Admin_GetEnrollMents";

        public const string USP_Common_GetTimeDelay = "USP_Common_GetTimeDelay";
        public const string USP_ADMIN_GetPasswordDetails = "USP_ADMIN_GetPasswordDetails";

        public const string USP_ADMIN_UpdatePasswordDetails = "USP_ADMIN_UpdatePasswordDetails";

        public const string USP_GetSecurityLevel = "USP_GetSecurityLevel";

        public const string USP_CanvasDataload = "USP_CanvasDataload";

        public const string USP_Common_GetReportsTypes = "USP_Common_GetReportsTypes";
        public const string USP_Common_GetReport_Type1 = "USP_Common_GetReport_Type1";
        public const string USP_Common_GetReport_Type2 = "USP_Common_GetReport_Type2";

        public const string USP_Admin_GetStudents = "USP_Admin_GetStudents";

        public const string USP_Admin_GetStudentEnrollments = "USP_Admin_GetStudentEnrollments";

        public const string USP_Admin_AddStudent = "USP_Admin_AddStudent";

        public const string USP_Admin_GetStudentDetails = "USP_Admin_GetStudentDetails";

        public const string USP_Admin_GetStudentExamTransactions = "USP_Admin_GetStudentExamTransactions";

        public const string USP_Admin_SaveStudentDetails = "USP_Admin_SaveStudentDetails";

        public const string USP_Admin_DeleteStudent = "USP_Admin_DeleteStudent";

        public const string USP_Admin_GetStudentName = "USP_Admin_GetStudentName";

        public const string USP_Admin_GetEnrollStudentDetails = "USP_Admin_GetEnrollStudentDetails";

        public const string USP_Admin_UpdateStudentStatus = "USP_Admin_UpdateStudentStatus";

        public const string USP_Admin_DeleteEnrollStudent = "USP_Admin_DeleteEnrollStudent";

        public const string USP_Common_AlertUpdateOrDelete = "USP_Common_AlertUpdateOrDelete";
        //..................CourseAdmin SPs Start.....................................................//
        public const string USP_CourseAdmin_GetCourses = "USP_CourseAdmin_GetCourses";

        public const string USP_CourseAdmin_GetExams = "USP_CourseAdmin_GetExams";

        public const string USP_CourseAdmin_GetSelectedExamDetails = "USP_CourseAdmin_GetSelectedExamDetails";

        public const string USP_CourseAdmin_AddCourse = "USP_CourseAdmin_AddCourse";

        public const string USP_CourseAdmin_GetSelectedCourseDetails = "USP_CourseAdmin_GetSelectedCourseDetails";

        public const string USP_CourseAdmin_UpdateCourseDetails = "USP_CourseAdmin_UpdateCourseDetails";

        public const string USP_CourseAdmin_ExamLevel = "USP_CourseAdmin_ExamLevel";

        public const string USP_CourseAdmin_GetSecurityLevelDesc = "USP_CourseAdmin_GetSecurityLevelDesc";

        public const string USP_CourseAdmin_CheckForExamExistence = "USP_CourseAdmin_CheckForExamExistence";

        public const string USP_CourseAdmin_SaveExamDetails = "USP_CourseAdmin_SaveExamDetails";

        public const string USP_CourseAdmin_DeleteCourse = "USP_CourseAdmin_DeleteCourse";

        public const string USP_CourseAdmin_GetStudents_Filtered = "USP_CourseAdmin_GetStudents_Filtered";

        public const string USP_CourseAdmin_GetStudentEnrollments = "USP_CourseAdmin_GetStudentEnrollments";

        public const string USP_CourseAdmin_GETALLSTUDENTS = "USP_CourseAdmin_GETALLSTUDENTS";

        public const string USP_CourseAdmin_GetProviderCourses = "USP_CourseAdmin_GetProviderCourses";

        public const string USP_CourseAdmin_GetStudentExamTransactions = "USP_CourseAdmin_GetStudentExamTransactions";

        public const string USP_CourseAdmin_GetStudentDetails = "USP_CourseAdmin_GetStudentDetails";

        public const string USP_CourseAdmin_GetStudentName = "USP_CourseAdmin_GetStudentName";

        public const string USP_CourseAdmin_EnrollStudent = "USP_CourseAdmin_EnrollStudent";

        public const string USP_CourseAdmin_GetStudentExamTransactionsForCourseAdmin = "USP_CourseAdmin_GetStudentExamTransactionsForCourseAdmin";

        public const string USP_CourseAdmin_GetExamStatus = "USP_CourseAdmin_GetExamStatus";

        public const string USP_CourseAdmin_GetProviders = "USP_CourseAdmin_GetProviders";

        public const string USP_CourseAdmin_GetCourseAdminSpecificProviderCourses = "USP_CourseAdmin_GetCourseAdminSpecificProviderCourses";

        public const string USP_CourseAdmin_AddStudent = "USP_CourseAdmin_AddStudent";

        public const string USP_CourseAdmin_DeleteEnrollStudent = "USP_CourseAdmin_DeleteEnrollStudent";

        public const string USP_CourseAdmin_GetEnrollStudentDetails = "USP_CourseAdmin_GetEnrollStudentDetails";

        public const string USP_CourseAdmin_DeleteExam = "USP_CourseAdmin_DeleteExam";

        public const string USP_CourseAdmin_UpdateStudentStatus = "USP_CourseAdmin_UpdateStudentStatus";

        public const string USP_CourseAdmin_CheckForUpdateExamExistence = "USP_CourseAdmin_CheckForUpdateExamExistence";

        public const string USP_CourseAdmin_DeleteUploadFile = "USP_CourseAdmin_DeleteUploadFile";

        public const string USP_CourseAdmin_EnroolStudent = "USP_CourseAdmin_EnroolStudent";

        public const string USP_CourseAdmin_GetStudentAndCourses = "USP_CourseAdmin_GetStudentAndCourses";

        public const string USP_CourseAdmin_GetExistingExams = "USP_CourseAdmin_GetExistingExams";

        public const string USP_CourseAdmin_ViewExamDetails = "USP_CourseAdmin_ViewExamDetails";

        public const string USP_CourseAdmin_UpdateExamDetails = "USP_CourseAdmin_UpdateExamDetails";

        //16july2015
        public const string USP_Admin_GetAppointmentDetails = "USP_Admin_GetAppointmentDetails";
        //..................CourseAdmin SPs End.....................................................//

        public const string USP_PortalSSO_ValidateUser = "USP_PortalSSO_ValidateUser";

        public const string USP_Admin_GetExamsBySplIns = "USP_Admin_GetExamsBySplIns";

    }
}
