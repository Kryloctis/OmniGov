using OmniGov.Core.Interfaces.Repositories;
using OmniGov.Core.Interfaces.Services;
using OmniGov.Core.Interfaces.Factories;
using System.Data;
using Treasury.Domain.Entities;

namespace Treasury.Domain.Interfaces
{
    public interface IBusinessCategoriesHasAddOnCharges : IRepository<BusinessCategoriesHasAddOnChargesModel>
    {
        bool Insert(int businessCategoriesId, List<BusinessCategoriesHasAddOnChargesModel> businessCategoriesHasAddOnChargesModels);

        bool Delete(int businessCategoriesId);

        DataTable GetViewRecordsByBusinessCategoriesId(int id);

        bool BusinessCategoriesHasAddOnCharges(int businessCategoriesId, int addOnChargesId);
    }
}
