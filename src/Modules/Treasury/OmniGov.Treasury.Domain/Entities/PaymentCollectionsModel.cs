namespace Treasury.Domain.Entities
{
    public class PaymentCollectionsModel
    {
        public int Id { get; set; }
        public int CollectingOfficerId { get; set; }
        public int? JobOrderId { get; set; }
        public int AccountableFormId { get; set; }
        public string Payee { get; set; }
        public string ReceiptNo { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public bool IsCancelled { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
    }
}
