using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using BLL;
using System.IO;

namespace SecureProctor.Provider
{
    public partial class Surveydetails : System.Web.UI.Page
    {
         
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                int clientID = 0;
               // txtFromDate.SelectedDate = DateTime.Now;

                DateTime firstDate = GetFirstDateOfWeek(DateTime.Now, DayOfWeek.Monday);
                DateTime lastDate = GetLastDateOfWeek(DateTime.Now, DayOfWeek.Sunday);

                //lblfirstdate.Text = firstDate.ToString("MM/dd/yyyy");
                //lblLastDate.Text = lastDate.ToString("MM/dd/yyyy");

                //if any dates in tabs selected the same dates should be displayed in all the tabs
                if (Request.QueryString["fdate"] != null && Request.QueryString["ldate"] != null)
                {
                   
                    
                    lblfirstdate.Text = AppSecurity.Decrypt(Request.QueryString["fdate"].ToString());
                    lblLastDate.Text = AppSecurity.Decrypt(Request.QueryString["ldate"].ToString());
                    
                    firstDate = Convert.ToDateTime(lblfirstdate.Text);
                    lastDate = Convert.ToDateTime(lblLastDate.Text);
                    txtFromDate.SelectedDate = firstDate;
                }
                else
                {
                    txtFromDate.SelectedDate = DateTime.Now;
                    lblfirstdate.Text = firstDate.ToString("MM/dd/yyyy");
                    lblLastDate.Text = lastDate.ToString("MM/dd/yyyy");
                }

                SurveyBL objSurvey = new SurveyBL();
                clientID = objSurvey.GetPortalClientId();
                hdnClientId.Value = clientID.ToString();
                int providerId = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID]);

                DataSet objResponse = new SurveyBL().SurveyDetails(firstDate.ToShortDateString(), lastDate.ToShortDateString(), clientID.ToString(), providerId);
                BindSurveyDetails(objResponse);

                //here we need to populate the tests and no of surveys
                //if (objResponse != null)
                //{
                //    lblTotalExamsAns.Text = objResponse.Tables[4].Rows[0][0].ToString();
                //    lblNoOfSurveysAns.Text = objResponse.Tables[3].Rows[0][0].ToString(); 
                //}
            }
        }
                
      
        private void BindSurveyDetails(DataSet objResponse)
        {
            DataTable dtSurvey = new DataTable();
            dtSurvey.Columns.Add("Id", typeof(string));
            dtSurvey.Columns.Add("AId", typeof(string));
            dtSurvey.Columns.Add("Name", typeof(string));
            dtSurvey.Columns.Add("From", typeof(string));
            dtSurvey.Columns.Add("Golive", typeof(string));

            for (int i = 0; i < objResponse.Tables[0].Rows.Count; i++)
            {
                dtSurvey.Rows.Add(-1, -1, "<strong>" + objResponse.Tables[0].Rows[i]["Name"].ToString() + "</strong>", "<strong>" + objResponse.Tables[0].Rows[i]["RatingFrom"].ToString() + "</strong>", "<strong>" + objResponse.Tables[0].Rows[i]["RatingGolive"].ToString() + "</strong>");

            }

            DataTable dtSurveyCounts = new DataTable();
            dtSurveyCounts.Columns.Add("Qid", typeof(string));
            dtSurveyCounts.Columns.Add("QText", typeof(string));
            dtSurveyCounts.Columns.Add("AnswerID", typeof(string));
            dtSurveyCounts.Columns.Add("AText", typeof(string));
            dtSurveyCounts.Columns.Add("FP", typeof(string));
            dtSurveyCounts.Columns.Add("GP", typeof(string));

            for (int k = 0; k < objResponse.Tables[2].Rows.Count; k++)
            {
                if (objResponse.Tables[1].Rows[k]["qid"].ToString() == objResponse.Tables[2].Rows[k]["qid"].ToString())
                {
                    dtSurveyCounts.Rows.Add(objResponse.Tables[1].Rows[k]["qid"].ToString(),
                                   objResponse.Tables[1].Rows[k]["Qtext"].ToString(),
                                   objResponse.Tables[1].Rows[k]["AnswerID"].ToString(),
                                   objResponse.Tables[1].Rows[k]["answertext"].ToString(),
                                   objResponse.Tables[1].Rows[k]["Percentage"].ToString(),
                                   objResponse.Tables[2].Rows[k]["Percentage"].ToString());
                }
            }

            for (int j = 0; j < dtSurveyCounts.Rows.Count; j++)
            {
                string Qid = dtSurveyCounts.Rows[j]["Qid"].ToString();
                bool Qidexists = dtSurvey.Select().ToList().Exists(row => row["Id"].ToString() == Qid);
                string qtext = dtSurveyCounts.Rows[j]["QText"].ToString(); //"Q" + Qid + ". " + 
                bool qtextexists = dtSurvey.Select().ToList().Exists(row => row["Name"].ToString() == qtext);
                if (!Qidexists && !qtextexists)
                {
                    dtSurvey.Rows.Add(Qid, 0, "<strong>" + qtext + "</strong>", string.Empty, string.Empty);
                    dtSurvey.Rows.Add(Qid, dtSurveyCounts.Rows[j]["AnswerID"].ToString(), dtSurveyCounts.Rows[j]["AText"].ToString(), dtSurveyCounts.Rows[j]["FP"].ToString() + "%", dtSurveyCounts.Rows[j]["GP"].ToString() + "%");
                }
                else
                {
                    bool Qidexists1 = dtSurvey.Select().ToList().Exists(row => row["Id"].ToString() == dtSurveyCounts.Rows[j]["Qid"].ToString());
                    bool Aidexists1 = dtSurvey.Select().ToList().Exists(row => row["AId"].ToString() == dtSurveyCounts.Rows[j]["AnswerID"].ToString());
                    if (Qidexists1 && !Aidexists1)
                    {
                        dtSurvey.Rows.Add(Qid, dtSurveyCounts.Rows[j]["AnswerID"].ToString(), dtSurveyCounts.Rows[j]["AText"].ToString(), dtSurveyCounts.Rows[j]["FP"].ToString() + "%", dtSurveyCounts.Rows[j]["GP"].ToString() + "%");
                    }
                }
            }
            gvResponses.DataSource = dtSurvey;
            gvResponses.DataBind();

            if (objResponse != null)
            {
                if (objResponse.Tables.Count > 4)
                {
                    lblTotalExamsAns.Text = objResponse.Tables[4].Rows[0][0].ToString();
                }
                lblNoOfSurveysAns.Text = objResponse.Tables[3].Rows[0][0].ToString();
            }
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

        protected void btnExport_Click(object sender, EventArgs e) 
        {
            DateTime firstDate = Convert.ToDateTime(lblfirstdate.Text);
            DateTime lastDate = Convert.ToDateTime(lblLastDate.Text);

            gvResponses.ExportSettings.IgnorePaging = true;
            gvResponses.ExportSettings.ExportOnlyData = true;
            gvResponses.ExportSettings.OpenInNewWindow = true;
            gvResponses.ExportSettings.FileName = "Survey details Report From " + firstDate.ToString("MM/dd/yyyy").Replace("/", "-").Replace(":", "-") + " " + lastDate.ToString("MM/dd/yyyy").Replace("/", "-").Replace(":", "-") + "";
          //  gvResponses.ExportSettings.Excel.FileExtension = "Xlsx";
            gvResponses.MasterTableView.ExportToExcel();
           // GenerateReport();
        }
        public void GenerateReport()
        {
            DateTime firstDate =Convert.ToDateTime(lblfirstdate.Text);
            DateTime lastDate = Convert.ToDateTime(lblLastDate.Text);

            int providerId = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID]);

            DataSet objResponse = new SurveyBL().SurveyDetails(firstDate.ToShortDateString(), lastDate.ToShortDateString(), hdnClientId.Value, providerId);

            DataTable dtSurvey = new DataTable();
            dtSurvey.Columns.Add("Id", typeof(string));
            dtSurvey.Columns.Add("AId", typeof(string));
            dtSurvey.Columns.Add("Name", typeof(string));
            dtSurvey.Columns.Add("From", typeof(string));
            dtSurvey.Columns.Add("Golive", typeof(string));

            for (int i = 0; i < objResponse.Tables[0].Rows.Count; i++)
            {
                dtSurvey.Rows.Add(-1, -1, "<strong>" + objResponse.Tables[0].Rows[i]["Name"].ToString() + "</strong>", "<strong>" + objResponse.Tables[0].Rows[i]["RatingFrom"].ToString() + "</strong>", "<strong>" + objResponse.Tables[0].Rows[i]["RatingGolive"].ToString() + "</strong>");
            }

            DataTable dtSurveyCounts = new DataTable();
            dtSurveyCounts.Columns.Add("Qid", typeof(string));
            dtSurveyCounts.Columns.Add("QText", typeof(string));
            dtSurveyCounts.Columns.Add("AnswerID", typeof(string));
            dtSurveyCounts.Columns.Add("AText", typeof(string));
            dtSurveyCounts.Columns.Add("FP", typeof(string));
            dtSurveyCounts.Columns.Add("GP", typeof(string));

            for (int k = 0; k < objResponse.Tables[2].Rows.Count; k++)
            {
                if (objResponse.Tables[1].Rows[k]["qid"].ToString() == objResponse.Tables[2].Rows[k]["qid"].ToString())
                {
                    dtSurveyCounts.Rows.Add(objResponse.Tables[1].Rows[k]["qid"].ToString(),
                                   objResponse.Tables[1].Rows[k]["Qtext"].ToString(),
                                   objResponse.Tables[1].Rows[k]["AnswerID"].ToString(),
                                   objResponse.Tables[1].Rows[k]["answertext"].ToString(),
                                   objResponse.Tables[1].Rows[k]["Percentage"].ToString(),
                                   objResponse.Tables[2].Rows[k]["Percentage"].ToString());
                }
            }

            for (int j = 0; j < dtSurveyCounts.Rows.Count; j++)
            {
                string Qid = dtSurveyCounts.Rows[j]["Qid"].ToString();
                bool Qidexists = dtSurvey.Select().ToList().Exists(row => row["Id"].ToString() == Qid);
                string qtext = "Q" + Qid + ". " + dtSurveyCounts.Rows[j]["QText"].ToString();
                bool qtextexists = dtSurvey.Select().ToList().Exists(row => row["Name"].ToString() == qtext);
                if (!Qidexists && !qtextexists)
                {
                    dtSurvey.Rows.Add(Qid, 0, "<strong>" + qtext + "</strong>", string.Empty, string.Empty);
                    dtSurvey.Rows.Add(Qid, dtSurveyCounts.Rows[j]["AnswerID"].ToString(), dtSurveyCounts.Rows[j]["AText"].ToString(), dtSurveyCounts.Rows[j]["FP"].ToString() + "%", dtSurveyCounts.Rows[j]["GP"].ToString() + "%");
                }
                else
                {
                    bool Qidexists1 = dtSurvey.Select().ToList().Exists(row => row["Id"].ToString() == dtSurveyCounts.Rows[j]["Qid"].ToString());
                    bool Aidexists1 = dtSurvey.Select().ToList().Exists(row => row["AId"].ToString() == dtSurveyCounts.Rows[j]["AnswerID"].ToString());
                    if (Qidexists1 && !Aidexists1)
                    {
                        dtSurvey.Rows.Add(Qid, dtSurveyCounts.Rows[j]["AnswerID"].ToString(), dtSurveyCounts.Rows[j]["AText"].ToString(), dtSurveyCounts.Rows[j]["FP"].ToString() + "%", dtSurveyCounts.Rows[j]["GP"].ToString() + "%");
                    }
                }
            }
            gvResponses.DataSource = dtSurvey;
            gvResponses.DataBind();


            FileInfo rptFileName = new FileInfo(Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["Reports"].ToString()) + @"Survey details_" + firstDate.ToString("MM/dd/yyyy").Replace("/", "-").Replace(":", "-") + ".xls");
            // If any file exists in this directory having name 'Sample1.xlsx', then delete it
            if (rptFileName.Exists)
            {
                rptFileName.Delete(); // ensures we create a new workbook
                rptFileName = new FileInfo(Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["Reports"].ToString()) + @"\Survey details from_" + firstDate.ToString("MM/dd/yyyy").Replace("/", "-").Replace(":", "-") + ".xls");
            }
            // this.DeleteHistoricFiles();
            ExcelSheetGenerator objExcel = new ExcelSheetGenerator();
            objExcel.GenerateReport(dtSurvey, rptFileName, "Surveydetails", "UserName");

            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AppendHeader("Content-Disposition", "attachment; filename=\"" + "Survey details Report From -" + firstDate.ToString("MM/dd/yyyy").Replace("/", "-").Replace(":", "-") + " " + lastDate.ToString("MM/dd/yyyy").Replace("/", "-").Replace(":", "-") + "" + ".xlsx");
            Response.TransmitFile(rptFileName.ToString());
            Response.End();
        }

        protected void txtFromDate_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
        {
            DateTime dt = (DateTime)txtFromDate.SelectedDate;


            DateTime firstDate = GetFirstDateOfWeek(txtFromDate.SelectedDate.Value, DayOfWeek.Monday);
            DateTime lastDate = GetLastDateOfWeek(txtFromDate.SelectedDate.Value, DayOfWeek.Sunday);

            lblfirstdate.Text = firstDate.ToString("MM/dd/yyyy");
            lblLastDate.Text = lastDate.ToString("MM/dd/yyyy");

            int providerId = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID]);


            DataSet objResponse = new SurveyBL().SurveyDetails(firstDate.ToShortDateString(), lastDate.ToShortDateString(), hdnClientId.Value, providerId);
             BindSurveyDetails(objResponse);
        }

        protected void btnleftarrow_Click(object sender, EventArgs e)
        {
            DateTime dtnextday = Convert.ToDateTime(lblfirstdate.Text);

            DateTime firstDate = GetFirstDateOfWeek(dtnextday.AddDays(-1), DayOfWeek.Monday);
            DateTime lastDate = GetLastDateOfWeek(dtnextday.AddDays(-1), DayOfWeek.Sunday);
            txtFromDate.SelectedDate = firstDate;

            lblfirstdate.Text = firstDate.ToString("MM/dd/yyyy");
            lblLastDate.Text = lastDate.ToString("MM/dd/yyyy");

            int providerId = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID]);

            DataSet objResponse = new SurveyBL().SurveyDetails(firstDate.ToShortDateString(), lastDate.ToShortDateString(), hdnClientId.Value, providerId);
             BindSurveyDetails(objResponse);

        }

        protected void btnrightarrow_Click(object sender, EventArgs e)
        {
            DateTime dtnextday = Convert.ToDateTime(lblLastDate.Text);

            DateTime firstDate = GetFirstDateOfWeek(dtnextday.AddDays(1), DayOfWeek.Monday);
            DateTime lastDate = GetLastDateOfWeek(dtnextday.AddDays(1), DayOfWeek.Sunday);
            txtFromDate.SelectedDate = firstDate;

            lblfirstdate.Text = firstDate.ToString("MM/dd/yyyy");
            lblLastDate.Text = lastDate.ToString("MM/dd/yyyy");


            int providerId = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID]);
            DataSet objResponse = new SurveyBL().SurveyDetails(firstDate.ToShortDateString(), lastDate.ToShortDateString(), hdnClientId.Value, providerId);
             BindSurveyDetails(objResponse);

        }

        protected void lnkQuestionSummary_Click(object sender, EventArgs e)
        {
            Response.Redirect("QuestionSummaries.aspx?fdate=" + AppSecurity.Encrypt(lblfirstdate.Text) + "&ldate=" + AppSecurity.Encrypt(lblLastDate.Text));
        }

        protected void lnkAll_Click(object sender, EventArgs e)
        {
            Response.Redirect("AllResponsesReport.aspx?fdate=" + AppSecurity.Encrypt(lblfirstdate.Text) + "&ldate=" + AppSecurity.Encrypt(lblLastDate.Text));
        }

    }
}