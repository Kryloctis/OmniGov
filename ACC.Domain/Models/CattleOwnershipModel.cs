using System;

namespace ACC.Domain.Models
{
    public class CattleOwnershipModel
    {
        public int ID { get; set; }
        public string OwnerName { get; set; }
        public int OwnerID { get; set; }
        public int Tag { get; set; }
        public string OwnerBarangay { get; set; }
        public string OwnerMunicipality { get; set; }
        public string OwnerProvince { get; set; }
        public string CattleType { get; set; }
        public string CattleSex { get; set; }
        public int CattleAge { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }
    }
}
