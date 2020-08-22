using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SecureProctor.Student;
using System.Xml;
using BLL;
using BusinessEntities;

namespace SecureProctor.Auditor
{
    public partial class DisplayVideo : System.Web.UI.Page
    {
        public string SessionID = "";
        public string TokenID = "";
        public String videosource = "";
        public string ArchiveId = "";
        public string videoid = "";
        public string Transid = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["Transid"] != null)
            {

                Transid = AppSecurity.Decrypt(Request.QueryString["Transid"].ToString());


                BECommon objBECommon = new BECommon();
                objBECommon.strTransID = Transid;
                BCommon objBCommon = new BCommon();
                objBCommon.BOpenTokGetArchiveID(objBECommon);
                ArchiveId = objBECommon.strArchiveId;

                if (ArchiveId.Trim().Length > 0)
                {
                    SessionID = "2_MX4yODQ2NTExMn4xOTIuMTY4LjEuMX5TdW4gTWF5IDEyIDIzOjQyOjMyIFBEVCAyMDEzfjAuNjk0NzQ5OH4";
                    //SessionID = "2_MX4yODQ2NTExMn5-V2VkIE1heSAwOCAwMDoxODowNCBQRFQgMjAxM34wLjIxNTc2MDQxfg";
                    OpenTokSDK opentok = new OpenTokSDK();

                    Dictionary<string, object> options = new Dictionary<string, object>();
                    options.Add("role", "moderator");

                    TokenID = opentok.GenerateToken(SessionID, options);

                    //Response.Clear();

                    System.Net.WebRequest request = System.Net.WebRequest.Create(@"https://api.opentok.com/hl/archive/getmanifest/" + ArchiveId.Trim());

                    request.Headers.Add("x-tb-token-auth", TokenID);
                    //api key and secret key
                    request.Headers.Add("X-TB-PARTNER-AUTH", "28465112:4ccafe5e867b5d99722c9b089593b9460bc02f1d");

                    System.Net.WebResponse response = request.GetResponse();

                    System.IO.StreamReader sr = new System.IO.StreamReader(response.GetResponseStream(), System.Text.Encoding.Default);


                    string content = sr.ReadToEnd();

                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(content);

                    XmlNodeList elementList = xmlDoc.GetElementsByTagName("video");
                    for (int i = 0; i < elementList.Count; i++)
                    {
                        videoid = elementList[i].Attributes["id"].Value;
                    }

                    sr.Close();


                    request = System.Net.WebRequest.Create(@"https://api.opentok.com/hl/archive/url/" + ArchiveId.Trim() + "/" + videoid.Trim());

                    request.Headers.Add("x-tb-token-auth", TokenID);
                    request.Headers.Add("X-TB-PARTNER-AUTH", "28465112:4ccafe5e867b5d99722c9b089593b9460bc02f1d");

                    response = request.GetResponse();

                    sr = new System.IO.StreamReader(response.GetResponseStream(), System.Text.Encoding.Default);


                    content = sr.ReadToEnd();

                    sr.Close();

                    //Response.Redirect(content.ToString());
                    videosource = Server.UrlEncode(content.ToString());
                    //Response.Write(videosource);
                }
            }
        }
    }
}