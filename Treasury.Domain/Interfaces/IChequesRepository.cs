using OmniGov.Core.Interfaces.Repositories;
using Treasury.Domain.Entities;

namespace Treasury.Domain.Interfaces
{
    public interface IChequesRepository : IRepository<ChequesModel>
    {
        int GetLastInsertId();
    }
}