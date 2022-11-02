using ACC.Data;
using RPT.Domain;
using RPT.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPT.Data
{
    public class RptFactory
    {
        private static RptGenericCommands mySqlGenericCommandsRPT = new RptGenericCommands("RealPropertyTaxInstance");

        public static IRealPropertiesRepository RealPropertiesRepository() => new RealPropertiesRepository(mySqlGenericCommandsRPT);

        public static ILandAppraisalRepository LandAppraisalRepository() => new LandAppraisalRepository(mySqlGenericCommandsRPT);

        public static IBuildingDetailsRepository BuildingDetailsRepository() => new BuildingDetailsRepository(mySqlGenericCommandsRPT);

        public static ILandPropertiesRepository LandPropertiesRepository() => new LandPropertiesRepository(mySqlGenericCommandsRPT);


    }
}
