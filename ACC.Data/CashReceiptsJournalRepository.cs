using System;
using System.Collections.Generic;
using System.Data;
using ACC.Domain.Interfaces;
using ACC.Domain.Models;

namespace ACC.Data
{
    class CashReceiptsJournalRepository : ICashReceiptsJournalRepository
    {
        private readonly IDbGenericCommands _dbGenericCommands;
        private const string tableName = "cash_receipts_journal";

        public CashReceiptsJournalRepository(IDbGenericCommands dbGenericCommands)
        {
            _dbGenericCommands = dbGenericCommands;
        }

        public int CountRecords()
        {
            throw new NotImplementedException();
        }

        public bool Delete(List<CashReceiptsJournalModel> entityList)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public bool IdExist(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(CashReceiptsJournalModel entity)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@jev_id", DbType.Int32, entity.JevId},
                    new object[] { "@collecting_officers_id", DbType.Byte, entity.CollectingOfficerId},
                    new object[] { "@rcd_number", DbType.String, entity.RCDNumber},
                };

                string query = $"INSERT INTO {tableName} (jev_id, collecting_officers_id, rcd_number) VALUES (@jev_id, @collecting_officers_id, @rcd_number)";
                return _dbGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Update(CashReceiptsJournalModel entity)
        {
            throw new NotImplementedException();
        }

        public bool UpdateByJevId(CashReceiptsJournalModel entity)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@jev_id", DbType.Int32, entity.JevId},
                    new object[] { "@collecting_officers_id", DbType.Byte, entity.CollectingOfficerId},
                    new object[] { "@rcd_number", DbType.String, entity.RCDNumber},
                };

                string query = $"UPDATE {tableName} SET collecting_officers_id = @collecting_officers_id, rcd_number = @rcd_number WHERE jev_id = @jev_id";
                return _dbGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Dictionary<string, string> GetRecordByJevID(int jevId)
        {
            var record = new Dictionary<string, string>();

            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@jev_id", DbType.Int32, jevId},
                };

                string query = $"SELECT id, collecting_officers_id, rcd_number FROM {tableName} WHERE jev_id = @jev_id";

                using (var reader = _dbGenericCommands.ExecuteReader(query, parameters))
                {
                    if (reader.Rows.Count < 1)
                        return record;

                    record.Add("id", reader.Rows[0][0].ToString());
                    record.Add("collecting_officers_id", reader.Rows[0][1].ToString());
                    record.Add("rcd_number", reader.Rows[0][2].ToString());
                }
            }
            catch (Exception)
            {
                throw;
            }

            return record;
        }

        public bool JevIdExist(int jevId)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@jev_id", DbType.Int32, jevId },
                };

                string query = $"SELECT id FROM {tableName} WHERE jev_id = @jev_id";
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
