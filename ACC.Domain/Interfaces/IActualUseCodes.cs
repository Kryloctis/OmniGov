using ACC.Domain.Models;

namespace ACC.Domain.Interfaces
{
    public interface IActualUseCodes : IRepository<ActualUseCodesModel>
    {
        bool NameExist(string name);
        bool NameExist(string name, int id);
    }
}
