using ACC.Domain.Models;
using System;
using System.Data;

namespace ACC.Domain.Interfaces
{
    public interface IReceiptsRepository : IAccRepository<ReceiptsModel>
    {
        int GetMaxReceiptNumberByAccountableFormId(int accountableFormId);

        int GetMinReceiptNumberByAccountableFormId(int accountableFormId);

        int GetReceiptNumberFromByReceiptId(int receiptId);

        bool ReceiptInRange(int receiptId, int receiptNumberFrom, int receiptNumberTo);

        DataTable GetRecordsByDateAndText(DateTime dateReceived, string txtSearch);
    }
}