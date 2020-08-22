using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessEntities;
using BLL;

namespace SecureProctor.Student
{
    public partial class ExamiKNOW : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.BindSecurityQuestions();

            }



        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            BStudent objBStudent = new BStudent();
            BEStudent objBEStudent = new BEStudent();
            objBEStudent.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID].ToString());
            objBEStudent.strAnswer1 = txtAnswer1.Text;
            objBEStudent.strQuestion1 = hfQid.Value;

            if (Request.QueryString["TransID"] != null)
            {
                objBEStudent.IntTransID = Convert.ToInt64(AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()));
            }
            else
            {
                Response.Redirect("StartAnExam.aspx");

            }
           // objBEStudent.IntTransID = Convert.ToInt32(HfTransID.Value);

            objBStudent.BAARandomSecurityQuestionsValidation(objBEStudent);

            if (objBEStudent.IntResult == 1)
            {   
                objBEStudent.IntType = 8;
                objBStudent.BUpdatePLTime(objBEStudent);

                Response.Redirect("examiKEY.aspx?TransID=" + Request.QueryString["TransID"].ToString(),false);
             
             
            }
            else
            {
                 var arr= objBEStudent.StrResult.Split('|');
                 var x = arr[0];
                 if (x == "nextQuestion")
                 {
                      hfQid.Value=arr[1].ToString();
                    lblQuestion1.Text=arr[2].ToString();
                     lblFailed.Text="";
                     txtAnswer1.Text = "";
                     txtAnswer1.Focus();
                     
                 }

                 else if (x == "Locked")
                 {
                     Response.Redirect("AuthenticationFailed.aspx?TransID=" + Request.QueryString["TransID"].ToString(), false);
                     
                 }
                 else
                 {
                     lblFailed.Text = x.ToString();
                     txtAnswer1.Text = "";
                     txtAnswer1.Focus();
                                    
                 }


               // lblFailed.Text = objBEStudent.StrResult.ToString();
          

            }


        }

        public void BindSecurityQuestions()
        {
            try
            {
                BStudent objBStudent = new BStudent();
                BEStudent objBEStudent = new BEStudent();
                objBEStudent.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID].ToString());
                objBStudent.BGetRandomQuestion(objBEStudent);
                if (objBEStudent.DtResult.Rows.Count > 0)
                {
                    lblQuestion1.Text = objBEStudent.DtResult.Rows[0]["QText"].ToString();

                    hfQid.Value = objBEStudent.DtResult.Rows[0]["Qid"].ToString();
                   



                }
                objBStudent = null;
                objBEStudent = null;
            }
            catch (Exception Ex)
            {
                //  ErrorLog.WriteError(Ex);
            }
        }
    }
}