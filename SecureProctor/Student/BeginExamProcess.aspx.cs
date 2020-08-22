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
    public partial class BeginExamProcess : System.Web.UI.Page
    {

        string TYPE = "";
        //int isexamiFACE = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Request.QueryString["isexamiFACE"] != null)
            //{
            //    isexamiFACE = Convert.ToInt32(AppSecurity.Decrypt(Request.QueryString["isexamiFACE"].ToString()));
            //    if (isexamiFACE == 1)
            //    {
            //        WithAutoProctor.Style.Add("display", "block");
            //        WithoutKEYStep4.Style.Add("display", "none");
            //        WithKEYStep5.Style.Add("display", "none");
            //    }
            //    else
            //    {
            //        if (Request.QueryString["examiKEY"] != null)
            //        {
            //            TYPE = AppSecurity.Decrypt(Request.QueryString["examiKEY"].ToString());
            //            if (TYPE == "1")
            //            {
            //                WithAutoProctor.Style.Add("display", "none");
            //                WithoutKEYStep4.Style.Add("display", "none");
            //                WithKEYStep5.Style.Add("display", "block");
            //            }
            //            else
            //            {

            //                WithAutoProctor.Style.Add("display", "none");
            //                WithoutKEYStep4.Style.Add("display", "block");
            //                WithKEYStep5.Style.Add("display", "none");

            //            }
            //        }


            //    }
            //}
            //else 
            if (Request.QueryString["examiKEY"] != null)
            {
                TYPE = AppSecurity.Decrypt(Request.QueryString["examiKEY"].ToString());
                if (TYPE == "1")
                {
                    WithoutKEYStep4.Style.Add("display", "none");
                    WithKEYStep5.Style.Add("display", "block");
                }
                else
                {
                    WithoutKEYStep4.Style.Add("display", "block");
                    WithKEYStep5.Style.Add("display", "none");
                }
            }

            if (!IsPostBack)
            {
                lblExamID.Text = "Exam ID : " + AppSecurity.Decrypt(Request.QueryString["TransID"].ToString());
                lblInfor1.Text = Resources.ResMessages.Student_ExamSession_NoClose;
                lblInfor2.Text = Resources.ResMessages.Student_ExamSession_Close;
                if (Request.QueryString["TransID"] != null)
                {
                    GetProviderFile();
                    Session[BaseClass.EnumPageSessions.TransID] = Request.QueryString["TransID"].ToString();
                }
                else
                    Session[BaseClass.EnumPageSessions.TransID] = null;
                           

            }

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
        public string GetTransID()
        {
            //if (btnClsoeExam.Visible)
            return AppSecurity.Decrypt(Request.QueryString["TransID"].ToString());
            //else
            //    return "";
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

        public string GetExamDetailsByTransID()
        {
            BEStudent objBEStudent = new BEStudent();
            BStudent objBStudent = new BStudent();
            objBEStudent.IntTransID = Convert.ToInt64(AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()));
            objBStudent.BGetExamDetailsByTransID(objBEStudent);

            return objBEStudent.DtResult.Rows[0]["LockDownBrowser"].ToString();
        }


        public string GetLockTransID()
        {
            //if (btnClsoeExam.Visible)
            return AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()) + "#" + System.Configuration.ConfigurationManager.AppSettings["LockDownPrefix"].ToString();
            //else
            //    return "";
        }

        protected void lnkOriginalFileName_Click(object sender, EventArgs e)
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

       
    }
}