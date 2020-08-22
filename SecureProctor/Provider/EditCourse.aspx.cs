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
    


     public partial class EditCourse : BaseClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Page.Title = EnumPageTitles.APPNAME + EnumPageTitles.EXAMPROVIDER_EDITCOURSE_EDITCOURSE;

                if (Request.QueryString != null && Request.QueryString.ToString() != "")
                    GetSelectedCourseDetails();

                trView.Visible = false;
                trEdit.Visible = true;
            }
            trMessage.Visible = false;
        }

        private void GetSelectedCourseDetails()
        {
            try
            {
                BEProvider objBEExamProvider = new BEProvider();
                BProvider objBProvider = new BProvider();
                objBEExamProvider.IntCourseID = Convert.ToInt32(Request.QueryString["CourseID"].ToString());
                objBProvider.BGetSelectedCourseDetails(objBEExamProvider);
                if (objBEExamProvider.DtResult != null && objBEExamProvider.DtResult.Rows.Count > 0)
                {
                    TxtCourseID.Text = objBEExamProvider.DtResult.Rows[0]["Course_ID"].ToString();
                    txtCourseName.Text = objBEExamProvider.DtResult.Rows[0]["CourseName"].ToString();
                    ddlStatus.Items.FindItemByText(objBEExamProvider.DtResult.Rows[0]["Status"].ToString()).Selected = true;
                    lblCreatedDate.Text = objBEExamProvider.DtResult.Rows[0]["CreatedDate"].ToString();
                    lblCreatedDate1.Text = objBEExamProvider.DtResult.Rows[0]["CreatedDate"].ToString();
                    lblModifiedDate.Text = objBEExamProvider.DtResult.Rows[0]["ModifiedDate"].ToString();
                }

                BECommon objBECommon = new BECommon();
                BCommon objBCommon = new BCommon();
                objBECommon.iID = Convert.ToInt32(Request.QueryString["CourseID"].ToString());
                //to get course lms settings
                objBECommon.iTypeID = 2;

                objBCommon.BGetLMSSettings(objBECommon);

                if (objBECommon.DtResult != null && objBECommon.DtResult.Rows.Count > 0)
                {
                    if (!Convert.ToBoolean(objBECommon.DtResult.Rows[0]["instructor"]))
                    {
                        TxtCourseID.ReadOnly = Convert.ToBoolean(objBECommon.DtResult.Rows[0]["Courseid"]);
                        if (Convert.ToBoolean(objBECommon.DtResult.Rows[0]["Courseid"]))
                        {
                            TxtCourseID.CssClass = "readonly";
                            RequiredFieldValidator1.Enabled = false;
                        }

                        txtCourseName.ReadOnly = Convert.ToBoolean(objBECommon.DtResult.Rows[0]["CourseName"]);
                        if (Convert.ToBoolean(objBECommon.DtResult.Rows[0]["CourseName"]))
                        {
                            txtCourseName.CssClass = "readonly";
                            RequiredFieldValidator2.Enabled = false;
                        }
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
                BEProvider objBEExamProvider = new BEProvider();
                BProvider objBProvider = new BProvider();
                objBEExamProvider.IntCourseID = Convert.ToInt32(Request.QueryString["CourseID"]);
                objBEExamProvider.strCourseID = TxtCourseID.Text;
                lblCourseID.Text = TxtCourseID.Text;

                objBEExamProvider.strCourseName = txtCourseName.Text;
                lblCourse.Text = txtCourseName.Text;
                objBEExamProvider.IntstatusFlag = Convert.ToInt32(ddlStatus.SelectedValue.ToString());
                if (ddlStatus.SelectedValue.ToString() == "1")
                    lblStatus.Text = "Active";
                else
                    lblStatus.Text = "Inactive";
                objBEExamProvider.IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID].ToString());
                objBProvider.BUpdateCourseDetails(objBEExamProvider);
                trMessage.Visible = true;
                if (objBEExamProvider.IntResult == 1)
                {
                    lblInfo.Text = Resources.AppMessages.Provider_EditCourse_Success_CourseUpdated;
                    lblInfo.ForeColor = System.Drawing.Color.FromName(Resources.AppConfigurations.Color_Success);
                    ImgInfo.ImageUrl = Resources.AppConfigurations.Image_Success;
                    tdInfo.Attributes.Add("style", Resources.AppConfigurations.Color_Table_Success);
                    trView.Visible = true;
                    trEdit.Visible = false;
                    lblModifiedDate1.Text = DateTime.Now.ToShortDateString();
                }
                else if (objBEExamProvider.IntResult == 0)
                {                    
                    lblInfo.Text = Resources.AppMessages.Provider_EditCourse_Error_CourseExists;
                    lblInfo.ForeColor = System.Drawing.Color.FromName(Resources.AppConfigurations.Color_Error);
                    ImgInfo.ImageUrl = Resources.AppConfigurations.Image_Error;
                    tdInfo.Attributes.Add("style", Resources.AppConfigurations.Color_Table_Error);
                }
                else if (objBEExamProvider.IntResult == 2)
                {                   
                    lblInfo.Text = Resources.AppMessages.Provider_EditCourse_Error_PendingExams;
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


