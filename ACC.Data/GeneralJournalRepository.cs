using System;
using System.Collections.Generic;
using System.Text;
using ACC.Domain.Models;
using ACC.Domain.Interfaces;
using System.Data;

namespace ACC.Data
{
    public class GeneralJournalRepository : IGeneralJournalRepository
    {
        private readonly IDbGenericCommands _dbGenericCommands;
        private readonly string tableName = "general_journal";
        private readonly string viewTableName = "view_general_journal";

        public GeneralJournalRepository(IDbGenericCommands dbGenericCommands)
        {
            _dbGenericCommands = dbGenericCommands;
        }

        public int CountRecords()
        {
            throw new NotImplementedException();
        }

        public bool Delete(List<GeneralJournalModel> entityList)
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

        public bool Insert(GeneralJournalModel entity)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@jev_id", DbType.Int32, entity.JevId},
                    new object[] { "@dv_no", DbType.String, entity.DVNo},
                    new object[] { "@check_no", DbType.String, entity.CheckNo},
                    new object[] { "@or_no", DbType.String, entity.ORNo},
                };

                string query = $"INSERT INTO {tableName} (jev_id, dv_no, check_no, or_no) VALUES (@jev_id, @dv_no, @check_no, @or_no);";
                return _dbGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Update(GeneralJournalModel entity)
        {
            throw new NotImplementedException();
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

        public bool UpdateByJevId(GeneralJournalModel entity)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@jev_id", DbType.Int32, entity.JevId},
                    new object[] { "@dv_no", DbType.String, entity.DVNo},
                    new object[] { "@check_no", DbType.String, entity.CheckNo},
                    new object[] { "@or_no", DbType.String, entity.ORNo},
                };

                string query = $"UPDATE {tableName} SET dv_no = @dv_no, check_no = @check_no, or_no = @or_no WHERE jev_id = @jev_id";
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

                string query = $"SELECT funds_id, journals_id, jev_no, date_entry, ref_no, payee, explanation, is_approved, created_at, created_by, updated_at, updated_by, general_journal_id, dv_no, check_no, or_no FROM {viewTableName} WHERE jev_id = @jev_id";

                using (var reader = _dbGenericCommands.ExecuteReader(query, parameters))
                {
                    if (reader.Rows.Count < 1)
                        return record;

                    record.Add("funds_id", reader.Rows[0]["funds_id"].ToString());
                    record.Add("journals_id", reader.Rows[0]["journals_id"].ToString());
                    record.Add("jev_no", reader.Rows[0]["jev_no"].ToString());
                    record.Add("date_entry", reader.Rows[0]["date_entry"].ToString());
                    record.Add("ref_no", reader.Rows[0]["ref_no"].ToString());
                    record.Add("payee", reader.Rows[0]["payee"].ToString());
                    record.Add("explanation", reader.Rows[0]["explanation"].ToString());
                    record.Add("is_approved", reader.Rows[0]["is_approved"].ToString());
                    record.Add("created_at", reader.Rows[0]["created_at"].ToString());
                    record.Add("created_by", reader.Rows[0]["created_by"].ToString());
                    record.Add("updated_at", reader.Rows[0]["updated_at"].ToString());
                    record.Add("updated_by", reader.Rows[0]["updated_by"].ToString());
                    record.Add("general_journal_id", reader.Rows[0]["general_journal_id"].ToString());
                    record.Add("dv_no", reader.Rows[0]["dv_no"].ToString());
                    record.Add("check_no", reader.Rows[0]["check_no"].ToString());
                    record.Add("or_no", reader.Rows[0]["or_no"].ToString());
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
