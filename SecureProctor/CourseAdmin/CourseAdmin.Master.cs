using System;
using System.Web.UI.WebControls;
using BLL;
using BusinessEntities;

namespace SecureProctor.CourseAdmin
{
    public partial class CourseAdmin : System.Web.UI.MasterPage
    {
        #region Events

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

            if (Session["RoleID"].ToString() != "8")
                Response.Redirect(BaseClass.EnumAppPage.ERRORMESSAGE, true);

            if (Session["TimeZone"] != null && Session["TimeZoneID"] != null)
            {

                BECommon objBECommon = new BECommon();
                BCommon objBCommon = new BCommon();
                objBECommon.iTimeZoneID = Convert.ToInt32(Session["TimeZoneID"]);
                objBCommon.BGetTimeDelay(objBECommon);
               
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
                    Response.Redirect(BaseClass.EnumAppPage.COURSEADMIN_HOME);
                    break;
                case "COURSEDETAILS":
                    Response.Redirect(BaseClass.EnumAppPage.COURSEADMIN_COURSEDETAILS);
                    break;
                case "EXAMDETAILS":
                    Response.Redirect(BaseClass.EnumAppPage.COURSEADMIN_EXAMDETAILS);
                    break;
                case "ENROLLSTUDENT":
                    Response.Redirect(BaseClass.EnumAppPage.COURSEADMIN_ENROLLSTUDENT);
                    break;
                case "COURSESTUDENTS":
                    Response.Redirect(BaseClass.EnumAppPage.COURSEADMIN_COURSESTUDENTS);
                    break;
                case "ADDSTUDENT":
                    Response.Redirect(BaseClass.EnumAppPage.COURSEADMIN_VIEWSTUDENT);
                    break;
                case "EXAMSTATUS":
                    Response.Redirect(BaseClass.EnumAppPage.COURSEADMIN_EXAMSTATUS);
                    break;
                case "REPORTS":
                    Response.Redirect(BaseClass.EnumAppPage.COURSEADMIN_REPORTS);
                    break;
                case "MYPROFILE":
                    Response.Redirect(BaseClass.EnumAppPage.COURSEADMIN_MYPROFILE);
                    break;
                case "LOGOUT":
                    Session.Abandon();
                    Response.Redirect(BaseClass.EnumAppPage.COMMON_LOGOUT);
                    break;
            }
        }

        protected void lbtnTimeZone_Click(object sender, EventArgs e)
        {
            Response.Redirect(BaseClass.EnumAppPage.COURSEADMIN_MYPROFILE.ToString());
        }

        #endregion

        #region Private/Protected Methods

        protected void GetSSOStatus()
        {

            BECommon objBECommon = new BECommon();
            BCommon objBCommon = new BCommon();
           
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

        #endregion
    }
}