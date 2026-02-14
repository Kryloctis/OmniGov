using OmniGov.Core.Repositories;
using System.Data;
using System.Transactions;
using Treasury.Domain.Entities;
using Treasury.Domain.Interfaces;

namespace Treasury.Data.Repositories
{
    internal class BusinessCategoriesRepository : IBusinessCategoriesRepository
    {
        private readonly GenericCommands _dbGenericCommands;
        private const string tableName = "business_categories";
        private const string viewTableName = "view_business_categories";

        public BusinessCategoriesRepository(GenericCommands dbGenericCommands)
        {
            _dbGenericCommands = dbGenericCommands;
        }

        public bool IdExist(int id)
        {
            throw new NotImplementedException();
        }

        public DataTable GetRecords()
        {
            string query = $"SELECT * FROM {tableName}";
            var dataTable = new DataTable();
            return _dbGenericCommands.FillBySearch(query, dataTable);
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            var parameters = new object[][]
            {
                new object[] { "@search_text", DbType.String, $"%{searchText}%"},
            };

            string query = $"SELECT * FROM {tableName} WHERE code LIKE @search_text OR ordinance_ref_no LIKE @search_text OR description LIKE @search_text";
            return _dbGenericCommands.FillBySearch(query, new DataTable(), parameters); ;
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            var dict = new Dictionary<string, string>();

            var parameter = new object[][] {
                new object[]{"@business_categories_id", DbType.Int32, Id}
            };
            string query = $"SELECT code, ordinance_ref_no, description, is_line_of_business FROM {tableName} WHERE id = @business_categories_id";

            using (var items = _dbGenericCommands.ExecuteReader(query, parameter))
            {
                if (items.Rows.Count < 1)
                    return dict;

                foreach (DataRow item in items.Rows)
                {
                    dict.Add("code", item["code"].ToString());
                    dict.Add("ordinance_ref_no", item["ordinance_ref_no"].ToString());
                    dict.Add("description", item["description"].ToString());
                    dict.Add("is_line_of_business", item["is_line_of_business"].ToString());
                }

                return dict;
            }
        }

        public int CountRecords()
        {
            throw new NotImplementedException();
        }

        public bool Insert(BusinessCategoriesModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@code", DbType.String, entity.Code},
                new object[] { "@ordinance_ref_no", DbType.String, entity.OrdinanceReferenceNumber},
                new object[] { "@description", DbType.String, entity.Description},
                new object[] { "@is_line_of_business", DbType.Boolean, entity.LineOfBusiness},
            };

            string query = $"INSERT INTO {tableName} (code, ordinance_ref_no, description, is_line_of_business) VALUES (@code, @ordinance_ref_no, @description, @is_line_of_business)";

            return _dbGenericCommands.ExecuteNonQuery(query, parameters);
        }

        public bool Update(BusinessCategoriesModel entity)
        {
            var parameters = new object[][] {
                new object[]{ "@business_categories_id", DbType.Int32, entity.BusinessCategoryID},
                new object[]{ "@code", DbType.String, entity.Code},
                new object[]{ "@ordinance_ref_no", DbType.String, entity.OrdinanceReferenceNumber},
                new object[]{ "@description", DbType.String, entity.Description },
                new object[]{ "@is_line_of_business", DbType.Boolean, entity.LineOfBusiness }
            };

            string query = $"UPDATE {tableName} SET code = @code, ordinance_ref_no = @ordinance_ref_no, description= @description, is_line_of_business = @is_line_of_business  WHERE id = @business_categories_id";
            return _dbGenericCommands.ExecuteNonQuery(query, parameters);
        }

        public bool Delete(List<BusinessCategoriesModel> entityList)
        {
            using (var scope = new TransactionScope())
            {
                foreach (var entity in entityList)
                {
                    var parameters = new object[][] { new object[] { @"id", DbType.Int32, entity.BusinessCategoryID } };

                    string query = $"DELETE FROM {tableName} WHERE id = @id";
                    _ = _dbGenericCommands.ExecuteNonQuery(query, parameters);
                }

                scope.Complete();
                return true;
            }
        }

        public int GetLastInsertedId()
        {
            string query = $"SELECT COALESCE(MAX(id), 0) FROM {tableName}";
            return Convert.ToInt32(_dbGenericCommands.ExecuteScalar(query));
        }

        public bool DescriptionExist(int id, string description)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, id},
                new object[] { "@description", DbType.String, description}
            };

            string query = $"SELECT id FROM {tableName} WHERE id <> @id AND description = @description";
            string result = _dbGenericCommands.ExecuteScalar(query, parameters);
            return !string.IsNullOrEmpty(result);
        }

        public bool DescriptionExist(string description)
        {
            var parameters = new object[][] { new object[] { "@description", DbType.String, description } };

            string query = $"SELECT id FROM {tableName} WHERE description = @description";
            string result = _dbGenericCommands.ExecuteScalar(query, parameters);
            return !string.IsNullOrEmpty(result);
        }
    }
}