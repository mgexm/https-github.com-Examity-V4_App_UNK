using System;
using System.Web.UI.WebControls;
using BusinessEntities;
using BLL;
using System.Web;
using System.Web.UI;
using RestSharp;
using System.Net;

namespace SecureProctor.Student
{
    public partial class Agreements : BaseClass
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.GetAllRules();
            }
        }

        protected void GetAllRules()
        {
            BECommon objBECommon = new BECommon();
            BCommon objBCommon = new BCommon();
            objBECommon.iID = Convert.ToInt64(AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()));
            objBECommon.iTypeID = 1;
            objBECommon.StrFromPage = "STUDENT";

            objBCommon.BGetExamRulesInformation(objBECommon);

            if (objBECommon.DsResult != null && objBECommon.DsResult.Tables.Count > 0 && objBECommon.DsResult.Tables[0].Rows.Count > 0)
            {
                gvStandard.DataSource = objBECommon.DsResult.Tables[0];
                gvStandard.DataBind();
            }
            else
                gvStandard.DataSource = new string[] { };


            //Additional Rules
            if (objBECommon.DsResult != null && objBECommon.DsResult.Tables.Count > 0 && objBECommon.DsResult.Tables[1].Rows.Count > 0)
            {
                gvAllowed.DataSource = objBECommon.DsResult.Tables[1];
                gvAllowed.DataBind();
            }
            else
            {
                gvAllowed.DataSource = new string[] { };
                gvAllowed.DataBind();
                trAllowed.Style.Add("display", "none");
            }

            //Special Instructions
            if (objBECommon.DsResult != null && objBECommon.DsResult.Tables.Count > 0 && objBECommon.DsResult.Tables[2].Rows.Count > 0)
            {
                gvSpecialInstructions_Student.DataSource = objBECommon.DsResult.Tables[2];
                gvSpecialInstructions_Student.DataBind();
            }
            else
            {
                gvSpecialInstructions_Student.DataSource = new string[] { };
                gvSpecialInstructions_Student.DataBind();
                trSpecialStudent.Style.Add("display", "none");
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Int64 TransID = Convert.ToInt64(AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()));
            BEStudent objBEStudent = new BEStudent();
            BStudent objBStudent = new BStudent();
            objBEStudent.IntTransID = TransID;
            objBEStudent.IntResult = 2;
            objBEStudent.IntType = 9;
            objBStudent.BUpdateNonProctorExamStatus(objBEStudent);
            objBStudent.BUpdatePLTime(objBEStudent);

            if (Session["isexamiFACE"] != null && Session["isexamiFACE"].ToString() == "1")
            {
                BECommon objBECommon = new BECommon();
                BCommon objBCommon = new BCommon();
                objBECommon.IntTransID = TransID;
                objBCommon.BGetOpenTokAutoProctorStatus(objBECommon);
                if (objBECommon.IntResult == 1)
                    {
                    var client = new RestClient(System.Configuration.ConfigurationManager.AppSettings["ExamityMeetingService_URL"].ToString());
                    var request = new RestRequest(Method.POST);
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append("Method=CreateAutoProctorMeeting&");
                    sb.Append("TransID=" + Request.QueryString["TransID"].ToString());
                    sb.Append("&ClientID=" + System.Configuration.ConfigurationManager.AppSettings["ExamityMeeting_ClientID"].ToString());

                    request.AddParameter("application/x-www-form-urlencoded", sb.ToString(), RestSharp.ParameterType.RequestBody);
                    var response = client.Execute(request);
                    Response.Redirect("BeginAutoProctorExam.aspx?TransID=" + Request.QueryString["TransID"].ToString());
                    //Response.Redirect("BeginAutoProctorExam.aspx?TransID=" + Request.QueryString["TransID"].ToString());
                }
                else
                    Response.Redirect("BeginAutoExam.aspx?TransID=" + Request.QueryString["TransID"].ToString());
            }
            else
            {
                Response.Redirect("BeginExam.aspx?TransID=" + Request.QueryString["TransID"].ToString());
            }
        }
    }
}