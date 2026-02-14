using System;

namespace Budget.Domain.Models
{
    public class BudgetAppropriationHasAugmentationsModel
    {
        public int Id { get; set; }
        public int AugmentationsId { get; set; }
        public int BudgetAppropriationsId { get; set; }
        public DateTime DateEntry { get; set; }
        public string Remarks { get; set; }
    }
}
