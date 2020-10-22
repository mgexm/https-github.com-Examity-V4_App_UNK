using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessEntities;
using BLL;

namespace SecureProctor.Auditor
{
    public partial class AuditorConfirmation : BaseClass
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                img.Visible = false;
                imgBack.Visible = true;
                ((LinkButton)this.Page.Master.FindControl("lnkInbox")).CssClass = "main_menu_active";
                this.Page.Title = EnumPageTitles.APPNAME + EnumPageTitles.AUDITOR_CONFIRMATION;
                BECommon objBECommon = new BECommon();
                BCommon objBCommon = new BCommon();
                if (Request.QueryString["TransID"] != null)
                {
                    ViewState[BaseClass.EnumPageSessions.TransID] = Convert.ToInt64(AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()));
                    objBECommon.IntTransID = Convert.ToInt64(AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()));
                    objBECommon.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID]);
                    objBECommon.Struserlogin = Session["EmailID"].ToString();
                    objBCommon.BGetStudentExamDetails(objBECommon);
                    if (objBECommon.DsResult.Tables[0] != null)
                    {
                        if (objBECommon.DsResult.Tables[0].Rows.Count > 0)
                        {
                            lblTransactionID.Text = AppSecurity.Decrypt(Request.QueryString["TransID"].ToString());
                            lblStudentName.Text = objBECommon.DsResult.Tables[0].Rows[0]["Name"].ToString();
                            lblcoursename.Text = objBECommon.DsResult.Tables[0].Rows[0]["CourseName"].ToString();
                            lblexamname.Text = objBECommon.DsResult.Tables[0].Rows[0]["ExamName"].ToString();
                            lblDAte.Text = objBECommon.DsResult.Tables[0].Rows[0]["ExamDate"].ToString();
                            lblSlot.Text = objBECommon.DsResult.Tables[0].Rows[0]["TimeDuration"].ToString();

                            if (Request.QueryString["type"].ToString() == "1")
                            {

                                lblHead.Text = "Approved Exam Details";
                                imgConfirm.Visible = true;
                            }


                            else
                            {
                                lblHead.Text = "Rejected Exam Details";
                                btnReject.Visible = true;
                            }
                              
                            
                        }
                    }
                }
            }
            catch (Exception )
            {

            }
        }

        protected void Confirm_Click(object sender, EventArgs e)
        {
            try
            {
                BECommon objBECommon = new BECommon();
                BCommon objBCommon = new BCommon();
                if (Request.QueryString["type"].ToString() == "1")
                {

                    objBECommon.IntTransID = Convert.ToInt64(AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()));
                    objBCommon.BGetExamProviderDetails(objBECommon);
                    if (objBECommon.DsResult.Tables[0].Rows.Count > 0)
                    {
                        //  objBECommon.StrEmailID = objBECommon.DsResult.Tables[0].Rows[0]["StudentEmail"].ToString();
                        objBECommon.IntUserID = Convert.ToInt32(objBECommon.DsResult.Tables[0].Rows[0]["UserID"]);
                        objBECommon.IntProviderID = Convert.ToInt32(objBECommon.DsResult.Tables[0].Rows[0]["ProviderUserID"]);
                        // objBECommon.strProviderEmailID = objBECommon.DsResult.Tables[0].Rows[0]["ExamProviderEmail"].ToString();

                    }

                    Approve_Transaction(1);

                        try
                        {
                            //EmailMsg obj = new EmailMsg();
                            //obj.ExamApprovedStudent(Convert.ToInt32(AppSecurity.Decrypt(Request.QueryString["TransID"].ToString())),"Approved");
                            //obj.ExamApprovedProvider(Convert.ToInt32(AppSecurity.Decrypt(Request.QueryString["TransID"].ToString())),"Approved");
                            //obj = null;

                            BEMail objBEMail = new BEMail();
                            BMail objBMail = new BMail();
                            objBEMail.IntTransID = objBECommon.IntTransID;
                            string FYI = "FYI";
                            //string mail = "Mail";
                            //if (mail == "Mail")
                            //{
                            //    objBEMail.IntUserID = objBECommon.IntUserID;

                            //    objBEMail.StrTemplateName = BaseClass.EnumEmails.ExamApprovedbyAuditor.ToString();
                            //    objBMail.BSendEmail(objBEMail);

                            //}

                            if (FYI == "FYI")
                            {
                                objBECommon.IntTransID = Convert.ToInt64(AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()));
                                objBCommon.BAuditorCheckEmailForApproval(objBECommon);
                                if (objBECommon.IntstatusFlag == 1)
                                {
                                    objBEMail.IntUserID = objBECommon.IntProviderID;

                                    objBEMail.StrTemplateName = BaseClass.EnumEmails.ExamApprovedbyAuditorFYI.ToString();
                                    objBMail.BSendEmail(objBEMail);

                                }
                 

                               
                            }
                        }

                        catch (Exception ex)
                        {
                            throw ex;

                        }

                    }
                

            }
            catch (Exception )
            {

            }
        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            try
            {

                if (Request.QueryString["type"].ToString() == "0")
                {
                    BECommon objBECommon = new BECommon();
                    BCommon objBCommon = new BCommon();
                    objBECommon.IntTransID = Convert.ToInt64(AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()));
                    objBCommon.BGetExamProviderDetails(objBECommon);
                    if (objBECommon.DsResult.Tables[0].Rows.Count > 0)
                    {
                       // objBECommon.StrEmailID = objBECommon.DsResult.Tables[0].Rows[0]["StudentEmail"].ToString();
                        objBECommon.IntUserID = Convert.ToInt32(objBECommon.DsResult.Tables[0].Rows[0]["UserID"]);
                        objBECommon.IntProviderID = Convert.ToInt32(objBECommon.DsResult.Tables[0].Rows[0]["ProviderUserID"]);

                      //  objBECommon.strProviderEmailID = objBECommon.DsResult.Tables[0].Rows[0]["ExamProviderEmail"].ToString();

                    }
                    Approve_Transaction(0);
                    try
                    {
                        //EmailMsg obj = new EmailMsg();
                        //obj.ExamApprovedStudent(Convert.ToInt32(AppSecurity.Decrypt(Request.QueryString["TransID"].ToString())), "Rejected");
                        //obj.ExamApprovedProvider(Convert.ToInt32(AppSecurity.Decrypt(Request.QueryString["TransID"].ToString())), "Rejected");
                        //obj = null;
                        BEMail objBEMail = new BEMail();
                        BMail objBMail = new BMail();
                        objBEMail.IntTransID = objBECommon.IntTransID;
                        string FYI = "FYI";
                        string mail = "Mail";                
                        if (mail == "Mail")
                        {
                            //objBEMail.IntUserID = objBECommon.IntUserID;
                            //objBEMail.StrTemplateName = BaseClass.EnumEmails.ExamRejectedbyAuditor.ToString();
                            //objBMail.BSendEmail(objBEMail);

                        }

                        if (FYI == "FYI")
                        {

                            //objBEMail.IntUserID = objBECommon.IntProviderID;

                            //objBEMail.StrTemplateName = BaseClass.EnumEmails.ExamRejectedbyAuditorFYI.ToString();
                            //objBMail.BSendEmail(objBEMail);
                        }
                        



                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                  
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        protected void back_Click(object sender, EventArgs e)
        {

            Response.Redirect("ExamDetails.aspx?TransID=" + AppSecurity.Encrypt(ViewState[BaseClass.EnumPageSessions.TransID].ToString()), false);
        }

        protected void Approve_Transaction(int type)
        {
            try
            {
                BECommon objBECommon = new BECommon();
                BCommon objBCommon = new BCommon();
                objBECommon.IntTransID = Convert.ToInt64(lblTransactionID.Text);
                objBECommon.IntEmployeeID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID]);
                objBECommon.IntType = type;

                objBCommon.BApproveOrRejectTransaction(objBECommon);

                if (type == 1 && objBECommon.IntResult > 0)
                {
                    img.Visible = true;
                    imgConfirm.Visible = false;
                    btnReject.Visible = false;
                    imgBack.Visible = false;
                    btnInbox.Visible = true;
                    //lblSuccess.Text = "Transaction is Approved Successfully.";
                    lblSuccess.Text = Resources.ResMessages.Audit_TransApprove;
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowSuccess", "alert('Transaction is Approved')", true);
                    //Response.Redirect("AuditorConfirmation.aspx?type=1&" + Request.QueryString.ToString(), false);
                }
                else
                    if (type == 0 && objBECommon.IntResult > 0)
                    {
                        img.Visible = true;
                        btnReject.Visible = false;
                        imgConfirm.Visible = false;
                        imgBack.Visible = false;
                        btnInbox.Visible = true;
                        lblSuccess.Text = Resources.ResMessages.Audit_TransReject;
                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowSuccess", "alert('Transaction is Rejected')", true);
                        // Response.Redirect("AuditorConfirmation.aspx?type=0&" + Request.QueryString.ToString(), false);

                    }
                    else
                    {
                        img.Visible = true;
                        imgConfirm.Visible = false;
                        imgBack.Visible = false;
                        //lblSuccess.Text = "Approval/Rejection Failed.Please try again";
                        lblSuccess.Text = Resources.ResMessages.Audit_TransFail;
                        btnInbox.Visible = true;
                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowSuccess", "alert('Approval/Rejection Failed.Please try again')", true);
                    }


            }
            catch (Exception )
            {
            }

        }

        protected void Inbox_Click(object sender, EventArgs e)
        {

            Response.Redirect(BaseClass.EnumAppPage.AUDITOR_INBOX);
        }

    }
}
