using MySql.Data.MySqlClient;
using OmniGov.Accounting.Domain.Entities;
using OmniGov.Accounting.Domain.Interfaces;
using OmniGov.Core.Interfaces.Services;
using System.Data;
using System.Transactions;

namespace OmniGov.Accounting.Data.Repositories
{
    public class JevRepository : IJevRepository
    {
        private readonly IJevAccountsRepository _jevAccountsRepository;
        private readonly IGeneralJournalRepository _generalJournalRepository;
        private readonly ICashDisbursementsJournalRepository _cashDisbursementsJournalRepository;
        private readonly ICheckDisbursementsJournalRepository _checkDisbursementsJournalRepository;
        private readonly ICashReceiptsJournalRepository _cashReceiptsJournalRepository;
        private readonly IAdaDisbursementsJournalRepository _adaDisbursementsJournalRepository;

        private readonly IGenericCommands _genericCommands;
        private const string tableName = "jev";
        private const string viewTableName = "view_jev";

        public JevRepository(IGenericCommands genericCommands,
            IJevAccountsRepository jevAccountsRepository,
            ICheckDisbursementsJournalRepository checkDisbursementsJournalRepository,
            ICashReceiptsJournalRepository cashReceiptsJournalRepository,
            IAdaDisbursementsJournalRepository adaDisbursementsJournalRepository,
            ICashDisbursementsJournalRepository cashDisbursementsJournalRepository,
            IGeneralJournalRepository generalJournalRepository)
        {
            _genericCommands = genericCommands ?? throw new ArgumentNullException(nameof(genericCommands));
            _jevAccountsRepository = jevAccountsRepository ?? throw new ArgumentNullException(nameof(jevAccountsRepository));
            _checkDisbursementsJournalRepository = checkDisbursementsJournalRepository ?? throw new ArgumentNullException(nameof(checkDisbursementsJournalRepository));
            _cashReceiptsJournalRepository = cashReceiptsJournalRepository ?? throw new ArgumentNullException(nameof(cashReceiptsJournalRepository));
            _adaDisbursementsJournalRepository = adaDisbursementsJournalRepository ?? throw new ArgumentNullException(nameof(adaDisbursementsJournalRepository));
            _cashDisbursementsJournalRepository = cashDisbursementsJournalRepository ?? throw new ArgumentNullException(nameof(cashDisbursementsJournalRepository));
            _generalJournalRepository = generalJournalRepository ?? throw new ArgumentNullException(nameof(generalJournalRepository));
        }

        public bool Delete(List<JevModel> entityList)
        {
            using (var scope = new TransactionScope())
            {
                foreach (JevModel jevModel in entityList)
                {
                    _ = _jevAccountsRepository.DeleteByJevId(jevModel.Id);
                    _ = _generalJournalRepository.DeleteByJevId(jevModel.Id);
                    _ = _cashReceiptsJournalRepository.DeleteByJevId(jevModel.Id);
                    _ = _cashDisbursementsJournalRepository.DeleteByJevId(jevModel.Id);
                    _ = _checkDisbursementsJournalRepository.DeleteByJevId(jevModel.Id);
                    _ = _adaDisbursementsJournalRepository.DeleteByJevId(jevModel.Id);
                    _ = Delete(jevModel);
                }

                scope.Complete();
                return true;
            }
        }

        public bool Delete(JevModel entity)
        {
            var parameters = new MySqlParameter[]
            {
                new("@id", entity.Id)
            };

            string query = $"DELETE FROM {tableName} WHERE id = @id";
            return _genericCommands.ExecuteNonQuery(query, parameters);
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            var recordDictionary = new Dictionary<string, string>();

            var parameters = new MySqlParameter[]
            {
                new("@id", Id)
            };

            string query = $"SELECT id, funds_id, fund_code, fund_name, journals_id, journal_name, is_special, transaction_no, jev_no, date_entry, ref_no, payee, explanation, status, created_at, created_by, created_by_name, updated_at, updated_by, updated_by_name FROM {viewTableName} WHERE id = @id";

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
            string query = $"SELECT * FROM {tableName}";
            return _genericCommands.Fill(query, new DataTable());
        }

        public DataTable GetRecordsByJevNoAndDate(string searchText, sbyte month, ushort year, byte journalId)
        {
            var parameters = new MySqlParameter[]
            {
                new ("@jev_no", $"%{searchText}%"),
                new ("@month", month),
                new ("@year", year),
                new ("@journalId", journalId)
            };

            string query = $@"SELECT * FROM {viewTableName}
                            WHERE MONTH(date_entry) = @month AND YEAR(date_entry) = @year AND journals_id = @journalId AND status='approved' AND jev_no LIKE @jev_no";

            return _genericCommands.FillBySearch(query, new DataTable(), parameters);
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            var parameters = new MySqlParameter[]
            {
                new ("@jev_no", $"%{searchText}%"),
                new ("@ref_no", $"%{searchText}%"),
                new ("@payee", $"%{searchText}%"),
                new ("@explanation", $"%{searchText}%")
            };

            string query = $"SELECT * FROM {viewTableName} WHERE status = 'approved'AND (jev_no LIKE @jev_no OR ref_no LIKE @ref_no OR payee LIKE @payee OR explanation LIKE @explanation)";

            return _genericCommands.FillBySearch(query, new DataTable(), parameters);
        }

        public bool IdExist(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(JevModel entity)
        {
            var parameters = new MySqlParameter[]
            {
               new ("@funds_id", entity.FundsId),
               new ("@journals_id", entity.JournalsId),
               new ("@transaction_no", entity.TransactionNo),
               new ("@jev_no", entity.JevNo),
               new ("@date_entry", entity.DateEntry),
               new ("@ref_no", entity.RefNo),
               new ("@payee", entity.Payee),
               new ("@explanation", entity.Explanation),
               new ("@status", entity.JevStatus.ToString()),
               new ("@created_by", entity.CreatedBy)
            };

            string query = $"INSERT INTO {tableName} (funds_id, journals_id, transaction_no, jev_no, date_entry, ref_no, payee, explanation, status, created_by) VALUES (@funds_id, @journals_id, @transaction_no, @jev_no, @date_entry, @ref_no, @payee, @explanation, @status, @created_by);";

            return _genericCommands.ExecuteNonQuery(query, parameters);
        }

        public int GetLastInsertedID()
        {
            string query = $"SELECT MAX(id) FROM {tableName}";
            return int.Parse(_genericCommands.ExecuteScalar(query));
        }

        public bool InsertGeneralJournalEntry(JevModel entity,
                                              List<JEVAccountsModel> jevAccountsModelList,
                                              GeneralJournalModel generalJournalModel)
        {
            using (var scope = new TransactionScope())
            {
                _ = Insert(entity);
                var lstInsrtId = GetLastInsertedID();

                jevAccountsModelList.ForEach(x => x.JEVId = lstInsrtId);
                _ = _jevAccountsRepository.BulkInsert(jevAccountsModelList);

                generalJournalModel.JevId = GetLastInsertedID();
                _ = _generalJournalRepository.Insert(generalJournalModel);

                scope.Complete();
                return true;
            }
        }

        public bool InsertCashDisbursementsJournalEntry(JevModel entity,
                                               List<JEVAccountsModel> jevAccountsModelList,
                                               CashDisbursementsJournalModel cashDisbursementsJournalModel)
        {
            using (var scope = new TransactionScope())
            {
                _ = Insert(entity);
                var lstInsrtId = GetLastInsertedID();

                jevAccountsModelList.ForEach(x => x.JEVId = lstInsrtId);
                _ = _jevAccountsRepository.BulkInsert(jevAccountsModelList);

                cashDisbursementsJournalModel.JevId = GetLastInsertedID();
                _ = _cashDisbursementsJournalRepository.Insert(cashDisbursementsJournalModel);

                scope.Complete();
                return true;
            }
        }

        public bool InsertCheckDisbursementsJournalEntry(JevModel jevModel,
                                                List<JEVAccountsModel> jevAccountsModelList,
                                                CheckDisbursementsJournalModel checkDisbursementsJournalModel)
        {
            using (var scope = new TransactionScope())
            {
                _ = Insert(jevModel);
                var lstInsrtId = GetLastInsertedID();

                jevAccountsModelList.ForEach(x => x.JEVId = lstInsrtId);
                _ = _jevAccountsRepository.BulkInsert(jevAccountsModelList);

                checkDisbursementsJournalModel.JevId = GetLastInsertedID();
                _checkDisbursementsJournalRepository.Insert(checkDisbursementsJournalModel);

                scope.Complete();
                return true;
            }
        }

        public bool InsertCashReceiptsJournalEntry(JevModel entity,
                                           List<JEVAccountsModel> jevAccountsModelList,
                                           CashReceiptsJournalModel cashReceiptsJournalModel)
        {
            using (var scope = new TransactionScope())
            {
                _ = Insert(entity);
                var lstInsrtId = GetLastInsertedID();

                jevAccountsModelList.ForEach(x => x.JEVId = lstInsrtId);
                _ = _jevAccountsRepository.BulkInsert(jevAccountsModelList);

                cashReceiptsJournalModel.JevId = lstInsrtId;
                _ = _cashReceiptsJournalRepository.Insert(cashReceiptsJournalModel);

                scope.Complete();
                return true;
            }
        }

        public bool InsertADADisbursementsJournalEntry(JevModel entity,
                                               List<JEVAccountsModel> jevAccountsModelList,
                                               ADADisbursementsJournalModel aDADisbursementsJournalModel)
        {
            using (var scope = new TransactionScope())
            {
                _ = Insert(entity);
                var lstInsrtId = GetLastInsertedID();

                jevAccountsModelList.ForEach(x => x.JEVId = lstInsrtId);
                _ = _jevAccountsRepository.BulkInsert(jevAccountsModelList);

                aDADisbursementsJournalModel.JevId = GetLastInsertedID();
                _ = _adaDisbursementsJournalRepository.Insert(aDADisbursementsJournalModel);

                scope.Complete();
                return true;
            }
        }

        public bool InsertProcurementReceivedJournalEntry(JevModel entity, List<JEVAccountsModel> jevAccountsModels)
        {
            using (var scope = new TransactionScope())
            {
                _ = Insert(entity);
                var lstInsrtId = GetLastInsertedID();

                jevAccountsModels.ForEach(x => x.JEVId = lstInsrtId);
                _ = _jevAccountsRepository.BulkInsert(jevAccountsModels);

                scope.Complete();
                return true;
            }
        }

        public bool DeletePrevJournals(int jevId, string journalName)
        {
            switch (journalName)
            {
                case "General Journal":
                    return _generalJournalRepository.DeleteByJevId(jevId);

                case "Cash Receipts Journal":
                    return _cashReceiptsJournalRepository.DeleteByJevId(jevId);

                case "Cash Disbursements Journal":
                    return _cashDisbursementsJournalRepository.DeleteByJevId(jevId);

                case "Check Disbursements Journal":
                    return _checkDisbursementsJournalRepository.DeleteByJevId(jevId);

                case "Authority to Debit Account Disbursement Journal":
                    return _adaDisbursementsJournalRepository.DeleteByJevId(jevId);

                default:
                    return false;
            }
        }

        public bool Update(JevModel entity)
        {
            var parameters = new MySqlParameter[]
            {
                new("@id", entity.Id),
                new("@funds_id", entity.FundsId),
                new("@journals_id", entity.JournalsId),
                new("@transaction_no", entity.TransactionNo),
                new("@jev_no", entity.JevNo),
                new("@date_entry", entity.DateEntry),
                new("@ref_no", entity.RefNo),
                new("@payee", entity.Payee),
                new("@explanation", entity.Explanation),
                new("@status", entity.JevStatus.ToString()),
                new("@updated_by", entity.UpdatedBy),
                new("@is_edited", entity.IsEdited),
                new("@remarks", entity.Remarks)
            };

            string query = $@"UPDATE {tableName} SET
                                                funds_id = @funds_id,
                                                journals_id = @journals_id,
                                                transaction_no = @transaction_no,
                                                jev_no = @jev_no,
                                                date_entry = @date_entry,
                                                ref_no = @ref_no,
                                                payee = @payee,
                                                explanation = @explanation,
                                                status = @status,
                                                updated_by = @updated_by,
                                                is_edited = @is_edited,
                                                remarks = @remarks
                                                WHERE
                                                id = @id";

            return _genericCommands.ExecuteNonQuery(query, parameters);
        }

        public bool UpdateGeneralJournalEntry(JevModel currentJev,
                                    (int jrnlId, string jrnlName) prevJournal,
                                    List<JEVAccountsModel> jevAccountsModelList,
                                    GeneralJournalModel generalJournalModel)
        {
            using (var scope = new TransactionScope())
            {
                _ = Update(currentJev);
                _ = SetJevStatus(currentJev.Id, JevModel.Status.pending, null);

                _ = _jevAccountsRepository.DeleteByJevId(currentJev.Id);
                jevAccountsModelList.ForEach(x => x.JEVId = currentJev.Id);
                _ = _jevAccountsRepository.BulkInsert(jevAccountsModelList);

                if (currentJev.JournalsId != prevJournal.jrnlId)
                {
                    _ = DeletePrevJournals(prevJournal.jrnlId, prevJournal.jrnlName);
                    _ = _generalJournalRepository.Insert(generalJournalModel);
                }
                else
                    _ = _generalJournalRepository.UpdateByJevId(generalJournalModel);

                scope.Complete();
                return true;
            }
        }

        public bool UpdateCheckDisbursementsJournalEntry(JevModel currentJev,
                                            (int jrnlId, string jrnlName) prevJournal,
                                            List<JEVAccountsModel> jevAccountsModelList,
                                            CheckDisbursementsJournalModel checkDisbursementsJournalModel)
        {
            using (var scope = new TransactionScope())
            {
                _ = Update(currentJev);
                _ = SetJevStatus(currentJev.Id, JevModel.Status.pending, null);

                _ = _jevAccountsRepository.DeleteByJevId(currentJev.Id);
                jevAccountsModelList.ForEach(x => x.JEVId = currentJev.Id);
                _ = _jevAccountsRepository.BulkInsert(jevAccountsModelList);

                if (currentJev.JournalsId != prevJournal.jrnlId)
                {
                    _ = DeletePrevJournals(prevJournal.jrnlId, prevJournal.jrnlName);
                    _ = _checkDisbursementsJournalRepository.Insert(checkDisbursementsJournalModel);
                }
                else
                    _checkDisbursementsJournalRepository.UpdateByJevID(checkDisbursementsJournalModel);

                scope.Complete();
                return true;
            }
        }

        public bool UpdateCashDisbursementsJournalEntry(JevModel currentJev,
                                            (int jrnlId, string jrnlName) prevJournal,
                                            List<JEVAccountsModel> jevAccountsModelList,
                                            CashDisbursementsJournalModel cashDisbursementsJournalModel)
        {
            using (var scope = new TransactionScope())
            {
                _ = Update(currentJev);
                _ = SetJevStatus(currentJev.Id, JevModel.Status.pending, null);

                _ = _jevAccountsRepository.DeleteByJevId(currentJev.Id);
                jevAccountsModelList.ForEach(x => x.JEVId = currentJev.Id);
                _ = _jevAccountsRepository.BulkInsert(jevAccountsModelList);

                if (currentJev.JournalsId != prevJournal.jrnlId)
                {
                    _ = DeletePrevJournals(prevJournal.jrnlId, prevJournal.jrnlName);
                    _ = _cashDisbursementsJournalRepository.Insert(cashDisbursementsJournalModel);
                }
                else
                    _ = _cashDisbursementsJournalRepository.UpdateByJevId(cashDisbursementsJournalModel);

                scope.Complete();
                return true;
            }
        }

        public bool UpdateCashReceiptsJournalEntry(JevModel currentJev,
                                        (int jrnlId, string jrnlName) prevJournal,
                                        List<JEVAccountsModel> jevAccountsModelList,
                                        CashReceiptsJournalModel cashReceiptsJournalModel)
        {
            using (var scope = new TransactionScope())
            {
                _ = Update(currentJev);
                _ = SetJevStatus(currentJev.Id, JevModel.Status.pending, null);

                _ = _jevAccountsRepository.DeleteByJevId(currentJev.Id);
                jevAccountsModelList.ForEach(x => x.JEVId = currentJev.Id);
                _ = _jevAccountsRepository.BulkInsert(jevAccountsModelList);

                if (currentJev.JournalsId != prevJournal.jrnlId)
                {
                    _ = DeletePrevJournals(prevJournal.jrnlId, prevJournal.jrnlName);
                    _ = _cashReceiptsJournalRepository.Insert(cashReceiptsJournalModel);
                }
                else
                    _ = _cashReceiptsJournalRepository.UpdateByJevId(cashReceiptsJournalModel);

                scope.Complete();
                return true;
            }
        }

        public bool UpdateProcurementReceivedJournalEntry(JevModel currentJev,
                                        (int jrnlId, string jrnlName) prevJournal,
                                        List<JEVAccountsModel> jevAccountsModels)
        {
            using (var scope = new TransactionScope())
            {
                _ = Update(currentJev);
                _ = SetJevStatus(currentJev.Id, JevModel.Status.pending, null);

                _ = _jevAccountsRepository.DeleteByJevId(currentJev.Id);
                jevAccountsModels.ForEach(x => x.JEVId = currentJev.Id);
                _ = _jevAccountsRepository.BulkInsert(jevAccountsModels);

                if (currentJev.JournalsId != prevJournal.jrnlId)
                    _ = DeletePrevJournals(prevJournal.jrnlId, prevJournal.jrnlName);

                scope.Complete();
                return true;
            }
        }

        public bool UpdateADADisbursementsJournalEntry(JevModel currentJev,
                                            (int jrnlId, string jrnlName) prevJournal,
                                            List<JEVAccountsModel> jevAccountsModelList,
                                            ADADisbursementsJournalModel aDADisbursementsJournalModel)
        {
            using (var scope = new TransactionScope())
            {
                _ = Update(currentJev);
                _ = SetJevStatus(currentJev.Id, JevModel.Status.pending, null);

                _ = _jevAccountsRepository.DeleteByJevId(currentJev.Id);
                jevAccountsModelList.ForEach(x => x.JEVId = currentJev.Id);
                _ = _jevAccountsRepository.BulkInsert(jevAccountsModelList);

                if (currentJev.JournalsId != prevJournal.jrnlId)
                {
                    _ = DeletePrevJournals(prevJournal.jrnlId, prevJournal.jrnlName);
                    _ = _adaDisbursementsJournalRepository.Insert(aDADisbursementsJournalModel);
                }
                else
                    _ = _adaDisbursementsJournalRepository.UpdateByJevId(aDADisbursementsJournalModel);

                scope.Complete();
                return true;
            }
        }

        public Dictionary<string, string> GetViewRecordByJEVId(int jevId)
        {
            var recordDictionary = new Dictionary<string, string>();

            var parameters = new MySqlParameter[]
            {
                new("@id", jevId)
            };

            string query = $"SELECT * FROM {viewTableName} WHERE id = @id";

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

        public int JevCounterByJournal(string fundName, int year, string journalName)
        {
            var parameters = new MySqlParameter[]
            {
                new("@fund_name", fundName),
                new("@year", year),
                new("@journal_name", journalName)
            };

            string query = $"SELECT COALESCE(COUNT(*), 0) AS jev_count FROM {viewTableName} WHERE status = 'approved'  {(fundName == "All" ? string.Empty : "AND fund_name = @fund_name")} AND journal_name = @journal_name AND YEAR(date_entry) <= @year";

            return Convert.ToInt32(_genericCommands.ExecuteScalar(query, parameters));
        }

        public int GetJevCount(JevModel.Status? status, string journalName, string fundName, short year)
        {
            var parameters = new MySqlParameter[]
            {
                new ("@journal_name", journalName),
                new ("@fund_name", fundName),
                new ("@year", year)
            };

            string statusQuery = status.HasValue ? $"status = '{status}' AND" : string.Empty;
            string journalQuery = journalName == "All" ? string.Empty : "journal_name = @journal_name AND";
            string fundQuery = fundName == "All" ? string.Empty : "fund_name = @fund_name AND";

            string query = $"SELECT COALESCE(COUNT(*), 0) AS jev_count FROM {viewTableName} WHERE {statusQuery} {journalQuery} {fundQuery} YEAR(date_entry) = @year";

            return Convert.ToInt32(_genericCommands.ExecuteScalar(query, parameters));
        }

        public DataTable GetViewRecords(string status, string searchTxt, string journalName, string fundName, short year)
        {
            var parameters = new MySqlParameter[]
            {
                new("@journal_name", journalName),
                new("@fund_name", fundName),
                new("@searchTxt", $"%{searchTxt}%"),
                new("@year", year),
                new("@status", status)
            };

            string query = $"SELECT * FROM {viewTableName} WHERE status = @status AND journal_name = @journal_name AND fund_name = @fund_name AND YEAR(date_entry) = @year AND (full_jev_no LIKE @searchTxt OR fund_name LIKE @searchTxt OR ref_no LIKE @searchTxt OR payee LIKE @searchTxt OR explanation LIKE @searchTxt) ORDER BY full_jev_no";
            return _genericCommands.FillBySearch(query, new DataTable(), parameters);
        }

        public string GetLastJevNoSeries(int fundId)
        {
            var parameters = new MySqlParameter[]
            {
                new("@funds_id", fundId)
            };

            string query = $"SELECT COALESCE(LPAD(MAX(jev_no)+1, 4, '0'), '0001') AS jev_no FROM {tableName} WHERE funds_id = @funds_id";
            return _genericCommands.ExecuteScalar(query, parameters);
        }

        public string GetLastTransactionNo(int year)
        {
            var parameters = new MySqlParameter[]
            {
                new("@date_entry_year", year)
            };

            string query = $"SELECT COALESCE(LPAD(MAX(transaction_no)+1, 4, '0'), '0001') AS transaction_no FROM {tableName} WHERE YEAR(date_entry) = @date_entry_year";
            return _genericCommands.ExecuteScalar(query, parameters);
        }

        //Auditing Section

        public bool SetJevStatus(int id, JevModel.Status status, string? remarks)
        {
            object? jevNo = status == JevModel.Status.approved ? GetLastJevNoSeries(id)
                : null;

            var parameters = new MySqlParameter[]
            {
                new("@id", id),
                new("@jev_no", jevNo ?? DBNull.Value),
                new("@remarks", remarks ?? (object)DBNull.Value),
                new("@status", status.ToString())
            };

            string query = $"UPDATE {tableName} SET jev_no = @jev_no, status = @status, remarks = @remarks  WHERE id = @id";

            bool result;
            using (var scope = new TransactionScope())
            {
                result = _genericCommands.ExecuteNonQuery(query, parameters);
                scope.Complete();
            }

            return result;
        }

        public DataTable GetViewRecords(JevModel.Status status)
        {
            var parameter = new MySqlParameter[]
            {
                new("@status", status.ToString())
            };

            string query = $"SELECT * FROM {viewTableName} WHERE status = @status";
            return _genericCommands.FillBySearch(query, new DataTable(), parameter);
        }
    }
}