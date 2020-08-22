using System;
using BusinessEntities;
using DAL;
using System.Collections.Generic;

namespace BLL
{
    public class BCommon
    {
        #region BBindCourse
        public void BBindCourse(BECommon objBECommon)
        {

            try
            {
                new DCommon().DBindCourse(objBECommon);
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public void BBindCourse_Accessibility(BECommon objBECommon)
        {

            try
            {
                new DCommon().DBindCourse_Accessibility(objBECommon);
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public void BGetStudentCourses(BECommon objBECommon)
        {

            try
            {
                new DCommon().DGetStudentCourses(objBECommon);
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        #region BGenderList
        public void BGenderList(BECommon objBECommon)
        {

            try
            {
                new DCommon().DGenderList(objBECommon);
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion


        #region BBindExam
        public void BBindExam(BECommon objBECommon)
        {

            try
            {
                new DCommon().DBindExam(objBECommon);
            }

            catch (Exception Ex)
            {

                throw Ex;
            }

        }


        public void BBindExam_Accessibility(BECommon objBECommon)
        {

            try
            {
                new DCommon().DBindExam_Accessibility(objBECommon);
            }

            catch (Exception Ex)
            {

                throw Ex;
            }

        }
        #endregion

        #region BGetTransactionComments
        public void BGetTransactionComments(BECommon objBECommon)
        {
            try
            {
                new DCommon().DGetTransactionComments(objBECommon);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        #region BGetStudentReprot
        public void BGetStudentReprot(BECommon objBECommon)
        {

            try
            {
                new DCommon().DGetStudentReprot(objBECommon);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        #region BAddComments
        public void BAddComments(BECommon objBECommon)
        {
            try
            {
                new DCommon().DAddComments(objBECommon);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        public void BApproveOrRejectTransaction(BECommon objBECommon)
        {

            try
            {
                new DCommon().DApproveOrRejectTransaction(objBECommon);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public void BAutoProcInboxApproveOrReject(BECommon objBECommon)
        {

            try
            {
                new DCommon().DAutoProcInboxApproveOrReject(objBECommon);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        
        #region BUpdateTimeZone
        public void BUpdateTimeZone(BECommon objBECommon)
        {
            try
            {
                new DCommon().DUpdateTimeZone(objBECommon);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        #region BGetStudentExamDetails
        public void BGetStudentExamDetails(BECommon objBECommon)
        {

            try
            {
                new DCommon().DGetStudentExamDetails(objBECommon);
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        #region BGetStudentDetails
        public void BGetStudentDetails(BECommon objBECommon)
        {
            try
            {
                new DCommon().DGetStudentDetails(objBECommon);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        #region BGetStudentCourseDetails
        public void BGetStudentCourseDetails(BECommon objBECommon)
        {
            try
            {
                new DCommon().DGetStudentCourseDetails(objBECommon);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        #region BGetExamProviderDetails
        public void BGetExamProviderDetails(BECommon objBECommon)
        {
            try
            {
                new DCommon().DGetExamProviderDetails(objBECommon);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion


        #region BBindTools
        public void BBindTools(BECommon objBECommon)
        {
            try
            {
                new DCommon().BBindTools(objBECommon);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion


        public static List<BECommon> CheckProctorLoggedInusers(BECommon objBECommon)
        {
            return new DCommon().CheckProctorLoggedInusers(objBECommon);
        }

        public static List<BECommon> CheckLoggedInusers(BECommon objBECommon)
        {
            return new DCommon().CheckLoggedInusers(objBECommon);
        }

        #region BGetEnrollStudentDetails
        public void BGetEnrollStudentDetails(BECommon objBECommon)
        {
            try
            {
                new DCommon().DGetEnrollStudentDetails(objBECommon);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        #region BindProviderNames
        public void BindProviderNames(BECommon objBECommon)
        {
            try
            {
                new DCommon().DBindProviderNames(objBECommon);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        #region BAdminGetEnrollStudentDetails
        public void BAdminGetEnrollStudentDetails(BECommon objBECommon)
        {
            try
            {
                new DCommon().DAdminGetEnrollStudentDetails(objBECommon);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion


        #region BOpenTokSaveSessionID
        public void BOpenTokSaveSessionID(BECommon objBECommon)
        {
            try
            {
                new DCommon().DOpenTokSaveSessionID(objBECommon);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        #region BOpenTokGetSessionID
        public void BOpenTokGetSessionID(BECommon objBECommon)
        {
            try
            {
                new DCommon().DOpenTokGetSessionID(objBECommon);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion


        #region BOpenTokSaveArchiveID
        public void BOpenTokSaveArchiveID(BECommon objBECommon)
        {
            try
            {
                new DCommon().DOpenTokSaveArchiveID(objBECommon);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        #region BOpenTokGetArchiveID
        public void BOpenTokGetArchiveID(BECommon objBECommon)
        {
            try
            {
                new DCommon().DOpenTokGetArchiveID(objBECommon);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        //new schedular methods

        public void BBind_GetBookedExamSlots(BECommon objBECommon)
        {
            try
            {
                new DCommon().DBind_GetBookedExamSlots(objBECommon);
            }
            catch (Exception Ex)
            {

                throw Ex;
            }

        }


        public void BGetExamStatus(BECommon objBECommon)
        {

            try
            {
                new DCommon().DGetExamStatus(objBECommon);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BGetTimeDelay(BECommon objBECommon)
        {

            try
            {
                new DCommon().DGetTimeDelay(objBECommon);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BBindSecurityLevel(BECommon objBECommon)
        {
            try
            {
                new DCommon().DBindSecurityLevel(objBECommon);

            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BGetAlerts(BECommon objBECommon)
        {
            try
            {
                new DCommon().DGetAlerts(objBECommon);

            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        public void BGetSelectedReport(BECommon objBECommon)
        {
            try
            {
                if (objBECommon.intReportTypeID == 1)
                    new DCommon().DGetSelectedReportType1(objBECommon);
                else if (objBECommon.intReportTypeID == 2)
                    new DCommon().DGetSelectedReportType2(objBECommon);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        public void BGetReportTypes(BECommon objBECommon)
        {
            try
            {
                new DCommon().DGetReportTypes(objBECommon);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BBindAllTools(BECommon objBECommon)
        {
            try
            {
                new DCommon().DBindAllTools(objBECommon);

            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BUpdateGotoMeeting(BECommon objBECommon)
        {
            try
            {
                new DCommon().DUpdateGotoMeeting(objBECommon);

            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BBindNotesAndRules(BECommon objBECommon)
        {
            try
            {
                new DCommon().DBindNotesAndRules(objBECommon);

            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BBindSelectedNotesAndRules(BECommon objBECommon)
        {
            try
            {
                new DCommon().DBindSelectedNotesAndRules(objBECommon);

            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        #region BGetStandardAndAdditionalRules

        public void BGetStandardAndAdditionalRules(BECommon objBECommon)
        {

            try
            {
                new DCommon().DGetStandardAndAdditionalRules(objBECommon);
            }

            catch (Exception Ex)
            {

                throw Ex;
            }

        }

        //08nov2016
        public void BGetSpecialAdditionalRules(BECommon objBECommon)
        {

            try
            {
                new DCommon().DGetSpecialAdditionalRules(objBECommon);
            }

            catch (Exception Ex)
            {

                throw Ex;
            }

        }
        #endregion

        #region BGetExamRulesInformation



        public void BGetExamRulesInformation(BECommon objBECommon)
        {

            try
            {
                new DCommon().DGetExamRulesInformation(objBECommon);
            }

            catch (Exception Ex)
            {

                throw Ex;
            }

        }
        #endregion

        public void BGetAvailableTimeSlots(BECommon objBECommon)
        {
            try
            {
                new DCommon().DGetAvailableTimeSlots(objBECommon);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        public void BDeleteUpdateAlerts(BECommon objBECommon)
        {
            try
            {
                new DCommon().DDeleteUpdateAlerts(objBECommon);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BGetClientDetails(BECommon objBECommon)
        {
            try
            {
                new DCommon().DGetClientDetails(objBECommon);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        public void BGetUploadFiles(BECommon objBECommon)
        {
            try
            {
                new DCommon().DGetUploadFiles(objBECommon);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public void BGetExamUploadFiles(BECommon objBECommon)
        {
            try
            {
                new DCommon().DGetExamUploadFiles(objBECommon);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        public void BGetStudentUploadFileStatus(BECommon objBECommon)
        {

            try
            {
                new DCommon().DGetStudentUploadFileStatus(objBECommon);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BgetExamFileUploadStatus(BECommon objBECommon)
        {

            try
            {
                new DCommon().DgetExamFileUploadStatus(objBECommon);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BGetSSOStatus(BECommon objBECommon)
        {

            try
            {
                new DCommon().DGetSSOStatus(objBECommon);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BAuditorCheckEmailForApproval(BECommon objBECommon)
        {

            try
            {
                new DCommon().DAuditorCheckEmailForApproval(objBECommon);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public void BAuditorCheckVideoLink(BECommon objBECommon)
        {

            try
            {
                new DCommon().DAuditorCheckVideoLink(objBECommon);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        

        public void BGetExamFeePerHour(BECommon objBECommon)
        {

            try
            {
                new DCommon().DGetExamFeePerHour(objBECommon);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BGetExamBillingDetails(BECommon objBECommon)
        {
            try
            {
                new DCommon().DGetExamBillingDetails(objBECommon);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        public void BGetCommentID(BECommon objBECommon)
        {
            try
            {
                new DCommon().DGetCommentID(objBECommon);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BGetPorviderTimeDelay(BECommon objBECommon)
        {

            try
            {
                new DCommon().DGetPorviderTimeDelay(objBECommon);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        #region BValidateTimeZone
        public void BValidateTimeZone(BECommon objBECommon)
        {
            try
            {
                new DCommon().DValidateTimeZone(objBECommon);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        public void BGetAdminTimeDelay(BECommon objBECommon)
        {

            try
            {
                new DCommon().DGetAdminTimeDelay(objBECommon);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BGetInstructors(BECommon objBECommon)
        {
            try
            {
                new DCommon().DGetInstructors(objBECommon);
            }
            catch (Exception Ex)
            {

                throw Ex;
            }

        }

        #region BGetLMSSettings
        public void BGetLMSSettings(BECommon objBECommon)
        {
            try
            {
                new DCommon().DGetLMSSettings(objBECommon);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion


        public void BUpdateFlowTimeStamp(BECommon objBECommon)
        {

            try
            {
                new DCommon().DUpdateFlowTimeStamp(objBECommon);
            }

            catch (Exception Ex)
            {

                throw Ex;
            }

        }
        public void BAddEndexamTimestamp(BECommon objBECommon)
        {

            try
            {
                new DCommon().DAddEndexamTimestamp(objBECommon);
            }

            catch (Exception Ex)
            {

                throw Ex;
            }

        }
        public void BSaveTransImage(BECommon objBECommon)
        {

            try
            {
                new DCommon().DSaveTransImage(objBECommon);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public void BSaveTransIDImage(BECommon objBECommon)
        {

            try
            {
                new DCommon().DSaveTransIDImage(objBECommon);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BGetExamDetails(BECommon objBECommon)
        {

            try
            {
                new DCommon().DGetExamDetails(objBECommon);
            }

            catch (Exception Ex)
            {

                throw Ex;
            }

        }
        public void BGetPaymentData(BECommon objBECommon)
        {
            try
            {
                new DCommon().DGetPaymentData(objBECommon);
            }
            catch (Exception Ex)
            { 
                throw Ex; 
            }
        }


        public void BGetExamiKeyScore(BECommon objBECommon)
        {

            try
            {
                new DCommon().DGetExamiKeyScore(objBECommon);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BGetAAPaymentData(BECommon objBECommon)
        {
            try
            {
                new DCommon().DGetAAPaymentData(objBECommon);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        public void BDeleteRule(BECommon objBECommon)
        {

            try
            {
                new DCommon().DDeleteRule(objBECommon);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        public void BGetSpecialInstructions(BECommon objBECommon)
        {

            try
            {
                new DCommon().DGetSpecialInstructions(objBECommon);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BUpdateSpecialInstruction(BECommon objBECommon)
        {

            try
            {
                new DCommon().DUpdateSpecialInstruction(objBECommon);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        public void BAddSpecialInstruction(BECommon objBECommon)
        {

            try
            {
                new DCommon().DAddSpecialInstruction(objBECommon);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BUpdateSpecialInstructionFlags(BECommon objBECommon)
        {

            try
            {
                new DCommon().DUpdateSpecialInstructionFlags(objBECommon);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        public void BUpdateExamiLOCK(BECommon objBECommon)
        {

            try
            {
                new DCommon().DUpdateExamiLOCK(objBECommon);
            }

            catch (Exception Ex)
            {

                throw Ex;
            }

        }

        public void BReenableschedulestatus(BECommon objBECommon)
        {
            try
            {
                new DCommon().DReenableschedulestatus(objBECommon);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void BReenableBeginExamstatus(BECommon objBECommon)
        {
            try
            {
                new DCommon().DReenableBeginExamstatus(objBECommon);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void BGetOpenTokAutoProctorStatus(BECommon objBECommon)
        {
            try
            {
                new DCommon().DGetOpenTokAutoProctorStatus(objBECommon);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void BGetExamDetailsForExamityMeeting(BECommon objBECommon) {
            try
            {
                 new DCommon().DGetExamDetailsForExamityMeeting(objBECommon);
            }
            catch (Exception)
            {                
                throw;
            }
        }
        public void BGetVideoVisibleStatus(BECommon objBECommon)
        {
            try
            {
                new DCommon().DGetVideoVisibleStatus(objBECommon);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
