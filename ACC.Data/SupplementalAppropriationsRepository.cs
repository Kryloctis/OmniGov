using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Transactions;

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
            try
            {
                using (var scope = new TransactionScope())
                {
                    foreach (var entity in entityList)
                    {
                        var parameters = new object[][]
                        {
                            new object[] { "@id", DbType.Int32, entity.Id},
                        };

                        string query = $"DELETE FROM {tableName} WHERE id = @id";
                        _ = _mySqlGenericCommands.ExecuteNonQuery(query, parameters);
                    }

                    scope.Complete();
                    return true;
                }
            }
            catch (Exception)
            {
                throw;
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

        public DataTable GetRecordsById(int budgetAppropriationsId)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@budget_appropriations_id",DbType.Int32, budgetAppropriationsId }
                };

                string query = $"SELECT id, budget_appropriations_id, date_entry, amount, remarks, created_at, updated_at FROM {tableName} WHERE budget_appropriations_id = @budget_appropriations_id";

                var dtSupplementalApprorpriation = new DataTable();

                return _mySqlGenericCommands.FillBySearch(query, dtSupplementalApprorpriation, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public decimal GetTotalSupplementalAmountById(int budgetAppropriationsId)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@budget_appropriations_id", DbType.Int32, budgetAppropriationsId }
                };

                string query = $"SELECT COALESCE(SUM(amount),0) as total_supplemental_amount " +
                    $"FROM lfsdb.supplemental_appropriations " +
                    $"WHERE budget_appropriations_id = @budget_appropriations_id";

                return Convert.ToDecimal(_mySqlGenericCommands.ExecuteScalar(query, parameters));

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
