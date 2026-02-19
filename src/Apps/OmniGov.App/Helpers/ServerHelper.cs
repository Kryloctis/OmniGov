using OmniGov.Core.Interfaces.Factories;
using OmniGov.Core.Models;
using OmniGov.Core.Services;
using System.Net.NetworkInformation;
using System.Text.Json;

namespace OmniGov.App.Helpers
{
    public class ServerHelper
    {
        public static LguProfile? SelectedProfile { get; set; }

        public static List<LguProfile> LoadProfiles()
        {
            string jsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "servers.json");

            // If not in base directory (e.g. during dev), check the project folder
            if (!File.Exists(jsonPath))
            {
                jsonPath = Path.Combine(Directory.GetCurrentDirectory(), "servers.json");
            }

            if (!File.Exists(jsonPath)) return new List<LguProfile>();

            string jsonContent = File.ReadAllText(jsonPath);
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            return JsonSerializer.Deserialize<List<LguProfile>>(jsonContent, options) ?? new List<LguProfile>();
        }

        public static Image? GetEmblem(string emblemName)
        {
            if (string.IsNullOrEmpty(emblemName)) return null;

            // Try to find the image in resources
            return Properties.Resources.ResourceManager.GetObject(emblemName) as Image;
        }

        public static bool HostReachable(DatabaseConfig config)
        {
            string server = config.Server;

            if (server.Equals("localhost", StringComparison.OrdinalIgnoreCase) ||
                server is "127.0.0.1" or "::1")
                return true;

            try
            {
                using var ping = new Ping();
                return ping.Send(server, 500)?.Status == IPStatus.Success;
            }
            catch { return false; }
        }

        public static List<LguProfile> GetAvailableProfiles()
        {
            var allProfiles = LoadProfiles();
            var available = new List<LguProfile>();

            foreach (var profile in allProfiles)
            {
                if (!HostReachable(profile.LfsDatabase)) continue;

                var factory = ServiceLocator.GetRequiredService<IRepositoryFactory>();
                bool isLfsConnectable = factory.ServerRepository().TestConnection(profile.LfsDatabase);
                bool isRptConnectable = factory.ServerRepository().TestConnection(profile.RptDatabase);

                if (isLfsConnectable && isRptConnectable)
                {
                    available.Add(profile);
                }
            }

            return available;
        }
    }
}