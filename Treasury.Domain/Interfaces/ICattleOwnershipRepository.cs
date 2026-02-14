using OmniGov.Core.Interfaces;
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