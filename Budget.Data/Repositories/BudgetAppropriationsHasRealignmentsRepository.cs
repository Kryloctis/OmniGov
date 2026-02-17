using Budget.Domain.Interfaces;
using Budget.Domain.Models;
using OmniGov.Core.Repositories;
using OmniGov.Core.Services;
using System.Data;
using System.Transactions;

namespace Budget.Data.Repositories
{
    public class BudgetAppropriationsHasRealignmentsRepository : IBudgetAppropriationsHasRealignments
    {
        private readonly string tableName = "budget_appropriations_has_realignments";
        private GenericCommands mySqlGenericCommands;

        public BudgetAppropriationsHasRealignmentsRepository(GenericCommands mySqlGenericCommands)
        {
            this.mySqlGenericCommands = mySqlGenericCommands;
        }

        public int CountRecords()
        {
            throw new NotImplementedException();
        }

        public bool Delete(List<BudgetAppropriationsHasRealignmentsModel> entityList)
        {
            using (var scope = new TransactionScope())
            {
                foreach (var item in entityList)
                {
                    var parameters = new object[] { new object[] { "@id", DbType.Int32, item.Id } };
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

        public bool Insert(BudgetAppropriationsHasRealignmentsModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@realignments_id", DbType.Int32, entity.RealignmentsId},
                new object[] { "@budget_appropriations_id", DbType.Int32, entity.BudgetAppropriationsId},
                new object[] { "@date_entry", DbType.DateTime, entity.DateEntry},
                new object[] { "@remarks", DbType.String, entity.Remarks},
            };

            string query = $"INSERT INTO {tableName} (realignments_id, budget_appropriations_id, date_entry, remarks) VALUES (@realignments_id, @budget_appropriations_id, @date_entry, @remarks)";
            return mySqlGenericCommands.ExecuteNonQuery(query, parameters);
        }

        public bool Update(BudgetAppropriationsHasRealignmentsModel entity)
        {
            throw new NotImplementedException();
        }
    }
}

