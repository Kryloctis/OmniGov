using ACC.Domain.Models;
using System.Data;

namespace ACC.Domain.Interfaces
{
    public interface IBankDepositsRepository : IAccRepository<BankDepositsModel>
    {
        int Deposits(BankDepositsModel entity);

        DataTable GetRecordsByBankAndAccountID(int bankID, int bankAccountID);

        DataTable GetBankDepositsSummary();
    }
}