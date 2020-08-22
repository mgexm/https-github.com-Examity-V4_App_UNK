using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using BusinessEntities;
using System.Web.Services;

namespace SecureProctor
{
    public partial class ChangePassword : BaseClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                btnSave.Visible = true;

            lblMessage.Text = string.Empty;

            txtCurrentPassword.Attributes.Add("onblur", "ValidatorOnChange(event);"); 

            txtNewPassword.Attributes.Add("onblur", "ValidatorOnChange(event);");

            txtConfirmNewPassword.Attributes.Add("onblur", "ValidatorOnChange(event);");

            txtCurrentPassword.Attributes.Add("onClick", "return ValidateChangePassword('" + txtCurrentPassword.ClientID + "','" + lblMessage.ClientID + "','" + txtNewPassword.ClientID + "','" + txtConfirmNewPassword.ClientID + "')");
            txtNewPassword.Attributes.Add("onClick", "return ValidateChangePassword('" + txtCurrentPassword.ClientID + "','" + lblMessage.ClientID + "','" + txtNewPassword.ClientID + "','" + txtConfirmNewPassword.ClientID + "')");
            txtConfirmNewPassword.Attributes.Add("onClick", "return ValidateChangePassword('" + txtCurrentPassword.ClientID + "','" + lblMessage.ClientID + "','" + txtNewPassword.ClientID + "','" + txtConfirmNewPassword.ClientID + "')");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                BEUser objBEUser = new BEUser();

                BUser objBUser = new BUser();

                objBEUser.strOldPassword = txtCurrentPassword.Text;

                objBEUser.strNewPassword = txtNewPassword.Text;

                objBEUser.strConfirmNewPassword = txtConfirmNewPassword.Text;

                objBEUser.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID]);

                objBEUser.StrUserName = Session["EmailID"].ToString();

                objBUser.BChangePassword(objBEUser);

                if (objBEUser.IntResult == 0)
                {
                    
                    lblMessage.Text = "<font color='#00C000'>"+Resources.ResMessages.MyProfile_PasswordUpdateSuccess;
                    tblContent.Visible = false;
                    btnSave.Visible = false;
                    lblmandate.Visible = false;
                    imgOK.Visible = true;

                    try
                    {

                        BEMail objBEMail = new BEMail();
                        BMail objBMail = new BMail();
                        objBEMail.IntUserID = objBEUser.IntUserID;
                        objBEMail.IntTransID = 0;
                        objBEMail.StrTemplateName = BaseClass.EnumEmails.ChangePassword.ToString();

                        objBMail.BSendEmail(objBEMail);

                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                }

                if (objBEUser.IntResult == 1)
                {
                    tblContent.Visible = true;
                    lblMessage.Text = "<font color='Red'>"+Resources.ResMessages.MyProfile_ValidCurrentPassword;
                    lblmandate.Visible = true;
                    imgOK.Visible = false;

                }
            }
        }

        protected void imgOK_Click(object sender, EventArgs e)
        {
            if (Session["RoleID"] != null)
            {
                switch (Session["RoleID"].ToString())
                {
                    case "6":
                        //ValidateTimeZone();
                        Response.Redirect(EnumAppPage.STUDENT_HOME, false);
                        break;
                    case "5":
                      //  ValidateTimeZone();
                        Response.Redirect(EnumAppPage.PROCTOR_HOME, false);
                        break;
                    case "4":
                       // ValidateTimeZone();
                        Response.Redirect(EnumAppPage.AUDITOR_HOME, false);
                        break;
                    case "3":
                        ValidateTimeZone();
                        Response.Redirect(EnumAppPage.PROVIDER_HOME, false);
                        break;
                    case "7":
                       // ValidateTimeZone();
                        Response.Redirect(EnumAppPage.ADMIN_HOME, false);
                        break;
                    case "8":
                        // ValidateTimeZone();
                        Response.Redirect(EnumAppPage.COURSEADMIN_HOME, false);
                        break;

                }



            }
            
        }

        protected void ValidateTimeZone()
        {
            BECommon objBECommon = new BECommon();
            objBECommon.IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID]);
            BCommon objBCommon = new BCommon();
            objBCommon.BValidateTimeZone(objBECommon);
            if (objBECommon.IntResult == 0)
            {
                Response.Redirect(EnumAppPage.COMMON_CHANGETIMEZONE, true);

            }

        }
  
        
        //[WebMethod(enableSession: true)]
        //public static int PasswordExists(string password)
        //{

        //    int pwdExists = 0;

        //    BEUser objBEUser = new BEUser();

        //    BUser objBUser = new BUser();

        //    BEStudent objBEStudent = new BEStudent();

        //    objBEUser.IntUserID = Convert.ToInt32(HttpContext.Current.Session[BaseClass.EnumPageSessions.USERID]);
        //    objBEUser.StrPassword = password;
        //    objBUser.BPasswordExists(objBEUser);


        //    pwdExists = objBEUser.IntResult;

        //    return objBEUser.IntResult;

        //}
    }
}