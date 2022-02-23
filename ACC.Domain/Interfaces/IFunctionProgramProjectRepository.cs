using ACC.Domain.Models;
using System.Data;

namespace ACC.Domain.Interfaces
{
    public interface IFunctionProgramProjectRepository : IRepository<FunctionProgramProjectModel>
    {
        DataTable GetViewRecordsByServiceNameId(byte id);
        DataTable GetViewRecords();
        DataTable GetRecordsByCodeName(string searchTxt);
        bool CodeExist(string code);
        bool CodeExist(string code, int id);
        bool NameExist(string name);
        bool NameExist(string name, int id);
    }
}
