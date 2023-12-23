using System;

namespace ACC.Domain.Models
{
    public class PaymentCollectionsModel
    {
        public int Id { get; set; }
        public CollectingOfficerModel CollectingOfficerModel { get; set; }
        public JobOrderModel JobOrderModel { get; set; }
        public AccountableFormsModel AccountableFormsModel { get; set; }
        public string Payee { get; set; }
        public string ReceiptNo { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public bool IsCancelled { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
    }
}