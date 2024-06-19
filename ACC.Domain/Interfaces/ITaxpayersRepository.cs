using ACC.Domain.Models;
using System.Collections.Generic;
using System.Data;

namespace ACC.Domain.Interfaces
{
    public interface ITaxpayersRepository : IAccRepository<TaxpayersModel>
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