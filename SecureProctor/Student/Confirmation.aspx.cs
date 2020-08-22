using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessEntities;
using BLL;
using System.IO;

namespace SecureProctor.Student
{
    public partial class Confirmation : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            String Bank_Resp_Code = string.Empty;

            if (!IsPostBack)
            {
                if (Request.QueryString["pid"] != null)
                {
                    if (Request.QueryString["pid"].ToString().Length > 0)
                    {
                        //Response.Write(Request.QueryString["pid"].ToString());
                        Bank_Resp_Code = "100";
                    }
                    else
                    {
                        Bank_Resp_Code = "0";
                    }
                }
                else
                {
                    Bank_Resp_Code = "0";
                }


                if (Bank_Resp_Code == "100")
                {
                    if (Session["BESTUDENT"] != null)
                    {
                        #region CreateTransaction
                        BEStudent objBEStudent = (BEStudent)Session["BESTUDENT"];
                        if (objBEStudent.IntScheduleID == 0)
                        {
                            new BStudent().BStudent_ScheduleExamOnDemand(objBEStudent);
                            lblTransID.Text = objBEStudent.DsResult.Tables[0].Rows[0]["ID"].ToString();
                            try
                            {

                                BEMail objBEMail = new BEMail();
                                BMail objBMail = new BMail();
                                objBEMail.IntUserID = 0;
                                objBEMail.IntTransID = Convert.ToInt64(objBEStudent.DsResult.Tables[0].Rows[0]["ID"]);
                                objBEMail.StrTemplateName = BaseClass.EnumEmails.StudentExamReceipt.ToString();
                                objBMail.BSendEmail(objBEMail);
                                //if (Session["Isproctorless"] != null)
                                //{

                                //    if (Convert.ToInt32(Session["Isproctorless"]) != 1)
                                //    {
                                //        BEMail objBEMail = new BEMail();
                                //        BMail objBMail = new BMail();
                                //        objBEMail.IntUserID = 0;
                                //        objBEMail.IntTransID = Convert.ToInt32(objBEStudent.DsResult.Tables[0].Rows[0]["ID"]);
                                //        objBEMail.StrTemplateName = BaseClass.EnumEmails.StudentExamReceipt.ToString();
                                //        objBMail.BSendEmail(objBEMail);
                                //    }
                                //}
                                //else
                                //{
                                //    BEMail objBEMail = new BEMail();
                                //    BMail objBMail = new BMail();
                                //    objBEMail.IntUserID = 0;
                                //    objBEMail.IntTransID = Convert.ToInt32(objBEStudent.DsResult.Tables[0].Rows[0]["ID"]);
                                //    objBEMail.StrTemplateName = BaseClass.EnumEmails.StudentExamReceipt.ToString();
                                //    objBMail.BSendEmail(objBEMail);
                                //}
                               
                            }
                            catch (Exception ex)
                            {
                            }
                            this.BindExamDetails(Convert.ToInt64(objBEStudent.DsResult.Tables[0].Rows[0]["ID"].ToString()));
                            this.LogPayments(Convert.ToInt64(objBEStudent.DsResult.Tables[0].Rows[0]["ID"].ToString()), objBEStudent.decExamFee + objBEStudent.PerHourFee, objBEStudent.decOnDemandFee);
                            this.GetAllRules(Convert.ToInt64(lblTransID.Text));
                            lblInfo.Text = "<img src='../Images/yes.png'align='middle'/>&nbsp;<font color='#00C000'>" + "Your Exam appointment is successfully scheduled.";
                        }
                        else
                        {
                            new BStudent().BStudent_ReScheduleExamOnDemand(objBEStudent);
                            lblTransID.Text = objBEStudent.IntScheduleID.ToString();
                            try
                            {
                                
                                
                                    BEMail objBEMail = new BEMail();
                                    BMail objBMail = new BMail();
                                    objBEMail.IntUserID = 0;
                                    objBEMail.IntTransID = Convert.ToInt64(objBEStudent.IntScheduleID);
                                    objBEMail.StrTemplateName = BaseClass.EnumEmails.ReScheduleConfirmation.ToString();
                                    objBMail.BSendEmail(objBEMail);
                                
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                            this.BindExamDetails(objBEStudent.IntScheduleID);
                            this.LogRePaymentDetails(objBEStudent.IntScheduleID, objBEStudent.decExamFee + objBEStudent.PerHourFee, objBEStudent.decOnDemandFee);
                            this.GetAllRules(Convert.ToInt64(lblTransID.Text));
                            lblInfo.Text = "<img src='../Images/yes.png'align='middle'/>&nbsp;<font color='#00C000'>" + "Your Exam appointment is successfully rescheduled.";
                        }

                        trSuccess.Visible = true;
                        trSuccessInfo.Visible = true;
                        trSuccessButtons.Visible = true;
                        trError.Visible = false; 
                        Session["BESTUDENT"] = null;
                        HideBeginExam();
                        #endregion
                    }
                    else
                    {
                        trSuccess.Visible = false;
                        trSuccessInfo.Visible = false;
                        trSuccessButtons.Visible = false;
                        trError.Visible = true;
                        //HideBeginExam();
                        /* new code*/
                        //trbeginexam.Visible = false;
                       // trPLExam.Visible = false;
                        trSuccessInfo.Visible = false;
                        trSuccessButtons.Visible = true;
                        Session["Isproctorless"] = null;
                        Session["Flowcheck"] = null;
                        Session["NonProctorExam"] = null;
                        /*new code end*/
                    }
                }
                else
                {
                    trSuccess.Visible = false;
                    trSuccessInfo.Visible = false;
                    trSuccessButtons.Visible = false;
                    trError.Visible = true;
                    //HideBeginExam();
                    /* new code*/
                    //trbeginexam.Visible = false;
                    //trPLExam.Visible = false;
                    trSuccessInfo.Visible = false;
                    trSuccessButtons.Visible = true;
                    Session["Isproctorless"] = null;
                    Session["Flowcheck"] = null;
                    Session["NonProctorExam"] = null;
                    /*new code end*/
                }
            }
        }
        protected void GetAllRules(Int64 id)
        {
            BECommon objBECommon = new BECommon();
            BCommon objBCommon = new BCommon();

            objBECommon.StrFromPage = "STUDENT";

            objBECommon.iID = id;
            objBECommon.iTypeID = 1;// sending ExamID

            objBCommon.BGetExamRulesInformation(objBECommon);
            if (objBECommon.DsResult != null && objBECommon.DsResult.Tables.Count > 0 && objBECommon.DsResult.Tables[0].Rows.Count > 0)
            {
                gvStandard.DataSource = objBECommon.DsResult.Tables[0];
                gvStandard.DataBind();
            }
            else
                gvStandard.DataSource = new string[] { };

            if (objBECommon.DsResult != null && objBECommon.DsResult.Tables.Count > 0 && objBECommon.DsResult.Tables[1].Rows.Count > 0)
            {
                gvAllowed.DataSource = objBECommon.DsResult.Tables[1];
                gvAllowed.DataBind();
            }
            else
                gvAllowed.DataSource = new string[] { };

            if (objBECommon.DsResult != null && objBECommon.DsResult.Tables.Count > 0 && objBECommon.DsResult.Tables[2].Rows.Count > 0)
            {

                gvSpecialInstructions_Student.DataSource = objBECommon.DsResult.Tables[2];
                gvSpecialInstructions_Student.DataBind();
                trSpecialStudent.Visible = true;



            }
            else
            {
                gvSpecialInstructions_Student.DataSource = new string[] { };

            }


        }
        protected void LogPayments(Int64 intTransID, decimal decExamFee, decimal decOnDemandFee)
        {
            BEStudent objBEStudent = new BEStudent();
            objBEStudent.IntTransID = intTransID;
            objBEStudent.decExamFee = decExamFee;
            objBEStudent.decOnDemandFee = decOnDemandFee;
            objBEStudent.intExamFeePaidBy = Convert.ToInt32(Session[BaseClass.EnumPayment.PaidBY_ExamFee].ToString());
            objBEStudent.intOndemandPaidBy = Convert.ToInt32(Session[BaseClass.EnumPayment.PaidBY_OndeMand].ToString());
            if (Request.QueryString["pid"] != null)
                objBEStudent.strOrderID = Request.QueryString["pid"].ToString();
            new BStudent().BSetPaymentDetails_Scheduled(objBEStudent);
        }
        protected void LogRePaymentDetails(Int64 intTransID, decimal decExamFee, decimal decOnDemandFee)
        {
            BEStudent objBEStudent = new BEStudent();
            objBEStudent.IntTransID = intTransID;
            objBEStudent.decExamFee = decExamFee;
            objBEStudent.decOnDemandFee = decOnDemandFee;
            objBEStudent.intExamFeePaidBy = Convert.ToInt32(Session[BaseClass.EnumPayment.PaidBY_ExamFee].ToString());
            objBEStudent.intOndemandPaidBy = Convert.ToInt32(Session[BaseClass.EnumPayment.PaidBY_OndeMand].ToString());
            if (Request.QueryString["pid"] != null)
                objBEStudent.strOrderID = Request.QueryString["pid"].ToString();
            new BStudent().BSetPaymentDetails_Recheduled(objBEStudent);
        }
        protected void BindExamDetails(Int64 TransactionID)
        {
            BECommon objBECommon = new BECommon();
            BCommon objBCommon = new BCommon();

            objBECommon.IntTransID = TransactionID;
            objBECommon.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID]);
            objBCommon.BGetStudentExamDetails(objBECommon);

            if (objBECommon.DsResult.Tables[0].Rows.Count > 0)
            {
                lblStudentName.Text = objBECommon.DsResult.Tables[0].Rows[0]["Name"].ToString();
                lblCourseName.Text = objBECommon.DsResult.Tables[0].Rows[0]["CourseName"].ToString();
                lblExamName.Text = objBECommon.DsResult.Tables[0].Rows[0]["ExamName"].ToString();
                lblDAte.Text = objBECommon.DsResult.Tables[0].Rows[0]["ExamDate"].ToString();
                lblTime.Text = objBECommon.DsResult.Tables[0].Rows[0]["TimeDuration"].ToString();
                lblStatus.Text = objBECommon.DsResult.Tables[0].Rows[0]["StatusName"].ToString();
                if (objBECommon.DsResult.Tables[0].Rows[0]["OriginalFileName"] != null && objBECommon.DsResult.Tables[0].Rows[0]["OriginalFileName"].ToString() != string.Empty)
                {
                    lnlFile.Visible = true;
                    lblFile.Visible = false;
                    lnlFile.Text = objBECommon.DsResult.Tables[0].Rows[0]["OriginalFileName"].ToString();
                }
                else
                {
                    lnlFile.Visible = false;
                    lblFile.Visible = true;
                    lblFile.Text = "N/A";
                }
            }


           
        }
        protected void lnlFile_Click(Object sender, EventArgs e)
        {
            BECommon objBECommon = new BECommon();
            BCommon objBCommon = new BCommon();

            objBECommon.IntTransID = Convert.ToInt64(Session[BaseClass.EnumPageSessions.EXAMID]);
            objBECommon.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID]);
            objBCommon.BGetStudentExamDetails(objBECommon);

            if (objBECommon.DsResult.Tables[0].Rows.Count > 0)
            {

                if (objBECommon.DsResult.Tables[0].Rows[0]["OriginalFileName"] != null && objBECommon.DsResult.Tables[0].Rows[0]["OriginalFileName"].ToString() != string.Empty)
                {

                    string UploadedFile = objBECommon.DsResult.Tables[0].Rows[0]["StoredFileName"].ToString();

                    string MapPath = Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["ProviderUploadPath"].ToString());

                    string fullPath = MapPath + '\\' + UploadedFile;

                    FileInfo fi = new FileInfo(fullPath);

                    if (fi.Exists)
                    {
                        long sz = fi.Length;

                        Response.ClearContent();

                        Response.ContentType = MimeType(Path.GetExtension(fullPath));

                        Response.AddHeader("Content-Disposition", string.Format("attachment; filename = {0}", System.IO.Path.GetFileName(fullPath))); Response.AddHeader("Content-Length", sz.ToString("F0"));

                        Response.TransmitFile(fullPath);

                        Response.End();

                    }
                    else
                    {
                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "NotSaved", "alert('File doesnot exist');", true);

                        Page.ClientScript.RegisterStartupScript(GetType(), "MyScript", "alert('File doesnot exist');", true);
                    }

                }
                else
                {
                    lnlFile.Visible = false;
                    lblFile.Visible = true;
                    lblFile.Text = "N/A";
                }
            }
        }
        public static string MimeType(string Extension)
        {
            string mime = "application/octetstream";

            if (string.IsNullOrEmpty(Extension))

                return mime;

            string ext = Extension.ToLower();

            Microsoft.Win32.RegistryKey rk = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ext);

            if (rk != null && rk.GetValue("Content Type") != null)

                mime = rk.GetValue("Content Type").ToString();

            return mime;
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "scriptid", "window.parent.location.href='Home.aspx';", true);
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "scriptid", "window.parent.location.href='PaymentProcess.aspx';", true);
        }


        public void HideBeginExam()
        {
            //if (Session["Isproctorless"] != null)
            //{
            //    if (Convert.ToInt32(Session["Isproctorless"]) == 1)
            //    {

            //        //trbeginexam.Visible = true;
            //        trSuccessButtons.Visible = false;
            //       // trPLExam.Visible = true;
            //        trSuccessInfo.Visible = false;
            //    }

            //}

            //else
            //{
                //trbeginexam.Visible = false; 
                trSuccessButtons.Visible = true;
                //trPLExam.Visible = false;
                trSuccessInfo.Visible = true;

            //}
            
                Session["Isproctorless"] = null;
                Session["Flowcheck"] = null;
                Session["NonProctorExam"] = null;
            

        }


     

        //protected void btnbeginexam_Click(object sender, EventArgs e)
        //{

        //    BEStudent objBEStudent = new BEStudent();
        //    BStudent objBStudent = new BStudent();
        //    objBEStudent.IntTransID = Convert.ToInt32(lblTransID.Text);
        //    objBEStudent.IntResult = 1;
        //    objBStudent.BUpdateNonProctorExamStatus(objBEStudent);
        //    // ClientScript.RegisterStartupScript(this.GetType(), "scriptid", "window.parent.location.href='Systemreadiness.aspx?TransID=" + AppSecurity.Encrypt(lblTransID.Text) + "';", true);

        //    ClientScript.RegisterStartupScript(this.GetType(), "scriptid", "window.parent.location.href='CaptureImage.aspx?TransID=" + AppSecurity.Encrypt(lblTransID.Text) + "';", true);
        //    //Response.Redirect("CaptureImage.aspx?TransID=" + AppSecurity.Encrypt(lblTransID.Text), false);

        //}
    }
}