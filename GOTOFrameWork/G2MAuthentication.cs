using System;

namespace GOTOFrameWork
{
    public class G2MAuthentication
    {
        public G2M_Token GetAuthenticationToken(G2M_Properties objG2MProperties)
        {
            G2M_Token objMeetingAccessToken = null;

            var Request_Main = new RestSharp.RestClient(G2M_URLS.API);

            RestSharp.RestRequest Request_Authentication = new RestSharp.RestRequest(G2M_URLS.Authentication_Direct + "?grant_type=password&client_id=" + G2M_Keys.Client_ID + "&user_id=" + objG2MProperties.strUserName + "&password=" + objG2MProperties.strPassword, RestSharp.Method.GET);

            var Response_Authentication = Request_Main.Execute(Request_Authentication);

            if (Response_Authentication.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonCode = Response_Authentication.Content;
                objMeetingAccessToken = Newtonsoft.Json.JsonConvert.DeserializeObject<G2M_Token>(jsonCode);
            }

            return objMeetingAccessToken;
        }

    }
}
