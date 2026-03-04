using OmniGov.Core.Interfaces.Repositories;
using OmniGov.Treasury.Domain.Entities;
using System.Data;

namespace OmniGov.Treasury.Domain.Interfaces
{
    public interface ICashTicketsIssuedRepository : IRepository<CashTicketsIssuedModel>
    {
        DataTable GetViewRecordsBySearch(DateTime dateIssued, string searchKey, int rowLimit);

        int GetIssuedCountByCashTcktId(int cashTicketId);
    }
}
