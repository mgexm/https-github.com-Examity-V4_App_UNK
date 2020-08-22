using System;
using BusinessEntities;
using DAL;

namespace BLL
{
    public class BAuditor
    {
        #region BGetAuditorInbox
        public void BGetAuditorInbox(BEAuditor objBEAuditor)
        {
            try
            {
                new DAuditor().GetAuditorInbox(objBEAuditor);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        public void BApproveTransaction(BEAuditor objBEAuditor)
        {

            try
            {
                new DAuditor().DApproveTransaction(objBEAuditor);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        #region BProcessedExamRequest
        public void BProcessedExamRequest(BEAuditor objBEAuditor)
        {

            try
            {
                new DAuditor().DProcessedExamRequest(objBEAuditor);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        public void BSearchStudentDetails(BEAuditor objBEAuditor)
        {
            try
            {
                new DAuditor().DSearchStudentDetails(objBEAuditor);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }

        }

        public void BGetAuditorCourseDetails(BEAuditor objBEAuditor)
        {
            try
            {
                new DAuditor().DGetAuditorCourseDetails(objBEAuditor);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        #region BGetStudentDetails
        public void BGetStudentDetails(BEAuditor objBEAuditor)
        {
            try
            {
                new DAuditor().DGetStudentDetails(objBEAuditor);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        #region BGetAuditorProviderDetails
        public void BGetAuditorProviderDetails(BEAuditor objBEAuditor1)
        {
            try
            {
                new DAuditor().DGetAuditorProviderDetails(objBEAuditor1);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        #region BGetComments
        public void BGetComments(BEAuditor objBEAuditor)
        {
            try
            {
                new DAuditor().DGetComments(objBEAuditor);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        #region BUpdateComments
        public void BUpdateComments(BEAuditor objBEAuditor)
        {
            try
            {
                new DAuditor().DUpdateComments(objBEAuditor);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion


        #region BGetAddedBy
        public void BGetAddedBy(BEAuditor objBEAuditor)
        {
            try
            {
                new DAuditor().DGetAddedBy(objBEAuditor);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        public void BDeleteAlertImage(BEAuditor objBEAuditor)
        {
            try
            {
                new DAuditor().DDeleteAlertImage(objBEAuditor);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
    }
}
