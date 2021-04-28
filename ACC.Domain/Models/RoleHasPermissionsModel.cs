using System;
using System.Collections.Generic;
using System.Text;

namespace ACC.Domain.Models
{
    public class RoleHasPermissionsModel
    {
        public byte RolesId { get; set; }
        public byte PermissionsId { get; set; }
    }
}
