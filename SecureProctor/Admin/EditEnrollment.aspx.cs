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
    public partial class EditEnrollment : BaseClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                this.Page.Title = EnumPageTitles.APPNAME + EnumPageTitles.ADMIN_EDITSTUDENTEXAMENROLLMENT;

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
                string status = objBEAdmin.DsResult.Tables[0].Rows[0]["EnrollmentStatus"].ToString();
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

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            BEAdmin objBEAdmin = new BEAdmin();
            BAdmin objBAdmin = new BAdmin();

            objBEAdmin.ddlStatus = ddlStatus.SelectedValue.ToString();
            objBEAdmin.IntEnrollID = Convert.ToInt32(Request.QueryString["EnrollmentID"].ToString());

            objBAdmin.BUpdateEnrollStatus(objBEAdmin);
            trMessage.Visible = true;
            if (objBEAdmin.IntResult == 1)
            {

                ddlStatus.Visible = false;
                lblStatus.Text = ddlStatus.SelectedItem.Text;
                lblInfo.Text = Resources.AppMessages.Admin_EditEnrollment_Success_EditEnrollmentStatus;
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
                lblInfo.Text = Resources.AppMessages.Admin_EditEnrollment_Error_EditEnrollmentStatus;
                lblInfo.ForeColor = System.Drawing.Color.FromName(Resources.AppConfigurations.Color_Error);
                ImgInfo.ImageUrl = Resources.AppConfigurations.Image_Error;
                tdInfo.Attributes.Add("style", Resources.AppConfigurations.Color_Table_Error);

            }

        }
    }
}