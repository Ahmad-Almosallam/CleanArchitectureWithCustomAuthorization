using Core.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationServices.Interfaces
{
    public interface IRolePermissionsService
    {
        public List<Permission> PermissionsBasedOnRoles(string[] roles);
    }
}
