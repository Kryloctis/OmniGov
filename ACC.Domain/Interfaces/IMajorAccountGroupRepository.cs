using ACC.Domain.Models;
using System.Data;

namespace ACC.Domain.Interfaces
{
    public interface IMajorAccountGroupRepository : IAccRepository<MajorAccountGroupModel>
    {
        DataTable GetViewRecords();

        DataTable GetViewRecordsByAccountGroupId(byte id);

        bool CodeExist(string code);

        bool CodeExist(string code, int id);

        bool NameExist(string name);

        bool NameExist(string name, int id);
    }
}