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



        public bool BulkInsert(List<AllotmentReleaseModel> allotmentReleaseModelList)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope()) 
                {
                    foreach (var item in allotmentReleaseModelList) 
                    {
                        var parameters = new object[][]
                        {
                            new object[] { "@budget_appropriations_id", DbType.Int32, item.BudgetAppropriationsID},
                            new object[] { "@aro_no", DbType.String, item.ARONumber},
                            new object[] { "@purpose", DbType.String, item.Purpose},
                            new object[] { "@date_issued", DbType.DateTime, item.DateIssued},
                            new object[] { "@amount", DbType.Decimal, item.amount}
                        };

                        string query = $"INSERT INTO {tableName} (budget_appropriations_id, aro_no, purpose, date_issued, amount) VALUES (@budget_appropriations_id, @aro_no, @purpose, @date_issued, @amount)";
                        _=_mySqlGenericCommands.ExecuteNonQuery(query, parameters);
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

        public bool allotmentReleaseExist(int budgetAppropriationId, string dateIssued)
        {
            try
            {
                var parameters = new object[][]
             {
                    new object[] { "@budget_appropriations_id", DbType.Int32, budgetAppropriationId},
                    new object[] { "@date_issued", DbType.String, dateIssued }
             };

                string query = $"SELECT id FROM {tableName} WHERE budget_appropriations_id = @budget_appropriations_id AND date_issued = @date_issued";
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

        public bool allotmentReleaseExist(int id, int budgetAppropriationId, string dateIssued)
        {
            try
            {
                var parameters = new object[][]
             {
                    new object[] { "@id", DbType.Int32, id},
                    new object[] { "@budget_appropriations_id", DbType.Int32, budgetAppropriationId},
                    new object[] { "@date_issued", DbType.String, dateIssued }
             };

                string query = $"SELECT id FROM {tableName} WHERE id <> @id AND budget_appropriations_id = @budget_appropriations_id AND date_issued = @date_issued";
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




        // For Budget Appropriation and Allotment Release Module

        public decimal GetViewTotalAllotmentReleaseAmountById(int budgetAppropriationId)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@budget_appropriations_id", DbType.Int32, budgetAppropriationId },
                };

                string query = $"SELECT " +
                    $"COALESCE(SUM(amount), 0) AS total_allotment_amount " +
                    $"FROM {tableName} " +
                    $"WHERE " +
                    $"budget_appropriations_id = @budget_appropriations_id ";


                return Convert.ToDecimal(_mySqlGenericCommands.ExecuteScalar(query, parameters));
            }
            catch (Exception)
            {
                throw;
            }
        }




        // For Obligation Request Module

        public decimal GetTotalAllotmentReleaseByDateYear(int fundID, int fppID, int? othersFPPID, int allotmentClassID, int accountID, DateTime dateIssued, short year)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@fpp_id", DbType.Int32,  fppID},
                    new object[] { "@others_fpp_id", DbType.String, othersFPPID },
                    new object[] { "@fund_id", DbType.Int32, fundID},
                    new object[] { "@allotment_class_id", DbType.Int32, allotmentClassID},
                    new object[] { "@gen_ledger_acc_id", DbType.Int32, accountID },
                    new object[] { "@allotment_release_date_issued",DbType.Date, dateIssued.Date },
                    new object[] { "@year",DbType.Int16, year}
                };

                string query = $"SELECT COALESCE " +
                    $"(SUM(allotment_release_amount), 0) AS total_allotment_amount " +
                    $"FROM {viewTableName} " +
                    $"WHERE fund_id = @fund_id " +
                    $"AND fpp_id = @fpp_id " +
                    $"AND others_fpp_id <=> @others_fpp_id " +
                    $"AND allotment_class_id = @allotment_class_id " +
                    $"AND gen_ledger_acc_id = @gen_ledger_acc_id " +
                    $"AND allotment_release_date_issued <= @allotment_release_date_issued " +
                    $"AND IF(budget_appropriations_continuing = 0, budget_appropriations_year = @year, budget_appropriations_year <= @year) ";

                return Convert.ToDecimal(_mySqlGenericCommands.ExecuteScalar(query, parameters));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public decimal GetTotalAllotmentReleaseByYear(int fundId, int fppId, int? othersFPPId, int allotmentClassId, int AccountId, short year)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@fund_id", DbType.Int32, fundId},
                    new object[] { "@fpp_id", DbType.Int32,  fppId},
                    new object[] { "@others_fpp_id", DbType.String, othersFPPId },
                    new object[] { "@allotment_class_id", DbType.String, allotmentClassId},
                    new object[] { "@gen_ledger_acc_id", DbType.Int32, AccountId },
                    new object[] { "@year", DbType.Int16, year}
                };

                string query = $"SELECT " +
                    $"COALESCE(SUM(allotment_release_amount), 0) AS total_allotment_amount " +
                    $"FROM view_allotment_release " +
                    $"WHERE fund_id = @fund_id " +
                    $"AND fpp_id = @fpp_id " +
                    $"AND others_fpp_id <=> @others_fpp_id " +
                    $"AND allotment_class_id = @allotment_class_id " +
                    $"AND gen_ledger_acc_id = @gen_ledger_acc_id " +
                    $"AND IF(budget_appropriations_continuing = 0, budget_appropriations_year = @year, budget_appropriations_year <= @year) ";

                return Convert.ToDecimal(_mySqlGenericCommands.ExecuteScalar(query, parameters));
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
