using System;
using BusinessEntities;
using System.Data.SqlClient;
using System.Data;


namespace DAL
{
    public class DProvider
    {
        #region DGetProviderExams
        public void DGetProviderExams(BEProvider objBEProvider)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[4];
                objSqlParam[0] = new SqlParameter("@V_ExamName", SqlDbType.VarChar, 100);
                objSqlParam[0].Value = objBEProvider.strExamName;
                objSqlParam[1] = new SqlParameter("@v_Name", SqlDbType.VarChar, 100);
                objSqlParam[1].Value = objBEProvider.strStudentName;
                objSqlParam[2] = new SqlParameter("@I_TransID", SqlDbType.BigInt);
                objSqlParam[2].Value = objBEProvider.IntTransID;
                objSqlParam[3] = new SqlParameter("@I_UserID", SqlDbType.Int);
                objSqlParam[3].Value = objBEProvider.IntUserID;

                //objSqlParam[1] = new SqlParameter("@I_Period", SqlDbType.Int);
                //objSqlParam[1].Value = objBEProvider.IntPeriod;


                objBEProvider.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Proctor_GetExamStatus, objSqlParam).Tables[0];

            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        public void DGetStudentsAndCourses(BEProvider objBEExamProvider)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[1];
                objSqlParam[0] = new SqlParameter("@UserID", SqlDbType.Int);
                objSqlParam[0].Value = objBEExamProvider.IntUserID;

                objBEExamProvider.DsResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Examprovider_GetStudentAndCourses, objSqlParam);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public void DProviderEnrollStudentCourse(BEProvider objBEExamProvider)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[4];
                objSqlParam[0] = new SqlParameter("@UserID", SqlDbType.BigInt);
                objSqlParam[0].Value = objBEExamProvider.IntUserID;
                objSqlParam[1] = new SqlParameter("@CourseID", SqlDbType.BigInt);
                objSqlParam[1].Value = objBEExamProvider.IntCourseID;
                objSqlParam[2] = new SqlParameter("@StudentID", SqlDbType.BigInt);
                objSqlParam[2].Value = objBEExamProvider.IntStudentID;
                objSqlParam[3] = new SqlParameter("@Flag", SqlDbType.Int);
                objSqlParam[3].Direction = ParameterDirection.Output;


                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_provider_EnrollStudentCourse, objSqlParam);

                objBEExamProvider.IntResult = Convert.ToInt32(objSqlParam[3].Value.ToString());
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void DGetStudentsDetails(BEProvider objBEExamProvider)
        {
            try
            {

                SqlParameter[] objSqlParam = new SqlParameter[4];

                objSqlParam[0] = new SqlParameter("@I_ProviderID", SqlDbType.Int);
                objSqlParam[0].Value = objBEExamProvider.IntProviderID;

                objSqlParam[1] = new SqlParameter("@StudentFirstName", SqlDbType.VarChar, 200);
                objSqlParam[1].Value = objBEExamProvider.strFirstName;

                objSqlParam[2] = new SqlParameter("@StudentLastName", SqlDbType.VarChar, 200);
                objSqlParam[2].Value = objBEExamProvider.strLastName;

                objSqlParam[3] = new SqlParameter("@StudentEmailAddress", SqlDbType.VarChar, 200);
                objSqlParam[3].Value = objBEExamProvider.strEmailAddress;

                objBEExamProvider.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Provider_GetStudentsDetails, objSqlParam).Tables[0];
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        /// <summary>
        /// Get Student Details
        /// </summary>
        /// <param name="objBEExamProvider"></param>
        public void DGetStudents(BEProvider objBEExamProvider)
        {
            try
            {
                objBEExamProvider.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Provider_GetStudents).Tables[0];
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        /// <summary>
        ///  Get Student Details
        /// </summary>
        /// <param name="objBECommon"></param>
        public void DGetStudentDetails(BEProvider objBEProvider)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[1];

                objSqlParam[0] = new SqlParameter("@I_StudentID", SqlDbType.Int);
                objSqlParam[0].Value = objBEProvider.IntStudentID;

                objBEProvider.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Provider_GetStudentDetails, objSqlParam).Tables[0];


            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        //#region DGetStudentDetails
        //public void DGetStudentDetails(BEProvider objBEExamProvider)
        //{
        //    try
        //    {
        //        SqlParameter[] objSqlParam = new SqlParameter[2];
        //        objSqlParam[0] = new SqlParameter("@V_Name", SqlDbType.VarChar, 50);
        //        if (objBEExamProvider.strStudentName.Length != 0)
        //            objSqlParam[0].Value = objBEExamProvider.strStudentName;
        //        else
        //            objSqlParam[0].Value = DBNull.Value;
        //        objSqlParam[1] = new SqlParameter("@UserID", SqlDbType.BigInt);
        //        objSqlParam[1].Value = objBEExamProvider.IntUserID;
        //        objBEExamProvider.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_GetStudents, objSqlParam).Tables[0];
        //    }
        //    catch (Exception Ex)
        //    {
        //        throw Ex;
        //    }
        //}
        //#endregion


        //#region DGetStudentEnrollments
        //public void DGetStudentEnrollments(BEProvider objBEExamProvider)
        //{
        //    try
        //    {
        //        SqlParameter[] objSqlParam = new SqlParameter[1];               
        //        objSqlParam[0] = new SqlParameter("@UserID", SqlDbType.BigInt);
        //        objSqlParam[0].Value = objBEExamProvider.IntUserID;
        //        objBEExamProvider.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_GetStudent_EnrollMents, objSqlParam).Tables[0];
        //    }
        //    catch (Exception Ex)
        //    {
        //        throw Ex;
        //    }
        //}
        //#endregion

        /// <summary>
        /// Get Student Enrollments
        /// </summary>
        /// <param name="objBEExamProvider"></param>
        public void DGetStudentEnrollments(BEProvider objBEExamProvider)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[2];

                objSqlParam[0] = new SqlParameter("@I_StudentID", SqlDbType.Int);
                objSqlParam[0].Value = objBEExamProvider.IntStudentID;

                objSqlParam[1] = new SqlParameter("@I_ProviderID", SqlDbType.Int);
                objSqlParam[1].Value = objBEExamProvider.IntUserID;

                objBEExamProvider.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Provider_GetStudentEnrollments, objSqlParam).Tables[0];
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        #region DSaveStudentDetails
        public void DSaveStudentDetails(BEProvider objBEExamProvider)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[6];
                objSqlParam[0] = new SqlParameter("@V_FirstName", SqlDbType.VarChar, 100);
                objSqlParam[0].Value = objBEExamProvider.strFirstName;
                objSqlParam[1] = new SqlParameter("@V_LastName", SqlDbType.VarChar, 100);
                objSqlParam[1].Value = objBEExamProvider.strLastName;
                objSqlParam[2] = new SqlParameter("@V_EmailAddress", SqlDbType.VarChar, 100);
                objSqlParam[2].Value = objBEExamProvider.strEmailAddress;
                objSqlParam[3] = new SqlParameter("@B_Flag", SqlDbType.Int);
                objSqlParam[3].Direction = ParameterDirection.Output;
                objSqlParam[4] = new SqlParameter("@V_SpecialNeeds", SqlDbType.VarChar, 100);
                objSqlParam[4].Value = objBEExamProvider.strSpecialNeeds;
                objSqlParam[5] = new SqlParameter("@V_Comments", SqlDbType.VarChar);
                objSqlParam[5].Value = objBEExamProvider.StrComments;

                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_ExamProvider_SaveStudentDetails, objSqlParam);
                objBEExamProvider.IntResult = int.Parse(objSqlParam[3].Value.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region DDeleteStudent
        public void DDeleteStudent(BEProvider objBEExamProvider)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[1];
                objSqlParam[0] = new SqlParameter("@I_StudentID", SqlDbType.Int);
                objSqlParam[0].Value = objBEExamProvider.IntStudentID;

                objBEExamProvider.DsResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_DeleteStudent, objSqlParam);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        public void DEnrollStudent(BEProvider objBEExamProvider)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[4];
                objSqlParam[0] = new SqlParameter("@UserID", SqlDbType.BigInt);
                objSqlParam[0].Value = objBEExamProvider.IntUserID;
                objSqlParam[1] = new SqlParameter("@CourseID", SqlDbType.BigInt);
                objSqlParam[1].Value = objBEExamProvider.IntCourseID;
                objSqlParam[2] = new SqlParameter("@StudentID", SqlDbType.BigInt);
                objSqlParam[2].Value = objBEExamProvider.IntExamID;
                objSqlParam[3] = new SqlParameter("@Flag", SqlDbType.Int);
                objSqlParam[3].Direction = ParameterDirection.Output;

                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Examprovider_EnroolStudent, objSqlParam);

                objBEExamProvider.IntResult = Convert.ToInt32(objSqlParam[3].Value.ToString());
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void DGetExistingExamDetails(BEProvider objBEExamProvider)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[3];
                objSqlParam[0] = new SqlParameter("@UserID", SqlDbType.Int);
                objSqlParam[0].Value = objBEExamProvider.IntUserID;
                objSqlParam[1] = new SqlParameter("@V_CourseName", SqlDbType.VarChar, 20);
                objSqlParam[1].Value = objBEExamProvider.strCourseName;
                objSqlParam[2] = new SqlParameter("@V_ExamName", SqlDbType.VarChar, 20);
                objSqlParam[2].Value = objBEExamProvider.strExamName;

                objBEExamProvider.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_ExamProvider_GetExistingExams, objSqlParam).Tables[0];
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void DValidateExam(BEProvider objBEExamProvider)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[4];
                objSqlParam[0] = new SqlParameter("@V_CourseID", SqlDbType.Int);
                objSqlParam[0].Value = objBEExamProvider.IntCourseID;
                objSqlParam[1] = new SqlParameter("@V_ExamName", SqlDbType.VarChar, 100);
                objSqlParam[1].Value = objBEExamProvider.strExamName;
                objSqlParam[2] = new SqlParameter("@I_Result", SqlDbType.Int);
                objSqlParam[2].Direction = ParameterDirection.Output;
                objSqlParam[3] = new SqlParameter("@I_UserID", SqlDbType.Int);
                objSqlParam[3].Value = objBEExamProvider.IntUserID;
                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_EP_CheckForExam, objSqlParam);

                objBEExamProvider.IntResult = int.Parse(objSqlParam[2].Value.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DAdminSaveExamDetails(BEProvider objBEExamProvider)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[16];
                objSqlParam[0] = new SqlParameter("@I_CourseID", SqlDbType.Int);
                objSqlParam[0].Value = objBEExamProvider.IntCourseID;
                objSqlParam[1] = new SqlParameter("@V_ExamName", SqlDbType.VarChar, 50);
                objSqlParam[1].Value = objBEExamProvider.strExamName;
                objSqlParam[2] = new SqlParameter("@D_ExamDuration", SqlDbType.VarChar, 50);
                objSqlParam[2].Precision = StoredProcedures.Precision;
                objSqlParam[2].Scale = StoredProcedures.Scale;
                objSqlParam[2].Value = objBEExamProvider.ddlHM;
                objSqlParam[3] = new SqlParameter("@V_ExamLink", SqlDbType.VarChar, 50);
                objSqlParam[3].Value = objBEExamProvider.strLinkAccessExam;
                objSqlParam[4] = new SqlParameter("@V_StartDate", SqlDbType.DateTime);
                objSqlParam[4].Value = objBEExamProvider.strExamStartDate;
                objSqlParam[5] = new SqlParameter("@V_EndDate", SqlDbType.DateTime);
                objSqlParam[5].Value = objBEExamProvider.strExamEndDate;
                objSqlParam[6] = new SqlParameter("@V_OpenBook", SqlDbType.Int);
                objSqlParam[6].Value = objBEExamProvider.strOpenBook;
                objSqlParam[7] = new SqlParameter("@V_Notes", SqlDbType.VarChar, 50);
                objSqlParam[7].Value = objBEExamProvider.strNotes;
                objSqlParam[8] = new SqlParameter("@Notes", SqlDbType.Structured);
                if (objBEExamProvider.DtResult != null)
                    objSqlParam[8].Value = objBEExamProvider.DtResult;
                else
                    objSqlParam[8].Value = getExamDataTable();
                objSqlParam[9] = new SqlParameter("@Rules", SqlDbType.Structured);
                if (objBEExamProvider.DtResult1 != null)
                    objSqlParam[9].Value = objBEExamProvider.DtResult1;
                else
                    objSqlParam[9].Value = getExamDataTable();
                objSqlParam[10] = new SqlParameter("@B_Flag", SqlDbType.Int);
                objSqlParam[10].Direction = ParameterDirection.Output;
                // objSqlParam[11] = new SqlParameter("@I_UserID", SqlDbType.BigInt);
                //  objSqlParam[11].Value = objBEExamProvider.IntUserID;
                //objSqlParam[11] = new SqlParameter("@Tool_Calc", SqlDbType.Int);
                //objSqlParam[11].Value = objBEExamProvider.intCalc;
                //objSqlParam[12] = new SqlParameter("@Tool_Notes", SqlDbType.Int);
                //objSqlParam[12].Value = objBEExamProvider.intStickyNotes;
                objSqlParam[11] = new SqlParameter("@ExamBufferTime", SqlDbType.Int);
                objSqlParam[11].Value = objBEExamProvider.IntBufferTime;
                objSqlParam[12] = new SqlParameter("@OriginalFileName", SqlDbType.VarChar, 200);
                objSqlParam[12].Value = objBEExamProvider.strOriginalFileName;
                objSqlParam[13] = new SqlParameter("@StoredFileName", SqlDbType.VarChar, 200);
                objSqlParam[13].Value = objBEExamProvider.strUploadPath;
                objSqlParam[14] = new SqlParameter("@ExamSecurity", SqlDbType.VarChar, 10);
                objSqlParam[14].Value = objBEExamProvider.strSecurityLevel;
                objSqlParam[15] = new SqlParameter("@ExamTools", SqlDbType.Structured);
                objSqlParam[15].Value = objBEExamProvider.DtTools;
                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_ADMIN_SAVEEXAMDETAILS, objSqlParam);

                objBEExamProvider.IntResult = int.Parse(objSqlParam[10].Value.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable getExamDataTable()
        {
            DataTable objDT = new DataTable();
            DataColumn objDC;
            objDC = new DataColumn("ID");
            objDT.Columns.Add(objDC);
            objDC = new DataColumn("Head");
            objDT.Columns.Add(objDC);
            objDC = new DataColumn("Text");
            objDT.Columns.Add(objDC);
            return objDT;
        }

        public void DViewExamDetails(BEProvider objBEExamProvider)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[1];
                objSqlParam[0] = new SqlParameter("@I_ExamID", SqlDbType.Int);
                objSqlParam[0].Value = objBEExamProvider.IntCourseID;

                objBEExamProvider.DsResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_ExamProvider_ViewExamDetails, objSqlParam);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DDeleteExamDetails(BEProvider objBEExamProvider)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[2];
                objSqlParam[0] = new SqlParameter("@I_ExamID", SqlDbType.BigInt);
                objSqlParam[0].Value = objBEExamProvider.IntExamID;
                objSqlParam[1] = new SqlParameter("@I_Flag", SqlDbType.Int);
                objSqlParam[1].Direction = ParameterDirection.Output;

                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_EXAMPROVIDER_DeleteExam, objSqlParam);

                objBEExamProvider.IntResult = int.Parse(objSqlParam[1].Value.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public void DUpdateExamDetails(BEProvider objBEExamProvider)
        //{
        //    try
        //    {
        //        SqlParameter[] objSqlParam = new SqlParameter[15];
        //        objSqlParam[0] = new SqlParameter("@D_ExamDuration", SqlDbType.VarChar, 50);
        //        objSqlParam[0].Precision = StoredProcedures.Precision;
        //        objSqlParam[0].Scale = StoredProcedures.Scale;
        //        objSqlParam[0].Value = objBEExamProvider.ddlHM;
        //        objSqlParam[1] = new SqlParameter("@V_EndDate", SqlDbType.DateTime);
        //        objSqlParam[1].Value = objBEExamProvider.strExamEndDate;
        //        objSqlParam[2] = new SqlParameter("@I_ExamID", SqlDbType.Int);
        //        objSqlParam[2].Value = objBEExamProvider.IntCourseID;
        //        objSqlParam[3] = new SqlParameter("@I_Flag", SqlDbType.Int);
        //        objSqlParam[3].Direction = ParameterDirection.Output;
        //        objSqlParam[4] = new SqlParameter("@V_StartDate", SqlDbType.DateTime);
        //        objSqlParam[4].Value = objBEExamProvider.strExamStartDate;
        //        objSqlParam[5] = new SqlParameter("@V_ExamLink", SqlDbType.VarChar, 2000);
        //        objSqlParam[5].Value = objBEExamProvider.strLinkAccessExam;
        //        objSqlParam[6] = new SqlParameter("@V_CourseName", SqlDbType.VarChar, 50);
        //        objSqlParam[6].Value = objBEExamProvider.strCourseName;
        //        objSqlParam[7] = new SqlParameter("@V_ExamName", SqlDbType.VarChar, 50);
        //        objSqlParam[7].Value = objBEExamProvider.strExamName;
        //        objSqlParam[8] = new SqlParameter("@V_Notes", SqlDbType.Structured);
        //        if (objBEExamProvider.DtResult != null)
        //            objSqlParam[8].Value = objBEExamProvider.DtResult;
        //        else
        //            objSqlParam[8].Value = getExamDataTable();
        //        objSqlParam[9] = new SqlParameter("@V_Rules", SqlDbType.Structured);
        //        if (objBEExamProvider.DtResult1 != null)
        //            objSqlParam[9].Value = objBEExamProvider.DtResult1;
        //        else
        //            objSqlParam[9].Value = getExamDataTable();
        //        //objSqlParam[10] = new SqlParameter("@Tool_Calc", SqlDbType.Int);
        //        //objSqlParam[10].Value = objBEExamProvider.intCalc;
        //        //objSqlParam[11] = new SqlParameter("@Tool_Notes", SqlDbType.Int);
        //        //objSqlParam[11].Value = objBEExamProvider.intStickyNotes;
        //        objSqlParam[10] = new SqlParameter("@ExamBufferTime", SqlDbType.Int);
        //        objSqlParam[10].Value = objBEExamProvider.IntBufferTime;
        //        objSqlParam[11] = new SqlParameter("@OriginalFileName", SqlDbType.VarChar, 200);
        //        objSqlParam[11].Value = objBEExamProvider.strOriginalFileName;
        //        objSqlParam[12] = new SqlParameter("@StoredFileName", SqlDbType.VarChar, 200);
        //        objSqlParam[12].Value = objBEExamProvider.strUploadPath;
        //        objSqlParam[13] = new SqlParameter("@ExamSecurity", SqlDbType.VarChar, 10);
        //        objSqlParam[13].Value = objBEExamProvider.strSecurityLevel;
        //        objSqlParam[14] = new SqlParameter("@ExamTools", SqlDbType.Structured);
        //        objSqlParam[14].Value = objBEExamProvider.DtTools;

        //        SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_ExamProvider_UpdateExamDetails, objSqlParam);

        //        objBEExamProvider.IntResult = int.Parse(objSqlParam[3].Value.ToString());
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        /// <summary>
        /// Update ExamDetails 
        /// </summary>
        /// <param name="objBEExamProvider"></param>
        public void DUpdateExamDetails(BEProvider objBEExamProvider)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[26];

                objSqlParam[0] = new SqlParameter("@I_ExamID", SqlDbType.Int);
                objSqlParam[0].Value = objBEExamProvider.IntExamID;
                objSqlParam[1] = new SqlParameter("@V_ExamName", SqlDbType.VarChar, 100);
                objSqlParam[1].Value = objBEExamProvider.strExamName;
                objSqlParam[2] = new SqlParameter("@D_ExamDuration", SqlDbType.VarChar, 50);
                objSqlParam[2].Precision = StoredProcedures.Precision;
                objSqlParam[2].Scale = StoredProcedures.Scale;
                objSqlParam[2].Value = objBEExamProvider.ddlHM;
                objSqlParam[3] = new SqlParameter("@V_ExamLink", SqlDbType.VarChar, 2000);
                objSqlParam[3].Value = objBEExamProvider.strLinkAccessExam;
                objSqlParam[4] = new SqlParameter("@V_StartDate", SqlDbType.DateTime);
                objSqlParam[4].Value = objBEExamProvider.dtExamStartDate;
                objSqlParam[5] = new SqlParameter("@V_EndDate", SqlDbType.DateTime);
                objSqlParam[5].Value = objBEExamProvider.dtExamEndDate;
                objSqlParam[6] = new SqlParameter("@AllowedRules", SqlDbType.Structured);
                if (objBEExamProvider.dtResult_Rules != null)
                    objSqlParam[6].Value = objBEExamProvider.dtResult_Rules;
                else
                    objSqlParam[6].Value = getAdditionalRulesDataTable();

                objSqlParam[7] = new SqlParameter("@SpecialRules", SqlDbType.Structured);
                if (objBEExamProvider.DtResult1 != null)
                    objSqlParam[7].Value = objBEExamProvider.DtResult1;
                else
                    objSqlParam[7].Value = getSpecialRulesDataTable();

                objSqlParam[8] = new SqlParameter("@B_Flag", SqlDbType.Int);
                objSqlParam[8].Direction = ParameterDirection.Output;
                objSqlParam[9] = new SqlParameter("@I_UserID", SqlDbType.BigInt);
                objSqlParam[9].Value = objBEExamProvider.IntUserID;
                //objSqlParam[10] = new SqlParameter("@ExamBufferTime", SqlDbType.Int);
                //objSqlParam[10].Value = objBEExamProvider.IntBufferTime;
                objSqlParam[10] = new SqlParameter("@SpecialNeedsFlag", SqlDbType.Bit);
                objSqlParam[10].Value = objBEExamProvider.strSpecialNeeds;
                objSqlParam[11] = new SqlParameter("@OriginalFileName", SqlDbType.VarChar, 200);
                objSqlParam[11].Value = objBEExamProvider.strOriginalFileName;
                objSqlParam[12] = new SqlParameter("@StoredFileName", SqlDbType.VarChar, 200);
                objSqlParam[12].Value = objBEExamProvider.strUploadPath;
                objSqlParam[13] = new SqlParameter("@SecurityLevel", SqlDbType.Int);
                objSqlParam[13].Value = objBEExamProvider.ddlSecurityLevel;
                objSqlParam[14] = new SqlParameter("@Status", SqlDbType.Int);
                objSqlParam[14].Value = objBEExamProvider.Intstatus;
                objSqlParam[15] = new SqlParameter("@ExamPassword", SqlDbType.VarChar, 50);
                objSqlParam[15].Value = objBEExamProvider.strPassword;
                objSqlParam[16] = new SqlParameter("@I_LockDownBrowser", SqlDbType.Bit);
                objSqlParam[16].Value = objBEExamProvider.intLockDownBrowser;
                objSqlParam[17] = new SqlParameter("@StudentUploadFile", SqlDbType.Bit);
                objSqlParam[17].Value = objBEExamProvider.intStudentUploadFile;
                objSqlParam[18] = new SqlParameter("@ExamFeePaidBy", SqlDbType.Int);
                objSqlParam[18].Value = objBEExamProvider.intExamFeePaidBy;
                objSqlParam[19] = new SqlParameter("@OnDemandFeePaidBy", SqlDbType.Int);
                objSqlParam[19].Value = objBEExamProvider.intOnDemandFeePaidBy;

                objSqlParam[20] = new SqlParameter("@ExamUserName", SqlDbType.VarChar, 250);
                objSqlParam[20].Value = objBEExamProvider.strExamUserName;
                objSqlParam[21] = new SqlParameter("@Files", SqlDbType.Structured);
                objSqlParam[21].Value = objBEExamProvider.DtResult;

                //objSqlParam[22] = new SqlParameter("@calValues", SqlDbType.VarChar, 250);//03nov2016
                //objSqlParam[22].Value = objBEExamProvider.CalValues;
                //objSqlParam[23] = new SqlParameter("@calText", SqlDbType.VarChar, 250);//03nov2016
                //objSqlParam[23].Value = objBEExamProvider.CalText;
                //objSqlParam[24] = new SqlParameter("@openText", SqlDbType.VarChar, 250);//03nov2016
                //objSqlParam[24].Value = objBEExamProvider.OpenBookText;

                objBEExamProvider.DsResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Provider_UpdateExamDetails, objSqlParam);

                objBEExamProvider.IntResult = int.Parse(objSqlParam[8].Value.ToString());

                //updating past rules flag
                if (objBEExamProvider.IntResult > 0)
                    DUpdateStatus(objBEExamProvider.IntExamID, objBEExamProvider.PastSpecialRules);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #region DUpdateStudentDetails
        public void DUpdateStudentDetails(BEProvider objBEExamProvider)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[8];
                objSqlParam[0] = new SqlParameter("@I_StudentID", SqlDbType.Int);
                objSqlParam[0].Value = objBEExamProvider.IntStudentID;
                objSqlParam[1] = new SqlParameter("@V_FirstName", SqlDbType.VarChar, 100);
                objSqlParam[1].Value = objBEExamProvider.strFirstName;
                objSqlParam[2] = new SqlParameter("@V_LastName", SqlDbType.VarChar, 100);
                objSqlParam[2].Value = objBEExamProvider.strLastName;
                objSqlParam[3] = new SqlParameter("@V_EmailAddress", SqlDbType.VarChar, 100);
                objSqlParam[3].Value = objBEExamProvider.strEmailAddress;
                objSqlParam[4] = new SqlParameter("@B_flag", SqlDbType.Int);
                objSqlParam[4].Direction = ParameterDirection.Output;
                objSqlParam[5] = new SqlParameter("@V_SpecialNeeds", SqlDbType.VarChar, 20);
                objSqlParam[5].Value = objBEExamProvider.strSpecialNeeds1;
                objSqlParam[6] = new SqlParameter("@V_Comments", SqlDbType.VarChar);
                objSqlParam[6].Value = objBEExamProvider.StrComments;
                objSqlParam[7] = new SqlParameter("@I_Status", SqlDbType.Int);
                objSqlParam[7].Value = objBEExamProvider.IntstatusFlag;

                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_GetUpdateStudentDetails, objSqlParam);

                objBEExamProvider.IntResult = int.Parse(objSqlParam[4].Value.ToString());
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        public void DUpdateStatus(BEProvider objBEExamProvider)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[3];
                objSqlParam[0] = new SqlParameter("@I_Status", SqlDbType.BigInt);
                objSqlParam[0].Value = objBEExamProvider.ddlStatus;
                objSqlParam[1] = new SqlParameter("@I_Flag", SqlDbType.Int);
                objSqlParam[1].Direction = ParameterDirection.Output;
                objSqlParam[2] = new SqlParameter("@I_EnrollId", SqlDbType.BigInt);
                objSqlParam[2].Value = objBEExamProvider.IntStudentID;

                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_EXAMPROVIDER_UpdateStudentStatus, objSqlParam);

                objBEExamProvider.IntResult = int.Parse(objSqlParam[1].Value.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DDeleteStatus(BEProvider objBEExamProvider)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[2];
                objSqlParam[0] = new SqlParameter("@I_EnrollID", SqlDbType.Int);
                objSqlParam[0].Value = objBEExamProvider.IntStudentID;
                objSqlParam[1] = new SqlParameter("@I_Flag", SqlDbType.Int);
                objSqlParam[1].Direction = ParameterDirection.Output;

                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_EXAMPROVIDER_DeleteEnrollStudent, objSqlParam);

                objBEExamProvider.IntResult = int.Parse(objSqlParam[1].Value.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DSaveCourseDetails(BEProvider objBEExamProvider)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[3];
                objSqlParam[0] = new SqlParameter("@V_Course_ID", SqlDbType.VarChar, 50);
                objSqlParam[0].Value = objBEExamProvider.strCourseID;

                objSqlParam[1] = new SqlParameter("@V_CourseName", SqlDbType.VarChar, 100);
                objSqlParam[1].Value = objBEExamProvider.strCourseName;

                objSqlParam[2] = new SqlParameter("@I_UserID", SqlDbType.Int);
                objSqlParam[2].Value = objBEExamProvider.IntUserID;

                objBEExamProvider.DsResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_ExamProvider_CreateCourse, objSqlParam);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        //public void DGetCourseDetails(BEProvider objBEExamProvider)
        //{
        //    try
        //    {
        //        SqlParameter[] objSqlParam = new SqlParameter[2];

        //        objSqlParam[0] = new SqlParameter("@I_UserID", SqlDbType.Int);
        //        objSqlParam[0].Value = objBEExamProvider.IntUserID;
        //        objSqlParam[1] = new SqlParameter("@I_CourseID", SqlDbType.Int);
        //        objSqlParam[1].Value = objBEExamProvider.IntCourseID;
        //        objBEExamProvider.DsResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_ExamProvider_GetCourses, objSqlParam);
        //    }
        //    catch (Exception Ex)
        //    {
        //        throw Ex;
        //    }
        //}

        /// <summary>
        /// Get Course Details For Selected Exam Provider
        /// </summary>
        /// <param name="objBEExamProvider"></param>
        public void DGetCourseDetails(BEProvider objBEExamProvider)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[1];

                objSqlParam[0] = new SqlParameter("@I_UserID", SqlDbType.Int);
                objSqlParam[0].Value = objBEExamProvider.IntUserID;

                objBEExamProvider.DsResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Provider_GetCourses, objSqlParam);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        //public void DUpdateCourseDetails(BEProvider objBEExamProvider)
        //{
        //    try
        //    {
        //        SqlParameter[] objSqlParam = new SqlParameter[4];

        //        objSqlParam[0] = new SqlParameter("@I_UserID", SqlDbType.Int);
        //        objSqlParam[0].Value = objBEExamProvider.IntUserID;
        //        objSqlParam[1] = new SqlParameter("@I_CourseID", SqlDbType.Int);
        //        objSqlParam[1].Value = objBEExamProvider.IntCourseID;
        //        objSqlParam[2] = new SqlParameter("@V_Course_ID", SqlDbType.VarChar, 50);
        //        objSqlParam[2].Value = objBEExamProvider.strCourseID;
        //        objSqlParam[3] = new SqlParameter("@V_CourseName", SqlDbType.VarChar,50);
        //        objSqlParam[3].Value = objBEExamProvider.strCourseName;
        //        objBEExamProvider.DsResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_ExamProvider_UpdateCourse, objSqlParam);
        //    }
        //    catch (Exception Ex)
        //    {
        //        throw Ex;
        //    }
        //}

        /// <summary>
        /// Update Course Details
        /// </summary>
        /// <param name="objBEExamProvider"></param>
        public void DUpdateCourseDetails(BEProvider objBEExamProvider)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[6];

                objSqlParam[0] = new SqlParameter("@I_CourseID", SqlDbType.Int);
                objSqlParam[0].Value = objBEExamProvider.IntCourseID;
                objSqlParam[1] = new SqlParameter("@V_Course_ID", SqlDbType.VarChar, 50);
                objSqlParam[1].Value = objBEExamProvider.strCourseID;
                objSqlParam[2] = new SqlParameter("@V_CourseName", SqlDbType.VarChar, 100);
                objSqlParam[2].Value = objBEExamProvider.strCourseName;
                objSqlParam[3] = new SqlParameter("@I_Status", SqlDbType.Int);
                objSqlParam[3].Value = objBEExamProvider.IntstatusFlag;
                objSqlParam[4] = new SqlParameter("@I_UserID", SqlDbType.Int);
                objSqlParam[4].Value = objBEExamProvider.IntstatusFlag;
                objSqlParam[5] = new SqlParameter("@I_Result", SqlDbType.Int);
                objSqlParam[5].Direction = ParameterDirection.Output;

                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Provider_UpdateCourseDetails, objSqlParam);

                objBEExamProvider.IntResult = Convert.ToInt32(objSqlParam[5].Value.ToString());
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        public void DAdminValidateExam(BEProvider objBEExamProvider)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[3];
                objSqlParam[0] = new SqlParameter("@V_CourseID", SqlDbType.Int);
                objSqlParam[0].Value = objBEExamProvider.IntCourseID;
                objSqlParam[1] = new SqlParameter("@V_ExamName", SqlDbType.VarChar, 100);
                objSqlParam[1].Value = objBEExamProvider.strExamName;
                objSqlParam[2] = new SqlParameter("@I_Result", SqlDbType.Int);
                objSqlParam[2].Direction = ParameterDirection.Output;

                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_ADMIN_EP_CheckForExam, objSqlParam);

                objBEExamProvider.IntResult = int.Parse(objSqlParam[2].Value.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public void DAdminEnrollStudent(BEProvider objBEExamProvider)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[4];
                objSqlParam[0] = new SqlParameter("@UserID", SqlDbType.BigInt);
                objSqlParam[0].Value = objBEExamProvider.IntUserID;
                objSqlParam[1] = new SqlParameter("@CourseID", SqlDbType.BigInt);
                objSqlParam[1].Value = objBEExamProvider.IntCourseID;
                objSqlParam[2] = new SqlParameter("@StudentID", SqlDbType.BigInt);
                objSqlParam[2].Value = objBEExamProvider.IntExamID;
                objSqlParam[3] = new SqlParameter("@Flag", SqlDbType.Int);
                objSqlParam[3].Direction = ParameterDirection.Output;

                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Admin_EnrolStudent, objSqlParam);

                objBEExamProvider.IntResult = Convert.ToInt32(objSqlParam[3].Value.ToString());
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        //public void DSaveExamDetails(BEProvider objBEExamProvider)
        //{
        //    try
        //    {
        //        SqlParameter[] objSqlParam = new SqlParameter[17];
        //        objSqlParam[0] = new SqlParameter("@I_CourseID", SqlDbType.Int);
        //        objSqlParam[0].Value = objBEExamProvider.IntCourseID;
        //        objSqlParam[1] = new SqlParameter("@V_ExamName", SqlDbType.VarChar, 50);
        //        objSqlParam[1].Value = objBEExamProvider.strExamName;
        //        objSqlParam[2] = new SqlParameter("@D_ExamDuration", SqlDbType.VarChar, 50);
        //        objSqlParam[2].Precision = StoredProcedures.Precision;
        //        objSqlParam[2].Scale = StoredProcedures.Scale;
        //        objSqlParam[2].Value = objBEExamProvider.ddlHM;
        //        objSqlParam[3] = new SqlParameter("@V_ExamLink", SqlDbType.VarChar, 2000);
        //        objSqlParam[3].Value = objBEExamProvider.strLinkAccessExam;
        //        objSqlParam[4] = new SqlParameter("@V_StartDate", SqlDbType.DateTime);
        //        objSqlParam[4].Value = objBEExamProvider.strExamStartDate;
        //        objSqlParam[5] = new SqlParameter("@V_EndDate", SqlDbType.DateTime);
        //        objSqlParam[5].Value = objBEExamProvider.strExamEndDate;
        //        objSqlParam[6] = new SqlParameter("@V_OpenBook", SqlDbType.Int);
        //        objSqlParam[6].Value = objBEExamProvider.strOpenBook;
        //        objSqlParam[7] = new SqlParameter("@V_Notes", SqlDbType.VarChar, 50);
        //        objSqlParam[7].Value = objBEExamProvider.strNotes;
        //        objSqlParam[8] = new SqlParameter("@Notes", SqlDbType.Structured);
        //        if (objBEExamProvider.DtResult != null)
        //            objSqlParam[8].Value = objBEExamProvider.DtResult;
        //        else
        //            objSqlParam[8].Value = getExamDataTable();
        //        objSqlParam[9] = new SqlParameter("@Rules", SqlDbType.Structured);
        //        if (objBEExamProvider.DtResult1 != null)
        //            objSqlParam[9].Value = objBEExamProvider.DtResult1;
        //        else
        //            objSqlParam[9].Value = getExamDataTable();
        //        objSqlParam[10] = new SqlParameter("@B_Flag", SqlDbType.Int);
        //        objSqlParam[10].Direction = ParameterDirection.Output;
        //        objSqlParam[11] = new SqlParameter("@I_UserID", SqlDbType.BigInt);
        //        objSqlParam[11].Value = objBEExamProvider.IntUserID;
        //        //objSqlParam[12] = new SqlParameter("@Tool_Calc", SqlDbType.Int);
        //        //objSqlParam[12].Value = objBEExamProvider.intCalc;
        //        //objSqlParam[13] = new SqlParameter("@Tool_Notes", SqlDbType.Int);
        //        //objSqlParam[13].Value = objBEExamProvider.intStickyNotes;
        //        objSqlParam[12] = new SqlParameter("@ExamBufferTime", SqlDbType.Int);
        //        objSqlParam[12].Value = objBEExamProvider.IntBufferTime;
        //        objSqlParam[13] = new SqlParameter("@OriginalFileName", SqlDbType.VarChar, 200);
        //        objSqlParam[13].Value = objBEExamProvider.strOriginalFileName;
        //        objSqlParam[14] = new SqlParameter("@StoredFileName", SqlDbType.VarChar, 200);
        //        objSqlParam[14].Value = objBEExamProvider.strUploadPath;
        //        objSqlParam[15] = new SqlParameter("@ExamSecurity", SqlDbType.VarChar, 10);
        //        objSqlParam[15].Value = objBEExamProvider.strSecurityLevel;
        //        objSqlParam[16] = new SqlParameter("@ExamTools", SqlDbType.Structured);
        //        objSqlParam[16].Value = objBEExamProvider.DtTools;

        //        SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_ExamProvider_SaveExamDetails, objSqlParam);

        //        objBEExamProvider.IntResult = int.Parse(objSqlParam[10].Value.ToString());
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        /// <summary>
        /// Save ExamDetails 
        /// </summary>
        /// <param name="objBEExamProvider"></param>
        public void DSaveExamDetails(BEProvider objBEExamProvider)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[30];

                objSqlParam[0] = new SqlParameter("@I_CourseID", SqlDbType.Int);
                objSqlParam[0].Value = objBEExamProvider.IntCourseID;
                objSqlParam[1] = new SqlParameter("@V_ExamName", SqlDbType.VarChar, 100);
                objSqlParam[1].Value = objBEExamProvider.strExamName;
                objSqlParam[2] = new SqlParameter("@D_ExamDuration", SqlDbType.VarChar, 50);
                objSqlParam[2].Precision = StoredProcedures.Precision;
                objSqlParam[2].Scale = StoredProcedures.Scale;
                objSqlParam[2].Value = objBEExamProvider.ddlHM;
                objSqlParam[3] = new SqlParameter("@V_ExamLink", SqlDbType.VarChar, 2000);
                objSqlParam[3].Value = objBEExamProvider.strLinkAccessExam;
                objSqlParam[4] = new SqlParameter("@V_StartDate", SqlDbType.DateTime);
                objSqlParam[4].Value = objBEExamProvider.strExamStartDate;
                objSqlParam[5] = new SqlParameter("@V_EndDate", SqlDbType.DateTime);
                objSqlParam[5].Value = objBEExamProvider.strExamEndDate;
                objSqlParam[6] = new SqlParameter("@V_OpenBook", SqlDbType.Int);
                objSqlParam[6].Value = objBEExamProvider.strOpenBook;
                objSqlParam[7] = new SqlParameter("@SpecialNeedsFlag", SqlDbType.Bit);
                objSqlParam[7].Value = objBEExamProvider.strSpecialNeeds;
                objSqlParam[8] = new SqlParameter("@Rules", SqlDbType.VarChar, 50);
                objSqlParam[8].Value = DBNull.Value;
                objSqlParam[9] = new SqlParameter("@B_Flag", SqlDbType.Int);
                objSqlParam[9].Direction = ParameterDirection.Output;
                objSqlParam[10] = new SqlParameter("@I_UserID", SqlDbType.BigInt);
                objSqlParam[10].Value = objBEExamProvider.IntUserID;
                objSqlParam[11] = new SqlParameter("@ExamBufferTime", SqlDbType.Int);
                objSqlParam[11].Value = objBEExamProvider.IntBufferTime;
                objSqlParam[12] = new SqlParameter("@OriginalFileName", SqlDbType.VarChar, 200);
                objSqlParam[12].Value = objBEExamProvider.strOriginalFileName;
                objSqlParam[13] = new SqlParameter("@StoredFileName", SqlDbType.VarChar, 200);
                objSqlParam[13].Value = objBEExamProvider.strUploadPath;
                objSqlParam[14] = new SqlParameter("@ExamLevel", SqlDbType.Int);
                objSqlParam[14].Value = objBEExamProvider.ddlSecurityLevel;
                objSqlParam[15] = new SqlParameter("@ExamPassword", SqlDbType.VarChar, 50);
                objSqlParam[15].Value = objBEExamProvider.strPassword;
                objSqlParam[16] = new SqlParameter("@AllowedRules", SqlDbType.Structured);
                if (objBEExamProvider.dtResult_Rules != null)
                    objSqlParam[16].Value = objBEExamProvider.dtResult_Rules;
                else
                    objSqlParam[16].Value = getAdditionalRulesDataTable();
                objSqlParam[17] = new SqlParameter("@SpecialRules", SqlDbType.Structured);
                if (objBEExamProvider.DtResult1 != null)
                    objSqlParam[17].Value = objBEExamProvider.DtResult1;
                else
                    objSqlParam[17].Value = getSpecialRulesDataTable();

                objSqlParam[18] = new SqlParameter("@I_LockDownBrowser", SqlDbType.Bit);
                objSqlParam[18].Value = objBEExamProvider.intLockDownBrowser;

                objSqlParam[19] = new SqlParameter("@StudentUploadFile", SqlDbType.Bit);
                objSqlParam[19].Value = objBEExamProvider.intStudentUploadFile;

                objSqlParam[20] = new SqlParameter("@ExamFeePaidBy", SqlDbType.Int);
                objSqlParam[20].Value = objBEExamProvider.intExamFeePaidBy;

                objSqlParam[21] = new SqlParameter("@OnDemandFeePaidBy", SqlDbType.Int);
                objSqlParam[21].Value = objBEExamProvider.intOnDemandFeePaidBy;

                objSqlParam[22] = new SqlParameter("@ExamUserName", SqlDbType.VarChar, 250);
                objSqlParam[22].Value = objBEExamProvider.strExamUserName;

                objSqlParam[23] = new SqlParameter("@Files", SqlDbType.Structured);
                objSqlParam[23].Value = objBEExamProvider.DtResult;

                //objSqlParam[24] = new SqlParameter("@calValues", SqlDbType.VarChar, 250);//03nov2016
                //objSqlParam[24].Value = objBEExamProvider.CalValues;

                //objSqlParam[25] = new SqlParameter("@calText", SqlDbType.VarChar, 250);//03nov2016
                //objSqlParam[25].Value = objBEExamProvider.CalText;

                //objSqlParam[26] = new SqlParameter("@openText", SqlDbType.VarChar, 250);//03nov2016
                //objSqlParam[26].Value = objBEExamProvider.OpenBookText;

                objBEExamProvider.DsResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Provider_SaveExamDetails, objSqlParam);

                objBEExamProvider.IntResult = int.Parse(objSqlParam[9].Value.ToString());

                //updating past rules flag
                if (objBEExamProvider.IntResult > 0)
                    DUpdateStatus(objBEExamProvider.IntResult, objBEExamProvider.PastSpecialRules);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void DSaveAdminUploads(BEProvider objBEExamProvider)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[3];


                objSqlParam[0] = new SqlParameter("@I_UserID", SqlDbType.BigInt);
                objSqlParam[0].Value = objBEExamProvider.IntUserID;
                objSqlParam[1] = new SqlParameter("@Files", SqlDbType.Structured);
                objSqlParam[1].Value = objBEExamProvider.DtResult;

                objBEExamProvider.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_Admin_SaveUploadFiles", objSqlParam).Tables[0];
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        public static DataTable getAdditionalRulesDataTable()
        {
            DataTable objDT = new DataTable();
            DataColumn objDC;
            objDC = new DataColumn("RuleID");
            objDT.Columns.Add(objDC);
            objDC = new DataColumn("RuleDesc");
            objDT.Columns.Add(objDC);
            objDC = new DataColumn("Status");
            objDT.Columns.Add(objDC);
            return objDT;
        }

        public DataTable getSpecialRulesDataTable()
        {
            DataTable objDT = new DataTable();
            DataColumn objDC;
            objDC = new DataColumn("RuleID");
            objDT.Columns.Add(objDC);
            objDC = new DataColumn("RuleDesc");
            objDT.Columns.Add(objDC);
            objDC = new DataColumn("Student");
            objDT.Columns.Add(objDC);
            objDC = new DataColumn("Proctor");
            objDT.Columns.Add(objDC);
            return objDT;
        }

        public void DDeleteUploadFiles(BEProvider objBEExamProvider)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[3];
                objSqlParam[0] = new SqlParameter("@I_ExamID", SqlDbType.Int);
                objSqlParam[0].Value = objBEExamProvider.IntExamID;

                objSqlParam[1] = new SqlParameter("@I_Flag", SqlDbType.Int);
                objSqlParam[1].Direction = ParameterDirection.Output;

                objSqlParam[2] = new SqlParameter("@v_StoredFileName", SqlDbType.VarChar,100);
                objSqlParam[2].Value = objBEExamProvider.strOriginalFileName;

                SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_ExamProvider_DeleteUploadFile, objSqlParam);

                objBEExamProvider.IntResult = int.Parse(objSqlParam[1].Value.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Get Exam Details for Selected Course
        /// </summary>
        /// <param name="objBEExamProvider"></param>
        public void DGetExamDetails(BEProvider objBEExamProvider)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[2];

                objSqlParam[0] = new SqlParameter("@I_CourseID", SqlDbType.Int);
                objSqlParam[0].Value = objBEExamProvider.IntCourseID;
                objSqlParam[1] = new SqlParameter("@I_UserID", SqlDbType.Int);
                objSqlParam[1].Value = objBEExamProvider.IntUserID;

                objBEExamProvider.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Provider_GetExams, objSqlParam).Tables[0];
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        /// <summary>
        /// Get Student Transactions associated with the current exam provider
        /// </summary>
        /// <param name="objBEExamProvider"></param>
        public void DGetStudentTransactionsForCurrentProvider(BEProvider objBEProvider)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[2];

                objSqlParam[0] = new SqlParameter("@I_StudentID", SqlDbType.Int);
                objSqlParam[0].Value = objBEProvider.IntStudentID;
                objSqlParam[1] = new SqlParameter("@I_ProviderID", SqlDbType.Int);
                objSqlParam[1].Value = objBEProvider.IntUserID;

                objBEProvider.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Provider_GetStudentExamTransactions, objSqlParam).Tables[0];

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Add Course
        /// </summary>
        /// <param name="objBEExamProvider"></param>
        public void DAddCourse(BEProvider objBEExamProvider)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[4];

                objSqlParam[0] = new SqlParameter("@V_CourseID", SqlDbType.VarChar, 50);
                objSqlParam[0].Value = objBEExamProvider.strCourseID;

                objSqlParam[1] = new SqlParameter("@V_CourseName", SqlDbType.VarChar, 100);
                objSqlParam[1].Value = objBEExamProvider.strCourseName;

                objSqlParam[2] = new SqlParameter("@I_UserID", SqlDbType.Int);
                objSqlParam[2].Value = objBEExamProvider.IntUserID;

                objSqlParam[3] = new SqlParameter("@I_Result", SqlDbType.Int);
                objSqlParam[3].Direction = ParameterDirection.Output;

                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Provider_AddCourse, objSqlParam);

                objBEExamProvider.IntResult = Convert.ToInt32(objSqlParam[3].Value.ToString());
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        /// <summary>
        /// Get Course Details For Selected Exam Provider
        /// </summary>
        /// <param name="objBEExamProvider"></param>
        public void DGetSelectedCourseDetails(BEProvider objBEExamProvider)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[1];

                objSqlParam[0] = new SqlParameter("@I_CourseID", SqlDbType.Int);
                objSqlParam[0].Value = objBEExamProvider.IntCourseID;

                objBEExamProvider.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Provider_GetSelectedCourseDetails, objSqlParam).Tables[0];
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        /// <summary>
        /// DDeleteCourse
        /// </summary>
        /// <param name="objBEProvider"></param>


        public void DDeleteCourse(BEProvider objBEExamProvider)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[2];
                objSqlParam[0] = new SqlParameter("@I_CourseID", SqlDbType.Int);
                objSqlParam[0].Value = objBEExamProvider.IntCourseID;

                objSqlParam[1] = new SqlParameter("@I_Flag", SqlDbType.Int);
                objSqlParam[1].Direction = ParameterDirection.Output;

                SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Provider_DeleteCourse, objSqlParam);

                objBEExamProvider.IntResult = int.Parse(objSqlParam[1].Value.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// DGetSelectedSecurityLevel
        /// </summary>
        /// <param name="objBEProvider"></param>
        public void DGetSelectedSecurityLevel(BEProvider objBEProvider)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[2];

                objSqlParam[0] = new SqlParameter("@I_SecurityLevel", SqlDbType.Int);
                objSqlParam[0].Value = objBEProvider.ddlSecurityLevel;
                objSqlParam[1] = new SqlParameter("@V_SecDesc", SqlDbType.VarChar, 500);
                objSqlParam[1].Direction = ParameterDirection.Output;

                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Provider_GetSecurityLevelDesc, objSqlParam);

                objBEProvider.StrResult = objSqlParam[1].Value.ToString();

            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        /// <summary>
        /// Add Student
        /// </summary>
        /// <param name="objBEExamProvider"></param>
        public void DAddStudent(BEProvider objBEProvider)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[10];
                objSqlParam[0] = new SqlParameter("@V_FirstName", SqlDbType.VarChar, 100);
                objSqlParam[0].Value = objBEProvider.strFirstName;
                objSqlParam[1] = new SqlParameter("@V_LastName", SqlDbType.VarChar, 100);
                objSqlParam[1].Value = objBEProvider.strLastName;
                objSqlParam[2] = new SqlParameter("@V_EmailID", SqlDbType.VarChar, 255);
                objSqlParam[2].Value = objBEProvider.strEmailAddress;
                objSqlParam[3] = new SqlParameter("@I_Flag", SqlDbType.Int);
                objSqlParam[3].Direction = ParameterDirection.Output;
                objSqlParam[4] = new SqlParameter("@B_SpecialNeeds", SqlDbType.Bit);
                objSqlParam[4].Value = objBEProvider.strSpecialNeeds;
                objSqlParam[5] = new SqlParameter("@V_Password", SqlDbType.VarChar, 50);
                objSqlParam[5].Value = objBEProvider.strPassword;
                objSqlParam[6] = new SqlParameter("@V_Comments", SqlDbType.VarChar);
                objSqlParam[6].Value = objBEProvider.StrComments;
                objSqlParam[7] = new SqlParameter("@I_CourseID", SqlDbType.Int);
                objSqlParam[7].Value = objBEProvider.IntCourseID;
                objSqlParam[8] = new SqlParameter("@I_ProviderID", SqlDbType.Int);
                objSqlParam[8].Value = objBEProvider.IntProviderID;
                objSqlParam[9] = new SqlParameter("@V_UserName", SqlDbType.VarChar, 200);
                objSqlParam[9].Value = objBEProvider.strUserName;
                

                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Provider_AddStudent, objSqlParam);

                objBEProvider.IntResult = int.Parse(objSqlParam[3].Value.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// DBindProviderSecurityLevel
        /// </summary>
        /// <param name="objBEProvider"></param>

        public void DBindProviderSecurityLevel(BEProvider objBEProvider)
        {
            try
            {


                objBEProvider.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Provider_ExamLevel).Tables[0];

            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        /// <summary>
        /// Find the Exam Existence while adding the new exam
        /// </summary>
        /// <param name="objBEExamProvider"></param>
        public void DCheckForExamExistence(BEProvider objBEExamProvider)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[4];
                objSqlParam[0] = new SqlParameter("@V_CourseID", SqlDbType.Int);
                objSqlParam[0].Value = objBEExamProvider.IntCourseID;
                objSqlParam[1] = new SqlParameter("@V_ExamName", SqlDbType.VarChar, 100);
                objSqlParam[1].Value = objBEExamProvider.strExamName;
                objSqlParam[2] = new SqlParameter("@I_Result", SqlDbType.Int);
                objSqlParam[2].Direction = ParameterDirection.Output;
                objSqlParam[3] = new SqlParameter("@I_UserID", SqlDbType.Int);
                objSqlParam[3].Value = objBEExamProvider.IntUserID;

                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Provider_CheckForExamExistence, objSqlParam);

                objBEExamProvider.IntResult = int.Parse(objSqlParam[2].Value.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get Course Details For Selected Exam Provider
        /// </summary>
        /// <param name="objBEExamProvider"></param>
        public void DGetSelectedExamDetails(BEProvider objBEExamProvider)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[1];

                objSqlParam[0] = new SqlParameter("@I_ExamID", SqlDbType.Int);
                objSqlParam[0].Value = objBEExamProvider.IntExamID;

                objBEExamProvider.DsResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Provider_GetSelectedExamDetails, objSqlParam);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        /// <summary>
        /// Delete Exam
        /// </summary>
        /// <param name="objBEExamProvider"></param>
        public void DDeleteExam(BEProvider objBEExamProvider)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[2];

                objSqlParam[0] = new SqlParameter("@I_ExamID", SqlDbType.Int);
                objSqlParam[0].Value = objBEExamProvider.IntExamID;

                objSqlParam[1] = new SqlParameter("@I_Status", SqlDbType.Int);
                objSqlParam[1].Direction = ParameterDirection.Output;

                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Provider_DeleteExam, objSqlParam);

                objBEExamProvider.IntResult = Convert.ToInt32(objSqlParam[1].Value.ToString());
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        /// <summary>
        /// DGetEnrollStudentName
        /// </summary>
        /// <param name="objBEProvider"></param>

        public void DGetStudentName(BEProvider objBEProvider)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[1];

                objSqlParam[0] = new SqlParameter("@I_UserID", SqlDbType.Int);
                objSqlParam[0].Value = objBEProvider.IntStudentID;

                objBEProvider.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Provider_GetStudentName, objSqlParam).Tables[0];

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// DGetProviderCourseDetails
        /// </summary>
        /// <param name="objBEProvider"></param>


        public void DGetProviderCourseDetails(BEProvider objBEProvider)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[1];

                objSqlParam[0] = new SqlParameter("@I_UserID", SqlDbType.Int);
                objSqlParam[0].Value = objBEProvider.IntUserID;

                objBEProvider.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Provider_GetProviderCourses, objSqlParam).Tables[0];

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// DProviderEnrollStudent
        /// </summary>
        /// <param name="objBEProvider"></param>
        public void DProviderEnrollStudent(BEProvider objBEExamProvider)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[4];
                objSqlParam[0] = new SqlParameter("@UserID", SqlDbType.BigInt);
                objSqlParam[0].Value = objBEExamProvider.IntUserID;
                objSqlParam[1] = new SqlParameter("@CourseID", SqlDbType.BigInt);
                objSqlParam[1].Value = objBEExamProvider.IntCourseID;
                objSqlParam[2] = new SqlParameter("@StudentID", SqlDbType.BigInt);
                objSqlParam[2].Value = objBEExamProvider.IntStudentID;
                objSqlParam[3] = new SqlParameter("@Flag", SqlDbType.Int);
                objSqlParam[3].Direction = ParameterDirection.Output;
              


                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_provider_EnrollStudent, objSqlParam);

                objBEExamProvider.IntResult = Convert.ToInt32(objSqlParam[3].Value.ToString());
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        public void DProviderEnrollSelectedStudents(BEProvider objBEExamProvider)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[5];
                objSqlParam[0] = new SqlParameter("@UserID", SqlDbType.BigInt);
                objSqlParam[0].Value = objBEExamProvider.IntUserID;
                objSqlParam[1] = new SqlParameter("@CourseID", SqlDbType.BigInt);
                objSqlParam[1].Value = objBEExamProvider.IntCourseID;
                objSqlParam[2] = new SqlParameter("@StudentID", SqlDbType.BigInt);
                objSqlParam[2].Value = objBEExamProvider.IntStudentID;
                objSqlParam[3] = new SqlParameter("@Flag", SqlDbType.Int);
                objSqlParam[3].Direction = ParameterDirection.Output;
                objSqlParam[4] = new SqlParameter("@TBL_Students", SqlDbType.Structured);
                objSqlParam[4].Value = objBEExamProvider.DtResult1;





                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_provider_EnrollSelectedStudents", objSqlParam);

                objBEExamProvider.IntResult = Convert.ToInt32(objSqlParam[3].Value.ToString());
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        /// <summary>
        /// DGetEnrollStudentDetails
        /// </summary>
        /// <param name="objBEProvider"></param>
        public void DGetEnrollStudentDetails(BEProvider objBEExamProvider)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[1];
                objSqlParam[0] = new SqlParameter("@I_EnrollID", SqlDbType.Int);
                objSqlParam[0].Value = objBEExamProvider.IntEnrollID;

                objBEExamProvider.DsResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Provider_GetEnrollStudentDetails, objSqlParam);
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        /// <summary>
        /// DUpdateStatus
        /// </summary>
        /// <param name="objBEProvider"></param>
        public void DUpdateEnrollStatus(BEProvider objBEExamProvider)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[3];
                objSqlParam[0] = new SqlParameter("@I_Status", SqlDbType.BigInt);
                objSqlParam[0].Value = objBEExamProvider.ddlStatus;
                objSqlParam[1] = new SqlParameter("@I_Flag", SqlDbType.Int);
                objSqlParam[1].Direction = ParameterDirection.Output;
                objSqlParam[2] = new SqlParameter("@I_EnrollId", SqlDbType.BigInt);
                objSqlParam[2].Value = objBEExamProvider.IntEnrollID;

                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Provider_UpdateStudentStatus, objSqlParam);

                objBEExamProvider.IntResult = int.Parse(objSqlParam[1].Value.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// DDeleteEnrollmentStatus
        /// </summary>
        /// <param name="objBEExamProvider"></param>
        public void DDeleteEnrollmentStatus(BEProvider objBEExamProvider)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[2];
                objSqlParam[0] = new SqlParameter("@I_EnrollID", SqlDbType.Int);
                objSqlParam[0].Value = objBEExamProvider.IntEnrollID;
                objSqlParam[1] = new SqlParameter("@I_Flag", SqlDbType.Int);
                objSqlParam[1].Direction = ParameterDirection.Output;

                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Provider_DeleteEnrollStudent, objSqlParam);

                objBEExamProvider.IntResult = int.Parse(objSqlParam[1].Value.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Find the Exam Existence while adding the new exam
        /// </summary>
        /// <param name="objBEExamProvider"></param>
        public void DCheckForUpdateExamExistence(BEProvider objBEExamProvider)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[3];

                objSqlParam[0] = new SqlParameter("@I_ExamID", SqlDbType.Int);
                objSqlParam[0].Value = objBEExamProvider.IntExamID;
                objSqlParam[1] = new SqlParameter("@V_ExamName", SqlDbType.VarChar, 100);
                objSqlParam[1].Value = objBEExamProvider.strExamName;
                objSqlParam[2] = new SqlParameter("@I_Result", SqlDbType.Int);
                objSqlParam[2].Direction = ParameterDirection.Output;

                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Provider_CheckForUpdateExamExistence, objSqlParam);

                objBEExamProvider.IntResult = int.Parse(objSqlParam[2].Value.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DGetProviderStudentsFiltered(BEProvider objBEExamProvider)
        {
            try
            {

                SqlParameter[] objSqlParam = new SqlParameter[1];

                objSqlParam[0] = new SqlParameter("@I_ProviderID", SqlDbType.Int);
                objSqlParam[0].Value = objBEExamProvider.IntProviderID;

                objBEExamProvider.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Provider_GetStudents_Filtered, objSqlParam).Tables[0];
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void DGetAllStudents(BEProvider objBEExamProvider)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[1];

                objSqlParam[0] = new SqlParameter("@I_ProviderID", SqlDbType.Int);
                objSqlParam[0].Value = objBEExamProvider.IntProviderID;
                objBEExamProvider.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_PROVIDER_GETALLSTUDENTS, objSqlParam).Tables[0];
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void DGetProviderCourses(BEProvider objBEExamProvider)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[1];

                objSqlParam[0] = new SqlParameter("@I_UserID", SqlDbType.Int);
                objSqlParam[0].Value = objBEExamProvider.IntProviderID;

                objBEExamProvider.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Provider_GetProviderCourses, objSqlParam).Tables[0];
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void DCheckTimeZone(BEProvider objBEProvider)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[2];

                objSqlParam[0] = new SqlParameter("@I_UserID", SqlDbType.Int);
                objSqlParam[0].Value = objBEProvider.IntUserID;

                objSqlParam[1] = new SqlParameter("@I_Flag", SqlDbType.Int);
                objSqlParam[1].Direction = ParameterDirection.Output;

               SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_Provider_checkTimeZone", objSqlParam);

               objBEProvider.IntResult = int.Parse(objSqlParam[1].Value.ToString());
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        public void DGetEditExamDetails(BEProvider objBEExamProvider)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[2];

                objSqlParam[0] = new SqlParameter("@I_ExamID", SqlDbType.Int);
                objSqlParam[0].Value = objBEExamProvider.IntExamID;
                objSqlParam[1] = new SqlParameter("@I_UserID", SqlDbType.Int);
                objSqlParam[1].Value = objBEExamProvider.IntUserID;

                objBEExamProvider.DsResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_Admin_GetEditExamDetails", objSqlParam);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void DGetStudentsNotInCourse(BEProvider objBEProvider)
        {

            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[1];

                objSqlParam[0] = new SqlParameter("@I_CourseID", SqlDbType.Int);
                objSqlParam[0].Value = objBEProvider.IntCourseID;

                objBEProvider.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Provider_GetStudentsNotInCourse, objSqlParam).Tables[0];
            }
            catch (Exception Ex)
            {

                throw Ex;
            }

        }
        public void DGetCourseStudents(BEProvider objBEExamProvider)
        {

            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[2];

                objSqlParam[0] = new SqlParameter("@I_CourseID", SqlDbType.Int);
                objSqlParam[0].Value = objBEExamProvider.IntCourseID;
                objSqlParam[1] = new SqlParameter("@I_ProviderID", SqlDbType.Int);
                objSqlParam[1].Value = objBEExamProvider.IntUserID;

                objBEExamProvider.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Provider_GetEnrolledStudents, objSqlParam).Tables[0];
            }
            catch (Exception Ex)
            {

                throw Ex;
            }

        }
        public void DGetCourseDetailsbyProvider(BEProvider objBEProvider)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[2];
                objSqlParam[0] = new SqlParameter("@I_CourseID", SqlDbType.Int);
                objSqlParam[0].Value = objBEProvider.IntCourseID;
                objSqlParam[1] = new SqlParameter("@I_ProviderID", SqlDbType.Int);
                objSqlParam[1].Value = objBEProvider.IntUserID;
                objBEProvider.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Provider_GetCourseDetailsbyProvider, objSqlParam).Tables[0];
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public void DUpdatePrimaryIns(BEProvider objBEProvider)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[3];
                objSqlParam[0] = new SqlParameter("@I_ProviderID", SqlDbType.Int);
                objSqlParam[0].Value = objBEProvider.IntProviderID;
                //objSqlParam[1] = new SqlParameter("@I_ProviderID", SqlDbType.Int);
                //objSqlParam[1].Value = objBEProvider.IntUserID;
                objSqlParam[1] = new SqlParameter("@IsPrimary", SqlDbType.Int);
                objSqlParam[1].Value = objBEProvider.intPrimaryIns;

                objBEProvider.DsResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_Admin_IsPrimaryIns", objSqlParam);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public void DCheckPrimaryIns(BEProvider objBEProvider)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[3];
                objSqlParam[0] = new SqlParameter("@I_ProviderID", SqlDbType.Int);
                objSqlParam[0].Value = objBEProvider.IntProviderID;
                objSqlParam[1] = new SqlParameter("@I_Flag", SqlDbType.Int);
                objSqlParam[1].Direction = ParameterDirection.Output;

                //objBEProvider.DsResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_Admin_GetIsPrimaryIns", objSqlParam);
                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_Admin_GetIsPrimaryIns", objSqlParam);

                objBEProvider.IntResult = int.Parse(objSqlParam[1].Value.ToString());
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        public void DGetAllCourseDetails(BEProvider objBEExamProvider)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[1];
                objSqlParam[0] = new SqlParameter("@UserID", SqlDbType.Int);
                objSqlParam[0].Value = objBEExamProvider.IntUserID;

                objBEExamProvider.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_Provider_GetAllCourses", objSqlParam).Tables[0];
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        //GetAdditionalRules
        public void DGetAdditionalRules(BEProvider objBEExamProvider)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[1];

                objSqlParam[0] = new SqlParameter("@I_ExamID", SqlDbType.Int);
                objSqlParam[0].Value = objBEExamProvider.IntExamID;


                objBEExamProvider.DsResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_Admin_GetAdditonalRules", objSqlParam);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void DUpdateStatus(int examId, int spId)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[3];
                objSqlParam[0] = new SqlParameter("@examId", SqlDbType.BigInt);
                objSqlParam[0].Value = examId;
                objSqlParam[1] = new SqlParameter("@spId", SqlDbType.BigInt);
                objSqlParam[1].Value = spId;

                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_UpdateSplInsFlagByExam", objSqlParam);


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
