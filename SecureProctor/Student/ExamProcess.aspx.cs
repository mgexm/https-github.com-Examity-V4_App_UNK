using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using BusinessEntities;
using BLL;
using System.IO;


namespace SecureProctor.Student
{
    public partial class ExamProcess : System.Web.UI.Page
    {
        #region Page Events

        protected void Page_Load(object sender, EventArgs e)
        {
            //btnProceed.Attributes.Add("onclick", "return browserValidate();");

            
            ((LinkButton)this.Page.Master.FindControl("lnkStart")).CssClass = "main_menu_active";
            if (Request.QueryString.ToString() != "")
            {
                BEStudent objBEStudent = new BEStudent();
                BStudent objBStudent = new BStudent();
                objBEStudent.IntTransID = Convert.ToInt64(GetTransID());
                objBStudent.BGetExamSessionID(objBEStudent);
                BindSecurityQuestions();
                BindStep4Details();
                this.GetAllRules();
                GetProviderFile();

               

                //GetSessionID();
            }
            else
            {
                //Show errors if any
            }
            //Get exam details for browser-lockdown signal
            new CommonFunctions().setExamDetailsForExamityMeeting(Request.QueryString["TransID"].ToString(), hdnIsLockDown, hdnIsPasswordExists, hdnLmsDomain, hdnExamSecurity);

            ScriptManager.RegisterStartupScript(this, this.GetType(), "NotSaved", "document.getElementById('" + imgHead.ClientID.ToString() + "').focus();", true);
        }

        #endregion

        #region Methods

        protected void GetAllRules()
        {
            BECommon objBECommon = new BECommon();
            BCommon objBCommon = new BCommon();
            objBECommon.StrFromPage = "STUDENT";


            if (Request.QueryString["TransID"] != null)
            {
                objBECommon.iID = Convert.ToInt64(AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()));
                objBECommon.iTypeID = 1;// sending TransID 



            }
            if (Request.QueryString["ExamID"] != null)
            {
                try
                {
                    objBECommon.iID = Convert.ToInt32(AppSecurity.Decrypt(Request.QueryString["ExamID"].ToString()));
                    objBECommon.iTypeID = 2;// sending ExamID


                }

                catch (Exception e)
                {

                    objBECommon.iID = Convert.ToInt32(Request.QueryString["ExamID"].ToString());
                    objBECommon.iTypeID = 2;// sending ExamID

                }

            }

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
                gvAllowed.Visible = true;
                //trAllowed.Visible = true;

            }
            else
            {
                gvAllowed.DataSource = new string[] { };
                trAllowed.Style.Add("display", "none");
            }

         
               

            if (objBECommon.DsResult != null && objBECommon.DsResult.Tables.Count > 0 && objBECommon.DsResult.Tables[2].Rows.Count > 0)
            {

               
                gvSpecialInstructions_Student.DataSource = objBECommon.DsResult.Tables[2];
                gvSpecialInstructions_Student.DataBind();
                


            }


            else
            {

             
                trSpecialStudent.Style.Add("display", "none");

           gvSpecialInstructions_Student.DataSource = new string[] { };

            }


        }

        public string GetTransID()
        {
            //if (btnClsoeExam.Visible)
            return AppSecurity.Decrypt(Request.QueryString["TransID"].ToString());
            //else
            //    return "";
        }


        public string GetLockTransID()
        {
            //if (btnClsoeExam.Visible)
            return AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()) + "#" + System.Configuration.ConfigurationManager.AppSettings["LockDownPrefix"].ToString();
            //else
            //    return "";
        }
        public string GetExamDetailsByTransID()
        {
            BEStudent objBEStudent = new BEStudent();
            BStudent objBStudent = new BStudent();
            objBEStudent.IntTransID = Convert.ToInt64(AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()));
            objBStudent.BGetExamDetailsByTransID(objBEStudent);

            return objBEStudent.DtResult.Rows[0]["LockDownBrowser"].ToString();
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
                    HfTransID.Value = AppSecurity.Decrypt(Request.QueryString["TransID"].ToString());



                }
                objBStudent = null;
                objBEStudent = null;
            }
            catch (Exception Ex)
            {
                //  ErrorLog.WriteError(Ex);
            }
        }
        protected void BindStep4Details()
        {
            lblExamID.Text = "Exam ID : " + AppSecurity.Decrypt(Request.QueryString["TransID"].ToString());
            lblInfor1.Text = Resources.ResMessages.Student_ExamSession_NoClose;
            lblInfor2.Text = Resources.ResMessages.Student_ExamSession_Close;
            if (Request.QueryString["TransID"] != null)
            {
                Session[BaseClass.EnumPageSessions.TransID] = Request.QueryString["TransID"].ToString();
            }
            else
                Session[BaseClass.EnumPageSessions.TransID] = null;
        }
        public string GetExamLink()
        {
            BEStudent objBEStudent = new BEStudent();
            BStudent objBStudent = new BStudent();
            objBEStudent.IntTransID = Convert.ToInt64(AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()));
            objBEStudent.IntFlag = 1;
            objBStudent.BSetExamStartandEndTime(objBEStudent);
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            objBStudent.BGetExamLink(objBEStudent);

            if (!objBEStudent.strExamLink.Contains("http://") && !objBEStudent.strExamLink.Contains("https://"))
            {
                objBEStudent.strExamLink = "http://" + objBEStudent.strExamLink;
            }

            return objBEStudent.strExamLink;
        }

        #endregion

        protected void lnkStartExam_Click(object sender, EventArgs e)
        {
            this.SetFlags("STARTEXAM", 0);
            ScriptManager.RegisterStartupScript(this, Page.GetType(), "newWindow", "window.open('" + GetExamLink() + "','_blank');", true);
        }

        #region Button Events

        protected void SetFlags(string strType, int intValue)
        {
            BEProctor objBEProctor = new BEProctor();
            BProctor objBProctor = new BProctor();
            objBEProctor.IntTransID = Convert.ToInt64(AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()));
            objBEProctor.strStatus = strType;
            objBEProctor.IntResult = intValue;
            objBProctor.BSetTransactionFlags(objBEProctor);
        }
        public string GetSessionID()
        {
            BEStudent objBEStudent = new BEStudent();
            BStudent objBStudent = new BStudent();
            objBEStudent.IntTransID = Convert.ToInt64(GetTransID());
            objBStudent.BGetExamSessionID(objBEStudent);

            return objBEStudent.strSessionID;
        }
        protected void btnProceed_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["TransID"] != null)
            {


                //System.Text.StringBuilder sb = new System.Text.StringBuilder();
                //sb.Append("var win = window.open('" + System.Configuration.ConfigurationManager.AppSettings["GOTOMeetingLink"].ToString() + objBEStudent.strSessionID + "','_blank');");
                //sb.Append("if (win == null || typeof(win) == 'undefined' || win.test == 'undefined' || win.outerHeight === 0)alert('The popup was blocked. You must allow popups to use this site.');");
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowSuccess", sb.ToString(), true);

                this.SetFlags("PROCEED", 0);
                BEStudent objBEStudent = new BEStudent();
                BStudent objBStudent = new BStudent();
                objBEStudent.IntTransID = Convert.ToInt64(GetTransID());
                objBStudent.BUpdateProceedTime(objBEStudent);

                //ScriptManager.RegisterStartupScript(this, Page.GetType(), "newWindow", "window.open('" + System.Configuration.ConfigurationManager.AppSettings["GOTOMeetingLink"].ToString() + objBEStudent.strSessionID + "','_blank','width=200,height=100');", true);
            }
        }


        #endregion
        [System.Web.Services.WebMethod]
        public string BindSecurityNextQuestion(String trId)
        {
            try
            {
                BStudent objBStudent = new BStudent();
                BEStudent objBEStudent = new BEStudent();
                objBEStudent.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID].ToString());
                objBStudent.BGetStudentSecurityQuestions(objBEStudent);
                if (objBEStudent.DtResult.Rows.Count > 0)
                {
                    lblQuestion1.Text = "<b>Question :   </b>" + objBEStudent.DtResult.Rows[0]["QText"].ToString();

                    hfQid.Value = objBEStudent.DtResult.Rows[0]["Qid"].ToString();
                    HfTransID.Value = trId;



                }
                objBStudent = null;
                objBEStudent = null;
            }
            catch (Exception Ex)
            {
                //  ErrorLog.WriteError(Ex);
            }
            return "false";
        }




        protected void lnlFile_Click(Object sender, EventArgs e)
        {

            string StoredFileName = ((LinkButton)sender).CommandArgument;


            string UploadedFile = StoredFileName;

            string MapPath = System.Web.HttpContext.Current.Server.MapPath("../Provider/Provider_Uploads");

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
              
                //Page.ClientScript.RegisterStartupScript(GetType(), "MyScript", "alert('File doesnot exist');", true);
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

        public void GetProviderFile()
        {


            if (Request.QueryString.ToString() != "")
            {

                BEStudent objBEStudent = new BEStudent();
                BStudent objBStudent = new BStudent();
                objBEStudent.IntTransID = Convert.ToInt64(GetTransID());
                objBStudent.BgetProviderFile(objBEStudent);
                if (objBEStudent.DsResult != null && objBEStudent.DsResult.Tables.Count > 0 && objBEStudent.DsResult.Tables[0].Rows.Count > 0)
                {
                    gvUploadFiles.DataSource = objBEStudent.DsResult.Tables[0];
                    gvUploadFiles.DataBind();
                    gvUploadFiles.Visible = true;

                }
                else
                {
                    //ExamFiles.Visible = false;
                    gvUploadFiles.DataSource = new string[] { };
                    gvUploadFiles.DataBind();
                    gvUploadFiles.Visible = false;
                }
            }
            else
            {
                //ExamFiles.Visible = false;
            }

        }

   
    }
}