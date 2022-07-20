using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ACC.Domain.Interfaces
{
    public interface IRptDiscountsRepository : IRepository<RptDiscountsModel>
    {
        bool CodeExist(string code);

        bool CodeExist(int id, string code);

        bool DescriptionExist(string description);

        bool DescriptionExist(int id, string description);
    }
}
