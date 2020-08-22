using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Web.UI.HtmlControls;
using Telerik.Web.UI;
using System.Data;
using BLL;
using System.Globalization;
using System.IO;

namespace SecureProctor.Admin
{
    public partial class QuestionSummaries : BaseClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DateTime firstDate = GetFirstDateOfWeek(DateTime.Now, DayOfWeek.Monday);
                DateTime lastDate = GetLastDateOfWeek(DateTime.Now, DayOfWeek.Sunday);

                if (Request.QueryString["fdate"] != null && Request.QueryString["ldate"] != null)
                {
                    lblfirstdate.Text = AppSecurity.Decrypt(Request.QueryString["fdate"].ToString());
                    lblLastDate.Text = AppSecurity.Decrypt(Request.QueryString["ldate"].ToString());
                    txtFromDate.SelectedDate = Convert.ToDateTime(lblfirstdate.Text);
                }
                else
                {
                    txtFromDate.SelectedDate = firstDate;
                    lblfirstdate.Text = firstDate.ToString("MM/dd/yyyy");
                    lblLastDate.Text = lastDate.ToString("MM/dd/yyyy");
                }

                BindDetails();
            }
        }

        protected void txtFromDate_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
        {

            DateTime dt = (DateTime)txtFromDate.SelectedDate;
            CultureInfo c = txtFromDate.Calendar.CultureInfo;
            int weeknumber = c.Calendar.GetWeekOfYear(dt, c.DateTimeFormat.CalendarWeekRule, c.DateTimeFormat.FirstDayOfWeek);

            DateTime firstDate = GetFirstDateOfWeek(txtFromDate.SelectedDate.Value, DayOfWeek.Monday);
            DateTime lastDate = GetLastDateOfWeek(txtFromDate.SelectedDate.Value, DayOfWeek.Sunday);

            lblfirstdate.Text = firstDate.ToString("MM/dd/yyyy");
            lblLastDate.Text = lastDate.ToString("MM/dd/yyyy");
            BindDetails();



        }
        protected void btnleftarrow_Click(object sender, EventArgs e)
        {
            DateTime dtnextday = Convert.ToDateTime(lblfirstdate.Text);

            DateTime firstDate = GetFirstDateOfWeek(dtnextday.AddDays(-1), DayOfWeek.Monday);
            DateTime lastDate = GetLastDateOfWeek(dtnextday.AddDays(-1), DayOfWeek.Sunday);
            txtFromDate.SelectedDate = firstDate;

            lblfirstdate.Text = firstDate.ToString("MM/dd/yyyy");
            lblLastDate.Text = lastDate.ToString("MM/dd/yyyy");
             BindDetails();
        }

        protected void btnrightarrow_Click(object sender, EventArgs e)
        {
            DateTime dtnextday = Convert.ToDateTime(lblLastDate.Text);

            DateTime firstDate = GetFirstDateOfWeek(dtnextday.AddDays(1), DayOfWeek.Monday);
            DateTime lastDate = GetLastDateOfWeek(dtnextday.AddDays(1), DayOfWeek.Sunday);
            txtFromDate.SelectedDate = firstDate;

            lblfirstdate.Text = firstDate.ToString("MM/dd/yyyy");
            lblLastDate.Text = lastDate.ToString("MM/dd/yyyy");
            BindDetails();
        }

        private DateTime GetFirstDateOfWeek(DateTime dayInWeek, DayOfWeek firstDay)
        {
            DateTime firstDayInWeek = dayInWeek.Date;
            while (firstDayInWeek.DayOfWeek != firstDay)
                firstDayInWeek = firstDayInWeek.AddDays(-1);

            return firstDayInWeek;
        }

        private DateTime GetLastDateOfWeek(DateTime dayInWeek, DayOfWeek firstDay)
        {
            DateTime lastDayInWeek = dayInWeek.Date;
            while (lastDayInWeek.DayOfWeek != firstDay)
                lastDayInWeek = lastDayInWeek.AddDays(1);

            return lastDayInWeek;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindDetails();
        }

        private void BindDetails()
        {
            string clientID = string.Empty;
            clientID = new SurveyBL().GetPortalClientId().ToString();

            DataSet objDataSet = new SurveyBL().SurveyDisplay(clientID, Convert.ToDateTime(lblfirstdate.Text), Convert.ToDateTime(lblLastDate.Text));
            PlaceSurveyQuestions.Controls.Clear();
            for (int i = 0; i < objDataSet.Tables[1].Rows.Count; i++)
            {
                HtmlGenericControl Div = new HtmlGenericControl("DIV");
                Div.ID = "Survey_" + i;
                Div.Attributes.Add("class", "testMain");
                HtmlGenericControl createDiv = new HtmlGenericControl("DIV");
                int QID = Convert.ToInt32(objDataSet.Tables[1].Rows[i]["QID"].ToString());
                createDiv.ID = "Q" + QID;
                createDiv.Attributes.Add("class", "Question_heading");
                createDiv.InnerHtml = "<strong>" + objDataSet.Tables[1].Rows[i]["QText"].ToString() + "</strong>";
                HtmlGenericControl answersDiv = new HtmlGenericControl("DIV");
                answersDiv.ID = "A" + objDataSet.Tables[1].Rows[i]["QID"].ToString();
                answersDiv.Attributes.Add("class", "Answer");
                answersDiv.InnerHtml = "Answered : " + objDataSet.Tables[1].Rows[i]["Answered"].ToString() + "  &nbsp;&nbsp;Skipped : " + objDataSet.Tables[1].Rows[i]["Skipped"].ToString();
                if (objDataSet.Tables[1].Rows[i]["QTypeID"].ToString() != "5" && objDataSet.Tables[1].Rows[i]["QTypeID"].ToString() != "4")
                {
                    Div.Controls.Add(createDiv);
                    Div.Controls.Add(answersDiv);

                    if (objDataSet.Tables[2].Rows.Count > 0)
                    {
                        DataTable tblFiltered = objDataSet.Tables[2].AsEnumerable()
                             .Where(r => r.Field<int>("QID") == QID)
                             .CopyToDataTable();


                        int val;
                        var maxVal = tblFiltered.AsEnumerable()
                                .Where(rw => int.TryParse(rw["value"].ToString(), out val))
                                .Select(rw => Convert.ToInt32(rw["value"])).Max();


                        if (tblFiltered.Rows.Count > 0)
                        {
                            HtmlGenericControl DIVBar = new HtmlGenericControl("DIVBar");
                            decimal sum = Convert.ToDecimal(tblFiltered.Compute("SUM(vcounts)", string.Empty));
                            decimal WeightedAvg;
                            try
                            {
                                WeightedAvg = (sum / Convert.ToDecimal(tblFiltered.Rows[0]["Total"]));
                            }
                            catch
                            {
                                WeightedAvg = 0;
                            }
                            DataTable dtCount = new DataTable();
                            dtCount.Columns.Add("Count", typeof(decimal));
                            dtCount.Rows.Add(string.Format("{0:0.00}", WeightedAvg));

                            RadHtmlChart objBarChart = new RadHtmlChart();
                            objBarChart.ID = "rdAnsweredCount" + QID;
                            objBarChart.Height = Unit.Pixel(100);
                            BarSeries objBarSeries = new BarSeries();
                            objBarSeries.Stacked = false;
                            objBarSeries.DataFieldY = "Count";
                            objBarSeries.LabelsAppearance.Visible = true;
                            objBarChart.Appearance.FillStyle.BackgroundColor = System.Drawing.Color.White;
                            objBarChart.Legend.Appearance.Visible = false;
                            objBarChart.PlotArea.YAxis.MaxValue = maxVal;

                            objBarChart.PlotArea.XAxis.MinorGridLines.Visible = false;
                            objBarChart.PlotArea.XAxis.MajorGridLines.Visible = false;
                            objBarChart.PlotArea.XAxis.MajorTickType = Telerik.Web.UI.HtmlChart.TickType.None;
                            objBarChart.PlotArea.XAxis.MinorTickType = Telerik.Web.UI.HtmlChart.TickType.Outside;
                            objBarChart.PlotArea.XAxis.Reversed = true;

                            objBarChart.PlotArea.YAxis.Step = 1;
                            objBarChart.PlotArea.YAxis.TitleAppearance.Text = string.Empty;
                            objBarChart.PlotArea.YAxis.MinorGridLines.Visible = false;
                            objBarChart.PlotArea.YAxis.MajorGridLines.Visible = false;
                            objBarChart.PlotArea.YAxis.Reversed = false;

                            objBarChart.PlotArea.Series.Add(objBarSeries);
                            objBarChart.DataSource = dtCount;
                            objBarChart.DataBind();

                            DIVBar.Controls.Add(objBarChart);
                            Div.Controls.Add(DIVBar);

                            HtmlTable htTable = new HtmlTable();
                            htTable.Align = "center";
                            htTable.Border = 0;
                            htTable.Width = "80%";
                            htTable.CellPadding = 0;
                            htTable.CellSpacing = 0;
                            HtmlTableRow htRow = new HtmlTableRow();

                            for (int h = 0; h < tblFiltered.Rows.Count; h++)
                            {
                                HtmlTableCell htCell = new HtmlTableCell();
                                Literal lt = new Literal();
                                lt.ID = QID + "_" + h;
                                lt.Text = "<div class='Tbheader'>" + tblFiltered.Rows[h]["answertext"].ToString() + "</div><div class='Tbheader1'>" + tblFiltered.Rows[h]["value"].ToString() + "</div>" + "<div class='Tbcell'>" + tblFiltered.Rows[h]["Percentage"].ToString() + " % <br>" + tblFiltered.Rows[h]["Answercounts"].ToString() + "</div>";
                                htCell.Controls.Add(lt);
                                htRow.Cells.Add(htCell);
                            }

                            HtmlTableCell htTotal = new HtmlTableCell();
                            Literal ltTotal = new Literal();
                            ltTotal.ID = QID + "_Total";
                            ltTotal.Text = "<div class='Tbheader'>Total</div><div class='Tbheader1'>&nbsp;" + "</div>" + "<div class='Tbcell'>" + tblFiltered.Rows[0]["Total"] + "<br>&nbsp;</div>";
                            htTotal.Controls.Add(ltTotal);
                            htRow.Cells.Add(htTotal);

                            HtmlTableCell htWeight = new HtmlTableCell();
                            Literal ltWeight = new Literal();
                            ltWeight.ID = QID + "_Weight";
                            ltWeight.Text = "<div class='Tbheader'>Weighted Averages</div><div class='Tbheader1'>&nbsp;" + "</div>" + "<div class='Tbcell'>" + string.Format("{0:0.00}", WeightedAvg) + "<br>&nbsp;</div>";
                            htWeight.Controls.Add(ltWeight);
                            htRow.Cells.Add(htWeight);

                            htTable.Rows.Add(htRow);
                            Div.Controls.Add(htTable);
                        }
                    }
                }
                else
                {
                    Div.Controls.Add(createDiv);
                    Div.Controls.Add(answersDiv);
                    if (objDataSet.Tables[3].Rows.Count > 0)
                    {
                        DataTable tblFiltered = objDataSet.Tables[3].AsEnumerable()
                             .Where(r => r.Field<int>("QID") == QID)
                             .CopyToDataTable();
                        //HtmlGenericControl divAN = new HtmlGenericControl("DIVAN");
                        // divAN.Attributes.Add("class", "Pcontent");
                        HtmlTable htTable = new HtmlTable();
                        htTable.Attributes.Add("class", "Pcontent");
                        htTable.Align = "center";
                        htTable.Border = 0;
                        htTable.Width = "80%";
                        htTable.CellPadding = 0;
                        htTable.CellSpacing = 0;

                        //HtmlGenericControl div = new HtmlGenericControl();
                        //div.Attributes.Add("class", "listitem");
                        for (int j = 0; j < tblFiltered.Rows.Count; j++)
                        {
                            HtmlTableRow htRow = new HtmlTableRow();
                            HtmlTableCell htCell = new HtmlTableCell();

                            Literal ltAnswers = new Literal();
                            ltAnswers.ID = QID + "_" + j;
                            ltAnswers.Text = "<div class='Tbcell1'>" + tblFiltered.Rows[j]["Response"].ToString() + "</br>" +
                                 tblFiltered.Rows[j]["Name"].ToString() + " &nbsp;&nbsp;" + tblFiltered.Rows[j]["CreatedDate"].ToString() + "</div>";
                            htCell.Controls.Add(ltAnswers);
                            htRow.Controls.Add(htCell);
                            htTable.Controls.Add(htRow);
                            //div.Controls.Add(div1);
                        }
                        // divAN.Controls.Add(htTable);
                        Div.Controls.Add(htTable);
                    }
                }
                PlaceSurveyQuestions.Controls.Add(Div);
            }
        }

       

        protected void lnkAll_Click(object sender, EventArgs e)
        {
            Response.Redirect("Surveydetails.aspx?fdate=" + AppSecurity.Encrypt(lblfirstdate.Text) + "&ldate=" + AppSecurity.Encrypt(lblLastDate.Text)); 
        }

        protected void lnkIndividual_Click(object sender, EventArgs e)
        {
            Response.Redirect("AllResponsesReport.aspx?fdate=" + AppSecurity.Encrypt(lblfirstdate.Text) + "&ldate=" + AppSecurity.Encrypt(lblLastDate.Text));
        }
        
        //Export 
        protected void BtnExportToExcel_Click(object sender, EventArgs e)
        {
            string clientID = string.Empty;
            clientID = new SurveyBL().GetPortalClientId().ToString();

            DataSet objDataSet = new SurveyBL().SurveyDisplay(clientID, Convert.ToDateTime(lblfirstdate.Text), Convert.ToDateTime(lblLastDate.Text));

            FileInfo rptFileName = new FileInfo(Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["Reports"].ToString()) + @"\Survey Responses from_" + lblfirstdate.Text.Replace("/", "-").Replace(":", "-") + ".xlsx");
            // If any file exists in this directory having name 'Sample1.xlsx', then delete it
            if (rptFileName.Exists)
            {
                rptFileName.Delete(); // ensures we create a new workbook
                rptFileName = new FileInfo(Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["Reports"].ToString()) + @"\Survey Responses from_" + lblfirstdate.Text.Replace("/", "-").Replace(":", "-") + ".xlsx");
            }


            if (objDataSet != null & objDataSet.Tables.Count > 0)
            {
                ExcelSheetGenerator objExcel = new ExcelSheetGenerator();
                objExcel.GenerateReportGraph(objDataSet, rptFileName, "Survey Responses", "UserName", Convert.ToDateTime(lblfirstdate.Text), Convert.ToDateTime(lblLastDate.Text));
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AppendHeader("Content-Disposition", "attachment; filename=\"" + "Examity Survey Responses Report From -" + lblfirstdate.Text.Replace("/", "-").Replace(":", "-") + " " + lblLastDate.Text.Replace("/", "-").Replace(":", "-") + "" + ".xlsx");
                Response.TransmitFile(rptFileName.ToString());
                Response.End();
            }
        }
    }
}