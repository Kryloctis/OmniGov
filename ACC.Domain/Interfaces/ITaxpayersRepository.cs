using ACC.Domain.Models;
using System.Collections.Generic;
using System.Data;

namespace ACC.Domain.Interfaces
{
    public interface ITaxpayersRepository : IRepository<TaxpayersModel>
    {
        DataTable GetTaxpayerType();
        bool ITaxpayerNameExist(string name);
        bool ITaxpayerNameExist(int id, string name);
        int LastInsertedId();
    }
}
