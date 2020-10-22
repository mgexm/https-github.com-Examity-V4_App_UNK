using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using BusinessEntities;

namespace SecureProctor.Student
{
    public partial class ExamCloseConfirmation : BaseClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (IsPostBack)
            //    ClientScript.RegisterClientScriptBlock(GetType(), "IsPostBack", "var isPostBack = true;", true);
            //else
            //    ClientScript.RegisterClientScriptBlock(GetType(), "IsPostBack", "var isPostBack = false;", true);
            try
            {
                lblHead.Text = "Exam Details";
                lblmsg.Visible = false;
                tickimg.Visible = true;
              
                lblmsg.Text = Resources.ResMessages.Student_ExamCloseconfirm;
                lblmsg.Visible = true;
               // tdButton.Visible = true;
                BEStudent objBEStudent = new BEStudent();
                BStudent objBStudent = new BStudent();
                if (Request.QueryString["TransID"] != null)
                {
                    this.Page.Title = EnumPageTitles.APPNAME + EnumPageTitles.STUDENT_SCHEDULEDetails;
                    ((LinkButton)this.Page.Master.FindControl("lnkStart")).CssClass = "main_menu_active";
                    objBEStudent.IntTransID = Convert.ToInt64(AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()));
                    objBStudent.BGetStudentExamDetails(objBEStudent);
                    if (objBEStudent.DtResult != null)
                    {
                        if (objBEStudent.DtResult.Rows.Count > 0)
                        {
                            lblTransactionID.Text = AppSecurity.Decrypt(Request.QueryString["TransID"].ToString());
                            lblStudentName.Text = objBEStudent.DtResult.Rows[0]["Name"].ToString();
                            lblCourseName.Text = objBEStudent.DtResult.Rows[0]["CourseName"].ToString();
                            lblExamName.Text = objBEStudent.DtResult.Rows[0]["ExamName"].ToString();
                            lblDAte.Text = objBEStudent.DtResult.Rows[0]["ExamDate"].ToString();
                            lblSlot.Text = objBEStudent.DtResult.Rows[0]["TimeDuration"].ToString();

                        }
                    }

                }

            }

            catch (Exception )
            {

            }
        }

        //protected void btnStopStreaming_Click(object sender, EventArgs e)
        //{
        //    StreamingServer.ServiceSoapClient obj = new StreamingServer.ServiceSoapClient();
        //    obj.StopStreaming("Webcam", AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()));
        //    obj.Close();
        //    obj.Abort();

        //    obj = new StreamingServer.ServiceSoapClient();
        //    obj.StopStreaming("Desktop", AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()));
        //    obj.Close();
        //    obj.Abort();
        //}

        protected void imgConfirm_Click(object sender, EventArgs e)
        {
            //BStudent objBStudent = new BStudent();
            //BEStudent objBEStudent = new BEStudent();
            //objBEStudent.IntTransID = Convert.ToInt32(AppSecurity.Decrypt(Request.QueryString["TransID"]));
            //objBStudent.BsetExamCompleted(objBEStudent);
            //objBEStudent = null;
            //objBStudent = null;
                
            //tdButton.Visible = false;
            tickimg.Visible = true;
            //lblmsg.Text = "Exam completed successfully";
            lblmsg.Text = Resources.ResMessages.Student_ExamCloseconfirm;
            lblmsg.Visible = true;

            //try
            //{

            //    BEMail objBEMail = new BEMail();
            //    BMail objBMail = new BMail();
            //    objBEMail.IntUserID = 0;
            //    objBEMail.IntTransID = Convert.ToInt32(AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()));
            //    objBEMail.StrTemplateName = BaseClass.EnumEmails.ExamCompletedConfirmation.ToString();

            //    objBMail.BSendEmail(objBEMail);

            //}
            //catch (Exception ex)
            //{
                
            //}
        }

        protected void imgBack_Click(object sender, EventArgs e)
        {
           Response.Redirect("ExamSession.aspx?"+Request.QueryString.ToString());
        }
    }
}