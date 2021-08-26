using Core.Entities.Identity;
using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Repositories
{
    public class PermissionsRepository : IPermissionsRepository
    {

        private readonly AppDbContext _dbcontext;
        public PermissionsRepository(AppDbContext appDbContext)
        {
            _dbcontext = appDbContext;
        }

        public List<Permission> PermissionsBasedOnRole(string RoleName)
        {
            var res = _dbcontext.Permissions.Where(p => p.RolePermission.Any(rp => rp.Role.NormalizedName == RoleName)).ToList();
            return res;
        }

        public List<Permission> PermissionsBasedOnRoles(string[] roles)
        {
            var res = _dbcontext.RolesToPermission.Where(p => roles == null || roles.Contains(p.Role.Name.Trim())).Select(x => x.Permission).ToList();
            return res;
        }
    }
}
