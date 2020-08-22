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
    public partial class AddStudent : BaseClass
    {
        #region GlobalDeclarations
        const int Length = 8;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                this.Page.Title = EnumPageTitles.APPNAME + "Add Student";
                trAddStudent.Visible = true;
                trAddStudentConfirm.Visible = false;
            }
            trMessage.Visible = false;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {

            BEAdmin objBEAdmin = new BEAdmin();
            BAdmin objBAdmin = new BAdmin();
            objBEAdmin.strFirstName = txtFirstName.Text;
            lblFirstName.Text = txtFirstName.Text;
            objBEAdmin.strLastName = txtLastName.Text;
            lblLastName.Text = txtLastName.Text;
            objBEAdmin.strEmailAddress = txtEmailAddress.Text;
            lblEmailAddress.Text = txtEmailAddress.Text;
            objBEAdmin.StrComments = txtcomments.Value;
            lblComments.Text = txtcomments.Value;

            objBEAdmin.strUserName = txtUserID.Text;
            lblUserName.Text = txtUserID.Text;
            //objBEAdmin.strPassword = GetRandomPassword(Length);
            if (chkConfirmEmail.Checked == true)
            {
                objBEAdmin.strPassword = "1";

            }
            else
            {
                objBEAdmin.strPassword = "0";

            }

            trMessage.Visible = true;
            if (ChkSpecialNeeds.Checked == true)
            {
                objBEAdmin.strSpecialNeeds = true;
                lblSpecialNeeds.Text = "Yes";
            }
            else
            {
                objBEAdmin.strSpecialNeeds = false;
                lblSpecialNeeds.Text = "No";
            }
            objBAdmin.BAddStudent(objBEAdmin);
            if (objBEAdmin.IntResult == 0)
            {


                lblInfo.Text = Resources.AppMessages.Admin_AddStudent_Error_AddStudent;
                lblInfo.ForeColor = System.Drawing.Color.FromName(Resources.AppConfigurations.Color_Error);
                ImgInfo.ImageUrl = Resources.AppConfigurations.Image_Error;
                tdInfo.Attributes.Add("style", Resources.AppConfigurations.Color_Table_Error);
                trAddStudent.Visible = true;
                trAddStudentConfirm.Visible = false;


            }

            if (objBEAdmin.IntResult == 1)
            {
                lblInfo.Text = Resources.AppMessages.Admin_AddStudent_Success_AddStudent;
                lblInfo.ForeColor = System.Drawing.Color.FromName(Resources.AppConfigurations.Color_Success);
                ImgInfo.ImageUrl = Resources.AppConfigurations.Image_Success;
                tdInfo.Attributes.Add("style", Resources.AppConfigurations.Color_Table_Success);
                trAddStudent.Visible = false;
                trAddStudentConfirm.Visible = true;


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
    }
}