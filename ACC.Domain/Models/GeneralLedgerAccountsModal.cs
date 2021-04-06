using System;
using System.Collections.Generic;
using System.Text;

namespace ACC.Domain.Models
{
    public class GeneralLedgerAccountsModal
    {
        public int Id { get; set; }
        public short SubMajorAccountGroupId { get; set; }
        public string LedgerCode { get; set; }
        public string LedgerName { get; set; }
        public bool IsContraAccount { get; set; }
    }
}
