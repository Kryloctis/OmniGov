using OmniGov.Core.Interfaces.Repositories;
using OmniGov.Treasury.Domain.Entities;
using System.Data;

namespace OmniGov.Treasury.Domain.Interfaces
{
    public interface ICashTicketsRepository : IRepository<CashTicketsModel>
    {
        DataTable GetRecordsBySearch(DateTime dateReceived, string txtSearch, int rowLimit);
    }
}
