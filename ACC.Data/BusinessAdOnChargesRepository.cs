using ACC.Data;
using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System.Collections.Generic;
using System.Data;

namespace AccountingSystem
{
    internal class BusinessAdOnChargesRepository : IBusinessAdOnChargesRepository
    {
        private readonly IAccGenericCommands _dbGenericCommands;
        private readonly string tableName = "account_group";


        public BusinessAdOnChargesRepository(IAccGenericCommands dbGenericCommands)
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
            throw new System.NotImplementedException();
        }

        public bool Update(BusinessAdOnChargesModel entity)
        {
            throw new System.NotImplementedException();
        }
    }
}