namespace OmniGov.Core.Entities
{
    public class MunicipalitiesModel
    {
        public int Id { get; set; }
        public int ProvincesId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
}