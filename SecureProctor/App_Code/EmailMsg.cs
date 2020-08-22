using System;
using System.Text;
using System.Net;
using System.Net.Mail;
using BusinessEntities;
using BLL;
using System.Data;

namespace SecureProctor
{
    public class EmailMsg
    {
        StringBuilder stbEmail;

        //#region Common
        ///// <summary>
        ///// Forgot Password
        ///// </summary>
        ///// <param name="strStudent"></param>
        //public void ForgotPassword(string strUserID, string Password)
        //{
        //    stbEmail = new StringBuilder();
        //    stbEmail.Append("<table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" >");
        //    stbEmail.Append("<tr><td><img src=\"http://demo.secureproctor.com/images/logo.png\" />");
        //    stbEmail.Append("<tr><td>&nbsp;</td></tr>");
        //    stbEmail.Append("<tr><td>Dear @STUDENTNAME,</td></tr>");
        //    stbEmail.Append("<tr><td>&nbsp;</td></tr>");
        //    stbEmail.Append("<tr><td>&nbsp;</td></tr>");
        //    stbEmail.Append("<tr><td>You have requested a password reset for Secure Proctor account " + strUserID + "</td></tr>");
        //    stbEmail.Append("<tr><td>&nbsp;</td></tr>");
        //    stbEmail.Append("<tr><td>New Password: " + Password + "</td></tr>");
        //    stbEmail.Append("<tr><td>&nbsp;</td></tr>");
        //    stbEmail.Append("<tr><td>&nbsp;</td></tr>");
        //    stbEmail.Append("<tr><td>&nbsp;</td></tr>");
        //    stbEmail.Append("<tr><td>&nbsp;</td></tr>");
        //    stbEmail.Append("<tr><td>Thanks,</td></tr>");
        //    stbEmail.Append("<tr><td>Secure Proctor Team.</td></tr>");
        //    stbEmail.Append("<tr><td>Secure Proctor LLC. ALL RIGHTS RESERVED.</td></tr>");
        //    stbEmail.Append("<tr><td>Contact Us: info@secureproctor.com</td></tr>");
        //    stbEmail.Append("<tr><td>***<b>DO NOT REPLY TO THIS EMAIL</b>***</td></tr>");
        //    stbEmail.Append("<tr><td></td></tr></table>");

        //    BEStudent objBEStudent = new BEStudent();
        //    BStudent objBStudent = new BStudent();
        //    objBEStudent.IntUserID = strUserID;
        //    objBStudent.BGetUserName(objBEStudent);

        //    stbEmail.Replace("@STUDENTNAME", objBEStudent.DtResult.Rows[0]["FirstName"].ToString() + " " + objBEStudent.DtResult.Rows[0]["LastName"].ToString());
        //    //this.SendMail(stbEmail.ToString(), "BAT: Forgot Password");
        //    this.SendMail(stbEmail.ToString(), "Secure Proctor: Secure Proctor Account Password Request");
        //}
        ///// <summary>
        ///// Change Password
        ///// </summary>
        ///// <param name="strStudent"></param>
        //public void ChangePassword(string strUserID, string strUserName, string Password)
        //{
        //    stbEmail = new StringBuilder();
        //    stbEmail.Append("<table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" >");
        //    stbEmail.Append("<tr><td><img src=\"http://demo.secureproctor.com/images/logo.png\" />");
        //    stbEmail.Append("<tr><td>&nbsp;</td></tr>");
        //    stbEmail.Append("<tr><td>Dear @STUDENTNAME,</td></tr>");
        //    stbEmail.Append("<tr><td>&nbsp;</td></tr>");
        //    stbEmail.Append("<tr><td>Our records indicate that you recently reset your password for Secure Vault.</td></tr>");
        //    stbEmail.Append("<tr><td>&nbsp;</td></tr>");
        //    stbEmail.Append("<tr><td>This password allows you to log into Secure Proctor.</td></tr>");
        //    stbEmail.Append("<tr><td>&nbsp;</td></tr>");
        //    stbEmail.Append("<tr><td>If you did not make this request, please contact us at info@secureproctor.com immediately.</td></tr>");
        //    stbEmail.Append("<tr><td>&nbsp;</td></tr>");
        //    stbEmail.Append("<tr><td>&nbsp;</td></tr>");
        //    stbEmail.Append("<tr><td>Thanks,</td></tr>");
        //    stbEmail.Append("<tr><td>Secure Proctor Team.</td></tr>");
        //    stbEmail.Append("<tr><td>Secure Proctor LLC. ALL RIGHTS RESERVED.</td></tr>");
        //    stbEmail.Append("<tr><td>Contact Us: info@secureproctor.com</td></tr>");
        //    stbEmail.Append("<tr><td>***<b>DO NOT REPLY TO THIS EMAIL</b>***</td></tr>");
        //    stbEmail.Append("<tr><td></td></tr></table>");
        //    BEStudent objBEStudent = new BEStudent();
        //    BStudent objBStudent = new BStudent();
        //    objBEStudent.IntUserID = Convert.ToInt32(strUserID);
        //    objBStudent.BGetStudentDetails(objBEStudent);

        //    stbEmail.Replace("@STUDENTNAME", objBEStudent.dtResult.Rows[0]["FirstName"].ToString() + " " + objBEStudent.dtResult.Rows[0]["LastName"].ToString());

        //    this.SendMail(stbEmail.ToString(), "Secure Proctor: Account Change Password");
        //}
        //#endregion
        #region Student
        /// <summary>
        /// Schedule Exam Mail
        /// </summary>
        /// <param name="TransID"></param>
        public void StudentExamReceipt(Int64 TransID)
        {
            stbEmail = new StringBuilder();
            stbEmail.Append("<table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" >");
            stbEmail.Append("<tr><td><img src=\"http://demo.secureproctor.com/images/logo.png\" />");
            stbEmail.Append("<tr><td>&nbsp;</td></tr>");
            stbEmail.Append("<tr><td>Dear @STUDENTNAME,</td></tr>");
            stbEmail.Append("<tr><td>&nbsp;</td></tr>");
            stbEmail.Append("<tr><td>Congratulations! You have successfully registered for the @EXAMNAME.</td></tr>");
            stbEmail.Append("<tr><td>&nbsp;</td></tr>");
            stbEmail.Append("<tr><td>Your Exam Information</td></tr>");
            stbEmail.Append("<tr><td>&nbsp;</td></tr>");
            stbEmail.Append("<tr><td>ID : @EXAMID</td></tr>");
            stbEmail.Append("<tr><td>Course Name : @COURSENAME</td></tr>");
            stbEmail.Append("<tr><td>Exam Name : @EXAMNAME</td></tr>");
            stbEmail.Append("<tr><td>Date : @DATE</td></tr>");
            stbEmail.Append("<tr><td>Time : @TIME [CST]</td></tr>");
            stbEmail.Append("<tr><td>&nbsp;</td></tr>");
            stbEmail.Append("<tr><td>On the day of your exam please remember to:</td></tr>");
            stbEmail.Append("<tr><td>&nbsp;</td></tr>");
            stbEmail.Append("<tr><td>1. Login into the Examity site 30 minutes prior to the start of the session.</td></tr>");
            stbEmail.Append("<tr><td>2. You might have to install some Examity tools.</td></tr>");
            stbEmail.Append("<tr><td>3.	Bring a valid photo ID (e.g. student ID card, driver's license or passport). This is the same photo ID that was used while setting up the account.</td></tr>");
            stbEmail.Append("<tr><td>4.	Have your username and password available (you will need this to log into the Exam).</td></tr>");
            stbEmail.Append("<tr><td>&nbsp;</td></tr>");
            stbEmail.Append("<tr><td>Scrap paper will be provided to you, including access to a Windows or Mac calculator. To ensure a fair and equal testing experience, personal calculators are not allowed. We encourage you to familiarize yourself with the scientific view of the computer's built-in calculator. Mobile phone, desktop applications (e.g. Excel), and the Internet are also strictly prohibited during the test.</td></tr>");
            stbEmail.Append("<tr><td>&nbsp;</td></tr>");
            stbEmail.Append("<tr><td>We look forward to seeing you soon!</td></tr>");
            stbEmail.Append("<tr><td>&nbsp;</td></tr>");
            stbEmail.Append("<tr><td>Good Luck!</td></tr>");
            stbEmail.Append("<tr><td>&nbsp;</td></tr>");
            stbEmail.Append("<tr><td>Thanks,</td></tr>");
            stbEmail.Append("<tr><td>Examity Team.</td></tr>");
            stbEmail.Append("<tr><td>Examity LLC. ALL RIGHTS RESERVED.</td></tr>");
            stbEmail.Append("<tr><td>Contact Us: support@exnjit.zendesk.com</td></tr>");
            stbEmail.Append("<tr><td>***<b>DO NOT REPLY TO THIS EMAIL</b>***</td></tr>");
            stbEmail.Append("<tr><td></td></tr></table>");

            BEStudent objBEStudent = new BEStudent();
            BStudent objBStudent = new BStudent();
            objBEStudent.IntTransID = TransID;
            objBStudent.BGetStudentExamDetails(objBEStudent);

            stbEmail.Replace("@EXAMID", TransID.ToString());
            stbEmail.Replace("@STUDENTNAME", objBEStudent.DtResult.Rows[0]["Name"].ToString());
            stbEmail.Replace("@COURSENAME", objBEStudent.DtResult.Rows[0]["CourseName"].ToString());
            stbEmail.Replace("@EXAMNAME", objBEStudent.DtResult.Rows[0]["ExamName"].ToString());
            stbEmail.Replace("@DATE", objBEStudent.DtResult.Rows[0]["ExamDate"].ToString());
            stbEmail.Replace("@TIME", objBEStudent.DtResult.Rows[0]["TimeDuration"].ToString());
            stbEmail.Replace("@URL", "http://test.secureproctor.com/njit/login.aspx");

            this.SendMail(stbEmail.ToString(), "Examity: " + objBEStudent.DtResult.Rows[0]["ExamName"].ToString() + " Exam Scheduled Confirmation [" + TransID.ToString() + "]");

            this.StudentScheduleMailtoProctor(TransID);
        }
        /// <summary>
        /// ReSchedule Exam Mail
        /// </summary>
        /// <param name="TransID"></param>
        public void StudentExamRescheduleReceipt(Int64 TransID)
        {
            stbEmail = new StringBuilder();
            stbEmail.Append("<table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" >");
            stbEmail.Append("<tr><td><img src=\"http://demo.secureproctor.com/images/logo.png\" />");
            stbEmail.Append("<tr><td>&nbsp;</td></tr>");
            stbEmail.Append("<tr><td>Dear @STUDENTNAME,</td></tr>");
            stbEmail.Append("<tr><td>&nbsp;</td></tr>");
            stbEmail.Append("<tr><td>Congratulations! Your Exam is Re-Scheduled successfully.</td></tr>");
            stbEmail.Append("<tr><td>&nbsp;</td></tr>");
            stbEmail.Append("<tr><td>Your Exam Information</td></tr>");
            stbEmail.Append("<tr><td>&nbsp;</td></tr>");
            stbEmail.Append("<tr><td>ID : @EXAMID</td></tr>");
            stbEmail.Append("<tr><td>Course Name : @COURSENAME</td></tr>");
            stbEmail.Append("<tr><td>Exam Name : @EXAMNAME</td></tr>");
            stbEmail.Append("<tr><td>Date : @DATE</td></tr>");
            stbEmail.Append("<tr><td>Time : @TIME [CST]</td></tr>");
            stbEmail.Append("<tr><td>&nbsp;</td></tr>");
            stbEmail.Append("<tr><td>On the day of your exam please remember to:</td></tr>");
            stbEmail.Append("<tr><td>&nbsp;</td></tr>");
            stbEmail.Append("<tr><td>1. Login into the Examity site 30 minutes prior to the start of the session.</td></tr>");
            stbEmail.Append("<tr><td>2. You might have to install some Examity tools.</td></tr>");
            stbEmail.Append("<tr><td>3.	Bring a valid photo ID (e.g. student ID card, driver's license or passport). This is the same photo ID that was used while setting up the account.</td></tr>");
            stbEmail.Append("<tr><td>4.	Have your username and password available (you will need this to log into the Exam).</td></tr>");
            stbEmail.Append("<tr><td>&nbsp;</td></tr>");
            stbEmail.Append("<tr><td>Scrap paper will be provided to you, including access to a Windows or Mac calculator. To ensure a fair and equal testing experience, personal calculators are not allowed. We encourage you to familiarize yourself with the scientific view of the computer's built-in calculator. Mobile phone, desktop applications (e.g. Excel), and the Internet are also strictly prohibited during the test.</td></tr>");
            stbEmail.Append("<tr><td>&nbsp;</td></tr>");
            stbEmail.Append("<tr><td>We look forward to seeing you soon!</td></tr>");
            stbEmail.Append("<tr><td>&nbsp;</td></tr>");
            stbEmail.Append("<tr><td>Good Luck!</td></tr>");
            stbEmail.Append("<tr><td>&nbsp;</td></tr>");
            stbEmail.Append("<tr><td>Thanks,</td></tr>");
            stbEmail.Append("<tr><td>Examity Team.</td></tr>");
            stbEmail.Append("<tr><td>Examity LLC. ALL RIGHTS RESERVED.</td></tr>");
            stbEmail.Append("<tr><td>Contact Us: support@exnjit.zendesk.com</td></tr>");
            stbEmail.Append("<tr><td>***<b>DO NOT REPLY TO THIS EMAIL</b>***</td></tr>");
            stbEmail.Append("<tr><td></td></tr></table>");

            BEStudent objBEStudent = new BEStudent();
            BStudent objBStudent = new BStudent();
            objBEStudent.IntTransID = TransID;
            objBStudent.BGetStudentExamDetails(objBEStudent);

            stbEmail.Replace("@EXAMID", TransID.ToString());
            stbEmail.Replace("@STUDENTNAME", objBEStudent.DtResult.Rows[0]["Name"].ToString());
            stbEmail.Replace("@COURSENAME", objBEStudent.DtResult.Rows[0]["CourseName"].ToString());
            stbEmail.Replace("@EXAMNAME", objBEStudent.DtResult.Rows[0]["ExamName"].ToString());
            stbEmail.Replace("@DATE", objBEStudent.DtResult.Rows[0]["ExamDate"].ToString());
            stbEmail.Replace("@TIME", objBEStudent.DtResult.Rows[0]["TimeDuration"].ToString());
            stbEmail.Replace("@URL", "http://test.secureproctor.com/njit/login.aspx");

            this.SendMail(stbEmail.ToString(), "Examity: " + objBEStudent.DtResult.Rows[0]["ExamName"].ToString() + " Exam Re-Scheduled Confirmation [" + TransID + "]");

            this.StudentReScheduleMailtoProctor(TransID);
        }
        /// <summary>
        /// Cancel Exam Mail
        /// </summary>
        /// <param name="TransID"></param>
        public void StudentExamCancelReceipt(Int64 TransID)
        {
            stbEmail = new StringBuilder();
            stbEmail.Append("<table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" >");
            stbEmail.Append("<tr><td><img src=\"http://demo.secureproctor.com/images/logo.png\" />");
            stbEmail.Append("<tr><td>&nbsp;</td></tr>");
            stbEmail.Append("<tr><td>Dear @STUDENTNAME,</td></tr>");
            stbEmail.Append("<tr><td>&nbsp;</td></tr>");
            stbEmail.Append("<tr><td>Your Exam is Cancelled successfully.</td></tr>");
            stbEmail.Append("<tr><td>&nbsp;</td></tr>");
            stbEmail.Append("<tr><td>Your Exam Information</td></tr>");
            stbEmail.Append("<tr><td>&nbsp;</td></tr>");
            stbEmail.Append("<tr><td>ID : @EXAMID</td></tr>");
            stbEmail.Append("<tr><td>Course Name : @COURSENAME</td></tr>");
            stbEmail.Append("<tr><td>Exam Name : @EXAMNAME</td></tr>");
            stbEmail.Append("<tr><td>Date : @DATE</td></tr>");
            stbEmail.Append("<tr><td>Time : @TIME [CST]</td></tr>");
            stbEmail.Append("<tr><td>&nbsp;</td></tr>");
            stbEmail.Append("<tr><td>Thanks,</td></tr>");
            stbEmail.Append("<tr><td>Examity Team.</td></tr>");
            stbEmail.Append("<tr><td>Examity LLC. ALL RIGHTS RESERVED.</td></tr>");
            stbEmail.Append("<tr><td>Contact Us: support@exnjit.zendesk.com</td></tr>");
            stbEmail.Append("<tr><td>***<b>DO NOT REPLY TO THIS EMAIL</b>***</td></tr>");
            stbEmail.Append("<tr><td></td></tr></table>");

            BEStudent objBEStudent = new BEStudent();
            BStudent objBStudent = new BStudent();
            objBEStudent.IntTransID = TransID;
            objBStudent.BGetStudentExamDetails(objBEStudent);

            stbEmail.Replace("@EXAMID", TransID.ToString());
            stbEmail.Replace("@STUDENTNAME", objBEStudent.DtResult.Rows[0]["Name"].ToString());
            stbEmail.Replace("@COURSENAME", objBEStudent.DtResult.Rows[0]["CourseName"].ToString());
            stbEmail.Replace("@EXAMNAME", objBEStudent.DtResult.Rows[0]["ExamName"].ToString());
            stbEmail.Replace("@DATE", objBEStudent.DtResult.Rows[0]["ExamDate"].ToString());
            stbEmail.Replace("@TIME", objBEStudent.DtResult.Rows[0]["TimeDuration"].ToString());

            this.SendMail(stbEmail.ToString(), "Examity: " + objBEStudent.DtResult.Rows[0]["ExamName"].ToString() + " Exam Cancel Confirmation [" + TransID + "]");
        }
        /// <summary>
        /// Student Registration Confirmation Mail
        /// </summary>
        /// <param name="strStudent"></param>
        public void StudentRegConfirmation(string strStudent)
        {
            stbEmail = new StringBuilder();
            stbEmail.Append("<table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" >");
            stbEmail.Append("<tr><td><img src=\"http://demo.secureproctor.com/images/logo.png\" />");
            stbEmail.Append("<tr><td>&nbsp;</td></tr>");
            stbEmail.Append("<tr><td>Dear @STUDENTNAME,</td></tr>");
            stbEmail.Append("<tr><td>&nbsp;</td></tr>");
            stbEmail.Append("<tr><td>Congratulations! You have successfully completed registration process in Examity.</td></tr>");
            stbEmail.Append("<tr><td>&nbsp;</td></tr>");
            stbEmail.Append("<tr><td>We look forward to seeing you soon!</td></tr>");
            stbEmail.Append("<tr><td>&nbsp;</td></tr>");
            stbEmail.Append("<tr><td>Good Luck!</td></tr>");
            stbEmail.Append("<tr><td>&nbsp;</td></tr>");
            stbEmail.Append("<tr><td>&nbsp;</td></tr>");
            stbEmail.Append("<tr><td>Thanks,</td></tr>");
            stbEmail.Append("<tr><td>Examity Team.</td></tr>");
            stbEmail.Append("<tr><td>Examity LLC. ALL RIGHTS RESERVED.</td></tr>");
            stbEmail.Append("<tr><td>Contact Us: support@exnjit.zendesk.com</td></tr>");
            stbEmail.Append("<tr><td>***<b>DO NOT REPLY TO THIS EMAIL</b>***</td></tr>");
            stbEmail.Append("<tr><td></td></tr></table>");

            stbEmail.Replace("@STUDENTNAME", strStudent);
            this.SendMail(stbEmail.ToString(), "Examity: Student Registration - Confirmation");
        }
        /// <summary>
        /// ExamCompleted
        /// </summary>
        /// <param name="TransID"></param>
        public void ExamCompleted(Int64 TransID)
        {
            stbEmail = new StringBuilder();
            stbEmail.Append("<table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" >");
            stbEmail.Append("<tr><td><img src=\"http://demo.secureproctor.com/images/logo.png\" />");
            stbEmail.Append("<tr><td>&nbsp;</td></tr>");
            stbEmail.Append("<tr><td>Dear @STUDENTNAME,</td></tr>");
            stbEmail.Append("<tr><td>&nbsp;</td></tr>");
            stbEmail.Append("<tr><td>Congratulations! You have successfully completed the Exam.</td></tr>");
            stbEmail.Append("<tr><td>&nbsp;</td></tr>");
            stbEmail.Append("<tr><td>Your Exam Information</td></tr>");
            stbEmail.Append("<tr><td>&nbsp;</td></tr>");
            stbEmail.Append("<tr><td>ID : @EXAMID</td></tr>");
            stbEmail.Append("<tr><td>Course Name : @COURSENAME</td></tr>");
            stbEmail.Append("<tr><td>Exam Name : @EXAMNAME</td></tr>");
            stbEmail.Append("<tr><td>Date : @DATE</td></tr>");
            stbEmail.Append("<tr><td>Time : @TIME (local time)</td></tr>");
            stbEmail.Append("<tr><td>&nbsp;</td></tr>");
            stbEmail.Append("<tr><td>&nbsp;</td></tr>");
            stbEmail.Append("<tr><td>Thanks,</td></tr>");
            stbEmail.Append("<tr><td>Examity Team.</td></tr>");
            stbEmail.Append("<tr><td>Examity LLC. ALL RIGHTS RESERVED.</td></tr>");
            stbEmail.Append("<tr><td>Contact Us: support@exnjit.zendesk.com</td></tr>");
            stbEmail.Append("<tr><td>***<b>DO NOT REPLY TO THIS EMAIL</b>***</td></tr>");
            stbEmail.Append("<tr><td></td></tr></table>");

            BEStudent objBEStudent = new BEStudent();
            BStudent objBStudent = new BStudent();
            objBEStudent.IntTransID = TransID;
            objBStudent.BGetStudentExamDetails(objBEStudent);

            stbEmail.Replace("@EXAMID", TransID.ToString());
            stbEmail.Replace("@STUDENTNAME", objBEStudent.DtResult.Rows[0]["Name"].ToString());
            stbEmail.Replace("@COURSENAME", objBEStudent.DtResult.Rows[0]["CourseName"].ToString());
            stbEmail.Replace("@EXAMNAME", objBEStudent.DtResult.Rows[0]["ExamName"].ToString());
            stbEmail.Replace("@DATE", objBEStudent.DtResult.Rows[0]["ExamDate"].ToString());
            stbEmail.Replace("@TIME", objBEStudent.DtResult.Rows[0]["TimeDuration"].ToString());
            stbEmail.Replace("@URL", "http://ProctorVaultV3.strateology.net/login.aspx");

            this.SendMail(stbEmail.ToString(), "Examity: Exam Completed - Confirmation");
        }
        #endregion
        #region Proctor
        protected void StudentScheduleMailtoProctor(Int64 TransID)
        {
            stbEmail = new StringBuilder();
            stbEmail.Append("<table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" >");
            stbEmail.Append("<tr><td><img src=\"http://demo.secureproctor.com/images/logo.png\" />");
            stbEmail.Append("<tr><td>&nbsp;</td></tr>");
            stbEmail.Append("<tr><td>Student Exam Scheduled information.</td></tr>");
            stbEmail.Append("<tr><td>&nbsp;</td></tr>");
            stbEmail.Append("<tr><td>&nbsp;</td></tr>");
            stbEmail.Append("<tr><td>Student Name : @STUDENTNAME</td></tr>");
            stbEmail.Append("<tr><td>ID : @EXAMID</td></tr>");
            stbEmail.Append("<tr><td>Course Name : @COURSENAME</td></tr>");
            stbEmail.Append("<tr><td>Exam Name : @EXAMNAME</td></tr>");
            stbEmail.Append("<tr><td>Date : @DATE</td></tr>");
            stbEmail.Append("<tr><td>Time : @TIME [CST]</td></tr>");
            stbEmail.Append("<tr><td>&nbsp;</td></tr>");
            stbEmail.Append("<tr><td>Thanks,</td></tr>");
            stbEmail.Append("<tr><td>Examity Team.</td></tr>");
            stbEmail.Append("<tr><td>Examity LLC. ALL RIGHTS RESERVED.</td></tr>");
            stbEmail.Append("<tr><td>Contact Us: support@exnjit.zendesk.com</td></tr>");
            stbEmail.Append("<tr><td>***<b>DO NOT REPLY TO THIS EMAIL</b>***</td></tr>");
            stbEmail.Append("<tr><td></td></tr></table>");

            BEStudent objBEStudent = new BEStudent();
            BStudent objBStudent = new BStudent();
            objBEStudent.IntTransID = TransID;
            objBStudent.BGetStudentExamDetails(objBEStudent);

            stbEmail.Replace("@EXAMID", TransID.ToString());
            stbEmail.Replace("@STUDENTNAME", objBEStudent.DtResult.Rows[0]["Name"].ToString());
            stbEmail.Replace("@COURSENAME", objBEStudent.DtResult.Rows[0]["CourseName"].ToString());
            stbEmail.Replace("@EXAMNAME", objBEStudent.DtResult.Rows[0]["ExamName"].ToString());
            stbEmail.Replace("@DATE", objBEStudent.DtResult.Rows[0]["ExamDate"].ToString());
            stbEmail.Replace("@TIME", objBEStudent.DtResult.Rows[0]["TimeDuration"].ToString());
            stbEmail.Replace("@URL", "http://test.secureproctor.com/njit/login.aspx");

            this.SendMail(stbEmail.ToString(), "Examity: FYI " + objBEStudent.DtResult.Rows[0]["ExamName"].ToString() + " Exam Scheduled Details [" + TransID.ToString() + "]");
        }
        protected void StudentReScheduleMailtoProctor(Int64 TransID)
        {
            stbEmail = new StringBuilder();
            stbEmail.Append("<table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" >");
            stbEmail.Append("<tr><td><img src=\"http://demo.secureproctor.com/images/logo.png\" />");
            stbEmail.Append("<tr><td>&nbsp;</td></tr>");
            stbEmail.Append("<tr><td>Student Exam ReScheduled information.</td></tr>");
            stbEmail.Append("<tr><td>&nbsp;</td></tr>");
            stbEmail.Append("<tr><td>&nbsp;</td></tr>");
            stbEmail.Append("<tr><td>Student Name : @STUDENTNAME</td></tr>");
            stbEmail.Append("<tr><td>ID : @EXAMID</td></tr>");
            stbEmail.Append("<tr><td>Course Name : @COURSENAME</td></tr>");
            stbEmail.Append("<tr><td>Exam Name : @EXAMNAME</td></tr>");
            stbEmail.Append("<tr><td>Date : @DATE</td></tr>");
            stbEmail.Append("<tr><td>Time : @TIME [CST]</td></tr>");
            stbEmail.Append("<tr><td>&nbsp;</td></tr>");
            stbEmail.Append("<tr><td>Thanks,</td></tr>");
            stbEmail.Append("<tr><td>Examity Team.</td></tr>");
            stbEmail.Append("<tr><td>Examity LLC. ALL RIGHTS RESERVED.</td></tr>");
            stbEmail.Append("<tr><td>Contact Us: support@exnjit.zendesk.com</td></tr>");
            stbEmail.Append("<tr><td>***<b>DO NOT REPLY TO THIS EMAIL</b>***</td></tr>");
            stbEmail.Append("<tr><td></td></tr></table>");

            BEStudent objBEStudent = new BEStudent();
            BStudent objBStudent = new BStudent();
            objBEStudent.IntTransID = TransID;
            objBStudent.BGetStudentExamDetails(objBEStudent);

            stbEmail.Replace("@EXAMID", TransID.ToString());
            stbEmail.Replace("@STUDENTNAME", objBEStudent.DtResult.Rows[0]["Name"].ToString());
            stbEmail.Replace("@COURSENAME", objBEStudent.DtResult.Rows[0]["CourseName"].ToString());
            stbEmail.Replace("@EXAMNAME", objBEStudent.DtResult.Rows[0]["ExamName"].ToString());
            stbEmail.Replace("@DATE", objBEStudent.DtResult.Rows[0]["ExamDate"].ToString());
            stbEmail.Replace("@TIME", objBEStudent.DtResult.Rows[0]["TimeDuration"].ToString());
            stbEmail.Replace("@URL", "http://test.secureproctor.com/njit/login.aspx");

            this.SendMail(stbEmail.ToString(), "Examity: FYI " + objBEStudent.DtResult.Rows[0]["ExamName"].ToString() + " Exam ReScheduled Details [" + TransID.ToString() + "]");
        }
        #endregion
        #region Auditor
        /// <summary>
        /// Exam Approved - Student : Approved By Proctor
        /// </summary>
        /// <param name="TransID"></param>
        public void ExamApprovedStudent(Int64 TransID, string strStatus)
        {
            stbEmail = new StringBuilder();
            stbEmail.Append("<table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" >");
            stbEmail.Append("<tr><td><img src=\"http://demo.secureproctor.com/images/logo.png\" />");
            stbEmail.Append("<tr><td>&nbsp;</td></tr>");
            stbEmail.Append("<tr><td>Dear @STUDENTNAME,</td></tr>");
            stbEmail.Append("<tr><td>&nbsp;</td></tr>");
            if (strStatus == "Approved")
            {
                stbEmail.Append("<tr><td>Congratulations! Your @EXAMNAME is successfully Approved by Auditor.</td></tr>");
            }
            else if (strStatus == "Rejected")
            {
                stbEmail.Append("<tr><td>Unfortunately, the @EXAMNAME exam is Rejected by Auditor.</td></tr>");
            }
            stbEmail.Append("<tr><td>&nbsp;</td></tr>");
            stbEmail.Append("<tr><td>Your Exam Information</td></tr>");
            stbEmail.Append("<tr><td>&nbsp;</td></tr>");
            stbEmail.Append("<tr><td>ID : @EXAMID</td></tr>");
            stbEmail.Append("<tr><td>Course Name : @COURSENAME</td></tr>");
            stbEmail.Append("<tr><td>Exam Name : @EXAMNAME</td></tr>");
            stbEmail.Append("<tr><td>Date : @DATE</td></tr>");
            stbEmail.Append("<tr><td>Time : @TIME (local time)</td></tr>");
            stbEmail.Append("<tr><td>&nbsp;</td></tr>");
            stbEmail.Append("<tr><td>&nbsp;</td></tr>");
            stbEmail.Append("<tr><td>&nbsp;</td></tr>");

            stbEmail.Append("<tr><td>&nbsp;</td></tr>");
            stbEmail.Append("<tr><td>Thanks,</td></tr>");
            stbEmail.Append("<tr><td>Examity Team.</td></tr>");
            stbEmail.Append("<tr><td>Examity LLC. ALL RIGHTS RESERVED.</td></tr>");
            stbEmail.Append("<tr><td>Contact Us: support@exnjit.zendesk.com</td></tr>");
            stbEmail.Append("<tr><td>***<b>DO NOT REPLY TO THIS EMAIL</b>***</td></tr>");
            stbEmail.Append("<tr><td></td></tr></table>");
            BEStudent objBEStudent = new BEStudent();
            BStudent objBStudent = new BStudent();
            objBEStudent.IntTransID = TransID;
            objBStudent.BGetStudentExamDetails(objBEStudent);

            stbEmail.Replace("@EXAMID", TransID.ToString());
            stbEmail.Replace("@STUDENTNAME", objBEStudent.DtResult.Rows[0]["Name"].ToString());
            stbEmail.Replace("@COURSENAME", objBEStudent.DtResult.Rows[0]["CourseName"].ToString());
            stbEmail.Replace("@EXAMNAME", objBEStudent.DtResult.Rows[0]["ExamName"].ToString());
            stbEmail.Replace("@DATE", objBEStudent.DtResult.Rows[0]["ExamDate"].ToString());
            stbEmail.Replace("@TIME", objBEStudent.DtResult.Rows[0]["TimeDuration"].ToString());
            stbEmail.Replace("@URL", "http://ProctorVaultV3.strateology.net/login.aspx");

            //this.SendMail(stbEmail.ToString(), "Exam is " + strStatus.ToLower().ToString() + " by Auditor");
            if (strStatus == "Approved")
            {
                this.SendMail(stbEmail.ToString(), "Examity: " + objBEStudent.DtResult.Rows[0]["ExamName"].ToString() + " [" + TransID.ToString() + "] Approval Confirmation");
            }
            else if (strStatus == "Rejected")
            {
                this.SendMail(stbEmail.ToString(), "Examity: " + objBEStudent.DtResult.Rows[0]["ExamName"].ToString() + " [" + TransID.ToString() + "] Exam Rejected by Auditor");
            }
        }
        /// <summary>
        /// Exam Approved - Provider
        /// </summary>
        /// <param name="TransID"></param>
        public void ExamApprovedProvider(Int64 TransID, string strStatus)
        {
            stbEmail = new StringBuilder();
            stbEmail.Append("<table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" >");
            stbEmail.Append("<tr><td><img src=\"http://demo.secureproctor.com/images/logo.png\" />");
            stbEmail.Append("<tr><td>&nbsp;</td></tr>");
            stbEmail.Append("<tr><td>The Exam @EXAMNAME is " + strStatus + " by Auditor.</td></tr>");
            stbEmail.Append("<tr><td>&nbsp;</td></tr>");
            stbEmail.Append("<tr><td>Exam Details</td></tr>");
            stbEmail.Append("<tr><td>&nbsp;</td></tr>");
            stbEmail.Append("<tr><td>Student Name : @STUDENTNAME</td></tr>");
            stbEmail.Append("<tr><td>ID : @EXAMID</td></tr>");
            stbEmail.Append("<tr><td>Course Name : @COURSENAME</td></tr>");
            stbEmail.Append("<tr><td>Exam Name : @EXAMNAME</td></tr>");
            stbEmail.Append("<tr><td>Date : @DATE</td></tr>");
            stbEmail.Append("<tr><td>Time : @TIME (local time)</td></tr>");
            stbEmail.Append("<tr><td>&nbsp;</td></tr>");
            stbEmail.Append("<tr><td>&nbsp;</td></tr>");
            stbEmail.Append("<tr><td>Thanks,</td></tr>");
            stbEmail.Append("<tr><td>Examity Team.</td></tr>");
            stbEmail.Append("<tr><td>Examity LLC. ALL RIGHTS RESERVED.</td></tr>");
            stbEmail.Append("<tr><td>Contact Us: support@exnjit.zendesk.com</td></tr>");
            stbEmail.Append("<tr><td>***<b>DO NOT REPLY TO THIS EMAIL</b>***</td></tr>");
            stbEmail.Append("<tr><td></td></tr></table>");
            BEStudent objBEStudent = new BEStudent();
            BStudent objBStudent = new BStudent();
            objBEStudent.IntTransID = TransID;
            objBStudent.BGetStudentExamDetails(objBEStudent);

            stbEmail.Replace("@EXAMID", TransID.ToString());
            stbEmail.Replace("@STUDENTNAME", objBEStudent.DtResult.Rows[0]["Name"].ToString());
            stbEmail.Replace("@COURSENAME", objBEStudent.DtResult.Rows[0]["CourseName"].ToString());
            stbEmail.Replace("@EXAMNAME", objBEStudent.DtResult.Rows[0]["ExamName"].ToString());
            stbEmail.Replace("@DATE", objBEStudent.DtResult.Rows[0]["ExamDate"].ToString());
            stbEmail.Replace("@TIME", objBEStudent.DtResult.Rows[0]["TimeDuration"].ToString());
            stbEmail.Replace("@URL", "http://ProctorVaultV3.strateology.net/login.aspx");

            if (strStatus == "Approved")
            {
                this.SendMail(stbEmail.ToString(), "Examity: FYI - " + objBEStudent.DtResult.Rows[0]["Name"].ToString() + " Exam - Approved by Auditor");
                //this.SendMail(stbEmail.ToString(), "Exam is " + strStatus.ToLower().ToString() + " by Auditor");
            }
            else if (strStatus == "Rejected")
            {
                this.SendMail(stbEmail.ToString(), "Examity: FYI - " + objBEStudent.DtResult.Rows[0]["Name"].ToString() + " Exam - Rejected by Auditor");
            }
        }
        #endregion
        #region SendMail
        /// <summary>
        /// Send Mail Method
        /// </summary>
        /// <param name="str"></param>
        /// <param name="strSubject"></param>
        protected void SendMail(string str, string strSubject)
        {
            try
            {               
                //MailMessage objmsg = new MailMessage();
                //objmsg.From = new MailAddress("PVMailConfig@gmail.com", "noreply@secureproctor.com");
                //objmsg.To.Add(new MailAddress(System.Configuration.ConfigurationManager.AppSettings["TO"].ToString()));
                //objmsg.CC.Add(new MailAddress(System.Configuration.ConfigurationManager.AppSettings["CC"].ToString()));
                //objmsg.Subject = strSubject;
                //objmsg.Body = str;
                //objmsg.IsBodyHtml = true;
                //objmsg.BodyEncoding = System.Text.Encoding.UTF8;
                //SmtpClient obj = new SmtpClient
                //{
                //    Host = "smtp.gmail.com",
                //    Port = 587,
                //    EnableSsl = true,
                //    DeliveryMethod = SmtpDeliveryMethod.Network,
                //    UseDefaultCredentials = false,
                //    Credentials = new NetworkCredential("PVMailConfig@gmail.com", "pv@TESTING")
                //};
                //obj.Send(objmsg);
                //objmsg = null;
                //obj = null;

                MailMessage objmsg = new MailMessage();
                objmsg.From = new MailAddress("admin@examity.com", "noreply@examity.com");
                objmsg.To.Add(new MailAddress(System.Configuration.ConfigurationManager.AppSettings["TO"].ToString()));
                objmsg.CC.Add(new MailAddress(System.Configuration.ConfigurationManager.AppSettings["CC"].ToString()));
                objmsg.Subject = strSubject;
                objmsg.Body = str;
                objmsg.IsBodyHtml = true;
                objmsg.BodyEncoding = System.Text.Encoding.UTF8;
                SmtpClient obj = new SmtpClient
                {
                    Host = "pod51011.outlook.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential("admin@examity.com", "Ad3!nAd3!n")
                };
                obj.Send(objmsg);
                objmsg = null;
                obj = null;
            }
            catch
            {
            }
        }
        #endregion
    }
}