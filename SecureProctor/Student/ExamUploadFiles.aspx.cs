using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessEntities;
using BLL;
using Telerik.Web.UI;
using System.IO;

namespace SecureProctor.Student
{
    public partial class ExamUploadFiles : BaseClass
    {
        int intTabCount = 11;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Page.Title = EnumPageTitles.APPNAME + EnumPageTitles.UPLOADFILES;
            ((LinkButton)this.Page.Master.FindControl("lnkUploadfiles")).CssClass = "main_menu_active";

            if (!IsPostBack)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "NotSaved", "document.getElementById('" + imgHead.ClientID.ToString() + "').focus();", true);
            }
        }

        protected void gvStudentHome_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            try
            {
                this.LoadData();
                if (Session["ACCESSIBILITY"] != null)
                {
                    if (Session["ACCESSIBILITY"].ToString() == "ON")
                        gvStudentHome.AllowPaging = false;
                    else
                        gvStudentHome.AllowPaging = true;
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        protected void LoadData()
        {
            try
            {
                BEStudent objBEStudent = new BEStudent();
                BStudent objBStudent = new BStudent();
                objBEStudent.IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID].ToString());
                objBEStudent.IntProviderID = 0;
                objBEStudent.strExamName = string.Empty;
                objBStudent.BGetStudentTransactions(objBEStudent);
                if (objBEStudent.DtResult.Rows.Count > 0)
                {
                    gvStudentHome.DataSource = objBEStudent.DtResult;

                }


                else
                {

                    gvStudentHome.DataSource = new object[] { };

                    objBEStudent = null;
                    objBStudent = null;

                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        protected void gvStudentHome_ItemCommand(object sender, GridCommandEventArgs e)
        {

            if (e.CommandName == "ExamID")
            {
                //Response.Redirect("ExamDetailsConfirmation.aspx?" + AppSecurity.Encrypt("ExamID=" + e.CommandArgument), false);
                Response.Redirect("ExamDetailsConfirmation.aspx?TransID=" + AppSecurity.Encrypt(e.CommandArgument.ToString()), false);
            }
            else if (e.CommandName == "Reschdule")
            {
                Response.Redirect("ScheduleAnExam.aspx?ExamDate=" + AppSecurity.Encrypt(e.CommandArgument.ToString().Replace("/", "EC").Trim()), false);
            }

        }

        protected void gvStudentHome_ItemDataBound(object sender, GridItemEventArgs e)
        {

            if (e.Item is GridDataItem)
            {
                GridDataItem item = (GridDataItem)e.Item;
                Label lbl = (Label)item.FindControl("lblStatusName");

                if (lbl.Text == "Scheduled")
                {

                    LinkButton lnkReschedule = (LinkButton)item.FindControl("lnkReschdule");
                    lnkReschedule.Visible = true;

                }
                else
                {
                    Label lblReschedule = (Label)item.FindControl("lblReschdule");
                    lblReschedule.Visible = true;

                }

                ImageButton img = (ImageButton)item.FindControl("imgUpload");
                if (img.CommandArgument == "True")
                {
                    if (lbl.Text == "No-show" || lbl.Text == "Cancelled" || lbl.Text == "Scheduled")
                        img.Visible = false;
                    else
                    {
                        img.Visible = true;
                        #region GridControlTabIndex
                        LinkButton lnkLinkButton1 = (LinkButton)item.FindControl("lnkTransID");
                        lnkLinkButton1.TabIndex = (short)intTabCount++;
                        item["CourseName"].TabIndex = (short)intTabCount++;
                        item["ExamName"].TabIndex = (short)intTabCount++;
                        item["ExamDate"].TabIndex = (short)intTabCount++;
                        item["SlotStartTime"].TabIndex = (short)intTabCount++;
                        item["StatusName"].TabIndex = (short)intTabCount++;
                        ImageButton ImgImageButton1 = (ImageButton)item.FindControl("imgUpload");
                        ImgImageButton1.TabIndex = (short)intTabCount++;
                        #endregion
                    }
                }
                else
                {
                    img.Visible = false;
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

        protected void lnkFile_Click(object sender, EventArgs e)
        {
            Int64 transID = Convert.ToInt64(((LinkButton)sender).CommandArgument);
            string FileName = ((LinkButton)sender).Text.ToString();

            BECommon objBECommon = new BECommon();
            BCommon objBCommon = new BCommon();

            objBECommon.IntTransID = Convert.ToInt64(transID);
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


                        Page.ClientScript.RegisterStartupScript(GetType(), "MyScript", "alert('File doesnot exist');", true);

                    }

                }
            }



        }

        protected void gvStudentHome_ItemCreated(object sender, GridItemEventArgs e)
        {


        }
    }
}