namespace ACC.Domain.Models
{
    public class RealPropertiesModel
    {
        public int Id { get; set; }
        public int TaxpayersId { get; set; }
        public string PropertyIdentifier { get; set; }
        public string CompleteArpNo { get; set; }
        public string Pin { get; set; }
        public string BarangayName { get; set; }
        public string MunicipalityName { get; set; }
        public string ProvinceName { get; set; }
        public string PropertyKind { get; set; }
        public int EffectivityQuarter { get; set; }
        public int EffectivityYear { get; set; }
        public decimal OtherImprovements { get; set; }
        public decimal AssessedValue { get; set; }
        public decimal Area { get; set; }
        public string LotNo { get; set; }
        public string ClassificationCode { get; set; }
        public string ClassificationName { get; set; }
        public string ActualUseCode { get; set; }
        public string ActualUseName { get; set; }
        public int GrYear { get; set; }
        public bool IsTaxable { get; set; }
        public bool IsCancelled { get; set; }
    }
}
