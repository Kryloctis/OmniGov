using ACC.Domain.Models;
using System;
using System.Data;

namespace ACC.Domain.Interfaces
{
    public interface IBankDepositsRepository : IAccRepository<BankDepositsModel>
    {
        int Deposits(BankDepositsModel entity);

        DataTable GetRecordsByBankAndAccountID(int bankID, int bankAccountID);

        DataTable GetViewRcdRecord(DateTime date, UsersModel createdBy);

        DataTable GetViewRcdRecord(RcdDepositsModel rcdDepositsModel);
    }
}