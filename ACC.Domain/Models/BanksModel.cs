using System;
using System.Collections.Generic;
using System.Text;

namespace ACC.Domain.Models
{
    public class BanksModel
    {
        public int Id { get; set; }
        public string AccountNo { get; set; }
        public string BankName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
