using OmniGov.Core.Interfaces.Repositories;
using OmniGov.Core.Interfaces.Services;
using System.Transactions;

using OmniGov.Core.Services;

namespace OmniGov.Core.Repositories
{
    public class ServerRepository : IServer
    {
        private readonly IGenericCommands _genericCommands;
        private readonly IConnectionProvider _connectionProvider;

        public ServerRepository(IGenericCommands genericCommands, IConnectionProvider connectionProvider)
        {
            this._genericCommands = genericCommands;
            this._connectionProvider = connectionProvider;
        }

        public bool ApplyConnection(string connectionName)
        {
            if (TestConnection(connectionName))
            {
                _connectionProvider.SetLfsConnectionName(connectionName);
                return true;
            }
            return false;
        }

        public bool TestConnection(string connectionName)
        {
            return _genericCommands.TestConnection(connectionName);
        }
    }
}
