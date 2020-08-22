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
using GOTOFrameWork;
using System.Data;


namespace SecureProctor.Proctor
{
    public partial class ProctorExamView : BaseClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RequiredFieldValidator11.Enabled = false;
            RequiredFieldValidator11.ValidationGroup = string.Empty;
            if (!IsPostBack)
            {
                this.Page.Title = EnumPageTitles.APPNAME + "Exam View";
                ((LinkButton)this.Page.Master.FindControl("lnkValidate")).CssClass = "main_menu_active";
                //this.BindAlerts();
                //lblfileupload.Visible = false;
                // lblError.Visible = false;
                //lblfileupload.Text = string.Empty;
                this.BindDropDowns();
                setExamDetails();
                this.BindStudentIdentity();
                this.GetStudentIdentityStatus();
                this.setExamFiles();




                //this.bindGOTOMeetingLink();
                //this.GetUploadedFileDetails(Convert.ToInt32(AppSecurity.Decrypt(Request.QueryString["TransID"].ToString())));
            }
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            //scriptManager.RegisterPostBackControl(this.lnlFile);
            scriptManager.RegisterPostBackControl(this.gvUploadFiles);
            lblInfo.Text = string.Empty;
            if (ddlAlerts.Items.Count > 0)
            {
                //txtComments.Visible = true;
                if (ddlAlerts.SelectedItem.Text.ToUpper() == "OTHER")
                {
                    // txtComments.Visible = true;
                    RequiredFieldValidator11.Visible = true;
                    // RequiredFieldValidator11.ValidationGroup = string.Empty;
                }
                else
                {
                    //txtComments.Visible = false;
                    RequiredFieldValidator11.Visible = false;
                }
            }
            else
            {
                txtComments.Visible = false;
                //RequiredFieldValidator11.Visible = false;


            }
        }


        /// <summary>
        /// BindStudentIdentity
        /// </summary>

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
                    // lblDAte.Text = objBECommon.DsResult.Tables[0].Rows[0]["ExamDate"].ToString();
                    //lblSlot.Text = objBECommon.DsResult.Tables[0].Rows[0]["TimeDuration"].ToString();
                    // lblSlot.Text = objBECommon.DsResult.Tables[0].Rows[0]["ExamStartDate"].ToString();
                    lblSlot.Text = objBECommon.DsResult.Tables[0].Rows[0]["ExamStartDate"].ToString() + " " + objBECommon.DsResult.Tables[0].Rows[0]["TimeDuration"].ToString();
                    lblStudentName.Text = objBECommon.DsResult.Tables[0].Rows[0]["Name"].ToString();
                    lblStudentEmail.Text = objBECommon.DsResult.Tables[0].Rows[0]["EmailAddress"].ToString();
                    lblCourseName.Text = objBECommon.DsResult.Tables[0].Rows[0]["CourseName"].ToString();
                    lblExamName.Text = objBECommon.DsResult.Tables[0].Rows[0]["ExamName"].ToString();

                    //lblPhoneNumber.Text = "+" + "(" + CommonFunctions.CheckNullValue(objBECommon.DtResult.Rows[0]["CountryCode"].ToString()) + ")";
                    // lblPhoneNumber.Text = "+" + "(" + CommonFunctions.CheckNullValue(objBECommon.DsResult.Tables[0].Rows[0]["CountryCode"].ToString()) + ")" + " - " + CommonFunctions.CheckNullValue(objBECommon.DsResult.Tables[0].Rows[0]["PhoneNumber"].ToString());
                    lblPhoneNumber.Text = CommonFunctions.CheckNullValue(objBECommon.DsResult.Tables[0].Rows[0]["PhoneNumber"].ToString());
                    //  lblPhoneNumber.Text = CommonFunctions.CheckNullValue(objBECommon.DsResult.Tables[0].Rows[0]["PhoneNumber"].ToString());
                    // lblTimeZone.Text = objBECommon.DsResult.Tables[0].Rows[0]["TimeZone"].ToString();
                    lblSpecialNeeds.Text = objBECommon.DsResult.Tables[0].Rows[0]["SpecialNeeds"].ToString();
                    lblexamiLOCK.Text = objBECommon.DsResult.Tables[0].Rows[0]["LockDownBrowser"].ToString() == "True" ? "Yes" : "No";
                    if (lblSpecialNeeds.Text == "Yes")
                    {
                        lblSpecialNeeds.Attributes.Add("style", "background-color:#FFA500; padding:5px 15px; width:25px; display:inline-block");
                    }
                    else
                    {
                        lblSpecialNeeds.Attributes.Add("style", "background-color:#d5d5d5; padding:5px 15px; width:25px; display:inline-block");
                    }
                    if (lblexamiLOCK.Text == "Yes")
                    {
                        ExamiLockLink.Visible = true;
                        lblexamiLOCK.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffa600");

                    }
                    else
                    {
                        ExamiLockLink.Visible = false;
                        lblexamiLOCK.Attributes.Add("style", "background-color:#c5c5c5");
                    }
                    lblExamLink.Text = objBECommon.DsResult.Tables[0].Rows[0]["ExamLink"].ToString();
                    if (objBECommon.DsResult.Tables[0].Rows[0]["Comments"] != DBNull.Value && objBECommon.DsResult.Tables[0].Rows[0]["Comments"].ToString() != string.Empty)
                    {
                        lblComments.Text = objBECommon.DsResult.Tables[0].Rows[0]["Comments"].ToString();
                        tdcoments.Attributes.Add("style", "height:50px;background-color:#fef65b; overflow:auto;");

                    }
                    else
                    {
                        lblComments.Text = "N/A";
                        tdcoments.Attributes.Add("style", "height:50px;background-color:#c5c5c5");
                    }
                    lblMaxAttempts.Text = objBECommon.DsResult.Tables[0].Rows[0]["AllowedAttempts"].ToString();
                    // lblUsedAttempts.Text = objBECommon.DsResult.Tables[0].Rows[0]["UsedAttempts"].ToString();

                    if (Convert.ToBoolean(objBECommon.DsResult.Tables[0].Rows[0]["ExamiKey"]) == true)
                    {
                        lblKeyScore.Text = objBECommon.DsResult.Tables[0].Rows[0]["Examikeyscore"].ToString() + "%";
                        trScore.Visible = true;
                        tdOverrideKEY.Visible = true;
                    }
                    else
                    {
                        trScore.Visible = false;
                        tdOverrideKEY.Visible = false;
                    }
                    lblDuration.Text = objBECommon.DsResult.Tables[0].Rows[0]["ExamDuration"].ToString();
                    //lblEndTime.Text = objBECommon.DsResult.Tables[0].Rows[0]["EndTime"].ToString();
                    // lblEndTime.Text = objBECommon.DsResult.Tables[0].Rows[0]["ExamEndDate"].ToString();
                    lblEndTime.Text = objBECommon.DsResult.Tables[0].Rows[0]["ExamEndDate"].ToString() + " " + objBECommon.DsResult.Tables[0].Rows[0]["EndTime"].ToString();
                    lblExamUserName.Text = objBECommon.DsResult.Tables[0].Rows[0]["ExamUserName"].ToString();
                    lblExamPassword.Text = objBECommon.DsResult.Tables[0].Rows[0]["ExamPassword"].ToString();

                    //if (objBECommon.DsResult.Tables[0].Rows[0]["OriginalFileName"] != null && objBECommon.DsResult.Tables[0].Rows[0]["OriginalFileName"].ToString() != "")
                    //{
                    //    lnkProviderFile.Visible = true;
                    //    lnkProviderFile.Text = objBECommon.DsResult.Tables[0].Rows[0]["OriginalFileName"].ToString();

                    //}
                    //else
                    //{
                    //    lnkProviderFile.Visible = false;
                    //    lblError.Visible = true;
                    //    lblError.Text = "N/A";
                    //}
                }
            }



            if (objBECommon.DsResult.Tables[4].Rows.Count > 0)
            {
                lblExamProviderName.Text = objBECommon.DsResult.Tables[4].Rows[0]["ExamProviderName"].ToString();
                lblExamProviderEmailAddress.Text = objBECommon.DsResult.Tables[4].Rows[0]["EmailAddress"].ToString();
                lblProctorName.Text = objBECommon.DsResult.Tables[4].Rows[0]["ProctorName"].ToString();

            }

            if (objBECommon.DsResult.Tables[5].Rows.Count > 0)
            {
                lblExamLevel.Text = objBECommon.DsResult.Tables[5].Rows[0]["Level"].ToString();
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
                if (Request.QueryString["TransID"] != null)
                {

                    BCommon objBCommon = new BCommon();
                    BECommon objBECommon = new BECommon();
                    objBECommon.IntTransID = Convert.ToInt64(AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()));
                    objBECommon.IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID]);
                    objBCommon.BGetTransactionComments(objBECommon);
                    gvComments.DataSource = objBECommon.DtResult;
                    ViewState["ALERTS"] = objBECommon.DtResult;

                }
            }
            catch (Exception Ex)
            {
                // ErrorLog.WriteError(Ex);
            }
        }
        #endregion

        #region AddComments
        protected void BindAlerts()
        {
            try
            {
                //txtComments.Visible = false;
                //RequiredFieldValidator11.Enabled = false;
                //RequiredFieldValidator11.ValidationGroup = string.Empty;
                BECommon objBEComon = new BECommon();
                BCommon objBCommon = new BCommon();
                objBEComon.intRoleID = Convert.ToInt32(Session["RoleID"].ToString());
                objBEComon.intAlertID = 4;
                objBCommon.BGetAlerts(objBEComon);
                //ddlAlerts.AppendDataBoundItems = true;
                //Telerik.Web.UI.RadComboBoxItem item = new Telerik.Web.UI.RadComboBoxItem("--Please select--", "0");
                //ddlAlerts.Items.Add(item);
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
                    //objBECommon.StrddlComments = getSelectFlag().ToString();
                    objBECommon.StrddlComments = ddlFlags.SelectedValue.ToString();
                    objBECommon.intAlertID = Convert.ToInt32(ddlAlerts.SelectedValue.ToString());
                    string TimeChoosed = string.Empty;
                    if (ddlHours.SelectedIndex != 0 && ddlHours.SelectedIndex != 1)
                    {
                        TimeChoosed = ddlHours.SelectedValue.ToString();

                        if (ddlMinutes.SelectedIndex != 0)
                            TimeChoosed = TimeChoosed + ":" + ddlMinutes.SelectedValue.ToString();
                        else
                            TimeChoosed = TimeChoosed + ":00";

                        if (ddlsec.SelectedIndex != 0)
                            TimeChoosed = TimeChoosed + ":" + ddlsec.SelectedValue.ToString();
                        else
                            TimeChoosed = TimeChoosed + ":00";

                    }
                    else if (ddlMinutes.SelectedIndex != 0 && ddlMinutes.SelectedIndex != 1)
                    {
                        TimeChoosed = ddlMinutes.SelectedValue.ToString();
                        if (ddlsec.SelectedIndex != 0)
                            TimeChoosed = TimeChoosed + ":" + ddlsec.SelectedValue.ToString();
                        else
                            TimeChoosed = TimeChoosed + ":00";


                    }
                    else if (ddlsec.SelectedIndex != 0 && ddlsec.SelectedIndex != 1)
                    {
                        TimeChoosed = ddlsec.SelectedValue.ToString();

                    }
                    else
                    {
                        TimeChoosed = string.Empty;
                    }

                    //if (ddlHours.SelectedIndex != 0 || ddlMinutes.SelectedIndex != 0 || ddlsec.SelectedIndex != 0)
                    //{
                    //    string TimeChoosed = string.Empty;

                    //    if (ddlHours.SelectedIndex != 0 && ddlHours.SelectedIndex != 1)
                    //    {
                    //        TimeChoosed = ddlHours.SelectedValue.ToString();

                    //    }

                    //    if (ddlHours.SelectedIndex != 0 && ddlMinutes.SelectedIndex != 0 && ddlsec.SelectedIndex != 0 && ddlHours.SelectedIndex != 1)
                    //    {

                    //        TimeChoosed = TimeChoosed + ":" + ddlMinutes.SelectedValue.ToString() + ":" + ddlsec.SelectedValue.ToString();
                    //    }



                    //    else if (ddlHours.SelectedIndex != 0 && ddlMinutes.SelectedIndex != 0 && ddlHours.SelectedIndex != 1)
                    //    {

                    //        TimeChoosed = ddlHours.SelectedValue.ToString() + ":" + ddlMinutes.SelectedValue.ToString();

                    //    }


                    //    else
                    //    {

                    //        if (ddlMinutes.SelectedIndex != 0)
                    //        {

                    //            TimeChoosed = ddlMinutes.SelectedValue.ToString();
                    //        }

                    //        if (ddlsec.SelectedIndex != 0)
                    //        {

                    //            TimeChoosed = ddlsec.SelectedValue.ToString();

                    //        }

                    //        if (ddlMinutes.SelectedIndex != 0 && ddlsec.SelectedIndex != 0)
                    //        {
                    //            TimeChoosed = ddlMinutes.SelectedValue.ToString() + ":" + ddlsec.SelectedValue.ToString();

                    //        }

                    //    }

                    //string TimeChoosed = string.Empty;
                    //if (ddlHours.SelectedIndex != 0 && ddlHours.SelectedIndex != 1)
                    //    TimeChoosed = ddlHours.SelectedValue.ToString() + ":";
                    //else
                    //    TimeChoosed =  "00" + ":";
                    //if (ddlMinutes.SelectedIndex != 0)
                    //    TimeChoosed = TimeChoosed + ddlMinutes.SelectedValue.ToString() + ":";
                    //else
                    //    TimeChoosed = TimeChoosed + "00" + ":";
                    //if (ddlsec.SelectedIndex != 0)
                    //    TimeChoosed = TimeChoosed + ddlsec.SelectedValue.ToString();
                    //else
                    //    TimeChoosed = TimeChoosed + "00";
                    //    objBECommon.strTime = TimeChoosed;
                    //}
                    //else
                    //    objBECommon.strTime = string.Empty;
                    objBECommon.strTime = TimeChoosed;
                    objBCommon.BAddComments(objBECommon);

                    objBECommon = null;
                    objBCommon = null;
                    txtComments.Text = string.Empty;
                    gvComments.Rebind();
                    ddlFlags.SelectedValue = "-1";
                    ddlHours.SelectedIndex = 0;
                    ddlMinutes.SelectedIndex = 0;
                    ddlsec.SelectedIndex = 0;
                    txtComments.Text = string.Empty;
                    ddlAlerts.Items.Clear();
                    //Telerik.Web.UI.RadComboBoxItem item = new Telerik.Web.UI.RadComboBoxItem("--Please select Description--", "0");
                    //ddlAlerts.Items.Add(item);
                    RequiredFieldValidator11.Enabled = false;
                    RequiredFieldValidator11.ValidationGroup = string.Empty;

                }


                catch (Exception Ex)
                {
                    txtComments.Text = string.Empty;
                    throw Ex;
                }
            }

        }
        /*
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
        */
        protected void ddlAlerts_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (ddlAlerts.SelectedItem.Text.ToString().ToUpper() == "OTHER")
            {
               // txtComments.Text = string.Empty;
                // txtComments.Visible = true;
                RequiredFieldValidator11.Enabled = true;
                RequiredFieldValidator11.ValidationGroup = "Add";
            }
            else
            {
                // txtComments.Visible = false;
                //txtComments.Text = string.Empty;
                RequiredFieldValidator11.Enabled = false;
                RequiredFieldValidator11.ValidationGroup = string.Empty;
            }
        }

        protected void ddlFlags_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            ddlAlerts.Items.Clear();
            if (!string.IsNullOrEmpty(ddlFlags.SelectedValue.ToString()))
            {
                BECommon objBEComon = new BECommon();
                BCommon objBCommon = new BCommon();
                objBEComon.intRoleID = Convert.ToInt32(Session["RoleID"].ToString());
                objBEComon.intAlertID = Convert.ToInt32(ddlFlags.SelectedValue.ToString());
                objBCommon.BGetAlerts(objBEComon);
                ddlAlerts.DataSource = objBEComon.DtResult;
                ddlAlerts.DataValueField = "AlertID";
                ddlAlerts.DataTextField = "AlertText";
                ddlAlerts.DataBind();
                txtComments.Visible = true;
                txtComments.Text = string.Empty;
                if (ddlAlerts.SelectedItem.Text.ToString().ToUpper() == "OTHER")
                {
                    txtComments.Text = string.Empty;
                    // txtComments.Visible = true;
                    RequiredFieldValidator11.Enabled = true;
                    RequiredFieldValidator11.ValidationGroup = "Add";
                }
                else
                {
                    // txtComments.Visible = false;
                    txtComments.Text = string.Empty;
                    RequiredFieldValidator11.Enabled = false;
                    RequiredFieldValidator11.ValidationGroup = string.Empty;
                }
            }
            else
            {
                txtComments.Text = string.Empty;
                txtComments.Visible = false;
                ddlAlerts.Items.Clear();
            }
            //if (ddlFlags.SelectedIndex == 0)
            //{
            //    txtComments.Visible = false;
            //}
        }

        /*
        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtComments.Text = string.Empty;
        }*/

        #endregion

        #region BtnapproveTransaction
        //protected void btnSubmit_Click(object sender, EventArgs e)
        //{
        //    try
        //    {

        //        BProctor objBProctor = new BProctor();
        //        BEProctor objBEProctor = new BEProctor();
        //        objBEProctor.IntTransID = Convert.ToInt32(AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()));
        //        objBEProctor.IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID].ToString());
        //        objBProctor.BGetExamTransactionStatus(objBEProctor);
        //        string stat = "";
        //        if (rdApprove.SelectedIndex == 0)
        //        {
        //            stat = "Approve";
        //        }
        //        else if (rdApprove.SelectedIndex == 1)
        //        {
        //            stat = "Close";
        //        }
        //        else if (h.SelectedIndex == 2)
        //        {
        //            stat = "Incomplete";
        //        }

        //        if (objBEProctor.DtResult.Rows[0][0].ToString() == "3")
        //        {
        //            if (stat != "" && stat == "Approve")
        //            {
        //                Response.Redirect("ProctorConfirmation.aspx?type=1&TransID=" + AppSecurity.Encrypt(objBEProctor.IntTransID.ToString()).ToString() + "&status=" + AppSecurity.Encrypt(stat) + "", false);
        //            }
        //            else
        //            {
        //                //lblalert.Visible = true;
        //                //lblalert.Text = "Exam has been already completed, please approve for auditor action";
        //                return;
        //            }
        //        }
        //        else if (objBEProctor.DtResult.Rows[0][0].ToString() == "2")
        //        {
        //            if (stat != "" && stat != "Approve")
        //            {
        //                if (stat == "Close")
        //                {
        //                    //BEProctor objBEProctor = new BEProctor();
        //                    //BProctor objBProctor = new BProctor();
        //                    //objBEProctor.IntTransID = Convert.ToInt32(AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()));
        //                    //objBEProctor.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID]);
        //                    objBEProctor.IntFlag = 0;
        //                    objBEProctor.strStatus = stat;
        //                    objBProctor.BProctorApproveExam(objBEProctor);
        //                    Response.Redirect("ProctorConfirmation.aspx?type=1&TransID=" + AppSecurity.Encrypt(objBEProctor.IntTransID.ToString()).ToString() + "&status=" + AppSecurity.Encrypt("Approve") + "", false);
        //                }
        //                else
        //                {
        //                    Response.Redirect("ProctorConfirmation.aspx?type=1&TransID=" + AppSecurity.Encrypt(objBEProctor.IntTransID.ToString()).ToString() + "&status=" + AppSecurity.Encrypt(stat) + "", false);
        //                }
        //            }
        //            else if (stat == "Approve")
        //            {
        //                //lblalert.Visible = true;
        //                //lblalert.Text = "Exam is still in progress";
        //                return;
        //            }
        //        }
        //        else
        //        {
        //            //lblInfo.Visible = true;
        //        }
        //        objBProctor = null;
        //        objBEProctor = null;
        //    }
        //    catch (Exception Ex)
        //    {
        //        throw Ex;
        //    }
        //}
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
                        //lnlFile.Visible = false;
                        //imgCancel.Visible = false;

                    }

                }

                objBProctor.BDeleteScreenshot(objBEProctor);
                if (objBEProctor.IntResult == 1)
                {
                    //lblFile.Visible = true;
                    // lblFile.Text = "N/A";
                    //upFile.Visible = true;
                    //lnlFile.Visible = false;
                    //imgCancel.Visible = false;

                }




            }

            catch (Exception e)
            {


            }

        }

        protected void lnkExamID_Click(object sender, EventArgs e)
        {
            try
            {
                BEProctor objBEProctor = new BEProctor();
                BProctor objBProctor = new BProctor();
                objBEProctor.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID].ToString());
                objBEProctor.IntTransID = Convert.ToInt64(AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()));
                objBProctor.BGetMeetingCredentials(objBEProctor);
                if (objBEProctor.strExamSessionID == String.Empty)
                {
                    // Create new Exam request.
                    G2M_Token objG2M_Token = new G2M_Token();
                    G2M_Properties objG2M_Properties = new G2M_Properties();
                    G2MAuthentication objG2MAuthentication = new G2MAuthentication();
                    objG2M_Properties.strUserName = objBEProctor.strMeetingUserName;
                    objG2M_Properties.strPassword = objBEProctor.strMeetingPassword;
                    objG2M_Properties.strMeetingSubject = System.Configuration.ConfigurationManager.AppSettings["GOTOMeetingExamSubject"].ToString() + AppSecurity.Decrypt(Request.QueryString["TransID"].ToString());
                    int intMinutes = 0;
                    string[] str = objBEProctor.strExamDuration.Split('.');
                    intMinutes = Convert.ToInt32(str[0].ToString()) * 60 + Convert.ToInt32(str[1].ToString()) + objBEProctor.intExamBufferTime + Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["GOTOMeetingProctorBufferTime"]);
                    objG2M_Properties.intMeetingMinutes = intMinutes;
                    objG2M_Token = objG2MAuthentication.GetAuthenticationToken(objG2M_Properties);
                    objG2MAuthentication = null;
                    if (objG2M_Token != null)
                    {
                        G2M_CreatedMeetingDetails objG2M_CreatedMeetingDetails = new G2M_CreatedMeetingDetails();
                        G2MMeetings objG2MMeetings = new G2MMeetings();
                        objG2M_CreatedMeetingDetails = objG2MMeetings.CreateMeeting(objG2M_Properties, objG2M_Token);
                        this.SetExamSessionID(objG2M_CreatedMeetingDetails.meetingid, objG2M_Token.access_token);
                        objG2M_Properties.strMeetingID = objG2M_CreatedMeetingDetails.meetingid;
                        G2M_StartMeeting objG2M_StartMeeting = new G2M_StartMeeting();
                        objG2M_StartMeeting = objG2MMeetings.StartMeeting(objG2M_Properties, objG2M_Token);
                        ScriptManager.RegisterStartupScript(this, Page.GetType(), "newWindow", "window.open('" + objG2M_StartMeeting.hostURL + "','_blank','width=200,height=100');", true);

                        objG2M_CreatedMeetingDetails = null;
                        objG2MMeetings = null;
                        objG2M_StartMeeting = null;
                    }
                    else
                    {
                        lblInfo.Text = "Invalid Meeting Credentials.Please try again.";

                        // lblInfo.Text =  Resources.ResMessages.Invalid_ClickHere;
                    }
                    objG2M_Token = null;
                    objG2M_Properties = null;
                }
                else
                {
                    // Exam is already scheduled.
                    G2M_Token objG2M_Token = new G2M_Token();
                    G2M_Properties objG2M_Properties = new G2M_Properties();
                    G2MMeetings objG2MMeetings = new G2MMeetings();
                    G2M_StartMeeting objG2M_StartMeeting = new G2M_StartMeeting();
                    objG2M_Properties.strMeetingID = objBEProctor.strExamSessionID;
                    objG2M_Token.access_token = objBEProctor.strMeetingToken;
                    objG2M_StartMeeting = objG2MMeetings.StartMeeting(objG2M_Properties, objG2M_Token);
                    ScriptManager.RegisterStartupScript(this, Page.GetType(), "newWindow", "window.open('" + objG2M_StartMeeting.hostURL + "','_blank','width=200,height=100');", true);
                    objG2M_Properties = null;
                    objG2M_Token = null;
                    objG2MMeetings = null;
                    objG2M_StartMeeting = null;
                }
            }
            catch
            {
                lblInfo.Text = "Error while creating the meeting request";
            }
        }


        protected void lnkProceed_Click(object sender, EventArgs e)
        {
            BEProctor objBEProctor = new BEProctor();
            BProctor objBProctor = new BProctor();
            objBEProctor.IntTransID = Convert.ToInt64(AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()));
            objBProctor.BUpdateEnableProceedButtonTime(objBEProctor);

            if (lnkProceed.Text == "Disable Proceed Button")
            {
                this.SetFlags("PROCEED", 0);
                lnkProceed.Text = "Enable Proceed Button";
            }
            else
            {
                this.SetFlags("PROCEED", 1);
                lnkProceed.Text = "Disable Proceed Button";
            }

        }

        protected void lnkStudentIDCheck_Click(object sender, EventArgs e)
        {
            this.GetStudentIdentityStatus();

        }

        protected void GetStudentIdentityStatus()
        {
            BEProctor objBEProctor = new BEProctor();
            BProctor objBProctor = new BProctor();
            objBEProctor.IntTransID = Convert.ToInt64(AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()));
            objBProctor.BStudentIdentityVerification(objBEProctor);

            if (objBEProctor.IntstatusFlag == 1)
            {
                // lnkStudentIDCheck.Text = "Student Identity Verified";
                lnkStudentIDCheck.Style.Add("display", "none");
                lblStudentCheck.Style.Add("display", "inline");
            }
            else
            {
                // lnkStudentIDCheck.Text = "Student Identity Verification";
                lnkStudentIDCheck.Style.Add("display", "inline");
                lblStudentCheck.Style.Add("display", "none");
            }
        }

        protected void lnkSurvey_Click(object sender, EventArgs e)
        {
            BECommon objBECommon = new BECommon();
            objBECommon.IntTransID = Convert.ToInt64(AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()));
            objBECommon.intTypeID = 21;
            BCommon objBCommon = new BCommon();
            objBCommon.BUpdateFlowTimeStamp(objBECommon);

            if (lnkSurvey.Text == "Enable Survey Link")
            {
                this.SetFlags("STARTEXAM", 0);
                lnkSurvey.Text = "Disable Survey Link";
                lnkStartExam.Text = "Enable Begin Exam Button";
            }
            else
            {
                this.SetFlags("STARTEXAM", 1);
                lnkSurvey.Text = "Enable Survey Link";
                lnkStartExam.Text = "Disable Begin Exam Button";
            }
        }


        protected void lnkStartExam_Click(object sender, EventArgs e)
        {
            BECommon objBECommon = new BECommon();
            objBECommon.IntTransID = Convert.ToInt64(AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()));
            objBECommon.intTypeID = 20;
            BCommon objBCommon = new BCommon();
            objBCommon.BUpdateFlowTimeStamp(objBECommon);
            if (lnkStartExam.Text == "Disable Begin Exam Button")
            {
                this.SetFlags("STARTEXAM", 0);
                lnkStartExam.Text = "Enable Begin Exam Button";
                lnkSurvey.Text = "Disable Survey Link";
            }
            else
            {
                this.SetFlags("STARTEXAM", 1);
                lnkStartExam.Text = "Disable Begin Exam Button";
                lnkSurvey.Text = "Enable Survey Link";

            }
        }

        protected void SetFlags(string strType, int intValue)
        {
            BEProctor objBEProctor = new BEProctor();
            BProctor objBProctor = new BProctor();
            objBEProctor.IntTransID = Convert.ToInt64(AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()));
            objBEProctor.strStatus = strType;
            objBEProctor.IntResult = intValue;
            objBProctor.BSetTransactionFlags(objBEProctor);
        }

        protected void SetExamSessionID(string strExamSessionID, string strAccessToken)
        {
            try
            {
                BEProctor objBEProctor = new BEProctor();
                BProctor objBProctor = new BProctor();
                objBEProctor.strExamSessionID = strExamSessionID;
                objBEProctor.IntTransID = Convert.ToInt64(AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()));
                objBEProctor.strMeetingToken = strAccessToken;
                objBProctor.BSetExamSessionID(objBEProctor);
                objBEProctor = null;
                objBProctor = null;
            }
            catch
            {
            }
        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
        }

        protected void gvComments_EditCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {

            if (e.CommandName == "EDIT")
            {
                DataTable objDT = (DataTable)ViewState["ALERTS"];
                gvComments.DataSource = objDT;
                gvComments.DataBind();
            }

        }

        protected void gvComments_DeleteCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            DataTable objDT = (DataTable)ViewState["ALERTS"];
            if (e.CommandName == "DELETE")
            {
                for (int i = 0; i < objDT.Rows.Count; i++)
                {
                    if (e.CommandArgument.ToString() == objDT.Rows[i][0].ToString())
                    {
                        objDT.Rows.RemoveAt(i);
                        objDT.AcceptChanges();
                        BECommon objBECommon = new BECommon();
                        BCommon objBCommon = new BCommon();
                        objBECommon.IntTransID = Convert.ToInt64(AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()));
                        objBECommon.intTypeID = 0;
                        objBECommon.intCommentID = Convert.ToInt32(e.CommandArgument);
                        objBECommon.StrComments = string.Empty;
                        objBCommon.BDeleteUpdateAlerts(objBECommon);


                    }
                    ViewState["ALERTS"] = objDT;
                    gvComments.DataSource = objDT;
                    gvComments.DataBind();
                }


            }
        }



        protected void gvComments_UpdateCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName.ToString().ToUpper() == "UPDATE")
            {
                Telerik.Web.UI.RadTextBox txt = (Telerik.Web.UI.RadTextBox)e.Item.FindControl("txtRuleDescription");
                DataTable objDT = (DataTable)ViewState["ALERTS"];

                BECommon objBECommon = new BECommon();
                BCommon objBCommon = new BCommon();
                objBECommon.IntTransID = Convert.ToInt64(AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()));
                objBECommon.intTypeID = 1;
                objBECommon.intCommentID = Convert.ToInt32(e.CommandArgument);
                objBECommon.StrComments = txt.Text.Trim();
                objBCommon.BDeleteUpdateAlerts(objBECommon);
                ViewState["ALERTS"] = objDT;
                gvComments.DataSource = objDT;
                gvComments.DataBind();
                BindTransactionsComments();
            }
        }

        protected void gvComments_CancelCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName.ToString().ToUpper() == "CANCEL")
            {
                DataTable objDT = (DataTable)ViewState["ALERTS"];
                gvComments.DataSource = objDT;
                gvComments.DataBind();
            }

        }

        protected void tbcExistingExamDetails_ActiveTabChanged(object sender, EventArgs e)
        {
            gvComments.Rebind();


        }

        protected void lnkResetExamSessionLink_Click(object sender, EventArgs e)
        {
            BEProctor objBEProctor = new BEProctor();
            BProctor objBProctor = new BProctor();
            objBEProctor.IntTransID = Convert.ToInt64(AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()));

            objBProctor.BresetExamSession(objBEProctor);
            this.ResetExamSession();
            lnkStudentIDCheck.Visible = true;
            lblStudentCheck.Visible = false;


        }

        protected void ResetExamSession()
        {
            try
            {
                BEProctor objBEProctor = new BEProctor();
                BProctor objBProctor = new BProctor();
                objBEProctor.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID].ToString());
                objBEProctor.IntTransID = Convert.ToInt64(AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()));
                objBProctor.BGetMeetingCredentials(objBEProctor);
                // Create new Exam request.
                G2M_Token objG2M_Token = new G2M_Token();
                G2M_Properties objG2M_Properties = new G2M_Properties();
                G2MAuthentication objG2MAuthentication = new G2MAuthentication();
                objG2M_Properties.strUserName = objBEProctor.strMeetingUserName;
                objG2M_Properties.strPassword = objBEProctor.strMeetingPassword;
                objG2M_Properties.strMeetingSubject = System.Configuration.ConfigurationManager.AppSettings["GOTOMeetingExamSubject"].ToString() + AppSecurity.Decrypt(Request.QueryString["TransID"].ToString());
                int intMinutes = 0;
                string[] str = objBEProctor.strExamDuration.Split('.');
                intMinutes = Convert.ToInt32(str[0].ToString()) * 60 + Convert.ToInt32(str[1].ToString()) + objBEProctor.intExamBufferTime + Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["GOTOMeetingProctorBufferTime"]);
                objG2M_Properties.intMeetingMinutes = intMinutes;
                objG2M_Token = objG2MAuthentication.GetAuthenticationToken(objG2M_Properties);
                objG2MAuthentication = null;
                if (objG2M_Token != null)
                {
                    G2M_CreatedMeetingDetails objG2M_CreatedMeetingDetails = new G2M_CreatedMeetingDetails();
                    G2MMeetings objG2MMeetings = new G2MMeetings();
                    objG2M_CreatedMeetingDetails = objG2MMeetings.CreateMeeting(objG2M_Properties, objG2M_Token);
                    this.SetExamSessionID(objG2M_CreatedMeetingDetails.meetingid, objG2M_Token.access_token);
                    objG2M_Properties.strMeetingID = objG2M_CreatedMeetingDetails.meetingid;
                    G2M_StartMeeting objG2M_StartMeeting = new G2M_StartMeeting();
                    objG2M_StartMeeting = objG2MMeetings.StartMeeting(objG2M_Properties, objG2M_Token);
                    ScriptManager.RegisterStartupScript(this, Page.GetType(), "newWindow", "window.open('" + objG2M_StartMeeting.hostURL + "','_blank','width=200,height=100');", true);
                    objG2M_CreatedMeetingDetails = null;
                    objG2MMeetings = null;
                    objG2M_StartMeeting = null;
                }
                else
                {
                    lblInfo.Text = "Invalid Meeting Credentials.  Please try again.";
                }
                objG2M_Token = null;
                objG2M_Properties = null;

            }
            catch (Exception ex)
            {

            }


        }
        public string isAllowAttemptsFeatured()
        {
            BECommon objBECommon = new BECommon();
            BCommon objBCommon = new BCommon();

            objBCommon.BGetClientDetails(objBECommon);

            return objBECommon.DsResult.Tables[0].Rows[0]["MaxAttemptsFeatured"].ToString();
        }


        protected void BindDropDowns()
        {
            DataTable dtHrs = GetHrsTable();
            DataTable dtMin = GetMinTable();
            DataTable dtSec = GetSecTable();
            ddlHours.DataSource = dtHrs;
            ddlHours.DataTextField = "Hrs";
            ddlHours.DataValueField = "Hrs";
            ddlHours.DataBind();
            ddlMinutes.DataSource = dtMin;
            ddlMinutes.DataTextField = "Min";
            ddlMinutes.DataValueField = "Min";
            ddlMinutes.DataBind();
            ddlsec.DataSource = dtSec;
            ddlsec.DataTextField = "Sec";
            ddlsec.DataValueField = "Sec";
            ddlsec.DataBind();



        }

        public static DataTable GetHrsTable()
        {
            DataTable dtHrs = new DataTable();
            DataRow dr;
            dtHrs.Columns.Add("Hrs", typeof(string));
            //
            dr = dtHrs.NewRow();
            dr["Hrs"] = "Hours";
            dtHrs.Rows.Add(dr);
            dr = dtHrs.NewRow();
            dr["Hrs"] = "0";
            dtHrs.Rows.Add(dr);
            //
            for (int i = 1; i <= 23; i++)
            {
                dr = dtHrs.NewRow();
                dr["Hrs"] = i.ToString("D1");
                dtHrs.Rows.Add(dr);
            }
            dtHrs.AcceptChanges();
            return dtHrs;
        }
        public static DataTable GetMinTable()
        {
            DataTable dtMin = new DataTable();
            DataRow dr;
            dtMin.Columns.Add("Min", typeof(string));
            //
            dr = dtMin.NewRow();
            dr["Min"] = "Minutes";
            dtMin.Rows.Add(dr);

            dr = dtMin.NewRow();
            dr["Min"] = "00";
            dtMin.Rows.Add(dr);
            //
            for (int i = 1; i <= 59; i = i + 1)
            {
                dr = dtMin.NewRow();
                dr["Min"] = i.ToString("D2");
                dtMin.Rows.Add(dr);
            }
            dtMin.AcceptChanges();
            return dtMin;
        }

        public static DataTable GetSecTable()
        {
            DataTable dtSec = new DataTable();
            DataRow dr;
            dtSec.Columns.Add("Sec", typeof(string));
            //
            dr = dtSec.NewRow();
            dr["Sec"] = "Seconds";
            dtSec.Rows.Add(dr);

            dr = dtSec.NewRow();
            dr["Sec"] = "00";
            dtSec.Rows.Add(dr);
            //
            for (int i = 1; i <= 59; i = i + 1)
            {
                dr = dtSec.NewRow();
                dr["Sec"] = i.ToString("D2");
                dtSec.Rows.Add(dr);
            }
            dtSec.AcceptChanges();
            return dtSec;
        }

        protected void lnkLMSHelp_Click(object sender, EventArgs e)
        {
            BECommon objBECommon = new BECommon();
            objBECommon.IntTransID = Convert.ToInt64(lblTransactionID.Text);
            objBECommon.intTypeID = 12;
            BCommon objBCommon = new BCommon();
            objBCommon.BUpdateFlowTimeStamp(objBECommon);
        }

        protected void lnkTechnicalHelp_Click(object sender, EventArgs e)
        {
            BECommon objBECommon = new BECommon();
            objBECommon.IntTransID = Convert.ToInt64(lblTransactionID.Text);
            objBECommon.intTypeID = 13;
            BCommon objBCommon = new BCommon();
            objBCommon.BUpdateFlowTimeStamp(objBECommon);
        }

        protected void lnkAuthentication_Click(object sender, EventArgs e)
        {
            BECommon objBECommon = new BECommon();
            objBECommon.IntTransID = Convert.ToInt64(AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()));
            objBECommon.intTypeID = 23;
            BCommon objBCommon = new BCommon();
            objBCommon.BUpdateFlowTimeStamp(objBECommon);
        }

        protected void lnkNext_Click(object sender, EventArgs e)
        {
            //BEProctor objBEProctor = new BEProctor();
            //BProctor objBProctor = new BProctor();
            //objBEProctor.IntTransID = Convert.ToInt32(AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()));
            //objBProctor.BUpdateEnableNextButtonTime(objBEProctor);

            if (lnkNext.Text == "Disable NEXT Button")
            {
                this.SetFlags("NEXT", 0);
                lnkNext.Text = "Enable NEXT Button";
            }
            else
            {
                this.SetFlags("NEXT", 1);
                lnkNext.Text = "Disable NEXT Button";
            }
        }

        public void setExamFiles()
        {
            BEStudent objBEStudent = new BEStudent();
            BStudent objBStudent = new BStudent();
            objBEStudent.IntTransID = Convert.ToInt64(AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()));
            objBStudent.BgetProviderFile(objBEStudent);
            if (objBEStudent.DsResult != null && objBEStudent.DsResult.Tables.Count > 0 && objBEStudent.DsResult.Tables[0].Rows.Count > 0)
            {
                gvUploadFiles.DataSource = objBEStudent.DsResult.Tables[0];
                gvUploadFiles.DataBind();

            }
            else
            {
                //ExamFiles.Visible = false;
                gvUploadFiles.DataSource = new string[] { };
            }

        }


        protected void lnlFile_Click(Object sender, EventArgs e)
        {

            string StoredFileName = ((LinkButton)sender).CommandArgument;


            string UploadedFile = StoredFileName;

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

                Page.ClientScript.RegisterStartupScript(GetType(), "MyScript", "alert('File does not exist');", true);
            }

        }

        protected void lnkOverrideKNOW_Click(object sender, EventArgs e)
        {
            BEStudent objBEStudent = new BEStudent();
            BStudent objBStudent = new BStudent();
            objBEStudent.IntTransID = Convert.ToInt64(AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()));
            objBEStudent.IntType = 1;
            objBEStudent.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID]);
            objBStudent.BOverrideAuthentication(objBEStudent);

        }

        protected void lnkOverrideKEY_Click(object sender, EventArgs e)
        {
            BEStudent objBEStudent = new BEStudent();
            BStudent objBStudent = new BStudent();
            objBEStudent.IntTransID = Convert.ToInt64(AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()));
            objBEStudent.IntType = 2;
            objBEStudent.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID]);
            objBStudent.BOverrideAuthentication(objBEStudent);
        }

        protected void lnlExamend_Click(object sender, EventArgs e)
        {
            BECommon objBECommon = new BECommon();
            objBECommon.IntTransID = Convert.ToInt64(AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()));
            objBECommon.intTypeID = 27;
            BCommon objBCommon = new BCommon();
            objBCommon.BAddEndexamTimestamp(objBECommon);
            //lnlExamend.Visible = false;
        }

        protected void ExamiLockLink_Click(object sender, EventArgs e)
        {
            BECommon objBECommon = new BECommon();
            objBECommon.IntTransID = Convert.ToInt64(AppSecurity.Decrypt(Request.QueryString["TransID"].ToString()));
            BCommon objBCommon = new BCommon();
            objBCommon.BUpdateExamiLOCK(objBECommon);
        }


    }
}