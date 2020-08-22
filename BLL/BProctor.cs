using System;
using BusinessEntities;
using DAL;

namespace BLL
{
    public class BProctor
    {
        #region BGetProctorExams
        public void BGetProctorExams(BEProctor objBEProctor)
        {
            try
            {
                new DProctor().DGetProctorExams(objBEProctor);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        public void BGetAutoProctorInbox(BEProctor objBEProctor)
        {
            try
            {
                new DProctor().GetAutoProctorInbox(objBEProctor);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public void BApproveAutoProcTransaction(BEProctor objBEProctor)
        {

            try
            {
                new DProctor().DApproveAutoProcTransaction(objBEProctor);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #region BGetAutoProctorProviderDetails
        public void BGetAutoProctorProviderDetails(BEProctor objBEProctor1)
        {
            try
            {
                new DProctor().DGetAutoProctorProviderDetails(objBEProctor1);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        #region BGetProctorExamLookUp
        public void BGetProctorExamLookUp(BEProctor objBEProctor)
        {
            try
            {
                new DProctor().DGetProctorExamLookUp(objBEProctor);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion


        #region GetExamTransactionStatus
        public void BGetExamTransactionStatus(BEProctor objBEProctor)
        {
            try
            {
                new DProctor().DGetExamTransactionStatus(objBEProctor);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        
        public void BGetExamTime(BEProctor objBEProctor)
        {
            try
            {
                new DProctor().DGetExamTime(objBEProctor);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        #region BProctorApproveExam
        public void BProctorApproveExam(BEProctor objBEProctor)
        {
            try
            {
                new DProctor().DProctorApproveExam(objBEProctor);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        #region BGetStudentValidationStatus
        public void BGetStudentValidationStatus(BEProctor objBEProctor)
        {
            try
            {
                new DProctor().DGetStudentValidationStatus(objBEProctor);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        #region BSaveIdentityValidation
        public void BSaveIdentityValidation(BEProctor objBEProctor)
        {
            try
            {
                new DProctor().DSaveIdentityValidation(objBEProctor);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        #region BGetExamDetails
        public void BGetExamDetails(BEProctor objBEProctor)
        {
            try
            {
                new DProctor().DGetExamDetails(objBEProctor);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        #region BUpdateScreenshotDetails
        public void BUpdateScreenshotDetails(BEProctor objBEProctor)
        {
            try
            {
                new DProctor().DUpdateScreenshotDetails(objBEProctor);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        #region BGetProctorReviewDetails
        public void BGetProctorReviewDetails(BEProctor objBEProctor)
        {
            try
            {
                new DProctor().DGetProctorReviewDetails(objBEProctor);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        #region BDeleteScreenshot
        public void BDeleteScreenshot(BEProctor objBEProctor)
        {
            try
            {
                new DProctor().DDeleteScreenshot(objBEProctor);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion


        public void BSetExamSessionID(BEProctor objBEProctor)
        {
            try
            {
                new DProctor().DSetExamSessionID(objBEProctor);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        public void BGetMeetingCredentials(BEProctor objBEProctor)
        {
            try
            {
                new DProctor().DGetMeetingCredentials(objBEProctor);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BGetZoomCredentials(BEProctor objBEProctor)
        {
            try
            {
                (new DProctor()).DGetZoomCredentials(objBEProctor);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public void BGetMeetingStatus(BEProctor objBEProctor)
        {
            try
            {
                new DProctor().DGetMeetingStatus(objBEProctor);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        public void BGetFlagStatus_Proceed(BEProctor objBEProctor)
        {
            try
            {
                objBEProctor.strStatus = "PROCEED";
                new DProctor().DGetFlagStatus(objBEProctor);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        public void BGetFlagStatus_StartExam(BEProctor objBEProctor)
        {
            try
            {
                objBEProctor.strStatus = "STARTEXAM";
                new DProctor().DGetFlagStatus(objBEProctor);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BGetFlagStatus_ExamCompleted(BEProctor objBEProctor)
        {
            try
            {
                objBEProctor.strStatus = "EXAMCOMPLETED";
                new DProctor().DGetFlagStatus(objBEProctor);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BGetFlagStatus_DownLoadStatusExam(BEProctor objBEProctor)
        {
            try
            {
               
                new DProctor().DGetDownLoadFlagStatus(objBEProctor);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BGetExamiKNOWStatus(BEProctor objBEProctor)
        {
            try
            {
                
                new DProctor().DGetExamiKNOWStatus(objBEProctor);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        //public void BGetFlagStatusNext(BEProctor objBEProctor)
        //{
        //    try
        //    {
        //        objBEProctor.strStatus = "NEXT";
        //        new DProctor().DGetFlagStatusNext(objBEProctor);
        //    }
        //    catch (Exception Ex)
        //    {
        //        throw Ex;
        //    }
        //}


        public void BSetTransactionFlags(BEProctor objBEProctor)
        {
            try
            {
                new DProctor().DSetTransactionFlags(objBEProctor);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BStudentIdentityVerification(BEProctor objBEProctor)
        {
            try
            {
                new DProctor().DStudentIdentityVerification(objBEProctor);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BresetExamSession(BEProctor objBEProctor)
        {
            try
            {
                new DProctor().DresetExamSession(objBEProctor);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        public void BGetProctor(BEProctor objBEProctor)
        {
            try
            {
                new DProctor().DGetProctor(objBEProctor);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BAddProctor(BEProctor objBEProctor)
        {
            try
            {
                new DProctor().DAddProctor(objBEProctor);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        //BLOCKED DATES :  START
        public void BGetBlockedDates(BEProctor objBEProctor)
        {
            try
            {
                new DProctor().DGetBlockedDates(objBEProctor);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public void BSaveBlockedDates(BEProctor objBEProctor)
        {
            try
            {
                new DProctor().DSaveBlockedDates(objBEProctor);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public void BDeleteBlockedDates(BEProctor objBEProctor)
        {
            try
            {
                new DProctor().DDeleteBlockedDates(objBEProctor);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public void BGetBlockedDatesForSelectedDate(BEProctor objBEProctor)
        {
            try
            {
                new DProctor().DGetBlockedDatesForSelectedDate(objBEProctor);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }



        //BLOCKED DATES :  END


        public void BGetMeetingID(BEProctor objBEProctor)
        {
            try
            {
                new DProctor().DGetMeetingID(objBEProctor);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BGetBrowserInfo(BEProctor objBEProctor)
        {
            try
            {
                new DProctor().DGetBrowserInfo(objBEProctor);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BGetWebExMeetingCredentials(BEProctor objBEProctor)
        {
            try
            {
                new DProctor().DGetWebExMeetingCredentials(objBEProctor);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BUpdateEnableProceedButtonTime(BEProctor objBEProctor)
        {
            try
            {
                new DProctor().DUpdateEnableProceedButtonTime(objBEProctor);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public void BUpdateEnableNextButtonTime(BEProctor objBEProctor)
        {
            try
            {
                new DProctor().DUpdateEnableNextButtonTime(objBEProctor);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BSetexamiFACETransactionStatus(BEProctor objBEProctor)
        {
            try
            {
                new DProctor().DSetexamiFACETransactionStatus(objBEProctor);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BSetexamiFACEDownLoadStatus(BEProctor objBEProctor)
        {
            try
            {
                new DProctor().DSetexamiFACEDownLoadStatus(objBEProctor);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
    }
}
