using System;
using System.Collections.Generic;
using System.Text;
using ACC.Domain.Models;

namespace ACC.Domain.Interfaces
{
    public interface IJEVRepository : IRepository<JEVModel>
    {
        bool Insert(JEVModel entity, List<JEVAccountsModel> jevAccountsModelList);

        int GetLastInsertedID();
    }
}
