///  <copyright file="ExceptionInfo.cs" company="Symphony Corporation">
///     Copyright (c) © Symphony Corporation. All rights reserved.
///     This code and information is provided "as is" without warranty Of any kind, 
///     either expressed or implied, including but not Limited to the implied warranties of   
///     merchantability and Fitness for a particular purpose.
/// </copyright>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ErrorHandlers
{
    public class ExceptionInfo
    {
        private int _FileColumnNumber;
        private int _FileLineNumber;
        private string _FileName;
        private string _Method;
        private string _Error;
        private string _PageName;
        public int FileColumnNumber
        {
            get
            {
                return this._FileColumnNumber;
            }
            set
            {
                this._FileColumnNumber = value;
            }
        }

        public int FileLineNumber
        {
            get
            {
                return this._FileLineNumber;
            }
            set
            {
                this._FileLineNumber = value;
            }
        }

        public string FileName
        {
            get
            {
                return this._FileName;
            }
            set
            {
                this._FileName = value;
            }
        }

        public string Method
        {
            get
            {
                return this._Method;
            }
            set
            {
                this._Method = value;
            }
        }

        public string Error
        {
            get
            {
                return this._Error;
            }
            set
            {
                this._Error = value;
            }
        }

        public string PageName
        {
            get
            {
                return this._PageName;
            }
            set
            {
                this._PageName = value;
            }
        }
    }
}
