using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@searchTxt", DbType.String, $"%{searchText}%"}
                };

                string query = $"SELECT " +
                    $"id, " +
                    $"obligation_no, " +
                    $"payee, " +
                    $"explanation, " +
                    $"reference_no, " +
                    $"date_requested, " +
                    $"created_at, " +
                    $"created_by, " +
                    $"updated_at, " +
                    $"updated_by " +
                    $"FROM " +
                    $"{tableName} " +
                    $"WHERE " +
                    $"obligation_no LIKE @searchTxt " +
                    $"OR payee LIKE @searchTxt " +
                    $"OR explanation LIKE @searchTxt " +
                    $"OR reference_no LIKE @searchTxt OR YEAR(date_requested) LIKE @searchTxt";

                var dataTable = new DataTable();
                return _mySqlGenericCommands.FillBySearch(query, dataTable, parameters);
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

        public Dictionary<string, string> GetViewRecordById(int Id)
        {
            var record = new Dictionary<string, string>();

            var parameters = new object[][]
            {
                new object[] { "@obligation_request_id", DbType.Int32, Id }
            };

            string query = $"SELECT * FROM {viewTableName} WHERE obligation_request_id = @obligation_request_id";

            using (var reader = _mySqlGenericCommands.ExecuteReader(query, parameters))
            {
                if (reader.Rows.Count < 1)
                    return record;

                record.Add("obligation_request_id", reader.Rows[0]["obligation_request_id"].ToString());
                record.Add("obligation_account_id", reader.Rows[0]["obligation_account_id"].ToString());
                record.Add("obligation_no", reader.Rows[0]["obligation_no"].ToString());
                record.Add("payee", reader.Rows[0]["payee"].ToString());
                record.Add("explanation", reader.Rows[0]["explanation"].ToString());
                record.Add("reference_no", reader.Rows[0]["reference_no"].ToString());
                record.Add("date_requested", reader.Rows[0]["date_requested"].ToString());
                record.Add("budget_appropriations_id", reader.Rows[0]["budget_appropriations_id"].ToString());
                record.Add("funds_id", reader.Rows[0]["funds_id"].ToString());
                record.Add("fund_code", reader.Rows[0]["fund_code"].ToString());
                record.Add("fund_name", reader.Rows[0]["fund_name"].ToString());
                record.Add("function_program_project_id", reader.Rows[0]["function_program_project_id"].ToString());
                record.Add("fpp_code", reader.Rows[0]["fpp_code"].ToString());
                record.Add("fpp_name", reader.Rows[0]["fpp_name"].ToString());
                record.Add("others_fpp_id", reader.Rows[0]["others_fpp_id"].ToString());
                record.Add("others_fpp_code", reader.Rows[0]["others_fpp_code"].ToString());
                record.Add("others_fpp_name", reader.Rows[0]["others_fpp_name"].ToString());
                record.Add("allotment_classes_id", reader.Rows[0]["allotment_classes_id"].ToString());
                record.Add("allotment_code", reader.Rows[0]["allotment_code"].ToString());
                record.Add("allotment_name", reader.Rows[0]["allotment_name"].ToString());
                record.Add("general_ledger_accounts_id", reader.Rows[0]["general_ledger_accounts_id"].ToString());
                record.Add("account_code", reader.Rows[0]["account_code"].ToString());
                record.Add("ledger_name", reader.Rows[0]["ledger_name"].ToString());
                record.Add("is_contra_account", reader.Rows[0]["is_contra_account"].ToString());
                record.Add("year", reader.Rows[0]["year"].ToString());
                record.Add("continuing", reader.Rows[0]["continuing"].ToString());
                record.Add("remarks", reader.Rows[0]["remarks"].ToString());
                record.Add("amount", reader.Rows[0]["amount"].ToString());
                record.Add("is_approved", reader.Rows[0]["is_approved"].ToString());
                record.Add("is_disapproved", reader.Rows[0]["is_disapproved"].ToString());
                record.Add("is_cancelled", reader.Rows[0]["is_cancelled"].ToString());
                record.Add("created_at", reader.Rows[0]["created_at"].ToString());
                record.Add("created_by_id", reader.Rows[0]["created_by_id"].ToString());
                record.Add("created_by_full_name", reader.Rows[0]["created_by_full_name"].ToString());
                record.Add("updated_at", reader.Rows[0]["updated_at"].ToString());
                record.Add("updated_by_id", reader.Rows[0]["updated_by_id"].ToString());
                record.Add("updated_by_full_name", reader.Rows[0]["updated_by_full_name"].ToString());
            }

            return record;
        }

        public DataTable GetViewRecordsById(int Id)
        {
            var parameters = new object[][]
           {
                new object[] { "@obligation_request_id", DbType.Int32, Id }
           };

            string query = $"SELECT * FROM {viewTableName} WHERE obligation_request_id = @obligation_request_id";
            var dataTable = new DataTable();
            return _mySqlGenericCommands.FillBySearch(query, dataTable, parameters);
        }

        public DataTable GetViewRecordsByBudgetAppropriationId(int budgetAppropriationId)
        {
            var parameters = new object[][]
            {
                new object[] { "@budget_appropriations_id", DbType.Int32, budgetAppropriationId }
            };

            string query = $"SELECT * FROM {viewTableName} WHERE budget_appropriations_id = @budget_appropriations_id";

            var dtObligationRequests = new DataTable();
            return _mySqlGenericCommands.FillBySearch(query, dtObligationRequests, parameters);
        }

        public DataTable GetViewRecords(int budgetAppropriationId, DateTime dateRequested)
        {
            var parameters = new object[][]
            {
                new object[] { "@budget_appropriations_id", DbType.Int32, budgetAppropriationId },
                new object[] { "@date_requested", DbType.Date, dateRequested.Date}
            };

            string query = $"SELECT * FROM {viewTableName} WHERE budget_appropriations_id = @budget_appropriations_id AND date_requested <= @date_requested";

            var dtObligationRequests = new DataTable();
            return _mySqlGenericCommands.FillBySearch(query, dtObligationRequests, parameters);
        }

        #region DASHBOARD BUDGET
        //DETAILED
        public decimal GetSumObligationsByAppropriationId(int appropriationId, DateTime dateRequested)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@budget_appropriations_id", DbType.Int32, appropriationId},
                    new object[] { "@date_requested", DbType.Date, dateRequested.Date}
                };

                string query = $"SELECT COALESCE(SUM(amount), 0) AS amount " +
                    $"FROM {viewTableName} " +
                    $"WHERE budget_appropriations_id = @budget_appropriations_id AND date_requested <= @date_requested";

                decimal obligations = Convert.ToDecimal(_mySqlGenericCommands.ExecuteScalar(query, parameters));
                return obligations;
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
        //SUMMARY
        public decimal GetSumObligations(string fppId, string subFPPId, int fundId, DateTime dateIssued, int allotmentClassId, byte isContinuing)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@function_program_project_id", DbType.String, fppId },
                    new object[] { "@others_fpp_id", DbType.String, subFPPId},
                    new object[] { "@funds_id", DbType.Int32, fundId },
                    new object[] { "@date_requested", DbType.Date, dateIssued.Date },
                    new object[] { "@allotment_classes_id", DbType.Int32, allotmentClassId},
                    new object[] { "@continuing", DbType.Byte, isContinuing},
                    new object[] { "@year", DbType.Int16, dateIssued.Year}
                };

                string fppWhereQuery = fppId == "all" ? string.Empty : "function_program_project_id = @function_program_project_id AND";
                string isContinuingQuery = isContinuing == 0 ? "year = @year" : "year <= @year";

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
                    $"WHERE " +
                    $"{fppWhereQuery} " +
                    $"{subFPPQuery} " +
                    $"funds_id = @funds_id " +
                    $"AND date_requested <= @date_requested " +
                    $"AND allotment_classes_id = @allotment_classes_id " +
                    $"AND continuing = @continuing " +
                    $"AND {isContinuingQuery}";

                decimal obligations = Convert.ToDecimal(_mySqlGenericCommands.ExecuteScalar(query, parameters));
                return obligations;
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
        #endregion

        private int GetLastInsertedID()
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

                        new object[] { "@obligation_no", DbType.String, entity.ObligationNo },
                        new object[] { "@payee", DbType.String, entity.Payee },
                        new object[] { "@explanation", DbType.String, entity.Explanation },
                        new object[] { "@reference_no", DbType.String, entity.ReferenceNo },
                        new object[] { "@date_requested", DbType.Date, entity.DateRequested.Date },
                        new object[] { "@created_by", DbType.Int32, entity.CreatedBy },
                    };

                    string query = $"INSERT INTO {tableName} " +
                        $"(obligation_no, " +
                        $"payee, " +
                        $"explanation, " +
                        $"reference_no, " +
                        $"date_requested, " +
                        $"created_by) " +
                        $"VALUES " +
                        $"(@obligation_no, " +
                        $"@payee, " +
                        $"@explanation, " +
                        $"@reference_no, " +
                        $"@date_requested, " +
                        $"@created_by)";

                    _ = _mySqlGenericCommands.ExecuteNonQuery(query, parameters);

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
                        new object[] { "@obligation_no", DbType.String, entity.ObligationNo },
                        new object[] { "@payee", DbType.String, entity.Payee },
                        new object[] { "@explanation", DbType.String, entity.Explanation },
                        new object[] { "@reference_no", DbType.String, entity.ReferenceNo },
                        new object[] { "@date_requested", DbType.Date, entity.DateRequested.Date },
                        new object[] { "@updated_by", DbType.Int32, entity.UpdatedBy },
                    };

                    string query = $"UPDATE {tableName} SET obligation_no = @obligation_no, payee = @payee, explanation = @explanation, reference_no = @reference_no, date_requested = @date_requested, updated_by = @updated_by WHERE id = @id";


                    // save and get the last inserted id
                    _ = _mySqlGenericCommands.ExecuteNonQuery(query, parameters);

                    // delete all the obligation accounts first
                    _ = _obligationAccountRepository.DeleteByObligationRequestId(entity.Id);

                    // loop obligation accounts list then insert each using the latest obligation request Id
                    foreach (var obligationAccounts in obligationAccountModels)
                    {
                        obligationAccounts.ObligationRequestId = entity.Id;
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
            catch (Exception)
            {
                throw;
            }
        }

        #region Validations

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

        #endregion

        public bool SetObligationRequestStatus(int obligationId, string status)
        {
            string Status()
            {
                switch (status)
                {
                    case "approve":
                        return "is_approved = 1, is_disapproved = 0, is_cancelled = 0";
                    case "disapprove":
                        return "is_approved = 0, is_disapproved = 1, is_cancelled = 0";
                    case "cancel":
                        return "is_cancelled = 1";
                    default:
                        return "is_cancelled= 0, is_disapproved = 0, is_approved = 0";
                }
            }

            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, obligationId},
            };

            string query = $"UPDATE {tableName} SET {Status()}  WHERE id = @id";

            return _mySqlGenericCommands.ExecuteNonQuery(query, parameters);
        }

        public string GetObligationRequestStatus(int obligationRequestId)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@id", DbType.Int32, obligationRequestId }
                };

                string query = $"SELECT is_approved, is_disapproved, is_cancelled FROM {tableName} WHERE id = @id";

                using (var reader = _mySqlGenericCommands.ExecuteReader(query, parameters))
                {
                    if (reader.Rows.Count < 1)
                        return string.Empty;

                    bool isApproved = Convert.ToBoolean(reader.Rows[0]["is_approved"]);
                    bool isDisapproved = Convert.ToBoolean(reader.Rows[0]["is_disapproved"]);
                    bool isCancelled = Convert.ToBoolean(reader.Rows[0]["is_cancelled"]);


                    if (isCancelled)
                        return "Cancelled";
                    else if (isDisapproved && !isApproved)
                        return "Disapproved";
                    else if (isApproved && !isDisapproved)
                        return "Approved";
                    else if (!isApproved && !isDisapproved && !isCancelled)
                        return "Pending";
                }

            }
            catch (Exception)
            {
                throw;
            }

            return string.Empty;
        }

        public DataTable GetViewRecordsBySearchAndStatus(string searchText, string status, int fundId, int allotmentClassId, DateTime dateOfRequest)
        {

            string Status()
            {
                switch (status)
                {
                    case "approved":
                        return "is_approved = 1 AND is_disapproved = 0 AND is_cancelled = 0 AND";
                    case "disapproved":
                        return "is_approved = 0 AND is_disapproved = 1 AND is_cancelled = 0 AND";
                    case "cancelled":
                        return "is_cancelled = 1 AND";
                    case "pending":
                        return "is_approved  = 0 AND is_disapproved = 0 AND is_cancelled = 0 AND";
                    default:
                        return string.Empty;
                }
            }

            var parameters = new object[][]
            {
                new object[] { "@searchText", DbType.String, $"%{searchText}%" },
                new object[] { "@funds_id", DbType.Int32, fundId},
                new object[] { "@allotment_classes_id", DbType.Int32, allotmentClassId },
                new object[] { "@date_requested", DbType.Date, dateOfRequest.Date}
            };

            string query = $"SELECT * FROM {viewTableName} WHERE funds_id = @funds_id AND allotment_classes_id = @allotment_classes_id AND  date_requested <= @date_requested AND {Status()} (obligation_no LIKE @searchText OR payee LIKE @searchText OR explanation = @searchText OR reference_no LIKE @searchText)";

            var dataTable = new DataTable();

            return _mySqlGenericCommands.FillBySearch(query, dataTable, parameters);
        }
    }
}
