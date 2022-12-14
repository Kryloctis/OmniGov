using ACC.Domain.Models;

namespace ACC.Domain.Interfaces
{
    public interface IFunctionalClassificationRepository : IAccRepository<FunctionalClassificationModel>
    {
        bool CodeExist(string code);

        bool CodeExist(string code, int id);

        bool NameExist(string name);

        bool NameExist(string name, int id);
    }
}