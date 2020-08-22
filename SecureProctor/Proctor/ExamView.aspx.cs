using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using BusinessEntities;
using SecureProctor.Student;
using System.IO;
using Telerik.Web.UI;
//using AjaxControlToolkit;

namespace SecureProctor.Proctor
{
    public partial class ExamView : BaseClass
    {
        public string SessionID = "";
        public string TokenID = "";
        public string Transid = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindGOTOMeetingLink();
                this.BindAlerts();
                //lblfileupload.Visible = false;
                lblError.Visible = false;
                lblfileupload.Text = string.Empty;
                //if (Request.QueryString.ToString() != "")
                //{
                //    SessionID = AppSecurity.Decrypt(Request.QueryString["OTSessionID"]);
                //}
                //else
                //{
                //    //Show errors if any
                //}
                //OpenTokSDK opentok = new OpenTokSDK();
                //TokenID = opentok.GenerateToken(SessionID);

                lblTools.Visible = false;
                imgCalc.Visible = false;
                imgStickyNotes.Visible = false;
                setExamDetails();
                this.BindStudentIdentity();
                this.GetUploadedFileDetails(Convert.ToInt64(AppSecurity.Decrypt(Request.QueryString["TransID"].ToString())));

            }
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager.RegisterPostBackControl(this.lnlFile);
            scriptManager.RegisterPostBackControl(this.lnkProviderFile);
        }

        protected void bindGOTOMeetingLink()
        {
            BEStudent objBEStudent = new BEStudent();
            BStudent objBStudent = new BStudent();
            objBEStudent.IntTransID = Convert.ToInt64(GetTransID());
            objBStudent.BGetExamSessionID(objBEStudent);
            lnk.Attributes.Add("onclick", "openwin('" + System.Configuration.ConfigurationManager.AppSettings["GOTOMeetingLink"].ToString() + objBEStudent.strSessionID);

        }

        #region BindStudentIdentity
        protected void BindStudentIdentity()
        {
            try
            {
                BCommon objBCommon = new BCommon();
                BECommon objBECommon = new BECommon();
                objBECommon.IntTransID = Convert.ToInt64(AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()));
                objBECommon.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID]);
                objBCommon.BGetStudentExamDetails(objBECommon);
                if (objBECommon.DsResult != null)
                {
                    if (objBECommon.DsResult.Tables[0].Rows.Count > 0)
                    {
                        //img.ImageUrl = "../Student/Student_Identity/" + objBECommon.DsResult.Tables[0].Rows[0]["PhotoIdentity"].ToString().Substring(3).ToString();
                        img.ImageUrl = new AppSecurity().ImageToBase64(objBECommon.DsResult.Tables[0].Rows[0]["PhotoIdentity"].ToString().Substring(3).ToString());
                        img.ImageAlign = ImageAlign.Top;

                    }
                }

            }
            catch (Exception Ex)
            {
                //ErrorLog.WriteError(Ex);
            }
        }
        #endregion

        protected void setExamDetails()
        {
            Int64 TransactionID = Convert.ToInt64(AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()));
            BCommon objBCommon = new BCommon();
            BECommon objBECommon = new BECommon();

            objBECommon.IntTransID = TransactionID;
            objBECommon.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID]);
            objBCommon.BGetStudentExamDetails(objBECommon);
            if (objBECommon.DsResult != null)
            {
                if (objBECommon.DsResult.Tables[0].Rows.Count > 0)
                {

                    lblTransactionID.Text = objBECommon.IntTransID.ToString();
                    lblDAte.Text = objBECommon.DsResult.Tables[0].Rows[0]["ExamDate"].ToString();
                    //lblSlot.Text = objBECommon.DsResult.Tables[0].Rows[0]["TimeDuration"].ToString();
                    lblSlot.Text = objBECommon.DsResult.Tables[0].Rows[0]["ExamStartDate"].ToString();
                    // lblStudentName.Text = objBECommon.DsResult.Tables[0].Rows[0]["Name"].ToString();
                    //lblEmailID.Text = objBECommon.DsResult.Tables[0].Rows[0]["EmailAddress"].ToString();
                    lblCourseName.Text = objBECommon.DsResult.Tables[0].Rows[0]["CourseName"].ToString();
                    lblExamName.Text = objBECommon.DsResult.Tables[0].Rows[0]["ExamName"].ToString();
                    lblPhoneNumber.Text = CommonFunctions.CheckNullValue(objBECommon.DsResult.Tables[0].Rows[0]["PhoneNumber"].ToString());
                    // lblTimeZone.Text = objBECommon.DsResult.Tables[0].Rows[0]["TimeZone"].ToString();
                    lblSpecialNeeds.Text = objBECommon.DsResult.Tables[0].Rows[0]["SpecialNeeds"].ToString();
                    lblExamLink.Text = objBECommon.DsResult.Tables[0].Rows[0]["ExamLink"].ToString();
                    if (objBECommon.DsResult.Tables[0].Rows[0]["Comments"] != DBNull.Value && objBECommon.DsResult.Tables[0].Rows[0]["Comments"].ToString() != string.Empty)
                    {
                        lblComments.Text = objBECommon.DsResult.Tables[0].Rows[0]["Comments"].ToString();
                    }
                    else
                    {
                        lblComments.Text = "N/A";
                    }

                    lblDuration.Text = objBECommon.DsResult.Tables[0].Rows[0]["ExamDuration"].ToString();
                    //lblEndTime.Text = objBECommon.DsResult.Tables[0].Rows[0]["EndTime"].ToString();
                    lblEndTime.Text = objBECommon.DsResult.Tables[0].Rows[0]["ExamEndDate"].ToString();

                    if (objBECommon.DsResult.Tables[0].Rows[0]["OriginalFileName"] != null && objBECommon.DsResult.Tables[0].Rows[0]["OriginalFileName"].ToString() != "")
                    {
                        lnkProviderFile.Visible = true;
                        lnkProviderFile.Text = objBECommon.DsResult.Tables[0].Rows[0]["OriginalFileName"].ToString();
                        lblError.Visible = false;
                        if (objBECommon.DsResult.Tables[0].Rows[0]["StoredFileName"] != null && objBECommon.DsResult.Tables[0].Rows[0]["StoredFileName"].ToString() != "")
                        {

                            string UploadedFile = objBECommon.DsResult.Tables[0].Rows[0]["StoredFileName"].ToString();

                            string MapPath = System.Web.HttpContext.Current.Server.MapPath("../Provider/Provider_Uploads");

                            string fullPath = MapPath + '\\' + UploadedFile;

                            FileInfo fi = new FileInfo(fullPath);

                            if (!fi.Exists)
                            {
                                lnkProviderFile.Visible = false;
                                lblError.Visible = true;
                                lblError.Text = "File doesnot exists";
                                lblError.ForeColor = System.Drawing.Color.Red;
                            }
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
                lblTools.Visible = true;

            if (objBECommon.DsResult.Tables[4].Rows.Count > 0)
            {
                lblExamProviderName.Text = objBECommon.DsResult.Tables[4].Rows[0]["ExamProviderName"].ToString();
                lblExamProviderEmailAddress.Text = objBECommon.DsResult.Tables[4].Rows[0]["EmailAddress"].ToString();

            }
        }

        protected void gvStudentNotes_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            try
            {
                this.GetComments();
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        protected void GetComments()
        {

            Int64 TransactionID = Convert.ToInt64(AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()));
            BCommon objBCommon = new BCommon();
            BECommon objBECommon = new BECommon();

            objBECommon.IntTransID = TransactionID;
            objBECommon.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID]);
            objBCommon.BGetStudentExamDetails(objBECommon);
            if (objBECommon.DsResult != null)
            {
                if (objBECommon.DsResult.Tables[0].Rows.Count > 0)
                {
                    if (objBECommon.DsResult.Tables[1].Rows.Count > 0)
                    {
                        gvStudentNotes.DataSource = objBECommon.DsResult.Tables[1];

                    }
                    else
                    {
                        gvStudentNotes.DataSource = new object[] { };
                    }
                }
            }
        }

        protected void gvComments_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            try
            {
                this.BindTransactionsComments();
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        #region BindTransactionsComments
        protected void BindTransactionsComments()
        {

            try
            {
                BCommon objBCommon = new BCommon();
                BECommon objBECommon = new BECommon();
                objBECommon.IntTransID = Convert.ToInt64(AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()));
                objBECommon.IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID]);
                objBCommon.BGetTransactionComments(objBECommon);
                if (objBECommon.DtResult.Rows.Count > 0 && objBECommon.DtResult != null)
                    gvComments.DataSource = objBECommon.DtResult;
                else
                    gvComments.DataSource = new object[] { };

            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        #endregion

        #region AddComments
        protected void BindAlerts()
        {
            try
            {
                txtComments.Visible = false;
                RequiredFieldValidator11.Enabled = false;
                RequiredFieldValidator11.ValidationGroup = string.Empty;
                BECommon objBEComon = new BECommon();
                BCommon objBCommon = new BCommon();
                objBEComon.intRoleID = Convert.ToInt32(Session["RoleID"].ToString());
                objBCommon.BGetAlerts(objBEComon);
                ddlAlerts.AppendDataBoundItems = true;
                Telerik.Web.UI.RadComboBoxItem item = new Telerik.Web.UI.RadComboBoxItem("--Please select--", "0");
                ddlAlerts.Items.Add(item);
                ddlAlerts.DataSource = objBEComon.DtResult;
                ddlAlerts.DataValueField = "AlertID";
                ddlAlerts.DataTextField = "AlertText";
                ddlAlerts.DataBind();
            }
            catch
            {
            }
        }
        protected void btnAddComments_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    BCommon objBCommon = new BCommon();
                    BECommon objBECommon = new BECommon();
                    objBECommon.IntTransID = Convert.ToInt64(AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()));
                    objBECommon.IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID].ToString());
                    objBECommon.StrComments = txtComments.Text.ToString();
                    objBECommon.StrddlComments = getSelectFlag().ToString();
                    objBECommon.intAlertID = Convert.ToInt32(ddlAlerts.SelectedValue.ToString());
                    objBCommon.BAddComments(objBECommon);
                    objBECommon = null;
                    objBCommon = null;
                    txtComments.Text = string.Empty;
                    gvComments.Rebind();
                }


                catch (Exception Ex)
                {
                    throw Ex;
                }
            }

        }

        protected int getSelectFlag()
        {
            int i = 1;
            if (rdGreen.Checked == true)
                i = 1;
            else if (rdOrange.Checked == true)
                i = 2;
            else if (rdRed.Checked == true)
                i = 3;
            else if (rdAlert.Checked == true)
                i = 4;
            return i;
        }
        protected void ddlAlerts_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (ddlAlerts.SelectedItem.Text.ToString().ToUpper() == "OTHER")
            {
                txtComments.Text = string.Empty;
                txtComments.Visible = true;
                RequiredFieldValidator11.Enabled = true;
                RequiredFieldValidator11.ValidationGroup = "Add";
            }
            else
            {
                txtComments.Visible = false;
                txtComments.Text = string.Empty;
                RequiredFieldValidator11.Enabled = false;
                RequiredFieldValidator11.ValidationGroup = string.Empty;
            }
        }
        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtComments.Text = string.Empty;
        }
        #endregion

        #region BtnapproveTransaction
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {

                BProctor objBProctor = new BProctor();
                BEProctor objBEProctor = new BEProctor();
                objBEProctor.IntTransID = Convert.ToInt64(AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()));
                objBEProctor.IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID].ToString());
                objBProctor.BGetExamTransactionStatus(objBEProctor);
                string stat = "";
                if (rdApprove.SelectedIndex == 0)
                {
                    stat = "Approve";
                }
                else if (rdApprove.SelectedIndex == 1)
                {
                    stat = "Close";
                }
                else if (rdApprove.SelectedIndex == 2)
                {
                    stat = "Incomplete";
                }

                if (objBEProctor.DtResult.Rows[0][0].ToString() == "3")
                {
                    if (stat != "" && stat == "Approve")
                    {
                        Response.Redirect("ProctorConfirmation.aspx?type=1&TransID=" + AppSecurity.Encrypt(objBEProctor.IntTransID.ToString()).ToString() + "&status=" + AppSecurity.Encrypt(stat) + "", false);
                    }
                    else
                    {
                        //lblalert.Visible = true;
                        //lblalert.Text = "Exam has been already completed, please approve for auditor action";
                        return;
                    }
                }
                else if (objBEProctor.DtResult.Rows[0][0].ToString() == "2")
                {
                    if (stat != "" && stat != "Approve")
                    {
                        if (stat == "Close")
                        {
                            //BEProctor objBEProctor = new BEProctor();
                            //BProctor objBProctor = new BProctor();
                            //objBEProctor.IntTransID = Convert.ToInt32(AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()));
                            //objBEProctor.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID]);
                            objBEProctor.IntFlag = 0;
                            objBEProctor.strStatus = stat;
                            objBProctor.BProctorApproveExam(objBEProctor);
                            Response.Redirect("ProctorConfirmation.aspx?type=1&TransID=" + AppSecurity.Encrypt(objBEProctor.IntTransID.ToString()).ToString() + "&status=" + AppSecurity.Encrypt("Approve") + "", false);
                        }
                        else
                        {
                            Response.Redirect("ProctorConfirmation.aspx?type=1&TransID=" + AppSecurity.Encrypt(objBEProctor.IntTransID.ToString()).ToString() + "&status=" + AppSecurity.Encrypt(stat) + "", false);
                        }
                    }
                    else if (stat == "Approve")
                    {
                        //lblalert.Visible = true;
                        //lblalert.Text = "Exam is still in progress";
                        return;
                    }
                }
                else
                {
                    //lblInfo.Visible = true;
                }
                objBProctor = null;
                objBEProctor = null;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        protected void SetComments(string strComments)
        {
            BCommon objBCommon = new BCommon();
            BECommon objBECommon = new BECommon();
            objBECommon.IntTransID = Convert.ToInt64(AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()));
            objBECommon.IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID].ToString());
            objBECommon.StrComments = strComments;
            if (strComments == "Student identity-Matched")
                objBECommon.StrddlComments = "1";
            else
                objBECommon.StrddlComments = "3";

            objBCommon.BAddComments(objBECommon);
            objBECommon = null;
            objBCommon = null;
        }

        #endregion
        public string GetTransID()
        {
            //if (btnClsoeExam.Visible)
            return AppSecurity.Decrypt(Request.QueryString["TransID"].ToString());
            //else
            //    return "";
        }

        protected void btnSaveImage_Click(object sender, EventArgs e)
        {
            //if (Page.IsValid)
            //{
            try
            {
                BProctor objBProctor = new BProctor();
                BEProctor objBEProctor = new BEProctor();

                objBEProctor.IntTransID = Convert.ToInt64(GetTransID());
                if (chkcam.Checked == true)
                {
                    objBEProctor.boolcam = true;
                }
                else
                {
                    objBEProctor.boolcam = false;
                }

                if (chkaudio.Checked == true)
                {
                    objBEProctor.boolaudio = true;
                }
                else
                {
                    objBEProctor.boolaudio = false;
                }

                if (chkdesktop.Checked == true)
                {
                    objBEProctor.booldesktop = true;
                }
                else
                {
                    objBEProctor.booldesktop = false;
                }

                if (chkvalidid.Checked == true)
                {
                    objBEProctor.boolidvalid = true;
                }
                else
                {
                    objBEProctor.boolidvalid = false;
                }

                if (ddlOs.SelectedIndex != 0)
                {
                    objBEProctor.strOs = ddlOs.SelectedItem.Text;
                }
                else
                {
                    objBEProctor.strOs = "";
                }

                if (ddlBrowser.SelectedIndex != 0)
                {
                    objBEProctor.strBrowser = ddlBrowser.SelectedItem.Text;
                }
                else
                {
                    objBEProctor.strBrowser = "";
                }

                if (txtProctorComments.Text == "")
                {
                    objBEProctor.strProctorComments = "";
                }
                else
                {
                    objBEProctor.strProctorComments = txtProctorComments.Text;
                }

                if (ScreenshotFileUpload.UploadedFiles.Count > 0)
                {
                    //check image name and do not overwrite duplicates.
                    foreach (UploadedFile f in ScreenshotFileUpload.UploadedFiles)
                    {
                        string strOriginalFileName = f.FileName;
                        string strUploadFileName = CommonFunctions.generateUploadFileName(strOriginalFileName);
                        objBEProctor.strOriginalFileName = strOriginalFileName;
                        objBEProctor.strUploadPath = strUploadFileName;
                        f.SaveAs(Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["ProctorUploads"]) + '\\' + strUploadFileName, false);
                    }
                }
                else
                {
                    objBEProctor.strOriginalFileName = string.Empty;
                    objBEProctor.strUploadPath = string.Empty;
                }

                objBProctor.BUpdateScreenshotDetails(objBEProctor);

                if (objBEProctor.IntResult > 0)
                {
                    lblfileupload.Text = "Proctor review details uploaded successfully.";
                    lblfileupload.ForeColor = System.Drawing.Color.Green;
                    //lnlFile.Text = objBEProctor.strOriginalFileName;
                    GetUploadedFileDetails(Convert.ToInt64(GetTransID()));
                    //lnlFile.Visible = true;
                    //chkcam.Checked = false;
                    //chkaudio.Checked = false;
                    //chkdesktop.Checked = false;
                    //chkvalidid.Checked = false;
                    //ddlBrowser.SelectedIndex = 0;
                    //ddlOs.SelectedIndex = 0;
                    //txtProctorComments.Text = "";
                }
                //}
                //else
                //{
                //    lblfileupload.Text = "Please fill the above details and save.";
                //    lblfileupload.ForeColor = System.Drawing.Color.Red;
                //}               
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            //}
        }

        protected void GetUploadedFileDetails(Int64 TransactionID)
        {


            BProctor objBProctor = new BProctor();
            BEProctor objBEProctor = new BEProctor();

            objBEProctor.IntTransID = TransactionID;
            objBProctor.BGetProctorReviewDetails(objBEProctor);
            if (objBEProctor.DsResult != null)
            {
                if (objBEProctor.DsResult.Tables[0].Rows.Count > 0)
                {
                    if (objBEProctor.DsResult.Tables[0].Rows[0]["CamStatus"].ToString().ToLower() == "working")
                    {
                        chkcam.Checked = true;
                    }
                    else
                    {
                        chkcam.Checked = false;
                    }
                    if (objBEProctor.DsResult.Tables[0].Rows[0]["AudioStatus"].ToString().ToLower() == "working")
                    {
                        chkaudio.Checked = true;
                    }
                    else
                    {
                        chkaudio.Checked = false;
                    }
                    if (objBEProctor.DsResult.Tables[0].Rows[0]["DesktopStatus"].ToString().ToLower() == "working")
                    {
                        chkdesktop.Checked = true;
                    }
                    else
                    {
                        chkdesktop.Checked = false;
                    }
                    if (objBEProctor.DsResult.Tables[0].Rows[0]["IDStatus"].ToString().ToLower() == "valid")
                    {
                        chkvalidid.Checked = true;
                    }
                    else
                    {
                        chkvalidid.Checked = false;
                    }
                    if (objBEProctor.DsResult.Tables[0].Rows[0]["OS"] != DBNull.Value && objBEProctor.DsResult.Tables[0].Rows[0]["OS"].ToString() != string.Empty)
                    {
                        ddlOs.FindItemByText(objBEProctor.DsResult.Tables[0].Rows[0]["OS"].ToString()).Selected = true;
                    }
                    else
                    {
                        ddlOs.SelectedIndex = 0;
                    }
                    if (objBEProctor.DsResult.Tables[0].Rows[0]["Browser"] != DBNull.Value && objBEProctor.DsResult.Tables[0].Rows[0]["Browser"].ToString() != "")
                    {
                        ddlBrowser.FindItemByText(objBEProctor.DsResult.Tables[0].Rows[0]["Browser"].ToString()).Selected = true;
                    }
                    else
                    {
                        ddlBrowser.SelectedIndex = 0;
                    }
                    if (objBEProctor.DsResult.Tables[0].Rows[0]["ReviewComments"] != DBNull.Value)
                    {
                        txtProctorComments.Text = objBEProctor.DsResult.Tables[0].Rows[0]["ReviewComments"].ToString();
                    }
                    if (objBEProctor.DsResult.Tables[0].Rows[0]["OriginalProctorFileName"] != null && objBEProctor.DsResult.Tables[0].Rows[0]["OriginalProctorFileName"].ToString() != string.Empty)
                    {
                        lnlFile.Visible = true;
                        lnlFile.Text = objBEProctor.DsResult.Tables[0].Rows[0]["OriginalProctorFileName"].ToString();
                        imgCancel.Visible = true;
                    }
                    else
                    {
                        lnlFile.Visible = false;
                        imgCancel.Visible = false;
                    }
                }
            }
        }

        protected void lnlFile_Click(Object sender, EventArgs e)
        {
            BProctor objBProctor = new BProctor();
            BEProctor objBEProctor = new BEProctor();

            objBEProctor.IntTransID = Convert.ToInt64(GetTransID());
            objBProctor.BGetProctorReviewDetails(objBEProctor);

            if (objBEProctor.DsResult.Tables[0].Rows.Count > 0)
            {

                if (objBEProctor.DsResult.Tables[0].Rows[0]["OriginalProctorFileName"] != null && objBEProctor.DsResult.Tables[0].Rows[0]["OriginalProctorFileName"].ToString() != string.Empty)
                {

                    string UploadedFile = objBEProctor.DsResult.Tables[0].Rows[0]["StoredProctorFileName"].ToString();

                    string MapPath = System.Web.HttpContext.Current.Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["ProctorUploads"].ToString());

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
                        //lblFile.Text = "File doesnot exist";
                    }

                }
                else
                {
                    lnlFile.Visible = false;
                    imgCancel.Visible = false;
                    //lblFile.Visible = true;
                    //lblFile.Text = "N/A";
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

            BEProctor objBEProctor = new BEProctor();
            BProctor objBProctor = new BProctor();

            objBEProctor.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID]);

            objBEProctor.IntExamID1 = Convert.ToInt64(GetTransID());

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
                        //lblError.Visible = true;
                        //lblError.ForeColor = System.Drawing.Color.Red;
                        //lblError.Text = "File doesnot exist";
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

        protected void lnkCancel_Click(Object sender, EventArgs e)
        {


            this.DeleteProviderUploadedFile();

        }

        protected void DeleteProviderUploadedFile()
        {

            try
            {
                string strpath = Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["ProctorUploads"]);
                BEProctor objBEProctor = new BEProctor();
                BProctor objBProctor = new BProctor();
                objBEProctor.IntTransID = Convert.ToInt64(GetTransID());
                objBProctor.BGetProctorReviewDetails(objBEProctor);
                if (objBEProctor.DsResult != null)
                {
                    if (objBEProctor.DsResult.Tables[0].Rows.Count > 0)
                    {

                        objBEProctor.strUploadPath = objBEProctor.DsResult.Tables[0].Rows[0]["StoredProctorFileName"].ToString();

                        string strTotalPath = strpath + '\\' + objBEProctor.strUploadPath.ToString();
                        System.IO.FileInfo fi = new System.IO.FileInfo(strTotalPath);


                        fi.Delete();

                    }

                    else
                    {

                        //upFile.Visible = true;
                        lnlFile.Visible = false;
                        imgCancel.Visible = false;

                    }

                }

                objBProctor.BDeleteScreenshot(objBEProctor);
                if (objBEProctor.IntResult == 1)
                {
                    //lblFile.Visible = true;
                    // lblFile.Text = "N/A";
                    //upFile.Visible = true;
                    lnlFile.Visible = false;
                    imgCancel.Visible = false;

                }




            }

            catch (Exception e)
            {


            }

        }

        //protected void fileUploadComplete(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
        //{
        //    try
        //    {
        //        BProctor objBProctor = new BProctor();
        //        BEProctor objBEProctor = new BEProctor();

        //        if (ScreenshotFileUpload.UploadedFiles.Count > 0)
        //        {
        //            //check image name and do not overwrite duplicates.
        //            DateTime getTimeTicks = DateTime.Now;
        //            string timeTicks = getTimeTicks.Ticks.ToString();
        //            foreach (UploadedFile f in ScreenshotFileUpload.UploadedFiles)
        //            {
        //                f.SaveAs(System.Configuration.ConfigurationManager.AppSettings["ProctorUploads"] + f.GetNameWithoutExtension() + timeTicks + f.GetExtension(), false);
        //            }
        //            //recipe.RecipeImage = ScreenshotFileUpload.UploadedFiles[0].GetNameWithoutExtension() + timeTicks + ScreenshotFileUpload.UploadedFiles[0].GetExtension();
        //        }
        //        else
        //        {
        //            lblfileupload.Text = "Screenshot uploaded successfully";
        //        }

        //        //if (ScreenshotFileUpload.HasFile)
        //        //{
        //        //    string strpath = Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["ProctorUploads"]);
        //        //    string strOriginalFileName = ScreenshotFileUpload.FileName;
        //        //    string strUploadFileName = CommonFunctions.generateUploadFileName(ScreenshotFileUpload.FileName);
        //        //    string strTotalPath = strpath + '\\' + strUploadFileName;
        //        //    string pathex = Path.GetExtension(strTotalPath);
        //        //    objBEProctor.strOriginalFileName = strOriginalFileName;
        //        //    objBEProctor.strUploadPath = strUploadFileName;
        //        //    if (pathex.ToLower() == ".jpg" || pathex.ToLower() == ".jpeg" || pathex.ToLower() == ".gif" || pathex.ToLower() == ".png" || pathex.ToLower() == ".bmp" || pathex.ToLower() == ".pdf")
        //        //    {
        //        //        ScreenshotFileUpload.SaveAs(strTotalPath);
        //        //    }
        //        //    else
        //        //    {
        //        //        ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowFailure", "alert('" + Resources.ResMessages.Reg_Validuploadfiles + "')", true);
        //        //        return;
        //        //    }

        //        //    objBProctor.BUpdateScreenshotDetails(objBEProctor);

        //        //    if (objBEProctor.IntResult > 0)
        //        //    {
        //        //        //lblfileupload.Visible = true;
        //        //        lblfileupload.Text = "Screenshot uploaded successfully";
        //        //    }
        //        //}
        //    }
        //    catch (Exception Ex)
        //    {
        //        throw Ex;
        //    }
        //}

    }
}