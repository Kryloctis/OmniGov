using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Transactions;

namespace ACC.Data
{
    public class FundsRepository : IFundsRepository
    {
        private readonly IAccGenericCommands _dbGenericCommands;
        private readonly string tableName = "funds";
        private readonly string tableName2 = "payment_collections";
        private readonly string tableName3 = "bank_deposits";

        public FundsRepository(IAccGenericCommands dbGenericCommands)
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

                string query = $"SELECT fund_code, fund_name, created_at, updated_at FROM {tableName} WHERE id = @id";

                using (var reader = _dbGenericCommands.ExecuteReader(query, parameters))
                {
                    if (reader.Rows.Count < 1)
                        return record;

                    record.Add("fund_code", reader.Rows[0][0].ToString());
                    record.Add("fund_name", reader.Rows[0][1].ToString());
                    record.Add("created_at", reader.Rows[0][2].ToString());
                    record.Add("updated_at", reader.Rows[0][3].ToString());
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
            string query = $"SELECT * FROM {tableName}";

            var dtFunds = new DataTable();
            return _dbGenericCommands.Fill(query, dtFunds);
        }

        public DataTable GetRecordsPrintCashposition(string date)
        {
            try
            {
                string query = $"SELECT {tableName}.id,CONCAT({tableName}.fund_name,'(',{tableName}.fund_code,')') AS fund,(SELECT IFNULL(SUM(amount),0) FROM {tableName3} WHERE funds_id={tableName}.id AND date < CAST('{date}' AS DATE)) AS beginning,(SELECT IFNULL(SUM(amount),0) FROM {tableName2} WHERE funds_id={tableName}.id AND payment_date=CAST('{date}' AS DATE)) AS collection,(SELECT IFNULL(SUM(amount),0) FROM {tableName3} WHERE funds_id={tableName}.id AND date = CAST('{date}' AS DATE)) AS deposited FROM {tableName}";

                var dtFunds = new DataTable();
                return _dbGenericCommands.Fill(query, dtFunds);
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
                var srchtxt = searchText;

                string query = $"SELECT * FROM {tableName} WHERE fund_code  LIKE'%" + srchtxt + "%' OR fund_name  LIKE'%" + srchtxt + "%'";

                var dtFunds = new DataTable();
                return _dbGenericCommands.Fill(query, dtFunds);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Insert(FundsModel entity)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@fund_name", DbType.String, entity.FundName},
                      new object[] { "@fund_code", DbType.String, entity.FundCode},
                };

                string query = $"INSERT INTO {tableName} (fund_code,fund_name) VALUES (@fund_code,@fund_name)";
                return _dbGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public bool Update(FundsModel entity)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@id", DbType.Int16, entity.Id},
                    new object[] { "@fund_name", DbType.String, entity.FundName},
                     new object[] { "@fund_code", DbType.String, entity.FundCode},
                };

                string query = $"UPDATE {tableName} SET fund_code = @fund_code, fund_name = @fund_name WHERE id = @id";
                return _dbGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public bool Delete(List<FundsModel> entityList)
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


        public bool NameExist(string fundName)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@fund_name", DbType.String, fundName },
                };

                string query = $"SELECT fund_name FROM {tableName} WHERE fund_name = @fund_name";
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


        public bool NameExist(string fundName, int fundId)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@id", DbType.Int16, fundId },
                    new object[] { "@fund_name", DbType.String, fundName },
                };

                string query = $"SELECT fund_name FROM {tableName} WHERE id <> @id AND fund_name = @fund_name";
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

        public bool CodeExist(string fundCode)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@fund_code", DbType.String, fundCode },
                };

                string query = $"SELECT fund_code FROM {tableName} WHERE fund_code = @fund_code";
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

        public bool CodeExist(string fundCode, int fundId)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@id", DbType.Int16, fundId },
                    new object[] { "@fund_code", DbType.String, fundCode },
                };

                string query = $"SELECT fund_code FROM {tableName} WHERE id <> @id AND fund_code = @fund_code";
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
