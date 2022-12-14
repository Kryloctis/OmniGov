using ACC.Domain.Models;
using System.Collections.Generic;
using System.Data;

namespace ACC.Domain.Interfaces
{
    public interface ITaxpayersRepository : IAccRepository<TaxpayersModel>
    {
        bool TaxpayerNameExist(string name);

        bool TaxpayerNameExist(int id, string name);

        int GetLastInsertedId();

        int GetIdByName(string name);

        DataTable GetViewRecords();

        DataTable GetViewRecordsBySearch(string searchText, bool showInactiveTaxpayers);

        DataTable GetViewRecordsBySearch(string searchText);

        Dictionary<string, string> GetViewRecordById(int id);
    }
}