using RPT.Domain.Interfaces;
using System.Configuration;
using System.Transactions;

namespace RPT.Data
{
    public class RptServerRepository : IServer
    {
        private RptGenericCommands mySqlGenericCommandsRPT;

        public RptServerRepository(RptGenericCommands mySqlGenericCommandsRPT)
        {
            this.mySqlGenericCommandsRPT = mySqlGenericCommandsRPT;
        }

        public bool ApplyConnection(string connectionName)
        {
            using (var scope = new TransactionScope())
            {
                RptFactory.mySqlGenericCommandsRPT = new RptGenericCommands(connectionName);

                scope.Complete();
                return true;
            }
        }

        public bool TestConnection(string connectionString)
        {
            return mySqlGenericCommandsRPT.TestConnection(connectionString);
        }
    }
}