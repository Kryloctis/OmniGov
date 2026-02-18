namespace Budget.Domain.Entities
{
    public class AugmentationsModel
    {
        public int Id { get; set; }
        public int BudgetAppropriationsId { get; set; }
        public decimal Amount { get; set; }
    }
}