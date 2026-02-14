using OmniGov.Core.Entities;

namespace OmniGov.Core.Interfaces
{
    public interface IClassificationCodes : IRepository<ClassificationCodesModel>
    {
        bool NameExist(string name);

        bool NameExist(string name, int id);

        int GetLastInsertedId();

        int GetIdByName(string name);
    }
}