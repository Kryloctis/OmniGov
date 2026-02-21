using OmniGov.Core.Interfaces.Repositories;
using OmniGov.Treasury.Domain.Entities;

namespace OmniGov.Treasury.Domain.Interfaces
{
    public interface IRptDiscountsRepository : IRepository<RptDiscountsModel>
    {
        bool DescriptionExist(string description);

        bool DescriptionExist(int id, string description);

        Dictionary<string, string> GetRecordByMonth(int month, bool isAdvance);
    }
}
