using System;
using System.Data;

namespace BusinessEntities
{
    public class BEBase
    {
        public int IntResult { get; set; }
        public string StrResult { get; set; }
        public bool BoolResult { get; set; }

        public System.Data.DataTable DtResult { get; set; }
        public System.Data.DataSet DsResult { get; set; }

        public int IntUserID { get; set; }
        public Int64 IntTransID { get; set; }
        public long LngTransID { get; set; }

        public int IntFlag { get; set; }

        public int IntCourseID { get; set; }
        public int IntExamID { get; set; }
        public Int64 IntExamID1 { get; set; }

        public int IntType { get; set; }

        public string strProviderEmailID { get; set; }

        public bool StudentIdentity { get; set; }
        public string strOTSessionID { get; set; }
        //public DataTable DtResult1 { get; set; }
        //public DataTable DtResult2 { get; set; }
        //public DataTable DtResult3 { get; set; }
        //public DataTable DtResult4 { get; set; }

        public DataTable DtStudentResult { get; set; }

        public string DtStartDate { get; set; }
        public string DtEndDate { get; set; }

        public string StrddlComments { get; set; }
        public string StrComments { get; set; }

        public int IntEmployeeID { get; set; }

        public int IntstatusFlag { get; set; }

        public string strExamName { get; set; }
        public string strCourseName { get; set; }

        public string SlotDetails { get; set; }
        public DateTime dtExam { get; set; }
        public Int64 IntScheduleID { get; set; }

        public int IntStudentID { get; set; }
        public string strTimeZone { get; set; }

        public int iTimeZoneID { get; set; }

        public string strStudentName { get; set; }
        public string StrEmailID { get; set; }
        public string StrRandomPassword { get; set; }
        public string Struserlogin { get; set; }
        public string StrFirstName { get; set; }
        public string StrLastName { get; set; }
        public string StrEmail { get; set; }
        public string StrGender { get; set; }

        public int IntProviderID { get; set; }

        public string strStatus { get; set; }

        public int intHours { get; set; }
        public decimal decAmount { get; set; }
        public int intStudentUploadFile { get; set; }
        public int intExamByFile { get; set; }

        public int intYear { get; set; }
        public int intMonth { get; set; }

        public int intStart { get; set; }
        public int intEnd { get; set; }
        public bool intPrimaryIns { get; set; }
        public string strUserName { get; set; }
        public string CountryCode { get; set; } //11Sep2017
    }
}
