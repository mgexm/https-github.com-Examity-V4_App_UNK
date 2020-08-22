using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessEntities;
using BLL;
using System.IO;

namespace SecureProctor.Proctor
{
    public partial class ExamDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            getExamDetails();
        }

        protected void getExamDetails()
        {
            BEProctor objBEProctor = new BEProctor();
            BProctor objBProctor = new BProctor();

            objBEProctor.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID]);

            objBEProctor.IntExamID1 = Convert.ToInt64(AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()));

            objBProctor.BGetExamDetails(objBEProctor);

            if (objBEProctor.DsResult.Tables[0].Rows.Count > 0)
            {

               // lblExamID.Text = CommonFunctions.CheckNullValue(objBEProctor.DsResult.Tables[0].Rows[0]["TransID"].ToString());
                lblDAte.Text = CommonFunctions.CheckNullValue(objBEProctor.DsResult.Tables[0].Rows[0]["ExamDate"].ToString());
                lblSlot.Text = CommonFunctions.CheckNullValue(objBEProctor.DsResult.Tables[0].Rows[0]["ExamStartDate"].ToString());
                lblCourseName.Text = CommonFunctions.CheckNullValue(objBEProctor.DsResult.Tables[0].Rows[0]["CourseName"].ToString());
                lblExamName.Text = CommonFunctions.CheckNullValue(objBEProctor.DsResult.Tables[0].Rows[0]["ExamName"].ToString());
                lblDuration.Text = CommonFunctions.CheckNullValue(objBEProctor.DsResult.Tables[0].Rows[0]["ExamDuration"].ToString());
                lblEndTime.Text = CommonFunctions.CheckNullValue(objBEProctor.DsResult.Tables[0].Rows[0]["ExamEndDate"].ToString());
                if (objBEProctor.DsResult.Tables[0].Rows[0]["OriginalFileName"] != null && objBEProctor.DsResult.Tables[0].Rows[0]["OriginalFileName"].ToString() != "")
                {
                    lnkProviderFile.Visible = true;
                    lnkProviderFile.Text = objBEProctor.DsResult.Tables[0].Rows[0]["OriginalFileName"].ToString();
                    lblError.Visible = false;
                }
                else
                {
                    lnkProviderFile.Visible = false;
                    lblError.Visible = true;
                    lblError.Text = "N/A";
                }
                if (objBEProctor.DsResult.Tables[0].Rows[0]["ExamLink"] != null && objBEProctor.DsResult.Tables[0].Rows[0]["ExamLink"].ToString() != "")

                    lblURL.Text = objBEProctor.DsResult.Tables[0].Rows[0]["ExamLink"].ToString();
                else
                    lblURL.Text = "N/A";


            }

        }

        //protected void gvStudentNotes_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        //{
        //    try
        //    {
        //        this.GetComments();
        //    }
        //    catch (Exception Ex)
        //    {
        //        throw Ex;
        //    }
        //}

        //protected void GetComments()
        //{


        //    BEProctor objBEProctor = new BEProctor();
        //    BProctor objBProctor = new BProctor();
        //    objBEProctor.IntExamID = Convert.ToInt32(AppSecurity.Decrypt(Request.QueryString["ExamID"].ToString()));

        //    objBEProctor.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID]);
        //    objBProctor.BGetExamDetails(objBEProctor);
        //    if (objBEProctor.DsResult != null)
        //    {
        //        if (objBEProctor.DsResult.Tables[0].Rows.Count > 0)
        //        {
        //            if (objBEProctor.DsResult.Tables[1].Rows.Count > 0)
        //            {
        //                gvStudentNotes.Visible = true;

        //                gvStudentNotes.DataSource = objBEProctor.DsResult.Tables[1];

        //            }
        //            else
        //            {
        //                // gvStudentNotes.DataSource = new object[] { };

        //                gvStudentNotes.Visible = false;
        //            }

        //        }


        //    }

        //}

        protected void lnkFile_Click(object sender, EventArgs e)
        {

            BEProctor objBEProctor = new BEProctor();
            BProctor objBProctor = new BProctor();

            objBEProctor.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID]);

            objBEProctor.IntExamID1 = Convert.ToInt64(AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()));

            objBProctor.BGetExamDetails(objBEProctor);

            if (objBEProctor.DsResult.Tables[0].Rows.Count > 0)
            {


                if (objBEProctor.DsResult.Tables[0].Rows[0]["StoredFileName"] != null && objBEProctor.DsResult.Tables[0].Rows[0]["StoredFileName"].ToString() != "")
                {

                    string UploadedFile = objBEProctor.DsResult.Tables[0].Rows[0]["StoredFileName"].ToString();

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

                        Page.ClientScript.RegisterStartupScript(GetType(), "MyScript", "alert('File doesnot exist');", true);

                    }
                }
                else
                {
                    lnkProviderFile.Visible = false;
                    lblError.Visible = true;
                    lblError.Text = "N/A";
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
    }
}