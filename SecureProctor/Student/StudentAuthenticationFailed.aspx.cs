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
    public partial class StudentAuthenticationFailed : System.Web.UI.Page
    {
        string TYPE = "";
        string frompage = string.Empty; 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["examiKEY"] != null)
            {
                TYPE = AppSecurity.Decrypt(Request.QueryString["examiKEY"].ToString());
            }
            if (Request.QueryString["From"] != null)
            {
                frompage = AppSecurity.Decrypt(Request.QueryString["From"].ToString());
            }
        }

        protected void btnnext_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["TransID"] != null)
            {
                Int64 TransID = Convert.ToInt64(AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()));
                BEStudent objBEStudent = new BEStudent();
                BStudent objBStudent = new BStudent();
                objBEStudent.IntTransID = TransID;
                objBEStudent.IntFlag = Convert.ToInt32(frompage);
                objBStudent.BGetAuthenticationOverrideStatus(objBEStudent);
            
                if(objBEStudent.DtResult.Rows.Count>0 && objBEStudent.DtResult.Rows[0][0].ToString()!="")
                {
                    if (TYPE == "1")
                    {
                        if (objBEStudent.DtResult.Rows[0][0].ToString() == "AGREE")
                        {
                            Response.Redirect("StudentAgreements.aspx?TransID=" + Request.QueryString["TransID"].ToString() + "&&ExamiKEY=" + AppSecurity.Encrypt("1"), false);
                        }
                        else if (objBEStudent.DtResult.Rows[0][0].ToString() == "KEY")
                        {
                            Response.Redirect("studentexamiKEY.aspx?TransID=" + Request.QueryString["TransID"].ToString() + "&&ExamiKEY=" + AppSecurity.Encrypt("1"), false);
                        }
                    }
                    else
                    {
                        if (objBEStudent.DtResult.Rows[0][0].ToString() == "AGREE")
                        {
                            Response.Redirect("StudentAgreements.aspx?TransID=" + Request.QueryString["TransID"].ToString() + "&&ExamiKEY=" + AppSecurity.Encrypt("0"), false);
                        }
                    }

                }

            }


        }
    }
}