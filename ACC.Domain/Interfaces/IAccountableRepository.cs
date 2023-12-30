using ACC.Domain.Models;
using System.Collections.Generic;
using System.Data;

namespace ACC.Domain.Interfaces
{
    public interface IAccountableRepository : IAccRepository<AccountableFormsModel>
    {
        bool CodeExist(string code);

        bool CodeExist(string code, int id);

        Dictionary<string, string> GetRecordByAccFormNo(string accFormNo);

        DataTable GetRecordsByAccFormNo(string accFormNo);
    }
}