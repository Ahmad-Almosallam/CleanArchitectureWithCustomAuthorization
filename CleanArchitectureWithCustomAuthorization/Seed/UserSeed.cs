using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitectureWithCustomAuthorization.Seed
{
    public class UserSeed
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<Role>>();

            SeedUsers(userManager, roleManager);
        }


        private static void SeedUsers(UserManager<AppUser> userManager, RoleManager<Role> roleManager)
        {
            if (userManager.FindByNameAsync("Huda").Result == null)
            {
                AppUser user = new AppUser()
                {
                    UserName = "Huda",
                    LockoutEnabled = false,
                    IsActive = true
                };
                
                var result = userManager.CreateAsync(user, "Huda").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }
            if (userManager.FindByNameAsync("Ahmad").Result == null)
            {
                AppUser user = new AppUser()
                {
                    UserName = "Ahmad",
                    LockoutEnabled = false,
                    IsActive = true
                };

                var result = userManager.CreateAsync(user, "Ahmad").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "SuperAdmin").Wait();
                }
            }

            if (userManager.FindByNameAsync("Mohammed").Result == null)
            {
                AppUser user = new AppUser()
                {
                    UserName = "Mohammed",
                    LockoutEnabled = false,
                    IsActive = true
                };

                var result = userManager.CreateAsync(user, "Mohammed").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "InventoryManager").Wait();
                }
            }
        }

    }
}
