using System;
using System.Collections.Generic;
using System.Text;

namespace ACC.Domain.Models
{
    public class BusinessAdOnChargesModel
    {
        public int BusinessAdOnChargesID  { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public bool AppliedEachBusiness { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
    }
}
