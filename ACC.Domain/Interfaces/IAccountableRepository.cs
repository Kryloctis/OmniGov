using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using ACC.Domain.Models;

namespace ACC.Domain.Interfaces
{
    public interface IAccountableRepository : IRepository<AccountableModel>
    {
        bool CodeExist(string code);
        bool CodeExist(string code, int id);
        Dictionary<string, string> GetRecordByAccFormNo(string accFormNo);
    }
}
