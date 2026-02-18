using OmniGov.Core.Interfaces.Repositories;
using System.Data;
using Treasury.Domain.Entities;

namespace Treasury.Domain.Interfaces
{
    public interface IAccountableFormsRepository : IRepository<AccountableFormsModel>
    {
        bool CodeExist(string code);

        bool CodeExist(string code, int id);

        Dictionary<string, string> GetRecordByAccFormNo(string accFormNo);

        DataTable GetRecordsByAccFormNo(string accFormNo);

        DataTable GetCashTicketsAccountableForm();
    }
}