using ACC.Domain.Models;
using System.Collections.Generic;
using System.Data;

namespace ACC.Domain.Interfaces
{
    public interface IBankAccountsRepository : IAccRepository<BankAccountsModel>
    {
        DataTable GetViewRecordsBySearch(string searchKey);

        DataTable GetViewRecords();

        bool bankAccountExist(string accountNo, string bankName);

        bool InsertWithBank(BankAccountsModel bankAccountsModel, BanksModel banksModel);

        int GetLastInsertedId();

        Dictionary<string, string> GetViewRecordByAccountNoBankName(string accountNo, string bankName);
    }
}