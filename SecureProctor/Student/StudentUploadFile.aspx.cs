using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using BLL;
using BusinessEntities;
using System.Data;

using System.IO;

namespace SecureProctor.Student
{
    public partial class StudentUploadFile : BaseClass
    {
        Int64 TransID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Page.Title = EnumPageTitles.APPNAME + EnumPageTitles.Student_UploadFile;
            if (Request.QueryString != null && Request.QueryString.ToString() != "")
                TransID = Convert.ToInt64(Request.QueryString["TransID"]);

           
        
        }

        protected void getOriginalUploadFiles()
        {
            try
            {
                BECommon objBECommon = new BECommon();
                BCommon objBCommon = new BCommon();
                if (Request.QueryString["TransID"] != null)
                {
                    objBECommon.iID = Convert.ToInt64(Request.QueryString["TransID"]);
                    objBCommon.BGetUploadFiles(objBECommon);

                    if (objBECommon.DsResult != null && objBECommon.DsResult.Tables.Count > 0 && objBECommon.DsResult.Tables[0].Rows.Count > 0)
                    {
                        gvUploadFiles.DataSource = objBECommon.DsResult.Tables[0];

                        trrad.Visible = false;
                        trFileTypes.Visible = false;
                        trsaveUpload.Visible = false;
                    

                    }
                    else
                    {
                        gvUploadFiles.DataSource = new string[] { };
                        if (Convert.ToInt32(objBECommon.IntFlag) == 1)
                        {
                            trrad.Visible = true;
                            trFileTypes.Visible = true;
                            trsaveUpload.Visible = true;
                          
                        }
                        else
                        {
                            trrad.Visible = false;
                            trFileTypes.Visible = false;
                            trsaveUpload.Visible = false;
                           

                        }

                    }


                }
            }
            catch (Exception e)
            {

            }


        }

        public void RadAsyncUpload1_FileUploaded(object sender, FileUploadedEventArgs e)
        {


            if (StudentUpload.UploadedFiles.Count > 0)
            {


                string strOriginalFileName = e.File.FileName;
                string strUploadFileName = Request.QueryString["TransID"].ToString() + '_' + CommonFunctions.generateUploadStudentFileName(strOriginalFileName);

                string path = Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["StudentUploads"]) + '\\' + strUploadFileName;

                e.File.SaveAs(path);

                if (ViewState["UploadFileName"] != null)
                {
                    DataTable dt1 = (DataTable)ViewState["UploadFileName"];

                    dt1.Rows.Add(strOriginalFileName, strUploadFileName);
                    ViewState["UploadFileName"] = dt1;

                }

                else
                {
                    DataTable dt = getUploadFiles();
                    dt.Rows.Add(strOriginalFileName, strUploadFileName);
                    ViewState["UploadFileName"] = dt;

                }
                if (ViewState["UploadFileName"] != null)
                {
                    if (StudentUpload.UploadedFiles.Count == ((DataTable)ViewState["UploadFileName"]).Rows.Count)
                    {
                        trMessage.Visible = true;
                        BEStudent objBEStudent = new BEStudent();
                        BStudent objBStudent = new BStudent();
                        objBEStudent.IntTransID = Convert.ToInt64(Request.QueryString["TransID"]);
                        objBEStudent.IntStudentID = Convert.ToInt32(Session[EnumPageSessions.USERID]);

                        objBEStudent.DtResult = (DataTable)ViewState["UploadFileName"];
                        objBStudent.BSaveStudentUploads(objBEStudent);
                        ViewState["UploadFileName"] = null;
                        if (objBEStudent.DtResult != null && objBEStudent.DtResult.Rows.Count > 0)
                        {
                            if (objBEStudent.DtResult.Rows[0][0].Equals(1))
                            {

                                if (StudentUpload.UploadedFiles.Count > 1)
                                    lblInfo.Text = Resources.AppMessages.Student_UploadFiles_Success;
                                else
                                    lblInfo.Text = Resources.AppMessages.Student_UploadFile_Success;

                                lblInfo.ForeColor = System.Drawing.Color.FromName(Resources.AppConfigurations.Color_Success);
                                ImgInfo.ImageUrl = Resources.AppConfigurations.Image_Success;
                                trrad.Visible = false;
                                trFileTypes.Visible = false;
                                trsaveUpload.Visible = false;
                               




                            }
                            else
                            {
                                lblInfo.Text = Resources.AppMessages.Student_UploadFile_Failed;
                                lblInfo.ForeColor = System.Drawing.Color.FromName(Resources.AppConfigurations.Color_Error);
                                ImgInfo.ImageUrl = Resources.AppConfigurations.Image_Error;
                                trrad.Visible = true;
                                trFileTypes.Visible = true;
                                trsaveUpload.Visible = true;
                              



                            }
                        }
                        gvUploadFiles.Rebind();



                    }
                }

            }


        }

        protected DataTable getUploadFiles()
        {

            DataTable objDT = new DataTable();
            DataColumn objDC;
            objDC = new DataColumn("OriginalFileName");
            objDT.Columns.Add(objDC);
            objDC = new DataColumn("UploadFileName");
            objDT.Columns.Add(objDC);
            return objDT;
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

        protected void lnkOriginalFileName_Click(object sender, EventArgs e)
        {
            string StoredFileName = ((LinkButton)sender).CommandArgument;


            string UploadedFile = StoredFileName;

            // string MapPath = System.Web.HttpContext.Current.Server.MapPath("../StudentUploads");

            string MapPath = Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["StudentUploads"].ToString());

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

        protected void gvUploadFiles_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                try
                {
                    string StoredFileName = e.CommandArgument.ToString();

                    BEStudent objBEStudent = new BEStudent();
                    BStudent objBStudent = new BStudent();
                    objBEStudent.IntTransID = Convert.ToInt64(Request.QueryString["TransID"]);

                    objBEStudent.strOriginalFileName = StoredFileName;

                    System.IO.FileInfo objFileName = new System.IO.FileInfo(Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["StudentUploads"]) + "\\" + StoredFileName);

                    if (objFileName.Exists)
                    {
                        objFileName.Delete();
                        objBStudent.BStudentDeleteUploadedFile(objBEStudent);
                    }
                    else
                    {
                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "NotSaved", "alert('File doesnot exist');", true);

                        Page.ClientScript.RegisterStartupScript(GetType(), "MyScript", "alert('File deletion failed.Please try again.');", true);
                    }
                    gvUploadFiles.Rebind();
                    trMessage.Visible = false;
                 

                }
                catch (Exception ex) 
                {

                }
            }
        }

      
        protected void gvUploadFiles_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            try
            {
                this.getOriginalUploadFiles();
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }


    }
}