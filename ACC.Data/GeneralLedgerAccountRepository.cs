using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using ACC.Domain.Interfaces;
using ACC.Domain.Models;

namespace ACC.Data
{
    public class GeneralLedgerAccountRepository : IGeneralLedgerAccountRepository
    {
        private readonly IDbGenericCommands _dbGenericCommands;
        private readonly string tableName = "general_ledger_accounts";

        public GeneralLedgerAccountRepository(IDbGenericCommands dbGenericCommands)
        {
            _dbGenericCommands = dbGenericCommands;
        }        

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            throw new NotImplementedException();
        }

        public DataTable GetRecords()
        {
            throw new NotImplementedException();
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            throw new NotImplementedException();
        }

        public bool Insert(GeneralLedgerAccountModal entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(GeneralLedgerAccountModal entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(List<GeneralLedgerAccountModal> entityList)
        {
            throw new NotImplementedException();
        }

        public int CountRecords()
        {
            throw new NotImplementedException();
        }

        public bool IdExist(int id)
        {
            throw new NotImplementedException();
        }
    }
}
