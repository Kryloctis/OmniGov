using OmniGov.Core.Interfaces.Repositories;
using OmniGov.Core.Interfaces.Services;
using OmniGov.Core.Interfaces.Factories;
using OmniGov.Core.Services;
using RPT.Domain.Interfaces;
using RptInterfaces = RPT.Domain.Interfaces;

namespace RPT.Data.Repositories
{
    public class RptFactory
    {
        internal static RptGenericCommands mySqlGenericCommandsRPT;

        public static IRealPropertiesRepository RealPropertiesRepository() => new RealPropertiesRepository(mySqlGenericCommandsRPT);

        public static ILandAppraisalRepository LandAppraisalRepository() => new LandAppraisalRepository(mySqlGenericCommandsRPT);

        public static IBuildingDetailsRepository BuildingDetailsRepository() => new BuildingDetailsRepository(mySqlGenericCommandsRPT);

        public static ILandPropertiesRepository LandPropertiesRepository() => new LandPropertiesRepository(mySqlGenericCommandsRPT);

        public static IPreviousAssessment PreviousAssessmentRepository() => new PreviousAssessmentRepository(mySqlGenericCommandsRPT);

        public static RptInterfaces.IServer ServerRepository() 
        {
            var provider = ServiceLocator.GetRequiredService<IConnectionProvider>();
            return new RptServerRepository(mySqlGenericCommandsRPT, provider);
        }
    }
}
