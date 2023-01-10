using System;
using System.Collections.Generic;
using System.Text;

namespace ACC.Domain.Models
{
    public class ChequesModel
    {
        public int Id { get; set; }
        public int BankAccountsId { get; set; }
        public string ChequeNo { get; set; }
        public DateTime ChequeDate { get; set; }
        public decimal Amount { get; set; }
    }
}