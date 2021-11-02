using System;
using System.Collections.Generic;
using System.Text;

namespace ACC.Domain.Models
{
    public class AmortizationScheduleModel
    {
        public int Id { get; set; }
        public int AmortizationId { get; set; }
        public DateTime Date { get; set; }
        public decimal PrincipalAmount { get; set; }
        public decimal InterestAmount { get; set; }
        public decimal GRTAmount { get; set; }
    }
}
