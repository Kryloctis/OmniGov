using ACC.Domain.Interfaces;
using ACC.Domain.Models;
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
            throw new System.NotImplementedException();
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