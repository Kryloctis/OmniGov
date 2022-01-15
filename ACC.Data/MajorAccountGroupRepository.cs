using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Transactions;

namespace ACC.Data
{
    public class MajorAccountGroupRepository : IMajorAccountGroupRepository
    {
        private readonly IDbGenericCommands _dbGenericCommands;
        private readonly string tableName = "major_account_group";
        private readonly string viewTableName = "view_major_account_group";


        public MajorAccountGroupRepository(IDbGenericCommands dbGenericCommands)
        {
            _dbGenericCommands = dbGenericCommands;
        }

        public DataTable GetRecords()
        {
            string query = $"SELECT * FROM {tableName}";

            var dtJournals = new DataTable();
            return _dbGenericCommands.Fill(query, dtJournals);
        }

        public DataTable GetViewRecords()
        {
            try
            {
                string query = $"SELECT maj_acc_group_id, maj_acc_group_code, maj_acc_group_name, account_group_name, created_at, updated_at FROM {viewTableName}";

                var dtJournals = new DataTable();
                return _dbGenericCommands.Fill(query, dtJournals);
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

                string query = $"SELECT account_group_id, maj_acc_group_code, maj_acc_group_name, created_at, updated_at FROM {tableName} WHERE id = @id";

                using (var reader = _dbGenericCommands.ExecuteReader(query, parameters))
                {
                    if (reader.Rows.Count < 1)
                        return record;

                    record.Add("account_group_id", reader.Rows[0][0].ToString());
                    record.Add("maj_acc_group_code", reader.Rows[0][1].ToString());
                    record.Add("maj_acc_group_name", reader.Rows[0][2].ToString());
                    record.Add("created_at", reader.Rows[0][3].ToString());
                    record.Add("updated_at", reader.Rows[0][4].ToString());
                }
            }
            catch (Exception)
            {
                throw;
            }

            return record;
        }

        public DataTable GetViewRecordsByAccountGroupId(byte id)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Byte, id},
            };

            string query = $"SELECT maj_acc_group_id, maj_acc_group_code, maj_acc_group_name, account_group_name, created_at, updated_at FROM {viewTableName} WHERE account_group_id =  @id";

            return _dbGenericCommands.ExecuteReader(query, parameters);
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            throw new NotImplementedException();
        }

        public bool Insert(MajorAccountGroupModel entity)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@account_group_id", DbType.Byte, entity.AccountGroupId},
                    new object[] { "@maj_acc_group_code", DbType.String, entity.MajorAccountGroupCode},
                    new object[] { "@maj_acc_group_name", DbType.String, entity.MajorAccountGroupName},
                };

                string query = $"INSERT INTO {tableName} (account_group_id, maj_acc_group_code, maj_acc_group_name) VALUES (@account_group_id, @maj_acc_group_code, @maj_acc_group_name)";
                return _dbGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Update(MajorAccountGroupModel entity)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@id", DbType.Int16, entity.Id},
                    new object[] { "@account_group_id", DbType.Byte, entity.AccountGroupId},
                    new object[] { "@maj_acc_group_code", DbType.String, entity.MajorAccountGroupCode},
                    new object[] { "@maj_acc_group_name", DbType.String, entity.MajorAccountGroupName},
                };

                string query = $"UPDATE {tableName} SET account_group_id = @account_group_id, maj_acc_group_code = @maj_acc_group_code, maj_acc_group_name = @maj_acc_group_name WHERE id = @id";
                return _dbGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Delete(List<MajorAccountGroupModel> entityList)
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

        public bool IdExist(int id)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@id", DbType.Int16, id },
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

        public bool CodeExist(string code)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@maj_acc_group_code", DbType.String, code },
                };

                string query = $"SELECT maj_acc_group_code FROM {tableName} WHERE maj_acc_group_code = @maj_acc_group_code";
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

        public bool CodeExist(string code, int id)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@id", DbType.Int16, id },
                    new object[] { "@maj_acc_group_code", DbType.String, code },
                };

                string query = $"SELECT maj_acc_group_code FROM {tableName} WHERE id <> @id AND maj_acc_group_code = @maj_acc_group_code";
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

        public bool NameExist(string name)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@maj_acc_group_name", DbType.String, name },
                };

                string query = $"SELECT maj_acc_group_name FROM {tableName} WHERE maj_acc_group_name = @maj_acc_group_name";
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

        public bool NameExist(string name, int id)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@id", DbType.Int16, id },
                    new object[] { "@maj_acc_group_name", DbType.String, name },
                };

                string query = $"SELECT maj_acc_group_name FROM {tableName} WHERE id <> @id AND maj_acc_group_name = @maj_acc_group_name";
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
    }
}
