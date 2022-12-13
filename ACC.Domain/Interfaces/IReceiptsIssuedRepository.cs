using System;
using System.Data;
using ACC.Domain.Models;

namespace ACC.Domain.Interfaces
{
    public interface IReceiptsIssuedRepository : IAccRepository<ReceiptsIssuedModel>
    {
        bool UpdateReturnedReceipt(ReceiptsIssuedModel entity);
        bool UpdateLastIssued(ReceiptsIssuedModel entity);
        bool ReceiptAvailabilityByQuantity(int receiptId, int receiptQuantity);
        DataTable GetViewIssuedReceiptToCollector(int collectingOfficerID, int accountableFormID);
        DataTable GetViewCollectorsAccountbleForms(int collectorId, bool collectorIsJO );
        DataTable GetAccountabilityForAccountableForms(string reportNumber);
        DataTable GetAccountabilityForAccountableForms(DateTime date);
        DataTable GetReturnedReceipts();
        DataTable GetReturnedReceiptsBySearch(string searchKey);
        int GetTotalIssuedReceiptByReceiptId(int receiptId);
        bool CollectingOfficerHasReceiptAssigned(int id);
        bool ReceiptIsUsed(int receiptId);
        DataTable GetRecordsBySearch(string dateIssued, string searchText);

    }
}
