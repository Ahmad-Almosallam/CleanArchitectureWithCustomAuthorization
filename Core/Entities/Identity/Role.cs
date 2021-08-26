using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Identity
{
    public class Role : IdentityRole<string>
    {
        public ICollection<RolePermission> RolePermission { get; set; }
    }
}
