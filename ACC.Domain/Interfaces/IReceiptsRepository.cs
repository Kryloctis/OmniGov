using System.Data;
using ACC.Domain.Models;

namespace ACC.Domain.Interfaces
{
    public interface IReceiptsRepository : IRepository<ReceiptsModel>
    {
        bool ReceiptConsumed(int id);
        bool ReceiptsIssued(int id);
        int RMAX(int accid);
        int RMIN(int accid);
        bool AllowEdit(int id);
        DataTable GetReceipts();
    }
}
