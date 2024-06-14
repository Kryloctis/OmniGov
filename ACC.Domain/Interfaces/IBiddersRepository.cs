using ACC.Domain.Models;

namespace ACC.Domain.Interfaces
{
    public interface IBiddersRepository : IAccRepository<BiddersModel>
    {
        int GetLastInsertedId(int createdById);
    }

}
