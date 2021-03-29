using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using ACC.Domain.Interfaces;
using ACC.Domain.Models;

namespace ACC.Data
{
    class ADADisbursementsJournalRepository : IADADisbursementsJournalRepository
    {
        private readonly IDbGenericCommands _dbGenericCommands;
        private const string tableName = "ada_disbursement_journal";

        public ADADisbursementsJournalRepository(IDbGenericCommands dbGenericCommands)
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
                };

                string query = $"INSERT INTO {tableName} (jev_id, ada_no) VALUES (@jev_id, @ada_no)";
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
    }
}
