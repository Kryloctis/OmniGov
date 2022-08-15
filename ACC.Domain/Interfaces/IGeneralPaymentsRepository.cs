using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ACC.Domain.Interfaces
{
    public interface IGeneralPaymentsRepository : IRepository<GeneralPaymentsModel>
    {
        Dictionary<string, string> GetRecordsByPaymentCollectionsID(int paymentCollectionID);
    }
}
