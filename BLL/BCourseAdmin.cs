using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessEntities;
using DAL;

namespace BLL
{
   public class BCourseAdmin
    {
        #region BGetProviderExams
        public void BGetProviderExams(BECourseAdmin objBECourseAdmin)
        {
            try
            {
                new DCourseAdmin().DGetProviderExams(objBECourseAdmin);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        public void BGetStudentsAndCourses(BECourseAdmin objBECourseAdmin)
        {
            try
            {
                new DCourseAdmin().DGetStudentsAndCourses(objBECourseAdmin);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public void BGetStudentsDetails(BECourseAdmin objBECourseAdmin)
        {
            try
            {
                new DCourseAdmin().DGetStudentsDetails(objBECourseAdmin);
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BProviderEnrollStudentCourse(BECourseAdmin objBECourseAdmin)
        {
            try
            {
                new DCourseAdmin().DProviderEnrollStudentCourse(objBECourseAdmin);
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
        public void BGetStudents(BECourseAdmin objBECourseAdmin)
        {
            try
            {
                new DCourseAdmin().DGetStudents(objBECourseAdmin);
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        #region BGetStudentDetails
        public void BGetStudentDetails(BECourseAdmin objBECourseAdmin)
        {
            try
            {
                new DCourseAdmin().DGetStudentDetails(objBECourseAdmin);
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        #region BGetStudentEnrollments
        public void BGetStudentEnrollments(BECourseAdmin objBECourseAdmin)
        {
            try
            {
                new DCourseAdmin().DGetStudentEnrollments(objBECourseAdmin);
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        #region BSaveStudentDetails
        public void BSaveStudentDetails(BECourseAdmin objBECourseAdmin)
        {
            try
            {
                new DCourseAdmin().DSaveStudentDetails(objBECourseAdmin);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        #region BDeleteStudent
        public void BDeleteStudent(BECourseAdmin objBECourseAdmin)
        {
            try
            {
                new DCourseAdmin().DDeleteStudent(objBECourseAdmin);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        public void BEnrollStudent(BECourseAdmin objBECourseAdmin)
        {
            try
            {
                new DCourseAdmin().DEnrollStudent(objBECourseAdmin);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BGetExistingExamDetails(BECourseAdmin objBECourseAdmin)
        {
            try
            {
                new DCourseAdmin().DGetExistingExamDetails(objBECourseAdmin);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BValidateExam(BECourseAdmin objBECourseAdmin)
        {

            try
            {
                new DCourseAdmin().DValidateExam(objBECourseAdmin);
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BSaveExamDetails(BECourseAdmin objBECourseAdmin)
        {

            try
            {
                new DCourseAdmin().DSaveExamDetails(objBECourseAdmin);
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BViewExamDetails(BECourseAdmin objBECourseAdmin)
        {

            try
            {
                new DCourseAdmin().DViewExamDetails(objBECourseAdmin);
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BDeleteExamDetails(BECourseAdmin objBECourseAdmin)
        {
            try
            {
                new DCourseAdmin().DDeleteExamDetails(objBECourseAdmin);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BUpdateExamDetails(BECourseAdmin objBECourseAdmin)
        {
            try
            {
                new DCourseAdmin().DUpdateExamDetails(objBECourseAdmin);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BUpdateStudentDetails(BECourseAdmin objBECourseAdmin)
        {

            try
            {
                new DCourseAdmin().DUpdateStudentDetails(objBECourseAdmin);
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BUpdateStatus(BECourseAdmin objBECourseAdmin)
        {
            try
            {
                new DCourseAdmin().DUpdateStatus(objBECourseAdmin);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BDeleteStatus(BECourseAdmin objBECourseAdmin)
        {
            try
            {
                new DCourseAdmin().DDeleteStatus(objBECourseAdmin);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BSaveCourseDetails(BECourseAdmin objBECourseAdmin)
        {
            try
            {
                new DCourseAdmin().DSaveCourseDetails(objBECourseAdmin);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BGetCourseDetails(BECourseAdmin objBECourseAdmin)
        {
            try
            {
                new DCourseAdmin().DGetCourseDetails(objBECourseAdmin);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BUpdateCourseDetails(BECourseAdmin objBECourseAdmin)
        {
            try
            {
                new DCourseAdmin().DUpdateCourseDetails(objBECourseAdmin);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BAdminValidateExam(BECourseAdmin objBECourseAdmin)
        {
            try
            {
                new DCourseAdmin().DAdminValidateExam(objBECourseAdmin);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BAdminSaveExamDetails(BECourseAdmin objBECourseAdmin)
        {
            try
            {
                new DCourseAdmin().DAdminSaveExamDetails(objBECourseAdmin);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BAdminEnrollStudent(BECourseAdmin objBECourseAdmin)
        {
            try
            {
                new DCourseAdmin().DAdminEnrollStudent(objBECourseAdmin);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BDeleteUploadFiles(BECourseAdmin objBECourseAdmin)
        {
            try
            {
                new DCourseAdmin().DDeleteUploadFiles(objBECourseAdmin);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        /// <summary>
        /// Get Exam Details for Selected Course
        /// </summary>
        /// <param name="objBECourseAdmin"></param>
        public void BGetExamDetails(BECourseAdmin objBECourseAdmin)
        {
            try
            {
                new DCourseAdmin().DGetExamDetails(objBECourseAdmin);
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
        public void BGetStudentTransactionsForCurrentProvider(BECourseAdmin objBECourseAdmin)
        {
            try
            {
                new DCourseAdmin().DGetStudentTransactionsForCurrentProvider(objBECourseAdmin);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BGetStudentTransactionsByLoggedInCourseAdminCourses(BECourseAdmin objBECourseAdmin)
        {
            try
            {
                new DCourseAdmin().DGetStudentTransactionsByLoggedInCourseAdminCourses(objBECourseAdmin);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        
        public void BBindCourseAdminSpecificProviderCourses(BECourseAdmin objBECourseAdmin) 
        {
            try
            {
                new DCourseAdmin().DBindCourseAdminSpecificProviderCourses(objBECourseAdmin);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        /// <summary>
        /// Add Course
        /// </summary>
        /// <param name="objBECourseAdmin"></param>
        public void BAddCourse(BECourseAdmin objBECourseAdmin)
        {
            try
            {
                new DCourseAdmin().DAddCourse(objBECourseAdmin);
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
        public void BGetSelectedCourseDetails(BECourseAdmin objBECourseAdmin)
        {
            try
            {
                new DCourseAdmin().DGetSelectedCourseDetails(objBECourseAdmin);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        /// <summary>
        /// BDeleteCourse
        /// </summary>
        /// <param name="objBECourseAdmin"></param>
        /// 
        public void BDeleteCourse(BECourseAdmin objBECourseAdmin)
        {
            try
            {
                new DCourseAdmin().DDeleteCourse(objBECourseAdmin);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        /// <summary>
        /// BGetSelectedSecurityLevel
        /// </summary>
        /// <param name="objBECourseAdmin"></param>

        public void BGetSelectedSecurityLevel(BECourseAdmin objBECourseAdmin)
        {

            try
            {
                new DCourseAdmin().DGetSelectedSecurityLevel(objBECourseAdmin);
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        /// <summary>
        /// ProviderSecurityLevel
        /// </summary>
        /// <param name="objBECourseAdmin"></param>

        public void BBindProviderSecurityLevel(BECourseAdmin objBECourseAdmin)
        {

            try
            {
                new DCourseAdmin().DBindProviderSecurityLevel(objBECourseAdmin);
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        /// <summary>
        /// BAddStudent
        /// </summary>
        /// <param name="objBECourseAdmin"></param>
        /// 
        public void BAddStudent(BECourseAdmin objBECourseAdmin)
        {
            try
            {
                new DCourseAdmin().DAddStudent(objBECourseAdmin);
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
        public void BCheckForExamExistence(BECourseAdmin objBECourseAdmin)
        {

            try
            {
                new DCourseAdmin().DCheckForExamExistence(objBECourseAdmin);
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        /// <summary>
        /// Get Selected Exam Details
        /// </summary>
        /// <param name="objBECourseAdmin"></param>
        public void BGetSelectedExamDetails(BECourseAdmin objBECourseAdmin)
        {
            try
            {
                new DCourseAdmin().DGetSelectedExamDetails(objBECourseAdmin);
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
        public void BDeleteExam(BECourseAdmin objBECourseAdmin)
        {
            try
            {
                new DCourseAdmin().DDeleteExam(objBECourseAdmin);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }



        /// <summary>
        /// DGetStudentName
        /// </summary>
        /// <param name="objBECourseAdmin"></param>

        public void BGetStudentName(BECourseAdmin objBECourseAdmin)
        {
            try
            {
                new DCourseAdmin().DGetStudentName(objBECourseAdmin);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        /// <summary>
        /// BGetProviderCourseDetails
        /// </summary>
        /// <param name="objBECourseAdmin"></param>

        public void BGetProviderCourseDetails(BECourseAdmin objBECourseAdmin)
        {
            try
            {
                new DCourseAdmin().DGetProviderCourseDetails(objBECourseAdmin);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        /// <summary>
        /// BProviderEnrollStudent
        /// </summary>
        /// <param name="objBECourseAdmin"></param>

        public void BProviderEnrollStudent(BECourseAdmin objBECourseAdmin)
        {
            try
            {
                new DCourseAdmin().DProviderEnrollStudent(objBECourseAdmin);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BCourseAdminEnrollStudents(BECourseAdmin objBECourseAdmin)
        {
            try
            {
                new DCourseAdmin().DCourseAdminEnrollStudents(objBECourseAdmin);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        /// <summary>
        /// BGetEnrollStudentDetails
        /// </summary>
        /// <param name="objBECourseAdmin"></param>


        public void BGetEnrollStudentDetails(BECourseAdmin objBECourseAdmin)
        {
            try
            {
                new DCourseAdmin().DGetEnrollStudentDetails(objBECourseAdmin);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        /// <summary>
        /// BUpdateEnrollStatus
        /// </summary>
        /// <param name="objBECourseAdmin"></param>
        public void BUpdateEnrollStatus(BECourseAdmin objBECourseAdmin)
        {
            try
            {
                new DCourseAdmin().DUpdateEnrollStatus(objBECourseAdmin);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        /// <summary>
        /// BDeleteEnrollmentStatus
        /// </summary>
        /// <param name="objBECourseAdmin"></param>

        public void BDeleteEnrollmentStatus(BECourseAdmin objBECourseAdmin)
        {
            try
            {
                new DCourseAdmin().DDeleteEnrollmentStatus(objBECourseAdmin);
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
        public void BCheckForUpdateExamExistence(BECourseAdmin objBECourseAdmin)
        {

            try
            {
                new DCourseAdmin().DCheckForUpdateExamExistence(objBECourseAdmin);
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BGetProviderStudentsFiltered(BECourseAdmin objBECourseAdmin)
        {
            try
            {
                new DCourseAdmin().DGetProviderStudentsFiltered(objBECourseAdmin);
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BGetAllStudents(BECourseAdmin objBECourseAdmin)
        {
            try
            {
                new DCourseAdmin().DGetAllStudents(objBECourseAdmin);
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        public void BGetProviderCourses(BECourseAdmin objBECourseAdmin)
        {
            try
            {
                new DCourseAdmin().DGetProviderCourses(objBECourseAdmin);
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        public void BCheckTimeZone(BECourseAdmin objBECourseAdmin)
        {
            try
            {
                new DCourseAdmin().DCheckTimeZone(objBECourseAdmin);
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BGetEditExamDetails(BECourseAdmin objBECourseAdmin)
        {
            try
            {
                new DCourseAdmin().DGetEditExamDetails(objBECourseAdmin);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BBindProviderNames(BECourseAdmin objBECourseAdmin) 
        {
            try
            {
                new DCourseAdmin().DBindProviderNames(objBECourseAdmin);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public void BGetStudentsByCourseId(BECourseAdmin objBECourseAdmin)
        {
            try
            {
                new DCourseAdmin().DGetStudentsByCourseId(objBECourseAdmin);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public void BGetStudentsNotInCourse(BECourseAdmin objBECourseAdmin)
        {
            new DCourseAdmin().DGetStudentsNotInCourse(objBECourseAdmin);
        }
        public void BGetCourseDetailsbyProvider(BECourseAdmin objBECourseAdmin)
        {
            new DCourseAdmin().DGetCourseDetailsbyProvider(objBECourseAdmin);
        }


        public void BGetCourseAdminDetails(BECourseAdmin objBECourseAdmin)
        {
            try
            {
                new DCourseAdmin().DGetCourseAdminDetails(objBECourseAdmin);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

    }
}
