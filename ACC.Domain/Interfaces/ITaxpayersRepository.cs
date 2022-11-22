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
        DataTable GetViewTaxpayerRecords();
        DataTable GetViewTaxpayerRecordsBySearch(string searchText);
        Dictionary<string, string> GetViewRecordById(int id);
    }
}
