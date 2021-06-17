using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ACC.Data
{
    public class AllotmentAccountRepository : IAllotmentAccountRepository
    {

        private MySqlGenericCommands _mySqlGenericCommands;
        private readonly string tableName = "allotment_account";

        public AllotmentAccountRepository(MySqlGenericCommands mySqlGenericCommands)
        {
            _mySqlGenericCommands = mySqlGenericCommands;
        }

        public int CountRecords()
        {
            throw new NotImplementedException();
        }

        public bool Delete(List<AllotmentAccountModel> entityList)
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

        public bool Insert(AllotmentAccountModel entity)
        {
            try
            {
                var parameters = new object[][] 
                {
                    new object[] { "@budget_appropriations_id", DbType.Int32, entity.BudgetAppropriationsID },
                    new object[] { "@allotment_release_id", DbType.Int32, entity.AllotmentReleaseID },
                    new object[] { "@amount", DbType.Decimal, entity.Amount}
                };

                string query = $"INSERT INTO allotment_account " +
                    $"(budget_appropriations_id, " +
                    $"allotment_release_id, " +
                    $"amount) " +
                    $"VALUES " +
                    $"(@budget_appropriations_id, " +
                    $"@allotment_release_id, " +
                    $"@amount)";

                return _mySqlGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Update(AllotmentAccountModel entity)
        {
            throw new NotImplementedException();
        }

        public decimal GetViewTotalAllotmentReleaseAmountById(int budgetAppropriationId)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "budget_appropriations_id", DbType.Int32, budgetAppropriationId}
                };

                string query = $"Select COALESCE(SUM(amount), 0) AS total_allotment_amount FROM {tableName} WHERE budget_appropriations_id = @budget_appropriations_id ";
                return Convert.ToDecimal(_mySqlGenericCommands.ExecuteScalar(query, parameters));
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
