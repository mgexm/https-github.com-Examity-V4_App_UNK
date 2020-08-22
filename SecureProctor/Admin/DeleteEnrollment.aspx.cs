using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessEntities;
using BLL;

namespace SecureProctor.Admin
{
    public partial class DeleteEnrollment : BaseClass
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Page.Title = EnumPageTitles.APPNAME + EnumPageTitles.ADMIN_DELETESTUDENTEXAMENROLLMENT;
                this.GetEnrollStudentDetails();

            }
            trMessage.Visible = false;

        }

        protected void GetEnrollStudentDetails()
        {
            BEAdmin objBEAdmin = new BEAdmin();
            BAdmin objBAdmin = new BAdmin();
            objBEAdmin.IntEnrollID = Convert.ToInt32(Request.QueryString["EnrollmentID"].ToString());
            objBAdmin.BGetEnrollStudentDetails(objBEAdmin);
            if (objBEAdmin.DsResult.Tables[0].Rows.Count > 0)
            {

                lblStudentName.Text = objBEAdmin.DsResult.Tables[0].Rows[0]["StudentName"].ToString();
                lblEmailAddress.Text = objBEAdmin.DsResult.Tables[0].Rows[0]["EmailAddress"].ToString();
                lblCourseName.Text = objBEAdmin.DsResult.Tables[0].Rows[0]["CourseName"].ToString();
                if (objBEAdmin.DsResult.Tables[0].Rows[0]["EnrollmentStatus"].ToString() == "True")
                {
                    lblStatus.Text = "Active";

                }
                if (objBEAdmin.DsResult.Tables[0].Rows[0]["EnrollmentStatus"].ToString() == "False")
                {

                    lblStatus.Text = "InActive";
                }
            }

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            BEAdmin objBEAdmin = new BEAdmin();
            BAdmin objBAdmin = new BAdmin();

            objBEAdmin.IntEnrollID = Convert.ToInt32(Request.QueryString["EnrollmentID"].ToString());

            objBAdmin.BDeleteEnrollmentStatus(objBEAdmin);
            trMessage.Visible = true;
            if (objBEAdmin.IntResult == 1)
            {

                lblInfo.Text = Resources.AppMessages.Admin_DeleteEnrollment_Success_DeleteEnrollmentStatus;
                lblInfo.ForeColor = System.Drawing.Color.FromName(Resources.AppConfigurations.Color_Success);
                btnDelete.Visible = false;
                btnCancel.Visible = false;
                ImgInfo.ImageUrl = Resources.AppConfigurations.Image_Success;
                tdInfo.Attributes.Add("style", Resources.AppConfigurations.Color_Table_Success);
            }
            else
            {
                lblInfo.Text = Resources.AppMessages.Admin_DeleteEnrollment_Error_DeleteEnrollmentStatus;
                lblInfo.ForeColor = System.Drawing.Color.FromName(Resources.AppConfigurations.Color_Error);
                btnDelete.Visible = false;
                btnCancel.Visible = false;
                ImgInfo.ImageUrl = Resources.AppConfigurations.Image_Error;
                tdInfo.Attributes.Add("style", Resources.AppConfigurations.Color_Table_Error);

            }



        }

    }
}