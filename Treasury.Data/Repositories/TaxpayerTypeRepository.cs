using OmniGov.Core.Repositories;
using OmniGov.Core.Services;
using System.Data;
using Treasury.Domain.Entities;
using Treasury.Domain.Interfaces;

namespace Treasury.Data.Repositories
{
    internal class TaxpayerTypeRepository : ITaxpayerTypeRepository
    {
        private GenericCommands _mySqlGenericCommands;
        private readonly string tableName = "taxpayer_type";

        public TaxpayerTypeRepository(GenericCommands mySqlGenericCommands)
        {
            _mySqlGenericCommands = mySqlGenericCommands;
        }

        public bool IdExist(int id)
        {
            throw new NotImplementedException();
        }

        public DataTable GetRecords()
        {
            string query = $"SELECT * FROM {tableName}";
            var dataTable = new DataTable();
            return _mySqlGenericCommands.Fill(query, dataTable);
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            throw new NotImplementedException();
        }

        public int CountRecords()
        {
            throw new NotImplementedException();
        }

        public bool Insert(TaxpayerTypeModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@code", DbType.String, entity.Code},
                new object[] { "@taxpayer_type", DbType.String, entity.taxpayerType}
            };

            string query = $"INSERT INTO {tableName} (code, taxpayer_type) VALUES (@code, @taxpayer_type)";
            return _mySqlGenericCommands.ExecuteNonQuery(query, parameters);
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
            return _mySqlGenericCommands.ExecuteNonQuery(query, parameters);
        }

        public bool Delete(List<TaxpayerTypeModel> entityList)
        {
            throw new NotImplementedException();
        }

        public bool NameExist(string name)
        {
            var parameters = new object[][] { new object[] { "@taxpayer_type", DbType.String, name } };
            string query = $"SELECT id FROM {tableName} WHERE taxpayer_type = @taxpayer_type";
            string result = _mySqlGenericCommands.ExecuteScalar(query, parameters);
            if (!string.IsNullOrEmpty(result))
                return true;
            return false;
        }

        public bool NameExist(string name, int id)
        {
            var parameters = new object[][] { new object[] { "@taxpayer_type", DbType.String, name } };
            string query = $"SELECT id FROM {tableName} WHERE taxpayer_type = @taxpayer_type";
            string result = _mySqlGenericCommands.ExecuteScalar(query, parameters);
            if (!string.IsNullOrEmpty(result))
                return true;
            return false;
        }

        public int GetIdByName(string name)
        {
            var parameters = new object[][] { new object[] { "@taxpayer_type", DbType.String, name } };
            string query = $"SELECT id FROM {tableName} WHERE taxpayer_type = @taxpayer_type";
            return Convert.ToInt32(_mySqlGenericCommands.ExecuteScalar(query, parameters));
        }

        public int GetLastInsertedId()
        {
            string query = $"SELECT MAX(id) FROM {tableName}";
            return Convert.ToInt32(_mySqlGenericCommands.ExecuteScalar(query));
        }
    }
}

