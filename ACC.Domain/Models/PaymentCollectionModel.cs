using System;
using System.Collections.Generic;
using System.Text;

namespace ACC.Domain.Models
{
    public class PaymentCollectionModel
    {
        public int Id { get; set; }
        public int CollectingOfficerId { get; set; }
        public int FundId { get; set; }
        public int AccountableFormId { get; set; }
        public int GeneralLedgerAccountId { get; set; }
        public int SlaId { get; set; }
        public string Payee { get; set; }
        public string ReceiptNo { get; set; }
        public int Quantity { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int UpdatedBy { get; set; }
    }
}
