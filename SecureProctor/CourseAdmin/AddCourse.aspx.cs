using System;
using BLL;
using BusinessEntities;
using Telerik.Web.UI;

namespace SecureProctor.CourseAdmin
{
    public partial class AddCourse : BaseClass
    {
        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Page.Title = EnumPageTitles.APPNAME + EnumPageTitles.EXAMPROVIDER_COURSEDETAILS_ADD_COURSE;
                trAddCourse.Visible = true;
                trAddCourseConfirm.Visible = false;
                this.BindCourseAdminSpecificProviders();
               
            }
            trMessage.Visible = false;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                BECourseAdmin objBECourseAdmin = new BECourseAdmin();
                BCourseAdmin objBCourseAdmin = new BCourseAdmin();

                objBECourseAdmin.strCourseID = txtCourseID.Text.Trim().ToString();
                lblCourseID.Text = txtCourseID.Text.Trim().ToString();
                objBECourseAdmin.strCourseName = txtCourseName.Text.Trim().ToString();
                lblCourseName.Text = txtCourseName.Text.Trim().ToString();
                objBECourseAdmin.IntUserID = Convert.ToInt32(ddlprovider.SelectedValue);
                objBCourseAdmin.BAddCourse(objBECourseAdmin);
                trMessage.Visible = true;

                if (objBECourseAdmin.IntResult == 1)
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

        #endregion

        #region Methods

        protected void BindCourseAdminSpecificProviders()
        {
            BECourseAdmin objBECourseAdmin = new BECourseAdmin();
            objBECourseAdmin.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID].ToString());
            new BCourseAdmin().BBindProviderNames(objBECourseAdmin);
            if (objBECourseAdmin.DtResult.Rows.Count > 0)
            {
                ddlprovider.AppendDataBoundItems = true;            
                ddlprovider.DataSource = objBECourseAdmin.DtResult;
                ddlprovider.DataTextField = "Name";
                ddlprovider.DataValueField = "ExamProviderID";
                ddlprovider.DataBind();
            }
        }
        #endregion
    }
}