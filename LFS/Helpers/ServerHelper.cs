using MySql.Data.MySqlClient;
using OmniGov.Core.Interfaces.Repositories;
using OmniGov.Core.Interfaces.Services;
using OmniGov.Core.Interfaces.Factories;
using OmniGov.Core.Repositories;
using OmniGov.Core.Factories;
using OmniGov.Core.Services;
using RPT.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Net.NetworkInformation;

namespace LFS.Helpers
{
    public class ServerHelper
    {
        public static ServerHelper selectedServer;

        internal int LguId { get; set; }
        internal string MunicipalityCode { get; set; }
        internal string MunicipalityName { get; set; }
        internal string ProvinceCode { get; set; }
        internal string ProvinceName { get; set; }
        internal string LfsInstance { get; set; }
        internal string RpmsInstance { get; set; }
        internal Image Emblem { get; set; }

        internal static List<ServerHelper> ServerProfiles()
        {
            var lguModelList = new List<ServerHelper>();
            Image buugEmblem = Properties.Resources.lgu_buug_zsi;
            Image titayEmblem = Properties.Resources.lgu_titay_zsi;

            var buugZsiModel = new ServerHelper()
            {
                LguId = 1,
                MunicipalityCode = "02",
                MunicipalityName = "Buug",
                ProvinceCode = "080",
                ProvinceName = "Zamboanga Sibugay",
                LfsInstance = "bg_zsi_lfs_instance",
                RpmsInstance = "bg_zsi_rpm_instance",
                Emblem = (Bitmap)buugEmblem
            };

            var titayZsiModel = new ServerHelper()
            {
                LguId = 2,
                MunicipalityCode = "15",
                MunicipalityName = "Titay",
                ProvinceCode = "080",
                ProvinceName = "Zamboanga Sibugay",
                LfsInstance = "tty_zsi_lfs_instance",
                RpmsInstance = "tty_zsi_rpm_instance",
                Emblem = (Bitmap)titayEmblem
            };

            var demoModel = new ServerHelper()
            {
                LguId = 3,
                MunicipalityCode = "Demo",
                MunicipalityName = "Demo",
                ProvinceCode = "Demo",
                ProvinceName = "Demo",
                LfsInstance = "demo_lfs_instance",
                RpmsInstance = "demo_rpm_instance",
                Emblem = null
            };

            lguModelList.Add(demoModel);
            lguModelList.Add(buugZsiModel);
            lguModelList.Add(titayZsiModel);

            return lguModelList;
        }

        private static bool HostReachable(string connectionName)
        {
            string connStr = ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
            var builder = new MySqlConnectionStringBuilder(connStr);
            string server = builder.Server;

            // Always true for localhost or offline testing
            if (server.Equals("localhost", StringComparison.OrdinalIgnoreCase) ||
                server is "127.0.0.1" or "::1")
                return true;

            using var ping = new Ping();
            return ping.Send(server, 500)?.Status == IPStatus.Success;
        }

        internal static List<ServerHelper> AvailableServerList()
        {
            var availableServerList = new List<ServerHelper>();

            foreach (ServerHelper model in ServerProfiles())
            {
                string lfsInstance = model.LfsInstance;
                string rpmInstance = model.RpmsInstance;

                if (!HostReachable(lfsInstance)) continue;

                // Use DI to test connections
                var factory = ServiceLocator.GetRequiredService<IRepositoryFactory>();
                bool isLfsdbConnected = factory.ServerRepository().TestConnection(lfsInstance);
                bool isRpmsdbConnected = RptFactory.ServerRepository().TestConnection(rpmInstance);

                if (!isRpmsdbConnected || !isLfsdbConnected)
                    continue;

                availableServerList.Add(model);
            }

            return availableServerList;
        }
    }
}

