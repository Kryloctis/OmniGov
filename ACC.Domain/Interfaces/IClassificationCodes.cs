using ACC.Domain.Models;

namespace ACC.Domain.Interfaces
{
    public interface IClassificationCodes : IAccRepository<ClassificationCodesModel>
    {
        bool NameExist(string name);

        bool NameExist(string name, int id);

        int GetLastInsertedId();

        int GetIdByName(string name);
    }
}