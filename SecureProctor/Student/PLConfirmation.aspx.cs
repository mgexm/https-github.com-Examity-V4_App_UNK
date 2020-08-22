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
    public partial class PLConfirmation : BaseClass
    {
        Int64 TransID = 0;
        string Type = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["TransID"] != null)
            {
                TransID = Convert.ToInt64(AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()));

            }

            if (Request.QueryString["Type"] != null)
            {
                Type = AppSecurity.Decrypt(Request.QueryString["Type"].ToString());

            }

            this.Page.Title = EnumPageTitles.APPNAME + "Schedule Confirmation";
            ((LinkButton)this.Page.Master.FindControl("lnkSchedule")).CssClass = "main_menu_active";
            this.BindExamDetails(TransID);
            this.GetAllRules(TransID);
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
        protected void BindExamDetails(Int64 TransactionID)
        {
            BECommon objBECommon = new BECommon();
            BCommon objBCommon = new BCommon();

            objBECommon.IntTransID = TransactionID;
            objBECommon.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID]);
            objBCommon.BGetStudentExamDetails(objBECommon);

            if (objBECommon.DsResult.Tables[0].Rows.Count > 0)
            {
                lblTransID.Text = TransactionID.ToString();
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
                if (Type == "0")
                {
                    lblInfo.Text = "<img src='../Images/yes.png'align='middle'/>&nbsp;<font color='#00C000'>" + "Appointment scheduled successfully.";
                }
                else if (Type == "1")
                {
                    lblInfo.Text = "<img src='../Images/yes.png'align='middle'/>&nbsp;<font color='#00C000'>" + "Appointment rescheduled successfully.";
                }
                else
                {
                    lblInfo.Text = "<img src='../Images/yes.png'align='middle'/>&nbsp;<font color='#00C000'>" + "Appointment scheduled successfully.";
                }

                if (objBECommon.DsResult.Tables[6] != null)
                {
                    if (objBECommon.DsResult.Tables[6].Rows.Count > 0)
                    {
                        int leval = Convert.ToInt32(objBECommon.DsResult.Tables[6].Rows[0]["secirtyType"].ToString());
                        bool isexamiFACE = Convert.ToBoolean(objBECommon.DsResult.Tables[6].Rows[0]["IsexamiFACE"].ToString());
                        if (leval == 5 || isexamiFACE)
                            trautoconnect.Visible = true;
                    }

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
    }
}
