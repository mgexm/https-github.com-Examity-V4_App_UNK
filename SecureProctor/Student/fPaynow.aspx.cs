using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SecureProctor.Student
{
    public partial class fPaynow : System.Web.UI.Page
    {
        public long Timestamp = 0;
        public string Amount = "";
        public string TransactionKey = string.Empty;
        public string xlogin = string.Empty;
        public string SequenceNumber = string.Empty;
        public string Hashcode = "";
        public string fActionPage = "";
        public string strFirstName = "";
        public string strLastName = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["BESTUDENT"].ToString()) != null)
            {
                BusinessEntities.BEStudent objBEStudent = (BusinessEntities.BEStudent)Session["BESTUDENT"];
                Amount = objBEStudent.decAmount.ToString();
                fActionPage = System.Configuration.ConfigurationManager.AppSettings["ActionPage"].ToString();
                xlogin = System.Configuration.ConfigurationManager.AppSettings["xlogin"].ToString();
                TransactionKey = System.Configuration.ConfigurationManager.AppSettings["TransactionKey"].ToString();
                SequenceNumber = System.Configuration.ConfigurationManager.AppSettings["SequenceNumber"].ToString();

                DateTime unixStart = DateTime.SpecifyKind(new DateTime(1970, 1, 1), DateTimeKind.Utc);
                Timestamp = (long)Math.Floor((DateTime.UtcNow - unixStart).TotalSeconds);

                Hashcode = CalculateHash.GenerateHash(TransactionKey, xlogin, SequenceNumber, Timestamp.ToString(), Amount, "");
                objBEStudent = null;
                objBEStudent = new BusinessEntities.BEStudent();
                BLL.BStudent objBStudent = new BLL.BStudent();
                objBEStudent.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID].ToString());
                objBStudent.BGetStudentName(objBEStudent);
                strFirstName = objBEStudent.DtResult.Rows[0]["FirstName"].ToString();
                strLastName = objBEStudent.DtResult.Rows[0]["LastName"].ToString();
                objBEStudent = null;
                objBStudent = null;
            }
            else
            {
                Response.Redirect("ScheduleAnExam.aspx");
            }
        }
    }
}