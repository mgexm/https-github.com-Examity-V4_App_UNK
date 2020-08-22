using System;
namespace GOTOFrameWork
{
    public class G2MGroups
    {
        public string GetGroups(G2M_Token objG2M_Token)
        {
            string strResult = string.Empty;

            var Request_Main = new RestSharp.RestClient(G2M_URLS.API);

            var Request_Sub = new RestSharp.RestRequest(G2M_URLS.Groups_GetGroups, RestSharp.Method.GET);

            Request_Sub.AddHeader("Accept", " application/json");
            Request_Sub.AddHeader("Content-type", "application/json");
            Request_Sub.AddHeader("Authorization", string.Format("OAuth oauth_token={0}", objG2M_Token.access_token));

            var Response_Meeting = Request_Main.Execute(Request_Sub);

            strResult = Response_Meeting.Content;

            return strResult;
        }
    }
}
