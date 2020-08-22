using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using BusinessEntities;
using BLL;
using System.IO;

namespace SecureProctor.Student
{
    public partial class StudentExamProcess : System.Web.UI.Page
    {
        string TYPE="";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["examiKEY"] != null)
            {
                TYPE= AppSecurity.Decrypt(Request.QueryString["examiKEY"].ToString());
                if (TYPE == "1")
                {

                    WithoutKEYStep1.Style.Add("display", "none");
                    WithKEYStep1.Style.Add("display", "block");
                }
                else
                {
                    WithoutKEYStep1.Style.Add("display", "block");
                    WithKEYStep1.Style.Add("display", "none");

                }

            }

            //Get exam details for browser-lockdown signal
            new CommonFunctions().setExamDetailsForExamityMeeting(Request.QueryString["TransID"].ToString(),hdnIsLockDown,hdnIsPasswordExists,hdnLmsDomain,hdnExamSecurity);
        }


        protected void btnProceed_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["TransID"] != null)
            {



                this.SetFlags("PROCEED", 0);
                BEStudent objBEStudent = new BEStudent();
                BStudent objBStudent = new BStudent();
                objBEStudent.IntTransID = Convert.ToInt64(GetTransID());
                objBStudent.BUpdateProceedTime(objBEStudent);


            }
        }

        protected void SetFlags(string strType, int intValue)
        {
            BEProctor objBEProctor = new BEProctor();
            BProctor objBProctor = new BProctor();
            objBEProctor.IntTransID = Convert.ToInt64(AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()));
            objBEProctor.strStatus = strType;
            objBEProctor.IntResult = intValue;
            objBProctor.BSetTransactionFlags(objBEProctor);
        }

        public string GetTransID()
        {

            return AppSecurity.Decrypt(Request.QueryString["TransID"].ToString());

        }

        protected void btnStep1Next_Click(object sender, EventArgs e)
        {
            BEStudent objBEStudent = new BEStudent();
            BStudent objBStudent = new BStudent();
            objBEStudent.IntTransID = Convert.ToInt64(AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()));
            objBStudent.BUpdateNextButtonTime(objBEStudent);

            if (TYPE == "1")
            {
                Response.Redirect("StudentexamiKNOW.aspx?TransID=" + Request.QueryString["TransID"].ToString() + "&&ExamiKEY=" + AppSecurity.Encrypt("1"), false);
            }
            else
            {
                Response.Redirect("StudentexamiKNOW.aspx?TransID=" + Request.QueryString["TransID"].ToString() + "&&ExamiKEY=" + AppSecurity.Encrypt("0"), false);
            }

           
        }

        //private void setExamDetailsForExamityMeeting()
        //{
        //    try
        //    {
        //        BECommon objBECommon = new BECommon();
        //        objBECommon.IntTransID = int.Parse(AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()));
        //        BCommon bCommon = new BCommon();
        //        bCommon.BGetExamDetailsForExamityMeeting(objBECommon);

        //        if (objBECommon.DsResult != null && objBECommon.DsResult.Tables.Count > 0)
        //        {
        //            var islockDown = Convert.ToBoolean(objBECommon.DsResult.Tables[0].Rows[0]["IsLockDown"]);
        //            hdnIsLockDown.Value = islockDown.ToString();

        //            var isPasswordExists = Convert.ToBoolean(objBECommon.DsResult.Tables[0].Rows[0]["ExamPassword"]);
        //            hdnIsPasswordExists.Value = isPasswordExists.ToString();

        //            var examSecurity = (objBECommon.DsResult.Tables[0].Rows[0]["ExamSecurity"]).ToString();

        //            hdnExamSecurity.Value = examSecurity == "4" ? "L3" : examSecurity;

        //            hdnLmsDomain.Value = objBECommon.DsResult.Tables[0].Rows[0]["ExamDomain"].ToString();
        //        }
        //    }
        //    catch (Exception)
        //    {
        //    }

        //}
    }
}