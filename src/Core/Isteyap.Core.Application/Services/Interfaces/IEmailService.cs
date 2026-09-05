using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Isteyap.Core.Application.Services.Interfaces
{
    public interface IEmailService
    {
        Task SendAsync(EmailMessage message,CancellationToken cancellationToken = default);
    }
}
