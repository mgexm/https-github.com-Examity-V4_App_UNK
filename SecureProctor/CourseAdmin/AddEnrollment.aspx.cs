using System;
using BusinessEntities;
using BLL;
using Telerik.Web.UI;

namespace SecureProctor.CourseAdmin
{
    public partial class AddEnrollment : BaseClass
    {
        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                this.GetStudentName();
              //  this.BindCourseName();
                // BindProviderNames();
                BindCourseAdminSpecificProviders();
                this.Page.Title = EnumPageTitles.APPNAME + EnumPageTitles.EXAMPROVIDER_ENROLLSTUDENT;

            }
            trMessage.Visible = false;

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                BECourseAdmin objBECourseAdmin = new BECourseAdmin();
                BCourseAdmin objBCourseAdmin = new BCourseAdmin();
                objBECourseAdmin.IntUserID = Convert.ToInt32(ddlprovider.SelectedValue);
                objBECourseAdmin.IntCourseID = Convert.ToInt32(ddlCourse.SelectedValue);
                objBECourseAdmin.IntStudentID = Convert.ToInt32(Request.QueryString["StudentID"].ToString());
                lblCourse.Text = ddlCourse.SelectedItem.Text;
                lblInstructor.Text = ddlprovider.SelectedItem.Text;
                objBCourseAdmin.BProviderEnrollStudentCourse(objBECourseAdmin);
                trMessage.Visible = true;
                if (objBECourseAdmin.IntResult.ToString() == "1")
                {
                    lblInfo.Text = Resources.AppMessages.Provider_Enrollment_Success_AddEnrollment;
                    lblInfo.ForeColor = System.Drawing.Color.FromName(Resources.AppConfigurations.Color_Success);
                    ImgInfo.ImageUrl = Resources.AppConfigurations.Image_Success;
                    tdInfo.Attributes.Add("style", Resources.AppConfigurations.Color_Table_Success);
                    lblCourse.Visible = true;
                    ddlCourse.Visible = false;
                    lblInstructor.Visible = true;
                    ddlprovider.Visible = false;
                    trUpdate.Visible = false;
                }

                else
                {
                    lblInfo.Text = Resources.AppMessages.Provider_Enrollment_Error_AddEnrollment;
                    lblInfo.ForeColor = System.Drawing.Color.FromName(Resources.AppConfigurations.Color_Error);
                    ImgInfo.ImageUrl = Resources.AppConfigurations.Image_Error;
                    tdInfo.Attributes.Add("style", Resources.AppConfigurations.Color_Table_Error);
                    lblCourse.Visible = false;
                    ddlCourse.Visible = true;
                    trUpdate.Visible = true;
                }
            }

            catch (Exception Ex)
            {
                ErrorHandlers.ErrorLog.WriteError(Ex);

            }
        }

        protected void ddlProviderName_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            try
            {
                //BEAdmin objBEAdmin = new BEAdmin();

                //BAdmin objBAdmin = new BAdmin();

                //objBEAdmin.IntProviderID = Convert.ToInt32(ddlprovider.SelectedValue);
                //objBAdmin.BBindCourse(objBEAdmin);
                //if (objBEAdmin.DtResult != null && objBEAdmin.DtResult.Rows.Count > 0)
                //{
                //    ddlCourse.Items.Clear();
                //    ddlCourse.AppendDataBoundItems = true;
                //    ddlCourse.Items.Add(new RadComboBoxItem("--Select Course--", "-1"));
                //    ddlCourse.DataSource = objBEAdmin.DtResult.DefaultView;
                //    ddlCourse.DataValueField = "CourseID";
                //    ddlCourse.DataTextField = "CourseName";
                //    ddlCourse.DataBind();
                //}
                //else
                //{
                //    ddlCourse.Items.Clear();
                //    ddlCourse.AppendDataBoundItems = true;
                //    ddlCourse.Items.Add(new RadComboBoxItem("--Select Course--", "-1"));
                //    ddlCourse.DataSource = null;
                //    ddlCourse.DataBind();

                //}
                BindCourseAdminSpecificProviderCourses();
            }
            catch (Exception) { }
        }

        #endregion

        #region Methods

        protected void GetStudentName()
        {
            try
            {
                BECourseAdmin objBECourseAdmin = new BECourseAdmin();
                BCourseAdmin objBCourseAdmin = new BCourseAdmin();
                objBECourseAdmin.IntStudentID = Convert.ToInt32(Request.QueryString["StudentID"].ToString());
                objBCourseAdmin.BGetStudentName(objBECourseAdmin);
                if (objBECourseAdmin.DtResult != null && objBECourseAdmin.DtResult.Rows.Count > 0)
                {


                    lblStudentName.Text = objBECourseAdmin.DtResult.Rows[0]["StudentName"].ToString();
                }
            }
            catch (Exception Ex)
            {
                ErrorHandlers.ErrorLog.WriteError(Ex);
            }

        }

        protected void BindCourseName()
        {
            try
            {

                BECourseAdmin objBECourseAdmin = new BECourseAdmin();
                BCourseAdmin objBCourseAdmin = new BCourseAdmin();
                objBECourseAdmin.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID].ToString());
                objBCourseAdmin.BGetProviderCourseDetails(objBECourseAdmin);
                if (objBECourseAdmin.DtResult.Rows.Count > 0)
                {

                    ddlCourse.AppendDataBoundItems = true;
                    ddlCourse.Items.Add(new RadComboBoxItem("--Select Course--", "-1"));
                    ddlCourse.DataSource = objBECourseAdmin.DtResult;
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

        protected void BindCourseAdminSpecificProviders()
        {
            BECourseAdmin objBECourseAdmin = new BECourseAdmin();
            objBECourseAdmin.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID].ToString());
            new BCourseAdmin().BBindProviderNames(objBECourseAdmin);
            if (objBECourseAdmin.DtResult.Rows.Count > 0)
            {
                ddlprovider.AppendDataBoundItems = true;
                ddlprovider.Items.Add(new RadComboBoxItem("--Select Instructor--", "-1"));
                ddlprovider.DataSource = objBECourseAdmin.DtResult;
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

        protected void BindCourseAdminSpecificProviderCourses()
        {
            try
            {
                BECourseAdmin objBECourseAdmin = new BECourseAdmin();

                BCourseAdmin objBCourseAdmin = new BCourseAdmin();

                objBECourseAdmin.IntProviderID = Convert.ToInt32(ddlprovider.SelectedValue);
                objBECourseAdmin.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID].ToString());

                objBCourseAdmin.BBindCourseAdminSpecificProviderCourses(objBECourseAdmin);
                if (objBECourseAdmin.DtResult != null && objBECourseAdmin.DtResult.Rows.Count > 0)
                {
                    ddlCourse.Items.Clear();
                    ddlCourse.AppendDataBoundItems = true;
                    ddlCourse.Items.Add(new RadComboBoxItem("--Select Course--", "-1"));
                    ddlCourse.DataSource = objBECourseAdmin.DtResult.DefaultView;
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
            catch (Exception)
            {

            }
        }

        #endregion

    }
}