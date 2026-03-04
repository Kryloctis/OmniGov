using OmniGov.Core.Interfaces.Services;
using OmniGov.Treasury.Domain.Entities;
using OmniGov.Treasury.Domain.Interfaces;
using System.Data;
using System.Transactions;

namespace OmniGov.Treasury.Data.Repositories
{
    internal class BusinessAddOnChargesRepository : IBusinessAdOnChargesRepository
    {
        private readonly IGenericCommands _genericCommands;
        private readonly string tableName = "business_add_on_charges";

        public BusinessAddOnChargesRepository(IGenericCommands genericCommands)
        {
            _genericCommands = genericCommands ?? throw new ArgumentNullException(nameof(genericCommands));
        }

        public bool Delete(List<BusinessAddOnChargesModel> entityList)
        {
            using (var scope = new TransactionScope())
            {
                foreach (var entity in entityList)
                {
                    var parameters = new object[][] { new object[] { @"id", DbType.Int32, entity.BusinessAddOnChargesID } };

                    string query = $"DELETE FROM {tableName} WHERE id = @id";
                    _ = _genericCommands.ExecuteNonQuery(query, parameters);
                }

                scope.Complete();
                return true;
            }
        }

        public bool DescriptionExist(string description)
        {
            var parameters = new object[][]
            {
                new object[] { "@description", DbType.String, description },
            };

            string query = $"SELECT id FROM {tableName} WHERE description = @description";
            string queryResult = _genericCommands.ExecuteScalar(query, parameters);

            if (!string.IsNullOrEmpty(queryResult))
                return true;

            return false;
        }

        public bool DescriptionExist(int id, string name)
        {
            var parameters = new object[][]
            {
                new object[] {"@id", DbType.Int32, id },
                new object[] {"@description", DbType.String, name}
            };

            string query = $"SELECT id FROM {tableName} WHERE id <> @id AND description = @description";
            string queryResult = _genericCommands.ExecuteScalar(query, parameters);
            if (!string.IsNullOrEmpty(queryResult))
                return true;

            return false;
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            var dict = new Dictionary<string, string>();

            var parameter = new object[][] {
                new object[]{"@business_add_on_charges_id", DbType.Int32, Id}
            };
            string query = $"SELECT code, description, is_applied_each_business FROM {tableName} WHERE id = @business_add_on_charges_id";

            using (var items = _genericCommands.ExecuteReader(query, parameter))
            {
                if (items.Rows.Count < 1)
                    return dict;

                foreach (DataRow item in items.Rows)
                {
                    dict.Add("code", item["code"].ToString());
                    dict.Add("description", item["description"].ToString());
                    dict.Add("is_applied_each_business", item["is_applied_each_business"].ToString());
                }

                return dict;
            }
        }

        public DataTable GetRecords()
        {
            string query = $"SELECT * FROM {tableName}";

            var dt = new DataTable();
            return _genericCommands.Fill(query, dt);
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            var parameters = new object[][]
            {
                new object[] { "@search_text", DbType.String, $"%{searchText}%"},
            };

            string query = $"SELECT * FROM {tableName} WHERE code LIKE @search_text OR description LIKE @search_text";

            var dtBarangay = new DataTable();
            return _genericCommands.FillBySearch(query, dtBarangay, parameters);
        }

        public bool IdExist(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool Insert(BusinessAddOnChargesModel entity)
        {
            var parameters = new object[][]
            {
                new object[] {"@code", DbType.String, entity.Code},
                new object[] {"@description", DbType.String, entity.Description},
                new object[] {"@is_applied_each_business", DbType.Boolean, entity.IsAppliedEachBusiness },
                new object[] {"@created_by", DbType.Int32, entity.CreatedBy },
            };

            string query = $"INSERT INTO {tableName} (code, description, is_applied_each_business, created_by) VALUES (@code, @description, @is_applied_each_business, @created_by)";

            return _genericCommands.ExecuteNonQuery(query, parameters);
        }

        public bool Update(BusinessAddOnChargesModel entity)
        {
            var parameters = new object[][] {
                new object[]{ "@id", DbType.Int32, entity.BusinessAddOnChargesID},
                new object[]{ "@code", DbType.String, entity.Code},
                new object[]{ "@description", DbType.String, entity.Description},
                new object[]{ "@is_applied_each_business", DbType.Boolean, entity.IsAppliedEachBusiness }
            };

            string query = $"UPDATE {tableName} SET code = @code, description= @description, is_applied_each_business = @is_applied_each_business  WHERE id = @id";
            return _genericCommands.ExecuteNonQuery(query, parameters);
        }
    }
}
