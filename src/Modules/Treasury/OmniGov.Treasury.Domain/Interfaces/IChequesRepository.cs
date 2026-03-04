using OmniGov.Core.Interfaces.Repositories;
using OmniGov.Treasury.Domain.Entities;

namespace OmniGov.Treasury.Domain.Interfaces
{
    public interface IChequesRepository : IRepository<ChequesModel>
    {
        int GetLastInsertId();
    }
}
