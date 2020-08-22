using System;
namespace GOTOFrameWork
{
    public class G2MMeetings
    {
        public G2M_CreatedMeetingDetails CreateMeeting(G2M_Properties objG2MProperties, G2M_Token objG2M_Token)
        {
            G2M_CreatedMeetingDetails objG2M_CreatedMeetingDetails = null;

            var Request_Main = new RestSharp.RestClient(G2M_URLS.API);

            var Request_Sub = new RestSharp.RestRequest(G2M_URLS.Meetings_Create, RestSharp.Method.POST);

            Request_Sub.AddHeader("Accept", "application/json");
            Request_Sub.AddHeader("Content-Type", "application/json");
            Request_Sub.AddHeader("Authorization", string.Format("OAuth oauth_token={0}", objG2M_Token.access_token));

            //creating the meeting request json for the request.
            Newtonsoft.Json.Linq.JObject objMeetingParameters = new Newtonsoft.Json.Linq.JObject();
            objMeetingParameters.Add(new Newtonsoft.Json.Linq.JProperty("subject", objG2MProperties.strMeetingSubject));
            objMeetingParameters.Add(new Newtonsoft.Json.Linq.JProperty("starttime", DateTime.UtcNow.AddMinutes(1).ToString("s")));
            objMeetingParameters.Add(new Newtonsoft.Json.Linq.JProperty("endtime", DateTime.UtcNow.AddMinutes(objG2MProperties.intMeetingMinutes+1).ToString("s")));
            objMeetingParameters.Add(new Newtonsoft.Json.Linq.JProperty("passwordrequired", "false"));
            objMeetingParameters.Add(new Newtonsoft.Json.Linq.JProperty("conferencecallinfo", "VoIP"));
            objMeetingParameters.Add(new Newtonsoft.Json.Linq.JProperty("timezonekey", ""));
            objMeetingParameters.Add(new Newtonsoft.Json.Linq.JProperty("meetingtype", "Immediate"));

            string gtmJSON = Newtonsoft.Json.JsonConvert.SerializeObject(objMeetingParameters);

            Request_Sub.AddParameter("application/json", gtmJSON, RestSharp.ParameterType.RequestBody);

            var Response_Meeting = Request_Main.Execute(Request_Sub);

            if (Response_Meeting.StatusCode == System.Net.HttpStatusCode.Created)
            {
                var jsonCode = Response_Meeting.Content;
                objG2M_CreatedMeetingDetails = Newtonsoft.Json.JsonConvert.DeserializeObject<G2M_CreatedMeetingDetails>(jsonCode.Substring(1, jsonCode.Length - 2));
            }

            return objG2M_CreatedMeetingDetails;
        }


        public int DeleteMeeting(G2M_Properties objG2MProperties, G2M_Token objG2M_Token)
        {
            int intReturn = 0;

            var Request_Main = new RestSharp.RestClient(G2M_URLS.API);

            var Request_Sub = new RestSharp.RestRequest(G2M_URLS.Meetings_Delete + objG2MProperties.strMeetingID, RestSharp.Method.DELETE);

            Request_Sub.AddHeader("Accept", " application/json");
            Request_Sub.AddHeader("Content-type", "application/json");
            Request_Sub.AddHeader("Authorization", string.Format("OAuth oauth_token={0}", objG2M_Token.access_token));

            var Response_Meeting = Request_Main.Execute(Request_Sub);

            if (Response_Meeting.ResponseStatus.ToString() == "Completed")
                intReturn = 1;

            return intReturn;
        }


        public string GetMeeting(G2M_Properties objG2MProperties, G2M_Token objG2M_Token)
        {
            string strResult = string.Empty;

            var Request_Main = new RestSharp.RestClient(G2M_URLS.API);

            var Request_Sub = new RestSharp.RestRequest(G2M_URLS.Meetings_GetMeeting + objG2MProperties.strMeetingID, RestSharp.Method.GET);

            Request_Sub.AddHeader("Accept", " application/json");
            Request_Sub.AddHeader("Content-type", "application/json");
            Request_Sub.AddHeader("Authorization", string.Format("OAuth oauth_token={0}", objG2M_Token.access_token));

            var Response_Meeting = Request_Main.Execute(Request_Sub);

            if (Response_Meeting.StatusCode == System.Net.HttpStatusCode.OK)
            {
                strResult = Response_Meeting.Content;
            }
            return strResult;
        }


        public string GetMeetings(G2M_Token objG2M_Token)
        {
            string strResult = string.Empty;

            var Request_Main = new RestSharp.RestClient(G2M_URLS.API);

            var Request_Sub = new RestSharp.RestRequest(G2M_URLS.Meetings_GetMeetings, RestSharp.Method.GET);

            Request_Sub.AddHeader("Accept", " application/json");
            Request_Sub.AddHeader("Content-type", "application/json");
            Request_Sub.AddHeader("Authorization", string.Format("OAuth oauth_token={0}", objG2M_Token.access_token));

            var Response_Meeting = Request_Main.Execute(Request_Sub);

            if (Response_Meeting.StatusCode == System.Net.HttpStatusCode.OK)
            {
                strResult = Response_Meeting.Content;
            }
            return strResult;
        }


        public G2M_StartMeeting StartMeeting(G2M_Properties objG2MProperties, G2M_Token objG2M_Token)
        {
            G2M_StartMeeting objG2M_StartMeeting = null;

            var Request_Main = new RestSharp.RestClient(G2M_URLS.API);

            var Request_Sub = new RestSharp.RestRequest(G2M_URLS.Meetings_StartMeeting.Replace("@MEETINGID", objG2MProperties.strMeetingID), RestSharp.Method.GET);

            Request_Sub.AddHeader("Accept", " application/json");
            Request_Sub.AddHeader("Content-type", "application/json");
            Request_Sub.AddHeader("Authorization", string.Format("OAuth oauth_token={0}", objG2M_Token.access_token));

            var Response_Meeting = Request_Main.Execute(Request_Sub);

            if (Response_Meeting.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonCode = Response_Meeting.Content;
                objG2M_StartMeeting = Newtonsoft.Json.JsonConvert.DeserializeObject<G2M_StartMeeting>(jsonCode);
            }
            return objG2M_StartMeeting;
        }


        public string UpdateMeeting(G2M_Properties objG2MProperties, G2M_Token objG2M_Token)
        {
            string strResult = string.Empty;

            var Request_Main = new RestSharp.RestClient(G2M_URLS.API);

            var Request_Sub = new RestSharp.RestRequest(G2M_URLS.Meetings_UpdateMeeting + objG2MProperties.strMeetingID, RestSharp.Method.PUT);

            Request_Sub.AddHeader("Accept", " application/json");
            Request_Sub.AddHeader("Content-type", "application/json");
            Request_Sub.AddHeader("Authorization", string.Format("OAuth oauth_token={0}", objG2M_Token.access_token));

            //creating the meeting request json for the request.
            Newtonsoft.Json.Linq.JObject objMeetingParameters = new Newtonsoft.Json.Linq.JObject();
            objMeetingParameters.Add(new Newtonsoft.Json.Linq.JProperty("subject", "ExamityMeeting_Updated"));
            objMeetingParameters.Add(new Newtonsoft.Json.Linq.JProperty("starttime", DateTime.UtcNow.AddHours(20).ToString("s")));
            objMeetingParameters.Add(new Newtonsoft.Json.Linq.JProperty("endtime", DateTime.UtcNow.AddHours(21).ToString("s")));
            objMeetingParameters.Add(new Newtonsoft.Json.Linq.JProperty("passwordrequired", "false"));
            objMeetingParameters.Add(new Newtonsoft.Json.Linq.JProperty("conferencecallinfo", "Hybrid"));
            objMeetingParameters.Add(new Newtonsoft.Json.Linq.JProperty("timezonekey", ""));
            objMeetingParameters.Add(new Newtonsoft.Json.Linq.JProperty("meetingtype", "Scheduled"));

            string gtmJSON = Newtonsoft.Json.JsonConvert.SerializeObject(objMeetingParameters);

            Request_Sub.AddParameter("application/json", gtmJSON, RestSharp.ParameterType.RequestBody);

            var Response_Meeting = Request_Main.Execute(Request_Sub);

            if (Response_Meeting.StatusCode == System.Net.HttpStatusCode.Created)
            {
                var jsonCode = Response_Meeting.Content;
                //objG2M_CreatedMeetingDetails = Newtonsoft.Json.JsonConvert.DeserializeObject<G2M_CreatedMeetingDetails>(jsonCode);
            }
            else
                strResult = Response_Meeting.Content;

            return strResult;
        }
    }
}
