using System.Data;
using ACC.Domain.Models;

namespace ACC.Domain.Interfaces
{
    public interface IReceiptsIssuedRepository : IRepository<ReceiptsIssuedModel>
    {
        bool UpdateReturnedReceipt(ReceiptsIssuedModel entity);
        bool UpdateCurrentIssued(ReceiptsIssuedModel entity);
        bool ReceiptAvailabilityByQuantity(int receiptId, int receiptQuantity);
        DataTable GetIssuedReceiptByCollectorIdAndAccountableFormId(string coid, string formid);
        DataTable GetIssuedReceiptByCollectorId(string collectorId);
        DataTable GetAccountabilityForAccountableForms(string reportNumber);
        DataTable GetReturnedReceipts();
        DataTable GetReturnedReceiptsBySearch(string searchKey);
        int GetReceiptIssuedQuantityByReceiptId(int receiptId);
        bool CollectingOfficerHasReceiptAssigned(int id);
    }
}
