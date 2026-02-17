using OmniGov.Core.Interfaces.Repositories;
using OmniGov.Core.Interfaces.Services;
using OmniGov.Core.Interfaces.Factories;
using Treasury.Domain.Entities;

namespace Treasury.Domain.Interfaces
{
    public interface ITaxpayerTypeRepository : IRepository<TaxpayerTypeModel>
    {
        bool NameExist(string name);

        bool NameExist(string name, int id);

        int GetLastInsertedId();

        int GetIdByName(string name);
    }
}
