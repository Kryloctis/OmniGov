using System;

namespace ACC.Domain.Models
{
    public class RealPropertiesModel
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string PropertyIdentifier { get; set; }
        public string CompleteArpNo { get; set; }
        public string PropertyPin { get; set; }
        public char PropertyKind { get; set; }
        public int EffectivityQuarter { get; set; }
        public int EffectivityYear { get; set; }
        public decimal OtherImprovements { get; set; }
        public decimal AssessedValue { get; set; }
        public decimal Area { get; set; }
        public string LotNo { get; set; }
        public int GrYear { get; set; }
        public bool IsTaxable { get; set; }
        public bool IsCancelled { get; set; }
        public int CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public TaxpayersModel TaxpayersModel { get; set; }
        public TaxpayerTypeModel TaxpayerTypeModel { get; set; }

        public ProvincesModel ProvincesModel { get; set; }
        public MunicipalitiesModel MunicipalitiesModel { get; set; }
        public BarangayModel BarangayModel { get; set; }
        public ActualUseCodesModel ActualUseCodesModel { get; set; }
        public ClassificationCodesModel ClassificationCodesModel { get; set; }
        public RptPreviousAssessmentModel RptPreviousAssessmentModel { get; set; }
    }
}