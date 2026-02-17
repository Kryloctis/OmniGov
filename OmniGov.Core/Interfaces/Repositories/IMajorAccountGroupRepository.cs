using OmniGov.Core.Entities;
using System.Data;

namespace OmniGov.Core.Interfaces.Repositories
{
    public interface IMajorAccountGroupRepository : IRepository<MajorAccountGroupModel>
    {
        DataTable GetViewRecords();

        DataTable GetViewRecordsByAccountGroupId(byte id);

        bool CodeExist(string code);

        bool CodeExist(string code, int id);

        bool NameExist(string name);

        bool NameExist(string name, int id);
    }
}
