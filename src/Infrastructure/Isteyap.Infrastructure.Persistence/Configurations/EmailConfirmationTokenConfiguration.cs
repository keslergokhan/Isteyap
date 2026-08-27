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
    public class EmailConfirmationTokenConfiguration : ConfigurationBase<EmailConfirmationToken>
    {
        public override void Configure(EntityTypeBuilder<EmailConfirmationToken> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.TokenHash).IsRequired();

            builder.Property(x => x.ExpiredDate).IsRequired();

            builder.Property(x => x.UserAt).IsRequired(false);

            builder.HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserID).OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(x => x.TokenHash).IsUnique();
        }
    }
}
