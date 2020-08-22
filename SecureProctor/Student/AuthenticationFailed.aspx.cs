using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessEntities;
using BLL;

namespace SecureProctor.Student
{
    public partial class AuthenticationFailed : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.QueryString["TransID"] != null)
            {
                Int64 TransID=Convert.ToInt64(AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()));

                BEStudent objBEStudent = new BEStudent();
                BStudent objBStudent = new BStudent();
                objBEStudent.IntTransID = TransID;
                objBEStudent.IntResult = 0;
           
                objBStudent.BUpdateNonProctorExamStatus(objBEStudent);
            }
        }
    }
}