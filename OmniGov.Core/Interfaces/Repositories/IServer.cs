namespace OmniGov.Core.Interfaces.Repositories
{
    public interface IServer
    {
        bool TestConnection(string connectionName);

        bool ApplyConnection(string connectionName);
    }
}
