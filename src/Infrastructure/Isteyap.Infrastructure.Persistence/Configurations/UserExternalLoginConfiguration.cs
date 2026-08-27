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
    public class UserExternalLoginConfiguration : ConfigurationBase<UserExternalLogin>
    {
        public override void Configure(EntityTypeBuilder<UserExternalLogin> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Provider).IsRequired();

            builder.Property(x => x.ProviderUserId).IsRequired().HasMaxLength(200);

            builder.Property(x => x.UserID).IsRequired();

            builder.HasIndex(x => new
            {
                x.Provider,
                x.ProviderUserId
            })
            .IsUnique();

            builder.HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserID).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
