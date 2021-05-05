using System;
using System.Collections.Generic;
using System.Text;

namespace ACC.Domain.Models
{
    public class PermissionsModel
    {
        public int Id { get; set; }
        public string PermissionName { get; set; }
        public int currentRole { get; set; }
    }
}
