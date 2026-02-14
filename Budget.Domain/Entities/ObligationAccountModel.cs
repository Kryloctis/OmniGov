namespace Budget.Domain.Models
{
    public class ObligationAccountModel
    {
        public int Id { get; set; }
        public int ObligationRequestId { get; set; }
        public int AllotmentAccountId { get; set; }
        public decimal Amount { get; set; }
    }
}
