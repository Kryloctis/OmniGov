namespace OmniGov.PropertyAssessment.Domain.Interfaces.Factories
{
    public interface IPropertyAssessmentFactory
    {
        public IBuildingDetailsRepository BuildingDetailsRepository();

        public ILandAppraisalRepository LandAppraisalRepository();

        public ILandPropertiesRepository LandPropertiesRepository();

        public IRealPropertiesRepository RealPropertiesRepository();

        public IPreviousAssessment PreviousAssessment();
    }
}
