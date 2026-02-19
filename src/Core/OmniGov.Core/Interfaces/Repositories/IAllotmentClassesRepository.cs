using OmniGov.Core.Entities;
using System.Data;

namespace OmniGov.Core.Interfaces.Repositories
{
    public interface IAllotmentClassesRepository : IRepository<AllotmentClassesModel>
    {
        DataTable GetRecordsBySearch(int rowLimit, string searchKey);

        bool NameExist(string name);

        bool NameExist(string name, int id);

        bool CodeExist(string code);

        bool CodeExist(string code, int id);
    }
}
