using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using BusinessEntities;
using System.Data;
using System.Web.UI.HtmlControls;

namespace SecureProctor.Proctor
{
	public partial class ProctorConfirmation :BaseClass
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {

                lblHead.Text = "Exam  Details";
                imgtick.Visible = false;
                btnConfirm.Visible = true;
                btnBack.Visible = true;
                ((LinkButton)this.Page.Master.FindControl("lnkValidate")).CssClass = "main_menu_active";
                this.Page.Title = EnumPageTitles.APPNAME + EnumPageTitles.PROCTOR_CONFIRMATION;
                this.BindDetails();

            }

		}

        protected void BindDetails()
        {
            try
            {
                BECommon objBECommon = new BECommon();
                BCommon objBCommon = new BCommon();
                if (Request.QueryString["TransID"] != null)
                {
                    ViewState[BaseClass.EnumPageSessions.TransID] = Convert.ToInt64(AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()));
                    objBECommon.IntTransID = Convert.ToInt64(AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()));
                    objBECommon.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID]);
                    objBCommon.BGetStudentExamDetails(objBECommon);
                    if (objBECommon.DsResult != null && objBECommon.DsResult.Tables[0].Rows.Count > 0)
                    {
                        lblTransactionID.Text = AppSecurity.Decrypt(Request.QueryString["TransID"].ToString());
                        lblStudentName.Text = objBECommon.DsResult.Tables[0].Rows[0]["Name"].ToString();
                        lblCourseName.Text = objBECommon.DsResult.Tables[0].Rows[0]["CourseName"].ToString();
                        lblExamName.Text = objBECommon.DsResult.Tables[0].Rows[0]["ExamName"].ToString();
                        lblDAte.Text = objBECommon.DsResult.Tables[0].Rows[0]["ExamDate"].ToString();
                        lblSlot.Text = objBECommon.DsResult.Tables[0].Rows[0]["TimeDuration"].ToString();

                    }
                          

                }

            }

            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["type"].ToString() == "1")
            {
                if (Request.QueryString["status"] != null && Request.QueryString["status"].ToString() != string.Empty)
                {
                    string status = AppSecurity.Decrypt(Request.QueryString["status"].ToString());
                    if (status == "Approve")
                    {
                        BEProctor objBEProctor = new BEProctor();
                        BProctor objBProctor = new BProctor();
                        objBEProctor.IntTransID = Convert.ToInt64(AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()));
                        objBEProctor.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID]);
                        objBEProctor.IntFlag = 0;
                        objBEProctor.strStatus =status;
                        objBProctor.BProctorApproveExam(objBEProctor);
                        //try
                        //{
                        //    StreamingServer.ServiceSoapClient client = new StreamingServer.ServiceSoapClient();
                        //    client.StopStreaming("", AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()));
                        //}
                        //catch
                        //{
                        //}
                        btnConfirm.Visible = false;
                        btnBack.Visible = false;
                        imgtick.Visible = true;
                        lblSuccess.Text = Resources.ResMessages.Proctor_ExamApprove;
                        try
                        {

                            BEMail objBEMail = new BEMail();
                            BMail objBMail = new BMail();
                            objBEMail.IntUserID = 0;
                            objBEMail.IntTransID = Convert.ToInt64(AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()));
                            objBEMail.StrTemplateName = BaseClass.EnumEmails.ExamApprovalConfirmation.ToString();

                            objBMail.BSendEmail(objBEMail);

                        }
                        catch (Exception ex)
                        {
                            //throw ex;
                        }
                    }
                    else if (status == "Close")
                    {
                        BEProctor objBEProctor = new BEProctor();
                        BProctor objBProctor = new BProctor();
                        objBEProctor.IntTransID = Convert.ToInt64(AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()));
                        objBEProctor.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID]);
                        objBEProctor.IntFlag = 0;
                        objBEProctor.strStatus = status;
                        objBProctor.BProctorApproveExam(objBEProctor);
                        //try
                        //{
                        //    StreamingServer.ServiceSoapClient client = new StreamingServer.ServiceSoapClient();
                        //    client.StopStreaming("", AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()));
                        //}
                        //catch
                        //{
                        //}
                        btnConfirm.Visible = false;
                        btnBack.Visible = false;
                        imgtick.Visible = true;
                        lblSuccess.Text = Resources.ResMessages.Proctor_ExamClose;
                        try
                        {

                            BEMail objBEMail = new BEMail();
                            BMail objBMail = new BMail();
                            objBEMail.IntUserID = 0;
                            objBEMail.IntTransID = Convert.ToInt64(AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()));
                            objBEMail.StrTemplateName = BaseClass.EnumEmails.ExamApprovalConfirmation.ToString();

                            objBMail.BSendEmail(objBEMail);

                        }
                        catch (Exception ex)
                        {
                            //throw ex;
                        }
                    }
                    else if (status == "Incomplete")
                    {
                        BEProctor objBEProctor = new BEProctor();
                        BProctor objBProctor = new BProctor();
                        objBEProctor.IntTransID = Convert.ToInt64(AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()));
                        objBEProctor.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID]);
                        objBEProctor.IntFlag = 0;
                        objBEProctor.strStatus = status;
                        objBProctor.BProctorApproveExam(objBEProctor);
                        //try
                        //{
                        //    StreamingServer.ServiceSoapClient client = new StreamingServer.ServiceSoapClient();
                        //    client.StopStreaming("", AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()));
                        //}
                        //catch
                        //{
                        //}
                        btnConfirm.Visible = false;
                        btnBack.Visible = false;
                        imgtick.Visible = true;
                        lblSuccess.Text = Resources.ResMessages.Proctor_ExamIncomplete;
                        try
                        {

                            BEMail objBEMail = new BEMail();
                            BMail objBMail = new BMail();
                            objBEMail.IntUserID = 0;
                            objBEMail.IntTransID = Convert.ToInt64(AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()));
                            objBEMail.StrTemplateName = BaseClass.EnumEmails.ExamApprovalConfirmation.ToString();

                            objBMail.BSendEmail(objBEMail);

                        }
                        catch (Exception ex)
                        {
                            //throw ex;
                        }
                    }
                    //status = "";
                }
            }         
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            string backstatus = "";
            if (Request.QueryString["status"] != null && Request.QueryString["status"].ToString() != string.Empty)
            {
                backstatus = Request.QueryString["status"].ToString();
                Response.Redirect("StudentLookUp.aspx?TransID=" + AppSecurity.Encrypt(ViewState[BaseClass.EnumPageSessions.TransID].ToString()) + "&status=" + backstatus + "", false);
            }
            else
            {
                Response.Redirect("StudentLookUp.aspx?TransID=" + AppSecurity.Encrypt(ViewState[BaseClass.EnumPageSessions.TransID].ToString()), false);
            }
            
           // Response.Redirect("ExamDetails.aspx?TransID=" + AppSecurity.Encrypt(transID.ToString()), false);


         
        }
	}
}