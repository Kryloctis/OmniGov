using System;
using System.Collections.Generic;
using System.Text;

namespace ACC.Domain.Models
{
    public class PaymentCollectionModel
    {
        public int Id { get; set; }
        public int CoId { get; set; }
        public int FId { get; set; }
        public int AccId { get; set; }
        public int GlaId { get; set; }
        public int SlaId { get; set; }
        public string Payee { get; set; }
        public string ReceiptNo { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int UpdatedBy { get; set; }
    }
}
