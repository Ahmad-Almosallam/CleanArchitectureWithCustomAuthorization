using Core.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Repositories
{
    public interface IPermissionsRepository
    {
        public List<Permission> PermissionsBasedOnRole(string RoleName);

        
    }
}
