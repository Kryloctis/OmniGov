using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using ACC.Domain.Models;

namespace ACC.Domain.Interfaces
{
    public interface IJEVAccountsRepository : IRepository<JEVAccountsModel>
    {
        DataTable GetRecordsByJevId(uint jevId);
        bool DeleteByJevId(uint jevId);
    }
}
