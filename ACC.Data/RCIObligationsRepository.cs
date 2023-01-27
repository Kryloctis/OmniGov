using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Transactions;

namespace ACC.Data
{
    public class RCIObligationsRepository : IRCIObligationsRepository
    {
        private readonly IAccGenericCommands _dbGenericCommands;
        private readonly string tableName = "rci_obligations";

        public RCIObligationsRepository(IAccGenericCommands dbGenericCommands)
        {
            _dbGenericCommands = dbGenericCommands;
        }

        public int CountRecords()
        {
            throw new NotImplementedException();
        }

        public bool Delete(List<RCIObligationsModel> entityList)
        {
            try
            {
                using (var scope = new TransactionScope())
                {
                    foreach (var entity in entityList)
                    {
                        var parameters = new object[][]
                        {
                            new object[] { "@id", DbType.Int32, entity.Id},
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

        public bool DeleteRecordsByRCIId(int rcidId)
        {
            using (var scope = new TransactionScope())
            {
                var parameters = new object[][]
                {
                    new object[] { "@id", DbType.Int32, rcidId }
                };

                string query = $"DELETE FROM {tableName} WHERE rci_id = @id";

                _ = _dbGenericCommands.ExecuteNonQuery(query, parameters);

                scope.Complete();
                return true;
            };
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            throw new NotImplementedException();
        }

        public DataTable GetRecords()
        {
            throw new NotImplementedException();
        }

        public DataTable GetRecordsByRCIId(int rciId)
        {
            try
            {
                var parameter = new object[][] {
                    new object[] {"@rciId", DbType.Int32, rciId}
                };

                string query = $"SELECT obligation_no FROM {tableName} WHERE rci_id = @rciId";
                var dtRCI = new DataTable();

                return _dbGenericCommands.FillBySearch(query, dtRCI, parameter);
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

        public bool IdExist(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(RCIObligationsModel entity)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@rci_id", DbType.Int32, entity.Rcid},
                    new object[] { "@obligations_id", DbType.String, entity.Obid}
                };

                string query = $"INSERT INTO {tableName} (rci_id,obligations_id) VALUES (@rci_id,@obligations_id)";
                return _dbGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Update(RCIObligationsModel entity)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@id", DbType.Int32, entity.Id},
                    new object[] { "@rci_id", DbType.Int32, entity.Rcid},
                    new object[] { "@obligations_id", DbType.String, entity.Obid}
                };

                string query = $"UPDATE {tableName} SET rci_id = @rci_id, obligations_id = @obligations_id WHERE id = @id";
                return _dbGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}