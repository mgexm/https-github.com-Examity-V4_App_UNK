using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using BusinessEntities;
using Telerik.Web.UI;
using System.Data;

namespace SecureProctor.CourseAdmin
{
    public partial class AddStudent : BaseClass
    {
        #region GlobalDeclarations
        const int Length = 8;
        #endregion

        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Page.Title = EnumPageTitles.APPNAME + EnumPageTitles.COURSEADMIN_ADDSTUDENT;
                trEnrollStudent.Visible = true;
                trAddStudent.Visible = false;
                trAddStudentConfirm.Visible = false;
                trEnrollStudentConfirmation.Visible = false;
                this.getAllStudents();
                this.BindCourseAdminSpecificProviders();
                //this.getProviderCourses();
                // this.getProviderNewCourses();

            }
            trMessage.Visible = false;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {

            BECourseAdmin objBECourseAdmin = new BECourseAdmin();
            BCourseAdmin objBCourseAdmin = new BCourseAdmin();

            objBECourseAdmin.strFirstName = txtFirstName.Text;
            lblFirstName.Text = txtFirstName.Text;
            objBECourseAdmin.strLastName = txtLastName.Text;
            lblLastName.Text = txtLastName.Text;
            objBECourseAdmin.strEmailAddress = txtEmailAddress.Text;
            lblEmailAddress.Text = txtEmailAddress.Text;
            objBECourseAdmin.StrComments = txtcomments.Value;
            lblComments.Text = txtcomments.Value;
            lblNewCourse.Text = rcbNewCourses.SelectedItem.Text.ToString();
            objBECourseAdmin.IntCourseID = Convert.ToInt32(rcbNewCourses.SelectedValue);
            objBECourseAdmin.IntProviderID = Convert.ToInt32(ddlprovider1.SelectedValue);
            objBECourseAdmin.strPassword = GetRandomPassword(Length);

            objBECourseAdmin.strUserName = txtUserID.Text;
            lblUserName.Text = txtUserID.Text;
            trMessage.Visible = true;
            if (ChkSpecialNeeds.Checked == true)
            {
                objBECourseAdmin.strSpecialNeeds = true;
                lblSpecialNeeds.Text = "Yes";
            }
            else
            {
                objBECourseAdmin.strSpecialNeeds = false;
                lblSpecialNeeds.Text = "No";
            }
            objBCourseAdmin.BAddStudent(objBECourseAdmin);
            if (objBECourseAdmin.IntResult == 0)
            {
                lblInfo.Text = Resources.AppMessages.Provider_AddStudent_Error_AddStudent;
                lblInfo.ForeColor = System.Drawing.Color.FromName(Resources.AppConfigurations.Color_Error);
                ImgInfo.ImageUrl = Resources.AppConfigurations.Image_Error;
                tdInfo.Attributes.Add("style", Resources.AppConfigurations.Color_Table_Error);
                trAddStudent.Visible = true;
                trAddStudentConfirm.Visible = false;
                trEnrollStudent.Visible = false;
                trEnrollStudentConfirmation.Visible = false;

            }

            if (objBECourseAdmin.IntResult == 1)
            {
                lblInfo.Text = Resources.AppMessages.Provider_AddStudent_Success_AddStudent;
                lblInfo.ForeColor = System.Drawing.Color.FromName(Resources.AppConfigurations.Color_Success);
                ImgInfo.ImageUrl = Resources.AppConfigurations.Image_Success;
                tdInfo.Attributes.Add("style", Resources.AppConfigurations.Color_Table_Success);
                trAddStudent.Visible = false;
                trAddStudentConfirm.Visible = true;
                trEnrollStudent.Visible = false;
                trEnrollStudentConfirmation.Visible = false;
            }

        }

        protected void btnStudentSave_Click(object sender, EventArgs e)
        {
            trMessage.Visible = true;
            lblStudentName.Text = rcbStudents.SelectedItem.Text.ToString();
            lblCourseName.Text = rcbCourses.SelectedItem.Text.ToString();
            lblInstructor.Text = ddlprovider.SelectedItem.Text.ToString();


            BECourseAdmin objBECourseAdmin = new BECourseAdmin();
            BCourseAdmin objBCourseAdmin = new BCourseAdmin();
            objBECourseAdmin.IntStudentID = Convert.ToInt32(rcbStudents.SelectedValue);
            objBECourseAdmin.IntCourseID = Convert.ToInt32(rcbCourses.SelectedValue);
            objBECourseAdmin.IntUserID = Convert.ToInt32(ddlprovider.SelectedValue);
            //Session[BaseClass.EnumPageSessions.USERID].ToString()

            objBCourseAdmin.BProviderEnrollStudent(objBECourseAdmin);
            if (objBECourseAdmin.IntResult.ToString() == "1")
            {
                lblInfo.Text = Resources.AppMessages.Provider_AddStudent_Success_AddStudent;
                lblInfo.ForeColor = System.Drawing.Color.FromName(Resources.AppConfigurations.Color_Success);
                ImgInfo.ImageUrl = Resources.AppConfigurations.Image_Success;
                trAddStudent.Visible = false;
                trAddStudentConfirm.Visible = false;
                trEnrollStudent.Visible = false;
                trEnrollStudentConfirmation.Visible = true;

            }
            else
            {
                lblInfo.Text = "Selected course already enrolled by selected student";
                lblInfo.ForeColor = System.Drawing.Color.FromName(Resources.AppConfigurations.Color_Error);
                ImgInfo.ImageUrl = Resources.AppConfigurations.Image_Error;
                trAddStudent.Visible = false;
                trAddStudentConfirm.Visible = false;
                trEnrollStudent.Visible = true;
                trEnrollStudentConfirmation.Visible = false;


            }

        }

        protected void lnkNewStudent_Click(object sender, EventArgs e)
        {
            trAddStudent.Visible = true;
            trAddStudentConfirm.Visible = false;
            trEnrollStudent.Visible = false;
            trEnrollStudentConfirmation.Visible = false;
            // getProviderNewCourses();
            BindCourseAdminSpecificProviderForNewStudent();
        }

        protected void lnkAdd_Click(object sender, EventArgs e)
        {
            trAddStudent.Visible = false;
            trAddStudentConfirm.Visible = false;
            trEnrollStudent.Visible = true;
            trEnrollStudentConfirmation.Visible = false;

        }

        protected void ddlprovider_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            BindCourseAdminSpecificProviderCourses();

        }

        protected void ddlprovider1_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            BindCourseAdminSpecificProviderCoursesNew();
        }

        #endregion

        #region Methods

        protected void getAllStudents()
        {
            BECourseAdmin objBECourseAdmin = new BECourseAdmin();
            BCourseAdmin objBCourseAdmin = new BCourseAdmin();
            objBECourseAdmin.IntProviderID = Convert.ToInt32(Session[EnumPageSessions.USERID]);
            objBCourseAdmin.BGetAllStudents(objBECourseAdmin);
            if (objBECourseAdmin.DtResult != null && objBECourseAdmin.DtResult.Rows.Count > 0)
            {
                rcbStudents.DataSource = objBECourseAdmin.DtResult;
                rcbStudents.DataBind();

            }
            else
            {
                rcbStudents.DataSource = new string[] { };
                rcbStudents.DataBind();

            }
        }

        protected void getProviderCourses()
        {
            BECourseAdmin objBECourseAdmin = new BECourseAdmin();
            BCourseAdmin objBCourseAdmin = new BCourseAdmin();
            objBECourseAdmin.IntProviderID = Convert.ToInt32(Session[EnumPageSessions.USERID]);
            objBCourseAdmin.BGetProviderCourses(objBECourseAdmin);
            if (objBECourseAdmin.DtResult != null && objBECourseAdmin.DtResult.Rows.Count > 0)
            {
                rcbCourses.DataSource = objBECourseAdmin.DtResult;
                rcbCourses.DataBind();

            }
            else
            {
                rcbCourses.DataSource = new string[] { };
                rcbCourses.DataBind();

            }
        }

        protected void getProviderNewCourses()
        {
            BECourseAdmin objBECourseAdmin = new BECourseAdmin();
            BCourseAdmin objBCourseAdmin = new BCourseAdmin();
            objBECourseAdmin.IntProviderID = Convert.ToInt32(Session[EnumPageSessions.USERID]);
            objBCourseAdmin.BGetProviderCourses(objBECourseAdmin);
            if (objBECourseAdmin.DtResult != null && objBECourseAdmin.DtResult.Rows.Count > 0)
            {
                rcbNewCourses.DataSource = objBECourseAdmin.DtResult;
                rcbNewCourses.DataBind();

            }
            else
            {
                rcbNewCourses.DataSource = new string[] { };
                rcbNewCourses.DataBind();

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
                // ddlprovider.Items.Add(new RadComboBoxItem("--Select Instructor--", "-1"));
                ddlprovider.DataSource = objBECourseAdmin.DtResult;
                ddlprovider.DataTextField = "Name";
                ddlprovider.DataValueField = "ExamProviderID";
                ddlprovider.DataBind();

                rcbCourses.AppendDataBoundItems = true;
                // rcbCourses.Items.Add(new RadComboBoxItem("--Select Course--", "-1"));


            }

            else
            {
                ddlprovider.Items.Clear();
                ddlprovider.AppendDataBoundItems = true;
                //ddlprovider.Items.Add(new RadComboBoxItem("--Select Instructor--", "-1"));
                ddlprovider.DataSource = null;
                ddlprovider.DataBind();
                rcbCourses.Items.Clear();
                rcbCourses.AppendDataBoundItems = true;
                // rcbCourses.Items.Add(new RadComboBoxItem("--Select Course--", "-1"));
                rcbCourses.DataSource = null;
                rcbCourses.DataBind();


            }

        }

        protected void BindCourseAdminSpecificProviderForNewStudent()
        {
            BECourseAdmin objBECourseAdmin = new BECourseAdmin();
            objBECourseAdmin.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID].ToString());
            new BCourseAdmin().BBindProviderNames(objBECourseAdmin);
            if (objBECourseAdmin.DtResult.Rows.Count > 0)
            {
                //ddlprovider1.AppendDataBoundItems = true;           
                ddlprovider1.DataSource = objBECourseAdmin.DtResult;
                ddlprovider1.DataTextField = "Name";
                ddlprovider1.DataValueField = "ExamProviderID";
                ddlprovider1.DataBind();
                //rcbCourses.AppendDataBoundItems = true;
            }

            else
            {
                ddlprovider1.Items.Clear();
                //ddlprovider1.AppendDataBoundItems = true;
                ddlprovider1.DataSource = null;
                ddlprovider1.DataBind();
                rcbCourses.Items.Clear();
                //rcbCourses.AppendDataBoundItems = true;
                rcbCourses.DataSource = null;
                rcbCourses.DataBind();
            }
        }

        protected void BindCourseAdminSpecificProviderCoursesNew()
        {
            BECourseAdmin objBECourseAdmin = new BECourseAdmin();

            BCourseAdmin objBCourseAdmin = new BCourseAdmin();
            try
            {
                objBECourseAdmin.IntProviderID = Convert.ToInt32(ddlprovider1.SelectedValue);
                objBECourseAdmin.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID].ToString());

                objBCourseAdmin.BBindCourseAdminSpecificProviderCourses(objBECourseAdmin);

                if (objBECourseAdmin.DtResult != null && objBECourseAdmin.DtResult.Rows.Count > 0)
                {
                    rcbNewCourses.Items.Clear();
                    //rcbNewCourses.AppendDataBoundItems = true;
                    rcbNewCourses.DataSource = objBECourseAdmin.DtResult;
                    rcbNewCourses.DataValueField = "CourseID";
                    rcbNewCourses.DataTextField = "CourseName";
                    rcbNewCourses.DataBind();
                }
                else
                {
                    rcbNewCourses.Items.Clear();
                    //rcbNewCourses.AppendDataBoundItems = true;
                    rcbNewCourses.DataSource = null;
                    rcbNewCourses.DataBind();

                }
            }
            catch (Exception)
            {

            }

        }

        protected void BindCourseAdminSpecificProviderCourses()
        {
            BECourseAdmin objBECourseAdmin = new BECourseAdmin();

            BCourseAdmin objBCourseAdmin = new BCourseAdmin();
            try
            {
                objBECourseAdmin.IntProviderID = Convert.ToInt32(ddlprovider.SelectedValue);
                objBECourseAdmin.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID].ToString());

                objBCourseAdmin.BBindCourseAdminSpecificProviderCourses(objBECourseAdmin);
                if (objBECourseAdmin.DtResult != null && objBECourseAdmin.DtResult.Rows.Count > 0)
                {
                    rcbCourses.Items.Clear();
                    rcbCourses.DataSource = objBECourseAdmin.DtResult;
                    rcbCourses.DataValueField = "CourseID";
                    rcbCourses.DataTextField = "CourseName";
                    rcbCourses.DataBind();
                }
                else
                {
                    rcbCourses.Items.Clear();
                    rcbCourses.DataSource = null;
                    rcbCourses.DataBind();

                }
            }
            catch (Exception)
            {

            }

        }

        #region GetRandowPassword
        public static string GetRandomPassword(int Length)
        {
            char[] chars = "$%#@!*abcdefghijklmnopqrstuvwxyz1234567890?;:ABCDEFGHIJKLMNOPQRSTUVWXYZ^&".ToCharArray();
            string password = string.Empty;
            Random random = new Random();
            for (int i = 0; i < Length; i++)
            {
                int x = random.Next(1, chars.Length);
                if (!password.Contains(chars.GetValue(x).ToString()))
                    password += chars.GetValue(x);
                else
                    i--;
            }
            return password;
        }
        #endregion

        #endregion
    }
}