using System;
using System.Collections.Generic;
using System.Text;
using ACC.Domain.Models;
using ACC.Domain.Interfaces;
using System.Data;

namespace ACC.Data
{
    class CashDisbursementsJournalRepository : ICashDisbursementsJournalRepository
    {
        private readonly IDbGenericCommands _dbGenericCommands;
        private const string tableName = "cash_disbursement_journal";
        private const string viewTableName = "view_cash_disbursement_journal";

        public CashDisbursementsJournalRepository(IDbGenericCommands dbGenericCommands)
        {
            _dbGenericCommands = dbGenericCommands;
        }

        public int CountRecords()
        {
            throw new NotImplementedException();
        }

        public bool Delete(List<CashDisbursementsJournalModel> entityList)
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

        public bool Insert(CashDisbursementsJournalModel entity)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@jev_id", DbType.Int32, entity.JevId},
                    new object[] { "@disbursing_officers_id", DbType.Byte, entity.DisbursingOfficerId},
                    new object[] { "@dv_no", DbType.String, entity.DVNo},
                    new object[] { "@date_paid", DbType.Date, entity.DatePaid},
                };

                string query = $"INSERT INTO {tableName} (jev_id, disbursing_officers_id, dv_no, date_paid) VALUES (@jev_id, @disbursing_officers_id, @dv_no, @date_paid)";
                return _dbGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Update(CashDisbursementsJournalModel entity)
        {
            throw new NotImplementedException();
        }

        public bool UpdateByJevId(CashDisbursementsJournalModel entity)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@jev_id", DbType.Int32, entity.JevId},
                    new object[] { "@disbursing_officers_id", DbType.Byte, entity.DisbursingOfficerId},
                    new object[] { "@dv_no", DbType.String, entity.DVNo},
                    new object[] { "@date_paid", DbType.Date, entity.DatePaid},
                };

                string query = $"UPDATE {tableName} SET disbursing_officers_id = @disbursing_officers_id, dv_no = @dv_no, date_paid = @date_paid WHERE jev_id = @jev_id";
                return _dbGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
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

        public Dictionary<string, string> GetViewRecordByJevID(int jevId)
        {
            var record = new Dictionary<string, string>();

            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@jev_id", DbType.Int32, jevId},
                };

                string query = $"SELECT id, disbursing_officers_id, dv_no, date_paid, first_name, mid_initial, last_name, full_name, job_title FROM {viewTableName} WHERE jev_id = @jev_id";

                using (var reader = _dbGenericCommands.ExecuteReader(query, parameters))
                {
                    if (reader.Rows.Count < 1)
                        return record;

                    record.Add("id", reader.Rows[0]["id"].ToString());
                    record.Add("disbursing_officers_id", reader.Rows[0]["disbursing_officers_id"].ToString());
                    record.Add("dv_no", reader.Rows[0]["dv_no"].ToString());
                    record.Add("date_paid", reader.Rows[0]["date_paid"].ToString());
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
    }
}
