using System;

namespace ACC.Domain.Models
{
    public class PrevCattleOwnershipModel
    {
        public int Id { get; set; }
        public int CattleOwnershipId { get; set; }
        public int PreviousCattleOwnershipId { get; set; }
        public decimal CattlePrice { get; set; }
        public DateTime TransferDate { get; set; }
    }
}