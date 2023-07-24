using RPT.Domain.Interfaces;

namespace RPT.Data
{
    public class RptFactory
    {
        internal static RptGenericCommands mySqlGenericCommandsRPT;

        public static IRealPropertiesRepository RealPropertiesRepository() => new RealPropertiesRepository(mySqlGenericCommandsRPT);

        public static ILandAppraisalRepository LandAppraisalRepository() => new LandAppraisalRepository(mySqlGenericCommandsRPT);

        public static IBuildingDetailsRepository BuildingDetailsRepository() => new BuildingDetailsRepository(mySqlGenericCommandsRPT);

        public static ILandPropertiesRepository LandPropertiesRepository() => new LandPropertiesRepository(mySqlGenericCommandsRPT);

        public static IPreviousAssessment PreviousAssessmentRepository() => new PreviousAssessmentRepository(mySqlGenericCommandsRPT);

        public static IServer ServerRepository() => new ServerRepository(mySqlGenericCommandsRPT);
    }
}