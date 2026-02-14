using RPT.Domain.Interfaces;
using System.Transactions;

namespace RPT.Data.Repositories
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
            mySqlGenericCommandsRPT = new RptGenericCommands(connectionString);
            return mySqlGenericCommandsRPT.TestConnection(connectionString);
        }
    }
}