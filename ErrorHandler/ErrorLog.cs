///  <copyright file="ErrorLog.cs" company="Symphony Corporation">
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
using System.Configuration;
using System.Web;
using System.Security;
namespace ErrorHandlers
{
    public class ErrorLog
    {
        #region Public Methods
        public ErrorLog()
        {

        }
        /// Handles error by accepting the error message 
        /// Displays the page on which the error occured
        public static void WriteError(Exception e)
        {
            try
            {
                // LogDBErrorInfo(e);
                LogDBErrorInfo(e);// this is used to insert the error details in DB
                ExceptionInfo exinfo = Exceptions.GetExceptionInfo(e);           
                string sPath = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
                System.IO.FileInfo oInfo = new System.IO.FileInfo(sPath);
                Utilities.strError = oInfo.Name;
                Utilities.LastError = exinfo;
                HttpContext.Current.Response.Redirect("~/Errors/ErrorPage.aspx", false);
            }
            catch (Exception ex)
            {
                ErrorLog.WriteError(ex);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strError"></param>
        /// <param name="strPageName"></param>
        /// <param name="strMethodName"></param>
        /// <param name="intFileLineNumber"></param>
        /// <param name="intFileColumnNumber"></param>
        /// <param name="strSource"></param>
        /// <param name="date"></param>
        public static void LogDBErrorInfo(string strError, string strPageName, string strMethodName, int intFileLineNumber, int intFileColumnNumber, string strSource, DateTime date)
        {
            string obj = string.Empty;

            try
            {
                DBErrorPage DALerr = new DBErrorPage();

                string sPath = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
                System.IO.FileInfo oInfo = new System.IO.FileInfo(sPath);
                strPageName = oInfo.Name;
                obj = Convert.ToString(DALerr.DBInsertErrorInfo(strError, strPageName, strMethodName, intFileLineNumber, intFileColumnNumber, strSource, date));
            }
            catch (Exception ex)
            {
                ErrorLog.WriteError(ex);
            }
            finally
            {

            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="exinfo"></param>
        public static void LogDBErrorInfo(ExceptionInfo exinfo)
        {
            string obj = string.Empty;

            try
            {
                DBErrorPage DALerr = new DBErrorPage();
                obj = Convert.ToString(DALerr.DBInsertErrorInfo(exinfo.Error, exinfo.PageName, exinfo.Method, exinfo.FileLineNumber, exinfo.FileColumnNumber, exinfo.FileName, DateTime.Now));
            }
            catch (Exception ex)
            {
                ErrorLog.WriteError(ex);
            }
            finally
            {

            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="exc"></param>
        public static void LogDBErrorInfo(Exception exc)
        {
            string obj = string.Empty;
            try
            {
                ExceptionInfo exinfo = Exceptions.GetExceptionInfo(exc);
                DBErrorPage DALerr = new DBErrorPage();
                string strMethod = exinfo.Method.Replace(exinfo.PageName, "");
                strMethod = strMethod.Replace("..", "").Trim();
                //string strPageName = System.Web.HttpContext.Current.Request.Url.AbsolutePath.ToString();
                string sPath = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
                System.IO.FileInfo oInfo = new System.IO.FileInfo(sPath);
                string strPageName = oInfo.Name;

                obj = Convert.ToString(DALerr.DBInsertErrorInfo(exinfo.Error, strPageName, strMethod, exinfo.FileLineNumber, exinfo.FileColumnNumber, exinfo.FileName, DateTime.Now));
                // obj = Convert.ToString(DALerr.DBInsertErrorInfo(exinfo.Error, exinfo.PageName, strMethod, exinfo.FileLineNumber, exinfo.FileColumnNumber, exinfo.FileName, DateTime.Now));
            }
            catch (Exception ex)
            {
                ErrorLog.WriteError(ex);
            }
            finally
            {

            }

        }
        #endregion Public Methods
    }
}
