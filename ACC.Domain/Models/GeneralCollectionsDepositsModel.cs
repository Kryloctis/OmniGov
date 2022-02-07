using System;
using System.Collections.Generic;
using System.Text;

namespace ACC.Domain.Models
{
    public class GeneralCollectionsDepositsModel
    {
        public int Id { get; set; }
        public int GeneralCollectionId { get; set; }
        public int BankDepositId { get; set; }
    }
}
