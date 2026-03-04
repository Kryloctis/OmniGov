using OmniGov.Core.Interfaces.Repositories;
using OmniGov.Treasury.Domain.Entities;
using System.Data;

namespace OmniGov.Treasury.Domain.Interfaces
{
    public interface ITaxpayersRepository : IRepository<TaxpayersModel>
    {
        bool TaxpayerNameExist(string name);

        bool TaxpayerNameExist(int id, string name);

        int GetLastInsertedId(int? createdBy);

        int GetIdByName(string name);

        DataTable GetViewRecords();

        DataTable GetViewRecordsByParameters(string searchText, bool showInactiveTaxpayers, int rowFilter);

        DataTable GetViewRecordsBySearch(string searchText);

        Dictionary<string, string> GetViewRecordById(int id);
    }
}
