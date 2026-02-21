using OmniGov.Core.Interfaces.Services;
using OmniGov.Treasury.Domain.Entities;
using OmniGov.Treasury.Domain.Interfaces;
using System.Data;
using System.Transactions;

namespace OmniGov.Treasury.Data.Repositories
{
    public class TaxpayerRepository : ITaxpayersRepository
    {
        private readonly IGenericCommands _genericCommands;
        private readonly string tableName = "taxpayers";
        private readonly string viewTableName = "view_taxpayers";

        public TaxpayerRepository(IGenericCommands genericCommands)
        {
            _genericCommands = genericCommands ?? throw new ArgumentNullException(nameof(genericCommands));
        }

        public bool Delete(List<TaxpayersModel> entityList)
        {
            using (var scope = new TransactionScope())
            {
                foreach (TaxpayersModel taxpayersModel in entityList)
                {
                    var parameters = new object[][] { new object[] { "@id", DbType.Int32, taxpayersModel.Id } };
                    string query = $"DELETE FROM {tableName} WHERE id = @id";
                    _ = _genericCommands.ExecuteNonQuery(query, parameters);
                }

                scope.Complete();
                return true;
            }
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

        public DataTable GetRecords()
        {
            string query = $"SELECT * FROM {tableName}";
            var dataTable = new DataTable();
            return _genericCommands.Fill(query, dataTable);
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            var parameters = new object[][]
            {
                new object[] {"@search_text", DbType.String, $"%{searchText}%" }
            };

            string query = $"SELECT * FROM {tableName} WHERE tin LIKE @search_text OR name LIKE @search_text";
            var dataTable = new DataTable();
            return _genericCommands.FillBySearch(query, dataTable, parameters);
        }

        public bool IdExist(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(TaxpayersModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@representative_registry_id", DbType.Object, entity.RepresentativeRegistryId},
                new object[] { "@taxpayer_type_id", DbType.Int32, entity.TaxpayerTypeId },
                new object[] { "@tin", DbType.String, entity.Tin },
                new object[] { "@name", DbType.String, entity.Name },
                new object[] { "@address", DbType.String, entity.Address },
                new object[] { "@municipality", DbType.String, entity.Municipality},
                new object[] { "@province", DbType.String, entity.Province},
                new object[] { "@contact_info", DbType.String, entity.ContactInfo },
                new object[] { "@is_active", DbType.Boolean, entity.IsActive },
                new object[] { "@created_by", DbType.Int32, entity.CreatedBy}
            };

            string query = $"INSERT INTO {tableName} (representative_registry_id, tin, name, taxpayer_type_id, contact_info, address, municipality, province, is_active, created_by) VALUES (@representative_registry_id, @tin, @name, @taxpayer_type_id, @contact_info, @address, @municipality, @province, @is_active, @created_by)";
            return _genericCommands.ExecuteNonQuery(query, parameters);
        }

        public bool Update(TaxpayersModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, entity.Id},
                new object[] { "@representative_registry_id", DbType.Object, entity.RepresentativeRegistryId},
                new object[] { "@taxpayer_type_id", DbType.Int32, entity.TaxpayerTypeId },
                new object[] { "@tin", DbType.String, entity.Tin },
                new object[] { "@name", DbType.String, entity.Name },
                new object[] { "@address", DbType.String, entity.Address },
                new object[] { "@municipality", DbType.String, entity.Municipality},
                new object[] { "@province", DbType.String, entity.Province},
                new object[] { "@contact_info", DbType.String, entity.ContactInfo },
                new object[] { "@is_active", DbType.Boolean, entity.IsActive },
                new object[] { "@updated_by", DbType.Int32, entity.UpdatedBy }
            };

            string query = $"UPDATE {tableName} SET  taxpayer_type_id = @taxpayer_type_id, representative_registry_id = @representative_registry_id, tin = @tin, name = @name, address = @address, municipality = @municipality, province = @province, contact_info = @contact_info, is_active = @is_active, updated_by = @updated_by WHERE id = @id";

            return _genericCommands.ExecuteNonQuery(query, parameters);
        }

        public bool TaxpayerNameExist(string name)
        {
            var parameters = new object[][]
            {
                new object[] { "@name", DbType.String, name}
            };

            string query = $"SELECT id FROM {tableName} WHERE name = @name";
            string result = _genericCommands.ExecuteScalar(query, parameters);

            if (!string.IsNullOrWhiteSpace(result))
                return true;
            return false;
        }

        public bool TaxpayerNameExist(int id, string name)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, id},
                new object[] { "@name", DbType.String, name}
            };

            string query = $"SELECT id FROM {tableName} WHERE id <> @id AND name = @name";
            string result = _genericCommands.ExecuteScalar(query, parameters);

            if (!string.IsNullOrWhiteSpace(result))
                return true;
            return false;
        }

        public int GetLastInsertedId(int? createdBy)
        {
            var parameters = new object[][]
            {
                new object[]{ "@created_by", DbType.Int32, createdBy }
            };

            string query = $"SELECT MAX(id) FROM {tableName} WHERE created_by = @created_by";
            return int.Parse(_genericCommands.ExecuteScalar(query, parameters));
        }

        public DataTable GetViewRecords()
        {
            var query = $"SELECT * FROM {viewTableName}";
            var dataTable = new DataTable();
            return _genericCommands.Fill(query, dataTable);
        }

        public DataTable GetViewRecordsBySearch(string searchText)
        {
            var parameters = new object[][] { new object[] { "@search_text", DbType.String, $"%{searchText}%" } };
            string query = $"SELECT * FROM {viewTableName} WHERE taxpayers_tin LIKE @search_text OR taxpayers_name LIKE @search_text";
            var dataTable = new DataTable();
            return _genericCommands.FillBySearch(query, dataTable, parameters);
        }

        public int GetIdByName(string name)
        {
            var parameters = new object[][] { new object[] { "@name", DbType.String, name } };
            string query = $"SELECT id FROM {tableName} WHERE name = @name";
            return Convert.ToInt32(_genericCommands.ExecuteScalar(query, parameters));
        }

        public Dictionary<string, string> GetViewRecordById(int id)
        {
            var recordDictionary = new Dictionary<string, string>();
            var parameters = new object[][]
            {
                new object[] { "@taxpayers_id", DbType.Int32, id}
            };

            string query = $"SELECT * FROM {viewTableName} WHERE taxpayers_id = @taxpayers_id";

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

        public DataTable GetViewRecordsByParameters(string searchText, bool showInactiveTaxpayers, int rowFilter)
        {
            var parameters = new object[][]
            {
                new object[] { "@search_text", DbType.String, $"%{searchText}%" },
                new object[] { "@row_filter", DbType.Int32, rowFilter}
            };

            string subQuery = showInactiveTaxpayers ? string.Empty : "is_active = 1 AND";

            string query = $"SELECT * FROM {viewTableName} WHERE {subQuery} (taxpayers_tin LIKE @search_text OR taxpayers_name LIKE @search_text OR representative_name LIKE @search_text) ORDER BY taxpayers_name ASC LIMIT @row_filter";
            var dataTable = new DataTable();
            return _genericCommands.FillBySearch(query, dataTable, parameters);
        }
    }
}
