using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace ACC.Domain.Interfaces
{
    public interface IBankDepositsRepository : IAccRepository<BankDepositsModel>
    {
        DataTable GetRecordsByBankAndAccountID(int bankID, int bankAccountID);

        DataTable GetViewRcdRecord(DateTime date, UsersModel createdBy);

        DataTable GetViewRcdRecord(RcdDepositsModel rcdDepositsModel);

        DataTable GetViewRecordBySearch(string searchKey, DateTime date, int filterRow);

        Dictionary<string, string> GetViewRecordById(int id);
    }
}