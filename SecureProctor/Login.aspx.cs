using System;
using System.IO;
using BusinessEntities;
using BLL;
using System.Security.Cryptography;
using System.Text;
using System.Configuration;

namespace SecureProctor
{
    public partial class Login : System.Web.UI.Page
    {
        System.Web.HttpBrowserCapabilities browser;

        protected void Page_PreInit(object sender, EventArgs e)
        {
            //this code is added by adarsh for finding the browser name to handle the webcam functionality with html5            
            browser = Request.Browser;
            if ((browser.Browser.ToString().Trim() == "Firefox") || (browser.Browser.ToString().Trim() == "Chrome") ||
                (browser.Browser.ToString().Trim() == "Opera") || (browser.Browser.ToString().Trim() == "Edge") || (browser.Browser.ToString().Trim() == "MicrosoftEdge"))
                Session["IsHmlCompliant"] = "Yes";
            else Session["IsHmlCompliant"] = "No";
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string strEmployeeId = string.Empty;

            try
            {

                if (Request.QueryString["UserName"] != null)
                {
                    //MSU SSO
                    strEmployeeId = Request.QueryString["userName"].ToString();
                    this.TrackLog("User from MSU: " + strEmployeeId, 0);
                }
                else if (Request["UserName"] != null)
                {
                    //blackboard SSO
                    strEmployeeId = Decrypt(Request["UserName"].ToString(), System.Configuration.ConfigurationManager.AppSettings["SSOSaltKey"].ToString());
                    this.TrackLog("User from Blackboard: " + strEmployeeId, 0);
                }

                else if (Request["lis_person_sourcedid"] != null && Request["custom_lms"] != null && Request["oauth_consumer_key"] != null && Request["oauth_consumer_key"].ToString() == System.Configuration.ConfigurationManager.AppSettings["SSOSaltKey"].ToString() && Request["custom_lms"].ToString().Equals("BB"))
                {
                    strEmployeeId = Request["lis_person_sourcedid"].ToString();
                    this.TrackLog("User from Blackboard Ultra: " + strEmployeeId, 0);
                }


                else if (Request["user_id"] != null && Request["custom_lms"] != null && Request["oauth_consumer_key"] != null)
                {
                    if (Request["oauth_consumer_key"].ToString() == System.Configuration.ConfigurationManager.AppSettings["D2LSaltKey"].ToString() && Request["custom_lms"].ToString().Equals("2"))
                    {
                        if (Request["user_id"].ToString().Contains("_"))
                        {
                            //d2l 
                            string[] ls = Request["user_id"].ToString().Split('_');
                            strEmployeeId = ls[1].ToString();
                            this.TrackLog("User from D2L: " + strEmployeeId, 0);
                        }
                        if (Request["user_id"].ToString().Contains("::"))
                        {
                            //schoology 
                            string[] ls = Request["user_id"].ToString().Split(':');
                            string[] ls1 = ls[0].ToString().Split(':');
                            strEmployeeId = ls1[0].ToString();
                            this.TrackLog("User from Schoology: " + strEmployeeId, 0);
                        }

                    }
                    else if (Request["oauth_consumer_key"].ToString() == System.Configuration.ConfigurationManager.AppSettings["SakaiSaltKey"].ToString() && Request["custom_lms"].ToString().ToLower().Equals("sakai"))
                    {
                        //sakai
                        strEmployeeId = Request["user_id"].ToString();
                        this.TrackLog("User from Sakai: " + strEmployeeId, 0);
                    }
                    else if (Request["oauth_consumer_key"].ToString() == System.Configuration.ConfigurationManager.AppSettings["AtrixSaltKey"].ToString() && Request["custom_lms"].ToString().Equals("atrix"))
                    {
                        // atrix
                        strEmployeeId = Request["user_id"].ToString();
                        this.TrackLog("User from Atrix LMS: " + strEmployeeId, 0);
                    }
                    else if (Request["lis_person_contact_email_primary"] != null && Request["oauth_consumer_key"].ToString() == System.Configuration.ConfigurationManager.AppSettings["Jenzabar"].ToString() && Request["custom_lms"].ToString().Equals("Jenzabar"))
                    {
                        // Jenzabar
                        strEmployeeId = Request["lis_person_contact_email_primary"].ToString();
                        this.TrackLog("User from Jenzabar LMS: " + strEmployeeId, 0);
                    }
                }

            }
            catch
            {
                strEmployeeId = "Error: ";
            }

            if (strEmployeeId == string.Empty)
            {
                this.TrackLog(ErrorMessages.GetErrorMessage(1004).ToString(), 0);
                this.ErrorLog(1004);
            }
            else if (strEmployeeId.Contains("Error:"))
            {
                this.ErrorLog(Convert.ToInt32(strEmployeeId.Replace("Error:", "")));
            }
            else
            {
                BEUser objBEUser = new BEUser();
                BUser objBUser = new BUser();
                objBEUser.strStudentCode = strEmployeeId;
                objBUser.BFindUser(objBEUser);
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
                    if (objBEUser.intDualRole == 0)
                    {
                        if (objBEUser.IntRoleID == 6)
                        {
                            if (ConfigurationManager.AppSettings["ExamityMeetingValidation"] != null && ConfigurationManager.AppSettings["ExamityMeetingValidation"].ToString().Equals("Yes"))
                            {
                                if ((browser.Browser.ToString().Trim() == "Firefox") || (browser.Browser.ToString().Trim() == "Chrome"))
                                    Response.Redirect("Student/Home.aspx", false);
                                else
                                {
                                    Session.Abandon();
                                    Response.Redirect("Detect.aspx", false);
                                }
                            }
                            else
                            {
                                Response.Redirect("Student/Home.aspx", false);
                            }
                        }
                        else if
                            (objBEUser.IntRoleID == 3)
                        {

                            if (ValidateTimeZone())
                                Response.Redirect(BaseClass.EnumAppPage.COMMON_CHANGETIMEZONE, false);
                            else
                                Response.Redirect(BaseClass.EnumAppPage.PROVIDER_HOME, false);
                        }
                        else if
                              (objBEUser.IntRoleID == 7)
                        {
                            if (ValidateTimeZone())
                                Response.Redirect(BaseClass.EnumAppPage.COMMON_CHANGETIMEZONE, false);
                            else
                                Response.Redirect("Admin/Home.aspx", false);
                        }
                        else if
                           (objBEUser.IntRoleID == 8)
                        {
                            if (ValidateTimeZone())
                                Response.Redirect(BaseClass.EnumAppPage.COMMON_CHANGETIMEZONE, false);
                            else
                                Response.Redirect("CourseAdmin/Home.aspx", false);
                        }
                    }
                    else
                    {
                        Session["DUALROLE"] = objBEUser.DsResult;
                        Response.Redirect("switchrole.aspx?ID=1");
                    }
                }
                else
                {
                    this.TrackLog(strEmployeeId + "  " + ErrorMessages.GetErrorMessage(3001).ToString(), 0);
                    this.ErrorLog(3001);
                }
            }
        }

        #region ErrorLog
        private void ErrorLog(int ErrorId)
        {
            Response.Redirect("Errors/SSOErrorPage.aspx?ErrorId=" + ErrorId.ToString(), true);
        }
        #endregion

        #region TrackLog
        private void TrackLog(string strMsg, byte Flag)
        {
            try
            {
                FileStream objFs = new FileStream(Server.MapPath("SecureProctorSSO_Examity.txt"), FileMode.Append, FileAccess.Write);
                StreamWriter objSw = new StreamWriter(objFs);
                //if (Flag == 1)
                //{                   
                objSw.WriteLine("===================================================================");
                objSw.WriteLine("Message DateTime : " + DateTime.Now.ToString());
                objSw.WriteLine(strMsg);
                //}
                objSw.Close();
                objFs.Close();
            }
            catch
            {
            }
        }
        #endregion

        public RijndaelManaged GetRijndaelManaged(String secretKey)
        {
            var keyBytes = new byte[16];
            var secretKeyBytes = Encoding.UTF8.GetBytes(secretKey);
            Array.Copy(secretKeyBytes, keyBytes, Math.Min(keyBytes.Length, secretKeyBytes.Length));
            return new RijndaelManaged
            {
                Mode = CipherMode.CBC,
                Padding = PaddingMode.PKCS7,
                KeySize = 128,
                BlockSize = 128,
                Key = keyBytes,
                IV = keyBytes
            };
        }

        public byte[] Decrypt(byte[] encryptedData, RijndaelManaged rijndaelManaged)
        {
            return rijndaelManaged.CreateDecryptor()
                .TransformFinalBlock(encryptedData, 0, encryptedData.Length);
        }

        public String Decrypt(String encryptedText, String key)
        {
            var encryptedBytes = Convert.FromBase64String(encryptedText);
            return Encoding.UTF8.GetString(Decrypt(encryptedBytes, GetRijndaelManaged(key)));
        }
        protected bool ValidateTimeZone()
        {
            BECommon objBECommon = new BECommon();
            objBECommon.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID]);
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
    }
}