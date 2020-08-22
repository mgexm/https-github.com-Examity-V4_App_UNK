using System;
using BusinessEntities;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DAuditor
    {
        #region ConnectionString
        public string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SecureProctor"].ConnectionString.ToString();
        #endregion ConnectionString
        #region GetAuditorInbox
        public void GetAuditorInbox(BEAuditor objBEAuditor)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[1];

                objSqlParam[0] = new SqlParameter("@I_UserID", SqlDbType.Int);
                objSqlParam[0].Value = objBEAuditor.IntUserID;
                //objBEAuditor.dtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Auditor_Inbox).Tables[0];
                //objBEAuditor.dtResult1 = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Auditor_Inbox).Tables[1];

                objBEAuditor.objDs = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Auditor_Inbox, objSqlParam);
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        public void DApproveTransaction(BEAuditor objBEAuditor)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[2];

                objSqlParam[0] = new SqlParameter("@I_UserID", SqlDbType.Int);
                objSqlParam[0].Value = objBEAuditor.IntEmployeeID;
                objSqlParam[1] = new SqlParameter("@TransID", SqlDbType.VarChar, 5000);
                objSqlParam[1].Value = objBEAuditor.strTransID;

                objBEAuditor.IntResult = SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Auditor_Approve_Inbox, objSqlParam);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        #region DProcessedExamRequest
        public void DProcessedExamRequest(BEAuditor objBEAuditor)
        {

            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[1];

                objSqlParam[0] = new SqlParameter("@I_UserID", SqlDbType.Int);
                objSqlParam[0].Value = objBEAuditor.IntUserID;

                //objSqlParam[1] = new SqlParameter("@I_Period", SqlDbType.Int);
                //objSqlParam[1].Value = objBEAuditor.IntPeriod;

                objBEAuditor.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Auditor_ProcessedExamRequest, objSqlParam).Tables[0];
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        public void DSearchStudentDetails(BEAuditor objBEAuditor)
        {
            try
            {

                objBEAuditor.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.SearchStudentDetails).Tables[0];
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void DGetAuditorCourseDetails(BEAuditor objBEAuditor)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[2];
                objSqlParam[0] = new SqlParameter("@I_StudentID", SqlDbType.Int);
                objSqlParam[0].Value = objBEAuditor.IntStudentID;
                objSqlParam[1] = new SqlParameter("@I_UserID", SqlDbType.Int);
                objSqlParam[1].Value = objBEAuditor.IntUserID;

                //objBEAuditor.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_AUDITOR_GetStudentCourseDetails, objSqlParam).Tables[0];
                objBEAuditor.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Common_GetStudentCourseDetails, objSqlParam).Tables[0];
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        #region DGetStudentDetails
        public void DGetStudentDetails(BEAuditor objBEAuditor)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[1];
                objSqlParam[0] = new SqlParameter("@StudentID", SqlDbType.Int);
                objSqlParam[0].Value = objBEAuditor.IntStudentID;

                objBEAuditor.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Common_ViewStudentDetails, objSqlParam).Tables[0];


            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        public void DGetAuditorProviderDetails(BEAuditor objBEAuditor1)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[1];
                objSqlParam[0] = new SqlParameter("@TransID", SqlDbType.VarChar, 1000);
                objSqlParam[0].Value = objBEAuditor1.strTransID;

                objBEAuditor1.DsResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Auditor_GetProviderDetails, objSqlParam);


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void DGetComments(BEAuditor objBEAuditor)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[2];
                objSqlParam[0] = new SqlParameter("@CommentID", SqlDbType.Int);
                objSqlParam[0].Value = objBEAuditor.IntCommentID;

                objSqlParam[1] = new SqlParameter("@UserID", SqlDbType.Int);
                objSqlParam[1].Value = objBEAuditor.IntUserID;



                objBEAuditor.DsResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_Auditor_GetEditComments", objSqlParam);


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void DUpdateComments(BEAuditor objBEAuditor)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[10];
                objSqlParam[0] = new SqlParameter("@CommentID", SqlDbType.Int);
                objSqlParam[0].Value = objBEAuditor.IntCommentID;

                objSqlParam[1] = new SqlParameter("@Comments", SqlDbType.VarChar, 5000);
                objSqlParam[1].Value = objBEAuditor.StrComments;


                objSqlParam[2] = new SqlParameter("@TimeStamp", SqlDbType.VarChar, 50);
                objSqlParam[2].Value = objBEAuditor.TimeStamp;

                objSqlParam[3] = new SqlParameter("@AddedBy", SqlDbType.VarChar, 50);
                objSqlParam[3].Value = objBEAuditor.strAddedBy;

                objSqlParam[4] = new SqlParameter("@AddedOn", SqlDbType.DateTime);
                objSqlParam[4].Value = objBEAuditor.strAddedOn;

                objSqlParam[5] = new SqlParameter("@I_Result", SqlDbType.Int);
                objSqlParam[5].Direction = ParameterDirection.Output;

                objSqlParam[6] = new SqlParameter("@userid", SqlDbType.Int);
                objSqlParam[6].Value = objBEAuditor.IntUserID;

                objSqlParam[7] = new SqlParameter("@flag", SqlDbType.Int);
                objSqlParam[7].Value = objBEAuditor.IntFlag;

                objSqlParam[8] = new SqlParameter("@Type", SqlDbType.Int);
                objSqlParam[8].Value = objBEAuditor.IntstatusFlag;
                objSqlParam[9] = new SqlParameter("@AlertID", SqlDbType.Int);
                objSqlParam[9].Value = objBEAuditor.IntAletID;




                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_Auditor_UpdateCommentDetails", objSqlParam);

                objBEAuditor.IntResult = Convert.ToInt32(objSqlParam[5].Value.ToString());


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void DGetAddedBy(BEAuditor objBEAuditor)
        {
            try
            {



                objBEAuditor.DsResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_Auditor_GetProctorsandauditors");


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DDeleteAlertImage(BEAuditor objBEAuditor)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[1];

                objSqlParam[0] = new SqlParameter("@I_CommentID", SqlDbType.BigInt);
                objSqlParam[0].Value = objBEAuditor.IntCommentID;

                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_Auditor_DeleteAlertImage", objSqlParam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
