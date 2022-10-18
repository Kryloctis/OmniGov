namespace ACC.Domain.Models
{
    public class RealPropertiesModel
    {
        public int Id { get; set; }
        public int TaxpayersId { get; set; }
        public int BarangaysId { get; set; }
        public int ClassificationCodesId { get; set; }
        public int ActualUseCodesId { get; set; }
        public string Street { get; set; }
        public string PropertyIdentifier { get; set; }
        public string CompleteArpNo { get; set; }
        public string PropertyPin { get; set; }
        public string PropertyKind { get; set; }
        public int EffectivityQuarter { get; set; }
        public int EffectivityYear { get; set; }
        public decimal OtherImprovements { get; set; }
        public decimal AssessedValue { get; set; }
        public decimal Area { get; set; }
        public string LotNo { get; set; }
        public int GrYear { get; set; }
        public bool IsTaxable { get; set; }
        public bool IsCancelled { get; set; }
    }
}
