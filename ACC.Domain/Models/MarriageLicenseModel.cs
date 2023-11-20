using System;

namespace ACC.Domain.Models
{
    public class MarriageLicenseModel
    {
        public int ID { get; set; }
        public DateTime IssuedOn { get; set; }
        public string RegisterNo { get; set; }
        public DateTime PublishedOn { get; set; }
        public string HusbandName { get; set; }
        public int HusbandAge { get; set; }
        public int HusbandMonth { get; set; }
        public string HusbandStreet { get; set; }
        public string HusbandBarangay { get; set; }
        public string HusbandMunipality { get; set; }
        public string HusbandProvince { get; set; }
        public string WifeName { get; set; }
        public int WifeAge { get; set; }
        public int WifeMonth { get; set; }
        public string WifeStreet { get; set; }
        public string WifeBarangay { get; set; }
        public string WifeMunicipality { get; set; }
        public string WifeProvince { get; set; }
        public int CreatedBy { get; set; }

    }
}
