using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Entities.Identity
{
    public class RolePermission
    {
        public string RoleId { get; set; }
        [ForeignKey("RoleId")]
        public Role Role { get; set; }

        public int PermissionId { get; set; }
        [ForeignKey("PermissionId")]
        public Permission Permission { get; set; }
    }
}
