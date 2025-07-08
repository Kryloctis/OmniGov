using ACC.Domain.Interfaces;
using System.Transactions;

namespace ACC.Data
{
    public class AccServerRepository : IServer
    {
        private AccGenericCommands mySqlGenericCommandsLFS;

        public AccServerRepository(AccGenericCommands mySqlGenericCommandsLFS)
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
            var test = new AccGenericCommands(connectionName);
            return test.TestConnection(connectionName);
        }
    }
}