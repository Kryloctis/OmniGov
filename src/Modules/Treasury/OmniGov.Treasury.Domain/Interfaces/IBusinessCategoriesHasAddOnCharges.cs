using OmniGov.Core.Interfaces.Repositories;
using OmniGov.Treasury.Domain.Entities;
using System.Data;

namespace OmniGov.Treasury.Domain.Interfaces
{
    public interface IBusinessCategoriesHasAddOnCharges : IRepository<BusinessCategoriesHasAddOnChargesModel>
    {
        bool Insert(int businessCategoriesId, List<BusinessCategoriesHasAddOnChargesModel> businessCategoriesHasAddOnChargesModels);

        bool Delete(int businessCategoriesId);

        DataTable GetViewRecordsByBusinessCategoriesId(int id);

        bool BusinessCategoriesHasAddOnCharges(int businessCategoriesId, int addOnChargesId);
    }
}
