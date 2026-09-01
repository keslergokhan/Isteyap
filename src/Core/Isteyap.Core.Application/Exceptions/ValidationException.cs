using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isteyap.Core.Application.Exceptions
{
    public class ValidationException : AppExceptionBase
    {
        public ValidationException(IEnumerable<FluentValidation.Results.ValidationFailure> failures)
            : base("VALIDATION","Validation failed")
        {
            Failures = failures;

            failures?.ToList().ForEach(failure =>
            {
                ErrorDetails.Add($"{failure.PropertyName}: {failure.ErrorMessage}");
            });
        }

        public IEnumerable<FluentValidation.Results.ValidationFailure> Failures { get; }

       
    }
}
