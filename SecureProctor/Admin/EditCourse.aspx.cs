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
    public partial class EditCourse : BaseClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString != null && Request.QueryString.ToString() != "")
                    this.GetSelectedDetails();
                this.Page.Title = EnumPageTitles.APPNAME + EnumPageTitles.ADMIN_EDITCOURSE_EDITCOURSE;
                trCourseEdit.Visible = true;
                trCourseView.Visible = false;
            }
            trMessage.Visible = false;
        }

        private void GetSelectedDetails()
        {
            try
            {
                BEAdmin objBEAdmin = new BEAdmin();
                BAdmin objBAdmin = new BAdmin();
                objBEAdmin.IntCourseID = Convert.ToInt32(Request.QueryString["CourseID"].ToString());
                objBAdmin.BGetSelectedCourseDetails(objBEAdmin);
                if (objBEAdmin.DtResult != null && objBEAdmin.DtResult.Rows.Count > 0)
                {
                    TxtCourseID.Text = objBEAdmin.DtResult.Rows[0]["Course_ID"].ToString();
                    txtCourseName.Text = objBEAdmin.DtResult.Rows[0]["CourseName"].ToString();
                    ddlStatus.Items.FindItemByText(objBEAdmin.DtResult.Rows[0]["Status"].ToString()).Selected = true;
                    lblCreatedDate.Text = objBEAdmin.DtResult.Rows[0]["CreatedDate"].ToString();
                    lblCreatedDate1.Text = objBEAdmin.DtResult.Rows[0]["CreatedDate"].ToString();
                    lblModifiedDate.Text = objBEAdmin.DtResult.Rows[0]["ModifiedDate"].ToString();
                }


                BECommon objBECommon = new BECommon();
                BCommon objBCommon = new BCommon();
                objBECommon.iID = Convert.ToInt32(Request.QueryString["CourseID"].ToString());
                //to get course lms settings
                objBECommon.iTypeID = 2;

                objBCommon.BGetLMSSettings(objBECommon);
                if (objBECommon.DtResult != null && objBECommon.DtResult.Rows.Count > 0)
                {
                    if (!Convert.ToBoolean(objBECommon.DtResult.Rows[0]["admin"]))
                    {
                        TxtCourseID.ReadOnly = Convert.ToBoolean(objBECommon.DtResult.Rows[0]["Courseid"]);
                        if (Convert.ToBoolean(objBECommon.DtResult.Rows[0]["Courseid"]))
                            TxtCourseID.CssClass = "readonly";

                        txtCourseName.ReadOnly = Convert.ToBoolean(objBECommon.DtResult.Rows[0]["CourseName"]);
                        if (Convert.ToBoolean(objBECommon.DtResult.Rows[0]["CourseName"]))
                            txtCourseName.CssClass = "readonly";
                    }
                }

            }
            catch (Exception Ex)
            {
                ErrorHandlers.ErrorLog.WriteError(Ex);
            }
        }


        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                BEAdmin objBEAdmin = new BEAdmin();
                BAdmin objBAdmin = new BAdmin();
                objBEAdmin.IntCourseID = Convert.ToInt32(Request.QueryString["CourseID"]);
                objBEAdmin.strCourseID = TxtCourseID.Text;
                lblCourseID.Text = TxtCourseID.Text;

                objBEAdmin.strCourseName = txtCourseName.Text;
                lblCourse.Text = txtCourseName.Text;
                objBEAdmin.IntstatusFlag = Convert.ToInt32(ddlStatus.SelectedValue.ToString());
                if (ddlStatus.SelectedValue.ToString() == "1")
                    lblStatus.Text = "Active";
                else
                    lblStatus.Text = "Inactive";
                objBAdmin.BUpdateCourseDetails(objBEAdmin);
                trMessage.Visible = true;
                if (objBEAdmin.IntResult == 1)
                {
                    lblInfo.Text = Resources.AppMessages.Admin_EditCourse_Success_CourseUpdated;
                    lblInfo.ForeColor = System.Drawing.Color.FromName(Resources.AppConfigurations.Color_Success);
                    ImgInfo.ImageUrl = Resources.AppConfigurations.Image_Success;
                    tdInfo.Attributes.Add("style", Resources.AppConfigurations.Color_Table_Success);
                    lblModifiedDate1.Text = DateTime.Now.ToShortDateString();
                    lblCourseID.Text = TxtCourseID.Text.ToString();
                    lblCourse.Text = txtCourseName.Text.ToString();
                    lblStatus.Text = ddlStatus.SelectedItem.Text.ToString();
                    trCourseEdit.Visible = false;
                    trCourseView.Visible = true;
                }
                else if (objBEAdmin.IntResult == 0)
                {
                    lblInfo.Text = Resources.AppMessages.Admin_EditCourse_Error_CourseExists;
                    lblInfo.ForeColor = System.Drawing.Color.FromName(Resources.AppConfigurations.Color_Error);
                    ImgInfo.ImageUrl = Resources.AppConfigurations.Image_Error;
                    tdInfo.Attributes.Add("style", Resources.AppConfigurations.Color_Table_Error);
                }
                else if (objBEAdmin.IntResult == 2)
                {
                    lblInfo.Text = Resources.AppMessages.Admin_EditCourse_Error_PendingExams;
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


    }
}
