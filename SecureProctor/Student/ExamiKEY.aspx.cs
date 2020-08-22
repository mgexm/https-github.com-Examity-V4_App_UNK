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
    public partial class ExamiKEY : System.Web.UI.Page
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
                    objBEStudent.IntType = 26;
                    objBStudent.BUpdatePLTime(objBEStudent);
                    objBStudent.BGetAAexamiKEYstatus(objBEStudent);
                    if (objBEStudent.IntResult == 0)
                    {
                        Response.Redirect("Agreements.aspx?TransID=" + Request.QueryString["TransID"].ToString(), false);

                    }
                    if (objBEStudent.IntResult == 1)
                    {
                        Response.Redirect("AuthenticationFailed.aspx?TransID=" + Request.QueryString["TransID"].ToString(), false);
                    }
                
            }


        }


        
    }
}