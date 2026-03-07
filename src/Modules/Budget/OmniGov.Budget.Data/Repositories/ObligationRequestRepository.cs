using OmniGov.Budget.Domain.Entities;
using OmniGov.Budget.Domain.Interfaces;
using OmniGov.Core.Interfaces.Services;
    using System.Collections.Generic;
using System.Data;
using System.Transactions;

namespace OmniGov.Budget.Data.Repositories
{
    public class ObligationRequestRepository : IObligationRequestRepository
    {
        private readonly string tableName = "obligation_request";
        private readonly string viewTableName = "view_obligation_request";

        private readonly IObligationAccountRepository obligationAccountRepository;

        private IGenericCommands _genericCommands;

        public ObligationRequestRepository(IGenericCommands genericCommands,
                                           IObligationAccountRepository obligationAccountRepository)
        {
            _genericCommands = genericCommands;
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

            DataTable dataTable = _genericCommands.ExecuteReader(query, parameters);

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

            return _genericCommands.FillBySearch(query, new DataTable(), parameters);
        }

        public bool IdExist(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(ObligationRequestModel entity)
        {
            int id = InsertGetId(entity);
            if (id > 0)
            {
                entity.Id = id;
                return true;
            }
            return false;
        }

        private int InsertGetId(ObligationRequestModel entity)
        {
            if (string.IsNullOrWhiteSpace(entity.TransactionNo))
                entity.TransactionNo = GetTransactionNo(entity.DateRequested.Year);

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
                new object[] { "@status", DbType.String, entity.ObligationStatus.ToString() },
                new object[] { "@remarks", DbType.String, entity.Remarks },
                new object[] { "@created_by", DbType.Int32, entity.CreatedBy },
            };

            string query = $@"INSERT INTO {tableName} (payee, function_program_project_id, allotment_classes_id, funds_id, transaction_no, explanation, reference_no, date_requested, status, remarks, created_by) VALUES (@payee, @function_program_project_id, @allotment_classes_id, @funds_id, @transaction_no, @explanation, @reference_no, @date_requested, @status, @remarks, @created_by)";
            return _genericCommands.ExecuteNonQueryId(query, parameters);
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

                _ = _genericCommands.ExecuteNonQuery(query, parameters);

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
                new object[] { "@status", DbType.String, entity.ObligationStatus.ToString() },
                new object[] { "@date_requested", DbType.Date, entity.DateRequested.Date },
                new object[] { "@updated_by", DbType.Int32, entity.UpdatedBy },
            };

            //set remarks back to null when updating a record
            string query = $@"UPDATE {tableName} SET
                            function_program_project_id = @function_program_project_id,
                            allotment_classes_id = @allotment_classes_id,
                            funds_id = @funds_id,
                            payee = @payee,
                            explanation = @explanation,
                            reference_no = @reference_no,
                            date_requested = @date_requested,
                            status = @status,
                            remarks = NULL,
                            updated_by = @updated_by WHERE id = @id";

            return _genericCommands.ExecuteNonQuery(query, parameters);
        }

        public Dictionary<string, string> GetViewRecordById(int Id)
        {
            var recordDictionary = new Dictionary<string, string>();

            var parameters = new object[][]
            {
                new object[] { "@obligation_request_id", DbType.Int32, Id }
            };

            string query = $"SELECT * FROM {viewTableName} WHERE obligation_request_id = @obligation_request_id";

            DataTable dataTable = _genericCommands.ExecuteReader(query, parameters);

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
            return _genericCommands.FillBySearch(query, dataTable, parameters);
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
            return _genericCommands.FillBySearch(query, dtObligationRequests, parameters);
        }

        public decimal GetSumObligationsByAppropriationId(int appropriationId, DateTime dateRequested)
        {
            var parameters = new object[][]
            {
                new object[] { "@budget_appropriations_id", DbType.Int32, appropriationId},
                new object[] { "@date_requested", DbType.Date, dateRequested.Date}
            };

            string query = $"SELECT COALESCE(SUM(amount), 0) AS amount FROM {viewTableName} WHERE budget_appropriations_id = @budget_appropriations_id AND date_requested <= @date_requested AND status != 'cancelled'";

            return Convert.ToDecimal(_genericCommands.ExecuteScalar(query, parameters));
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
                            AND status != 'cancelled'";

            return Convert.ToDecimal(_genericCommands.ExecuteScalar(query, parameters));
        }


        public bool Insert(ObligationRequestModel entity, List<ObligationAccountModel> obligationAccountModels)
        {
            using (var scope = new TransactionScope())
            {
                int lstInsrtdId = InsertGetId(entity);
                if (lstInsrtdId == 0) return false;

                foreach (var obligationAccounts in obligationAccountModels)
                {
                    obligationAccounts.ObligationRequestId = lstInsrtdId;
                    if (!obligationAccountRepository.Insert(obligationAccounts)) return false;
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

        public DataTable GetViewRecordsBySearchAndStatus(string searchText, ObligationRequestModel.Status status, int fundId, int allotmentClassId, DateTime dateOfRequest)
        {
            string Status()
            {
                switch (status)
                {
                    case ObligationRequestModel.Status.approved:
                        return "status = 'approved' AND";

                    case ObligationRequestModel.Status.disapproved:
                        return "status = 'disapproved' AND";

                    case ObligationRequestModel.Status.cancelled:
                        return "status = 'cancelled' AND";

                    case ObligationRequestModel.Status.pending:
                        return "status = 'pending' AND";

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

            return _genericCommands.FillBySearch(query, new DataTable(), parameters);
        }

        public decimal GetSumObligationsByBudgetAppropriationAndStatus(int budgetAppropriationId)
        {
            var parameters = new object[][]
            {
                new object[] { "@budget_appropriations_id", DbType.Int32, budgetAppropriationId }
            };

            string query = $"SELECT COALESCE(SUM(amount), 0) FROM {viewTableName} WHERE budget_appropriations_id = @budget_appropriations_id AND status != 'cancelled'";

            return Convert.ToDecimal(_genericCommands.ExecuteScalar(query, parameters));
        }

        public DataTable GetRecords(string srchKey, ObligationRequestModel.Status status, DateTime dtFrom, DateTime dtTo, int rowLimit)
        {
            var parameters = new object[][]
            {
                new object[] {"@search_key", DbType.String, $"%{srchKey}%"},
                new object[] {"@status", DbType.String, status.ToString()},
                new object[] {"@dt_from", DbType.DateTime, dtFrom.Date},
                new object[] {"@dt_to", DbType.DateTime, dtTo.Date},
                new object[] {"@row_limit", DbType.Int32, rowLimit},
            };

            string query = $@"SELECT * FROM {tableName}
                                WHERE status = @status AND
                                (obligation_no LIKE @search_key OR payee LIKE @search_key) AND
                                (date_requested >= @dt_from AND date_requested <= @dt_to) LIMIT @row_limit";

            return _genericCommands.FillBySearch(query, new DataTable(), parameters);
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

            string seqNo = _genericCommands.ExecuteScalar(query, parameters);
            return $"{year}-{seqNo}";
        }

        public bool SetStatus(int id, ObligationRequestModel.Status status, string? remarks)
        {
            object? obligationNo = null;
            if (status == ObligationRequestModel.Status.approved)
            {
                var record = GetRecordByID(id);
                if (record.ContainsKey("funds_id"))
                {
                    int fundId = int.Parse(record["funds_id"]);
                    obligationNo = GetLastObligationNoSeries(fundId);
                }
            }

            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, id },
                new object[] { "@obligation_no", DbType.String, obligationNo ?? (object)DBNull.Value },
                new object[] { "@remarks", DbType.String, remarks ?? (object)DBNull.Value },
                new object[] { "@status", DbType.String, status.ToString() }
            };

            string query = $@"UPDATE {tableName} SET 
                            obligation_no = @obligation_no, 
                            status = @status, 
                            remarks = @remarks 
                            WHERE id = @id";

            bool result;
            using (var scope = new TransactionScope())
            {
                result = _genericCommands.ExecuteNonQuery(query, parameters);
                scope.Complete();
            }

            return result;
        }

        private string GetLastObligationNoSeries(int fundId)
        {
            var parameters = new object[][]
            {
                new object[] { "@funds_id", DbType.Int32, fundId }
            };

            // Simplified version based on JEV pattern - incrementing a sequence
            // In a real scenario, this might include year/month from the record
            string query = $"SELECT COALESCE(LPAD(MAX(CAST(SUBSTRING_INDEX(obligation_no, '-', -1) AS UNSIGNED)) + 1, 4, '0'), '0001') FROM {tableName} WHERE funds_id = @funds_id";
            string seq = _genericCommands.ExecuteScalar(query, parameters);
            
            // Note: In production, you'd concat with prefixes (e.g., 01-2026-02-0001)
            // But without the full business rule for prefix, I'll return the sequence for now
            // or try to match the ucObligations template if I can.
            return seq;
        }
    }
}