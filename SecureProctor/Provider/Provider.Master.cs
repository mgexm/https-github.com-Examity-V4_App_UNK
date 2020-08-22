using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using BusinessEntities;

namespace SecureProctor.Provider
{
    public partial class Provider : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session[BaseClass.EnumPageSessions.USERID] != null)
            {
                lblUser.Text = Session["UserName"].ToString();
            }
            else
            {
                Response.Redirect(BaseClass.EnumAppPage.LOGIN, false);
            }


            if (Session["RoleID"].ToString() != "3")
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
                //lblTimeZone.Text = "[ <b>Time Zone : </b>" + Session["TimeZone"].ToString() + " ]";
                string[] strtimezone = Session["TimeZone"].ToString().Split('(');
                lbtnTimeZone.Text = strtimezone[0].ToString() + " : " + DateTime.UtcNow.AddMinutes(objBECommon.IntResult).ToString("MM/dd/yyyy HH:mm tt");
            }
            else
            {
                Response.Redirect(BaseClass.EnumAppPage.LOGIN, false);
            }

            GetSSOStatus();
        }

        protected void lnkTab_Click(object sender, EventArgs e)
        {
            LinkButton lnk = (LinkButton)sender;
            switch (lnk.CommandName.ToString())
            {
                case "HOME":
                    Response.Redirect(BaseClass.EnumAppPage.PROVIDER_HOME);
                    break;
                case "COURSEDETAILS":
                    Response.Redirect(BaseClass.EnumAppPage.PROVIDER_COURSEDETAILS);
                    break;
                case "EXAMDETAILS":
                    Response.Redirect(BaseClass.EnumAppPage.PROVIDER_EXAMDETAILS);
                    break;
                case "ENROLLSTUDENT":
                    Response.Redirect(BaseClass.EnumAppPage.PROVIDER_ENROLLSTUDENT);
                    break;
                case "ENROLLCOURSESTUDENT":
                    Response.Redirect(BaseClass.EnumAppPage.PROVIDER_COURSESTUDENTS);
                    break;
                case "ADDSTUDENT":
                    Response.Redirect(BaseClass.EnumAppPage.PROVIDER_VIEWSTUDENT);
                    break;
                case "EXAMSTATUS":
                    Response.Redirect(BaseClass.EnumAppPage.PROVIDER_EXAMSTATUS);
                    break;
                case "REPORTS":
                    Response.Redirect(BaseClass.EnumAppPage.PROVIDER_REPORTS);
                    break;
                case "MYPROFILE":
                    Response.Redirect(BaseClass.EnumAppPage.PROVIDER_MYPROFILE);
                    break;
                case "LOGOUT":
                    Session.Abandon();
                    Response.Redirect(BaseClass.EnumAppPage.COMMON_LOGOUT);
                    break;
            }
        }

        protected void lbtnTimeZone_Click(object sender, EventArgs e)
        {
            Response.Redirect(BaseClass.EnumAppPage.PROVIDER_MYPROFILE.ToString());
        }

        protected void GetSSOStatus()
        {

            BECommon objBECommon = new BECommon();
            BCommon objBCommon = new BCommon();

            //objBEStudent.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID]);
            objBCommon.BGetSSOStatus(objBECommon);

            if (objBECommon.DsResult != null && objBECommon.DsResult.Tables.Count > 0 && objBECommon.DsResult.Tables[0].Rows.Count > 0)
            {
                bool sso = Convert.ToBoolean(objBECommon.DsResult.Tables[0].Rows[0]["SSO"].ToString());
                if (sso == false)
                {

                    liprofile.Visible = true;
                }

                if (sso == true)
                {

                    liprofile.Visible = false;
                }
            }
        }
    }
}