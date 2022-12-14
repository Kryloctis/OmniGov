using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Transactions;

namespace ACC.Data
{
    public class SupplementalAppropriationsRepository : ISupplementalAppropriationsRepository
    {
        private AccGenericCommands _mySqlGenericCommands;
        private readonly string tableName = "supplemental_appropriations";
        private readonly string viewTableName = "view_supplemental_appropriations";

        public SupplementalAppropriationsRepository(AccGenericCommands mySqlGenericCommands)
        {
            _mySqlGenericCommands = mySqlGenericCommands;
        }

        public int CountRecords()
        {
            throw new NotImplementedException();
        }

        public bool Insert(List<SupplementalAppropriationsModel> supplementalAppropriationsModelList, int budgetAppropriationId)
        {
            using (var scope = new TransactionScope())
            {
                _ = DeleteByBudgerAppropriationId(budgetAppropriationId);

                foreach (SupplementalAppropriationsModel supplementalAppropriationsModel in supplementalAppropriationsModelList)
                {
                    _ = Insert(supplementalAppropriationsModel);
                }

                scope.Complete();
                return true;
            };
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

        public bool DeleteByBudgerAppropriationId(int budgetAppropriationId)
        {
            using (var scope = new TransactionScope())
            {
                var parameters = new object[][]
                {
                    new object[] { "@budget_appropriations_id", DbType.Int32, budgetAppropriationId}
                };

                string query = $"DELETE FROM {tableName} WHERE budget_appropriations_id = @budget_appropriations_id";
                _ = _mySqlGenericCommands.ExecuteNonQuery(query, parameters);

                scope.Complete();
                return true;
            }
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            var record = new Dictionary<string, string>();

            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@id", DbType.Int32, Id }
                };

                string query = $"SELECT " +
                    $"id, " +
                    $"budget_appropriations_id, " +
                    $"date_entry, " +
                    $"amount, " +
                    $"remarks, " +
                    $"created_at, " +
                    $"updated_at " +
                    $"FROM {tableName} " +
                    $"WHERE id = @id";

                using (var reader = _mySqlGenericCommands.ExecuteReader(query, parameters))
                {
                    if (reader.Rows.Count < 1)
                        return record;

                    foreach (DataRow item in reader.Rows)
                    {
                        record.Add("id", item[0].ToString());
                        record.Add("budget_appropriations_id", item[1].ToString());
                        record.Add("date_entry", item[2].ToString());
                        record.Add("amount", item[3].ToString());
                        record.Add("remarks", item[4].ToString());
                        record.Add("created_at", item[5].ToString());
                        record.Add("updated_at", item[6].ToString());
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return record;
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
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@id", DbType.Int32, entity.Id },
                    new object[] { "@date_entry", DbType.Date, entity.date_entry },
                    new object[] { "@amount",DbType.Decimal, entity.amount },
                    new object[] { "@remarks", DbType.String, entity.remarks }
                };

                string query = $"UPDATE {tableName} SET date_entry = @date_entry, amount = @amount, remarks = @remarks WHERE id = @id";

                return _mySqlGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetRecordsByBudgetAppropriationId(int budgetAppropriationsId)
        {
            var parameters = new object[][]
            {
                new object[] { "@budget_appropriations_id",DbType.Int32, budgetAppropriationsId }
            };

            string query = $"SELECT id, budget_appropriations_id, date_entry, amount, remarks FROM {tableName} WHERE budget_appropriations_id = @budget_appropriations_id";

            var dtSupplementalApprorpriation = new DataTable();

            return _mySqlGenericCommands.FillBySearch(query, dtSupplementalApprorpriation, parameters);
        }

        public DataTable GetRecordsByBudgetAppropriationIdDateEntry(int budgetAppropriationId, DateTime dateEntry)
        {
            var parameters = new object[][]
            {
                new object[] { "@budget_appropriations_id", DbType.Int32, budgetAppropriationId },
                new object[] { "@date_entry", DbType.Date, dateEntry.Date}
            };

            string query = $"SELECT " +
                $"id, " +
                $"budget_appropriations_id, " +
                $"date_entry, " +
                $"amount, " +
                $"remarks " +
                $"FROM {tableName} " +
                $"WHERE " +
                $"budget_appropriations_id = @budget_appropriations_id " +
                $"AND date_entry <= @date_entry";

            var dtSupplementalApprorpriation = new DataTable();

            return _mySqlGenericCommands.FillBySearch(query, dtSupplementalApprorpriation, parameters);
        }

        public decimal GetSumSupplementalAppropriationsBy_FppId_SubFPPId_DateEntry_AllotmentClassId_IsContinuing(string fppId, string subFPPId, int fundId, DateTime dateEntry, int allotmentClassId, Byte isContinuing)
        {
            var parameters = new object[][]
            {
                new object[] { "@function_program_project_id", DbType.String, fppId },
                new object[] { "@others_fpp_id", DbType.String, subFPPId },
                new object[] { "@funds_id", DbType.Int32, fundId },
                new object[] { "@date_entry", DbType.Date, dateEntry.Date},
                new object[] { "@allotment_classes_id", DbType.Int32, allotmentClassId },
                new object[] { "@continuing", DbType.Byte, isContinuing },
                new object[] { "@appropriation_year", DbType.Int16, dateEntry.Year}
            };

            string fppWhereQuery = fppId == "all" ? string.Empty : "function_program_project_id = @function_program_project_id AND";
            string isContinuingQuery = isContinuing == 0 ? "appropriation_year = @appropriation_year" : "appropriation_year <= @appropriation_year";

            string subFPPQuery = string.Empty;
            if (subFPPId == "all")
                subFPPQuery = "others_fpp_id IS NOT NULL AND";
            else if (fppId == "all")
                subFPPQuery = string.Empty;
            else if (string.IsNullOrEmpty(subFPPId))
                subFPPQuery = "others_fpp_id IS NULL AND";
            else
                subFPPQuery = "others_fpp_id = @others_fpp_id AND";

            string query = $"SELECT COALESCE(SUM(amount), 0) AS amount " +
                $"FROM {viewTableName} " +
                $"WHERE {fppWhereQuery} " +
                $"{subFPPQuery} " +
                $"funds_id = @funds_id " +
                $"AND date_entry <= @date_entry " +
                $"AND allotment_classes_id = @allotment_classes_id " +
                $"AND continuing = @continuing " +
                $"AND {isContinuingQuery}";

            decimal supplementalAppropriations = Convert.ToDecimal(_mySqlGenericCommands.ExecuteScalar(query, parameters));

            return supplementalAppropriations;
        }

        public decimal GetSumSupplementalAppropriationsBy_BudgetAppropriationsId_DateEntry(int budgetAppropriationId, DateTime dateEntry)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@budget_appropriations_id", DbType.Int32, budgetAppropriationId },
                    new object[] { "@date_entry",DbType.Date, dateEntry.Date}
                };
                string query = $"SELECT COALESCE(SUM(amount),0) AS amount FROM {tableName} WHERE budget_appropriations_id = @budget_appropriations_id AND date_entry <= @date_entry";
                decimal supplementalAmount = Convert.ToDecimal(_mySqlGenericCommands.ExecuteScalar(query, parameters));
                return supplementalAmount;
            }
            catch (MySqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public decimal GetSumSupplementalAppropriationsBy_BudgetAppropriationsId(int budgetAppropriationId)
        {
            var parameters = new object[][]
            {
                new object[] { "@budget_appropriations_id", DbType.Int32, budgetAppropriationId }
            };
            string query = $"SELECT COALESCE(SUM(amount),0) AS amount FROM {tableName} WHERE budget_appropriations_id = @budget_appropriations_id";
            decimal supplementalAmount = Convert.ToDecimal(_mySqlGenericCommands.ExecuteScalar(query, parameters));
            return supplementalAmount;
        }
    }
}