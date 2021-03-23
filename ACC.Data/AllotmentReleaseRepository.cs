using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ACC.Data
{
    public class AllotmentReleaseRepository : IAllotmentReleaseRepository
    {
        private MySqlGenericCommands _mySqlGenericCommands;
        private readonly string tableName = "allotment_release";

        public AllotmentReleaseRepository(MySqlGenericCommands mySqlGenericCommands)
        {
            this._mySqlGenericCommands = mySqlGenericCommands;
        }

        public int CountRecords()
        {
            throw new NotImplementedException();
        }

        public bool Delete(List<AllotmentReleaseModel> entityList)
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

        public bool Insert(AllotmentReleaseModel entity)
        {
            try
            {
                var parameters = new object[][]
               {
                    new object[] { "@budget_appropriations_id", DbType.Int32, entity.BudgetAppropriationsID},
                    new object[] { "@aro_no", DbType.String, entity.ARONumber},
                    new object[] { "@purpose", DbType.String, entity.Purpose},
                    new object[] { "@date_issued", DbType.DateTime, entity.DateIssued},
                    new object[] { "@amount", DbType.Decimal, entity.amount}
               };

                string query = $"INSERT INTO {tableName} (budget_appropriations_id, aro_no, purpose, date_issued, amount) VALUES (@budget_appropriations_id, @aro_no, @purpose, @date_issued, @amount)";
                return _mySqlGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Update(AllotmentReleaseModel entity)
        {
            throw new NotImplementedException();
        }

        public DataTable GetRecordsByBudgetAppropriationID(int budgetAppropriationID)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] {"@budget_appropriations_id", DbType.Int32, budgetAppropriationID }
                };

                string query = $"SELECT id, budget_appropriations_id, aro_no, purpose, date_issued, amount, created_at, updated_at FROM {tableName} WHERE budget_appropriations_id = @budget_appropriations_id";

                var dtAllotmentClasses = new DataTable();
                return _mySqlGenericCommands.FillBySearch(query, dtAllotmentClasses, parameters);
            }
            catch (Exception)
            {
                throw;
            }        
        }

        public DataTable GetRecordsByBudgetAppropriationID(int budgetAppropriationID, string allotmentReleaseNum)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] {"@budget_appropriations_id", DbType.Int32, budgetAppropriationID },
                    new object[] {"@aro_no", DbType.String, $"%{allotmentReleaseNum}%"}
                };

                string query = $"SELECT id, budget_appropriations_id, aro_no, purpose, date_issued, amount, created_at, updated_at FROM {tableName} WHERE budget_appropriations_id = @budget_appropriations_id AND aro_no LIKE @aro_no";

                var dtAllotmentClasses = new DataTable();
                return _mySqlGenericCommands.FillBySearch(query, dtAllotmentClasses, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
