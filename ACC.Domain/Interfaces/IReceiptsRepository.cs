using System;
using System.Data;
using ACC.Domain.Models;

namespace ACC.Domain.Interfaces
{
    public interface IReceiptsRepository : IRepository<ReceiptsModel>
    {
        int GetMaxReceiptNumberByAccountableFormId(int accountableFormId);
        int GetMinReceiptNumberByAccountableFormId(int accountableFormId);
        int GetReceiptNumberFromByReceiptId(int receiptId);
        bool IsReceiptBetweenFromAndTo(int receiptId, int receiptNumberFrom, int receiptNumberTo);

        DataTable GetRecordsByDateAndText(string dateReceived, string txtSearch);
       
    }
}
