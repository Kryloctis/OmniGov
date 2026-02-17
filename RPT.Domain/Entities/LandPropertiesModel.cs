namespace RPT.Domain.Models
{
    public class LandPropertiesModel
    {
        public int Id { get; set; }
        public int RealPropertiesId { get; set; }
        public int LandRestrictionsId { get; set; }
        public string TitleCertificate { get; set; }
        public string TitleCertDate { get; set; }
        public string SurveyNo { get; set; }
        public string LotNo { get; set; }
        public string BlockNo { get; set; }
        public string BoundaryNorth { get; set; }
        public string BoundaryEast { get; set; }
        public string BoundarySouth { get; set; }
        public string BoundaryWest { get; set; }
        public byte Sketch { get; set; }
    }
}
