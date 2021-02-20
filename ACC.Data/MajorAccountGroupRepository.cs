using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using ACC.Domain.Interfaces;
using ACC.Domain.Models;

namespace ACC.Data
{
    public class MajorAccountGroupRepository : IMajorAccountGroupRepository
    {
        private readonly IDbGenericCommands _dbGenericCommands;
        private readonly string tableName = "major_account_group";

        public MajorAccountGroupRepository(IDbGenericCommands dbGenericCommands)
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

        public bool Insert(MajorAccountGroupModel entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(MajorAccountGroupModel entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(List<MajorAccountGroupModel> entityList)
        {
            throw new NotImplementedException();
        }

        public bool IdExist(int id)
        {
            throw new NotImplementedException();
        }

        public int CountRecords()
        {
            throw new NotImplementedException();
        }
    }
}
