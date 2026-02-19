using OmniGov.Core.Entities;

namespace OmniGov.Core.Interfaces.Repositories
{
    public interface IJournalsRepository : IRepository<JournalsModel>
    {
        bool NameExist(string name);

        bool NameExist(string name, int id);
    }
}
