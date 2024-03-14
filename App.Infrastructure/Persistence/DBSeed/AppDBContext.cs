using App.Domain.Entities.Authentication;
using App.Infrastructure.Persistence.DBSeed;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.Persistence
{
    public partial class AppDbContext : IdentityDbContext<User, Role, int, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {

        partial void OnModelCreatingDataSeed(ModelBuilder builder)
        {
            new TaskSeed().Seed(builder);
        }
    }
}
