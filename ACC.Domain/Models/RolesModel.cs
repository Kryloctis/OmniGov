using System.Collections.Generic;

namespace ACC.Domain.Models
{
    public class RolesModel
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public List<PermissionsModel> PermissionsModels { get; set; }
    }
}