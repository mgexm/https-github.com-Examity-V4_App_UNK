using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessEntities;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
   public  class DMail
    {
        #region ConnectionString
        public string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SecureProctor"].ConnectionString.ToString();
        public static SqlConnection getConnection()
        {
            return new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SecureProctor"].ConnectionString.ToString());
        }
        #endregion ConnectionString


        public void DSendMail(BEMail objBEMail)
        {

            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[3];
                objSqlParam[0] = new SqlParameter("@StudentID", SqlDbType.Int);
                objSqlParam[0].Value = objBEMail.IntUserID;
                objSqlParam[1] = new SqlParameter("@TransID", SqlDbType.BigInt);
                objSqlParam[1].Value = objBEMail.IntTransID;
                objSqlParam[2] = new SqlParameter("@TemplateName", SqlDbType.VarChar, 100);
                objSqlParam[2].Value = objBEMail.StrTemplateName;
                SQLHelper.ExecuteNonQuery(DConConfig.ConnectionString, CommandType.StoredProcedure, StoredProcedures.USP_SendEmail, objSqlParam);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



    }
}
