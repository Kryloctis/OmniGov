using System;

namespace ACC.Domain.Models
{
    public class BankDepositsModel
    {
        public int Id { get; set; }
        public int bankId { get; set; }
        public string Reference { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int UpdatedBy { get; set; }
        public int fundId { get; set; }
    }
}