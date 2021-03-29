using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Transactions;

namespace ACC.Data
{
    public class ObligationRequestRepository : IObligationRequestRepository
    {
        private MySqlGenericCommands mySqlGenericCommands;
        private readonly string tableName = "obligation_request";
        private readonly string viewTableName = "view_obligation_request";


        public ObligationRequestRepository(MySqlGenericCommands mySqlGenericCommands)
        {
            this.mySqlGenericCommands = mySqlGenericCommands;
        }

        public int CountRecords()
        {
            throw new NotImplementedException();
        }

        public bool Delete(List<ObligationRequestModel> entityList)
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
                        _ = mySqlGenericCommands.ExecuteNonQuery(query, parameters);
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

        public bool Insert(ObligationRequestModel entity)
        {
            try
            {
                var parameters = new object[][]
               {
                    new object[] { "@funds_id", DbType.Int32, entity.FundID },
                    new object[] { "@function_program_project_id", DbType.Int32, entity.FPPId },
                    new object[] { "@others_fpp_id", DbType.String, entity.OtherFPPId },
                    new object[] { "@allotment_classes_id", DbType.Int32, entity.AllotmentClassesID },
                    new object[] { "@general_ledger_accounts_id", DbType.Int32, entity.GenLedgerAccID},
                    new object[] { "@obligation_no", DbType.String, entity.ObligationNo},
                    new object[] { "@obligation_amount", DbType.Decimal, entity.ObligationAmount},
                    new object[] { "@created_by", DbType.Int32, entity.CreatedBy}
               };

                string query = $"INSERT INTO {tableName} " +
                    $"(funds_id, " +
                    $"function_program_project_id, " +
                    $"others_fpp_id, " +
                    $"allotment_classes_id, " +
                    $"general_ledger_accounts_id, " +
                    $"obligation_no, " +
                    $"obligation_amount, " +
                    $"created_by) " +
                    $"VALUES " +
                    $"(@funds_id, " +
                    $"@function_program_project_id, " +
                    $"@others_fpp_id, " +
                    $"@allotment_classes_id, " +
                    $"@general_ledger_accounts_id, " +
                    $"@obligation_no, " +
                    $"@obligation_amount, " +
                    $"@created_by)";
                return mySqlGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Update(ObligationRequestModel entity)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@id", DbType.Int32, entity.ID },
                    new object[] { "@obligation_no", DbType.String, entity.ObligationNo },
                    new object[] { "@obligation_amount", DbType.Decimal, entity.ObligationAmount },
                    new object[] { "@updated_by", DbType.Int32, entity.UpdatedBy }
                };

                string query = $"UPDATE {tableName} " +
                    $"SET " +
                    $"obligation_no = @obligation_no, " +
                    $"obligation_amount = @obligation_amount, " +
                    $"updated_by = @updated_by" +
                    $" WHERE id = @id";

                return mySqlGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #region Validations

        public bool ObligationNumExist(string obligationNum)
        {
            try
            {
                var parameters = new object[][]
                {
                   new object[] { "@obligation_no", DbType.String, obligationNum }
                };

                string query = $"SELECT id FROM {tableName} WHERE obligation_no = @obligation_no";
                string queryResult = mySqlGenericCommands.ExecuteScalar(query, parameters);

                // if query is not null, means found some record, so true
                if (!string.IsNullOrEmpty(queryResult)) return true;
            }
            catch (Exception)
            {
                throw;
            }
            return false;
        }
        public bool ObligationNumExist(int id, string obligationNum)
        {
            try
            {
                var parameters = new object[][]
                {
                   new object[] { "@id", DbType.Int32, id },
                   new object[] { "@obligation_no", DbType.String, obligationNum }
                };

                string query = $"SELECT id FROM {tableName} WHERE id <> @id AND obligation_no = @obligation_no";
                string queryResult = mySqlGenericCommands.ExecuteScalar(query, parameters);

                // if query is not null, means found some record, so true
                if (!string.IsNullOrEmpty(queryResult)) return true;
            }
            catch (Exception)
            {
                throw;
            }
            return false;
        }

        Dictionary<string, string> IObligationRequestRepository.GetRecordByObligationNum(string obligationNum)
        {
            var record = new Dictionary<string, string>();

            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@obligation_no", DbType.String, obligationNum}
                };

                string query = $"SELECT " +
                    $"obligation_request_id, " +
                    $"funds_id, " +
                    $"fund_name, " +
                    $"function_program_project_id, " +
                    $"fpp_code, " +
                    $"fpp_name, " +
                    $"others_fpp_id, " +
                    $"others_fpp_name, " +
                    $"allotment_classes_id, " +
                    $"allotment_code, " +
                    $"allotment_name, " +
                    $"general_ledger_accounts_id, " +
                    $"ledger_code, " +
                    $"account_code, " +
                    $"ledger_name, " +
                    $"obligation_no, " +
                    $"obligation_amount, " +
                    $"created_at, " +
                    $"created_by, " +
                    $"updated_at, " +
                    $"updated_by " +
                    $"FROM {viewTableName} " +
                    $"WHERE obligation_no = @obligation_no";

                using (var reader = mySqlGenericCommands.ExecuteReader(query, parameters))
                {
                    if (reader.Rows.Count < 1)
                        return record;

                    foreach (DataRow item in reader.Rows)
                    {
                        record.Add("obligation_request_id", item[0].ToString());
                        record.Add("funds_id", item[1].ToString());
                        record.Add("fund_name", item[2].ToString());
                        record.Add("function_program_project_id", item[3].ToString());
                        record.Add("fpp_code", item[4].ToString());
                        record.Add("fpp_name", item[5].ToString());
                        record.Add("others_fpp_id", item[6].ToString());
                        record.Add("others_fpp_name", item[7].ToString());
                        record.Add("allotment_classes_id", item[8].ToString());
                        record.Add("allotment_code", item[9].ToString());
                        record.Add("allotment_name", item[10].ToString());
                        record.Add("general_ledger_accounts_id", item[11].ToString());
                        record.Add("ledger_code", item[12].ToString());
                        record.Add("account_code", item[13].ToString());
                        record.Add("ledger_name", item[14].ToString());
                        record.Add("obligation_no", item[15].ToString());
                        record.Add("obligation_amount", item[16].ToString());
                        record.Add("created_at", item[16].ToString());
                        record.Add("created_by", item[17].ToString());
                        record.Add("updated_at", item[18].ToString());
                        record.Add("updated_by", item[19].ToString());
                    }
                }
            }
            catch (Exception)
            {
                    throw;
            }
            return record;
        }

        #endregion Validations
    }
}
