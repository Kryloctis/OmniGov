using System;

namespace RPT.Domain.Models
{
    public class BuildingDetailsModel
    {
        public int Id { get; set; }
        public int BuildingPropertiesId { get; set; }
        public int ClassificationCodesId { get; set; }
        public int ActualUseCodesId { get; set; }
        public int KindsOfBuildingsId { get; set; }
        public int BuildingStructuralTypeId { get; set; }
        public int BuildingClassId { get; set; }
        public int BuildingDepreciationId { get; set; }
        public int Floor { get; set; }
        public decimal Area { get; set; }
        public decimal PercentageCompletion { get; set; }
        public DateTime DateCompleted { get; set; }
        public DateTime DateOccupied { get; set; }
        public decimal UnitValue { get; set; }
        public decimal MarketValue { get; set; }
    }
}
