using System;
using BusinessEntities;
using BLL;
using System.Web.UI;

namespace SecureProctor
{
    public partial class AdminLogin : BaseClass
    {
        #region GlobalDeclarations
        const int Length = 8;
        #endregion
        #region PageLoad
        protected void Page_PreInit(object sender, EventArgs e)
        {
            //this code is added by adarsh for finding the browser name to handle the webcam functionality with html5            
            System.Web.HttpBrowserCapabilities browser = Request.Browser;
            if ((browser.Browser.ToString().Trim() == "Firefox") || (browser.Browser.ToString().Trim() == "Chrome") ||
                (browser.Browser.ToString().Trim() == "Opera") || (browser.Browser.ToString().Trim() == "Edge") || (browser.Browser.ToString().Trim() == "MicrosoftEdge"))
                Session["IsHmlCompliant"] = "Yes";
            else Session["IsHmlCompliant"] = "No"; 



        }
        protected void Page_Load(object sender, EventArgs e)
        {
            txtUserName.Focus();
            if (!IsPostBack)
            {
                lblInvalidEmailAddress.Text = string.Empty;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "NotSaved", "document.getElementById('" + txtUserName.ClientID.ToString() + "').focus();", true);
            }
        }
        #endregion
        #region Login Button
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {

                lblInvalidEmailAddress.Text = string.Empty;
                lblInvalid.Text = string.Empty;
                BEUser objBEUser = new BEUser() { StrUserName = txtUserName.Text.Trim(), StrPassword = txtPassword.Text.Trim() };
                new BUser().BValidateUser(objBEUser);
                if (objBEUser.IntResult != 0)
                {
                    Session[EnumPageSessions.USERID] = objBEUser.IntUserID;
                    Session["UserName"] = objBEUser.StrUserAliasName;
                    Session["EmailID"] = objBEUser.StrUserName;
                    Session["TimeZoneID"] = objBEUser.IntTimeZoneID.ToString();
                    Session["TimeZone"] = objBEUser.StringTimeZone.ToString();
                    Session["RoleID"] = objBEUser.IntRoleID.ToString();
                    Session[EnumPayment.PaidBY_ExamFee] = objBEUser.PaidBy_ExamFee.ToString();
                    Session[EnumPayment.PaidBY_OndeMand] = objBEUser.PaidBy_OndemandFee.ToString();

                    this.SetAccessibility();

                    if (objBEUser.StrPasswordReset == "True")
                    {
                        Response.Redirect(EnumAppPage.ChangePassword, false);
                    }


                    else if (objBEUser.intDualRole == 0)
                    {
                        if (objBEUser.loginflag == false)
                        {

                            switch (objBEUser.IntRoleID.ToString())
                            {
                                case "6":
                                    
                                    new BUser().BUpdateLoginFlag(objBEUser);
                                    //ValidateTimeZone();
                                    Response.Redirect(EnumAppPage.STUDENT_HOME, false);
                                    break;
                                case "5":
                                    //ValidateTimeZone();
                                    Response.Redirect(EnumAppPage.PROCTOR_HOME, false);
                                    break;
                                case "4":
                                   // ValidateTimeZone();
                                    if (ValidateTimeZone())
                                        Response.Redirect(EnumAppPage.COMMON_CHANGETIMEZONE, false);
                                    else
                                    Response.Redirect(EnumAppPage.AUDITOR_HOME, false);
                                    break;
                                case "3":
                                       if(ValidateTimeZone())
                                       Response.Redirect(EnumAppPage.COMMON_CHANGETIMEZONE, false);
                                   else
                                    Response.Redirect(EnumAppPage.PROVIDER_HOME, false);
                                    break;
                                case "7":
                                    //ValidateTimeZone();
                                    if (ValidateTimeZone())
                                        Response.Redirect(EnumAppPage.COMMON_CHANGETIMEZONE, false);
                                    else
                                    Response.Redirect(EnumAppPage.ADMIN_HOME, false);
                                    break;
                                case "8":
                                    //ValidateTimeZone();
                                    if (ValidateTimeZone())
                                        Response.Redirect(EnumAppPage.COMMON_CHANGETIMEZONE, false);
                                    else
                                        Response.Redirect(EnumAppPage.COURSEADMIN_HOME, false);
                                    break;

                            }
                        }
                        else
                        {
                            Session[EnumPageSessions.USERID] = objBEUser.IntUserID;
                            Session["UserName"] = objBEUser.StrUserAliasName;
                            Session["EmailID"] = objBEUser.StrUserName;
                            Session["TimeZoneID"] = objBEUser.IntTimeZoneID.ToString();
                            Session["TimeZone"] = objBEUser.StringTimeZone.ToString();
                            Session[EnumPayment.PaidBY_ExamFee] = objBEUser.PaidBy_ExamFee.ToString();
                            Session[EnumPayment.PaidBY_OndeMand] = objBEUser.PaidBy_OndemandFee.ToString();
                            switch (objBEUser.IntRoleID.ToString())
                            {
                                case "6":
                                   // ValidateTimeZone();
                                    Response.Redirect(EnumAppPage.STUDENT_HOME, false);
                                    // Response.Redirect(EnumAppPage.STUDENT_MYPROFILE, false);
                                    break;
                                case "5":
                                    //ValidateTimeZone();
                                    Response.Redirect(EnumAppPage.PROCTOR_HOME, false);
                                    break;
                                case "4":
                                   // ValidateTimeZone();
                                    Response.Redirect(EnumAppPage.AUDITOR_HOME, false);
                                    break;
                                case "3":
                                     if(ValidateTimeZone())
                                       Response.Redirect(EnumAppPage.COMMON_CHANGETIMEZONE, false);
                                   else
                                    Response.Redirect(EnumAppPage.PROVIDER_HOME, false);
                                    break;
                                case "7":
                                    //ValidateTimeZone();
                                    Response.Redirect(EnumAppPage.ADMIN_HOME, false);
                                    break;
                                case "8":
                                    //ValidateTimeZone();
                                    if (ValidateTimeZone())
                                        Response.Redirect(EnumAppPage.COMMON_CHANGETIMEZONE, false);
                                    else
                                        Response.Redirect(EnumAppPage.COURSEADMIN_HOME, false);
                                    break;

                            }
                        }
                    }
                    else
                    {
                        Session["DUALROLE"] = objBEUser.DsResult;
                        Response.Redirect("switchrole.aspx?ID=0", false);
                    }
                }
                if (objBEUser.IntResult == 0)
                {
                    //lblInvalid.Text = "Invalid Email Address/Password";
                    lblInvalid.Text = Resources.ResMessages.Login_Invalidemail_password;
                }
            }
            catch
            {
                //lblInvalid.Text = "Sorry for the inconvenience.  Unable to connect to the DB server.";
                //lblInvalid.Text = GetGlobalResourceObject("<%$ Resources:ResMessages,Login_InvalidDB %>", "Login_InvalidDB").ToString();
                lblInvalid.Text = Resources.ResMessages.Login_InvalidDB;
            }
        }
        protected void SetAccessibility()
        {
            BEStudent objBEStudent = new BEStudent();
            BStudent objBStudent = new BStudent();
            objBEStudent.IntStudentID = Convert.ToInt32(Session[EnumPageSessions.USERID].ToString());
            objBStudent.BGetAccessibility(objBEStudent);
            if (objBEStudent.IntFlag == 1)
                Session["ACCESSIBILITY"] = "ON";
            else
                Session["ACCESSIBILITY"] = "OFF";
        }

        protected bool ValidateTimeZone()
        {
            BECommon objBECommon = new BECommon();
            objBECommon.IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID]);
            BCommon objBCommon = new BCommon();
            objBCommon.BValidateTimeZone(objBECommon);
            if (objBECommon.IntResult == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion
        #region Registration Button
        protected void btnRegistration_Click(object sender, EventArgs e)
        {
            Response.Redirect(EnumAppPage.STUDENT_REGISTRATION, false);
        }
        #endregion
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
        #region ForgotPassword Button
        protected void btnForGotPassword_Click(object sender, EventArgs e)
        {
            try
            {
                RequiredFieldValidator1.Text = string.Empty;
                RequiredFieldValidator2.Text = string.Empty;
                lblInvalid.Text = string.Empty;
                BEUser objBEUser = new BEUser();
                BUser objBUser = new BUser();
                if (txtEmailID.Text.Trim() != "")
                {
                    objBEUser.StrEmailID = txtEmailID.Text.Trim();
                }
                else
                {

                    lblInvalidEmailAddress.Text = "<font color='Red'>" + Resources.ResMessages.Login_InvalidEmailID;
                    lblEmailAddressSuccess.Text = "";
                    this.Clear();
                    objBEUser.StrEmailID = null;
                    return;
                }
                lblInvalidEmailAddress.Text = "";
                objBEUser.StrRandomPassword = GetRandomPassword(Length);
                objBUser.BForgotPassword(objBEUser);
                if (objBEUser.IntResult == 1)
                {
                    try
                    {
                        BEMail objBEMail = new BEMail();
                        BMail objBMail = new BMail();
                        objBEMail.IntUserID = objBEUser.IntUserID;
                        objBEMail.IntTransID = 0;
                        objBEMail.StrTemplateName = BaseClass.EnumEmails.ForgotPassword.ToString();
                        objBMail.BSendEmail(objBEMail);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    if (objBEUser.StrEmailID != "")
                        lblEmailAddressSuccess.Text = "<font color='#00C000'>" + Resources.ResMessages.Login_EmailSuccess + " " + objBEUser.StrEmailID;

                    else
                        lblEmailAddressSuccess.Text = "No email address is registered.Please update your Email address.";
                    this.Clear();
                }
                else
                {
                    lblInvalidEmailAddress.Text = "<font color='Red'>"+Resources.ResMessages.Login_EmailVerify;
                    lblEmailAddressSuccess.Text = "";
                    this.Clear();
                }
            }
            catch (Exception Ex)
            {
                // ErrorLog.WriteError(Ex);
            }
        }
        #endregion
        #region ClearFields
        protected void Clear()
        {
            txtEmailID.Text = "";
            
        }
        #endregion
        
    }
}