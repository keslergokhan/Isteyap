using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isteyap.Core.Application.Configurations.AppSettings
{
    public sealed class EmailOptions
    {
        public const string SectionName = "Email";

        public required string Host { get; init; }

        public int Port { get; init; }

        public required string Username { get; init; }

        public required string Password { get; init; }

        public required string FromAddress { get; init; }

        public required string FromName { get; init; }

        public bool UseSsl { get; init; }
    }
}
