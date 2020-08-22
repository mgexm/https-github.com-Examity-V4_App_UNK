using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessEntities;
using BLL;

namespace SecureProctor.Reports
{
    public partial class Reports : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session[BaseClass.EnumPageSessions.USERID] != null)
                lblUser.Text = Session["UserName"].ToString();
            else
                Response.Redirect(BaseClass.EnumAppPage.LOGIN, false);

            if (Session["TimeZone"] != null)
            {
                //lblDate.Text = "Date: " + CommonFunctions.GetTime(DateTime.UtcNow, Session["TimeZone"].ToString()).ToString();
                BECommon objBECommon = new BECommon();
                BCommon objBCommon = new BCommon();
                objBECommon.iTimeZoneID = Convert.ToInt32(Session["TimeZoneID"]);
                objBCommon.BGetTimeDelay(objBECommon);
                lblDate.Text = "Date: " + DateTime.UtcNow.AddMinutes(objBECommon.IntResult).ToString();
                lbtnTimeZone.Text = "[ " + Session["TimeZone"].ToString() + " ]";
                // lblTimeZone.Text = "[ <b>Time Zone : </b>" + Session["TimeZone"].ToString() + " ]";
            }


            else
                Response.Redirect(BaseClass.EnumAppPage.LOGIN, false);
        }

        protected void lbtnTimeZone_Click(object sender, EventArgs e)
        {
            Response.Redirect(BaseClass.EnumAppPage.PROCTOR_MYPROFILE.ToString());

        }
    }
}