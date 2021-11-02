using System;
using System.Collections.Generic;
using System.Text;

namespace ACC.Domain.Models
{
    public class AmortizationModel
    {
        public int Id { get; set; }
        public string BankName { get; set; }
        public string AmortizationTerm { get; set; }
        public int Interest { get; set; }
        public decimal AmountReleased { get; set; }
    }
}
