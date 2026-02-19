using OmniGov.Core.Entities;
using System.Data;

namespace OmniGov.Core.Interfaces.Repositories
{
    public interface IFundsRepository : IRepository<FundsModel>
    {
        bool CodeExist(string code);

        bool CodeExist(string code, int id);

        bool NameExist(string name);

        bool NameExist(string name, int id);

        DataTable GetRecordsPrintCashposition(DateTime date);

        DataTable GetRecords(string searchText, int rowLimit);
    }
}
