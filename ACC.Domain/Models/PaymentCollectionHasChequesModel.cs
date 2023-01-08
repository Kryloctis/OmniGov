using System;
using System.Collections.Generic;
using System.Text;

namespace ACC.Domain.Models
{
    public class PaymentCollectionHasChequesModel
    {
        public int PaymentCollectionId { get; set; }
        public int ChequesId { get; set; }
    }
}
