using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Transactions;

namespace ACC.Data
{
    public class JEVRepository : IJEVRepository
    {
        private readonly IJEVAccountsRepository _jevAccountsRepository;
        private readonly ICheckDisbursementsJournalRepository _checkDisbursementsJournalRepository;
        private readonly ICashReceiptsJournalRepository _cashReceiptsJournalRepository;
        private readonly IADADisbursementsJournalRepository _aDADisbursementsJournalRepository;
        private readonly ICashDisbursementsJournalRepository _cashDisbursementsJournalRepository;
        private readonly IGeneralJournalRepository _generalJournalRepository;
        private AccGenericCommands mySqlGenericCommandsLFS;
        private IJEVAccountsRepository iJEVAccountsRepository;
        private IADADisbursementsJournalRepository iADADisbursementsJournalRepository;
        private const string tableName = "jev";
        private const string viewTableName = "view_jev";

        public JEVRepository(AccGenericCommands mySqlGenericCommandsLFS, IJEVAccountsRepository iJEVAccountsRepository, ICheckDisbursementsJournalRepository checkDisbursementsJournalRepository, ICashReceiptsJournalRepository cashReceiptsJournalRepository, IADADisbursementsJournalRepository iADADisbursementsJournalRepository, ICashDisbursementsJournalRepository cashDisbursementsJournalRepository, IGeneralJournalRepository generalJournalRepository)
        {
            this.mySqlGenericCommandsLFS = mySqlGenericCommandsLFS;
            this.iJEVAccountsRepository = iJEVAccountsRepository;
            _checkDisbursementsJournalRepository = checkDisbursementsJournalRepository;
            _cashReceiptsJournalRepository = cashReceiptsJournalRepository;
            this.iADADisbursementsJournalRepository = iADADisbursementsJournalRepository;
            _cashDisbursementsJournalRepository = cashDisbursementsJournalRepository;
            _generalJournalRepository = generalJournalRepository;
        }

        public bool Delete(List<JevModel> entityList)
        {
            throw new NotImplementedException();
        }

        public bool Delete(JevModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, entity.Id},
            };

            string query = $"DELETE FROM {tableName} WHERE id = @id";
            return mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            var recordDictionary = new Dictionary<string, string>();

            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, Id},
            };

            string query = $"SELECT id, funds_id, fund_code, fund_name, journals_id, journal_name, is_special, jev_no, date_entry, ref_no, payee, explanation, is_approved, is_disapproved, is_cancelled, created_at, created_by, created_by_name, updated_at, updated_by, updated_by_name FROM {viewTableName} WHERE id = @id";

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
            string query = $"SELECT * FROM {tableName}";
            return mySqlGenericCommandsLFS.Fill(query, new DataTable());
        }

        public DataTable GetRecordsByJEVNoAndDate(string searchText, sbyte month, ushort year, byte journalId)
        {
            var parameters = new object[][]
            {
                new object[] { "@jev_no", DbType.String, $"%{searchText}%" },
                new object[] { "@month", DbType.DateTime2, month },
                new object[] { "@year", DbType.DateTime2, year },
                new object[] { "@journalId", DbType.String, journalId }
            };

            string query = $"SELECT id, funds_id, journals_id, jev_no, ref_no, payee, explanation, fund_code, is_approved, is_disapproved, is_cancelled, created_at, created_by, updated_at, updated_by, CONCAT_WS('-', fund_code,YEAR(date_entry),MONTH(date_entry),jev_no) AS full_jev_no, date_entry FROM {viewTableName} WHERE MONTH(date_entry) = @month AND YEAR(date_entry) = @year AND journals_id = @journalId AND is_approved = 1 AND is_disapproved = 0 AND is_cancelled =  0 AND jev_no LIKE @jev_no";

            return mySqlGenericCommandsLFS.FillBySearch(query, new DataTable(), parameters);
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            var parameters = new object[][]
            {
                new object[] { "@jev_no", DbType.String, $"%{searchText}%" },
                new object[] { "@ref_no", DbType.String, $"%{searchText}%" },
                new object[] { "@payee", DbType.String, $"%{searchText}%" },
                new object[] { "@explanation", DbType.String, $"%{searchText}%" },
            };

            string query = $"SELECT id, funds_id, journals_id, jev_no, full_jev_no, date_entry, ref_no, payee, explanation, fund_code, is_approved, is_disapproved, is_cancelled, created_at, created_by, updated_at, updated_by FROM {viewTableName} WHERE is_approved=1 AND (jev_no LIKE @jev_no OR ref_no LIKE @ref_no OR payee LIKE @payee OR explanation LIKE @explanation)";

            return mySqlGenericCommandsLFS.FillBySearch(query, new DataTable(), parameters);
        }

        public bool IdExist(int id)
        {
            throw new NotImplementedException();
        }

        public bool InsertWithCheckDisbursement(JevModel jevModel,
                                                List<JEVAccountsModel> jevAccountsModelList,
                                                CheckDisbursementsJournalModel checkDisbursementsJournalModel)
        {
            using (var scope = new TransactionScope())
            {
                _ = Insert(jevModel, jevAccountsModelList);

                // assigning jev_id kay karon paman nato makuha tungod sa na insert na sa taas
                checkDisbursementsJournalModel.JevId = GetLastInsertedID();

                _checkDisbursementsJournalRepository.Insert(checkDisbursementsJournalModel);

                scope.Complete();
                return true;
            }
        }

        public bool InsertWithCashReceipts(JevModel entity,
                                           List<JEVAccountsModel> jevAccountsModelList,
                                           CashReceiptsJournalModel cashReceiptsJournalModel)
        {
            using (var scope = new TransactionScope())
            {
                _ = Insert(entity, jevAccountsModelList);

                cashReceiptsJournalModel.JevId = GetLastInsertedID();

                _ = _cashReceiptsJournalRepository.Insert(cashReceiptsJournalModel);

                scope.Complete();
                return true;
            }
        }

        public bool InsertWithADADisbursements(JevModel entity,
                                               List<JEVAccountsModel> jevAccountsModelList,
                                               ADADisbursementsJournalModel aDADisbursementsJournalModel)
        {
            using (var scope = new TransactionScope())
            {
                _ = Insert(entity, jevAccountsModelList);

                aDADisbursementsJournalModel.JevId = GetLastInsertedID();

                _ = _aDADisbursementsJournalRepository.Insert(aDADisbursementsJournalModel);

                scope.Complete();
                return true;
            }
        }

        public bool InsertWithCashDisbursements(JevModel entity,
                                               List<JEVAccountsModel> jevAccountsModelList,
                                               CashDisbursementsJournalModel cashDisbursementsJournalModel)
        {
            using (var scope = new TransactionScope())
            {
                _ = Insert(entity, jevAccountsModelList);

                cashDisbursementsJournalModel.JevId = GetLastInsertedID();

                _ = _cashDisbursementsJournalRepository.Insert(cashDisbursementsJournalModel);

                scope.Complete();
                return true;
            }
        }

        public bool InsertWithGeneralJournal(JevModel entity,
                                               List<JEVAccountsModel> jevAccountsModelList,
                                               GeneralJournalModel generalJournalModel)
        {
            try
            {
                using (var scope = new TransactionScope())
                {
                    _ = Insert(entity, jevAccountsModelList);

                    generalJournalModel.JevId = GetLastInsertedID();

                    _ = _generalJournalRepository.Insert(generalJournalModel);

                    scope.Complete();
                    return true;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Insert(JevModel entity, List<JEVAccountsModel> jevAccountsModelList)
        {
            using (var scope = new TransactionScope())
            {
                object[][] parameters = new object[][]
                {
                        new object[] { "@funds_id", DbType.Byte, entity.FundsId },
                        new object[] { "@journals_id", DbType.Byte, entity.JournalsId },
                        new object[] { "@jev_no", DbType.String, entity.JEVNumber },
                        new object[] { "@date_entry", DbType.Date, entity.DateEntry },
                        new object[] { "@ref_no", DbType.String, entity.RefNo },
                        new object[] { "@payee", DbType.String, entity.Payee },
                        new object[] { "@explanation", DbType.String, entity.Explanation },
                        new object[] { "@is_approved", DbType.Boolean, entity.IsApproved },
                        new object[] { "@created_by", DbType.Byte, entity.CreatedBy },
                };

                string query = $"INSERT INTO {tableName} (funds_id, journals_id, jev_no, date_entry, ref_no, payee, explanation, is_approved, created_by) VALUES (@funds_id, @journals_id, @jev_no, @date_entry, @ref_no, @payee, @explanation, @is_approved, @created_by);";

                // save and get the last inserted id
                _ = mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);

                // loop jev accounts list then insert each using the latest Jev Id
                foreach (var jevAccounts in jevAccountsModelList)
                {
                    jevAccounts.JEVId = GetLastInsertedID();
                    _ = _jevAccountsRepository.Insert(jevAccounts);
                }

                scope.Complete();

                return true;
            }
        }

        public bool Insert(JevModel entity)
        {
            throw new NotImplementedException();
        }

        public bool UpdateWithCheckDisbursement(JevModel entity,
                                                List<JEVAccountsModel> jevAccountsModelList,
                                                CheckDisbursementsJournalModel checkDisbursementsJournalModel)
        {
            using (var scope = new TransactionScope())
            {
                _ = Update(entity, jevAccountsModelList);

                _checkDisbursementsJournalRepository.UpdateByJevID(checkDisbursementsJournalModel);
                scope.Complete();
                return true;
            }
        }

        public bool UpdateWithCashReceipts(JevModel entity,
                                           List<JEVAccountsModel> jevAccountsModelList,
                                           CashReceiptsJournalModel cashReceiptsJournalModel)
        {
            using (var scope = new TransactionScope())
            {
                _ = Update(entity, jevAccountsModelList);

                _ = _cashReceiptsJournalRepository.UpdateByJevId(cashReceiptsJournalModel);

                scope.Complete();
                return true;
            }
        }

        public bool UpdateWithADADisbursements(JevModel entity,
                                               List<JEVAccountsModel> jevAccountsModelList,
                                               ADADisbursementsJournalModel aDADisbursementsJournalModel)
        {
            try
            {
                using (var scope = new TransactionScope())
                {
                    _ = Update(entity, jevAccountsModelList);

                    _ = _aDADisbursementsJournalRepository.UpdateByJevId(aDADisbursementsJournalModel);

                    scope.Complete();
                    return true;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool UpdateWithCashDisbursements(JevModel entity, List<JEVAccountsModel> jevAccountsModelList, CashDisbursementsJournalModel cashDisbursementsJournalModel)
        {
            using (var scope = new TransactionScope())
            {
                _ = Update(entity, jevAccountsModelList);

                _ = _cashDisbursementsJournalRepository.UpdateByJevId(cashDisbursementsJournalModel);

                scope.Complete();
                return true;
            }
        }

        public bool UpdateWithGeneralJournal(JevModel entity, List<JEVAccountsModel> jevAccountsModelList, GeneralJournalModel generalJournalModel)
        {
            using (var scope = new TransactionScope())
            {
                _ = Update(entity, jevAccountsModelList);

                _ = _generalJournalRepository.UpdateByJevId(generalJournalModel);

                scope.Complete();
                return true;
            }
        }

        public bool SetJEVStatus(int jevId, int fundId, string status)
        {
            using (var scope = new TransactionScope())
            {
                var parameters = new object[][]
                {
                    new object[] { "@jev_id", DbType.Int64, jevId },
                    new object[] { "@jev_no", DbType.String, GetLastJevNoSeries(fundId) }
                };

                string Status()
                {
                    switch (status)
                    {
                        case "approve":
                            return "is_approved = 1, is_disapproved = 0, is_cancelled = 0, jev_no = @jev_no";

                        case "disapprove":
                            return "is_approved = 0, is_disapproved = 1, is_cancelled = 0, jev_no = NULL";

                        case "cancel":
                            return "is_cancelled = 1";

                        case "pending":
                            return "is_cancelled= 0, is_disapproved = 0, is_approved = 0, jev_no = NULL";

                        default:
                            return "is_cancelled= 0, is_disapproved = 0, is_approved = 0, jev_no = NULL";
                    }
                }

                string query = $"UPDATE {tableName} SET {Status()} WHERE id = @jev_id";
                _ = mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);

                scope.Complete();
                return true;
            }
        }

        public bool Update(JevModel entity, List<JEVAccountsModel> jevAccountsModelList)
        {
            using (var scope = new TransactionScope())
            {
                var parameters = new object[][]
                {
                    new object[] { "@id", DbType.Int32, entity.Id },
                    new object[] { "@funds_id", DbType.Byte, entity.FundsId },
                    new object[] { "@journals_id", DbType.Byte, entity.JournalsId },
                    new object[] { "@jev_no", DbType.String, entity.JEVNumber },
                    new object[] { "@date_entry", DbType.Date, entity.DateEntry },
                    new object[] { "@ref_no", DbType.String, entity.RefNo },
                    new object[] { "@payee", DbType.String, entity.Payee },
                    new object[] { "@explanation", DbType.String, entity.Explanation },
                    new object[] { "@is_approved", DbType.Boolean, entity.IsApproved},
                    new object[] { "@is_disapproved", DbType.Boolean, entity.IsDisapproved},
                    new object[] { "@is_cancelled", DbType.Boolean, entity.IsCancelled},
                    new object[] { "@updated_by", DbType.Byte, entity.UpdatedBy },
                    new object[] { "@is_edited", DbType.Byte, entity.IsEdited},
                    new object[] { "@remarks", DbType.String, entity.Remarks},
                };

                string query = $"UPDATE {tableName} SET funds_id = @funds_id, journals_id = @journals_id, jev_no = @jev_no, date_entry = @date_entry, ref_no = @ref_no, payee = @payee, explanation = @explanation, is_approved = @is_approved, is_disapproved = @is_disapproved, is_cancelled = @is_cancelled, updated_by = @updated_by, is_edited = @is_edited, remarks = @remarks WHERE id = @id";

                // save and get the last inserted id
                _ = mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);

                // delete all the jev accounts first
                _ = _jevAccountsRepository.DeleteByJevId(entity.Id);

                // loop jev accounts list then insert each using the latest Jev Id
                foreach (var jevAccounts in jevAccountsModelList)
                {
                    jevAccounts.JEVId = entity.Id;
                    _ = _jevAccountsRepository.Insert(jevAccounts);
                }

                scope.Complete();
                return true;
            }
        }

        public bool Update(JevModel entity)
        {
            throw new NotImplementedException();
        }

        public int GetLastInsertedID()
        {
            string query = $"SELECT MAX(id) FROM {tableName}";
            return int.Parse(mySqlGenericCommandsLFS.ExecuteScalar(query));
        }

        public Dictionary<string, string> GetViewRecordByJEVId(int jevId)
        {
            var record = new Dictionary<string, string>();

            var parameters = new object[][]
            {
                    new object[] { "@id", DbType.Int32, jevId},
            };

            string query = $"SELECT id, " +
                $"funds_id, " +
                $"fund_code, " +
                $"fund_name, " +
                $"journals_id, " +
                $"journal_name, " +
                $"is_special, " +
                $"jev_no, " +
                $"date_entry, " +
                $"ref_no, " +
                $"payee, " +
                $"explanation, " +
                $"is_approved, " +
                $"is_disapproved, " +
                $"is_cancelled, " +
                $"is_edited, " +
                $"created_at, " +
                $"created_by, " +
                $"created_by_name, " +
                $"updated_at, " +
                $"updated_by, " +
                $"updated_by_name " +
                $"FROM {viewTableName} " +
                $"WHERE id = @id";

            using (var reader = mySqlGenericCommandsLFS.ExecuteReader(query, parameters))
            {
                if (reader.Rows.Count < 1)
                    return record;

                record.Add("id", reader.Rows[0]["id"].ToString());
                record.Add("funds_id", reader.Rows[0]["funds_id"].ToString());
                record.Add("fund_code", reader.Rows[0]["fund_code"].ToString());
                record.Add("fund_name", reader.Rows[0]["fund_name"].ToString());
                record.Add("journals_id", reader.Rows[0]["journals_id"].ToString());
                record.Add("journal_name", reader.Rows[0]["journal_name"].ToString());
                record.Add("is_special", reader.Rows[0]["is_special"].ToString());
                record.Add("jev_no", reader.Rows[0]["jev_no"].ToString());
                record.Add("date_entry", reader.Rows[0]["date_entry"].ToString());
                record.Add("ref_no", reader.Rows[0]["ref_no"].ToString());
                record.Add("payee", reader.Rows[0]["payee"].ToString());
                record.Add("explanation", reader.Rows[0]["explanation"].ToString());
                record.Add("is_approved", reader.Rows[0]["is_approved"].ToString());
                record.Add("is_disapproved", reader.Rows[0]["is_disapproved"].ToString());
                record.Add("is_cancelled", reader.Rows[0]["is_cancelled"].ToString());
                record.Add("is_edited", reader.Rows[0]["is_edited"].ToString());
                record.Add("created_at", reader.Rows[0]["created_at"].ToString());
                record.Add("created_by", reader.Rows[0]["created_by"].ToString());
                record.Add("created_by_name", reader.Rows[0]["created_by_name"].ToString());
                record.Add("updated_at", reader.Rows[0]["updated_at"].ToString());
                record.Add("updated_by", reader.Rows[0]["updated_by"].ToString());
                record.Add("updated_by_name", reader.Rows[0]["updated_by_name"].ToString());
            }

            return record;
        }

        public int JevCounterByJournal(string fundName, int month, int year, string journalName)
        {
            var parameters = new object[][]
            {
                    new object[] { "@fund_name", DbType.String, fundName },
                    new object[] { "@month", DbType.Int32, month},
                    new object[] { "@year", DbType.Int32, year},
                    new object[] { "@journal_name", DbType.String, journalName }
            };

            string query = $"SELECT COUNT(*) " +
                $"FROM {viewTableName} " +
                $"WHERE is_approved = 1 AND is_cancelled = 0 AND is_disapproved = 0 " +
                $"AND fund_name = @fund_name " +
                $"AND journal_name = @journal_name " +
                $"AND MONTH(date_entry) = @month " +
                $"AND YEAR(date_entry) = @year";

            if (string.IsNullOrWhiteSpace(mySqlGenericCommandsLFS.ExecuteScalar(query, parameters)))
                return 0;
            else
                return int.Parse(mySqlGenericCommandsLFS.ExecuteScalar(query, parameters));
        }

        public bool JevNumberExistBy_JevNo_FundId_Year(string jevNo, int fundId, int year)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object [] { "@jev_no", DbType.String, jevNo },
                    new object [] { "@funds_id", DbType.Int32, fundId},
                    new object [] { "@year", DbType.Int16, year},
                };

                string query = $"SELECT * FROM {tableName} WHERE jev_no = @jev_no AND funds_id = @funds_id AND YEAR(date_entry) = @year";
                string queryResult = mySqlGenericCommandsLFS.ExecuteScalar(query, parameters);

                // if query is not null, means found some record, so true
                if (!string.IsNullOrEmpty(queryResult)) return true;
            }
            catch (Exception)
            {
                throw;
            }
            ;

            return false;
        }

        public bool JevNumberExistBy_JevId_JevNo_FundId_Year(int id, string jevNo, int fundId, int year)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@id", DbType.Int32, id },
                    new object[] { "@jev_no", DbType.String, jevNo },
                    new object[] { "@funds_id", DbType.Int32, fundId},
                    new object[] { "@year", DbType.Int16, year}
                };

                string query = $"SELECT id FROM {tableName} WHERE id <> @id AND jev_no = @jev_no AND funds_id = @funds_id AND YEAR(date_entry) = @year";
                string queryResult = mySqlGenericCommandsLFS.ExecuteScalar(query, parameters);

                // if query is not null, means found some record, so true
                if (!string.IsNullOrEmpty(queryResult)) return true;
            }
            catch (Exception)
            {
                throw;
            }
            ;

            return false;
        }

        public int GetJevCount(string status, string journalName, string fundName, short year)
        {
            var parameters = new object[][]
            {
                new object[] { "@journal_name", DbType.String, journalName },
                new object[] { "@fund_name", DbType.String, fundName},
                new object[] { "@year", DbType.Int16, year}
            };

            string journalQuery = journalName == "All" ? string.Empty : "journal_name = @journal_name AND";
            string fundQuery = fundName == "All" ? string.Empty : "fund_name = @fund_name AND";

            string statusQuery;

            switch (status)
            {
                case "pending":
                    statusQuery = "is_approved = 0 AND is_disapproved = 0 AND is_cancelled = 0 AND";
                    break;

                case "approved":
                    statusQuery = "is_approved = 1 AND is_disapproved = 0 AND is_cancelled = 0 AND";
                    break;

                case "disapproved":
                    statusQuery = "is_approved = 0 AND is_disapproved = 1 AND is_cancelled = 0 AND";
                    break;

                case "cancelled":
                    statusQuery = "is_cancelled = 1 AND";
                    break;

                default:
                    statusQuery = string.Empty;
                    break;
            }

            string query = $"SELECT COUNT(*) FROM {viewTableName} WHERE {statusQuery} {journalQuery} {fundQuery} YEAR(date_entry) = @year";

            return int.Parse(mySqlGenericCommandsLFS.ExecuteScalar(query, parameters));
        }

        public int TotalApproveJEV(short month, short year)
        {
            var parameters = new object[][]
            {
                new object[] { "@month", DbType.Int16, month},
                new object[] { "@year", DbType.Int16, year}
            };

            string query = $"SELECT COUNT(*) FROM {tableName} WHERE is_approved=1 AND is_disapproved=0 AND is_cancelled=0 AND MONTH(date_entry)<=@month AND YEAR(date_entry)=@year";

            return int.Parse(mySqlGenericCommandsLFS.ExecuteScalar(query, parameters));
        }

        public int TotalPendingJEV(short month, short year)
        {
            var parameters = new object[][]
            {
                new object[] { "@month", DbType.Int16, month},
                new object[] { "@year", DbType.Int16, year}
            };

            string query = $"SELECT COUNT(*) FROM {tableName} WHERE  is_approved=0 AND is_disapproved=0 AND is_cancelled=0 AND MONTH(date_entry)<=@month AND YEAR(date_entry)=@year";

            return int.Parse(mySqlGenericCommandsLFS.ExecuteScalar(query, parameters));
        }

        public int TotalDisapprovedJEV(short month, short year)
        {
            var parameters = new object[][]
            {
                new object[] { "@month", DbType.Int16, month},
                new object[] { "@year", DbType.Int16, year}
            };

            string query = $"SELECT COUNT(*) FROM {tableName} WHERE  is_approved=0 AND is_disapproved=1 AND is_cancelled=0 AND MONTH(date_entry)<=@month AND YEAR(date_entry)=@year";

            return int.Parse(mySqlGenericCommandsLFS.ExecuteScalar(query, parameters));
        }

        public int TotalCancelledJEV(short month, short year)
        {
            var parameters = new object[][]
            {
                new object[] { "@month", DbType.Int16, month},
                new object[] { "@year", DbType.Int16, year}
            };

            string query = $"SELECT COUNT(*) FROM {tableName} WHERE is_approved=1 AND is_disapproved=0 AND is_cancelled=1 AND MONTH(date_entry)<=@month AND YEAR(date_entry)=@year";

            return int.Parse(mySqlGenericCommandsLFS.ExecuteScalar(query, parameters));
        }

        public DataTable GetViewRecords(string jevStatus, string searchTxt, string journalName, string fundName, short year)
        {
            var parameters = new object[][]
            {
                new object[] { "@journal_name", DbType.String, journalName},
                new object[] { "@fund_name", DbType.String, fundName},
                new object[] { "@searchTxt", DbType.String, $"%{searchTxt}%"},
                new object[] { "@year", DbType.Int16, year}
            };

            string journalQuery = journalName == "All" ? string.Empty : "journal_name = @journal_name AND";
            string fundQuery = fundName == "All" ? string.Empty : "fund_name = @fund_name AND";
            string jevStatusQuery;

            switch (jevStatus)
            {
                case "pending":
                    jevStatusQuery = $"is_approved = 0 AND is_disapproved = 0 AND is_cancelled = 0 AND ";
                    break;

                case "approved":
                    jevStatusQuery = $"is_approved = 1 AND is_disapproved = 0 AND is_cancelled = 0 AND ";
                    break;

                case "disapproved":
                    jevStatusQuery = $"is_approved = 0 AND is_disapproved = 1 AND is_cancelled = 0 AND ";
                    break;

                case "cancelled":
                    jevStatusQuery = $"is_cancelled = 1 AND ";
                    break;

                default:
                    jevStatusQuery = string.Empty;
                    break;
            }
            string query = $"SELECT * FROM {viewTableName} WHERE {jevStatusQuery} {journalQuery} {fundQuery} YEAR(date_entry) = @year AND (full_jev_no LIKE @searchTxt OR fund_name LIKE @searchTxt OR ref_no LIKE @searchTxt OR payee LIKE @searchTxt OR explanation LIKE @searchTxt) ORDER BY full_jev_no";
            return mySqlGenericCommandsLFS.FillBySearch(query, new DataTable(), parameters);
        }

        //SFPs
        public decimal GetSumByMajorAccountGroup(int fundId, int majorAccountGroupId, byte isDebit, DateTime dateEntry)
        {
            var parameters = new object[][]
            {
                new object[] { "@funds_id", DbType.Int32, fundId},
                new object[] { "@major_account_group_id",DbType.Int32, majorAccountGroupId},
                new object[] { "@is_debit",DbType.Byte, isDebit},
                new object[] { "@date_entry", DbType.Date, dateEntry.Date },
                new object[] { "@year", DbType.Int16, dateEntry.Year}
            };

            string query = $"SELECT COALESCE(SUM(b.amount), 0) AS amount FROM jev a JOIN jev_accounts b ON b.jev_id = a.id JOIN general_ledger_accounts c ON c.id = b.general_ledger_accounts_id JOIN sub_major_account_group d ON d.id = c.sub_major_account_group_id JOIN major_account_group e ON e.id = d.major_account_group_id JOIN account_group f ON f.id = e.account_group_id WHERE a.funds_id = @funds_id AND a.date_entry <= @date_entry AND YEAR(a.date_entry) = @year AND e.id  = @major_account_group_id AND b.is_debit = @is_debit";
            decimal amount = Convert.ToDecimal(mySqlGenericCommandsLFS.ExecuteScalar(query, parameters));
            return amount;
        }

        public decimal GetSumPreviousYearTransactionsByFundIdAndMajAccountGroupId(int fundId, int majorAccountGroupId, byte isDebit, DateTime dateEntry)
        {
            var parameters = new object[][]
            {
                new object[] { "@funds_id", DbType.Int32, fundId},
                new object[] { "@major_account_group_id",DbType.Int32, majorAccountGroupId},
                new object[] { "@year", DbType.Int16, dateEntry.Year -1},
                new object[] { "@is_debit", DbType.Byte, isDebit}
            };
            string query = $"SELECT COALESCE(SUM(b.amount), 0) AS amount FROM jev a JOIN jev_accounts b ON b.jev_id = a.id JOIN general_ledger_accounts c ON c.id = b.general_ledger_accounts_id JOIN sub_major_account_group d ON d.id = c.sub_major_account_group_id JOIN major_account_group e ON e.id = d.major_account_group_id JOIN account_group f ON f.id = e.account_group_id WHERE a.funds_id = @funds_id AND YEAR(a.date_entry) = @year AND e.id  = @major_account_group_id AND b.is_debit = @is_debit";
            decimal amount = Convert.ToDecimal(mySqlGenericCommandsLFS.ExecuteScalar(query, parameters));
            return amount;
        }

        public string GetLastJevNoSeries(int fundId)
        {
            var parameters = new object[][]
            {
                new object[] { "@funds_id", DbType.Int32, fundId}
            };

            string query = $"SELECT COALESCE(LPAD(MAX(jev_no)+1, 4, '0'), '0001') AS jev_no FROM {tableName} WHERE funds_id = @funds_id";
            return mySqlGenericCommandsLFS.ExecuteScalar(query, parameters);
        }

        public string GetJevStatus(int jevId)
        {
            var parameters = new object[][]
            {
                new object[] { "@jev_id", DbType.Int32, jevId}
            };
            string query = $"SELECT is_approved, is_disapproved, is_cancelled FROM {tableName} WHERE id = @jev_id";
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

        public string GetRemarks(int jevId)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, jevId}
            };

            string query = $"SELECT remarks FROM {tableName} WHERE id = @id";
            return mySqlGenericCommandsLFS.ExecuteScalar(query, parameters).ToString();
        }
    }
}