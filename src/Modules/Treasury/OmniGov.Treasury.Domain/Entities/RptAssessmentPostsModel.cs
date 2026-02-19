namespace Treasury.Domain.Entities
{
    public class RptAssessmentPostsModel
    {
        public int Id { get; set; }
        public string CompleteArpNo { get; set; }
        public string PropertyKind { get; set; }

        public int TaxpayerId { get; set; }
        public string PropertyPin { get; set; }
        public string TaxpayerTin { get; set; }
        public string TaxpayerName { get; set; }
        public string TaxpayerContactInfo { get; set; }
        public string TaxpayerAddress { get; set; }
        public string Street { get; set; }
        public string BarangayName { get; set; }
        public string MunicipalityName { get; set; }
        public string ProvinceName { get; set; }
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
        public decimal PenaltyRate { get; set; }
        public string PenaltyFrequency { get; set; }
        public decimal BasicRate { get; set; }
        public decimal SefRate { get; set; }
        public int DueYear { get; set; }
        public int PostedBy { get; set; }
    }
}
