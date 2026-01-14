namespace ACC.Domain.Models
{
    public class ObligationAccountModel
    {
        public int Id { get; set; }
        public int ObligationRequestId { get; set; }
        public int AllotmentReleaseId { get; set; }
        public decimal Amount { get; set; }
    }
}