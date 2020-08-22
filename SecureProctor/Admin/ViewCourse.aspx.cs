using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessEntities;
using BLL;
using Telerik.Web.UI;

namespace SecureProctor.Admin
{
    public partial class ViewCourse : BaseClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Page.Title = EnumPageTitles.APPNAME + EnumPageTitles.ADMIN_VIEWCOURSE;
            ((LinkButton)this.Page.Master.FindControl("lnkCourses")).CssClass = "main_menu_active";

            if (!IsPostBack)
            {
                BindProviderNames();
            }
        }

        protected void gvCourseStatus_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            try
            {
                this.LoadDataTable();
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        protected void LoadDataTable()
        {
            BEAdmin objBEAdmin = new BEAdmin();
            BAdmin objBAdmin = new BAdmin();
            objBEAdmin.IntCourseID = 0;
            objBAdmin.BGetCourseDetails(objBEAdmin);

            if (objBEAdmin.DtResult!=null && objBEAdmin.DtResult.Rows.Count > 0)
            {               
                gvCourseStatus.DataSource = objBEAdmin.DtResult;                
            }
            else
            {
                gvCourseStatus.DataSource = new string[] { };                
            }            
        }

        protected void gvCourseStatus_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName.ToString() == "EditCourse")
            {
                string courseprov = e.CommandArgument.ToString();
                if (courseprov.Contains(','))
                {
                    string[] cpid = courseprov.Split(',');
                    Response.Redirect("EditCourseDetails.aspx?CourseID=" + AppSecurity.Encrypt(cpid[0]) + "&ExamProviderID=" + AppSecurity.Encrypt(cpid[1]) + "");
                }
            }
        }

        protected void BindProviderNames()
        {
            BECommon objBECommon = new BECommon();
            new BCommon().BindProviderNames(objBECommon);
            if (objBECommon.DtResult.Rows.Count > 0)
            {
                ddlprovider.AppendDataBoundItems = true;
                ddlprovider.Items.Add(new RadComboBoxItem("--Select Instructor--", "-1"));
                ddlprovider.DataSource = objBECommon.DtResult;
                ddlprovider.DataTextField = "Name";
                ddlprovider.DataValueField = "ExamProviderID";
                ddlprovider.DataBind();
            }
            else
            {
                ddlprovider.Items.Clear();
                ddlprovider.AppendDataBoundItems = true;
                ddlprovider.Items.Add(new RadComboBoxItem("--Select Instructor--", "-1"));
                ddlprovider.DataSource = null;
                ddlprovider.DataBind();
            }
        }

        protected void BtnSaveCourse_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                BEAdmin objBEAdmin = new BEAdmin();
                BAdmin objBAdmin = new BAdmin();
                objBEAdmin.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID].ToString());
                //objBEExamProvider.IntCourseID = Convert.ToInt32(AppSecurity.Decrypt(Request.QueryString["CourseID"]));
                objBEAdmin.strCourseID = txtCourseID.Text;
                objBEAdmin.strCourseName = txtCourseName.Text;
                objBEAdmin.IntProviderID = Convert.ToInt32(ddlprovider.SelectedValue);
                objBAdmin.BSaveCourseDetails(objBEAdmin);
                if (objBEAdmin.DsResult.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToInt32(objBEAdmin.DsResult.Tables[0].Rows[0][0]) == 1)
                    {
                        lblSuccess.Text = Resources.ResMessages.Provider_CourseSuccess;
                        lblSuccess.Visible = true;
                        lblSuccess.ForeColor = System.Drawing.Color.Green;
                        txtCourseID.Text = string.Empty;
                        txtCourseName.Text = string.Empty;
                        ddlprovider.SelectedIndex = 0;
                        gvCourseStatus.Rebind();
                    }
                    else
                    {
                        lblSuccess.Text = Resources.ResMessages.Provider_CourseExists;
                        lblSuccess.ForeColor = System.Drawing.Color.Red;
                        lblSuccess.Visible = true;
                    }
                    //LoadDataTable();
                }
            }
        }

        protected void BtnClear_Click(object sender, EventArgs e)
        {
            txtCourseID.Text = string.Empty;
            txtCourseName.Text = string.Empty;
            ddlprovider.SelectedIndex = 0;
            lblSuccess.Text = string.Empty;



        }

        protected void lblExamDetailslink_Click(object sender, EventArgs e)
        {
            //Response.Redirect("ProcessedExamRequests.aspx");
            Response.Redirect(BaseClass.EnumAppPage.ADMIN_EXAMDETAILS);
        }
    }
}