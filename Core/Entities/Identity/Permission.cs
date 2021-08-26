using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Identity
{
    public class Permission
    {
        public int Id { get; set; }

        public int ParentId { get; set; }

        public string Name { get; set; }

        public ICollection<RolePermission> RolePermission { get; set; }
    }
}
