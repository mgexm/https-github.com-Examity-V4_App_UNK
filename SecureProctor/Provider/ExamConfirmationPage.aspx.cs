using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using BusinessEntities;
using System.Data;
using System.IO;
namespace SecureProctor.Provider
{
    public partial class ExamConfirmationPage : BaseClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Page.Title = EnumPageTitles.APPNAME + EnumPageTitles.EXAMPROVIDER_EXAMDETAILS;
            if (!IsPostBack)
            {
                //((LinkButton)this.Page.Master.FindControl("lnkExamDetails")).CssClass = "main_menu_active";
                trSuccess.Visible = false;
                ((LinkButton)this.Page.Master.FindControl("lnkCourseDetails")).CssClass = "main_menu_active";
                if (Session["EP_Exam"] != null)
                {
                    BEProvider objBEExamProvider = (BEProvider)Session["EP_Exam"];
                    lblCourseName.Text = objBEExamProvider.strCourseName;
                    lblExamName.Text = objBEExamProvider.strExamName;
                    lblExamsecurity.Text = objBEExamProvider.strSecurityLevel1;
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
                        ViewState["ExamFile"] = objBEExamProvider.strUploadPath.ToString();
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
                    //if (objBEExamProvider.intCalc.ToString() != "1" && objBEExamProvider.intStickyNotes.ToString() != "1")
                    //{
                    //    lblError.Visible = true;
                    //    lblError.Text = "No tools available";
                    //}
                    //else
                    //{
                    //    lblError.Visible = false;
                    //}
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
                    objBEExamProvider.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID].ToString());


                    objBExamProvider.BSaveExamDetails(objBEExamProvider);
                    trSuccess.Visible = true;
                    trButtons.Visible = false;
                    trMessage.Visible = true;
                    objBEExamProvider = null;
                    objBEExamProvider = null;
                    Session["EP_Exam"] = null;
                    Session["DT_Notes"] = null;
                    Session["DT_Rules"] = null;
                    lblMsg.Text = "<img src='../Images/yes.png' align='middle'/>&nbsp;<font color='#00C000'>" + Resources.ResMessages.Provider_ExamDetailsSuccess + "</font>";

                }

            }
            catch
            {
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {

            //this.DeleteProviderUploadedFile();
            Session["EP_Exam"] = null;

            Response.Redirect("ExamDetails.aspx");




        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (lnlFile.Text != "N/A")
                this.DeleteProviderUploadedFile();

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

                        gvNotes.DataSource = new string[] { };
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
                        gvRules.DataSource = new string[] { };

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
                string strpath = Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["ProviderUploads"]);

                BEProvider objBEExamProvider = (BEProvider)Session["EP_Exam"];
                string strTotalPath = strpath + '\\' + objBEExamProvider.strUploadPath.ToString();
                System.IO.FileInfo fi = new System.IO.FileInfo(strTotalPath);
                fi.Delete();


            }

            catch (Exception e)
            {


            }

        }

        protected void lnlFile_Click(Object sender, EventArgs e)
        {
            BEProvider objBEExamProvider = (BEProvider)Session["EP_Exam"];

            if (ViewState["ExamFile"] != null && ViewState["ExamFile"].ToString() != "")
            {

                string UploadedFile = ViewState["ExamFile"].ToString();

                string MapPath = System.Web.HttpContext.Current.Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["ProviderUploads"]);

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