using ApplicationServices.Enum;
using ApplicationServices.Interfaces;
using CleanArchitectureWithCustomAuthorization.Helpers;
using CleanArchitectureWithCustomAuthorization.Models;
using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CleanArchitectureWithCustomAuthorization.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<AppUser> _userManger;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IRolePermissionsService _rolePermissionsService;

        public HomeController(ILogger<HomeController> logger, UserManager<AppUser> userManger, SignInManager<AppUser> signInManager, IRolePermissionsService permissions)
        {
            _logger = logger;
            _userManger = userManger;
            _signInManager = signInManager;
            _rolePermissionsService = permissions;
        }
        public async Task<IActionResult> Index()
        {
            AppUser identityUser = new AppUser()
            {
                UserName = "ahmad"
            };
            
            if (_signInManager.IsSignedIn(User))
                await _signInManager.SignOutAsync();

            var user = await _userManger.FindByNameAsync("Ahmad");
            var claims = new List<Claim>();
            var roles = await _userManger.GetRolesAsync(user);
            foreach (var role in roles)
                claims.Add(new Claim(ClaimTypes.Role, role));

            var roleStirng = roles.ToArray();
            var permissions = _rolePermissionsService.PermissionsBasedOnRoles(roleStirng);
            foreach (var permission in permissions)
                claims.Add(new Claim("permissions", permission.Id.ToString()));


            await _signInManager.SignInWithClaimsAsync(identityUser, new Microsoft.AspNetCore.Authentication.AuthenticationProperties(), claims);
            


            return View();
        }

        [WebAuthorize(PermissionsEnum.editUser)]
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
