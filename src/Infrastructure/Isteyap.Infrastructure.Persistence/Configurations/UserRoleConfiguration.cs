using Isteyap.Core.Domain.Entities;
using Isteyap.Infrastructure.Persistence.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isteyap.Infrastructure.Persistence.Configurations
{
    public class UserRoleConfiguration : ConfigurationBase<UserRole>
    {
        public override void Configure(EntityTypeBuilder<UserRole> builder)
        {
            base.Configure(builder);


            builder.Property(x => x.Role).IsRequired();

            builder.Property(x => x.UserID).IsRequired();

            // Aynı kullanıcıya aynı rol birden fazla kez verilemez.
            builder.HasIndex(x => new
            {
                x.UserID,
                x.Role
            })
            .IsUnique();

            builder.HasOne(x => x.User).WithMany(x => x.Roles).HasForeignKey(x => x.UserID).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
