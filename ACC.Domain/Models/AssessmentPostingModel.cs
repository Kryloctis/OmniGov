using System;

namespace RPT.Domain.Models
{
    public class AssessmentPostingModel
    {
        public int Id { get; set; }
        public string ArpNo  { get; set; }
        public string PIN { get; set; }
        public string Owner { get; set; }
        public string  BarangayCode { get; set; }
        public string BarangayName { get; set; }
        public string MunicipalityCode { get; set; }
        public string MunicipalityName { get; set; }
        public string ProvinceCode { get; set; }
        public string ProvinceName { get; set; }
        public string PropertyKind { get; set; }
        public int EffectivityQuarter  { get; set; }
        public int EffectivityYear  { get; set; }
        public decimal AssessedValue { get; set; }
        public bool IsTaxable { get; set; }
        public bool IsCancelled { get; set; }
        public DateTime PostedAt { get; set; }
        public Decimal PenaltyRate { get; set; }
        public string   PenaltyFrequency { get; set; }
        public Decimal BasicRate { get; set; }
        public decimal SEFRate { get; set; }
    }
}
