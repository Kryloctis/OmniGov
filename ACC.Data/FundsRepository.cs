using System;
using System.Collections.Generic;
using System.Data;
using System.Transactions;
using ACC.Domain.Interfaces;
using ACC.Domain.Models;

namespace ACC.Data
{
   public class FundsRepository : IFundsRepository
    {
        private readonly IDbGenericCommands _dbGenericCommands;
        private readonly string tableName = "funds";
        

        public FundsRepository(IDbGenericCommands dbGenericCommands)
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

                string query = $"SELECT fund_name, created_at, updated_at FROM {tableName} WHERE id = @id";

                using (var reader = _dbGenericCommands.ExecuteReader(query, parameters))
                {
                    if (reader.Rows.Count < 1)
                        return record;

                    record.Add("fund_name", reader.Rows[0][0].ToString());
                    record.Add("created_at", reader.Rows[0][1].ToString());
                    record.Add("updated_at", reader.Rows[0][2].ToString());
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
            throw new NotImplementedException();
        }

        public bool Insert(FundsModel entity)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@fund_name", DbType.String, entity.FundName},
                };

                string query = $"INSERT INTO {tableName} (fund_name) VALUES (@fund_name)";
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
                };

                string query = $"UPDATE {tableName} SET fund_name = @fund_name WHERE id = @id";
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



    }
}
