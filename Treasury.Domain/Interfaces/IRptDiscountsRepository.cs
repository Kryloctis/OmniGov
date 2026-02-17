using OmniGov.Core.Interfaces.Repositories;
using OmniGov.Core.Interfaces.Services;
using OmniGov.Core.Interfaces.Factories;
using Treasury.Domain.Entities;

namespace Treasury.Domain.Interfaces
{
    public interface IRptDiscountsRepository : IRepository<RptDiscountsModel>
    {
        bool DescriptionExist(string description);

        bool DescriptionExist(int id, string description);

        Dictionary<string, string> GetRecordByMonth(int month, bool isAdvance);
    }
}
