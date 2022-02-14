using System.Data;
using ACC.Domain.Models;

namespace ACC.Domain.Interfaces
{
    public interface IReceiptsRepository : IRepository<ReceiptsModel>
    {
        bool ReceiptConsumed(int id);
        bool ReceiptsIssued(int id);
        int GetMaxReceiptNumberByAccountableFormId(int accountableFormId);
        int GetMinReceiptNumberByAccountableFormId(int accountableFormId);
        bool AllowEdit(int id);
        DataTable GetReceipts();
        int GetReceiptNumberFromByReceiptId(int receiptId);
        bool IsReceiptBetweenFromAndTo(int receiptId, int receiptNumberFrom, int receiptNumberTo);

    }
}
