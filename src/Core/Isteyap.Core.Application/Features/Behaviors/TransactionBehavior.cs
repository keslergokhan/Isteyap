using Isteyap.Core.Application.IsteyapDbContext;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isteyap.Core.Application.Features.Behaviors
{
    public class TransactionBehavior<TRequest, TResponse> : 
        IPipelineBehavior<TRequest, TResponse> where TRequest : notnull, ITransactionBehavior
    {
        private readonly IAppDbContext _appDbContext;

        public TransactionBehavior(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var transaction = await _appDbContext.BeginTransactionAsync(cancellationToken);
            try
            {
                var response = await next();
                await _appDbContext.SaveChangesAsync(cancellationToken);
                await transaction.CommitAsync(cancellationToken);
                return response;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync(cancellationToken);
                throw ex;
            }
            
        }
    }
}
