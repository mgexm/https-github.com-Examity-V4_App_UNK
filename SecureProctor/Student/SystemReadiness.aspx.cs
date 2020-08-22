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
    public partial class SystemReadiness : BaseClass
    {
        Int64 transid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Page.Title = SecureProctor.BaseClass.EnumPageTitles.APPNAME + SecureProctor.BaseClass.EnumPageTitles.STUDENT_SYSTEMREADINESS;
        }

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
            if (strType == SecureProctor.BaseClass.EnumPayment.ExamType_Scheduled)
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