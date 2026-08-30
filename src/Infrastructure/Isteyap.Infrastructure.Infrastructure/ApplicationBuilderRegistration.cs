using Microsoft.AspNetCore.Builder;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isteyap.Infrastructure.Infrastructure
{
    public static class ApplicationBuilderRegistration
    {
        public static WebApplicationBuilder AddInfrastructureApplicationBuilderRegistration(this WebApplicationBuilder builder)
        {
            builder.Host.UseSerilog((context, services, configuration) => 
                { 
                    configuration.ReadFrom.Configuration(context.Configuration).ReadFrom.Services(services).Enrich.FromLogContext(); 
                });

            return builder;
        }
    }
}
