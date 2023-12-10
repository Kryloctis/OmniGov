using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System.Collections.Generic;
using System.Data;

namespace ACC.Data
{
    internal class CattleOwnershipRepository : ICattleOwnershipRepository
    {
        private readonly IAccGenericCommands _dbGenericCommands;
        private readonly string tableName = "cattle_ownership";

        public CattleOwnershipRepository(IAccGenericCommands dbGenericCommands)
        {
            _dbGenericCommands = dbGenericCommands;
        }

        public int CountRecords()
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(List<CattleOwnershipModel> entityList)
        {
            throw new System.NotImplementedException();
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            throw new System.NotImplementedException();
        }

        public DataTable GetRecords()
        {
            throw new System.NotImplementedException();
        }

        public DataTable GetRecordsByIDAndSearch(int oldOwnerID, string searchKey)
        {
            var parameter = new object[][]
            {
                new object[] { "@owner_id", DbType.Int32, oldOwnerID},
                new object[] { "@searchKey", DbType.String, $"%{searchKey}%" },
            };

            string query = $"SELECT id, cattle_type, cattle_sex, cattle_age, description FROM {tableName} WHERE owner_id = @owner_id AND description LIKE @searchKey AND cattle_type LIKE @searchKey";

            var dataTable = new DataTable();
            return _dbGenericCommands.FillBySearch(query, dataTable, parameter);
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            throw new System.NotImplementedException();
        }

        public bool IdExist(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool Insert(CattleOwnershipModel entity)
        {
            throw new System.NotImplementedException();
        }

        public bool InsertWithCattleOwnershipPayment(CattleOwnershipModel entity)
        {
            var parameters = new object[][]
            {
                new object[] {"@payment_collections_id", DbType.Int32, entity.PaymentCollections.Id},
                new object[] {"@owner_registry_id", DbType.Int32, entity.Id},
                new object[] {"@cattle_name", DbType.String, entity.CattleName},
                new object[] {"@cattle_sex", DbType.String, entity.CattleSex},
                new object[] {"@cattle_age", DbType.Int32, entity.CattleAge},
                new object[] {"@description", DbType.String, entity.Description},
            };

            string query = $"INSERT INTO {tableName} (owner_id, tag, owner_name, owner_barangay, owner_municipality, owner_province, cattle_type, cattle_sex, cattle_age, description, created_at, created_by) VALUES(@owner_id, @tag, @owner_name, @owner_barangay, @owner_municipality, @owner_province, @cattle_type, @cattle_sex, @cattle_age, @description, @created_at, @created_by)";

            bool result = _dbGenericCommands.ExecuteNonQuery(query, parameters);
            return result;
        }

        public bool Update(CattleOwnershipModel entity)
        {
            throw new System.NotImplementedException();
        }
    }
}