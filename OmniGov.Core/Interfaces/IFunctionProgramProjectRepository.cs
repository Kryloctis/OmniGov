using OmniGov.Core.Entities;
using System.Data;

namespace OmniGov.Core.Interfaces
{
    public interface IFunctionProgramProjectRepository : IRepository<FunctionProgramProjectModel>
    {
        DataTable GetViewRecords();

        DataTable GetViewRecordsByService_And_Search_And_IsSpecial(int serviceId, string searchText, bool isSpecial);

        DataTable GetViewRecordsBySearch_And_IsSpecial(string searchText, bool isSpecial);

        DataTable GetRecordsByCodeName(string searchTxt);

        bool CodeExist(string code);

        bool CodeExist(string code, int id);

        bool NameExist(string name, int serviceId);

        bool NameExist(string name, int serviceId, int id);
    }
}