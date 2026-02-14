namespace Treasury.Domain.Entities
{
    public class CashTicketsIssuedModel
    {
        public int Id { get; set; }
        public int CashTicketId { get; set; }
        public int CollectorId { get; set; }
        public int? JobOrderId { get; set; }
        public DateTime DateIssued { get; set; }
        public int Quantity { get; set; }
        public int IssuedBy { get; set; }
    }
}