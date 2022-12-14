using ACC.Domain.Models;
using System.Collections.Generic;

namespace ACC.Domain.Interfaces
{
    public interface IGeneralPaymentsRepository : IAccRepository<GeneralPaymentsModel>
    {
        Dictionary<string, string> GetRecordsByPaymentCollectionsID(int paymentCollectionID);
    }
}