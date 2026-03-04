namespace OmniGov.Budget.Domain.Entities
{
    public class ObligationRequestModel
    {
        public int Id { get; set; }
        public int FppId { get; set; }
        public int AllotmentClassId { get; set; }
        public int FundId { get; set; }
        public string TransactionNo { get; set; }
        public string ObligationNo { get; set; }
        public string Payee { get; set; }
        public string Explanation { get; set; }
        public string ReferenceNo { get; set; }
        public DateTime DateRequested { get; set; }
        public enum Status
        { draft, pending, approved, disapproved, cancelled }

        public Status ObligationStatus { get; set; }
        public string Remarks { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
    }
}