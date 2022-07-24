using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPT.Domain.Models
{
    public class AssessmentPostsModel
    {
        public int Id { get; set; }
        public string ArpNo  { get; set; }
        public decimal TaxRate { get; set; }
        public decimal DiscountRate { get; set; }
        public decimal PenaltyRate { get; set; }
        public DateTime PostedAt { get; set; }
    }
}
