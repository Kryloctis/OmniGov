using OmniGov.Core.Interfaces;
using System.Data;
using Treasury.Domain.Entities;

namespace Treasury.Domain.Interfaces
{
    public interface IOtherPaymentRatesRepository : IRepository<OtherPaymentRatesModel>
    {
        DataTable GetRecordsByTaxTypeID(int taxTypeID);

        DataTable GetRecordsByTaxTypeIDAndDescription(int taxTypeID, string description);
    }
}