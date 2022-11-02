using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace ACC.Data
{
    public class SubMajorAccountGroupRepository : ISubMajorAccountGroupRepository
    {
        private readonly IAccGenericCommands _dbGenericCommands;
        private readonly string tableName = "sub_major_account_group";
        private readonly string viewTableName = "view_sub_major_account_group";

        public SubMajorAccountGroupRepository(IAccGenericCommands dbGenericCommands)
        {
            _dbGenericCommands = dbGenericCommands;
        }

        public int CountRecords()
        {
            throw new NotImplementedException();
        }

        public bool Delete(List<SubMajorAccountGroupModel> entityList)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            throw new NotImplementedException();
        }

        public DataTable GetRecords()
        {
            throw new NotImplementedException();
        }


        public DataTable GetRecordsByMajorAccountId(short majorAccountId)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@id", DbType.Byte, majorAccountId},
                };

                string query = $"SELECT * FROM {tableName} WHERE major_account_group_id =  @id";

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

        public DataTable GetViewRecordsByMajorAccountId(short majorAccountId)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Byte, majorAccountId},
            };

            string query = $"SELECT sub_maj_acc_group_id, sub_maj_acc_group_code, sub_maj_acc_group_name, maj_acc_group_name, created_at, updated_at FROM {viewTableName} WHERE major_account_group_id =  @id";

            return _dbGenericCommands.ExecuteReader(query, parameters);
        }

        public bool IdExist(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(SubMajorAccountGroupModel entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(SubMajorAccountGroupModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
