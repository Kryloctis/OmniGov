using System;
using System.Collections.Generic;
using System.Text;

namespace ACC.Domain.Models
{
    public class SubsidiaryLedgerAccountsModel
    {
        public int Id { get; set; }
        public byte FundId { get; set; }
        public ushort GeneralLedgerAccountsId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
