using ApplicationServices.Enum;
using ApplicationServices.Interfaces;
using Core.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CleanArchitectureWithCustomAuthorization.Helpers
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class WebAuthorize : Attribute, IAuthorizationFilter
    {

        readonly PermissionsEnum[] _permissions;

        public WebAuthorize(params PermissionsEnum[] permissions)
        {
            _permissions = permissions;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var result = new ViewResult()
            {
                ViewName = "AccessDenied",
                ViewData = new ViewDataDictionary(new Microsoft.AspNetCore.Mvc.ModelBinding.EmptyModelMetadataProvider(), new Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary())
                { { "AuthorizeMessage", "AccessDenied" } }
            };

            var user = context.HttpContext.User;

            if (!user.Identity.IsAuthenticated)
            {
                context.Result = result;
                return;
            }

            var role = user.Claims.Where(x => x.Type == ClaimTypes.Role).FirstOrDefault();
            if (role == null)
            {
                context.Result = result;
                return;
            }

            var per = (IPermissionsService)context.HttpContext.RequestServices.GetService(typeof(IPermissionsService));

            var rolePermissions = per.PermissionsBasedOnRole(role.Value);

            if (rolePermissions == null || rolePermissions?.Any() == false)
            {
                context.Result = result;
                return;
            }

            if (!_permissions.Any(p => rolePermissions.Select(rp => rp.Id).Contains((int)p)))
            {
                context.Result = result;
                return;
            }

        }
    }
}
