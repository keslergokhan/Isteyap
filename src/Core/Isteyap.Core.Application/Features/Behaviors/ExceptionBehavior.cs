using Isteyap.Core.Application.Results;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isteyap.Core.Application.Features.Behaviors
{
    public class ExceptionBehavior<TRequest, TResponse> : 
        IPipelineBehavior<TRequest, TResponse> 
        where TResponse : IResultControl
    {
        private readonly ILogger<ExceptionBehavior<TRequest, TResponse>> _logger;

        public ExceptionBehavior(ILogger<ExceptionBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            Type type = typeof(TRequest);
            try
            {
                return await next();
            }
            catch (Exception ex)
            {

                _logger.LogError(ex,"Bir hata oluştu {RequestName}",type.Name);

                return (TResponse)ResultControl.FailError(ex);
            }
        }
    }
}
