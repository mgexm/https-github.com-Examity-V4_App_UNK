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
    public partial class AdminEditEnrollment : BaseClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Page.Title = EnumPageTitles.APPNAME + EnumPageTitles.Admin_STUDENTREGISTRATION;
            ((LinkButton)this.Page.Master.FindControl("LnkStudentRegistration")).CssClass = "main_menu_active";
            if (!IsPostBack)
            {

                imgSuccess.Visible = false;
                trUpdate.Visible = true;
                if (Request.QueryString != null && Request.QueryString.ToString() != "")
                {

                    int EnrollID = Convert.ToInt32(AppSecurity.Decrypt(Request.QueryString["EnrollID"].ToString()));

                    Session["StudentID"] = EnrollID;

                    GetEnrollStudentDetails(EnrollID);

                }

            }
        }

        protected void GetEnrollStudentDetails(int EnrollID)
        {
            BECommon objBECommon = new BECommon();
            BCommon objBCommon = new BCommon();
            objBECommon.IntStudentID = EnrollID;
            objBCommon.BGetEnrollStudentDetails(objBECommon);
            if (objBECommon.DsResult.Tables[0].Rows.Count > 0)
            {

                lblStudentName.Text = objBECommon.DsResult.Tables[0].Rows[0]["StudentName"].ToString();
                lblEmailAddress.Text = objBECommon.DsResult.Tables[0].Rows[0]["EmailAddress"].ToString();
                lblGender.Text = objBECommon.DsResult.Tables[0].Rows[0]["GenderName"].ToString();
                lblCourseName.Text = objBECommon.DsResult.Tables[0].Rows[0]["CourseName"].ToString();
                string stat = objBECommon.DsResult.Tables[0].Rows[0]["EnrollmentStatus"].ToString();
                if (stat.ToLower() == "false")
                {
                    ddlStatus.SelectedValue = "0";
                }
                else if (stat.ToLower() == "true")
                {
                    ddlStatus.SelectedValue = "1";
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            BEProvider objBEExamProvider = new BEProvider();
            BProvider objBPrrovider = new BProvider();
            objBEExamProvider.ddlStatus = ddlStatus.SelectedValue.ToString();
            objBEExamProvider.IntStudentID = Convert.ToInt16(Session["StudentID"]);

            objBPrrovider.BUpdateStatus(objBEExamProvider);

            if (objBEExamProvider.IntResult == 1)
            {
                //lblMsg.Text = "Updated Successfully.";
                lblMsg.Text = Resources.ResMessages.Provider_EnrollUpdate;
                lblMsg.ForeColor = System.Drawing.Color.Green;
                GetEnrollStudentDetails(Convert.ToInt32(Session["StudentID"]));
                imgSuccess.Visible = true;
                trUpdate.Visible = false;
                lblStatus.Text = ddlStatus.SelectedItem.Text;
                ddlStatus.Visible = false;
                //lblStudentName.Visible = true;
                //txtStudentName.Visible = false;

                //lblEmailAddress.Visible = true;
                //txtEmailAddress.Visible = false;

                //lblGender.Visible = true;
                //ddlGender.Visible = false;

                //lblCourseName.Visible = true;
                //ddlCourseName.Visible = false;

                //btnUpdate.Visible = false;
                //btnEdit.Visible = true;                
            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

            Response.Redirect("AdminEnrollStudent.aspx", false);
        }
    }
}