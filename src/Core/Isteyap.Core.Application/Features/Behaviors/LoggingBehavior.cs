using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isteyap.Core.Application.Features.Behaviors
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

        public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            _logger.LogInformation("---------*---------------*-------------*---------> Handling START {RequestName} <---------*----------------*------------*---------", typeof(TRequest).Name);
            var response = await next();
            _logger.LogInformation("---------*-----------*--------------*------------> Handled END {RequestName} <-----------*--------------*-------------*------------", typeof(TRequest).Name);
            return response;
        }
    }
}
