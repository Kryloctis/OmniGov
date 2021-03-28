using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Transactions;

namespace ACC.Data
{
    public class AllotmentReleaseRepository : IAllotmentReleaseRepository
    {
        private MySqlGenericCommands _mySqlGenericCommands;
        private readonly string viewTableName = "view_allotment_release";
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
            try
            {
                using (var scope = new TransactionScope())
                {
                    foreach (var entity in entityList)
                    {
                        var parameters = new object[][]
                        {
                            new object[] { "@id", DbType.Int32, entity.ID},
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
            var record = new Dictionary<string, string>();

            try
            {
                var parameters = new object[][]
                {
                   new object[] { "@id", DbType.Int32, Id},
                };
                string query = $"SELECT aro_no, purpose, date_issued, amount FROM {tableName} WHERE id = @id";

                using (var reader = _mySqlGenericCommands.ExecuteReader(query, parameters))
                {
                    if (reader.Rows.Count < 1)
                        return record;

                    foreach (DataRow item in reader.Rows)
                    {
                        record.Add("aro_no", item[0].ToString());
                        record.Add("purpose", item[1].ToString());
                        record.Add("date_issued", item[2].ToString());
                        record.Add("amount", item[3].ToString());
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
            try
            {
                var parameters = new object[][]
               {
                    new object[] { "@id", DbType.Int32, entity.ID},  
                    new object[] { "@aro_no", DbType.String, entity.ARONumber},
                    new object[] { "@purpose", DbType.String, entity.Purpose},
                    new object[] { "@date_issued", DbType.DateTime, entity.DateIssued},
                    new object[] { "@amount", DbType.Decimal, entity.amount}
               };

                string query = $"UPDATE {tableName} SET aro_no = @aro_no, purpose = @purpose, date_issued = @date_issued, amount = @amount WHERE id = @id";
                return _mySqlGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
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

        public bool allotmentReleaseNumExist(string alltomentReleaseNum)
        {
            try
            {
                var parameters = new object[][]
               {
                    new object[] { "@aro_no", DbType.String, alltomentReleaseNum}
               };

                string query = $"SELECT id FROM {tableName} WHERE aro_no = @aro_no";
                string queryResult = _mySqlGenericCommands.ExecuteScalar(query, parameters);

                // if query is not null, means found some record, so true
                if (!string.IsNullOrEmpty(queryResult)) return true;
            }
            catch (Exception)
            {
                throw;
            }
            return false;
        }

        public bool allotmentReleaseNumExist(int id, string alltomentReleaseNum)
        {
            try
            {
                var parameters = new object[][]
               {
                    new object[] { "@id", DbType.String, id},
                    new object[] { "@aro_no", DbType.String, alltomentReleaseNum}
               };

                string query = $"SELECT id FROM {tableName} WHERE  id <> @id AND aro_no = @aro_no";
                string queryResult = _mySqlGenericCommands.ExecuteScalar(query, parameters);

                // if query is not null, means found some record, so true
                if (!string.IsNullOrEmpty(queryResult)) return true;
            }
            catch (Exception)
            {
                throw;
            }
            return false;
        }

        public DataTable GetViewRecords()
        {
            try
            {
                string query = $"SELECT " +
                    $"id, " +
                    $"aro_no, " +
                    $"allotment_release_purpose, " +
                    $"allotment_release_date_issued, " +
                    $"SUM(allotment_release_amount) AS allotment_release_amount, " +
                    $"budget_appropriations_id, " +
                    $"budget_appropriations_year, " +
                    $"budget_appropriations_amount, " +
                    $"fund_id, " +
                    $"fund_code, " +
                    $"fund_name, " +
                    $"fpp_id, " +
                    $"fpp_code, " +
                    $"fpp_name, " +
                    $"others_fpp_id, " +
                    $"others_fpp_name, " +
                    $"allotment_classes_id, " +
                    $"allotment_code, " +
                    $"allotment_name, " +
                    $"gen_ledger_acc_id, " +
                    $"gen_ledger_code, " +
                    $"account_code, " +
                    $"gen_ledger_name " +
                    $"FROM {viewTableName} " +
                    $"GROUP BY gen_ledger_acc_id , others_fpp_id , fpp_id , budget_appropriations_year";

                var dtAllotmentClasses = new DataTable();
                return _mySqlGenericCommands.Fill(query, dtAllotmentClasses);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetViewRecords(int fppId, int? othersFPPId, int fundsId, int allotmentClassId, short year)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object [] { "@fpp_id", DbType.Int32, fppId},
                    new object [] { "@fund_id", DbType.Int32, fundsId},
                    new object [] { "@allotment_class_id", DbType.Int32, allotmentClassId},
                    new object [] { "@others_fpp_id", DbType.String, othersFPPId},
                    new object [] { "@budget_appropriations_year", DbType.Int32, year}
                };

                string query = $"SELECT " +
                    $"SUM(allotment_release_amount) AS total_allotment_release_amount, " +
                    $"budget_appropriations_id, " +
                    $"budget_appropriations_year, " +
                    $"budget_appropriations_amount, " +
                    $"fund_id, " +
                    $"fund_code, " +
                    $"fund_name, " +
                    $"fpp_id, " +
                    $"fpp_code, " +
                    $"fpp_name, " +
                    $"others_fpp_id, " +
                    $"others_fpp_name, " +
                    $"allotment_class_id, " +
                    $"allotment_class_code, " +
                    $"allotment_class_name, " +
                    $"gen_ledger_acc_id, " +
                    $"gen_ledger_code, " +
                    $"account_code, " +
                    $"gen_ledger_name " +
                    $"FROM {viewTableName} WHERE fpp_id = @fpp_id AND others_fpp_id <=> @others_fpp_id AND fund_id = @fund_id AND allotment_class_id = @allotment_class_id AND budget_appropriations_year = @budget_appropriations_year " +
                    $"GROUP BY gen_ledger_acc_id , others_fpp_id , fpp_id , budget_appropriations_year";

                var dtAllotmentClasses = new DataTable();
                return _mySqlGenericCommands.FillBySearch(query, dtAllotmentClasses, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetFPPRecords()
        {
            try
            {
                string query = $"SELECT fpp_id, fpp_code, fpp_name FROM {viewTableName} GROUP BY fpp_id;";

                var dtAllotmentClasses = new DataTable();
                return _mySqlGenericCommands.Fill(query, dtAllotmentClasses);

            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetOthersFPPRecords(int fppId, int allotmentClassId, int fundId, short year)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object [] { "@fpp_id", DbType.Int32, fppId},
                    new object [] { "@fund_id", DbType.Int32, fundId},
                    new object [] { "@allotment_class_id", DbType.Int32, allotmentClassId},
                    new object [] { "@budget_appropriations_year", DbType.Int32, year}
                };

                string query = $"SELECT DISTINCT" +
                    $" a.others_fpp_id," +
                    $" a.others_fpp_name FROM view_allotment_release a " +
                    $"JOIN " +
                    $"others_fpp b ON a.others_fpp_id = b.id " +
                    $"WHERE a.fpp_id = @fpp_id AND a.allotment_class_id = @allotment_class_id AND fund_id = @fund_id AND a.budget_appropriations_year = @budget_appropriations_year";

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
