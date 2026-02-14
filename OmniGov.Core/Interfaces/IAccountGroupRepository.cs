using OmniGov.Core.Entities;

namespace OmniGov.Core.Interfaces
{
    public interface IAccountGroupRepository : IRepository<AccountGroupModel>
    {
        bool CodeExist(string code);

        bool CodeExist(string code, int id);

        bool NameExist(string name);

        bool NameExist(string name, int id);
    }
}