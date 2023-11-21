using ACC.Domain.Interfaces;
using System.Transactions;

namespace ACC.Data
{
    public class ServerRepository : IServer
    {
        private AccGenericCommands mySqlGenericCommandsLFS;

        public ServerRepository(AccGenericCommands mySqlGenericCommandsLFS)
        {
            this.mySqlGenericCommandsLFS = mySqlGenericCommandsLFS;
        }

        public bool ApplyConnection(string connectionName)
        {
            using (var scope = new TransactionScope())
            {
                _ = TestConnection(connectionName);
                AccFactory.mySqlGenericCommandsLFS = new AccGenericCommands(connectionName);

                scope.Complete();
                return true;
            }
        }

        public bool TestConnection(string connectionName)
        {
            mySqlGenericCommandsLFS = new AccGenericCommands(connectionName);
            return mySqlGenericCommandsLFS.TestConnection(connectionName);
        }
    }
}