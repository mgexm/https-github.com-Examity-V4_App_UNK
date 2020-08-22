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
    public partial class StudentAgreements : System.Web.UI.Page
    {
        string TYPE = "";
        protected void Page_Load(object sender, EventArgs e)
        {           
            if (Request.QueryString["examiKEY"] != null)
            {
                TYPE = AppSecurity.Decrypt(Request.QueryString["examiKEY"].ToString());
                if (TYPE == "1")
                {
                    WithoutKEYStep3.Style.Add("display", "none");
                    WithKEYStep4.Style.Add("display", "block");
                }
                else
                {
                    WithoutKEYStep3.Style.Add("display", "block");
                    WithKEYStep4.Style.Add("display", "none");
                }
            }

            if (!IsPostBack)
            {
                this.GetAllRules();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Int64 TransID = Convert.ToInt64(AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()));
            BEStudent objBEStudent = new BEStudent();
            BStudent objBStudent = new BStudent();

            objBEStudent.IntTransID = TransID;//Convert.ToInt32(AppSecurity.Decrypt(Request.Form["TransID"].ToString()));
            objBEStudent.IntstatusFlag = 2;

            objBStudent.BUpdateExamStatus(objBEStudent);
            Response.Redirect("BeginExamProcess.aspx?TransID=" + Request.QueryString["TransID"].ToString() + "&&ExamiKEY=" + Request.QueryString["examiKEY"].ToString());
        }


        protected void GetAllRules()
        {
            BECommon objBECommon = new BECommon();
            BCommon objBCommon = new BCommon();
            objBECommon.StrFromPage = "STUDENT";

            if (Request.QueryString["TransID"] != null)
            {
                objBECommon.iID = Convert.ToInt64(AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()));
                objBECommon.iTypeID = 1;// sending TransID 
            }
            if (Request.QueryString["ExamID"] != null)
            {
                try
                {
                    objBECommon.iID = Convert.ToInt32(AppSecurity.Decrypt(Request.QueryString["ExamID"].ToString()));
                    objBECommon.iTypeID = 2;// sending ExamID
                }

                catch (Exception e)
                {
                    objBECommon.iID = Convert.ToInt32(Request.QueryString["ExamID"].ToString());
                    objBECommon.iTypeID = 2;// sending ExamID
                }
            }

            objBCommon.BGetExamRulesInformation(objBECommon);
            if (objBECommon.DsResult != null && objBECommon.DsResult.Tables.Count > 0 && objBECommon.DsResult.Tables[0].Rows.Count > 0)
            {
                gvStandard.DataSource = objBECommon.DsResult.Tables[0];
                gvStandard.DataBind();
            }
            else
                gvStandard.DataSource = new string[] { };

            if (objBECommon.DsResult != null && objBECommon.DsResult.Tables.Count > 0 && objBECommon.DsResult.Tables[1].Rows.Count > 0)
            {

                gvAllowed.DataSource = objBECommon.DsResult.Tables[1];
                gvAllowed.DataBind();
                gvAllowed.Visible = true;
                //trAllowed.Visible = true;

            }
            else
            {
                gvAllowed.DataSource = new string[] { };
                gvAllowed.DataBind();
                trAllowed.Style.Add("display", "none");
            }

            if (objBECommon.DsResult != null && objBECommon.DsResult.Tables.Count > 0 && objBECommon.DsResult.Tables[2].Rows.Count > 0)
            {
                gvSpecialInstructions_Student.DataSource = objBECommon.DsResult.Tables[2];
                gvSpecialInstructions_Student.DataBind();
            }
            else
            {
                trSpecialStudent.Style.Add("display", "none");
                gvSpecialInstructions_Student.DataSource = new string[] { };
                gvSpecialInstructions_Student.DataBind();
            }
        }
    }
}