using Core.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Repositories
{
    public interface IRolePermissionsRepository
    {
        public List<Permission> PermissionsBasedOnRoles(string[] roles);
    }
}
