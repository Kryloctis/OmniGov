
using OmniGov.Core.Models;

namespace OmniGov.Core.Interfaces.Services
{
    /// <summary>
    /// Manages the active LGU profile and provides connection strings for the application
    /// </summary>
    public interface IConnectionProvider
    {
        /// <summary>
        /// Gets the currently active LGU profile
        /// </summary>
        LguProfile? GetActiveProfile();

        /// <summary>
        /// Sets the active LGU profile
        /// </summary>
        void SetActiveProfile(LguProfile profile);

        /// <summary>
        /// Gets the connection string for the specified target (LFS or RPT)
        /// </summary>
        string? GetConnectionString(bool useRpt = false);

        /// <summary>
        /// Indicates whether a profile has been selected
        /// </summary>
        bool IsInitialized { get; }
    }
}
