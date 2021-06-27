using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using ACC.Domain.Models;

namespace ACC.Domain.Interfaces
{
    public interface IBankDepositsRepository : IRepository<BankDepositsModel>
    {
        int Deposits(BankDepositsModel entity);
        DataTable GetRecordsBySearch(int id);
    }
}
