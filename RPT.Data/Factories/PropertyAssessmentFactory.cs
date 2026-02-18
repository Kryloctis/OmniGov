using PropertyAssessment.Domain.Interfaces;

namespace PropertyAssessment.Data.Factories
{
    public static class PropertyAssessmentFactory
    {
        private static T Resolve<T>() where T : notnull => OmniGov.Core.Services.ServiceLocator.GetRequiredService<T>();

        public static IRealPropertiesRepository RealPropertiesRepository() => Resolve<IRealPropertiesRepository>();

        public static ILandAppraisalRepository LandAppraisalRepository() => Resolve<ILandAppraisalRepository>();

        public static IBuildingDetailsRepository BuildingDetailsRepository() => Resolve<IBuildingDetailsRepository>();

        public static ILandPropertiesRepository LandPropertiesRepository() => Resolve<ILandPropertiesRepository>();

        public static IPreviousAssessment PreviousAssessmentRepository() => Resolve<IPreviousAssessment>();
    }
}