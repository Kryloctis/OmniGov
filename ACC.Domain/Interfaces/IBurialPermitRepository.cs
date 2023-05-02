using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ACC.Domain.Interfaces
{
    public interface IBurialPermitRepository : IAccRepository<BurialPermitModel>
    {
        bool InsertWithPayment(PaymentCollectionHasChequesModel paymentCollectionHasChequesModel, PaymentCollectionsModel paymentCollectionsModel, BurialPermitModel burialPermitModel);
    }
}
