using Isteyap.Core.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isteyap.Infrastructure.Persistence.Configurations.Base
{
    public abstract class ConfigurationBase<T> : IEntityTypeConfiguration<T> where T : BasicEntityBase
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x=>x.ID);
            builder.ToTable(typeof(T).Name);

            builder.Property(x => x.ID).HasColumnOrder(0);

            builder.Property(x => x.ID)
            .UseIdentityColumn(1, 1)
            .ValueGeneratedOnAdd();

            builder
                .Property(x => x.ModifiedDate)
                .IsRequired(false)
                .HasColumnOrder(999);

            builder
                .Property(x => x.CreateDate)
                .IsRequired(true)
                .HasColumnOrder(998);

            builder.Property(x => x.State)
                .IsRequired(true)
                .HasColumnOrder(9999);
        }
    }
}
