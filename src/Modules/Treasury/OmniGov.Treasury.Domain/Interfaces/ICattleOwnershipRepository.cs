using OmniGov.Core.Interfaces.Repositories;
using OmniGov.Treasury.Domain.Entities;
using System.Data;

namespace OmniGov.Treasury.Domain.Interfaces
{
    public interface ICattleOwnershipRepository : IRepository<CattleOwnershipModel>
    {
        DataTable GetRecordsByIDAndSearch(int oldOwnerID, string keySearch);

        DataTable GetRecordByTaxpayerId(int taxpayerId);

        int GetLastInsertedId(int createdBy);
    }
}
