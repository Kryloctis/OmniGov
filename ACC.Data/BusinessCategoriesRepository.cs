using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Transactions;

namespace AccountingSystem
{
    internal class BusinessCategoriesRepository : IBusinessCategoriesRepository
    {
        private readonly IAccGenericCommands _dbGenericCommands;
        private const string tableName = "business_categories";
        private const string viewTableName = "view_business_categories";

        public BusinessCategoriesRepository(IAccGenericCommands dbGenericCommands)
        {
            _dbGenericCommands = dbGenericCommands;
        }

        public bool IdExist(int id)
        {
            throw new System.NotImplementedException();
        }

        public DataTable GetRecords()
        {
            string query = $"SELECT * FROM {tableName}";
            var dataTable = new DataTable();
            return _dbGenericCommands.FillBySearch(query, dataTable);
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            throw new System.NotImplementedException();
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
            throw new System.NotImplementedException();
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
                new object[]{ "@code", DbType.Int32, entity.Code},
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
    }
}