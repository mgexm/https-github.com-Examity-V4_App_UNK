using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessEntities;
using BLL;

namespace SecureProctor.CourseAdmin
{
    public partial class DeleteEnrollment : BaseClass
    {
        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Page.Title = EnumPageTitles.APPNAME + EnumPageTitles.EXAMPROVIDER_DELETESTUDENTEXAMENROLLMENT;
                this.GetEnrollStudentDetails();

            }
            trMessage.Visible = false;

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            BECourseAdmin objBEExamProvider = new BECourseAdmin();

            BCourseAdmin objBPrrovider = new BCourseAdmin();

            objBEExamProvider.IntEnrollID = Convert.ToInt32(Request.QueryString["EnrollmentID"].ToString());

            objBPrrovider.BDeleteEnrollmentStatus(objBEExamProvider);
            trMessage.Visible = true;
            if (objBEExamProvider.IntResult == 1)
            {
                lblInfo.Text = Resources.AppMessages.Provider_DeleteEnrollment_Success_DeleteEnrollmentStatus;
                lblInfo.ForeColor = System.Drawing.Color.FromName(Resources.AppConfigurations.Color_Success);
                btnDelete.Visible = false;
                btnCancel.Visible = false;
                ImgInfo.ImageUrl = Resources.AppConfigurations.Image_Success;
                tdInfo.Attributes.Add("style", Resources.AppConfigurations.Color_Table_Success);
            }
            else
            {
                lblInfo.Text = Resources.AppMessages.Provider_DeleteEnrollment_Error_DeleteEnrollmentStatus;
                lblInfo.ForeColor = System.Drawing.Color.FromName(Resources.AppConfigurations.Color_Error);
                btnDelete.Visible = false;
                btnCancel.Visible = false;
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
                if (objBEProvider.DsResult.Tables[0].Rows[0]["EnrollmentStatus"].ToString() == "True")
                {
                    lblStatus.Text = "Active";
                }
                if (objBEProvider.DsResult.Tables[0].Rows[0]["EnrollmentStatus"].ToString() == "False")
                {
                    lblStatus.Text = "InActive";
                }
            }
        }

        #endregion        
    }
}