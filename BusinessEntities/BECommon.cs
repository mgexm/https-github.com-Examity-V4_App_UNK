using System;
using System.Data;

namespace BusinessEntities
{
    public class BECommon : BEBase
    {
        //public int TransID { get; set; }
        public string PUid { get; set; }
        public string Puname { get; set; }
        public bool Plogin { get; set; }

        public string DUid { get; set; }
        public string Duname { get; set; }
        public bool Dlogin { get; set; }

        public int intRoleID { get; set; }

        public int intAlertID { get; set; }

        public int IntRoleID { get; set; }

        public int iReportID { get; set; }

        public string strTime { get; set; }

        public int intReportTypeID { get; set; }

        public DateTime DateStartDate { get; set; }
        public DateTime DateEndDate { get; set; }

        public string TransID { get; set; }

        public string GotoMeetingID { get; set; }
        public Int64 iID { get; set; }
        public int iTypeID { get; set; }
        public string StrFromPage { get; set; }


        public int intOndemand { get; set; }
        public string strCommentID { get; set; }
        public int intCommentID { get; set; }
        public int intTypeID { get; set; }
        public int intExamiKeyScore { get; set; }

        public Byte[] image { get; set; }

        public int intRuleID { get; set; }
        public string StrRuleDesc { get; set; }
        public int intRoleTypeID { get; set; }
        public int intDisplayType { get; set; }



        #region Opentok entities
        public string strTransID { get; set; }
        public string strSessionID { get; set; }
        public string strResult { get; set; }
        public DataSet _DataSet { get; set; }
        public string strErrorDesc { get; set; }
        public string strArchiveId { get; set; }
        #endregion


       
    }
}
