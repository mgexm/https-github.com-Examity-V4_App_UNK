using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using BusinessEntities;

namespace SecureProctor.Student
{
    public partial class AuthenticationCode : BaseClass
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                GetEmailID();
                if (Request.QueryString["TransID"] != null)
                {
                    ViewState["TransID"] = Convert.ToInt64(AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()));

                }

            }



        }

        public void GetEmailID()
        {
            BEStudent objbestudent = new BEStudent() { IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID]) };
            BStudent objbstudent = new BStudent();
            objbstudent.BGetEmailID(objbestudent);
            lblMail.Text = lblMail.Text + "  " + "<b>" + objbestudent.StrEmail + "</b>" + ".";




        }

        protected void btncode_Click(object sender, EventArgs e)
        {
            tbl1.Visible = false;
            tbl2.Visible = true;

            BEStudent objbestudent = new BEStudent() { strPassword = GetRandomPassword(5), IntTransID = Convert.ToInt64(ViewState["TransID"]) };
            BStudent objbstudent = new BStudent();
            objbstudent.BSetAuthenticationCode(objbestudent);


        }

        protected void btnValidate_Click(object sender, EventArgs e)
        {
            BEStudent objbestudent = new BEStudent() { strPassword = txtCode.Text.Trim(), IntTransID = Convert.ToInt64(ViewState["TransID"]) };
            BStudent objbstudent = new BStudent();
            objbstudent.BValidateAuthenticationCode(objbestudent);
            if (objbestudent.IntResult == 1)
            {
                tbl1.Visible = false;
                tbl2.Visible = false;
                tbl3.Visible = true;
                lblresult.Text = "Code successfully verified.";

                BEStudent objBEStudent = new BEStudent();
                BStudent objBStudent = new BStudent();
                objBEStudent.IntTransID = Convert.ToInt64(ViewState["TransID"]);
                objBEStudent.IntType = 16;
                objBStudent.BUpdatePLTime(objBEStudent);
                Response.Redirect("Agreements.aspx?TransID=" + AppSecurity.Encrypt(ViewState["TransID"].ToString()), false);

            }
            else
            {
                tbl1.Visible = false;
                tbl2.Visible = true;
                tbl3.Visible = true;
                lblresult.Text = "Invalid code, please try again.";
                txtCode.Text = "";

            }


        }

        #region GetRandowPassword
        public static string GetRandomPassword(int Length)
        {
            char[] chars = "abcdefghijklmnopqrstuvwxyz1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            string password = string.Empty;
            Random random = new Random();
            for (int i = 0; i < Length; i++)
            {
                int x = random.Next(1, chars.Length);
                if (!password.Contains(chars.GetValue(x).ToString()))
                    password += chars.GetValue(x);
                else
                    i--;
            }
            return password;
        }
        #endregion

        protected void lbtnResend_Click(object sender, EventArgs e)
        {
            tbl1.Visible = false;
            tbl2.Visible = true;
            lblresult.Text = "";
            txtCode.Text = "";

            BEStudent objbestudent = new BEStudent() { strPassword = GetRandomPassword(5), IntTransID = Convert.ToInt64(ViewState["TransID"]) };
            BStudent objbstudent = new BStudent();
            objbstudent.BSetAuthenticationCode(objbestudent);

        }


    }
}