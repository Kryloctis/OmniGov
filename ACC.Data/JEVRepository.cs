using System;
using System.Collections.Generic;
using System.Data;
using System.Transactions;
using ACC.Domain.Interfaces;
using ACC.Domain.Models;

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
            throw new NotImplementedException();
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
                    new object[] { "@jev_no", DbType.String, $"%{searchText}%" },
                    new object[] { "@ref_no", DbType.String, $"%{searchText}%" },
                    new object[] { "@payee", DbType.String, $"%{searchText}%" },
                    new object[] { "@explanation", DbType.String, $"%{searchText}%" },
                };

                string query = $"SELECT id, funds_id, journals_id, jev_no, date_entry, ref_no, payee, explanation, is_approved, created_at, created_by, updated_at, updated_by FROM {viewTableName} WHERE is_approved = 1 AND (jev_no LIKE @jev_no OR ref_no LIKE @ref_no OR payee LIKE @payee OR explanation LIKE @explanation)";

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
                        new object[] { "@created_by", DbType.Byte, entity.CreatedBy },
                    };

                    string query = $"INSERT INTO {tableName} (funds_id, journals_id, jev_no, date_entry, ref_no, payee, explanation, created_by) VALUES (@funds_id, @journals_id, @jev_no, @date_entry, @ref_no, @payee, @explanation, @created_by);";

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
                    };

                    string query = $"UPDATE {tableName} SET funds_id = @funds_id, journals_id = @journals_id, jev_no = @jev_no, date_entry = @date_entry, ref_no = @ref_no, payee = @payee, explanation = @explanation, updated_by = @updated_by WHERE id = @id";

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

        public bool JevNumberExist(string jevNo)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@jev_no", DbType.String, jevNo },
                };

                string query = $"SELECT id FROM {tableName} WHERE jev_no = @jev_no";
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

        public bool JevNumberExist(string jevNo, int id)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@id", DbType.Int32, id },
                    new object[] { "@jev_no", DbType.String, jevNo },
                };

                string query = $"SELECT id FROM {tableName} WHERE id <> @id AND jev_no = @jev_no";
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

        public Dictionary<string, string> GetRecordByJEV(string jevNo)
        {
            var record = new Dictionary<string, string>();

            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@jev_no", DbType.String, jevNo},
                };

                string query = $"SELECT id, funds_id, fund_code, fund_name, journals_id, journal_name, is_special, jev_no, date_entry, ref_no, payee, explanation, created_at, created_by, created_by_name, updated_at, updated_by, updated_by_name FROM {viewTableName} WHERE is_approved = 1 AND jev_no = @jev_no";

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

        public int JevCounter(byte journalId)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@journals_id", DbType.Int32, journalId },
                };

                string query = $"SELECT COUNT(*) FROM {tableName} WHERE is_approved = 1 AND journals_id = @journals_id GROUP BY journals_id";

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
    }
}
