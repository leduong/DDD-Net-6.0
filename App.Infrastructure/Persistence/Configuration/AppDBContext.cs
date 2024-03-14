using App.Domain.Entities;
using App.Domain.Entities.Authentication;
 using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace App.Infrastructure.Persistence
{
    public partial class AppDbContext : IdentityDbContext<User, Role, int, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        partial void OnModelCreatingConfiguration(ModelBuilder builder)
        {
            // Tasks
            builder.Entity<Domain.Entities.Task>().ToTable("Tasks");

            // User
            builder.Entity<User>().ToTable("Users");
            builder.Entity<User>().Property(e => e.Id).ValueGeneratedOnAdd();

            // Role
            builder.Entity<Role>().ToTable("Roles");
            builder.Entity<Role>().Property(e => e.Id).ValueGeneratedOnAdd();

            // UserRole
            builder.Entity<UserRole>().ToTable("UserRoles")
                    .HasKey(e => e.Id)
                    .HasName("pk_user_role_id");
            builder.Entity<UserRole>()
                    .HasOne(ur => ur.User)
                    .WithMany(u => u.Roles)
                    .HasForeignKey(ur => ur.UserId);
            builder.Entity<UserRole>()
                    .HasOne(ur => ur.Role)
                    .WithMany(u => u.UserRoles)
                    .HasForeignKey(ur => ur.RoleId);

            // RoleClaims
            builder.Entity<RoleClaim>().ToTable("RoleClaims")
                    .HasKey(e => e.Id).HasName("pk_role_claim_id");
            builder.Entity<RoleClaim>()
                    .HasOne(rc => rc.Role)
                    .WithMany(r => r.Claims)
                    .HasForeignKey(rc => rc.RoleId);

            // UserClaim
            builder.Entity<UserClaim>().ToTable("UserClaims")
                    .HasKey(e => e.Id)
                    .HasName("pk_user_claim_id");
            builder.Entity<UserClaim>()
                    .HasOne(uc => uc.User)
                    .WithMany(u => u.Claims)
                    .HasForeignKey(uc => uc.UserId);

            // UserLogin
            builder.Entity<UserLogin>().ToTable("UserLogins")
                    .HasKey(e => e.Id)
                    .HasName("pk_user_login_id");
            builder.Entity<UserLogin>()
                    .HasOne(ul => ul.User)
                    .WithMany(u => u.Logins)
                    .HasForeignKey(uc => uc.UserId);

            // UserTokens
            builder.Entity<UserToken>().ToTable("UserTokens")
                    .HasKey(e => e.Id)
                    .HasName("pk_user_token_id");
            builder.Entity<UserToken>()
                    .HasOne(ut => ut.User)
                    .WithMany(u => u.Tokends)
                    .HasForeignKey(ut => ut.UserId);

        }
    }
}
