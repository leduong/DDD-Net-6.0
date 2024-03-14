using App.Domain.Entities.Common;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Entities.Authentication
{
    public class UserClaim : IdentityUserClaim<int>, IEntity<int>
    {
        public virtual User User { get; set; }
    }
}
