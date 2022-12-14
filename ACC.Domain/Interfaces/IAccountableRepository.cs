using ACC.Domain.Models;
using System.Collections.Generic;

namespace ACC.Domain.Interfaces
{
    public interface IAccountableRepository : IAccRepository<AccountableModel>
    {
        bool CodeExist(string code);

        bool CodeExist(string code, int id);

        Dictionary<string, string> GetRecordByAccFormNo(string accFormNo);
    }
}