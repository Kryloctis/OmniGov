using System;

namespace RPT.Domain.Interfaces
{
    public class PreviousAssessmentModel
    {
        public int Id { get; set; }
        public int RealPropertiesId { get; set; }
        public string Pin { get; set; }
        public string ArpNo { get; set; }
        public decimal AssessedValue { get; set; }
        public string PreviousOwner { get; set; }
        public string EffectivityAssessment { get; set; }
        public string RecordingPerson { get; set; }
        public DateTime DateRecorded { get; set; }
    }
}
