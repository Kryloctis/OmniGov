using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Transactions;

namespace ACC.Data
{

    public class JEVRepository : IJEVRepository
    {
        private readonly IDbGenericCommands _dbGenericCommands;
        private readonly IJEVAccountsRepository _jevAccountsRepository;
        private readonly ICheckDisbursementsJournalRepository _checkDisbursementsJournalRepository;
        private readonly ICashReceiptsJournalRepository _cashReceiptsJournalRepository;
        private readonly IADADisbursementsJournalRepository _aDADisbursementsJournalRepository;
        private readonly ICashDisbursementsJournalRepository _cashDisbursementsJournalRepository;
        private readonly IGeneralJournalRepository _generalJournalRepository;
        private const string tableName = "jev";
        private const string viewTableName = "view_jev";

        public JEVRepository(
            IDbGenericCommands dbGenericCommands,
            IJEVAccountsRepository jevAccountsRepository,
            ICheckDisbursementsJournalRepository checkDisbursementsJournalRepository,
            ICashReceiptsJournalRepository cashReceiptsJournalRepository,
            IADADisbursementsJournalRepository aDADisbursementsJournalRepository,
            ICashDisbursementsJournalRepository cashDisbursementsJournalRepository,
            IGeneralJournalRepository generalJournalRepository)
        {
            _dbGenericCommands = dbGenericCommands;
            _jevAccountsRepository = jevAccountsRepository;
            _checkDisbursementsJournalRepository = checkDisbursementsJournalRepository;
            _cashReceiptsJournalRepository = cashReceiptsJournalRepository;
            _aDADisbursementsJournalRepository = aDADisbursementsJournalRepository;
            _cashDisbursementsJournalRepository = cashDisbursementsJournalRepository;
            _generalJournalRepository = generalJournalRepository;
        }

        public int CountRecords()
        {
            try
            {
                string query = $"SELECT COUNT(*) FROM {tableName}";

                return int.Parse(_dbGenericCommands.ExecuteScalar(query));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int CountRecords(short month, short year)
        {
            try
            {

                var parameters = new object[][]
                {
                    new object[] { "@month", DbType.Int16, month},
                    new object[] { "@year", DbType.Int16, year}
                };

                string query = $"SELECT COUNT(*) FROM {tableName} WHERE MONTH(date_entry)=@month AND YEAR(date_entry)=@year";

                return int.Parse(_dbGenericCommands.ExecuteScalar(query, parameters));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Delete(List<JEVModel> entityList)
        {
            throw new NotImplementedException();
        }

        public bool Delete(JEVModel entity)
        {
            try
            {
                using (var scope = new TransactionScope())
                {
                    var parameters = new object[][]
                    {
                        new object[] { "@id", DbType.Int32, entity.Id},
                    };

                    string query = $"DELETE FROM {tableName} WHERE id = @id";
                    _ = _dbGenericCommands.ExecuteNonQuery(query, parameters);

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
                    $"created_at, " +
                    $"created_by, " +
                    $"created_by_name, " +
                    $"updated_at, " +
                    $"updated_by, " +
                    $"updated_by_name " +
                    $"FROM {viewTableName} " +
                    $"WHERE id = @id";

                using (var reader = _dbGenericCommands.ExecuteReader(query, parameters))
                {
                    if (reader.Rows.Count < 1)
                        return record;

                    foreach (DataRow item in reader.Rows)
                    {
                        record.Add("id", item[0].ToString());
                        record.Add("funds_id", item[1].ToString());
                        record.Add("fund_code", item[2].ToString());
                        record.Add("fund_name", item[3].ToString());
                        record.Add("journals_id", item[4].ToString());
                        record.Add("journal_name", item[5].ToString());
                        record.Add("is_special", item[6].ToString());
                        record.Add("jev_no", item[7].ToString());
                        record.Add("date_entry", item[8].ToString());
                        record.Add("ref_no", item[9].ToString());
                        record.Add("payee", item[10].ToString());
                        record.Add("explanation", item[11].ToString());
                        record.Add("is_approved", item[12].ToString());
                        record.Add("is_disapproved", item[13].ToString());
                        record.Add("is_cancelled", item[14].ToString());
                        record.Add("created_at", item[15].ToString());
                        record.Add("created_by", item[16].ToString());
                        record.Add("created_by_name", item[17].ToString());
                        record.Add("updated_at", item[18].ToString());
                        record.Add("updated_by", item[19].ToString());
                        record.Add("updated_by_name", item[20].ToString());
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
            try
            {
                string query = $"SELECT * FROM {tableName}";

                var dtJournals = new DataTable();
                return _dbGenericCommands.Fill(query, dtJournals);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetRecordsByJEVNoAndDate(string searchText, sbyte month, ushort year, byte journalId)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@jev_no", DbType.String, $"%{searchText}%" },
                    new object[] { "@month", DbType.DateTime2, month },
                    new object[] { "@year", DbType.DateTime2, year },
                    new object[] { "@journalId", DbType.String, journalId }
                };

                string query = $"SELECT " +
                $"id, " +
                $"funds_id, " +
                $"journals_id, " +
                $"jev_no, " +
                $"ref_no, " +
                $"payee, " +
                $"explanation, " +
                $"fund_code, " +
                $"is_approved, " +
                $"is_disapproved, " +
                $"is_cancelled, " +
                $"created_at, " +
                $"created_by, " +
                $"updated_at, " +
                $"updated_by, " +
                $"CONCAT_WS('-', fund_code,YEAR(date_entry),MONTH(date_entry),jev_no) AS full_jev_no, " +
                $"date_entry " +
                $"FROM {viewTableName} " +
                $"WHERE " +
                $"MONTH(date_entry) = @month " +
                $"AND YEAR(date_entry) = @year " +
                $"AND journals_id = @journalId " +
                $"AND is_approved = 1 " +
                $"AND is_disapproved = 0 " +
                $"AND is_cancelled =  0 " +
                $"AND jev_no LIKE @jev_no";

                var dtGeneralLedgers = new DataTable();
                return _dbGenericCommands.FillBySearch(query, dtGeneralLedgers, parameters);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@jev_no", DbType.String, $"%{searchText}%" },
                    new object[] { "@ref_no", DbType.String, $"%{searchText}%" },
                    new object[] { "@payee", DbType.String, $"%{searchText}%" },
                    new object[] { "@explanation", DbType.String, $"%{searchText}%" },
                    new object[] { "@date", DbType.String, $"%{searchText}%" },
                };

                string query = $"SELECT " +
                    $"id, " +
                    $"funds_id, " +
                    $"journals_id, " +
                    $"jev_no, " +
                    $"full_jev_no, " +
                    $"date_entry, " +
                    $"ref_no, " +
                    $"payee, " +
                    $"explanation, " +
                    $"fund_code, " +
                    $"is_approved, " +
                    $"is_disapproved, " +
                    $"is_cancelled, " +
                    $"created_at, " +
                    $"created_by, " +
                    $"updated_at, " +
                    $"updated_by " +
                    $"FROM {viewTableName} " +
                    $"WHERE is_approved=1 " +
                    $"AND (jev_no LIKE @jev_no OR ref_no LIKE @ref_no OR payee LIKE @payee OR explanation LIKE @explanation)";

                var dtGeneralLedgers = new DataTable();
                return _dbGenericCommands.FillBySearch(query, dtGeneralLedgers, parameters);
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

        public bool InsertWithCheckDisbursement(JEVModel jevModel,
                                                List<JEVAccountsModel> jevAccountsModelList,
                                                CheckDisbursementsJournalModel checkDisbursementsJournalModel)
        {
            try
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
            catch (Exception)
            {
                throw;
            }
        }

        public bool InsertWithCashReceipts(JEVModel entity,
                                           List<JEVAccountsModel> jevAccountsModelList,
                                           CashReceiptsJournalModel cashReceiptsJournalModel)
        {
            try
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
            catch (Exception)
            {
                throw;
            }
        }

        public bool InsertWithADADisbursements(JEVModel entity,
                                               List<JEVAccountsModel> jevAccountsModelList,
                                               ADADisbursementsJournalModel aDADisbursementsJournalModel)
        {
            try
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
            catch (Exception)
            {
                throw;
            }
        }

        public bool InsertWithCashDisbursements(JEVModel entity,
                                               List<JEVAccountsModel> jevAccountsModelList,
                                               CashDisbursementsJournalModel cashDisbursementsJournalModel)
        {
            try
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
            catch (Exception)
            {
                throw;
            }
        }

        public bool InsertWithGeneralJournal(JEVModel entity,
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

        public bool Insert(JEVModel entity, List<JEVAccountsModel> jevAccountsModelList)
        {
            try
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
                    _ = _dbGenericCommands.ExecuteNonQuery(query, parameters);

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
            catch (Exception)
            {
                throw;
            }
        }

        public bool Insert(JEVModel entity)
        {
            throw new NotImplementedException();
        }

        public bool UpdateWithCheckDisbursement(JEVModel entity,
                                                List<JEVAccountsModel> jevAccountsModelList,
                                                CheckDisbursementsJournalModel checkDisbursementsJournalModel)
        {
            try
            {
                using (var scope = new TransactionScope())
                {
                    _ = Update(entity, jevAccountsModelList);

                    _checkDisbursementsJournalRepository.UpdateByJevID(checkDisbursementsJournalModel);
                    scope.Complete();
                    return true;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool UpdateWithCashReceipts(JEVModel entity,
                                           List<JEVAccountsModel> jevAccountsModelList,
                                           CashReceiptsJournalModel cashReceiptsJournalModel)
        {
            try
            {
                using (var scope = new TransactionScope())
                {
                    _ = Update(entity, jevAccountsModelList);

                    _ = _cashReceiptsJournalRepository.UpdateByJevId(cashReceiptsJournalModel);

                    scope.Complete();
                    return true;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool UpdateWithADADisbursements(JEVModel entity,
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

        public bool UpdateWithCashDisbursements(JEVModel entity, List<JEVAccountsModel> jevAccountsModelList, CashDisbursementsJournalModel cashDisbursementsJournalModel)
        {
            try
            {
                using (var scope = new TransactionScope())
                {
                    _ = Update(entity, jevAccountsModelList);

                    _ = _cashDisbursementsJournalRepository.UpdateByJevId(cashDisbursementsJournalModel);

                    scope.Complete();
                    return true;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool UpdateWithGeneralJournal(JEVModel entity, List<JEVAccountsModel> jevAccountsModelList, GeneralJournalModel generalJournalModel)
        {
            try
            {
                using (var scope = new TransactionScope())
                {
                    _ = Update(entity, jevAccountsModelList);

                    _ = _generalJournalRepository.UpdateByJevId(generalJournalModel);

                    scope.Complete();
                    return true;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Update(JEVModel entity, List<JEVAccountsModel> jevAccountsModelList)
        {
            try
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
                        new object[] { "@updated_by", DbType.Byte, entity.UpdatedBy },
                        new object[] { "@is_edited", DbType.Byte, entity.IsEdited},
                    };

                    string query = $"UPDATE {tableName} SET funds_id = @funds_id, journals_id = @journals_id, jev_no = @jev_no, date_entry = @date_entry, ref_no = @ref_no, payee = @payee, explanation = @explanation, updated_by = @updated_by, is_edited = @is_edited WHERE id = @id";

                    // save and get the last inserted id
                    _ = _dbGenericCommands.ExecuteNonQuery(query, parameters);

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
            catch (Exception)
            {
                throw;
            }
        }

        public bool Update(JEVModel entity)
        {
            throw new NotImplementedException();
        }

        public int GetLastInsertedID()
        {
            try
            {
                string query = $"SELECT MAX(id) FROM {tableName}";
                return int.Parse(_dbGenericCommands.ExecuteScalar(query));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string GetLastJevNoSeries(int fundId)
        {
            var parameters = new object[][]
            {
                new object[] { "@funds_id", DbType.Int32, fundId}
            };

            string query = $"SELECT COALESCE(LPAD(MAX(jev_no)+1, 4, '0'), '0001') AS jev_no FROM {tableName} WHERE funds_id = @funds_id";
            return _dbGenericCommands.ExecuteScalar(query, parameters);
        }


        public Dictionary<string, string> GetViewRecordByJEV(string jevNo)
        {
            var record = new Dictionary<string, string>();

            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@jev_no", DbType.String, jevNo},
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
                    $"WHERE jev_no = @jev_no";

                using (var reader = _dbGenericCommands.ExecuteReader(query, parameters))
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
            }
            catch (Exception)
            {
                throw;
            }

            return record;
        }

        public int JevCounterByJournal(string fundName, int month, int year, string journalName)
        {
            try
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

                if (string.IsNullOrWhiteSpace(_dbGenericCommands.ExecuteScalar(query, parameters)))
                    return 0;
                else
                    return int.Parse(_dbGenericCommands.ExecuteScalar(query, parameters));
            }
            catch (Exception)
            {
                throw;
            };
        }


        #region  Validations 

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
                string queryResult = _dbGenericCommands.ExecuteScalar(query, parameters);

                // if query is not null, means found some record, so true
                if (!string.IsNullOrEmpty(queryResult)) return true;
            }
            catch (Exception)
            {
                throw;
            };

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
                string queryResult = _dbGenericCommands.ExecuteScalar(query, parameters);

                // if query is not null, means found some record, so true
                if (!string.IsNullOrEmpty(queryResult)) return true;
            }
            catch (Exception)
            {
                throw;
            };

            return false;
        }

        #endregion


        public int GetJEVCount(string status, string journalName, string fundName, short month, short year)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@journal_name", DbType.String, journalName },
                    new object[] { "@fund_name", DbType.String, fundName},
                    new object[] { "@month", DbType.Int16, month},
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

                string query = $"SELECT COUNT(*) FROM {viewTableName} WHERE {statusQuery} {journalQuery} {fundQuery} MONTH(date_entry)<=@month AND YEAR(date_entry)=@year";

                return int.Parse(_dbGenericCommands.ExecuteScalar(query, parameters));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int TotalApproveJEV(short month, short year)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@month", DbType.Int16, month},
                    new object[] { "@year", DbType.Int16, year}
                };

                string query = $"SELECT COUNT(*) FROM {tableName} WHERE is_approved=1 AND is_disapproved=0 AND is_cancelled=0 AND MONTH(date_entry)<=@month AND YEAR(date_entry)=@year";

                return int.Parse(_dbGenericCommands.ExecuteScalar(query, parameters));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int TotalPendingJEV(short month, short year)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@month", DbType.Int16, month},
                    new object[] { "@year", DbType.Int16, year}
                };

                string query = $"SELECT COUNT(*) FROM {tableName} WHERE  is_approved=0 AND is_disapproved=0 AND is_cancelled=0 AND MONTH(date_entry)<=@month AND YEAR(date_entry)=@year";

                return int.Parse(_dbGenericCommands.ExecuteScalar(query, parameters));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int TotalDisapprovedJEV(short month, short year)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@month", DbType.Int16, month},
                    new object[] { "@year", DbType.Int16, year}
                };

                string query = $"SELECT COUNT(*) FROM {tableName} WHERE  is_approved=0 AND is_disapproved=1 AND is_cancelled=0 AND MONTH(date_entry)<=@month AND YEAR(date_entry)=@year";

                return int.Parse(_dbGenericCommands.ExecuteScalar(query, parameters));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int TotalCancelledJEV(short month, short year)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@month", DbType.Int16, month},
                    new object[] { "@year", DbType.Int16, year}
                };

                string query = $"SELECT COUNT(*) FROM {tableName} WHERE is_approved=1 AND is_disapproved=0 AND is_cancelled=1 AND MONTH(date_entry)<=@month AND YEAR(date_entry)=@year";

                return int.Parse(_dbGenericCommands.ExecuteScalar(query, parameters));

            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetViewRecords_By_Status_JournalName_Search_Month_Year(string jevStatus, string searchTxt, string journalName, string fundName, short month, short year)
        {
            var parameters = new object[][]
            {
                new object[] { "@journal_name", DbType.String, journalName},
                new object[] { "@fund_name", DbType.String, fundName},
                new object[] { "@searchTxt", DbType.String, $"%{searchTxt}%"},
                new object[] { "@month", DbType.Int16, month},
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
            string query = $"SELECT * FROM {viewTableName} WHERE {jevStatusQuery} {journalQuery} {fundQuery} MONTH(date_entry) <= @month AND YEAR(date_entry) = @year AND (jev_no LIKE @searchTxt OR ref_no LIKE @searchTxt OR payee LIKE @searchTxt OR explanation LIKE @searchTxt) ORDER BY full_jev_no";

            var dtGeneralLedgers = new DataTable();
            return _dbGenericCommands.FillBySearch(query, dtGeneralLedgers, parameters);
        }

        //SFPs
        public decimal GetSumByMajorAccountGroup(int fundId, int majorAccountGroupId, byte isDebit, DateTime dateEntry)
        {
            try
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
                decimal amount = Convert.ToDecimal(_dbGenericCommands.ExecuteScalar(query, parameters));
                return amount;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public decimal GetSumPreviousYearTransactionsByFundIdAndMajAccountGroupId(int fundId, int majorAccountGroupId, byte isDebit, DateTime dateEntry)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@funds_id", DbType.Int32, fundId},
                    new object[] { "@major_account_group_id",DbType.Int32, majorAccountGroupId},
                    new object[] { "@year", DbType.Int16, dateEntry.Year -1},
                    new object[] { "@is_debit", DbType.Byte, isDebit}
                };
                string query = $"SELECT COALESCE(SUM(b.amount), 0) AS amount FROM jev a JOIN jev_accounts b ON b.jev_id = a.id JOIN general_ledger_accounts c ON c.id = b.general_ledger_accounts_id JOIN sub_major_account_group d ON d.id = c.sub_major_account_group_id JOIN major_account_group e ON e.id = d.major_account_group_id JOIN account_group f ON f.id = e.account_group_id WHERE a.funds_id = @funds_id AND YEAR(a.date_entry) = @year AND e.id  = @major_account_group_id AND b.is_debit = @is_debit";
                decimal amount = Convert.ToDecimal(_dbGenericCommands.ExecuteScalar(query, parameters));
                return amount;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool SetJEVStatus(int jevId, string status)
        {
            var parameters = new object[][]
            {
                new object[] { "@jev_id", DbType.Int64, jevId},
            };

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
                    case "pending":
                        return "is_cancelled= 0, is_disapproved = 0, is_approved = 0";
                    default:
                        return "is_cancelled= 0, is_disapproved = 0, is_approved = 0";
                }
            }

            string query = $"UPDATE {tableName} SET {Status()} WHERE id = @jev_id";
            return _dbGenericCommands.ExecuteNonQuery(query, parameters);
        }

        public string GetJevStatus(int jevId)
        {
            var parameters = new object[][]
            {
                new object[] { "@jev_id", DbType.Int32, jevId}
            };
            string query = $"SELECT is_approved, is_disapproved, is_cancelled FROM {tableName} WHERE id = @jev_id";
            using (var reader = _dbGenericCommands.ExecuteReader(query, parameters))
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

        //REMARKS
        public bool SetRemarks(int jevId, string remarks)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@id", DbType.Int32, jevId},
                    new object[] { "@remarks", DbType.String, remarks}
                };

                string query = $"UPDATE {tableName} SET remarks = @remarks WHERE id = @id";

                return _dbGenericCommands.ExecuteNonQuery(query, parameters);
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

        public string GetRemarks(int jevId)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@id", DbType.Int32, jevId}
                };

                string query = $"SELECT remarks FROM {tableName} WHERE id = @id";
                return _dbGenericCommands.ExecuteScalar(query, parameters).ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}