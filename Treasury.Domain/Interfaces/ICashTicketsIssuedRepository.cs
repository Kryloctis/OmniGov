using OmniGov.Core.Interfaces.Repositories;
using OmniGov.Core.Interfaces.Services;
using OmniGov.Core.Interfaces.Factories;
using System.Data;
using Treasury.Domain.Entities;

namespace Treasury.Domain.Interfaces
{
    public interface ICashTicketsIssuedRepository : IRepository<CashTicketsIssuedModel>
    {
        DataTable GetViewRecordsBySearch(DateTime dateIssued, string searchKey, int rowLimit);

        int GetIssuedCountByCashTcktId(int cashTicketId);
    }
}
