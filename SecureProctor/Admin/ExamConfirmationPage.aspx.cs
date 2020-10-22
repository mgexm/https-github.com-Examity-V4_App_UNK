using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessEntities;
using BLL;
using System.IO;

namespace SecureProctor.Admin
{
    public partial class ExamConfirmationPage : BaseClass
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            this.Page.Title = EnumPageTitles.APPNAME + EnumPageTitles.EXAMPROVIDER_EXAMDETAILS;

            if (!IsPostBack)
            {
                //((LinkButton)this.Page.Master.FindControl("lnkExamDetails")).CssClass = "main_menu_active";
                ((LinkButton)this.Page.Master.FindControl("lnkCourses")).CssClass = "main_menu_active";
                if (Session["EP_Exam"] != null)
                {
                    BEProvider objBEExamProvider = (BEProvider)Session["EP_Exam"];
                    lblCourseName.Text = objBEExamProvider.strCourseName;
                    lblExamsecurity.Text = objBEExamProvider.strSecurityLevel1;
                    lblExamName.Text = objBEExamProvider.strExamName;
                    if (objBEExamProvider.ddlHours.ToString().Length < 2)
                    {
                        lblHours.Text = "0" + objBEExamProvider.ddlHours.ToString();
                    }
                    else
                    {
                        lblHours.Text = objBEExamProvider.ddlHours.ToString();
                    }
                    if (objBEExamProvider.ddlMinutes.ToString().Length < 2)
                    {
                        lblMinutes.Text = "0" + objBEExamProvider.ddlMinutes.ToString();
                    }
                    else
                    {
                        lblMinutes.Text = objBEExamProvider.ddlMinutes.ToString();
                    }
                    if (objBEExamProvider.IntBufferTime.ToString().Length < 2)
                    {
                        lblBufferTime.Text = "0" + objBEExamProvider.IntBufferTime.ToString();
                    }
                    else
                    {
                        lblBufferTime.Text = objBEExamProvider.IntBufferTime.ToString();
                    }
                    if (objBEExamProvider.strOriginalFileName != null && objBEExamProvider.strOriginalFileName.ToString() != "")
                    {
                        lnlFile.Visible = true;
                        lblFile.Visible = false;
                        lnlFile.Text = objBEExamProvider.strOriginalFileName.ToString();

                    }
                    else
                    {
                        lnlFile.Visible = false;
                        lblFile.Visible = true;
                        lblFile.Text = "N/A";
                    }
                    lbllink.Text = objBEExamProvider.strLinkAccessExam;
                    lblStartDate.Text = objBEExamProvider.strExamStartDate.ToShortDateString();
                    lblEndDate.Text = objBEExamProvider.strExamEndDate.ToShortDateString();
                    //if (objBEExamProvider.intCalc.ToString() == "1")
                    //    imgCalc.Visible = true;
                    //else
                    //    imgCalc.Visible = false;
                    //if (objBEExamProvider.intStickyNotes.ToString() == "1")
                    //    imgStickyNotes.Visible = true;
                    //else
                    //    imgStickyNotes.Visible = false;
                    trButtons.Visible = true;
                    trMessage.Visible = false;
                }
                else
                {
                    Response.Redirect("Home.aspx");
                }
            }
            else
            {
                if (Session["EP_Exam"] == null)
                {
                    trButtons.Visible = false;
                    trMessage.Visible = true;
                }
            }
        }

        protected void btnProceed_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["EP_Exam"] != null)
                {
                    BEProvider objBEExamProvider = (BEProvider)Session["EP_Exam"];
                    BProvider objBExamProvider = new BProvider();
                    // objBEExamProvider.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID].ToString());
                    objBExamProvider.BAdminSaveExamDetails(objBEExamProvider);
                    trButtons.Visible = false;
                    trMessage.Visible = true;
                    objBEExamProvider = null;
                    objBEExamProvider = null;
                    Session["EP_Exam"] = null;
                    Session["DT_Notes"] = null;
                    Session["DT_Rules"] = null;
                }
                else
                {

                }
            }
            catch
            {
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {



            Response.Redirect("ExamDetails.aspx");




        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ExamDetails.aspx");
        }

        protected void gvNotes_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            try
            {
                if (Session["EP_Exam"] != null)
                {
                    BEProvider objBEProvider = (BEProvider)Session["EP_Exam"];
                    if (objBEProvider.DtResult != null)
                    {
                        gvNotes.DataSource = objBEProvider.DtResult;
                    }

                    else
                    {

                        gvNotes.DataSource = new object[] { };
                    }
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        protected void gvRules_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            try
            {
                if (Session["EP_Exam"] != null)
                {
                    BEProvider objBEProvider = (BEProvider)Session["EP_Exam"];
                    if (objBEProvider.DtResult1 != null)
                    {
                        gvRules.DataSource = objBEProvider.DtResult1;
                    }

                    else
                    {
                        gvRules.DataSource = new object[] { };

                    }
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        protected void gvExamTools_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            try
            {
                if (Session["EP_Exam"] != null)
                {
                    BEProvider objBEProvider = (BEProvider)Session["EP_Exam"];
                    if (objBEProvider.DtTools != null)
                    {
                        gvExamTools.DataSource = objBEProvider.DtTools;
                    }

                    else
                    {

                        gvExamTools.DataSource = new string[] { };
                    }
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        protected void DeleteProviderUploadedFile()
        {

            try
            {
                string strpath = Server.MapPath("../Provider/Provider_Uploads");

                BEProvider objBEExamProvider = (BEProvider)Session["EP_Exam"];
                string strTotalPath = strpath + '\\' + objBEExamProvider.strUploadPath.ToString();
                System.IO.FileInfo fi = new System.IO.FileInfo(strTotalPath);
                fi.Delete();


            }

            catch (Exception )
            {


            }

        }

        protected void lnlFile_Click(Object sender, EventArgs e)
        {
            BEProvider objBEExamProvider = (BEProvider)Session["EP_Exam"];

            if (objBEExamProvider.strOriginalFileName != null && objBEExamProvider.strOriginalFileName.ToString() != "")
            {
                string UploadedFile = objBEExamProvider.strUploadPath;

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
