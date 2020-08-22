using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessEntities;
using BLL;
using Telerik.Web.UI;
using System.Data;

namespace SecureProctor.Admin
{
    public partial class CourseExamDetails : BaseClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Page.Title = EnumPageTitles.APPNAME + EnumPageTitles.ADMIN_VIEWCOURSE;
            ((LinkButton)this.Page.Master.FindControl("lnkCourses")).CssClass = "main_menu_active";

            if (Request.QueryString["Type"] != null)
            {
                if (Request.QueryString["Type"] == "C")
                {
                    trCourse.Visible = true;
                    trExam.Visible = false;
                }
                else if (Request.QueryString["Type"] == "E")
                {
                    trCourse.Visible = false;
                    trExam.Visible = true;
                }
            }

            //if (!IsPostBack)
            //{
            if (trCourse.Visible == true)
            {
                BindProviderNames();
                LoadDataTable();

            }
            else if (trExam.Visible == true)
            {
                BindExamDetails();
                BindExistingExamDetails();
            }
            //}
        }

        protected void BindExamDetails()
        {
            DataTable dtHrs = GetHrsTable();
            DataTable dtMin = GetMinTable();
            if (Session["EP_Exam"] != null)
            {
                BEProvider objBEExamProvider = (BEProvider)Session["EP_Exam"];
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
                if (objBEExamProvider.intCalc.ToString() == "1")
                {
                    chkCalc.Checked = true;
                }
                else
                {
                    chkCalc.Checked = false;
                }
                if (objBEExamProvider.intStickyNotes.ToString() == "1")
                {
                    chkStickynotes.Checked = true;
                }
                else
                {
                    chkStickynotes.Checked = false;
                }
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

            BEAdmin objBEAdmin = new BEAdmin();

            BAdmin objBAdmin = new BAdmin();
            objBAdmin.BAdminBindCourse(objBEAdmin);
            if (objBEAdmin.DtResult != null & objBEAdmin.DtResult.Rows.Count > 0)
            {
                ddlCourse.DataSource = objBEAdmin.DtResult;
                ddlCourse.DataTextField = "CourseName";
                ddlCourse.DataValueField = "CourseID";
                ddlCourse.DataBind();
            }
        }

        protected void gvCourseStatus_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            try
            {
                this.LoadDataTable();
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        protected void LoadDataTable()
        {
            BEAdmin objBEAdmin = new BEAdmin();
            BAdmin objBAdmin = new BAdmin();
            objBEAdmin.IntCourseID = 0;
            objBAdmin.BGetCourseDetails(objBEAdmin);

            if (objBEAdmin.DtResult != null && objBEAdmin.DtResult.Rows.Count > 0)
            {
                gvCourseStatus.DataSource = objBEAdmin.DtResult;
            }
            else
            {
                gvCourseStatus.DataSource = new string[] { };
            }
        }

        protected void gvCourseStatus_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName.ToString() == "EditCourse")
            {
                string courseprov = e.CommandArgument.ToString();
                if (courseprov.Contains(','))
                {
                    string[] cpid = courseprov.Split(',');
                    Response.Redirect("EditCourseDetails.aspx?CourseID=" + AppSecurity.Encrypt(cpid[0]) + "&ExamProviderID=" + AppSecurity.Encrypt(cpid[1]) + "");
                }
            }
        }

        protected void BindProviderNames()
        {
            BECommon objBECommon = new BECommon();
            new BCommon().BindProviderNames(objBECommon);
            if (objBECommon.DtResult.Rows.Count > 0)
            {
                ddlprovider.AppendDataBoundItems = true;
                ddlprovider.Items.Add(new RadComboBoxItem("--Select Instructor--", "-1"));
                ddlprovider.DataSource = objBECommon.DtResult;
                ddlprovider.DataTextField = "Name";
                ddlprovider.DataValueField = "ExamProviderID";
                ddlprovider.DataBind();
            }
            else
            {
                ddlprovider.Items.Clear();
                ddlprovider.AppendDataBoundItems = true;
                ddlprovider.Items.Add(new RadComboBoxItem("--Select Instructor--", "-1"));
                ddlprovider.DataSource = null;
                ddlprovider.DataBind();
            }
        }

        protected void BtnSaveCourse_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                BEAdmin objBEAdmin = new BEAdmin();
                BAdmin objBAdmin = new BAdmin();
                objBEAdmin.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID].ToString());
                //objBEExamProvider.IntCourseID = Convert.ToInt32(AppSecurity.Decrypt(Request.QueryString["CourseID"]));
                objBEAdmin.strCourseID = txtCourseID.Text;
                objBEAdmin.strCourseName = txtCourseName.Text;
                objBEAdmin.IntProviderID = Convert.ToInt32(ddlprovider.SelectedValue);
                objBAdmin.BSaveCourseDetails(objBEAdmin);
                if (objBEAdmin.DsResult.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToInt32(objBEAdmin.DsResult.Tables[0].Rows[0][0]) == 1)
                    {
                        lblSuccess.Text = Resources.ResMessages.Provider_CourseSuccess;
                        lblSuccess.Visible = true;
                        lblSuccess.ForeColor = System.Drawing.Color.Green;
                        txtCourseID.Text = string.Empty;
                        txtCourseName.Text = string.Empty;
                        ddlprovider.SelectedIndex = 0;
                        gvCourseStatus.Rebind();
                    }
                    else
                    {
                        lblSuccess.Text = Resources.ResMessages.Provider_CourseExists;
                        lblSuccess.ForeColor = System.Drawing.Color.Red;
                        lblSuccess.Visible = true;
                    }
                    //LoadDataTable();
                }
            }
        }

        protected void BtnClear_Click(object sender, EventArgs e)
        {
            txtCourseID.Text = string.Empty;
            txtCourseName.Text = string.Empty;
            ddlprovider.SelectedIndex = 0;
            lblSuccess.Text = string.Empty;
        }

        protected void lnkExam_Click(object sender, EventArgs e)
        {
            trExam.Visible = true;
            trCourse.Visible = false;
            BindExamDetails();
        }

        protected void lnkCourse_Click(object sender, EventArgs e)
        {
            trExam.Visible = false;
            trCourse.Visible = true;
            BindProviderNames();
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
            for (int i = 2; i <= 59; i = i + 2)
            {
                dr = dtMin.NewRow();
                dr["Min"] = i.ToString("D2");
                dtMin.Rows.Add(dr);
            }
            dtMin.AcceptChanges();
            return dtMin;
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

        protected void BindExistingExamDetails()
        {
            try
            {
                BEAdmin objBEAdmin = new BEAdmin();
                BAdmin objBAdmin = new BAdmin();

                objBAdmin.BGetExistingExamDetails(objBEAdmin);
                gvExamDetails.DataSource = objBEAdmin.DtResult;
                gvExamDetails.Rebind();
            }
            catch (Exception Ex)
            {

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
                    BEProvider objBEExamProvider = new BEProvider();
                    BProvider objBExamProvider = new BProvider();
                    objBEExamProvider.strCourseName = ddlCourse.SelectedItem.Text;
                    objBEExamProvider.IntCourseID = Convert.ToInt32(ddlCourse.SelectedItem.Value.ToString());
                    objBEExamProvider.strExamName = txtExam.Text.Trim();
                    objBEExamProvider.ddlHours = Convert.ToDecimal(ddlHours.SelectedValue);
                    objBEExamProvider.ddlMinutes = Convert.ToDecimal(ddlMinutes.SelectedValue);
                    objBEExamProvider.ddlHM = objBEExamProvider.ddlHours.ToString() + '.' + objBEExamProvider.ddlMinutes.ToString();
                    objBEExamProvider.IntBufferTime = Convert.ToInt32(ddlBufferTime.SelectedValue);
                    objBEExamProvider.strLinkAccessExam = txtAccessExam.InnerText;
                    objBEExamProvider.strExamStartDate = Convert.ToDateTime(CalendarExtender1.SelectedDate.ToString());
                    objBEExamProvider.strExamEndDate = Convert.ToDateTime(CalendarExtender2.SelectedDate.ToString());
                    objBEExamProvider.strOpenBook = 1;
                    //  objBEExamProvider.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID].ToString());
                    objBExamProvider.BAdminValidateExam(objBEExamProvider);
                    if (upFile.HasFile)
                    {
                        string strpath = Server.MapPath("../Provider/Provider_Uploads");
                        //string strpath = Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["ProviderUploads"]);
                        string strOriginalFileName = upFile.FileName;
                        string strUploadFileName= CommonFunctions.generateUploadFileName(upFile.FileName);
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
                    if (chkCalc.Checked == true)
                        objBEExamProvider.intCalc = 1;
                    else
                        objBEExamProvider.intCalc = 0;
                    if (chkStickynotes.Checked == true)
                        objBEExamProvider.intStickyNotes = 1;
                    else
                        objBEExamProvider.intStickyNotes = 0;
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
    }
}