using ACC.Domain.Models;
using System.Collections.Generic;

namespace ACC.Domain.Interfaces
{
    public interface IRptDiscountsRepository : IAccRepository<RptDiscountsModel>
    {
        bool DescriptionExist(string description);

        bool DescriptionExist(int id, string description);

        Dictionary<string, string> GetRecordByMonth(int month, bool isAdvance);
    }
}