using Isteyap.Core.Application.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isteyap.Core.Application.Features.Test
{
    public class GetTestCommand : IRequest<IResultControl>
    {
        public string Name { get; set; }
    }


    public class GetTestCommandHandler : IRequestHandler<GetTestCommand, IResultControl>
    {
        public async Task<IResultControl> Handle(GetTestCommand request, CancellationToken cancellationToken)
        {
            var result = new ResultControl();

            string sssss = "sdfsfsdfsdf";

            throw new ArgumentNullException("Boş değer var");
            return result;
        }
    }
}
