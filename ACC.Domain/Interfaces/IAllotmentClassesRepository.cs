using ACC.Domain.Models;
using System.Data;

namespace ACC.Domain.Interfaces
{
    public interface IAllotmentClassesRepository : IAccRepository<AllotmentClassesModel>
    {
        DataTable GetRecordsBySearch(int rowLimit, string searchKey);

        bool NameExist(string name);

        bool NameExist(string name, int id);

        bool CodeExist(string code);

        bool CodeExist(string code, int id);
    }
}