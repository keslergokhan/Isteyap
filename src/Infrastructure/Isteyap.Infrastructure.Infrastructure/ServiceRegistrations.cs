using Isteyap.Core.Application.Configurations.AppSettings;
using Isteyap.Core.Application.Services;
using Isteyap.Core.Application.Services.Interfaces;
using Isteyap.Infrastructure.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isteyap.Infrastructure.Infrastructure
{
    public static class ServiceRegistrations
    {
        public static IServiceCollection AddInfrastructureServiceRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IPasswordHasher, PasswordHasher>();

            services.Configure<EmailOptions>(configuration.GetSection(EmailOptions.SectionName));
            services.AddScoped<IEmailService, EmailService>();
            return services;
        }
    }
}
