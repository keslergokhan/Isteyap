using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isteyap.Core.Application.Exceptions
{
    public class AppExceptionBase : Exception
    {
        public virtual string ErrorCode { get; }
        protected AppExceptionBase()
        {

        }
        protected AppExceptionBase(string errorCode)
        {
            this.ErrorCode = errorCode;
        }
        public AppExceptionBase(string errorCode, string message) : base(message)
        {
            this.ErrorCode = errorCode;
        }

        public AppExceptionBase(string errorCode, string message, Exception innerException) : base(message, innerException)
        {
            this.ErrorCode = errorCode;
        }
    }
}
