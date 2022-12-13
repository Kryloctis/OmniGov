using ACC.Domain.Models;

namespace ACC.Domain.Interfaces
{
    public interface IJournalsRepository : IAccRepository<JournalsModel>
    {
        bool NameExist(string name);

        bool NameExist(string name, int id);
    }
}