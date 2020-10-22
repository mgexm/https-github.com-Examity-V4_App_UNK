using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessEntities;
using BLL;

namespace SecureProctor.Student
{
    public partial class Systemreadiness : BaseClass
    {
        //Int64 transid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Page.Title = EnumPageTitles.APPNAME + EnumPageTitles.STUDENT_SYSTEMREADINESS;

           
           
        }

        //protected void btnNext_Click(object sender, EventArgs e)
        //{


        //    if (Session["NonProctorExam"] != null)
        //    {

        //        BEStudent objBEStudent = (BEStudent)Session["NonProctorExam"];
        //        this.SetExamFeeSettings(objBEStudent.IntExamID, "EXAMID");
        //        new BStudent().BCheckPLexamretake(objBEStudent);

        //        if (objBEStudent.intReExam == 0)
        //        {

        //            //unversity pay
        //            if (Session[EnumPayment.PaidBY_ExamFee].ToString() == EnumPayment.PaidBy_University)
        //            {

        //                //Response.Redirect("PLConfirmation.aspx?TransID=" + AppSecurity.Encrypt(objBEStudent.DsResult.Tables[0].Rows[0]["ID"].ToString()), false);
        //                if (Session["Flowcheck"] != null && Convert.ToInt32(Session["Flowcheck"]) == 1)
        //                {
        //                    new BStudent().BStudent_NonProctorScheduleExam(objBEStudent);
        //                    this.LogPayments(Convert.ToInt32(objBEStudent.DsResult.Tables[0].Rows[0]["ID"].ToString()), objBEStudent.decExamFee + objBEStudent.PerHourFee, objBEStudent.decOnDemandFee, EnumPayment.ExamType_Scheduled);
        //                    //  Response.Redirect("CaptureImage.aspx?TransID=" + AppSecurity.Encrypt(objBEStudent.DsResult.Tables[0].Rows[0]["ID"].ToString()), false);
        //                    Response.Redirect(HttpContext.Current.Request.Url.AbsoluteUri.Replace("http", "https").Replace("Systemreadiness.aspx", "CaptureImage.aspx?TransID=" + AppSecurity.Encrypt(objBEStudent.DsResult.Tables[0].Rows[0]["ID"].ToString())), false);
        //                }
        //                else
        //                    //  Response.Redirect(BaseClass.EnumAppPage.STUDENT_SCHEDULE);
        //                    Response.Redirect(HttpContext.Current.Request.Url.AbsoluteUri.Replace("http", "https").Replace("Systemreadiness.aspx", "ScheduleAnExam.aspx"), false);
        //            }
        //            //student pay
        //            else if (Session[EnumPayment.PaidBY_ExamFee].ToString() == EnumPayment.PaidBy_Student)
        //            {
        //                Session["Isproctorless"] = 1;
        //                new BStudent().BStudent_NonProctorValidateExam(objBEStudent);
        //                ProcessPayment_Schedule(objBEStudent);
        //            }


        //        }

        //        else if (objBEStudent.intReExam == 1)
        //        {

        //            if (objBEStudent.intStep == 1)
        //            {
        //                Response.Redirect(HttpContext.Current.Request.Url.AbsoluteUri.Replace("http", "https").Replace("Systemreadiness.aspx", "CaptureImage.aspx?TransID=" + AppSecurity.Encrypt(objBEStudent.IntTransID.ToString())), false);
        //            }

        //            else if (objBEStudent.intStep == 2)
        //            {
        //                Response.Redirect(HttpContext.Current.Request.Url.AbsoluteUri.Replace("http", "https").Replace("Systemreadiness.aspx", "CaptureIDImage.aspx?TransID=" + AppSecurity.Encrypt(objBEStudent.IntTransID.ToString())), false);
        //            }
        //            else if (objBEStudent.intStep == 3)
        //            {
        //                Response.Redirect(HttpContext.Current.Request.Url.AbsoluteUri.Replace("http", "https").Replace("Systemreadiness.aspx", "Authenticationcode.aspx?TransID=" + AppSecurity.Encrypt(objBEStudent.IntTransID.ToString())), false);
        //            }
        //            else if (objBEStudent.intStep == 4)
        //            {
        //                Response.Redirect(HttpContext.Current.Request.Url.AbsoluteUri.Replace("http", "https").Replace("Systemreadiness.aspx", "Agreements.aspx?TransID=" + AppSecurity.Encrypt(objBEStudent.IntTransID.ToString())), false);
        //            }

        //        }









        //    }






        //}


        protected void btnNext_Click(object sender, EventArgs e)
        {
            Int64 TransID = 0;
            if (Request.QueryString["TransID"] != null)
            {
                TransID = Convert.ToInt64(AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()));


                //BEStudent objBEStudent = new BEStudent();
                //objBEStudent.IntTransID = TransID;
                //new BStudent().BCheckPLexamretake(objBEStudent);
                string url = HttpContext.Current.Request.Url.ToString();

               // Response.Redirect(url.Replace("http", "https").Replace("Systemreadiness.aspx", "CaptureImage.aspx"), false);
                Response.Redirect("CaptureImage.aspx?TransID=" + AppSecurity.Encrypt(TransID.ToString()), false);
                //Response.Redirect(HttpContext.Current.Request.Url.AbsoluteUri.Replace("http", "https").Replace("Systemreadiness.aspx", "CaptureImage.aspx?TransID=" + AppSecurity.Encrypt(TransID.ToString())), false);
            }
          
                else
            {
                Response.Redirect("StartAnExam.aspx");

            }
           

        }

        protected void SetExamFeeSettings(int intID, String strType)
        {
            BEStudent objBEStudent = new BEStudent();
            BStudent objBStudent = new BStudent();
            objBEStudent.IntExamID = intID;
            objBEStudent.IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID]);
            if (strType == "EXAMID")
                objBStudent.BGetExamFeeSettingsByExamID(objBEStudent);
            else
                objBStudent.BGetExamFeeSettingsByTransID(objBEStudent);
            Session[EnumPayment.PaidBY_ExamFee] = objBEStudent.intExamFeePaidBy.ToString();
            Session[EnumPayment.PaidBY_OndeMand] = objBEStudent.intOndemandPaidBy.ToString();

            objBEStudent = null;
            objBStudent = null;
        }

        protected void LogPayments(Int64 intTransID, decimal decExamFee, decimal decOnDemandFee, string strType)
        {
            if (strType == EnumPayment.ExamType_Scheduled)
            {
                BEStudent objBEStudent = new BEStudent();
                objBEStudent.IntTransID = intTransID;
                objBEStudent.decExamFee = decExamFee;
                objBEStudent.decOnDemandFee = decOnDemandFee;
                objBEStudent.intExamFeePaidBy = Convert.ToInt32(Session[EnumPayment.PaidBY_ExamFee].ToString());
                objBEStudent.intOndemandPaidBy = Convert.ToInt32(Session[EnumPayment.PaidBY_OndeMand].ToString());
                new BStudent().BSetPaymentDetails_Scheduled(objBEStudent);
            }
            else
            {
                BEStudent objBEStudent = new BEStudent();
                objBEStudent.IntTransID = intTransID;
                objBEStudent.decExamFee = decExamFee;
                objBEStudent.decOnDemandFee = decOnDemandFee;
                objBEStudent.intExamFeePaidBy = Convert.ToInt32(Session[EnumPayment.PaidBY_ExamFee].ToString());
                objBEStudent.intOndemandPaidBy = Convert.ToInt32(Session[EnumPayment.PaidBY_OndeMand].ToString());
                new BStudent().BSetPaymentDetails_Recheduled(objBEStudent);
            }
        }

        protected void ProcessPayment_Schedule(BEStudent objBEStudent)
        {
            Session["BESTUDENT"] = objBEStudent;
            // Response.Redirect(HttpContext.Current.Request.Url.AbsoluteUri.Replace("http", "https").Replace("Systemreadiness.aspx", "PaymentProcess.aspx"), false);
            Response.Redirect("PaymentProcess.aspx");
        }
    }
}