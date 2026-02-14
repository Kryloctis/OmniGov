using OmniGov.Core.Interfaces;
using System.Transactions;

namespace OmniGov.Core.Repositories
{
    public class AccServerRepository : IServer
    {
        private GenericCommands mySqlGenericCommandsLFS;

        public AccServerRepository(GenericCommands mySqlGenericCommandsLFS)
        {
            this.mySqlGenericCommandsLFS = mySqlGenericCommandsLFS;
        }

        public bool ApplyConnection(string connectionName)
        {
            using (var scope = new TransactionScope())
            {
                _ = TestConnection(connectionName);
                mySqlGenericCommandsLFS = new GenericCommands(connectionName);

                scope.Complete();
                return true;
            }
        }

        public bool TestConnection(string connectionName)
        {
            mySqlGenericCommandsLFS = new GenericCommands(connectionName);
            return mySqlGenericCommandsLFS.TestConnection(connectionName);
        }
    }
}