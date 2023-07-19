using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Data.Common;

namespace Gen.Domain.Models
{
    public class ServerModel
    {
        public int LguId { get; set; }
        public string MunicipalityCode { get; set; }
        public string MunicipalityName { get; set; }
        public string ProvinceCode { get; set; }
        public string ProvinceName { get; set; }
        public string LfsInstance { get; set; }
        public string RpmInstance { get; set; }
        public byte[] Emblem { get; set; }
    }
}