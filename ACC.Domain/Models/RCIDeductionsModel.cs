using System;
using System.Collections.Generic;
using System.Text;

namespace ACC.Domain.Models
{
    public class RCIDeductionsModel
    {
        public int Id { get; set; }
        public int Rcid { get; set; }
        public String Description { get; set; }
        public Decimal Amount { get; set; }
    }
}
