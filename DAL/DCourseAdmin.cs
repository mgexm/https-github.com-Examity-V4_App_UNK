using System;
using BusinessEntities;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class DCourseAdmin
    {
        #region DGetProviderExams
        public void DGetProviderExams(BECourseAdmin objBECourseAdmin)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[4];
                objSqlParam[0] = new SqlParameter("@V_ExamName", SqlDbType.VarChar, 100);
                objSqlParam[0].Value = objBECourseAdmin.strExamName;
                objSqlParam[1] = new SqlParameter("@v_Name", SqlDbType.VarChar, 100);
                objSqlParam[1].Value = objBECourseAdmin.strStudentName;
                objSqlParam[2] = new SqlParameter("@I_TransID", SqlDbType.BigInt);
                objSqlParam[2].Value = objBECourseAdmin.IntTransID;
                objSqlParam[3] = new SqlParameter("@I_UserID", SqlDbType.Int);
                objSqlParam[3].Value = objBECourseAdmin.IntUserID;

                objBECourseAdmin.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_CourseAdmin_GetExamStatus, objSqlParam).Tables[0];

            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        public void DGetStudentsAndCourses(BECourseAdmin objBECourseAdmin)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[1];
                objSqlParam[0] = new SqlParameter("@UserID", SqlDbType.Int);
                objSqlParam[0].Value = objBECourseAdmin.IntUserID;

                objBECourseAdmin.DsResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_CourseAdmin_GetStudentAndCourses, objSqlParam);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public void DGetStudentsDetails(BECourseAdmin objBECourseAdmin)
        {

            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[4];

                objSqlParam[0] = new SqlParameter("@I_ProviderID", SqlDbType.Int);
                objSqlParam[0].Value = objBECourseAdmin.IntProviderID;

                objSqlParam[1] = new SqlParameter("@StudentFirstName", SqlDbType.VarChar, 200);
                objSqlParam[1].Value = objBECourseAdmin.strFirstName;

                objSqlParam[2] = new SqlParameter("@StudentLastName", SqlDbType.VarChar, 200);
                objSqlParam[2].Value = objBECourseAdmin.strLastName;

                objSqlParam[3] = new SqlParameter("@StudentEmailAddress", SqlDbType.VarChar, 200);
                objSqlParam[3].Value = objBECourseAdmin.strEmailAddress;

                objBECourseAdmin.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_CourseAdmin_GetStudentsDetails, objSqlParam).Tables[0];
            }
            catch (Exception Ex)
            {

                throw Ex;
            }

        }
        public void DProviderEnrollStudentCourse(BECourseAdmin objBECourseAdmin)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[4];
                objSqlParam[0] = new SqlParameter("@UserID", SqlDbType.BigInt);
                objSqlParam[0].Value = objBECourseAdmin.IntUserID;
                objSqlParam[1] = new SqlParameter("@CourseID", SqlDbType.BigInt);
                objSqlParam[1].Value = objBECourseAdmin.IntCourseID;
                objSqlParam[2] = new SqlParameter("@StudentID", SqlDbType.BigInt);
                objSqlParam[2].Value = objBECourseAdmin.IntStudentID;
                objSqlParam[3] = new SqlParameter("@Flag", SqlDbType.Int);
                objSqlParam[3].Direction = ParameterDirection.Output;


                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_CourseAdmin_EnrollStudentCourse, objSqlParam);

                objBECourseAdmin.IntResult = Convert.ToInt32(objSqlParam[3].Value.ToString());
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        /// <summary>
        /// Get Student Details
        /// </summary>
        /// <param name="objBECourseAdmin"></param>
        public void DGetStudents(BECourseAdmin objBECourseAdmin)
        {
            try
            {
                objBECourseAdmin.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Provider_GetStudents).Tables[0];
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
        public void DGetStudentDetails(BECourseAdmin objBECourseAdmin)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[1];

                objSqlParam[0] = new SqlParameter("@I_StudentID", SqlDbType.Int);
                objSqlParam[0].Value = objBECourseAdmin.IntStudentID;

                objBECourseAdmin.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_CourseAdmin_GetStudentDetails, objSqlParam).Tables[0];


            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        //#region DGetStudentDetails
        //public void DGetStudentDetails(BECourseAdmin objBECourseAdmin)
        //{
        //    try
        //    {
        //        SqlParameter[] objSqlParam = new SqlParameter[2];
        //        objSqlParam[0] = new SqlParameter("@V_Name", SqlDbType.VarChar, 50);
        //        if (objBECourseAdmin.strStudentName.Length != 0)
        //            objSqlParam[0].Value = objBECourseAdmin.strStudentName;
        //        else
        //            objSqlParam[0].Value = DBNull.Value;
        //        objSqlParam[1] = new SqlParameter("@UserID", SqlDbType.BigInt);
        //        objSqlParam[1].Value = objBECourseAdmin.IntUserID;
        //        objBECourseAdmin.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_GetStudents, objSqlParam).Tables[0];
        //    }
        //    catch (Exception Ex)
        //    {
        //        throw Ex;
        //    }
        //}
        //#endregion


        //#region DGetStudentEnrollments
        //public void DGetStudentEnrollments(BECourseAdmin objBECourseAdmin)
        //{
        //    try
        //    {
        //        SqlParameter[] objSqlParam = new SqlParameter[1];               
        //        objSqlParam[0] = new SqlParameter("@UserID", SqlDbType.BigInt);
        //        objSqlParam[0].Value = objBECourseAdmin.IntUserID;
        //        objBECourseAdmin.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_GetStudent_EnrollMents, objSqlParam).Tables[0];
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
        /// <param name="objBECourseAdmin"></param>
        public void DGetStudentEnrollments(BECourseAdmin objBECourseAdmin)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[2];

                objSqlParam[0] = new SqlParameter("@I_StudentID", SqlDbType.Int);
                objSqlParam[0].Value = objBECourseAdmin.IntStudentID;

                objSqlParam[1] = new SqlParameter("@I_ProviderID", SqlDbType.Int);
                objSqlParam[1].Value = objBECourseAdmin.IntUserID;

                objBECourseAdmin.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_CourseAdmin_GetStudentEnrollments, objSqlParam).Tables[0];
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        #region DSaveStudentDetails
        public void DSaveStudentDetails(BECourseAdmin objBECourseAdmin)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[6];
                objSqlParam[0] = new SqlParameter("@V_FirstName", SqlDbType.VarChar, 100);
                objSqlParam[0].Value = objBECourseAdmin.strFirstName;
                objSqlParam[1] = new SqlParameter("@V_LastName", SqlDbType.VarChar, 100);
                objSqlParam[1].Value = objBECourseAdmin.strLastName;
                objSqlParam[2] = new SqlParameter("@V_EmailAddress", SqlDbType.VarChar, 100);
                objSqlParam[2].Value = objBECourseAdmin.strEmailAddress;
                objSqlParam[3] = new SqlParameter("@B_Flag", SqlDbType.Int);
                objSqlParam[3].Direction = ParameterDirection.Output;
                objSqlParam[4] = new SqlParameter("@V_SpecialNeeds", SqlDbType.VarChar, 100);
                objSqlParam[4].Value = objBECourseAdmin.strSpecialNeeds;
                objSqlParam[5] = new SqlParameter("@V_Comments", SqlDbType.VarChar);
                objSqlParam[5].Value = objBECourseAdmin.StrComments;

                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_ExamProvider_SaveStudentDetails, objSqlParam);
                objBECourseAdmin.IntResult = int.Parse(objSqlParam[3].Value.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region DDeleteStudent
        public void DDeleteStudent(BECourseAdmin objBECourseAdmin)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[1];
                objSqlParam[0] = new SqlParameter("@I_StudentID", SqlDbType.Int);
                objSqlParam[0].Value = objBECourseAdmin.IntStudentID;

                objBECourseAdmin.DsResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_DeleteStudent, objSqlParam);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        public void DEnrollStudent(BECourseAdmin objBECourseAdmin)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[4];
                objSqlParam[0] = new SqlParameter("@UserID", SqlDbType.BigInt);
                objSqlParam[0].Value = objBECourseAdmin.IntUserID;
                objSqlParam[1] = new SqlParameter("@CourseID", SqlDbType.BigInt);
                objSqlParam[1].Value = objBECourseAdmin.IntCourseID;
                objSqlParam[2] = new SqlParameter("@StudentID", SqlDbType.BigInt);
                objSqlParam[2].Value = objBECourseAdmin.IntExamID;
                objSqlParam[3] = new SqlParameter("@Flag", SqlDbType.Int);
                objSqlParam[3].Direction = ParameterDirection.Output;

                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_CourseAdmin_EnroolStudent, objSqlParam);

                objBECourseAdmin.IntResult = Convert.ToInt32(objSqlParam[3].Value.ToString());
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void DGetExistingExamDetails(BECourseAdmin objBECourseAdmin)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[3];
                objSqlParam[0] = new SqlParameter("@UserID", SqlDbType.Int);
                objSqlParam[0].Value = objBECourseAdmin.IntUserID;
                objSqlParam[1] = new SqlParameter("@V_CourseName", SqlDbType.VarChar, 20);
                objSqlParam[1].Value = objBECourseAdmin.strCourseName;
                objSqlParam[2] = new SqlParameter("@V_ExamName", SqlDbType.VarChar, 20);
                objSqlParam[2].Value = objBECourseAdmin.strExamName;

                objBECourseAdmin.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_CourseAdmin_GetExistingExams, objSqlParam).Tables[0];
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void DValidateExam(BECourseAdmin objBECourseAdmin)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[4];
                objSqlParam[0] = new SqlParameter("@V_CourseID", SqlDbType.Int);
                objSqlParam[0].Value = objBECourseAdmin.IntCourseID;
                objSqlParam[1] = new SqlParameter("@V_ExamName", SqlDbType.VarChar, 100);
                objSqlParam[1].Value = objBECourseAdmin.strExamName;
                objSqlParam[2] = new SqlParameter("@I_Result", SqlDbType.Int);
                objSqlParam[2].Direction = ParameterDirection.Output;
                objSqlParam[3] = new SqlParameter("@I_UserID", SqlDbType.Int);
                objSqlParam[3].Value = objBECourseAdmin.IntUserID;
                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_EP_CheckForExam, objSqlParam);

                objBECourseAdmin.IntResult = int.Parse(objSqlParam[2].Value.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DAdminSaveExamDetails(BECourseAdmin objBECourseAdmin)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[16];
                objSqlParam[0] = new SqlParameter("@I_CourseID", SqlDbType.Int);
                objSqlParam[0].Value = objBECourseAdmin.IntCourseID;
                objSqlParam[1] = new SqlParameter("@V_ExamName", SqlDbType.VarChar, 50);
                objSqlParam[1].Value = objBECourseAdmin.strExamName;
                objSqlParam[2] = new SqlParameter("@D_ExamDuration", SqlDbType.VarChar, 50);
                objSqlParam[2].Precision = StoredProcedures.Precision;
                objSqlParam[2].Scale = StoredProcedures.Scale;
                objSqlParam[2].Value = objBECourseAdmin.ddlHM;
                objSqlParam[3] = new SqlParameter("@V_ExamLink", SqlDbType.VarChar, 50);
                objSqlParam[3].Value = objBECourseAdmin.strLinkAccessExam;
                objSqlParam[4] = new SqlParameter("@V_StartDate", SqlDbType.DateTime);
                objSqlParam[4].Value = objBECourseAdmin.strExamStartDate;
                objSqlParam[5] = new SqlParameter("@V_EndDate", SqlDbType.DateTime);
                objSqlParam[5].Value = objBECourseAdmin.strExamEndDate;
                objSqlParam[6] = new SqlParameter("@V_OpenBook", SqlDbType.Int);
                objSqlParam[6].Value = objBECourseAdmin.strOpenBook;
                objSqlParam[7] = new SqlParameter("@V_Notes", SqlDbType.VarChar, 50);
                objSqlParam[7].Value = objBECourseAdmin.strNotes;
                objSqlParam[8] = new SqlParameter("@Notes", SqlDbType.Structured);
                if (objBECourseAdmin.DtResult != null)
                    objSqlParam[8].Value = objBECourseAdmin.DtResult;
                else
                    objSqlParam[8].Value = getExamDataTable();
                objSqlParam[9] = new SqlParameter("@Rules", SqlDbType.Structured);
                if (objBECourseAdmin.DtResult1 != null)
                    objSqlParam[9].Value = objBECourseAdmin.DtResult1;
                else
                    objSqlParam[9].Value = getExamDataTable();
                objSqlParam[10] = new SqlParameter("@B_Flag", SqlDbType.Int);
                objSqlParam[10].Direction = ParameterDirection.Output;
                // objSqlParam[11] = new SqlParameter("@I_UserID", SqlDbType.BigInt);
                //  objSqlParam[11].Value = objBECourseAdmin.IntUserID;
                //objSqlParam[11] = new SqlParameter("@Tool_Calc", SqlDbType.Int);
                //objSqlParam[11].Value = objBECourseAdmin.intCalc;
                //objSqlParam[12] = new SqlParameter("@Tool_Notes", SqlDbType.Int);
                //objSqlParam[12].Value = objBECourseAdmin.intStickyNotes;
                objSqlParam[11] = new SqlParameter("@ExamBufferTime", SqlDbType.Int);
                objSqlParam[11].Value = objBECourseAdmin.IntBufferTime;
                objSqlParam[12] = new SqlParameter("@OriginalFileName", SqlDbType.VarChar, 200);
                objSqlParam[12].Value = objBECourseAdmin.strOriginalFileName;
                objSqlParam[13] = new SqlParameter("@StoredFileName", SqlDbType.VarChar, 200);
                objSqlParam[13].Value = objBECourseAdmin.strUploadPath;
                objSqlParam[14] = new SqlParameter("@ExamSecurity", SqlDbType.VarChar, 10);
                objSqlParam[14].Value = objBECourseAdmin.strSecurityLevel;
                objSqlParam[15] = new SqlParameter("@ExamTools", SqlDbType.Structured);
                objSqlParam[15].Value = objBECourseAdmin.DtTools;
                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_ADMIN_SAVEEXAMDETAILS, objSqlParam);

                objBECourseAdmin.IntResult = int.Parse(objSqlParam[10].Value.ToString());
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

        public void DViewExamDetails(BECourseAdmin objBECourseAdmin)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[1];
                objSqlParam[0] = new SqlParameter("@I_ExamID", SqlDbType.Int);
                objSqlParam[0].Value = objBECourseAdmin.IntCourseID;

                objBECourseAdmin.DsResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_CourseAdmin_ViewExamDetails, objSqlParam);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DDeleteExamDetails(BECourseAdmin objBECourseAdmin)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[2];
                objSqlParam[0] = new SqlParameter("@I_ExamID", SqlDbType.BigInt);
                objSqlParam[0].Value = objBECourseAdmin.IntExamID;
                objSqlParam[1] = new SqlParameter("@I_Flag", SqlDbType.Int);
                objSqlParam[1].Direction = ParameterDirection.Output;

                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_CourseAdmin_DeleteExam, objSqlParam);

                objBECourseAdmin.IntResult = int.Parse(objSqlParam[1].Value.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public void DUpdateExamDetails(BECourseAdmin objBECourseAdmin)
        //{
        //    try
        //    {
        //        SqlParameter[] objSqlParam = new SqlParameter[15];
        //        objSqlParam[0] = new SqlParameter("@D_ExamDuration", SqlDbType.VarChar, 50);
        //        objSqlParam[0].Precision = StoredProcedures.Precision;
        //        objSqlParam[0].Scale = StoredProcedures.Scale;
        //        objSqlParam[0].Value = objBECourseAdmin.ddlHM;
        //        objSqlParam[1] = new SqlParameter("@V_EndDate", SqlDbType.DateTime);
        //        objSqlParam[1].Value = objBECourseAdmin.strExamEndDate;
        //        objSqlParam[2] = new SqlParameter("@I_ExamID", SqlDbType.Int);
        //        objSqlParam[2].Value = objBECourseAdmin.IntCourseID;
        //        objSqlParam[3] = new SqlParameter("@I_Flag", SqlDbType.Int);
        //        objSqlParam[3].Direction = ParameterDirection.Output;
        //        objSqlParam[4] = new SqlParameter("@V_StartDate", SqlDbType.DateTime);
        //        objSqlParam[4].Value = objBECourseAdmin.strExamStartDate;
        //        objSqlParam[5] = new SqlParameter("@V_ExamLink", SqlDbType.VarChar, 2000);
        //        objSqlParam[5].Value = objBECourseAdmin.strLinkAccessExam;
        //        objSqlParam[6] = new SqlParameter("@V_CourseName", SqlDbType.VarChar, 50);
        //        objSqlParam[6].Value = objBECourseAdmin.strCourseName;
        //        objSqlParam[7] = new SqlParameter("@V_ExamName", SqlDbType.VarChar, 50);
        //        objSqlParam[7].Value = objBECourseAdmin.strExamName;
        //        objSqlParam[8] = new SqlParameter("@V_Notes", SqlDbType.Structured);
        //        if (objBECourseAdmin.DtResult != null)
        //            objSqlParam[8].Value = objBECourseAdmin.DtResult;
        //        else
        //            objSqlParam[8].Value = getExamDataTable();
        //        objSqlParam[9] = new SqlParameter("@V_Rules", SqlDbType.Structured);
        //        if (objBECourseAdmin.DtResult1 != null)
        //            objSqlParam[9].Value = objBECourseAdmin.DtResult1;
        //        else
        //            objSqlParam[9].Value = getExamDataTable();
        //        //objSqlParam[10] = new SqlParameter("@Tool_Calc", SqlDbType.Int);
        //        //objSqlParam[10].Value = objBECourseAdmin.intCalc;
        //        //objSqlParam[11] = new SqlParameter("@Tool_Notes", SqlDbType.Int);
        //        //objSqlParam[11].Value = objBECourseAdmin.intStickyNotes;
        //        objSqlParam[10] = new SqlParameter("@ExamBufferTime", SqlDbType.Int);
        //        objSqlParam[10].Value = objBECourseAdmin.IntBufferTime;
        //        objSqlParam[11] = new SqlParameter("@OriginalFileName", SqlDbType.VarChar, 200);
        //        objSqlParam[11].Value = objBECourseAdmin.strOriginalFileName;
        //        objSqlParam[12] = new SqlParameter("@StoredFileName", SqlDbType.VarChar, 200);
        //        objSqlParam[12].Value = objBECourseAdmin.strUploadPath;
        //        objSqlParam[13] = new SqlParameter("@ExamSecurity", SqlDbType.VarChar, 10);
        //        objSqlParam[13].Value = objBECourseAdmin.strSecurityLevel;
        //        objSqlParam[14] = new SqlParameter("@ExamTools", SqlDbType.Structured);
        //        objSqlParam[14].Value = objBECourseAdmin.DtTools;

        //        SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_ExamProvider_UpdateExamDetails, objSqlParam);

        //        objBECourseAdmin.IntResult = int.Parse(objSqlParam[3].Value.ToString());
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        /// <summary>
        /// Update ExamDetails 
        /// </summary>
        /// <param name="objBECourseAdmin"></param>
        public void DUpdateExamDetails(BECourseAdmin objBECourseAdmin)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[30];

                objSqlParam[0] = new SqlParameter("@I_ExamID", SqlDbType.Int);
                objSqlParam[0].Value = objBECourseAdmin.IntExamID;
                objSqlParam[1] = new SqlParameter("@V_ExamName", SqlDbType.VarChar, 100);
                objSqlParam[1].Value = objBECourseAdmin.strExamName;
                objSqlParam[2] = new SqlParameter("@D_ExamDuration", SqlDbType.VarChar, 50);
                objSqlParam[2].Precision = StoredProcedures.Precision;
                objSqlParam[2].Scale = StoredProcedures.Scale;
                objSqlParam[2].Value = objBECourseAdmin.ddlHM;
                objSqlParam[3] = new SqlParameter("@V_ExamLink", SqlDbType.VarChar, 2000);
                objSqlParam[3].Value = objBECourseAdmin.strLinkAccessExam;
                objSqlParam[4] = new SqlParameter("@V_StartDate", SqlDbType.DateTime);
                objSqlParam[4].Value = objBECourseAdmin.dtExamStartDate;
                objSqlParam[5] = new SqlParameter("@V_EndDate", SqlDbType.DateTime);
                objSqlParam[5].Value = objBECourseAdmin.dtExamEndDate;
                objSqlParam[6] = new SqlParameter("@AllowedRules", SqlDbType.Structured);
                if (objBECourseAdmin.dtResult_Rules != null)
                    objSqlParam[6].Value = objBECourseAdmin.dtResult_Rules;
                else
                    objSqlParam[6].Value = getAdditionalRulesDataTable();

                objSqlParam[7] = new SqlParameter("@SpecialRules", SqlDbType.Structured);
                if (objBECourseAdmin.DtResult1 != null)
                    objSqlParam[7].Value = objBECourseAdmin.DtResult1;
                else
                    objSqlParam[7].Value = getSpecialRulesDataTable();

                objSqlParam[8] = new SqlParameter("@B_Flag", SqlDbType.Int);
                objSqlParam[8].Direction = ParameterDirection.Output;
                objSqlParam[9] = new SqlParameter("@I_UserID", SqlDbType.BigInt);
                objSqlParam[9].Value = objBECourseAdmin.IntUserID;
                //objSqlParam[10] = new SqlParameter("@ExamBufferTime", SqlDbType.Int);
                //objSqlParam[10].Value = objBECourseAdmin.IntBufferTime;
                objSqlParam[10] = new SqlParameter("@SpecialNeedsFlag", SqlDbType.Bit);
                objSqlParam[10].Value = objBECourseAdmin.strSpecialNeeds;
                objSqlParam[11] = new SqlParameter("@OriginalFileName", SqlDbType.VarChar, 200);
                objSqlParam[11].Value = objBECourseAdmin.strOriginalFileName;
                objSqlParam[12] = new SqlParameter("@StoredFileName", SqlDbType.VarChar, 200);
                objSqlParam[12].Value = objBECourseAdmin.strUploadPath;
                objSqlParam[13] = new SqlParameter("@SecurityLevel", SqlDbType.Int);
                objSqlParam[13].Value = objBECourseAdmin.ddlSecurityLevel;
                objSqlParam[14] = new SqlParameter("@Status", SqlDbType.Int);
                objSqlParam[14].Value = objBECourseAdmin.Intstatus;
                objSqlParam[15] = new SqlParameter("@ExamPassword", SqlDbType.VarChar, 50);
                objSqlParam[15].Value = objBECourseAdmin.strPassword;
                objSqlParam[16] = new SqlParameter("@I_LockDownBrowser", SqlDbType.Bit);
                objSqlParam[16].Value = objBECourseAdmin.intLockDownBrowser;
                objSqlParam[17] = new SqlParameter("@StudentUploadFile", SqlDbType.Bit);
                objSqlParam[17].Value = objBECourseAdmin.intStudentUploadFile;
                objSqlParam[18] = new SqlParameter("@ExamFeePaidBy", SqlDbType.Int);
                objSqlParam[18].Value = objBECourseAdmin.intExamFeePaidBy;
                objSqlParam[19] = new SqlParameter("@OnDemandFeePaidBy", SqlDbType.Int);
                objSqlParam[19].Value = objBECourseAdmin.intOnDemandFeePaidBy;
                objSqlParam[20] = new SqlParameter("@ExamUserName", SqlDbType.VarChar, 250);
                objSqlParam[20].Value = objBECourseAdmin.strExamUserName;
                objSqlParam[21] = new SqlParameter("@Files", SqlDbType.Structured);
                objSqlParam[21].Value = objBECourseAdmin.DtResult;
                //objSqlParam[22] = new SqlParameter("@calValues", SqlDbType.VarChar, 250);//03nov2016
                //objSqlParam[22].Value = objBECourseAdmin.CalValues;
                //objSqlParam[23] = new SqlParameter("@calText", SqlDbType.VarChar, 250);//03nov2016
                //objSqlParam[23].Value = objBECourseAdmin.CalText;
                //objSqlParam[24] = new SqlParameter("@openText", SqlDbType.VarChar, 250);//03nov2016
                //objSqlParam[24].Value = objBECourseAdmin.OpenBookText;

                objBECourseAdmin.DsResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_CourseAdmin_UpdateExamDetails, objSqlParam);

                objBECourseAdmin.IntResult = int.Parse(objSqlParam[8].Value.ToString());
                //updating past rules flag
                if (objBECourseAdmin.IntResult > 0)
                    DUpdateStatus(objBECourseAdmin.IntExamID, objBECourseAdmin.PastSpecialRules);




            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #region DUpdateStudentDetails
        public void DUpdateStudentDetails(BECourseAdmin objBECourseAdmin)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[8];
                objSqlParam[0] = new SqlParameter("@I_StudentID", SqlDbType.Int);
                objSqlParam[0].Value = objBECourseAdmin.IntStudentID;
                objSqlParam[1] = new SqlParameter("@V_FirstName", SqlDbType.VarChar, 100);
                objSqlParam[1].Value = objBECourseAdmin.strFirstName;
                objSqlParam[2] = new SqlParameter("@V_LastName", SqlDbType.VarChar, 100);
                objSqlParam[2].Value = objBECourseAdmin.strLastName;
                objSqlParam[3] = new SqlParameter("@V_EmailAddress", SqlDbType.VarChar, 100);
                objSqlParam[3].Value = objBECourseAdmin.strEmailAddress;
                objSqlParam[4] = new SqlParameter("@B_flag", SqlDbType.Int);
                objSqlParam[4].Direction = ParameterDirection.Output;
                objSqlParam[5] = new SqlParameter("@V_SpecialNeeds", SqlDbType.VarChar, 20);
                objSqlParam[5].Value = objBECourseAdmin.strSpecialNeeds1;
                objSqlParam[6] = new SqlParameter("@V_Comments", SqlDbType.VarChar);
                objSqlParam[6].Value = objBECourseAdmin.StrComments;
                objSqlParam[7] = new SqlParameter("@I_Status", SqlDbType.Int);
                objSqlParam[7].Value = objBECourseAdmin.IntstatusFlag;

                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_GetUpdateStudentDetails, objSqlParam);

                objBECourseAdmin.IntResult = int.Parse(objSqlParam[4].Value.ToString());
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        public void DUpdateStatus(BECourseAdmin objBECourseAdmin)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[3];
                objSqlParam[0] = new SqlParameter("@I_Status", SqlDbType.BigInt);
                objSqlParam[0].Value = objBECourseAdmin.ddlStatus;
                objSqlParam[1] = new SqlParameter("@I_Flag", SqlDbType.Int);
                objSqlParam[1].Direction = ParameterDirection.Output;
                objSqlParam[2] = new SqlParameter("@I_EnrollId", SqlDbType.BigInt);
                objSqlParam[2].Value = objBECourseAdmin.IntStudentID;

                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_EXAMPROVIDER_UpdateStudentStatus, objSqlParam);

                objBECourseAdmin.IntResult = int.Parse(objSqlParam[1].Value.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DDeleteStatus(BECourseAdmin objBECourseAdmin)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[2];
                objSqlParam[0] = new SqlParameter("@I_EnrollID", SqlDbType.Int);
                objSqlParam[0].Value = objBECourseAdmin.IntStudentID;
                objSqlParam[1] = new SqlParameter("@I_Flag", SqlDbType.Int);
                objSqlParam[1].Direction = ParameterDirection.Output;

                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_EXAMPROVIDER_DeleteEnrollStudent, objSqlParam);

                objBECourseAdmin.IntResult = int.Parse(objSqlParam[1].Value.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DSaveCourseDetails(BECourseAdmin objBECourseAdmin)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[3];
                objSqlParam[0] = new SqlParameter("@V_Course_ID", SqlDbType.VarChar, 50);
                objSqlParam[0].Value = objBECourseAdmin.strCourseID;

                objSqlParam[1] = new SqlParameter("@V_CourseName", SqlDbType.VarChar, 100);
                objSqlParam[1].Value = objBECourseAdmin.strCourseName;

                objSqlParam[2] = new SqlParameter("@I_UserID", SqlDbType.Int);
                objSqlParam[2].Value = objBECourseAdmin.IntUserID;

                objBECourseAdmin.DsResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_ExamProvider_CreateCourse, objSqlParam);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        /// <summary>
        /// Get Course Details For Selected Course Admin
        /// </summary>
        /// <param name="objBECourseAdmin"></param>
        public void DGetCourseDetails(BECourseAdmin objBECourseAdmin)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[1];

                objSqlParam[0] = new SqlParameter("@I_UserID", SqlDbType.Int);
                objSqlParam[0].Value = objBECourseAdmin.IntUserID;

                objBECourseAdmin.DsResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_CourseAdmin_GetCourses, objSqlParam);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        //public void DUpdateCourseDetails(BECourseAdmin objBECourseAdmin)
        //{
        //    try
        //    {
        //        SqlParameter[] objSqlParam = new SqlParameter[4];

        //        objSqlParam[0] = new SqlParameter("@I_UserID", SqlDbType.Int);
        //        objSqlParam[0].Value = objBECourseAdmin.IntUserID;
        //        objSqlParam[1] = new SqlParameter("@I_CourseID", SqlDbType.Int);
        //        objSqlParam[1].Value = objBECourseAdmin.IntCourseID;
        //        objSqlParam[2] = new SqlParameter("@V_Course_ID", SqlDbType.VarChar, 50);
        //        objSqlParam[2].Value = objBECourseAdmin.strCourseID;
        //        objSqlParam[3] = new SqlParameter("@V_CourseName", SqlDbType.VarChar,50);
        //        objSqlParam[3].Value = objBECourseAdmin.strCourseName;
        //        objBECourseAdmin.DsResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_ExamProvider_UpdateCourse, objSqlParam);
        //    }
        //    catch (Exception Ex)
        //    {
        //        throw Ex;
        //    }
        //}

        /// <summary>
        /// Update Course Details
        /// </summary>
        /// <param name="objBECourseAdmin"></param>
        public void DUpdateCourseDetails(BECourseAdmin objBECourseAdmin)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[6];

                objSqlParam[0] = new SqlParameter("@I_CourseID", SqlDbType.Int);
                objSqlParam[0].Value = objBECourseAdmin.IntCourseID;
                objSqlParam[1] = new SqlParameter("@V_Course_ID", SqlDbType.VarChar, 50);
                objSqlParam[1].Value = objBECourseAdmin.strCourseID;
                objSqlParam[2] = new SqlParameter("@V_CourseName", SqlDbType.VarChar, 100);
                objSqlParam[2].Value = objBECourseAdmin.strCourseName;
                objSqlParam[3] = new SqlParameter("@I_Status", SqlDbType.Int);
                objSqlParam[3].Value = objBECourseAdmin.IntstatusFlag;
                objSqlParam[4] = new SqlParameter("@I_UserID", SqlDbType.Int);
                objSqlParam[4].Value = objBECourseAdmin.IntUserID;
                objSqlParam[5] = new SqlParameter("@I_Result", SqlDbType.Int);
                objSqlParam[5].Direction = ParameterDirection.Output;

                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_CourseAdmin_UpdateCourseDetails, objSqlParam);

                objBECourseAdmin.IntResult = Convert.ToInt32(objSqlParam[5].Value.ToString());
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        public void DAdminValidateExam(BECourseAdmin objBECourseAdmin)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[3];
                objSqlParam[0] = new SqlParameter("@V_CourseID", SqlDbType.Int);
                objSqlParam[0].Value = objBECourseAdmin.IntCourseID;
                objSqlParam[1] = new SqlParameter("@V_ExamName", SqlDbType.VarChar, 100);
                objSqlParam[1].Value = objBECourseAdmin.strExamName;
                objSqlParam[2] = new SqlParameter("@I_Result", SqlDbType.Int);
                objSqlParam[2].Direction = ParameterDirection.Output;

                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_ADMIN_EP_CheckForExam, objSqlParam);

                objBECourseAdmin.IntResult = int.Parse(objSqlParam[2].Value.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public void DAdminEnrollStudent(BECourseAdmin objBECourseAdmin)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[4];
                objSqlParam[0] = new SqlParameter("@UserID", SqlDbType.BigInt);
                objSqlParam[0].Value = objBECourseAdmin.IntUserID;
                objSqlParam[1] = new SqlParameter("@CourseID", SqlDbType.BigInt);
                objSqlParam[1].Value = objBECourseAdmin.IntCourseID;
                objSqlParam[2] = new SqlParameter("@StudentID", SqlDbType.BigInt);
                objSqlParam[2].Value = objBECourseAdmin.IntExamID;
                objSqlParam[3] = new SqlParameter("@Flag", SqlDbType.Int);
                objSqlParam[3].Direction = ParameterDirection.Output;

                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Admin_EnrolStudent, objSqlParam);

                objBECourseAdmin.IntResult = Convert.ToInt32(objSqlParam[3].Value.ToString());
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        //public void DSaveExamDetails(BECourseAdmin objBECourseAdmin)
        //{
        //    try
        //    {
        //        SqlParameter[] objSqlParam = new SqlParameter[17];
        //        objSqlParam[0] = new SqlParameter("@I_CourseID", SqlDbType.Int);
        //        objSqlParam[0].Value = objBECourseAdmin.IntCourseID;
        //        objSqlParam[1] = new SqlParameter("@V_ExamName", SqlDbType.VarChar, 50);
        //        objSqlParam[1].Value = objBECourseAdmin.strExamName;
        //        objSqlParam[2] = new SqlParameter("@D_ExamDuration", SqlDbType.VarChar, 50);
        //        objSqlParam[2].Precision = StoredProcedures.Precision;
        //        objSqlParam[2].Scale = StoredProcedures.Scale;
        //        objSqlParam[2].Value = objBECourseAdmin.ddlHM;
        //        objSqlParam[3] = new SqlParameter("@V_ExamLink", SqlDbType.VarChar, 2000);
        //        objSqlParam[3].Value = objBECourseAdmin.strLinkAccessExam;
        //        objSqlParam[4] = new SqlParameter("@V_StartDate", SqlDbType.DateTime);
        //        objSqlParam[4].Value = objBECourseAdmin.strExamStartDate;
        //        objSqlParam[5] = new SqlParameter("@V_EndDate", SqlDbType.DateTime);
        //        objSqlParam[5].Value = objBECourseAdmin.strExamEndDate;
        //        objSqlParam[6] = new SqlParameter("@V_OpenBook", SqlDbType.Int);
        //        objSqlParam[6].Value = objBECourseAdmin.strOpenBook;
        //        objSqlParam[7] = new SqlParameter("@V_Notes", SqlDbType.VarChar, 50);
        //        objSqlParam[7].Value = objBECourseAdmin.strNotes;
        //        objSqlParam[8] = new SqlParameter("@Notes", SqlDbType.Structured);
        //        if (objBECourseAdmin.DtResult != null)
        //            objSqlParam[8].Value = objBECourseAdmin.DtResult;
        //        else
        //            objSqlParam[8].Value = getExamDataTable();
        //        objSqlParam[9] = new SqlParameter("@Rules", SqlDbType.Structured);
        //        if (objBECourseAdmin.DtResult1 != null)
        //            objSqlParam[9].Value = objBECourseAdmin.DtResult1;
        //        else
        //            objSqlParam[9].Value = getExamDataTable();
        //        objSqlParam[10] = new SqlParameter("@B_Flag", SqlDbType.Int);
        //        objSqlParam[10].Direction = ParameterDirection.Output;
        //        objSqlParam[11] = new SqlParameter("@I_UserID", SqlDbType.BigInt);
        //        objSqlParam[11].Value = objBECourseAdmin.IntUserID;
        //        //objSqlParam[12] = new SqlParameter("@Tool_Calc", SqlDbType.Int);
        //        //objSqlParam[12].Value = objBECourseAdmin.intCalc;
        //        //objSqlParam[13] = new SqlParameter("@Tool_Notes", SqlDbType.Int);
        //        //objSqlParam[13].Value = objBECourseAdmin.intStickyNotes;
        //        objSqlParam[12] = new SqlParameter("@ExamBufferTime", SqlDbType.Int);
        //        objSqlParam[12].Value = objBECourseAdmin.IntBufferTime;
        //        objSqlParam[13] = new SqlParameter("@OriginalFileName", SqlDbType.VarChar, 200);
        //        objSqlParam[13].Value = objBECourseAdmin.strOriginalFileName;
        //        objSqlParam[14] = new SqlParameter("@StoredFileName", SqlDbType.VarChar, 200);
        //        objSqlParam[14].Value = objBECourseAdmin.strUploadPath;
        //        objSqlParam[15] = new SqlParameter("@ExamSecurity", SqlDbType.VarChar, 10);
        //        objSqlParam[15].Value = objBECourseAdmin.strSecurityLevel;
        //        objSqlParam[16] = new SqlParameter("@ExamTools", SqlDbType.Structured);
        //        objSqlParam[16].Value = objBECourseAdmin.DtTools;

        //        SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_ExamProvider_SaveExamDetails, objSqlParam);

        //        objBECourseAdmin.IntResult = int.Parse(objSqlParam[10].Value.ToString());
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        /// <summary>
        /// Save ExamDetails 
        /// </summary>
        /// <param name="objBECourseAdmin"></param>
        public void DSaveExamDetails(BECourseAdmin objBECourseAdmin)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[30];

                objSqlParam[0] = new SqlParameter("@I_CourseID", SqlDbType.Int);
                objSqlParam[0].Value = objBECourseAdmin.IntCourseID;
                objSqlParam[1] = new SqlParameter("@V_ExamName", SqlDbType.VarChar, 100);
                objSqlParam[1].Value = objBECourseAdmin.strExamName;
                objSqlParam[2] = new SqlParameter("@D_ExamDuration", SqlDbType.VarChar, 50);
                objSqlParam[2].Precision = StoredProcedures.Precision;
                objSqlParam[2].Scale = StoredProcedures.Scale;
                objSqlParam[2].Value = objBECourseAdmin.ddlHM;
                objSqlParam[3] = new SqlParameter("@V_ExamLink", SqlDbType.VarChar, 2000);
                objSqlParam[3].Value = objBECourseAdmin.strLinkAccessExam;
                objSqlParam[4] = new SqlParameter("@V_StartDate", SqlDbType.DateTime);
                objSqlParam[4].Value = objBECourseAdmin.strExamStartDate;
                objSqlParam[5] = new SqlParameter("@V_EndDate", SqlDbType.DateTime);
                objSqlParam[5].Value = objBECourseAdmin.strExamEndDate;
                objSqlParam[6] = new SqlParameter("@V_OpenBook", SqlDbType.Int);
                objSqlParam[6].Value = objBECourseAdmin.strOpenBook;
                objSqlParam[7] = new SqlParameter("@SpecialNeedsFlag", SqlDbType.Bit);
                objSqlParam[7].Value = objBECourseAdmin.strSpecialNeeds;
                objSqlParam[8] = new SqlParameter("@Rules", SqlDbType.VarChar, 50);
                objSqlParam[8].Value = DBNull.Value;
                objSqlParam[9] = new SqlParameter("@B_Flag", SqlDbType.Int);
                objSqlParam[9].Direction = ParameterDirection.Output;
                objSqlParam[10] = new SqlParameter("@I_UserID", SqlDbType.BigInt);
                objSqlParam[10].Value = objBECourseAdmin.IntUserID;
                objSqlParam[11] = new SqlParameter("@ExamBufferTime", SqlDbType.Int);
                objSqlParam[11].Value = objBECourseAdmin.IntBufferTime;
                objSqlParam[12] = new SqlParameter("@OriginalFileName", SqlDbType.VarChar, 200);
                objSqlParam[12].Value = objBECourseAdmin.strOriginalFileName;
                objSqlParam[13] = new SqlParameter("@StoredFileName", SqlDbType.VarChar, 200);
                objSqlParam[13].Value = objBECourseAdmin.strUploadPath;
                objSqlParam[14] = new SqlParameter("@ExamLevel", SqlDbType.Int);
                objSqlParam[14].Value = objBECourseAdmin.ddlSecurityLevel;
                objSqlParam[15] = new SqlParameter("@ExamPassword", SqlDbType.VarChar, 50);
                objSqlParam[15].Value = objBECourseAdmin.strPassword;
                objSqlParam[16] = new SqlParameter("@AllowedRules", SqlDbType.Structured);
                if (objBECourseAdmin.dtResult_Rules != null)
                    objSqlParam[16].Value = objBECourseAdmin.dtResult_Rules;
                else
                    objSqlParam[16].Value = getAdditionalRulesDataTable();
                objSqlParam[17] = new SqlParameter("@SpecialRules", SqlDbType.Structured);
                if (objBECourseAdmin.DtResult1 != null)
                    objSqlParam[17].Value = objBECourseAdmin.DtResult1;
                else
                    objSqlParam[17].Value = getSpecialRulesDataTable();

                objSqlParam[18] = new SqlParameter("@I_LockDownBrowser", SqlDbType.Bit);
                objSqlParam[18].Value = objBECourseAdmin.intLockDownBrowser;

                objSqlParam[19] = new SqlParameter("@StudentUploadFile", SqlDbType.Bit);
                objSqlParam[19].Value = objBECourseAdmin.intStudentUploadFile;

                objSqlParam[20] = new SqlParameter("@ExamFeePaidBy", SqlDbType.Int);
                objSqlParam[20].Value = objBECourseAdmin.intExamFeePaidBy;

                objSqlParam[21] = new SqlParameter("@OnDemandFeePaidBy", SqlDbType.Int);
                objSqlParam[21].Value = objBECourseAdmin.intOnDemandFeePaidBy;

                objSqlParam[22] = new SqlParameter("@ExamUserName", SqlDbType.VarChar, 250);
                objSqlParam[22].Value = objBECourseAdmin.strExamUserName;

                objSqlParam[23] = new SqlParameter("@Files", SqlDbType.Structured);
                objSqlParam[23].Value = objBECourseAdmin.DtResult;

                //objSqlParam[24] = new SqlParameter("@calValues", SqlDbType.VarChar, 250);//03nov2016
                //objSqlParam[24].Value = objBECourseAdmin.CalValues;

                //objSqlParam[25] = new SqlParameter("@calText", SqlDbType.VarChar, 250);//03nov2016
                //objSqlParam[25].Value = objBECourseAdmin.CalText;

                //objSqlParam[26] = new SqlParameter("@openText", SqlDbType.VarChar, 250);//03nov2016
                //objSqlParam[26].Value = objBECourseAdmin.OpenBookText;


                objBECourseAdmin.DsResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_CourseAdmin_SaveExamDetails, objSqlParam);

                objBECourseAdmin.IntResult = int.Parse(objSqlParam[9].Value.ToString());
                //updating past rules flag
                if (objBECourseAdmin.IntResult > 0)
                    DUpdateStatus(objBECourseAdmin.IntResult, objBECourseAdmin.PastSpecialRules);


            }
            catch (Exception ex)
            {
                throw ex;
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

        public void DDeleteUploadFiles(BECourseAdmin objBECourseAdmin)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[2];
                objSqlParam[0] = new SqlParameter("@I_ExamID", SqlDbType.Int);
                objSqlParam[0].Value = objBECourseAdmin.IntExamID;

                objSqlParam[1] = new SqlParameter("@I_Flag", SqlDbType.Int);
                objSqlParam[1].Direction = ParameterDirection.Output;

                SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_CourseAdmin_DeleteUploadFile, objSqlParam);

                objBECourseAdmin.IntResult = int.Parse(objSqlParam[1].Value.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Get Exam Details for Selected Course
        /// </summary>
        /// <param name="objBECourseAdmin"></param>
        public void DGetExamDetails(BECourseAdmin objBECourseAdmin)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[2];

                objSqlParam[0] = new SqlParameter("@I_CourseID", SqlDbType.Int);
                objSqlParam[0].Value = objBECourseAdmin.IntCourseID;
                objSqlParam[1] = new SqlParameter("@I_UserID", SqlDbType.Int);
                objSqlParam[1].Value = objBECourseAdmin.IntUserID;

                objBECourseAdmin.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_CourseAdmin_GetExams, objSqlParam).Tables[0];
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        /// <summary>
        /// Get Student Transactions associated with the current exam provider
        /// </summary>
        /// <param name="objBECourseAdmin"></param>
        public void DGetStudentTransactionsForCurrentProvider(BECourseAdmin objBECourseAdmin)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[2];

                objSqlParam[0] = new SqlParameter("@I_StudentID", SqlDbType.Int);
                objSqlParam[0].Value = objBECourseAdmin.IntStudentID;
                objSqlParam[1] = new SqlParameter("@I_ProviderID", SqlDbType.Int);
                objSqlParam[1].Value = objBECourseAdmin.IntUserID;

                objBECourseAdmin.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_CourseAdmin_GetStudentExamTransactions, objSqlParam).Tables[0];

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Gets Transactions of student for all providers based on logged-in CourseAdmin's course_ID field
        /// </summary>
        /// <param name="objBECourseAdmin"></param>
        public void DGetStudentTransactionsByLoggedInCourseAdminCourses(BECourseAdmin objBECourseAdmin)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[2];

                objSqlParam[0] = new SqlParameter("@I_StudentID", SqlDbType.Int);
                objSqlParam[0].Value = objBECourseAdmin.IntStudentID;
                objSqlParam[1] = new SqlParameter("@I_ProviderID", SqlDbType.Int);
                objSqlParam[1].Value = objBECourseAdmin.IntUserID;

                objBECourseAdmin.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_CourseAdmin_GetStudentExamTransactionsForCourseAdmin, objSqlParam).Tables[0];

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Add Course
        /// </summary>
        /// <param name="objBECourseAdmin"></param>
        public void DAddCourse(BECourseAdmin objBECourseAdmin)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[4];

                objSqlParam[0] = new SqlParameter("@V_CourseID", SqlDbType.VarChar, 50);
                objSqlParam[0].Value = objBECourseAdmin.strCourseID;

                objSqlParam[1] = new SqlParameter("@V_CourseName", SqlDbType.VarChar, 100);
                objSqlParam[1].Value = objBECourseAdmin.strCourseName;

                objSqlParam[2] = new SqlParameter("@I_UserID", SqlDbType.Int);
                objSqlParam[2].Value = objBECourseAdmin.IntUserID;

                objSqlParam[3] = new SqlParameter("@I_Result", SqlDbType.Int);
                objSqlParam[3].Direction = ParameterDirection.Output;

                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_CourseAdmin_AddCourse, objSqlParam);

                objBECourseAdmin.IntResult = Convert.ToInt32(objSqlParam[3].Value.ToString());
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        /// <summary>
        /// Get Course Details For Selected Exam Provider
        /// </summary>
        /// <param name="objBECourseAdmin"></param>
        public void DGetSelectedCourseDetails(BECourseAdmin objBECourseAdmin)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[1];

                objSqlParam[0] = new SqlParameter("@I_CourseID", SqlDbType.Int);
                objSqlParam[0].Value = objBECourseAdmin.IntCourseID;

                objBECourseAdmin.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_CourseAdmin_GetSelectedCourseDetails, objSqlParam).Tables[0];
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        /// <summary>
        /// DDeleteCourse
        /// </summary>
        /// <param name="objBECourseAdmin"></param>


        public void DDeleteCourse(BECourseAdmin objBECourseAdmin)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[2];
                objSqlParam[0] = new SqlParameter("@I_CourseID", SqlDbType.Int);
                objSqlParam[0].Value = objBECourseAdmin.IntCourseID;

                objSqlParam[1] = new SqlParameter("@I_Flag", SqlDbType.Int);
                objSqlParam[1].Direction = ParameterDirection.Output;

                SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_CourseAdmin_DeleteCourse, objSqlParam);

                objBECourseAdmin.IntResult = int.Parse(objSqlParam[1].Value.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// DGetSelectedSecurityLevel
        /// </summary>
        /// <param name="objBECourseAdmin"></param>
        public void DGetSelectedSecurityLevel(BECourseAdmin objBECourseAdmin)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[2];

                objSqlParam[0] = new SqlParameter("@I_SecurityLevel", SqlDbType.Int);
                objSqlParam[0].Value = objBECourseAdmin.ddlSecurityLevel;
                objSqlParam[1] = new SqlParameter("@V_SecDesc", SqlDbType.VarChar, 500);
                objSqlParam[1].Direction = ParameterDirection.Output;

                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_CourseAdmin_GetSecurityLevelDesc, objSqlParam);

                objBECourseAdmin.StrResult = objSqlParam[1].Value.ToString();

            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        /// <summary>
        /// Add Student
        /// </summary>
        /// <param name="objBECourseAdmin"></param>
        public void DAddStudent(BECourseAdmin objBECourseAdmin)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[10];
                objSqlParam[0] = new SqlParameter("@V_FirstName", SqlDbType.VarChar, 100);
                objSqlParam[0].Value = objBECourseAdmin.strFirstName;
                objSqlParam[1] = new SqlParameter("@V_LastName", SqlDbType.VarChar, 100);
                objSqlParam[1].Value = objBECourseAdmin.strLastName;
                objSqlParam[2] = new SqlParameter("@V_EmailID", SqlDbType.VarChar, 255);
                objSqlParam[2].Value = objBECourseAdmin.strEmailAddress;
                objSqlParam[3] = new SqlParameter("@I_Flag", SqlDbType.Int);
                objSqlParam[3].Direction = ParameterDirection.Output;
                objSqlParam[4] = new SqlParameter("@B_SpecialNeeds", SqlDbType.Bit);
                objSqlParam[4].Value = objBECourseAdmin.strSpecialNeeds;
                objSqlParam[5] = new SqlParameter("@V_Password", SqlDbType.VarChar, 50);
                objSqlParam[5].Value = objBECourseAdmin.strPassword;
                objSqlParam[6] = new SqlParameter("@V_Comments", SqlDbType.VarChar);
                objSqlParam[6].Value = objBECourseAdmin.StrComments;
                objSqlParam[7] = new SqlParameter("@I_CourseID", SqlDbType.Int);
                objSqlParam[7].Value = objBECourseAdmin.IntCourseID;
                objSqlParam[8] = new SqlParameter("@I_ProviderID", SqlDbType.Int);
                objSqlParam[8].Value = objBECourseAdmin.IntProviderID;
                objSqlParam[9] = new SqlParameter("@V_UserName", SqlDbType.VarChar, 200);
                objSqlParam[9].Value = objBECourseAdmin.strUserName;


                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_CourseAdmin_AddStudent, objSqlParam);

                objBECourseAdmin.IntResult = int.Parse(objSqlParam[3].Value.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// DBindProviderSecurityLevel
        /// </summary>
        /// <param name="objBECourseAdmin"></param>

        public void DBindProviderSecurityLevel(BECourseAdmin objBECourseAdmin)
        {
            try
            {


                objBECourseAdmin.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_CourseAdmin_ExamLevel).Tables[0];

            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        /// <summary>
        /// Find the Exam Existence while adding the new exam
        /// </summary>
        /// <param name="objBECourseAdmin"></param>
        public void DCheckForExamExistence(BECourseAdmin objBECourseAdmin)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[4];
                objSqlParam[0] = new SqlParameter("@V_CourseID", SqlDbType.Int);
                objSqlParam[0].Value = objBECourseAdmin.IntCourseID;
                objSqlParam[1] = new SqlParameter("@V_ExamName", SqlDbType.VarChar, 100);
                objSqlParam[1].Value = objBECourseAdmin.strExamName;
                objSqlParam[2] = new SqlParameter("@I_Result", SqlDbType.Int);
                objSqlParam[2].Direction = ParameterDirection.Output;
                objSqlParam[3] = new SqlParameter("@I_UserID", SqlDbType.Int);
                objSqlParam[3].Value = objBECourseAdmin.IntUserID;

                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_CourseAdmin_CheckForExamExistence, objSqlParam);

                objBECourseAdmin.IntResult = int.Parse(objSqlParam[2].Value.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get Course Details For Selected Exam Provider
        /// </summary>
        /// <param name="objBECourseAdmin"></param>
        public void DGetSelectedExamDetails(BECourseAdmin objBECourseAdmin)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[2];

                objSqlParam[0] = new SqlParameter("@I_ExamID", SqlDbType.Int);
                objSqlParam[0].Value = objBECourseAdmin.IntExamID;
                objSqlParam[1] = new SqlParameter("@I_UserID", SqlDbType.Int);
                objSqlParam[1].Value = objBECourseAdmin.IntUserID;

                objBECourseAdmin.DsResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_CourseAdmin_GetSelectedExamDetails, objSqlParam);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        /// <summary>
        /// Delete Exam
        /// </summary>
        /// <param name="objBECourseAdmin"></param>
        public void DDeleteExam(BECourseAdmin objBECourseAdmin)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[2];

                objSqlParam[0] = new SqlParameter("@I_ExamID", SqlDbType.Int);
                objSqlParam[0].Value = objBECourseAdmin.IntExamID;

                objSqlParam[1] = new SqlParameter("@I_Status", SqlDbType.Int);
                objSqlParam[1].Direction = ParameterDirection.Output;

                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_CourseAdmin_DeleteExam, objSqlParam);

                objBECourseAdmin.IntResult = Convert.ToInt32(objSqlParam[1].Value.ToString());
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        /// <summary>
        /// DGetEnrollStudentName
        /// </summary>
        /// <param name="objBECourseAdmin"></param>

        public void DGetStudentName(BECourseAdmin objBECourseAdmin)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[1];

                objSqlParam[0] = new SqlParameter("@I_UserID", SqlDbType.Int);
                objSqlParam[0].Value = objBECourseAdmin.IntStudentID;

                objBECourseAdmin.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_CourseAdmin_GetStudentName, objSqlParam).Tables[0];

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// DGetProviderCourseDetails
        /// </summary>
        /// <param name="objBECourseAdmin"></param>


        public void DGetProviderCourseDetails(BECourseAdmin objBECourseAdmin)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[1];

                objSqlParam[0] = new SqlParameter("@I_UserID", SqlDbType.Int);
                objSqlParam[0].Value = objBECourseAdmin.IntUserID;

                objBECourseAdmin.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_CourseAdmin_GetProviderCourses, objSqlParam).Tables[0];

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// DProviderEnrollStudent
        /// </summary>
        /// <param name="objBECourseAdmin"></param>
        public void DProviderEnrollStudent(BECourseAdmin objBECourseAdmin)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[4];
                objSqlParam[0] = new SqlParameter("@UserID", SqlDbType.BigInt);
                objSqlParam[0].Value = objBECourseAdmin.IntUserID;
                objSqlParam[1] = new SqlParameter("@CourseID", SqlDbType.BigInt);
                objSqlParam[1].Value = objBECourseAdmin.IntCourseID;
                objSqlParam[2] = new SqlParameter("@StudentID", SqlDbType.BigInt);
                objSqlParam[2].Value = objBECourseAdmin.IntStudentID;
                objSqlParam[3] = new SqlParameter("@Flag", SqlDbType.Int);
                objSqlParam[3].Direction = ParameterDirection.Output;
             

                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_CourseAdmin_EnrollStudent, objSqlParam);

                objBECourseAdmin.IntResult = Convert.ToInt32(objSqlParam[3].Value.ToString());
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        public void DCourseAdminEnrollStudents(BECourseAdmin objBECourseAdmin)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[5];
                objSqlParam[0] = new SqlParameter("@UserID", SqlDbType.BigInt);
                objSqlParam[0].Value = objBECourseAdmin.IntUserID;
                objSqlParam[1] = new SqlParameter("@CourseID", SqlDbType.BigInt);
                objSqlParam[1].Value = objBECourseAdmin.IntCourseID;
                objSqlParam[2] = new SqlParameter("@StudentID", SqlDbType.BigInt);
                objSqlParam[2].Value = objBECourseAdmin.IntStudentID;
                objSqlParam[3] = new SqlParameter("@Flag", SqlDbType.Int);
                objSqlParam[3].Direction = ParameterDirection.Output;
                objSqlParam[4] = new SqlParameter("@TBL_Students", SqlDbType.Structured);
                objSqlParam[4].Value = objBECourseAdmin.DtResult1;

                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_CourseAdmin_EnrollSelectedStudents", objSqlParam);

                objBECourseAdmin.IntResult = Convert.ToInt32(objSqlParam[3].Value.ToString());
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        /// <summary>
        /// DGetEnrollStudentDetails
        /// </summary>
        /// <param name="objBECourseAdmin"></param>
        public void DGetEnrollStudentDetails(BECourseAdmin objBECourseAdmin)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[1];
                objSqlParam[0] = new SqlParameter("@I_EnrollID", SqlDbType.Int);
                objSqlParam[0].Value = objBECourseAdmin.IntEnrollID;

                objBECourseAdmin.DsResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_CourseAdmin_GetEnrollStudentDetails, objSqlParam);
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        /// <summary>
        /// DUpdateStatus
        /// </summary>
        /// <param name="objBECourseAdmin"></param>
        public void DUpdateEnrollStatus(BECourseAdmin objBECourseAdmin)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[3];
                objSqlParam[0] = new SqlParameter("@I_Status", SqlDbType.BigInt);
                objSqlParam[0].Value = objBECourseAdmin.ddlStatus;
                objSqlParam[1] = new SqlParameter("@I_Flag", SqlDbType.Int);
                objSqlParam[1].Direction = ParameterDirection.Output;
                objSqlParam[2] = new SqlParameter("@I_EnrollId", SqlDbType.BigInt);
                objSqlParam[2].Value = objBECourseAdmin.IntEnrollID;

                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_CourseAdmin_UpdateStudentStatus, objSqlParam);

                objBECourseAdmin.IntResult = int.Parse(objSqlParam[1].Value.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// DDeleteEnrollmentStatus
        /// </summary>
        /// <param name="objBECourseAdmin"></param>
        public void DDeleteEnrollmentStatus(BECourseAdmin objBECourseAdmin)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[2];
                objSqlParam[0] = new SqlParameter("@I_EnrollID", SqlDbType.Int);
                objSqlParam[0].Value = objBECourseAdmin.IntEnrollID;
                objSqlParam[1] = new SqlParameter("@I_Flag", SqlDbType.Int);
                objSqlParam[1].Direction = ParameterDirection.Output;

                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_CourseAdmin_DeleteEnrollStudent, objSqlParam);

                objBECourseAdmin.IntResult = int.Parse(objSqlParam[1].Value.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Find the Exam Existence while adding the new exam
        /// </summary>
        /// <param name="objBECourseAdmin"></param>
        public void DCheckForUpdateExamExistence(BECourseAdmin objBECourseAdmin)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[3];

                objSqlParam[0] = new SqlParameter("@I_ExamID", SqlDbType.Int);
                objSqlParam[0].Value = objBECourseAdmin.IntExamID;
                objSqlParam[1] = new SqlParameter("@V_ExamName", SqlDbType.VarChar, 100);
                objSqlParam[1].Value = objBECourseAdmin.strExamName;
                objSqlParam[2] = new SqlParameter("@I_Result", SqlDbType.Int);
                objSqlParam[2].Direction = ParameterDirection.Output;

                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_CourseAdmin_CheckForUpdateExamExistence, objSqlParam);

                objBECourseAdmin.IntResult = int.Parse(objSqlParam[2].Value.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DGetProviderStudentsFiltered(BECourseAdmin objBECourseAdmin)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[1];

                objSqlParam[0] = new SqlParameter("@I_ProviderID", SqlDbType.Int);
                objSqlParam[0].Value = objBECourseAdmin.IntProviderID;

                objBECourseAdmin.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_CourseAdmin_GetStudents_Filtered, objSqlParam).Tables[0];
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void DGetAllStudents(BECourseAdmin objBECourseAdmin)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[1];

                objSqlParam[0] = new SqlParameter("@I_ProviderID", SqlDbType.Int);
                objSqlParam[0].Value = objBECourseAdmin.IntProviderID;
                objBECourseAdmin.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_CourseAdmin_GETALLSTUDENTS, objSqlParam).Tables[0];
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void DGetProviderCourses(BECourseAdmin objBECourseAdmin)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[1];

                objSqlParam[0] = new SqlParameter("@I_UserID", SqlDbType.Int);
                objSqlParam[0].Value = objBECourseAdmin.IntProviderID;

                objBECourseAdmin.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_CourseAdmin_GetProviderCourses, objSqlParam).Tables[0];
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void DCheckTimeZone(BECourseAdmin objBECourseAdmin)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[2];

                objSqlParam[0] = new SqlParameter("@I_UserID", SqlDbType.Int);
                objSqlParam[0].Value = objBECourseAdmin.IntUserID;

                objSqlParam[1] = new SqlParameter("@I_Flag", SqlDbType.Int);
                objSqlParam[1].Direction = ParameterDirection.Output;

                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_CourseAdmin_checkTimeZone", objSqlParam);

                objBECourseAdmin.IntResult = int.Parse(objSqlParam[1].Value.ToString());
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        public void DGetEditExamDetails(BECourseAdmin objBECourseAdmin)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[2];

                objSqlParam[0] = new SqlParameter("@I_ExamID", SqlDbType.Int);
                objSqlParam[0].Value = objBECourseAdmin.IntExamID;
                objSqlParam[1] = new SqlParameter("@I_UserID", SqlDbType.Int);
                objSqlParam[1].Value = objBECourseAdmin.IntUserID;

                objBECourseAdmin.DsResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_Admin_GetEditExamDetails", objSqlParam);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void DBindProviderNames(BECourseAdmin objBECourseAdmin)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[1];

                objSqlParam[0] = new SqlParameter("@I_ProviderID", SqlDbType.Int);
                objSqlParam[0].Value = objBECourseAdmin.IntUserID;

                objBECourseAdmin.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_CourseAdmin_GetProviders,objSqlParam).Tables[0];
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void DBindCourseAdminSpecificProviderCourses(BECourseAdmin objBECourseAdmin)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[2];

                objSqlParam[0] = new SqlParameter("@I_ProviderID", SqlDbType.Int);
                objSqlParam[0].Value = objBECourseAdmin.IntProviderID;
                objSqlParam[1] = new SqlParameter("@I_UserID", SqlDbType.Int);
                objSqlParam[1].Value = objBECourseAdmin.IntUserID;
                

                objBECourseAdmin.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_CourseAdmin_GetCourseAdminSpecificProviderCourses, objSqlParam).Tables[0];
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void DGetCourseDetailsbyProvider(BECourseAdmin objBECourseAdmin)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[2];
                objSqlParam[0] = new SqlParameter("@I_CourseID", SqlDbType.Int);
                objSqlParam[0].Value = objBECourseAdmin.IntCourseID;
                objSqlParam[1] = new SqlParameter("@I_ProviderID", SqlDbType.Int);
                objSqlParam[1].Value = objBECourseAdmin.IntProviderID;
                objBECourseAdmin.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_CourseAdmin_GetCourseDetailsbyProvider", objSqlParam).Tables[0];
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public void DGetStudentsByCourseId(BECourseAdmin objBECourseAdmin)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[1];

                objSqlParam[0] = new SqlParameter("@I_CourseID", SqlDbType.Int);
                objSqlParam[0].Value = objBECourseAdmin.IntCourseID;

                objBECourseAdmin.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_CourseAdmin_GetStudentsByCourseID", objSqlParam).Tables[0];
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public void DGetStudentsNotInCourse(BECourseAdmin objBECourseAdmin)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[1];

                objSqlParam[0] = new SqlParameter("@I_CourseID", SqlDbType.Int);
                objSqlParam[0].Value = objBECourseAdmin.IntCourseID;

                objBECourseAdmin.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_CourseAdmin_GetStudentsNotInCourse", objSqlParam).Tables[0];
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }


        public void DGetCourseAdminDetails(BECourseAdmin objBECourseAdmin)
        {

            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[4];

                objSqlParam[0] = new SqlParameter("@CourseID", SqlDbType.VarChar, 200);
                objSqlParam[0].Value = objBECourseAdmin.strCourseID;

                objSqlParam[1] = new SqlParameter("@strCourseName", SqlDbType.VarChar, 200);
                objSqlParam[1].Value = objBECourseAdmin.strCourseName;

                objSqlParam[2] = new SqlParameter("@strInstructorName", SqlDbType.VarChar, 200);
                objSqlParam[2].Value = objBECourseAdmin.strStudentName;

                objSqlParam[3] = new SqlParameter("@I_UserID", SqlDbType.Int);
                objSqlParam[3].Value = objBECourseAdmin.IntUserID;


                objBECourseAdmin.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_Admin_GetCourseAdminDetails", objSqlParam).Tables[0];
                //objBEAdmin.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Admin_GetStudentsDetails).Tables[0];
            }
            catch (Exception Ex)
            {

                throw Ex;
            }

        }
    }
}
