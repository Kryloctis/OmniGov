using ACC.Domain.Models;
using System;
using System.Data;

namespace ACC.Domain.Interfaces
{
    public interface ICashTicketsRepository : IAccRepository<CashTicketsModel>
    {
        DataTable GetRecordsBySearch(DateTime dateReceived, string txtSearch, int rowLimit);
    }
}
