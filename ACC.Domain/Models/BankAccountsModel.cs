using System;
using System.Collections.Generic;
using System.Text;

namespace ACC.Domain.Models
{
    public class BankAccountsModel
    {
        public int ID { get; set; }
        public int BankID { get; set; }
        public string AccountNumber { get; set; }
    }
}
