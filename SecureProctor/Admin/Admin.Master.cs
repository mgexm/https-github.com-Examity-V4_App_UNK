using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessEntities;
using BLL;

namespace SecureProctor.Admin
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session[BaseClass.EnumPageSessions.USERID] != null)
                lblUser.Text = Session["UserName"].ToString();
            else
                Response.Redirect(BaseClass.EnumAppPage.LOGIN, false);



            if (Session["RoleID"].ToString() != "7")
          
            Response.Redirect(BaseClass.EnumAppPage.ERRORMESSAGE, true);

            if (Session["TimeZone"] != null && Session["TimeZoneID"] != null)
            {
                BECommon objBECommon = new BECommon();
                BCommon objBCommon = new BCommon();
                objBECommon.iTimeZoneID = Convert.ToInt32(Session["TimeZoneID"]);
                objBCommon.BGetTimeDelay(objBECommon);
                //lblDate.Text = "Date: " + CommonFunctions.GetTime(DateTime.UtcNow, Session["TimeZone"].ToString()).ToString();
                //lblDate.Text = "Date: " + DateTime.UtcNow.AddMinutes(objBECommon.IntResult).ToString();
                //lbtnTimeZone.Text = "[ " + Session["TimeZone"].ToString() + " ]";
                string[] strtimezone = Session["TimeZone"].ToString().Split('(');
                lbtnTimeZone.Text = strtimezone[0].ToString() + " : " + DateTime.UtcNow.AddMinutes(objBECommon.IntResult).ToString("MM/dd/yyyy HH:mm tt");                
            }
            else
                Response.Redirect(BaseClass.EnumAppPage.LOGIN, false);
        }

        protected void lnkTab_Click(object sender, EventArgs e)
        {
            LinkButton lnk = (LinkButton)sender;
            switch (lnk.CommandName.ToString())
            {
                case "HOME":
                    Response.Redirect(BaseClass.EnumAppPage.ADMIN_HOME);
                    break;

                case "VIEWSTUDENT":
                    Response.Redirect(BaseClass.EnumAppPage.ADMIN_VIEWSTUDENT);
                    break;

                case "VIEWCOURSE":
                    Response.Redirect(BaseClass.EnumAppPage.ADMIN_VIEWCOURSE);
                    break;
                case "EXAMSTATUS":
                    Response.Redirect(BaseClass.EnumAppPage.ADMIN_EXAMSTATUS);
                    break;
                //case "INSTRUCTOR":
                //    Response.Redirect(BaseClass.EnumAppPage.ADMIN_INSTRUCTOR);
                //    break;

                case "REPORTS":
                    Response.Redirect(BaseClass.EnumAppPage.ADMIN_REPORTS);
                    break;
                case "ENROLLSTUDENT":
                    Response.Redirect(BaseClass.EnumAppPage.ADMIN_STUDENTS);
                    break;
                case "ENROLLCOURSESTUDENT":
                    Response.Redirect(BaseClass.EnumAppPage.ADMIN_COURSESTUDENTS);
                    break;

                case "EXAMDETAILS":
                    Response.Redirect(BaseClass.EnumAppPage.ADMIN_EXAMDETAILS);
                  
                    break;

                case "MYPROFILE":
                    Response.Redirect(BaseClass.EnumAppPage.ADMIN_MYPROFILE);
                    break;

                case "LOGOUT":
                    Session.Abandon();
                    Response.Redirect(BaseClass.EnumAppPage.COMMON_LOGOUT);
                    break;
            }
        }

        protected void lbtnTimeZone_Click(object sender, EventArgs e)
        {
            Response.Redirect(BaseClass.EnumAppPage.ADMIN_MYPROFILE.ToString());
        }

       
    }
}
