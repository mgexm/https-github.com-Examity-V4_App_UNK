using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;
using System.Text;
using Telerik.Web.UI;
using System.Globalization;

namespace SecureProctor.Admin
{
    public partial class QuestionSummaries_old : BaseClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               // txtFromDate.SelectedDate = DateTime.Now;

                DateTime firstDate = GetNextFirstDateOfWeek(DateTime.Now, DayOfWeek.Monday);
                DateTime lastDate = GetNextLastDateOfWeek(DateTime.Now, DayOfWeek.Sunday);

                //lblfirstdate.Text = firstDate.ToString("MM/dd/yyyy");
                //lblLastDate.Text = lastDate.ToString("MM/dd/yyyy");

                //if any dates in tabs selected the same dates should be displayed in all the tabs
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

                

                PopulatedGrids();
            }
        }

        //public static DateTime GetFirstDateOfWeek(DateTime dayInWeek, DayOfWeek firstDay)
        //{
        //    DateTime firstDayInWeek = dayInWeek.Date;
        //    while (firstDayInWeek.DayOfWeek != firstDay)
        //        firstDayInWeek = firstDayInWeek.AddDays(-1);

        //    DateTime previousWeekStart = firstDayInWeek.AddDays(-7);
        //    return previousWeekStart;
        //}
        //public static DateTime GetLastDateOfWeek(DateTime dayInWeek, DayOfWeek firstDay)
        //{
        //    DateTime lastDayInWeek = dayInWeek.Date;
        //    while (lastDayInWeek.DayOfWeek != firstDay)
        //        lastDayInWeek = lastDayInWeek.AddDays(-1);

        //    DateTime previousWeekEnd = lastDayInWeek.AddDays(-1);
        //    return previousWeekEnd;
        //}

        protected void txtFromDate_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
        {

            DateTime dt = (DateTime)txtFromDate.SelectedDate;
            CultureInfo c = txtFromDate.Calendar.CultureInfo;
            int weeknumber = c.Calendar.GetWeekOfYear(dt, c.DateTimeFormat.CalendarWeekRule, c.DateTimeFormat.FirstDayOfWeek);

            DateTime firstDate = GetNextFirstDateOfWeek(txtFromDate.SelectedDate.Value, DayOfWeek.Monday);
            DateTime lastDate = GetNextLastDateOfWeek(txtFromDate.SelectedDate.Value, DayOfWeek.Sunday);

            lblfirstdate.Text = firstDate.ToString("MM/dd/yyyy");
            lblLastDate.Text = lastDate.ToString("MM/dd/yyyy");
            PopulatedGrids();

        

        }
        private void PopulatedGrids()
        {
            int clientID = 0;
            // if (Request.QueryString["ClientID"] != null)
            {
                SurveyBL objSurvey1 = new SurveyBL();
                clientID = objSurvey1.GetPortalClientId();

                SurveyBL objSurvey2 = new SurveyBL();
                DateTime goliveDate = objSurvey2.GetGoliveDate(clientID);

                //getting the template questions
                SurveyBL objSurvey = new SurveyBL();
                DataTable dtMainQuestions = objSurvey.GetSurveyTemplateQuestions(clientID);


                //now we need to get the responses for each answer
                if (dtMainQuestions != null && dtMainQuestions.Rows.Count > 0)
                {
                    int templateId = Convert.ToInt32(dtMainQuestions.Rows[0]["TID"].ToString());



                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    ////Question 1
                    ////What did you like about Examity?
                    //DataSet dsQsa1 = objSurvey.GetSurveyTemplateAnswerResponses(clientID, templateId, Convert.ToInt32(dtMainQuestions.Rows[2][0])); //temporary qid
                    //lblQsa1.Text = dtMainQuestions.Rows[2]["QText"].ToString();
                    ////for displaying label count
                    //if (dsQsa1.Tables[0] != null && dsQsa1.Tables[0].Rows.Count > 0)
                    //    lblAnswerd1.Text = dsQsa1.Tables[0].Rows.Count.ToString();
                    //else
                    //    lblAnswerd1.Text = "0";
                    //if (dsQsa1.Tables[1] != null && dsQsa1.Tables[1].Rows.Count > 0)
                    //{
                    //    lblSkipped1.Text = dsQsa1.Tables[1].Rows[0][0].ToString();
                    //}
                    //else
                    //    lblSkipped1.Text = "0";

                    ////for displaying the responses with dates under it
                    //List<SurveyBL> lstSurveyQsa1 = new List<SurveyBL>();
                    //if (dsQsa1 != null && dsQsa1.Tables[0] != null && dsQsa1.Tables[0].Rows.Count > 0)
                    //{
                    //    foreach (DataRow dr in dsQsa1.Tables[0].Rows)
                    //    {
                    //        SurveyBL objBL = new SurveyBL();
                    //        objBL.Response = dr["Response"].ToString();
                    //        objBL.Date = dr["CreatedDate"].ToString();

                    //        objBL.Answer = dr["Response"].ToString() + " <br/>  " + Environment.NewLine + dr["CreatedDate"].ToString();
                    //        //objBL.Answer = objBL.Answer.Replace("TXT_", "");
                    //        lstSurveyQsa1.Add(objBL);
                    //    }
                    //}

                    //gvResponses.DataSource = lstSurveyQsa1;
                    //gvResponses.DataBind();

                    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    lblDates.Text = Convert.ToDateTime(lblfirstdate.Text).ToString("MMM dd yyyy")+" - "+  Convert.ToDateTime(lblLastDate.Text).ToString("MMM dd yyyy");

                    #region Question 2
                    //Question 2  
                    //How would you rate your proctor?
                    //binding graph grid
                    DataSet dtPer = objSurvey.GetSurveyResponsePercentage(clientID, templateId, Convert.ToInt32(dtMainQuestions.Rows[0][0]), Convert.ToDateTime(lblfirstdate.Text), Convert.ToDateTime(lblLastDate.Text),0);
                    lblQsa2.Text = dtMainQuestions.Rows[0]["QText"].ToString();
                    if (dtPer != null)
                    {
                        lblTotalExamsAns.Text = dtPer.Tables[3].Rows[0][0].ToString();
                        lblNoOfSurveysAns.Text = dtPer.Tables[2].Rows[0][0].ToString();
                    }
                    List<SurveyBL> lstPercent = new List<SurveyBL>();
                    if (dtPer != null && dtPer.Tables[1] != null && dtPer.Tables[1].Rows.Count > 0)
                    {
                        SurveyBL objPer = new SurveyBL();
                        DataRow[] dtRows;

                        //for counts
                        objPer.Response = "WGU Responses";
                        dtRows = dtPer.Tables[1].Select("AnswerText ='Very Dissatisfied'");
                        if (dtRows.Length > 0)
                        {
                            objPer.VeryDissatisfied = dtRows[0]["indCount"].ToString();
                            objPer.Value1 = Convert.ToInt32(dtRows[0]["value"]);
                        }
                        dtRows = dtPer.Tables[1].Select("AnswerText ='Dissatisfied'");
                        if (dtRows.Length > 0)
                        {
                            objPer.Dissatisfied = dtRows[0]["indCount"].ToString();
                            objPer.Value2 = Convert.ToInt32(dtRows[0]["value"]);
                        }
                        dtRows = dtPer.Tables[1].Select("AnswerText ='Neutral'");
                        if (dtRows.Length > 0)
                        {
                            objPer.Neutral = dtRows[0]["indCount"].ToString();
                            objPer.Value3 = Convert.ToInt32(dtRows[0]["value"]);
                        }
                        dtRows = dtPer.Tables[1].Select("AnswerText ='Satisfied'");
                        if (dtRows.Length > 0)
                        {
                            objPer.Satisfied = dtRows[0]["indCount"].ToString();
                            objPer.Value4 = Convert.ToInt32(dtRows[0]["value"]);
                        }
                        dtRows = dtPer.Tables[1].Select("AnswerText ='Very Satisfied'");
                        if (dtRows.Length > 0)
                        {
                            objPer.VerySatisfied = dtRows[0]["indCount"].ToString();
                            objPer.Value5 = Convert.ToInt32(dtRows[0]["value"]);
                        }

                        //total

                        objPer.Total = Math.Round(Convert.ToDouble(objPer.VeryDissatisfied) + Convert.ToDouble(objPer.Dissatisfied) + Convert.ToDouble(objPer.Neutral) + Convert.ToDouble(objPer.Satisfied) + Convert.ToDouble(objPer.VerySatisfied), 2);

                        //weighted average
                        objPer.WeightedAvg = Math.Round(((Convert.ToDouble(objPer.VeryDissatisfied) * objPer.Value1) + (Convert.ToDouble(objPer.Dissatisfied) * objPer.Value2) + (Convert.ToDouble(objPer.Neutral) * objPer.Value3) + (Convert.ToDouble(objPer.Satisfied) * objPer.Value4) + (Convert.ToDouble(objPer.VerySatisfied) * objPer.Value5)) / objPer.Total, 2);

                        //for percentages        
                        if (objPer.Total > 0)
                        {
                            objPer.VeryDissatisfied = Math.Round((Convert.ToDouble(objPer.VeryDissatisfied) * 100) / objPer.Total, 2).ToString() + "%" + "<br/>" + objPer.VeryDissatisfied;
                            objPer.Dissatisfied = Math.Round((Convert.ToDouble(objPer.Dissatisfied) * 100) / objPer.Total, 2).ToString() + "%" + "<br/>" + objPer.Dissatisfied;
                            objPer.Neutral = Math.Round((Convert.ToDouble(objPer.Neutral) * 100) / objPer.Total, 2).ToString() + "%" + "<br/>" + objPer.Neutral;
                            objPer.Satisfied = Math.Round((Convert.ToDouble(objPer.Satisfied) * 100) / objPer.Total, 2).ToString() + "%" + "<br/>" + objPer.Satisfied;
                            objPer.VerySatisfied = Math.Round((Convert.ToDouble(objPer.VerySatisfied) * 100) / objPer.Total, 2).ToString() + "%" + "<br/>" + objPer.VerySatisfied;
                        }

                        lstPercent.Add(objPer);

                        //datatable
                        DataTable dtTemp = new DataTable();
                        dtTemp.Columns.Add("Count", typeof(double));

                        dtTemp.Rows.Add(objPer.WeightedAvg);

                        rptAnsweredCount.DataSource = dtTemp;
                        rptAnsweredCount.DataBind();
                    }
                    else
                    {
                        DataTable dtTemp = new DataTable();
                        dtTemp.Columns.Add("Count", typeof(double));

                        dtTemp.Rows.Add(0.00);

                        rptAnsweredCount.DataSource = dtTemp;
                        rptAnsweredCount.DataBind();
                    }


                    rgvReponsePercentage.DataSource = lstPercent;
                    rgvReponsePercentage.DataBind();

                    //for building the graph
                    DataSet dsQsa2 = objSurvey.GetSurveyTemplateAnswerResponses(clientID, templateId, Convert.ToInt32(dtMainQuestions.Rows[0][0]), Convert.ToDateTime(lblfirstdate.Text), Convert.ToDateTime(lblLastDate.Text), 0); //temporary qid

                    //for displaying label count
                    if (dsQsa2.Tables[0] != null && dsQsa2.Tables[0].Rows.Count > 0)
                        lblAnswerd2.Text = dsQsa2.Tables[0].Rows.Count.ToString();
                    else
                        lblAnswerd2.Text = "0";
                    if (dsQsa2.Tables[1] != null && dsQsa2.Tables[1].Rows.Count > 0)
                    {
                        lblSkipped2.Text = dsQsa2.Tables[1].Rows[0][0].ToString();
                    }
                    else
                        lblSkipped2.Text = "0";

                    #endregion Question 2

                    #region Question 3
                    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                    //Question 3 
                    //How would you rate your overall experience with Examity?
                    //binding graph grid
                    DataSet dtPer2 = objSurvey.GetSurveyResponsePercentage(clientID, templateId, Convert.ToInt32(dtMainQuestions.Rows[1][0]), Convert.ToDateTime(lblfirstdate.Text), Convert.ToDateTime(lblLastDate.Text),0);
                    lblQsa3.Text = dtMainQuestions.Rows[1]["QText"].ToString();
                    List<SurveyBL> lstPercent1 = new List<SurveyBL>();
                    if (dtPer2 != null && dtPer2.Tables[1] != null && dtPer2.Tables[1].Rows.Count > 0)
                    {
                        SurveyBL objPer = new SurveyBL();
                        DataRow[] dtRows;

                        //for counts
                        objPer.Response = "WGU Responses";
                        dtRows = dtPer2.Tables[1].Select("AnswerText ='Very Dissatisfied'");
                        if (dtRows.Length > 0)
                        {
                            objPer.VeryDissatisfied = dtRows[0]["indCount"].ToString();
                            objPer.Value1 = Convert.ToInt32(dtRows[0]["value"]);
                        }
                        dtRows = dtPer2.Tables[1].Select("AnswerText ='Dissatisfied'");
                        if (dtRows.Length > 0)
                        {
                            objPer.Dissatisfied = dtRows[0]["indCount"].ToString();
                            objPer.Value2 = Convert.ToInt32(dtRows[0]["value"]);
                        }
                        dtRows = dtPer2.Tables[1].Select("AnswerText ='Neutral'");
                        if (dtRows.Length > 0)
                        {
                            objPer.Neutral = dtRows[0]["indCount"].ToString();
                            objPer.Value3 = Convert.ToInt32(dtRows[0]["value"]);
                        }
                        dtRows = dtPer2.Tables[1].Select("AnswerText ='Satisfied'");
                        if (dtRows.Length > 0)
                        {
                            objPer.Satisfied = dtRows[0]["indCount"].ToString();
                            objPer.Value4 = Convert.ToInt32(dtRows[0]["value"]);
                        }
                        dtRows = dtPer2.Tables[1].Select("AnswerText ='Very Satisfied'");
                        if (dtRows.Length > 0)
                        {
                            objPer.VerySatisfied = dtRows[0]["indCount"].ToString();
                            objPer.Value5 = Convert.ToInt32(dtRows[0]["value"]);
                        }

                        //total
                        objPer.Total = Math.Round(Convert.ToDouble(objPer.VeryDissatisfied) + Convert.ToDouble(objPer.Dissatisfied) + Convert.ToDouble(objPer.Neutral) + Convert.ToDouble(objPer.Satisfied) + Convert.ToDouble(objPer.VerySatisfied), 2);

                        //weighted average
                        objPer.WeightedAvg = Math.Round(((Convert.ToDouble(objPer.VeryDissatisfied) * objPer.Value1) + (Convert.ToDouble(objPer.Dissatisfied) * objPer.Value2) + (Convert.ToDouble(objPer.Neutral) * objPer.Value3) + (Convert.ToDouble(objPer.Satisfied) * objPer.Value4) + (Convert.ToDouble(objPer.VerySatisfied) * objPer.Value5)) / objPer.Total,2);

                        //for percentages
                        if (objPer.Total > 0)
                        {
                            objPer.VeryDissatisfied =Math.Round((Convert.ToDouble(objPer.VeryDissatisfied) * 100) / objPer.Total,2).ToString() + "%" + "<br/>" + objPer.VeryDissatisfied;
                            objPer.Dissatisfied = Math.Round((Convert.ToDouble(objPer.Dissatisfied) * 100) / objPer.Total,2).ToString() + "%" + "<br/>" + objPer.Dissatisfied;
                            objPer.Neutral = Math.Round((Convert.ToDouble(objPer.Neutral) * 100) / objPer.Total,2).ToString() + "%" + "<br/>" + objPer.Neutral;
                            objPer.Satisfied = Math.Round((Convert.ToDouble(objPer.Satisfied) * 100) / objPer.Total,2).ToString() + "%" + "<br/>" + objPer.Satisfied;
                            objPer.VerySatisfied =Math.Round((Convert.ToDouble(objPer.VerySatisfied) * 100) / objPer.Total,2).ToString() + "%" + "<br/>" + objPer.VerySatisfied;
                        }

                        lstPercent1.Add(objPer);

                        //datatable
                        DataTable dtTemp = new DataTable();
                        dtTemp.Columns.Add("Count", typeof(double));

                        dtTemp.Rows.Add(objPer.WeightedAvg);

                        rptAnsweredCount1.DataSource = dtTemp;
                        rptAnsweredCount1.DataBind();
                    }
                    else
                    {
                        DataTable dtTemp = new DataTable();
                        dtTemp.Columns.Add("Count", typeof(double));

                        dtTemp.Rows.Add(0.00);

                        rptAnsweredCount1.DataSource = dtTemp;
                        rptAnsweredCount1.DataBind();
                    }


                    rgvReponsePercentage1.DataSource = lstPercent1;
                    rgvReponsePercentage1.DataBind();

                    //for building the graph
                    DataSet dsQsa3 = objSurvey.GetSurveyTemplateAnswerResponses(clientID, templateId, Convert.ToInt32(dtMainQuestions.Rows[1][0]), Convert.ToDateTime(lblfirstdate.Text), Convert.ToDateTime(lblLastDate.Text), 0); //temporary qid

                    //for displaying label count
                    if (dsQsa3.Tables[0] != null && dsQsa3.Tables[0].Rows.Count > 0)
                        lblAnswerd3.Text = dsQsa3.Tables[0].Rows.Count.ToString();
                    else
                        lblAnswerd3.Text = "0";
                    if (dsQsa3.Tables[1] != null && dsQsa3.Tables[1].Rows.Count > 0)
                    {
                        lblSkipped3.Text = dsQsa3.Tables[1].Rows[0][0].ToString();
                    }
                    else
                        lblSkipped3.Text = "0";
                    #endregion Question 3

                    #region YQuestion 2

                    lblGoliveDate.Text = goliveDate.ToString("MMM dd yyyy") + " -  " + Convert.ToDateTime(lblLastDate.Text).ToString("MMM dd yyyy");
                    //Question 2  
                    //How would you rate your proctor?
                    //binding graph grid
                    DataSet dtYPer = objSurvey.GetSurveyResponsePercentage(clientID, templateId, Convert.ToInt32(dtMainQuestions.Rows[0][0]), Convert.ToDateTime(lblfirstdate.Text), Convert.ToDateTime(lblLastDate.Text), 1);
                    lblYQsa2.Text = dtMainQuestions.Rows[0]["QText"].ToString();
                    List<SurveyBL> lstYPercent = new List<SurveyBL>();
                    if (dtYPer != null && dtYPer.Tables[1] != null && dtYPer.Tables[1].Rows.Count > 0)
                    {
                        SurveyBL objPer = new SurveyBL();
                        DataRow[] dtRows;

                        //for counts
                        objPer.Response = "WGU Responses";
                        dtRows = dtYPer.Tables[1].Select("AnswerText ='Very Dissatisfied'");
                        if (dtRows.Length > 0)
                        {
                            objPer.VeryDissatisfied = dtRows[0]["indCount"].ToString();
                            objPer.Value1 = Convert.ToInt32(dtRows[0]["value"]);
                        }
                        dtRows = dtYPer.Tables[1].Select("AnswerText ='Dissatisfied'");
                        if (dtRows.Length > 0)
                        {
                            objPer.Dissatisfied = dtRows[0]["indCount"].ToString();
                            objPer.Value2 = Convert.ToInt32(dtRows[0]["value"]);
                        }
                        dtRows = dtYPer.Tables[1].Select("AnswerText ='Neutral'");
                        if (dtRows.Length > 0)
                        {
                            objPer.Neutral = dtRows[0]["indCount"].ToString();
                            objPer.Value3 = Convert.ToInt32(dtRows[0]["value"]);
                        }
                        dtRows = dtYPer.Tables[1].Select("AnswerText ='Satisfied'");
                        if (dtRows.Length > 0)
                        {
                            objPer.Satisfied = dtRows[0]["indCount"].ToString();
                            objPer.Value4 = Convert.ToInt32(dtRows[0]["value"]);
                        }
                        dtRows = dtYPer.Tables[1].Select("AnswerText ='Very Satisfied'");
                        if (dtRows.Length > 0)
                        {
                            objPer.VerySatisfied = dtRows[0]["indCount"].ToString();
                            objPer.Value5 = Convert.ToInt32(dtRows[0]["value"]);
                        }

                        //total
                        objPer.Total = Math.Round(Convert.ToDouble(objPer.VeryDissatisfied) + Convert.ToDouble(objPer.Dissatisfied) + Convert.ToDouble(objPer.Neutral) + Convert.ToDouble(objPer.Satisfied) + Convert.ToDouble(objPer.VerySatisfied),2);

                        //weighted average
                        objPer.WeightedAvg = Math.Round(((Convert.ToDouble(objPer.VeryDissatisfied) * objPer.Value1) + (Convert.ToDouble(objPer.Dissatisfied) * objPer.Value2) + (Convert.ToDouble(objPer.Neutral) * objPer.Value3) + (Convert.ToDouble(objPer.Satisfied) * objPer.Value4) + (Convert.ToDouble(objPer.VerySatisfied) * objPer.Value5)) / objPer.Total, 2);

                        //for percentages        
                        if (objPer.Total > 0)
                        {
                            objPer.VeryDissatisfied = Math.Round((Convert.ToDouble(objPer.VeryDissatisfied) * 100) / objPer.Total,2).ToString() + "%" + "<br/>" + objPer.VeryDissatisfied;
                            objPer.Dissatisfied = Math.Round((Convert.ToDouble(objPer.Dissatisfied) * 100) / objPer.Total, 2).ToString() + "%" + "<br/>" + objPer.Dissatisfied;
                            objPer.Neutral = Math.Round((Convert.ToDouble(objPer.Neutral) * 100) / objPer.Total, 2).ToString() + "%" + "<br/>" + objPer.Neutral;
                            objPer.Satisfied = Math.Round((Convert.ToDouble(objPer.Satisfied) * 100) / objPer.Total, 2).ToString() + "%" + "<br/>" + objPer.Satisfied;
                            objPer.VerySatisfied = Math.Round((Convert.ToDouble(objPer.VerySatisfied) * 100) / objPer.Total,2).ToString() + "%" + "<br/>" + objPer.VerySatisfied;
                        }

                        lstYPercent.Add(objPer);

                        //datatable
                        DataTable dtTemp = new DataTable();
                        dtTemp.Columns.Add("Count", typeof(double));

                        dtTemp.Rows.Add(objPer.WeightedAvg);
                        rptAnsweredCount2.DataSource = dtTemp;
                        rptAnsweredCount2.DataBind();
                       
                    }
                    else
                    {
                        DataTable dtTemp = new DataTable();
                        dtTemp.Columns.Add("Count", typeof(double));

                        dtTemp.Rows.Add(0.00);

                        rptAnsweredCount2.DataSource = dtTemp;
                        rptAnsweredCount2.DataBind();
                    }


                    rgvReponsePercentage2.DataSource = lstYPercent;
                    rgvReponsePercentage2.DataBind();

                    //for building the graph
                    DataSet dsYQsa2 = objSurvey.GetSurveyTemplateAnswerResponses(clientID, templateId, Convert.ToInt32(dtMainQuestions.Rows[0][0]), Convert.ToDateTime(lblfirstdate.Text), Convert.ToDateTime(lblLastDate.Text), 1); //temporary qid

                    //for displaying label count
                    if (dsYQsa2.Tables[0] != null && dsYQsa2.Tables[0].Rows.Count > 0)
                        lblYAnswerd2.Text = dsYQsa2.Tables[0].Rows.Count.ToString();
                    else
                        lblYAnswerd2.Text = "0";
                    if (dsYQsa2.Tables[1] != null && dsYQsa2.Tables[1].Rows.Count > 0)
                    {
                        lblYSkipped2.Text = dsYQsa2.Tables[1].Rows[0][0].ToString();
                    }
                    else
                        lblYSkipped2.Text = "0";

                    #endregion YQuestion 2

                    #region YQuestion 3
                    //Question 2  
                    //How would you rate your proctor?
                    //binding graph grid
                    DataSet dtYPer2 = objSurvey.GetSurveyResponsePercentage(clientID, templateId, Convert.ToInt32(dtMainQuestions.Rows[1][0]), Convert.ToDateTime(lblfirstdate.Text), Convert.ToDateTime(lblLastDate.Text), 1);
                    lblYQsa3.Text = dtMainQuestions.Rows[1]["QText"].ToString();
                    List<SurveyBL> lstYPercent2 = new List<SurveyBL>();
                    if (dtYPer2 != null && dtYPer2.Tables[1] != null && dtYPer2.Tables[1].Rows.Count > 0)
                    {
                        SurveyBL objPer = new SurveyBL();
                        DataRow[] dtRows;

                        //for counts
                        objPer.Response = "WGU Responses";
                        dtRows = dtYPer2.Tables[1].Select("AnswerText ='Very Dissatisfied'");
                        if (dtRows.Length > 0)
                        {
                            objPer.VeryDissatisfied = dtRows[0]["indCount"].ToString();
                            objPer.Value1 = Convert.ToInt32(dtRows[0]["value"]);
                        }
                        dtRows = dtYPer2.Tables[1].Select("AnswerText ='Dissatisfied'");
                        if (dtRows.Length > 0)
                        {
                            objPer.Dissatisfied = dtRows[0]["indCount"].ToString();
                            objPer.Value2 = Convert.ToInt32(dtRows[0]["value"]);
                        }
                        dtRows = dtYPer2.Tables[1].Select("AnswerText ='Neutral'");
                        if (dtRows.Length > 0)
                        {
                            objPer.Neutral = dtRows[0]["indCount"].ToString();
                            objPer.Value3 = Convert.ToInt32(dtRows[0]["value"]);
                        }
                        dtRows = dtYPer2.Tables[1].Select("AnswerText ='Satisfied'");
                        if (dtRows.Length > 0)
                        {
                            objPer.Satisfied = dtRows[0]["indCount"].ToString();
                            objPer.Value4 = Convert.ToInt32(dtRows[0]["value"]);
                        }
                        dtRows = dtYPer2.Tables[1].Select("AnswerText ='Very Satisfied'");
                        if (dtRows.Length > 0)
                        {
                            objPer.VerySatisfied = dtRows[0]["indCount"].ToString();
                            objPer.Value5 = Convert.ToInt32(dtRows[0]["value"]);
                        }

                        //total
                        objPer.Total = Math.Round(Convert.ToDouble(objPer.VeryDissatisfied) + Convert.ToDouble(objPer.Dissatisfied) + Convert.ToDouble(objPer.Neutral) + Convert.ToDouble(objPer.Satisfied) + Convert.ToDouble(objPer.VerySatisfied),2);

                        //weighted average
                        objPer.WeightedAvg = Math.Round(((Convert.ToDouble(objPer.VeryDissatisfied) * objPer.Value1) + (Convert.ToDouble(objPer.Dissatisfied) * objPer.Value2) + (Convert.ToDouble(objPer.Neutral) * objPer.Value3) + (Convert.ToDouble(objPer.Satisfied) * objPer.Value4) + (Convert.ToDouble(objPer.VerySatisfied) * objPer.Value5)) / objPer.Total,2);

                        //for percentages        
                        if (objPer.Total > 0)
                        {
                            objPer.VeryDissatisfied = Math.Round((Convert.ToDouble(objPer.VeryDissatisfied) * 100) / objPer.Total,2).ToString() + "%" + "<br/>" + objPer.VeryDissatisfied;
                            objPer.Dissatisfied = Math.Round((Convert.ToDouble(objPer.Dissatisfied) * 100) / objPer.Total, 2).ToString() + "%" + "<br/>" + objPer.Dissatisfied;
                            objPer.Neutral = Math.Round((Convert.ToDouble(objPer.Neutral) * 100) / objPer.Total, 2).ToString() + "%" + "<br/>" + objPer.Neutral;
                            objPer.Satisfied = Math.Round((Convert.ToDouble(objPer.Satisfied) * 100) / objPer.Total, 2).ToString() + "%" + "<br/>" + objPer.Satisfied;
                            objPer.VerySatisfied = Math.Round((Convert.ToDouble(objPer.VerySatisfied) * 100) / objPer.Total, 2).ToString() + "%" + "<br/>" + objPer.VerySatisfied;
                        }

                        lstYPercent2.Add(objPer);

                        //datatable
                        DataTable dtTemp = new DataTable();
                        dtTemp.Columns.Add("Count", typeof(Double));

                        dtTemp.Rows.Add(objPer.WeightedAvg);

                        rptAnsweredCount3.DataSource = dtTemp;
                        rptAnsweredCount3.DataBind();
                    }
                    else
                    {
                        DataTable dtTemp = new DataTable();
                        dtTemp.Columns.Add("Count", typeof(double));

                        dtTemp.Rows.Add(0.00);

                        rptAnsweredCount3.DataSource = dtTemp;
                        rptAnsweredCount3.DataBind();
                    }

                    rgvReponsePercentage3.DataSource = lstYPercent2;
                    rgvReponsePercentage3.DataBind();

                    //for building the graph
                    DataSet dsYQsa3 = objSurvey.GetSurveyTemplateAnswerResponses(clientID, templateId, Convert.ToInt32(dtMainQuestions.Rows[1][0]), Convert.ToDateTime(lblfirstdate.Text), Convert.ToDateTime(lblLastDate.Text), 1); //temporary qid

                    //for displaying label count
                    if (dsYQsa3.Tables[0] != null && dsYQsa3.Tables[0].Rows.Count > 0)
                        lblYAnswerd3.Text = dsYQsa3.Tables[0].Rows.Count.ToString();
                    else
                        lblYAnswerd3.Text = "0";
                    if (dsYQsa3.Tables[1] != null && dsYQsa3.Tables[1].Rows.Count > 0)
                    {
                        lblySkipped3.Text = dsYQsa3.Tables[1].Rows[0][0].ToString();
                    }
                    else
                        lblySkipped3.Text = "0";

                    #endregion YQuestion 3


                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    ////Question 4
                    ////What did you not like about Examity?
                    //DataSet dsQsa4 = objSurvey.GetSurveyTemplateAnswerResponses(clientID, templateId, Convert.ToInt32(dtMainQuestions.Rows[3][0])); //temporary qid
                    //lblQsa4.Text = dtMainQuestions.Rows[3]["QText"].ToString();
                    ////for displaying label count
                    //if (dsQsa4.Tables[0] != null && dsQsa4.Tables[0].Rows.Count > 0)
                    //    lblAnswerd4.Text = dsQsa4.Tables[0].Rows.Count.ToString();
                    //else
                    //    lblAnswerd4.Text = "0";
                    //if (dsQsa4.Tables[1] != null && dsQsa4.Tables[1].Rows.Count > 0)
                    //{
                    //    lblSkipped4.Text = dsQsa4.Tables[1].Rows[0][0].ToString();
                    //}
                    //else
                    //    lblSkipped4.Text = "0";

                    ////for displaying the responses with dates under it
                    //List<SurveyBL> lstSurveyQsa2 = new List<SurveyBL>();
                    //if (dsQsa4 != null && dsQsa4.Tables[0] != null && dsQsa4.Tables[0].Rows.Count > 0)
                    //{
                    //    foreach (DataRow dr in dsQsa4.Tables[0].Rows)
                    //    {
                    //        SurveyBL objBL = new SurveyBL();
                    //        objBL.Response = dr["Response"].ToString();
                    //        objBL.Date = dr["CreatedDate"].ToString();

                    //        objBL.Answer = dr["Response"].ToString() + " <br/>  " + Environment.NewLine + dr["CreatedDate"].ToString();
                    //        // objBL.Answer = objBL.Answer.Replace("TXT_", "");
                    //        lstSurveyQsa2.Add(objBL);
                    //    }
                    //}

                    //gvResponses1.DataSource = lstSurveyQsa2;
                    //gvResponses1.DataBind();


                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    ////Question 5
                    ////Additional comments?
                    //DataSet dsQsa5 = objSurvey.GetSurveyTemplateAnswerResponses(clientID, templateId, Convert.ToInt32(dtMainQuestions.Rows[4][0])); //temporary qid
                    //lblQsa5.Text = dtMainQuestions.Rows[4]["QText"].ToString();
                    ////for displaying label count
                    //if (dsQsa5.Tables[0] != null && dsQsa5.Tables[0].Rows.Count > 0)
                    //    lblAnswerd5.Text = dsQsa5.Tables[0].Rows.Count.ToString();
                    //else
                    //    lblAnswerd5.Text = "0";
                    //if (dsQsa5.Tables[1] != null && dsQsa5.Tables[1].Rows.Count > 0)
                    //{
                    //    lblSkipped5.Text = dsQsa5.Tables[1].Rows[0][0].ToString();
                    //}
                    //else
                    //    lblSkipped5.Text = "0";

                    ////for displaying the responses with dates under it
                    //List<SurveyBL> lstSurveyQsa3 = new List<SurveyBL>();
                    //if (dsQsa5 != null && dsQsa5.Tables[0] != null && dsQsa5.Tables[0].Rows.Count > 0)
                    //{
                    //    foreach (DataRow dr in dsQsa5.Tables[0].Rows)
                    //    {
                    //        SurveyBL objBL = new SurveyBL();
                    //        objBL.Response = dr["Response"].ToString();
                    //        objBL.Date = dr["CreatedDate"].ToString();

                    //        objBL.Answer = dr["Response"].ToString() + " <br/>  " + Environment.NewLine + dr["CreatedDate"].ToString();
                    //        // objBL.Answer = objBL.Answer.Replace("TXT_", "");
                    //        lstSurveyQsa3.Add(objBL);
                    //    }
                    //}

                    //gvResponses2.DataSource = lstSurveyQsa3;
                    //gvResponses2.DataBind();


                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    ////Question 5
                    ////Computer/Operating System used for this test.
                    //DataSet dsQsa6 = objSurvey.GetSurveyTemplateAnswerResponses(clientID, templateId, Convert.ToInt32(dtMainQuestions.Rows[6][0])); //temporary qid
                    //lblQsa6.Text = dtMainQuestions.Rows[6]["QText"].ToString();
                    ////for displaying label count
                    //if (dsQsa6.Tables[0] != null && dsQsa6.Tables[0].Rows.Count > 0)
                    //    lblAnswerd6.Text = dsQsa6.Tables[0].Rows.Count.ToString();
                    //else
                    //    lblAnswerd6.Text = "0";
                    //if (dsQsa6.Tables[1] != null && dsQsa6.Tables[1].Rows.Count > 0)
                    //{
                    //    lblSkipped6.Text = dsQsa6.Tables[1].Rows[0][0].ToString();
                    //}
                    //else
                    //    lblSkipped6.Text = "0";

                    ////for displaying the responses with dates under it
                    //List<SurveyBL> lstSurveyQsa4 = new List<SurveyBL>();
                    //if (dsQsa6 != null && dsQsa6.Tables[0] != null && dsQsa6.Tables[0].Rows.Count > 0)
                    //{
                    //    foreach (DataRow dr in dsQsa6.Tables[0].Rows)
                    //    {
                    //        SurveyBL objBL = new SurveyBL();
                    //        objBL.Response = dr["Response"].ToString();
                    //        objBL.Date = dr["CreatedDate"].ToString();

                    //        objBL.Answer = dr["Response"].ToString() + " <br/>  " + Environment.NewLine + dr["CreatedDate"].ToString();
                    //        // objBL.Answer = objBL.Answer.Replace("TXT_", "");
                    //        lstSurveyQsa4.Add(objBL);
                    //    }
                    //}

                    //gvResponses3.DataSource = lstSurveyQsa4;
                    //gvResponses3.DataBind();


                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    ////Question 6 //I.D Number
                    //DataSet dsQsa7 = objSurvey.GetSurveyTemplateAnswerResponses(clientID, templateId, Convert.ToInt32(dtMainQuestions.Rows[5][0])); //temporary qid
                    //lblQsa7.Text = dtMainQuestions.Rows[5]["QText"].ToString();
                    ////for displaying label count
                    //if (dsQsa7.Tables[0] != null && dsQsa7.Tables[0].Rows.Count > 0)
                    //    lblAnswerd7.Text = dsQsa7.Tables[0].Rows.Count.ToString();
                    //else
                    //    lblAnswerd7.Text = "0";
                    //if (dsQsa7.Tables[1] != null && dsQsa7.Tables[1].Rows.Count > 0)
                    //{
                    //    lblSkipped7.Text = dsQsa7.Tables[1].Rows[0][0].ToString();
                    //}
                    //else
                    //    lblSkipped7.Text = "0";

                    ////for displaying the responses with dates under it
                    //List<SurveyBL> lstSurveyQsa5 = new List<SurveyBL>();
                    //if (dsQsa7 != null && dsQsa7.Tables[0] != null && dsQsa7.Tables[0].Rows.Count > 0)
                    //{
                    //    foreach (DataRow dr in dsQsa7.Tables[0].Rows)
                    //    {
                    //        SurveyBL objBL = new SurveyBL();
                    //        objBL.Response = dr["Response"].ToString();
                    //        objBL.Date = dr["CreatedDate"].ToString();

                    //        objBL.Answer = dr["Response"].ToString() + " <br/>  " + Environment.NewLine + dr["CreatedDate"].ToString();
                    //        // objBL.Answer = objBL.Answer.Replace("TXT_", "");
                    //        lstSurveyQsa5.Add(objBL);
                    //    }
                    //}

                    //gvResponses4.DataSource = lstSurveyQsa5;
                    //gvResponses4.DataBind();
                }
            }
        }

        protected void rgvReponsePercentage_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                //GridDataItem dataItem = e.Item as GridDataItem;
                SurveyBL ss = e.Item.DataItem as SurveyBL;
                //ss.VeryDissatisfied = ss.VeryDissatisfied / ss.Total * 100;

            }
        }

        protected void gvResponses_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                SurveyBL ss = e.Item.DataItem as SurveyBL;
                ss.Answer = ss.Response + " \n " + ss.Date;
            }
        }

        protected void btnleftarrow_Click(object sender, EventArgs e)
        {
            DateTime dtnextday = Convert.ToDateTime(lblfirstdate.Text);

            DateTime firstDate = GetNextFirstDateOfWeek(dtnextday.AddDays(-1), DayOfWeek.Monday);
            DateTime lastDate = GetNextLastDateOfWeek(dtnextday.AddDays(-1), DayOfWeek.Sunday);
            txtFromDate.SelectedDate = firstDate;

            lblfirstdate.Text = firstDate.ToString("MM/dd/yyyy");
            lblLastDate.Text = lastDate.ToString("MM/dd/yyyy");
            PopulatedGrids();
        }

        protected void btnrightarrow_Click(object sender, EventArgs e)
        {
            DateTime dtnextday = Convert.ToDateTime(lblLastDate.Text);

            DateTime firstDate = GetNextFirstDateOfWeek(dtnextday.AddDays(1), DayOfWeek.Monday);
            DateTime lastDate = GetNextLastDateOfWeek(dtnextday.AddDays(1), DayOfWeek.Sunday);
            txtFromDate.SelectedDate = firstDate;

            lblfirstdate.Text = firstDate.ToString("MM/dd/yyyy");
            lblLastDate.Text = lastDate.ToString("MM/dd/yyyy");
            PopulatedGrids();
        }

        public static DateTime GetNextFirstDateOfWeek(DateTime dayInWeek, DayOfWeek firstDay)
        {
            DateTime firstDayInWeek = dayInWeek.Date;
            while (firstDayInWeek.DayOfWeek != firstDay)
                firstDayInWeek = firstDayInWeek.AddDays(-1);

            return firstDayInWeek;
        }
        public static DateTime GetNextLastDateOfWeek(DateTime dayInWeek, DayOfWeek firstDay)
        {
            DateTime lastDayInWeek = dayInWeek.Date;
            while (lastDayInWeek.DayOfWeek != firstDay)
                lastDayInWeek = lastDayInWeek.AddDays(1);

            return lastDayInWeek;
        }

        protected void lnkAll_Click(object sender, EventArgs e)
        {
            Response.Redirect("Surveydetails.aspx?fdate=" + AppSecurity.Encrypt(lblfirstdate.Text) + "&ldate=" + AppSecurity.Encrypt(lblLastDate.Text));
        }

        protected void lnkIndividual_Click(object sender, EventArgs e)
        {
            Response.Redirect("AllResponsesReport.aspx?fdate=" + AppSecurity.Encrypt(lblfirstdate.Text) + "&ldate=" + AppSecurity.Encrypt(lblLastDate.Text));
        }

    }
}