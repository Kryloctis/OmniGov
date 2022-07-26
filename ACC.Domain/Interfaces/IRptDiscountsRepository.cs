using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ACC.Domain.Interfaces
{
    public interface IRptDiscountsRepository : IRepository<RptDiscountsModel>
    {
        bool DescriptionExist(string description);

        bool DescriptionExist(int id, string description);

        decimal GetDiscountRateByMonth(sbyte month);
    }
}
