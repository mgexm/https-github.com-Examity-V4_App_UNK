using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using BusinessEntities;

namespace SecureProctor.CourseAdmin
{
    public partial class Home : BaseClass
    {
        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Page.Title = EnumPageTitles.APPNAME + EnumPageTitles.HOME;
            ((LinkButton)this.Page.Master.FindControl("lnkHome")).CssClass = "main_menu_active";

            checkInstructorTimeZone();
        }

        #endregion

        #region Methods

        protected void checkInstructorTimeZone()
        {
            BECourseAdmin objBEProvider = new BECourseAdmin();

            BCourseAdmin objBProvider = new BCourseAdmin();

            objBEProvider.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID]);

            objBProvider.BCheckTimeZone(objBEProvider);

            if (objBEProvider.IntResult == 1)
            {
                lblMsg.Visible = true;

            }

            else
            {
                lblMsg.Visible = false;
            }


        }

        #endregion
    }
}