using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ACC.Data
{
    public class SupplementalAppropriationsRepository : ISupplementalAppropriationsRepository
    {
        private MySqlGenericCommands _mySqlGenericCommands;
        private readonly string tableName = "supplemental_appropriations";

        public SupplementalAppropriationsRepository(MySqlGenericCommands mySqlGenericCommands)
        {
            _mySqlGenericCommands = mySqlGenericCommands;
        }

        public int CountRecords()
        {
            throw new NotImplementedException();
        }

        public bool Delete(List<SupplementalAppropriationsModel> entityList)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            throw new NotImplementedException();
        }

        public DataTable GetRecords()
        {
            throw new NotImplementedException();
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            throw new NotImplementedException();
        }

        public bool IdExist(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(SupplementalAppropriationsModel entity)
        {
            try
            {
                var parameters = new object[][]
              {
                    new object[] { "@budget_appropriations_id", DbType.Int32, entity.BudgetAppropriationID},
                    new object[] { "@date_entry", DbType.Date, entity.date_entry.Date},
                    new object[] { "@amount", DbType.Decimal, entity.amount},
                    new object[] { "@remarks", DbType.String, entity.remarks},
              };

                string query = $"INSERT INTO {tableName} (budget_appropriations_id, date_entry, amount, remarks) VALUES (@budget_appropriations_id, @date_entry, @amount, @remarks)";
                return _mySqlGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Update(SupplementalAppropriationsModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
