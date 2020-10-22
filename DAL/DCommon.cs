using System;
using BusinessEntities;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;

namespace DAL
{
    public class DCommon
    {
        #region ConnectionString
        public string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SecureProctor"].ConnectionString.ToString();
        public static SqlConnection getConnection()
        {
            return new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SecureProctor"].ConnectionString.ToString());
        }
        #endregion ConnectionString

        #region DBindCourse
        public void DBindCourse(BECommon objBECommon)
        {

            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[2];

                objSqlParam[0] = new SqlParameter("@StudentID", SqlDbType.Int);
                objSqlParam[0].Value = objBECommon.IntUserID;
                objSqlParam[1] = new SqlParameter("@InstructorID", SqlDbType.Int);
                objSqlParam[1].Value = objBECommon.IntProviderID;

                objBECommon.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Student_GetAllCourses, objSqlParam).Tables[0];
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public void DBindCourse_Accessibility(BECommon objBECommon)
        {

            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[1];

                objSqlParam[0] = new SqlParameter("@StudentID", SqlDbType.Int);
                objSqlParam[0].Value = objBECommon.IntUserID;

                objBECommon.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Student_GetAllCourses_Accessibility, objSqlParam).Tables[0];
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public void DGetStudentCourses(BECommon objBECommon)
        {

            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[1];

                objSqlParam[0] = new SqlParameter("@StudentID", SqlDbType.Int);
                objSqlParam[0].Value = objBECommon.IntUserID;

                objBECommon.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Student_GetStudentCourses, objSqlParam).Tables[0];
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
                SqlParameter[] objSqlParam = new SqlParameter[1];

                objSqlParam[0] = new SqlParameter("@I_ExamID", SqlDbType.Int);
                objSqlParam[0].Value = objBECommon.IntCourseID;

                objBECommon._DataSet = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_GETEXAMTOOLS, objSqlParam);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion



        #region DBindExam
        public void DBindExam(BECommon objBECommon)
        {

            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[3];

                objSqlParam[0] = new SqlParameter("@I_CourseID", SqlDbType.Int);
                objSqlParam[0].Value = objBECommon.IntCourseID;
                objSqlParam[1] = new SqlParameter("@I_ExamID", SqlDbType.Int);
                objSqlParam[1].Value = objBECommon.IntExamID;
                objSqlParam[2] = new SqlParameter("@I_UserID", SqlDbType.Int);
                objSqlParam[2].Value = objBECommon.IntUserID;

                objBECommon.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Student_GetExamsForCourse, objSqlParam).Tables[0];
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void DBindExam_Accessibility(BECommon objBECommon)
        {

            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[3];

                objSqlParam[0] = new SqlParameter("@I_CourseID", SqlDbType.Int);
                objSqlParam[0].Value = objBECommon.IntCourseID;
                objSqlParam[1] = new SqlParameter("@I_ExamID", SqlDbType.Int);
                objSqlParam[1].Value = objBECommon.IntExamID;
                objSqlParam[2] = new SqlParameter("@I_UserID", SqlDbType.Int);
                objSqlParam[2].Value = objBECommon.IntUserID;

                objBECommon.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Student_GetExamsForCourse_Accessibility, objSqlParam).Tables[0];
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        #region DGetTransactionComments
        public void DGetTransactionComments(BECommon objBECommon)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[2];

                objSqlParam[0] = new SqlParameter("@TransID", SqlDbType.BigInt);
                objSqlParam[0].Value = objBECommon.IntTransID;
                objSqlParam[1] = new SqlParameter("@UserID", SqlDbType.Int);
                objSqlParam[1].Value = objBECommon.IntUserID;

                objBECommon.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_GetComments, objSqlParam).Tables[0];
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        #region DGetStudentReprot
        public void DGetStudentReprot(BECommon objBECommon)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[4];
                objSqlParam[0] = new SqlParameter("@dtStart", SqlDbType.VarChar, 50);
                objSqlParam[0].Value = objBECommon.DtStartDate;
                objSqlParam[1] = new SqlParameter("@dtEnd", SqlDbType.VarChar, 50);
                objSqlParam[1].Value = objBECommon.DtEndDate;
                objSqlParam[2] = new SqlParameter("@IntStatus", SqlDbType.Int);
                objSqlParam[2].Value = objBECommon.IntType;
                objSqlParam[3] = new SqlParameter("@UserID", SqlDbType.Int);
                objSqlParam[3].Value = objBECommon.IntUserID;

                objBECommon.DsResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Reports_Student, objSqlParam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region DAddComments
        public void DAddComments(BECommon objBECommon)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[6];

                objSqlParam[0] = new SqlParameter("@TransID", SqlDbType.BigInt);
                objSqlParam[0].Value = objBECommon.IntTransID;
                objSqlParam[1] = new SqlParameter("@Comments", SqlDbType.VarChar, 500);
                if (objBECommon.StrComments != string.Empty)
                    objSqlParam[1].Value = objBECommon.StrComments;
                else
                    objSqlParam[1].Value = DBNull.Value;
                objSqlParam[2] = new SqlParameter("@UserID", SqlDbType.Int);
                objSqlParam[2].Value = objBECommon.IntUserID;
                objSqlParam[3] = new SqlParameter("@I_ID", SqlDbType.Int);
                objSqlParam[3].Value = Convert.ToInt32(objBECommon.StrddlComments);
                objSqlParam[4] = new SqlParameter("@I_AlertID", SqlDbType.Int);
                objSqlParam[4].Value = Convert.ToInt32(objBECommon.intAlertID);
                objSqlParam[5] = new SqlParameter("@V_Time", SqlDbType.VarChar, 50);
                objSqlParam[5].Value = objBECommon.strTime;

                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Common_AddComments, objSqlParam);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        public void DApproveOrRejectTransaction(BECommon objBECommon)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[4];

                objSqlParam[0] = new SqlParameter("@I_UserID", SqlDbType.Int);
                objSqlParam[0].Value = objBECommon.IntEmployeeID;
                objSqlParam[1] = new SqlParameter("@I_Type", SqlDbType.Int);
                objSqlParam[1].Value = objBECommon.IntType;
                objSqlParam[2] = new SqlParameter("@I_TransactionID", SqlDbType.BigInt);
                objSqlParam[2].Value = objBECommon.IntTransID;
                objSqlParam[3] = new SqlParameter("@flag", SqlDbType.Bit);
                objSqlParam[3].Value = Convert.ToByte(objBECommon.IntstatusFlag);

                objBECommon.IntResult = SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Auditor_Approve_Reject_Inbox, objSqlParam);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public void DAutoProcInboxApproveOrReject(BECommon objBECommon)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[4];

                objSqlParam[0] = new SqlParameter("@I_UserID", SqlDbType.Int);
                objSqlParam[0].Value = objBECommon.IntEmployeeID;
                objSqlParam[1] = new SqlParameter("@I_Type", SqlDbType.Int);
                objSqlParam[1].Value = objBECommon.IntType;
                objSqlParam[2] = new SqlParameter("@I_TransactionID", SqlDbType.BigInt);
                objSqlParam[2].Value = objBECommon.IntTransID;
                objSqlParam[3] = new SqlParameter("@flag", SqlDbType.Bit);
                objSqlParam[3].Value = Convert.ToByte(objBECommon.IntstatusFlag);

                objBECommon.IntResult = SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Proctor_AutoProcInboxApprove_Reject, objSqlParam);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }




        #region DUpdateTimeZone
        public void DUpdateTimeZone(BECommon objBECommon)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[4];

                objSqlParam[0] = new SqlParameter("@I_UserID", SqlDbType.Int);
                objSqlParam[0].Value = objBECommon.IntStudentID;

                objSqlParam[1] = new SqlParameter("@V_TimeZone", SqlDbType.VarChar, 20);
                objSqlParam[1].Value = objBECommon.strTimeZone;

                objSqlParam[2] = new SqlParameter("@I_flag", SqlDbType.Int);
                objSqlParam[2].Direction = ParameterDirection.Output;


                objSqlParam[3] = new SqlParameter("@V_TimeZoneName", SqlDbType.VarChar, 20);
                objSqlParam[3].Direction = ParameterDirection.Output;
                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_STUDENT_UpdateTimeZone, objSqlParam);
                // objBEStudent.dtResult1 = SQLHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_STUDENT_GetTimeZoneList1, objSqlParam).Tables[1];

                objBECommon.IntResult = Convert.ToInt16(objSqlParam[2].Value);

                objBECommon.strTimeZone = objSqlParam[3].Value.ToString();
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        #region DGetStudentExamDetails
        public void DGetStudentExamDetails(BECommon objBECommon)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[2];
                objSqlParam[0] = new SqlParameter("@TransID", SqlDbType.BigInt);
                objSqlParam[0].Value = objBECommon.IntTransID;

                objSqlParam[1] = new SqlParameter("@UserID1", SqlDbType.Int);
                objSqlParam[1].Value = objBECommon.IntUserID;

                objBECommon.DsResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Common_getStudentExamDetails, objSqlParam);
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        #region DGetExamProviderDetails
        public void DGetExamProviderDetails(BECommon objBECommon)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[1];
                objSqlParam[0] = new SqlParameter("@I_TransID", SqlDbType.BigInt);
                objSqlParam[0].Value = objBECommon.IntTransID;

                objBECommon.DsResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Common_GetEmailIDs, objSqlParam);
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        //#region DGetStudentDetails
        //public void DGetStudentDetails(BECommon objBECommon)
        //{
        //    try
        //    {
        //        SqlParameter[] objSqlParam = new SqlParameter[1];
        //        objSqlParam[0] = new SqlParameter("@StudentID", SqlDbType.Int);
        //        objSqlParam[0].Value = objBECommon.IntStudentID;

        //        objBECommon.DsResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Common_ViewStudentDetails, objSqlParam);


        //    }

        //    catch (Exception Ex)
        //    {
        //        throw Ex;
        //    }
        //}
        //#endregion

        /// <summary>
        /// Get Student Details
        /// </summary>
        /// <param name="objBECommon"></param>
        public void DGetStudentDetails(BECommon objBECommon)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[1];
                objSqlParam[0] = new SqlParameter("@StudentID", SqlDbType.Int);
                objSqlParam[0].Value = objBECommon.IntStudentID;

                objBECommon.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Common_GetSelectedStudentDetails, objSqlParam).Tables[0];
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        #region DGetStudentCourseDetails
        public void DGetStudentCourseDetails(BECommon objBECommon)
        {

            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[2];
                objSqlParam[0] = new SqlParameter("@I_StudentID", SqlDbType.Int);
                objSqlParam[0].Value = objBECommon.IntStudentID;
                objSqlParam[1] = new SqlParameter("@I_UserID", SqlDbType.Int);
                objSqlParam[1].Value = objBECommon.IntUserID;
                objBECommon.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Common_GetStudentCourseDetails, objSqlParam).Tables[0];

            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        public List<BECommon> CheckProctorLoggedInusers(BECommon objBECommon)
        {
            List<BECommon> userlist = null;
            SqlConnection con = null;
            BECommon ms = null;

            try
            {
                con = getConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand(StoredProcedures.checkproctorlogin, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userid", objBECommon.IntUserID);
                SqlDataReader rd = cmd.ExecuteReader();
                userlist = new List<BECommon>();
                while (rd.Read())
                {
                    ms = new BECommon();
                    ms.PUid = rd["Userid"].ToString();
                    ms.Puname = rd["Username"].ToString();
                    ms.Plogin = Convert.ToBoolean(rd["LoggedIn"]);
                    userlist.Add(ms);
                }
            }
            catch (Exception )
            { }
            finally
            { //ConnectionUtil.Close(con); 
            }

            return userlist;
        }

        public List<BECommon> CheckLoggedInusers(BECommon objBECommon)
        {
            List<BECommon> userlist = null;
            SqlConnection con = null;
            BECommon ms = null;

            try
            {
                con = getConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand(StoredProcedures.checkuserlogin, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userid", objBECommon.IntUserID);
                cmd.Parameters.AddWithValue("@Transid", objBECommon.IntTransID);
                SqlDataReader rd = cmd.ExecuteReader();
                userlist = new List<BECommon>();
                while (rd.Read())
                {
                    ms = new BECommon();
                    ms.DUid = rd["Userid"].ToString();
                    ms.Duname = rd["Username"].ToString();
                    ms.Dlogin = Convert.ToBoolean(rd["LoggedIn"]);
                    userlist.Add(ms);
                }
            }
            catch (Exception )            { }
            finally
            { //ConnectionUtil.Close(con); 
            }

            return userlist;
        }

        #region DGetEnrollStudentDetails
        public void DGetEnrollStudentDetails(BECommon objBECommon)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[1];
                objSqlParam[0] = new SqlParameter("@I_EnrollID", SqlDbType.Int);
                objSqlParam[0].Value = objBECommon.IntStudentID;

                objBECommon.DsResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Common_GetEnrollStudentDetails, objSqlParam);
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        #region DAdminGetEnrollStudentDetails
        public void DAdminGetEnrollStudentDetails(BECommon objBECommon)
        {
            try
            {


                objBECommon.DsResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Admin_GetEnrollMents);
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion


        #region DGenderList
        public void DGenderList(BECommon objBECommon)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[1];
                objSqlParam[0] = new SqlParameter("@I_StudentID", SqlDbType.Int);
                objSqlParam[0].Value = objBECommon.IntUserID;

                objBECommon.DsResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Common_GetGenderList, objSqlParam);
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        #region DBindProviderNames
        public void DBindProviderNames(BECommon objBECommon)
        {

            try
            {


                objBECommon.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Common_GetProviders).Tables[0];
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        #region DOpenTokSaveSessionID
        public void DOpenTokSaveSessionID(BECommon objBECommon)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[2];
                objSqlParam[0] = new SqlParameter("@I_TransID", SqlDbType.BigInt);
                objSqlParam[0].Value = objBECommon.strTransID;
                objSqlParam[1] = new SqlParameter("@V_SessionID", SqlDbType.VarChar, 8000);
                objSqlParam[1].Value = objBECommon.strSessionID;


                objBECommon._DataSet = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_OpenTok_SaveSession, objSqlParam);
                if (objBECommon._DataSet.Tables[0].Rows[0]["Result"].ToString() == "0")
                {

                    if (objBECommon._DataSet.Tables[0].Rows[0]["Status"].ToString() == "1")
                    {
                        objBECommon.strResult = "oldsession";
                        objBECommon.strSessionID = objBECommon._DataSet.Tables[0].Rows[0]["SessionID"].ToString();
                    }
                    else
                    {
                        objBECommon.strResult = "invalidexam";
                        objBECommon.strErrorDesc = "User exam rejected or approved with this exam ID";
                    }
                }
                else
                {
                    objBECommon.strResult = "newsession";
                }
            }
            catch (Exception )
            {
            }
        }
        #endregion

        #region DOpenTokGetSessionID
        public void DOpenTokGetSessionID(BECommon objBECommon)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[1];
                objSqlParam[0] = new SqlParameter("@I_TransID", SqlDbType.BigInt);
                objSqlParam[0].Value = objBECommon.strTransID;

                objBECommon._DataSet = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_OpenTok_GetSession, objSqlParam);
                if (objBECommon._DataSet.Tables[0].Rows.Count > 0)
                {
                    objBECommon.strSessionID = (String)objBECommon._DataSet.Tables[0].Rows[0]["SessionID"];
                }
                else
                {
                    objBECommon.strSessionID = "";
                }

            }
            catch (Exception )
            {
            }
        }
        #endregion


        #region DOpenTokSaveArchiveID
        public void DOpenTokSaveArchiveID(BECommon objBECommon)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[2];
                objSqlParam[0] = new SqlParameter("@I_TransID", SqlDbType.BigInt);
                objSqlParam[0].Value = objBECommon.strTransID;
                objSqlParam[1] = new SqlParameter("@V_ArchiveID", SqlDbType.VarChar, 8000);
                objSqlParam[1].Value = objBECommon.strArchiveId;


                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_OpenTok_SaveArchiveID, objSqlParam);
            }
            catch (Exception )
            {
            }
        }
        #endregion

        #region DOpenTokGetArchiveID
        public void DOpenTokGetArchiveID(BECommon objBECommon)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[1];
                objSqlParam[0] = new SqlParameter("@I_TransID", SqlDbType.BigInt);
                objSqlParam[0].Value = objBECommon.strTransID;



                objBECommon.strArchiveId = (String)SQLHelper.ExecuteScalar(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_OpenTok_GetArchiveID, objSqlParam);
            }
            catch (Exception )
            {
            }
        }
        #endregion

        // new schedular methods

        public void DBind_GetBookedExamSlots(BECommon objBECommon)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[1];

                objSqlParam[0] = new SqlParameter("@I_StudenID", SqlDbType.Int);
                objSqlParam[0].Value = objBECommon.IntUserID;

                objBECommon.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Student_GetBookedExamSlots, objSqlParam).Tables[0];
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void DGetExamStatus(BECommon objBECommon)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[2];

                objSqlParam[0] = new SqlParameter("@I_TransID", SqlDbType.BigInt);
                objSqlParam[0].Value = objBECommon.IntTransID;

                objSqlParam[1] = new SqlParameter("@B_Status", SqlDbType.Int);
                objSqlParam[1].Direction = ParameterDirection.Output;

                SQLHelper.ExecuteScalar(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Proctor_GetTimerExamStatus, objSqlParam);

                objBECommon.IntType = Convert.ToInt16(objSqlParam[1].Value.ToString());
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        #region DGetTimeDelay
        public void DGetTimeDelay(BECommon objBECommon)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[1];
                objSqlParam[0] = new SqlParameter("@TimeZoneID", SqlDbType.Int);
                objSqlParam[0].Value = objBECommon.iTimeZoneID;



                objBECommon.IntResult = (Int32)SQLHelper.ExecuteScalar(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Common_GetTimeDelay, objSqlParam);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        public void DBindSecurityLevel(BECommon objBECommon)
        {
            try
            {

                objBECommon.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_GetSecurityLevel).Tables[0];
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        public void DGetAlerts(BECommon objBECommon)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[3];

                objSqlParam[0] = new SqlParameter("@I_RoleID", SqlDbType.Int);
                objSqlParam[0].Value = objBECommon.intRoleID;
                objSqlParam[1] = new SqlParameter("@I_AlertGroup", SqlDbType.Int);
                objSqlParam[1].Value = objBECommon.intAlertID;
                objSqlParam[2] = new SqlParameter("@I_CommentID", SqlDbType.Int);
                objSqlParam[2].Value = objBECommon.intCommentID;

                objBECommon.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_GetAlerts", objSqlParam).Tables[0];
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void DGetSelectedReportType1(BECommon objBECommon)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[5];

                objSqlParam[0] = new SqlParameter("@I_RoleID", SqlDbType.Int);
                objSqlParam[0].Value = objBECommon.IntRoleID;
                objSqlParam[1] = new SqlParameter("@I_ReportID", SqlDbType.Int);
                objSqlParam[1].Value = objBECommon.iReportID;
                objSqlParam[2] = new SqlParameter("@D_StartDate", SqlDbType.DateTime);
                if (objBECommon.DateStartDate != null && objBECommon.DateStartDate.ToShortDateString() != "1/1/0001")
                    objSqlParam[2].Value = objBECommon.DateStartDate;
                else
                    objSqlParam[2].Value = DBNull.Value;
                objSqlParam[3] = new SqlParameter("@D_EndDate", SqlDbType.DateTime);
                if (objBECommon.DateEndDate != null && objBECommon.DateEndDate.ToShortDateString() != "1/1/0001")
                    objSqlParam[3].Value = objBECommon.DateEndDate;
                else
                    objSqlParam[3].Value = DBNull.Value;
                objSqlParam[4] = new SqlParameter("@I_UserID", SqlDbType.Int);
                objSqlParam[4].Value = objBECommon.IntUserID;

                objBECommon.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Common_GetReport_Type1, objSqlParam).Tables[0];



            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }



        /// <summary>
        /// Get Selected Report
        /// </summary>
        /// <param name="objBECommon"></param>
        public void DGetSelectedReportType2(BECommon objBECommon)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[7];

                objSqlParam[0] = new SqlParameter("@I_RoleID", SqlDbType.Int);
                objSqlParam[0].Value = objBECommon.IntRoleID;
                objSqlParam[1] = new SqlParameter("@I_ReportID", SqlDbType.Int);
                objSqlParam[1].Value = objBECommon.iReportID;
                objSqlParam[2] = new SqlParameter("@V_CourseName", SqlDbType.VarChar, 500);
                objSqlParam[2].Value = objBECommon.strCourseName;
                objSqlParam[3] = new SqlParameter("@V_ExamName", SqlDbType.VarChar, 500);
                objSqlParam[3].Value = objBECommon.strExamName;
                objSqlParam[4] = new SqlParameter("@V_FirstName", SqlDbType.VarChar, 100);
                objSqlParam[4].Value = objBECommon.StrFirstName;
                objSqlParam[5] = new SqlParameter("@V_LastName", SqlDbType.VarChar, 100);
                objSqlParam[5].Value = objBECommon.StrLastName;
                objSqlParam[6] = new SqlParameter("@I_UserID", SqlDbType.Int);
                objSqlParam[6].Value = objBECommon.IntUserID;

                objBECommon.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Common_GetReport_Type2, objSqlParam).Tables[0];
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        public void DGetReportTypes(BECommon objBECommon)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[1];

                objSqlParam[0] = new SqlParameter("@I_RoleID", SqlDbType.Int);
                objSqlParam[0].Value = objBECommon.IntRoleID;


                objBECommon.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Common_GetReportsTypes, objSqlParam).Tables[0];



            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void DBindAllTools(BECommon objBECommon)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[0];

                objBECommon.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Common_GetExamTools, objSqlParam).Tables[0];

            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void DUpdateGotoMeeting(BECommon objBECommon)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[4];

                objSqlParam[0] = new SqlParameter("@I_TransID", SqlDbType.BigInt);
                objSqlParam[0].Value = objBECommon.TransID;

                objSqlParam[1] = new SqlParameter("@I_GotoMeetingID", SqlDbType.BigInt);

                objSqlParam[1].Value = objBECommon.GotoMeetingID;

                objSqlParam[2] = new SqlParameter("@B_Status", SqlDbType.Int);
                objSqlParam[2].Direction = ParameterDirection.Output;

                objSqlParam[3] = new SqlParameter("@I_MeetingType", SqlDbType.Int);
                objSqlParam[3].Value = objBECommon.intTypeID;

                SQLHelper.ExecuteScalar(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_Common_UpdateGotomeetingTransID", objSqlParam);

                objBECommon.IntstatusFlag = Convert.ToInt16(objSqlParam[2].Value.ToString());

            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void DBindNotesAndRules(BECommon objBECommon)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[0];

                objBECommon.DsResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Common_GetNotesAndRules, objSqlParam);

            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void DBindSelectedNotesAndRules(BECommon objBECommon)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[1];
                objSqlParam[0] = new SqlParameter("@ExamID", SqlDbType.Int);
                objSqlParam[0].Value = objBECommon.IntExamID;


                objBECommon.DsResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Common_GetSeletedNotesAndRules, objSqlParam);

            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void DGetStandardAndAdditionalRules(BECommon objBECommon)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[0];

                objBECommon.DsResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Common_ExamRules_GetStandardAndAdditionalRules, objSqlParam);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        //08nov2016
        public void DGetSpecialAdditionalRules(BECommon objBECommon)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[0];

                objBECommon.DsResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Common_ExamRules_GetSpecialAdditionalRules, objSqlParam);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void DGetExamRulesInformation(BECommon objBECommon)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[3];
                objSqlParam[0] = new SqlParameter("@ID", SqlDbType.BigInt);
                objSqlParam[0].Value = objBECommon.iID;
                objSqlParam[1] = new SqlParameter("@TypeID", SqlDbType.Int);
                objSqlParam[1].Value = objBECommon.iTypeID;
                objSqlParam[2] = new SqlParameter("@Role", SqlDbType.VarChar, 50);
                objSqlParam[2].Value = objBECommon.StrFromPage;


                objBECommon.DsResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Common_ExamRules_GetExamRules, objSqlParam);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        public void DGetAvailableTimeSlots(BECommon objBECommon)
        {

            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[4];

                objSqlParam[0] = new SqlParameter("@I_UserID", SqlDbType.Int);
                objSqlParam[0].Value = objBECommon.IntUserID;

                objSqlParam[1] = new SqlParameter("@I_OnDemand", SqlDbType.Int);
                objSqlParam[1].Value = objBECommon.intOndemand;

                objSqlParam[2] = new SqlParameter("@D_ExamDate", SqlDbType.VarChar, 50);
                objSqlParam[2].Value = objBECommon.dtExam.ToString("MM/dd/yyyy");

                objSqlParam[3] = new SqlParameter("@I_ExamID", SqlDbType.Int);
                objSqlParam[3].Value = objBECommon.IntExamID;

                objBECommon.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_GetAvailableTimeSlots, objSqlParam).Tables[0];
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        public void DDeleteUpdateAlerts(BECommon objBECommon)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[5];

                objSqlParam[0] = new SqlParameter("@I_TransID", SqlDbType.BigInt);
                objSqlParam[0].Value = objBECommon.IntTransID;
                objSqlParam[1] = new SqlParameter("@I_TypeID", SqlDbType.Int);
                objSqlParam[1].Value = objBECommon.intTypeID;
                objSqlParam[2] = new SqlParameter("@I_CommentID", SqlDbType.Int);
                objSqlParam[2].Value = objBECommon.intCommentID;
                objSqlParam[3] = new SqlParameter("@V_CommentDesc", SqlDbType.VarChar, 250);
                objSqlParam[3].Value = objBECommon.StrComments;
                objSqlParam[4] = new SqlParameter("@V_ID", SqlDbType.VarChar, 8000);
                objSqlParam[4].Value = objBECommon.strCommentID;

                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Common_AlertUpdateOrDelete, objSqlParam);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void DGetClientDetails(BECommon objBECommon)
        {
            try
            {
                objBECommon.DsResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_GetClientDetails);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void DGetUploadFiles(BECommon objBECommon)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[2];


                objSqlParam[0] = new SqlParameter("@TransID", SqlDbType.BigInt);
                objSqlParam[0].Value = objBECommon.iID;
                objSqlParam[1] = new SqlParameter("@Status", SqlDbType.Int);
                objSqlParam[1].Direction = ParameterDirection.Output;

                objBECommon.DsResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_GetStudentUploadFiles, objSqlParam);
                objBECommon.IntFlag = Convert.ToInt32(objSqlParam[1].Value);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void DGetExamUploadFiles(BECommon objBECommon)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[2];


                objSqlParam[0] = new SqlParameter("@ExamID", SqlDbType.BigInt);
                objSqlParam[0].Value = objBECommon.iID;
                objSqlParam[1] = new SqlParameter("@Status", SqlDbType.Int);
                objSqlParam[1].Direction = ParameterDirection.Output;

                objBECommon.DsResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_GetExamUploadFiles", objSqlParam);
                objBECommon.IntFlag = Convert.ToInt32(objSqlParam[1].Value);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        public void DGetStudentUploadFileStatus(BECommon objBECommon)
        {
            try
            {

                objBECommon.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Common_GetStudentUploadFileStatus).Tables[0];
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void DgetExamFileUploadStatus(BECommon objBECommon)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[1];

                objSqlParam[0] = new SqlParameter("@I_TransID", SqlDbType.BigInt);
                objSqlParam[0].Value = objBECommon.IntTransID;
                objBECommon.DsResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Common_getExamFileUploadStatus, objSqlParam);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void DGetSSOStatus(BECommon objBECommon)
        {
            try
            {
                //SqlParameter[] objSqlParam = new SqlParameter[1];

                //objSqlParam[0] = new SqlParameter("@SSO", SqlDbType.Bit);
                //objSqlParam[0].Direction = ParameterDirection.Output;

                objBECommon.DsResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Common_GetSSOStatus);

                //objBECommon.BoolResult = Convert.ToBoolean(objSqlParam[0].Value.ToString());
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        public void DAuditorCheckEmailForApproval(BECommon objBECommon)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[2];

                objSqlParam[0] = new SqlParameter("@TransID", SqlDbType.BigInt);
                objSqlParam[0].Value = objBECommon.IntTransID;
                objSqlParam[1] = new SqlParameter("@Result", SqlDbType.Int);
                objSqlParam[1].Direction = ParameterDirection.Output;

                SQLHelper.ExecuteScalar(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Auditor_CheckEmailForApproval, objSqlParam);

                objBECommon.IntstatusFlag = Convert.ToInt16(objSqlParam[1].Value.ToString());

            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public void DAuditorCheckVideoLink(BECommon objBECommon)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[2];
                objSqlParam[0] = new SqlParameter("@TransID", SqlDbType.BigInt);
                objSqlParam[0].Value = objBECommon.IntTransID;
                objSqlParam[1] = new SqlParameter("@Result", SqlDbType.Int);
                objSqlParam[1].Direction = ParameterDirection.Output;
                SQLHelper.ExecuteScalar(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_AuditorCheckVideoLink, objSqlParam);
                objBECommon.IntstatusFlag = Convert.ToInt16(objSqlParam[1].Value.ToString());

            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }



        public void DGetExamFeePerHour(BECommon objBECommon)
        {
            try
            {

                SqlParameter[] objSqlParam = new SqlParameter[1];
                objSqlParam[0] = new SqlParameter("@EXAMID", SqlDbType.Int);
                objSqlParam[0].Value = objBECommon.IntExamID;

                objBECommon.DsResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Common_GetAdditionalFeeperhour, objSqlParam);


            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public void DGetExamBillingDetails(BECommon objBECommon)
        {
            SqlParameter[] objPara = new SqlParameter[3];
            objPara[0] = new SqlParameter("@V_StartDate", SqlDbType.VarChar, 20);
            objPara[0].Value = objBECommon.DateStartDate.ToShortDateString();
            objPara[1] = new SqlParameter("@V_EndDate", SqlDbType.VarChar, 20);
            objPara[1].Value = objBECommon.DateEndDate.ToShortDateString();
            objPara[2] = new SqlParameter("@I_UserID", SqlDbType.BigInt);
            objPara[2].Value = objBECommon.IntUserID;
            //objPara[4] = new SqlParameter("@V_Status", SqlDbType.VarChar);
            //objPara[4].Value = objBECommon.strStatus;

            objBECommon.DsResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, StoredProcedures.USP_Admin_GETBILLINGDETAILS, objPara);
        }


        public void DGetCommentID(BECommon objBECommon)
        {
            try
            {

                SqlParameter[] objSqlParam = new SqlParameter[2];

                objSqlParam[0] = new SqlParameter("@I_CommentID", SqlDbType.Int);
                objSqlParam[0].Value = objBECommon.intCommentID;

                objBECommon.DsResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, "GetCommentID", objSqlParam);


            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public void DGetPorviderTimeDelay(BECommon objBECommon)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[1];
                objSqlParam[0] = new SqlParameter("@CourseID", SqlDbType.Int);
                objSqlParam[0].Value = objBECommon.IntCourseID;


                objBECommon.DsResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Common_GetPorviderTimeDelay, objSqlParam);
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #region DValidateTimeZone
        public void DValidateTimeZone(BECommon objBECommon)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[2];

                objSqlParam[0] = new SqlParameter("@I_UserID", SqlDbType.Int);
                objSqlParam[0].Value = objBECommon.IntUserID;
                objSqlParam[1] = new SqlParameter("@I_flag", SqlDbType.Int);
                objSqlParam[1].Direction = ParameterDirection.Output;

                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Common_ValidateTimeZone, objSqlParam);


                objBECommon.IntResult = Convert.ToInt32(objSqlParam[1].Value);


            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion


        public void DGetAdminTimeDelay(BECommon objBECommon)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[1];
                objSqlParam[0] = new SqlParameter("@UserID", SqlDbType.Int);
                objSqlParam[0].Value = objBECommon.IntUserID;


                objBECommon.DsResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_Common_GetAdminTimeDelay", objSqlParam);
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        public void DGetInstructors(BECommon objBECommon)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[1];

                objSqlParam[0] = new SqlParameter("@I_StudenID", SqlDbType.Int);
                objSqlParam[0].Value = objBECommon.IntUserID;

                objBECommon.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Common_getInstructors, objSqlParam).Tables[0];
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void DGetLMSSettings(BECommon objBECommon)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[2];
                objSqlParam[0] = new SqlParameter("@ID", SqlDbType.Int);
                objSqlParam[0].Value = objBECommon.iID;
                objSqlParam[1] = new SqlParameter("@Type", SqlDbType.Int);
                objSqlParam[1].Value = objBECommon.iTypeID;

                objBECommon.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Common_GetLMSSettings, objSqlParam).Tables[0];
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public void DUpdateFlowTimeStamp(BECommon objBECommon)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[2];
                objSqlParam[0] = new SqlParameter("@TransID", SqlDbType.BigInt);
                objSqlParam[0].Value = objBECommon.IntTransID;
                objSqlParam[1] = new SqlParameter("@FlowID", SqlDbType.Int);
                objSqlParam[1].Value = objBECommon.intTypeID;


                objBECommon.DsResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_Common_UpdateFlowTimeStamp", objSqlParam);
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public void DAddEndexamTimestamp(BECommon objBECommon)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[2];
                objSqlParam[0] = new SqlParameter("@TransID", SqlDbType.BigInt);
                objSqlParam[0].Value = objBECommon.IntTransID;
                objSqlParam[1] = new SqlParameter("@FlowID", SqlDbType.Int);
                objSqlParam[1].Value = objBECommon.intTypeID;


                objBECommon.DsResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_AddEndexamTimestamp", objSqlParam);
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void DSaveTransImage(BECommon objBECommon)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[4];

                objSqlParam[0] = new SqlParameter("@I_TransID", SqlDbType.BigInt);
                objSqlParam[0].Value = objBECommon.IntTransID;
                objSqlParam[1] = new SqlParameter("@B_Image", SqlDbType.Image);
                objSqlParam[1].Value = objBECommon.image;
                objSqlParam[2] = new SqlParameter("@I_Result", SqlDbType.Int);
                objSqlParam[2].Direction = ParameterDirection.Output;
                objSqlParam[3] = new SqlParameter("@V_SavedTime", SqlDbType.VarChar, 50);
                objSqlParam[3].Value = objBECommon.strTime;

                SQLHelper.ExecuteScalar(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_SaveTransImage", objSqlParam);
                objBECommon.IntstatusFlag = Convert.ToInt16(objSqlParam[2].Value.ToString());

            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void DSaveTransIDImage(BECommon objBECommon)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[4];

                objSqlParam[0] = new SqlParameter("@I_TransID", SqlDbType.BigInt);
                objSqlParam[0].Value = objBECommon.IntTransID;
                objSqlParam[1] = new SqlParameter("@B_Image", SqlDbType.Image);
                objSqlParam[1].Value = objBECommon.image;
                objSqlParam[2] = new SqlParameter("@I_Result", SqlDbType.Int);
                objSqlParam[2].Direction = ParameterDirection.Output;
                objSqlParam[3] = new SqlParameter("@V_SavedTime", SqlDbType.VarChar, 50);
                objSqlParam[3].Value = objBECommon.strTime;

                SQLHelper.ExecuteScalar(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_SaveTransIDImage", objSqlParam);
                objBECommon.IntstatusFlag = Convert.ToInt16(objSqlParam[2].Value.ToString());

            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void DGetExamDetails(BECommon objBECommon)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[2];

                objSqlParam[0] = new SqlParameter("@I_ExamID", SqlDbType.Int);
                objSqlParam[0].Value = objBECommon.IntExamID;
                objSqlParam[1] = new SqlParameter("@I_UserID", SqlDbType.Int);
                objSqlParam[1].Value = objBECommon.IntUserID;


                objBECommon.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_Common_GetExamDetails", objSqlParam).Tables[0];


            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public void DGetPaymentData(BECommon objBECommon)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[2];

                objSqlParam[0] = new SqlParameter("@I_ExamID", SqlDbType.Int);
                objSqlParam[0].Value = objBECommon.IntExamID;
                objSqlParam[1] = new SqlParameter("@I_Result", SqlDbType.Int);
                objSqlParam[1].Direction = ParameterDirection.Output;

                objBECommon.DsResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_GetPaymentData", objSqlParam);
                objBECommon.IntResult = Convert.ToInt16(objSqlParam[1].Value);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        public void DGetExamiKeyScore(BECommon objBECommon)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[2];

                objSqlParam[0] = new SqlParameter("@I_TransID", SqlDbType.BigInt);
                objSqlParam[0].Value = objBECommon.IntTransID;

                objSqlParam[1] = new SqlParameter("@I_KeyScore", SqlDbType.Int);
                objSqlParam[1].Direction = ParameterDirection.Output;

                SQLHelper.ExecuteScalar(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_Proctor_GetTimerExamKeyScore", objSqlParam);

                objBECommon.intExamiKeyScore = Convert.ToInt16(objSqlParam[1].Value.ToString());
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void DGetAAPaymentData(BECommon objBECommon)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[2];

                objSqlParam[0] = new SqlParameter("@I_ExamID", SqlDbType.BigInt);
                objSqlParam[0].Value = objBECommon.IntExamID1;
                objSqlParam[1] = new SqlParameter("@I_Result", SqlDbType.Int);
                objSqlParam[1].Direction = ParameterDirection.Output;

                objBECommon.DsResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_GetAAPaymentData", objSqlParam);
                objBECommon.IntResult = Convert.ToInt16(objSqlParam[1].Value);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        public void DDeleteRule(BECommon objBECommon)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[2];
                objSqlParam[0] = new SqlParameter("@RuleID", SqlDbType.Int);
                objSqlParam[0].Value = objBECommon.intRuleID;
                objSqlParam[1] = new SqlParameter("@ExamID", SqlDbType.Int);
                objSqlParam[1].Value = objBECommon.IntExamID;


                objBECommon.DsResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_DeleteRule", objSqlParam);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        public void DGetSpecialInstructions(BECommon objBECommon)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[1];

                objSqlParam[0] = new SqlParameter("@ExamID", SqlDbType.Int);
                objSqlParam[0].Value = objBECommon.IntExamID;


                objBECommon.DsResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_GetSpecialInstructions", objSqlParam);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        public void DUpdateSpecialInstruction(BECommon objBECommon)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[3];
                objSqlParam[0] = new SqlParameter("@RuleID", SqlDbType.Int);
                objSqlParam[0].Value = objBECommon.intRuleID;
                objSqlParam[1] = new SqlParameter("@ExamID", SqlDbType.Int);
                objSqlParam[1].Value = objBECommon.IntExamID;
                objSqlParam[2] = new SqlParameter("@RuleDesc", SqlDbType.VarChar, 5000);
                objSqlParam[2].Value = objBECommon.StrRuleDesc;



                objBECommon.DsResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_UpdateSpecialInstruction", objSqlParam);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        public void DAddSpecialInstruction(BECommon objBECommon)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[3];

                objSqlParam[0] = new SqlParameter("@ExamID", SqlDbType.Int);
                objSqlParam[0].Value = objBECommon.IntExamID;
                objSqlParam[1] = new SqlParameter("@RuleDesc", SqlDbType.VarChar, 5000);
                objSqlParam[1].Value = objBECommon.StrRuleDesc;
                objSqlParam[2] = new SqlParameter("@RoleTypeID", SqlDbType.Int);
                objSqlParam[2].Value = objBECommon.intRoleTypeID;



                objBECommon.DsResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_AddSpecialInstruction", objSqlParam);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        public void DUpdateSpecialInstructionFlags(BECommon objBECommon)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[3];

                objSqlParam[0] = new SqlParameter("@ExamID", SqlDbType.Int);
                objSqlParam[0].Value = objBECommon.IntExamID;
                objSqlParam[1] = new SqlParameter("@RuleID", SqlDbType.Int);
                objSqlParam[1].Value = objBECommon.intRuleID;
                objSqlParam[2] = new SqlParameter("@DisplayType", SqlDbType.Int);
                objSqlParam[2].Value = objBECommon.intDisplayType;



                objBECommon.DsResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_UpdateSpecialInstructionFlags", objSqlParam);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        public void DUpdateExamiLOCK(BECommon objBECommon)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[1];
                objSqlParam[0] = new SqlParameter("@TransID", SqlDbType.BigInt);
                objSqlParam[0].Value = objBECommon.IntTransID;



                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_Common_UpdateExamiLOCK", objSqlParam);
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void DReenableschedulestatus(BECommon objBECommon)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[1];
                objSqlParam[0] = new SqlParameter("@TransID", SqlDbType.BigInt);
                objSqlParam[0].Value = objBECommon.IntTransID;



                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_Common_UpdateSchedileStatus", objSqlParam);
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void DReenableBeginExamstatus(BECommon objBECommon)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[2];
                objSqlParam[0] = new SqlParameter("@TransID", SqlDbType.BigInt);
                objSqlParam[0].Value = objBECommon.IntTransID;
                objSqlParam[1] = new SqlParameter("@status", SqlDbType.Int);
                objSqlParam[1].Value = objBECommon.IntstatusFlag;
                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_Common_UpdateBiginExamStatus", objSqlParam);
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void DGetOpenTokAutoProctorStatus(BECommon objBECommon)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[2];

                objSqlParam[0] = new SqlParameter("@I_TransID", SqlDbType.BigInt);
                objSqlParam[0].Value = objBECommon.IntTransID;
                objSqlParam[1] = new SqlParameter("@I_Result", SqlDbType.Int);
                objSqlParam[1].Direction = ParameterDirection.Output;

                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_Common_OpenTokAutoProcotorStatus", objSqlParam);

                objBECommon.IntResult = Convert.ToInt32(objSqlParam[1].Value.ToString());
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        //
        public void DGetExamDetailsForExamityMeeting(BECommon objBECommon)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[1];

                objSqlParam[0] = new SqlParameter("@I_TransID", SqlDbType.BigInt);
                objSqlParam[0].Value = objBECommon.IntTransID;

                objBECommon.DsResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_Common_GetExamLinkDetails", objSqlParam);
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void DGetVideoVisibleStatus(BECommon objBECommon)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[2];
                objSqlParam[0] = new SqlParameter("@I_TransID", SqlDbType.BigInt);
                objSqlParam[0].Value = objBECommon.LngTransID;
                objSqlParam[1] = new SqlParameter("@I_Result", SqlDbType.Int);
                objSqlParam[1].Direction = ParameterDirection.Output;

                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_Common_GetVideoVisibleStatus", objSqlParam);

                objBECommon.IntResult = Convert.ToInt32(objSqlParam[1].Value.ToString());
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }

    }
}
