using OmniGov.Core.Interfaces.Repositories;
using OmniGov.Treasury.Domain.Entities;
using System.Data;

namespace OmniGov.Treasury.Domain.Interfaces
{
    public interface ITaxTypesRepository : IRepository<TaxTypesModel>
    {
        DataTable GetTaxTypeCodes();

        bool DeleteTaxType(int taxTypeID);

        bool UnDeleteTaxType(int taxTypeID);
    }
}
