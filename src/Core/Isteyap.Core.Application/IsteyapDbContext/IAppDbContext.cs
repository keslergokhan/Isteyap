using Isteyap.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isteyap.Core.Application.IsteyapDbContext
{
    public interface IAppDbContext : IDisposable, IAsyncDisposable
    {
        public DbSet<User> User {get;}
        public DbSet<UserExternalLogin> UserExternalLogin {get;}
        public DbSet<UserRole> UserRole { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        public Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default);


    }
}
