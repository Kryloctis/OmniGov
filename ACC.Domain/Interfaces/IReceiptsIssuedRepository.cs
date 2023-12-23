using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace ACC.Domain.Interfaces
{
    public interface IReceiptsIssuedRepository : IAccRepository<ReceiptsIssuedModel>
    {
        bool UpdateReturnedReceipt(ReceiptsIssuedModel entity);

        bool UpdateLastIssued(ReceiptsIssuedModel entity);

        bool ReceiptAvailabilityByQuantity(int receiptId, int receiptQuantity);

        DataTable GetViewRecordsByCollectorId_AccFormId(int collectingOfficerId, int accountableFormID);

        DataTable GetViewCollectorsAccountbleForms(int collectorId, bool collectorIsJO);

        DataTable GettAccFormByCOid(string reportNumber);

        DataTable GetAccountabilityForAccountableForms(DateTime date);

        DataTable GetReturnedReceipts();

        DataTable GetReturnedReceiptsBySearch(string searchKey);

        int GetTotalIssuedReceiptByReceiptId(int receiptId);

        bool CollectingOfficerHasReceiptAssigned(int id);

        bool ReceiptHasIssuance(int receiptId);

        DataTable GetRecordsBySearch(DateTime dateIssued, string searchText);

        bool ReceiptNumberInRange(int receiptId, int receiptNumber);

        bool ReceiptNumberInRange(int receiptId, int receiptNumber, int receiptIssuedId);

        Dictionary<string, string> GetViewRecordReceiptId(int receiptID);
    }
}