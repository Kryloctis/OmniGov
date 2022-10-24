using ACC.Domain.Models;

namespace ACC.Domain.Interfaces
{
    public interface IClassificationCodes : IRepository<ClassificationCodesModel>
    {
        bool NameExist(string name);
        bool NameExist(string name, int id);
    }
}
