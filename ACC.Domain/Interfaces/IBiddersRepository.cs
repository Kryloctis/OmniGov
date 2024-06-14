using ACC.Domain.Models;
using System.Data;

namespace ACC.Domain.Interfaces
{
    public interface IBiddersRepository : IAccRepository<BiddersModel>
    {
        int GetLastInsertedId(int createdById);
        DataTable GetViewRecords();
    }

}
