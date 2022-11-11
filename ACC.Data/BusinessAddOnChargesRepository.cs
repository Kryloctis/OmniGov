using ACC.Data;
using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System.Collections.Generic;
using System.Data;

namespace AccountingSystem
{
    internal class BusinessAddOnChargesRepository : IBusinessAdOnChargesRepository
    {
        private readonly IAccGenericCommands _dbGenericCommands;
        private readonly string tableName = "business_add_on_charges";


        public BusinessAddOnChargesRepository(IAccGenericCommands dbGenericCommands)
        {
            _dbGenericCommands = dbGenericCommands;
        }

        public int CountRecords()
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(List<BusinessAdOnChargesModel> entityList)
        {
            throw new System.NotImplementedException();
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            throw new System.NotImplementedException();
        }

        public DataTable GetRecords()
        {
            string query = $"SELECT * FROM {tableName}";

            var dt = new DataTable();
            return _dbGenericCommands.Fill(query, dt);
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            throw new System.NotImplementedException();
        }

        public bool IdExist(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool Insert(BusinessAdOnChargesModel entity)
        {
            var parameters = new object[][]
            {
                new object[] {"@code", DbType.String, entity.Code},
                new object[] {"@description", DbType.String, entity.Description},
                new object[] {"@is_applied_each_business", DbType.Boolean, entity.AppliedEachBusiness },
                new object[] {"@created_by", DbType.Int32, entity.CreatedBy },
            };

            string query = $"INSERT INTO {tableName} (code, description, is_applied_each_business, created_by) VALUES (@code, @description, @is_applied_each_business, @created_by)";

            return _dbGenericCommands.ExecuteNonQuery(query, parameters);
        }

        public bool Update(BusinessAdOnChargesModel entity)
        {
            throw new System.NotImplementedException();
        }
    }
}