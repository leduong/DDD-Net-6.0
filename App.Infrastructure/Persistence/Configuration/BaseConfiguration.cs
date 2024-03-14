using App.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.Persistence.Configuration
{
    public abstract class BaseConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public void Configure(EntityTypeBuilder<T> entity)
        {
            // Common configuration for tables
            entity.Property(e => e.Id).UseIdentityColumn(seed: 100);
            
            this.CustomConfigure(entity);
        }

        public abstract void CustomConfigure(EntityTypeBuilder<T> entity);
    }
}
