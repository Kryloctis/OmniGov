using RPT.Domain.Interfaces;
using System.Transactions;

namespace RPT.Data
{
    public class ServerRepository : IServer
    {
        private RptGenericCommands mySqlGenericCommandsRPT;

        public ServerRepository(RptGenericCommands mySqlGenericCommandsRPT)
        {
            this.mySqlGenericCommandsRPT = mySqlGenericCommandsRPT;
        }

        public bool ApplyConnection(string connectionName)
        {
            using (var scope = new TransactionScope())
            {
                _ = TestConnection(connectionName);
                RptFactory.mySqlGenericCommandsRPT = new RptGenericCommands(connectionName);

                scope.Complete();
                return true;
            }
        }

        public bool TestConnection(string connectionName)
        {
            mySqlGenericCommandsRPT = new RptGenericCommands(connectionName);
            return mySqlGenericCommandsRPT.TestConnection(connectionName);
        }
    }
}