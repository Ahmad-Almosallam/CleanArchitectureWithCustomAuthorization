using Core.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationServices.Interfaces
{
    public interface IPermissionsService
    {
        public List<Permission> PermissionsBasedOnRole(string RoleName);

        
    }
}
