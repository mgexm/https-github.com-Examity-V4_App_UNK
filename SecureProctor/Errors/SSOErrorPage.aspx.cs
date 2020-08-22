using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SecureProctor.Errors
{
    public partial class SSOErrorPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["ErrorId"] != null)
            {
                lblError.Text = ErrorMessages.GetErrorMessage(Convert.ToInt32(Request.QueryString["ErrorId"].ToString()));
            }
        }
    }
}