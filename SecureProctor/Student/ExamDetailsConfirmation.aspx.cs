using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using BusinessEntities;
using System.IO;

namespace SecureProctor.Student
{
    public partial class ExamDetailsConfirmation : BaseClass
    {
        string strExamID = string.Empty;
      

        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {

                this.Page.Title = EnumPageTitles.APPNAME + EnumPageTitles.HOME;
                ((LinkButton)this.Page.Master.FindControl("lnkMyExams")).CssClass = "main_menu_active";
                this.Page.Title = EnumPageTitles.APPNAME + EnumPageTitles.ExamDetails;
                if (!IsPostBack)
                {
                    imgCalc.Visible = false;
                    imgStickyNotes.Visible = false;
                    lblTools.Visible = false;
                   
                    
                    if (Request.QueryString != null && Request.QueryString.ToString() != "")
                    {
                        //string[] strAr = CommonFunctions.UrlDecryptor(Server.UrlDecode(Request.QueryString.ToString()));
                        //foreach (string strItem in strAr)
                        //{
                        //    if (strItem.Contains("ExamID"))
                        //        strExamID = strItem.Split('=')[1].ToString();
                        //    Session[BaseClass.EnumPageSessions.EXAMID] = strExamID;
                            
                        //}
                        strExamID = AppSecurity.Decrypt(Request.QueryString["TransID"].ToString());
                        Session[BaseClass.EnumPageSessions.EXAMID] = strExamID;

                    }
                    if (Session[BaseClass.EnumPageSessions.EXAMID] != null)
                    {
                        SetExamDetails(Convert.ToInt64(Session[BaseClass.EnumPageSessions.EXAMID]));


                    }
                  

                }
            }
            catch (Exception )
            {
                //ErrorLog.WriteError(Ex);

            }





        }


        protected void SetExamDetails(Int64 TransactionID)
        {


            BECommon objBECommon = new BECommon();
            BCommon objBCommon = new BCommon();

            objBECommon.IntTransID = TransactionID;
            objBECommon.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID]);
            objBCommon.BGetStudentExamDetails(objBECommon);

            if (objBECommon.DsResult.Tables[0].Rows.Count > 0)
            {
                lblTransactionID.Text = objBECommon.IntTransID.ToString();
                lblStudentName.Text = objBECommon.DsResult.Tables[0].Rows[0]["Name"].ToString();
                lblCourseName.Text = objBECommon.DsResult.Tables[0].Rows[0]["CourseName"].ToString();
                //lblExamName.Text = objBECommon.DsResult.Tables[0].Rows[0]["ExamName"].ToString();
                lblDAte.Text = objBECommon.DsResult.Tables[0].Rows[0]["ExamDate"].ToString();
                lblSlot.Text = objBECommon.DsResult.Tables[0].Rows[0]["TimeDuration"].ToString();
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




            if (objBECommon.DsResult.Tables[3].Rows.Count > 0)
            {
               // gvStudentRules.Visible = true;
               // gvStudentRules.DataSource = objBECommon.DsResult.Tables[3];

                //gvStudentRules.DataBind();
            }
            else
            {
               // gvStudentRules.Visible = false;
            }
            //else
            //   {
            // gvStudentRules.DataSource = null;

            //   gvStudentRules.DataSource = new object[] { };

            // gvStudentRules.DataBind();

            // }



            bool noTools = false;
            if (objBECommon.DsResult.Tables[2].Rows.Count > 0)
            {
                noTools = true;
                for (int i = 0; i < objBECommon.DsResult.Tables[2].Rows.Count; i++)
                {
                    if (objBECommon.DsResult.Tables[2].Rows[i]["ToolID"].ToString() == "101")
                        imgCalc.Visible = true;
                    if (objBECommon.DsResult.Tables[2].Rows[i]["ToolID"].ToString() == "102")
                        imgStickyNotes.Visible = true;
                }
            }
            if (noTools == false)
            {
                lblError.Visible = true;
                lblError.Text = "N/A";

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
    }
}