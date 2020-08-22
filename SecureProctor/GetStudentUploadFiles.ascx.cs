using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using BusinessEntities;
using System.IO;

namespace SecureProctor
{
    public partial class GetStudentUploadFiles : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void getUploadFiles()
        {
            try
            {
                BECommon objBECommon = new BECommon();
                BCommon objBCommon = new BCommon();
                if (Request.QueryString["TransID"] != null)
                {
                    objBECommon.iID = Convert.ToInt64(AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()));
                    objBCommon.BGetUploadFiles(objBECommon);

                    if (objBECommon.DsResult != null && objBECommon.DsResult.Tables.Count > 0 && objBECommon.DsResult.Tables[0].Rows.Count > 0)
                    {
                        gvUploadFiles.DataSource = objBECommon.DsResult.Tables[0];
                        gvUploadFiles.DataBind();
                    }
                    else
                        gvUploadFiles.DataSource = new string[] { };


                }
            }
            catch (Exception e)
            {

            }

 
           

        }

        protected void lnlFile_Click(Object sender, EventArgs e)
        {
            string StoredFileName = ((LinkButton)sender).CommandArgument;
          
     
                    string UploadedFile = StoredFileName;

                    string MapPath = System.Web.HttpContext.Current.Server.MapPath("../StudentUploads");

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

        protected void gvUploadFiles_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            this.getUploadFiles();
        }
    }
}