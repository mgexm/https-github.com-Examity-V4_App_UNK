using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SecureProctor.Student
{
    public partial class PaymentProcess : BaseClass 
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Page.Title = EnumPageTitles.APPNAME + "Payment Process";
            ((LinkButton)this.Page.Master.FindControl("lnkSchedule")).CssClass = "main_menu_active";
        }
    }
}