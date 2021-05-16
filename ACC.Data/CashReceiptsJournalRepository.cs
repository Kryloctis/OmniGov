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
        private const string viewTableName = "view_cash_receipts_journal";

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
                    new object[] { "@rcd_no", DbType.String, entity.RCDNo},
                    new object[] { "@or_no", DbType.String, entity.ORNo},
                    new object[] { "@or_date", DbType.Date, entity.ORDate},
                };

                string query = $"INSERT INTO {tableName} (jev_id, collecting_officers_id, rcd_no, or_no, or_date) VALUES (@jev_id, @collecting_officers_id, @rcd_no, @or_no, @or_date)";
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
                    new object[] { "@rcd_no", DbType.String, entity.RCDNo},
                    new object[] { "@or_no", DbType.String, entity.ORNo},
                    new object[] { "@or_date", DbType.Date, entity.ORDate},
                };

                string query = $"UPDATE {tableName} SET collecting_officers_id = @collecting_officers_id, rcd_no = @rcd_no, or_no = @or_no, or_date = @or_date WHERE jev_id = @jev_id";
                return _dbGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Dictionary<string, string> GetViewRecordByJevID(int jevId)
        {
            var record = new Dictionary<string, string>();

            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@jev_id", DbType.Int32, jevId},
                };

                string query = $"SELECT id, collecting_officers_id, rcd_no, or_no, or_date, first_name, mid_initial, last_name, full_name, job_title FROM {viewTableName} WHERE jev_id = @jev_id";

                using (var reader = _dbGenericCommands.ExecuteReader(query, parameters))
                {
                    if (reader.Rows.Count < 1)
                        return record;

                    record.Add("id", reader.Rows[0]["id"].ToString());
                    record.Add("collecting_officers_id", reader.Rows[0]["collecting_officers_id"].ToString());
                    record.Add("rcd_no", reader.Rows[0]["rcd_no"].ToString());
                    record.Add("or_no", reader.Rows[0]["or_no"].ToString());
                    record.Add("or_date", reader.Rows[0]["or_date"].ToString());
                    record.Add("first_name", reader.Rows[0]["first_name"].ToString());
                    record.Add("mid_initial", reader.Rows[0]["mid_initial"].ToString());
                    record.Add("last_name", reader.Rows[0]["last_name"].ToString());
                    record.Add("full_name", reader.Rows[0]["full_name"].ToString());
                    record.Add("job_title", reader.Rows[0]["job_title"].ToString());
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
