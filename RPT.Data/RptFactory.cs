using RPT.Domain.Interfaces;

namespace RPT.Data
{
    public class RptFactory
    {
        private static RptGenericCommands mySqlGenericCommandsRPT = new RptGenericCommands("RealPropertyTaxInstance");

        public static IRealPropertiesRepository RealPropertiesRepository() => new RealPropertiesRepository(mySqlGenericCommandsRPT);

        public static ILandAppraisalRepository LandAppraisalRepository() => new LandAppraisalRepository(mySqlGenericCommandsRPT);

        public static IBuildingDetailsRepository BuildingDetailsRepository() => new BuildingDetailsRepository(mySqlGenericCommandsRPT);

        public static ILandPropertiesRepository LandPropertiesRepository() => new LandPropertiesRepository(mySqlGenericCommandsRPT);

        public static IPreviousAssessment PreviousAssessmentRepository() => new PreviousAssessmentRepository(mySqlGenericCommandsRPT);
    }
}