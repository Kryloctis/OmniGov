using OmniGov.Core.Interfaces.Services;
using OmniGov.Treasury.Domain.Entities;
using OmniGov.Treasury.Domain.Interfaces;
using System.Data;
using System.Transactions;

namespace OmniGov.Treasury.Data.Repositories
{
    internal class CattleOwnershipRepository : ICattleOwnershipRepository
    {
        private readonly string tableName = "cattle_ownership";
        private readonly IGenericCommands _genericCommands;

        public CattleOwnershipRepository(IGenericCommands genericCommands)
        {
            _genericCommands = genericCommands ?? throw new ArgumentNullException(nameof(genericCommands));
        }

        public bool Delete(List<CattleOwnershipModel> entityList)
        {
            using (var scope = new TransactionScope())
            {
                foreach (var cattleOwnershipModel in entityList)
                {
                    var parameters = new object[][] { new object[] { "@id", DbType.Int32, cattleOwnershipModel.Id } };
                    string query = $"DELETE FROM {tableName} WHERE id = @id";
                    _ = _genericCommands.ExecuteNonQuery(query, parameters);
                }

                scope.Complete();
                return true;
            }
        }

        public int GetLastInsertedId(int createdBy)
        {
            var parameters = new object[][]
            {
                new object[] {"@created_by", DbType.Int32, createdBy}
            };

            string query = $"SELECT COALESCE(MAX(id)) FROM {tableName} WHERE created_by = @created_by";
            return Convert.ToInt32(_genericCommands.ExecuteScalar(query, parameters));
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            var recordDictionary = new Dictionary<string, string>();

            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, Id}
            };

            string query = $"SELECT * FROM {tableName} WHERE id = @id";
            DataTable dataTable = _genericCommands.ExecuteReader(query, parameters);

            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];

                foreach (DataColumn column in dataTable.Columns)
                    recordDictionary[column.ColumnName] = row[column].ToString();

                return recordDictionary;
            }
            return recordDictionary;
        }

        public DataTable GetRecordByTaxpayerId(int taxpayerId)
        {
            var parameters = new object[][]
            {
                new object[] { "@taxpayers_id", DbType.Int32, taxpayerId}
            };

            string query = $"SELECT * FROM {tableName} WHERE taxpayers_id = @taxpayers_id";
            var dataTable = new DataTable();
            return _genericCommands.FillBySearch(query, dataTable, parameters);
        }

        public DataTable GetRecords()
        {
            string query = $"SELECT * FROM {tableName}";
            var dataTable = new DataTable();
            return _genericCommands.Fill(query, dataTable);
        }

        public DataTable GetRecordsByIDAndSearch(int oldOwnerID, string searchKey)
        {
            var parameter = new object[][]
            {
                new object[] { "@owner_id", DbType.Int32, oldOwnerID},
                new object[] { "@searchKey", DbType.String, $"%{searchKey}%" },
            };

            string query = $"SELECT * FROM {tableName} WHERE owner_id = @owner_id AND description LIKE @searchKey AND cattle_type LIKE @searchKey";

            var dataTable = new DataTable();
            return _genericCommands.FillBySearch(query, dataTable, parameter);
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            throw new NotImplementedException();
        }

        public bool IdExist(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(CattleOwnershipModel entity)
        {
            var parameters = new object[][]
            {
                new object[] {"@payment_collections_id" ,DbType.Int32, entity.PaymentCollectionId},
                new object[] {"@taxpayers_id" ,DbType.Int32, entity.TaxpayerId},
                new object[] {"@cattle_name" ,DbType.String, entity.CattleName},
                new object[] {"@cattle_sex" ,DbType.String, entity.CattleSex},
                new object[] {"@cattle_age" ,DbType.Int32, entity.CattleAge},
                new object[] {"@cattle_years", DbType.Int32, entity.CattleYears},
                new object[] {"@description" ,DbType.String, entity.Description},
                new object[] {"@created_by" ,DbType.Int32, entity.CreatedBy},
            };

            string query = $"INSERT INTO {tableName} (payment_collections_id, taxpayers_id, cattle_name, cattle_sex, cattle_age, cattle_years, description, created_by) VALUES (@payment_collections_id, @taxpayers_id, @cattle_name, @cattle_sex, @cattle_age, @cattle_years, @description, @created_by)";

            return _genericCommands.ExecuteNonQuery(query, parameters);
        }

        public bool Update(CattleOwnershipModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, entity.Id },
                new object[] { "@payment_collections_id" ,DbType.Int32, entity.PaymentCollectionId },
                new object[] { "@taxpayers_id" ,DbType.Int32, entity.TaxpayerId },
                new object[] { "@cattle_name" ,DbType.String, entity.CattleName },
                new object[] { "@cattle_sex" ,DbType.String, entity.CattleSex },
                new object[] { "@cattle_age" ,DbType.Int32, entity.CattleAge },
                new object[] { "@cattle_years", DbType.Int32, entity.CattleYears },
                new object[] { "@description" ,DbType.String, entity.Description },
                new object[] { "@updated_by" ,DbType.String, entity.UpdatedBy },
            };

            string query = $"UPDATE {tableName} SET payment_collections_id = @payment_collections_id, taxpayers_id = @taxpayers_id, cattle_name = @cattle_name, cattle_sex = @cattle_sex, cattle_age = @cattle_age, cattle_years = @cattle_years, description = @description, updated_by = @updated_by WHERE id = @id;";
            return _genericCommands.ExecuteNonQuery(query, parameters);
        }
    }
}
