using System;

namespace ACC.Domain.Models
{
    public class RptPreviousAssessmentModel
    {
        public int Id { get; set; }
        public int RealPropertiesId { get; set; }
        public int PrevPropertiesId { get; set; }
        public string Pin { get; set; }
        public string CompleteArpNo { get; set; }
        public decimal AssessedValue { get; set; }
        public string Owner { get; set; }
        public string Effectivity { get; set; }
        public string RecordingPerson { get; set; }
        public DateTime DateRecorded { get; set; }
    }
}