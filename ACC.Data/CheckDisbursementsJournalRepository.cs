using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace ACC.Data
{
    public class CheckDisbursementsJournalRepository : ICheckDisbursementsJournalRepository
    {
        private readonly IAccGenericCommands _dbGenericCommands;
        private const string tableName = "check_disbursements_journal";
        private const string viewTableName = "view_check_disbursement_journal";

        public CheckDisbursementsJournalRepository(IAccGenericCommands dbGenericCommands)
        {
            _dbGenericCommands = dbGenericCommands;
        }

        public int CountRecords()
        {
            throw new NotImplementedException();
        }

        public bool Delete(List<CheckDisbursementsJournalModel> entityList)
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

        public bool Insert(CheckDisbursementsJournalModel entity)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@jev_id", DbType.Int32, entity.JevId},
                    new object[] { "@check_date", DbType.Date, entity.CheckDate},
                    new object[] { "@check_no", DbType.String, entity.CheckNo},
                    new object[] { "@dv_no", DbType.String, entity.DVNo},
                    new object[] { "@rci_no", DbType.String, entity.RCINo},
                };

                string query = $"INSERT INTO {tableName} (jev_id, check_date, check_no, dv_no, rci_no) VALUES (@jev_id, @check_date, @check_no, @dv_no, @rci_no)";
                return _dbGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Update(CheckDisbursementsJournalModel entity)
        {
            throw new NotImplementedException();
        }

        public bool UpdateByJevID(CheckDisbursementsJournalModel entity)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@jev_id", DbType.Int32, entity.JevId},
                    new object[] { "@check_date", DbType.Date, entity.CheckDate},
                    new object[] { "@check_no", DbType.String, entity.CheckNo},
                    new object[] { "@dv_no", DbType.String, entity.DVNo},
                    new object[] { "@rci_no", DbType.String, entity.RCINo},
                };

                string query = $"UPDATE {tableName} SET check_date = @check_date, check_no = @check_no, dv_no = @dv_no, rci_no = @rci_no WHERE jev_id = @jev_id";
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

                string query = $"SELECT id, payee, check_date, check_no, dv_no, rci_no FROM {viewTableName} WHERE jev_id = @jev_id";

                using (var reader = _dbGenericCommands.ExecuteReader(query, parameters))
                {
                    if (reader.Rows.Count < 1)
                        return record;

                    record.Add("id", reader.Rows[0]["id"].ToString());
                    record.Add("payee", reader.Rows[0]["payee"].ToString());
                    record.Add("check_date", reader.Rows[0]["check_date"].ToString());
                    record.Add("check_no", reader.Rows[0]["check_no"].ToString());
                    record.Add("dv_no", reader.Rows[0]["dv_no"].ToString());
                    record.Add("rci_no", reader.Rows[0]["rci_no"].ToString());
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

        public bool DeleteCheckDisbursementJournalByJevID(int jevId)
        {
            try
            {
                var parameters = new object[][]
                {
            new object[] { "@id", DbType.Int32, jevId},
                };

                string query = $"DELETE FROM {tableName} WHERE jev_id = @id";
                return _dbGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}