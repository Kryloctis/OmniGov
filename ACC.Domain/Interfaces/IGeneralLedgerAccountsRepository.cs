using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using ACC.Domain.Models;

namespace ACC.Domain.Interfaces
{
    public interface IGeneralLedgerAccountsRepository : IRepository<GeneralLedgerAccountsModal>
    {
        DataTable GetViewRecords();

        DataTable GetViewRecordsBySearch(string searchText);

        //Budget System
        DataTable GetViewRecordsByMajAccGroupName(string majAccGroupName);

        DataTable GetAllViewRecords();


        bool NameExist(string txtName);

        bool NameExist(int id, string txtName);
    }
}
