using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ACC.Domain.Interfaces
{
    public interface IOtherPaymentRatesRepository : IAccRepository<OtherPaymentRatesModel>
    {
        Dictionary<string, string> GetRecordsByTaxTypeID(int taxTypeID);
    }
}
