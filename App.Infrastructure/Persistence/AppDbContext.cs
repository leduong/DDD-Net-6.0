using App.Domain.Entities;
using App.Domain.Entities.Authentication;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Task = App.Domain.Entities.Task;

namespace App.Infrastructure.Persistence
{
    public partial class AppDbContext : IdentityDbContext<User, Role, int, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        public DbSet<Task> Task { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) // Sửa đổi kiểu dữ liệu ở đây
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //builder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
            this.OnModelCreatingDataSeed(builder);
            this.OnModelCreatingConfiguration(builder);
        }

        partial void OnModelCreatingDataSeed(ModelBuilder builder);
        partial void OnModelCreatingConfiguration(ModelBuilder builder);
    }
}
