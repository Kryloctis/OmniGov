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

        Dictionary<string, string> GetViewRecordByID(ushort generalLedgerId);

        DataTable GetViewRecordsBySearch(string searchText);

        DataTable GetRecordsBySearch();

        DataTable GetAllViewRecords();

        DataTable GetAllViewRecordsBySearch(string searchText);



        DataTable GetViewRecordsByMajorAccGroupName(string majAccGroupName);

        DataTable GetViewRecordsByMajorAccGroupNameSearch(string majAccGroupName, string searchText);



        DataTable GetViewRecordsByAccountGroupName(string accountGroupName);
        DataTable GetViewRecordsByAccountGroupNameSearch(string accountGroupName, string searchText);


        bool NameExist(string txtName);

        bool NameExist(int id, string txtName);
    }
}
