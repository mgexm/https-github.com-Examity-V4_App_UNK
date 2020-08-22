using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using BusinessEntities;

namespace SecureProctor.CourseAdmin
{
    public partial class EditEnrollment : BaseClass
    {

        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Page.Title = EnumPageTitles.APPNAME + "Edit Enrollment";
                this.GetEnrollStudentDetails();
            }
            trMessage.Visible = false;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            BECourseAdmin objBEExamProvider = new BECourseAdmin();
            BCourseAdmin objBPrrovider = new BCourseAdmin();
            objBEExamProvider.ddlStatus = ddlStatus.SelectedValue.ToString();
            objBEExamProvider.IntEnrollID = Convert.ToInt32(Request.QueryString["EnrollmentID"].ToString());

            objBPrrovider.BUpdateEnrollStatus(objBEExamProvider);
            trMessage.Visible = true;
            if (objBEExamProvider.IntResult == 1)
            {

                ddlStatus.Visible = false;
                lblStatus.Text = ddlStatus.SelectedItem.Text;
                lblInfo.Text = Resources.AppMessages.Provider_EditEnrollment_Success_EditEnrollmentStatus;
                lblInfo.ForeColor = System.Drawing.Color.FromName(Resources.AppConfigurations.Color_Success);
                ImgInfo.ImageUrl = Resources.AppConfigurations.Image_Success;
                tdInfo.Attributes.Add("style", Resources.AppConfigurations.Color_Table_Success);
                btnUpdate.Visible = false;
                btnCancel.Visible = false;

            }

            else
            {
                btnUpdate.Visible = true;
                btnCancel.Visible = true;
                ddlStatus.Visible = true;
                lblInfo.Text = Resources.AppMessages.Provider_EditEnrollment_Error_EditEnrollmentStatus;
                lblInfo.ForeColor = System.Drawing.Color.FromName(Resources.AppConfigurations.Color_Error);
                ImgInfo.ImageUrl = Resources.AppConfigurations.Image_Error;
                tdInfo.Attributes.Add("style", Resources.AppConfigurations.Color_Table_Error);

            }

        }

        #endregion

        #region Methods

        protected void GetEnrollStudentDetails()
        {
            BECourseAdmin objBEProvider = new BECourseAdmin();
            BCourseAdmin objBProvider = new BCourseAdmin();
            objBEProvider.IntEnrollID = Convert.ToInt32(Request.QueryString["EnrollmentID"].ToString());
            objBProvider.BGetEnrollStudentDetails(objBEProvider);
            if (objBEProvider.DsResult.Tables[0].Rows.Count > 0)
            {

                lblStudentName.Text = objBEProvider.DsResult.Tables[0].Rows[0]["StudentName"].ToString();
                lblEmailAddress.Text = objBEProvider.DsResult.Tables[0].Rows[0]["EmailAddress"].ToString();
                lblCourseName.Text = objBEProvider.DsResult.Tables[0].Rows[0]["CourseName"].ToString();
                string status = objBEProvider.DsResult.Tables[0].Rows[0]["EnrollmentStatus"].ToString();
                if (status.ToLower() == "false")
                {
                    ddlStatus.SelectedValue = "0";
                }
                else if (status.ToLower() == "true")
                {
                    ddlStatus.SelectedValue = "1";
                }
            }
        }

        #endregion

    }
}