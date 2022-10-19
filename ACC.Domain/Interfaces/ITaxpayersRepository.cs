using ACC.Domain.Models;
using System.Data;

namespace ACC.Domain.Interfaces
{
    public interface ITaxpayersRepository : IRepository<TaxpayersModel>
    {
        bool ITaxpayerNameExist(string name);
        bool ITaxpayerNameExist(int id, string name);
        int LastInsertedId();
        DataTable GetViewTaxpayerRecords();
        DataTable GetViewTaxpayerRecordsBySearch(string searchText);
    }
}
