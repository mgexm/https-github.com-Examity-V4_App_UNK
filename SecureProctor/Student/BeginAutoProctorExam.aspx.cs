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
    public partial class BeginAutoProctorExam : BaseClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetProviderFile();

            //if (!IsPostBack)
            //{
            //    setExamDetailsForExamityMeeting();
            //}
            
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



        protected void btnBegin_Click(object sender, EventArgs e)
        {
            Session["Flowcheck"] = null;
            Session["NonProctorExam"] = null;
            Session["Isproctorless"] = null;
            BEStudent objBEStudent = new BEStudent();
            BStudent objBStudent = new BStudent();
            objBEStudent.IntTransID = Convert.ToInt64(AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()));
            objBEStudent.IntType = 18;
            objBEStudent.IntResult = 0;
            objBStudent.BUpdateNonProctorExamStatus(objBEStudent);
            objBStudent.BUpdatePLTime(objBEStudent);


            ScriptManager.RegisterStartupScript(this, Page.GetType(), "newWindow", "window.open('" + GetExamLink() + "','_blank');", true);
        }

        public string GetTransID()
        {
            //if (btnClsoeExam.Visible)
            return AppSecurity.Decrypt(Request.QueryString["TransID"].ToString());
            //else
            //    return "";
        }

        //the following function is used to display the uploaded files in the grid for auto authentication exam
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
                    gvUploadFiles.DataSource = new string[] { };
                    gvUploadFiles.DataBind();
                    gvUploadFiles.Visible = false;
                }

                if (objBEStudent.DsResult != null && objBEStudent.DsResult.Tables.Count > 0 && objBEStudent.DsResult.Tables[1].Rows.Count > 0)
                {
                    if (objBEStudent.DsResult.Tables[1].Rows[0]["ExamPassword"].ToString() == "")
                    {
                        divpassword.Attributes.Add("style", "display:none");
                    }
                    else
                    {
                        divpassword.Attributes.Add("style", "display:block");
                        txtpassword.Text = objBEStudent.DsResult.Tables[1].Rows[0]["ExamPassword"].ToString();
                    }

                }
            }
        }

        //for clicking the link in the upload files grid
        protected void lnlFile_Click(object sender, EventArgs e)
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

        public string GetExamiFaceFaceTransID()
        {

            return AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()) + "#" + System.Configuration.ConfigurationManager.AppSettings["examiFACEPrefix"].ToString();

        }

        public string GetIsexamiFACE()
        {

            BEStudent objBEStudent = new BEStudent();
            BStudent objBStudent = new BStudent();
            objBEStudent.IntTransID = Convert.ToInt64(AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()));
            objBStudent.BCheckIsexamiFACE(objBEStudent);
            return objBEStudent.DtResult.Rows[0]["IsexamiFACE"].ToString(); ;

        }

        public string GetIsexamiFACEDownLoad()
        {

            BEStudent objBEStudent = new BEStudent();
            BStudent objBStudent = new BStudent();
            objBEStudent.IntTransID = Convert.ToInt64(AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()));
            objBStudent.BCheckIsexamiFACEDownLoad(objBEStudent);
            return objBEStudent.DtResult.Rows[0]["IsexamiFACE"].ToString(); ;

        }

        private void setExamDetailsForExamityMeeting()
        {
            try
            {
                BECommon objBECommon = new BECommon();
                objBECommon.IntTransID = Int64.Parse(AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()));
                BCommon bCommon = new BCommon();
                bCommon.BGetExamDetailsForExamityMeeting(objBECommon);

                if (objBECommon.DsResult != null && objBECommon.DsResult.Tables.Count > 0)
                {
                   var islockDown= Convert.ToBoolean(objBECommon.DsResult.Tables[0].Rows[0]["IsLockDown"]);
                   hdnIsLockDown.Value = islockDown.ToString();

                   var isPasswordExists = Convert.ToBoolean(objBECommon.DsResult.Tables[0].Rows[0]["ExamPassword"]);
                   hdnIsPasswordExists.Value = isPasswordExists.ToString();
             
                    hdnLmsDomain.Value = objBECommon.DsResult.Tables[0].Rows[0]["ExamDomain"].ToString();
                }
            }
            catch (Exception)
            {
            }

        }
    }
}