using ACC.Domain.Models;

namespace ACC.Domain.Interfaces
{
    public interface ITaxpayerTypeRepository : IAccRepository<TaxpayerTypeModel>
    {
        bool NameExist(string name);

        bool NameExist(string name, int id);

        int GetLastInsertedId();

        int GetIdByName(string name);
    }
}