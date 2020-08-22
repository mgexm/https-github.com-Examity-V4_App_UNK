using System;
using System.Data;

namespace BusinessEntities
{
    public class BEProctor : BEBase 
    {
        public DateTime dtDate { get; set; }
        public string StrDate { get; set; }
        public string strExamName { get; set; }
        public string strStudentName { get; set; }
        public int iStudentID { get; set; }
        public int ExamTime { get; set; }
        public string strOriginalFileName { get; set; }
        public string strUploadPath { get; set; }
        public bool boolcam { get; set; }
        public bool boolaudio { get; set; }
        public bool booldesktop { get; set; }
        public bool boolidvalid { get; set; }
        public string strOs { get; set; }
        public string strBrowser { get; set; }
        public string strProctorComments { get; set; }

        public string strExamSessionID { get; set; }
        public string strMeetingUserName { get; set; }
        public string strMeetingPassword { get; set; }
        public string strMeetingToken { get; set; }
        public string strZoomHostId { get; set; } 
        public string strExamDuration { get; set; }
        public int intExamBufferTime { get; set; }

        public int ProctorID { get; set; }

        public string strSlotDate { get; set; }
        public string strSlotTime { get; set; }
        public int intAllDay { get; set; }
        public int intID { get; set; }
        public DataSet objDs { get; set; }
        public string strTransID { get; set; }
        public string Uname { get; set; } //added for passing the username for wfm dashboard on 8.8.2017
    }
}
