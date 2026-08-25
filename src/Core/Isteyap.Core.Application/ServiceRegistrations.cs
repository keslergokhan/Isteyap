using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isteyap.Core.Application
{
    public static class ServiceRegistrations
    {
        public static IServiceCollection AddApplicationServiceRegistration(this IServiceCollection services,IConfiguration configuration)
        {
            return services;
        } 
    }
}
