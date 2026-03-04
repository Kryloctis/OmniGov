namespace OmniGov.Budget.Domain.Entities
{
    public class BudgetAppropriationsHasRealignmentsModel
    {
        public int Id { get; set; }
        public int RealignmentsId { get; set; }
        public int BudgetAppropriationsId { get; set; }
        public DateTime DateEntry { get; set; }
        public string Remarks { get; set; }
    }
}
