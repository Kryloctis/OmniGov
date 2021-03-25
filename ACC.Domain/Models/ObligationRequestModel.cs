using System;
using System.Collections.Generic;
using System.Text;

namespace ACC.Domain.Models
{
    public class ObligationRequestModel
    {
        public int ID { get; set; }
        public int AllotmentReleaseID { get; set; }
        public string ObligationNo { get; set; }
        public decimal ObligationAmount { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
    }
}
