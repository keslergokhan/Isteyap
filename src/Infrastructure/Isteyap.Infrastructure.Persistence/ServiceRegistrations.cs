using Isteyap.Core.Application.IsteyapDbContext;
using Isteyap.Infrastructure.Persistence.IsteyapDbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isteyap.Infrastructure.Persistence
{
    public static class ServiceRegistrations
    {
        public static IServiceCollection AddInfrastructurePersistenceServiceRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IAppDbContext, IsteyapDbContext>(x =>
            {
                x.UseSqlServer(configuration.GetConnectionString("IsteyapConnection"));
            });

            return services;
        }
    }
}
