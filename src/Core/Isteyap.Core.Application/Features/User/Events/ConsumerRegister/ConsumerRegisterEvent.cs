using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isteyap.Core.Application.Features
{
    public class ConsumerRegisterEvent : INotification
    {
        public string Email { get; set; }
        public string FullName { get; set; }
        public string VerificationLink { get; set; }
    }
}
