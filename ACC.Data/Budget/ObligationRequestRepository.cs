using ACC.Domain.Budget.Interfaces;
using ACC.Domain.Budget.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Transactions;

namespace ACC.Data.Budget
{
    public class ObligationRequestRepository : IObligationRequestRepository
    {
        private readonly string tableName = "obligation_request";
        private readonly string viewTableName = "view_obligation_request";

        private readonly IObligationAccountRepository obligationAccountRepository;

        private AccGenericCommands mySqlGenericCommandsLFS;

        public ObligationRequestRepository(AccGenericCommands mySqlGenericCommandsLFS, IObligationAccountRepository obligationAccountRepository)
        {
            this.mySqlGenericCommandsLFS = mySqlGenericCommandsLFS;
            this.obligationAccountRepository = obligationAccountRepository;
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            var recordDictionary = new Dictionary<string, string>();

            var parameters = new object[][]
            {
               new object[] { "@id", DbType.Int32, Id}
            };

            string query = $"SELECT * FROM {tableName} WHERE id = @id";

            DataTable dataTable = mySqlGenericCommandsLFS.ExecuteReader(query, parameters);

            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];

                foreach (DataColumn column in dataTable.Columns)
                    recordDictionary[column.ColumnName] = row[column].ToString();

                return recordDictionary;
            }
            return recordDictionary;
        }

        public DataTable GetRecords()
        {
            throw new NotImplementedException();
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            var parameters = new object[][]
            {
                new object[] { "@searchTxt", DbType.String, $"%{searchText}%"}
            };

            string query = $"SELECT id, obligation_no, payee, explanation, reference_no, date_requested, created_at, created_by, updated_at, updated_by FROM {tableName} WHERE obligation_no LIKE @searchTxt OR payee LIKE @searchTxt OR explanation LIKE @searchTxt OR reference_no LIKE @searchTxt OR YEAR(date_requested) LIKE @searchTxt";

            return mySqlGenericCommandsLFS.FillBySearch(query, new DataTable(), parameters);
        }

        public bool IdExist(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(ObligationRequestModel entity)
        {
            object[][] parameters = new object[][]
            {
                new object[] { "@payee", DbType.String, entity.Payee },
                new object[] { "@function_program_project_id", DbType.Int32,entity.FppId },
                new object[] { "@allotment_classes_id", DbType.Int32, entity.AllotmentClassId },
                new object[] { "@funds_id", DbType.Int32, entity.FundId },
                new object[] { "@transaction_no", DbType.String, entity.TransactionNo },
                new object[] { "@explanation", DbType.String, entity.Explanation },
                new object[] { "@reference_no", DbType.String, entity.ReferenceNo },
                new object[] { "@date_requested", DbType.Date, entity.DateRequested.Date },
                new object[] { "@created_by", DbType.Int32, entity.CreatedBy },
            };

            string query = $@"INSERT INTO {tableName}
                            (payee,
                            function_program_project_id,
                            allotment_classes_id,
                            funds_id,
                            transaction_no,
                            explanation,
                            reference_no,
                            date_requested,
                            created_by)
                            VALUES
                            (@payee,
                            @function_program_project_id,
                            @allotment_classes_id,
                            @funds_id,
                            @transaction_no,
                            @explanation,
                            @reference_no,
                            @date_requested,
                            @created_by)";

            return mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
        }

        public bool Delete(List<ObligationRequestModel> entityList)
        {
            using (var scope = new TransactionScope())
            {
                foreach (var model in entityList)
                {
                    _ = DeleteById(model.Id);
                }

                scope.Complete();
                return true;
            }
        }

        public bool DeleteById(int obligationRequestId)
        {
            using (var scope = new TransactionScope())
            {
                obligationAccountRepository.DeleteByOblgtnId(obligationRequestId);

                var parameters = new object[][]
                {
                    new object[] { "@id", DbType.Int32, obligationRequestId}
                };

                string query = $"DELETE FROM {tableName} WHERE id = @id";

                _ = mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);

                scope.Complete();
                return true;
            }
        }

        public bool Update(ObligationRequestModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@id",DbType.Int32, entity.Id},
                new object[] { "@function_program_project_id", DbType.Int32,entity.FppId },
                new object[] { "@allotment_classes_id", DbType.Int32, entity.AllotmentClassId },
                new object[] { "@funds_id", DbType.Int32, entity.FundId },
                new object[] { "@payee", DbType.String, entity.Payee },
                new object[] { "@reference_no", DbType.String, entity.ReferenceNo },
                new object[] { "@explanation", DbType.String, entity.Explanation },
                new object[] { "@date_requested", DbType.Date, entity.DateRequested.Date },
                new object[] { "@updated_by", DbType.Int32, entity.UpdatedBy },
            };

            string query = $@"UPDATE {tableName} SET
                            function_program_project_id = @function_program_project_id,
                            allotment_classes_id = @allotment_classes_id,
                            funds_id = @funds_id,
                            payee = @payee,
                            explanation = @explanation,
                            reference_no = @reference_no,
                            date_requested = @date_requested,
                            updated_by = @updated_by WHERE id = @id";

            return mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
        }

        public Dictionary<string, string> GetViewRecordById(int Id)
        {
            var recordDictionary = new Dictionary<string, string>();

            var parameters = new object[][]
            {
                new object[] { "@obligation_request_id", DbType.Int32, Id }
            };

            string query = $"SELECT * FROM {viewTableName} WHERE obligation_request_id = @obligation_request_id";

            DataTable dataTable = mySqlGenericCommandsLFS.ExecuteReader(query, parameters);

            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];

                foreach (DataColumn column in dataTable.Columns)
                    recordDictionary[column.ColumnName] = row[column].ToString();

                return recordDictionary;
            }
            return recordDictionary;
        }

        public DataTable GetViewRecordsById(int Id)
        {
            var parameters = new object[][]
           {
                new object[] { "@obligation_request_id", DbType.Int32, Id }
           };

            string query = $"SELECT * FROM {viewTableName} WHERE obligation_request_id = @obligation_request_id";
            var dataTable = new DataTable();
            return mySqlGenericCommandsLFS.FillBySearch(query, dataTable, parameters);
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
            return mySqlGenericCommandsLFS.FillBySearch(query, dtObligationRequests, parameters);
        }

        public decimal GetSumObligationsByAppropriationId(int appropriationId, DateTime dateRequested)
        {
            var parameters = new object[][]
            {
                new object[] { "@budget_appropriations_id", DbType.Int32, appropriationId},
                new object[] { "@date_requested", DbType.Date, dateRequested.Date}
            };

            string query = $"SELECT COALESCE(SUM(amount), 0) AS amount FROM {viewTableName} WHERE budget_appropriations_id = @budget_appropriations_id AND date_requested <= @date_requested AND is_cancelled = 0";

            return Convert.ToDecimal(mySqlGenericCommandsLFS.ExecuteScalar(query, parameters));
        }

        public decimal GetSumObligations(string fppId, string subFPPId, int fundId, DateTime dateIssued, int allotmentClassId, byte isContinuing)
        {
            var parameters = new object[][]
            {
                new object[] { "@function_program_project_id", DbType.String, fppId },
                new object[] { "@others_fpp_id", DbType.String, subFPPId},
                new object[] { "@funds_id", DbType.Int32, fundId },
                new object[] { "@date_requested", DbType.Date, dateIssued.Date },
                new object[] { "@allotment_class_id", DbType.Int32, allotmentClassId},
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

            string query = $@"SELECT COALESCE(SUM(amount), 0) AS amount FROM {viewTableName}
                            WHERE
                            {fppWhereQuery}
                            {subFPPQuery}
                            funds_id = @funds_id
                            AND date_requested <= @date_requested
                            AND allotment_class_id = @allotment_class_id
                            AND continuing = @continuing
                            AND {isContinuingQuery}
                            AND is_cancelled = 0";

            return Convert.ToDecimal(mySqlGenericCommandsLFS.ExecuteScalar(query, parameters));
        }

        private int GetLastInsertedId(int createdById)
        {
            var parameters = new object[][]
            {
                new object[]{ "@created_by", DbType.Int32, createdById}
            };

            string query = $"SELECT MAX(id) FROM {tableName} WHERE created_by = @created_by";
            return int.Parse(mySqlGenericCommandsLFS.ExecuteScalar(query, parameters));
        }

        public bool Insert(ObligationRequestModel entity, List<ObligationAccountModel> obligationAccountModels)
        {
            using (var scope = new TransactionScope())
            {
                _ = Insert(entity);
                int lstInsrtdId = GetLastInsertedId(entity.CreatedBy);

                foreach (var obligationAccounts in obligationAccountModels)
                {
                    obligationAccounts.ObligationRequestId = lstInsrtdId;
                    _ = obligationAccountRepository.Insert(obligationAccounts);
                }

                scope.Complete();
                return true;
            }
        }

        public bool Update(ObligationRequestModel entity, List<ObligationAccountModel> obligationAccountModels)
        {
            using (var scope = new TransactionScope())
            {
                _ = Update(entity);
                _ = obligationAccountRepository.DeleteByOblgtnId(entity.Id);

                foreach (var obligationAccounts in obligationAccountModels)
                {
                    obligationAccounts.ObligationRequestId = entity.Id;
                    _ = obligationAccountRepository.Insert(obligationAccounts);
                }

                scope.Complete();
                return true;
            }
        }

        public bool ObligationRequestNoExist(string obligationNo)
        {
            var parameters = new object[][]
            {
                new object[] { "@obligation_no", DbType.String, obligationNo }
            };

            string query = $"SELECT id FROM {tableName} WHERE obligation_no = @obligation_no";

            return !string.IsNullOrEmpty(mySqlGenericCommandsLFS.ExecuteScalar(query, parameters));
        }

        public bool ObligationRequestNoExist(int Id, string obligationNo)
        {
            var parameters = new object[][]
            {
                new object[] { "@id",DbType.Int32, Id },
                new object[] { "@obligation_no", DbType.String, obligationNo }
            };

            string query = $"SELECT id FROM {tableName} WHERE id <> @id AND obligation_no = @obligation_no";

            return !string.IsNullOrEmpty(mySqlGenericCommandsLFS.ExecuteScalar(query, parameters));
        }

        public bool SetObligationRequestStatus(int obligationRequestId, string status, string disapprovalMessage = null)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, obligationRequestId},
                new object[] { "@disapproval_message", DbType.String, disapprovalMessage}
            };

            string Status()
            {
                switch (status)
                {
                    case "approve":
                        return "is_approved = 1, is_disapproved = 0, is_cancelled = 0";

                    case "disapprove":
                        return "is_approved = 0, is_disapproved = 1, is_cancelled = 0 , disapproval_message = @disapproval_message";

                    case "cancel":
                        return "is_cancelled = 1";

                    case "pending":
                        return "is_cancelled= 0, is_disapproved = 0, is_approved = 0";

                    default:
                        return "is_cancelled= 0, is_disapproved = 0, is_approved = 0";
                }
            }

            string query = $"UPDATE {tableName} SET {Status()}  WHERE id = @id";

            return mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
        }

        public string GetObligationRequestStatus(int obligationRequestId)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, obligationRequestId }
            };

            string query = $"SELECT is_approved, is_disapproved, is_cancelled FROM {tableName} WHERE id = @id";

            using (var reader = mySqlGenericCommandsLFS.ExecuteReader(query, parameters))
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
                new object[] { "@allotment_class_id", DbType.Int32, allotmentClassId },
                new object[] { "@date_requested", DbType.Date, dateOfRequest.Date}
            };

            string query = $@"SELECT * FROM {viewTableName}
                            WHERE funds_id = @funds_id
                            AND allotment_class_id = @allotment_class_id
                            AND  date_requested <= @date_requested
                            AND YEAR(date_requested) = YEAR(@date_requested)
                            AND {Status()}
                            (obligation_no LIKE @searchText
                                OR payee LIKE @searchText
                                OR explanation = @searchText
                                OR reference_no LIKE @searchText)
                            GROUP BY obligation_request_id
                            ORDER BY obligation_no";

            return mySqlGenericCommandsLFS.FillBySearch(query, new DataTable(), parameters);
        }

        public decimal GetSumObligationsById(int obligationRequestId)
        {
            var parameters = new object[][]
            {
                new object[] {"@obligation_request_id", DbType.Int32, obligationRequestId}
            };

            string query = $"SELECT COALESCE(SUM(amount), 0) FROM {viewTableName} WHERE obligation_request_id = @obligation_request_id";

            return Convert.ToDecimal(mySqlGenericCommandsLFS.ExecuteScalar(query, parameters));
        }

        public decimal GetSumObligationsByBudgetAppropriationAndStatus(int budgetAppropriationId)
        {
            var parameters = new object[][]
            {
                new object[] { "@budget_appropriations_id", DbType.Int32, budgetAppropriationId }
            };

            string query = $"SELECT COALESCE(SUM(amount), 0) FROM {viewTableName} WHERE budget_appropriations_id = @budget_appropriations_id AND is_cancelled = 0";

            return Convert.ToDecimal(mySqlGenericCommandsLFS.ExecuteScalar(query, parameters));
        }

        public string GetLeastOblgtnNo()
        {
            string query = $"SELECT COALESCE(LPAD(MAX(obligation_no)+1, 4, '0'),'0001') AS obligation_no FROM {viewTableName}";
            return mySqlGenericCommandsLFS.ExecuteScalar(query);
        }

        public DataTable GetRecords(string srchKey, string status, DateTime dtFrom, DateTime dtTo, int rowLimit)
        {
            var parameters = new object[][]
            {
                new object[] {"@search_key", DbType.String, $"%{srchKey}%"},
                new object[] {"@status", DbType.String, status},
                new object[] {"@dt_from", DbType.DateTime, dtFrom.Date},
                new object[] {"@dt_to", DbType.DateTime, dtTo.Date},
                new object[] {"@row_limit", DbType.Int32, rowLimit},
            };

            string statusQuery;

            switch (status)
            {
                case "pending":
                    statusQuery = $"is_approved = 0 AND is_disapproved = 0 AND is_cancelled = 0 AND ";
                    break;

                case "approved":
                    statusQuery = $"is_approved = 1 AND is_disapproved = 0 AND is_cancelled = 0 AND ";
                    break;

                case "disapproved":
                    statusQuery = $"is_approved = 0 AND is_disapproved = 1 AND is_cancelled = 0 AND ";
                    break;

                case "cancelled":
                    statusQuery = $"is_cancelled = 1 AND ";
                    break;

                default:
                    statusQuery = string.Empty;
                    break;
            }

            string query = $@"SELECT * FROM {tableName}
                                WHERE {statusQuery}
                                (obligation_no LIKE @search_key OR payee LIKE @search_key) AND
                                (date_requested >= @dt_from AND date_requested <= @dt_to) LIMIT @row_limit";

            return mySqlGenericCommandsLFS.FillBySearch(query, new DataTable(), parameters);
        }

        public string GetTransactionNo(int year)
        {
            var parameters = new object[][]
            {
                new object[] {"@year", DbType.Int32, year},
            };

            string query = $@"SELECT
                                 LPAD(COALESCE(MAX(CAST(SUBSTRING_INDEX(transaction_no, '-', - 1) AS UNSIGNED)), 0) + 1, 4, '0') AS next_seq
                            FROM
                                {tableName}
                            WHERE
                               transaction_no REGEXP CONCAT('^', @year, '-')";

            string seqNo = mySqlGenericCommandsLFS.ExecuteScalar(query, parameters);
            return $"{year}-{seqNo}";
        }
    }
}