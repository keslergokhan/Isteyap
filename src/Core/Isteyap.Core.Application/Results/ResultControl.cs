using Isteyap.Core.Application.Results.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isteyap.Core.Application.Results
{
    public class ResultControl : ResultControlBase, IResultControl
    {

        public static IResultControl CreateSuccess()
        {
            return new ResultControl().Success();
        }

        public static IResultControl FailError(Exception exception = null)
        {
            if (exception!=null)
            {
                return new ResultControl().Fail(exception);
            }
            else
            {
                return new ResultControl().Fail();
            }
        }

        public static IResultControl FailError(string title, string message)
        {
            return new ResultControl().Fail(title, message);
        }

    }
}
