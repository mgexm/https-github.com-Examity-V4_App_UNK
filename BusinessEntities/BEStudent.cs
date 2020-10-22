using System;
using System.Data;

namespace BusinessEntities
{
    public class BEStudent : BEBase
    {
        public string strExamDate { get; set; }
        //public int IntProviderID { get; set; }
        //public string strExamName { get; set; }
        public string strAnswer1 { get; set; }
        public string strAnswer2 { get; set; }
        public string strAnswer3 { get; set; }
        public string strUploadPath { get; set; }
        public string strOriginalFileName { get; set; }
        public string strQuestion1 { get; set; }
        public string strQuestion2 { get; set; }
        public string strQuestion3 { get; set; }
        public string strFirstName { get; set; }
        public string strLastName { get; set; }
        public string strPassword { get; set; }
        public string strConfirmPassword { get; set; }
        //public string strUserName { get; set; }
        public string strGender { get; set; }
        public string strphoneNumber { get; set; }
        public string strPrefferedPhoneNumber { get; set; }

        public string strSubject { get; set; }
        public string strDescription { get; set; }
        public string strExamLink { get; set; }

        public int intFlagPhotoIdentity { get; set; }
        public int intFlagSecurityQuestions { get; set; }
        public int intFlagPhoneNUmber { get; set; }

        public string strSessionID { get; set; }
        //public int IntResult { get; set; }

        public int intOndemand { get; set; }

        public decimal decExamFee { get; set; }
        public decimal decOnDemandFee { get; set; }

        public int intExamFeePaidBy { get; set; }
        public int intOndemandPaidBy { get; set; }
        public decimal PerHourFee { get; set; }

        public string strOrderID { get; set; }
        public int intReExam { get; set; }
        public int intStep { get; set; }
        public int intExamiKeyScore { get; set; }

        public string strBrowser { get; set; }
        public string strBrowserVersion { get; set; }
        public string strOS { get; set; }
    }

}
