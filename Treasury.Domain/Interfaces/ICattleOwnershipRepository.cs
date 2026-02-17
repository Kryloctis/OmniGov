using OmniGov.Core.Interfaces.Repositories;
using OmniGov.Core.Interfaces.Services;
using OmniGov.Core.Interfaces.Factories;
using System.Data;
using Treasury.Domain.Entities;

namespace Treasury.Domain.Interfaces
{
    public interface ICattleOwnershipRepository : IRepository<CattleOwnershipModel>
    {
        DataTable GetRecordsByIDAndSearch(int oldOwnerID, string keySearch);

        DataTable GetRecordByTaxpayerId(int taxpayerId);

        int GetLastInsertedId(int createdBy);
    }
}
