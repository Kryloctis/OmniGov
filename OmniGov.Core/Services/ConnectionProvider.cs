using OmniGov.Core.Interfaces.Services;

namespace OmniGov.Core.Services
{
    /// <summary>
    /// Manages database connection names for the application
    /// </summary>
    public class ConnectionProvider : IConnectionProvider
    {
        private string? _lfsConnectionName;
        private string? _rptConnectionName;

        public bool IsInitialized => !string.IsNullOrWhiteSpace(_lfsConnectionName)
                                   && !string.IsNullOrWhiteSpace(_rptConnectionName);

        public string? GetLfsConnectionName()
        {
            return _lfsConnectionName;
        }

        public string? GetRptConnectionName()
        {
            return _rptConnectionName;
        }

        public void SetLfsConnectionName(string connectionName)
        {
            if (string.IsNullOrWhiteSpace(connectionName))
                throw new ArgumentNullException(nameof(connectionName));

            _lfsConnectionName = connectionName;
        }

        public void SetRptConnectionName(string connectionName)
        {
            if (string.IsNullOrWhiteSpace(connectionName))
                throw new ArgumentNullException(nameof(connectionName));

            _rptConnectionName = connectionName;
        }
    }
}