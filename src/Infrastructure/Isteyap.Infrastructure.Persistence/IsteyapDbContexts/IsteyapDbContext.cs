using Isteyap.Core.Application.IsteyapDbContext;
using Isteyap.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Isteyap.Infrastructure.Persistence.IsteyapDbContexts
{
    public class IsteyapDbContext : DbContext, IAppDbContext
    {
        public IsteyapDbContext(DbContextOptions<IsteyapDbContext> dbContext) : base(dbContext)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
            var foreignKeys = modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys());

        }

        public DbSet<User> User => Set<User>();
        public DbSet<UserExternalLogin> UserExternalLogin => Set<UserExternalLogin>();
        public DbSet<UserRole> UserRole => Set<UserRole>();
    }
}
