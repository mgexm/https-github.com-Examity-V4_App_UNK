using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BusinessEntities
{
   public class BEReports
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CurrentDate { get; set; }
        public string Status { get; set; }
        public string RoleID { get; set; }
        public string InstructorId { get; set; }
        public string paidexamfee { get; set; }
        public string paidondemandfee { get; set; }
        // public int ClientID { get; set; }

        //Proctor Shifts
        public int ShiftId { get; set; }
        public string ShiftName { get; set; }
        public bool Other { get; set; }
        public DateTime ShiftDate { get; set; }
        public string ShiftTiming { get; set; }
        public string ProctorName { get; set; }

        public DateTime StartDate1 { get; set; }
        public DateTime EndDate1 { get; set; }
        public string PendindatAuditorStatus { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int AssignedMe { get; set; }
        public string PromotionCode { get; set; }
        public DataSet dsResult { get; set; }
    }
}
