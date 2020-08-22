using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using BusinessEntities;

namespace SecureProctor.Admin
{
    public partial class AddCourse : BaseClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Page.Title = EnumPageTitles.APPNAME + EnumPageTitles.EXAMPROVIDER_COURSEDETAILS_ADD_COURSE;
                BindProviders();
                trAddCourse.Visible = true;
                trViewCourse.Visible = false;
            }
            trMessage.Visible = false;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                BEAdmin objBEAdmin = new BEAdmin();
                BAdmin objBAdmin = new BAdmin();
                objBEAdmin.strCourseID = txtCourseID.Text.Trim().ToString();
                objBEAdmin.strCourseName = txtCourseName.Text.Trim().ToString();
                objBEAdmin.IntProviderID = Convert.ToInt32(ddlProviderName.SelectedValue.ToString());
                objBAdmin.BAddCourse(objBEAdmin);
                if (objBEAdmin.IntResult == 1)
                {
                    trMessage.Visible = true;
                    lblInfo.Text = Resources.AppMessages.Admin_AddCourse_Success_AddCourse;
                    lblInfo.ForeColor = System.Drawing.Color.FromName(Resources.AppConfigurations.Color_Success);
                    ImgInfo.ImageUrl = Resources.AppConfigurations.Image_Success;
                    tdInfo.Attributes.Add("style", Resources.AppConfigurations.Color_Table_Success);
                    lblCourseID.Text = txtCourseID.Text.ToString();
                    lblCourseName.Text = txtCourseName.Text.ToString();
                    lblProviderName.Text = ddlProviderName.SelectedItem.Text.ToString();
                    txtCourseID.Text = string.Empty;
                    txtCourseName.Text = string.Empty;
                    trAddCourse.Visible = false;
                    trViewCourse.Visible = true;
                }
                else
                {
                    trMessage.Visible = true;
                    lblInfo.Text = Resources.AppMessages.Admin_AddCourse_Error_AddCourse;
                    lblInfo.ForeColor = System.Drawing.Color.FromName(Resources.AppConfigurations.Color_Error);
                    ImgInfo.ImageUrl = Resources.AppConfigurations.Image_Error;
                    tdInfo.Attributes.Add("style", Resources.AppConfigurations.Color_Table_Error);
                }
            }
            catch (Exception Ex)
            {
                ErrorHandlers.ErrorLog.WriteError(Ex);
            }
        }

        protected void BindProviders()
        {
            try
            {
                BEAdmin objBEAdmin = new BEAdmin();
                BAdmin objBAdmin = new BAdmin();
                objBAdmin.BGetExamProviders(objBEAdmin);
                if (objBEAdmin.DtResult.Rows.Count > 0)
                {
                    ddlProviderName.DataTextField = "ProviderName";
                    ddlProviderName.DataValueField = "ProviderID";
                    ddlProviderName.DataSource = objBEAdmin.DtResult;
                    ddlProviderName.DataBind();
                }
            }
            catch (Exception)
            {

                throw;
            }


        }

    }
}