using System;
using BusinessEntities;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class DProctor
    {
        #region DGetProctorExams
        public void DGetProctorExams(BEProctor objBEProctor)
        {

            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[3];
                objSqlParam[0] = new SqlParameter("@V_Date", SqlDbType.DateTime);
                objSqlParam[0].Value = Convert.ToDateTime(objBEProctor.dtDate);
                objSqlParam[1] = new SqlParameter("@I_TransactionType", SqlDbType.Int);
                objSqlParam[1].Value = 0;
                objSqlParam[2] = new SqlParameter("@UserID", SqlDbType.Int);
                objSqlParam[2].Value = objBEProctor.IntUserID;


                objBEProctor.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Proctor_ValidateStudentIdentity, objSqlParam).Tables[0];

            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        public void DApproveAutoProcTransaction(BEProctor objBEProctor)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[2];

                objSqlParam[0] = new SqlParameter("@I_UserID", SqlDbType.Int);
                objSqlParam[0].Value = objBEProctor.IntEmployeeID;
                objSqlParam[1] = new SqlParameter("@TransID", SqlDbType.VarChar, 5000);
                objSqlParam[1].Value = objBEProctor.strTransID;

                objBEProctor.IntResult = SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Proctor_AutoProcInboxApprove, objSqlParam);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public void DGetAutoProctorProviderDetails(BEProctor objBEProctor1)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[1];
                objSqlParam[0] = new SqlParameter("@TransID", SqlDbType.VarChar, 1000);
                objSqlParam[0].Value = objBEProctor1.strTransID;

                objBEProctor1.DsResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Proctor_GetAutoProctorProviderDetails, objSqlParam);


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void GetAutoProctorInbox(BEProctor objBEProctor)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[1];

                objSqlParam[0] = new SqlParameter("@I_UserID", SqlDbType.Int);
                objSqlParam[0].Value = objBEProctor.IntUserID;
                //objBEAuditor.dtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Auditor_Inbox).Tables[0];
                //objBEAuditor.dtResult1 = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Auditor_Inbox).Tables[1];

                objBEProctor.objDs = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Proctor_AutoProctorInbox, objSqlParam);
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #region DGetProctorExams
        public void DGetProctorExamLookUp(BEProctor objBEProctor)
        {

            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[4];
                objSqlParam[0] = new SqlParameter("@V_ExamName", SqlDbType.VarChar, 100);
                objSqlParam[0].Value = objBEProctor.strExamName;
                objSqlParam[1] = new SqlParameter("@v_Name", SqlDbType.VarChar, 100);
                objSqlParam[1].Value = objBEProctor.strStudentName;
                objSqlParam[2] = new SqlParameter("@I_TransID", SqlDbType.BigInt);
                objSqlParam[2].Value = objBEProctor.IntTransID;

                objSqlParam[3] = new SqlParameter("@I_UserID", SqlDbType.Int);
                objSqlParam[3].Value = objBEProctor.IntUserID;

                objBEProctor.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Proctor_GetProctorExamLookUp, objSqlParam).Tables[0];


            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion


        #region DGetExamTransactionStatus
        public void DGetExamTransactionStatus(BEProctor objBEProctor)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[1];
                objSqlParam[0] = new SqlParameter("@I_TransID", SqlDbType.BigInt);
                objSqlParam[0].Value = objBEProctor.IntTransID;

                objBEProctor.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_GetExamTransactionStatus, objSqlParam).Tables[0];

            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion



        public void DGetExamTime(BEProctor objBEProctor)
        {
            SqlParameter[] objSqlParam = new SqlParameter[2];

            objSqlParam[0] = new SqlParameter("@TransID", SqlDbType.BigInt);
            objSqlParam[0].Value = objBEProctor.IntTransID;
            objSqlParam[1] = new SqlParameter("@TotalMinutes", SqlDbType.Int);
            objSqlParam[1].Direction = ParameterDirection.Output;

            SQLHelper.ExecuteScalar(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_GetExamTime, objSqlParam);
            objBEProctor.ExamTime = Convert.ToInt32(objSqlParam[1].Value);
        }

        #region DProctorApproveExam
        public void DProctorApproveExam(BEProctor objBEProctor)
        {

            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[4];
                objSqlParam[0] = new SqlParameter("@I_TransID", SqlDbType.BigInt);
                objSqlParam[0].Value = objBEProctor.IntTransID;
                objSqlParam[1] = new SqlParameter("@I_ApproverID", SqlDbType.Int);
                objSqlParam[1].Value = objBEProctor.IntUserID;
                objSqlParam[2] = new SqlParameter("@I_Flag", SqlDbType.Int);
                objSqlParam[2].Value = objBEProctor.IntFlag;
                objSqlParam[3] = new SqlParameter("@I_TransStatus", SqlDbType.VarChar, 20);
                objSqlParam[3].Value = objBEProctor.strStatus;


                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Proctor_ApproveExam, objSqlParam);

            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        #region DGetStudentValidationStatus
        public void DGetStudentValidationStatus(BEProctor objBEProctor)
        {

            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[4];
                objSqlParam[0] = new SqlParameter("@I_TransID", SqlDbType.BigInt);
                objSqlParam[0].Value = objBEProctor.IntTransID;
                objSqlParam[1] = new SqlParameter("@V_OTSessionID", SqlDbType.VarChar, 8000);
                objSqlParam[1].Direction = ParameterDirection.Output;
                objSqlParam[2] = new SqlParameter("@I_TransactionStatus", SqlDbType.Int);
                objSqlParam[2].Direction = ParameterDirection.Output;
                objSqlParam[3] = new SqlParameter("@I_StudentIdentity", SqlDbType.Bit);
                objSqlParam[3].Direction = ParameterDirection.Output;

                SQLHelper.ExecuteScalar(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_GetStudentValidationStatus, objSqlParam);
                objBEProctor.strOTSessionID = objSqlParam[1].Value.ToString();
                objBEProctor.strStatus = objSqlParam[2].Value.ToString();
                objBEProctor.StudentIdentity = Convert.ToBoolean(objSqlParam[3].Value.ToString());
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        #region DSaveIdentityValidation
        public void DSaveIdentityValidation(BEProctor objBEProctor)
        {

            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[4];
                objSqlParam[0] = new SqlParameter("@I_TransID", SqlDbType.BigInt);
                objSqlParam[0].Value = objBEProctor.IntTransID;
                objSqlParam[1] = new SqlParameter("@B_IdentityValidation", SqlDbType.Bit);
                objSqlParam[1].Value = objBEProctor.StudentIdentity;
                objSqlParam[2] = new SqlParameter("@Status", SqlDbType.Int);
                objSqlParam[2].Direction = ParameterDirection.Output;
                objSqlParam[3] = new SqlParameter("@UserID", SqlDbType.Int);
                objSqlParam[3].Value = objBEProctor.IntUserID;

                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_SaveIdentityValidation, objSqlParam);
                objBEProctor.IntResult = Convert.ToInt32(objSqlParam[2].Value);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion


        #region DGetExamDetails
        public void DGetExamDetails(BEProctor objBEProctor)
        {

            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[2];
                objSqlParam[0] = new SqlParameter("@I_TransID", SqlDbType.BigInt);
                objSqlParam[0].Value = objBEProctor.IntExamID1;

                objSqlParam[1] = new SqlParameter("@I_UserID", SqlDbType.Int);
                objSqlParam[1].Value = objBEProctor.IntUserID;

                objBEProctor.DsResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Proctor_GetExamDetails, objSqlParam);

            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        #region DUpdateScreenshotDetails
        public void DUpdateScreenshotDetails(BEProctor objBEProctor)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[10];
                objSqlParam[0] = new SqlParameter("@V_OriginalProctorFileName", SqlDbType.VarChar, 200);
                objSqlParam[0].Value = objBEProctor.strOriginalFileName;
                objSqlParam[1] = new SqlParameter("@V_StoredProctorFileName", SqlDbType.VarChar, 200);
                objSqlParam[1].Value = objBEProctor.strUploadPath;
                objSqlParam[2] = new SqlParameter("@I_CheckCam", SqlDbType.Bit);
                objSqlParam[2].Value = objBEProctor.boolcam;
                objSqlParam[3] = new SqlParameter("@I_CheckAudio", SqlDbType.Bit);
                objSqlParam[3].Value = objBEProctor.boolaudio;
                objSqlParam[4] = new SqlParameter("@I_CheckDesktop", SqlDbType.Bit);
                objSqlParam[4].Value = objBEProctor.booldesktop;
                objSqlParam[5] = new SqlParameter("@I_CheckIDValid", SqlDbType.Bit);
                objSqlParam[5].Value = objBEProctor.boolidvalid;
                objSqlParam[6] = new SqlParameter("@I_OS", SqlDbType.VarChar, 50);
                objSqlParam[6].Value = objBEProctor.strOs;
                objSqlParam[7] = new SqlParameter("@I_Browser", SqlDbType.VarChar, 50);
                objSqlParam[7].Value = objBEProctor.strBrowser;
                objSqlParam[8] = new SqlParameter("@I_TransID", SqlDbType.BigInt);
                objSqlParam[8].Value = objBEProctor.IntTransID;
                objSqlParam[9] = new SqlParameter("@I_Comments", SqlDbType.VarChar);
                objSqlParam[9].Value = objBEProctor.strProctorComments;

                //SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_SaveIdentityValidation, objSqlParam);
                objBEProctor.IntResult = SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Proctor_UpdateScreenshotDetails, objSqlParam);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        #region DGetProctorReviewDetails
        public void DGetProctorReviewDetails(BEProctor objBEProctor)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[1];
                objSqlParam[0] = new SqlParameter("@I_TransID", SqlDbType.BigInt);
                objSqlParam[0].Value = objBEProctor.IntTransID;

                objBEProctor.DsResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Proctor_GetProctorReviewDetails, objSqlParam);

            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        #region DDeleteScreenshot
        public void DDeleteScreenshot(BEProctor objBEProctor)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[1];
                objSqlParam[0] = new SqlParameter("@I_TransID", SqlDbType.BigInt);
                objSqlParam[0].Value = objBEProctor.IntTransID;

                //SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_SaveIdentityValidation, objSqlParam);
                objBEProctor.IntResult = SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Proctor_DeleteUploadFile, objSqlParam);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        public void DSetExamSessionID(BEProctor objBEProctor)
        {
            SqlParameter[] objSqlParam = new SqlParameter[3];

            objSqlParam[0] = new SqlParameter("@TransID", SqlDbType.BigInt);
            objSqlParam[0].Value = objBEProctor.IntTransID;
            objSqlParam[1] = new SqlParameter("@ExamSessionID", SqlDbType.VarChar, 100);
            objSqlParam[1].Value = objBEProctor.strExamSessionID;
            objSqlParam[2] = new SqlParameter("@ExamTokenID", SqlDbType.VarChar, 100);
            objSqlParam[2].Value = objBEProctor.strMeetingToken;

            SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, "usp_Proctor_SetExamID", objSqlParam);
        }

        public void DGetMeetingCredentials(BEProctor objBEProctor)
        {
            SqlParameter[] objSqlParam = new SqlParameter[10];

            objSqlParam[0] = new SqlParameter("@UserID", SqlDbType.BigInt);
            objSqlParam[0].Value = objBEProctor.IntUserID;
            objSqlParam[1] = new SqlParameter("@UserName", SqlDbType.VarChar, 100);
            objSqlParam[1].Direction = ParameterDirection.Output;
            objSqlParam[2] = new SqlParameter("@Password", SqlDbType.VarChar, 100);
            objSqlParam[2].Direction = ParameterDirection.Output;
            objSqlParam[3] = new SqlParameter("@TransID", SqlDbType.BigInt);
            objSqlParam[3].Value = objBEProctor.IntTransID;
            objSqlParam[4] = new SqlParameter("@ExamSessionID", SqlDbType.VarChar, 100);
            objSqlParam[4].Direction = ParameterDirection.Output;
            objSqlParam[5] = new SqlParameter("@ExamToken", SqlDbType.VarChar, 100);
            objSqlParam[5].Direction = ParameterDirection.Output;
            objSqlParam[6] = new SqlParameter("@ExamDuration", SqlDbType.VarChar, 10);
            objSqlParam[6].Direction = ParameterDirection.Output;
            objSqlParam[7] = new SqlParameter("@ExamBufferTime", SqlDbType.Int);
            objSqlParam[7].Direction = ParameterDirection.Output;
            objSqlParam[8] = new SqlParameter("@MeetingUsername", SqlDbType.VarChar, 100);//added for passing the username for wfm dashboard on 8.8.2017
            objSqlParam[8].Value = objBEProctor.Uname;
            objSqlParam[9] = new SqlParameter("@StationID", SqlDbType.Int);//added for passing the username for wfm dashboard on 8.8.2017
            objSqlParam[9].Value = objBEProctor.intID;

            SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, "usp_Proctor_GetMeetingCredentials", objSqlParam);

            objBEProctor.strMeetingUserName = objSqlParam[1].Value.ToString();
            objBEProctor.strMeetingPassword = objSqlParam[2].Value.ToString();
            objBEProctor.strExamSessionID = objSqlParam[4].Value.ToString();
            objBEProctor.strMeetingToken = objSqlParam[5].Value.ToString();
            objBEProctor.strExamDuration = objSqlParam[6].Value.ToString();
            objBEProctor.intExamBufferTime = Convert.ToInt32(objSqlParam[7].Value.ToString());
        }


        public void DGetMeetingStatus(BEProctor objBEProctor)
        {

            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[2];
                objSqlParam[0] = new SqlParameter("@I_TransID", SqlDbType.BigInt);
                objSqlParam[0].Value = objBEProctor.IntTransID;
                objSqlParam[1] = new SqlParameter("@I_Status", SqlDbType.Int);
                objSqlParam[1].Direction = ParameterDirection.Output;


                SQLHelper.ExecuteScalar(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_Student_GetMeetingStatus", objSqlParam);
                objBEProctor.IntstatusFlag = Convert.ToInt32(objSqlParam[1].Value.ToString());

            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        public void DGetFlagStatus(BEProctor objBEProctor)
        {

            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[3];
                objSqlParam[0] = new SqlParameter("@I_TransID", SqlDbType.BigInt);
                objSqlParam[0].Value = objBEProctor.IntTransID;
                objSqlParam[1] = new SqlParameter("@Type", SqlDbType.VarChar, 50);
                objSqlParam[1].Value = objBEProctor.strStatus;
                objSqlParam[2] = new SqlParameter("@I_Status", SqlDbType.Int);
                objSqlParam[2].Direction = ParameterDirection.Output;

                SQLHelper.ExecuteScalar(DConConfig.ConnectionString, CommandType.StoredProcedure, "usp_GetTransactionsFlags", objSqlParam);
                objBEProctor.IntstatusFlag = Convert.ToInt32(objSqlParam[2].Value.ToString());

            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void DGetDownLoadFlagStatus(BEProctor objBEProctor)
        {

            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[2];
                objSqlParam[0] = new SqlParameter("@I_TransID", SqlDbType.BigInt);
                objSqlParam[0].Value = objBEProctor.IntTransID;
                objSqlParam[1] = new SqlParameter("@I_Status", SqlDbType.Int);
                objSqlParam[1].Direction = ParameterDirection.Output;

                SQLHelper.ExecuteScalar(DConConfig.ConnectionString, CommandType.StoredProcedure, "usp_GetTransactionsexamiFaceDownLoadStatus", objSqlParam);
                objBEProctor.IntstatusFlag = Convert.ToInt32(objSqlParam[1].Value.ToString());

            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        public void DGetExamiKNOWStatus(BEProctor objBEProctor)
        {

            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[3];
                objSqlParam[0] = new SqlParameter("@I_TransID", SqlDbType.BigInt);
                objSqlParam[0].Value = objBEProctor.IntTransID;
           
                objSqlParam[1] = new SqlParameter("@I_Status", SqlDbType.Int);
                objSqlParam[1].Direction = ParameterDirection.Output;

                objSqlParam[2] = new SqlParameter("@I_From", SqlDbType.Int);
                objSqlParam[2].Value = objBEProctor.IntFlag;

                SQLHelper.ExecuteScalar(DConConfig.ConnectionString, CommandType.StoredProcedure, "usp_GetExamiKNOWStatus", objSqlParam);
                objBEProctor.IntstatusFlag = Convert.ToInt32(objSqlParam[1].Value.ToString());

            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        //public void DGetFlagStatusNext(BEProctor objBEProctor)
        //{

        //    try
        //    {
        //        SqlParameter[] objSqlParam = new SqlParameter[3];
        //        objSqlParam[0] = new SqlParameter("@I_TransID", SqlDbType.Int);
        //        objSqlParam[0].Value = objBEProctor.IntTransID;
        //        objSqlParam[1] = new SqlParameter("@Type", SqlDbType.VarChar, 50);
        //        objSqlParam[1].Value = objBEProctor.strStatus;
        //        objSqlParam[2] = new SqlParameter("@I_Status", SqlDbType.Int);
        //        objSqlParam[2].Direction = ParameterDirection.Output;

        //        SQLHelper.ExecuteScalar(DConConfig.ConnectionString, CommandType.StoredProcedure, "usp_GetFlagStatusNext", objSqlParam);
        //        objBEProctor.IntstatusFlag = Convert.ToInt32(objSqlParam[2].Value.ToString());

        //    }
        //    catch (Exception Ex)
        //    {
        //        throw Ex;
        //    }
        //}
        public void DSetTransactionFlags(BEProctor objBEProctor)
        {
            SqlParameter[] objSqlParam = new SqlParameter[3];

            objSqlParam[0] = new SqlParameter("@TransID", SqlDbType.BigInt);
            objSqlParam[0].Value = objBEProctor.IntTransID;
            objSqlParam[1] = new SqlParameter("@Type", SqlDbType.VarChar, 50);
            objSqlParam[1].Value = objBEProctor.strStatus;
            objSqlParam[2] = new SqlParameter("@Value", SqlDbType.Bit);
            objSqlParam[2].Value = objBEProctor.IntResult;

            SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, "usp_SetTransactionsFlags", objSqlParam);
        }
        public void DStudentIdentityVerification(BEProctor objBEProctor)
        {
            SqlParameter[] objSqlParam = new SqlParameter[2];

            objSqlParam[0] = new SqlParameter("@TransID", SqlDbType.BigInt);
            objSqlParam[0].Value = objBEProctor.IntTransID;
            objSqlParam[1] = new SqlParameter("@Result", SqlDbType.Int);
            objSqlParam[1].Direction = ParameterDirection.Output;



            SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Proctor_CheckStudentIdentity, objSqlParam);
            objBEProctor.IntstatusFlag = Convert.ToInt32(objSqlParam[1].Value);

        }


        public void DresetExamSession(BEProctor objBEProctor)
        {
            SqlParameter[] objSqlParam = new SqlParameter[1];

            objSqlParam[0] = new SqlParameter("@TransID", SqlDbType.BigInt);
            objSqlParam[0].Value = objBEProctor.IntTransID;




            SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Proctor_ResetExamSession, objSqlParam);


        }


        public void DGetProctor(BEProctor objBEProctor)
        {


            objBEProctor.DsResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Common_GetProctors);


        }

        public void DAddProctor(BEProctor objBEProctor)
        {
            SqlParameter[] objSqlParam = new SqlParameter[2];

            objSqlParam[0] = new SqlParameter("@TransID", SqlDbType.BigInt);
            objSqlParam[0].Value = objBEProctor.IntTransID;

            objSqlParam[1] = new SqlParameter("@ProctorID", SqlDbType.BigInt);
            objSqlParam[1].Value = objBEProctor.ProctorID;



            objBEProctor.IntResult = SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Proctor_UpdateProctor, objSqlParam);


        }

        //BLOCKED DATES :  START
        public void DGetBlockedDates(BEProctor objBEProctor)
        {
            SqlParameter[] objSqlParam = new SqlParameter[5];

            objSqlParam[0] = new SqlParameter("@UserID", SqlDbType.Int);
            objSqlParam[0].Value = objBEProctor.IntUserID;

            objBEProctor.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_BlockSlots_GetSlots", objSqlParam).Tables[0];
        }
        public void DSaveBlockedDates(BEProctor objBEProctor)
        {
            SqlParameter[] objSqlParam = new SqlParameter[5];

            objSqlParam[0] = new SqlParameter("@SlotDate", SqlDbType.VarChar, 50);
            objSqlParam[0].Value = objBEProctor.strSlotDate;
            objSqlParam[1] = new SqlParameter("@SlotTime", SqlDbType.VarChar, 50);
            objSqlParam[1].Value = objBEProctor.strSlotTime;
            objSqlParam[2] = new SqlParameter("@AllDay", SqlDbType.Bit);
            objSqlParam[2].Value = objBEProctor.intAllDay;
            objSqlParam[3] = new SqlParameter("@UserID", SqlDbType.Int);
            objSqlParam[3].Value = objBEProctor.IntUserID;
            objSqlParam[4] = new SqlParameter("@I_Result", SqlDbType.Int);
            objSqlParam[4].Direction = ParameterDirection.Output;

            SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_BlockSlots_AddSlots", objSqlParam);

            objBEProctor.IntResult = Convert.ToInt32(objSqlParam[4].Value);
        }
        public void DDeleteBlockedDates(BEProctor objBEProctor)
        {
            SqlParameter[] objSqlParam = new SqlParameter[3];

            objSqlParam[0] = new SqlParameter("@ID", SqlDbType.Int);
            objSqlParam[0].Value = objBEProctor.intID;
            objSqlParam[1] = new SqlParameter("@UserID", SqlDbType.Int);
            objSqlParam[1].Value = objBEProctor.IntUserID;
            objSqlParam[2] = new SqlParameter("@I_Result", SqlDbType.Int);
            objSqlParam[2].Direction = ParameterDirection.Output;

            SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_BlockSlots_DeleteSlot", objSqlParam);

            objBEProctor.IntResult = Convert.ToInt32(objSqlParam[2].Value);
        }
        public void DGetBlockedDatesForSelectedDate(BEProctor objBEProctor)
        {
            SqlParameter[] objSqlParam = new SqlParameter[2];

            objSqlParam[0] = new SqlParameter("@Date", SqlDbType.VarChar, 50);
            objSqlParam[0].Value = objBEProctor.StrDate;

            objSqlParam[1] = new SqlParameter("@UserID", SqlDbType.Int);
            objSqlParam[1].Value = objBEProctor.IntUserID;

            objBEProctor.DsResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_BlockSlots_GetBlockedSlots", objSqlParam);
        }
        //BLOCKED DATES :  END

        public void DGetMeetingID(BEProctor objBEProctor)
        {
            SqlParameter[] objSqlParam = new SqlParameter[2];

            objSqlParam[0] = new SqlParameter("@TransID", SqlDbType.BigInt);
            objSqlParam[0].Value = objBEProctor.IntTransID;

            objSqlParam[1] = new SqlParameter("@MeetingID", SqlDbType.VarChar, 250);
            objSqlParam[1].Direction = ParameterDirection.Output;

            SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Proctor_GetMeetingID, objSqlParam);

            objBEProctor.StrResult = objSqlParam[1].Value.ToString();


        }

        public void DGetBrowserInfo(BEProctor objBEProctor)
        {
            SqlParameter[] objSqlParam = new SqlParameter[2];

            objSqlParam[0] = new SqlParameter("@TransID", SqlDbType.BigInt);
            objSqlParam[0].Value = objBEProctor.IntTransID;

            objSqlParam[1] = new SqlParameter("@BrowserInfo", SqlDbType.VarChar, 250);
            objSqlParam[1].Direction = ParameterDirection.Output;

            SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_Proctor_GetBrowserInfo", objSqlParam);

            objBEProctor.StrResult = objSqlParam[1].Value.ToString();


        }

        public void DGetWebExMeetingCredentials(BEProctor objBEProctor)
        {
            SqlParameter[] objSqlParam = new SqlParameter[10];

            objSqlParam[0] = new SqlParameter("@UserID", SqlDbType.BigInt);
            objSqlParam[0].Value = objBEProctor.IntUserID;
            objSqlParam[1] = new SqlParameter("@UserName", SqlDbType.VarChar, 100);
            objSqlParam[1].Direction = ParameterDirection.Output;
            objSqlParam[2] = new SqlParameter("@Password", SqlDbType.VarChar, 100);
            objSqlParam[2].Direction = ParameterDirection.Output;
            objSqlParam[3] = new SqlParameter("@TransID", SqlDbType.BigInt);
            objSqlParam[3].Value = objBEProctor.IntTransID;
            objSqlParam[4] = new SqlParameter("@ExamSessionID", SqlDbType.VarChar, 100);
            objSqlParam[4].Direction = ParameterDirection.Output;
            objSqlParam[5] = new SqlParameter("@ExamToken", SqlDbType.VarChar, 100);
            objSqlParam[5].Direction = ParameterDirection.Output;
            objSqlParam[6] = new SqlParameter("@ExamDuration", SqlDbType.VarChar, 10);
            objSqlParam[6].Direction = ParameterDirection.Output;
            objSqlParam[7] = new SqlParameter("@ExamBufferTime", SqlDbType.Int);
            objSqlParam[7].Direction = ParameterDirection.Output;
            objSqlParam[8] = new SqlParameter("@StudentName", SqlDbType.VarChar, 100);
            objSqlParam[8].Direction = ParameterDirection.Output;
            objSqlParam[9] = new SqlParameter("@StudentEmailID", SqlDbType.VarChar, 100);
            objSqlParam[9].Direction = ParameterDirection.Output;
            SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, "usp_Proctor_GetWebExMeetingCredentials", objSqlParam);
            objBEProctor.strMeetingUserName = objSqlParam[1].Value.ToString();
            objBEProctor.strMeetingPassword = objSqlParam[2].Value.ToString();
            objBEProctor.strExamSessionID = objSqlParam[4].Value.ToString();
            objBEProctor.strMeetingToken = objSqlParam[5].Value.ToString();
            objBEProctor.strExamDuration = objSqlParam[6].Value.ToString();
            objBEProctor.intExamBufferTime = Convert.ToInt32(objSqlParam[7].Value.ToString());
            objBEProctor.strStudentName = objSqlParam[8].Value.ToString();
            objBEProctor.StrEmailID = objSqlParam[9].Value.ToString();
        }

        public void DUpdateEnableProceedButtonTime(BEProctor objBEProctor)
        {
            SqlParameter[] objSqlParam = new SqlParameter[1];

            objSqlParam[0] = new SqlParameter("@TransID", SqlDbType.BigInt);
            objSqlParam[0].Value = objBEProctor.IntTransID;
            SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_Proctor_UpdateEnableProceedButtonTime", objSqlParam);
        }
        public void DUpdateEnableNextButtonTime(BEProctor objBEProctor)
        {
            SqlParameter[] objSqlParam = new SqlParameter[1];

            objSqlParam[0] = new SqlParameter("@TransID", SqlDbType.BigInt);
            objSqlParam[0].Value = objBEProctor.IntTransID;
            SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_Proctor_UpdateEnableNextButton", objSqlParam);
        }

        public void DSetexamiFACETransactionStatus(BEProctor objBEProctor)
        {
            SqlParameter[] objSqlParam = new SqlParameter[3];

            objSqlParam[0] = new SqlParameter("@TransID", SqlDbType.BigInt);
            objSqlParam[0].Value = objBEProctor.IntTransID;


            SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, "usp_SetexamiFACEStatus", objSqlParam);
        }

        public void DSetexamiFACEDownLoadStatus(BEProctor objBEProctor)
        {
            SqlParameter[] objSqlParam = new SqlParameter[2];

            objSqlParam[0] = new SqlParameter("@TransID", SqlDbType.BigInt);
            objSqlParam[0].Value = objBEProctor.IntTransID;
            objSqlParam[1] = new SqlParameter("@status", SqlDbType.Int);
            objSqlParam[1].Value = Convert.ToInt32(objBEProctor.strStatus);


            SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, "usp_SetexamiFACEDownLoadStatus", objSqlParam);
        }
        public void DGetZoomCredentials(BEProctor objBEProctor)
        {
            SqlParameter[] sqlParameter = new SqlParameter[5];
            SqlParameter _paramUserId = new SqlParameter("@UserID", SqlDbType.BigInt);

            _paramUserId.Value = objBEProctor.IntUserID;
            sqlParameter[0] = _paramUserId;

            sqlParameter[1] = new SqlParameter("@TransID", SqlDbType.BigInt);
            sqlParameter[1].Value = objBEProctor.IntTransID;

            sqlParameter[2] = new SqlParameter("@MeetingUsername", SqlDbType.VarChar, 100);//added for passing the username for wfm dashboard on 8.8.2017
            sqlParameter[2].Value = objBEProctor.Uname;

            sqlParameter[3] = new SqlParameter("@StationId", SqlDbType.Int);//added for passing the username for wfm dashboard on 8.8.2017
            sqlParameter[3].Value = objBEProctor.intID;

            SqlParameter _zoomHostId = new SqlParameter("@ZoomHostId", SqlDbType.VarChar, 250);
            _zoomHostId.Direction = ParameterDirection.Output;
            sqlParameter[4] = _zoomHostId;

            SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, "usp_Proctor_GetZoomMeetingCredentials", sqlParameter);
            objBEProctor.strZoomHostId = sqlParameter[4].Value.ToString();
        }

    }
    }

