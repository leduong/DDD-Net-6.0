using App.Domain.Entities;
using App.Domain.Entities.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.Persistence.DBConfiguration.Authentication
{
    public class RoleClaimConfiguration : BaseConfiguration<RoleClaim>
    {
        public override void CustomConfigure(EntityTypeBuilder<RoleClaim> entity)
        {
            _ = entity.ToTable("RoleClaims");
            _ = entity.Property(e => e.Id).ValueGeneratedOnAdd();
            _ = entity.HasKey(e => e.Id).HasName("pk_role_claim_id");
        }
    }
}
