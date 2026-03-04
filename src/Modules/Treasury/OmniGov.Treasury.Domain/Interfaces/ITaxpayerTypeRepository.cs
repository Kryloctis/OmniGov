using OmniGov.Core.Interfaces.Repositories;
using OmniGov.Treasury.Domain.Entities;

namespace OmniGov.Treasury.Domain.Interfaces
{
    public interface ITaxpayerTypeRepository : IRepository<TaxpayerTypeModel>
    {
        bool NameExist(string name);

        bool NameExist(string name, int id);

        int GetLastInsertedId();

        int GetIdByName(string name);
    }
}
