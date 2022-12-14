using ACC.Domain.Models;
using System.Collections.Generic;
using System.Data;

namespace ACC.Domain.Interfaces
{
    public interface IBusinessCategoriesHasAddOnCharges : IAccRepository<BusinessCategoriesHasAddOnChargesModel>
    {
        bool Insert(int businessCategoriesId, List<BusinessCategoriesHasAddOnChargesModel> businessCategoriesHasAddOnChargesModels);

        bool Delete(int businessCategoriesId);

        DataTable GetViewRecordsByBusinessCategoriesId(int id);

        bool BusinessCategoriesHasAddOnCharges(int businessCategoriesId, int addOnChargesId);
    }
}