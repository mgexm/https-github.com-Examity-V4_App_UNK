using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using BLL;
using BusinessEntities;
using System.Data;

namespace SecureProctor.Admin
{
    public partial class ViewExam : BaseClass
    {

        #region PageLoad
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Page.Title = EnumPageTitles.APPNAME + EnumPageTitles.ADMIN_COURSEDETAILS_VIEW_EXAM;
                this.getSelectedExamDetails();

                this.GetStudentUploadFileStatus();
            }
        }
        #endregion

        protected void GetStudentUploadFileStatus()
        {

            BECommon objBECommon = new BECommon();
            BCommon objBCommon = new BCommon();
            objBCommon.BGetStudentUploadFileStatus(objBECommon);

            if (objBECommon.DtResult != null && objBECommon.DtResult.Rows.Count > 0)
            {
                if (objBECommon.DtResult.Rows[0][0].Equals(true))
                    trStudentUpload.Visible = true;
                else
                    trStudentUpload.Visible = false;

            }
        }
       


        #region getSelectedExamDetails
        protected void getSelectedExamDetails()
        {
            try
            {

                BEAdmin objBEAdmin = new BEAdmin();
                BAdmin objBAdmin = new BAdmin();
                objBEAdmin.IntExamID = Convert.ToInt32(Request.QueryString["ExamID"].ToString());
                objBEAdmin.IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID]);
                objBAdmin.BGetSelectedExamDetails(objBEAdmin);

                if (objBEAdmin.DsResult != null)
                {
                    lblCourseName.Text = objBEAdmin.DsResult.Tables[0].Rows[0]["CourseName"].ToString();
                    lblExamName.Text = objBEAdmin.DsResult.Tables[0].Rows[0]["ExamName"].ToString();
                    lblExamSecurityLevel.Text = objBEAdmin.DsResult.Tables[0].Rows[0]["Description"].ToString();
                    lblExamUserName.Text = objBEAdmin.DsResult.Tables[0].Rows[0]["ExamUserName"].ToString();
                    lblExamPassword.Text = objBEAdmin.DsResult.Tables[0].Rows[0]["ExamPassword"].ToString();
                    string[] str = objBEAdmin.DsResult.Tables[0].Rows[0]["ExamDuration"].ToString().Split('.');
                    if (str[0].ToString().Length == 1)
                        lblHoursValue.Text = "0" + str[0].ToString();
                    else
                        lblHoursValue.Text = str[0].ToString();
                    if (str[1].ToString().Length == 1)
                        lblMinutesValue.Text = "0" + str[1].ToString();
                    else
                        lblMinutesValue.Text = str[1].ToString();

                    lblStudentUploadFile.Text = objBEAdmin.DsResult.Tables[0].Rows[0]["StudentUploadFile"].ToString();

                    lblExamLink.Text = objBEAdmin.DsResult.Tables[0].Rows[0]["ExamLink"].ToString();
                    if (objBEAdmin.DsResult.Tables[0].Rows[0]["ExamStartDate"].ToString() != null && objBEAdmin.DsResult.Tables[0].Rows[0]["ExamStartDate"].ToString() != "--")
                    {
                        lblExamStartDate.Text = objBEAdmin.DsResult.Tables[0].Rows[0]["ExamStartDate"].ToString();
                    }

                    if (objBEAdmin.DsResult.Tables[0].Rows[0]["ExamEndDate"].ToString() != null && objBEAdmin.DsResult.Tables[0].Rows[0]["ExamEndDate"].ToString() != "--")
                    {

                        lblExamEndDate.Text = objBEAdmin.DsResult.Tables[0].Rows[0]["ExamEndDate"].ToString();
                    }
                    //if (objBEAdmin.DsResult.Tables[0].Rows[0]["OriginalFileName"].ToString() != "" && objBEAdmin.DsResult.Tables[0].Rows[0]["StoredFileName"].ToString() != "")
                    //{
                        //lnkUploadFile.Visible = true;
                      //  lblUploadValue.Visible = false;
                        //foreach (DataRow dr in objBEAdmin.DsResult.Tables[0].Rows)
                        //{

                        //    for (int i = 0; i < objBEAdmin.DsResult.Tables[0].Rows.Count; i++)
                        //    {
                        //        int rowValue;
                        //        if (int.TryParse(dr[i].ToString(), out rowValue))
                        //        {
                        //            dr[i] = i;
                        //            lnkUploadFile.Text = objBEAdmin.DsResult.Tables[0].Rows[i]["OriginalFileName"].ToString();
                        //            lnkUploadFile.CommandArgument = objBEAdmin.DsResult.Tables[0].Rows[i]["StoredFileName"].ToString();
                        //        }
                        //    }

                        //}


                        if(objBEAdmin.DsResult.Tables[4].Rows.Count>0)
                        {
                            ucUploadFiles.Visible = true;

                        }
                        else
                            ucUploadFiles.Visible = false;


                        //lnkUploadFile.Text =

                        //    objBEAdmin.DsResult.Tables[0].Rows[0]["OriginalFileName"].ToString() + ", " +
                        //    objBEAdmin.DsResult.Tables[0].Rows[1]["OriginalFileName"].ToString();

                        //lnkUploadFile.CommandArgument = objBEAdmin.DsResult.Tables[0].Rows[0]["StoredFileName"].ToString() + ", " +
                        //    objBEAdmin.DsResult.Tables[0].Rows[1]["StoredFileName"].ToString();
                    }
                    //else
                    //{
                     //   lnkUploadFile.Visible = false;
                     //   lblUploadValue.Visible = true;
                      //  lblUploadValue.Text = "N/A";

                    //}

                    //lblSpecialNeeds.Text = objBEAdmin.DsResult.Tables[0].Rows[0]["Specialneedsflag"].ToString();
                    if (objBEAdmin.DsResult.Tables[0].Rows[0]["Specialneedsflag"].ToString() == "False")
                    {
                        lblSpecialNeeds.Text = "No";
                    }
                    else
                    {
                        lblSpecialNeeds.Text = "Yes";
                    }
                    if (objBEAdmin.DsResult.Tables[0].Rows[0]["LockDownBrowser"].ToString() == "True")
                    {
                        lblLockdownBrowser.Text = "Yes";
                    }
                    else
                    {
                        lblLockdownBrowser.Text = "No";
                    }


                    if (objBEAdmin.DsResult.Tables[0].Rows[0]["PastSpecialRules"].ToString() == "1")
                    {
                        lblNoSpRules.Text = "Yes";
                    }
                    else
                    {
                        lblNoSpRules.Text = "No";
                    }

                    //updated from app  --22nov2017
                    string strUpdatedFromApp = objBEAdmin.DsResult.Tables[0].Rows[0]["UpdatedFromApp"].ToString();
                    lblUpdatedFromAppResult.Text = strUpdatedFromApp;
                    //color coding for this label if "Yes" - Red  , "No" - Black
                    if (strUpdatedFromApp == "Yes")
                        lblUpdatedFromAppResult.ForeColor = System.Drawing.Color.Red;
                    else
                        lblUpdatedFromAppResult.ForeColor = System.Drawing.Color.Black;
                    if (objBEAdmin.DsResult.Tables[0].Rows[0]["PaidBy_ExamFee"] != null)
                    {
                        if (objBEAdmin.DsResult.Tables[0].Rows[0]["PaidBy_ExamFee"].ToString() == "1")
                            lblExamFeePaidByConfirm.Text = "University";
                        else if (objBEAdmin.DsResult.Tables[0].Rows[0]["PaidBy_ExamFee"].ToString() == "2")
                            lblExamFeePaidByConfirm.Text = "Student";
                    }
                    if (objBEAdmin.DsResult.Tables[0].Rows[0]["PaidBy_OnDemandFee"] != null)
                    {
                        if (objBEAdmin.DsResult.Tables[0].Rows[0]["PaidBy_OnDemandFee"].ToString() == "1")
                            lblondemandFeePaidByConfirm.Text = "University";
                        else if (objBEAdmin.DsResult.Tables[0].Rows[0]["PaidBy_OnDemandFee"].ToString() == "2")
                            lblondemandFeePaidByConfirm.Text = "Student";
                    }

                    lblExamAttempts.Text = objBEAdmin.DsResult.Tables[0].Rows[0]["AllowedAttempts"].ToString();
                  
                    //gvNotes.DataSource = objBEAdmin.DsResult.Tables[1];
                    //gvNotes.Rebind();

                    //gvRules.DataSource = objBEAdmin.DsResult.Tables[2];
                    //gvRules.Rebind();
                }
            
            catch
            {
            }
        }
        #endregion
        //#region DownloadFile
        //protected void lnkUploadFile_Click(object sender, EventArgs e)
        //{
        //    this.openFile();

        //}
        //#endregion

        //#region openFile
        //protected void openFile()
        //{
        //    string MapPath = Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["ProviderUploadPath"].ToString());
        //    string UploadedFile = lnkUploadFile.CommandArgument.ToString();

        //    string fullPath = MapPath + '\\' + UploadedFile;

        //    FileInfo fi = new FileInfo(fullPath);

        //    if (fi.Exists)
        //    {

        //        long sz = fi.Length;

        //        Response.ClearContent();

        //        Response.ContentType = MimeType(Path.GetExtension(fullPath));

        //        Response.AddHeader("Content-Disposition", string.Format("attachment; filename = {0}", System.IO.Path.GetFileName(fullPath))); Response.AddHeader("Content-Length", sz.ToString("F0"));

        //        Response.TransmitFile(fullPath);

        //        Response.End();

        //    }
        //    else
        //    {
        //        Page.ClientScript.RegisterStartupScript(GetType(), "MyScript", "alert('File does not exist');", true);

        //    }




        //}

        //#endregion openFile

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
