using System;
using System.Collections.Generic;
using System.Text;

namespace ACC.Domain.Models
{
    public class CattleTransferOfOwnershipModel
    {
        public int ID { get; set; }
        public int CattleOwnershipID { get; set; }
        public int OldOwnerID { get; set; }
        public int NewOwnerID { get; set; }
        public string Barangay { get; set; }
        public string Municipality { get; set; }
        public string Province { get; set; }
        public Decimal Amount { get; set; }
        public string CattleType { get; set; }
        public string CattleSex { get; set; }
        public int CattleAge { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }
    }
}
