using System;

namespace BusinessEntities
{
    public class BEUser : BEBase 
    {
        public string StrUserId { get; set; }
        public string StrUserName { get; set; }
        public string StrPassword { get; set; }
        public string StrUserAliasName { get; set; }
        public int intDualRole { get; set; }
        public int IntTimeZoneID { get; set; }
        public int IntRoleID { get; set; }
        //public string strTimeZone { get; set; }
        public string StringTimeZone { get; set; }
        public string StrPasswordReset { get; set; }
        public string strOldPassword { get; set; }
        public string strNewPassword { get; set; }
        public string strConfirmNewPassword { get; set; }
        public string strPhoneNumber { get; set; }

        public string strStudentCode { get; set; }
        public int intProfileUpdate { get; set; }
        public bool loginflag { get; set; }

        public string PaidBy_ExamFee { get; set; }
        public string PaidBy_OndemandFee { get; set; }
        public string strRole { get; set; }
        public int IsExistingRoleUser { get; set; }
        public string strCourseId { get; set; }
        public string strUser_Id { get; set; }
    }
}
