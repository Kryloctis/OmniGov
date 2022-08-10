using System;
using System.Collections.Generic;
using System.Text;

namespace ACC.Domain.Models
{
    public class RptTaxDuesModel
    {
        public int Id { get; set; }
        public int RptAssessmentPostId { get; set; }
        public int RptPaymentPostsId { get; set; }
        public decimal DiscountRate { get; set; }
        public bool IsAdvance { get; set; }
    }
}
