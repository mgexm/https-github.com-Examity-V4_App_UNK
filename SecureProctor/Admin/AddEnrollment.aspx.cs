using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using BusinessEntities;
using Telerik.Web.UI;

namespace SecureProctor.Admin
{
    public partial class AddEnrollment : BaseClass
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                this.GetStudentName();
                this.BindProviderNames();
                trAddEnrollment.Visible = true;
                trAddEnrollmentConfirmation.Visible = false;

                this.Page.Title = EnumPageTitles.APPNAME + EnumPageTitles.ADMIN_ENROLLSTUDENT;

            }
            trMessage.Visible = false;


        }

        protected void GetStudentName()
        {
            try
            {
                BEAdmin objBEAdmin = new BEAdmin();
                BAdmin objBAdmin = new BAdmin();

                objBEAdmin.IntStudentID = Convert.ToInt32(Request.QueryString["StudentID"].ToString());
                objBAdmin.BGetStudentName(objBEAdmin);
                if (objBEAdmin.DtResult != null && objBEAdmin.DtResult.Rows.Count > 0)
                {


                    lblStudentName.Text = objBEAdmin.DtResult.Rows[0]["StudentName"].ToString();
                }
            }
            catch (Exception Ex)
            {
                ErrorHandlers.ErrorLog.WriteError(Ex);
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

                ddlCourse.AppendDataBoundItems = true;
                ddlCourse.Items.Add(new RadComboBoxItem("--Select Course--", "-1"));


            }

            else
            {
                ddlprovider.Items.Clear();
                ddlprovider.AppendDataBoundItems = true;
                ddlprovider.Items.Add(new RadComboBoxItem("--Select Instructor--", "-1"));
                ddlprovider.DataSource = null;
                ddlprovider.DataBind();
                ddlCourse.Items.Clear();
                ddlCourse.AppendDataBoundItems = true;
                ddlCourse.Items.Add(new RadComboBoxItem("--Select Course--", "-1"));
                ddlCourse.DataSource = null;
                ddlCourse.DataBind();


            }

        }

        protected void ddlProviderName_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            try
            {

                BEAdmin objBEAdmin = new BEAdmin();

                BAdmin objBAdmin = new BAdmin();

                objBEAdmin.IntProviderID = Convert.ToInt32(ddlprovider.SelectedValue);
                objBAdmin.BBindCourse(objBEAdmin);
                if (objBEAdmin.DtResult != null && objBEAdmin.DtResult.Rows.Count > 0)
                {
                    ddlCourse.Items.Clear();
                    ddlCourse.AppendDataBoundItems = true;
                    ddlCourse.Items.Add(new RadComboBoxItem("--Select Course--", "-1"));
                    ddlCourse.DataSource = objBEAdmin.DtResult.DefaultView;
                    ddlCourse.DataValueField = "CourseID";
                    ddlCourse.DataTextField = "CourseName";
                    ddlCourse.DataBind();
                }
                else
                {
                    ddlCourse.Items.Clear();
                    ddlCourse.AppendDataBoundItems = true;
                    ddlCourse.Items.Add(new RadComboBoxItem("--Select Course--", "-1"));
                    ddlCourse.DataSource = null;
                    ddlCourse.DataBind();

                }
            }
            catch
            {

            }


        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    BEAdmin objBEAdmin = new BEAdmin();
                    BAdmin objBAdmin = new BAdmin();
                    objBEAdmin.IntStudentID = Convert.ToInt32(Request.QueryString["StudentID"].ToString());
                    objBEAdmin.IntUserID = Convert.ToInt32(ddlprovider.SelectedValue.ToString());
                    objBEAdmin.IntCourseID = Convert.ToInt32(ddlCourse.SelectedValue.ToString());
                    objBAdmin.BAdminEnrollStudentCourse(objBEAdmin);
                    trMessage.Visible = true;
                    if (objBEAdmin.IntResult.ToString() == "1")
                    {
                        lblInfo.Text = Resources.AppMessages.Admin_Enrollment_Success_AddEnrollment;
                        lblInfo.ForeColor = System.Drawing.Color.FromName(Resources.AppConfigurations.Color_Success);
                        ImgInfo.ImageUrl = Resources.AppConfigurations.Image_Success;
                        tdInfo.Attributes.Add("style", Resources.AppConfigurations.Color_Table_Success);
                        lblStudentnameConfirmation.Text = lblStudentName.Text;
                        ddlCourse.Visible = false;
                        trUpdate.Visible = false;
                        lblInstructor.Visible = true;
                        ddlprovider.Visible = false;
                        lblInstuctorNameConfirm.Text = ddlprovider.SelectedItem.Text;
                        lblCourseNameConfirm.Text = ddlCourse.SelectedItem.Text;
                        trAddEnrollment.Visible = false;
                        trAddEnrollmentConfirmation.Visible = true;

                    }
                    else
                    {
                        lblInfo.Text = Resources.AppMessages.Admin_Enrollment_Error_AddEnrollment;
                        lblInfo.ForeColor = System.Drawing.Color.FromName(Resources.AppConfigurations.Color_Error);
                        ImgInfo.ImageUrl = Resources.AppConfigurations.Image_Error;
                        tdInfo.Attributes.Add("style", Resources.AppConfigurations.Color_Table_Error);
                        trAddEnrollment.Visible = true;
                        trAddEnrollmentConfirmation.Visible = false;

                    }
                }
            }
            catch
            {
            }




        }




    }
}