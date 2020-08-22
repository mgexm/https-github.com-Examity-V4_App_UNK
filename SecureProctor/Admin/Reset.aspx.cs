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
    public partial class Reset : BaseClass
    {
        #region GlobalDeclarations
        const int Length = 8;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Page.Title = EnumPageTitles.APPNAME + EnumPageTitles.ADMIN_RESETSTUDENT;
            getPassword();
            trMessage.Visible = false;

        }

        protected void getPassword()
        {

            BEAdmin objBEAdmin = new BEAdmin();
            BAdmin objBAdmin = new BAdmin();

            objBEAdmin.IntStudentID = Convert.ToInt32(Request.QueryString["StudentID"].ToString());
            objBAdmin.BGetPassword(objBEAdmin);

            if (objBEAdmin.DtResult.Rows.Count != 0)
            {
                lblEmailAddress.Text = objBEAdmin.DtResult.Rows[0]["EmailAddress"].ToString();

            }

        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            BEAdmin objBEAdmin = new BEAdmin();
            BAdmin objBAdmin = new BAdmin();
            objBEAdmin.IntStudentID = Convert.ToInt32(Request.QueryString["StudentID"].ToString());
            objBEAdmin.StrRandomPassword = GetRandomPassword(Length);
            objBAdmin.BUpdatePassword(objBEAdmin);
            if (objBEAdmin.IntResult == 1)
            {
                try
                {
                    BEMail objBEMail = new BEMail();
                    BMail objBMail = new BMail();
                    objBEMail.IntUserID = objBEAdmin.IntStudentID;
                    objBEMail.IntTransID = 0;
                    objBEMail.StrTemplateName = BaseClass.EnumEmails.ForgotPassword.ToString();
                    objBMail.BSendEmail(objBEMail);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                trMessage.Visible = true;
                lblInfo.Text = Resources.AppMessages.Admin_Reset_Success_Reset;
                lblInfo.ForeColor = System.Drawing.Color.FromName(Resources.AppConfigurations.Color_Success);
                ImgInfo.ImageUrl = Resources.AppConfigurations.Image_Success;
                tdInfo.Attributes.Add("style", Resources.AppConfigurations.Color_Table_Success);


            }

            else
            {

                trMessage.Visible = true;
                lblInfo.Text = Resources.AppMessages.Admin_Reset_Error_ResetStudent;
                lblInfo.ForeColor = System.Drawing.Color.FromName(Resources.AppConfigurations.Color_Error);
                ImgInfo.ImageUrl = Resources.AppConfigurations.Image_Error;
                tdInfo.Attributes.Add("style", Resources.AppConfigurations.Color_Table_Error);
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