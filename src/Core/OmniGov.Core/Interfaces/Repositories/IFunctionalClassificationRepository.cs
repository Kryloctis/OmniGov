using OmniGov.Core.Entities;

namespace OmniGov.Core.Interfaces.Repositories
{
    public interface IFunctionalClassificationRepository : IRepository<FunctionalClassificationModel>
    {
        bool CodeExist(string code);

        bool CodeExist(string code, int id);

        bool NameExist(string name);

        bool NameExist(string name, int id);
    }
}
