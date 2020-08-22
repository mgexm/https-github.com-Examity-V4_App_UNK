using System;
using BusinessEntities;
using DAL;

namespace BLL
{
    public class BProvider
    {
        #region BGetProviderExams
        public void BGetProviderExams(BEProvider objBEProvider)
        {
            try
            {
                new DProvider().DGetProviderExams(objBEProvider);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        public void BGetStudentsAndCourses(BEProvider objBEExamProvider)
        {
            try
            {
                new DProvider().DGetStudentsAndCourses(objBEExamProvider);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public void BProviderEnrollStudentCourse(BEProvider objBEExamProvider)
        {
            try
            {
                new DProvider().DProviderEnrollStudentCourse(objBEExamProvider);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        } 

        public void BGetStudentsDetails(BEProvider objBEExamProvider)
        {
            try
            {
                new DProvider().DGetStudentsDetails(objBEExamProvider);
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
        public void BGetStudents(BEProvider objBEExamProvider)
        {
            try
            {
                new DProvider().DGetStudents(objBEExamProvider);
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        #region BGetStudentDetails
        public void BGetStudentDetails(BEProvider objBEExamProvider)
        {
            try
            {
                new DProvider().DGetStudentDetails(objBEExamProvider);
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        #region BGetStudentEnrollments
        public void BGetStudentEnrollments(BEProvider objBEExamProvider)
        {
            try
            {
                new DProvider().DGetStudentEnrollments(objBEExamProvider);
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        #region BSaveStudentDetails
        public void BSaveStudentDetails(BEProvider objBEExamProvider)
        {
            try
            {
                new DProvider().DSaveStudentDetails(objBEExamProvider);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        #region BDeleteStudent
        public void BDeleteStudent(BEProvider objBEProvider)
        {
            try
            {
                new DProvider().DDeleteStudent(objBEProvider);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        public void BEnrollStudent(BEProvider objBEExamProvider)
        {
            try
            {
                new DProvider().DEnrollStudent(objBEExamProvider);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BGetExistingExamDetails(BEProvider  objBEExamProvider)
        {
            try
            {
                new DProvider().DGetExistingExamDetails(objBEExamProvider);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BValidateExam(BEProvider objBEExamProvider)
        {

            try
            {
                new DProvider().DValidateExam(objBEExamProvider);
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BSaveExamDetails(BEProvider objBEExamProvider)
        {

            try
            {
                new DProvider().DSaveExamDetails(objBEExamProvider);
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public void BSaveAdminUploads(BEProvider objBEExamProvider)
        {
            try
            {
                new DProvider().DSaveAdminUploads(objBEExamProvider);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BViewExamDetails(BEProvider  objBEExamProvider)
        {

            try
            {
                new DProvider().DViewExamDetails(objBEExamProvider);
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BDeleteExamDetails(BEProvider objBEExamProvider)
        {
            try
            {
                new DProvider().DDeleteExamDetails(objBEExamProvider);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BUpdateExamDetails(BEProvider objBEExamProvider)
        {
            try
            {
                new DProvider().DUpdateExamDetails(objBEExamProvider);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BUpdateStudentDetails(BEProvider objBEExamProvider)
        {

            try
            {
                new DProvider().DUpdateStudentDetails(objBEExamProvider);
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BUpdateStatus(BEProvider objBEExamProvider)
        {
            try
            {
                new DProvider().DUpdateStatus(objBEExamProvider);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BDeleteStatus(BEProvider objBEExamProvider)
        {
            try
            {
                new DProvider().DDeleteStatus(objBEExamProvider);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BSaveCourseDetails(BEProvider objBEExamProvider)
        {
            try
            {
                new DProvider().DSaveCourseDetails(objBEExamProvider);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BGetCourseDetails(BEProvider objBEExamProvider)
        {
            try
            {
                new DProvider().DGetCourseDetails(objBEExamProvider);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BUpdateCourseDetails(BEProvider objBEExamProvider)
        {
            try
            {
                new DProvider().DUpdateCourseDetails(objBEExamProvider);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BAdminValidateExam(BEProvider objBEExamProvider)
        {
            try
            {
                new DProvider().DAdminValidateExam(objBEExamProvider);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BAdminSaveExamDetails(BEProvider objBEExamProvider)
        {
            try
            {
                new DProvider().DAdminSaveExamDetails(objBEExamProvider);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BAdminEnrollStudent(BEProvider objBEExamProvider)
        {
            try
            {
                new DProvider().DAdminEnrollStudent(objBEExamProvider);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BDeleteUploadFiles(BEProvider objBEExamProvider)
        {
            try
            {
                new DProvider().DDeleteUploadFiles(objBEExamProvider);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        /// <summary>
        /// Get Exam Details for Selected Course
        /// </summary>
        /// <param name="objBEExamProvider"></param>
        public void BGetExamDetails(BEProvider objBEExamProvider)
        {
            try
            {
                new DProvider().DGetExamDetails(objBEExamProvider);
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
        public void BGetStudentTransactionsForCurrentProvider(BEProvider objBEExamProvider)
        {
            try
            {
                new DProvider().DGetStudentTransactionsForCurrentProvider(objBEExamProvider);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        /// <summary>
        /// Add Course
        /// </summary>
        /// <param name="objBEExamProvider"></param>
        public void BAddCourse(BEProvider objBEExamProvider)
        {
            try
            {
                new DProvider().DAddCourse(objBEExamProvider);
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
        public void BGetSelectedCourseDetails(BEProvider objBEExamProvider)
        {
            try
            {
                new DProvider().DGetSelectedCourseDetails(objBEExamProvider);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        /// <summary>
        /// BDeleteCourse
        /// </summary>
        /// <param name="objBEProvider"></param>
        /// 
        public void BDeleteCourse(BEProvider objBEExamProvider)
        {
            try
            {
                new DProvider().DDeleteCourse(objBEExamProvider);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        /// <summary>
        /// BGetSelectedSecurityLevel
        /// </summary>
        /// <param name="objBEProvider"></param>

        public void BGetSelectedSecurityLevel(BEProvider objBEExamProvider)
        {

            try
            {
                new DProvider().DGetSelectedSecurityLevel(objBEExamProvider);
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        /// <summary>
        /// ProviderSecurityLevel
        /// </summary>
        /// <param name="objBEProvider"></param>

        public void BBindProviderSecurityLevel(BEProvider objBEExamProvider)
        {

            try
            {
                new DProvider().DBindProviderSecurityLevel(objBEExamProvider);
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        /// <summary>
        /// BAddStudent
        /// </summary>
        /// <param name="objBEProvider"></param>
        /// 
        public void BAddStudent(BEProvider objBEExamProvider)
        {
            try
            {
                new DProvider().DAddStudent(objBEExamProvider);
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
        public void BCheckForExamExistence(BEProvider objBEExamProvider)
        {

            try
            {
                new DProvider().DCheckForExamExistence(objBEExamProvider);
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        /// <summary>
        /// Get Selected Exam Details
        /// </summary>
        /// <param name="objBEExamProvider"></param>
        public void BGetSelectedExamDetails(BEProvider objBEExamProvider)
        {
            try
            {
                new DProvider().DGetSelectedExamDetails(objBEExamProvider);
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
        public void BDeleteExam(BEProvider objBEExamProvider)
        {
            try
            {
                new DProvider().DDeleteExam(objBEExamProvider);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }



        /// <summary>
        /// DGetStudentName
        /// </summary>
        /// <param name="objBEProvider"></param>

        public void BGetStudentName(BEProvider objBEExamProvider)
        {
            try
            {
                new DProvider().DGetStudentName(objBEExamProvider);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        /// <summary>
        /// BGetProviderCourseDetails
        /// </summary>
        /// <param name="objBEProvider"></param>

        public void BGetProviderCourseDetails(BEProvider objBEExamProvider)
        {
            try
            {
                new DProvider().DGetProviderCourseDetails(objBEExamProvider);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        /// <summary>
        /// BProviderEnrollStudent
        /// </summary>
        /// <param name="objBEProvider"></param>

        public void BProviderEnrollStudent(BEProvider objBEExamProvider)
        {
            try
            {
                new DProvider().DProviderEnrollStudent(objBEExamProvider);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        /// <summary>
        /// BGetEnrollStudentDetails
        /// </summary>
        /// <param name="objBEProvider"></param>


        public void BGetEnrollStudentDetails(BEProvider objBEExamProvider)
        {
            try
            {
                new DProvider().DGetEnrollStudentDetails(objBEExamProvider);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        /// <summary>
        /// BUpdateEnrollStatus
        /// </summary>
        /// <param name="objBEProvider"></param>
        public void BUpdateEnrollStatus(BEProvider objBEExamProvider)
        {
            try
            {
                new DProvider().DUpdateEnrollStatus(objBEExamProvider);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        /// <summary>
        /// BDeleteEnrollmentStatus
        /// </summary>
        /// <param name="objBEExamProvider"></param>

        public void BDeleteEnrollmentStatus(BEProvider objBEProvider)
        {
            try
            {
                new DProvider().DDeleteEnrollmentStatus(objBEProvider);
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
        public void BCheckForUpdateExamExistence(BEProvider objBEExamProvider)
        {

            try
            {
                new DProvider().DCheckForUpdateExamExistence(objBEExamProvider);
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BGetProviderStudentsFiltered(BEProvider objBEExamProvider)
        {
            try
            {
                new DProvider().DGetProviderStudentsFiltered(objBEExamProvider);
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BGetAllStudents(BEProvider objBEExamProvider)
        {
            try
            {
                new DProvider().DGetAllStudents(objBEExamProvider);
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        public void BGetProviderCourses(BEProvider objBEExamProvider)
        {
            try
            {
                new DProvider().DGetProviderCourses(objBEExamProvider);
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        public void BCheckTimeZone(BEProvider objBEExamProvider)
        {
            try
            {
                new DProvider().DCheckTimeZone(objBEExamProvider);
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BGetEditExamDetails(BEProvider objBEExamProvider)
        {
            try
            {
                new DProvider().DGetEditExamDetails(objBEExamProvider);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BGetStudentsNotInCourse(BEProvider objBEExamProvider)
        {
            try
            {
                new DProvider().DGetStudentsNotInCourse(objBEExamProvider);
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #region BGetStudentEnrollments
        public void BGetCourseStudents(BEProvider objBEExamProvider)
        {
            try
            {
                new DProvider().DGetCourseStudents(objBEExamProvider);
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion
        public void BGetCourseDetailsbyProvider(BEProvider objBEExamProvider)
        {
            try
            {
                new DProvider().DGetCourseDetailsbyProvider(objBEExamProvider);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public void BUpdatePrimaryIns(BEProvider objBEExamProvider)
        {
            try
            {
                new DProvider().DUpdatePrimaryIns(objBEExamProvider);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public void BCheckPrimaryIns(BEProvider objBEExamProvider)
        {
            try
            {
                new DProvider().DCheckPrimaryIns(objBEExamProvider);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }



        public void BProviderEnrollSelectedStudents(BEProvider objBEExamProvider)
        {
            try
            {
                new DProvider().DProviderEnrollSelectedStudents(objBEExamProvider);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        public void BGetAllCourseDetails(BEProvider objBEExamProvider)
        {
            try
            {
                new DProvider().DGetAllCourseDetails(objBEExamProvider);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        // GetAdditionalRules
        public void BGetAdditionalRules(BEProvider objBEExamProvider)
        {
            try
            {
                new DProvider().DGetAdditionalRules(objBEExamProvider);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BUpdateStatus(int examId, int spId)
        {

            try
            {
                new DProvider().DUpdateStatus(examId, spId);
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }
     
    }
}
