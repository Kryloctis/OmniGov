using MySql.Data.MySqlClient;
using OmniGov.Budget.Domain.Entities;
using OmniGov.Budget.Domain.Interfaces;
using OmniGov.Core.Interfaces.Services;
using System.Data;
using System.Transactions;

namespace OmniGov.Budget.Data.Repositories
{
    public class BudgetAppropriationsHasRealignmentsRepository : IBudgetAppropriationsHasRealignments
    {
        private readonly string tableName = "budget_appropriations_has_realignments";
        private IGenericCommands _genericCommands;

        public BudgetAppropriationsHasRealignmentsRepository(IGenericCommands genericCommands)
        {
            _genericCommands = genericCommands;
        }

        public bool Delete(List<BudgetAppropriationsHasRealignmentsModel> entityList)
        {
            using (var scope = new TransactionScope())
            {
                foreach (var item in entityList)
                {
                    var parameters = new MySqlParameter[]
                    {
                        new("@id", item.Id),
                    };

                    string query = $"DELETE FROM {tableName} WHERE id = @id";
                    _ = _genericCommands.ExecuteNonQuery(query, parameters);
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
            var parameters = new MySqlParameter[]
            {
                new("@realignments_id", entity.RealignmentsId),
                new("@budget_appropriations_id", entity.BudgetAppropriationsId),
                new("@date_entry", entity.DateEntry),
                new("@remarks", entity.Remarks),
            };

            string query = $"INSERT INTO {tableName} (realignments_id, budget_appropriations_id, date_entry, remarks) VALUES (@realignments_id, @budget_appropriations_id, @date_entry, @remarks)";
            return _genericCommands.ExecuteNonQuery(query, parameters);
        }

        public bool Update(BudgetAppropriationsHasRealignmentsModel entity)
        {
            throw new NotImplementedException();
        }
    }
}