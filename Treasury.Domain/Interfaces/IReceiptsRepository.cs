using OmniGov.Core.Interfaces.Repositories;
using OmniGov.Core.Interfaces.Services;
using OmniGov.Core.Interfaces.Factories;
using System.Data;
using Treasury.Domain.Entities;

namespace Treasury.Domain.Interfaces
{
    public interface IReceiptsRepository : IRepository<ReceiptsModel>
    {
        DataTable GetViewRecords();

        int GetMaxReceiptNumberByAccountableFormId(int accountableFormId);

        int GetMinReceiptNumberByAccountableFormId(int accountableFormId);

        bool ReceiptNumberInRange(int receiptId, int receiptNumber);

        DataTable GetRecordsByDateAndText(DateTime dateReceived, string txtSearch, int rowLimit);

        bool ReceiptNumberExist(int accountableFormID, int receiptNumber);

        bool ReceiptNumberExist(int accountableFormID, int receiptNumber, int receiptID);
    }
}
