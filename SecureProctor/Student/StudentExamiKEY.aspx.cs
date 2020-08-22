using BusinessEntities;
using BLL;
using System;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;


namespace SecureProctor.Student
{
    public partial class StudentExamiKEY : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["TransID"] != null)
            {
                BEStudent objBEStudent = new BEStudent();
                BStudent objBStudent = new BStudent();
                objBEStudent.IntTransID = Convert.ToInt64(AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()));              
                objBStudent.BGetAAexamiKEYstatus(objBEStudent);


                if (objBEStudent.IntResult == 0)
                {
                        Response.Redirect("StudentAgreements.aspx?TransID=" + Request.QueryString["TransID"].ToString() + "&&ExamiKEY=" + AppSecurity.Encrypt("1") + "&&From=" + AppSecurity.Encrypt("2"), false);
                }
                if (objBEStudent.IntResult == 1)
                {
                    Response.Redirect("StudentAuthenticationFailed.aspx?TransID=" + Request.QueryString["TransID"].ToString() + "&&ExamiKEY=" + AppSecurity.Encrypt("1") + "&&From=" + AppSecurity.Encrypt("2"), false);
                }
            }
        }
    }
}