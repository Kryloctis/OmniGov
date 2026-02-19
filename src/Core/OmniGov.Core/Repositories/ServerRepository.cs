
using OmniGov.Core.Interfaces.Repositories;
using OmniGov.Core.Interfaces.Services;
using OmniGov.Core.Models;

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

        public bool TestConnection(DatabaseConfig config)
        {
            return _genericCommands.TestConnection(config.ToConnectionString());
        }

        public void ApplyProfile(LguProfile profile)
        {
            _connectionProvider.SetActiveProfile(profile);
        }
    }
}
