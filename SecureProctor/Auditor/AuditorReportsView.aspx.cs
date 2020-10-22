using BLL;
using BusinessEntities;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace SecureProctor.Auditor
{
    public partial class AuditorReportsView : BaseClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BECommon objBECommon = new BECommon();
                BCommon objBCommon = new BCommon();
                objBECommon.iTimeZoneID = Convert.ToInt32(Session["TimeZoneID"].ToString());
                objBCommon.BGetTimeDelay(objBECommon);
                dtpstartdate.SelectedDate = DateTime.UtcNow.AddMinutes(objBECommon.IntResult);
                dtpEnddate.SelectedDate = DateTime.UtcNow.AddMinutes(objBECommon.IntResult);
                btnInvoice.Visible = false;
                string monthselect = DateTime.Today.Month.ToString();
                string yrselect = DateTime.Today.Year.ToString();
                ddlMonths.FindItemByValue(monthselect).Selected = true;
                ddlYear.FindItemByText(yrselect).Selected = true;
            }

            this.Page.Title = EnumPageTitles.APPNAME + EnumPageTitles.Auditor_AuditorREPORTS;
            ((LinkButton)this.Page.Master.FindControl("lnkReports")).CssClass = "main_menu_active";

            if (Request.QueryString != null && Request.QueryString.ToString() != null)
            {

                int intReportID = Convert.ToInt32(AppSecurity.Decrypt(Request.QueryString["ReportID"].ToString()));
                int intTypeID = Convert.ToInt32(AppSecurity.Decrypt(Request.QueryString["ReportTypeID"].ToString()));


                if (intTypeID == 1)
                {
                    trSearchCriteria1.Visible = true;
                    trSearchCriteria2.Visible = false;
                    trSearchCriteria3.Visible = false;
                }
                else if (intTypeID == 2)
                {
                    trSearchCriteria1.Visible = false;
                    trSearchCriteria2.Visible = true;
                    trSearchCriteria3.Visible = false;
                }
                else if (intTypeID == 3)
                {
                    trSearchCriteria1.Visible = false;
                    trSearchCriteria2.Visible = false;
                    trSearchCriteria3.Visible = true;
                    btnInvoice.Visible = true;
                }
            }
        }

        protected void gvReports_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            try
            {
                this.GetReportsData();

            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        protected void BtnExportToExcel_Click(object sender, ImageClickEventArgs e)
        {
            ConfigureExport();
            gvReports.ExportSettings.ExportOnlyData = true;
            gvReports.MasterTableView.ExportToExcel();
        }

        protected void BtnExportToPdf_Click(object sender, ImageClickEventArgs e)
        {
            ConfigureExport();
            gvReports.MasterTableView.ExportToPdf();
        }
        
        public void ConfigureExport()
        {
            gvReports.ExportSettings.ExportOnlyData = true;
            gvReports.ExportSettings.IgnorePaging = true;
            gvReports.ExportSettings.OpenInNewWindow = true;

        }

        protected void btnReports_Click(object sender, EventArgs e)
        {
            gvReports.Rebind();
        }

        protected void ddlMonths_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime StartDate = DateTime.Parse(ddlMonths.SelectedValue + "/01/" + DateTime.Now.Year.ToString());
            DateTime EndDate = DateTime.Parse(ddlMonths.SelectedValue + "/01/" + DateTime.Now.Year.ToString()).AddMonths(1).AddDays(-1);
            LoadExamStatusDetails(StartDate, EndDate);
        }
        protected void ddlYears_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime StartDate = DateTime.Parse("01/01/" + ddlYear.SelectedValue);
            DateTime EndDate = DateTime.Parse("12/31/" + ddlYear.SelectedValue);
            LoadExamStatusDetails(StartDate, EndDate);
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

            DateTime StartDate = DateTime.Parse("01/01/" + ddlYear.SelectedItem.Text);
            DateTime EndDate = DateTime.Parse("12/31/" + ddlYear.SelectedItem.Text);
            LoadExamStatusDetails(StartDate, EndDate);
        }
        protected void LoadExamStatusDetails(DateTime StartDate, DateTime EndDate)
        {
            BECommon objBECommon = new BECommon();
            BCommon objBCommon = new BCommon();
            objBECommon.IntUserID = int.Parse(Session[BaseClass.EnumPageSessions.USERID].ToString());
            objBECommon.DateStartDate = StartDate;
            objBECommon.DateEndDate = EndDate;

            objBCommon.BGetExamBillingDetails(objBECommon);

            DataTable objDt = objBECommon.DsResult.Tables[0];

            for (int i = 1; i < objBECommon.DsResult.Tables.Count; i++)
            {
                objDt.Merge(objBECommon.DsResult.Tables[i]);
            }
            objDt.AcceptChanges();

            //gvReports.DataSource = objDt;
            if (objDt != null && objDt.Rows.Count > 0)
            {
                gvReports.DataSource = objDt;
                //gvReports.Rebind();
                trExportButtons.Visible = true;
                trGridView.Visible = true;
            }
            else
            {
                gvReports.DataSource = new Object[0];
                trExportButtons.Visible = false;
                trGridView.Visible = true;
            }
            //gvReports.Rebind();
            //gvReports.DataBind();
            trexamfee.Visible = true;
            tdtotalfee.Visible = true;
            tdtotalfeelabel.Visible = true;
            //trondemandfee.Visible = true;
            string paidexamfee = string.Empty;
            string paidondemandfee = string.Empty;

            BEAdmin objBEAdmin = new BEAdmin();
            BAdmin objBAdmin = new BAdmin();
            objBAdmin.BGetPaymentMode(objBEAdmin);
            if (objBEAdmin.DtResult != null && objBEAdmin.DtResult.Rows.Count > 0)
            {
                paidexamfee = objBEAdmin.DtResult.Rows[0]["PaidBy_ExamFee"].ToString();
                paidondemandfee = objBEAdmin.DtResult.Rows[0]["PaidBy_OnDemandFee"].ToString();
            }
            lblRecords.Text = objDt.Rows.Count.ToString();
            btnInvoice.Enabled = true;
            btnInvoice.ToolTip = "Generate Invoice";
            //lblExamFee.Text = "$" + objDt.Compute("SUM(ExamFee)", String.Empty);
            //lblOnDemandFee.Text = "$" + objDt.Compute("SUM(OndemandFee)", String.Empty);
            if (paidexamfee == "University" && paidondemandfee != "University")
            {
                //tdondemandfee.Visible = false;
                //tdondemandfeelabel.Visible = false;
                //tdexamfeelabel.Visible = true;
                //tdexamfee.Visible = true;
                lblexamfeetitle.Text = "Total Exam Fee (University) :";
                lblondemandtitle.Text = "Total On-demand Fee (Student) :";
                lbltotalfeetitle.Text = "Total Fee (Paid by University) :";
                lblExamFee.Text = "$" + objDt.Compute("SUM([Exam Fee (Paid by University)])", String.Empty);
                lblOnDemandFee.Text = "$" + objDt.Compute("SUM([On-demandFee (Paid by Student)])", String.Empty);
                lblTotalFee.Text = "$" + objDt.Compute("SUM([Exam Fee (Paid by University)])", String.Empty);
            }
            else if (paidexamfee != "University" && paidondemandfee == "University")
            {
                //tdexamfeelabel.Visible = false;
                //tdexamfee.Visible = false;
                //tdondemandfee.Visible = true;
                //tdondemandfeelabel.Visible = true;
                lblexamfeetitle.Text = "Total Exam Fee (Student) :";
                lblondemandtitle.Text = "Total On-demand Fee (University) :";
                lbltotalfeetitle.Text = "Total Fee (Paid by University) :";
                lblExamFee.Text = "$" + objDt.Compute("SUM([Exam Fee (Paid by Student)])", String.Empty);
                lblOnDemandFee.Text = "$" + objDt.Compute("SUM([On-demandFee (Paid by University)])", String.Empty);
                lblTotalFee.Text = "$" + objDt.Compute("SUM([On-demandFee (Paid by University)])", String.Empty);
            }
            else if (paidexamfee == "University" && paidondemandfee == "University")
            {
                //tdexamfeelabel.Visible = true;
                //tdexamfee.Visible = true;
                //tdondemandfee.Visible = true;
                //tdondemandfeelabel.Visible = true;
                lblexamfeetitle.Text = "Total Exam Fee (University) :";
                lblondemandtitle.Text = "Total On-demand Fee (University) :";
                lbltotalfeetitle.Text = "Total Fee (Paid by University) :";
                lblExamFee.Text = "$" + objDt.Compute("SUM([Exam Fee (Paid by University)])", String.Empty);
                lblOnDemandFee.Text = "$" + objDt.Compute("SUM([On-demandFee (Paid by University)])", String.Empty);
                lblTotalFee.Text = "$" + objDt.Compute("SUM([Total Fee (Paid by University)])", String.Empty);
            }
            else if (paidexamfee != "University" && paidondemandfee != "University")
            {
                //lblTotalFee.Text = "$" + objDt.Compute("SUM(TotalFee)", String.Empty);
                //tdexamfeelabel.Visible = false;
                //tdexamfee.Visible = false;
                //tdondemandfee.Visible = false;
                //tdondemandfeelabel.Visible = false;
                //tdtotalfee.Visible = false;
                //tdtotalfeelabel.Visible = false;
                lblexamfeetitle.Text = "Total Exam Fee (Student) :";
                lblondemandtitle.Text = "Total On-demand Fee (Student) :";
                lbltotalfeetitle.Text = "Total Fee (Paid by University) :";
                lblExamFee.Text = "$" + objDt.Compute("SUM([Exam Fee (Paid by Student)])", String.Empty);
                lblOnDemandFee.Text = "$" + objDt.Compute("SUM([On-demandFee (Paid by Student)])", String.Empty);
                lblTotalFee.Text = "$" + objDt.Compute("0", String.Empty);
                btnInvoice.Enabled = false;
                btnInvoice.ToolTip = "Invoice cannot be raised as the Payment mode is Student";
            }

        }

        protected void GetReportsData()
        {
            try
            {
                trexamfee.Visible = false;
                int intReportType = Convert.ToInt32(AppSecurity.Decrypt(Request.QueryString["ReportTypeID"].ToString()));
                BECommon objBECommon = new BECommon();
                BCommon objBCommon = new BCommon();
                objBECommon.IntRoleID = Convert.ToInt32(Session["RoleID"]);
                if (intReportType != 3)
                {
                    if (intReportType == 1)
                    {
                        if (dtpstartdate.SelectedDate != null)
                            objBECommon.DateStartDate = Convert.ToDateTime(dtpstartdate.SelectedDate);
                        if (dtpEnddate.SelectedDate != null)
                            objBECommon.DateEndDate = Convert.ToDateTime(dtpEnddate.SelectedDate);
                    }
                    else
                    {
                        objBECommon.strCourseName = txtCourseName.Text.ToString();
                        objBECommon.strExamName = txtExamName.Text.ToString();
                        objBECommon.StrFirstName = txtFirstName.Text.ToString();
                        objBECommon.StrLastName = txtLastName.Text.ToString();
                    }
                    objBECommon.iReportID = Convert.ToInt32(AppSecurity.Decrypt(Request.QueryString["ReportID"].ToString()));
                    objBECommon.IntUserID = Convert.ToInt32(Session[EnumPageSessions.USERID]);
                    objBECommon.intReportTypeID = intReportType;
                    objBCommon.BGetSelectedReport(objBECommon);
                    if (objBECommon.DtResult != null && objBECommon.DtResult.Rows.Count > 0)
                    {
                        gvReports.DataSource = objBECommon.DtResult;
                        trExportButtons.Visible = true;
                        trGridView.Visible = true;
                    }
                    else
                    {
                        gvReports.DataSource = new Object[0];
                        trExportButtons.Visible = false;
                        trGridView.Visible = true;
                    }
                }
                else
                {
                    DateTime StartDate = new DateTime();
                    DateTime EndDate = new DateTime();
                    if (ddlYear.SelectedIndex > 0 && ddlMonths.SelectedIndex > 0)
                    {
                        StartDate = DateTime.Parse(ddlMonths.SelectedValue + "/01/" + ddlYear.SelectedItem.Text);
                        EndDate = DateTime.Parse(ddlMonths.SelectedValue + "/01/" + ddlYear.SelectedItem.Text.ToString()).AddMonths(1).AddDays(-1);
                        LoadExamStatusDetails(StartDate, EndDate);
                    }
                    else if (ddlYear.SelectedIndex > 0 && ddlMonths.SelectedIndex <= 0)
                    {
                        StartDate = DateTime.Parse("01/01/" + ddlYear.SelectedItem.Text);
                        EndDate = DateTime.Parse("01/01/" + ddlYear.SelectedItem.Text.ToString()).AddMonths(12);
                        LoadExamStatusDetails(StartDate, EndDate);
                    }
                    else
                    {
                        gvReports.DataSource = new Object[0];
                        trExportButtons.Visible = false;
                    }

                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        protected void gvReports_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                int intReportType = Convert.ToInt32(AppSecurity.Decrypt(Request.QueryString["ReportTypeID"].ToString()));
                if (intReportType == 3)
                {
                    GridDataItem dataItem = e.Item as GridDataItem;
                    int columnCount = ((DataRowView)dataItem.DataItem).Row.Table.Columns.Count;
                    string cellValue = string.Empty;
                    string uniqueColumnname = string.Empty;
                    string paidexamfee = string.Empty;
                    string paidondemandfee = string.Empty;

                    BEAdmin objBEAdmin = new BEAdmin();
                    BAdmin objBAdmin = new BAdmin();
                    objBAdmin.BGetPaymentMode(objBEAdmin);
                    if (objBEAdmin.DtResult != null && objBEAdmin.DtResult.Rows.Count > 0)
                    {
                        paidexamfee = objBEAdmin.DtResult.Rows[0]["PaidBy_ExamFee"].ToString();
                        paidondemandfee = objBEAdmin.DtResult.Rows[0]["PaidBy_OnDemandFee"].ToString();
                    }
                    for (int x = 0; x < columnCount; x++)
                    {
                        if (x == 8)
                        {
                            uniqueColumnname = ((DataRowView)dataItem.DataItem).Row.Table.Columns[x].ToString();
                            cellValue = ((DataRowView)dataItem.DataItem)[uniqueColumnname].ToString();
                            if (paidexamfee == "University")
                            {
                                TableCell cell = dataItem[uniqueColumnname];
                                cell.BackColor = System.Drawing.Color.White;
                            }
                            else if (paidexamfee == "Student")
                            {
                                TableCell cell = dataItem[uniqueColumnname];
                                cell.BackColor = System.Drawing.Color.Orange;
                                cell.ToolTip = "Paid by Student";
                            }
                        }

                        if (x == 9)
                        {
                            uniqueColumnname = ((DataRowView)dataItem.DataItem).Row.Table.Columns[x].ToString();
                            cellValue = ((DataRowView)dataItem.DataItem)[uniqueColumnname].ToString();
                            if (paidondemandfee == "University")
                            {
                                TableCell cell = dataItem[uniqueColumnname];
                                cell.BackColor = System.Drawing.Color.White;
                            }
                            else if (paidondemandfee == "Student")
                            {
                                TableCell cell = dataItem[uniqueColumnname];
                                cell.BackColor = System.Drawing.Color.Orange;
                                cell.ToolTip = "Paid by Student";
                            }
                        }
                    }
                }
            }
        }

        protected void GenerateReport(object sender, EventArgs e)
        {
            //BECommon objBECommon = new BECommon();
            //BCommon objBCommon = new BCommon();
            //objBECommon.IntUserID = int.Parse(Session[BaseClass.EnumPageSessions.USERID].ToString());
            //objBECommon.DateStartDate = StartDate;
            //objBECommon.DateEndDate = EndDate;

            //objBCommon.BGetExamBillingDetails(objBECommon);

            //DataTable objDt = objBECommon.DsResult.Tables[0];

            //for (int i = 1; i < objBECommon.DsResult.Tables.Count; i++)
            //{
            //    objDt.Merge(objBECommon.DsResult.Tables[i]);
            //}
            //objDt.AcceptChanges();

            ////gvReports.DataSource = objDt;
            //if (objDt != null && objDt.Rows.Count > 0)
            //{
            //    gvReports.DataSource = objDt;
            //    //gvReports.Rebind();
            //    trExportButtons.Visible = true;
            //    trGridView.Visible = true;
            //}
            //else
            //{
            //    gvReports.DataSource = new Object[0];
            //    trExportButtons.Visible = false;
            //    trGridView.Visible = true;
            //}

            //string paidexamfee = string.Empty;
            //string paidondemandfee = string.Empty;

            //BEAdmin objBEAdmin = new BEAdmin();
            //BAdmin objBAdmin = new BAdmin();
            //objBAdmin.BGetPaymentMode(objBEAdmin);
            //if (objBEAdmin.DtResult != null && objBEAdmin.DtResult.Rows.Count > 0)
            //{
            //    paidexamfee = objBEAdmin.DtResult.Rows[0]["PaidBy_ExamFee"].ToString();
            //    paidondemandfee = objBEAdmin.DtResult.Rows[0]["PaidBy_OnDemandFee"].ToString();
            //}
            //lblRecords.Text = objDt.Rows.Count.ToString();
            ////lblExamFee.Text = "$" + objDt.Compute("SUM(ExamFee)", String.Empty);
            ////lblOnDemandFee.Text = "$" + objDt.Compute("SUM(OndemandFee)", String.Empty);
            //if (paidexamfee == "University" && paidondemandfee != "University")
            //{
            //    //tdondemandfee.Visible = false;
            //    //tdondemandfeelabel.Visible = false;
            //    //tdexamfeelabel.Visible = true;
            //    //tdexamfee.Visible = true;
            //    lblexamfeetitle.Text = "Total Exam Fee (University) :";
            //    lblondemandtitle.Text = "Total On-demand Fee (Student) :";
            //    lbltotalfeetitle.Text = "Total Fee (University) :";
            //    lblExamFee.Text = "$" + objDt.Compute("SUM(ExamFee)", String.Empty);
            //    lblOnDemandFee.Text = "$" + objDt.Compute("SUM(OndemandFee)", String.Empty);
            //    lblTotalFee.Text = "$" + objDt.Compute("SUM(ExamFee)", String.Empty);
            //}
            //else if (paidexamfee != "University" && paidondemandfee == "University")
            //{
            //    //tdexamfeelabel.Visible = false;
            //    //tdexamfee.Visible = false;
            //    //tdondemandfee.Visible = true;
            //    //tdondemandfeelabel.Visible = true;
            //    lblexamfeetitle.Text = "Total Exam Fee (Student) :";
            //    lblondemandtitle.Text = "Total On-demand Fee (University) :";
            //    lbltotalfeetitle.Text = "Total Fee (University) :";
            //    lblExamFee.Text = "$" + objDt.Compute("SUM(ExamFee)", String.Empty);
            //    lblOnDemandFee.Text = "$" + objDt.Compute("SUM(OndemandFee)", String.Empty);
            //    lblTotalFee.Text = "$" + objDt.Compute("SUM(OndemandFee)", String.Empty);
            //}
            //else if (paidexamfee == "University" && paidondemandfee == "University")
            //{
            //    //tdexamfeelabel.Visible = true;
            //    //tdexamfee.Visible = true;
            //    //tdondemandfee.Visible = true;
            //    //tdondemandfeelabel.Visible = true;
            //    lblexamfeetitle.Text = "Total Exam Fee (University) :";
            //    lblondemandtitle.Text = "Total On-demand Fee (University) :";
            //    lbltotalfeetitle.Text = "Total Fee (University) :";
            //    lblExamFee.Text = "$" + objDt.Compute("SUM(ExamFee)", String.Empty);
            //    lblOnDemandFee.Text = "$" + objDt.Compute("SUM(OndemandFee)", String.Empty);
            //    lblTotalFee.Text = "$" + objDt.Compute("SUM(TotalFee)", String.Empty);
            //}
            //else if (paidexamfee != "University" && paidondemandfee != "University")
            //{
            //    //lblTotalFee.Text = "$" + objDt.Compute("SUM(TotalFee)", String.Empty);
            //    //tdexamfeelabel.Visible = false;
            //    //tdexamfee.Visible = false;
            //    //tdondemandfee.Visible = false;
            //    //tdondemandfeelabel.Visible = false;
            //    //tdtotalfee.Visible = false;
            //    //tdtotalfeelabel.Visible = false;
            //    lblexamfeetitle.Text = "Total Exam Fee (Student) :";
            //    lblondemandtitle.Text = "Total On-demand Fee (Student) :";
            //    lbltotalfeetitle.Text = "Total Fee (Student) :";
            //    lblExamFee.Text = "$" + objDt.Compute("SUM(ExamFee)", String.Empty);
            //    lblOnDemandFee.Text = "$" + objDt.Compute("SUM(OndemandFee)", String.Empty);
            //    lblTotalFee.Text = "$" + objDt.Compute("SUM(TotalFee)", String.Empty);
            //}

            BEAdmin objBEAdmin = new BEAdmin();
            BAdmin objBAdmin = new BAdmin();

            objBAdmin.BGetClientContactDetails(objBEAdmin);
            string ExamIDSeries = string.Empty;
            string strOrgName = string.Empty;
            string strStreet1 = string.Empty;
            string strStreet2 = string.Empty;
            string strCity = string.Empty;
            string strRegion = string.Empty;
            string strPostalCode = string.Empty;
            string strName = string.Empty;
            string strDesignation = string.Empty;


            if (objBEAdmin.DsResult != null && objBEAdmin.DsResult.Tables[0].Rows.Count > 0)
            {
                ExamIDSeries = objBEAdmin.DsResult.Tables[0].Rows[0]["ExamIDSeries"].ToString();
            }

            if (objBEAdmin.DsResult != null && objBEAdmin.DsResult.Tables[1].Rows.Count > 0)
            {
                strOrgName = objBEAdmin.DsResult.Tables[1].Rows[0]["OrganizationName"].ToString();
                strStreet1 = objBEAdmin.DsResult.Tables[1].Rows[0]["Street1"].ToString();
                strStreet2 = objBEAdmin.DsResult.Tables[1].Rows[0]["Street2"].ToString();
                strCity = objBEAdmin.DsResult.Tables[1].Rows[0]["City"].ToString();
                strRegion = objBEAdmin.DsResult.Tables[1].Rows[0]["Region"].ToString();
                strPostalCode = objBEAdmin.DsResult.Tables[1].Rows[0]["PostalCode"].ToString();
                strName = objBEAdmin.DsResult.Tables[1].Rows[0]["Name"].ToString();
                strDesignation = objBEAdmin.DsResult.Tables[1].Rows[0]["Designation"].ToString();
            }


            Document document = new Document(PageSize.A4, 88f, 88f, 10f, 10f);
            Font NormalFont = FontFactory.GetFont("Times New Roman", 12, Font.NORMAL, Color.BLACK);
            using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
            {
                PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
                //Phrase phrase = null;
                PdfPCell cell = null;
                PdfPTable table = null;
                //Color color = null;

                document.Open();

                //Header Table
                table = new PdfPTable(1);
                table.TotalWidth = 450f;
                table.LockedWidth = true;
                table.SetWidths(new float[] { 1f });

                document.Add(table);

                table = new PdfPTable(4);
                table.HorizontalAlignment = Element.ALIGN_CENTER;
                table.LockedWidth = true;
                table.SetWidths(new float[] { 1f, 1f, 1f, 1f });
                table.SpacingBefore = 20f;
                table.TotalWidth = 450f;


                cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                cell.Colspan = 1;
                table.AddCell(cell);
                cell = PhraseCell(new Phrase("Secure Proctor", FontFactory.GetFont("Times New Roman", 12, Font.UNDERLINE, Color.BLACK)), PdfPCell.ALIGN_CENTER);
                cell.Colspan = 2;
                cell.PaddingTop = 20f;
                table.AddCell(cell);
                cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                cell.Colspan = 1;
                cell.PaddingBottom = 60f;
                table.AddCell(cell);

                cell = PhraseCell(new Phrase("BILL TO:\n", FontFactory.GetFont("Times New Roman", 10, Font.BOLD, Color.BLACK)), PdfPCell.ALIGN_LEFT);
                cell.Colspan = 2;
                table.AddCell(cell);
                cell = PhraseCell(new Phrase("Date:", FontFactory.GetFont("Times New Roman", 10, Font.NORMAL, Color.BLACK)), PdfPCell.ALIGN_RIGHT);
                cell.Colspan = 1;
                cell.PaddingRight = 29f;
                table.AddCell(cell);
                cell = PhraseCell(new Phrase(String.Format("{0:d}", DateTime.Today), FontFactory.GetFont("Times New Roman", 10, Font.NORMAL, Color.BLACK)), PdfPCell.ALIGN_LEFT);
                cell.Colspan = 1;
                table.AddCell(cell);

                cell = PhraseCell(new Phrase(strOrgName, FontFactory.GetFont("Times New Roman", 10, Font.NORMAL, Color.BLACK)), PdfPCell.ALIGN_LEFT);
                cell.Colspan = 2;
                table.AddCell(cell);
                cell = PhraseCell(new Phrase("Invoice #:", FontFactory.GetFont("Times New Roman", 10, Font.NORMAL, Color.BLACK)), PdfPCell.ALIGN_RIGHT);
                cell.Colspan = 1;
                cell.PaddingRight = 10f;
                table.AddCell(cell);
                cell = PhraseCell(new Phrase(String.Format("{0:yyMMdd}", DateTime.Today) + ExamIDSeries, FontFactory.GetFont("Times New Roman", 10, Font.NORMAL, Color.BLACK)), PdfPCell.ALIGN_LEFT);
                cell.Colspan = 1;
                table.AddCell(cell);

                cell = PhraseCell(new Phrase(strName + "\n", FontFactory.GetFont("Times New Roman", 10, Font.NORMAL, Color.BLACK)), PdfPCell.ALIGN_LEFT);
                cell.Colspan = 2;
                table.AddCell(cell);
                cell = PhraseCell(new Phrase("Terms:", FontFactory.GetFont("Times New Roman", 10, Font.NORMAL, Color.BLACK)), PdfPCell.ALIGN_RIGHT);
                cell.Colspan = 1;
                cell.PaddingRight = 22f;
                table.AddCell(cell);
                cell = PhraseCell(new Phrase("Due On Receipt", FontFactory.GetFont("Times New Roman", 10, Font.NORMAL, Color.BLACK)), PdfPCell.ALIGN_LEFT);
                cell.Colspan = 1;
                table.AddCell(cell);

                cell = PhraseCell(new Phrase(strDesignation + "\n", FontFactory.GetFont("Times New Roman", 10, Font.NORMAL, Color.BLACK)), PdfPCell.ALIGN_LEFT);
                cell.Colspan = 3;
                table.AddCell(cell);
                cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_LEFT);
                cell.Colspan = 1;
                table.AddCell(cell);

                cell = PhraseCell(new Phrase(strStreet1 + " " + strStreet2 + "\n", FontFactory.GetFont("Times New Roman", 10, Font.NORMAL, Color.BLACK)), PdfPCell.ALIGN_LEFT);
                cell.Colspan = 3;
                table.AddCell(cell);
                cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_LEFT);
                cell.Colspan = 1;
                table.AddCell(cell);

                cell = PhraseCell(new Phrase(strCity + "," + strRegion + " " + strPostalCode, FontFactory.GetFont("Times New Roman", 10, Font.NORMAL, Color.BLACK)), PdfPCell.ALIGN_LEFT);
                cell.Colspan = 3;
                table.AddCell(cell);
                cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_LEFT);
                cell.Colspan = 1;
                table.AddCell(cell);


                cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                cell.Colspan = 1;
                table.AddCell(cell);
                cell = PhraseCell(new Phrase("INVOICE", FontFactory.GetFont("Times New Roman", 14, Font.UNDERLINE, Color.BLACK)), PdfPCell.ALIGN_CENTER);
                cell.Colspan = 2;
                cell.PaddingTop = 20f;
                table.AddCell(cell);
                cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                cell.Colspan = 1;
                cell.PaddingBottom = 40f;
                table.AddCell(cell);

                document.Add(table);

                table = new PdfPTable(6);
                table.HorizontalAlignment = Element.ALIGN_CENTER;
                table.LockedWidth = true;
                table.SetWidths(new float[] { 1f, 1f, 1f, 1f, 1f, 1f });
                table.SpacingBefore = 20f;
                table.TotalWidth = 450f;

                cell = PhraseCell(new Phrase("DESCRIPTION", FontFactory.GetFont("Times New Roman", 12, Font.BOLD, Color.BLACK)), PdfPCell.ALIGN_CENTER);
                cell.Colspan = 3;
                cell.MinimumHeight = 40f;
                cell.PaddingTop = 10f;
                cell.BorderColor = new Color(System.Drawing.Color.Black);
                cell.Border = Rectangle.BOTTOM_BORDER | Rectangle.TOP_BORDER | Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
                table.AddCell(cell);
                cell = PhraseCell(new Phrase("Quantity", FontFactory.GetFont("Times New Roman", 10, Font.BOLD, Color.BLACK)), PdfPCell.ALIGN_CENTER);
                cell.Colspan = 1;
                cell.BorderColor = new Color(System.Drawing.Color.Black);
                cell.Border = Rectangle.BOTTOM_BORDER | Rectangle.TOP_BORDER | Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
                table.AddCell(cell);
                cell = PhraseCell(new Phrase("", FontFactory.GetFont("Times New Roman", 10, Font.BOLD, Color.BLACK)), PdfPCell.ALIGN_CENTER);
                cell.Colspan = 1;
                cell.BorderColor = new Color(System.Drawing.Color.Black);
                cell.Border = Rectangle.BOTTOM_BORDER | Rectangle.TOP_BORDER | Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
                table.AddCell(cell);
                cell = PhraseCell(new Phrase("Amount", FontFactory.GetFont("Times New Roman", 10, Font.BOLD, Color.BLACK)), PdfPCell.ALIGN_CENTER);
                cell.Colspan = 1;
                cell.BorderColor = new Color(System.Drawing.Color.Black);
                cell.Border = Rectangle.BOTTOM_BORDER | Rectangle.TOP_BORDER | Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
                table.AddCell(cell);

                document.Add(table);

                table = new PdfPTable(6);
                table.HorizontalAlignment = Element.ALIGN_CENTER;
                table.LockedWidth = true;
                table.SetWidths(new float[] { 1f, 1f, 1f, 1f, 1f, 1f });
                table.TotalWidth = 450f;

                cell = PhraseCell(new Phrase(ddlMonths.SelectedItem.Text + " Proctoring " + strOrgName, FontFactory.GetFont("Times New Roman", 8, Font.NORMAL, Color.BLACK)), PdfPCell.ALIGN_LEFT);
                cell.Colspan = 3;
                cell.MinimumHeight = 80f;
                cell.PaddingTop = 5f;
                cell.BorderColor = new Color(System.Drawing.Color.Black);
                cell.Border = Rectangle.BOTTOM_BORDER | Rectangle.TOP_BORDER | Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
                table.AddCell(cell);
                cell = PhraseCell(new Phrase(lblRecords.Text, FontFactory.GetFont("Times New Roman", 8, Font.NORMAL, Color.BLACK)), PdfPCell.ALIGN_RIGHT);
                cell.Colspan = 1;
                cell.MinimumHeight = 80f;
                cell.BorderColor = new Color(System.Drawing.Color.Black);
                cell.Border = Rectangle.BOTTOM_BORDER | Rectangle.TOP_BORDER | Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
                table.AddCell(cell);
                cell = PhraseCell(new Phrase("", FontFactory.GetFont("Times New Roman", 8, Font.NORMAL, Color.BLACK)), PdfPCell.ALIGN_RIGHT);
                cell.Colspan = 1;
                cell.MinimumHeight = 80f;
                cell.BorderColor = new Color(System.Drawing.Color.Black);
                cell.Border = Rectangle.BOTTOM_BORDER | Rectangle.TOP_BORDER | Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
                table.AddCell(cell);
                cell = PhraseCell(new Phrase(lblTotalFee.Text, FontFactory.GetFont("Times New Roman", 8, Font.NORMAL, Color.BLACK)), PdfPCell.ALIGN_RIGHT);
                cell.Colspan = 1;
                cell.MinimumHeight = 80f;
                cell.BorderColor = new Color(System.Drawing.Color.Black);
                cell.Border = Rectangle.BOTTOM_BORDER | Rectangle.TOP_BORDER | Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
                table.AddCell(cell);

                document.Add(table);

                table = new PdfPTable(6);
                table.HorizontalAlignment = Element.ALIGN_CENTER;
                table.LockedWidth = true;
                table.SetWidths(new float[] { 1f, 1f, 1f, 1f, 1f, 1f });
                table.TotalWidth = 450f;

                cell = PhraseCell(new Phrase(" Please make checks payable to Secure Proctor and remit to 20 Pickering St,\n Needham, MA 02492", FontFactory.GetFont("Times New Roman", 7, Font.NORMAL, Color.BLACK)), PdfPCell.ALIGN_LEFT);
                cell.Colspan = 4;
                cell.MinimumHeight = 40f;
                cell.PaddingTop = 5f;
                cell.BorderColor = new Color(System.Drawing.Color.Black);
                cell.Border = Rectangle.BOTTOM_BORDER | Rectangle.TOP_BORDER | Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
                table.AddCell(cell);
                cell = PhraseCell(new Phrase("TOTAL", FontFactory.GetFont("Times New Roman", 8, Font.NORMAL, Color.BLACK)), PdfPCell.ALIGN_RIGHT);
                cell.Colspan = 1;
                cell.BorderColor = new Color(System.Drawing.Color.Black);
                cell.Border = Rectangle.BOTTOM_BORDER | Rectangle.TOP_BORDER | Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
                cell.PaddingTop = 5f;
                table.AddCell(cell);
                cell = PhraseCell(new Phrase(lblTotalFee.Text, FontFactory.GetFont("Times New Roman", 8, Font.NORMAL, Color.BLACK)), PdfPCell.ALIGN_RIGHT);
                cell.Colspan = 1;
                cell.PaddingTop = 5f;
                cell.BorderColor = new Color(System.Drawing.Color.Black);
                cell.Border = Rectangle.BOTTOM_BORDER | Rectangle.TOP_BORDER | Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
                table.AddCell(cell);
                document.Add(table);
                document.Close();
                byte[] bytes = memoryStream.ToArray();
                memoryStream.Close();
                Response.Clear();
                Response.ContentType = "application/pdf";
                Response.AddHeader("Content-Disposition", "attachment; filename=Invoice.pdf");
                Response.ContentType = "application/pdf";
                Response.Buffer = true;
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.BinaryWrite(bytes);
                Response.End();
                Response.Close();
            }
        }

        private static void DrawLine(PdfWriter writer, float x1, float y1, float x2, float y2, Color color)
        {
            PdfContentByte contentByte = writer.DirectContent;
            contentByte.SetColorStroke(color);
            contentByte.MoveTo(x1, y1);
            contentByte.LineTo(x2, y2);
            contentByte.Stroke();
        }
        private static PdfPCell PhraseCell(Phrase phrase, int align)
        {
            PdfPCell cell = new PdfPCell(phrase);
            cell.BorderColor = Color.WHITE;
            cell.VerticalAlignment = PdfCell.ALIGN_TOP;
            cell.HorizontalAlignment = align;
            cell.PaddingBottom = 2f;
            cell.PaddingTop = 0f;
            return cell;
        }
        private static PdfPCell ImageCell(string path, float scale, int align)
        {
            iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(path));
            image.ScalePercent(scale);
            PdfPCell cell = new PdfPCell(image);
            cell.BorderColor = Color.WHITE;
            cell.VerticalAlignment = PdfCell.ALIGN_TOP;
            cell.HorizontalAlignment = align;
            cell.PaddingBottom = 0f;
            cell.PaddingTop = 0f;
            return cell;
        }
    }
}