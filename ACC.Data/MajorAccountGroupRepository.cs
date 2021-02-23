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
        private readonly string viewTableName = "view_major_account_group";

        public MajorAccountGroupRepository(IDbGenericCommands dbGenericCommands)
        {
            _dbGenericCommands = dbGenericCommands;
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

        public DataTable GetViewRecords()
        {
            try
            {
                string query = $"SELECT maj_acc_group_id, maj_acc_group_code, maj_acc_group_name, account_group_name, created_at, updated_at FROM {viewTableName}";

                var dtJournals = new DataTable();
                return _dbGenericCommands.Fill(query, dtJournals);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            throw new NotImplementedException();
        }

        public DataTable GetRecordsByAccountGroupId(byte id)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@id", DbType.Byte, id},
                };

                string query = $"SELECT * FROM {tableName} WHERE account_group_id =  @id";

                return _dbGenericCommands.ExecuteReader(query, parameters);
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
            try
            {
                string query = $"SELECT COUNT(*) FROM {tableName}";

                return int.Parse(_dbGenericCommands.ExecuteScalar(query));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
