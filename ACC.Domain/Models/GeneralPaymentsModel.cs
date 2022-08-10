using System;
using System.Collections.Generic;
using System.Text;

namespace ACC.Domain.Models
{
    public class GeneralPaymentsModel
    {
        public int Id { get; set; }

        public int PaymentCollectionId { get; set; }

        public int GeneralLedgerAccountsId { get; set; }

        public int SubsidiaryLedgerAccountsId { get; set; }

        public int Quantity { get; set; }

    }
}
