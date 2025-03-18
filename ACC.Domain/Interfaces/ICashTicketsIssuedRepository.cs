using ACC.Domain.Models;
using System;
using System.Data;

namespace ACC.Domain.Interfaces
{
    public interface ICashTicketsIssuedRepository : IAccRepository<CashTicketsIssuedModel>
    {
        DataTable GetViewRecordsBySearch(DateTime dateIssued, string searchKey, int rowLimit);
        int GetIssuedCountByCashTcktId(int cashTicketId);
    }
}
