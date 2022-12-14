using ACC.Domain.Models;

namespace ACC.Domain.Interfaces
{
    public interface IBusinessCategoriesRepository : IAccRepository<BusinessCategoriesModel>
    {
        int GetLastInsertedId();

        bool DescriptionExist(int id, string description);

        bool DescriptionExist(string description);
    }
}