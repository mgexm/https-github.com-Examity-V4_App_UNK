using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessEntities;
using BLL;
using Telerik.Web.UI;
using Telerik.Web.UI.Skins;

namespace SecureProctor.Proctor
{
    public partial class StudentIdentityVerification : BaseClass
    {
        public string SessionID = "";
        public string TokenID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            SessionID = Request.QueryString["OTSessionID"].ToString();
            SessionID=AppSecurity.Decrypt(SessionID);
            SecureProctor.Student.OpenTokSDK opentok = new SecureProctor.Student.OpenTokSDK();
            TokenID = opentok.GenerateToken(SessionID);

            if (!IsPostBack)
            {
                this.Page.Title = EnumPageTitles.APPNAME + EnumPageTitles.PROCTOR_VALIDATESTUDENTIDENTITY;
                ((LinkButton)this.Page.Master.FindControl("lnkValidate")).CssClass = "main_menu_active";
            }
        }
        protected void btnContinue_Click(object sender, EventArgs e)
        {
            BEProctor objBEProctor = new BEProctor();
            BProctor objBProctor = new BProctor();
            objBEProctor.IntTransID = Convert.ToInt64(AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()));
            objBEProctor.StudentIdentity = chkValidateIdentity.Checked;

            objBProctor.BSaveIdentityValidation(objBEProctor);

            if (chkValidateIdentity.Checked)
                Response.Redirect("StudentLookUp.aspx?" + Request.QueryString.ToString());
            else
                Response.Write("<script type='text/javascript'>window.close();</script>");
        }
    }
}
