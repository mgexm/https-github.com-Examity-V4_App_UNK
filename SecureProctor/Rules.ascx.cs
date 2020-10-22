using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using BusinessEntities;

namespace SecureProctor
{
    public partial class Rules : System.Web.UI.UserControl
    {
        public string DisplayFrom { get; set; }
      

        protected void Page_Load(object sender, EventArgs e)
        {
          
           this.GetAllRules();
        }

        protected void GetAllRules()
        {
            BECommon objBECommon = new BECommon();
            BCommon objBCommon = new BCommon();

            objBECommon.StrFromPage = DisplayFrom;
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

                catch (Exception )
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
            }
            else
                gvAllowed.DataSource = new string[] { };

            if (objBECommon.DsResult != null && objBECommon.DsResult.Tables.Count > 0 && objBECommon.DsResult.Tables[2].Rows.Count > 0)
            {
                if (DisplayFrom == "STUDENT")
                {
                    gvSpecialInstructions_Student.DataSource = objBECommon.DsResult.Tables[2];
                    gvSpecialInstructions_Student.DataBind();
                    trSpecialStudent.Visible = true;
                    trSpecialProctor.Visible = false;
                }
                if (DisplayFrom == "PROCTOR")
                {
                    gvSpecialInstructions_Proctor.DataSource = objBECommon.DsResult.Tables[2];
                    gvSpecialInstructions_Proctor.DataBind();
                    trSpecialProctor.Visible = true;
                    trSpecialStudent.Visible = false;

                }
            }
            else
            {
                gvSpecialInstructions_Student.DataSource = new string[] { };
                gvSpecialInstructions_Proctor.DataSource = new string[] { };
                trSpecialProctor.Visible = true;
            }


            objBECommon=null;
            objBCommon = null;
        }
    }
}