namespace OmniGov.Budget.Domain.Entities
{
    public class RealignmentsModel
    {
        public int Id { get; set; }
        public int BudgetAppropriationsId { get; set; }
        public decimal Amount { get; set; }
    }
}
