namespace Treasury.Domain.Entities
{
    public class RptPreviousAssessmentModel
    {
        public int Id { get; set; }
        public int RealPropertiesId { get; set; }
        public TaxpayersModel TaxpayersModel { get; set; }
        public string CompleteArpNo { get; set; }
        public string Pin { get; set; }
        public decimal AssessedValue { get; set; }
        public DateTime DateOfEntry { get; set; }
        public string EffectivityQtr { get; set; }
        public string EffectivityYear { get; set; }
        public int GrYear { get; set; }
        public int IsTaxable { get; set; }
        public int IsCancelled { get; set; }
        public string RecordingPerson { get; set; }
        public int CreatedBy { get; set; }
    }
}
