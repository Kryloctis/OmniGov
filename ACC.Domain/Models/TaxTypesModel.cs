using System;
using System.Collections.Generic;
using System.Text;

namespace ACC.Domain.Models
{
    public class TaxTypesModel
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int ?ParentID { get; set; }
        public int FundID { get; set; }
        public string COAAccountCode { get; set; }
        public string BLGFAccountCode { get; set; }
        public bool IsDeleted { get; set; }

    }
}
