using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Transactions;

namespace ACC.Data
{
    internal class GeneralCollectionsDepositsRepository : IGeneralCollectionsDepositsRepository
    {
        private readonly IAccGenericCommands _dbGenericCommands;
        private readonly string tableName = "general_collections_deposits";
        private readonly string viewTableName = "view_general_collections_deposits";

        public GeneralCollectionsDepositsRepository(IAccGenericCommands dbGenericCommands)
        {
            _dbGenericCommands = dbGenericCommands;
        }

        public int CountRecords()
        {
            throw new NotImplementedException();
        }

        public bool Delete(List<GeneralCollectionsDepositsModel> entityList)
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

        public DataTable GetCollectionsDepositsByRCDNo(string rcdNo)
        {
            var parameter = new object[][] {
                new object[]{"@rcdNo", DbType.String, rcdNo }
            };

            string query = $"SELECT * FROM {viewTableName} WHERE rcd_no = @rcdNo";
            var dtRCD = new DataTable();

            return _dbGenericCommands.FillBySearch(query, dtRCD, parameter);
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

                string query = $"SELECT * FROM {tableName} WHERE id = @id";

                using (var reader = _dbGenericCommands.ExecuteReader(query, parameters))
                {
                    if (reader.Rows.Count < 1)
                        return record;
                    record.Add("id", reader.Rows[0]["id"].ToString());
                    record.Add("general_collections_id", reader.Rows[0]["general_collections_id"].ToString());
                    record.Add("bank_deposits_id", reader.Rows[0]["bank_deposits_id"].ToString());
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
            throw new NotImplementedException();
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            throw new NotImplementedException();
        }

        public bool IdExist(int id)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@general_collections_id", DbType.Int16, id },
                };

                string query = $"SELECT general_collections_id FROM {tableName} WHERE general_collections_id = @general_collections_id";
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

        public bool Insert(GeneralCollectionsDepositsModel entity)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@general_collections_id", DbType.Int16, entity.GeneralCollectionId},
                    new object[] { "@bank_deposits_id", DbType.Int16, entity.BankDepositId},
                };

                string query = $"INSERT INTO {tableName} (general_collections_id, bank_deposits_id) " +
                    $"VALUES (@general_collections_id, @bank_deposits_id)";
                return _dbGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Update(GeneralCollectionsDepositsModel entity)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@id", DbType.Int16, entity.Id},
                    new object[] { "@general_collections_id", DbType.Int16, entity.GeneralCollectionId},
                    new object[] { "@bank_deposits_id", DbType.Int16, entity.BankDepositId},
                };

                string query = $"UPDATE {tableName} SET general_collections_id=@general_collections_id,bank_deposits_id=@bank_deposits_id WHERE id=@id";
                return _dbGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}