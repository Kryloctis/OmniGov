using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ACC.Domain.Interfaces
{
    public interface IMarriageLicenseRepository:IAccRepository<MarriageLicenseModel>
    {
        bool InsertWithMarriageLicensePayment(PaymentCollectionHasChequesModel paymentCollectionHasChequesModel, PaymentCollectionsModel paymentCollectionsModel, MarriageLicenseModel marriageLicenseModel);
    }
}
