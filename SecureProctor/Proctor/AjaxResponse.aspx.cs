using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessEntities;
using BLL;
using GOTOFrameWork;
using ExamityWebEx;
using System.Configuration;

namespace SecureProctor.Proctor
{
    public partial class AjaxResponse : System.Web.UI.Page
    {
        string uname = string.Empty;
        string TransID = string.Empty;
        string reqMethod = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["MeetingAccount"] != null)
            {
                uname = Session["MeetingAccount"].ToString();
            }

            if (Request.Form["Method"] != null)
            {
                reqMethod = Request.Form["Method"].ToString();
                BECommon objBECommon = new BECommon();
                BCommon objBCommon = new BCommon();
                BEProctor objBEProctor = new BEProctor();
                BProctor objBProctor = new BProctor();

                switch (reqMethod)
                {
                    case "ExamStatus":
                        {
                            try
                            {
                                //BECommon objBECommon = new BECommon();

                                //BCommon objBCommon = new BCommon();

                                objBECommon.IntTransID = Convert.ToInt64(AppSecurity.Decrypt(Request.Form["TransID"].ToString()));

                                objBCommon.BGetExamStatus(objBECommon);

                                Response.Write(objBECommon.IntType);
                            }
                            catch (Exception )
                            {
                                Response.Write(AppSecurity.Decrypt(Request.Form["TransID"].ToString()));
                            }


                        }
                        break;

                    case "ExamiKEYScore":
                        {
                            try
                            {
                                //BECommon objBECommon = new BECommon();

                                //BCommon objBCommon = new BCommon();

                                objBECommon.IntTransID = Convert.ToInt64(AppSecurity.Decrypt(Request.Form["TransID"].ToString()));

                                objBCommon.BGetExamiKeyScore(objBECommon);

                                Response.Write(objBECommon.intExamiKeyScore);
                            }
                            catch (Exception )
                            {
                                Response.Write(AppSecurity.Decrypt(Request.Form["TransID"].ToString()));
                            }


                        }
                        break;

                    case "GetMeetingID":
                        {
                            try
                            {
                                //BEProctor objBEProctor = new BEProctor();

                                //BProctor objBProctor = new BProctor();

                                objBEProctor.IntTransID = Convert.ToInt64(AppSecurity.Decrypt(Request.Form["TransID"].ToString()));

                                objBProctor.BGetMeetingID(objBEProctor);

                                Response.Write(objBEProctor.StrResult);
                            }
                            catch (Exception )
                            {
                                Response.Write(AppSecurity.Decrypt(Request.Form["TransID"].ToString()));
                            }

                        }
                        break;
                    case "GetBrowserInfo":
                        {
                            try
                            {
                                //BEProctor objBEProctor = new BEProctor();

                                //BProctor objBProctor = new BProctor();

                                objBEProctor.IntTransID = Convert.ToInt64(AppSecurity.Decrypt(Request.Form["TransID"].ToString()));

                                objBProctor.BGetBrowserInfo(objBEProctor);

                                Response.Write(objBEProctor.StrResult);
                            }
                            catch (Exception )
                            {
                                Response.Write(AppSecurity.Decrypt(Request.Form["TransID"].ToString()));
                            }

                        }
                        break;

                    case "ExamTimer":
                        {
                            //BEProctor objBEProctor = new BEProctor();
                            //BProctor objBProctor = new BProctor();

                            objBEProctor.IntTransID = Convert.ToInt64(AppSecurity.Decrypt(Request.Form["TransID"].ToString()));
                            objBProctor.BGetExamTime(objBEProctor);

                            if (objBEProctor.ExamTime >= 60)
                                Response.Write((objBEProctor.ExamTime / 60).ToString() + "|" + (objBEProctor.ExamTime % 60).ToString() + "|0");
                            else
                                Response.Write("0|" + objBEProctor.ExamTime + "|0");
                        }
                        break;
                    case "StudentIdentity":
                        {

                            //BEProctor objBEProctor = new BEProctor();
                            //BProctor objBProctor = new BProctor();
                            objBEProctor.IntTransID = Convert.ToInt64(AppSecurity.Decrypt(Request.Form["TransID"].ToString()));
                            objBEProctor.StudentIdentity = Convert.ToBoolean(Convert.ToInt16(Request.Form["Status"].ToString()));
                            objBEProctor.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID]);
                            objBProctor.BSaveIdentityValidation(objBEProctor);
                            Response.Write(objBEProctor.IntResult);
                        }
                        break;
                    case "StudentExamStatus":
                        {
                            try
                            {
                                //BECommon objBECommon = new BECommon();

                                //BCommon objBCommon = new BCommon();

                                objBECommon.IntTransID = Convert.ToInt64(Request.Form["TransID"].ToString());

                                objBCommon.BGetExamStatus(objBECommon);

                                Response.Write(objBECommon.IntType.ToString() + "|" + Request.Form["RowNo"].ToString());
                            }
                            catch (Exception ex)
                            {
                                Response.Write(ex.Message);
                            }

                        }
                        break;

                    case "GetStudentIdentity":
                        {

                            //BEProctor objBEProctor = new BEProctor();
                            //BProctor objBProctor = new BProctor();
                            objBEProctor.IntTransID = Convert.ToInt64(AppSecurity.Decrypt(Request.Form["TransID"].ToString()).Trim());

                            objBProctor.BGetStudentValidationStatus(objBEProctor);

                            Response.Write(objBEProctor.StudentIdentity);
                        }
                        break;
                    case "GetMeetingStatus":
                        {
                            //BEProctor objBEProctor = new BEProctor();
                            //BProctor objBProctor = new BProctor();
                            objBEProctor.IntTransID = Convert.ToInt64(AppSecurity.Decrypt(Request.Form["TransID"].ToString()).Trim());

                            objBProctor.BGetMeetingStatus(objBEProctor);

                            Response.Write(objBEProctor.IntstatusFlag);
                        }
                        break;

                    case "GetProceedStatus":
                        {
                            //BEProctor objBEProctor = new BEProctor();
                            //BProctor objBProctor = new BProctor();
                            objBEProctor.IntTransID = Convert.ToInt64(AppSecurity.Decrypt(Request.Form["TransID"].ToString()).Trim());

                            objBProctor.BGetFlagStatus_Proceed(objBEProctor);

                            Response.Write(objBEProctor.IntstatusFlag);
                        }
                        break;

                    case "StartExam":
                        {
                            //BEProctor objBEProctor = new BEProctor();
                            //BProctor objBProctor = new BProctor();
                            objBEProctor.IntTransID = Convert.ToInt64(AppSecurity.Decrypt(Request.Form["TransID"].ToString()).Trim());

                            objBProctor.BGetFlagStatus_StartExam(objBEProctor);

                            Response.Write(objBEProctor.IntstatusFlag);
                        }
                        break;


                    case "GetExamiKNOWStatus":
                        {

                            //BEProctor objBEProctor = new BEProctor();
                            //BProctor objBProctor = new BProctor();
                            objBEProctor.IntTransID = Convert.ToInt64(AppSecurity.Decrypt(Request.Form["TransID"].ToString()).Trim());
                            objBEProctor.IntFlag = Convert.ToInt32(AppSecurity.Decrypt(Request.Form["From"].ToString()).Trim());
                            objBProctor.BGetExamiKNOWStatus(objBEProctor);
                            Response.Write(objBEProctor.IntstatusFlag);

                        }
                        break;
                    case "ExamCompleted":
                        {
                            //if (Convert.ToInt32(Session["ExamCompleted"]) == 0)
                            //    Session["ExamCompleted"] = 2;
                            if (Convert.ToInt32(Session["ExamCompleted"]) == 0)
                            {
                                //BEProctor objBEProctor = new BEProctor();
                                //BProctor objBProctor = new BProctor();
                                objBEProctor.IntTransID = Convert.ToInt64(AppSecurity.Decrypt(Request.Form["TransID"].ToString()).Trim());

                                objBProctor.BGetFlagStatus_ExamCompleted(objBEProctor);

                                Response.Write(objBEProctor.IntstatusFlag);
                                // Session["ExamCompleted"] = 1;
                            }
                        }
                        break;
                    case "ProctorSubmitTransaction":
                        {
                            string TransID = AppSecurity.Decrypt(HttpUtility.UrlDecode(Request.Form["TransID"].ToString()));

                            try
                            {
                                //BProctor objBProctor = new BProctor();
                                //BEProctor objBEProctor = new BEProctor();
                                objBEProctor.IntTransID = Convert.ToInt64(TransID);
                                objBEProctor.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID].ToString());
                                objBProctor.BGetExamTransactionStatus(objBEProctor);
                                string Selectedvalue = Request.Form["Selectedvalue"].ToString();
                                string stat = "";
                                if (Selectedvalue == "0")
                                {
                                    stat = "Approve";

                                }

                                else if (Selectedvalue == "2")
                                {
                                    stat = "Incomplete";
                                }

                                if (objBEProctor.DtResult.Rows[0][0].ToString() == "3")
                                {
                                    if (stat == "Approve")
                                    {
                                        // approvre directly

                                        //BEProctor objBEProctor = new BEProctor();
                                        //BProctor objBProctor = new BProctor();
                                        //objBEProctor.IntTransID = Convert.ToInt32(TransID);
                                        //objBEProctor.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID]);

                                        objBEProctor.IntFlag = 0;
                                        objBEProctor.strStatus = stat;
                                        objBProctor.BProctorApproveExam(objBEProctor);
                                        //try
                                        //{
                                        //    StreamingServer.ServiceSoapClient client = new StreamingServer.ServiceSoapClient();
                                        //    client.StopStreaming("", TransID);
                                        //}
                                        //catch (Exception ex)
                                        //{
                                        //    Response.Write(ex.Message);
                                        //}

                                        try
                                        {

                                            BEMail objBEMail = new BEMail();
                                            BMail objBMail = new BMail();
                                            objBEMail.IntUserID = 0;
                                            objBEMail.IntTransID = Convert.ToInt64(TransID);
                                            objBEMail.StrTemplateName = BaseClass.EnumEmails.ExamApprovalConfirmation.ToString();
                                            objBMail.BSendEmail(objBEMail);
                                            objBEMail = null;
                                            objBMail = null;
                                        }
                                        catch (Exception )
                                        {
                                            //Response.Write(ex.Message);
                                        }
                                        Response.Write("1");
                                    }
                                    else
                                    {
                                        //lblalert.Visible = true;
                                        // lblalert.Text = "Exam has been already completed, please approve for auditor action";
                                        //return;

                                        Response.Write("2");

                                    }
                                }





                                if (objBEProctor.DtResult.Rows[0][0].ToString() == "1")
                                {
                                    if (stat == "Incomplete")
                                    {
                                        objBEProctor.IntFlag = 0;
                                        objBEProctor.strStatus = stat;
                                        objBProctor.BProctorApproveExam(objBEProctor);


                                        Response.Write("4");
                                    }

                                    if (stat == "Approve")
                                    {
                                        try
                                        {
                                            //BECommon objBECommon = new BECommon();

                                            //BCommon objBCommon = new BCommon();

                                            objBECommon.IntTransID = Convert.ToInt64(TransID);

                                            objBCommon.BGetExamStatus(objBECommon);

                                            //Response.Write(objBECommon.IntType);

                                            if (objBECommon.IntType == 16)
                                            {
                                                objBEProctor.IntFlag = 0;
                                                objBEProctor.strStatus = stat;
                                                objBProctor.BProctorApproveExam(objBEProctor);
                                                Response.Write("1");
                                            }
                                        }
                                        catch (Exception )
                                        {
                                        }
                                    }

                                }

                                if (objBEProctor.DtResult.Rows[0][0].ToString() == "12")
                                {
                                    if (stat == "Approve")
                                    {


                                        objBEProctor.IntFlag = 0;
                                        objBEProctor.strStatus = stat;
                                        objBProctor.BProctorApproveExam(objBEProctor);
                                        Response.Write("1");
                                    }

                                }

                                if (objBEProctor.DtResult.Rows[0][0].ToString() == "12")
                                {
                                    if (stat == "Incomplete")
                                    {


                                        objBEProctor.IntFlag = 0;
                                        objBEProctor.strStatus = stat;
                                        objBProctor.BProctorApproveExam(objBEProctor);
                                        Response.Write("4");
                                    }

                                }



                                else if (objBEProctor.DtResult.Rows[0][0].ToString() == "2" || objBEProctor.DtResult.Rows[0][0].ToString() == "13")
                                {
                                    if (stat == "Approve")
                                    {
                                        objBEProctor.IntFlag = 0;
                                        objBEProctor.strStatus = stat;
                                        objBProctor.BProctorApproveExam(objBEProctor);
                                        try
                                        {
                                            BEMail objBEMail = new BEMail();
                                            BMail objBMail = new BMail();
                                            objBEMail.IntUserID = 0;
                                            objBEMail.IntTransID = Convert.ToInt64(TransID);
                                            objBEMail.StrTemplateName = BaseClass.EnumEmails.ExamApprovalConfirmation.ToString();
                                            objBMail.BSendEmail(objBEMail);
                                            objBEMail = null;
                                            objBMail = null;
                                        }
                                        catch (Exception )
                                        {
                                            //Response.Write(ex.Message);
                                        }
                                        Response.Write("1");

                                        //// change status to closed

                                        ////BEProctor objBEProctor = new BEProctor();
                                        ////BProctor objBProctor = new BProctor();
                                        ////objBEProctor.IntTransID = Convert.ToInt32(TransID);
                                        ////objBEProctor.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID]);
                                        //objBEProctor.IntFlag = 0;
                                        //objBEProctor.strStatus = stat;
                                        //objBProctor.BProctorApproveExam(objBEProctor);

                                        //// closed on behalf of student

                                        //objBEProctor.IntFlag = 0;
                                        //objBEProctor.strStatus = "Approve";
                                        //objBProctor.BProctorApproveExam(objBEProctor);
                                        ////try
                                        ////{
                                        ////    StreamingServer.ServiceSoapClient client = new StreamingServer.ServiceSoapClient();
                                        ////    client.StopStreaming("", TransID);
                                        ////}
                                        ////catch (Exception ex)
                                        ////{
                                        ////    Response.Write(ex.Message);
                                        ////}

                                        //try
                                        //{

                                        //    BEMail objBEMail = new BEMail();
                                        //    BMail objBMail = new BMail();
                                        //    objBEMail.IntUserID = 0;
                                        //    objBEMail.IntTransID = Convert.ToInt32(TransID);
                                        //    objBEMail.StrTemplateName = BaseClass.EnumEmails.ExamApprovalConfirmation.ToString();
                                        //    objBMail.BSendEmail(objBEMail);
                                        //}
                                        //catch (Exception ex)
                                        //{
                                        //    //Response.Write(ex.Message);
                                        //}
                                        //Response.Write("1");

                                    }
                                    else
                                    {
                                        // incomplete

                                        //BEProctor objBEProctor = new BEProctor();
                                        //BProctor objBProctor = new BProctor();
                                        //objBEProctor.IntTransID = Convert.ToInt32(TransID);
                                        //objBEProctor.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID]);
                                        objBEProctor.IntFlag = 0;
                                        objBEProctor.strStatus = stat;
                                        objBProctor.BProctorApproveExam(objBEProctor);
                                        //try
                                        //{
                                        //    StreamingServer.ServiceSoapClient client = new StreamingServer.ServiceSoapClient();
                                        //    client.StopStreaming("", TransID);
                                        //}
                                        //catch
                                        //{
                                        //}
                                        //btnConfirm.Visible = false;
                                        //btnBack.Visible = false;
                                        //imgtick.Visible = true;
                                        //lblSuccess.Text = Resources.ResMessages.Proctor_ExamIncomplete;
                                        try
                                        {
                                            BEMail objBEMail = new BEMail();
                                            BMail objBMail = new BMail();
                                            objBEMail.IntUserID = 0;
                                            objBEMail.IntTransID = Convert.ToInt64(TransID);
                                            objBEMail.StrTemplateName = BaseClass.EnumEmails.ExamApprovalConfirmation.ToString();
                                            objBMail.BSendEmail(objBEMail);
                                            objBEMail = null;
                                            objBMail = null;
                                        }
                                        catch (Exception )
                                        {
                                            //throw ex;
                                        }
                                        Response.Write("4");
                                    }
                                }
                                //else if (stat == "Approve")
                                //{                                
                                //    Response.Write("5");
                                //}
                                //}

                                //else if (Request.Form["Method"].ToString() == "CloseExam")
                                //        {
                                //            BEStudent objBEStudent = new BEStudent();
                                //            BStudent objBStudent = new BStudent();
                                //            objBEStudent.IntTransID = Convert.ToInt32(AppSecurity.Decrypt(Request.Form["TransID"].ToString()));
                                //            objBEStudent.IntFlag = 0;
                                //            objBStudent.BSetExamStartandEndTime(objBEStudent);

                                //            objBStudent.BsetExamCompleted(objBEStudent);
                                //        }
                                //        else
                                //        {
                                //            Response.Write("6");
                                //        }
                                objBProctor = null;
                                objBEProctor = null;
                            }
                            catch (Exception Ex)
                            {
                                throw Ex;
                            }

                        }
                        break;
                    case "CreateGotoMeetingSession":
                        {
                            try
                            {
                                string TransID = AppSecurity.Decrypt(HttpUtility.UrlDecode(Request.Form["TransID"].ToString()));
                                //BECommon objBECommon = new BECommon();
                                objBECommon.IntTransID = Convert.ToInt64(TransID);
                                objBECommon.intTypeID = 2;
                                //BCommon objBCommon = new BCommon();
                                objBCommon.BUpdateFlowTimeStamp(objBECommon);
                                //BEProctor objBEProctor = new BEProctor();
                                //BProctor objBProctor = new BProctor();
                                objBEProctor.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID].ToString());
                                objBEProctor.IntTransID = Convert.ToInt64(TransID);
                                objBEProctor.Uname = uname;//added for passing the username for wfm dashboard on 8.8.2017
                                if (Session["StationID"] != null)
                                    objBEProctor.intID = Convert.ToInt32(Session["StationID"]);
                                else
                                    objBEProctor.intID = 0;
                                objBProctor.BGetMeetingCredentials(objBEProctor);
                                if (objBEProctor.strExamSessionID == String.Empty)
                                {
                                    // Create new Exam request.
                                    G2M_Token objG2M_Token = new G2M_Token();
                                    G2M_Properties objG2M_Properties = new G2M_Properties();
                                    G2MAuthentication objG2MAuthentication = new G2MAuthentication();
                                    objG2M_Properties.strUserName = objBEProctor.strMeetingUserName;
                                    objG2M_Properties.strPassword = objBEProctor.strMeetingPassword;
                                    objG2M_Properties.strMeetingSubject = System.Configuration.ConfigurationManager.AppSettings["GOTOMeetingExamSubject"].ToString() + TransID;
                                    int intMinutes = 0;
                                    string[] str = objBEProctor.strExamDuration.Split('.');
                                    intMinutes = Convert.ToInt32(str[0].ToString()) * 60 + Convert.ToInt32(str[1].ToString()) + objBEProctor.intExamBufferTime + Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["GOTOMeetingProctorBufferTime"]);
                                    objG2M_Properties.intMeetingMinutes = intMinutes;
                                    objG2M_Token = objG2MAuthentication.GetAuthenticationToken(objG2M_Properties);
                                    objG2MAuthentication = null;
                                    if (objG2M_Token != null)
                                    {
                                        G2M_CreatedMeetingDetails objG2M_CreatedMeetingDetails = new G2M_CreatedMeetingDetails();
                                        G2MMeetings objG2MMeetings = new G2MMeetings();
                                        objG2M_CreatedMeetingDetails = objG2MMeetings.CreateMeeting(objG2M_Properties, objG2M_Token);
                                        this.SetExamSessionID(objG2M_CreatedMeetingDetails.meetingid, objG2M_Token.access_token);
                                        objG2M_Properties.strMeetingID = objG2M_CreatedMeetingDetails.meetingid;
                                        G2M_StartMeeting objG2M_StartMeeting = new G2M_StartMeeting();
                                        objG2M_StartMeeting = objG2MMeetings.StartMeeting(objG2M_Properties, objG2M_Token);
                                        //ScriptManager.RegisterStartupScript(this, Page.GetType(), "newWindow", "window.open('" + objG2M_StartMeeting.hostURL + "','_blank','width=200,height=100');", true);

                                        Response.Write(objG2M_StartMeeting.hostURL);
                                        objG2M_CreatedMeetingDetails = null;
                                        objG2MMeetings = null;
                                        objG2M_StartMeeting = null;

                                    }
                                    else
                                    {
                                        Response.Write("INVALID");//Invalid Meeting Credentials.  Please try again.
                                    }
                                    objG2M_Token = null;
                                    objG2M_Properties = null;
                                }
                                else
                                {
                                    // Exam is already scheduled.
                                    G2M_Token objG2M_Token = new G2M_Token();
                                    G2M_Properties objG2M_Properties = new G2M_Properties();
                                    G2MMeetings objG2MMeetings = new G2MMeetings();
                                    G2M_StartMeeting objG2M_StartMeeting = new G2M_StartMeeting();
                                    objG2M_Properties.strMeetingID = objBEProctor.strExamSessionID;
                                    objG2M_Token.access_token = objBEProctor.strMeetingToken;
                                    objG2M_StartMeeting = objG2MMeetings.StartMeeting(objG2M_Properties, objG2M_Token);
                                    //ScriptManager.RegisterStartupScript(this, Page.GetType(), "newWindow", "window.open('" + objG2M_StartMeeting.hostURL + "','_blank','width=200,height=100');", true);
                                    Response.Write(objG2M_StartMeeting.hostURL);
                                    objG2M_Properties = null;
                                    objG2M_Token = null;
                                    objG2MMeetings = null;
                                    objG2M_StartMeeting = null;

                                }
                            }
                            catch
                            {
                                Response.Write("ERROR");//Error while creating the meeting request
                            }
                        }
                        break;
                    case "CreateWebEx":
                        {
                            #region CreateWebEx
                            try
                            {
                                string TransID = AppSecurity.Decrypt(HttpUtility.UrlDecode(Request.Form["TransID"].ToString()));
                                //BECommon objBECommon = new BECommon();
                                objBECommon.IntTransID = Convert.ToInt64(TransID);
                                objBECommon.intTypeID = 4;
                                //BCommon objBCommon = new BCommon();
                                objBCommon.BUpdateFlowTimeStamp(objBECommon);
                                //BEProctor objBEProctor = new BEProctor();
                                //BProctor objBProctor = new BProctor();
                                objBEProctor.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID].ToString());
                                objBEProctor.IntTransID = Convert.ToInt64(TransID);
                                objBEProctor.Uname = uname;//added for passing the username for wfm dashboard on 8.8.2017
                                if (Session["StationID"] != null)
                                    objBEProctor.intID = Convert.ToInt32(Session["StationID"]);
                                else
                                    objBEProctor.intID = 0;
                                objBProctor.BGetWebExMeetingCredentials(objBEProctor);
                                if (objBEProctor.strExamSessionID == String.Empty)
                                {
                                    // Create new Exam request.
                                    WebEx_Properties objProperties = new WebEx_Properties();
                                    objProperties.Host_UserName = objBEProctor.strMeetingUserName;
                                    objProperties.Host_Password = objBEProctor.strMeetingPassword;
                                    objProperties.MeetingPassword = string.Empty;
                                    objProperties.ExamID = TransID;
                                    objProperties.Guest_UserName = objBEProctor.strStudentName;
                                    objProperties.Guest_EmailID = objBEProctor.StrEmailID;
                                    int intMinutes = 0;
                                    string[] str = objBEProctor.strExamDuration.Split('.');
                                    intMinutes = Convert.ToInt32(str[0].ToString()) * 60 + Convert.ToInt32(str[1].ToString()) + objBEProctor.intExamBufferTime + Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["GOTOMeetingProctorBufferTime"]);
                                    objProperties.ExamDuration = intMinutes;
                                    WebEx_Meetings objMeetings = new WebEx_Meetings();
                                    objMeetings.CreateMeeting(objProperties);
                                    if (objProperties.Response_MeetingID != null && objProperties.Response_MeetingID.Length != 0)
                                    {
                                        this.SetExamSessionID(objProperties.Response_MeetingID, "WEBEX");
                                        objProperties.MeetingID = objProperties.Response_MeetingID;
                                        objMeetings.GetHostMeetingURL(objProperties);

                                        Response.Write(objProperties.Response_HostURL);
                                    }
                                    else
                                        Response.Write("ERROR");
                                }
                                else
                                {
                                    // Exam is already scheduled.
                                    WebEx_Properties objProperties = new WebEx_Properties();
                                    objProperties.Host_UserName = objBEProctor.strMeetingUserName;
                                    objProperties.Host_Password = objBEProctor.strMeetingPassword;
                                    //objProperties.MeetingID = objProperties.Response_MeetingID;
                                    WebEx_Meetings objMeetings = new WebEx_Meetings();
                                    objProperties.MeetingID = objBEProctor.strExamSessionID;
                                    objMeetings.GetHostMeetingURL(objProperties);
                                    Response.Write(objProperties.Response_HostURL);
                                }
                            }
                            catch
                            {
                                Response.Write("ERROR");//Error while creating the meeting request
                            }
                            #endregion
                        }
                        break;
                    case "ResetWebEx":
                        {
                            #region ResetWebEx
                            try
                            {
                                string TransID = AppSecurity.Decrypt(HttpUtility.UrlDecode(Request.Form["TransID"].ToString()));
                                //BECommon objBECommon = new BECommon();
                                objBECommon.IntTransID = Convert.ToInt64(TransID);
                                objBECommon.intTypeID = 5;
                                //BCommon objBCommon = new BCommon();
                                objBCommon.BUpdateFlowTimeStamp(objBECommon);
                                //BEProctor objBEProctor = new BEProctor();
                                //BProctor objBProctor = new BProctor();
                                objBEProctor.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID].ToString());
                                objBEProctor.IntTransID = Convert.ToInt64(TransID);
                                objBEProctor.Uname = uname;//added for passing the username for wfm dashboard on 8.8.2017
                                if (Session["StationID"] != null)
                                    objBEProctor.intID = Convert.ToInt32(Session["StationID"]);
                                else
                                    objBEProctor.intID = 0;
                                objBProctor.BresetExamSession(objBEProctor);
                                objBProctor.BGetWebExMeetingCredentials(objBEProctor);
                                // Create new Exam request.
                                WebEx_Properties objProperties = new WebEx_Properties();
                                objProperties.Host_UserName = objBEProctor.strMeetingUserName;
                                objProperties.Host_Password = objBEProctor.strMeetingPassword;
                                objProperties.MeetingPassword = string.Empty;
                                objProperties.ExamID = TransID;
                                objProperties.Guest_UserName = objBEProctor.strStudentName;
                                objProperties.Guest_EmailID = objBEProctor.StrEmailID;
                                int intMinutes = 0;
                                string[] str = objBEProctor.strExamDuration.Split('.');
                                intMinutes = Convert.ToInt32(str[0].ToString()) * 60 + Convert.ToInt32(str[1].ToString()) + objBEProctor.intExamBufferTime + Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["GOTOMeetingProctorBufferTime"]);
                                objProperties.ExamDuration = intMinutes;
                                WebEx_Meetings objMeetings = new WebEx_Meetings();
                                objMeetings.CreateMeeting(objProperties);
                                if (objProperties.Response_MeetingID != null && objProperties.Response_MeetingID.Length != 0)
                                {
                                    this.SetExamSessionID(objProperties.Response_MeetingID, "WEBEX");
                                    objProperties.MeetingID = objProperties.Response_MeetingID;
                                    objMeetings.GetHostMeetingURL(objProperties);


                                    Response.Write(objProperties.Response_HostURL);
                                }
                                else
                                    Response.Write("ERROR");
                            }
                            catch
                            {
                                Response.Write("ERROR");//Error while creating the meeting request
                            }
                            #endregion
                        }
                        break;
                    case "CreateZoomMeetingSession":
                        {
                            #region CreateZoomMeeting
                            string TransID = AppSecurity.Decrypt(HttpUtility.UrlDecode(Request.Form["TransID"].ToString()));

                            //BECommon objBECommon = new BECommon();
                            objBECommon.IntTransID = Convert.ToInt64(TransID);
                            objBECommon.intTypeID = 41; //Replace with Create Zoom Id from DB
                                                        //BCommon objBCommon = new BCommon();
                            objBCommon.BUpdateFlowTimeStamp(objBECommon);

                            //BEProctor objBEProctor = new BEProctor();
                            //BProctor objBProctor = new BProctor();
                            objBEProctor.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID]);
                            objBEProctor.IntTransID = Convert.ToInt64(TransID);
                            objBEProctor.Uname = uname;//added for passing the username for wfm dashboard on 8.8.2017
                            if (Session["StationID"] != null)
                                objBEProctor.intID = Convert.ToInt32(Session["StationID"]);
                            else
                                objBEProctor.intID = 0;
                            objBProctor.BGetZoomCredentials(objBEProctor);

                            try
                            {
                                if (!string.IsNullOrEmpty(objBEProctor.strZoomHostId) && objBEProctor.strExamSessionID == null)
                                {
                                    ExamityZoomMeeting.ExamityZoomMeetingMain objZoomMeeting = new ExamityZoomMeeting.ExamityZoomMeetingMain();

                                    ExamityZoomMeeting.MeetingRequestDTO objMeetingRequest = new ExamityZoomMeeting.MeetingRequestDTO();
                                    objMeetingRequest.host_id = objBEProctor.strZoomHostId;
                                    objMeetingRequest.topic = "Examity Proctoring Meeting";
                                    objMeetingRequest.type = 2;/*Meeting type: 1 means instant meeting (Only used for host to start it as soon as created). 2 means normal scheduled meeting. 3 means a recurring meeting with no fixed time. 8 means a recurring meeting with fixed time.*/
                                    objMeetingRequest.start_time = DateTime.Now.ToUniversalTime().ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'");
                                    objMeetingRequest.duration = "120";
                                    objMeetingRequest.option_auto_record_type = ConfigurationManager.AppSettings["ZoomMeetingRecordType"];

                                    ExamityZoomMeeting.MeetingResponseDTO objZoomMeetingResponse = objZoomMeeting.CreateMeeting(objMeetingRequest);

                                    if (!string.IsNullOrEmpty(objZoomMeetingResponse.start_url) &&
                                         !string.IsNullOrEmpty(objZoomMeetingResponse.join_url))
                                    {
                                        this.SetExamSessionID(objZoomMeetingResponse.id + "|" + objZoomMeetingResponse.start_url, "ZOOM");
                                        Response.Write(objZoomMeetingResponse.start_url);
                                    }
                                    else
                                        Response.Write("ERROR");
                                }

                            }
                            catch (Exception)
                            { Response.Write("ERROR"); }

                            #endregion
                        }
                        break;
                    case "ResetZoomMeetingSession":
                        {
                            #region ResetZoomMeeting

                            string TransID = AppSecurity.Decrypt(HttpUtility.UrlDecode(Request.Form["TransID"].ToString()));
                            //BECommon objBECommon = new BECommon();
                            objBECommon.IntTransID = Convert.ToInt64(TransID);
                            objBECommon.intTypeID = 42;
                            //BCommon objBCommon = new BCommon();
                            objBCommon.BUpdateFlowTimeStamp(objBECommon);

                            //BEProctor objBEProctor = new BEProctor();
                            //BProctor objBProctor = new BProctor();
                            objBEProctor.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID].ToString());
                            objBEProctor.IntTransID = Convert.ToInt64(TransID);
                            objBEProctor.Uname = uname;//added for passing the username for wfm dashboard on 8.8.2017
                            if (Session["StationID"] != null)
                                objBEProctor.intID = Convert.ToInt32(Session["StationID"]);
                            else
                                objBEProctor.intID = 0;
                            objBProctor.BresetExamSession(objBEProctor);

                            try
                            {
                                objBProctor.BGetZoomCredentials(objBEProctor);

                                if (!string.IsNullOrEmpty(objBEProctor.strZoomHostId))
                                {
                                    ExamityZoomMeeting.ExamityZoomMeetingMain objZoomMeeting = new ExamityZoomMeeting.ExamityZoomMeetingMain();

                                    ExamityZoomMeeting.MeetingRequestDTO objMeetingRequest = new ExamityZoomMeeting.MeetingRequestDTO();
                                    objMeetingRequest.host_id = objBEProctor.strZoomHostId;
                                    objMeetingRequest.topic = "Examity Proctoring Meeting";
                                    objMeetingRequest.type = 2;/*Meeting type: 1 means instant meeting (Only used for host to start it as soon as created). 2 means normal scheduled meeting. 3 means a recurring meeting with no fixed time. 8 means a recurring meeting with fixed time.*/
                                    objMeetingRequest.start_time = DateTime.Now.ToUniversalTime().ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'");
                                    objMeetingRequest.duration = "120";
                                    objMeetingRequest.option_auto_record_type = ConfigurationManager.AppSettings["ZoomMeetingRecordType"];

                                    ExamityZoomMeeting.MeetingResponseDTO objZoomMeetingResponse = objZoomMeeting.CreateMeeting(objMeetingRequest);

                                    if (!string.IsNullOrEmpty(objZoomMeetingResponse.start_url) &&
                                         !string.IsNullOrEmpty(objZoomMeetingResponse.join_url))
                                    {
                                        this.SetExamSessionID(objZoomMeetingResponse.id + "|" + objZoomMeetingResponse.start_url, "ZOOM");
                                        Response.Write(objZoomMeetingResponse.start_url);
                                    }
                                    else
                                        Response.Write("ERROR");
                                }
                                else
                                    Response.Write("ERROR");

                            }
                            catch (Exception)
                            { Response.Write("ERROR"); }
                            #endregion
                        }
                        break;

                    case "ResetGotoMeetingSession":
                        {
                            try
                            {
                                string TransID = AppSecurity.Decrypt(HttpUtility.UrlDecode(Request.Form["TransID"].ToString()));
                                //BECommon objBECommon = new BECommon();
                                objBECommon.IntTransID = Convert.ToInt64(TransID);
                                objBECommon.intTypeID = 3;
                                //BCommon objBCommon = new BCommon();
                                objBCommon.BUpdateFlowTimeStamp(objBECommon);
                                //BEProctor objBEProctor = new BEProctor();
                                //BProctor objBProctor = new BProctor();
                                objBEProctor.IntTransID = Convert.ToInt64(TransID);
                                objBProctor.BresetExamSession(objBEProctor);
                                objBEProctor.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID].ToString());
                                objBEProctor.Uname = uname;//added for passing the username for wfm dashboard on 8.8.2017
                                if (Session["StationID"] != null)
                                    objBEProctor.intID = Convert.ToInt32(Session["StationID"]);
                                else
                                    objBEProctor.intID = 0;
                                objBProctor.BGetMeetingCredentials(objBEProctor);


                                // Create new Exam request.
                                G2M_Token objG2M_Token = new G2M_Token();
                                G2M_Properties objG2M_Properties = new G2M_Properties();
                                G2MAuthentication objG2MAuthentication = new G2MAuthentication();
                                objG2M_Properties.strUserName = objBEProctor.strMeetingUserName;
                                objG2M_Properties.strPassword = objBEProctor.strMeetingPassword;
                                objG2M_Properties.strMeetingSubject = System.Configuration.ConfigurationManager.AppSettings["GOTOMeetingExamSubject"].ToString() + TransID;
                                int intMinutes = 0;
                                string[] str = objBEProctor.strExamDuration.Split('.');
                                intMinutes = Convert.ToInt32(str[0].ToString()) * 60 + Convert.ToInt32(str[1].ToString()) + objBEProctor.intExamBufferTime + Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["GOTOMeetingProctorBufferTime"]);
                                objG2M_Properties.intMeetingMinutes = intMinutes;
                                objG2M_Token = objG2MAuthentication.GetAuthenticationToken(objG2M_Properties);
                                objG2MAuthentication = null;
                                if (objG2M_Token != null)
                                {
                                    G2M_CreatedMeetingDetails objG2M_CreatedMeetingDetails = new G2M_CreatedMeetingDetails();
                                    G2MMeetings objG2MMeetings = new G2MMeetings();
                                    objG2M_CreatedMeetingDetails = objG2MMeetings.CreateMeeting(objG2M_Properties, objG2M_Token);
                                    this.SetExamSessionID(objG2M_CreatedMeetingDetails.meetingid, objG2M_Token.access_token);
                                    objG2M_Properties.strMeetingID = objG2M_CreatedMeetingDetails.meetingid;
                                    G2M_StartMeeting objG2M_StartMeeting = new G2M_StartMeeting();
                                    objG2M_StartMeeting = objG2MMeetings.StartMeeting(objG2M_Properties, objG2M_Token);

                                    //ScriptManager.RegisterStartupScript(this, Page.GetType(), "newWindow", "window.open('" + objG2M_StartMeeting.hostURL + "','_blank','width=200,height=100');", true);
                                    Response.Write(objG2M_StartMeeting.hostURL);
                                    objG2M_CreatedMeetingDetails = null;
                                    objG2MMeetings = null;
                                    objG2M_StartMeeting = null;

                                }
                                else
                                {
                                    Response.Write("INVALID");//Invalid Meeting Credentials.  Please try again.
                                }
                                objG2M_Token = null;
                                objG2M_Properties = null;

                            }
                            catch (Exception )
                            {
                                Response.Write("ERROR");//Error while creating the meeting request
                            }
                        }
                        break;
                }

                objBECommon = null;
                objBCommon = null;
                objBEProctor = null;
                objBProctor = null;
            }
        }
        protected void SetExamSessionID(string strExamSessionID, string strAccessToken)
        {
            try
            {
                BEProctor objBEProctor = new BEProctor();
                BProctor objBProctor = new BProctor();
                objBEProctor.strExamSessionID = strExamSessionID;
                objBEProctor.IntTransID = Convert.ToInt64(AppSecurity.Decrypt(HttpUtility.UrlDecode(Request.Form["TransID"].ToString())));
                objBEProctor.strMeetingToken = strAccessToken;
                objBProctor.BSetExamSessionID(objBEProctor);
                objBEProctor = null;
                objBProctor = null;
            }
            catch
            {
            }
        }
    }
}