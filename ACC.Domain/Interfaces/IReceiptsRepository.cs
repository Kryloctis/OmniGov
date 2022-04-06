using System.Data;
using ACC.Domain.Models;

namespace ACC.Domain.Interfaces
{
    public interface IReceiptsRepository : IRepository<ReceiptsModel>
    {
        bool ReceiptsIssued(int id);
        int GetMaxReceiptNumberByAccountableFormId(int accountableFormId);
        int GetMinReceiptNumberByAccountableFormId(int accountableFormId);
        DataTable GetReceipts();
        int GetReceiptNumberFromByReceiptId(int receiptId);
        bool IsReceiptBetweenFromAndTo(int receiptId, int receiptNumberFrom, int receiptNumberTo);

    }
}
