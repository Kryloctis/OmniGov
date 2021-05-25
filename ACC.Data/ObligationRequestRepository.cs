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
        private readonly string tableName = "obligation_request";
        private readonly string viewTableName = "view_obligation_request";

        private readonly IObligationAccountRepository _obligationAccountRepository;

        private MySqlGenericCommands _mySqlGenericCommands;

        public ObligationRequestRepository(
            MySqlGenericCommands mySqlGenericCommands,
            IObligationAccountRepository obligationAccountRepository)
        {
            _mySqlGenericCommands = mySqlGenericCommands;
            _obligationAccountRepository = obligationAccountRepository;
        }

        public int CountRecords()
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

        public bool Insert(ObligationRequestModel entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(List<ObligationRequestModel> entityList)
        {
            throw new NotImplementedException();
        }

        public bool Update(ObligationRequestModel entity)
        {
            throw new NotImplementedException();
        }

        //Validations

        public bool ObligationRequestNoExist(string obligationNo)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@obligation_no", DbType.String, obligationNo }
                };

                string query = $"SELECT id FROM {tableName} WHERE obligation_no = @obligation_no";
                string queryResult = _mySqlGenericCommands.ExecuteScalar(query, parameters);

                if (!string.IsNullOrEmpty(queryResult)) return true;
            }
            catch (Exception)
            {
                throw;
            };

            return false;
        }

        public bool ObligationRequestNoExist(int Id, string obligationNo)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@id",DbType.Int32, Id },
                    new object[] { "@obligation_no", DbType.String, obligationNo }
                };

                string query = $"SELECT id FROM {tableName} WHERE id <> @id AND obligation_no = @obligation_no";
                string queryResult = _mySqlGenericCommands.ExecuteScalar(query, parameters);

                if (!string.IsNullOrEmpty(queryResult)) return true;
            }
            catch (Exception)
            {
                throw;
            };

            return false;
        }


        public Dictionary<string, string> GetViewRecordByObligationNo(string obligationNo)
        {
            var record = new Dictionary<string, string>();

            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@obligation_no", DbType.String, obligationNo }
                };

                string query = $"SELECT " +
                    $"obligation_request_id, " +
                    $"funds_id, " +
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
                    $"date_requested, " +
                    $"obligation_no, " +
                    $"payee, " +
                    $"explanation, " +
                    $"reference_no, " +
                    $"obligation_requested_created_at, " +
                    $"obligation_requested_created_by, " +
                    $"obligation_requested_updated_at, " +
                    $"obligation_requested_updated_by, " +
                    $"obligation_account_id, " +
                    $"general_ledger_accounts_id, " +
                    $"COALESCE(SUM(obligation_requested_amount),0) AS obligation_requested_amount " +
                    $"FROM {viewTableName} " +
                    $"WHERE " +
                    $"obligation_no = @obligation_no " +
                    $"GROUP BY obligation_request_id";


                using (var reader = _mySqlGenericCommands.ExecuteReader(query, parameters))
                {
                    if (reader.Rows.Count < 1)
                        return record;

                    foreach (DataRow item in reader.Rows)
                    {
                        record.Add("obligation_request_id", item[0].ToString());
                        record.Add("funds_id", item[1].ToString());
                        record.Add("fund_code", item[2].ToString());
                        record.Add("fund_name", item[3].ToString());
                        record.Add("fpp_id", item[4].ToString());
                        record.Add("fpp_code", item[5].ToString());
                        record.Add("fpp_name", item[6].ToString());
                        record.Add("others_fpp_id", item[7].ToString());
                        record.Add("others_fpp_name", item[8].ToString());
                        record.Add("allotment_classes_id", item[9].ToString());
                        record.Add("allotment_code", item[10].ToString());
                        record.Add("allotment_name", item[11].ToString());
                        record.Add("date_requested", item[12].ToString());
                        record.Add("obligation_no", item[13].ToString());
                        record.Add("payee", item[14].ToString());
                        record.Add("explanation", item[15].ToString());
                        record.Add("reference_no", item[16].ToString());
                        record.Add("obligation_requested_created_at", item[17].ToString());
                        record.Add("obligation_requested_created_by", item[18].ToString());
                        record.Add("obligation_requested_updated_at", item[19].ToString());
                        record.Add("obligation_requested_updated_by", item[20].ToString());
                        record.Add("obligation_account_id", item[21].ToString());
                        record.Add("general_ledger_accounts_id", item[22].ToString());
                        record.Add("obligation_requested_amount", item[23].ToString());
                    }
                }

                return record;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetViewRecordsById(int Id)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@obligation_request_id", DbType.String, Id }
                };

                string query = $"SELECT " +
                    $"obligation_request_id, " +
                    $"funds_id, " +
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
                    $"date_requested, " +
                    $"obligation_no, " +
                    $"payee, " +
                    $"explanation, " +
                    $"reference_no, " +
                    $"obligation_requested_created_at, " +
                    $"obligation_requested_created_by, " +
                    $"obligation_requested_updated_at, " +
                    $"obligation_requested_updated_by, " +
                    $"obligation_account_id, " +
                    $"general_ledger_accounts_id, " +
                    $"account_code, " +
                    $"ledger_accounts_name, " +
                    $"obligation_requested_amount " +
                    $"FROM {viewTableName} " +
                    $"WHERE " +
                    $"obligation_request_id = @obligation_request_id";

                var dtObligationRequests = new DataTable();
                return _mySqlGenericCommands.FillBySearch(query, dtObligationRequests, parameters);
            }
            catch (Exception )
            {
                throw;
            }
        }




        public int GetLastInsertedID()
        {
            try
            {
                string query = $"SELECT MAX(id) FROM {tableName}";
                return int.Parse(_mySqlGenericCommands.ExecuteScalar(query));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Insert(ObligationRequestModel entity, List<ObligationAccountModel> obligationAccountModels)
        {
            try
            {
                using (var scope = new TransactionScope())
                {
                    object[][] parameters = new object[][]
                    {
                        new object[] { "@function_program_project_id", DbType.Int32, entity.FPPId },
                        new object[] { "@others_fpp_id", DbType.String, entity.OtherFPPId },
                        new object[] { "@funds_id", DbType.Int32, entity.FundId },
                        new object[] { "@allotment_classes_id", DbType.Int32, entity.AllotmentClassId },
                        new object[] { "@date_requested", DbType.Date, entity.DateRequested.Date },
                        new object[] { "@obligation_no", DbType.String, entity.ObligationNo },
                        new object[] { "@payee", DbType.String, entity.Payee },
                        new object[] { "@explanation", DbType.String, entity.Explanation },
                        new object[] { "@reference_no", DbType.String, entity.ReferenceNo },
                        new object[] { "@created_by", DbType.Int32, entity.CreatedBy },
                    };

                    string query = $"INSERT INTO {tableName} " +
                        $"(funds_id, " +
                        $"function_program_project_id, " +
                        $"others_fpp_id, " +
                        $"allotment_classes_id, " +
                        $"date_requested, " +
                        $"obligation_no, " +
                        $"payee, " +
                        $"explanation, " +
                        $"reference_no, " +
                        $"created_by) " +
                        $"VALUES(" +
                        $"@funds_id, " +
                        $"@function_program_project_id, " +
                        $"@others_fpp_id, " +
                        $"@allotment_classes_id, " +
                        $"@date_requested, " +
                        $"@obligation_no, " +
                        $"@payee, " +
                        $"@explanation, " +
                        $"@reference_no, " +
                        $"@created_by)";

                    // save and get the last inserted id
                    _ = _mySqlGenericCommands.ExecuteNonQuery(query, parameters);

                    // loop obligation  accounts list then insert each using the latest obligation request Id
                    foreach (var obligationAccounts in obligationAccountModels)
                    {
                        obligationAccounts.ObligationRequestId = GetLastInsertedID();
                        _ = _obligationAccountRepository.Insert(obligationAccounts);
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

        public bool Update(ObligationRequestModel entity, List<ObligationAccountModel> obligationAccountModels)
        {
            try
            {
                using (var scope = new TransactionScope()) 
                {
                    var parameters = new object[][]
                    {
                        new object[] { "@id",DbType.Int32, entity.Id},
                        new object[] { "@payee", DbType.String, entity.Payee },
                        new object[] { "@explanation", DbType.String, entity.Explanation },
                        new object[] { "@reference_no", DbType.String, entity.ReferenceNo },
                        new object[] { "@updated_by", DbType.Int32, entity.UpdatedBy },
                    };

                    string query = $"UPDATE {tableName} SET payee = @payee, explanation = @explanation, reference_no = @reference_no, updated_by = @updated_by WHERE id = @id";


                    // save and get the last inserted id
                    _ = _mySqlGenericCommands.ExecuteNonQuery(query, parameters);

                    // delete all the obligation accounts first
                    _ = _obligationAccountRepository.DeleteByObligationRequestId(entity.Id);

                    // loop obligation accounts list then insert each using the latest obligation request Id
                    foreach (var obligationAccounts in obligationAccountModels)
                    {
                        obligationAccounts.ObligationRequestId = GetLastInsertedID();
                        _ = _obligationAccountRepository.Insert(obligationAccounts);
                    }


                    scope.Complete();

                    return true;
                };

            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Delete(int obligationRequestId)
        {
            try
            {
                using (var scope = new TransactionScope()) 
                {
                    _obligationAccountRepository.DeleteByObligationRequestId(obligationRequestId);

                    var parameters = new object[][]
                    {
                        new object[] { "@id", DbType.Int32, obligationRequestId} 
                    };

                    string query = $"DELETE FROM {tableName} WHERE id = @id";

                    _ = _mySqlGenericCommands.ExecuteNonQuery(query, parameters);


                    scope.Complete();
                    return true;
                };

            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public decimal TotalObligationRequestByYear(int fundsId, int fppId, int? otherFPPId, int allotmentClassId, int accountId, short year)
        {
            try
            {
                try
                {
                    var parameters = new object[][]
                    {
                        new object[] { "@funds_id", DbType.Int32, fundsId },
                        new object[] { "@fpp_id", DbType.Int32, fppId },
                        new object[] { "@others_fpp_id", DbType.String, otherFPPId },
                        new object[] { "@allotment_classes_id", DbType.Int32, allotmentClassId },
                        new object[] { "@general_ledger_accounts_id", DbType.Int32, accountId},
                        new object[] { "@year",DbType.Int16, year}
                    };

                    string query = $"SELECT " +
                        $"COALESCE(SUM(obligation_requested_amount), 0) AS total_obligation_request_amount " +
                        $"FROM {viewTableName} " +
                        $"WHERE " +
                        $"funds_id = @funds_id " +
                        $"AND fpp_id = @fpp_id " +
                        $"AND others_fpp_id <=> others_fpp_id " +
                        $"AND allotment_classes_id = @allotment_classes_id " +
                        $"AND general_ledger_accounts_id = @general_ledger_accounts_id " +
                        $"AND YEAR(date_requested) = @year";


                    return Convert.ToDecimal(_mySqlGenericCommands.ExecuteScalar(query, parameters));
                }
                catch (Exception)
                {
                    throw;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public decimal TotalObligationRequestByDateYear(int fundId, int fppId, int? otherFPPId, int allotmentClassId, int accountId, DateTime dateRequested, short year)
        {
            try
            {
                try
                {
                    var parameters = new object[][]
                    {
                        new object[] { "@funds_id", DbType.Int32, fundId },
                        new object[] { "@fpp_id", DbType.Int32, fppId },
                        new object[] { "@others_fpp_id", DbType.String, otherFPPId },
                        new object[] { "@allotment_classes_id", DbType.Int32, allotmentClassId },
                        new object[] { "@general_ledger_accounts_id", DbType.Int32, accountId},
                        new object[] { "@date_requested", DbType.Date, dateRequested.Date },
                        new object[] { "@year",DbType.Int16, year}
                    };

                    string query = $"SELECT " +
                        $"COALESCE(SUM(obligation_requested_amount), 0) AS total_obligation_request_amount " +
                        $"FROM {viewTableName} " +
                        $"WHERE " +
                        $"funds_id = @funds_id " +
                        $"AND fpp_id = @fpp_id " +
                        $"AND others_fpp_id <=> others_fpp_id " +
                        $"AND allotment_classes_id = @allotment_classes_id " +
                        $"AND general_ledger_accounts_id = @general_ledger_accounts_id " +
                        $"AND date_requested <= @date_requested " +
                        $"AND YEAR(date_requested) = @year";


                    return Convert.ToDecimal(_mySqlGenericCommands.ExecuteScalar(query, parameters));
                }
                catch (Exception)
                {
                    throw;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        //Dashboards

        public decimal GetTotalObligationsByIds(int fundId, int allotmentClassId, int fppId)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@funds_id", DbType.Int32, fundId},
                    new object[] { "@allotment_classes_id", DbType.Int32, allotmentClassId},
                    new object[] { "@fpp_id", DbType.Int32, fppId}
                };

                string query = $"SELECT " +
                    $"COALESCE(SUM(obligation_requested_amount), 0) AS total_obligations " +
                    $"FROM {viewTableName} WHERE " +
                    $"funds_id = @funds_id " +
                    $"AND allotment_classes_id = @allotment_classes_id " +
                    $"AND fpp_id = @fpp_id;";

                return Convert.ToDecimal(_mySqlGenericCommands.ExecuteScalar(query, parameters));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
