using System;

namespace ACC.Domain.Models
{
    public class PrevCattleOwnershipModel
    {
        private int Id { get; set; }
        private int PreviousCattleOwnershipId { get; set; }
        private decimal CattlePrice { get; set; }
        private DateTime TransferDate { get; set; }
    }
}