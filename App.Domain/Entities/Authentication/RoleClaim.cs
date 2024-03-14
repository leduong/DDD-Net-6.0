using App.Domain.Entities.Common;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Entities.Authentication
{
    public class RoleClaim : IdentityRoleClaim<int>//, IEntity<int>
    {
        public virtual Role Role { get; set; }
    }
}
