using ACC.Domain.Models;

namespace ACC.Domain.Interfaces
{
    public interface ITaxpayers : IRepository<TaxpayersModel>
    {
        bool ITaxpayerNameExist(string name);
        bool ITaxpayerNameExist(int id, string name);
        int LastInsertedId();
    }
}
