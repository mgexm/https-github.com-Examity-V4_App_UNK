using BusinessEntities;
using BLL;
using System;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Configuration;

namespace SecureProctor
{
    public partial class AjaxHandler : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Form["method"] != null)
            {
                switch (Request.Form["method"].ToString())
                {
                    case "GetIdentityValidation":
                        {
                            BEStudent objBEStudent = new BEStudent();
                            BStudent objBStudent = new BStudent();

                            objBEStudent.IntTransID = Convert.ToInt64(AppSecurity.Decrypt(Request.Form["TransID"].ToString()));

                            objBStudent.BGetIdentityValidation(objBEStudent);

                            Response.Write(objBEStudent.StudentIdentity.ToString());
                        }
                        break;
                    case "ValidateStep1":
                        {
                            BEStudent objBEStudent = new BEStudent();
                            BStudent objBStudent = new BStudent();

                            objBEStudent.IntTransID = Convert.ToInt64(AppSecurity.Decrypt(Request.Form["TransID"].ToString()));

                            objBStudent.BGetIdentityValidation(objBEStudent);

                            if (objBEStudent.StudentIdentity)
                                Response.Write("true");
                            else
                                Response.Write("false");
                        }
                        break;
                    //case "ValidateStep2":
                    //    {
                    //        BStudent objBStudent = new BStudent();
                    //        BEStudent objBEStudent = new BEStudent();
                    //        objBEStudent.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID].ToString());
                    //        objBEStudent.strAnswer1 = Request.Form["Answer1"].ToString().Trim().ToString();
                    //        objBEStudent.strAnswer2 = Request.Form["Answer2"].ToString().Trim().ToString();
                    //        objBEStudent.strAnswer3 = Request.Form["Answer3"].ToString().Trim().ToString();
                    //        objBStudent.BValidateStudentSecurityQuestions(objBEStudent);
                    //        if (objBEStudent.IntResult == 1)
                    //            Response.Write("true");
                    //        else
                    //            Response.Write("false");
                    //    }
                    //    break;
                    case "ValidateStep2":
                        {
                            BStudent objBStudent = new BStudent();
                            BEStudent objBEStudent = new BEStudent();
                            objBEStudent.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID].ToString());
                            objBEStudent.strAnswer1 = Request.Form["Answer"].ToString().Trim().ToString();
                            objBEStudent.strQuestion1 = Request.Form["Question"].ToString().Trim().ToString();
                            objBEStudent.IntTransID = Convert.ToInt64(Request.Form["TransID"].ToString().Trim().ToString());

                            objBStudent.BRandomSecurityQuestionsValidation(objBEStudent);

                            if (objBEStudent.IntResult == 1)
                            {
                                //  Response.Write("true" + "|" + objBEStudent.StrResult.ToString());
                                //Response.Write(objBEStudent.StrResult.ToString());
                                Response.Write("true");

                            }
                            else
                            {
                                Response.Write(objBEStudent.StrResult.ToString());

                            }
                        }
                        break;



                    case "setStatus":
                        {
                            BEProctor objBEProctor = new BEProctor();
                            BProctor objBProctor = new BProctor();
                            objBEProctor.IntTransID = Convert.ToInt64(AppSecurity.Decrypt(Request.Form["TransID"].ToString()));
                            objBEProctor.strStatus = "STARTEXAM";
                            objBEProctor.IntResult = 0;
                            objBProctor.BSetTransactionFlags(objBEProctor);
                        }
                        break;
                    case "setexamiFACEStatus":
                        {
                            BEProctor objBEProctor = new BEProctor();
                            BProctor objBProctor = new BProctor();
                            objBEProctor.IntTransID = Convert.ToInt64(AppSecurity.Decrypt(Request.Form["TransID"].ToString()));

                            objBProctor.BSetexamiFACETransactionStatus(objBEProctor);
                        }
                        break;
                    case "setexamiFACEDownLoadStatus":
                        {
                            BEProctor objBEProctor = new BEProctor();
                            BProctor objBProctor = new BProctor();
                            objBEProctor.IntTransID = Convert.ToInt64(AppSecurity.Decrypt(Request.Form["TransID"].ToString()));
                            objBEProctor.strStatus = Request.Form["Status"].ToString().Trim().ToString();

                            objBProctor.BSetexamiFACEDownLoadStatus(objBEProctor);
                        }
                        break;
                    case "setexamiFACEDownLoadStatus1":
                        {
                            //BEProctor objBEProctor = new BEProctor();
                            //BProctor objBProctor = new BProctor();
                            //objBEProctor.IntTransID = Convert.ToInt32(AppSecurity.Decrypt(Request.Form["TransID"].ToString()));
                            //objBEProctor.strStatus = Request.Form["Status"].ToString().Trim().ToString();

                            //objBProctor.BSetexamiFACEDownLoadStatus(objBEProctor);

                            BECommon objBECommon = new BECommon();
                            BCommon objBCommon = new BCommon();

                            objBECommon.IntTransID = Convert.ToInt64(AppSecurity.Decrypt(Request.Form["TransID"].ToString()));
                            objBECommon.IntstatusFlag = Convert.ToInt32(Request.Form["Status"].ToString().Trim().ToString());
                            objBCommon.BReenableBeginExamstatus(objBECommon);
                        }
                        break;

                    case "ValidateStep3":
                        {
                            BEStudent objBEStudent = new BEStudent();
                            BStudent objBStudent = new BStudent();

                            objBEStudent.IntTransID = Convert.ToInt64(AppSecurity.Decrypt(Request.Form["TransID"].ToString()));
                            objBEStudent.IntstatusFlag = 2;

                            objBStudent.BUpdateExamStatus(objBEStudent);
                            Response.Write("true");
                        }
                        break;
                    case "ValidateStep4":
                        {
                            BEStudent objBEStudent = new BEStudent();
                            BStudent objBStudent = new BStudent();
                            objBEStudent.IntTransID = Convert.ToInt64(AppSecurity.Decrypt(Request.Form["TransID"].ToString()));
                            objBEStudent.IntFlag = 0;
                            objBStudent.BSetExamStartandEndTime(objBEStudent);

                            objBStudent.BsetExamCompleted(objBEStudent);
                            Response.Write("true");
                        }
                        break;
                    case "GetSessionID":
                        {
                            BEStudent objBEStudent = new BEStudent();
                            BStudent objBStudent = new BStudent();
                            objBEStudent.IntTransID = Convert.ToInt64(AppSecurity.Decrypt(Request.Form["TransID"].ToString()));
                            objBStudent.BGetExamSessionIDWithPrefix(objBEStudent);
                            if (objBEStudent.strSessionID.Length != 0)
                            {
                                if (objBEStudent.strSessionID.Substring(0, 1).ToString() == "G")
                                    Response.Write(objBEStudent.strSessionID.Substring(2, objBEStudent.strSessionID.Length - 2));
                                else if (objBEStudent.strSessionID.Substring(0, 1).ToString() == "W")
                                {
                                    Response.Write(System.Configuration.ConfigurationManager.AppSettings["WebExURL"].ToString() + objBEStudent.strSessionID.Substring(2, objBEStudent.strSessionID.Length - 2));
                                }
                                else if (objBEStudent.strSessionID.Substring(0, 1).ToString() == "E")
                                {
                                    if (Session["isexamiFACE"].ToString() == "1")
                                    {
                                        if (objBEStudent.strSessionID.Substring(2, objBEStudent.strSessionID.Length - 2).ToString().ToUpper().Substring(0, 1) == "P")
                                            Response.Write(System.Configuration.ConfigurationManager.AppSettings["ExamityMeeting_AutoProctorURL_Premium"].ToString() + objBEStudent.strSessionID.Substring(2, objBEStudent.strSessionID.Length - 2));
                                        else
                                            Response.Write(System.Configuration.ConfigurationManager.AppSettings["ExamityMeeting_AutoProctorURL_Standard"].ToString() + objBEStudent.strSessionID.Substring(2, objBEStudent.strSessionID.Length - 2));
                                    }
                                    else
                                        Response.Write(System.Configuration.ConfigurationManager.AppSettings["ExamityMeeting_URL"].ToString() + objBEStudent.strSessionID.Substring(2, objBEStudent.strSessionID.Length - 2));
                                }
                                else
                                {
                                    Response.Write(System.Configuration.ConfigurationManager.AppSettings["ZoomJoinURL"].ToString() + objBEStudent.strSessionID.Substring(2, objBEStudent.strSessionID.Length - 2));
                                };
                            }
                        }
                        break;
                    case "UpdateNextButtonTime":
                        {
                            BEStudent objBEStudent = new BEStudent();
                            BStudent objBStudent = new BStudent();
                            objBEStudent.IntTransID = Convert.ToInt64(AppSecurity.Decrypt(Request.Form["TransID"].ToString()));
                            objBStudent.BUpdateNextButtonTime(objBEStudent);

                            Response.Write("true");
                        }
                        break;
                    case "KeyStroke":
                        {
                            PostToKeyStroke();
                        }
                        break;




                }
            }
        }

        public void PostToKeyStroke()
        {

            string userid = Session[SecureProctor.BaseClass.EnumPageSessions.USERID].ToString();
            string firstname = Request["firstname"];
            string firstnamelastname = Request["firstNameLastName"];

            BEUser objBEUser = new BEUser() { IntTransID = Convert.ToInt64(AppSecurity.Decrypt(Request.Form["TransID"].ToString())) };
            BUser objBUser = new BUser();
            objBUser.BGetProfileExamiKeyDetails(objBEUser);
            string FirstName = objBEUser.DtResult.Rows[0]["FName"].ToString();
            string lastName = objBEUser.DtResult.Rows[0]["LFName"].ToString();

            if (((firstname.Split(','))[0] == FirstName) && ((firstnamelastname.Split(','))[0] == lastName))
            {

                try
                {

                    var jsonObject = new JObject();
                    jsonObject.Add("userId", userid);
                    jsonObject.Add("client", ConfigurationManager.AppSettings["client"]);
                    jsonObject.Add("firstName", firstname);
                    jsonObject.Add("firstNameLastName", firstnamelastname);

                    var request1 = ConfigurationManager.AppSettings["apiurl"].ToString() + "examity/api/user/score";
                    var request = (HttpWebRequest)HttpWebRequest.Create(request1);
                    request.Method = "POST";
                    request.Headers["Authorization"] = ConfigurationManager.AppSettings["authkey"];

                    UTF8Encoding encoding = new UTF8Encoding();
                    byte[] byteArray = encoding.GetBytes(jsonObject.ToString());
                    request.ContentType = "application/json";
                    request.ContentLength = byteArray.Length;
                    Stream dataStream = request.GetRequestStream();
                    dataStream.Write(byteArray, 0, byteArray.Length);
                    dataStream.Close();

                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        dataStream = response.GetResponseStream();
                        StreamReader reader = new StreamReader(dataStream);
                        string ret = reader.ReadToEnd();
                        response.Close();
                        dynamic json = JValue.Parse(ret);

                        if (json.statusCode == "1003")
                        {
                            dynamic jobj = json.scoreInfo as JObject;

                            string obj = jobj.score;
                            int score = Convert.ToInt32(obj);

                            BEStudent objBEStudent = new BEStudent()
                            {
                                IntTransID = Convert.ToInt64(AppSecurity.Decrypt(Request.Form["TransID"].ToString())),
                                intExamiKeyScore = score,
                                IntType = 26
                            };
                            BStudent objBStudent = new BStudent();
                            objBStudent.BUpdateExamiKEYScore(objBEStudent);
                            objBStudent.BUpdatePLTime(objBEStudent);
                            Response.Write("true" + "|" + objBEStudent.StrResult);
                        }
                        else if (json.statusCode == "1004")
                        {
                            //lblmsg.Text = "Invalid Profile Details Provided / Profile details not found.";
                            Response.Write("false" + "|" + "Error in validating examiKEY");
                        }
                    }
                }
                catch (WebException ex)
                {
                    using (WebResponse response = ex.Response)
                    {
                        HttpWebResponse httpResponse = (HttpWebResponse)response;
                        using (Stream data = response.GetResponseStream())
                        {
                            string ret = new StreamReader(data).ReadToEnd();
                            dynamic json = JValue.Parse(ret);
                        }
                    }
                    Response.Write("false" + "|" + "Error in validating examiKEY");
                }
            }
            else
            {


                if (((firstname.Split(','))[0] == FirstName) & ((firstnamelastname.Split(','))[0] != lastName))
                {
                    Response.Write("false" + "|" + "First Name and Last Name do not match with profile data.");
                }
                else if (((firstname.Split(','))[0] != FirstName) & ((firstnamelastname.Split(','))[0] == lastName))
                {
                    Response.Write("false" + "|" + "First Name does not match with profile data.");
                }
                else if (((firstname.Split(','))[0] != FirstName) & ((firstnamelastname.Split(','))[0] != lastName))
                {
                    Response.Write("false" + "|" + "This does not match with your profile. Please try again.");
                }
                else
                {
                    Response.Write("false" + "|" + "This does not match with your profile. Please try again.");

                }
            }
        }

    }
}