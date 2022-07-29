using System;

namespace RPT.Domain.Models
{
    public class AssessmentPostingModel
    {
        public int Id { get; set; }
        public string CompleteArpNo  { get; set; }
        public string PropertyPin { get; set; }
        public string OwnerName { get; set; }
        public string OwnerTin { get; set; }
        public string OwnerAddress { get; set; }
        public string OwnerContact { get; set; }
        public string BarangayName { get; set; }
        public string MunicipalityName { get; set; }
        public string ProvinceName { get; set; }
        public string PropertyKind { get; set; }
        public int EffectivityQuarter  { get; set; }
        public int EffectivityYear  { get; set; }
        public decimal AssessedValue { get; set; }
        public bool IsTaxable { get; set; }
        public bool IsCancelled { get; set; }
        public decimal PenaltyRate { get; set; }
        public string   PenaltyFrequency { get; set; }
        public decimal BasicRate { get; set; }
        public decimal SefRate { get; set; }
        public bool isAdvance { get; set; }
        public DateTime PostedAt { get; set; }
        public int PostedBy { get; set; }
        public DateTime RepostedAt { get; set; }
        public int RepostedBy { get; set; }
    }
}
