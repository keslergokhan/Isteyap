using Isteyap.Core.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Isteyap.Core.Application.Results.Base
{
    public abstract class ResultControlBase : IResultControl
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

        public ResultControlBase()
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
            _isSuccess = false;
            return this;
        }

        public IResultControl Fail(string title, string message)
        {
            _isSuccess = false;
            return this;
        }

        public virtual IResultControl Fail(Exception exception)
        {
            _isSuccess = false;
            _exception = exception;
            _errorMessage = exception.Message;
            return this;
        }
    }
}
