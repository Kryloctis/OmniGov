using System;
using System.Collections.Generic;
using System.Text;

namespace ACC.Domain.Models
{
   public class RolesModel
    {
        public int Id { get; set; }
        public string Office { get; set; }
        public string RoleName { get; set; }
        public List<PermissionsModel> PermissionsModels { get; set; }
    }
}
