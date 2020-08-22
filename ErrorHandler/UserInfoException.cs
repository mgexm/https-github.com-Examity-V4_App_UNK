///  <copyright file="UserInfoException.cs" company="Symphony Corporation">
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

/*****************************************************************************************************************
 * Copyright © Symphony Corporation. All rights reserved.
 * THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
 * OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
 * LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
 * FITNESS FOR A PARTICULAR PURPOSE.
 *****************************************************************************************************************
 * Author			:	Hari Naidu
 * Purpose			:	
 * Created Date		:	16-Oct-2009
*****************************************************************************************************************/


namespace ErrorHandlers
{
    public class UserInfoException : ApplicationException
    {
        public UserInfoException()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        // Exception Message
        private string customMessage = "";

        // Exception
        private Exception innerException;

        // Public accessor forthe custom message
        public string CustomMessage
        {
            get { return this.customMessage; }
            set { this.customMessage = value; }
        }

        // Constructor with parameters
        public UserInfoException(string customMessage, Exception innerException)
            : base(customMessage, innerException)
        {
            this.customMessage = customMessage;
            this.innerException = innerException;
        }

        // Constructor with parameters
        public UserInfoException(string customMessage)
            : base(customMessage)
        {
            this.customMessage = customMessage;
        }
    }
}
