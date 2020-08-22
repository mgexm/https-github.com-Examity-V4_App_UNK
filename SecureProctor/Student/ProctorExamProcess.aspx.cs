using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using BusinessEntities;
using BLL;
using System.IO;

namespace SecureProctor.Student
{
    public partial class ProctorExamProcess : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void btnProceed_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["TransID"] != null)
            {


              
                this.SetFlags("PROCEED", 0);
                BEStudent objBEStudent = new BEStudent();
                BStudent objBStudent = new BStudent();
                objBEStudent.IntTransID = Convert.ToInt64(GetTransID());
                objBStudent.BUpdateProceedTime(objBEStudent);

               
            }
        }

        protected void SetFlags(string strType, int intValue)
        {
            BEProctor objBEProctor = new BEProctor();
            BProctor objBProctor = new BProctor();
            objBEProctor.IntTransID = Convert.ToInt64(AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()));
            objBEProctor.strStatus = strType;
            objBEProctor.IntResult = intValue;
            objBProctor.BSetTransactionFlags(objBEProctor);
        }

        public string GetTransID()
        {
          
            return AppSecurity.Decrypt(Request.QueryString["TransID"].ToString());
          
        }

        protected void btnStep1Next_Click(object sender, EventArgs e)
        {
           
        }
    }
}