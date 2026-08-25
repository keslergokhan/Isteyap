using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isteyap.Infrastructure.Persistence.IsteyapDbContexts
{
    public class IsteyapDbContext : DbContext
    {
        public IsteyapDbContext(DbContextOptions<IsteyapDbContext> dbContext) : base(dbContext)
        {
            
        }


    }
}
