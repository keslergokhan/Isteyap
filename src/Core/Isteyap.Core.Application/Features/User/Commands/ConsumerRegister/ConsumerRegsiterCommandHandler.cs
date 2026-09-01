using Isteyap.Core.Application.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isteyap.Core.Application.Features
{
    public class ConsumerRegsiterCommandHandler : IRequestHandler<ConsumerRegisterCommand, IResultControl>
    {
        public async Task<IResultControl> Handle(ConsumerRegisterCommand request, CancellationToken cancellationToken)
        {
            IResultControl result = new ResultControl();



            return ResultControl.CreateSuccess();
        }
    }
}
