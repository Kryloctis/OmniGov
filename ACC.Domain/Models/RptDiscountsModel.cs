using System;
using System.Collections.Generic;
using System.Text;

namespace ACC.Domain.Models
{
    public class RptDiscountsModel
    {
        public int Id { get; set; }

        public int Month { get; set; }

        public string Description { get; set; }
        
        public decimal Rate { get; set; }

        public bool IsAdvance { get; set; }
    }
}
