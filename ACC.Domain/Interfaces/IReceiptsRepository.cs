using ACC.Domain.Models;
using System;
using System.Data;

namespace ACC.Domain.Interfaces
{
    public interface IReceiptsRepository : IAccRepository<ReceiptsModel>
    {
        int GetMaxReceiptNumberByAccountableFormId(int accountableFormId);
        int GetMinReceiptNumberByAccountableFormId(int accountableFormId);
        bool ReceiptNumberInRange(int receiptId, int receiptNumber);
        DataTable GetRecordsByDateAndText(DateTime dateReceived, string txtSearch);
        bool ReceiptNumberExist(int accountableFormID, int receiptNumber);
        bool ReceiptNumberExist(int accountableFormID, int receiptNumber, int receiptID);
    }
}