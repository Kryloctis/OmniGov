using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ACC.Domain.Interfaces
{
    public interface IFundsRepository : IRepository<FundsModel>
    {
        bool NameExist(string name);
        bool NameExist(string name, int id);
    }
}
