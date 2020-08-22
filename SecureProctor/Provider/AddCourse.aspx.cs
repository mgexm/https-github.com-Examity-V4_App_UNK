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
    public partial class AddCourse : BaseClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Page.Title = EnumPageTitles.APPNAME + EnumPageTitles.EXAMPROVIDER_COURSEDETAILS_ADD_COURSE;
                trAddCourse.Visible = true;
                trAddCourseConfirm.Visible = false;
            }
            trMessage.Visible = false;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                BEProvider objBEExamProvider = new BEProvider();
                BProvider objBExamProvider = new BProvider();
                objBEExamProvider.strCourseID = txtCourseID.Text.Trim().ToString();
                lblCourseID.Text = txtCourseID.Text.Trim().ToString();
                objBEExamProvider.strCourseName = txtCourseName.Text.Trim().ToString();
                lblCourseName.Text = txtCourseName.Text.Trim().ToString();
                objBEExamProvider.IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID].ToString());
                objBExamProvider.BAddCourse(objBEExamProvider);
                trMessage.Visible = true;
                if (objBEExamProvider.IntResult == 1)
                {

                    lblInfo.Text = Resources.AppMessages.Provider_AddCourse_Success_AddCourse;
                    lblInfo.ForeColor = System.Drawing.Color.FromName(Resources.AppConfigurations.Color_Success);
                    ImgInfo.ImageUrl = Resources.AppConfigurations.Image_Success;
                    tdInfo.Attributes.Add("style", Resources.AppConfigurations.Color_Table_Success);
                    trAddCourse.Visible = false;
                    trAddCourseConfirm.Visible = true;
                }
                else
                {

                    lblInfo.Text = Resources.AppMessages.Provider_AddCourse_Error_AddCourse;
                    lblInfo.ForeColor = System.Drawing.Color.FromName(Resources.AppConfigurations.Color_Error);
                    ImgInfo.ImageUrl = Resources.AppConfigurations.Image_Error;
                    tdInfo.Attributes.Add("style", Resources.AppConfigurations.Color_Table_Error);
                    trAddCourse.Visible = true;
                    trAddCourseConfirm.Visible = false;
                }
            }
            catch (Exception Ex)
            {
                ErrorHandlers.ErrorLog.WriteError(Ex);
            }
        }
    }
}