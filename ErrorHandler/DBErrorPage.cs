///  <copyright file="DBErrorPage.cs" company="Symphony Corporation">
///     Copyright (c) © Symphony Corporation. All rights reserved.
///     This code and information is provided "as is" without warranty Of any kind, 
///     either expressed or implied, including but not Limited to the implied warranties of   
///     merchantability and Fitness for a particular purpose.
/// </copyright>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using ErrorHandlers;

namespace ErrorHandlers
{
    public class DBErrorPage 
    {

        #region SP Names
        private readonly string PROC_INSERT_ErrorInfo = "USP_Error_InsertErrorInfo";
        #endregion SP Names
        #region Public Methods
        #region Connection String
        string conString = System.Configuration.ConfigurationManager.ConnectionStrings["SecureProctor"].ConnectionString;
        #endregion Connection String

        public string DBInsertErrorInfo(string strError, string strPageName, string strMethodName, int intFileLineNumber, int intFileColumnNumber, string strSource, DateTime date)
        {
            string obj = string.Empty;
            try
            {

                SqlParameter[] arParam = new SqlParameter[7];

                arParam[0] = new SqlParameter("@V_EorInfo", SqlDbType.NVarChar, 4000);
                arParam[0].Value = strError;
                arParam[1] = new SqlParameter("@V_EorPageName", SqlDbType.NVarChar, 250);
                arParam[1].Value = strPageName;
                arParam[2] = new SqlParameter("@V_EorMethodName", SqlDbType.NVarChar, 250);
                arParam[2].Value = strMethodName;
                arParam[3] = new SqlParameter("@I_EorLineNumber", SqlDbType.Int);
                arParam[3].Value = intFileLineNumber;
                arParam[4] = new SqlParameter("@I_EorColumnNumber", SqlDbType.Int);
                arParam[4].Value = intFileColumnNumber;
                arParam[5] = new SqlParameter("@V_EorSource", SqlDbType.NVarChar, 250);

                if (String.IsNullOrEmpty(strSource))
                {
                    strSource = "";
                    arParam[5].Value = strSource;
                }
                else
                {
                    arParam[5].Value = strSource;
                }

                arParam[6] = new SqlParameter("@v_CreatedBy", SqlDbType.VarChar);
                arParam[6].Value = System.Web.HttpContext.Current.User.Identity.Name;

                obj = Convert.ToString(SqlHelper.ExecuteNonQuery(conString, CommandType.StoredProcedure, PROC_INSERT_ErrorInfo, arParam));

            }
            catch (Exception)
            {
                //ErrorLog.WriteError(ex);
            }

            return obj;

        }

        #endregion Public Methods
    }
}
