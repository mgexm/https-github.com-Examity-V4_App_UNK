using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using BusinessEntities;

namespace SecureProctor.CourseAdmin
{
    public partial class DeleteCourse : BaseClass
    {
        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                this.Page.Title = EnumPageTitles.APPNAME + EnumPageTitles.EXAMPROVIDER_DELETECOURSE_DELETECOURSE;

                if (Request.QueryString != null && Request.QueryString.ToString() != "")
                    GetSelectedDetails();

            }
            trMessage.Visible = false;
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

            BECourseAdmin objBECourseAdmin = new BECourseAdmin();
            BCourseAdmin objBCourseAdmin = new BCourseAdmin();
            objBECourseAdmin.IntCourseID = Convert.ToInt32(Request.QueryString["CourseID"].ToString());
            objBCourseAdmin.BDeleteCourse(objBECourseAdmin);
            if (objBECourseAdmin.IntResult == 1)
            {
                lblInfo.Text = Resources.AppMessages.Provider_DeleteCourse_Success_DeleteCourse;
                lblInfo.ForeColor = System.Drawing.Color.FromName(Resources.AppConfigurations.Color_Success);
                ImgInfo.ImageUrl = Resources.AppConfigurations.Image_Success;
                tdInfo.Attributes.Add("style", Resources.AppConfigurations.Color_Table_Success);
                trMessage.Visible = true;
                trDelete.Visible = false;


            }
            if (objBECourseAdmin.IntResult == 0)
            {

                lblInfo.Text = Resources.AppMessages.Provider_DeletCourse_Error_DeleteCoursePending;
                lblInfo.ForeColor = System.Drawing.Color.FromName(Resources.AppConfigurations.Color_Error);
                ImgInfo.ImageUrl = Resources.AppConfigurations.Image_Error;
                tdInfo.Attributes.Add("style", Resources.AppConfigurations.Color_Table_Error);
                trMessage.Visible = true;
            }
        }

        #endregion

        #region Methods

        protected void GetSelectedDetails()
        {
            try
            {
                BECourseAdmin objBECourseAdmin = new BECourseAdmin();
                BCourseAdmin objBCourseAdmin = new BCourseAdmin();
                objBECourseAdmin.IntCourseID = Convert.ToInt32(Request.QueryString["CourseID"].ToString());
                objBCourseAdmin.BGetSelectedCourseDetails(objBECourseAdmin);
                if (objBECourseAdmin.DtResult != null && objBECourseAdmin.DtResult.Rows.Count > 0)
                {
                    lblCourseID.Text = objBECourseAdmin.DtResult.Rows[0]["Course_ID"].ToString();
                    lblCourseName.Text = objBECourseAdmin.DtResult.Rows[0]["CourseName"].ToString();


                }
            }
            catch (Exception Ex)
            {
                ErrorHandlers.ErrorLog.WriteError(Ex);
            }

        }

        #endregion

    }
}