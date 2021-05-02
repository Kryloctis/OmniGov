using System;
using System.Collections.Generic;
using System.Text;

namespace ACC.Domain.Models
{
    public class ObligationRequestModel
    {
        public int ID { get; set; }
        public int FundID { get; set; }   
        public int FPPId { get; set; }
        public int? OtherFPPId { get; set; }
        public int AllotmentClassesID { get; set; }
        public int GenLedgerAccID { get; set; }
        public DateTime DateRequested { get; set; }
        public string ObligationNo { get; set; }
        public string Payee { get; set; }
        public string Explanation { get; set; }
        public string ReferencesNo { get; set; }
        public decimal ObligationAmount { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
    }
}
