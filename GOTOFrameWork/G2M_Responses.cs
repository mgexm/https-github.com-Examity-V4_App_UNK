using System;

namespace GOTOFrameWork
{
    public class G2M_Token
    {
        public string access_token { get; set; }
        public string expires_in { get; set; }
        public string refresh_token { get; set; }
        public string organizer_key { get; set; }
        public string account_key { get; set; }
        public string account_type { get; set; }
    }

    public class G2M_CreatedMeetingDetails
    {
        public string joinURL { get; set; }
        public string maxParticipants { get; set; }
        public string uniqueMeetingId { get; set; }
        public string conferenceCallInfo { get; set; }
        public string meetingid { get; set; }
    }

    public class G2M_StartMeeting
    {
        public string hostURL { get; set; }
    }

    public class G2M_GetMeetingDetails
    {
        public string createTime { get; set; }
        public string passwordRequired { get; set; }
        public string status { get; set; }
        public string subject { get; set; }
        public string endTime { get; set; }
        public string conferenceCallInfo { get; set; }
        public string startTime { get; set; }
        public string duration { get; set; }
        public string maxParticipants { get; set; }
        public string meetingId { get; set; }
        public string meetingKey { get; set; }
        public string meetingType { get; set; }
        public string uniqueMeetingId { get; set; }
    }
}
