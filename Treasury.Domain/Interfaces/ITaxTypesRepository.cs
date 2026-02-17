using OmniGov.Core.Interfaces.Repositories;
using OmniGov.Core.Interfaces.Services;
using OmniGov.Core.Interfaces.Factories;
using System.Data;
using Treasury.Domain.Entities;

namespace Treasury.Domain.Interfaces
{
    public interface ITaxTypesRepository : IRepository<TaxTypesModel>
    {
        DataTable GetTaxTypeCodes();

        bool DeleteTaxType(int taxTypeID);

        bool UnDeleteTaxType(int taxTypeID);
    }
}
