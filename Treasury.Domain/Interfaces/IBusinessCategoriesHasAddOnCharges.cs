using OmniGov.Core.Interfaces;
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