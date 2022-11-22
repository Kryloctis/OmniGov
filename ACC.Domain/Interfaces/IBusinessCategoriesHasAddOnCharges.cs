using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

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
