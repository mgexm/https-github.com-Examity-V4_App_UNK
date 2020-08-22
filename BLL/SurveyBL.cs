using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

using System.Configuration;
using DAL;

namespace BLL
{
    public class SurveyBL
    {
        public string Question { get; set; }
        public string Answer { get; set; }

        public string Response { get; set; }
        public string Date { get; set; }
        public int Value1 { get; set; }
        public int Value2 { get; set; }
        public int Value3 { get; set; }
        public int Value4 { get; set; }
        public int Value5 { get; set; }
        public int Count { get; set; }

        public string VeryDissatisfied { get; set; }
        public string Dissatisfied { get; set; }
        public string Neutral { get; set; }
        public string Satisfied { get; set; }
        public string VerySatisfied { get; set; }
        public double Total { get; set; }
        public double WeightedAvg { get; set; }


        public DataTable GetSurveyTemplateQuestions(int clientId)
        {
            SqlParameter[] objSqlParam = new SqlParameter[5];
            objSqlParam[0] = new SqlParameter("@V_ClientID", SqlDbType.Int);
            objSqlParam[0].Value = clientId;

            return SQLHelper.ExecuteDataset(DConConfig.ConnectionStringPortal, CommandType.StoredProcedure, "USP_GetTemplateQuestions", objSqlParam).Tables[0];
        }
        public DataSet GetSurveyTemplateAnswerResponses(int clientId, int templateId, int qId, DateTime startdate, DateTime enddate, int isgolivedate)
        {
            SqlParameter[] objSqlParam = new SqlParameter[8];
            objSqlParam[0] = new SqlParameter("@V_ClientID", SqlDbType.Int);
            objSqlParam[0].Value = clientId;
            objSqlParam[1] = new SqlParameter("@V_TemplateID", SqlDbType.Int);
            objSqlParam[1].Value = templateId;
            objSqlParam[2] = new SqlParameter("@V_QID", SqlDbType.Int);
            objSqlParam[2].Value = qId;
            objSqlParam[3] = new SqlParameter("@V_FromDate", SqlDbType.DateTime);
            objSqlParam[3].Value = startdate;
            objSqlParam[4] = new SqlParameter("@V_ToDate", SqlDbType.DateTime);
            objSqlParam[4].Value = enddate;
            objSqlParam[5] = new SqlParameter("@I_isgolivedate", SqlDbType.Int);
            objSqlParam[5].Value = isgolivedate;

            return SQLHelper.ExecuteDataset(DConConfig.ConnectionStringPortal, CommandType.StoredProcedure, "USP_GetExamitySurveyAnswerResponses_new", objSqlParam);
        }

        public DataSet GetSurveyResponsePercentage(int clientId, int templateId, int qId,DateTime startdate,DateTime enddate,int isgolivedate)
        {
            SqlParameter[] objSqlParam = new SqlParameter[8];
            objSqlParam[0] = new SqlParameter("@V_ClientId", SqlDbType.Int);
            objSqlParam[0].Value = clientId;
            objSqlParam[1] = new SqlParameter("@V_Tid", SqlDbType.Int);
            objSqlParam[1].Value = templateId;
            objSqlParam[2] = new SqlParameter("@V_Qid", SqlDbType.Int);
            objSqlParam[2].Value = qId;
            objSqlParam[3] = new SqlParameter("@V_FromDate", SqlDbType.DateTime);
            objSqlParam[3].Value = startdate;
            objSqlParam[4] = new SqlParameter("@V_ToDate", SqlDbType.DateTime);
            objSqlParam[4].Value = enddate;
            objSqlParam[5] = new SqlParameter("@I_isgolivedate", SqlDbType.Int);
            objSqlParam[5].Value = isgolivedate;

            return SQLHelper.ExecuteDataset(DConConfig.ConnectionStringPortal, CommandType.StoredProcedure, "USP_GetExamitySurveyResponsePercentage_new", objSqlParam);
        }
        public DataTable GetIndividualResponseReportData(int clientID, DateTime strDate, DateTime endDate)
        {
            SqlParameter[] objSqlParam = new SqlParameter[3];
            objSqlParam[0] = new SqlParameter("@clientID", SqlDbType.Int);
            objSqlParam[0].Value = clientID;
            objSqlParam[1] = new SqlParameter("@strDate", SqlDbType.DateTime);
            objSqlParam[1].Value = strDate;
            objSqlParam[2] = new SqlParameter("@endDate", SqlDbType.DateTime);
            objSqlParam[2].Value = endDate;


            //return SQLHelper.ExecuteDataset(conString, CommandType.StoredProcedure, "USP_ExamitySurvey_GetIndividualResponseReport", objSqlParam).Tables[0];
            return SQLHelper.ExecuteDataset(DConConfig.ConnectionStringPortal, CommandType.StoredProcedure, "USP_ExamitySurvey_GetIndividualResponseReportNew", objSqlParam).Tables[0];
        }
        public DataSet GetSurveyIndividualReport(string clientId, string studentName, int examID, DateTime fromDate, DateTime toDate)
        {
            SqlParameter[] objSqlParam = new SqlParameter[5];
            objSqlParam[0] = new SqlParameter("@V_ClientID", SqlDbType.VarChar, 8000);
            objSqlParam[0].Value = clientId;
            objSqlParam[1] = new SqlParameter("@V_Name", SqlDbType.VarChar, 8000);
            objSqlParam[1].Value = studentName;
            objSqlParam[2] = new SqlParameter("@V_ExamID", SqlDbType.BigInt);
            objSqlParam[2].Value = examID;
            objSqlParam[3] = new SqlParameter("@V_FromDate", SqlDbType.VarChar, 100);
            objSqlParam[3].Value = fromDate.ToShortDateString();
            objSqlParam[4] = new SqlParameter("@V_ToDate", SqlDbType.VarChar, 100);
            objSqlParam[4].Value = toDate.ToShortDateString();

            return SQLHelper.ExecuteDataset(DConConfig.ConnectionStringPortal, CommandType.StoredProcedure, "USP_GETSurveyIndividualReport", objSqlParam);
        }
        public DataSet GetSurveyIndividualReport(string clientId, string studentName, int examID, DateTime fromDate, DateTime toDate, int ProviderId)
        {
            SqlParameter[] objSqlParam = new SqlParameter[6];
            objSqlParam[0] = new SqlParameter("@V_ClientID", SqlDbType.VarChar, 8000);
            objSqlParam[0].Value = clientId;
            objSqlParam[1] = new SqlParameter("@V_Name", SqlDbType.VarChar, 8000);
            objSqlParam[1].Value = studentName;
            objSqlParam[2] = new SqlParameter("@V_ExamID", SqlDbType.BigInt);
            objSqlParam[2].Value = examID;
            objSqlParam[3] = new SqlParameter("@V_FromDate", SqlDbType.VarChar, 100);
            objSqlParam[3].Value = fromDate.ToShortDateString();
            objSqlParam[4] = new SqlParameter("@V_ToDate", SqlDbType.VarChar, 100);
            objSqlParam[4].Value = toDate.ToShortDateString();
            objSqlParam[5] = new SqlParameter("@I_ProviderId", SqlDbType.BigInt);
            objSqlParam[5].Value = ProviderId;

            return SQLHelper.ExecuteDataset(DConConfig.ConnectionStringPortal, CommandType.StoredProcedure, "USP_GETSurveyIndividualReport_Provider", objSqlParam);
        }
        public int GetPortalClientId()
        {
            SqlParameter[] objSqlParam = new SqlParameter[3];

            
            objSqlParam[0] = new SqlParameter("@I_Value", SqlDbType.Int);
            objSqlParam[0].Direction = ParameterDirection.Output;           

            SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, "USP_ExamitySurvey_GetPortalClientId", objSqlParam);

            return Convert.ToInt32(objSqlParam[0].Value.ToString());
        }
        public DateTime GetGoliveDate(int clientId)
        {
            SqlParameter[] objSqlParam = new SqlParameter[5];
            objSqlParam[0] = new SqlParameter("@V_ClientID", SqlDbType.VarChar, 8000);
            objSqlParam[0].Value = clientId;
            objSqlParam[1] = new SqlParameter("@D_GoliveDate", SqlDbType.DateTime);
            objSqlParam[1].Direction = ParameterDirection.Output;

            SQLHelper.ExecuteNonQuery(DConConfig.ConnectionStringPortal, CommandType.StoredProcedure, "USP_ExamitySurvey_GetClientGoliveDate", objSqlParam);

            return Convert.ToDateTime(objSqlParam[1].Value.ToString());
        }

        public DataSet SurveyDetails(string startDate, string enddate, string clientId)
        {
            SqlParameter[] objSqlParam = new SqlParameter[3];

            objSqlParam[0] = new SqlParameter("@V_StartDate", SqlDbType.VarChar, 20);
            objSqlParam[0].Value = startDate;
            objSqlParam[1] = new SqlParameter("@V_EndDate", SqlDbType.VarChar, 20);
            objSqlParam[1].Value = enddate;
            objSqlParam[2] = new SqlParameter("@V_ClientId", SqlDbType.VarChar, 20);
            objSqlParam[2].Value = clientId;

            return SQLHelper.ExecuteDataset(DConConfig.ConnectionStringPortal, CommandType.StoredProcedure, "USP_ExamitySurveyDetails", objSqlParam);
        }
        public DataSet SurveyDetails(string startDate, string enddate, string clientId, int ProviderId)
        {
            SqlParameter[] objSqlParam = new SqlParameter[5];

            objSqlParam[0] = new SqlParameter("@V_StartDate", SqlDbType.VarChar, 20);
            objSqlParam[0].Value = startDate;
            objSqlParam[1] = new SqlParameter("@V_EndDate", SqlDbType.VarChar, 20);
            objSqlParam[1].Value = enddate;
            objSqlParam[2] = new SqlParameter("@V_ClientId", SqlDbType.VarChar, 20);
            objSqlParam[2].Value = clientId;
            objSqlParam[3] = new SqlParameter("@I_ProviderId", SqlDbType.BigInt);
            objSqlParam[3].Value = ProviderId;

            return SQLHelper.ExecuteDataset(DConConfig.ConnectionStringPortal, CommandType.StoredProcedure, "USP_ExamitySurveyDetails_Provider", objSqlParam);
        }

        public DataSet SurveyDisplay(string clientId, DateTime firstDate, DateTime lastDate)
        {
            SqlParameter[] objSqlParam = new SqlParameter[3];
            objSqlParam[0] = new SqlParameter("@V_ClientId", SqlDbType.VarChar, 20);
            objSqlParam[0].Value = clientId;
            objSqlParam[1] = new SqlParameter("@V_StartDate", SqlDbType.DateTime);
            objSqlParam[1].Value = firstDate;
            objSqlParam[2] = new SqlParameter("@V_EndDate", SqlDbType.DateTime);
            objSqlParam[2].Value = lastDate;

            return SQLHelper.ExecuteDataset(DConConfig.ConnectionStringPortal, CommandType.StoredProcedure, "USP_Examity_SurveyResponse_Display", objSqlParam);
        }
        public DataSet SurveyDisplay(string clientId, int ProviderId, DateTime firstDate, DateTime lastDate)
        {
            SqlParameter[] objSqlParam = new SqlParameter[5];
            objSqlParam[0] = new SqlParameter("@V_ClientId", SqlDbType.VarChar, 20);
            objSqlParam[0].Value = clientId;
            objSqlParam[1] = new SqlParameter("@V_StartDate", SqlDbType.DateTime);
            objSqlParam[1].Value = firstDate;
            objSqlParam[2] = new SqlParameter("@V_EndDate", SqlDbType.DateTime);
            objSqlParam[2].Value = lastDate;
            objSqlParam[3] = new SqlParameter("@I_ProviderId", SqlDbType.BigInt);
            objSqlParam[3].Value = ProviderId;

            return SQLHelper.ExecuteDataset(DConConfig.ConnectionStringPortal, CommandType.StoredProcedure, "USP_Examity_SurveyResponse_Provider_Display", objSqlParam);
        }
       
    }
}