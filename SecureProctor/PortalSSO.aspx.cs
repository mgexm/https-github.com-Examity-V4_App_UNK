using System;
using BusinessEntities;
using BLL;
using System.IO;
using System.Xml;
using System.Text;
using System.Security.Cryptography;

namespace SecureProctor
{
    public partial class PortalSSO : System.Web.UI.Page
    {

        protected void Page_PreInit(object sender, EventArgs e)
        {
            //this code is added by adarsh for finding the browser name to handle the webcam functionality with html5            
            System.Web.HttpBrowserCapabilities browser = Request.Browser;
            if ((browser.Browser.ToString().Trim() == "Firefox") || (browser.Browser.ToString().Trim() == "Chrome") ||
                (browser.Browser.ToString().Trim() == "Opera") || (browser.Browser.ToString().Trim() == "Edge") || (browser.Browser.ToString().Trim() == "MicrosoftEdge"))
                Session["IsHmlCompliant"] = "Yes";
            else Session["IsHmlCompliant"] = "No";



        }
        #region GlobalDeclarations
        private static byte[] key = { };
        private static byte[] IV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xab, 0xcd, 0xef };
        #endregion
        #region PageLoad
        protected void Page_Load(object sender, EventArgs e)
        {
            LoginUser(DecryptQueryString("Username"), DecryptQueryString("Password"), DecryptQueryString("Redirect"));
        }
        #endregion
        #region LoginUser
        protected void LoginUser(string UserName, string Password, string RedirectURL)
        {
            try
            {
                try
                {
                    if (DecryptQueryString("StationID") != string.Empty)
                        Session["StationID"] = DecryptQueryString("StationID");

                    if (DecryptQueryString("MeetingAccount") != string.Empty)
                        Session["MeetingAccount"] = DecryptQueryString("MeetingAccount");

                }
                catch
                {
                }
                BEUser objBEUser = new BEUser() { StrUserName = UserName, StrPassword = Password };
                new BUser().BValidateUser(objBEUser);
                if (objBEUser.IntResult != 0)
                {
                    Session[BaseClass.EnumPageSessions.USERID] = objBEUser.IntUserID;
                    Session["UserName"] = objBEUser.StrUserAliasName;
                    Session["EmailID"] = objBEUser.StrUserName;
                    Session["TimeZoneID"] = objBEUser.IntTimeZoneID.ToString();
                    Session["TimeZone"] = objBEUser.StringTimeZone.ToString();
                    Session["RoleID"] = objBEUser.IntRoleID.ToString();
                    Session[BaseClass.EnumPayment.PaidBY_ExamFee] = objBEUser.PaidBy_ExamFee.ToString();
                    Session[BaseClass.EnumPayment.PaidBY_OndeMand] = objBEUser.PaidBy_OndemandFee.ToString();

                    Response.Redirect(RedirectURL);
                }
                if (objBEUser.IntResult == 0)
                {
                    Response.Write("Invalid Login!");
                    //lblInvalid.Text = "Invalid Email Address/Password";
                    //lblInvalid.Text = Resources.ResMessages.Login_Invalidemail_password;
                }
            }
            catch
            {
                Response.Write("Invalid Login!");
            }
        }
        #endregion
        #region Decryption
        protected string DecryptQueryString(string query)
        {
            string result = string.Empty;
            foreach (string str in Decryption(Server.UrlDecode(Request.QueryString.ToString()), System.Configuration.ConfigurationManager.AppSettings["SaltKey"].ToString()).Split('|'))
            {
                if (str.Split('#')[0] == query)
                    result = str.Split('#')[1];
            }

            //string var = Decryption(Server.UrlDecode(Request.QueryString.ToString()), System.Configuration.ConfigurationManager.AppSettings["SaltKey"].ToString());

            return result;
        }
        private string Decryption(string stringToDecrypt, string SEncryptionKey)
        {
            byte[] inputByteArray = new byte[stringToDecrypt.Length + 1];
            try
            {
                key = System.Text.Encoding.UTF8.GetBytes(SEncryptionKey.Substring(0));
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                inputByteArray = Convert.FromBase64String(stringToDecrypt);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(key, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                System.Text.Encoding encoding = System.Text.Encoding.UTF8;
                return encoding.GetString(ms.ToArray());
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        #endregion
    }

}