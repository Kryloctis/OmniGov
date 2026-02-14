using OmniGov.Core.Interfaces;
using Treasury.Domain.Entities;

namespace Treasury.Domain.Interfaces
{
    public interface IBusinessCategoriesRepository : IRepository<BusinessCategoriesModel>
    {
        int GetLastInsertedId();

        bool DescriptionExist(int id, string description);

        bool DescriptionExist(string description);
    }
}