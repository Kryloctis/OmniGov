using System;

namespace ACC.Domain.Models
{
    public class ReceiptsIssuedModel
    {
        public int Id { get; set; }
        public int CollectorId { get; set; }
        public int? JobOrderId { get; set; }
        public int Is_returned { get; set; }
        public DateTime Returned_date { get; set; }
        public DateTime IssuedDate { get; set; }
        public int ReceiptId { get; set; }
        public int IssuedFrom { get; set; }
        public int IssuedTo { get; set; }
        public int Last_issued { get; set; }
        public int Quantity { get; set; }
        public int IssuedByUserId { get; set; }
    }
}