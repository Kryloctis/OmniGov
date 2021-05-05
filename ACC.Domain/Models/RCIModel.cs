using System;
using System.Collections.Generic;
using System.Text;

namespace ACC.Domain.Models
{
    public class RCIModel
    {
        public int Id { get; set; }
        public int BankId { get; set; }
        public int FundsId { get; set; }
        public int FunctionProgramProjectId { get; set; }
        public DateTime CheckDate { get; set; }
        public string CheckNo { get; set; }
        public string DvNo { get; set; }
        public string Payee { get; set; }
        public string NaturePayment { get; set; }
        public string ObNo { get; set; }
        public decimal Amount { get; set; }
        public decimal TrustLiabilities { get; set; }
        public decimal BirVatNonVat { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
