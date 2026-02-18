namespace OmniGov.Core.Interfaces.Services
{
    /// <summary>
    /// Provides database connection names for the application
    /// </summary>
    public interface IConnectionProvider
    {
        /// <summary>
        /// Gets the connection name for the LFS database
        /// </summary>
        string? GetLfsConnectionName();

        /// <summary>
        /// Gets the connection name for the RPT database
        /// </summary>
        string? GetRptConnectionName();

        /// <summary>
        /// Sets the LFS connection name
        /// </summary>
        void SetLfsConnectionName(string connectionName);

        /// <summary>
        /// Sets the RPT connection name
        /// </summary>
        void SetRptConnectionName(string connectionName);

        /// <summary>
        /// Indicates whether connections have been initialized
        /// </summary>
        bool IsInitialized { get; }
    }
}
