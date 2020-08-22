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
    public partial class AdminDeleteEnrollment : BaseClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Page.Title = EnumPageTitles.APPNAME + EnumPageTitles.Admin_STUDENTREGISTRATION;
            ((LinkButton)this.Page.Master.FindControl("LnkStudentRegistration")).CssClass = "main_menu_active";
            if (!IsPostBack)
            {
                imgSuccess.Visible = false;
                trDelete.Visible = true;
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
                if (objBECommon.DsResult.Tables[0].Rows[0]["EnrollmentStatus"].ToString() == "True")
                {
                    lblStatus.Text = "Active";

                }
                if (objBECommon.DsResult.Tables[0].Rows[0]["EnrollmentStatus"].ToString() == "False")
                {

                    lblStatus.Text = "InActive";
                }

            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            BEProvider objBEExamProvider = new BEProvider();
            BProvider objBPrrovider = new BProvider();

            objBEExamProvider.IntStudentID = Convert.ToInt16(Session["StudentID"]);

            objBPrrovider.BDeleteStatus(objBEExamProvider);

            if (objBEExamProvider.IntResult == 1)
            {
                //lblMsg.Text = "Deleted Successfully.";
                lblMsg.Text = Resources.ResMessages.Provider_DeleteEnrollment;
                lblMsg.ForeColor = System.Drawing.Color.Green;
                imgSuccess.Visible = true;
                trDelete.Visible = false;
            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminEnrollStudent.aspx", false);

        }
    }
}