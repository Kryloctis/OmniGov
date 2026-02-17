using Budget.Domain.Interfaces;
using Budget.Domain.Models;
using OmniGov.Core.Repositories;
using OmniGov.Core.Services;
using System.Data;

namespace Budget.Data.Repositories
{
    public class AllotmentAccountRepository : IAllotmentAccountRepository
    {
        private GenericCommands _mySqlGenericCommands;
        private readonly string tableName = "allotment_account";

        public AllotmentAccountRepository(GenericCommands mySqlGenericCommands)
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

                string query = $"INSERT INTO {tableName} " +
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

        public bool DeleteByAllotmentReleaseId(int allotmentReleaseId)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@allotment_release_id", DbType.Int32, allotmentReleaseId}
                };

                string query = $"DELETE FROM {tableName} WHERE allotment_release_id = @allotment_release_id ";

                return _mySqlGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

