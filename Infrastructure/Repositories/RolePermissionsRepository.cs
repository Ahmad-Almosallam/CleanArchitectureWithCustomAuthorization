using Core.Entities.Identity;
using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Repositories
{
    public class RolePermissionsRepository : IRolePermissionsRepository
    {

        private readonly AppDbContext _dbcontext;
        public RolePermissionsRepository(AppDbContext appDbContext)
        {
            _dbcontext = appDbContext;
        }



        public List<Permission> PermissionsBasedOnRoles(string[] roles)
        {
            var res = _dbcontext.RolesToPermission.Where(p => roles == null || roles.Contains(p.Role.Name.Trim())).Select(x => x.Permission).ToList();
            return res;
        }
    }
}
