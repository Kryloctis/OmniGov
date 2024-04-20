using ACC.Domain.Models;

namespace ACC.Domain.Interfaces
{
    public interface IRcd : IAccRepository<RcdModel>
    {
        bool reportNoExist(string reportNo);

        bool reportNoExist(string reportNo, int id);
    }
}