using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using BusinessEntities;

namespace BLL
{
    public class BAdmin
    {

        public void BGetCourseDetails(BEAdmin objBEAdmin)
        {
            try
            {
                new DAdmin().DGetCourseDetails(objBEAdmin);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        //the following is to get all the course details for primary instructor
        public void BGetAllCourseDetails(BEAdmin objBEAdmin)
        {
            try
            {
                new DAdmin().DGetAllCourseDetails(objBEAdmin);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        //20july2015
        //the following is to get the coursed details for the instructor and primary instructor
        public void BGetInstructorCourseDetails(BEAdmin objBEAdmin)
        {
            try
            {
                new DAdmin().DGetInstructorCourseDetails(objBEAdmin);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        //to populate exam summary grid
        public void BGetExamSummaryReportDetails(BEAdmin objBEAdmin)
        {
            try
            {
                new DAdmin().DGetExamSummaryDetails(objBEAdmin);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BViewStudentDetails(BEAdmin objBEAdmin)
        {
            try
            {
                new DAdmin().DViewStudentDetails(objBEAdmin);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BSaveCourseDetails(BEAdmin objBEAdmin)
        {
            try
            {
                new DAdmin().DSaveCourseDetails(objBEAdmin);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BUpdateCourseDetails(BEAdmin objBEAdmin)
        {
            try
            {
                new DAdmin().DUpdateCourseDetails(objBEAdmin);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BGetExistingExamDetails(BEAdmin objBEAdmin)
        {
            try
            {
                new DAdmin().DGetExistingExamDetails(objBEAdmin);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BBindCourse(BEAdmin objBEAdmin)
        {
            try
            {
                new DAdmin().DBindCourse(objBEAdmin);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BGetAdminExamStatus(BEAdmin objBEAdmin)
        {
            try
            {
                new DAdmin().DGetAdminExamStatus(objBEAdmin);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BAdminBindCourse(BEAdmin objBEAdmin)
        {
            try
            {
                new DAdmin().DAdminBindCourse(objBEAdmin);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BGetPassword(BEAdmin objBEAdmin)
        {
            try
            {
                new DAdmin().DGetPassword(objBEAdmin);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BUpdatePassword(BEAdmin objBEAdmin)
        {
            try
            {
                new DAdmin().DUpdatePassword(objBEAdmin);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public void BExecuteCanvasDataLoad(BEAdmin objBEAdmin)
        {
            try
            {
                new DAdmin().DExecuteCanvasDataLoad(objBEAdmin);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        /// <summary>
        /// Get Student
        /// </summary>

        public void BGetStudents(BEAdmin objBEAdmin)
        {
            try
            {
                new DAdmin().DGetStudents(objBEAdmin);
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        /// <summary>
        /// Get Student Enrollments
        /// </summary>

        public void BGetStudentEnrollments(BEAdmin objBEAdmin)
        {
            try
            {
                new DAdmin().DGetStudentEnrollments(objBEAdmin);
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        /// <summary>
        ///BAddStudent
        /// </summary>

        public void BAddStudent(BEAdmin objBEAdmin)
        {
            try
            {
                new DAdmin().DAddStudent(objBEAdmin);
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        /// <summary>
        /// Get Student Details
        /// </summary>

        public void BGetStudentDetails(BEAdmin objBEAdmin)
        {
            try
            {
                new DAdmin().DGetStudentDetails(objBEAdmin);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        /// <summary>
        /// Get Student Transactions
        /// </summary>

        public void BGetStudentTransactionsForAllProviders(BEAdmin objBEAdmin)
        {
            try
            {
                new DAdmin().DGetStudentTransactionsForAllProviders(objBEAdmin);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        /// <summary>
        /// Updating Student Details
        /// </summary>

        public void BUpdateStudentDetails(BEAdmin objBEAdmin)
        {
            try
            {
                new DAdmin().DUpdateStudentDetails(objBEAdmin);
            }

            catch (Exception Ex)
            {
                throw Ex;
            }

        }


        /// <summary>
        /// BDeleteStudent
        /// </summary>

        public void BDeleteStudent(BEAdmin objBEAdmin)
        {
            try
            {
                new DAdmin().DDeleteStudent(objBEAdmin);
            }

            catch (Exception Ex)
            {
                throw Ex;
            }

        }

        /// <summary>
        /// DGetStudentName
        /// </summary>

        public void BGetStudentName(BEAdmin objBEAdmin)
        {
            try
            {
                new DAdmin().DGetStudentName(objBEAdmin);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        /// <summary>
        /// BAdminEnrollStudent
        /// </summary>
        /// <param name="objBEProvider"></param>
        /// 

        public void BAdminEnrollStudent(BEAdmin objBEAdmin)
        {
            try
            {
                new DAdmin().DAdminEnrollStudent(objBEAdmin);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        /// <summary>
        /// BGetEnrollStudentDetails
        /// </summary>      

        public void BAdminUpdateisPrimaryInstructor(BEAdmin objBEAdmin)
        {
            try
            {
                new DAdmin().DAdminUpdateisPrimaryInstructor(objBEAdmin);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        public void BAdminEnrollStudentCourse(BEAdmin objBEAdmin)
        {
            try
            {
                new DAdmin().DAdminEnrollStudentCourse(objBEAdmin);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }



        public void BGetEnrollStudentDetails(BEAdmin objBEAdmin)
        {
            try
            {
                new DAdmin().DGetEnrollStudentDetails(objBEAdmin);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        /// <summary>
        /// BUpdateEnrollStatus
        /// </summary>

        public void BUpdateEnrollStatus(BEAdmin objBEAdmin)
        {
            try
            {
                new DAdmin().DUpdateEnrollStatus(objBEAdmin);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        /// <summary>
        /// Delete Enrollment Status
        /// </summary>

        public void BDeleteEnrollmentStatus(BEAdmin objBEAdmin)
        {
            try
            {
                new DAdmin().DDeleteEnrollmentStatus(objBEAdmin);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        /// <summary>
        /// Get Exam Details for Selected Course
        /// </summary>

        public void BGetExamDetails(BEAdmin objBEAdmin)
        {
            try
            {
                new DAdmin().DGetExamDetails(objBEAdmin);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        /// <summary>
        /// Add Course
        /// </summary>

        public void BAddCourse(BEAdmin objBEAdmin)
        {
            try
            {
                new DAdmin().DAddCourse(objBEAdmin);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        /// <summary>
        /// Get Provider Name
        /// </summary>
        /// 

        public void BGetExamProviders(BEAdmin objBEAdmin)
        {
            try
            {
                new DAdmin().DGetExamProviders(objBEAdmin);
            }
            catch (Exception Ex)
            {

                throw Ex;
            }

        }
        /// <summary>
        /// Get Course Details
        /// </summary>

        public void BGetSelectedCourseDetails(BEAdmin objBEAdmin)
        {
            try
            {
                new DAdmin().DGetSelectedCourseDetails(objBEAdmin);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        /// <summary>
        /// Get Selected Exam Details
        /// </summary>

        public void BGetSelectedExamDetails(BEAdmin objBEAdmin)
        {
            try
            {
                new DAdmin().DGetSelectedExamDetails(objBEAdmin);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        /// <summary>
        /// Delete Exam
        /// </summary>

        public void BDeleteExam(BEAdmin objBEAdmin)
        {
            try
            {
                new DAdmin().DDeleteExam(objBEAdmin);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        /// <summary>
        /// ProviderSecurityLevel
        /// </summary>

        public void BBindProviderSecurityLevel(BEAdmin objBEAdmin)
        {
            try
            {
                new DAdmin().DBindProviderSecurityLevel(objBEAdmin);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }

        }

        /// <summary>
        /// Find the Exam Existence while adding the new exam
        /// </summary>

        public void BCheckForUpdateExamExistence(BEAdmin objBEAdmin)
        {

            try
            {
                new DAdmin().DCheckForUpdateExamExistence(objBEAdmin);
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        /// <summary>
        /// Update ExamDetails
        /// </summary>

        public void BUpdateExamDetails(BEAdmin objBEAdmin)
        {

            try
            {
                new DAdmin().DUpdateExamDetails(objBEAdmin);
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        /// <summary>
        /// BDeleteUploadFiles
        /// </summary>
        /// <param name="objBEProvider"></param>

        public void BDeleteUploadFiles(BEAdmin objBEAdmin)
        {
            try
            {
                new DAdmin().DDeleteUploadFiles(objBEAdmin);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        /// <summary>
        /// Get Selected Security Level
        /// </summary>
        public void BGetSelectedSecurityLevel(BEAdmin objBEAdmin)
        {
            try
            {
                new DAdmin().DGetSelectedSecurityLevel(objBEAdmin);
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
        public void BCheckForExamExistence(BEAdmin objBEAdmin)
        {

            try
            {
                new DAdmin().DCheckForExamExistence(objBEAdmin);
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        /// <summary>
        /// Save ExamDetails
        /// </summary>

        public void BSaveExamDetails(BEAdmin objBEAdmin)
        {

            try
            {
                new DAdmin().DSaveExamDetails(objBEAdmin);
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BGetInstructors(BEAdmin objBEAdmin)
        {
            try
            {
                new DAdmin().DGetInstructors(objBEAdmin);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BAddInstructor(BEAdmin objBEAdmin)
        {
            try
            {
                new DAdmin().DAddInstructor(objBEAdmin);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BGetPaymentMode(BEAdmin objBEAdmin)
        {
            try
            {
                new DAdmin().DGetPaymentMode(objBEAdmin);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BGetClientContactDetails(BEAdmin objBEAdmin)
        {
            try
            {
                new DAdmin().DGetClientContactDetails(objBEAdmin);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public void BGetCourseDetails_CourseStudents(BEAdmin objBEAdmin)
        {
            try
            {
                new DAdmin().DGetCourseDetails_CourseStudents(objBEAdmin);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public void BGetCourseDetailsbyProvider(BEAdmin objBEAdmin)
        {
            try
            {
                new DAdmin().DGetCourseDetailsbyProvider(objBEAdmin);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public void BGetCourseStudents(BEAdmin objBEAdmin)
        {
            try
            {
                new DAdmin().DGetCourseStudents(objBEAdmin);
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public void BGetStudentsNotInCourse(BEAdmin objBEAdmin)
        {
            try
            {
                new DAdmin().DGetStudentsNotInCourse(objBEAdmin);
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BGetStudentsDetails(BEAdmin objBEAdmin)
        {
            try
            {
                new DAdmin().DGetStudentsDetails(objBEAdmin);
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        public void BGetCoursePrimaryInstructors(BEAdmin objBEAdmin)
        {
            try
            {
                new DAdmin().DGetCoursePrimaryInstructors(objBEAdmin);
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BGetCourseExamDetails(BEAdmin objBEAdmin)
        {
            try
            {
                new DAdmin().DGetCourseExamDetails(objBEAdmin);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        //16july2015
        //the following function is used to populate details when clicked on scheduled appointments and unscheduled appointments in admin reports
        public void BGetAdminAppointmentDetails(BEAdmin objBEAdmin)
        {
            try
            {
                new DAdmin().DGetAdminAppointmentDetails(objBEAdmin);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        public void BGetTestResultReportDetails(BEAdmin objBEAdmin)
        {
            try
            {
                new DAdmin().DGetTestResultReportDetails(objBEAdmin);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        public void BGetAllExamDetails(BEAdmin objBEAdmin)
        {
            try
            {
                new DAdmin().DGetAllExamDetails(objBEAdmin);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }



        public void BGetAppointmentScheduleReportDetails(BEAdmin objBEAdmin)
        {
            try
            {
                new DAdmin().DGetAppointmentScheduleReportDetails(objBEAdmin);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        public void BGetExamDetailsBySplIns(BEAdmin objBEAdmin)
        {
            try
            {
                new DAdmin().DGetExamDetailsBySplIns(objBEAdmin);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BGetCoursesBySplIns(BEAdmin objBEAdmin)
        {
            try
            {
                new DAdmin().DGetCoursesBySplIns(objBEAdmin);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        //10feb2017
        public void BGetExamDetailsByCourseAndSplIns(BEAdmin objBEAdmin)
        {
            try
            {
                new DAdmin().DGetExamDetailsByCourseAndSplIns(objBEAdmin);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BGetCourseAdminCoursesBySplIns(BEAdmin objBEAdmin)
        {
            try
            {
                new DAdmin().DGetCourseAdminCoursesBySplIns(objBEAdmin);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void BProviderGetCoursesBySplIns(BEAdmin objBEAdmin)
        {
            try
            {
                new DAdmin().DGetProviderCoursesBySplIns(objBEAdmin);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

       

    }
}
