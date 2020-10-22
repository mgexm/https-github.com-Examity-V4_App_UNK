using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using BusinessEntities;
using BLL;

namespace SecureProctor.Student
{
    public partial class IdentityVerification : BaseClass 
    {
        public string SessionID = "";
        public string TokenID = "";
        public string Transid = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.ToString() != "")
            {
                SessionID = AppSecurity.Decrypt(Request.QueryString["OTSessionID"]);
            }
            else
            {
                //Show errors if any
            }
            OpenTokSDK opentok = new OpenTokSDK();
            TokenID = opentok.GenerateToken(SessionID);

            this.Page.Title = EnumPageTitles.APPNAME + EnumPageTitles.STUDENT_VALIDATEIDENTITY;
            ((LinkButton)this.Page.Master.FindControl("lnkStart")).CssClass = "main_menu_active";
            
        }

        protected void btnContinue_Click(object sender, EventArgs e)
        {
            try
            {
                BEStudent objBEStudent = new BEStudent();
                BStudent objBStudent = new BStudent();

                objBEStudent.IntTransID = Convert.ToInt64(AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()));

                objBStudent.BGetIdentityValidation(objBEStudent);

                if (objBEStudent.StudentIdentity)
                    Response.Redirect("ValidateStudent.aspx?" + Request.QueryString.ToString(), false);
                else
                    lblError.Visible = true;
            }
            catch (Exception )
            {
                //ErrorLog.WriteError(Ex);
            }
        }
        
    }
}