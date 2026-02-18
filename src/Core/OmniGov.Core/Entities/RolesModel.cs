namespace OmniGov.Core.Entities
{
    public class RolesModel
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public List<PermissionsModel> PermissionsModels { get; set; }
    }
}
