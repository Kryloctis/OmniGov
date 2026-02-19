
using OmniGov.Core.Models;

namespace OmniGov.Core.Interfaces.Repositories
{
    public interface IServer
    {
        bool TestConnection(DatabaseConfig config);
        void ApplyProfile(LguProfile profile);
    }
}
