using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ACC.Domain.Interfaces
{
    public interface IBusinessCategoriesHasAddOnCharges : IAccRepository<BusinessCategoriesHasAddOnChargesModel>
    {
        bool Insert(List<BusinessCategoriesHasAddOnChargesModel> businessCategoriesHasAddOnChargesModels);
        bool Delete(int businesCategoriesId, List<int> businessAddOnChargesIds);
        DataTable GetViewRecordsById(int id);

    }
}
