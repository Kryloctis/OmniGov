namespace OmniGov.Budget.Domain.Entities
{
    public class SupplementalAppropriationsModel
    {
        public int Id { get; set; }
        public int BudgetAppropriationID { get; set; }
        public DateTime date_entry { get; set; }
        public decimal amount { get; set; }
        public string remarks { get; set; }
    }
}
