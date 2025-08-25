using ACC.Data;
using RPT.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        internal static List<ServerHelper> AvailableServerList()
        {
            var availableServerList = new List<ServerHelper>();

            foreach (ServerHelper model in ServerProfiles())
            {
                string lfsInstance = model.LfsInstance;
                string rpmInstance = model.RpmsInstance;

                bool isLfsdbConnected = AccFactory.ServerRepository().TestConnection(lfsInstance);
                bool isRpmsdbConnected = RptFactory.ServerRepository().TestConnection(rpmInstance);

                if (!isRpmsdbConnected && !isLfsdbConnected)
                    continue;

                availableServerList.Add(model);
            }

            return availableServerList;
        }
    }
}