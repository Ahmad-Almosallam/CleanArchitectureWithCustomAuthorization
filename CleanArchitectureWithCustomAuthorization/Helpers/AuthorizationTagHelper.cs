using ApplicationServices.Enum;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitectureWithCustomAuthorization.Helpers
{
    [HtmlTargetElement(Attributes = nameof(Permissions))]
    [HtmlTargetElement(Attributes = nameof(Permission))]
    public class AuthorizationTagHelper : TagHelper
    {
        private readonly UserHelper _webUserHelper;

        public AuthorizationTagHelper(UserHelper webUserHelper)
        {
            _webUserHelper = webUserHelper;
        }

        /// <summary>
        /// Gets or sets a list of permission that are allowed to access the HTML block.
        /// </summary>
        public List<PermissionsEnum> Permissions { get; set; }

        /// <summary>
        /// Gets or sets a permission that are allowed to access the HTML block.
        /// </summary>
        public PermissionsEnum Permission { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            bool authorizePermissionsResult = false;
            bool authorizePermissionResult = false;

            if (Permissions?.Count > 0)
            {
                int[] userPermissions = _webUserHelper.GetPermissions();
                if (userPermissions?.Length > 0)
                    authorizePermissionsResult = Permissions.Any(p => userPermissions.Contains((int)p));
            }
            if (Enum.IsDefined(typeof(PermissionsEnum), Permission))
            {
                int[] userPermissions = _webUserHelper.GetPermissions();
                if (userPermissions?.Length > 0)
                    authorizePermissionResult = userPermissions.Contains((int)Permission);
            }

            if (!authorizePermissionsResult && !authorizePermissionResult)
            {
                output.TagName = "a";
                var s = output.Attributes.Where(x => x.Name == "class").Select(x => x.Value.ToString()).FirstOrDefault();
                s += " disabled";
                output.Attributes.SetAttribute("class", s);
            }
        }
    }
}
