using System;
using System.Data;

namespace BusinessEntities
{
    public class BEAuditor : BEBase 
    {
        public DataSet objDs { get; set; }

        //public int intEmployeeID { get; set; }

        public string strTransID { get; set; }

        public int IntCommentID { get; set; }

        public string TimeStamp { get; set; }

        public string strAddedBy { get; set; }
        public DateTime strAddedOn { get; set; }

        public int IntPeriod { get; set; }
        public int IntAletID { get; set; }
    }
}
