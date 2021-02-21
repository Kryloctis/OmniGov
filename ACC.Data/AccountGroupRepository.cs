using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using ACC.Domain.Interfaces;
using ACC.Domain.Models;

namespace ACC.Data
{
    public class AccountGroupRepository : IAccountGroupRepository
    {
        private readonly IDbGenericCommands _dbGenericCommands;
        private readonly string tableName = "account_group";

        public AccountGroupRepository(IDbGenericCommands dbGenericCommands)
        {
            _dbGenericCommands = dbGenericCommands;
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            throw new NotImplementedException();
        }

        public DataTable GetRecords()
        {
            try
            {
                string query = $"SELECT * FROM {tableName}";

                var dtJournals = new DataTable();
                return _dbGenericCommands.Fill(query, dtJournals);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            throw new NotImplementedException();
        }

        public bool Insert(AccountGroupModel entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(AccountGroupModel entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(List<AccountGroupModel> entityList)
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

        public bool CodeExist(string name)
        {
            throw new NotImplementedException();
        }

        public bool CodeExist(string name, int id)
        {
            throw new NotImplementedException();
        }

        public bool NameExist(string name)
        {
            throw new NotImplementedException();
        }

        public bool NameExist(string name, int id)
        {
            throw new NotImplementedException();
        }
    }
}
