using OmniGov.Core.Interfaces.Repositories;
using OmniGov.Core.Interfaces.Services;
using OmniGov.Core.Interfaces.Factories;
using RPT.Domain.Interfaces;
using RptInterfaces = RPT.Domain.Interfaces;
using System.Transactions;

namespace RPT.Data.Repositories
{
    public class RptServerRepository : RptInterfaces.IServer
    {
        private IRPTGenericCommands mySqlGenericCommandsRPT;
        private readonly IConnectionProvider _connectionProvider;

        public RptServerRepository(IRPTGenericCommands mySqlGenericCommandsRPT, IConnectionProvider connectionProvider)
        {
            this.mySqlGenericCommandsRPT = mySqlGenericCommandsRPT;
            this._connectionProvider = connectionProvider;
        }

        public bool ApplyConnection(string connectionName)
        {
            if (TestConnection(connectionName))
            {
                RptFactory.mySqlGenericCommandsRPT = new RptGenericCommands(connectionName);
                _connectionProvider.SetRptConnectionName(connectionName);
                return true;
            }
            return false;
        }

        public bool TestConnection(string connectionString)
        {
            mySqlGenericCommandsRPT = new RptGenericCommands(connectionString);
            return mySqlGenericCommandsRPT.TestConnection(connectionString);
        }
    }
}

