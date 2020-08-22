using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SecureProctor.Proctor
{
	public partial class Home : BaseClass 
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            this.Page.Title = EnumPageTitles.APPNAME + EnumPageTitles.HOME;
            ((LinkButton)this.Page.Master.FindControl("lnkHome")).CssClass = "main_menu_active";
		}
	}
}