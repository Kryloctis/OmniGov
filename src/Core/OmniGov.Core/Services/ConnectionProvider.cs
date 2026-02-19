
using OmniGov.Core.Interfaces.Services;
using OmniGov.Core.Models;

namespace OmniGov.Core.Services
{
    public class ConnectionProvider : IConnectionProvider
    {
        private LguProfile? _activeProfile;

        public bool IsInitialized => _activeProfile != null;

        public LguProfile? GetActiveProfile() => _activeProfile;

        public void SetActiveProfile(LguProfile profile)
        {
            _activeProfile = profile ?? throw new ArgumentNullException(nameof(profile));
        }

        public string? GetConnectionString(bool useRpt = false)
        {
            if (_activeProfile == null) return null;

            return useRpt 
                ? _activeProfile.RptDatabase.ToConnectionString()
                : _activeProfile.LfsDatabase.ToConnectionString();
        }
    }
}