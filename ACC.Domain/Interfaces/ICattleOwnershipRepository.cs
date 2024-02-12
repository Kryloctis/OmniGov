using ACC.Domain.Models;
using System.Data;

namespace ACC.Domain.Interfaces
{
    public interface ICattleOwnershipRepository : IAccRepository<CattleOwnershipModel>
    {
        DataTable GetRecordsByIDAndSearch(int oldOwnerID, string keySearch);

        DataTable GetRecordByTaxpayerId(int taxpayerId);

        int GetLastInsertedId(int createdBy);
    }
}