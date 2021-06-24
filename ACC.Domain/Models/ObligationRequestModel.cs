using System;
using System.Collections.Generic;
using System.Text;

namespace ACC.Domain.Models
{
    public class ObligationRequestModel
    {
        public int Id { get; set; }
        public string ObligationNo { get; set; }
        public string Payee { get; set; }
        public string Explanation { get; set; }
        public string ReferenceNo { get; set; }
        public DateTime DateRequested { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
    }
}
