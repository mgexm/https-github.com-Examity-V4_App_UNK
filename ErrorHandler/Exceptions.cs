///  <copyright file="Exceptions.cs" company="Symphony Corporation">
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
using System.Diagnostics;
using System.Reflection;
using System.Threading;

namespace ErrorHandlers
{
    public sealed class Exceptions
    {
        public static ExceptionInfo GetExceptionInfo(Exception e)
        {
            ExceptionInfo objExceptionInfo = new ExceptionInfo();
            while (!(e.InnerException == null))
            {
                e = e.InnerException;
            }
            StackTrace st = new StackTrace(e, true);
            StackFrame sf = st.GetFrame(0);
            try
            {
                //Get the corresponding method for that stack frame.
                MemberInfo mi = sf.GetMethod();
                // Get the namespace where that method is defined.
                string res = mi.DeclaringType.Namespace + ".";
                // Append the type name.
                res += mi.DeclaringType.Name + ".";
                // Append the name of the method.
                res += mi.Name;
                objExceptionInfo.Method = res;
                objExceptionInfo.PageName = mi.DeclaringType.Name;
            }
            catch (Exception)
            {
                objExceptionInfo.Method = "N/A - Reflection Permission required";
            }

            if (sf.GetFileName() != "")
            {
                objExceptionInfo.FileName = sf.GetFileName();
                objExceptionInfo.FileColumnNumber = sf.GetFileColumnNumber();
                objExceptionInfo.FileLineNumber = sf.GetFileLineNumber();
                objExceptionInfo.Error = e.Message;
            }

            return objExceptionInfo;
        }

        private static bool ThreadAbortCheck(Exception exc)
        {
            if (exc is ThreadAbortException)
            {
                Thread.ResetAbort();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
