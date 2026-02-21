using OmniGov.Core.Interfaces.Repositories;
using OmniGov.Treasury.Domain.Entities;
using System.Data;

namespace OmniGov.Treasury.Domain.Interfaces
{
    public interface IOtherPaymentRatesRepository : IRepository<OtherPaymentRatesModel>
    {
        DataTable GetRecordsByTaxTypeID(int taxTypeID);

        DataTable GetRecordsByTaxTypeIDAndDescription(int taxTypeID, string description);
    }
}
