using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace ACC.Data
{
    public class ADADisbursementsJournalRepository : IADADisbursementsJournalRepository
    {
        private readonly IAccGenericCommands _dbGenericCommands;
        private const string tableName = "ada_disbursement_journal";

        public ADADisbursementsJournalRepository(IAccGenericCommands dbGenericCommands)
        {
            _dbGenericCommands = dbGenericCommands;
        }

        public int CountRecords()
        {
            throw new NotImplementedException();
        }

        public bool Delete(List<ADADisbursementsJournalModel> entityList)
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

        public Dictionary<string, string> GetRecordByJevID(int jevId)
        {
            var record = new Dictionary<string, string>();

            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@jev_id", DbType.Int32, jevId},
                };

                string query = $"SELECT id, ada_no FROM {tableName} WHERE jev_id = @jev_id";

                using (var reader = _dbGenericCommands.ExecuteReader(query, parameters))
                {
                    if (reader.Rows.Count < 1)
                        return record;

                    record.Add("id", reader.Rows[0][0].ToString());
                    record.Add("ada_no", reader.Rows[0][1].ToString());
                }
            }
            catch (Exception)
            {
                throw;
            }

            return record;
        }

        public bool IdExist(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(ADADisbursementsJournalModel entity)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@jev_id", DbType.Int32, entity.JevId},
                    new object[] { "@ada_no", DbType.String, entity.ADANumber},
                    new object[] { "@dv_no", DbType.String, entity.DVNo},
                };

                string query = $"INSERT INTO {tableName} (jev_id, ada_no, dv_no) VALUES (@jev_id, @ada_no, @dv_no)";
                return _dbGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Update(ADADisbursementsJournalModel entity)
        {
            throw new NotImplementedException();
        }

        public bool UpdateByJevId(ADADisbursementsJournalModel entity)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@jev_id", DbType.Int32, entity.JevId},
                    new object[] { "@ada_no", DbType.String, entity.ADANumber},
                    new object[] { "@dv_no", DbType.String, entity.DVNo},
                };

                string query = $"UPDATE {tableName} SET ada_no = @ada_no, dv_no = @dv_no WHERE jev_id = @jev_id";
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

                string query = $"SELECT id, ada_no, dv_no FROM {tableName} WHERE jev_id = @jev_id";

                using (var reader = _dbGenericCommands.ExecuteReader(query, parameters))
                {
                    if (reader.Rows.Count < 1)
                        return record;

                    record.Add("id", reader.Rows[0]["id"].ToString());
                    record.Add("ada_no", reader.Rows[0]["ada_no"].ToString());
                    record.Add("dv_no", reader.Rows[0]["dv_no"].ToString());
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