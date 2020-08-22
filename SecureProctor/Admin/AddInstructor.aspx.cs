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
    public partial class AddInstructor : BaseClass
    {
        #region GlobalDeclarations
        const int Length = 8;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Page.Title = EnumPageTitles.APPNAME + "Add Instructor";
                trAddInstructor.Visible = true;
                trAddInstructorConfirm.Visible = false;
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
            objBAdmin.BAddInstructor(objBEAdmin);
            if (objBEAdmin.IntResult == 0)
            {


                lblInfo.Text = Resources.ResMessages.Admin_AddStudent_Error_AddInstructor;
                lblInfo.ForeColor = System.Drawing.Color.FromName(Resources.AppConfigurations.Color_Error);
                ImgInfo.ImageUrl = Resources.AppConfigurations.Image_Error;
                tdInfo.Attributes.Add("style", Resources.AppConfigurations.Color_Table_Error);
                trAddInstructor.Visible = true;
                trAddInstructorConfirm.Visible = false;


            }

            if (objBEAdmin.IntResult == 1)
            {
                lblInfo.Text = Resources.ResMessages.Admin_AddStudent_Success_AddInstructor;
                lblInfo.ForeColor = System.Drawing.Color.FromName(Resources.AppConfigurations.Color_Success);
                ImgInfo.ImageUrl = Resources.AppConfigurations.Image_Success;
                tdInfo.Attributes.Add("style", Resources.AppConfigurations.Color_Table_Success);
                trAddInstructor.Visible = false;
                trAddInstructorConfirm.Visible = true;

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