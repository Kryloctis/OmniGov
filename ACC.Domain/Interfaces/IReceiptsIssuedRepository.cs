using System;
using System.Data;
using ACC.Domain.Models;

namespace ACC.Domain.Interfaces
{
    public interface IReceiptsIssuedRepository : IRepository<ReceiptsIssuedModel>
    {
        bool UpdateReturnedReceipt(ReceiptsIssuedModel entity);
        bool UpdateLastIssued(ReceiptsIssuedModel entity);
        bool ReceiptAvailabilityByQuantity(int receiptId, int receiptQuantity);
        DataTable GetIssuedReceiptToCollector(int collectingOfficerID, int accountableFormID);
        DataTable GetCollectorsAccountbleForms(int collectorId, bool collectorIsJO );
        DataTable GetAccountabilityForAccountableForms(string reportNumber);
        DataTable GetAccountabilityForAccountableForms(DateTime date);
        DataTable GetReturnedReceipts();
        DataTable GetReturnedReceiptsBySearch(string searchKey);
        int GetTotalIssuedReceiptByReceiptId(int receiptId);
        bool CollectingOfficerHasReceiptAssigned(int id);
        bool ReceiptIsUsed(int receiptId);
    }
}
