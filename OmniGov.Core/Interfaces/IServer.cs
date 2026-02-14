namespace OmniGov.Core.Interfaces
{
    public interface IServer
    {
        bool TestConnection(string connectionName);

        bool ApplyConnection(string connectionName);
    }
}