using ApplicationServices.Enum;
using Core.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    public class ConfigureDbTables
    {

        public static void ConfigureAuthTables(ModelBuilder modelBuilder)
        {
            var superAdmin = Guid.NewGuid().ToString();
            var roles = new[]
            {
                new Role()
                {
                    Id = superAdmin,
                    Name = "SuperAdmin",
                    NormalizedName = "SUPERADMIN",
                },
                new Role()
                {
                    Id = "41e61acb-b3dc-4260-b05c-4045df5cfbb4",
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                },
                new Role()
                {
                    Id = "775f6a8f-5eea-47a5-a5f0-c625782d8e2f",
                    Name = "Employee",
                    NormalizedName = "EMPLOYEE",
                }
            };
            var Enumpermissions = Enum.GetValues(typeof(PermissionsEnum));
            var permissions = new List<Permission>();
            var RoleTopermissions = new List<RolePermission>();
            foreach (int i in Enumpermissions)
            {
                if (i == 5) break;
                permissions.Add(new Permission()
                {
                    Id = i,
                    Name = Enum.GetName(typeof(PermissionsEnum), i),
                });

                RoleTopermissions.Add(new RolePermission()
                {

                    RoleId = superAdmin,
                    PermissionId = i
                });
            }

            modelBuilder.Entity<Role>().HasData(roles);

            modelBuilder.Entity<Permission>().HasData(permissions);

            modelBuilder.Entity<RolePermission>()
        .HasKey(bc => new { bc.RoleId, bc.PermissionId });

            modelBuilder.Entity<RolePermission>()
                .HasOne(a => a.Permission)
                .WithMany(b => b.RolePermission)
                .HasForeignKey(bc => bc.PermissionId);

            modelBuilder.Entity<RolePermission>()
                .HasOne(a => a.Role)
                .WithMany(b => b.RolePermission)
                .HasForeignKey(bc => bc.RoleId);
            


            modelBuilder.Entity<RolePermission>().HasData(RoleTopermissions);
        }
    }
}
