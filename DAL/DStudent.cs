using System;
using BusinessEntities;
using System.Data.SqlClient;
using System.Data;
namespace DAL
{
    public class DStudent
    {
        #region ConnectionString
        public string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SecureProctor"].ConnectionString.ToString();
        #endregion ConnectionString
        #region DGetStudentTransactions
        public void DGetStudentTransactions(BEStudent objBEStudent)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[3];

                objSqlParam[0] = new SqlParameter("@UserID", SqlDbType.Int);
                objSqlParam[0].Value = objBEStudent.IntUserID;

                objSqlParam[1] = new SqlParameter("@TransID", SqlDbType.BigInt);
                objSqlParam[1].Value = objBEStudent.IntProviderID;

                objSqlParam[2] = new SqlParameter("@ExamName", SqlDbType.VarChar, 500);
                objSqlParam[2].Value = objBEStudent.strExamName;

                objBEStudent.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.UPS_STUDENT_GetStudentTransactions, objSqlParam).Tables[0];
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        #region DGetStudentGetPendingExams
        public void DGetStudentGetPendingExams(BEStudent objBEStudent)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[1];

                objSqlParam[0] = new SqlParameter("@I_EmployeeID", SqlDbType.Int);
                objSqlParam[0].Value = objBEStudent.IntUserID;

                objBEStudent.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Student_StudentRescheduleExam, objSqlParam).Tables[0];
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        #region DGetStudentTodayExams
        public void DGetStudentTodayExams(BEStudent objBEStudent)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[2];

                objSqlParam[0] = new SqlParameter("@I_EmployeeID", SqlDbType.Int);
                objSqlParam[0].Value = objBEStudent.IntUserID;


                objSqlParam[1] = new SqlParameter("@I_ProviderID", SqlDbType.Int);
                objSqlParam[1].Value = objBEStudent.IntProviderID;

                objBEStudent.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Student_Start_scheduleExam, objSqlParam).Tables[0];
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        //#region DGetStudentExamDetails
        //public void DGetStudentExamDetails(BEStudent objBEStudent)
        //{
        //    try
        //    {
        //        SqlParameter[] objSqlParam = new SqlParameter[1];
        //        objSqlParam[0] = new SqlParameter("@TransID", SqlDbType.Int);
        //        objSqlParam[0].Value = objBEStudent.IntTransID;

        //        objBEStudent.dtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.usp_getStudentExamDetails, objSqlParam).Tables[0];

        //        objBEStudent.dtResult1 = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.usp_getStudentExamDetails, objSqlParam).Tables[1];

        //        objBEStudent.dtResult3 = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.usp_getStudentExamDetails, objSqlParam).Tables[2];

        //        objBEStudent.dtResult2 = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.usp_getStudentExamDetails, objSqlParam).Tables[3];
        //        objBEStudent.dtResult4 = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.usp_getStudentExamDetails, objSqlParam).Tables[4];
        //    }

        //    catch (Exception Ex)
        //    {
        //        throw Ex;
        //    }
        //}
        //#endregion

        #region DCancelExam
        public void DCancelExam(BEStudent objBEStudent)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[1];

                objSqlParam[0] = new SqlParameter("@TransID", SqlDbType.BigInt);
                objSqlParam[0].Value = objBEStudent.IntTransID;

                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_CancelExam, objSqlParam);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        #region DGetStudentSecurityQuestions
        public void DGetStudentSecurityQuestions(BEStudent objBEStudent)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[1];
                objSqlParam[0] = new SqlParameter("@UserID", SqlDbType.Int);
                objSqlParam[0].Value = objBEStudent.IntUserID;

                objBEStudent.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_GetSecurityQeustionsAndAsnwers, objSqlParam).Tables[0];
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion
        #region DValidateStudentSecurityQuestions
        public void DValidateStudentSecurityQuestions(BEStudent objBEStudent)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[5];

                objSqlParam[0] = new SqlParameter("@Answer1", SqlDbType.VarChar, 500);
                objSqlParam[0].Value = objBEStudent.strAnswer1;

                objSqlParam[1] = new SqlParameter("@Answer2", SqlDbType.VarChar, 500);
                objSqlParam[1].Value = objBEStudent.strAnswer2;

                objSqlParam[2] = new SqlParameter("@Answer3", SqlDbType.VarChar, 500);
                objSqlParam[2].Value = objBEStudent.strAnswer3;

                objSqlParam[3] = new SqlParameter("@UserID", SqlDbType.Int);
                objSqlParam[3].Value = objBEStudent.IntUserID;

                objSqlParam[4] = new SqlParameter("@Status", SqlDbType.Int);
                objSqlParam[4].Direction = ParameterDirection.Output;

                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_ValidateStudentSecurityQuestions, objSqlParam);

                objBEStudent.IntResult = Convert.ToInt32(objSqlParam[4].Value.ToString());
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion


        #region DRandomSecurityQuestionsValidation
        public void DRandomSecurityQuestionsValidation(BEStudent objBEStudent)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[6];

                objSqlParam[0] = new SqlParameter("@Answer", SqlDbType.VarChar, 500);
                objSqlParam[0].Value = objBEStudent.strAnswer1;

                objSqlParam[1] = new SqlParameter("@UserID", SqlDbType.Int);
                objSqlParam[1].Value = objBEStudent.IntUserID;
                objSqlParam[2] = new SqlParameter("@Question", SqlDbType.Int);
                objSqlParam[2].Value = Convert.ToInt32(objBEStudent.strQuestion1);
                objSqlParam[3] = new SqlParameter("@Status", SqlDbType.Int);
                objSqlParam[3].Direction = ParameterDirection.Output;
                objSqlParam[4] = new SqlParameter("@TransID", SqlDbType.BigInt);
                objSqlParam[4].Value = objBEStudent.IntTransID;
            
                objSqlParam[5] = new SqlParameter("@ErrorMsg", SqlDbType.VarChar,500);
                objSqlParam[5].Direction = ParameterDirection.Output;

                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_RandomSecurityQuestionsValidation, objSqlParam);

                objBEStudent.IntResult = Convert.ToInt32(objSqlParam[3].Value.ToString());
              
                objBEStudent.StrResult = objSqlParam[5].Value.ToString();

            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion


        #region DGetExamLink
        public void DGetExamLink(BEStudent objBEStudent)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[2];
                objSqlParam[0] = new SqlParameter("@I_TransID", SqlDbType.BigInt);
                objSqlParam[0].Value = objBEStudent.IntTransID;
                objSqlParam[1] = new SqlParameter("@V_ExamLink", SqlDbType.VarChar, 500);
                objSqlParam[1].Direction = ParameterDirection.Output;

                SQLHelper.ExecuteScalar(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Student_GetExamLink, objSqlParam);
                objBEStudent.strExamLink = objSqlParam[1].Value.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        public void DSetExamStartandEndTime(BEStudent objBEStudent)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[2];

                objSqlParam[0] = new SqlParameter("@TransID", SqlDbType.BigInt);
                objSqlParam[0].Value = objBEStudent.IntTransID;

                objSqlParam[1] = new SqlParameter("@Flag", SqlDbType.Int);
                objSqlParam[1].Value = objBEStudent.IntFlag;

                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_SetExamTime, objSqlParam);
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void DGetExamSessionID(BEStudent objBEStudent)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[2];

                objSqlParam[0] = new SqlParameter("@TransID", SqlDbType.BigInt);
                objSqlParam[0].Value = objBEStudent.IntTransID;

                objSqlParam[1] = new SqlParameter("@SessionID", SqlDbType.VarChar, 100);
                objSqlParam[1].Direction = ParameterDirection.Output;

                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Student_GetExamSessionID, objSqlParam);

                objBEStudent.strSessionID = objSqlParam[1].Value.ToString();
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        #region DBindProfileSecurityQuestions
        public void DBindProfileSecurityQuestions(BEStudent objBEStudent)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[1];
                objSqlParam[0] = new SqlParameter("@I_UserID", SqlDbType.Int);
                objSqlParam[0].Value = objBEStudent.IntUserID;


                objBEStudent.DsResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Student_getSelectedSecurityQuestion, objSqlParam);



            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion
        #region DUpdateSecurityQuestions
        public void DUpdateSecurityQuestions(BEStudent objBEStudent)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[7];
                objSqlParam[0] = new SqlParameter("@I_UserID", SqlDbType.Int);
                objSqlParam[0].Value = objBEStudent.IntUserID;
                objSqlParam[1] = new SqlParameter("@I_SQuestion1", SqlDbType.Int);
                objSqlParam[1].Value = objBEStudent.strQuestion1;
                objSqlParam[2] = new SqlParameter("@V_SAnswer1", SqlDbType.VarChar, 50);
                objSqlParam[2].Value = objBEStudent.strAnswer1;
                objSqlParam[3] = new SqlParameter("@I_SQuestion2", SqlDbType.Int);
                objSqlParam[3].Value = objBEStudent.strQuestion2;
                objSqlParam[4] = new SqlParameter("@V_SAnswer2", SqlDbType.VarChar, 50);
                objSqlParam[4].Value = objBEStudent.strAnswer2;
                objSqlParam[5] = new SqlParameter("@I_SQuestion3", SqlDbType.Int);
                objSqlParam[5].Value = objBEStudent.strQuestion3;
                objSqlParam[6] = new SqlParameter("@V_SAnswer3", SqlDbType.VarChar, 50);
                objSqlParam[6].Value = objBEStudent.strAnswer3;

                objBEStudent.IntResult = SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Student_UpdateSecurityQuestions, objSqlParam);

            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void DUpdateKeyStrokeDetails(BEStudent objBEStudent)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[3];
                objSqlParam[0] = new SqlParameter("@I_UserID", SqlDbType.Int);
                objSqlParam[0].Value = objBEStudent.IntUserID;
                objSqlParam[1] = new SqlParameter("@V_Fname", SqlDbType.VarChar, 50);
                objSqlParam[1].Value = objBEStudent.strFirstName;
                objSqlParam[2] = new SqlParameter("@V_LFname", SqlDbType.VarChar, 50);
                objSqlParam[2].Value = objBEStudent.strLastName;


                objBEStudent.IntResult = SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_Student_UpdateKeyStrokeValues", objSqlParam);

            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        #region DGetPhotoIdentity
        public void DGetPhotoIdentity(BEStudent objBEStudent)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[1];
                objSqlParam[0] = new SqlParameter("@I_UserID", SqlDbType.Int);
                objSqlParam[0].Value = objBEStudent.IntUserID;

                objBEStudent.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Student_getPhotoIdentity, objSqlParam).Tables[0];
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion
        #region DUploadPhotoIdentity
        public void DUploadPhotoIdentity(BEStudent objBEStudent)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[2];
                objSqlParam[0] = new SqlParameter("@I_UserID", SqlDbType.Int);
                objSqlParam[0].Value = objBEStudent.IntUserID;

                objSqlParam[1] = new SqlParameter("@V_PhotoIdentity", SqlDbType.VarChar, 500);
                objSqlParam[1].Value = objBEStudent.strUploadPath;

                objBEStudent.IntResult = SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Student_UpdatePhotoIdentity, objSqlParam);
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        #region DGetStudentReprot
        public void DGetStudentReprot(BEStudent objBEStudent)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[4];
                objSqlParam[0] = new SqlParameter("@dtStart", SqlDbType.VarChar, 50);
                objSqlParam[0].Value = objBEStudent.DtStartDate;
                objSqlParam[1] = new SqlParameter("@dtEnd", SqlDbType.VarChar, 50);
                objSqlParam[1].Value = objBEStudent.DtEndDate;
                objSqlParam[2] = new SqlParameter("@IntStatus", SqlDbType.Int);
                objSqlParam[2].Value = objBEStudent.IntType;
                objSqlParam[3] = new SqlParameter("@UserID", SqlDbType.Int);
                objSqlParam[3].Value = objBEStudent.IntUserID;

                objBEStudent.DsResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Reports_Student, objSqlParam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region DGetRules
        public void DGetRules(BEStudent objBEStudent)
        {

            try
            {

                SqlParameter[] objSqlParam = new SqlParameter[1];
                objSqlParam[0] = new SqlParameter("@I_ExamID", SqlDbType.Int);
                objSqlParam[0].Value = objBEStudent.IntExamID;
                objBEStudent.DsResult = SQLHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Student_GetRules, objSqlParam);


            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        #region DScheduleAnExam
        public void DScheduleAnExam(BEStudent objBEStudent)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[7];
                objSqlParam[0] = new SqlParameter("@UserID", SqlDbType.Int);
                objSqlParam[0].Value = objBEStudent.IntUserID;
                objSqlParam[1] = new SqlParameter("@CourseID", SqlDbType.Int);
                objSqlParam[1].Value = objBEStudent.IntCourseID;
                objSqlParam[2] = new SqlParameter("@ScheduleID", SqlDbType.Int);
                objSqlParam[2].Value = objBEStudent.IntScheduleID;
                objSqlParam[3] = new SqlParameter("@ExamID", SqlDbType.Int);
                objSqlParam[3].Value = objBEStudent.IntExamID;
                objSqlParam[4] = new SqlParameter("@ExamDate", SqlDbType.DateTime);
                objSqlParam[4].Value = objBEStudent.dtExam;
                objSqlParam[5] = new SqlParameter("@TransID", SqlDbType.BigInt);
                objSqlParam[5].Direction = ParameterDirection.Output;
                objSqlParam[6] = new SqlParameter("@TimeZone", SqlDbType.VarChar);
                objSqlParam[6].Value = objBEStudent.strTimeZone;

                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_ScheduleExam, objSqlParam);
                objBEStudent.IntTransID = Convert.ToInt32(objSqlParam[5].Value.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region DReScheduleAnExam
        public void DReScheduleAnExam(BEStudent objBEStudent)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[5];
                objSqlParam[0] = new SqlParameter("@UserID", SqlDbType.Int);
                objSqlParam[0].Value = objBEStudent.IntUserID;
                objSqlParam[1] = new SqlParameter("@ScheduleID", SqlDbType.Int);
                objSqlParam[1].Value = objBEStudent.IntScheduleID;
                objSqlParam[2] = new SqlParameter("@ExamDate", SqlDbType.DateTime);
                objSqlParam[2].Value = objBEStudent.dtExam;
                objSqlParam[3] = new SqlParameter("@TimeZone", SqlDbType.VarChar);
                objSqlParam[3].Value = objBEStudent.strTimeZone;
                objSqlParam[4] = new SqlParameter("@TransID", SqlDbType.BigInt);
                objSqlParam[4].Value = objBEStudent.IntTransID;

                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_ReScheduleExam, objSqlParam);

                //objBEStudent.intResult = Convert.ToInt32(objSqlParam[3].Value);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion


        #region DBindExamSlots
        public void DBindExamSlots(BEStudent objBEStudent)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[2];

                objSqlParam[0] = new SqlParameter("@I_ExamID", SqlDbType.Int);
                objSqlParam[0].Value = objBEStudent.IntExamID;

                objSqlParam[1] = new SqlParameter("@Date", SqlDbType.DateTime);
                objSqlParam[1].Value = objBEStudent.dtExam.ToShortDateString();

                objBEStudent.DsResult = SQLHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Student_GetExamSlots, objSqlParam);

            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        #region DBindReExamSlots
        public void DBindReExamSlots(BEStudent objBEStudent)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[4];

                objSqlParam[0] = new SqlParameter("@I_ExamID", SqlDbType.Int);
                objSqlParam[0].Value = objBEStudent.IntExamID;

                objSqlParam[1] = new SqlParameter("@Date", SqlDbType.DateTime);
                objSqlParam[1].Value = objBEStudent.dtExam.ToShortDateString();

                objSqlParam[2] = new SqlParameter("@UserID", SqlDbType.Int);
                objSqlParam[2].Value = objBEStudent.IntUserID;

                objSqlParam[3] = new SqlParameter("@Transid", SqlDbType.BigInt);
                objSqlParam[3].Value = objBEStudent.IntTransID;

                objBEStudent.DsResult = SQLHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Student_GetExamSlots1, objSqlParam);

            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        #region DGetCourseDetails
        public void DGetCourseDetails(BEStudent objBEStudent)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[2];
                objSqlParam[0] = new SqlParameter("@I_ScheduleID", SqlDbType.BigInt);
                objSqlParam[0].Value = objBEStudent.IntTransID;

                objSqlParam[1] = new SqlParameter("@UserID", SqlDbType.Int);
                objSqlParam[1].Value = objBEStudent.IntUserID;

                objBEStudent.DtResult = SQLHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_STUDENT_GetCourseDetails, objSqlParam).Tables[0];
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        #region DStudentRegistration
        public void DStudentRegistration(BEStudent objBEStudent)
        {

            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[17];
                objSqlParam[0] = new SqlParameter("@V_FirstName", SqlDbType.VarChar, 100);
                objSqlParam[0].Value = objBEStudent.strFirstName;
                objSqlParam[1] = new SqlParameter("@V_LastName", SqlDbType.VarChar, 100);
                objSqlParam[1].Value = objBEStudent.strLastName;
                objSqlParam[2] = new SqlParameter("@V_UserName", SqlDbType.VarChar, 100);
                objSqlParam[2].Value = objBEStudent.strUserName;
                objSqlParam[3] = new SqlParameter("@V_PhotoID", SqlDbType.VarChar, 100);
                objSqlParam[3].Value = objBEStudent.strUploadPath;
                objSqlParam[4] = new SqlParameter("@V_Password", SqlDbType.VarChar, 100);
                objSqlParam[4].Value = objBEStudent.strPassword;
                objSqlParam[5] = new SqlParameter("@V_Gender", SqlDbType.VarChar, 50);
                objSqlParam[5].Value = objBEStudent.strGender;
                objSqlParam[6] = new SqlParameter("@I_SecQuestion1", SqlDbType.Int);
                objSqlParam[6].Value = objBEStudent.strQuestion1;
                objSqlParam[7] = new SqlParameter("@V_SecAnswer1", SqlDbType.VarChar, 100);
                objSqlParam[7].Value = objBEStudent.strAnswer1;
                objSqlParam[8] = new SqlParameter("@I_SecQuestion2", SqlDbType.Int);
                objSqlParam[8].Value = objBEStudent.strQuestion2;
                objSqlParam[9] = new SqlParameter("@V_SecAnswer2", SqlDbType.VarChar, 100);
                objSqlParam[9].Value = objBEStudent.strAnswer2;
                objSqlParam[10] = new SqlParameter("@I_SecQuestion3", SqlDbType.Int);
                objSqlParam[10].Value = objBEStudent.strQuestion3;
                objSqlParam[11] = new SqlParameter("@V_SecAnswer3", SqlDbType.VarChar, 100);
                objSqlParam[11].Value = objBEStudent.strAnswer3;
                objSqlParam[12] = new SqlParameter("@Flag", SqlDbType.Int);
                objSqlParam[12].Direction = ParameterDirection.Output;
                objSqlParam[13] = new SqlParameter("@I_PhoneNumber", SqlDbType.VarChar, 15);
                objSqlParam[13].Value = objBEStudent.strphoneNumber;
                objSqlParam[14] = new SqlParameter("@I_TimeZone", SqlDbType.Int);
                objSqlParam[14].Value = objBEStudent.strTimeZone;
                objSqlParam[15] = new SqlParameter("@I_PrefferedPhoneNumber", SqlDbType.VarChar, 15);
                objSqlParam[15].Value = objBEStudent.strPrefferedPhoneNumber;
                objSqlParam[16] = new SqlParameter("@I_UserID", SqlDbType.Int);
                objSqlParam[16].Direction = ParameterDirection.Output;


                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_STUDENT_StudentRegistartion, objSqlParam);

                objBEStudent.IntResult = Convert.ToInt32(objSqlParam[12].Value);
                objBEStudent.IntUserID = Convert.ToInt32(objSqlParam[16].Value);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        #region DExamService
        public void DGetExamDetails(BEStudent objBEStudent)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[1];
                objSqlParam[0] = new SqlParameter("@V_ExamTransID", SqlDbType.VarChar);
                objSqlParam[0].Value = objBEStudent.IntTransID.ToString();

                objBEStudent.DtResult = SQLHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Service_GetExamDetails, objSqlParam).Tables[0];
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion DExamService

        #region DUpdateExamTransactionStatus
        public void DUpdateExamStatus(BEStudent objBEStudent)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[2];
                objSqlParam[0] = new SqlParameter("@I_ExamTransID", SqlDbType.BigInt);
                objSqlParam[0].Value = objBEStudent.IntTransID;
                objSqlParam[1] = new SqlParameter("@I_Status", SqlDbType.Int);
                objSqlParam[1].Value = objBEStudent.IntstatusFlag;

                SQLHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Student_UpdateExamStatus, objSqlParam);
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion DUpdateExamStatus

        #region DGetUserName
        public void DGetUserName(BEStudent objBEStudent)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[1];
                objSqlParam[0] = new SqlParameter("@UserName", SqlDbType.VarChar, 50);
                objSqlParam[0].Value = objBEStudent.Struserlogin;

                objBEStudent.DtResult = SQLHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_STUDENT_GetUserName, objSqlParam).Tables[0];
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        public void DGetStudentExamDetails(BEStudent objBEStudent)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[1];
                objSqlParam[0] = new SqlParameter("@TransID", SqlDbType.BigInt);
                objSqlParam[0].Value = objBEStudent.IntTransID;

                objBEStudent.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.usp_getStudentExamDetails, objSqlParam).Tables[0];

            }

            catch (Exception Ex)
            {
                throw Ex;
            }

        }

        public void DsetExamCompleted(BEStudent objBEStudent)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[1];
                objSqlParam[0] = new SqlParameter("@TransID", SqlDbType.BigInt);
                objSqlParam[0].Value = objBEStudent.IntTransID;

                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.usp_setExamComplete, objSqlParam);

            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        #region DGetProviderCourses
        public void DGetProviderCourses(BEStudent objBEStudent)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[2];

                objSqlParam[0] = new SqlParameter("@I_ProviderID", SqlDbType.Int);
                objSqlParam[0].Value = objBEStudent.IntProviderID;
                objSqlParam[1] = new SqlParameter("@I_UserID", SqlDbType.Int);
                objSqlParam[1].Value = objBEStudent.IntStudentID;

                objBEStudent.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_GetProviderCourses, objSqlParam).Tables[0];
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        #region DGetIdentityValidation
        public void DGetIdentityValidation(BEStudent objBEStudent)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[2];

                objSqlParam[0] = new SqlParameter("@I_TransID", SqlDbType.BigInt);
                objSqlParam[0].Value = objBEStudent.IntTransID;
                objSqlParam[1] = new SqlParameter("@B_StudentIdentity", SqlDbType.Bit);
                objSqlParam[1].Direction = ParameterDirection.Output;

                SQLHelper.ExecuteScalar(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_GetIdentityValidation, objSqlParam);
                objBEStudent.StudentIdentity = Convert.ToBoolean(objSqlParam[1].Value.ToString());
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion DGetIdentityValidation



        public void DStudent_ValidateExam(BEStudent objBEStudent)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[10];

                objSqlParam[0] = new SqlParameter("@UserID", SqlDbType.Int);
                objSqlParam[0].Value = objBEStudent.IntUserID;
                objSqlParam[1] = new SqlParameter("@CourseID", SqlDbType.Int);
                objSqlParam[1].Value = objBEStudent.IntCourseID;
                objSqlParam[2] = new SqlParameter("@ExamID", SqlDbType.Int);
                objSqlParam[2].Value = objBEStudent.IntExamID;
                objSqlParam[3] = new SqlParameter("@ExamDate", SqlDbType.DateTime);
                objSqlParam[3].Value = objBEStudent.dtExam;
                objSqlParam[4] = new SqlParameter("@OnDemand", SqlDbType.Int);
                objSqlParam[4].Value = objBEStudent.intOndemand;
                objSqlParam[5] = new SqlParameter("@I_Result", SqlDbType.Int);
                objSqlParam[5].Direction = ParameterDirection.Output;
                objSqlParam[6] = new SqlParameter("@ExamFee", SqlDbType.Decimal);
                objSqlParam[6].Precision = 5;
                objSqlParam[6].Scale = 2;
                objSqlParam[6].Direction = ParameterDirection.Output;
                objSqlParam[7] = new SqlParameter("@OnDemandFee", SqlDbType.Decimal);
                objSqlParam[7].Precision = 5;
                objSqlParam[7].Scale = 2;
                objSqlParam[7].Direction = ParameterDirection.Output;
                objSqlParam[8] = new SqlParameter("@TotalExamFee", SqlDbType.Decimal);
                objSqlParam[8].Precision = 5;
                objSqlParam[8].Scale = 2;
                objSqlParam[8].Direction = ParameterDirection.Output;
                objSqlParam[9] = new SqlParameter("@PerHourFee", SqlDbType.Decimal);
                objSqlParam[9].Precision = 5;
                objSqlParam[9].Scale = 2;
                objSqlParam[9].Direction = ParameterDirection.Output;
                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Student_ScheduleExam_Validate, objSqlParam);

                objBEStudent.IntResult = Convert.ToInt32(objSqlParam[5].Value.ToString());
                objBEStudent.decExamFee = Convert.ToDecimal(objSqlParam[6].Value.ToString());
                objBEStudent.decOnDemandFee = Convert.ToDecimal(objSqlParam[7].Value.ToString());
                objBEStudent.decAmount = Convert.ToDecimal(objSqlParam[8].Value.ToString());
                objBEStudent.PerHourFee = Convert.ToDecimal(objSqlParam[9].Value.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void DStudent_ValidateRescheduledExam(BEStudent objBEStudent)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[9];

                objSqlParam[0] = new SqlParameter("@UserID", SqlDbType.Int);
                objSqlParam[0].Value = objBEStudent.IntUserID;
                objSqlParam[1] = new SqlParameter("@TransID", SqlDbType.BigInt);
                objSqlParam[1].Value = objBEStudent.IntScheduleID;             
                objSqlParam[2] = new SqlParameter("@ExamDate", SqlDbType.DateTime);
                objSqlParam[2].Value = objBEStudent.dtExam;
                objSqlParam[3] = new SqlParameter("@OnDemand", SqlDbType.Int);
                objSqlParam[3].Value = objBEStudent.intOndemand;
                objSqlParam[4] = new SqlParameter("@I_Result", SqlDbType.Int);
                objSqlParam[4].Direction = ParameterDirection.Output;
                objSqlParam[5] = new SqlParameter("@ExamFee", SqlDbType.Decimal);
                objSqlParam[5].Precision = 5;
                objSqlParam[5].Scale = 2;
                objSqlParam[5].Direction = ParameterDirection.Output;
                objSqlParam[6] = new SqlParameter("@OnDemandFee", SqlDbType.Decimal);
                objSqlParam[6].Precision = 5;
                objSqlParam[6].Scale = 2;
                objSqlParam[6].Direction = ParameterDirection.Output;
                objSqlParam[7] = new SqlParameter("@TotalExamFee", SqlDbType.Decimal);
                objSqlParam[7].Precision = 5;
                objSqlParam[7].Scale = 2;
                objSqlParam[7].Direction = ParameterDirection.Output;
                objSqlParam[8] = new SqlParameter("@PerHourFee", SqlDbType.Decimal);
                objSqlParam[8].Precision = 5;
                objSqlParam[8].Scale = 2;
                objSqlParam[8].Direction = ParameterDirection.Output;

                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Student_ExamReschedule_Validate, objSqlParam);

                objBEStudent.IntResult = Convert.ToInt32(objSqlParam[4].Value.ToString());
                objBEStudent.decExamFee = Convert.ToDecimal(objSqlParam[5].Value.ToString());
                objBEStudent.decOnDemandFee = Convert.ToDecimal(objSqlParam[6].Value.ToString());
                objBEStudent.decAmount = Convert.ToDecimal(objSqlParam[7].Value.ToString());
                objBEStudent.PerHourFee = Convert.ToDecimal(objSqlParam[8].Value.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        public void DStudent_ScheduleExam(BEStudent objBEStudent)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[8];

                objSqlParam[0] = new SqlParameter("@UserID", SqlDbType.Int);
                objSqlParam[0].Value = objBEStudent.IntUserID;
                objSqlParam[1] = new SqlParameter("@CourseID", SqlDbType.Int);
                objSqlParam[1].Value = objBEStudent.IntCourseID;
                objSqlParam[2] = new SqlParameter("@ExamID", SqlDbType.Int);
                objSqlParam[2].Value = objBEStudent.IntExamID;
                objSqlParam[3] = new SqlParameter("@ExamDate", SqlDbType.DateTime);
                objSqlParam[3].Value = objBEStudent.dtExam;
                objSqlParam[4] = new SqlParameter("@OnDemand", SqlDbType.Int);
                objSqlParam[4].Value = objBEStudent.intOndemand;              
                objSqlParam[5] = new SqlParameter("@ExamFee", SqlDbType.Decimal);
                objSqlParam[5].Precision = 5;
                objSqlParam[5].Scale = 2;
                objSqlParam[5].Direction = ParameterDirection.Output;
                objSqlParam[6] = new SqlParameter("@OnDemandFee", SqlDbType.Decimal);
                objSqlParam[6].Precision = 5;
                objSqlParam[6].Scale = 2;
                objSqlParam[6].Direction = ParameterDirection.Output;
                objSqlParam[7] = new SqlParameter("@PerHourFee", SqlDbType.Decimal);
                objSqlParam[7].Precision = 5;
                objSqlParam[7].Scale = 2;
                objSqlParam[7].Direction = ParameterDirection.Output;
                
                objBEStudent.DsResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Student_ScheduleExam, objSqlParam);

             
                objBEStudent.decExamFee = Convert.ToDecimal(objSqlParam[5].Value.ToString());
                objBEStudent.decOnDemandFee = Convert.ToDecimal(objSqlParam[6].Value.ToString());
                objBEStudent.PerHourFee = Convert.ToDecimal(objSqlParam[7].Value.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void DStudent_ScheduleExamOnDemand(BEStudent objBEStudent)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[4];
                objSqlParam[0] = new SqlParameter("@UserID", SqlDbType.Int);
                objSqlParam[0].Value = objBEStudent.IntUserID;
                objSqlParam[1] = new SqlParameter("@CourseID", SqlDbType.Int);
                objSqlParam[1].Value = objBEStudent.IntCourseID;
                objSqlParam[2] = new SqlParameter("@ExamID", SqlDbType.Int);
                objSqlParam[2].Value = objBEStudent.IntExamID;
                objSqlParam[3] = new SqlParameter("@ExamDate", SqlDbType.DateTime);
                objSqlParam[3].Value = objBEStudent.dtExam;
                objBEStudent.DsResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Student_ScheduleExam_OnDemand, objSqlParam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DStudent_ReScheduleExamOnDemand(BEStudent objBEStudent)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[7];

                objSqlParam[0] = new SqlParameter("@UserID", SqlDbType.Int);
                objSqlParam[0].Value = objBEStudent.IntUserID;
                objSqlParam[1] = new SqlParameter("@TransID", SqlDbType.BigInt); // schedule id here
                objSqlParam[1].Value = objBEStudent.IntScheduleID;
                objSqlParam[2] = new SqlParameter("@ExamDate", SqlDbType.DateTime);
                objSqlParam[2].Value = objBEStudent.dtExam;
                objSqlParam[3] = new SqlParameter("@V_Description", SqlDbType.VarChar);
                objSqlParam[3].Value = objBEStudent.strDescription;

                objBEStudent.DsResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Student_ReScheduleExam_OnDemand, objSqlParam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void DStudent_UpdateScheduleExam(BEStudent objBEStudent)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[8];

                objSqlParam[0] = new SqlParameter("@UserID", SqlDbType.Int);
                objSqlParam[0].Value = objBEStudent.IntUserID;
                objSqlParam[1] = new SqlParameter("@TransID", SqlDbType.BigInt); // schedule id here
                objSqlParam[1].Value = objBEStudent.IntScheduleID;
                objSqlParam[2] = new SqlParameter("@ExamDate", SqlDbType.DateTime);
                objSqlParam[2].Value = objBEStudent.dtExam;
                objSqlParam[3] = new SqlParameter("@V_Description", SqlDbType.VarChar);
                objSqlParam[3].Value = objBEStudent.strDescription;
                objSqlParam[4] = new SqlParameter("@OnDemand", SqlDbType.Int);
                objSqlParam[4].Value = objBEStudent.intOndemand;
                objSqlParam[5] = new SqlParameter("@ExamFee", SqlDbType.Decimal);
                objSqlParam[5].Direction = ParameterDirection.Output;
                objSqlParam[6] = new SqlParameter("@OnDemandFee", SqlDbType.Decimal);
                objSqlParam[6].Direction = ParameterDirection.Output;

                objSqlParam[7] = new SqlParameter("@PerHourFee", SqlDbType.Decimal);
                objSqlParam[7].Direction = ParameterDirection.Output;

                objBEStudent.DsResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Student_ReScheduleExam, objSqlParam);

                objBEStudent.decExamFee = Convert.ToDecimal(objSqlParam[5].Value.ToString());
                objBEStudent.decOnDemandFee = Convert.ToDecimal(objSqlParam[6].Value.ToString());
                objBEStudent.PerHourFee = Convert.ToDecimal(objSqlParam[7].Value.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region DStudentOnDemandScheduleExam

        public void DStudent_OnDemandScheduleExam(BEStudent objBEStudent)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[4];
                objSqlParam[0] = new SqlParameter("@UserID", SqlDbType.Int);
                objSqlParam[0].Value = objBEStudent.IntUserID;
                objSqlParam[1] = new SqlParameter("@CourseID", SqlDbType.Int);
                objSqlParam[1].Value = objBEStudent.IntCourseID;
                objSqlParam[2] = new SqlParameter("@ExamID", SqlDbType.Int);
                objSqlParam[2].Value = objBEStudent.IntExamID;
                objSqlParam[3] = new SqlParameter("@ExamDate", SqlDbType.DateTime);
                objSqlParam[3].Value = objBEStudent.dtExam;
                objBEStudent.DsResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Student_OnDemandScheduleExam, objSqlParam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region DStudentGetAmountForDemandSchedule

        public void DStudent_GetAmountForDemandSchedule(BEStudent objBEStudent)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[2];
                objSqlParam[0] = new SqlParameter("@Hours", SqlDbType.Int);
                objSqlParam[0].Value = objBEStudent.intHours;
                objSqlParam[1] = new SqlParameter("@Amount", SqlDbType.Decimal);
                objSqlParam[1].Precision = 5;
                objSqlParam[1].Scale = 2;
                objSqlParam[1].Direction = ParameterDirection.Output;
                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Student_GetAmountForDemandSchedule, objSqlParam);
                objBEStudent.decAmount = Convert.ToDecimal(objSqlParam[1].Value.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region DGetExamStartEndDates
        public void DGetExamStartEndDates(BEStudent obj)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[3];

                objSqlParam[0] = new SqlParameter("@I_ExamID", SqlDbType.Int);
                objSqlParam[0].Value = obj.IntExamID;
                objSqlParam[1] = new SqlParameter("@I_TransID", SqlDbType.BigInt);
                objSqlParam[1].Value = obj.IntTransID;
                objSqlParam[2] = new SqlParameter("@I_UserID", SqlDbType.Int);
                objSqlParam[2].Value = obj.IntUserID;
                obj.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_STUDENT_GetExamStartEndDates, objSqlParam).Tables[0];
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        #region DGetExamScheduledDate
        public void DGetExamScheduledDate(BEStudent objBEStudent)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[3];

                objSqlParam[0] = new SqlParameter("@I_ExamID", SqlDbType.Int);
                objSqlParam[0].Value = objBEStudent.IntExamID;
                objSqlParam[1] = new SqlParameter("@I_UserID", SqlDbType.Int);
                objSqlParam[1].Value = objBEStudent.IntUserID;
                objSqlParam[2] = new SqlParameter("@I_CourseID", SqlDbType.Int);
                objSqlParam[2].Value = objBEStudent.IntCourseID;
                objBEStudent.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_STUDENT_GetExamScheduledDate, objSqlParam).Tables[0];
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        #region DDeleteAppointment
        public void DDeleteAppointment(BEStudent objBEStudent)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[2];

                objSqlParam[0] = new SqlParameter("@I_TransID", SqlDbType.BigInt);
                objSqlParam[0].Value = objBEStudent.IntTransID;
                objSqlParam[1] = new SqlParameter("@I_UserID", SqlDbType.Int);
                objSqlParam[1].Value = objBEStudent.IntUserID;

                objBEStudent.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_STUDENT_DeleteAppointment, objSqlParam).Tables[0];
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        #region DValidateStudentProfileSettings
        public void DValidateStudentProfileSettings(BEStudent objBEStudent)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[4];

                objSqlParam[0] = new SqlParameter("@I_UserID", SqlDbType.Int);
                objSqlParam[0].Value = objBEStudent.IntUserID;
                objSqlParam[1] = new SqlParameter("@I_FlagPhotoIdentity", SqlDbType.Int);
                objSqlParam[1].Direction = ParameterDirection.Output;
                objSqlParam[2] = new SqlParameter("@I_FlagSecurityQuestions", SqlDbType.Int);
                objSqlParam[2].Direction = ParameterDirection.Output;
                objSqlParam[3] = new SqlParameter("@I_FlagPhoneNumber", SqlDbType.Int);
                objSqlParam[3].Direction = ParameterDirection.Output;

                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_Student_ValidateProfileSettings", objSqlParam);

                objBEStudent.intFlagPhotoIdentity = Convert.ToInt32(objSqlParam[1].Value.ToString());
                objBEStudent.intFlagSecurityQuestions = Convert.ToInt32(objSqlParam[2].Value.ToString());
                objBEStudent.intFlagPhoneNUmber = Convert.ToInt32(objSqlParam[3].Value.ToString());
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        public void DCheckExamStartTime(BEStudent objBEStudent)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[2];

                objSqlParam[0] = new SqlParameter("@TransID", SqlDbType.BigInt);
                objSqlParam[0].Value = objBEStudent.IntTransID;

                objSqlParam[1] = new SqlParameter("@UserID", SqlDbType.Int);
                objSqlParam[1].Value = objBEStudent.IntUserID;

                objBEStudent.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Student_CheckExamStartTime, objSqlParam).Tables[0];

            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void DCheckexamiKEY(BEStudent objBEStudent)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[2];

                objSqlParam[0] = new SqlParameter("@TransID", SqlDbType.BigInt);
                objSqlParam[0].Value = objBEStudent.IntTransID;

                objSqlParam[1] = new SqlParameter("@UserID", SqlDbType.Int);
                objSqlParam[1].Value = objBEStudent.IntUserID;

                objBEStudent.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_Student_CheckexamiKEY", objSqlParam).Tables[0];

            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void DValidateUploadandQuestions(BEStudent objBEStudent)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[2];

                objSqlParam[0] = new SqlParameter("@StudentID", SqlDbType.Int);
                objSqlParam[0].Value = objBEStudent.IntUserID;
                 objSqlParam[1] = new SqlParameter("@SSO", SqlDbType.Bit);
                objSqlParam[1].Direction = ParameterDirection.Output;

                objBEStudent.DsResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Student_MyProfile_ValidatePictureandSecurityQuestions, objSqlParam);

                objBEStudent.BoolResult =Convert.ToBoolean(objSqlParam[1].Value.ToString());
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void DGetStudentName(BEStudent objBEStudent)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[1];

                objSqlParam[0] = new SqlParameter("@I_UserID", SqlDbType.BigInt);
                objSqlParam[0].Value = objBEStudent.IntUserID;

                objBEStudent.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_Student_GetStudentName", objSqlParam).Tables[0];
            }

            catch (Exception Ex)
            {
                throw Ex;
            }

        }

        public void DGetExamiBadge(BEStudent objBEStudent)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[3];

                objSqlParam[0] = new SqlParameter("@UserID", SqlDbType.Int);
                objSqlParam[0].Value = objBEStudent.IntUserID;

                objSqlParam[1] = new SqlParameter("@BadgeType", SqlDbType.VarChar, 250);
                objSqlParam[1].Direction = ParameterDirection.Output;

                objSqlParam[2] = new SqlParameter("@BadgeCount", SqlDbType.Int);
                objSqlParam[2].Direction = ParameterDirection.Output;



                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_Student_UpdateExamiBADGECount", objSqlParam);

                objBEStudent.StrResult = objSqlParam[1].Value.ToString();
                objBEStudent.IntResult =Convert.ToInt32(objSqlParam[2].Value);
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void DSetStudentStartExamFlag(BEStudent objBEStudent)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[1];

                objSqlParam[0] = new SqlParameter("@TransID", SqlDbType.BigInt);
                objSqlParam[0].Value = objBEStudent.IntTransID;

                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_Student_SetStudentStartExamFlag", objSqlParam);
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        public void DSetPaymentDetails_Scheduled(BEStudent objBEStudent)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[7];

                objSqlParam[0] = new SqlParameter("@TransID", SqlDbType.BigInt);
                objSqlParam[0].Value = objBEStudent.IntTransID;
                objSqlParam[1] = new SqlParameter("@Type", SqlDbType.VarChar, 50);
                objSqlParam[1].Value = "Scheduled";
                objSqlParam[2] = new SqlParameter("@ExamFee", SqlDbType.Decimal);
                objSqlParam[2].Precision = 5;
                objSqlParam[2].Scale = 2;
                objSqlParam[2].Value = objBEStudent.decExamFee;
                objSqlParam[3] = new SqlParameter("@OnDemandFee", SqlDbType.Decimal);
                objSqlParam[3].Precision = 5;
                objSqlParam[3].Scale = 2;
                objSqlParam[3].Value = objBEStudent.decOnDemandFee;
                objSqlParam[4] = new SqlParameter("@ExamFee_PaidBy", SqlDbType.Int);
                objSqlParam[4].Value = objBEStudent.intExamFeePaidBy;
                objSqlParam[5] = new SqlParameter("@OndemandFee_PaidBy", SqlDbType.Int);
                objSqlParam[5].Value = objBEStudent.intOndemandPaidBy;
                objSqlParam[6] = new SqlParameter("@OrderID", SqlDbType.VarChar, 50);
                objSqlParam[6].Value = objBEStudent.strOrderID;

                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_Student_Schedule_LogPaymentDetails", objSqlParam);
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void DSetPaymentDetails_Recheduled(BEStudent objBEStudent)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[7];

                objSqlParam[0] = new SqlParameter("@TransID", SqlDbType.BigInt);
                objSqlParam[0].Value = objBEStudent.IntTransID;
                objSqlParam[1] = new SqlParameter("@Type", SqlDbType.VarChar, 50);
                objSqlParam[1].Value = "Rescheduled";
                objSqlParam[2] = new SqlParameter("@ExamFee", SqlDbType.Decimal);
                objSqlParam[2].Precision = 5;
                objSqlParam[2].Scale = 2;
                objSqlParam[2].Value = objBEStudent.decExamFee;
                objSqlParam[3] = new SqlParameter("@OnDemandFee", SqlDbType.Decimal);
                objSqlParam[3].Precision = 5;
                objSqlParam[3].Scale = 2;
                objSqlParam[3].Value = objBEStudent.decOnDemandFee;
                objSqlParam[4] = new SqlParameter("@ExamFee_PaidBy", SqlDbType.Int);
                objSqlParam[4].Value = objBEStudent.intExamFeePaidBy;
                objSqlParam[5] = new SqlParameter("@OndemandFee_PaidBy", SqlDbType.Int);
                objSqlParam[5].Value = objBEStudent.intOndemandPaidBy;
                objSqlParam[6] = new SqlParameter("@OrderID", SqlDbType.VarChar, 50);
                objSqlParam[6].Value = objBEStudent.strOrderID;

                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_Student_Schedule_LogPaymentDetails", objSqlParam);
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        public void DGetCourseAndExam(BEStudent objBEStudent)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[1];

                objSqlParam[0] = new SqlParameter("@TransID", SqlDbType.BigInt);
                objSqlParam[0].Value = objBEStudent.IntScheduleID;

                objBEStudent.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, "usp_student_getCourseAndExam", objSqlParam).Tables[0];
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void DGetExamDetailsByTransID(BEStudent objBEStudent)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[1];

                objSqlParam[0] = new SqlParameter("@I_TransID", SqlDbType.BigInt);
                objSqlParam[0].Value = objBEStudent.IntTransID;

                objBEStudent.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_GetExamDetailsByTransID, objSqlParam).Tables[0];
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void DGetRandomQuestion(BEStudent objBEStudent)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[1];

                objSqlParam[0] = new SqlParameter("@UserID", SqlDbType.BigInt);
                objSqlParam[0].Value = objBEStudent.IntUserID;

             

                objBEStudent.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_GetRandomSecurityQuestion, objSqlParam).Tables[0];
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void DSaveStudentUploads(BEStudent objBEStudent)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[3];

                objSqlParam[0] = new SqlParameter("@TransID", SqlDbType.BigInt);
                objSqlParam[0].Value = objBEStudent.IntTransID;
                objSqlParam[1] = new SqlParameter("@StudentID", SqlDbType.BigInt);
                objSqlParam[1].Value = objBEStudent.IntStudentID;
                objSqlParam[2] = new SqlParameter("@Files", SqlDbType.Structured);
                objSqlParam[2].Value = objBEStudent.DtResult;

                objBEStudent.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Student_SaveUploadFiles, objSqlParam).Tables[0];
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void DGetCourseDetailsByExamID(BEStudent objBEStudent)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[2];

                objSqlParam[0] = new SqlParameter("@I_ExamID", SqlDbType.BigInt);
                objSqlParam[0].Value = objBEStudent.IntExamID;

                objSqlParam[1] = new SqlParameter("@I_Flag", SqlDbType.Int);
                objSqlParam[1].Value = objBEStudent.IntFlag;

                objBEStudent.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, "usp_Student_GetExamDetails", objSqlParam).Tables[0];
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        public void DStudentDeleteUploadedFile(BEStudent objBEStudent)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[2];

                objSqlParam[0] = new SqlParameter("@TransID", SqlDbType.BigInt);
                objSqlParam[0].Value = objBEStudent.IntTransID;
                objSqlParam[1] = new SqlParameter("@StoredFileName", SqlDbType.VarChar,250);
                objSqlParam[1].Value = objBEStudent.strOriginalFileName;


             SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Student_DeleteUploadedFile, objSqlParam);
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void DGetAccessibility(BEStudent objBEStudent)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[3];

                objSqlParam[0] = new SqlParameter("@I_UserID", SqlDbType.BigInt);
                objSqlParam[0].Value = objBEStudent.IntStudentID;
                objSqlParam[1] = new SqlParameter("@I_Accessibility", SqlDbType.Int);
                objSqlParam[1].Direction = ParameterDirection.Output;
                objSqlParam[2] = new SqlParameter("@I_StudentAccessibility", SqlDbType.Int);
                objSqlParam[2].Direction = ParameterDirection.Output;

                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_Common_GetAccessibility", objSqlParam);

                objBEStudent.IntResult = Convert.ToInt32(objSqlParam[1].Value.ToString());
                objBEStudent.IntFlag = Convert.ToInt32(objSqlParam[2].Value.ToString());
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        public void DGetExamTimes(BEStudent objBEStudent)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[8];

                objSqlParam[0] = new SqlParameter("@I_UserID", SqlDbType.BigInt);
                objSqlParam[0].Value = objBEStudent.IntUserID;
                objSqlParam[1] = new SqlParameter("@I_ExamID", SqlDbType.BigInt);
                objSqlParam[1].Value = objBEStudent.IntExamID;
                objSqlParam[2] = new SqlParameter("@I_Type", SqlDbType.Int);
                objSqlParam[2].Value = objBEStudent.IntType;
                objSqlParam[3] = new SqlParameter("@I_Year", SqlDbType.Int);
                objSqlParam[3].Value = objBEStudent.intYear;
                objSqlParam[4] = new SqlParameter("@I_Month", SqlDbType.Int);
                objSqlParam[4].Value = objBEStudent.intMonth;
                objSqlParam[5] = new SqlParameter("@I_OnDemand", SqlDbType.Int);
                objSqlParam[5].Value = objBEStudent.intOndemand;
                objSqlParam[6] = new SqlParameter("@I_Start", SqlDbType.Int);
                objSqlParam[6].Direction = ParameterDirection.Output;
                objSqlParam[7] = new SqlParameter("@I_End", SqlDbType.Int);
                objSqlParam[7].Direction = ParameterDirection.Output;

                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_Common_GetExamTimes", objSqlParam);

                objBEStudent.intStart = Convert.ToInt32(objSqlParam[6].Value.ToString());
                objBEStudent.intEnd = Convert.ToInt32(objSqlParam[7].Value.ToString());
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void DUpdateAccessibility(BEStudent objBEStudent)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[2];

                objSqlParam[0] = new SqlParameter("@I_UserID", SqlDbType.BigInt);
                objSqlParam[0].Value = objBEStudent.IntStudentID;
                objSqlParam[1] = new SqlParameter("@I_Accessibility", SqlDbType.Int);
                objSqlParam[1].Value = objBEStudent.IntResult;

                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_Common_UpdateAccessibility", objSqlParam);
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        public void DGetCourseAndExamDetails(BEStudent objBEStudent)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[1];

                objSqlParam[0] = new SqlParameter("@I_TransID", SqlDbType.BigInt);
                objSqlParam[0].Value = objBEStudent.IntTransID;

                objBEStudent.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, "usp_GetCourseAndExam", objSqlParam).Tables[0];
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        public void DCheckExamBoundaries(BEStudent objBEStudent)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[4];

                objSqlParam[0] = new SqlParameter("@UserID", SqlDbType.Int);
                objSqlParam[0].Value = objBEStudent.IntUserID;
                objSqlParam[1] = new SqlParameter("@CourseID", SqlDbType.Int);
                objSqlParam[1].Value = objBEStudent.IntCourseID;
                objSqlParam[2] = new SqlParameter("@ExamID", SqlDbType.Int);
                objSqlParam[2].Value = objBEStudent.IntExamID;
                objSqlParam[3] = new SqlParameter("@ExamDate", SqlDbType.DateTime);
                objSqlParam[3].Value = objBEStudent.dtExam;
           
                //objSqlParam[4] = new SqlParameter("@I_Result", SqlDbType.Int);
                //objSqlParam[4].Direction = ParameterDirection.Output;
                //objSqlParam[5] = new SqlParameter("@ExamStartDate", SqlDbType.DateTime);
                //objSqlParam[5].Direction = ParameterDirection.Output;
                //objSqlParam[6] = new SqlParameter("@ExamEndDate", SqlDbType.DateTime);
                //objSqlParam[6].Direction = ParameterDirection.Output;


                objBEStudent.DsResult=SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Student_CheckExamBoundaries, objSqlParam);
      


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void DCheckExamBoundariesReschedule(BEStudent objBEStudent)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[3];

                objSqlParam[0] = new SqlParameter("@UserID", SqlDbType.Int);
                objSqlParam[0].Value = objBEStudent.IntUserID;
                objSqlParam[1] = new SqlParameter("@ExamDate", SqlDbType.DateTime);
                objSqlParam[1].Value = objBEStudent.dtExam;
                objSqlParam[2] = new SqlParameter("@TransID", SqlDbType.BigInt);
                objSqlParam[2].Value = objBEStudent.IntTransID;
                //objSqlParam[4] = new SqlParameter("@I_Result", SqlDbType.Int);
                //objSqlParam[4].Direction = ParameterDirection.Output;
                //objSqlParam[5] = new SqlParameter("@ExamStartDate", SqlDbType.DateTime);
                //objSqlParam[5].Direction = ParameterDirection.Output;
                //objSqlParam[6] = new SqlParameter("@ExamEndDate", SqlDbType.DateTime);
                //objSqlParam[6].Direction = ParameterDirection.Output;


                objBEStudent.DsResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Student_CheckExamBoundariesReschedule, objSqlParam);



            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DGetExamFeeSettingsByExamID(BEStudent objBEStudent)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[4];

                objSqlParam[0] = new SqlParameter("@I_ExamID", SqlDbType.BigInt);
                objSqlParam[0].Value = objBEStudent.IntExamID1;
                objSqlParam[1] = new SqlParameter("@I_ExamFeePaidBy", SqlDbType.Int);
                objSqlParam[1].Direction = ParameterDirection.Output;
                objSqlParam[2] = new SqlParameter("@I_OnDemandFeePaidBy", SqlDbType.Int);
                objSqlParam[2].Direction = ParameterDirection.Output;
                objSqlParam[3] = new SqlParameter("@I_UserID", SqlDbType.Int);
                objSqlParam[3].Value = objBEStudent.IntUserID;

                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Student_USP_GetExamFeeSettingsByExamID, objSqlParam);

                objBEStudent.intExamFeePaidBy = Convert.ToInt32(objSqlParam[1].Value.ToString());
                objBEStudent.intOndemandPaidBy = Convert.ToInt32(objSqlParam[2].Value.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DGetExamFeeSettingsByTransID(BEStudent objBEStudent)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[3];

                objSqlParam[0] = new SqlParameter("@I_TransID", SqlDbType.BigInt);
                objSqlParam[0].Value = objBEStudent.IntExamID1;
                objSqlParam[1] = new SqlParameter("@I_ExamFeePaidBy", SqlDbType.Int);
                objSqlParam[1].Direction = ParameterDirection.Output;
                objSqlParam[2] = new SqlParameter("@I_OnDemandFeePaidBy", SqlDbType.Int);
                objSqlParam[2].Direction = ParameterDirection.Output;

                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Student_USP_GetExamFeeSettingsByTransID, objSqlParam);

                objBEStudent.intExamFeePaidBy = Convert.ToInt32(objSqlParam[1].Value.ToString());
                objBEStudent.intOndemandPaidBy = Convert.ToInt32(objSqlParam[2].Value.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DGetExamSessionIDWithPrefix(BEStudent objBEStudent)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[6];

                objSqlParam[0] = new SqlParameter("@TransID", SqlDbType.BigInt);
                objSqlParam[0].Value = objBEStudent.IntTransID;
                objSqlParam[1] = new SqlParameter("@SessionID", SqlDbType.VarChar, 100);
                objSqlParam[1].Direction = ParameterDirection.Output;
                objSqlParam[2] = new SqlParameter("@UserName", SqlDbType.VarChar, 100);
                objSqlParam[2].Direction = ParameterDirection.Output;
                objSqlParam[3] = new SqlParameter("@Password", SqlDbType.VarChar, 100);
                objSqlParam[3].Direction = ParameterDirection.Output;
                objSqlParam[4] = new SqlParameter("@StudentName", SqlDbType.VarChar, 100);
                objSqlParam[4].Direction = ParameterDirection.Output;
                objSqlParam[5] = new SqlParameter("@StudentEmailID", SqlDbType.VarChar, 100);
                objSqlParam[5].Direction = ParameterDirection.Output;

                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_Student_GetExamSessionID", objSqlParam);

                objBEStudent.strSessionID = objSqlParam[1].Value.ToString();
                objBEStudent.strUserName = objSqlParam[2].Value.ToString();
                objBEStudent.strPassword = objSqlParam[3].Value.ToString();
                objBEStudent.strStudentName = objSqlParam[4].Value.ToString();
                objBEStudent.StrEmail = objSqlParam[5].Value.ToString();
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void DUpdateProceedTime(BEStudent objBEStudent)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[1];

                objSqlParam[0] = new SqlParameter("@TransID", SqlDbType.BigInt);
                objSqlParam[0].Value = objBEStudent.IntTransID;


                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_Student_UpdateProceedTime", objSqlParam);


            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void DUpdateNextButtonTime(BEStudent objBEStudent)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[1];

                objSqlParam[0] = new SqlParameter("@TransID", SqlDbType.BigInt);
                objSqlParam[0].Value = objBEStudent.IntTransID;


                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_Student_UpdateNextTime", objSqlParam);


            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void DUpdateExamiKEYScore(BEStudent objBEStudent)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[3];

                objSqlParam[0] = new SqlParameter("@TransID", SqlDbType.BigInt);
                objSqlParam[0].Value = objBEStudent.IntTransID;
                objSqlParam[1] = new SqlParameter("@KeyScore", SqlDbType.BigInt);
                objSqlParam[1].Value = objBEStudent.intExamiKeyScore;
                objSqlParam[2] = new SqlParameter("@result", SqlDbType.VarChar, 500);
                objSqlParam[2].Direction = ParameterDirection.Output;

                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_Student_UpdateExamiKeyScore", objSqlParam);

                objBEStudent.StrResult = objSqlParam[2].Value.ToString();
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void DUpdatePLTime(BEStudent objBEStudent)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[2];

                objSqlParam[0] = new SqlParameter("@TransID", SqlDbType.BigInt);
                objSqlParam[0].Value = objBEStudent.IntTransID;
                objSqlParam[1] = new SqlParameter("@TypeID", SqlDbType.BigInt);
                objSqlParam[1].Value = objBEStudent.IntType;



                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_Student_UpdateCaptureImageTime", objSqlParam);


            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void DGetEmailID(BEStudent objBEStudent)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[2];

                objSqlParam[0] = new SqlParameter("@UserID", SqlDbType.BigInt);
                objSqlParam[0].Value = objBEStudent.IntUserID;

                objSqlParam[1] = new SqlParameter("@EmailID", SqlDbType.VarChar, 100);
                objSqlParam[1].Direction = ParameterDirection.Output;

                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_Student_GetEmailID", objSqlParam);

                objBEStudent.StrEmail = objSqlParam[1].Value.ToString();
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void DSetAuthenticationCode(BEStudent objBEStudent)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[2];

                objSqlParam[0] = new SqlParameter("@Code", SqlDbType.VarChar, 100);
                objSqlParam[0].Value = objBEStudent.strPassword;
                objSqlParam[1] = new SqlParameter("@TransID", SqlDbType.BigInt);
                objSqlParam[1].Value = objBEStudent.IntTransID;

                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_Student_SetAuthenticationCode", objSqlParam);


            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        public void DValidateAuthenticationCode(BEStudent objBEStudent)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[3];

                objSqlParam[0] = new SqlParameter("@Code", SqlDbType.VarChar, 100);
                objSqlParam[0].Value = objBEStudent.strPassword;
                objSqlParam[1] = new SqlParameter("@TransID", SqlDbType.BigInt);
                objSqlParam[1].Value = objBEStudent.IntTransID;
                objSqlParam[2] = new SqlParameter("@flag", SqlDbType.Int);
                objSqlParam[2].Direction = ParameterDirection.Output;

                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_Student_ValidateAuthenticationCode", objSqlParam);
                objBEStudent.IntResult = Convert.ToInt32(objSqlParam[2].Value);


            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        public void DUpdateNonProctorExamStatus(BEStudent objBEStudent)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[2];
                objSqlParam[0] = new SqlParameter("@I_TransID", SqlDbType.BigInt);
                objSqlParam[0].Value = objBEStudent.IntTransID;
                objSqlParam[1] = new SqlParameter("@Type", SqlDbType.BigInt);
                objSqlParam[1].Value = objBEStudent.IntResult;

                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_Student_UpdateNonProctorExamStatus", objSqlParam);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region DValidateStudentExam
        public void DValidateStudentExam(BEStudent objBEStudent)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[5];

                objSqlParam[0] = new SqlParameter("@I_UserID", SqlDbType.BigInt);
                objSqlParam[0].Value = objBEStudent.IntUserID;
                objSqlParam[1] = new SqlParameter("@I_ExamID", SqlDbType.Int);
                objSqlParam[1].Value = objBEStudent.IntExamID;
                objSqlParam[2] = new SqlParameter("@I_Result", SqlDbType.Int);
                objSqlParam[2].Direction = ParameterDirection.Output;
                objSqlParam[3] = new SqlParameter("@I_TransID", SqlDbType.BigInt);
                objSqlParam[3].Direction = ParameterDirection.Output;
                objSqlParam[4] = new SqlParameter("@V_ExamDate", SqlDbType.VarChar, 50);
                objSqlParam[4].Direction = ParameterDirection.Output;


                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_Student_ValidateStudentExam", objSqlParam);

                objBEStudent.IntResult = Convert.ToInt32(objSqlParam[2].Value.ToString());
                objBEStudent.IntTransID = Convert.ToInt64(objSqlParam[3].Value.ToString());
                objBEStudent.strExamDate = objSqlParam[4].Value.ToString();
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        public void DValidatePLExam(BEStudent objBEStudent)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[4];

                objSqlParam[0] = new SqlParameter("@I_UserID", SqlDbType.BigInt);
                objSqlParam[0].Value = objBEStudent.IntUserID;
                objSqlParam[1] = new SqlParameter("@I_ExamID", SqlDbType.Int);
                objSqlParam[1].Value = objBEStudent.IntExamID;
                objSqlParam[2] = new SqlParameter("@I_Result", SqlDbType.Int);
                objSqlParam[2].Direction = ParameterDirection.Output;
                objSqlParam[3] = new SqlParameter("@V_ExamDate", SqlDbType.VarChar, 50);
                objSqlParam[3].Value = objBEStudent.dtExam;


                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_Student_ValidatePLExam", objSqlParam);

                objBEStudent.IntResult = Convert.ToInt32(objSqlParam[2].Value.ToString());

            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void DGetExamValues(BEStudent objBEStudent)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[7];

                objSqlParam[0] = new SqlParameter("@I_TransID", SqlDbType.BigInt);
                objSqlParam[0].Value = objBEStudent.IntTransID;
                objSqlParam[1] = new SqlParameter("@I_ProviderID", SqlDbType.BigInt);
                objSqlParam[1].Direction = ParameterDirection.Output;
                objSqlParam[2] = new SqlParameter("@I_CourseID", SqlDbType.Int);
                objSqlParam[2].Direction = ParameterDirection.Output;
                objSqlParam[3] = new SqlParameter("@I_ExamID", SqlDbType.Int);
                objSqlParam[3].Direction = ParameterDirection.Output;
                objSqlParam[4] = new SqlParameter("@V_ProviderName", SqlDbType.VarChar, 500);
                objSqlParam[4].Direction = ParameterDirection.Output;
                objSqlParam[5] = new SqlParameter("@V_CourseName", SqlDbType.VarChar, 500);
                objSqlParam[5].Direction = ParameterDirection.Output;
                objSqlParam[6] = new SqlParameter("@V_ExamName", SqlDbType.VarChar, 500);
                objSqlParam[6].Direction = ParameterDirection.Output;


                objBEStudent.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_Student_GetExamValues", objSqlParam).Tables[0];

                objBEStudent.IntProviderID = Convert.ToInt32(objSqlParam[1].Value.ToString());
                objBEStudent.IntCourseID = Convert.ToInt32(objSqlParam[2].Value.ToString());
                objBEStudent.IntExamID = Convert.ToInt32(objSqlParam[3].Value.ToString());
                objBEStudent.strUserName = objSqlParam[4].Value.ToString();
                objBEStudent.strCourseName = objSqlParam[5].Value.ToString();
                objBEStudent.strExamName = objSqlParam[6].Value.ToString();
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void DStudent_NonProctorScheduleExam(BEStudent objBEStudent)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[8];

                objSqlParam[0] = new SqlParameter("@UserID", SqlDbType.Int);
                objSqlParam[0].Value = objBEStudent.IntUserID;
                objSqlParam[1] = new SqlParameter("@CourseID", SqlDbType.Int);
                objSqlParam[1].Value = objBEStudent.IntCourseID;
                objSqlParam[2] = new SqlParameter("@ExamID", SqlDbType.Int);
                objSqlParam[2].Value = objBEStudent.IntExamID;
                objSqlParam[3] = new SqlParameter("@ExamDate", SqlDbType.DateTime);
                objSqlParam[3].Value = objBEStudent.dtExam;
                objSqlParam[4] = new SqlParameter("@OnDemand", SqlDbType.Int);
                objSqlParam[4].Value = objBEStudent.intOndemand;
                objSqlParam[5] = new SqlParameter("@ExamFee", SqlDbType.Decimal);
                objSqlParam[5].Precision = 5;
                objSqlParam[5].Scale = 2;
                objSqlParam[5].Direction = ParameterDirection.Output;
                objSqlParam[6] = new SqlParameter("@OnDemandFee", SqlDbType.Decimal);
                objSqlParam[6].Precision = 5;
                objSqlParam[6].Scale = 2;
                objSqlParam[6].Direction = ParameterDirection.Output;
                objSqlParam[7] = new SqlParameter("@PerHourFee", SqlDbType.Decimal);
                objSqlParam[7].Precision = 5;
                objSqlParam[7].Scale = 2;
                objSqlParam[7].Direction = ParameterDirection.Output;


                objBEStudent.DsResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_Student_NonProctorScheduleExam", objSqlParam);


                objBEStudent.decExamFee = Convert.ToDecimal(objSqlParam[5].Value.ToString());
                objBEStudent.decOnDemandFee = Convert.ToDecimal(objSqlParam[6].Value.ToString());
                objBEStudent.PerHourFee = Convert.ToDecimal(objSqlParam[7].Value.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DStudent_NonProctorValidateExam(BEStudent objBEStudent)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[9];

                objSqlParam[0] = new SqlParameter("@UserID", SqlDbType.Int);
                objSqlParam[0].Value = objBEStudent.IntUserID;
                objSqlParam[1] = new SqlParameter("@CourseID", SqlDbType.Int);
                objSqlParam[1].Value = objBEStudent.IntCourseID;
                objSqlParam[2] = new SqlParameter("@ExamID", SqlDbType.Int);
                objSqlParam[2].Value = objBEStudent.IntExamID;
                objSqlParam[3] = new SqlParameter("@ExamDate", SqlDbType.DateTime);
                objSqlParam[3].Value = objBEStudent.dtExam;
                objSqlParam[4] = new SqlParameter("@OnDemand", SqlDbType.Int);
                objSqlParam[4].Value = objBEStudent.intOndemand;
                objSqlParam[5] = new SqlParameter("@ExamFee", SqlDbType.Decimal);
                objSqlParam[5].Precision = 5;
                objSqlParam[5].Scale = 2;
                objSqlParam[5].Direction = ParameterDirection.Output;
                objSqlParam[6] = new SqlParameter("@OnDemandFee", SqlDbType.Decimal);
                objSqlParam[6].Precision = 5;
                objSqlParam[6].Scale = 2;
                objSqlParam[6].Direction = ParameterDirection.Output;
                objSqlParam[7] = new SqlParameter("@TotalExamFee", SqlDbType.Decimal);
                objSqlParam[7].Precision = 5;
                objSqlParam[7].Scale = 2;
                objSqlParam[7].Direction = ParameterDirection.Output;
                objSqlParam[8] = new SqlParameter("@PerHourFee", SqlDbType.Decimal);
                objSqlParam[8].Precision = 5;
                objSqlParam[8].Scale = 2;
                objSqlParam[8].Direction = ParameterDirection.Output;
                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_Student_ProctorlessExamStudentPay", objSqlParam);


                objBEStudent.decExamFee = Convert.ToDecimal(objSqlParam[5].Value.ToString());
                objBEStudent.decOnDemandFee = Convert.ToDecimal(objSqlParam[6].Value.ToString());
                objBEStudent.decAmount = Convert.ToDecimal(objSqlParam[7].Value.ToString());
                objBEStudent.PerHourFee = Convert.ToDecimal(objSqlParam[8].Value.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void DCheckPLexamretake(BEStudent objBEStudent)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[6];

                objSqlParam[0] = new SqlParameter("@UserID", SqlDbType.Int);
                objSqlParam[0].Value = objBEStudent.IntUserID;
                objSqlParam[1] = new SqlParameter("@CourseID", SqlDbType.Int);
                objSqlParam[1].Value = objBEStudent.IntCourseID;
                objSqlParam[2] = new SqlParameter("@ExamID", SqlDbType.Int);
                objSqlParam[2].Value = objBEStudent.IntExamID;
                objSqlParam[3] = new SqlParameter("@Reexam", SqlDbType.Int);
                objSqlParam[3].Direction = ParameterDirection.Output;
                objSqlParam[4] = new SqlParameter("@Step", SqlDbType.Int);
                objSqlParam[4].Direction = ParameterDirection.Output;
                objSqlParam[5] = new SqlParameter("@TransID", SqlDbType.BigInt);
                objSqlParam[5].Direction = ParameterDirection.Output;

                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_Student_CheckPLexamretake", objSqlParam);
                objBEStudent.intReExam = Convert.ToInt32(objSqlParam[3].Value.ToString());
                objBEStudent.intStep = Convert.ToInt32(objSqlParam[4].Value.ToString());
                objBEStudent.IntTransID = Convert.ToInt64(objSqlParam[5].Value.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DgetProviderFile(BEStudent objBEStudent)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[1];
                objSqlParam[0] = new SqlParameter("@I_TransID", SqlDbType.BigInt);
                objSqlParam[0].Value = objBEStudent.IntTransID;



                objBEStudent.DsResult=SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_Student_GetProviderFile", objSqlParam);
              

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void DShowOrHideexamiKEY(BEStudent objBEStudent)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[2];
                objSqlParam[0] = new SqlParameter("@UserID", SqlDbType.Int);
                objSqlParam[0].Value = objBEStudent.IntUserID;
                objSqlParam[1] = new SqlParameter("@Result", SqlDbType.Bit);
                objSqlParam[1].Direction = ParameterDirection.Output;

                //objBEStudent.DsResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_Student_ShowOrHideexamiKEY", objSqlParam);
                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_Student_ShowOrHideexamiKEY", objSqlParam);
                objBEStudent.BoolResult = Convert.ToBoolean(objSqlParam[1].Value.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void DStudent_AAScheduleExam(BEStudent objBEStudent)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[7];

                objSqlParam[0] = new SqlParameter("@UserID", SqlDbType.Int);
                objSqlParam[0].Value = objBEStudent.IntUserID;
                objSqlParam[1] = new SqlParameter("@CourseID", SqlDbType.Int);
                objSqlParam[1].Value = objBEStudent.IntCourseID;
                objSqlParam[2] = new SqlParameter("@ExamID", SqlDbType.Int);
                objSqlParam[2].Value = objBEStudent.IntExamID;
                objSqlParam[3] = new SqlParameter("@ExamDate", SqlDbType.DateTime);
                objSqlParam[3].Value = objBEStudent.dtExam;
                objSqlParam[4] = new SqlParameter("@ExamFee", SqlDbType.Decimal);
                objSqlParam[4].Precision = 5;
                objSqlParam[4].Scale = 2;
                objSqlParam[4].Direction = ParameterDirection.Output;
                objSqlParam[5] = new SqlParameter("@PerHourFee", SqlDbType.Decimal);
                objSqlParam[5].Precision = 5;
                objSqlParam[5].Scale = 2;
                objSqlParam[5].Direction = ParameterDirection.Output;
                objSqlParam[6] = new SqlParameter("@TransID", SqlDbType.BigInt);
                objSqlParam[6].Direction = ParameterDirection.Output;


                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_Student_AAScheduleExam", objSqlParam);


                objBEStudent.decExamFee = Convert.ToDecimal(objSqlParam[4].Value.ToString());
                objBEStudent.decOnDemandFee = 0;
                objBEStudent.PerHourFee = Convert.ToDecimal(objSqlParam[5].Value.ToString());
                objBEStudent.IntTransID = Convert.ToInt64(objSqlParam[6].Value.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void DStudent_AAScheduleStudentPayExam(BEStudent objBEStudent)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[7];

                objSqlParam[0] = new SqlParameter("@UserID", SqlDbType.Int);
                objSqlParam[0].Value = objBEStudent.IntUserID;
                objSqlParam[1] = new SqlParameter("@CourseID", SqlDbType.Int);
                objSqlParam[1].Value = objBEStudent.IntCourseID;
                objSqlParam[2] = new SqlParameter("@ExamID", SqlDbType.Int);
                objSqlParam[2].Value = objBEStudent.IntExamID;
                objSqlParam[3] = new SqlParameter("@ExamDate", SqlDbType.DateTime);
                objSqlParam[3].Value = objBEStudent.dtExam;
                objSqlParam[4] = new SqlParameter("@ExamFee", SqlDbType.Decimal);
                objSqlParam[4].Precision = 5;
                objSqlParam[4].Scale = 2;
                objSqlParam[4].Direction = ParameterDirection.Output;
                objSqlParam[5] = new SqlParameter("@TotalExamFee", SqlDbType.Decimal);
                objSqlParam[5].Precision = 5;
                objSqlParam[5].Scale = 2;
                objSqlParam[5].Direction = ParameterDirection.Output;
                objSqlParam[6] = new SqlParameter("@PerHourFee", SqlDbType.Decimal);
                objSqlParam[6].Precision = 5;
                objSqlParam[6].Scale = 2;
                objSqlParam[6].Direction = ParameterDirection.Output;
                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_Student_AAScheduleStudentPayExam", objSqlParam);


                objBEStudent.decExamFee = Convert.ToDecimal(objSqlParam[4].Value.ToString());
                objBEStudent.decOnDemandFee = 0;
                objBEStudent.decAmount = Convert.ToDecimal(objSqlParam[5].Value.ToString());
                objBEStudent.PerHourFee = Convert.ToDecimal(objSqlParam[6].Value.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void DGetAAExams(BEStudent objBEStudent)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[1];

                objSqlParam[0] = new SqlParameter("@UserID", SqlDbType.Int);
                objSqlParam[0].Value = objBEStudent.IntUserID;


                objBEStudent.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_Student_GetAAExams", objSqlParam).Tables[0];
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        public void DAARandomSecurityQuestionsValidation(BEStudent objBEStudent)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[6];

                objSqlParam[0] = new SqlParameter("@Answer", SqlDbType.VarChar, 500);
                objSqlParam[0].Value = objBEStudent.strAnswer1;

                objSqlParam[1] = new SqlParameter("@UserID", SqlDbType.Int);
                objSqlParam[1].Value = objBEStudent.IntUserID;
                objSqlParam[2] = new SqlParameter("@Question", SqlDbType.Int);
                objSqlParam[2].Value = Convert.ToInt32(objBEStudent.strQuestion1);
                objSqlParam[3] = new SqlParameter("@Status", SqlDbType.Int);
                objSqlParam[3].Direction = ParameterDirection.Output;
                objSqlParam[4] = new SqlParameter("@TransID", SqlDbType.BigInt);
                objSqlParam[4].Value = objBEStudent.IntTransID;

                objSqlParam[5] = new SqlParameter("@ErrorMsg", SqlDbType.VarChar, 500);
                objSqlParam[5].Direction = ParameterDirection.Output;

                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_AARandomSecurityQuestionsValidation", objSqlParam);

                objBEStudent.IntResult = Convert.ToInt32(objSqlParam[3].Value.ToString());

                objBEStudent.StrResult = objSqlParam[5].Value.ToString();

            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        public void DGetAAexamiKEYstatus(BEStudent objBEStudent)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[2];
                objSqlParam[0] = new SqlParameter("@I_TransID", SqlDbType.BigInt);
                objSqlParam[0].Value = objBEStudent.IntTransID;
                objSqlParam[1] = new SqlParameter("@Result", SqlDbType.Int); 
                objSqlParam[1].Direction = ParameterDirection.Output;


 SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_Student_GetAAexamiKEYstatus", objSqlParam);
 objBEStudent.IntResult = Convert.ToInt32(objSqlParam[1].Value.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void DGetAAExamScheduledDate(BEStudent objBEStudent)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[2];

                objSqlParam[0] = new SqlParameter("@I_TransID", SqlDbType.BigInt);
                objSqlParam[0].Value = objBEStudent.IntTransID;
                objSqlParam[1] = new SqlParameter("@I_UserID", SqlDbType.Int);
                objSqlParam[1].Value = objBEStudent.IntUserID;

                objBEStudent.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_STUDENT_GetAAExamScheduledDate", objSqlParam).Tables[0];
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        public void DValidateReschedulePLExam(BEStudent objBEStudent)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[4];

                objSqlParam[0] = new SqlParameter("@I_UserID", SqlDbType.BigInt);
                objSqlParam[0].Value = objBEStudent.IntUserID;
                objSqlParam[1] = new SqlParameter("@I_TransID", SqlDbType.BigInt);
                objSqlParam[1].Value = objBEStudent.IntTransID;
                objSqlParam[2] = new SqlParameter("@I_Result", SqlDbType.Int);
                objSqlParam[2].Direction = ParameterDirection.Output;
                objSqlParam[3] = new SqlParameter("@V_ExamDate", SqlDbType.VarChar, 50);
                objSqlParam[3].Value = objBEStudent.dtExam;


                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_Student_ValidateReschedulePLExam", objSqlParam);

                objBEStudent.IntResult = Convert.ToInt32(objSqlParam[2].Value.ToString());

            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        //public void DStudent_AAGetExamDetails(BEStudent objBEStudent)
        //{
        //    try
        //    {
        //        SqlParameter[] objSqlParam = new SqlParameter[2];

        //        objSqlParam[0] = new SqlParameter("@I_UserID", SqlDbType.BigInt);
        //        objSqlParam[0].Value = objBEStudent.IntUserID;
        //        objSqlParam[1] = new SqlParameter("@I_TransID", SqlDbType.Int);
        //        objSqlParam[1].Value = objBEStudent.IntTransID;


        //        objBEStudent.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_Student_AAGetExamDetails", objSqlParam).Tables[0];

               

        //    }
        //    catch (Exception Ex)
        //    {
        //        throw Ex;
        //    }
        //}

        public void DDeleteAAAppointment(BEStudent objBEStudent)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[2];

                objSqlParam[0] = new SqlParameter("@I_TransID", SqlDbType.BigInt);
                objSqlParam[0].Value = objBEStudent.IntTransID;
                objSqlParam[1] = new SqlParameter("@I_UserID", SqlDbType.Int);
                objSqlParam[1].Value = objBEStudent.IntUserID;

                objBEStudent.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_STUDENT_DeleteAAAppointment", objSqlParam).Tables[0];
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        public void DStudent_UpdateAAExamReschedule(BEStudent objBEStudent)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[3];

                objSqlParam[0] = new SqlParameter("@UserID", SqlDbType.Int);
                objSqlParam[0].Value = objBEStudent.IntUserID;
                objSqlParam[1] = new SqlParameter("@TransID", SqlDbType.BigInt); 
                objSqlParam[1].Value = objBEStudent.IntTransID;
                objSqlParam[2] = new SqlParameter("@ExamDate", SqlDbType.DateTime);
                objSqlParam[2].Value = objBEStudent.dtExam;


            SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_Student_UpdateAAExamReschedule", objSqlParam);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void DGetTransID(BEStudent objBEStudent)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[4];

                objSqlParam[0] = new SqlParameter("@UserID", SqlDbType.Int);
                objSqlParam[0].Value = objBEStudent.IntUserID;
                objSqlParam[1] = new SqlParameter("@CourseID", SqlDbType.Int);
                objSqlParam[1].Value = objBEStudent.IntCourseID;
                objSqlParam[2] = new SqlParameter("@ExamID", SqlDbType.Int);
                objSqlParam[2].Value = objBEStudent.IntExamID;
                objSqlParam[3] = new SqlParameter("@I_TransID", SqlDbType.BigInt);
                objSqlParam[3].Direction = ParameterDirection.Output;



                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_Student_GetTransID", objSqlParam);


                objBEStudent.IntTransID = Convert.ToInt64(objSqlParam[3].Value.ToString());
             
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void DGetAuthenticationOverrideStatus(BEStudent objBEStudent)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[2];

                objSqlParam[0] = new SqlParameter("@TransID", SqlDbType.BigInt);
                objSqlParam[0].Value = objBEStudent.IntTransID;
                objSqlParam[1] = new SqlParameter("@from", SqlDbType.Int);
                objSqlParam[1].Value = objBEStudent.IntFlag;


                objBEStudent.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_Student_GetAuthenticationOverrideStatus", objSqlParam).Tables[0];

            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        public void DOverrideAuthentication(BEStudent objBEStudent)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[3];
                objSqlParam[0] = new SqlParameter("@I_TransID", SqlDbType.BigInt);
                objSqlParam[0].Value = objBEStudent.IntTransID;
                objSqlParam[1] = new SqlParameter("@I_Type", SqlDbType.Int);
                objSqlParam[1].Value = objBEStudent.IntType;
                objSqlParam[2] = new SqlParameter("@I_UserId", SqlDbType.Int);
                objSqlParam[2].Value = objBEStudent.IntUserID;




                objBEStudent.DsResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_Proctor_OverrideAuthentication", objSqlParam);


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void DCheckExamiKEY(BEStudent objBEStudent)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[2];
                objSqlParam[0] = new SqlParameter("@I_UserID", SqlDbType.Int);
                objSqlParam[0].Value = objBEStudent.IntUserID;
                objSqlParam[1] = new SqlParameter("@Route", SqlDbType.Bit);
                objSqlParam[1].Direction = ParameterDirection.Output;

                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_Common_CheckExamiKEY", objSqlParam);
                objBEStudent.BoolResult = Convert.ToBoolean(objSqlParam[1].Value);
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void DCheckIsexamiFACE(BEStudent objBEStudent)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[1];

                objSqlParam[0] = new SqlParameter("@I_TransID", SqlDbType.BigInt);
                objSqlParam[0].Value = objBEStudent.IntTransID;

                objBEStudent.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_Student_CheckIsexamiFace", objSqlParam).Tables[0];
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        public void DCheckIsexamiFACEDownLoad(BEStudent objBEStudent)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[1];

                objSqlParam[0] = new SqlParameter("@I_TransID", SqlDbType.BigInt);
                objSqlParam[0].Value = objBEStudent.IntTransID;

                objBEStudent.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_Student_CheckIsexamiFaceDownLoadStatus", objSqlParam).Tables[0];
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void DCaptureOSAndBrowser(BEStudent objBEStudent)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[4];

                objSqlParam[0] = new SqlParameter("@I_TransID", SqlDbType.BigInt);
                objSqlParam[0].Value = objBEStudent.IntTransID;
                objSqlParam[1] = new SqlParameter("@V_Browser", SqlDbType.VarChar,500);
                objSqlParam[1].Value = objBEStudent.strBrowser;
                objSqlParam[2] = new SqlParameter("@V_BrowserVersion", SqlDbType.VarChar, 500);
                objSqlParam[2].Value = objBEStudent.strBrowserVersion;
                objSqlParam[3] = new SqlParameter("@V_OS", SqlDbType.VarChar, 500);
                objSqlParam[3].Value = objBEStudent.strOS;

                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_Student_CaptureOsAndBrowser", objSqlParam);
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }

    }
}
