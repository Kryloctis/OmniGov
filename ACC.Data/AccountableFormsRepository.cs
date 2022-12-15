using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Transactions;

namespace ACC.Data
{
    public class AccountableFormsRepository : IAccountableRepository
    {
        private readonly IAccGenericCommands _dbGenericCommands;
        private readonly string tableName = "accountable_forms";
        private readonly string viewTableName = "view_accountable_forms";

        public AccountableFormsRepository(IAccGenericCommands dbGenericCommands)
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

                string query = $"SELECT acc_form_no, acc_form_desc FROM {tableName} WHERE id = @id";

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

        public Dictionary<string, string> GetRecordByAccFormNo(string accFormNo)
        {
            var dict = new Dictionary<string, string>();

            var parameters = new object[][]
            {
                new object[] { "@acc_form_no", DbType.String, accFormNo}
            };

            string query = $"SELECT id, acc_form_no, acc_form_desc FROM {tableName} WHERE acc_form_no = @acc_form_no";

            using (var reader = _dbGenericCommands.ExecuteReader(query, parameters))
            {
                if (reader.Rows.Count < 1)
                    return dict;

                foreach (DataRow row in reader.Rows)
                {
                    dict.Add("id", row["id"].ToString());
                    dict.Add("acc_form_no", row["acc_form_no"].ToString());
                    dict.Add("acc_form_desc", row["acc_form_desc"].ToString());
                }

                return dict;
            }
        }
    }
}