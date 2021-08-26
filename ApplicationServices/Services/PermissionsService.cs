using ApplicationServices.Interfaces;
using Core;
using Core.Entities.Identity;
using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationServices.Services
{
    public class PermissionsService : IPermissionsService
    {
        private readonly IPermissionsRepository _permissionsRepository;

        public PermissionsService(IPermissionsRepository _permissionsRepository)
        {
            this._permissionsRepository = _permissionsRepository;
        }

        public List<Permission> PermissionsBasedOnRole(string RoleName)
        {
            return _permissionsRepository.PermissionsBasedOnRole(RoleName);
        }

        
    }
}
