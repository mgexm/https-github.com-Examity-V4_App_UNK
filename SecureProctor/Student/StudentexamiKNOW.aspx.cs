using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessEntities;
using BLL;

namespace SecureProctor.Student
{
    public partial class StudentexamiKNOW : BaseClass
    {
        string TYPE = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["examiKEY"] != null)
            {
                  TYPE = AppSecurity.Decrypt(Request.QueryString["examiKEY"].ToString());
                if (TYPE == "1")
                {

                    WithoutKEYStep2.Style.Add("display", "none");
                    WithKEYStep2.Style.Add("display", "block");
                }
                else
                {
                    WithoutKEYStep2.Style.Add("display", "block");
                    WithKEYStep2.Style.Add("display", "none");
                }
            }
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
                    if (TYPE == "1")
                    {
                        Response.Redirect("studentexamiKEY.aspx?TransID=" + Request.QueryString["TransID"].ToString() + "&&ExamiKEY=" + AppSecurity.Encrypt("1"), false);
                    }
                    else
                    {
                        Response.Redirect("StudentAgreements.aspx?TransID=" + Request.QueryString["TransID"].ToString() + "&&ExamiKEY=" + AppSecurity.Encrypt("0"), false);
                    }
            }
            else
            {
                var arr = objBEStudent.StrResult.Split('|');
                var x = arr[0];
                if (x == "nextQuestion")
                {
                    hfQid.Value = arr[1].ToString();
                    lblQuestion1.Text = arr[2].ToString();
                    lblFailed.Text = "";
                    txtAnswer1.Text = "";
                    txtAnswer1.Focus();
                   

                }

                else if (x == "Locked")
                {
                    if (TYPE == "1")
                    {
                        Response.Redirect("StudentAuthenticationFailed.aspx?TransID=" + Request.QueryString["TransID"].ToString() + "&&ExamiKEY=" + AppSecurity.Encrypt("1") + "&&From=" + AppSecurity.Encrypt("1"), false);
                    }
                    else
                    {
                        Response.Redirect("StudentAuthenticationFailed.aspx?TransID=" + Request.QueryString["TransID"].ToString() + "&&ExamiKEY=" + AppSecurity.Encrypt("0") + "&&From=" + AppSecurity.Encrypt("1"), false);
                    }
                   

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
            catch (Exception )
            {
                //  ErrorLog.WriteError(Ex);
            }
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            BEStudent objBEStudent = new BEStudent();
            BStudent objBStudent = new BStudent();
            objBEStudent.IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID].ToString());
            objBEStudent.IntTransID = Convert.ToInt64(AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()));
            objBStudent.BCheckexamiKEY(objBEStudent);

            if (objBEStudent.DtResult != null && objBEStudent.DtResult.Rows.Count > 0)
            {
               
                    if (Convert.ToBoolean(objBEStudent.DtResult.Rows[0]["ExamiKey"]) == true)
                    {
                        Response.Redirect("StudentexamiKEY.aspx?TransID=" + Request.QueryString["TransID"].ToString(),false);
                    }
                   else
                    {
                         Response.Redirect("StudentAgreements.aspx?TransID=" + Request.QueryString["TransID"].ToString(),false);
                    }
                }
            }


        }
    }
