using ACC.Data;
using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace AccountingSystem
{
    internal class TaxpayerTypeRepository : ITaxpayerTypeRepository
    {
        private MySqlGenericCommands _mySqlGenericCommandsLFS;
        private readonly string tableName = "taxpayer_type";

        public TaxpayerTypeRepository(MySqlGenericCommands mySqlGenericCommandsLFS)
        {
            _mySqlGenericCommandsLFS = mySqlGenericCommandsLFS;
        }

        public bool IdExist(int id)
        {
            throw new System.NotImplementedException();
        }

        public DataTable GetRecords()
        {
            string query = $"SELECT * FROM {tableName}";
            var dataTable = new DataTable();
            return _mySqlGenericCommandsLFS.Fill(query, dataTable);
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            throw new System.NotImplementedException();
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            throw new System.NotImplementedException();
        }

        public int CountRecords()
        {
            throw new System.NotImplementedException();
        }

        public bool Insert(TaxpayerTypeModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@code", DbType.String, entity.Code},
                new object[] { "@taxpayer_type", DbType.String, entity.taxpayerType}
            };

            string query = $"INSERT INTO {tableName} (id, code, taxpayer_type) VALUES (@id, @code, @taxpayer_type)";
            return _mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
        }

        public bool Update(TaxpayerTypeModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, entity.Id},
                new object[] { "@code", DbType.String, entity.Code},
                new object[] { "@taxpayer_type", DbType.String, entity.taxpayerType}
            };

            string query = $"UPDATE {tableName} SET code = @code, taxpayer_type = @taxpayer_type WHERE id = @id";
            return _mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
        }

        public bool Delete(List<TaxpayerTypeModel> entityList)
        {
            throw new System.NotImplementedException();
        }

        public bool NameExist(string name)
        {
            var parameters = new object[][] { new object[] { "@taxpayer_type", DbType.String, name } };
            string query = $"SELECT id FROM {tableName} WHERE taxpayer_type = @taxpayer_type";
            string result = _mySqlGenericCommandsLFS.ExecuteScalar(query, parameters);
            if (!string.IsNullOrEmpty(result))
                return true;
            return false;
        }

        public bool NameExist(string name, int id)
        {
            var parameters = new object[][] { new object[] { "@taxpayer_type", DbType.String, name } };
            string query = $"SELECT id FROM {tableName} WHERE taxpayer_type = @taxpayer_type";
            string result = _mySqlGenericCommandsLFS.ExecuteScalar(query, parameters);
            if (!string.IsNullOrEmpty(result))
                return true;
            return false;
        }

        public int GetIdByName(string name)
        {
            var parameters = new object[][] { new object[] { "@taxpayer_type", DbType.String, name } };
            string query = $"SELECT id FROM {tableName} WHERE taxpayer_type = @taxpayer_type";
            return Convert.ToInt32(_mySqlGenericCommandsLFS.ExecuteScalar(query, parameters));
        }
    }
}