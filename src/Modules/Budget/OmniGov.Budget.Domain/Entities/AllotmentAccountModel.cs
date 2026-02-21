namespace OmniGov.Budget.Domain.Entities
{
    public class AllotmentAccountModel
    {
        public int ID { get; set; }
        public int BudgetAppropriationsID { get; set; }
        public int AllotmentReleaseID { get; set; }
        public decimal Amount { get; set; }
    }
}
