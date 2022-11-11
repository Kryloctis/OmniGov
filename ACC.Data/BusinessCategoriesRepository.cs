using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;

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
            throw new System.NotImplementedException();
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
            throw new System.NotImplementedException();
        }

        public bool Delete(List<BusinessCategoriesModel> entityList)
        {
            throw new System.NotImplementedException();
        }
    }
}