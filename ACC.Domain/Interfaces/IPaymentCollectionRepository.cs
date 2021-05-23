using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using ACC.Domain.Models;

namespace ACC.Domain.Interfaces
{
    public interface IPaymentCollectionRepository : IRepository<PaymentCollectionModel>
    {
        DataTable GetRecordByLedger(string month);
        DataTable GetRecordByExcel(string month);
        DataTable GetRecordsBySearch(string searchText);
    }
}
