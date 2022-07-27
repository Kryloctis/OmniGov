using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ACC.Domain.Interfaces
{
    public interface IRptTaxRatesRepository : IRepository<RptTaxRatesModel>
    {
        decimal GetTaxRateByCode(string taxRateCode);
    }
}
