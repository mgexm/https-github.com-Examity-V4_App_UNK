using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessEntities;
using BLL;
using System.IO;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Configuration;

namespace SecureProctor.Student
{
    public partial class UpdateExamiKEY : BaseClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                trKeyStrokeEdit.Visible = true;
                lblkeyMsg.Text = "";
                imgOK.Visible = false;
                trheading.Visible = true;
                //trSucess.Visible = false;
                //trError.Visible = false;
            }




        }

        protected void btnradSave_Click(object sender, EventArgs e)
        {
            PostToKeyStroke();
           

        }

        public void PostToKeyStroke()
        {
            try
            {
                string userid = Session[EnumPageSessions.USERID].ToString();
                string firstname = Request["firstname"];
                string firstnamelastname = Request["firstNameLastName"];
                string refirstNameLastName = Request["refirstNameLastName"];

                var jsonObject = new JObject();
                jsonObject.Add("userId", userid);
                jsonObject.Add("client", ConfigurationManager.AppSettings["client"]);
                jsonObject.Add("firstName", firstname);
                jsonObject.Add("firstNameLastName", firstnamelastname);
                jsonObject.Add("refirstNameLastName", refirstNameLastName);

                var request1 = ConfigurationManager.AppSettings["apiurl"].ToString() + "examity/api/user/profile";
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

                    if (json.statusCode == "1001")
                    {

                        trKeyStrokeEdit.Visible = false;
                        imgOK.Visible = true;
                        trheading.Visible = false;
                      

                        BEStudent objBEStudent = new BEStudent()
                        {
                            IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID]),
                            strFirstName = (firstname.Split(','))[0],
                            strLastName = (firstnamelastname.Split(','))[0]
                        };
                        BStudent objBStudent = new BStudent();
                        objBStudent.BUpdateKeyStrokeDetails(objBEStudent);
                        
                        lblkeyMsg.Text = "<img src='../Images/yes.png'align='middle'/>&nbsp;<font color='#00C000'>" + Resources.ResMessages.MyProfile_ExamiKEYUpdated + "</font>";
                    }
                    else if (json.statusCode == "1002")
                    {

                        trKeyStrokeEdit.Visible = true;
                        imgOK.Visible = false;
                        trheading.Visible = true;
                     
                      

                        lblkeyMsg.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + Resources.ResMessages.MyProfile_ExamiKEYNotUpdated1 + "</font>";
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
                        trKeyStrokeEdit.Visible = true;
                        imgOK.Visible = false;
                        trheading.Visible = true;
                      

                        lblkeyMsg.Text = "<img src='../Images/no.png'align='middle'/>&nbsp;<font color='red'>" + Resources.ResMessages.MyProfile_ExamiKEYNotUpdated + "</font>";
                    }
                }
            }
        }

        protected void imgOK_Click(object sender, EventArgs e)
        {
            Response.Redirect(EnumAppPage.STUDENT_HOME, false);
        }

       
    }
}