using Isteyap.Core.Application.Exceptions;
using Isteyap.Core.Application.Results.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Isteyap.Core.Application.Results.Base
{
    public abstract class BaseResultControl : IResultControl
    {
        protected bool _isSuccess;
        public bool IsSuccess => _isSuccess;
        private Exception _exception;
        [JsonIgnore]
        public Exception Exception => _exception;
        public string _errorMessage;
        public string ErrorMessage => _errorMessage;
        public string ErrorCode
        {
            get
            {
                if (this._isSuccess)
                {
                    return "";
                }

                if (this.Exception is AppExceptionBase)
                {
                    return (this.Exception as AppExceptionBase).ErrorCode;
                }
                else
                {
                    return "UNKNOWN_ERROR";
                }
            }
        }

        public BaseResultControl()
        {
            _isSuccess = true;
        }
        public IResultControl Success()
        {
            _isSuccess = true;
            return this;
        }

        public IResultControl Fail()
        {
            this._isSuccess = false;
            return this;
        }

        public IResultControl Fail(string title, string message)
        {
            this._isSuccess = false;
            return this;
        }

        public virtual IResultControl Fail(Exception exception)
        {
            this._isSuccess = false;
            this._exception = exception;
            this._errorMessage = exception.Message;
            return this;
        }
    }
}
