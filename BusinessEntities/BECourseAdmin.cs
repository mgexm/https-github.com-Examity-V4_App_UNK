using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntities
{
  public class BECourseAdmin : BEBase
    {
        public string strFirstName { get; set; }

        public string strLastName { get; set; }

        public string strEmailAddress { get; set; }

        public Decimal ddlHours { get; set; }

        public Decimal ddlMinutes { get; set; }

        public string ddlHM { get; set; }

        public string strLinkAccessExam { get; set; }

        public DateTime strExamStartDate { get; set; }

        public DateTime strExamEndDate { get; set; }

        public Int32 strOpenBook { get; set; }
        public int intLockDownBrowser { get; set; }

        public string strNotes { get; set; }

        public System.Data.DataTable dtResult_Rules { get; set; }

        public System.Data.DataTable DtResult1 { get; set; }
        public System.Data.DataTable DtTools { get; set; }

        public int intCalc { get; set; }
        public int intStickyNotes { get; set; }

        public string strPhoneNumber { get; set; }

        public int IntBufferTime { get; set; }

        public string ddlStatus { get; set; }

        public bool strSpecialNeeds { get; set; }

        public string strSpecialNeeds1 { get; set; }
        public string strCourseID { get; set; }

        public string strUploadPath { get; set; }
        public string strOriginalFileName { get; set; }

        public string strSecurityLevel { get; set; }
        public string strSecurityLevel1 { get; set; }
        public int ddlSecurityLevel { get; set; }

        public string strPassword { get; set; }

        public int IntEnrollID { get; set; }
        public int Intstatus { get; set; }

        public int IntPeriod { get; set; }

        public int intExamFeePaidBy { get; set; }
        public int intOnDemandFeePaidBy { get; set; }

        public DateTime? dtExamStartDate { get; set; }

        public DateTime? dtExamEndDate { get; set; }

        public string strExamUserName { get; set; }

      //09nov2016
        public string CalValues { get; set; }
        public string CalText { get; set; }
        public string OpenBookText { get; set; }

        public int PastSpecialRules { get; set; }
    }
}
