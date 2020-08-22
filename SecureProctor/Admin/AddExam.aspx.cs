using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessEntities;
using System.IO;
using BLL;
using Telerik.Web.UI;


namespace SecureProctor.Admin
{
    public partial class AddExam : BaseClass
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                this.Page.Title = EnumPageTitles.APPNAME + EnumPageTitles.EXAMPROVIDER_COURSEDETAILS_ADD_EXAM;
                this.BindDropDowns();
                this.GetCourseName();
                this.BindSecurityLevel();
                this.BindSecurityLevelDescription();
                this.BindCustomTimeValues(ExamStartRadTimePicker);
                this.BindCustomTimeValues(ExamEndRadTimePicker);
                this.GetStudentUploadFileStatus();
                this.BindNotesAndRules();
                trAddExam.Visible = true;
                trAddExamConfirm.Visible = false;
            }
            trMessage.Visible = false;

        }
        protected void BindCustomTimeValues(Telerik.Web.UI.RadTimePicker rdTimeView)
        {
            rdTimeView.TimeView.CustomTimeValues = new TimeSpan[] { new TimeSpan(00, 0, 0), new TimeSpan(00, 30, 0), new TimeSpan(1, 0, 0), new TimeSpan(1, 30, 0), new TimeSpan(2, 0, 0), new TimeSpan(2, 30, 0), new TimeSpan(3, 0, 0), new TimeSpan(3, 30, 0), new TimeSpan(4, 0, 0), new TimeSpan(4, 30, 0), new TimeSpan(5, 0, 0), new TimeSpan(5, 30, 0), new TimeSpan(6, 0, 0), new TimeSpan(6, 30, 0), new TimeSpan(7, 0, 0), new TimeSpan(7, 30, 0), new TimeSpan(8, 0, 0), new TimeSpan(8, 30, 0), new TimeSpan(9, 0, 0), new TimeSpan(9, 30, 0), new TimeSpan(10, 0, 0), new TimeSpan(10, 30, 0), new TimeSpan(11, 0, 0), new TimeSpan(11, 30, 0), new TimeSpan(12, 0, 0), new TimeSpan(12, 30, 0), new TimeSpan(13, 0, 0), new TimeSpan(13, 30, 0), new TimeSpan(14, 0, 0), new TimeSpan(14, 30, 0), new TimeSpan(15, 0, 0), new TimeSpan(15, 30, 0), new TimeSpan(16, 0, 0), new TimeSpan(16, 30, 0), new TimeSpan(17, 0, 0), new TimeSpan(17, 30, 0), new TimeSpan(18, 0, 0), new TimeSpan(18, 30, 0), new TimeSpan(19, 0, 0), new TimeSpan(19, 30, 0), new TimeSpan(20, 0, 0), new TimeSpan(20, 30, 0), new TimeSpan(21, 0, 0), new TimeSpan(21, 30, 0), new TimeSpan(22, 0, 0), new TimeSpan(22, 30, 0), new TimeSpan(23, 0, 0), new TimeSpan(23, 30, 0), new TimeSpan(23, 59, 0) };
        }

        protected void GetStudentUploadFileStatus()
        {

            BECommon objBECommon = new BECommon();
            BCommon objBCommon = new BCommon();
            objBCommon.BGetStudentUploadFileStatus(objBECommon);

            if (objBECommon.DtResult != null && objBECommon.DtResult.Rows.Count > 0)
            {
                if (objBECommon.DtResult.Rows[0][0].Equals(true))
                {
                    trStudentUpload.Visible = true;
                    trStudentUploadConfirm.Visible = true;
                }
                else
                {
                    trStudentUpload.Visible = false;
                    trStudentUploadConfirm.Visible = false;
                }

            }
        }
        #region BindSecurityLevels
        protected void ddlSecurityLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindSecurityLevelDescription();
        }
        protected void BindSecurityLevelDescription()
        {

            BEProvider objBEProvider = new BEProvider();
            BProvider objBProvider = new BProvider();
            objBEProvider.ddlSecurityLevel = Convert.ToInt32(ddlSecurityLevel.SelectedValue);
            objBProvider.BGetSelectedSecurityLevel(objBEProvider);
            lblLevelDesc.Text = objBEProvider.StrResult;
            lblLevelDesc.Visible = true;
        }
        protected void BindSecurityLevel()
        {
            try
            {
                BEProvider objBEProvider = new BEProvider();
                BProvider objBProvider = new BProvider();
                objBProvider.BBindProviderSecurityLevel(objBEProvider);
                ddlSecurityLevel.DataSource = objBEProvider.DtResult;
                ddlSecurityLevel.DataValueField = "ID";
                ddlSecurityLevel.DataTextField = "Level";
                ddlSecurityLevel.DataBind();
            }
            catch (Exception Ex)
            {
                ErrorHandlers.ErrorLog.WriteError(Ex);
            }
        }
        #endregion
        #region GetCourseName
        protected void GetCourseName()
        {
            try
            {
                BEProvider objBEExamProvider = new BEProvider();
                BProvider objBProvider = new BProvider();
                objBEExamProvider.IntCourseID = Convert.ToInt32(Request.QueryString["CourseID"].ToString());
                objBProvider.BGetSelectedCourseDetails(objBEExamProvider);
                if (objBEExamProvider.DtResult != null && objBEExamProvider.DtResult.Rows.Count > 0)
                {
                    lblCourseName.Text = objBEExamProvider.DtResult.Rows[0]["CourseName"].ToString() + " [" + objBEExamProvider.DtResult.Rows[0]["Course_ID"].ToString() + "] ";
                }
            }
            catch (Exception Ex)
            {
                ErrorHandlers.ErrorLog.WriteError(Ex);
            }
        }
        #endregion
        #region BindDropDowns
        protected void BindDropDowns()
        {
            DataTable dtHrs = GetHrsTable();
            DataTable dtMin = GetMinTable();
            ddlHours.DataSource = dtHrs;
            ddlHours.DataTextField = "Hrs";
            ddlHours.DataValueField = "Hrs";
            ddlHours.DataBind();
            ddlMinutes.DataSource = dtMin;
            ddlMinutes.DataTextField = "Min";
            ddlMinutes.DataValueField = "Min";
            ddlMinutes.DataBind();
            //ddlBufferTime.DataSource = dtMin;
            //ddlBufferTime.DataTextField = "Min";
            //ddlBufferTime.DataValueField = "Min";
            //ddlBufferTime.DataBind();
        }
        public static DataTable GetHrsTable()
        {
            DataTable dtHrs = new DataTable();
            DataRow dr;
            dtHrs.Columns.Add("Hrs", typeof(string));
            //
            dr = dtHrs.NewRow();
            dr["Hrs"] = "00";
            dtHrs.Rows.Add(dr);
            //
            for (int i = 1; i <= 23; i++)
            {
                dr = dtHrs.NewRow();
                dr["Hrs"] = i.ToString("D2");
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
        #endregion
        #region gvNotesGridEvents

        //protected void gvnotesConfirm_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        //{
        //    try
        //    {



        //        if (ViewState["DT_Notes"] != null)
        //        {
        //            gvnotesConfirm.DataSource = (DataTable)ViewState["DT_Notes"];
        //        }
        //        else
        //        {
        //            gvnotesConfirm.DataSource = new string[] { };
        //        }
        //    }
        //    catch (Exception Ex)
        //    {
        //        throw Ex;
        //    }
        //}


        #endregion



        #region OpenFile
        protected void lnkUpload_Click(Object sender, EventArgs e)
        {
            this.openFile();
        }
        protected void openFile()
        {
            if (ViewState["UploadedFile"] != null)
            {
                string UploadedFile = ViewState["UploadedFile"].ToString();
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
                    Page.ClientScript.RegisterStartupScript(GetType(), "MyScript", "alert('File does not exist');", true);
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "MyScript", "alert('File does not exist');", true);
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
        #endregion

        #region SaveExamButton
        protected void BtnSaveExam_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    int TimeDelay = 0;
                    BEProvider objBEExamProvider = new BEProvider();
                    BProvider objBExamProvider = new BProvider();

                    objBEExamProvider.IntCourseID = Convert.ToInt32(Request.QueryString["CourseID"].ToString());
                    lblConfirmCourseValue.Text = lblCourseName.Text;
                    objBEExamProvider.strExamName = txtExam.Text.Trim();
                    lblConfirmExamValue.Text = txtExam.Text.Trim();
                    lblExamPassword.Text = txtExamPassword.Text;
                    objBEExamProvider.strPassword = txtExamPassword.Text.Trim();
                    lblExamUserName.Text = txtExamUserName.Text.Trim();
                    objBEExamProvider.strExamUserName = txtExamUserName.Text.Trim();

                    objBEExamProvider.ddlHours = Convert.ToDecimal(ddlHours.SelectedValue);

                    objBEExamProvider.ddlMinutes = Convert.ToDecimal(ddlMinutes.SelectedValue);

                    if (objBEExamProvider.ddlMinutes.ToString().Length == 1)
                    {

                        objBEExamProvider.ddlHM = objBEExamProvider.ddlHours.ToString() + '.' + "0" + objBEExamProvider.ddlMinutes.ToString();
                    }

                    else
                    {
                        objBEExamProvider.ddlHM = objBEExamProvider.ddlHours.ToString() + '.' + objBEExamProvider.ddlMinutes.ToString();

                    }


                    lblConfirmExamDurationValue.Text = "Hours" + "  " + ddlHours.SelectedValue + "  :  " + "Minutes" + "  " + ddlMinutes.SelectedValue;

                    objBEExamProvider.IntBufferTime = 0;
                    //lblConfirmBufferTimeValue.Text = "Minutes" + " " + ddlBufferTime.SelectedValue;

                    objBEExamProvider.strLinkAccessExam = txtAccessExam.InnerText;
                    lblConfirmExamLinkValue.Text = txtAccessExam.InnerText;

                    BECommon objBECommon = new BECommon();
                    BCommon objBCommon = new BCommon();
                    //objBECommon.IntCourseID = Convert.ToInt32(Request.QueryString["CourseID"].ToString());
                    //objBCommon.BGetPorviderTimeDelay(objBECommon);
                    objBECommon.IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID]);
                    objBCommon.BGetAdminTimeDelay(objBECommon);
                    if (objBECommon.DsResult != null && objBECommon.DsResult.Tables.Count > 0 && objBECommon.DsResult.Tables[0].Rows.Count > 0)
                    {
                        TimeDelay = -1 * Convert.ToInt32(objBECommon.DsResult.Tables[0].Rows[0]["TimeDelay"].ToString());
                    }

                    DateTime examstartdate = Convert.ToDateTime(ExamStartRadDatePicker.SelectedDate);
                    DateTime examenddate = Convert.ToDateTime(ExamEndRadDatePicker.SelectedDate);
                    DateTime examstarttime = Convert.ToDateTime(ExamStartRadTimePicker.SelectedDate);
                    DateTime examendtime = Convert.ToDateTime(ExamEndRadTimePicker.SelectedDate);

                    //   String strdate=Convert.ToDateTime(ExamStartRadDatePicker.SelectedDate).ToString("d") + " " + (Convert.ToDateTime(ExamStartRadTimePicker.SelectedTime)).ToString("t");
                    string startdatetime = examstartdate.ToShortDateString() + " " + examstarttime.ToShortTimeString();
                    string enddatetime = examenddate.ToShortDateString() + " " + examendtime.ToShortTimeString();
                    objBEExamProvider.strExamStartDate = Convert.ToDateTime(startdatetime).AddMinutes(TimeDelay);
                    objBEExamProvider.strExamEndDate = Convert.ToDateTime(enddatetime).AddMinutes(TimeDelay);

                    //objBEExamProvider.strExamStartDate = CalendarExtender1.SelectedDate.Value.AddMinutes(TimeDelay);
                    //objBEExamProvider.strExamEndDate = CalendarExtender2.SelectedDate.Value.AddMinutes(TimeDelay);
                    //lblConfirmStartDateValue.Text = CalendarExtender1.SelectedDate.Value.ToString();
                    //lblConfirmEndDateValue.Text = CalendarExtender2.SelectedDate.Value.ToString();

                    lblConfirmStartDateValue.Text = startdatetime.ToString();
                    lblConfirmEndDateValue.Text = enddatetime.ToString();


                    //objBEExamProvider.strExamStartDate = Convert.ToDateTime(CalendarExtender1.SelectedDate.ToString());
                    //lblConfirmStartDateValue.Text = DateTime.Parse(CalendarExtender1.SelectedDate.ToString()).ToShortDateString();

                    // objBEExamProvider.strExamEndDate = Convert.ToDateTime(CalendarExtender2.SelectedDate.ToString());
                    // lblConfirmEndDateValue.Text = DateTime.Parse(CalendarExtender2.SelectedDate.ToString()).ToShortDateString();
                    objBEExamProvider.ddlSecurityLevel = Convert.ToInt32(ddlSecurityLevel.SelectedValue);
                    lblConfirmSecurityLevelValue.Text = ddlSecurityLevel.SelectedItem.Text;
                    objBEExamProvider.strOpenBook = 1;
                    objBEExamProvider.intLockDownBrowser = int.Parse(ddlLockDownBrowser.SelectedValue);
                    objBEExamProvider.intStudentUploadFile = int.Parse(rcbStudentUpload.SelectedValue);
                    objBEExamProvider.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID].ToString());
                    if (ddlSpecialNeeds.SelectedValue == "No")
                    {
                        objBEExamProvider.strSpecialNeeds = false;
                        lblspecialneedsflag.Text = "No";
                        Panel1.Visible = false;
                    }
                    else if (ddlSpecialNeeds.SelectedValue == "Yes")
                    {
                        objBEExamProvider.strSpecialNeeds = true;
                        lblspecialneedsflag.Text = "Yes";
                        Panel1.Visible = true;
                    }
                    lblLockDownBrowser.Text = ddlLockDownBrowser.SelectedItem.Text;
                    lblStudentUploadFileConfirm.Text = rcbStudentUpload.SelectedItem.Text;
                    lblExamFeePaidByConfirm.Text = ddlExamFeePaidBy.SelectedItem.Text.ToString();
                    lblondemandFeePaidByConfirm.Text = ddlOnDemandFeePaidBy.SelectedItem.Text.ToString();
                    objBExamProvider.BCheckForExamExistence(objBEExamProvider);
                    trMessage.Visible = true;

                    if (objBEExamProvider.IntResult == 0)
                    {
                        lblInfo.Text = Resources.AppMessages.Provider_AddExam_Error_ExamExists;
                        lblInfo.ForeColor = System.Drawing.Color.FromName(Resources.AppConfigurations.Color_Error);

                        ImgInfo.ImageUrl = Resources.AppConfigurations.Image_Error;
                        tdInfo.Attributes.Add("style", Resources.AppConfigurations.Color_Table_Error);
                        trAddExam.Visible = true;
                        trAddExamConfirm.Visible = false;
                    }
                    else
                    {

                       
                        savefiles();
                        if (ViewState["UploadedFile1"] != null)
                        {

                            objBEExamProvider.DtResult = (DataTable)ViewState["UploadedFile1"];
                        }

                        //additional rules

                        DataTable objDT = (DataTable)ViewState["ADDITIONALRULE"];

                        if (gvAllowed.Items.Count > 0)
                        {
                            foreach (GridDataItem item in gvAllowed.Items)
                            {
                                CheckBox chkBx = (CheckBox)item.FindControl("ChkProctor");

                                if (chkBx != null && chkBx.Checked)
                                {
                                    objDT.Rows[item.ItemIndex][2] = "true";


                                }
                            }
                        }

                        objBEExamProvider.dtResult_Rules = objDT;

                        //special instructions
                        DataTable objDTSpecial = (DataTable)ViewState["SPECIALRULE"];
                        //here we are updating the ruleid inorder to display the order in which move up/down has taken place 01dec2017
                        if (objDTSpecial != null)
                        {
                            if (objDTSpecial.Rows.Count > 0)
                            {
                                int rowIndex = Convert.ToInt32(objDTSpecial.Compute("min([RuleID])", string.Empty));


                                foreach (DataRow row in objDTSpecial.Rows)
                                {
                                    if (ViewState["MinRuleID"] != null)
                                        rowIndex = Convert.ToInt32(ViewState["MinRuleID"].ToString());

                                    row["RuleID"] = rowIndex;
                                    ViewState["MinRuleID"] = rowIndex + 1;//this view state is used for maintaining and incrementing the minimun rule id
                                }
                            }
                        }
                      

                        objBEExamProvider.DtResult1 = objDTSpecial;

                        if (ddlreusespecialinstructions.SelectedValue.ToString() == "Yes")
                        {
                            if ((lblNoExams.Visible == false) && (ddlExams.SelectedItem != null) && (lblNoSpRules.Visible == false))
                            {
                                objBEExamProvider.PastSpecialRules = 1;
                            }
                            else
                                objBEExamProvider.PastSpecialRules = 0;
                        }
                        else
                            objBEExamProvider.PastSpecialRules = 0;

                        ViewState["pastValue"] = objBEExamProvider.PastSpecialRules;


                        objBEExamProvider.intExamFeePaidBy = Convert.ToInt32(ddlExamFeePaidBy.SelectedValue.ToString());
                        objBEExamProvider.intOnDemandFeePaidBy = Convert.ToInt32(ddlOnDemandFeePaidBy.SelectedValue.ToString());
                        objBExamProvider.BSaveExamDetails(objBEExamProvider);
                        trAddExam.Visible = false;
                        trAddExamConfirm.Visible = true;


                        //bind all saved files to grid

                        objBECommon.iID = objBEExamProvider.IntResult;
                        objBCommon.BGetExamUploadFiles(objBECommon);

                        if (objBECommon.DsResult != null && objBECommon.DsResult.Tables.Count > 0 && objBECommon.DsResult.Tables[0].Rows.Count > 0)
                        {
                            gvUploadFiles.DataSource = objBECommon.DsResult.Tables[0];
                            gvUploadFiles.DataBind();

                        }
                        else
                        {
                            gvUploadFiles.DataSource = new string[] { };
                            gvUploadFiles.DataBind();
                        }


                        gvViewStandard.DataSource = objBEExamProvider.DsResult.Tables[0];
                        gvViewStandard.DataBind();
                        gvViewAdditional.DataSource = objBEExamProvider.DsResult.Tables[1];
                        gvViewAdditional.DataBind();
                        gvViewSpecial.DataSource = objBEExamProvider.DsResult.Tables[2];
                        gvViewSpecial.DataBind();

                      
                        lblInfo.Text = Resources.AppMessages.Provider_AddExam_Success_AddExam;
                        lblInfo.ForeColor = System.Drawing.Color.FromName(Resources.AppConfigurations.Color_Success);
                        ImgInfo.ImageUrl = Resources.AppConfigurations.Image_Success;
                        tdInfo.Attributes.Add("style", Resources.AppConfigurations.Color_Table_Success);
                    }
                    objBEExamProvider = null;
                    objBExamProvider = null;
                }
            }
            catch
            {
                lblInfo.Text = Resources.AppMessages.Provider_AddExam_Error_ExamError;
                lblInfo.ForeColor = System.Drawing.Color.FromName(Resources.AppConfigurations.Color_Error);

                ImgInfo.ImageUrl = Resources.AppConfigurations.Image_Error;
                tdInfo.Attributes.Add("style", Resources.AppConfigurations.Color_Table_Error);
                trAddExam.Visible = true;
                trAddExamConfirm.Visible = false;
            }
        }
        #endregion
        protected void BindNotesAndRules()
        {
            BECommon objBECommon = new BECommon();
            BCommon objBCommon = new BCommon();
            objBCommon.BGetStandardAndAdditionalRules(objBECommon);
            if (objBECommon.DsResult != null & objBECommon.DsResult.Tables.Count > 0 && objBECommon.DsResult.Tables[0].Rows.Count > 0)
            {
                gvStandard.DataSource = objBECommon.DsResult.Tables[0];
                gvStandard.DataBind();
            }
            else
            {
                gvStandard.DataSource = new string[] { };
            }
            if (objBECommon.DsResult != null & objBECommon.DsResult.Tables.Count > 0 && objBECommon.DsResult.Tables[1].Rows.Count > 0)
            {
                ViewState["ADDITIONALRULE"] = this.getRulesDataTable(objBECommon.DsResult.Tables[1]);
                ViewState["ADDITIONALRULE_OLD"] = this.getRulesDataTable(objBECommon.DsResult.Tables[1]);
                gvAllowed.DataSource = this.getRulesDataTable(objBECommon.DsResult.Tables[1]);
                //gvAllowed.DataSource = objBECommon.DsResult.Tables[1];
                gvAllowed.DataBind();
            }
            else
            {
                gvAllowed.DataSource = new string[] { };
            }
            gvSpecial.DataSource = this.getSpecialRulesDataTable();
            gvSpecial.DataBind();
            ViewState["SPECIALRULE"] = this.getSpecialRulesDataTable();
        }

        public DataTable
            getRulesDataTable(System.Data.DataTable objDt)
        {
            DataTable objDT = new DataTable();
            DataColumn objDC;
            objDC = new DataColumn("RuleID");
            objDT.Columns.Add(objDC);
            objDC = new DataColumn("RuleDesc");
            objDT.Columns.Add(objDC);
            objDC = new DataColumn("status");
            objDT.Columns.Add(objDC);
            DataRow objDR;
            for (int i = 0; i < objDt.Rows.Count; i++)
            {
                objDR = objDT.NewRow();
                objDR[0] = objDt.Rows[i][0];
                objDR[1] = objDt.Rows[i][1];
                objDR[2] = "false";
                objDT.Rows.Add(objDR);
            }
            return objDT;
        }
        public DataTable getSpecialRulesDataTable()
        {
            DataTable objDT = new DataTable();
            DataColumn objDC;
            objDC = new DataColumn("RuleID");
            objDT.Columns.Add(objDC);
            objDC = new DataColumn("RuleDesc");
            objDT.Columns.Add(objDC);
            objDC = new DataColumn("Proctor");
            objDT.Columns.Add(objDC);
            objDC = new DataColumn("Student");
            objDT.Columns.Add(objDC);
            return objDT;
        }
        protected void ChkAdditionalRule_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            Telerik.Web.UI.GridDataItem gr = (Telerik.Web.UI.GridDataItem)chk.NamingContainer;
            int i = gr.ItemIndex;
            this.BindAdditionalRules(i, chk.Checked);
        }
        protected void BindAdditionalRules(int intIndex, bool boolchecked)
        {
            DataTable objDT = (DataTable)ViewState["ADDITIONALRULE"];
            for (int i = 0; i < objDT.Rows.Count; i++)
            {
                if (i == intIndex)
                {
                    if (boolchecked)
                        objDT.Rows[intIndex][2] = "True";
                    else
                        objDT.Rows[intIndex][2] = "False";
                }
            }
            ViewState["ADDITIONALRULE"] = objDT;
            gvAllowed.DataSource = objDT;
            gvAllowed.DataBind();
        }
        protected void rdRulesSave_Click(object sender, EventArgs e)
        {
            if (taAdditionalRules.InnerText.ToString().Length != 0)
            {
                System.Data.DataTable objDt = (DataTable)ViewState["SPECIALRULE"];
                DataRow objDR;
                objDR = objDt.NewRow();
                objDR[0] = objDt.Rows.Count + 1;
                objDR[1] = taAdditionalRules.InnerText.ToString();
                if (chkStudent.Checked == true)
                {
                    objDR[2] = "False";
                    objDR[3] = "True";
                }
                else if (chkProctor.Checked == true)
                {
                    objDR[2] = "True";
                    objDR[3] = "False";
                }
                if (chkStudentAndProctor.Checked == true)
                {
                    objDR[2] = "True";
                    objDR[3] = "True";
                }
                objDt.Rows.Add(objDR);
                gvSpecial.DataSource = objDt;
                gvSpecial.DataBind();
                ViewState["SPECIALRULE"] = objDt;
                taAdditionalRules.InnerHtml = string.Empty;
            }
        }

        protected void ChkProctor_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            Telerik.Web.UI.GridDataItem gr = (Telerik.Web.UI.GridDataItem)chk.NamingContainer;
            int i = gr.ItemIndex;
            this.BindRules(i, chk.Checked, 0);
        }

        protected void ChkStudent_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            Telerik.Web.UI.GridDataItem gr = (Telerik.Web.UI.GridDataItem)chk.NamingContainer;
            int i = gr.ItemIndex;
            this.BindRules(i, chk.Checked, 1);
        }

        protected void BindRules(int intIndex, bool boolchecked, int intType)
        {
            DataTable objDT = (DataTable)ViewState["SPECIALRULE"];
            for (int i = 0; i < objDT.Rows.Count; i++)
            {
                if (i == intIndex)
                {
                    if (intType == 1)//student
                    {
                        objDT.Rows[intIndex][3] = boolchecked;
                    }
                    else
                    {
                        objDT.Rows[intIndex][2] = boolchecked;
                    }
                }
            }
            ViewState["SPECIALRULE"] = objDT;
            gvSpecial.DataSource = objDT;
            gvSpecial.DataBind();
        }

        protected void gvSpecial_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            DataTable objDT = (DataTable)ViewState["SPECIALRULE"];
            if (e.CommandName == "DELETE")
            {
                for (int i = 0; i < objDT.Rows.Count; i++)
                {
                    if (e.CommandArgument.ToString() == objDT.Rows[i][0].ToString())
                    {
                        objDT.Rows.RemoveAt(i);
                        objDT.AcceptChanges();
                    }
                }
                ViewState["SPECIALRULE"] = objDT;
                gvSpecial.DataSource = objDT;
                gvSpecial.DataBind();
            }

            // if (e.CommandName == "EDIT")
            //{
            //    for (int i = 0; i < objDT.Rows.Count; i++)
            //    {
            //        if (e.CommandArgument.ToString() == objDT.Rows[i][0].ToString())
            //        {
            //            if (objDT.Rows[i][2].ToString() == "True")
            //            {
            //            }
            //        }
            //    }
            //}
            //else 
        }

        protected void ddlSpecialNeeds_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(ddlSpecialNeeds.SelectedValue.ToString()))
            {
                if (ddlSpecialNeeds.SelectedValue.ToString() == "Yes")
                {
                    pnlInfo.Visible = true;
                }
                else
                {
                    pnlInfo.Visible = false;
                }
            }
        }

        protected void gvSpecial_EditCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName == "EDIT")
            {
                DataTable objDT = (DataTable)ViewState["SPECIALRULE"];
                gvSpecial.DataSource = objDT;
                gvSpecial.DataBind();
            }
        }

        protected void gvSpecial_UpdateCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName.ToString().ToUpper() == "UPDATE")
            {
                Telerik.Web.UI.RadTextBox txt = (Telerik.Web.UI.RadTextBox)e.Item.FindControl("txtRuleDescription");
                DataTable objDT = (DataTable)ViewState["SPECIALRULE"];
                ViewState["SPECIALRULE"] = setValue(objDT, e.CommandArgument.ToString(), txt.Text.Trim().ToString());
                gvSpecial.DataSource = objDT;
                gvSpecial.DataBind();
            }
        }


        protected DataTable setValue(DataTable objDT, string id, string value)
        {
            for (int i = 0; i < objDT.Rows.Count; i++)
            {
                if (objDT.Rows[i][0].ToString() == id)
                {
                    objDT.Rows[i][1] = value;
                    break;
                }
            }
            return objDT;
        }

        protected void gvSpecial_CancelCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName.ToString().ToUpper() == "CANCEL")
            {
                DataTable objDT = (DataTable)ViewState["SPECIALRULE"];
                gvSpecial.DataSource = objDT;
                gvSpecial.DataBind();
            }
        }

        protected void ServerValidation(object source, ServerValidateEventArgs args)
        {
            if (ddlHours.SelectedIndex == 0 && ddlMinutes.SelectedIndex == 0)
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }

        protected void ValidateDuration(object sender, ServerValidateEventArgs e)
        {
            DateTime examstartdate = Convert.ToDateTime(ExamStartRadDatePicker.SelectedDate);
            DateTime examenddate = Convert.ToDateTime(ExamEndRadDatePicker.SelectedDate);
            DateTime examstarttime = Convert.ToDateTime(ExamStartRadTimePicker.SelectedDate);
            DateTime examendtime = Convert.ToDateTime(ExamEndRadTimePicker.SelectedDate);


            string startdatetime = examstartdate.ToShortDateString() + " " + examstarttime.ToShortTimeString();
            string enddatetime = examenddate.ToShortDateString() + " " + examendtime.ToShortTimeString();
            if (Convert.ToDateTime(startdatetime) <= Convert.ToDateTime(enddatetime))
                e.IsValid = true;
            else
                e.IsValid = false;

        }

        #region uploadmulfiles

        //protected void RadAsyncUpload1_FileUploaded(object sender, FileUploadedEventArgs e)
        //{
        //    if (AdminUpload.UploadedFiles.Count > 0)
        //    {
        //        string a = AdminUpload.UploadedFiles[0].ToString();
        //        BEProvider objBEExamProvider = new BEProvider();
        //        BProvider objBExamProvider = new BProvider();
        //        string strpath = Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["ProviderUploadPath"]);
        //        string strUploadFileName = CommonFunctions.generateUploadFileName(e.File.FileName);
        //        string strOriginalFileName = e.File.FileName;                
        //        string strTotalPath = strpath + "\\" + strUploadFileName;
        //        objBEExamProvider.strOriginalFileName = strOriginalFileName;
        //        objBEExamProvider.strUploadPath = strUploadFileName;
        //        e.File.SaveAs(strTotalPath);
        //        ViewState["UploadedFile1"] = strUploadFileName;
        //       // lnkUpload.Text = strOriginalFileName;
        //        //lnkUpload.Visible = true;      

        //        if (ViewState["UploadFileName1"] != null)
        //        {
        //            DataTable dt1 = (DataTable)ViewState["UploadFileName1"];
        //            dt1.Rows.Add(strOriginalFileName, strUploadFileName);
        //            ViewState["UploadFileName1"] = dt1;
        //        }

        //        else
        //        {
        //            DataTable dt = getUploadFiles();
        //            dt.Rows.Add(strOriginalFileName, strUploadFileName);
        //            ViewState["UploadFileName1"] = dt;
        //        }
        //        if (ViewState["UploadFileName1"] != null)
        //        {
        //            if (AdminUpload.UploadedFiles.Count == ((DataTable)ViewState["UploadFileName1"]).Rows.Count)
        //            {
        //                trMessage.Visible = true;
        //                objBEExamProvider.IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID]);
        //                objBEExamProvider.DtResult = (DataTable)ViewState["UploadFileName1"];
        //            }
        //        }

        //    }
        //    else
        //    {

        //      //  lblConfirmUploadValue.Text = "N/A";
        //        ViewState["UploadedFile1"] = null;
        //       // lblConfirmUploadValue.Visible = true;
        //    }


        //}

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

        #endregion uploadmulfiles


        public void getUploadExamFiles()
        {
            try
            {
                BECommon objBECommon = new BECommon();
                BCommon objBCommon = new BCommon();
                if (ViewState["ExamID"] != null)
                {
                    objBECommon.iID = Convert.ToInt32(ViewState["ExamID"].ToString());
                    objBCommon.BGetExamUploadFiles(objBECommon);

                    if (objBECommon.DsResult != null && objBECommon.DsResult.Tables.Count > 0 && objBECommon.DsResult.Tables[0].Rows.Count > 0)
                    {
                        gvUploadFiles.DataSource = objBECommon.DsResult.Tables[0];
                        gvUploadFiles.DataBind();
                        ViewState["ExamID"] = null;
                    }
                    else
                        gvUploadFiles.DataSource = new string[] { };


                }
            }
            catch (Exception e)
            {

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

                Page.ClientScript.RegisterStartupScript(GetType(), "MyScript", "alert('File doesnot exist');", true);
            }


        }


        public void savefiles()
        {
            DataTable objDt = getUploadFiles();


            if (AdminUpload.UploadedFiles.Count > 0)
            {
                foreach (UploadedFile file in AdminUpload.UploadedFiles)
                {

                    DataRow objDr = objDt.NewRow();
                    BEProvider objBEExamProvider = new BEProvider();
                    BProvider objBExamProvider = new BProvider();
                    string strpath = Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["ProviderUploadPath"]);
                    string strUploadFileName = CommonFunctions.generateUploadFileName(file.FileName);
                    string strOriginalFileName = file.FileName;
                    string strTotalPath = strpath + "\\" + strUploadFileName;
                    objBEExamProvider.strOriginalFileName = strOriginalFileName;
                    objBEExamProvider.strUploadPath = strUploadFileName;
                    file.SaveAs(strTotalPath);
                    objDt.Rows.Add(strOriginalFileName, strUploadFileName);


                }

            }
            ViewState["UploadedFile1"] = objDt;



        }


        /// <summary>
        ///   Cloning Methods
        /// </summary>
        /// 

        private string tempId = string.Empty;

        protected void ddlreusespecialinstructions_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {

            if (!string.IsNullOrEmpty(ddlreusespecialinstructions.SelectedIndex.ToString()))
            {
                if (ddlreusespecialinstructions.SelectedValue.ToString() == "Yes")
                {
                    rcbCourses.Visible = true;
                    GetCoursesBySpecialInstructions();
                }
                else
                {
                    ddlExams.Visible = false;
                    rcbCourses.Visible = false;
                    lblNoExam.Visible = false;
                    lblNoExams.Visible = false;
                    lblNoSpRules.Visible = false;

                    if (ViewState["tempId"] != null)
                    {
                        DataTable dt = ViewState["SPECIALRULE"] as DataTable;
                        string[] arr = (ViewState["tempId"] as string).Split(',');
                        for (int i = 0; i < arr.Length; i++)
                        {
                            if (arr[i] != "")
                            {
                                DataRow[] DrArrCheck = dt.Select("RuleId = '" + arr[i] + "'");
                                foreach (DataRow DrCheck in DrArrCheck)
                                {
                                    dt.Rows.Remove(DrCheck);
                                }
                            }
                        }
                        dt.AcceptChanges();
                        ViewState["SPECIALRULE"] = dt;
                        tempId = string.Empty;
                        ViewState["tempId"] = tempId;
                        gvSpecial.DataSource = ViewState["SPECIALRULE"] as DataTable;
                        gvSpecial.DataBind();
                    }

                    if (ViewState["ADDITIONALRULE_OLD"] != null)
                    {
                        ViewState["ADDITIONALRULE"] = ViewState["ADDITIONALRULE_OLD"];
                        gvAllowed.DataSource = ViewState["ADDITIONALRULE"] as DataTable;
                        gvAllowed.DataBind();
                    }

                }
            }
        }

        private void GetCoursesBySpecialInstructions()
        {
            BEAdmin objBEAdmin = new BEAdmin();
            BAdmin objBAdmin = new BAdmin();
            objBAdmin.BGetCoursesBySplIns(objBEAdmin);
            if (objBEAdmin.DtResult != null && objBEAdmin.DtResult.Rows.Count > 0)
            {
                lblNoExam.Visible = false;
                rcbCourses.Items.Clear();
                rcbCourses.DataValueField = "CourseID";
                rcbCourses.DataTextField = "CourseName";
                rcbCourses.DataSource = objBEAdmin.DtResult;
                rcbCourses.DataBind();
                rcbCourses.Text = "";
                rcbCourses.ClearSelection();
            }
            else
            {
                lblNoExam.Visible = true;
                lblNoExams.Visible = false;
                rcbCourses.Text = "";
                rcbCourses.ClearSelection();
                rcbCourses.Visible = false;
            }
        }

        protected void rcbCourses_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (rcbCourses.SelectedItem != null && rcbCourses.SelectedIndex > -1)
            {
                GetExamDetailsByCourses();
            }
            else
            {
                ddlExams.Visible = false;
            }
        }

        protected void GetExamDetailsByCourses()
        {
            try
            {
                lblNoSpRules.Visible = false;
                BEAdmin objBEAdmin = new BEAdmin();
                BAdmin objBAdmin = new BAdmin();
                if (rcbCourses.SelectedItem != null)
                    objBEAdmin.IntCourseID = Convert.ToInt32(rcbCourses.SelectedItem.Value);

                objBAdmin.BGetExamDetailsByCourseAndSplIns(objBEAdmin);
                if (objBEAdmin.DtResult != null && objBEAdmin.DtResult.Rows.Count > 0)
                {
                    lblNoSpRules.Visible = false;
                    ddlExams.Visible = true;
                    lblNoExam.Visible = false;
                    lblNoExams.Visible = false;
                    ddlExams.DataValueField = "ExamID";
                    ddlExams.DataTextField = "ExamName";
                    ddlExams.DataSource = objBEAdmin.DtResult;
                    ddlExams.DataBind();
                    ddlExams.Text = "";
                    ddlExams.ClearSelection();
                }
                else
                {
                    lblNoExam.Visible = true;
                    lblNoExams.Visible = false;
                    ddlExams.Text = "";
                    ddlExams.ClearSelection();
                    ddlExams.Visible = false;
                }
            }
            catch (Exception Ex)
            {
                ErrorHandlers.ErrorLog.WriteError(Ex);
            }
        }

        protected void ddlExams_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (ViewState["Exam_Old"] != null && ViewState["Exam_Old"].ToString() != ddlExams.SelectedValue)
            {
                if (ViewState["tempId"] != null)
                {
                    DataTable dt = ViewState["SPECIALRULE"] as DataTable;
                    string[] arr = (ViewState["tempId"] as string).Split(',');
                    for (int i = 0; i < arr.Length; i++)
                    {
                        DataRow[] DrArrCheck = dt.Select("RuleId = '" + arr[i] + "'");
                        foreach (DataRow DrCheck in DrArrCheck)
                        {
                            dt.Rows.Remove(DrCheck);
                        }
                    }
                    dt.AcceptChanges();
                    ViewState["SPECIALRULE"] = dt;
                    tempId = string.Empty;
                    ViewState["tempId"] = tempId;
                }
            }

            GetSpecialInstructionsByExam();
            GetAdditionalInstructionsByExam();
        }

        private void GetSpecialInstructionsByExam()
        {
            BEProvider objBEExamProvider = new BEProvider();
            BProvider objBProvider = new BProvider();
            objBEExamProvider.IntExamID = Convert.ToInt32(ddlExams.SelectedValue);
            objBEExamProvider.IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID]);
            objBProvider.BGetEditExamDetails(objBEExamProvider);

            if (objBEExamProvider.DsResult.Tables[3].Rows.Count > 0)
            {
                if (ViewState["SPECIALRULE"] != null)
                {
                    DataTable dt = ViewState["SPECIALRULE"] as DataTable;
                    int i = 1;
                    foreach (DataRow row in objBEExamProvider.DsResult.Tables[3].Rows)
                    {
                        dt.Rows.Add((Convert.ToInt32(ddlExams.SelectedValue) + i), row["RuleDesc"].ToString(), row["Proctor"].ToString(), row["Student"].ToString());
                        if (ViewState["tempId"] != null)
                        {
                            tempId = ViewState["tempId"] as string + (Convert.ToInt32(ddlExams.SelectedValue) + i) + ",";
                        }
                        else
                        {
                            tempId = (Convert.ToInt32(ddlExams.SelectedValue) + i) + ",";
                        }
                        ViewState["tempId"] = tempId;
                        i++;
                    }
                    ViewState["SPECIALRULE"] = dt;
                    ViewState["Exam_Old"] = ddlExams.SelectedValue;
                }
                else
                {
                    ViewState["SPECIALRULE"] = objBEExamProvider.DsResult.Tables[3];
                }

                gvSpecial.DataSource = ViewState["SPECIALRULE"] as DataTable;
                gvSpecial.DataBind();

                //ViewState["SPECIALRULE"] = objBEExamProvider.DsResult.Tables[3];
                lblNoSpRules.Visible = false;
            }
            else
            {
                if (ViewState["SPECIALRULE"] != null)
                {
                    gvSpecial.DataSource = ViewState["SPECIALRULE"] as DataTable;
                    gvSpecial.DataBind();
                    lblNoSpRules.Visible = true;
                }
                else
                {
                    gvSpecial.DataSource = new string[] { };
                    gvSpecial.DataBind();
                    lblNoSpRules.Visible = true;
                }

            }
        }

        private void GetAdditionalInstructionsByExam()
        {
            BEProvider objBEExamProvider = new BEProvider();
            BProvider objBProvider = new BProvider();
            objBEExamProvider.IntExamID = Convert.ToInt32(ddlExams.SelectedValue);
            objBEExamProvider.IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID]);
            objBProvider.BGetAdditionalRules(objBEExamProvider);

            if (objBEExamProvider.DsResult.Tables[0].Rows.Count > 0)
            {
                gvAllowed.DataSource = objBEExamProvider.DsResult.Tables[0];
                gvAllowed.DataBind();

                ViewState["ADDITIONALRULE"] = objBEExamProvider.DsResult.Tables[0];
                if (objBEExamProvider.DsResult.Tables.Count > 1)
                    lblNoSpRules.Visible = true;
                else
                    lblNoSpRules.Visible = false;
            }
            else
            {
                if (ViewState["ADDITIONALRULE"] != null)
                {
                    gvAllowed.DataSource = ViewState["ADDITIONALRULE"] as DataTable;
                    gvAllowed.DataBind();

                    if (objBEExamProvider.DsResult.Tables.Count > 1)
                        lblNoSpRules.Visible = true;
                    else
                        lblNoSpRules.Visible = false;
                }
                else
                {
                    gvAllowed.DataSource = new string[] { };
                    gvAllowed.DataBind();
                    if (objBEExamProvider.DsResult.Tables.Count > 1)
                        lblNoSpRules.Visible = true;
                    else
                        lblNoSpRules.Visible = false;
                }
            }
        }

        /// <summary>
        ///   End of cloning
        /// </summary>
        /// 

        ////////06nov2017/move up/down feature       

        protected void ChangeOrder(string strType)
        {
            int Index = 0;
            bool boolFlag = false;
            foreach (Telerik.Web.UI.GridDataItem item in gvSpecial.Items)
            {
                //RadioButton btn = (RadioButton)item.FindControl("rbInstruction");
                //if (btn.Checked == true)
                //{
                //item["TrackerId"].BackColor = ColorTranslator.FromHtml("#d7dbe2");

                if (item.Selected == true)
                {
                    DataTable objDTSpecial = (DataTable)ViewState["SPECIALRULE"];

                    //here we are moving special instructions up / down
                    if (objDTSpecial != null)
                    {
                        MoveRow(objDTSpecial, item.ItemIndex, strType);
                    }

                    ////here we need to show the moved row highlighted
                    if (strType == "MOVEUP")
                        Index = item.ItemIndex - 1;
                    else if (strType == "MOVEDOWN")
                        Index = item.ItemIndex + 1;
                }
            }
            gvSpecial.MasterTableView.Items[Index].Selected = true;

            if (!boolFlag)
            {
                //  ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "jAlert('Please select order.','" + Resources.PageTitles.APPNAME + "')", true);
            }
        }

        private void MoveRow(DataTable table, int idx, string strType)
        {
            DataRow selectedRow = table.Rows[idx];
            DataRow newRow = table.NewRow();
            newRow.ItemArray = selectedRow.ItemArray; // copy data
            table.Rows.Remove(selectedRow);

            if (strType == "MOVEUP")
                table.Rows.InsertAt(newRow, idx + 1 / -1);
            else if (strType == "MOVEDOWN")
                table.Rows.InsertAt(newRow, idx - 1 / -1);

            ViewState["SPECIALRULE"] = table;
            gvSpecial.DataSource = table;
            gvSpecial.DataBind();
        }

        protected void btnImgMoveUp_Click(object sender, ImageClickEventArgs e)
        {
            this.ChangeOrder("MOVEUP");
        }

        protected void btnImgMoveDown_Click(object sender, ImageClickEventArgs e)
        {
            this.ChangeOrder("MOVEDOWN");
        }

        protected void btnImgMoveDelete_Click(object sender, ImageClickEventArgs e)
        {
            foreach (Telerik.Web.UI.GridDataItem item in gvSpecial.Items)
            {
                if (item.Selected == true)
                {
                    DataTable objDTSpecial = (DataTable)ViewState["SPECIALRULE"];

                    //here we are moving special instructions up / down
                    if (objDTSpecial != null)
                    {
                        DataRow selectedRow = objDTSpecial.Rows[item.ItemIndex];
                        DataRow newRow = objDTSpecial.NewRow();
                        newRow.ItemArray = selectedRow.ItemArray; // copy data
                        objDTSpecial.Rows.Remove(selectedRow);

                        ViewState["SPECIALRULE"] = objDTSpecial;
                        gvSpecial.DataSource = objDTSpecial;
                        gvSpecial.DataBind();
                    }
                }
            }
        }

    }
}