using OmniGov.Core.Interfaces;
using Treasury.Domain.Entities;

namespace Treasury.Domain.Interfaces
{
    public interface IChequesRepository : IRepository<ChequesModel>
    {
        int GetLastInsertId();
    }
}