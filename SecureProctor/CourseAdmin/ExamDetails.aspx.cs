using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessEntities;
using BLL;
using System.Data;

namespace SecureProctor.CourseAdmin
{
    public partial class ExamDetails : BaseClass
    {
        #region Events

        protected void DateTimeComparision_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Convert.ToDateTime(CalendarExtender1) < Convert.ToDateTime(CalendarExtender2);
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            Page.MaintainScrollPositionOnPostBack = true;
            this.Page.Title = EnumPageTitles.APPNAME + EnumPageTitles.EXAMPROVIDER_EXAMDETAILS;
            //((LinkButton)this.Page.Master.FindControl("lnkExamDetails")).CssClass = "main_menu_active";
            ((LinkButton)this.Page.Master.FindControl("lnkCourseDetails")).CssClass = "main_menu_active";
            if (!IsPostBack)
            {

                DataTable dtHrs = GetHrsTable();
                DataTable dtMin = GetMinTable();
                if (Session["EP_Exam"] != null)
                {
                    BECourseAdmin objBEExamProvider = (BECourseAdmin)Session["EP_Exam"];
                    // txtCourse.Text = objBEExamProvider.strCourseName;
                    txtExam.Text = objBEExamProvider.strExamName;

                    ddlHours.DataSource = dtHrs;
                    ddlHours.DataTextField = "Hrs";
                    ddlHours.DataValueField = "Hrs";
                    ddlHours.DataBind();
                    string dlhours = "";
                    if (objBEExamProvider.ddlHours.ToString().Length < 2)
                    {
                        dlhours = "0" + objBEExamProvider.ddlHours.ToString();
                    }
                    else
                    {
                        dlhours = objBEExamProvider.ddlHours.ToString();
                    }
                    ddlHours.Items.FindItemByText(dlhours).Selected = true;
                    //
                    ddlMinutes.DataSource = dtMin;
                    ddlMinutes.DataTextField = "Min";
                    ddlMinutes.DataValueField = "Min";
                    ddlMinutes.DataBind();
                    string dlmin = "";
                    if (objBEExamProvider.ddlMinutes.ToString().Length < 2)
                    {
                        dlmin = "0" + objBEExamProvider.ddlMinutes.ToString();
                    }
                    else
                    {
                        dlmin = objBEExamProvider.ddlMinutes.ToString();
                    }
                    ddlMinutes.Items.FindItemByText(dlmin).Selected = true;
                    //lblHours.Text = objBEExamProvider.ddlHours.ToString();
                    //lblMinutes.Text = objBEExamProvider.ddlMinutes.ToString();
                    // lblDuration.Text = objBEExamProvider.ddlHM.ToString();
                    ddlBufferTime.DataSource = dtMin;
                    ddlBufferTime.DataTextField = "Min";
                    ddlBufferTime.DataValueField = "Min";
                    ddlBufferTime.DataBind();
                    string ddlbuffer = "";
                    if (objBEExamProvider.IntBufferTime.ToString().Length < 2)
                    {
                        ddlbuffer = "0" + objBEExamProvider.IntBufferTime.ToString();
                    }
                    else
                    {
                        ddlbuffer = objBEExamProvider.IntBufferTime.ToString();
                    }
                    ddlBufferTime.Items.FindItemByText(ddlbuffer).Selected = true;

                    txtAccessExam.InnerText = objBEExamProvider.strLinkAccessExam;
                    CalendarExtender1.SelectedDate = Convert.ToDateTime(objBEExamProvider.strExamStartDate.ToShortDateString());
                    CalendarExtender2.SelectedDate = Convert.ToDateTime(objBEExamProvider.strExamEndDate.ToShortDateString());
                    //if (objBEExamProvider.intCalc.ToString() == "1")
                    //{
                    //    chkCalc.Checked = true;
                    //}
                    //else
                    //{
                    //    chkCalc.Checked = false;
                    //}
                    //if (objBEExamProvider.intStickyNotes.ToString() == "1")
                    //{
                    //    chkStickynotes.Checked = true;
                    //}
                    //else
                    //{
                    //    chkStickynotes.Checked = false;
                    //}
                }
                Session["DT_Notes"] = null;
                Session["DT_Rules"] = null;
                //Session["EP_Exam"] = null;
                //DataTable dtHrs = GetHrsTable();
                //DataTable dtMin = GetMinTable();
                ddlHours.DataSource = dtHrs;
                ddlHours.DataTextField = "Hrs";
                ddlHours.DataValueField = "Hrs";
                ddlHours.DataBind();
                //
                ddlMinutes.DataSource = dtMin;
                ddlMinutes.DataTextField = "Min";
                ddlMinutes.DataValueField = "Min";
                ddlMinutes.DataBind();

                ddlBufferTime.DataSource = dtMin;
                ddlBufferTime.DataTextField = "Min";
                ddlBufferTime.DataValueField = "Min";
                ddlBufferTime.DataBind();

                BECommon objBECommon = new BECommon();
                objBECommon.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID].ToString());
                BCommon objBCommon = new BCommon();
                objBCommon.BBindCourse(objBECommon);
                if (objBECommon.DtResult != null & objBECommon.DtResult.Rows.Count > 0)
                {
                    ddlCourse.DataSource = objBECommon.DtResult;
                    ddlCourse.DataTextField = "CourseName";
                    ddlCourse.DataValueField = "CourseID";
                    ddlCourse.DataBind();
                }
                objBCommon.BBindSecurityLevel(objBECommon);
                if (objBECommon.DtResult != null & objBECommon.DtResult.Rows.Count > 0)
                {
                    ddlExamSecurity.DataSource = objBECommon.DtResult;
                    ddlExamSecurity.DataTextField = "Security Description";
                    ddlExamSecurity.DataValueField = "SecurityLevel";
                    ddlExamSecurity.DataBind();
                }
                objBCommon.BBindAllTools(objBECommon);
                if (objBECommon.DtResult != null & objBECommon.DtResult.Rows.Count > 0)
                {
                    RadListBoxSource.DataSource = objBECommon.DtResult;
                    RadListBoxSource.DataTextField = "ToolName";
                    RadListBoxSource.DataValueField = "ToolID";
                    RadListBoxSource.DataBind();
                }


            }
        }

        protected void gvNotes_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            try
            {
                if (Session["DT_Notes"] != null)
                {
                    gvNotes.DataSource = (DataTable)Session["DT_Notes"];
                }
                else
                {
                    gvNotes.DataSource = new string[] { };
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        protected void BtnAddNotes_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                DataTable objDT;
                DataRow objDR;
                if (Session["DT_Notes"] == null)
                {
                    objDT = CommonFunctions.getExamDataTable();
                    objDR = objDT.NewRow();
                    objDR[0] = "0";
                    objDR[1] = "Note 1";
                    objDR[2] = txtNotes.Text.Trim().ToString();
                    objDT.Rows.Add(objDR);
                    Session["DT_Notes"] = objDT;
                }
                else
                {
                    objDT = (DataTable)Session["DT_Notes"];
                    objDR = objDT.NewRow();
                    objDR[0] = objDT.Rows.Count.ToString();
                    objDR[1] = "Note " + (objDT.Rows.Count + 1).ToString();
                    objDR[2] = txtNotes.Text.Trim().ToString();
                    objDT.Rows.Add(objDR);
                    Session["DT_Notes"] = objDT;
                }
                txtNotes.Text = string.Empty;
                gvNotes.Rebind();
            }
        }

        protected void BtnClearNotes_Click(object sender, EventArgs e)
        {
            txtNotes.Text = string.Empty;
        }

        protected void gvRules_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            try
            {
                if (Session["DT_Rules"] != null)
                {
                    gvRules.DataSource = (DataTable)Session["DT_Rules"];
                }
                else
                {
                    gvRules.DataSource = new string[] { };
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        protected void BtnAddRules_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                DataTable objDT;
                DataRow objDR;
                if (Session["DT_Rules"] == null)
                {
                    objDT = CommonFunctions.getExamDataTable();
                    objDR = objDT.NewRow();
                    objDR[0] = "0";
                    objDR[1] = "Rule 1";
                    objDR[2] = txtRules.Text.Trim().ToString();
                    objDT.Rows.Add(objDR);
                    Session["DT_Rules"] = objDT;
                }
                else
                {
                    objDT = (DataTable)Session["DT_Rules"];
                    objDR = objDT.NewRow();
                    objDR[0] = objDT.Rows.Count.ToString();
                    objDR[1] = "Rule " + (objDT.Rows.Count + 1).ToString();
                    objDR[2] = txtRules.Text.Trim().ToString();
                    objDT.Rows.Add(objDR);
                    Session["DT_Rules"] = objDT;
                }
                txtRules.Text = string.Empty;
                gvRules.Rebind();
            }
        }

        protected void BtnClearRules_Click(object sender, EventArgs e)
        {
            txtRules.Text = string.Empty;
        }

        protected void gvNotes_UpdateCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName == "Update")
            {
                Telerik.Web.UI.RadTextBox txt = (Telerik.Web.UI.RadTextBox)e.Item.FindControl("txtNotesDescription");
                DataTable objDT;
                objDT = (DataTable)Session["DT_Notes"];
                Session["DT_Notes"] = setValue(objDT, e.CommandArgument.ToString(), txt.Text.Trim().ToString());
                gvNotes.Rebind();
            }
        }

        protected void gvNotes_DeleteCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                string strID = e.CommandArgument.ToString();
                DataTable objDT;
                if (Session["DT_Notes"] != null)
                {
                    objDT = (DataTable)Session["DT_Notes"];
                    for (int i = 0; i < objDT.Rows.Count; i++)
                    {
                        if (objDT.Rows[i][0].ToString() == strID)
                        {
                            objDT.Rows.Remove(objDT.Rows[i]);
                            objDT.AcceptChanges();
                            break;
                        }
                    }
                    for (int i = 0; i < objDT.Rows.Count; i++)
                    {
                        objDT.Rows[i][0] = i.ToString();
                        objDT.Rows[i][1] = "Note " + (i + 1).ToString();
                    }
                    Session["DT_Notes"] = objDT;
                    gvNotes.Rebind();
                }
            }
        }

        protected void gvRules_UpdateCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName == "Update")
            {
                Telerik.Web.UI.RadTextBox txt = (Telerik.Web.UI.RadTextBox)e.Item.FindControl("txtRuleDescription");
                DataTable objDT;
                objDT = (DataTable)Session["DT_Rules"];
                Session["DT_Rules"] = setValue(objDT, e.CommandArgument.ToString(), txt.Text.Trim().ToString());
                gvRules.Rebind();
            }
        }

        protected void gvRules_DeleteCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                string strID = e.CommandArgument.ToString();
                DataTable objDT;
                if (Session["DT_Rules"] != null)
                {
                    objDT = (DataTable)Session["DT_Rules"];
                    for (int i = 0; i < objDT.Rows.Count; i++)
                    {
                        if (objDT.Rows[i][0].ToString() == strID)
                        {
                            objDT.Rows.Remove(objDT.Rows[i]);
                            objDT.AcceptChanges();
                            break;
                        }
                    }
                    for (int i = 0; i < objDT.Rows.Count; i++)
                    {
                        objDT.Rows[i][0] = i.ToString();
                        objDT.Rows[i][1] = "Note " + (i + 1).ToString();
                    }
                    Session["DT_Rules"] = objDT;
                    gvRules.Rebind();
                }
            }
        }

        protected void gvExamDetails_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            try
            {
                BindExistingExamDetails();
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        protected void gvExamDetails_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName.ToString() == "EditExam")
                Response.Redirect("ViewExamDetails.aspx?ExamID=" + AppSecurity.Encrypt(e.CommandArgument.ToString()) + "&Type=Edit");
            else if (e.CommandName.ToString() == "ViewExam")
                Response.Redirect("ViewExamDetails.aspx?ExamID=" + AppSecurity.Encrypt(e.CommandArgument.ToString()) + "&Type=View");
            else if (e.CommandName.ToString() == "DeleteExam")
                Response.Redirect("ViewExamDetails.aspx?ExamID=" + AppSecurity.Encrypt(e.CommandArgument.ToString()) + "&Type=Delete");
        }

        protected void BtnSaveExam_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    BECourseAdmin objBEExamProvider = new BECourseAdmin();
                    BCourseAdmin objBExamProvider = new BCourseAdmin();
                    objBEExamProvider.strCourseName = ddlCourse.SelectedItem.Text;
                    objBEExamProvider.IntCourseID = Convert.ToInt32(ddlCourse.SelectedItem.Value.ToString());
                    objBEExamProvider.strSecurityLevel = ddlExamSecurity.SelectedItem.Value.ToString();

                    objBEExamProvider.strSecurityLevel1 = ddlExamSecurity.SelectedItem.Text;
                    objBEExamProvider.strExamName = txtExam.Text.Trim();
                    objBEExamProvider.ddlHours = Convert.ToDecimal(ddlHours.SelectedValue);
                    objBEExamProvider.ddlMinutes = Convert.ToDecimal(ddlMinutes.SelectedValue);
                    objBEExamProvider.ddlHM = objBEExamProvider.ddlHours.ToString() + '.' + objBEExamProvider.ddlMinutes.ToString();
                    objBEExamProvider.IntBufferTime = Convert.ToInt32(ddlBufferTime.SelectedValue);
                    objBEExamProvider.strLinkAccessExam = txtAccessExam.InnerText;
                    objBEExamProvider.strExamStartDate = Convert.ToDateTime(CalendarExtender1.SelectedDate.ToString());
                    objBEExamProvider.strExamEndDate = Convert.ToDateTime(CalendarExtender2.SelectedDate.ToString());
                    objBEExamProvider.strOpenBook = 1;
                    objBEExamProvider.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID].ToString());
                    objBExamProvider.BValidateExam(objBEExamProvider);
                    if (upFile.HasFile)
                    {
                        string strpath = Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["ProviderUploads"]);
                        string strOriginalFileName = upFile.FileName;
                        string strUploadFileName = CommonFunctions.generateUploadFileName(upFile.FileName);
                        string strTotalPath = strpath + '\\' + strUploadFileName;
                        objBEExamProvider.strOriginalFileName = strOriginalFileName;
                        objBEExamProvider.strUploadPath = strUploadFileName;
                        upFile.SaveAs(strTotalPath);



                    }

                    else
                    {
                        objBEExamProvider.strOriginalFileName = null;
                        objBEExamProvider.strUploadPath = null;
                    }
                    if (Session["DT_Notes"] != null)
                        objBEExamProvider.DtResult = (DataTable)Session["DT_Notes"];
                    if (Session["DT_Rules"] != null)
                        objBEExamProvider.DtResult1 = (DataTable)Session["DT_Rules"];

                    DataTable dt = new DataTable();
                    DataColumn dc;
                    dc = new DataColumn("ToolID");
                    dt.Columns.Add(dc);
                    dc = new DataColumn("ToolName");
                    dt.Columns.Add(dc);
                    if (RadListBoxDestination.Items.Count > 0)
                    {

                        for (int i = 0; i < RadListBoxDestination.Items.Count; i++)
                        {
                            DataRow dr = dt.NewRow();
                            dr[0] = RadListBoxDestination.Items[i].Value.ToString();
                            dr[1] = RadListBoxDestination.Items[i].Text;
                            dt.Rows.Add(dr);
                        }
                        objBEExamProvider.DtTools = dt;
                    }
                    else
                    {
                        objBEExamProvider.DtTools = dt;

                    }
                    //if (chkCalc.Checked == true)
                    //    objBEExamProvider.intCalc = 1;
                    //else
                    //    objBEExamProvider.intCalc = 0;
                    //if (chkStickynotes.Checked == true)
                    //    objBEExamProvider.intStickyNotes = 1;
                    //else
                    //    objBEExamProvider.intStickyNotes = 0;
                    if (objBEExamProvider.IntResult == 1)
                    {
                        //lblSuccess.Text = "Exam Name Already Exists";
                        lblSuccess.Text = Resources.ResMessages.Provider_ExamExists;
                    }
                    if (objBEExamProvider.IntResult == 0)
                    {
                        Session["EP_Exam"] = objBEExamProvider;
                        Response.Redirect("ExamConfirmationPage.aspx", false);
                    }
                    objBEExamProvider = null;
                    objBExamProvider = null;
                }
            }
            catch (Exception Ex)
            {

            }
        }

        protected void btnSaveImage_Click(object sender, EventArgs e)
        {



        }

        protected void lblCourseDetailslink_Click(object sender, EventArgs e)
        {
            //Response.Redirect("ProcessedExamRequests.aspx");
            Response.Redirect(BaseClass.EnumAppPage.PROVIDER_COURSEDETAILS);
        }

        #endregion

        #region Methods

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
            for (int i = 2; i <= 59; i = i + 2)
            {
                dr = dtMin.NewRow();
                dr["Min"] = i.ToString("D2");
                dtMin.Rows.Add(dr);
            }
            dtMin.AcceptChanges();
            return dtMin;
        }

        protected DataTable setValue(DataTable objDT, string id, string value)
        {
            for (int i = 0; i < objDT.Rows.Count; i++)
            {
                if (objDT.Rows[i][0].ToString() == id)
                {
                    objDT.Rows[i][2] = value;
                    break;
                }
            }
            return objDT;
        }

        protected void BindExistingExamDetails()
        {
            try
            {
                BECourseAdmin objBEExamProvider = new BECourseAdmin();
                BCourseAdmin objBExamProvider = new BCourseAdmin();
                objBEExamProvider.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID].ToString());
                objBEExamProvider.strCourseName = string.Empty; ;
                objBEExamProvider.strExamName = string.Empty; ;
                objBExamProvider.BGetExistingExamDetails(objBEExamProvider);
                gvExamDetails.DataSource = objBEExamProvider.DtResult;

            }
            catch (Exception Ex)
            {

            }
        }

        #endregion
    }
}