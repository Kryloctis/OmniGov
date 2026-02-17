namespace Budget.Domain.Models
{
    public class AllotmentAccountModel
    {
        public int ID { get; set; }
        public int BudgetAppropriationsID { get; set; }
        public int AllotmentReleaseID { get; set; }
        public decimal Amount { get; set; }
    }
}
