using System;
using BLL;
using BusinessEntities;
using System.IO;
using System.Configuration;

namespace SecureProctor
{
    public partial class LMSLogin : System.Web.UI.Page
    {
        public string LMSuserrole = "";
        string strEmployeeId = string.Empty;
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
            if (Request.Form["oauth_consumer_key"] != null && Request.Form["oauth_consumer_key"].ToString() == System.Configuration.ConfigurationManager.AppSettings["LMSConsumerKey"].ToString())
            {
                BEUser objBEUser = new BEUser();
                BUser objBUser = new BUser();
                objBEUser.strStudentCode = Request.Form["lis_person_contact_email_primary"];
                strEmployeeId = objBEUser.strStudentCode;
                this.TrackLog("User from Canvas or Moodlre or Learning studio LMS: " + strEmployeeId, 0);
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
                    Response.Redirect("Errors/SSOErrorPage.aspx?ErrorId=3001", true);
                }
            }
            else
            {
                Response.Redirect("Errors/SSOErrorPage.aspx?ErrorId=3001", true);
            }
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
    }
}