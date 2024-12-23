using ACC.Domain.Models;
using System;
using System.Data;

namespace ACC.Domain.Interfaces
{
    public interface ICashTicketsRepository : IAccRepository<CashTicketsModel>
    {
        DataTable GetRecordsByDateAndText(DateTime dateReceived, string txtSearch, int rowLimit);
    }
}
