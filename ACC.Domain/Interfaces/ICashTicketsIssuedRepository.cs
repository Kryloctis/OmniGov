using ACC.Domain.Models;
using System;
using System.Data;

namespace ACC.Domain.Interfaces
{
    public interface ICashTicketsIssuedRepository : IAccRepository<CashTicketsIssuedModel>
    {
        DataTable GetRecordsByDateAndText(DateTime dateIssued, string searchKey, int rowLimit);
        int GetTotalIssuedCashTicketById(int cashTicketId);
    }
}
