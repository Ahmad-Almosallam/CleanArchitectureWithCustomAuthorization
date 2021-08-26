using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitectureWithCustomAuthorization.Seed
{
    public class RoleSeed
    {

        public static void Initialize(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<Role>>();
            
            SeedRoles(roleManager);
        }


        private static void SeedRoles(RoleManager<Role> roleManager)
        {
            if (!roleManager.RoleExistsAsync("SuperAdmin").Result)
            {
                var result = roleManager.CreateAsync(new Role { Name = "SuperAdmin", Id = Guid.NewGuid().ToString() }).Result;
            }

            if (!roleManager.RoleExistsAsync("Admin").Result)
            {
                var result = roleManager.CreateAsync(new Role { Name = "Admin", Id= Guid.NewGuid().ToString() }).Result;
            }

            if (!roleManager.RoleExistsAsync("InventoryManager").Result)
            {
                var result = roleManager.CreateAsync(new Role { Name = "InventoryManager" , Id = Guid.NewGuid().ToString() }).Result;
            }

        }
    }
}
