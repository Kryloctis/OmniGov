using ACC.Data;
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
        private static MySqlGenericCommands mySqlGenericCommandsRPT = new MySqlGenericCommands("RealPropertyTaxInstance");

        public static IRealPropertiesRepository RealPropertiesRepository() => new RealPropertiesRepository(mySqlGenericCommandsRPT);

        public static ILandAppraisalRepository LandAppraisalRepository() => new LandAppraisalRepository(mySqlGenericCommandsRPT);

    }
}
