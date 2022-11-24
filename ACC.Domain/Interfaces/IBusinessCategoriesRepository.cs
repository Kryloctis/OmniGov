using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ACC.Domain.Interfaces
{
    public interface IBusinessCategoriesRepository: IAccRepository<BusinessCategoriesModel>
    {
        int GetLastInsertedId();
        bool DescriptionExist(int id, string description);  
        bool DescriptionExist(string description);
    }
}
