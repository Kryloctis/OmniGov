namespace ACC.Domain.Models
{
    public class MunicipalitiesModel
    {
        public int Id { get; set; }
        public int ProvincesId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public BarangayModel BarangayModel { get; set; }
    }
}
