using ACC.Domain.Models;
using System.Data;

namespace ACC.Domain.Interfaces
{
    public interface IOtherPaymentRatesRepository : IAccRepository<OtherPaymentRatesModel>
    {
        DataTable GetRecordsByTaxTypeID(int taxTypeID);

        DataTable GetRecordsByTaxTypeIDAndDescription(int taxTypeID, string description);

        DataTable GetViewRecords_Description(string description);
    }
}