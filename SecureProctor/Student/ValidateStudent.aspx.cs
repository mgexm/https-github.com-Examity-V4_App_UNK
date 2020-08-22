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
    public partial class ValidateStudent : BaseClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            this.Page.Title = EnumPageTitles.APPNAME + EnumPageTitles.STUDENT_VALIDATESTUDENT;
            ((LinkButton)this.Page.Master.FindControl("lnkStart")).CssClass = "main_menu_active";
            if (!IsPostBack)
            {
                //Session["TransID"] = null;
                //GetAllProctorLoginUsers();
                this.BindSecurityQuestions();
            }
        }

        #region BindSecurityQuestions
        protected void BindSecurityQuestions()
        {
            try
            {
                BStudent objBStudent = new BStudent();
                BEStudent objBEStudent = new BEStudent();
                objBEStudent.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID].ToString());
                objBStudent.BGetStudentSecurityQuestions(objBEStudent);
                if (objBEStudent.DtResult.Rows.Count > 0)
                {
                    lblQuestion1.Text = "<b>Question #1:   </b>" + objBEStudent.DtResult.Rows[0]["QText"].ToString();
                    lblQuestion2.Text = "<b>Question #2:   </b>" + objBEStudent.DtResult.Rows[1]["QText"].ToString();
                    lblQuestion3.Text = "<b>Question #3:   </b>" + objBEStudent.DtResult.Rows[2]["QText"].ToString();


                }
                objBStudent = null;
                objBEStudent = null;
            }
            catch (Exception Ex)
            {
              //  ErrorLog.WriteError(Ex);
            }
        }
        #endregion
        #region ButtonEvents
        protected void btnValidate_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    BStudent objBStudent = new BStudent();
                    BEStudent objBEStudent = new BEStudent();
                    objBEStudent.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID].ToString());
                    objBEStudent.strAnswer1 = txtAnswer1.Text.Trim().ToString();
                    objBEStudent.strAnswer2 = txtAnswer2.Text.Trim().ToString();
                    objBEStudent.strAnswer3 = txtAnswer3.Text.Trim().ToString();
                    objBStudent.BValidateStudentSecurityQuestions(objBEStudent);
                    if (objBEStudent.IntResult == 1)
                        // Response.Redirect("ExamConfig.aspx?" + Request.QueryString.ToString(),false);
                        Response.Redirect("Agreements.aspx?" + Request.QueryString.ToString(), false);
                    else
                        // ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowSuccess", "alert('Invalid Security Answers,  Please try again')", true);

                        //lblFailed.Text = "Invalid Security Answers,  Please try again";
                        lblFailed.Text = Resources.ResMessages.Student_InvalidSecAns;
                }

                catch (Exception Ex)
                {
                    // ErrorLog.WriteError(Ex);
                }
            }
        }
        protected void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                txtAnswer1.Text = string.Empty;
                txtAnswer2.Text = string.Empty;
                txtAnswer3.Text = string.Empty;
            }
            catch (Exception Ex)
            {

               // ErrorLog.WriteError(Ex);
            }
        #endregion
        }

    }
}