using System;

namespace ACC.Domain.Models
{
    public class RptPreviousAssessmentModel
    {
        public int Id { get; set; }
        public int RealPropertiesId { get; set; }
        public string PropertyPin { get; set; }
        public string CompleteArpNo { get; set; }
        public decimal AssessedValue { get; set; }
        public string PreviousOwner { get; set; }
        public string EffectivityAssessment { get; set; }
        public DateTime? DateRecorded { get; set; }
    }
}
