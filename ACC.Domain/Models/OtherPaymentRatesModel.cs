using System;
using System.Collections.Generic;
using System.Text;

namespace ACC.Domain.Models
{
    public class OtherPaymentRatesModel
    {
        public int Id { get; set; }
        public int TaxTypeID { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public int StartingYear { get; set; }
        public bool IsRateEditable { get; set; }
        public int CreatedBy { get; set; }
    }
}
