using OmniGov.Core.Interfaces;
using System.Data;
using Treasury.Domain.Entities;

namespace Treasury.Domain.Interfaces
{
    public interface ICashTicketsRepository : IRepository<CashTicketsModel>
    {
        DataTable GetRecordsBySearch(DateTime dateReceived, string txtSearch, int rowLimit);
    }
}