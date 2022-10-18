namespace ACC.Domain.Models
{
    public class ProvincesModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public MunicipalitiesModel MunicipalitiesModel { get; set; }
    }
}
