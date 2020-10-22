using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessEntities;
using BLL;
using System.Data;
using System.IO;

namespace SecureProctor.Admin
{
    public partial class ViewExamDetails : BaseClass

    {

        string strExamID = string.Empty;

        protected void DateTimeComparision_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Convert.ToDateTime(txtStartDate) < Convert.ToDateTime(txtEndDate);
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                Page.MaintainScrollPositionOnPostBack = true;
                //((LinkButton)this.Page.Master.FindControl("lnkExamDetails")).CssClass = "main_menu_active";
                ((LinkButton)this.Page.Master.FindControl("lnkCourses")).CssClass = "main_menu_active";
                txtEndDate.Attributes.Add("onkeydown", "return false;");
                txtEndDate.Attributes.Add("onpaste", "return false;");
                if (!IsPostBack)
                {
                    if (Request.QueryString != null && Request.QueryString.ToString() != "")
                    {

                        BEProvider objBEExamProvider = new BEProvider();
                        BProvider objBExamProvider = new BProvider();
                        objBEExamProvider.IntCourseID = Convert.ToInt32(AppSecurity.Decrypt(Request.QueryString["ExamID"].ToString()));
                        objBExamProvider.BViewExamDetails(objBEExamProvider);

                        BECommon objBECommon = new BECommon();
                        BCommon objBCommon = new BCommon();
                        objBCommon.BBindSecurityLevel(objBECommon);
                        if (objBECommon.DtResult != null & objBECommon.DtResult.Rows.Count > 0)
                        {
                            ddlExamSecurity.DataSource = objBECommon.DtResult;
                            ddlExamSecurity.DataTextField = "Security Description";
                            ddlExamSecurity.DataValueField = "SecurityLevel";
                            ddlExamSecurity.DataBind();
                        }

                        if (objBEExamProvider.DsResult != null)
                        {
                            if (objBEExamProvider.DsResult.Tables[0].Rows.Count > 0)
                            {
                                this.EnableDisable("Edit");
                                this.BindTimesDropDown();
                                string ExamDuration = objBEExamProvider.DsResult.Tables[0].Rows[0]["ExamDuration"].ToString();
                                string[] b = ExamDuration.Split('.');
                                if (Request.QueryString["Type"].ToString() == "Edit")
                                {
                                    this.Page.Title = EnumPageTitles.APPNAME + "Edit exam details";
                                    string Hour = string.Empty;
                                    if (Convert.ToInt32((b[0].ToString())) <= 9)

                                        Hour = "0" + b[0].ToString();

                                    else

                                        Hour = b[0].ToString();

                                    ddlHours.SelectedValue = Hour;
                                    ddlMinutes.SelectedValue = b[1].ToString();
                                    ddlBufferTime.SelectedValue = objBEExamProvider.DsResult.Tables[0].Rows[0]["ExamBufferTime"].ToString();
                                    txtExam.Text = objBEExamProvider.DsResult.Tables[0].Rows[0]["ExamName"].ToString();
                                    // txtCourse.Text = objBEExamProvider.DsResult.Tables[0].Rows[0]["CourseName"].ToString();
                                    lblCourseName.Text = objBEExamProvider.DsResult.Tables[0].Rows[0]["CourseName"].ToString();
                                    lblExamSecurity.Visible = false;
                                    ddlExamSecurity.Visible = true;
                                    ddlExamSecurity.SelectedValue = objBEExamProvider.DsResult.Tables[0].Rows[0]["ExamSecurity"].ToString();
                                    txtEndDate.SelectedDate = Convert.ToDateTime(objBEExamProvider.DsResult.Tables[0].Rows[0]["ExamEndDate"].ToString());
                                    txtAccessExam.InnerText= objBEExamProvider.DsResult.Tables[0].Rows[0]["ExamLink"].ToString();
                                    txtStartDate.SelectedDate = Convert.ToDateTime(objBEExamProvider.DsResult.Tables[0].Rows[0]["ExamStartDate"].ToString());
                                    lblFile.Text = CommonFunctions.CheckNullValue(objBEExamProvider.DsResult.Tables[0].Rows[0]["OriginalFileName"].ToString());
                                    // lnlFile.Text = objBEExamProvider.DsResult.Tables[0].Rows[0]["OriginalFileName"].ToString();

                                    if (objBEExamProvider.DsResult.Tables[0].Rows[0]["OriginalFileName"].ToString() != null && objBEExamProvider.DsResult.Tables[0].Rows[0]["OriginalFileName"].ToString() != "")
                                    {
                                        upFile.Visible = false;
                                        lnlFile.Visible = true;
                                        imgCancel.Visible = true;
                                        lnlFile.Text = objBEExamProvider.DsResult.Tables[0].Rows[0]["OriginalFileName"].ToString();

                                    }
                                    else
                                    {
                                        upFile.Visible = true;
                                        lnlFile.Visible = false;
                                        //lblFile.Visible = true;
                                        imgCancel.Visible = false;
                                        // lblFile.Text = "N/A";
                                    }
                                    Session["DT_Notes"] = objBEExamProvider.DsResult.Tables[1];
                                    Session["DT_Rules"] = objBEExamProvider.DsResult.Tables[2];
                                    if (objBEExamProvider.DsResult.Tables[3].Rows.Count > 0)
                                    {
                                        for (int i = 0; i < objBEExamProvider.DsResult.Tables[3].Rows.Count; i++)
                                        {
                                            if (objBEExamProvider.DsResult.Tables[3].Rows[i]["ToolID"].ToString() == "101")
                                                chkCalc.Checked = true;
                                            if (objBEExamProvider.DsResult.Tables[3].Rows[i]["ToolID"].ToString() == "102")
                                                chkStickynotes.Checked = true;
                                        }
                                    }

                                }
                                else if (Request.QueryString["Type"].ToString() == "View")
                                {
                                    upFile.Visible = false;
                                    this.Page.Title = EnumPageTitles.APPNAME + "View exam details";
                                    //  gvNotes.MasterTableView.GetColumn("Action").Visible = false; 

                                    //ImageButton imgNoteEdit=  gvNotes.FindControl("imgNoteEdit") as ImageButton;
                                    //imgNoteEdit.Visible = false;
                                    ////gvNotes.FindControl("imgNoteDelete").Visible = false;
                                    this.EnableDisable("View");
                                    if (b[0].ToString().Length < 2)
                                    {
                                        lblHours.Text = "0" + b[0].ToString();

                                    }
                                    else
                                    {
                                        lblHours.Text = b[0].ToString();
                                    }
                                    lblMinutes.Text = b[1].ToString();
                                    lblExamName.Text = objBEExamProvider.DsResult.Tables[0].Rows[0]["ExamName"].ToString();
                                    lblCourseName.Text = objBEExamProvider.DsResult.Tables[0].Rows[0]["CourseName"].ToString();
                                    if (objBEExamProvider.DsResult.Tables[0].Rows[0]["Security Description"] != DBNull.Value && objBEExamProvider.DsResult.Tables[0].Rows[0]["Security Description"].ToString() != "")
                                    {
                                        lblExamSecurity.Text = objBEExamProvider.DsResult.Tables[0].Rows[0]["Security Description"].ToString();
                                    }
                                    else
                                    {
                                        lblExamSecurity.Text = "N/A";
                                    }
                                    ddlExamSecurity.Visible = false;
                                    lblEndDate.Text = objBEExamProvider.DsResult.Tables[0].Rows[0]["ExamEndDate"].ToString();
                                    lblAccessExam.Text = objBEExamProvider.DsResult.Tables[0].Rows[0]["ExamLink"].ToString();
                                    lblStartDate.Text = objBEExamProvider.DsResult.Tables[0].Rows[0]["ExamStartDate"].ToString();
                                    //lnlFile.Text =CommonFunctions.CheckNullValue(objBEExamProvider.DsResult.Tables[0].Rows[0]["OriginalFileName"].ToString());
                                    if (objBEExamProvider.DsResult.Tables[0].Rows[0]["OriginalFileName"].ToString() != null && objBEExamProvider.DsResult.Tables[0].Rows[0]["OriginalFileName"].ToString() != "")
                                    {
                                        lnlFile.Visible = true;
                                        lblFile.Visible = false;
                                        lnlFile.Text = objBEExamProvider.DsResult.Tables[0].Rows[0]["OriginalFileName"].ToString();

                                    }
                                    else
                                    {
                                        lnlFile.Visible = false;
                                        lblFile.Visible = true;
                                        lblFile.Text = "N/A";
                                    }
                                    if (objBEExamProvider.DsResult.Tables[0].Rows[0]["ExamBufferTime"].ToString().Length < 2)
                                    {
                                        lblBufferTime.Text = "0" + objBEExamProvider.DsResult.Tables[0].Rows[0]["ExamBufferTime"].ToString();

                                    }

                                    else
                                    {

                                        lblBufferTime.Text = objBEExamProvider.DsResult.Tables[0].Rows[0]["ExamBufferTime"].ToString();
                                    }
                                    bool noTools = false;
                                    if (objBEExamProvider.DsResult.Tables[3].Rows.Count > 0)
                                    {
                                        noTools = true;
                                        for (int i = 0; i < objBEExamProvider.DsResult.Tables[3].Rows.Count; i++)
                                        {
                                            if (objBEExamProvider.DsResult.Tables[3].Rows[i]["ToolID"].ToString() == "101")
                                                imgCalc.Visible = true;
                                            if (objBEExamProvider.DsResult.Tables[3].Rows[i]["ToolID"].ToString() == "102")
                                                imgStickyNotes.Visible = true;
                                        }
                                    }
                                    if (noTools == false)
                                        lblTools.Visible = true;

                                    gvNotes.MasterTableView.GetColumn("Action").Visible = false;
                                    gvRules.MasterTableView.GetColumn("Action").Visible = false;
                                }
                                else if (Request.QueryString["Type"].ToString() == "Delete")
                                {
                                    upFile.Visible = false;
                                    lnlFile.Visible = true;
                                    this.Page.Title = EnumPageTitles.APPNAME + "Delete exam details";
                                    lblHead.Text = "This exam will be deleted. Please click Confirm to delete the exam OR Cancel to go back to Exam details page.";
                                    this.EnableDisable("Delete");
                                    if (b[0].ToString().Length < 2)
                                    {
                                        lblHours.Text = "0" + b[0].ToString();
                                    }
                                    else
                                    {

                                        lblHours.Text = b[0].ToString();
                                    }
                                    lblMinutes.Text = b[1].ToString();
                                    lblExamName.Text = objBEExamProvider.DsResult.Tables[0].Rows[0]["ExamName"].ToString();
                                    lblCourseName.Text = objBEExamProvider.DsResult.Tables[0].Rows[0]["CourseName"].ToString();
                                    if (objBEExamProvider.DsResult.Tables[0].Rows[0]["Security Description"] != DBNull.Value && objBEExamProvider.DsResult.Tables[0].Rows[0]["Security Description"].ToString() != "")
                                    {
                                        lblExamSecurity.Text = objBEExamProvider.DsResult.Tables[0].Rows[0]["Security Description"].ToString();
                                    }
                                    else
                                    {
                                        lblExamSecurity.Text = "N/A";
                                    }
                                    ddlExamSecurity.Visible = false;
                                    lblEndDate.Text = objBEExamProvider.DsResult.Tables[0].Rows[0]["ExamEndDate"].ToString();
                                    lblAccessExam.Text = objBEExamProvider.DsResult.Tables[0].Rows[0]["ExamLink"].ToString();
                                    lblStartDate.Text = objBEExamProvider.DsResult.Tables[0].Rows[0]["ExamStartDate"].ToString();
                                    if (objBEExamProvider.DsResult.Tables[0].Rows[0]["OriginalFileName"].ToString() != null && objBEExamProvider.DsResult.Tables[0].Rows[0]["OriginalFileName"].ToString() != "")
                                    {
                                        lnlFile.Visible = true;
                                        lblFile.Visible = false;
                                        lnlFile.Text = objBEExamProvider.DsResult.Tables[0].Rows[0]["OriginalFileName"].ToString();

                                    }
                                    else
                                    {
                                        lnlFile.Visible = false;
                                        lblFile.Visible = true;
                                        lblFile.Text = "N/A";
                                    }
                                    // lnlFile.Text =CommonFunctions.CheckNullValue(objBEExamProvider.DsResult.Tables[0].Rows[0]["OriginalFileName"].ToString());
                                    // lblFile.Text = objBEExamProvider.DsResult.Tables[0].Rows[0]["OriginalFileName"].ToString();
                                    //lblBufferTime.Text = objBEExamProvider.DsResult.Tables[0].Rows[0]["ExamBufferTime"].ToString();
                                    if (objBEExamProvider.DsResult.Tables[0].Rows[0]["ExamBufferTime"].ToString().Length < 2)
                                    {
                                        lblBufferTime.Text = "0" + objBEExamProvider.DsResult.Tables[0].Rows[0]["ExamBufferTime"].ToString();

                                    }

                                    else
                                    {

                                        lblBufferTime.Text = objBEExamProvider.DsResult.Tables[0].Rows[0]["ExamBufferTime"].ToString();
                                    }
                                    bool noTools = false;
                                    if (objBEExamProvider.DsResult.Tables[3].Rows.Count > 0)
                                    {
                                        noTools = true;
                                        for (int i = 0; i < objBEExamProvider.DsResult.Tables[3].Rows.Count; i++)
                                        {
                                            if (objBEExamProvider.DsResult.Tables[3].Rows[i]["ToolID"].ToString() == "101")
                                                imgCalc.Visible = true;
                                            if (objBEExamProvider.DsResult.Tables[3].Rows[i]["ToolID"].ToString() == "102")
                                                imgStickyNotes.Visible = true;
                                        }
                                    }
                                    if (noTools == false)
                                        lblTools.Visible = true;

                                    gvNotes.MasterTableView.GetColumn("Action").Visible = false;
                                    gvRules.MasterTableView.GetColumn("Action").Visible = false;
                                }

                                gvNotes.DataSource = objBEExamProvider.DsResult.Tables[1];
                                gvNotes.DataBind();
                                gvRules.DataSource = objBEExamProvider.DsResult.Tables[2];
                                gvRules.DataBind();
                            }
                        }

                    }
                }
            }
            catch (Exception )
            {

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
                string strpath = Server.MapPath("../Provider/Provider_Uploads");
                BEProvider objBEExamProvider = new BEProvider();
                BProvider objBExamProvider = new BProvider();
                objBEExamProvider.IntCourseID = Convert.ToInt32(AppSecurity.Decrypt(Request.QueryString["ExamID"].ToString()));
                objBExamProvider.BViewExamDetails(objBEExamProvider);
                if (objBEExamProvider.DsResult != null)
                {
                    if (objBEExamProvider.DsResult.Tables[0].Rows.Count > 0)
                    {

                        objBEExamProvider.strUploadPath = objBEExamProvider.DsResult.Tables[0].Rows[0]["StoredFileName"].ToString();

                        string strTotalPath = strpath + '\\' + objBEExamProvider.strUploadPath.ToString();
                        System.IO.FileInfo fi = new System.IO.FileInfo(strTotalPath);


                        fi.Delete();

                    }

                    else
                    {

                        upFile.Visible = true;
                        lnlFile.Visible = false;
                        imgCancel.Visible = false;

                    }

                }

                objBExamProvider.BDeleteUploadFiles(objBEExamProvider);
                if (objBEExamProvider.IntResult == 1)
                {
                    //lblFile.Visible = true;
                    // lblFile.Text = "N/A";
                    upFile.Visible = true;
                    lnlFile.Visible = false;
                    imgCancel.Visible = false;

                }




            }

            catch (Exception )
            {


            }

        }

        protected void lnlFile_Click(Object sender, EventArgs e)
        {

            this.openFile();

        }

        protected void openFile()
        {

            BEProvider objBEExamProvider = new BEProvider();
            BProvider objBExamProvider = new BProvider();
            objBEExamProvider.IntCourseID = Convert.ToInt32(AppSecurity.Decrypt(Request.QueryString["ExamID"].ToString()));
            objBExamProvider.BViewExamDetails(objBEExamProvider);
            if (objBEExamProvider.DsResult != null)
            {
                if (objBEExamProvider.DsResult.Tables[0].Rows.Count > 0)
                {


                    if (objBEExamProvider.DsResult.Tables[0].Rows[0]["StoredFileName"].ToString() != null && objBEExamProvider.DsResult.Tables[0].Rows[0]["StoredFileName"].ToString() != "")
                    {
                        string UploadedFile = objBEExamProvider.DsResult.Tables[0].Rows[0]["StoredFileName"].ToString();

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
                            //ScriptManager.RegisterStartupScript(this, this.GetType(), "NotSaved", "alert('File does not exist');", true);

                            Page.ClientScript.RegisterStartupScript(GetType(), "MyScript", "alert('File does not exist');", true);

                        }

                    }
                    else
                    {
                        lnlFile.Visible = false;
                        lblFile.Visible = true;
                        lblFile.Text = "N/A";
                    }

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

        protected void EnableDisable(string Type)
        {
            switch (Type)
            {
                case "Edit": trEditButton.Visible = true;
                    ddlHours.Visible = true;
                    ddlMinutes.Visible = true;
                    txtExam.Visible = true;
                    // txtCourse.Visible = true;
                    txtEndDate.Visible = true;
                    txtStartDate.Visible = true;
                    txtAccessExam.Visible = true;
                    ddlBufferTime.Visible = true;
                    lblHours.Visible = false;
                    lblMinutes.Visible = false;
                    lblExamName.Visible = false;
                    // lblCourseName.Visible = false;
                    lblEndDate.Visible = false;
                    lblAccessExam.Visible = false;
                    lblStartDate.Visible = false;
                    lblBufferTime.Visible = false;
                    trViewButton.Visible = false;
                    trDeleteButton.Visible = false;
                    trMessage.Visible = false;
                    lblTools.Visible = false;
                    trUpdateNotes.Visible = true;
                    trUpdateRules.Visible = true;
                    lblHead.Visible = false;
                    lblExamSecurity.Visible = false;
                    ddlExamSecurity.Visible = true;
                    break;
                case "View": trEditButton.Visible = false;
                    ddlHours.Visible = false;
                    ddlMinutes.Visible = false;
                    txtExam.Visible = false;
                    // txtCourse.Visible = false;
                    txtEndDate.Visible = false;
                    txtStartDate.Visible = false;
                    txtAccessExam.Visible = false;
                    ddlBufferTime.Visible = false;
                    lblHours.Visible = true;
                    lblMinutes.Visible = true;
                    lblExamName.Visible = true;
                    //lblCourseName.Visible = true;
                    lblEndDate.Visible = true;
                    lblAccessExam.Visible = true;
                    lblStartDate.Visible = true;
                    lblBufferTime.Visible = true;
                    trViewButton.Visible = true;
                    trDeleteButton.Visible = false;
                    trMessage.Visible = false;
                    chkCalc.Visible = false;
                    chkStickynotes.Visible = false;
                    imgCalc.Visible = false;
                    imgStickyNotes.Visible = false;
                    lblTools.Visible = false;
                    trUpdateNotes.Visible = false;
                    trUpdateRules.Visible = false;
                    lblHead.Visible = false;
                    lblExamSecurity.Visible = true;
                    ddlExamSecurity.Visible = false;
                    break;
                case "Delete": trEditButton.Visible = false;
                    ddlHours.Visible = false;
                    ddlMinutes.Visible = false;
                    txtExam.Visible = false;
                    //txtCourse.Visible = false;
                    txtEndDate.Visible = false;
                    txtStartDate.Visible = false;
                    txtAccessExam.Visible = false;
                    ddlBufferTime.Visible = false;
                    lblHours.Visible = true;
                    lblMinutes.Visible = true;
                    lblExamName.Visible = true;
                    //lblCourseName.Visible = true;
                    lblEndDate.Visible = true;
                    lblAccessExam.Visible = true;
                    lblStartDate.Visible = true;
                    lblBufferTime.Visible = true;
                    trViewButton.Visible = false;
                    trDeleteButton.Visible = true;
                    trMessage.Visible = false;
                    chkCalc.Visible = false;
                    chkStickynotes.Visible = false;
                    imgCalc.Visible = false;
                    imgStickyNotes.Visible = false;
                    lblTools.Visible = false;
                    trUpdateNotes.Visible = false;
                    trUpdateRules.Visible = false;
                    lblHead.Visible = true;
                    lblExamSecurity.Visible = true;
                    ddlExamSecurity.Visible = false;
                    break;




            }
        }
        protected void BindTimesDropDown()
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

            ddlBufferTime.DataSource = dtMin;
            ddlBufferTime.DataTextField = "Min";
            ddlBufferTime.DataValueField = "Min";
            ddlBufferTime.DataBind();
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






        protected void gvNotes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (Request.QueryString["Type"].ToString() == "View" || Request.QueryString["Type"].ToString() == "Delete")
            {
                ImageButton imgBtn = e.Row.FindControl("imgEdit") as ImageButton;
                if (null != imgBtn)
                    imgBtn.Enabled = false;
                ImageButton imgDelete = e.Row.FindControl("imgDelete") as ImageButton;
                if (null != imgDelete)
                    imgDelete.Enabled = false;
            }
        }

        protected void gvRules_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (Request.QueryString["Type"].ToString() == "View" || Request.QueryString["Type"].ToString() == "Delete")
            {
                ImageButton imgBtn = e.Row.FindControl("imgEdit") as ImageButton;
                if (null != imgBtn)
                    imgBtn.Enabled = false;
                ImageButton imgDelete = e.Row.FindControl("imgDelete") as ImageButton;
                if (null != imgDelete)
                    imgDelete.Enabled = false;
            }
        }
        protected void BindNotesGrid()
        {
            DataTable objDT;
            if (Session["DT_Notes"] != null)
            {
                objDT = (DataTable)Session["DT_Notes"];
                gvNotes.DataSource = objDT;
                gvNotes.DataBind();
            }
        }
        protected void BindRulesGrid()
        {
            DataTable objDT;
            if (Session["DT_Rules"] != null)
            {
                objDT = (DataTable)Session["DT_Rules"];
                gvRules.DataSource = objDT;
                gvRules.DataBind();
            }
        }
        //protected void gvNotes_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        //{
        //    gvNotes.EditIndex = -1;
        //    this.BindNotesGrid();
        //}
        //protected void gvNotes_RowEditing(object sender, GridViewEditEventArgs e)
        //{
        //    gvNotes.EditIndex = e.NewEditIndex;
        //    this.BindNotesGrid();
        //}
        //protected void gvNotes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        //{
        //    string strID = (string)this.gvNotes.DataKeys[e.RowIndex]["ID"].ToString();
        //    DataTable objDT;
        //    if (Session["DT_Notes"] != null)
        //    {
        //        objDT = (DataTable)Session["DT_Notes"];
        //        for (int i = 0; i < objDT.Rows.Count; i++)
        //        {
        //            if (objDT.Rows[i][0].ToString() == strID)
        //            {
        //                objDT.Rows.Remove(objDT.Rows[i]);
        //                objDT.AcceptChanges();
        //                break;
        //            }
        //        }
        //        for (int i = 0; i < objDT.Rows.Count; i++)
        //        {
        //            objDT.Rows[i][0] = i.ToString();
        //            objDT.Rows[i][1] = "Note " + (i + 1).ToString();
        //        }
        //        Session["DT_Notes"] = objDT;
        //        BindNotesGrid();
        //    }
        //}
        //protected void gvNotes_RowUpdating(object sender, GridViewUpdateEventArgs e)
        //{
        //    if (Session["DT_Notes"] != null)
        //    {
        //        string strID = (string)this.gvNotes.DataKeys[e.RowIndex]["ID"].ToString();
        //        GridViewRow gr = gvNotes.Rows[e.RowIndex];
        //        TextBox txtNote = (TextBox)gr.FindControl("txtGridNotes");
        //        DataTable objDT;
        //        objDT = (DataTable)Session["DT_Notes"];
        //        Session["DT_Notes"] = setValue(objDT, strID, txtNote.Text.Trim().ToString());
        //        gvNotes.EditIndex = -1;
        //        this.BindNotesGrid();
        //    }
        //}
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
        //protected void gvRules_RowDeleting(object sender, GridViewDeleteEventArgs e)
        //{
        //    if (Session["DT_Rules"] != null)
        //    {
        //        string strID = (string)this.gvRules.DataKeys[e.RowIndex]["ID"].ToString();
        //        DataTable objDT;
        //        if (Session["DT_Rules"] != null)
        //        {
        //            objDT = (DataTable)Session["DT_Rules"];
        //            for (int i = 0; i < objDT.Rows.Count; i++)
        //            {
        //                if (objDT.Rows[i][0].ToString() == strID)
        //                {
        //                    objDT.Rows.Remove(objDT.Rows[i]);
        //                    objDT.AcceptChanges();
        //                    break;
        //                }
        //            }
        //            for (int i = 0; i < objDT.Rows.Count; i++)
        //            {
        //                objDT.Rows[i][0] = i.ToString();
        //                objDT.Rows[i][1] = "Rule " + (i + 1).ToString();
        //            }
        //            Session["DT_Rules"] = objDT;
        //            BindRulesGrid();
        //        }
        //    }
        //}
        //protected void gvRules_RowUpdating(object sender, GridViewUpdateEventArgs e)
        //{
        //    if (Session["DT_Rules"] != null)
        //    {
        //        string strID = (string)this.gvRules.DataKeys[e.RowIndex]["ID"].ToString();
        //        GridViewRow gr = gvRules.Rows[e.RowIndex];
        //        TextBox txtNote = (TextBox)gr.FindControl("txtGridRules");
        //        DataTable objDT;
        //        objDT = (DataTable)Session["DT_Rules"];
        //        Session["DT_Rules"] = setValue(objDT, strID, txtNote.Text.Trim().ToString());
        //        gvRules.EditIndex = -1;
        //        this.BindRulesGrid();
        //    }
        //}
        //protected void gvRules_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        //{
        //    gvRules.EditIndex = -1;
        //    this.BindRulesGrid();
        //}
        //protected void gvRules_RowEditing(object sender, GridViewEditEventArgs e)
        //{
        //    gvRules.EditIndex = e.NewEditIndex;
        //    this.BindRulesGrid();
        //}

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            BEProvider objBEExamProvider = new BEProvider();
            BProvider objBExamProvider = new BProvider();
            objBEExamProvider.IntExamID = Convert.ToInt32(AppSecurity.Decrypt(Request.QueryString["ExamID"].ToString()));
            objBExamProvider.BDeleteExamDetails(objBEExamProvider);
            if (objBEExamProvider.IntResult == 1)
            {
                upFile.Visible = false;
                lblFile.Visible = true;
                lnlFile.Visible = false;
                objBEExamProvider.IntCourseID = Convert.ToInt32(AppSecurity.Decrypt(Request.QueryString["ExamID"].ToString()));
                objBExamProvider.BViewExamDetails(objBEExamProvider);
                lblFile.Text = CommonFunctions.CheckNullValue(objBEExamProvider.DsResult.Tables[0].Rows[0]["OriginalFileName"].ToString());
                trMessage.Visible = true;
                trViewButton.Visible = true;
                trDeleteButton.Visible = false;
                //lblMessage.Text = "Exam has been deleted successfully";
                //lblMessage.Text = Resources.ResMessages.Provider_ExamDeleteSuccess;
                lblMessage.Text = "<img src='../Images/yes.png' align='middle'/>&nbsp;<font color='#00C000'>" + Resources.ResMessages.Provider_ExamDeleteSuccess + "</font>"; 
            }
            //else
            //{
            //    trMessage.Visible = true;
            //    trDeleteButton.Visible = true;
            //    lblMessage.Text = "Exam is not deleted, there few pending exams";
            //}
        }



        protected void btnAddNotes_Click(object sender, EventArgs e)
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
                gvNotes.DataSource = objDT;
                gvNotes.DataBind();
            }
        }

        protected void btnClearNotes_Click(object sender, EventArgs e)
        {
            txtNotes.Text = string.Empty;
        }

        protected void btnAddRules_Click(object sender, EventArgs e)
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
                    Session["DT_Notes"] = objDT;
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
                gvRules.DataSource = objDT;
                gvRules.DataBind();
            }
        }

        protected void btnClearRules_Click(object sender, EventArgs e)
        {
            txtRules.Text = string.Empty;
        }

        protected void btnSave_Click1(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                BEProvider objBEExamProvider = new BEProvider();
                BProvider objBExamProvider = new BProvider();
                objBEExamProvider.IntCourseID = Convert.ToInt32(AppSecurity.Decrypt(Request.QueryString["ExamID"].ToString()));
                objBEExamProvider.ddlHours = Convert.ToDecimal(ddlHours.SelectedValue);
                lblHours.Text = ddlHours.SelectedValue.ToString();
                objBEExamProvider.ddlMinutes = Convert.ToDecimal(ddlMinutes.SelectedValue);
                lblMinutes.Text = ddlMinutes.SelectedValue.ToString();
                objBEExamProvider.ddlHM = objBEExamProvider.ddlHours.ToString() + '.' + objBEExamProvider.ddlMinutes.ToString();
                objBEExamProvider.IntBufferTime = Convert.ToInt32(ddlBufferTime.SelectedValue);
                lblBufferTime.Text = ddlBufferTime.SelectedValue.ToString();
                objBEExamProvider.strExamEndDate = Convert.ToDateTime(txtEndDate.SelectedDate.ToString());
                lblStartDate.Text = DateTime.Parse(txtStartDate.SelectedDate.ToString()).ToShortDateString();
                lblEndDate.Text = DateTime.Parse(txtEndDate.SelectedDate.ToString()).ToShortDateString();
                objBEExamProvider.strExamStartDate = Convert.ToDateTime(txtStartDate.SelectedDate.ToString());
                objBEExamProvider.strLinkAccessExam = txtAccessExam.InnerText;
                lblAccessExam.Text = txtAccessExam.InnerText;
                objBEExamProvider.strCourseName = lblCourseName.Text;
                objBEExamProvider.strSecurityLevel = ddlExamSecurity.SelectedItem.Value.ToString();

                lblExamSecurity.Text = ddlExamSecurity.SelectedItem.Text.ToString();
                //objBEExamProvider.strCourseName = txtCourse.Text.Trim().ToString();
                // lblCourseName.Text = txtCourse.Text.Trim().ToString();
                objBEExamProvider.strExamName = txtExam.Text.Trim().ToString();
                lblExamName.Text = txtExam.Text.Trim().ToString();
                objBEExamProvider.DtResult = (DataTable)Session["DT_Notes"];
                objBEExamProvider.DtResult1 = (DataTable)Session["DT_Rules"];
                if (chkCalc.Checked == true)
                    objBEExamProvider.intCalc = 1;
                else
                    objBEExamProvider.intCalc = 0;
                if (chkStickynotes.Checked == true)
                    objBEExamProvider.intStickyNotes = 1;
                else
                    objBEExamProvider.intStickyNotes = 0;

                if (upFile.HasFile)
                {
                    string strpath = Server.MapPath("../Provider/Provider_Uploads");
                    //string strpath = Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["ProviderUploads"]);
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

                objBExamProvider.BUpdateExamDetails(objBEExamProvider);


                this.EnableDisable("View");

                objBEExamProvider.IntCourseID = Convert.ToInt32(AppSecurity.Decrypt(Request.QueryString["ExamID"].ToString()));
                objBExamProvider.BViewExamDetails(objBEExamProvider);
                bool noTools = false;
                if (objBEExamProvider.DsResult.Tables[3].Rows.Count > 0)
                {
                    noTools = true;
                    for (int i = 0; i < objBEExamProvider.DsResult.Tables[3].Rows.Count; i++)
                    {
                        if (objBEExamProvider.DsResult.Tables[3].Rows[i]["ToolID"].ToString() == "101")
                            imgCalc.Visible = true;
                        if (objBEExamProvider.DsResult.Tables[3].Rows[i]["ToolID"].ToString() == "102")
                            imgStickyNotes.Visible = true;
                    }
                }
                if (noTools == false)
                    lblTools.Visible = true;

                if (objBEExamProvider.DsResult.Tables[0].Rows[0]["OriginalFileName"].ToString() != null && objBEExamProvider.DsResult.Tables[0].Rows[0]["OriginalFileName"].ToString() != "")
                {
                    lnlFile.Visible = true;
                    lblFile.Visible = false;
                    lnlFile.Text = objBEExamProvider.DsResult.Tables[0].Rows[0]["OriginalFileName"].ToString();
                    imgCancel.Visible = false;

                }
                else
                {
                    lnlFile.Visible = false;
                    lblFile.Visible = true;
                    lblFile.Text = "N/A";
                    ////lblFile.Visible = false;
                    imgCancel.Visible = false;
                }

                //lnlFile.Text =CommonFunctions.CheckNullValue(objBEExamProvider.DsResult.Tables[0].Rows[0]["OriginalFileName"].ToString());

                //lblFile.Text = CommonFunctions.CheckNullValue(objBEExamProvider.DsResult.Tables[0].Rows[0]["OriginalFileName"].ToString());
                upFile.Visible = false;
                // lblFile.Visible = false;
                // lnlFile.Visible = true;         

                trMessage.Visible = true;
                trEditButton.Visible = false;
                //lblMessage.Text = "Exam details updated successfully";
                lblMessage.Text = "<img src='../Images/yes.png' align='middle'/>&nbsp;<font color='#00C000'>" + Resources.ResMessages.Provider_ExamUpdateSuccess + "</font></br>";
                gvNotes.MasterTableView.GetColumn("Action").Visible = false;
                gvRules.MasterTableView.GetColumn("Action").Visible = false;
            }
        }

        protected void btnCancel_Click1(object sender, EventArgs e)
        {
            Response.Redirect("ExamDetails.aspx");
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("ExamDetails.aspx");
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
                    gvNotes.DataSource = new object[] { };
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
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
                    gvRules.DataSource = new object[] { };
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
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
    }
}