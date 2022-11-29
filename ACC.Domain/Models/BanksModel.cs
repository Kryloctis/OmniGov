using System;
using System.Collections.Generic;
using System.Text;

namespace ACC.Domain.Models
{
    public class BanksModel
    {
        public int Id { get; set; }
        public string BankCode { get; set; }
        public string BankName { get; set; }
        public string BankBranch { get; set; }
    }
}
