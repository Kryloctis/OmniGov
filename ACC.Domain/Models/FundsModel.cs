using System;
using System.Collections.Generic;
using System.Text;

namespace ACC.Domain.Models
{
    public class FundsModel
    {
        public int Id { get; set; }
        public string FundCode { get; set; }
        public string FundName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
