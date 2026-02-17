using ACC.Domain.Interfaces;
using Budget.Domain.Entities;
using OmniGov.Core.Repositories;
using OmniGov.Core.Services;
using System.Data;
using System.Transactions;

namespace Budget.Data.Repositories
{
    public class RealignmentsRepository : IRealignments
    {
        private readonly string tableName = "realignments";
        private GenericCommands mySqlGenericCommands;

        public RealignmentsRepository(GenericCommands mySqlGenericCommands)
        {
            this.mySqlGenericCommands = mySqlGenericCommands;
        }

        public int CountRecords()
        {
            throw new NotImplementedException();
        }

        public bool Delete(List<RealignmentsModel> entityList)
        {
            using (var scope = new TransactionScope())
            {
                foreach (var item in entityList)
                {
                    var parameters = new object[][]
                    {
                        new object[]{ "@id", DbType.Int32, item.Id}
                    };

                    string query = $"DELETE FROM {tableName} WHERE id = @id";
                    _ = mySqlGenericCommands.ExecuteNonQuery(query, parameters);
                }

                scope.Complete();
                return true;
            }
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

        public bool Insert(RealignmentsModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@budget_appropriations_id", DbType.Int32, entity.BudgetAppropriationsId },
                new object[] { "@amount", DbType.Decimal, entity.Amount}
            };

            string query = $"INSERT INTO {tableName}(budget_appropriations_id, amount) VALUES  (@budget_appropriations_id, @amount)";
            return mySqlGenericCommands.ExecuteNonQuery(query, parameters);
        }

        public bool Update(RealignmentsModel entity)
        {
            throw new NotImplementedException();
        }
    }
}

