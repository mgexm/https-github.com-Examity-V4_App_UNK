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
    public partial class EditCourseDetails : BaseClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((LinkButton)this.Page.Master.FindControl("lnkCourses")).CssClass = "main_menu_active";
            if (!IsPostBack)
            {
                if (Request.QueryString != null && Request.QueryString.ToString() != "")
                    GetCourseEditDetails();             
            }
        }


        private void GetCourseEditDetails()
        {
            try
            {
                BEAdmin objBEAdmin = new BEAdmin();
                BAdmin objBAdmin = new BAdmin();

                objBEAdmin.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID].ToString());

                objBEAdmin.IntCourseID = Convert.ToInt32(AppSecurity.Decrypt(Request.QueryString["CourseID"]));
                objBAdmin.BGetCourseDetails(objBEAdmin);
                if (objBEAdmin.DtResult != null && objBEAdmin.DtResult.Rows.Count > 0)
                {

                    TxtCourseID.Text = objBEAdmin.DtResult.Rows[0]["Course_ID"].ToString();
                    txtCourseName.Text = objBEAdmin.DtResult.Rows[0]["CourseName"].ToString();
                    //lblProviderName.Text = objBEAdmin.DtResult.Rows[0]["ProviderName"].ToString();
                    lblProviderName.Text = objBEAdmin.DtResult.Rows[0]["ProviderFirstName"].ToString() + ' ' + objBEAdmin.DtResult.Rows[0]["ProviderLastName"].ToString();

                }
                else
                {
                    TxtCourseID.Text = string.Empty;
                    txtCourseName.Text = string.Empty;
                    lblProviderName.Text = string.Empty;

                }
  
                
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                BEAdmin objBEAdmin = new BEAdmin();
                BAdmin objBAdmin = new BAdmin();
                //objBEAdmin.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID].ToString());
                objBEAdmin.IntProviderID = Convert.ToInt32(AppSecurity.Decrypt(Request.QueryString["ExamProviderID"]));
                objBEAdmin.IntCourseID = Convert.ToInt32(AppSecurity.Decrypt(Request.QueryString["CourseID"]));
                objBEAdmin.strCourseID = TxtCourseID.Text;
                objBEAdmin.strCourseName = txtCourseName.Text;
                objBAdmin.BUpdateCourseDetails(objBEAdmin);
                if (objBEAdmin.DsResult.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToInt32(objBEAdmin.DsResult.Tables[0].Rows[0][0]) == 1)
                    {

                        lblSuccess.Text = Resources.ResMessages.Provider_CourseEditSuccess;
                        lblCourseID.Visible = true;
                        lblCourseID.Text = TxtCourseID.Text;
                        lblCourseName.Visible = true;
                        lblCourseName.Text = txtCourseName.Text;
                        btnUpdate.Visible = false;
                        TxtCourseID.Visible = false;
                        txtCourseName.Visible = false;
                        btnBack.Visible = true;
                        // lblModifiedDate.Text = DateTime.Now.ToShortDateString();
                        lblSuccess.Visible = true;
                        lblSuccess.ForeColor = System.Drawing.Color.Green;
                        imgSuccess.Visible = true;
                    }
                    else
                    {
                        TxtCourseID.Visible = true;
                        txtCourseName.Visible = true;
                        lblSuccess.Text = Resources.ResMessages.Provider_CourseEditFailed;
                        lblSuccess.ForeColor = System.Drawing.Color.Red;
                        btnUpdate.Visible = true;

                        btnBack.Visible = true;
                        lblSuccess.Visible = true;

                        imgSuccess.Visible = false;
                    }
                }
            }
        }


        protected void btnBack_Click(object sender, EventArgs e)
        {
            //Response.Redirect(BaseClass.EnumAppPage.ADMIN_VIEWCOURSE + "?Type=C");
            Response.Redirect(BaseClass.EnumAppPage.ADMIN_VIEWCOURSE);
        }    
    }
}