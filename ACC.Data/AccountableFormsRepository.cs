using System;
using System.Collections.Generic;
using System.Data;
using System.Transactions;
using ACC.Domain.Interfaces;
using ACC.Domain.Models;

namespace ACC.Data
{
    public class AccountableFormsRepository:IAccountableRepository
    {
        private readonly IDbGenericCommands _dbGenericCommands;
        private readonly string tableName = "accountable_forms";
        private readonly string viewTableName = "view_accountable_forms";

        public AccountableFormsRepository(IDbGenericCommands dbGenericCommands)
        {
            _dbGenericCommands = dbGenericCommands;
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

                string query = $"SELECT acc_form_no,acc_form_desc FROM {tableName} WHERE id = @id";

                using (var reader = _dbGenericCommands.ExecuteReader(query, parameters))
                {
                    if (reader.Rows.Count < 1)
                        return record;

                    record.Add("acc_form_no", reader.Rows[0][0].ToString());
                    record.Add("acc_form_desc", reader.Rows[0][1].ToString());
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
                string query = $"SELECT * FROM {viewTableName}";

                var dtBanks = new DataTable();
                return _dbGenericCommands.Fill(query, dtBanks);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetRecords(int id)
        {
            try
            {
                string query = $"SELECT * FROM {tableName} WHERE id IN (SELECT receipts.accountable_forms_id FROM receipts LEFT JOIN receipts_issued ON receipts_issued.receipts_id = receipts.id WHERE receipts_issued.collecting_officers_id={id} AND IF(IFNULL(receipts_issued.is_returned,0)<1,false,true)=false AND IFNULL(receipts_issued.last_issued,0) < receipts_issued.issueto)";

                var dtBanks = new DataTable();
                return _dbGenericCommands.Fill(query, dtBanks);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool Insert(AccountableModel entity)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@acc_form_no", DbType.String, entity.AccFormNo},
                      new object[] { "@acc_form_desc", DbType.String, entity.AccFormDesc},
                };

                string query = $"INSERT INTO {tableName} (acc_form_no,acc_form_desc) VALUES (@acc_form_no,@acc_form_desc)";
                return _dbGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public bool Update(AccountableModel entity)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@id", DbType.Int16, entity.Id},
                     new object[] { "@acc_form_no", DbType.String, entity.AccFormNo},
                      new object[] { "@acc_form_desc", DbType.String, entity.AccFormDesc},
                };

                string query = $"UPDATE {tableName} SET acc_form_no = @acc_form_no, acc_form_desc = @acc_form_desc WHERE id = @id";
                return _dbGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public bool Delete(List<AccountableModel> entityList)
        {
            try
            {
                using (var scope = new TransactionScope())
                {
                    foreach (var entity in entityList)
                    {
                        var parameters = new object[][]
                        {
                            new object[] { "@id", DbType.Int16, entity.Id},
                        };

                        string query = $"DELETE FROM {tableName} WHERE id = @id";
                        _ = _dbGenericCommands.ExecuteNonQuery(query, parameters);
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


        public bool IdExist(int id)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@id", DbType.Int32, id },
                };

                string query = $"SELECT id FROM {tableName} WHERE id = @id";
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

        public bool CodeExist(string accountCode)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@acc_form_no", DbType.String, accountCode },
                };

                string query = $"SELECT acc_form_no FROM {tableName} WHERE acc_form_no = @acc_form_no";
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

        public bool CodeExist(string accountCode, int accId)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@id", DbType.Int16, accId },
                    new object[] { "@acc_form_no", DbType.String, accountCode },
                };

                string query = $"SELECT acc_form_no FROM {tableName} WHERE id <> @id AND acc_form_no = @acc_form_no";
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
        public DataTable GetRecordsBySearch(string searchText)
        {
            try
            {
                var srchtxt = searchText;

                string query = $"SELECT * FROM {viewTableName} WHERE acc_form_no  LIKE'%" + srchtxt + "%' OR acc_form_desc  LIKE'%" + srchtxt + "%'";

                var dtBanks = new DataTable();
                return _dbGenericCommands.Fill(query, dtBanks);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
