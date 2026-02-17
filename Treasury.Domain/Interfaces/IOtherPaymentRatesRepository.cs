using OmniGov.Core.Interfaces.Repositories;
using OmniGov.Core.Interfaces.Services;
using OmniGov.Core.Interfaces.Factories;
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
