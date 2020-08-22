using System;
using BusinessEntities;
using DAL;

namespace BLL
{
    public class BStudent
    {
        #region BGetStudentTransactions
        public void BGetStudentTransactions(BEStudent objBEStudent)
        {
            try
            {
                new DStudent().DGetStudentTransactions(objBEStudent);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        #region BGetStudentGetPendingExam
        public void BGetStudentGetPendingExams(BEStudent objBEStudent)
        {

            try
            {
                new DStudent().DGetStudentGetPendingExams(objBEStudent);
            }

            catch (Exception Ex)
            {

                throw Ex;
            }

        }
        #endregion
        #region BGetStudentTodayExams
        public void BGetStudentTodayExams(BEStudent objBEStudent)
        {
            try
            {
                new DStudent().DGetStudentTodayExams(objBEStudent);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion



        #region BCancelExam
        public void BCancelExam(BEStudent objBEStudent)
        {
            try
            {
                new DStudent().DCancelExam(objBEStudent);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        #region BGetStudentSecurityQuestions
        public void BGetStudentSecurityQuestions(BEStudent objBEStudent)
        {

            try
            {
                new DStudent().DGetStudentSecurityQuestions(objBEStudent);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        #region BValidateStudentSecurityQuestions
        public void BValidateStudentSecurityQuestions(BEStudent objBEStudent)
        {
            try
            {
                new DStudent().DValidateStudentSecurityQuestions(objBEStudent);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }

        }
        #endregion

        #region BRandomSecurityQuestionsValidation
        public void BRandomSecurityQuestionsValidation(BEStudent objBEStudent)
        {
            try
            {
                new DStudent().DRandomSecurityQuestionsValidation(objBEStudent);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }

        }
        #endregion




        #region BGetExamLink
        public void BGetExamLink(BEStudent objBEStudent)
        {

            try
            {
                new DStudent().DGetExamLink(objBEStudent);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion
        public void BSetExamStartandEndTime(BEStudent objBEStudent)
        {
            try
            {
                new DStudent().DSetExamStartandEndTime(objBEStudent);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BGetExamSessionID(BEStudent objBEStudent)
        {
            try
            {
                new DStudent().DGetExamSessionID(objBEStudent);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        //#region BGetStudentExamDetails
        //public void BGetStudentExamDetails(BEStudent objBEStudent)
        //{

        //    try
        //    {
        //        new DStudent().DGetStudentExamDetails(objBEStudent);
        //    }

        //    catch (Exception Ex)
        //    {
        //        throw Ex;
        //    }
        //}
        //#endregion



        #region BBindProfileSecurityQuestions
        public void BBindProfileSecurityQuestions(BEStudent objBEStudent)
        {

            try
            {
                new DStudent().DBindProfileSecurityQuestions(objBEStudent);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        #region BgetPhotoIdentity
        public void BgetPhotoIdentity(BEStudent objBEStudent)
        {

            try
            {
                new DStudent().DGetPhotoIdentity(objBEStudent);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        #region BUploadPhotoIdentity
        public void BUploadPhotoIdentity(BEStudent objBEStudent)
        {

            try
            {
                new DStudent().DUploadPhotoIdentity(objBEStudent);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        #region BUpdateSecurityQuestions
        public void BUpdateSecurityQuestions(BEStudent objBEStudent)
        {

            try
            {
                new DStudent().DUpdateSecurityQuestions(objBEStudent);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public void BUpdateKeyStrokeDetails(BEStudent objBEStudent)
        {

            try
            {
                new DStudent().DUpdateKeyStrokeDetails(objBEStudent);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion
        #region BGetStudentReprot
        public void BGetStudentReprot(BEStudent objBEStudent)
        {

            try
            {
                new DStudent().DGetStudentReprot(objBEStudent);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion
        #region BGetRules
        public void BGetRules(BEStudent objBEStudent)
        {

            try
            {
                new DStudent().DGetRules(objBEStudent);
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        #region BScheduleAnExam
        public void BScheduleAnExam(BEStudent objBEStudent)
        {
            try
            {
                new DStudent().DScheduleAnExam(objBEStudent);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        #region BReScheduleAnExam
        public void BReScheduleAnExam(BEStudent objBEStudent)
        {

            try
            {
                new DStudent().DReScheduleAnExam(objBEStudent);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion


        #region BBindExamSlots
        public void BBindExamSlots(BEStudent objBEStudent)
        {

            try
            {
                new DStudent().DBindExamSlots(objBEStudent);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion


        #region BBindReExamSlots
        public void BBindReExamSlots(BEStudent objBEStudent)
        {

            try
            {
                new DStudent().DBindReExamSlots(objBEStudent);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        #region BGetCourseDetails
        public void BGetCourseDetails(BEStudent objBEStudent)
        {

            try
            {
                new DStudent().DGetCourseDetails(objBEStudent);
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        #region BStudentRegistration
        public void BStudentRegistration(BEStudent objBEStudent)
        {
            try
            {
                new DStudent().DStudentRegistration(objBEStudent);
            }

            catch (Exception Ex)
            {
                throw Ex;
            }

        }
        #endregion

        #region BExamService
        public void BGetExamDetails(BEStudent objBEStudent)
        {

            try
            {
                new DStudent().DGetExamDetails(objBEStudent);
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion BExamService

        #region BUpdateExamTransactionStatus
        public void BUpdateExamStatus(BEStudent objBEStudent)
        {

            try
            {
                new DStudent().DUpdateExamStatus(objBEStudent);
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion BUpdateExamTransactionStatus

        #region BGetUserName
        public void BGetUserName(BEStudent objBEStudent)
        {
            try
            {
                new DStudent().DGetUserName(objBEStudent);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        public void BGetStudentExamDetails(BEStudent objBEStudent)
        {

            try
            {
                new DStudent().DGetStudentExamDetails(objBEStudent);
            }

            catch (Exception Ex)
            {
                throw Ex;
            }

        }

        public void BsetExamCompleted(BEStudent objBEStudent)
        {

            try
            {
                new DStudent().DsetExamCompleted(objBEStudent);
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        #region BGetProviderCourses
        public void BGetProviderCourses(BEStudent objBEStudent)
        {
            try
            {
                new DStudent().DGetProviderCourses(objBEStudent);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        #region BGetIdentityValidation
        public void BGetIdentityValidation(BEStudent objBEStudent)
        {
            try
            {
                new DStudent().DGetIdentityValidation(objBEStudent);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion BGetIdentityValidation


        public void BStudent_ValidateExam(BEStudent objBEStudent)
        {
            try
            {
                new DStudent().DStudent_ValidateExam(objBEStudent);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // new scheduler methods

        public void BStudent_ScheduleExam(BEStudent objBEStudent)
        {
            try
            {
                new DStudent().DStudent_ScheduleExam(objBEStudent);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void BStudent_ScheduleExamOnDemand(BEStudent objBEStudent)
        {
            try
            {
                new DStudent().DStudent_ScheduleExamOnDemand(objBEStudent);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void BStudent_ReScheduleExamOnDemand(BEStudent objBEStudent)
        {
            try
            {
                new DStudent().DStudent_ReScheduleExamOnDemand(objBEStudent);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void BGetStudentName(BEStudent objBEStudent)
        {
            try
            {
                new DStudent().DGetStudentName(objBEStudent);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }

        }

        public void BStudent_ValidateRescheduledExam(BEStudent objBEStudent)
        {
            try
            {
                new DStudent().DStudent_ValidateRescheduledExam(objBEStudent);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void BStudent_UpdateScheduleExam(BEStudent objBEStudent)
        {
            try
            {
                new DStudent().DStudent_UpdateScheduleExam(objBEStudent);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region BStudentOnDemandScheduleExam

        public void BStudent_OnDemandScheduleExam(BEStudent objBEStudent)
        {
            try
            {
                new DStudent().DStudent_OnDemandScheduleExam(objBEStudent);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region BStudentGetAmountForDemandSchedule

        public void BStudent_GetAmountForDemandSchedule(BEStudent objBEStudent)
        {
            new DStudent().DStudent_GetAmountForDemandSchedule(objBEStudent);
        }

        #endregion

        #region BGetExamStartEndDates
        public void BGetExamStartEndDates(BEStudent obj)
        {

            try
            {
                new DStudent().DGetExamStartEndDates(obj);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion
        #region BGetExamScheduledDate
        public void BGetExamScheduledDate(BEStudent objBEStudent)
        {

            try
            {
                new DStudent().DGetExamScheduledDate(objBEStudent);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        #region BDeleteAppointment
        public void BDeleteAppointment(BEStudent objBEStudent)
        {

            try
            {
                new DStudent().DDeleteAppointment(objBEStudent);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion


        #region BValidateStudentProfileSettings
        public void BValidateStudentProfileSettings(BEStudent objBEStudent)
        {

            try
            {
                new DStudent().DValidateStudentProfileSettings(objBEStudent);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        public void BValidateUploadandQuestions(BEStudent objBEStudent)
        {

            try
            {
                new DStudent().DValidateUploadandQuestions(objBEStudent);
            }

            catch (Exception Ex)
            {
                throw Ex;
            }

        }

        public void BGetExamiBadge(BEStudent objBEStudent)
        {

            try
            {
                new DStudent().DGetExamiBadge(objBEStudent);
            }

            catch (Exception Ex)
            {
                throw Ex;
            }

        }

        public void BCheckExamStartTime(BEStudent objBEStudent)
        {

            try
            {
                new DStudent().DCheckExamStartTime(objBEStudent);
            }

            catch (Exception Ex)
            {
                throw Ex;
            }

        }

        public void BCheckexamiKEY(BEStudent objBEStudent)
        {

            try
            {
                new DStudent().DCheckexamiKEY(objBEStudent);
            }

            catch (Exception Ex)
            {
                throw Ex;
            }

        }
        public void BSetStudentStartExamFlag(BEStudent objBEStudent)
        {
            try
            {
                new DStudent().DSetStudentStartExamFlag(objBEStudent);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        public void BSetPaymentDetails_Scheduled(BEStudent objBEStudent)
        {
            try
            {
                new DStudent().DSetPaymentDetails_Scheduled(objBEStudent);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        public void BSetPaymentDetails_Recheduled(BEStudent objBEStudent)
        {
            try
            {
                new DStudent().DSetPaymentDetails_Recheduled(objBEStudent);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BGetCourseAndExam(BEStudent objBEStudent)
        {
            try
            {
                new DStudent().DGetCourseAndExam(objBEStudent);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BGetExamDetailsByTransID(BEStudent objBEStudent)
        {
            try
            {
                new DStudent().DGetExamDetailsByTransID(objBEStudent);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BGetRandomQuestion(BEStudent objBEStudent)
        {
            try
            {
                new DStudent().DGetRandomQuestion(objBEStudent);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BSaveStudentUploads(BEStudent objBEStudent)
        {
            try
            {
                new DStudent().DSaveStudentUploads(objBEStudent);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BGetCourseDetailsByExamID(BEStudent objBEStudent)
        {
            try
            {
                new DStudent().DGetCourseDetailsByExamID(objBEStudent);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BStudentDeleteUploadedFile(BEStudent objBEStudent)
        {
            try
            {
                new DStudent().DStudentDeleteUploadedFile(objBEStudent);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BGetAccessibility(BEStudent objBEStudent)
        {
            try
            {
                new DStudent().DGetAccessibility(objBEStudent);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        public void BGetExamTimes(BEStudent objBEStudent)
        {
            try
            {
                new DStudent().DGetExamTimes(objBEStudent);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        public void BUpdateAccessibility(BEStudent objBEStudent)
        {
            try
            {
                new DStudent().DUpdateAccessibility(objBEStudent);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BGetCourseAndExamDetails(BEStudent objBEStudent)
        {
            try
            {
                new DStudent().DGetCourseAndExamDetails(objBEStudent);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BCheckExamBoundaries(BEStudent objBEStudent)
        {
            try
            {
                new DStudent().DCheckExamBoundaries(objBEStudent);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BCheckExamBoundariesReschedule(BEStudent objBEStudent)
        {
            try
            {
                new DStudent().DCheckExamBoundariesReschedule(objBEStudent);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BGetExamFeeSettingsByExamID(BEStudent objBEStudent)
        {
            try
            {
                new DStudent().DGetExamFeeSettingsByExamID(objBEStudent);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BGetExamFeeSettingsByTransID(BEStudent objBEStudent)
        {
            try
            {
                new DStudent().DGetExamFeeSettingsByTransID(objBEStudent);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BGetExamSessionIDWithPrefix(BEStudent objBEStudent)
        {
            try
            {
                new DStudent().DGetExamSessionIDWithPrefix(objBEStudent);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BUpdateProceedTime(BEStudent objBEStudent)
        {
            try
            {
                new DStudent().DUpdateProceedTime(objBEStudent);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BUpdateNextButtonTime(BEStudent objBEStudent)
        {
            try
            {
                new DStudent().DUpdateNextButtonTime(objBEStudent);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BUpdateExamiKEYScore(BEStudent objBEStudent)
        {
            try
            {
                new DStudent().DUpdateExamiKEYScore(objBEStudent);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BUpdatePLTime(BEStudent objBEStudent)
        {
            try
            {
                new DStudent().DUpdatePLTime(objBEStudent);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BGetEmailID(BEStudent objBEStudent)
        {
            try
            {
                new DStudent().DGetEmailID(objBEStudent);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BSetAuthenticationCode(BEStudent objBEStudent)
        {
            try
            {
                new DStudent().DSetAuthenticationCode(objBEStudent);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public void BValidateAuthenticationCode(BEStudent objBEStudent)
        {
            try
            {
                new DStudent().DValidateAuthenticationCode(objBEStudent);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BUpdateNonProctorExamStatus(BEStudent objBEStudent)
        {

            try
            {
                new DStudent().DUpdateNonProctorExamStatus(objBEStudent);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BValidateStudentExam(BEStudent objBEStudent)
        {

            try
            {
                new DStudent().DValidateStudentExam(objBEStudent);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public void BValidatePLExam(BEStudent objBEStudent)
        {

            try
            {
                new DStudent().DValidatePLExam(objBEStudent);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BGetExamValues(BEStudent objBEStudent)
        {

            try
            {
                new DStudent().DGetExamValues(objBEStudent);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BStudent_NonProctorScheduleExam(BEStudent objBEStudent)
        {
            try
            {
                new DStudent().DStudent_NonProctorScheduleExam(objBEStudent);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void BStudent_NonProctorValidateExam(BEStudent objBEStudent)
        {
            try
            {
                new DStudent().DStudent_NonProctorValidateExam(objBEStudent);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void BCheckPLexamretake(BEStudent objBEStudent)
        {
            try
            {
                new DStudent().DCheckPLexamretake(objBEStudent);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BgetProviderFile(BEStudent objBEStudent)
        {
            try
            {
                new DStudent().DgetProviderFile(objBEStudent);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void BShowOrHideexamiKEY(BEStudent objBEStudent)
        {

            try
            {
                new DStudent().DShowOrHideexamiKEY(objBEStudent);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        public void BStudent_AAScheduleExam(BEStudent objBEStudent)
        {
            try
            {
                new DStudent().DStudent_AAScheduleExam(objBEStudent);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void BStudent_AAScheduleStudentPayExam(BEStudent objBEStudent)
        {
            try
            {
                
                new DStudent().DStudent_AAScheduleStudentPayExam(objBEStudent);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void BGetAAExams(BEStudent objBEStudent)
        {
            try
            {
                new DStudent().DGetAAExams(objBEStudent);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BAARandomSecurityQuestionsValidation(BEStudent objBEStudent)
        {
            try
            {
                new DStudent().DAARandomSecurityQuestionsValidation(objBEStudent);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }

        }

        public void BGetAAexamiKEYstatus(BEStudent objBEStudent)
        {
            try
            {
                new DStudent().DGetAAexamiKEYstatus(objBEStudent);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        public void BGetAAExamScheduledDate(BEStudent objBEStudent)
        {

            try
            {
                new DStudent().DGetAAExamScheduledDate(objBEStudent);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        public void BValidateReschedulePLExam(BEStudent objBEStudent)
        {

            try
            {
                new DStudent().DValidateReschedulePLExam(objBEStudent);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        //public void BStudent_AAGetExamDetails(BEStudent objBEStudent)
        //{

        //    try
        //    {
        //        new DStudent().DStudent_AAGetExamDetails(objBEStudent);
        //    }
        //    catch (Exception Ex)
        //    {
        //        throw Ex;
        //    }
        //}

        public void BDeleteAAAppointment(BEStudent objBEStudent)
        {

            try
            {
                new DStudent().DDeleteAAAppointment(objBEStudent);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        public void BStudent_UpdateAAExamReschedule(BEStudent objBEStudent)
        {
            try
            {
                new DStudent().DStudent_UpdateAAExamReschedule(objBEStudent);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BGetTransID(BEStudent objBEStudent)
        {
            try
            {
                new DStudent().DGetTransID(objBEStudent);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        public void BGetAuthenticationOverrideStatus(BEStudent objBEStudent)
        {
            try
            {
                new DStudent().DGetAuthenticationOverrideStatus(objBEStudent);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        public void BOverrideAuthentication(BEStudent objBEStudent)
        {
            try
            {
                new DStudent().DOverrideAuthentication(objBEStudent);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void BCheckExamiKEY(BEStudent objBEStudent)
        {

            try
            {
                new DStudent().DCheckExamiKEY(objBEStudent);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public void BCheckIsexamiFACE(BEStudent objBEStudent)
        {
            try
            {
                new DStudent().DCheckIsexamiFACE(objBEStudent);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BCheckIsexamiFACEDownLoad(BEStudent objBEStudent)
        {
            try
            {
                new DStudent().DCheckIsexamiFACEDownLoad(objBEStudent);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BCaptureOSAndBrowser(BEStudent objBEStudent)
        {
            try
            {
                new DStudent().DCaptureOSAndBrowser(objBEStudent);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
    }
}
