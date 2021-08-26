using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CleanArchitectureWithCustomAuthorization.Helpers
{
    public class UserHelper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string[] GetRoles()
        {
            return _httpContextAccessor.HttpContext.User.Claims.Where(x => x.Type == ClaimTypes.Role).Select(r => r.Value).ToArray();
        }

        public int[] GetPermissions()
        {
            return _httpContextAccessor.HttpContext.User.Claims.Where(x => x.Type == "permissions").Select(r => int.Parse(r.Value)).ToArray();
        }
    }
}
