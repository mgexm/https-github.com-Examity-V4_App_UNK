using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessEntities;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
  public class DAdmin
    {

        /// <summary>
        /// Get Course Details
        /// </summary>    
        public void DGetCourseDetails(BEAdmin objBEAdmin)
        {
            try
            {
                objBEAdmin.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Admin_GetCourses).Tables[0];
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

      //written for getting course details
        public void DGetAllCourseDetails(BEAdmin objBEAdmin)
        {
            try
            {
                objBEAdmin.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Admin_GetAllCourseDetails).Tables[0];
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

      //20july2015
        //written for getting course details
        public void DGetInstructorCourseDetails(BEAdmin objBEAdmin)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[1];
                objSqlParam[0] = new SqlParameter("@examProviderId", SqlDbType.Int);
                objSqlParam[0].Value = objBEAdmin.IntUserID;

                objBEAdmin.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Provider_GetInstructorCourseDetails, objSqlParam).Tables[0];
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

      //written for populating the grid
        public void DGetExamSummaryDetails(BEAdmin objBEAdmin)
        {
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[2];
                objSqlParam[0] = new SqlParameter("@courseId", SqlDbType.VarChar);
                objSqlParam[0].Value = objBEAdmin.strCourseID;
                objSqlParam[1] = new SqlParameter("@instructorId", SqlDbType.Int);
                objSqlParam[1].Value = objBEAdmin.IntUserID;

                objBEAdmin.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Admin_GetExamSummaryReport, objSqlParam).Tables[0];
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

      public void DViewStudentDetails(BEAdmin objBEAdmin)
      {
          try
          {

              SqlParameter[] objSqlParam = new SqlParameter[1];

              objSqlParam[0] = new SqlParameter("@StudentID", SqlDbType.Int);
              objSqlParam[0].Value = objBEAdmin.IntStudentID;

              objBEAdmin.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_ADMIN_GetViewStudentDetails, objSqlParam).Tables[0];
          }
          catch (Exception Ex)
          {
              throw Ex;
          }
      }

      public void DSaveCourseDetails(BEAdmin objBEAdmin)
      {
          try
          {
              SqlParameter[] objSqlParam = new SqlParameter[3];
              objSqlParam[0] = new SqlParameter("@V_Course_ID", SqlDbType.VarChar, 50);
              objSqlParam[0].Value = objBEAdmin.strCourseID;

              objSqlParam[1] = new SqlParameter("@V_CourseName", SqlDbType.VarChar, 100);
              objSqlParam[1].Value = objBEAdmin.strCourseName;

              //objSqlParam[2] = new SqlParameter("@I_UserID", SqlDbType.Int);
              //objSqlParam[2].Value = objBEAdmin.IntUserID;

              objSqlParam[2] = new SqlParameter("@I_UserID", SqlDbType.Int);
              objSqlParam[2].Value = objBEAdmin.IntProviderID;

              objBEAdmin.DsResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Admin_CreateCourse, objSqlParam);
          }
          catch (Exception Ex)
          {
              throw Ex;
          }
      }

      public void DUpdateCourseDetails(BEAdmin objBEAdmin)
      {
          try
          {
              SqlParameter[] objSqlParam = new SqlParameter[5];

              objSqlParam[0] = new SqlParameter("@I_CourseID", SqlDbType.Int);
              objSqlParam[0].Value = objBEAdmin.IntCourseID;
              objSqlParam[1] = new SqlParameter("@V_Course_ID", SqlDbType.VarChar, 50);
              objSqlParam[1].Value = objBEAdmin.strCourseID;
              objSqlParam[2] = new SqlParameter("@V_CourseName", SqlDbType.VarChar, 100);
              objSqlParam[2].Value = objBEAdmin.strCourseName;
              objSqlParam[3] = new SqlParameter("@I_Status", SqlDbType.Int);
              objSqlParam[3].Value = objBEAdmin.IntstatusFlag;
              // objSqlParam[4] = new SqlParameter("@I_UserID", SqlDbType.Int);
              // objSqlParam[4].Value = objBEAdmin.IntstatusFlag;
              objSqlParam[4] = new SqlParameter("@I_Result", SqlDbType.Int);
              objSqlParam[4].Direction = ParameterDirection.Output;

              SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Admin_UpdateCourseDetails, objSqlParam);

              objBEAdmin.IntResult = Convert.ToInt32(objSqlParam[4].Value.ToString());
          }
          catch (Exception Ex)
          {
              throw Ex;
          }
      }

      public void DGetExistingExamDetails(BEAdmin objBEAdmin)
      {
          try
          {

              objBEAdmin.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_ADMIN_GetExistingExamDetails).Tables[0];
          }
          catch (Exception Ex)
          {
              throw Ex;
          }
      }

      public void DBindCourse(BEAdmin objBEAdmin)
      {
          try
          {
              SqlParameter[] objSqlParam = new SqlParameter[1];

              objSqlParam[0] = new SqlParameter("@I_ProviderID", SqlDbType.Int);
              objSqlParam[0].Value = objBEAdmin.IntProviderID;
              objBEAdmin.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Admin_GetProviderCourses, objSqlParam).Tables[0];
          }
          catch (Exception Ex)
          {
              throw Ex;
          }
      }


      public void DAdminBindCourse(BEAdmin objBEAdmin)
      {
          try
          {
              
              objBEAdmin.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Admin_GetCourses).Tables[0];
          }
          catch (Exception Ex)
          {
              throw Ex;
          }
      }

      public void DGetAdminExamStatus(BEAdmin objBEAdmin)
      {
          try
          {
              SqlParameter[] objSqlParam = new SqlParameter[1];              
              objSqlParam[0] = new SqlParameter("@I_UserID", SqlDbType.Int);
              objSqlParam[0].Value = objBEAdmin.IntUserID;

              //objSqlParam[1] = new SqlParameter("@I_Period", SqlDbType.Int);
              //objSqlParam[1].Value = objBEAdmin.IntPeriod;

              objBEAdmin.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Admin_GetExamStatus, objSqlParam).Tables[0];
          }
          catch (Exception Ex)
          {
              throw Ex;
          }
      }
      public void DGetPassword(BEAdmin objBEAdmin)
      {
          try
          {

              SqlParameter[] objSqlParam = new SqlParameter[1];

              objSqlParam[0] = new SqlParameter("@StudentID", SqlDbType.Int);
              objSqlParam[0].Value = objBEAdmin.IntStudentID;

              objBEAdmin.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_ADMIN_GetPasswordDetails, objSqlParam).Tables[0];
          }
          catch (Exception Ex)
          {
              throw Ex;
          }
      }

      public void DUpdatePassword(BEAdmin objBEAdmin)
      {
          try
          {

              SqlParameter[] objSqlParam = new SqlParameter[3];

              objSqlParam[0] = new SqlParameter("@StudentID", SqlDbType.Int);
              objSqlParam[0].Value = objBEAdmin.IntStudentID;

              objSqlParam[1] = new SqlParameter("@Password", SqlDbType.VarChar, 20);
              objSqlParam[1].Value = objBEAdmin.StrRandomPassword;

              objSqlParam[2] = new SqlParameter("@Flag", SqlDbType.Int);
              objSqlParam[2].Direction = ParameterDirection.Output;

              SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_ADMIN_UpdatePasswordDetails, objSqlParam);
              objBEAdmin.IntResult = int.Parse(objSqlParam[2].Value.ToString());
          }
          catch (Exception Ex)
          {
              throw Ex;
          }
      }

      public void DExecuteCanvasDataLoad(BEAdmin objBEAdmin)
      {
          try
          {
              SqlParameter[] objSqlParam = new SqlParameter[4];

              objSqlParam[0] = new SqlParameter("@UDT_CanvasUsers", SqlDbType.Structured);
              objSqlParam[0].Value = objBEAdmin.DsResult.Tables[0];
              objSqlParam[1] = new SqlParameter("@UDT_CanvasCourses", SqlDbType.Structured);
              objSqlParam[1].Value = objBEAdmin.DsResult.Tables[1];
              objSqlParam[2] = new SqlParameter("@UDT_CanvasEnrollments", SqlDbType.Structured);
              objSqlParam[2].Value = objBEAdmin.DsResult.Tables[2];
              objSqlParam[3] = new SqlParameter("@UDT_CanvasExams", SqlDbType.Structured);
              objSqlParam[3].Value = objBEAdmin.DsResult.Tables[3];

              SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_CanvasDataload, objSqlParam);
          }
          catch (Exception Ex)
          {
              throw Ex;
          }
      }

      /// <summary>
      /// Get Student Details
      /// </summary>

      public void DGetStudents(BEAdmin objBEAdmin)
      {

          try
          {
              objBEAdmin.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Admin_GetStudents).Tables[0];
          }
          catch (Exception Ex)
          {

              throw Ex;
          }

      }


      /// <summary>
      /// Get Student Enrollments
      /// </summary>

      public void DGetStudentEnrollments(BEAdmin objBEAdmin)
      {
          try
          {
              SqlParameter[] objSqlParam = new SqlParameter[1];

              objSqlParam[0] = new SqlParameter("I_StudentID", SqlDbType.Int);
              objSqlParam[0].Value = objBEAdmin.IntStudentID;


              objBEAdmin.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Admin_GetStudentEnrollments, objSqlParam).Tables[0];
          }

          catch (Exception Ex)
          {
              throw Ex;
          }

      }

      /// <summary>
      /// Add Student
      /// </summary>

      public void DAddStudent(BEAdmin objBEAdmin)
      {
          try
          {
              SqlParameter[] objSqlParam = new SqlParameter[8];
              objSqlParam[0] = new SqlParameter("@V_FirstName", SqlDbType.VarChar, 100);
              objSqlParam[0].Value = objBEAdmin.strFirstName;
              objSqlParam[1] = new SqlParameter("@V_LastName", SqlDbType.VarChar, 100);
              objSqlParam[1].Value = objBEAdmin.strLastName;
              objSqlParam[2] = new SqlParameter("@V_EmailID", SqlDbType.VarChar, 255);
              objSqlParam[2].Value = objBEAdmin.strEmailAddress;
              objSqlParam[3] = new SqlParameter("@I_Flag", SqlDbType.Int);
              objSqlParam[3].Direction = ParameterDirection.Output;
              objSqlParam[4] = new SqlParameter("@B_SpecialNeeds", SqlDbType.Bit);
              objSqlParam[4].Value = objBEAdmin.strSpecialNeeds;
              objSqlParam[5] = new SqlParameter("@V_Password", SqlDbType.VarChar, 50);
              objSqlParam[5].Value = objBEAdmin.strPassword;
              objSqlParam[6] = new SqlParameter("@V_Comments", SqlDbType.VarChar);
              objSqlParam[6].Value = objBEAdmin.StrComments;
              objSqlParam[7] = new SqlParameter("@V_UserName", SqlDbType.VarChar, 200);
              objSqlParam[7].Value = objBEAdmin.strUserName;




              SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Admin_AddStudent, objSqlParam);

              objBEAdmin.IntResult = int.Parse(objSqlParam[3].Value.ToString());
          }
          catch (Exception ex)
          {
              throw ex;
          }
      }


      /// <summary>
      /// Get Student Details
      /// </summary>

      public void DGetStudentDetails(BEAdmin objBEAdmin)
      {
          try
          {
              SqlParameter[] objSqlParam = new SqlParameter[1];

              objSqlParam[0] = new SqlParameter("@I_StudentID", SqlDbType.Int);
              objSqlParam[0].Value = objBEAdmin.IntStudentID;

              objBEAdmin.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Admin_GetStudentDetails, objSqlParam).Tables[0];


          }

          catch (Exception Ex)
          {
              throw Ex;
          }
      }

      /// <summary>
      /// Get Student Transactions
      /// </summary>

      public void DGetStudentTransactionsForAllProviders(BEAdmin objBEAdmin)
      {
          try
          {
              SqlParameter[] objSqlParam = new SqlParameter[1];

              objSqlParam[0] = new SqlParameter("@I_StudentID", SqlDbType.Int);
              objSqlParam[0].Value = objBEAdmin.IntStudentID;
              //objSqlParam[1] = new SqlParameter("@I_ProviderID", SqlDbType.Int);
              //objSqlParam[1].Value = objBEAdmin.IntUserID;

              objBEAdmin.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Admin_GetStudentExamTransactions, objSqlParam).Tables[0];

          }
          catch (Exception ex)
          {
              throw ex;
          }
      }

      /// <summary>
      /// Updating Student Details
      /// </summary>

      public void DUpdateStudentDetails(BEAdmin objBEAdmin)
      {
          try
          {
              SqlParameter[] objSqlParam = new SqlParameter[8];
              objSqlParam[0] = new SqlParameter("@I_StudentID", SqlDbType.Int);
              objSqlParam[0].Value = objBEAdmin.IntStudentID;
              objSqlParam[1] = new SqlParameter("@V_FirstName", SqlDbType.VarChar, 100);
              objSqlParam[1].Value = objBEAdmin.strFirstName;
              objSqlParam[2] = new SqlParameter("@V_LastName", SqlDbType.VarChar, 100);
              objSqlParam[2].Value = objBEAdmin.strLastName;
              objSqlParam[3] = new SqlParameter("@V_EmailAddress", SqlDbType.VarChar, 100);
              objSqlParam[3].Value = objBEAdmin.strEmailAddress;
              //objSqlParam[4] = new SqlParameter("@V_PhoneNumber", SqlDbType.VarChar, 20);
              //objSqlParam[4].Value = objBEAdmin.strPhoneNumber;
              objSqlParam[4] = new SqlParameter("@B_flag", SqlDbType.Int);
              objSqlParam[4].Direction = ParameterDirection.Output;
              //objSqlParam[6] = new SqlParameter("@V_TimeZone", SqlDbType.VarChar, 20);
              //objSqlParam[6].Value = objBEAdmin.strTimeZone;
              objSqlParam[5] = new SqlParameter("@V_SpecialNeeds", SqlDbType.VarChar, 20);
              objSqlParam[5].Value = objBEAdmin.strSpecialNeeds1;
              objSqlParam[6] = new SqlParameter("@V_Comments", SqlDbType.VarChar);
              objSqlParam[6].Value = objBEAdmin.StrComments;
              objSqlParam[7] = new SqlParameter("@I_Status", SqlDbType.Int);
              objSqlParam[7].Value = objBEAdmin.IntstatusFlag;

              SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Admin_SaveStudentDetails, objSqlParam);

              objBEAdmin.IntResult = int.Parse(objSqlParam[4].Value.ToString());
          }
          catch (Exception Ex)
          {
              throw Ex;
          }
      }

      /// <summary>
      /// Deleting Student
      /// </summary>

      public void DDeleteStudent(BEAdmin objBEAdmin)
      {
          try
          {
              SqlParameter[] objSqlParam = new SqlParameter[1];
              objSqlParam[0] = new SqlParameter("@I_StudentID", SqlDbType.Int);
              objSqlParam[0].Value = objBEAdmin.IntStudentID;

              objBEAdmin.DsResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Admin_DeleteStudent, objSqlParam);

          }
          catch (Exception ex)
          {
              throw ex;
          }
      }

      /// <summary>
      /// DGetEnrollStudentName
      /// </summary>

      public void DGetStudentName(BEAdmin objBEAdmin)
      {
          try
          {
              SqlParameter[] objSqlParam = new SqlParameter[1];

              objSqlParam[0] = new SqlParameter("@I_UserID", SqlDbType.Int);
              objSqlParam[0].Value = objBEAdmin.IntStudentID;

              objBEAdmin.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Admin_GetStudentName, objSqlParam).Tables[0];

          }
          catch (Exception ex)
          {
              throw ex;
          }
      }

      /// <summary>
      /// DAdminEnrollStudent
      /// </summary>
      /// <param name="objBEProvider"></param>
      /// 

      public void DAdminEnrollStudent(BEAdmin objBEAdmin)
      {
          try
          {
              SqlParameter[] objSqlParam = new SqlParameter[5];
              objSqlParam[0] = new SqlParameter("@UserID", SqlDbType.BigInt);
              objSqlParam[0].Value = objBEAdmin.IntUserID;
              objSqlParam[1] = new SqlParameter("@CourseID", SqlDbType.BigInt);
              objSqlParam[1].Value = objBEAdmin.IntCourseID;
              objSqlParam[2] = new SqlParameter("@StudentID", SqlDbType.BigInt);
              objSqlParam[2].Value = objBEAdmin.IntStudentID;
              objSqlParam[3] = new SqlParameter("@Flag", SqlDbType.Int);
              objSqlParam[3].Direction = ParameterDirection.Output;
              objSqlParam[4] = new SqlParameter("@TBL_Students", SqlDbType.Structured);
              objSqlParam[4].Value = objBEAdmin.DtResult1;
              SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Admin_EnrolStudent, objSqlParam);

              objBEAdmin.IntResult = Convert.ToInt32(objSqlParam[3].Value.ToString());
          }
          catch (Exception Ex)
          {
              throw Ex;
          }
      }


      /// <summary>
      /// Get Enrolled Student Details
      /// </summary>

      public void DAdminEnrollStudentCourse(BEAdmin objBEAdmin)
      {
          try
          {
              SqlParameter[] objSqlParam = new SqlParameter[4];
              objSqlParam[0] = new SqlParameter("@UserID", SqlDbType.BigInt);
              objSqlParam[0].Value = objBEAdmin.IntUserID;
              objSqlParam[1] = new SqlParameter("@CourseID", SqlDbType.BigInt);
              objSqlParam[1].Value = objBEAdmin.IntCourseID;
              objSqlParam[2] = new SqlParameter("@StudentID", SqlDbType.BigInt);
              objSqlParam[2].Value = objBEAdmin.IntStudentID;
              objSqlParam[3] = new SqlParameter("@Flag", SqlDbType.Int);
              objSqlParam[3].Direction = ParameterDirection.Output;


              SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Admin_EnrolStudentCourse, objSqlParam);

              objBEAdmin.IntResult = Convert.ToInt32(objSqlParam[3].Value.ToString());
          }
          catch (Exception Ex)
          {
              throw Ex;
          }
      }



      public void DGetEnrollStudentDetails(BEAdmin objBEAdmin)
      {
          try
          {
              SqlParameter[] objSqlParam = new SqlParameter[1];
              objSqlParam[0] = new SqlParameter("@I_EnrollID", SqlDbType.Int);
              objSqlParam[0].Value = objBEAdmin.IntEnrollID;

              objBEAdmin.DsResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Admin_GetEnrollStudentDetails, objSqlParam);
          }

          catch (Exception Ex)
          {
              throw Ex;
          }
      }

      /// <summary>
      /// Update Status
      /// </summary>

      public void DUpdateEnrollStatus(BEAdmin objBEAdmin)
      {
          try
          {
              SqlParameter[] objSqlParam = new SqlParameter[3];
              objSqlParam[0] = new SqlParameter("@I_Status", SqlDbType.BigInt);
              objSqlParam[0].Value = objBEAdmin.ddlStatus;
              objSqlParam[1] = new SqlParameter("@I_Flag", SqlDbType.Int);
              objSqlParam[1].Direction = ParameterDirection.Output;
              objSqlParam[2] = new SqlParameter("@I_EnrollId", SqlDbType.BigInt);
              objSqlParam[2].Value = objBEAdmin.IntEnrollID;

              SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Admin_UpdateStudentStatus, objSqlParam);

              objBEAdmin.IntResult = int.Parse(objSqlParam[1].Value.ToString());
          }
          catch (Exception ex)
          {
              throw ex;
          }
      }


      /// <summary>
      /// Delete Enrollment Status
      /// </summary>

      public void DDeleteEnrollmentStatus(BEAdmin objBEAdmin)
      {
          try
          {
              SqlParameter[] objSqlParam = new SqlParameter[2];
              objSqlParam[0] = new SqlParameter("@I_EnrollID", SqlDbType.Int);
              objSqlParam[0].Value = objBEAdmin.IntEnrollID;
              objSqlParam[1] = new SqlParameter("@I_Flag", SqlDbType.Int);
              objSqlParam[1].Direction = ParameterDirection.Output;

              SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Admin_DeleteEnrollStudent, objSqlParam);

              objBEAdmin.IntResult = int.Parse(objSqlParam[1].Value.ToString());
          }
          catch (Exception ex)
          {
              throw ex;
          }
      }

      /// <summary>
      /// Get Exam Details for Selected Course
      /// </summary>

      public void DGetExamDetails(BEAdmin objBEAdmin)
      {
          try
          {
              SqlParameter[] objSqlParam = new SqlParameter[2];

              objSqlParam[0] = new SqlParameter("@I_CourseID", SqlDbType.Int);
              objSqlParam[0].Value = objBEAdmin.IntCourseID;
              objSqlParam[1] = new SqlParameter("@I_UserID", SqlDbType.Int);
              objSqlParam[1].Value = objBEAdmin.IntUserID;

              objBEAdmin.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Admin_GetExams, objSqlParam).Tables[0];
          }
          catch (Exception Ex)
          {
              throw Ex;
          }
      }
      /// <summary>
      /// Add Course
      /// </summary>

      public void DAddCourse(BEAdmin objBEAdmin)
      {
          try
          {
              SqlParameter[] objSqlParam = new SqlParameter[4];

              objSqlParam[0] = new SqlParameter("@V_CourseID", SqlDbType.VarChar, 50);
              objSqlParam[0].Value = objBEAdmin.strCourseID;

              objSqlParam[1] = new SqlParameter("@V_CourseName", SqlDbType.VarChar, 100);
              objSqlParam[1].Value = objBEAdmin.strCourseName;

              objSqlParam[2] = new SqlParameter("@I_ProviderID", SqlDbType.Int);
              objSqlParam[2].Value = objBEAdmin.IntProviderID;

              objSqlParam[3] = new SqlParameter("@I_Result", SqlDbType.Int);
              objSqlParam[3].Direction = ParameterDirection.Output;

              SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Admin_AddCourse, objSqlParam);

              objBEAdmin.IntResult = Convert.ToInt32(objSqlParam[3].Value.ToString());
          }
          catch (Exception Ex)
          {
              throw Ex;
          }
      }


      /// <summary>
      /// DBindProviderSecurityLevel
      /// </summary>

      public void DGetExamProviders(BEAdmin objBEAdmin)
      {
          try
          {
              objBEAdmin.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Admin_GetExamProviders).Tables[0];
          }
          catch (Exception Ex)
          {

              throw Ex;
          }

      }

      /// <summary>
      /// Get Course Details
      /// </summary>

      public void DGetSelectedCourseDetails(BEAdmin objBEAdmin)
      {
          try
          {
              SqlParameter[] objSqlParam = new SqlParameter[1];

              objSqlParam[0] = new SqlParameter("@I_CourseID", SqlDbType.Int);
              objSqlParam[0].Value = objBEAdmin.IntCourseID;

              objBEAdmin.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Admin_GetSelectedCourseDetails, objSqlParam).Tables[0];
          }
          catch (Exception Ex)
          {
              throw Ex;
          }
      }

      /// <summary>
      /// Get Course Details For Selected Exam Provider
      /// </summary>

      public void DGetSelectedExamDetails(BEAdmin objBEAdmin)
      {
          try
          {
              SqlParameter[] objSqlParam = new SqlParameter[2];

              objSqlParam[0] = new SqlParameter("@I_ExamID", SqlDbType.Int);
              objSqlParam[0].Value = objBEAdmin.IntExamID;
              objSqlParam[1] = new SqlParameter("@I_UserID", SqlDbType.Int);
              objSqlParam[1].Value = objBEAdmin.IntUserID;

              objBEAdmin.DsResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Admin_GetSelectedExamDetails, objSqlParam);
          }
          catch (Exception Ex)
          {
              throw Ex;
          }
      }
      /// <summary>
      /// Delete Exam
      /// </summary>

      public void DDeleteExam(BEAdmin objBEAdmin)
      {
          try
          {
              SqlParameter[] objSqlParam = new SqlParameter[2];

              objSqlParam[0] = new SqlParameter("@I_ExamID", SqlDbType.Int);
              objSqlParam[0].Value = objBEAdmin.IntExamID;

              objSqlParam[1] = new SqlParameter("@I_Status", SqlDbType.Int);
              objSqlParam[1].Direction = ParameterDirection.Output;

              SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Admin_DeleteExam, objSqlParam);

              objBEAdmin.IntResult = Convert.ToInt32(objSqlParam[1].Value.ToString());
          }
          catch (Exception Ex)
          {
              throw Ex;
          }
      }
      /// <summary>
      /// DBindProviderSecurityLevel
      /// </summary>

      public void DBindProviderSecurityLevel(BEAdmin objBEAdmin)
      {
          try
          {
              objBEAdmin.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Admin_ExamLevel).Tables[0];
          }
          catch (Exception Ex)
          {
              throw Ex;
          }
      }

      /// <summary>
      /// Find the Exam Existence while updating the new exam
      /// </summary>

      public void DCheckForUpdateExamExistence(BEAdmin objBEAdmin)
      {
          try
          {
              SqlParameter[] objSqlParam = new SqlParameter[3];

              objSqlParam[0] = new SqlParameter("@I_ExamID", SqlDbType.Int);
              objSqlParam[0].Value = objBEAdmin.IntExamID;
              objSqlParam[1] = new SqlParameter("@V_ExamName", SqlDbType.VarChar, 100);
              objSqlParam[1].Value = objBEAdmin.strExamName;
              objSqlParam[2] = new SqlParameter("@I_Result", SqlDbType.Int);
              objSqlParam[2].Direction = ParameterDirection.Output;

              SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Admin_CheckForUpdateExamExistence, objSqlParam);

              objBEAdmin.IntResult = int.Parse(objSqlParam[2].Value.ToString());
          }
          catch (Exception ex)
          {
              throw ex;
          }
      }


      public void DUpdateExamDetails(BEAdmin objBEAdmin)
      {
          try
          {
              SqlParameter[] objSqlParam = new SqlParameter[16];

              objSqlParam[0] = new SqlParameter("@I_ExamID", SqlDbType.Int);
              objSqlParam[0].Value = objBEAdmin.IntExamID;
              objSqlParam[1] = new SqlParameter("@V_ExamName", SqlDbType.VarChar, 50);
              objSqlParam[1].Value = objBEAdmin.strExamName;
              objSqlParam[2] = new SqlParameter("@D_ExamDuration", SqlDbType.VarChar, 50);
              objSqlParam[2].Precision = StoredProcedures.Precision;
              objSqlParam[2].Scale = StoredProcedures.Scale;
              objSqlParam[2].Value = objBEAdmin.ddlHM;
              objSqlParam[3] = new SqlParameter("@V_ExamLink", SqlDbType.VarChar, 2000);
              objSqlParam[3].Value = objBEAdmin.strLinkAccessExam;
              objSqlParam[4] = new SqlParameter("@V_StartDate", SqlDbType.DateTime);
              objSqlParam[4].Value = objBEAdmin.strExamStartDate;
              objSqlParam[5] = new SqlParameter("@V_EndDate", SqlDbType.DateTime);
              objSqlParam[5].Value = objBEAdmin.strExamEndDate;
              objSqlParam[6] = new SqlParameter("@Notes", SqlDbType.Structured);
              if (objBEAdmin.DtResult != null)
                  objSqlParam[6].Value = objBEAdmin.DtResult;
              objSqlParam[7] = new SqlParameter("@Rules", SqlDbType.Structured);
              if (objBEAdmin.DtResult1 != null)
                  objSqlParam[7].Value = objBEAdmin.DtResult1;
            
              objSqlParam[8] = new SqlParameter("@B_Flag", SqlDbType.Int);
              objSqlParam[8].Direction = ParameterDirection.Output;
              objSqlParam[9] = new SqlParameter("@I_UserID", SqlDbType.BigInt);
              objSqlParam[9].Value = objBEAdmin.IntUserID;
              objSqlParam[10] = new SqlParameter("@ExamBufferTime", SqlDbType.Int);
              objSqlParam[10].Value = objBEAdmin.IntBufferTime;
              objSqlParam[11] = new SqlParameter("@OriginalFileName", SqlDbType.VarChar, 200);
              objSqlParam[11].Value = objBEAdmin.strOriginalFileName;
              objSqlParam[12] = new SqlParameter("@StoredFileName", SqlDbType.VarChar, 200);
              objSqlParam[12].Value = objBEAdmin.strUploadPath;
              objSqlParam[13] = new SqlParameter("@SecurityLevel", SqlDbType.Int);
              objSqlParam[13].Value = objBEAdmin.ddlSecurityLevel;
              objSqlParam[14] = new SqlParameter("@Status", SqlDbType.Int);
              objSqlParam[14].Value = objBEAdmin.Intstatus;
              objSqlParam[15] = new SqlParameter("@ExamPassword", SqlDbType.VarChar,50);
              objSqlParam[15].Value = objBEAdmin.strPassword;

              SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Admin_UpdateExamDetails, objSqlParam);

              objBEAdmin.IntResult = int.Parse(objSqlParam[8].Value.ToString());
          }
          catch (Exception ex)
          {
              throw ex;
          }
      }

      /// <summary>
      /// DDeleteUploadFiles
      /// </summary>
      /// <param name="objBEProvider"></param>

      public void DDeleteUploadFiles(BEAdmin objBEAdmin)
      {
          try
          {
              SqlParameter[] objSqlParam = new SqlParameter[2];
              objSqlParam[0] = new SqlParameter("@I_ExamID", SqlDbType.Int);
              objSqlParam[0].Value = objBEAdmin.IntExamID;

              objSqlParam[1] = new SqlParameter("@I_Flag", SqlDbType.Int);
              objSqlParam[1].Direction = ParameterDirection.Output;

              SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Admin_DeleteUploadFile, objSqlParam);

              objBEAdmin.IntResult = int.Parse(objSqlParam[1].Value.ToString());

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
      public void DGetSelectedSecurityLevel(BEAdmin objBEAdmin)
      {
          try
          {
              SqlParameter[] objSqlParam = new SqlParameter[2];

              objSqlParam[0] = new SqlParameter("@I_SecurityLevel", SqlDbType.Int);
              objSqlParam[0].Value = objBEAdmin.ddlSecurityLevel;
              objSqlParam[1] = new SqlParameter("@V_SecDesc", SqlDbType.VarChar, 500);
              objSqlParam[1].Direction = ParameterDirection.Output;

              SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Admin_GetSecurityLevelDesc, objSqlParam);

              objBEAdmin.StrResult = objSqlParam[1].Value.ToString();

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
      public void DCheckForExamExistence(BEAdmin objBEAdmin)
      {
          try
          {
              SqlParameter[] objSqlParam = new SqlParameter[4];
              objSqlParam[0] = new SqlParameter("@V_CourseID", SqlDbType.Int);
              objSqlParam[0].Value = objBEAdmin.IntCourseID;
              objSqlParam[1] = new SqlParameter("@V_ExamName", SqlDbType.VarChar, 100);
              objSqlParam[1].Value = objBEAdmin.strExamName;
              objSqlParam[2] = new SqlParameter("@I_Result", SqlDbType.Int);
              objSqlParam[2].Direction = ParameterDirection.Output;
              objSqlParam[3] = new SqlParameter("@I_UserID", SqlDbType.Int);
              objSqlParam[3].Value = objBEAdmin.IntUserID;

              SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Admin_CheckForExamExistence, objSqlParam);

              objBEAdmin.IntResult = int.Parse(objSqlParam[2].Value.ToString());
          }
          catch (Exception ex)
          {
              throw ex;
          }
      }


      /// <summary>
      /// Save ExamDetails 
      /// </summary>

      public void DSaveExamDetails(BEAdmin objBEAdmin)
      {
          try
          {
              SqlParameter[] objSqlParam = new SqlParameter[16];
              objSqlParam[0] = new SqlParameter("@I_CourseID", SqlDbType.Int);
              objSqlParam[0].Value = objBEAdmin.IntCourseID;
              objSqlParam[1] = new SqlParameter("@V_ExamName", SqlDbType.VarChar, 50);
              objSqlParam[1].Value = objBEAdmin.strExamName;
              objSqlParam[2] = new SqlParameter("@D_ExamDuration", SqlDbType.VarChar, 50);
              objSqlParam[2].Precision = StoredProcedures.Precision;
              objSqlParam[2].Scale = StoredProcedures.Scale;
              objSqlParam[2].Value = objBEAdmin.ddlHM;
              objSqlParam[3] = new SqlParameter("@V_ExamLink", SqlDbType.VarChar, 2000);
              objSqlParam[3].Value = objBEAdmin.strLinkAccessExam;
              objSqlParam[4] = new SqlParameter("@V_StartDate", SqlDbType.DateTime);
              objSqlParam[4].Value = objBEAdmin.strExamStartDate;
              objSqlParam[5] = new SqlParameter("@V_EndDate", SqlDbType.DateTime);
              objSqlParam[5].Value = objBEAdmin.strExamEndDate;
              objSqlParam[6] = new SqlParameter("@V_OpenBook", SqlDbType.Int);
              objSqlParam[6].Value = objBEAdmin.strOpenBook;
              objSqlParam[7] = new SqlParameter("@V_Notes", SqlDbType.VarChar, 50);
              objSqlParam[7].Value = objBEAdmin.strNotes;
              objSqlParam[8] = new SqlParameter("@Notes", SqlDbType.Structured);
              if (objBEAdmin.DtResult != null)
                  objSqlParam[8].Value = objBEAdmin.DtResult;
            
              objSqlParam[9] = new SqlParameter("@Rules", SqlDbType.Structured);
              if (objBEAdmin.DtResult1 != null)
                  objSqlParam[9].Value = objBEAdmin.DtResult1;
            
              objSqlParam[10] = new SqlParameter("@B_Flag", SqlDbType.Int);
              objSqlParam[10].Direction = ParameterDirection.Output;
              objSqlParam[11] = new SqlParameter("@ExamBufferTime", SqlDbType.Int);
              objSqlParam[11].Value = objBEAdmin.IntBufferTime;
              objSqlParam[12] = new SqlParameter("@OriginalFileName", SqlDbType.VarChar, 200);
              objSqlParam[12].Value = objBEAdmin.strOriginalFileName;
              objSqlParam[13] = new SqlParameter("@StoredFileName", SqlDbType.VarChar, 200);
              objSqlParam[13].Value = objBEAdmin.strUploadPath;
              objSqlParam[14] = new SqlParameter("@ExamLevel", SqlDbType.Int);
              objSqlParam[14].Value = objBEAdmin.ddlSecurityLevel;
              objSqlParam[15] = new SqlParameter("@ExamPassword", SqlDbType.VarChar, 50);
              objSqlParam[15].Value = objBEAdmin.strPassword;



              SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Admin_SaveExamDetails, objSqlParam);

              objBEAdmin.IntResult = int.Parse(objSqlParam[10].Value.ToString());
          }
          catch (Exception ex)
          {
              throw ex;
          }
      }


      public void DGetInstructors(BEAdmin objBEAdmin)
      {
          try
          {

              SqlParameter[] objSqlParam = new SqlParameter[0];



              objBEAdmin.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Admin_GetInstructors, objSqlParam).Tables[0];
          }
          catch (Exception Ex)
          {
              throw Ex;
          }
      }
      public void DAddInstructor(BEAdmin objBEAdmin)
      {
          try
          {
              SqlParameter[] objSqlParam = new SqlParameter[6];
              objSqlParam[0] = new SqlParameter("@V_FirstName", SqlDbType.VarChar, 100);
              objSqlParam[0].Value = objBEAdmin.strFirstName;
              objSqlParam[1] = new SqlParameter("@V_LastName", SqlDbType.VarChar, 100);
              objSqlParam[1].Value = objBEAdmin.strLastName;
              objSqlParam[2] = new SqlParameter("@V_EmailID", SqlDbType.VarChar, 255);
              objSqlParam[2].Value = objBEAdmin.strEmailAddress;
              objSqlParam[3] = new SqlParameter("@I_Flag", SqlDbType.Int);
              objSqlParam[3].Direction = ParameterDirection.Output;
              objSqlParam[4] = new SqlParameter("@V_Password", SqlDbType.VarChar, 50);
              objSqlParam[4].Value = objBEAdmin.strPassword;
              objSqlParam[5] = new SqlParameter("@V_UserName", SqlDbType.VarChar, 200);
              objSqlParam[5].Value = objBEAdmin.strUserName;
             


              SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Admin_AddInstructor, objSqlParam);

              objBEAdmin.IntResult = int.Parse(objSqlParam[3].Value.ToString());
          }
          catch (Exception ex)
          {
              throw ex;
          }
      }

      public void DGetPaymentMode(BEAdmin objBEAdmin)
      {
          try
          {
              objBEAdmin.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Admin_PaymentMode).Tables[0];
          }
          catch (Exception Ex)
          {
              throw Ex;
          }
      }

      public void DGetClientContactDetails(BEAdmin objBEAdmin)
      {
          try
          {
              objBEAdmin.DsResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Admin_GetClientContactDetails);
          }
          catch (Exception Ex)
          {
              throw Ex;
          }
      }
      public void DGetCourseDetails_CourseStudents(BEAdmin objBEAdmin)
      {
          try
          {
              objBEAdmin.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Admin_GetCourses_CourseStudents).Tables[0];
          }
          catch (Exception Ex)
          {
              throw Ex;
          }
      }
      public void DGetCourseDetailsbyProvider(BEAdmin objBEAdmin)
      {
          try
          {
              SqlParameter[] objSqlParam = new SqlParameter[2];
              objSqlParam[0] = new SqlParameter("@I_CourseID", SqlDbType.Int);
              objSqlParam[0].Value = objBEAdmin.IntCourseID;
              objSqlParam[1] = new SqlParameter("@I_ProviderID", SqlDbType.Int);
              objSqlParam[1].Value = objBEAdmin.IntProviderID;
              objBEAdmin.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Admin_GetCourseDetailsbyProvider, objSqlParam).Tables[0];
          }
          catch (Exception Ex)
          {
              throw Ex;
          }
      }
      public void DGetCourseStudents(BEAdmin objBEAdmin)
      {

          try
          {
              SqlParameter[] objSqlParam = new SqlParameter[2];

              objSqlParam[0] = new SqlParameter("@I_CourseID", SqlDbType.Int);
              objSqlParam[0].Value = objBEAdmin.IntCourseID;
              objSqlParam[1] = new SqlParameter("@I_ProviderID", SqlDbType.Int);
              objSqlParam[1].Value = objBEAdmin.IntProviderID;

              objBEAdmin.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Admin_GetEnrolledStudents, objSqlParam).Tables[0];
          }
          catch (Exception Ex)
          {

              throw Ex;
          }

      }
      public void DGetStudentsNotInCourse(BEAdmin objBEAdmin)
      {

          try
          {
              SqlParameter[] objSqlParam = new SqlParameter[1];

              objSqlParam[0] = new SqlParameter("@I_CourseID", SqlDbType.Int);
              objSqlParam[0].Value = objBEAdmin.IntCourseID;

              objBEAdmin.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Admin_GetStudentsNotInCourse, objSqlParam).Tables[0];
          }
          catch (Exception Ex)
          {

              throw Ex;
          }

      }
      public void DGetStudentsDetails(BEAdmin objBEAdmin)
      {

          try
          {
              SqlParameter[] objSqlParam = new SqlParameter[3];

              objSqlParam[0] = new SqlParameter("@StudentFirstName", SqlDbType.VarChar, 200);
              objSqlParam[0].Value = objBEAdmin.strFirstName;

              objSqlParam[1] = new SqlParameter("@StudentLastName", SqlDbType.VarChar, 200);
              objSqlParam[1].Value = objBEAdmin.strLastName;

              objSqlParam[2] = new SqlParameter("@StudentEmailAddress", SqlDbType.VarChar, 200);
              objSqlParam[2].Value = objBEAdmin.strEmailAddress;

              objBEAdmin.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Admin_GetStudentsDetails, objSqlParam).Tables[0];
              //objBEAdmin.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Admin_GetStudentsDetails).Tables[0];
          }
          catch (Exception Ex)
          {

              throw Ex;
          }

      }


      public void DGetCoursePrimaryInstructors(BEAdmin objBEAdmin)
      {

          try
          {
              SqlParameter[] objSqlParam = new SqlParameter[1];

              objSqlParam[0] = new SqlParameter("@I_CourseID", SqlDbType.Int);
              objSqlParam[0].Value = objBEAdmin.IntCourseID;

              objBEAdmin.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_GetCoursePrimaryInstructors", objSqlParam).Tables[0];
          }
          catch (Exception Ex)
          {

              throw Ex;
          }

      }


      public void DAdminUpdateisPrimaryInstructor(BEAdmin objBEAdmin)
      {
          try
          {
              SqlParameter[] objSqlParam = new SqlParameter[3];
       
              objSqlParam[0] = new SqlParameter("@CourseID", SqlDbType.BigInt);
              objSqlParam[0].Value = objBEAdmin.IntCourseID;
         
              objSqlParam[1] = new SqlParameter("@Flag", SqlDbType.Int);
              objSqlParam[1].Direction = ParameterDirection.Output;
              objSqlParam[2] = new SqlParameter("@TBL_Students", SqlDbType.Structured);
              objSqlParam[2].Value = objBEAdmin.DtResult1;

              SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_Admin_UpdatePrimaryInstructors", objSqlParam);

              objBEAdmin.IntResult = Convert.ToInt32(objSqlParam[1].Value.ToString());
          }
          catch (Exception Ex)
          {
              throw Ex;
          }
      }



      public void DGetCourseExamDetails(BEAdmin objBEAdmin)
      {

          try
          {
              SqlParameter[] objSqlParam = new SqlParameter[3];

              objSqlParam[0] = new SqlParameter("@CourseID", SqlDbType.VarChar, 200);
              objSqlParam[0].Value = objBEAdmin.strCourseID;

              objSqlParam[1] = new SqlParameter("@strCourseName", SqlDbType.VarChar, 200);
              objSqlParam[1].Value = objBEAdmin.strCourseName;

              objSqlParam[2] = new SqlParameter("@strInstructorName", SqlDbType.VarChar, 200);
              objSqlParam[2].Value = objBEAdmin.strStudentName;

              objBEAdmin.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_Admin_GetCourseExamDetails", objSqlParam).Tables[0];
              //objBEAdmin.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Admin_GetStudentsDetails).Tables[0];
          }
          catch (Exception Ex)
          {

              throw Ex;
          }

      }

      //16july2015
      public void DGetAdminAppointmentDetails(BEAdmin objBEAdmin)
      {
          try
          {
              SqlParameter[] objSqlParam = new SqlParameter[3];
              objSqlParam[0] = new SqlParameter("@courseId", SqlDbType.Int);
              objSqlParam[0].Value = objBEAdmin.IntCourseID;
              objSqlParam[1] = new SqlParameter("@examId", SqlDbType.Int);
              objSqlParam[1].Value = objBEAdmin.IntExamID;
              objSqlParam[2] = new SqlParameter("@type", SqlDbType.Int);
              objSqlParam[2].Value = objBEAdmin.IntType;

              objBEAdmin.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Admin_GetAppointmentDetails, objSqlParam).Tables[0];
          }
          catch (Exception Ex)
          {
              throw Ex;
          }
      }



      public void DGetTestResultReportDetails(BEAdmin objBEAdmin)
      {
          try
          {
              SqlParameter[] objSqlParam = new SqlParameter[4];
              //objSqlParam[0] = new SqlParameter("@SearchStartDate", SqlDbType.DateTime);
              //objSqlParam[0].Value = objBEAdmin.strExamStartDate;
              //objSqlParam[1] = new SqlParameter("@searchEndDate", SqlDbType.DateTime);
              //objSqlParam[1].Value = objBEAdmin.strExamEndDate;
              //objSqlParam[2] = new SqlParameter("@courseID", SqlDbType.VarChar);
              //objSqlParam[2].Value = objBEAdmin.strCourseID;
              objSqlParam[0] = new SqlParameter("@ExamID", SqlDbType.VarChar);
              objSqlParam[0].Value = objBEAdmin.strCourseID;
              objSqlParam[1] = new SqlParameter("@instructorId", SqlDbType.Int);
              objSqlParam[1].Value = objBEAdmin.IntUserID;
              objSqlParam[2] = new SqlParameter("@StartDate", SqlDbType.VarChar, 50);
              objSqlParam[2].Value = objBEAdmin.DtStartDate;
              objSqlParam[3] = new SqlParameter("@EndDate", SqlDbType.VarChar, 50);
              objSqlParam[3].Value = objBEAdmin.DtEndDate;



              objBEAdmin.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_Admin_GetTestResultsReport", objSqlParam).Tables[0];
          }
          catch (Exception Ex)
          {
              throw Ex;
          }
      }

      public void DGetAllExamDetails(BEAdmin objBEAdmin)
      {
          try
          {
              SqlParameter[] objSqlParam = new SqlParameter[1];
              objSqlParam[0] = new SqlParameter("@courseId", SqlDbType.VarChar);
              objSqlParam[0].Value = objBEAdmin.strCourseID;

              objBEAdmin.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Admin_GetAllExamDetails, objSqlParam).Tables[0];
          }
          catch (Exception Ex)
          {
              throw Ex;
          }
      }


      public void DGetAppointmentScheduleReportDetails(BEAdmin objBEAdmin)
      {
          try
          {
              SqlParameter[] objSqlParam = new SqlParameter[2];

              objSqlParam[0] = new SqlParameter("@ExamID", SqlDbType.VarChar);
              objSqlParam[0].Value = objBEAdmin.strCourseID;
              objSqlParam[1] = new SqlParameter("@instructorId", SqlDbType.Int);
              objSqlParam[1].Value = objBEAdmin.IntUserID;



              objBEAdmin.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_Admin_AppointmentScheduleReport", objSqlParam).Tables[0];
          }
          catch (Exception Ex)
          {
              throw Ex;
          }
      }

      public void DGetExamDetailsBySplIns(BEAdmin objBEAdmin)
      {
          try
          {
              SqlParameter[] objSqlParam = new SqlParameter[2];

              objSqlParam[0] = new SqlParameter("@I_CourseID", SqlDbType.Int);
              objSqlParam[0].Value = objBEAdmin.IntCourseID;
              objSqlParam[1] = new SqlParameter("@I_UserID", SqlDbType.Int);
              objSqlParam[1].Value = objBEAdmin.IntUserID;

              objBEAdmin.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_Admin_GetExamsBySplIns, objSqlParam).Tables[0];
          }
          catch (Exception Ex)
          {
              throw Ex;
          }
      }

      public void DGetCoursesBySplIns(BEAdmin objBEAdmin)
      {
          try
          {
              //SqlParameter[] objSqlParam = new SqlParameter[2];

              //objSqlParam[0] = new SqlParameter("@I_CourseID", SqlDbType.Int);
              //objSqlParam[0].Value = objBEAdmin.IntCourseID;
              //objSqlParam[1] = new SqlParameter("@I_UserID", SqlDbType.Int);
              //objSqlParam[1].Value = objBEAdmin.IntUserID;

              objBEAdmin.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_Admin_GetCoursesBySpecialInstructions").Tables[0];
          }
          catch (Exception Ex)
          {
              throw Ex;
          }
      }

      //10feb2017
      public void DGetExamDetailsByCourseAndSplIns(BEAdmin objBEAdmin)
      {
          try
          {
              SqlParameter[] objSqlParam = new SqlParameter[2];

              objSqlParam[0] = new SqlParameter("@courseId", SqlDbType.Int);
              objSqlParam[0].Value = objBEAdmin.IntCourseID;
              //objSqlParam[1] = new SqlParameter("@I_UserID", SqlDbType.Int);
              //objSqlParam[1].Value = objBEAdmin.IntUserID;

              objBEAdmin.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_Admin_GetExamsByCourseAndSpecialInstructions", objSqlParam).Tables[0];
          }
          catch (Exception Ex)
          {
              throw Ex;
          }
      }

      //10feb2017
      public void DGetProviderCoursesBySplIns(BEAdmin objBEAdmin)
      {
          try
          {
              SqlParameter[] objSqlParam = new SqlParameter[2];

              objSqlParam[0] = new SqlParameter("@providerId", SqlDbType.Int);
              objSqlParam[0].Value = objBEAdmin.IntUserID;
              //objSqlParam[1] = new SqlParameter("@I_UserID", SqlDbType.Int);
              //objSqlParam[1].Value = objBEAdmin.IntUserID;

              objBEAdmin.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_Provider_GetCoursesBySpecialInstructions", objSqlParam).Tables[0];
          }
          catch (Exception Ex)
          {
              throw Ex;
          }
      }
      //10feb2017
      public void DGetCourseAdminCoursesBySplIns(BEAdmin objBEAdmin)
      {
          try
          {
              SqlParameter[] objSqlParam = new SqlParameter[2];

              objSqlParam[0] = new SqlParameter("@I_UserID", SqlDbType.Int);
              objSqlParam[0].Value = objBEAdmin.IntUserID;
              //objSqlParam[1] = new SqlParameter("@I_UserID", SqlDbType.Int);
              //objSqlParam[1].Value = objBEAdmin.IntUserID;

              objBEAdmin.DtResult = SQLHelper.ExecuteDataset(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_CourseAdmin_GetCoursesBySpecialInstructions", objSqlParam).Tables[0];
          }
          catch (Exception Ex)
          {
              throw Ex;
          }
      }
     

    }
}
