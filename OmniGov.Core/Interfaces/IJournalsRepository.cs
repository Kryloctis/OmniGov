using OmniGov.Core.Entities;

namespace OmniGov.Core.Interfaces
{
    public interface IJournalsRepository : IRepository<JournalsModel>
    {
        bool NameExist(string name);

        bool NameExist(string name, int id);
    }
}