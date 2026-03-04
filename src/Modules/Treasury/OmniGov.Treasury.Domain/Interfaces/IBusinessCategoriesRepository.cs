using OmniGov.Core.Interfaces.Repositories;
using OmniGov.Treasury.Domain.Entities;

namespace OmniGov.Treasury.Domain.Interfaces
{
    public interface IBusinessCategoriesRepository : IRepository<BusinessCategoriesModel>
    {
        int GetLastInsertedId();

        bool DescriptionExist(int id, string description);

        bool DescriptionExist(string description);
    }
}
