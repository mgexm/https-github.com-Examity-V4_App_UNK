///  <copyright file="Utilities.cs" company="Symphony Corporation">
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

namespace ErrorHandlers
{
    public class Utilities
    {
        public static string strError = null;
        public static ExceptionInfo LastError = null;
        public Utilities()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}
