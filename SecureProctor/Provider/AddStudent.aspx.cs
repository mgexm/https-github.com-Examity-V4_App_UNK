using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using BusinessEntities;

namespace SecureProctor.Provider
{
    public partial class AddStudent : BaseClass
    {



        #region GlobalDeclarations
        const int Length = 8;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Page.Title = EnumPageTitles.APPNAME + EnumPageTitles.EXAMPROVIDER_ADDSTUDENT;
                trEnrollStudent.Visible = true;
                trAddStudent.Visible = false;
                trAddStudentConfirm.Visible = false;
                trEnrollStudentConfirmation.Visible = false;
                this.getAllStudents();
                this.getProviderCourses();
                this.getProviderNewCourses();

            }
            trMessage.Visible = false;
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {

            BEProvider objBEExamProvider = new BEProvider();
            BProvider objBExamProvider = new BProvider();
            objBEExamProvider.strFirstName = txtFirstName.Text;
            lblFirstName.Text = txtFirstName.Text;
            objBEExamProvider.strLastName = txtLastName.Text;
            lblLastName.Text = txtLastName.Text;
            objBEExamProvider.strEmailAddress = txtEmailAddress.Text;
            lblEmailAddress.Text = txtEmailAddress.Text;
            objBEExamProvider.StrComments = txtcomments.Value;
            lblComments.Text = txtcomments.Value;
            lblNewCourse.Text = rcbNewCourses.SelectedItem.Text.ToString();
            objBEExamProvider.IntCourseID = Convert.ToInt32(rcbNewCourses.SelectedValue);
            objBEExamProvider.IntProviderID = Convert.ToInt32(Session[EnumPageSessions.USERID]);
            objBEExamProvider.strPassword = GetRandomPassword(Length);
            objBEExamProvider.strUserName = txtUserID.Text;
            lblUserName.Text = txtUserID.Text;


            trMessage.Visible = true;
            if (ChkSpecialNeeds.Checked == true)
            {
                objBEExamProvider.strSpecialNeeds = true;
                lblSpecialNeeds.Text = "Yes";
            }
            else
            {
                objBEExamProvider.strSpecialNeeds = false;
                lblSpecialNeeds.Text = "No";
            }
            objBExamProvider.BAddStudent(objBEExamProvider);
            if (objBEExamProvider.IntResult == 0)
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

            if (objBEExamProvider.IntResult == 1)
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

        protected void getAllStudents()
        {
            BEProvider objBEExamProvider = new BEProvider();
            BProvider objBExamProvider = new BProvider();
            objBEExamProvider.IntProviderID = Convert.ToInt32(Session[EnumPageSessions.USERID]);
            objBExamProvider.BGetAllStudents(objBEExamProvider);
            if (objBEExamProvider.DtResult != null && objBEExamProvider.DtResult.Rows.Count > 0)
            {
                rcbStudents.DataSource = objBEExamProvider.DtResult;
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
            BEProvider objBEExamProvider = new BEProvider();
            BProvider objBExamProvider = new BProvider();
            objBEExamProvider.IntProviderID = Convert.ToInt32(Session[EnumPageSessions.USERID]);
            objBExamProvider.BGetProviderCourses(objBEExamProvider);
            if (objBEExamProvider.DtResult != null && objBEExamProvider.DtResult.Rows.Count > 0)
            {
                rcbCourses.DataSource = objBEExamProvider.DtResult;
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
            BEProvider objBEExamProvider = new BEProvider();
            BProvider objBExamProvider = new BProvider();
            objBEExamProvider.IntProviderID = Convert.ToInt32(Session[EnumPageSessions.USERID]);
            objBExamProvider.BGetProviderCourses(objBEExamProvider);
            if (objBEExamProvider.DtResult != null && objBEExamProvider.DtResult.Rows.Count > 0)
            {
                rcbNewCourses.DataSource = objBEExamProvider.DtResult;
                rcbNewCourses.DataBind();

            }
            else
            {
                rcbNewCourses.DataSource = new string[] { };
                rcbNewCourses.DataBind();

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

        protected void btnStudentSave_Click(object sender, EventArgs e)
        {
            trMessage.Visible = true;
            lblStudentName.Text = rcbStudents.SelectedItem.Text.ToString();
            lblCourseName.Text = rcbCourses.SelectedItem.Text.ToString();
            

            BEProvider objBEProvider = new BEProvider();
            BProvider objBProvider = new BProvider();
            objBEProvider.IntStudentID = Convert.ToInt32(rcbStudents.SelectedValue);
            objBEProvider.IntCourseID = Convert.ToInt32(rcbCourses.SelectedValue.ToString());
            objBEProvider.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID].ToString());
           
            objBProvider.BProviderEnrollStudent(objBEProvider);
            if (objBEProvider.IntResult.ToString() == "1")
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
            getProviderNewCourses();

        }

        protected void lnkAdd_Click(object sender, EventArgs e)
        {
            trAddStudent.Visible = false;
            trAddStudentConfirm.Visible = false;
            trEnrollStudent.Visible = true;
            trEnrollStudentConfirmation.Visible = false;
           
        }








    }
}