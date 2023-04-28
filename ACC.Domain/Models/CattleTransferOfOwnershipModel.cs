using System;
using System.Collections.Generic;
using System.Text;

namespace ACC.Domain.Models
{
    public class CattleTransferOfOwnershipModel
    {
        public int ID { get; set; }
        public int OldOwnerID { get; set; }
        public int NewOwnerID { get; set; }
        public string Barangay { get; set; }
        public string Municipality { get; set; }
        public string Province { get; set; }
        public string Type { get; set; }
        public string Sex { get; set; }
        public string Age { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }
    }
}
