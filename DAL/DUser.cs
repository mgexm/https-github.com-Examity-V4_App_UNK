using System;
using BusinessEntities;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class DUser
    {
        #region DValidateUser
        /// <summary>
        /// Validate User
        /// </summary>
        /// <param name="objBEUser"></param>
        public void DValidateUser(BEUser objBEUser)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[14];
                objSqlParam[0] = new SqlParameter("@V_UserName", SqlDbType.VarChar, 50);
                objSqlParam[0].Value = objBEUser.StrUserName;
                objSqlParam[1] = new SqlParameter("@V_Password", SqlDbType.VarChar, 50);
                objSqlParam[1].Value = objBEUser.StrPassword;
                objSqlParam[2] = new SqlParameter("@I_RoleId", SqlDbType.Int);
                objSqlParam[2].Direction = ParameterDirection.Output;
                objSqlParam[3] = new SqlParameter("@I_UserID", SqlDbType.Int);
                objSqlParam[3].Direction = ParameterDirection.Output;
                objSqlParam[4] = new SqlParameter("@B_Flag", SqlDbType.Int);
                objSqlParam[4].Direction = ParameterDirection.Output;
                objSqlParam[5] = new SqlParameter("@V_Name", SqlDbType.VarChar, 500);
                objSqlParam[5].Direction = ParameterDirection.Output;
                objSqlParam[6] = new SqlParameter("@B_pwdReset", SqlDbType.Bit);
                objSqlParam[6].Direction = ParameterDirection.Output;
                objSqlParam[7] = new SqlParameter("@V_UName", SqlDbType.VarChar, 50);
                objSqlParam[7].Direction = ParameterDirection.Output;
                objSqlParam[8] = new SqlParameter("@TimeZoneID", SqlDbType.Int);
                objSqlParam[8].Direction = ParameterDirection.Output;
                objSqlParam[9] = new SqlParameter("@TimeZoneName", SqlDbType.VarChar, 500);
                objSqlParam[9].Direction = ParameterDirection.Output;
                objSqlParam[10] = new SqlParameter("@B_LoginFlag", SqlDbType.Int);
                objSqlParam[10].Direction = ParameterDirection.Output;
                objSqlParam[11] = new SqlParameter("@PaidBy_ExamFee", SqlDbType.Int);
                objSqlParam[11].Direction = ParameterDirection.Output;
                objSqlParam[12] = new SqlParameter("@PaidBy_OndemandFee", SqlDbType.Int);
                objSqlParam[12].Direction = ParameterDirection.Output;
                objSqlParam[13] = new SqlParameter("@I_DualRole", SqlDbType.Int);
                objSqlParam[13].Direction = ParameterDirection.Output;
                //SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_USER_ValidateUser, objSqlParam);
                objBEUser.DsResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_USER_ValidateUser, objSqlParam);
                objBEUser.IntResult = int.Parse(objSqlParam[4].Value.ToString());
                if (objBEUser.IntResult != 0)
                {
                    objBEUser.IntRoleID = Convert.ToInt32(objSqlParam[2].Value.ToString());
                    objBEUser.IntUserID = Convert.ToInt32(objSqlParam[3].Value.ToString());
                    objBEUser.StrUserAliasName = objSqlParam[5].Value.ToString();
                    objBEUser.StrPasswordReset = objSqlParam[6].Value.ToString();
                    objBEUser.StrUserName = objSqlParam[7].Value.ToString();
                    objBEUser.IntTimeZoneID = Convert.ToInt32(objSqlParam[8].Value.ToString());
                    objBEUser.StringTimeZone = objSqlParam[9].Value.ToString();
                    objBEUser.loginflag = Convert.ToBoolean(objSqlParam[10].Value);
                    objBEUser.PaidBy_ExamFee = objSqlParam[11].Value.ToString();
                    objBEUser.PaidBy_OndemandFee = objSqlParam[12].Value.ToString();
                    objBEUser.intDualRole = Convert.ToInt32(objSqlParam[13].Value.ToString());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region DChangePassword
        public void DChangePassword(BEUser objBEUser)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[4];
                objSqlParam[0] = new SqlParameter("@V_oldPassword", SqlDbType.VarChar, 50);
                objSqlParam[0].Value = objBEUser.strOldPassword;
                objSqlParam[1] = new SqlParameter("@V_NewPassword", SqlDbType.VarChar, 50);
                objSqlParam[1].Value = objBEUser.strNewPassword;
                objSqlParam[2] = new SqlParameter("@I_UserID", SqlDbType.Int);
                objSqlParam[2].Value = objBEUser.IntUserID;

                objSqlParam[3] = new SqlParameter("@I_Flag", SqlDbType.Int);
                objSqlParam[3].Direction = ParameterDirection.Output;

                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_USER_ChangePassword, objSqlParam);

                objBEUser.IntResult = Convert.ToInt32(objSqlParam[3].Value);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion


        #region DGetProfileDetails
        public void DGetProfileDetails(BEUser objBEUser)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[1];
                objSqlParam[0] = new SqlParameter("@I_UserID", SqlDbType.Int);
                objSqlParam[0].Value = objBEUser.IntUserID;

                objBEUser.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Common_GetProfileDetails, objSqlParam).Tables[0];
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void DGetProfileExamiKeyDetails(BEUser objBEUser)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[1];
                objSqlParam[0] = new SqlParameter("@I_TransId", SqlDbType.BigInt);
                objSqlParam[0].Value = objBEUser.IntTransID;

                objBEUser.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_Common_GetProfileExamiKeyDetails", objSqlParam).Tables[0];
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        #region DGetTimeZone
        public void DGetTimeZone(BEUser objBEUser)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[1];

                objSqlParam[0] = new SqlParameter("@I_StudentID", SqlDbType.Int);
                objSqlParam[0].Value = objBEUser.IntUserID;

                objBEUser.DsResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Common_GetTimeZoneList, objSqlParam);
               
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        #region DGenderList
        public void DGenderList(BEUser objBEUser)
        {
            try
            {
                objBEUser.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_STUDENT_GetGenderList).Tables[0];
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        #region DForgotPassword
        public void DForgotPassword(BEUser objBEUser)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[5];
                objSqlParam[0] = new SqlParameter("@V_EmailID", SqlDbType.VarChar, 50);
                objSqlParam[0].Value = objBEUser.StrEmailID;
                objSqlParam[1] = new SqlParameter("@V_NewPassword", SqlDbType.VarChar, 50);
                objSqlParam[1].Value = objBEUser.StrRandomPassword;

                objSqlParam[2] = new SqlParameter("@B_Flag", SqlDbType.Int);
                objSqlParam[2].Direction = ParameterDirection.Output;

                objSqlParam[3] = new SqlParameter("@I_UserID", SqlDbType.Int);
                objSqlParam[3].Direction = ParameterDirection.Output;

                objSqlParam[4] = new SqlParameter("@V_EmailAddress", SqlDbType.VarChar,100);
                objSqlParam[4].Direction = ParameterDirection.Output;

                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_USER_ForgotPassword, objSqlParam);

                objBEUser.IntResult = Convert.ToInt32(objSqlParam[2].Value);
                objBEUser.IntUserID = Convert.ToInt32(objSqlParam[3].Value);
                objBEUser.StrEmailID = objSqlParam[4].Value.ToString();


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion


        #region DUpdateTimeZone
        public void DUpdateTimeZone(BEUser objBEUser)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[10];

                objSqlParam[0] = new SqlParameter("@I_UserID", SqlDbType.Int);
                objSqlParam[0].Value = objBEUser.IntUserID;

                objSqlParam[1] = new SqlParameter("@V_TimeZone", SqlDbType.VarChar, 20);
                objSqlParam[1].Value = objBEUser.strTimeZone;

                objSqlParam[2] = new SqlParameter("@I_flag", SqlDbType.Int);
                objSqlParam[2].Direction = ParameterDirection.Output;


                objSqlParam[3] = new SqlParameter("@V_FirstName", SqlDbType.VarChar, 50);
                objSqlParam[3].Value = objBEUser.StrFirstName;

                objSqlParam[4] = new SqlParameter("@V_LastName", SqlDbType.VarChar, 50);
                objSqlParam[4].Value = objBEUser.StrLastName;

                objSqlParam[5] = new SqlParameter("@V_Email", SqlDbType.VarChar, 50);
                objSqlParam[5].Value = objBEUser.StrEmail;

                objSqlParam[6] = new SqlParameter("@V_Gender", SqlDbType.VarChar, 20);
                objSqlParam[6].Value = objBEUser.StrGender;

                objSqlParam[7] = new SqlParameter("@V_PhoneNumber", SqlDbType.VarChar, 15);
                objSqlParam[7].Value = objBEUser.strPhoneNumber;

                objSqlParam[8] = new SqlParameter("@V_TimeZoneName", SqlDbType.VarChar, 500);
                objSqlParam[8].Direction = ParameterDirection.Output;
                objSqlParam[9] = new SqlParameter("@V_CountryCode", SqlDbType.VarChar, 15);
                objSqlParam[9].Value = objBEUser.CountryCode;



                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_STUDENT_UpdateTimeZone, objSqlParam);
                // objBEStudent.dtResult1 = SQLHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_STUDENT_GetTimeZoneList1, objSqlParam).Tables[1];

                objBEUser.IntResult = Convert.ToInt16(objSqlParam[2].Value);

                objBEUser.strTimeZone = objSqlParam[8].Value.ToString();
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        #region DValidateUser
        /// <summary>
        /// Validate User
        /// </summary>
        /// <param name="objBEUser"></param>
        public void DFindUser(BEUser objBEUser)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[12];
                objSqlParam[0] = new SqlParameter("@V_StudentCode", SqlDbType.VarChar, 50);
                objSqlParam[0].Value = objBEUser.strStudentCode;
                objSqlParam[1] = new SqlParameter("@I_RoleId", SqlDbType.Int);
                objSqlParam[1].Direction = ParameterDirection.Output;
                objSqlParam[2] = new SqlParameter("@I_UserID", SqlDbType.Int);
                objSqlParam[2].Direction = ParameterDirection.Output;
                objSqlParam[3] = new SqlParameter("@B_Flag", SqlDbType.Int);
                objSqlParam[3].Direction = ParameterDirection.Output;
                objSqlParam[4] = new SqlParameter("@V_Name", SqlDbType.VarChar, 500);
                objSqlParam[4].Direction = ParameterDirection.Output;
                objSqlParam[5] = new SqlParameter("@V_UName", SqlDbType.VarChar, 50);
                objSqlParam[5].Direction = ParameterDirection.Output;
                objSqlParam[6] = new SqlParameter("@TimeZoneID", SqlDbType.Int);
                objSqlParam[6].Direction = ParameterDirection.Output;
                objSqlParam[7] = new SqlParameter("@TimeZoneName", SqlDbType.VarChar, 50);
                objSqlParam[7].Direction = ParameterDirection.Output;
                objSqlParam[8] = new SqlParameter("@ProfileUpdate", SqlDbType.Int);
                objSqlParam[8].Direction = ParameterDirection.Output;
                objSqlParam[9] = new SqlParameter("@PaidBy_ExamFee", SqlDbType.Int);
                objSqlParam[9].Direction = ParameterDirection.Output;
                objSqlParam[10] = new SqlParameter("@PaidBy_OndemandFee", SqlDbType.Int);
                objSqlParam[10].Direction = ParameterDirection.Output;
                objSqlParam[11] = new SqlParameter("@I_DualRole", SqlDbType.Int);
                objSqlParam[11].Direction = ParameterDirection.Output;
                //SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_SSO_Login_ValidateUser", objSqlParam);
                objBEUser.DsResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_SSO_Login_ValidateUser", objSqlParam);
                objBEUser.IntResult = int.Parse(objSqlParam[3].Value.ToString());
                if (objBEUser.IntResult != 0)
                {
                    objBEUser.IntRoleID = int.Parse(objSqlParam[1].Value.ToString());
                    objBEUser.IntUserID = Convert.ToInt32(objSqlParam[2].Value.ToString());
                    objBEUser.StrUserAliasName = objSqlParam[4].Value.ToString();
                    objBEUser.StrUserName = objSqlParam[5].Value.ToString();
                    objBEUser.IntTimeZoneID = Convert.ToInt32(objSqlParam[6].Value.ToString());
                    objBEUser.StringTimeZone = objSqlParam[7].Value.ToString();
                    objBEUser.intProfileUpdate = Convert.ToInt32(objSqlParam[8].Value.ToString());
                    objBEUser.PaidBy_ExamFee = objSqlParam[9].Value.ToString();
                    objBEUser.PaidBy_OndemandFee = objSqlParam[10].Value.ToString();
                    objBEUser.intDualRole = Convert.ToInt32(objSqlParam[11].Value.ToString());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region DUpdateLoginFlag
        public void DUpdateLoginFlag(BEUser objBEUser)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[1];

                objSqlParam[0] = new SqlParameter("@I_UserID", SqlDbType.Int);
                objSqlParam[0].Value = objBEUser.IntUserID;

                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_STUDENT_UpdateUserLoginFlag, objSqlParam);
                // objBEStudent.dtResult1 = SQLHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_STUDENT_GetTimeZoneList1, objSqlParam).Tables[1];

                //objBEUser.IntResult = Convert.ToInt16(objSqlParam[2].Value);

                //objBEUser.strTimeZone = objSqlParam[7].Value.ToString();
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        #region DCanvasLogin
        public void DCanvasLogin(BEUser objBEUser)
        {
            SqlParameter[] objSqlParam = new SqlParameter[1];
            objSqlParam[0] = new SqlParameter("@V_UserName", SqlDbType.VarChar, 100);
            objSqlParam[0].Value = objBEUser.StrUserName;

            objBEUser.DsResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_CanvasLogin, objSqlParam);
        }
        #endregion

        #region DLMSLogin
        public void DLMSLogin(BEUser objBEUser)
        {
            SqlParameter[] objSqlParam = new SqlParameter[1];
            objSqlParam[0] = new SqlParameter("@V_UserName", SqlDbType.VarChar, 100);
            objSqlParam[0].Value = objBEUser.StrUserName;

            objBEUser.DsResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_LMSLogin, objSqlParam);
        }
        #endregion
        #region DCommonUpdateTimeZone
        public void DCommonUpdateTimeZone(BEUser objBEUser)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[3];
                objSqlParam[0] = new SqlParameter("@I_TimeZone", SqlDbType.Int);
                objSqlParam[0].Value = objBEUser.IntTimeZoneID;    
                objSqlParam[1] = new SqlParameter("@I_UserID", SqlDbType.Int);
                objSqlParam[1].Value = objBEUser.IntUserID;
                objSqlParam[2] = new SqlParameter("@I_Flag", SqlDbType.Int);
                objSqlParam[2].Direction = ParameterDirection.Output;

                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Common_UpdateTimeZone, objSqlParam);

                objBEUser.IntResult = Convert.ToInt32(objSqlParam[2].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region DValidatePortalUser
        /// <summary>
        /// Validate Portal User
        /// </summary>
        /// <param name="objBEUser"></param>
        public void DValidatePortalUser(BEUser objBEUser)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[16];
                objSqlParam[0] = new SqlParameter("@V_UserName", SqlDbType.VarChar, 50);
                objSqlParam[0].Value = objBEUser.StrUserName;
                objSqlParam[1] = new SqlParameter("@V_Role", SqlDbType.VarChar, 50);
                objSqlParam[1].Value = objBEUser.strRole;
                objSqlParam[2] = new SqlParameter("@I_RoleId", SqlDbType.Int);
                objSqlParam[2].Direction = ParameterDirection.Output;
                objSqlParam[3] = new SqlParameter("@I_UserID", SqlDbType.Int);
                objSqlParam[3].Direction = ParameterDirection.Output;
                objSqlParam[4] = new SqlParameter("@B_Flag", SqlDbType.Int);
                objSqlParam[4].Direction = ParameterDirection.Output;
                objSqlParam[5] = new SqlParameter("@V_Name", SqlDbType.VarChar, 500);
                objSqlParam[5].Direction = ParameterDirection.Output;
                objSqlParam[6] = new SqlParameter("@B_pwdReset", SqlDbType.Bit);
                objSqlParam[6].Direction = ParameterDirection.Output;
                objSqlParam[7] = new SqlParameter("@V_UName", SqlDbType.VarChar, 50);
                objSqlParam[7].Direction = ParameterDirection.Output;
                objSqlParam[8] = new SqlParameter("@TimeZoneID", SqlDbType.Int);
                objSqlParam[8].Direction = ParameterDirection.Output;
                objSqlParam[9] = new SqlParameter("@TimeZoneName", SqlDbType.VarChar, 500);
                objSqlParam[9].Direction = ParameterDirection.Output;
                objSqlParam[10] = new SqlParameter("@B_LoginFlag", SqlDbType.Int);
                objSqlParam[10].Direction = ParameterDirection.Output;
                objSqlParam[11] = new SqlParameter("@PaidBy_ExamFee", SqlDbType.Int);
                objSqlParam[11].Direction = ParameterDirection.Output;
                objSqlParam[12] = new SqlParameter("@PaidBy_OndemandFee", SqlDbType.Int);
                objSqlParam[12].Direction = ParameterDirection.Output;
                objSqlParam[13] = new SqlParameter("@I_DualRole", SqlDbType.Int);
                objSqlParam[13].Direction = ParameterDirection.Output;
                objSqlParam[14] = new SqlParameter("@B_IsExistingRole", SqlDbType.Int);
                objSqlParam[14].Direction = ParameterDirection.Output;
                
                objBEUser.DsResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_PortalSSO_ValidateUser, objSqlParam);
                objBEUser.IntResult = int.Parse(objSqlParam[4].Value.ToString());
                if (objBEUser.IntResult != 0)
                {
                    objBEUser.IntRoleID = Convert.ToInt32(objSqlParam[2].Value.ToString());
                    objBEUser.IntUserID = Convert.ToInt32(objSqlParam[3].Value.ToString());
                    objBEUser.StrUserAliasName = objSqlParam[5].Value.ToString();
                    objBEUser.StrPasswordReset = objSqlParam[6].Value.ToString();
                    objBEUser.StrUserName = objSqlParam[7].Value.ToString();
                    objBEUser.IntTimeZoneID = Convert.ToInt32(objSqlParam[8].Value.ToString());
                    objBEUser.StringTimeZone = objSqlParam[9].Value.ToString();
                    objBEUser.loginflag = Convert.ToBoolean(objSqlParam[10].Value);
                    objBEUser.PaidBy_ExamFee = objSqlParam[11].Value.ToString();
                    objBEUser.PaidBy_OndemandFee = objSqlParam[12].Value.ToString();
                    objBEUser.intDualRole = Convert.ToInt32(objSqlParam[13].Value.ToString());
                    objBEUser.IsExistingRoleUser = Convert.ToInt32(objSqlParam[14].Value.ToString());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        public void DSSO_ADDUSER(BEUser objBEUser, string LMSID)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[12];
                objSqlParam[0] = new SqlParameter("@V_UserId", SqlDbType.VarChar, 250);
                objSqlParam[0].Value = objBEUser.StrUserId;
                objSqlParam[1] = new SqlParameter("@V_FirstName", SqlDbType.VarChar, 250);
                objSqlParam[1].Value = objBEUser.StrFirstName;
                objSqlParam[2] = new SqlParameter("@V_LastName", SqlDbType.VarChar, 250);
                objSqlParam[2].Value = objBEUser.StrLastName;
                objSqlParam[3] = new SqlParameter("@V_FullName", SqlDbType.VarChar);
                objSqlParam[3].Value = objBEUser.strStudentName;
                objSqlParam[4] = new SqlParameter("@V_EmailAddress", SqlDbType.VarChar, 500);
                objSqlParam[4].Value = objBEUser.StrEmail;
                objSqlParam[5] = new SqlParameter("@V_CourseID", SqlDbType.VarChar, 8000);
                objSqlParam[5].Value = objBEUser.strCourseId;
                objSqlParam[6] = new SqlParameter("@V_CourseName", SqlDbType.VarChar, 8000);
                objSqlParam[6].Value = objBEUser.strCourseName;
                objSqlParam[7] = new SqlParameter("@V_user_id", SqlDbType.VarChar, 8000);
                objSqlParam[7].Value = objBEUser.strUser_Id;
                objSqlParam[8] = new SqlParameter("@V_Role", SqlDbType.VarChar, 8000);
                objSqlParam[8].Value = objBEUser.strRole;
                objSqlParam[9] = new SqlParameter("@V_LMSID", SqlDbType.VarChar, 250);
                objSqlParam[9].Value = LMSID;
                objSqlParam[10] = new SqlParameter("@TokenExists", SqlDbType.Bit);
                objSqlParam[10].Direction = ParameterDirection.Output;
                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_SSO_ADDUSER", objSqlParam);
                objBEUser.IntResult = Convert.ToInt32(objSqlParam[10].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void DSSO_SaveToken(string emailAddress, string token)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[2];
                objSqlParam[0] = new SqlParameter("@V_UserEmail", SqlDbType.VarChar, 500);
                objSqlParam[0].Value = emailAddress;
                objSqlParam[1] = new SqlParameter("@V_Token", SqlDbType.VarChar, 8000);
                objSqlParam[1].Value = token;
                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_SSO_SaveToken", objSqlParam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public void DPasswordExists(BEUser objBEUser)
        //{
        //    try
        //    {
        //        SqlParameter[] objSqlParam = new SqlParameter[4];
        //        objSqlParam[0] = new SqlParameter("@I_UserID", SqlDbType.Int);
        //        objSqlParam[0].Value = objBEUser.IntUserID;
        //        objSqlParam[1] = new SqlParameter("@V_Password", SqlDbType.VarChar, 100);
        //        objSqlParam[1].Value = objBEUser.StrPassword;
        //        objSqlParam[2] = new SqlParameter("@I_Flag", SqlDbType.Int);
        //        objSqlParam[2].Direction = ParameterDirection.Output;

        //        SQLHelper.ExecuteScalar(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.spPasswordExists, objSqlParam);

        //        objBEUser.IntResult = Convert.ToInt32(objSqlParam[2].Value);




        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}


        
    }
}
