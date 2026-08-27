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
    public class UserConfiguration : ConfigurationBase<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.FirstName).HasMaxLength(200).IsRequired();
            builder.Property(x => x.LastName).HasMaxLength(200).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(400).IsRequired();
            builder.HasIndex(x => x.Email).IsUnique();
            builder.HasIndex(x => x.NormalizedEmail).IsUnique();
            builder.Property(x => x.NormalizedEmail).HasMaxLength(400).IsRequired();
            builder.Property(x => x.IsEmailConfirmed).IsRequired().HasDefaultValue(false);
            builder.Property(x => x.PhoneNumber).HasMaxLength(100).IsRequired(false).HasMaxLength(20);
            builder.Property(x => x.PasswordHash).HasMaxLength(500).IsRequired().HasMaxLength(500);
            builder.Property(x => x.LastLoginAt).IsRequired(false);
            builder.Ignore(x => x.FullName);
        }
    }
}
