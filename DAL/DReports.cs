using System;
using BusinessEntities;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
   public class DReports
    {
       public string ConnString = System.Configuration.ConfigurationManager.ConnectionStrings["SecureProctor"].ToString();

       public void DGETLAUNCHTIMEREPORT(BEReports objBEReports)
       {
           SqlParameter[] objPara = new SqlParameter[2];
           objPara[0] = new SqlParameter("@V_StartDate", SqlDbType.VarChar, 20);
           objPara[0].Value = objBEReports.StartDate.ToShortDateString();
           objPara[1] = new SqlParameter("@V_EndDate", SqlDbType.VarChar, 20);
           objPara[1].Value = objBEReports.EndDate.ToShortDateString();
           objBEReports.dsResult = SQLHelper.ExecuteDataset(ConnString, "USP_GetLaunchTimeReport", objPara);
       }
    }
}
