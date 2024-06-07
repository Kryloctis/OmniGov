using ACC.Domain.Models;
using System;
using System.Data;

namespace ACC.Domain.Interfaces
{
    public interface IFundsRepository : IAccRepository<FundsModel>
    {
        bool CodeExist(string code);

        bool CodeExist(string code, int id);

        bool NameExist(string name);

        bool NameExist(string name, int id);

        DataTable GetRecordsPrintCashposition(DateTime date);

        DataTable GetRecords(string searchText, int rowLimit);
    }
}