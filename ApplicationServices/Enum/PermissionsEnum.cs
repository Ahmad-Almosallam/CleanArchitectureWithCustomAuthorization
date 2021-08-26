using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApplicationServices.Enum
{
    public enum PermissionsEnum
    {
        [Display(Name = "CreateUser")]
        createUser = 1,
        [Display(Name = "editUser")]
        editUser = 2,
        [Display(Name = "deleteUser")]
        deleteUser = 3,
        [Display(Name = "readUser")]
        readUser = 4,
        [Display(Name = "Page1")]
        Page1 = 5,
    }
}
