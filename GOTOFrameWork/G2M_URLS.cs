using System;
namespace GOTOFrameWork
{
    public class G2M_URLS
    {
        //ADMIN 
        public const string Admin_URL = "https://login.citrixonline.com/cas-service/login";

        //MAIN API
        //public const string API = "https://api.citrixonline.com"; //Old URL
        public const string API = "https://api.getgo.com";       //  New URL

        //AUTHENTICATION
        public const string Authentication_Direct = "/oauth/access_token";

        //MEETINGS
        public const string Meetings_Create = "/G2M/rest/meetings";
        public const string Meetings_Delete = "/G2M/rest/meetings/";
        public const string Meetings_GetMeeting = "/G2M/rest/meetings/";
        public const string Meetings_GetMeetings = "/G2M/rest/meetings?scheduled=true";
        public const string Meetings_StartMeeting = "/G2M/rest/meetings/@MEETINGID/start";
        public const string Meetings_UpdateMeeting = "/G2M/rest/meetings/";

        //ORGANIZERS
        public const string Organizer_Create = "/G2M/rest/groups/@GROUPKEY/organizers";

        //GROUPS
        public const string Groups_GetGroups = "/G2M/rest/groups";

    }
}
