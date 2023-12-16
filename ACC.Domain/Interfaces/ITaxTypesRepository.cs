using ACC.Domain.Models;
using System.Data;

namespace ACC.Domain.Interfaces
{
    public interface ITaxTypesRepository : IAccRepository<TaxTypesModel>
    {
        DataTable GetTaxTypeCodes();

        bool DeleteTaxType(int taxTypeID);

        bool UnDeleteTaxType(int taxTypeID);
    }
}