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

namespace SecureProctor.Provider
{
    public partial class EditExam : BaseClass
    {
        #region PageLoad
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Page.Title = EnumPageTitles.APPNAME + EnumPageTitles.EXAMPROVIDER_COURSEDETAILS_EDIT_EXAM;
                this.BindDropDowns();
                this.BindProviderSecurityLevel();
                this.GetStudentUploadFileStatus();
                this.getSelectedExamDetails();
                this.BindCustomTimeValues(ExamStartRadTimePicker);
                this.BindCustomTimeValues(ExamEndRadTimePicker);
                trEditExam.Visible = true;
                trEditExamConfirm.Visible = false;
                trMessage.Visible = false;
            }
        }
        #endregion
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


        #region getSelectedExamDetails
        protected void getSelectedExamDetails()
        {
            try
            {
                //  upFile.Visible = true;

                BEProvider objBEExamProvider = new BEProvider();
                BProvider objBProvider = new BProvider();
                objBEExamProvider.IntExamID = Convert.ToInt32(Request.QueryString["ExamID"].ToString());
                objBProvider.BGetSelectedExamDetails(objBEExamProvider);
                if (objBEExamProvider.DsResult != null)
                {
                    lblLevelDesc.Visible = true;
                    lblCourseName.Text = objBEExamProvider.DsResult.Tables[0].Rows[0]["CourseName"].ToString();
                    txtExamUserName.Text = objBEExamProvider.DsResult.Tables[0].Rows[0]["ExamUserName"].ToString();
                    txtExamPassword.Text = objBEExamProvider.DsResult.Tables[0].Rows[0]["ExamPassword"].ToString();
                    txtExam.Text = objBEExamProvider.DsResult.Tables[0].Rows[0]["ExamName"].ToString();
                    ddlSecurityLevel.SelectedValue = objBEExamProvider.DsResult.Tables[0].Rows[0]["ID"].ToString();
                    lblLevelDesc.Text = objBEExamProvider.DsResult.Tables[0].Rows[0]["Description"].ToString();
                    string[] str = objBEExamProvider.DsResult.Tables[0].Rows[0]["ExamDuration"].ToString().Split('.');
                    if (str[0].ToString().Length == 1)
                        ddlHours.SelectedValue = "0" + str[0].ToString();
                    else
                        ddlHours.SelectedValue = str[0].ToString();
                    if (str[1].ToString().Length == 1)
                        ddlMinutes.SelectedValue = "0" + str[1].ToString();
                    else
                        ddlMinutes.SelectedValue = str[1].ToString();

                    if (objBEExamProvider.DsResult.Tables[0].Rows[0]["Specialneedsflag"].ToString() == "False")
                    {
                        ddlSpecialNeeds.SelectedValue = "0";
                        pnlInfo.Visible = false;
                    }
                    else
                    {
                        ddlSpecialNeeds.SelectedValue = "1";
                        pnlInfo.Visible = true;
                    }
                    if (objBEExamProvider.DsResult.Tables[0].Rows[0]["LockDownBrowser"].ToString() == "True")
                    {
                        ddlLockDownBrowser.SelectedValue = "1";
                    }
                    else
                    {
                        ddlLockDownBrowser.SelectedValue = "0";
                    }

                    if (objBEExamProvider.DsResult.Tables[0].Rows[0]["StudentUploadFile"].ToString() == "Yes")
                    {
                        rcbStudentUpload.SelectedValue = "1";
                    }
                    else
                    {
                        rcbStudentUpload.SelectedValue = "0";
                    }

                    if (objBEExamProvider.DsResult.Tables[0].Rows[0]["PastSpecialRules"].ToString() == "1")
                    {
                        ddlreusespecialinstructions.SelectedValue = "Yes";
                        //ddlExams.Visible = true;
                        //GetExamDetails();
                        rcbCourses.Visible = true;
                        GetCoursesBySpecialInstructions();
                    }
                    else
                    {
                        ddlreusespecialinstructions.SelectedValue = "No";
                    }


                    ddlExamFeePaidBy.SelectedValue = objBEExamProvider.DsResult.Tables[0].Rows[0]["PaidBy_ExamFee"].ToString();
                    ddlOnDemandFeePaidBy.SelectedValue = objBEExamProvider.DsResult.Tables[0].Rows[0]["PaidBy_OnDemandFee"].ToString();

                    txtAccessExam.InnerText = objBEExamProvider.DsResult.Tables[0].Rows[0]["ExamLink"].ToString();
                    if (objBEExamProvider.DsResult.Tables[0].Rows[0]["ExamStartDate"].ToString() != null && objBEExamProvider.DsResult.Tables[0].Rows[0]["ExamStartDate"].ToString() != "--" && objBEExamProvider.DsResult.Tables[0].Rows[0]["ExamStartDate"].ToString() != "")
                    {
                        DateTime examstartdate = Convert.ToDateTime(objBEExamProvider.DsResult.Tables[0].Rows[0]["ExamStartDate"]);
                        DateTime examstarttime = Convert.ToDateTime(objBEExamProvider.DsResult.Tables[0].Rows[0]["ExamStartDate"]);
                        ExamStartRadDatePicker.SelectedDate = Convert.ToDateTime(examstartdate.ToShortDateString());
                        ExamStartRadTimePicker.SelectedDate = Convert.ToDateTime(examstarttime.ToShortTimeString());
                        //calStartDate.SelectedDate = Convert.ToDateTime(objBEExamProvider.DsResult.Tables[0].Rows[0]["ExamStartDate"].ToString());
                    }

                    if (objBEExamProvider.DsResult.Tables[0].Rows[0]["ExamEndDate"].ToString() != null && objBEExamProvider.DsResult.Tables[0].Rows[0]["ExamEndDate"].ToString() != "--" && objBEExamProvider.DsResult.Tables[0].Rows[0]["ExamEndDate"].ToString() != "")
                    {
                        DateTime examenddate = Convert.ToDateTime(objBEExamProvider.DsResult.Tables[0].Rows[0]["ExamEndDate"]);
                        DateTime examendtime = Convert.ToDateTime(objBEExamProvider.DsResult.Tables[0].Rows[0]["ExamEndDate"]);
                        ExamEndRadDatePicker.SelectedDate = Convert.ToDateTime(examenddate.ToShortDateString());
                        ExamEndRadTimePicker.SelectedDate = Convert.ToDateTime(examendtime.ToShortTimeString());
                        //calEndDate.SelectedDate = Convert.ToDateTime(objBEExamProvider.DsResult.Tables[0].Rows[0]["ExamEndDate"].ToString());
                    }
                    ddlStatus.Items.FindItemByText(objBEExamProvider.DsResult.Tables[0].Rows[0]["status"].ToString()).Selected = true;


                    //if (objBEExamProvider.DsResult.Tables[0].Rows[0]["OriginalFileName"].ToString() != null && objBEExamProvider.DsResult.Tables[0].Rows[0]["OriginalFileName"].ToString() != "")
                    //{

                    //    lnkUploadFile.Text = objBEExamProvider.DsResult.Tables[0].Rows[0]["OriginalFileName"].ToString();
                    //    lnkUploadFile.CommandArgument = objBEExamProvider.DsResult.Tables[0].Rows[0]["StoredFileName"].ToString();
                    //    lnkUpload.Text = objBEExamProvider.DsResult.Tables[0].Rows[0]["OriginalFileName"].ToString();
                    //    lnkUpload.CommandArgument = objBEExamProvider.DsResult.Tables[0].Rows[0]["StoredFileName"].ToString();
                    //    lnkUploadFile.Visible = true;
                    //    lblFile.Visible = false;
                    //    imgCancel.Visible = true;
                    //    upFile.Visible = false;
                    //    lnkUpload.Visible = true;
                    //    lblConfirmUploadValue.Visible = false;

                    //}

                    //else
                    //{

                    //    lnkUploadFile.Visible = false;
                    //    lnkUpload.Visible = false;
                    //    lblFile.Visible = false;
                    //    imgCancel.Visible = false;
                    //    lblConfirmUploadValue.Visible = true;
                    //    lblConfirmUploadValue.Text = "N/A";


                    //}
                    if (objBEExamProvider.DsResult.Tables[1].Rows.Count > 0)
                    {

                        gvStandard.DataSource = objBEExamProvider.DsResult.Tables[1];
                        gvStandard.DataBind();

                    }
                    else
                    {
                        gvStandard.DataSource = new string[] { };
                        gvStandard.DataBind();
                    }

                    if (objBEExamProvider.DsResult.Tables[2].Rows.Count > 0)
                    {
                        // ViewState["DT_Notes"] = objBEExamProvider.DsResult.Tables[2];
                        ViewState["ADDITIONALRULE"] = objBEExamProvider.DsResult.Tables[2];
                        ViewState["ADDITIONALRULE_OLD"] = objBEExamProvider.DsResult.Tables[2];
                        gvAllowed.DataSource = objBEExamProvider.DsResult.Tables[2];
                        gvAllowed.DataBind();

                    }
                    else
                    {
                        gvStandard.DataSource = new string[] { };
                        gvStandard.DataBind();
                    }

                    if (objBEExamProvider.DsResult.Tables[3].Rows.Count > 0)
                    {
                        ViewState["SPECIALRULE"] = objBEExamProvider.DsResult.Tables[3];
                        gvSpecial.DataSource = objBEExamProvider.DsResult.Tables[3];
                        gvSpecial.DataBind();
                    }
                    else
                    {
                        gvSpecial.DataSource = new string[] { };
                        gvSpecial.DataBind();
                    }
                }
                BECommon objBECommon = new BECommon();
                BCommon objBCommon = new BCommon();

                objBECommon.iID = Convert.ToInt32(Request.QueryString["ExamID"].ToString());
                objBCommon.BGetExamUploadFiles(objBECommon);

                if (objBECommon.DsResult != null && objBECommon.DsResult.Tables.Count > 0 && objBECommon.DsResult.Tables[0].Rows.Count > 0)
                {
                    gvUploadFiles.DataSource = objBECommon.DsResult.Tables[0];
                    gvUploadFiles.DataBind();
                    trUploadedFiles.Visible = true;
                    ViewState["UploadedFiles"] = getdeletefilesDataTable(objBECommon.DsResult.Tables[0]);


                }
                else
                {
                    gvUploadFiles.DataSource = new string[] { };
                    gvUploadFiles.DataBind();
                    trUploadedFiles.Visible = false;
                    ViewState["UploadedFiles"] = null;
                }
                objBECommon.iID = Convert.ToInt32(Request.QueryString["ExamID"].ToString());
                objBECommon.iTypeID = 3;
                objBCommon.BGetLMSSettings(objBECommon);

                if (objBECommon.DtResult != null && objBECommon.DtResult.Rows.Count > 0)
                {

                    if (!Convert.ToBoolean(objBECommon.DtResult.Rows[0]["instructor"]))
                    {

                        txtExam.ReadOnly = Convert.ToBoolean(objBECommon.DtResult.Rows[0]["ExamName"]);
                        if (Convert.ToBoolean(objBECommon.DtResult.Rows[0]["ExamName"]))
                            txtExam.CssClass = "disableField";

                        txtAccessExam.Disabled = Convert.ToBoolean(objBECommon.DtResult.Rows[0]["ExamUrl"]);

                        txtExamPassword.ReadOnly = Convert.ToBoolean(objBECommon.DtResult.Rows[0]["ExamPassword"]);
                        if (Convert.ToBoolean(objBECommon.DtResult.Rows[0]["ExamPassword"]))
                            txtExamPassword.CssClass = "disableField";

                        if (Convert.ToBoolean(objBECommon.DtResult.Rows[0]["ExamStartdate"]))
                        {
                            ExamStartRadDatePicker.Enabled = false;
                            ExamStartRadTimePicker.Enabled = false;
                            //calStartDate.Enabled = false;
                            RFV1.Enabled = false;
                        }
                        else
                        {
                            ExamStartRadDatePicker.Enabled = true;
                            ExamStartRadTimePicker.Enabled = true;
                        }
                        //calStartDate.Enabled = true;

                        if (Convert.ToBoolean(objBECommon.DtResult.Rows[0]["ExamEnddate"]))
                        {
                            ExamEndRadTimePicker.Enabled = false;
                            ExamEndRadDatePicker.Enabled = false;
                            //calEndDate.Enabled = false;
                            RF4.Enabled = false;
                            CompareValidator1.Enabled = false;
                        }
                        else
                        {
                            ExamEndRadTimePicker.Enabled = true;
                            ExamEndRadDatePicker.Enabled = true;
                            //calEndDate.Enabled = true;
                        }


                        if (Convert.ToBoolean(objBECommon.DtResult.Rows[0]["ExamDuration"]))
                        {
                            ddlHours.Enabled = false;
                            ddlMinutes.Enabled = false;
                        }
                        else
                        {
                            ddlHours.Enabled = true;
                            ddlMinutes.Enabled = true;
                        }
                    }

                }
            }
            catch
            {
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

        /*
        protected void gvnotesConfirm_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            try
            {
                if (ViewState["DT_Notes"] != null)
                {
                    gvnotesConfirm.DataSource = (DataTable)ViewState["DT_Notes"];
                }
                else
                {
                    gvnotesConfirm.DataSource = new string[] { };
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        */

        #endregion
        #region gvRuleGridEvents
        /*
        protected void gvRulesConfirm_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            try
            {
                if (ViewState["DT_Rules"] != null)
                {
                    gvRulesConfirm.DataSource = (DataTable)ViewState["DT_Rules"];
                }
                else
                {
                    gvRulesConfirm.DataSource = new string[] { };
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
       */
        #endregion
        #region setValue
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
        #endregion
        #region UpdateExamButton


        protected void BtnUpdateExam_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    int TimeDelay = 0;
                    BEProvider objBEExamProvider = new BEProvider();
                    BProvider objBExamProvider = new BProvider();
                    lblConfirmCourseValue.Text = lblCourseName.Text;
                    objBEExamProvider.IntExamID = Convert.ToInt32(Request.QueryString["ExamID"].ToString());
                    lblConfirmExamValue.Text = txtExam.Text.Trim();
                    lblExamUserName.Text = txtExamUserName.Text.Trim();
                    objBEExamProvider.strExamUserName = txtExamUserName.Text.Trim();

                    objBEExamProvider.strPassword = txtExamPassword.Text;
                    objBEExamProvider.strExamName = txtExam.Text.Trim();
                    objBEExamProvider.ddlHours = Convert.ToDecimal(ddlHours.SelectedValue);
                    objBEExamProvider.ddlMinutes = Convert.ToDecimal(ddlMinutes.SelectedValue);
                    //  objBEExamProvider.ddlHM = objBEExamProvider.ddlHours.ToString() + '.' + objBEExamProvider.ddlMinutes.ToString();

                    if (objBEExamProvider.ddlMinutes.ToString().Length == 1)
                    {

                        objBEExamProvider.ddlHM = objBEExamProvider.ddlHours.ToString() + '.' + "0" + objBEExamProvider.ddlMinutes.ToString();
                    }

                    else
                    {
                        objBEExamProvider.ddlHM = objBEExamProvider.ddlHours.ToString() + '.' + objBEExamProvider.ddlMinutes.ToString();

                    }

                    lblConfirmExamDurationValue.Text = "Hours" + " " + ddlHours.SelectedValue + ":" + "Minutes" + " " + ddlMinutes.SelectedValue;
                    lblExamPassword.Text = txtExamPassword.Text;

                    objBEExamProvider.strLinkAccessExam = txtAccessExam.InnerText;
                    lblConfirmExamLinkValue.Text = txtAccessExam.InnerText;
                    objBEExamProvider.ddlSecurityLevel = Convert.ToInt32(ddlSecurityLevel.SelectedValue);
                    lblConfirmSecurityLevelValue.Text = ddlSecurityLevel.SelectedItem.Text;

                    objBEExamProvider.strOpenBook = 1;
                    objBEExamProvider.intLockDownBrowser = int.Parse(ddlLockDownBrowser.SelectedValue);
                    objBEExamProvider.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID].ToString());
                    objBEExamProvider.Intstatus = Convert.ToInt32(ddlStatus.SelectedValue);
                    if (objBEExamProvider.Intstatus == 1)
                    {

                        lblStatus.Text = "Active";
                    }

                    if (objBEExamProvider.Intstatus == 0)
                    {

                        lblStatus.Text = "Inactive";
                    }

                    if (ddlSpecialNeeds.SelectedValue == "0")
                    {
                        objBEExamProvider.strSpecialNeeds = false;
                        lblspecialneedsflag.Text = "No";
                        Panel1.Visible = false;
                    }
                    else if (ddlSpecialNeeds.SelectedValue == "1")
                    {
                        objBEExamProvider.strSpecialNeeds = true;
                        lblspecialneedsflag.Text = "Yes";
                        Panel1.Visible = true;
                    }

                    if (rcbStudentUpload.SelectedValue == "1")
                    {
                        objBEExamProvider.intStudentUploadFile = 1;
                    }
                    else
                        objBEExamProvider.intStudentUploadFile = 0;

                    if (Session["TimeZone"] != null && Session["TimeZoneID"] != null)
                    {

                        BECommon objBECommon = new BECommon();
                        BCommon objBCommon = new BCommon();
                        objBECommon.iTimeZoneID = Convert.ToInt32(Session["TimeZoneID"]);
                        objBCommon.BGetTimeDelay(objBECommon);
                        TimeDelay = -1 * objBECommon.IntResult;


                    }
                    DateTime examstartdate = Convert.ToDateTime(ExamStartRadDatePicker.SelectedDate);
                    DateTime examenddate = Convert.ToDateTime(ExamEndRadDatePicker.SelectedDate);
                    DateTime examstarttime = Convert.ToDateTime(ExamStartRadTimePicker.SelectedDate);
                    DateTime examendtime = Convert.ToDateTime(ExamEndRadTimePicker.SelectedDate);
                    string startdatetime = examstartdate.ToShortDateString() + " " + examstarttime.ToShortTimeString();
                    string enddatetime = examenddate.ToShortDateString() + " " + examendtime.ToShortTimeString();

                    objBEExamProvider.dtExamStartDate = Convert.ToDateTime(startdatetime).AddMinutes(TimeDelay);
                    objBEExamProvider.dtExamEndDate = Convert.ToDateTime(enddatetime).AddMinutes(TimeDelay);



                    lblConfirmStartDateValue.Text = startdatetime.ToString();
                    lblConfirmEndDateValue.Text = enddatetime.ToString();

                    lblLockDownBrowser.Text = ddlLockDownBrowser.SelectedItem.Text;
                    objBEExamProvider.intLockDownBrowser = Convert.ToInt32(ddlLockDownBrowser.SelectedValue);
                    lblStudentUploadFileConfirm.Text = rcbStudentUpload.SelectedItem.Text;
                    lblExamFeePaidByConfirm.Text = ddlExamFeePaidBy.SelectedItem.Text.ToString();
                    lblondemandFeePaidByConfirm.Text = ddlOnDemandFeePaidBy.SelectedItem.Text.ToString();
                    objBExamProvider.BCheckForUpdateExamExistence(objBEExamProvider);

                    if (objBEExamProvider.IntResult == 0)
                    {
                        lblInfo.Text = Resources.AppMessages.Provider_EditExam_Error_ExamExists;
                        lblInfo.ForeColor = System.Drawing.Color.FromName(Resources.AppConfigurations.Color_Error);
                        ImgInfo.ImageUrl = Resources.AppConfigurations.Image_Error;
                        tdInfo.Attributes.Add("style", Resources.AppConfigurations.Color_Table_Error);
                        trEditExam.Visible = true;
                        trEditExamConfirm.Visible = false;
                    }
                    else
                    {

                        //delete files

                        DeleteFiles();
                        //save new files

                        savefiles();
                        if (ViewState["UploadedFile1"] != null)
                        {

                            objBEExamProvider.DtResult = (DataTable)ViewState["UploadedFile1"];
                        }

                        //additional rules
                        DataTable dtAdditionalRules = (DataTable)ViewState["ADDITIONALRULE"];
                        if (gvAllowed.Items.Count > 0)
                        {
                            foreach (GridDataItem item in gvAllowed.Items)
                            {
                                CheckBox chkBx = (CheckBox)item.FindControl("ChkProctor");

                                if (chkBx != null && chkBx.Checked)
                                {
                                    dtAdditionalRules.Rows[item.ItemIndex][2] = "true";


                                }
                                else
                                {
                                    dtAdditionalRules.Rows[item.ItemIndex][2] = "false";
                                }
                            }
                        }

                        objBEExamProvider.dtResult_Rules = dtAdditionalRules;

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

                        //objBEExamProvider.DtResult1 = (DataTable)ViewState["SPECIALRULE"];
                        objBEExamProvider.DtResult1 = objDTSpecial;
                        objBEExamProvider.intExamFeePaidBy = Convert.ToInt32(ddlExamFeePaidBy.SelectedValue.ToString());
                        objBEExamProvider.intOnDemandFeePaidBy = Convert.ToInt32(ddlOnDemandFeePaidBy.SelectedValue.ToString());
                        //objBExamProvider.BSaveExamDetails(objBEExamProvider);
                        objBExamProvider.BUpdateExamDetails(objBEExamProvider);

                        trEditExam.Visible = false;
                        trEditExamConfirm.Visible = true;

                        gvViewStandard.DataSource = objBEExamProvider.DsResult.Tables[0];
                        gvViewStandard.DataBind();
                        gvViewAdditional.DataSource = objBEExamProvider.DsResult.Tables[1];
                        gvViewAdditional.DataBind();
                        gvViewSpecial.DataSource = objBEExamProvider.DsResult.Tables[2];
                        gvViewSpecial.DataBind();
                        BECommon objBECommon = new BECommon();
                        BCommon objBCommon = new BCommon();
                        objBECommon.iID = Convert.ToInt32(Request.QueryString["ExamID"].ToString());
                        objBCommon.BGetExamUploadFiles(objBECommon);

                        if (objBECommon.DsResult != null && objBECommon.DsResult.Tables.Count > 0 && objBECommon.DsResult.Tables[0].Rows.Count > 0)
                        {
                            gvFilesUploaded.DataSource = objBECommon.DsResult.Tables[0];
                            gvFilesUploaded.DataBind();

                        }
                        else
                        {
                            gvFilesUploaded.DataSource = new string[] { };
                            gvFilesUploaded.DataBind();

                        }

                        trMessage.Visible = true;
                        lblInfo.Text = Resources.AppMessages.Provider_EditExam_Success_EditExam;
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
                lblInfo.Text = Resources.AppMessages.Provider_EditExam_Error_ExamError;
                lblInfo.ForeColor = System.Drawing.Color.FromName(Resources.AppConfigurations.Color_Error);
                ImgInfo.ImageUrl = Resources.AppConfigurations.Image_Error;
                tdInfo.Attributes.Add("style", Resources.AppConfigurations.Color_Table_Error);
                trEditExam.Visible = true;
                trEditExamConfirm.Visible = false;
            }
        }


        #endregion
        #region BindProviderSecurityLevel
        protected void BindProviderSecurityLevel()
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
        protected void ddlSecurityLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            BEProvider objBEProvider = new BEProvider();
            BProvider objBProvider = new BProvider();
            objBEProvider.ddlSecurityLevel = Convert.ToInt32(ddlSecurityLevel.SelectedValue);
            objBProvider.BGetSelectedSecurityLevel(objBEProvider);
            lblLevelDesc.Text = objBEProvider.StrResult;
            lblLevelDesc.Visible = true;
        }
        #endregion
        #region FileFunctins




        protected void lnkUpload_Click(Object sender, EventArgs e)
        {
            this.openFileForUpload();
        }

        protected void openFileForUpload()
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

        /*
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (taRules.InnerText != null && taRules.InnerText != "" &&taRules.InnerText.Count()!=0)
            {
                Telerik.Web.UI.RadListBoxItem item = new Telerik.Web.UI.RadListBoxItem();
                item.Text = taRules.InnerText;
                item.Value = DateTime.Now.ToString("yyyyMMddHHmmss");
                rdRulesDestination.Items.Add(item);
                taRules.InnerText = string.Empty;
            }
        }

        protected void btnProctorNotes_Click(object sender, EventArgs e)
        {
            if (taProctorNotes.InnerText != null && taProctorNotes.InnerText != ""  && taProctorNotes.InnerText.Count() != 0)
            {
                Telerik.Web.UI.RadListBoxItem item = new Telerik.Web.UI.RadListBoxItem();
                item.Text = taProctorNotes.InnerText;
                item.Value = DateTime.Now.ToString("yyyyMMddHHmmss");

                RadListBoxDestination.Items.Add(item);
                taProctorNotes.InnerText = string.Empty;
            }
        }
        */

        #endregion

        protected void ddlSpecialNeeds_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(ddlSpecialNeeds.SelectedValue.ToString()))
            {
                if (ddlSpecialNeeds.SelectedValue.ToString() == "1")
                {
                    pnlInfo.Visible = true;
                }
                else
                {
                    pnlInfo.Visible = false;
                }
            }
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

            //if (e.CommandName == "DELETE")
            //{

            //    DeleteSpecialInstruction(Convert.ToInt32(e.CommandArgument));
            //}

        }

        public DataTable getRulesDataTable(System.Data.DataTable objDt)
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
                if (objDt == null)
                    objDt = getSpecialRulesDataTable();
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

                //BECommon objBECommon = new BECommon();
                //BCommon objBCommon = new BCommon();
                //objBECommon.IntExamID = Convert.ToInt32(Request.QueryString["ExamID"].ToString());
                //objBECommon.StrRuleDesc = taAdditionalRules.InnerText.ToString();
                //if (chkStudent.Checked == true)
                //{
                //    objBECommon.intRoleTypeID = 6;
                //}
                //else if (chkProctor.Checked == true)
                //{
                //    objBECommon.intRoleTypeID = 5;
                //}
                //if (chkStudentAndProctor.Checked == true)
                //{
                //    objBECommon.intRoleTypeID = 1;
                //}
                //objBCommon.BAddSpecialInstruction(objBECommon);


                //gvSpecial.DataSource = objBECommon.DsResult.Tables[0];
                //gvSpecial.DataBind();

                //taAdditionalRules.InnerHtml = string.Empty;

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

        protected void gvSpecial_EditCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName == "EDIT")
            {
                DataTable objDT = (DataTable)ViewState["SPECIALRULE"];
                gvSpecial.DataSource = objDT;
                gvSpecial.DataBind();
                // this.BindSpecialInstructions();
            }
        }

        protected void gvSpecial_CancelCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName.ToString().ToUpper() == "CANCEL")
            {
                DataTable objDT = (DataTable)ViewState["SPECIALRULE"];
                gvSpecial.DataSource = objDT;
                gvSpecial.DataBind();
                //this.BindSpecialInstructions();

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

        protected void imgDelete_Click(object sender, ImageClickEventArgs e)
        {
            string StoredFileName = ((ImageButton)sender).CommandArgument;
            DeleteProviderUploadedFile(StoredFileName);
        }

        protected void DeleteProviderUploadedFile(string filename)
        {
            try
            {
                if (ViewState["UploadedFiles"] != null)
                {

                    DataTable DT = (DataTable)ViewState["UploadedFiles"];

                    for (int i = 0; i <= DT.Rows.Count; i++)
                    {
                        if (DT.Rows[i][0].ToString() == filename)
                        {

                            DT.Rows[i][2] = "true";
                            ViewState["UploadedFiles"] = DT;

                            break;
                        }


                    }

                    gvUploadFiles.DataSource = DT.Select("status='false'");
                    gvUploadFiles.DataBind();

                }


            }
            catch (Exception )
            {

            }
        }

        public DataTable getdeletefilesDataTable(System.Data.DataTable objDt)
        {
            DataTable objDT = new DataTable();
            DataColumn objDC;
            objDC = new DataColumn("StoredFileName");
            objDT.Columns.Add(objDC);
            objDC = new DataColumn("OriginalFileName");
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


        public void DeleteFiles()
        {
            if (ViewState["UploadedFiles"] != null)
            {
                DataTable dt = (DataTable)(ViewState["UploadedFiles"]);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i][2].ToString() == "true")
                    {
                        BEProvider objBEExamProvider = new BEProvider();
                        BProvider objBExamProvider = new BProvider();
                        objBEExamProvider.IntExamID = Convert.ToInt32(Request.QueryString["ExamID"].ToString());
                        objBEExamProvider.strOriginalFileName = dt.Rows[i][0].ToString();

                        System.IO.FileInfo objFileName = new System.IO.FileInfo(Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["ProviderUploadPath"]) + "\\" + dt.Rows[i][0].ToString());

                        if (objFileName.Exists)
                        {
                            objFileName.Delete();
                            objBExamProvider.BDeleteUploadFiles(objBEExamProvider);
                        }


                    }



                }



            }




        }

        public void DeleteSpecialInstruction(int RuleID)
        {
            BECommon objBECommon = new BECommon();
            BCommon objBCommon = new BCommon();
            objBECommon.intRuleID = RuleID;
            objBECommon.IntExamID = Convert.ToInt32(Request.QueryString["ExamID"].ToString());
            objBCommon.BDeleteRule(objBECommon);

            gvSpecial.DataSource = objBECommon.DsResult.Tables[0];
            gvSpecial.DataBind();



        }


        public void BindSpecialInstructions()
        {

            BECommon objBECommon = new BECommon();
            BCommon objBCommon = new BCommon();
            objBECommon.IntExamID = Convert.ToInt32(Request.QueryString["ExamID"].ToString());
            objBCommon.BGetSpecialInstructions(objBECommon);
            gvSpecial.DataSource = objBECommon.DsResult.Tables[0];
            gvSpecial.DataBind();


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
                    lblNoExam.Visible = false;
                    rcbCourses.Visible = false;
                    ddlExams.Visible = false;
                    lblNoExams.Visible = false;
                    lblNoSpRules.Visible = false;

                    // removing special and additional rules of previosuly selected exam if no is selected.
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
                        DataTable dts = (DataTable)ViewState["ADDITIONALRULE_OLD"];
                        ViewState["ADDITIONALRULE"] = dts;
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
            objBEAdmin.IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID]);
            objBAdmin.BProviderGetCoursesBySplIns(objBEAdmin);
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
                   
                    ddlExams.Visible = true;
                    lblNoExam.Visible = false;
                    lblNoExams.Visible = false;
                    ddlExams.Items.Clear();
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
            // deleting previously selcted exam special instructions
            if (ViewState["Exam_Old"] != null && ViewState["Exam_Old"].ToString() != ddlExams.SelectedValue)
            {
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
                }
                //Additional rules deletion
                DataTable dtAdditional = (DataTable)ViewState["ADDITIONALRULE_OLD"];
                ViewState["ADDITIONALRULE"] = dtAdditional;
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

                DataTable dtPast1 = new DataTable();
                dtPast1 = ViewState["SPECIALRULE"] as DataTable;
                if (dtPast1 == null)
                {
                    dtPast1 = getSpecialRulesDataTable();
                    ViewState["SPECIALRULE"] = dtPast1;
                }

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

                lblNoSpRules.Visible = false;
            }
            else
            {
                // if no is selected remove previosuly selected exam special rules
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
                DataTable objDt_V = (DataTable)ViewState["ADDITIONALRULE"];
                DataTable objDt_V1 = objDt_V.Copy();
                DataTable objDt = objBEExamProvider.DsResult.Tables[0];
                DataRow[] DrArrCheck = objDt.Select("Status = true");
                foreach (DataRow DrCheck in DrArrCheck)
                {
                    foreach (DataRow DrCheck1 in objDt_V1.Rows)
                    {
                        if (DrCheck1["RuleId"].ToString() == DrCheck["RuleId"].ToString())
                        {
                            DrCheck1["Status"] = DrCheck["Status"].ToString();
                            objDt_V1.AcceptChanges();
                        }
                    }
                }
                gvAllowed.DataSource = objDt_V1;
                gvAllowed.DataBind();

                ViewState["ADDITIONALRULE"] = objDt_V1;

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