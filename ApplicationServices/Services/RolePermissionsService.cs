using ApplicationServices.Interfaces;
using Core;
using Core.Entities.Identity;
using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationServices.Services
{
    public class RolePermissionsService : IRolePermissionsService
    {
        private readonly IRolePermissionsRepository _rolePermissionsRepository;

        public RolePermissionsService(IRolePermissionsRepository _permissionsRepository)
        {
            this._rolePermissionsRepository = _permissionsRepository;
        }

        public List<Permission> PermissionsBasedOnRoles(string []roles)
        {
            return _rolePermissionsRepository.PermissionsBasedOnRoles(roles);
        }
    }
}
