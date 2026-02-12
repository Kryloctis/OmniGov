using Accounting.Domain.Entities;
using Accounting.Domain.Interfaces;
using OmniGov.Core.Repositories;
using System.Data;

namespace Accounting.Data.Repositories
{
    internal class CashDisbursementsJournalRepository : ICashDisbursementsJournalRepository
    {
        private GenericCommands mySqlGenericCommandsLFS;
        private const string tableName = "cash_disbursement_journal";
        private const string viewTableName = "view_cash_disbursement_journal";

        public CashDisbursementsJournalRepository(GenericCommands mySqlGenericCommandsLFS)
        {
            this.mySqlGenericCommandsLFS = mySqlGenericCommandsLFS;
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
            var parameters = new object[][]
            {
                new object[] { "@jev_id", DbType.Int32, entity.JevId},
                new object[] { "@disbursing_officers_id", DbType.Byte, entity.DisbursingOfficerId},
                new object[] { "@dv_no", DbType.String, entity.DVNo},
                new object[] { "@date_paid", DbType.Date, entity.DatePaid},
            };

            string query = $"INSERT INTO {tableName} (jev_id, disbursing_officers_id, dv_no, date_paid) VALUES (@jev_id, @disbursing_officers_id, @dv_no, @date_paid)";
            return mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
        }

        public bool Update(CashDisbursementsJournalModel entity)
        {
            throw new NotImplementedException();
        }

        public bool UpdateByJevId(CashDisbursementsJournalModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@jev_id", DbType.Int32, entity.JevId},
                new object[] { "@disbursing_officers_id", DbType.Byte, entity.DisbursingOfficerId},
                new object[] { "@dv_no", DbType.String, entity.DVNo},
                new object[] { "@date_paid", DbType.Date, entity.DatePaid},
            };

            string query = $"UPDATE {tableName} SET disbursing_officers_id = @disbursing_officers_id, dv_no = @dv_no, date_paid = @date_paid WHERE jev_id = @jev_id";
            return mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
        }

        public bool JevIdExist(int jevId)
        {
            var parameters = new object[][]
            {
                new object[] { "@jev_id", DbType.Int32, jevId },
            };

            string query = $"SELECT id FROM {tableName} WHERE jev_id = @jev_id";

            // if query is not null, means found some record, so true
            return !string.IsNullOrEmpty(mySqlGenericCommandsLFS.ExecuteScalar(query, parameters));
        }

        public Dictionary<string, string> GetViewRecordByJevID(int jevId)
        {
            var recordDictionary = new Dictionary<string, string>();

            var parameters = new object[][]
            {
                new object[] { "@jev_id", DbType.Int32, jevId},
            };

            string query = $"SELECT id, disbursing_officers_id, dv_no, date_paid, first_name, mid_initial, last_name, full_name, job_title FROM {viewTableName} WHERE jev_id = @jev_id";

            DataTable dataTable = mySqlGenericCommandsLFS.ExecuteReader(query, parameters);

            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];

                foreach (DataColumn column in dataTable.Columns)
                    recordDictionary[column.ColumnName] = row[column].ToString();

                return recordDictionary;
            }
            return recordDictionary;
        }

        public bool DeleteByJevId(int jevId)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, jevId},
            };

            string query = $"DELETE FROM {tableName} WHERE jev_id = @id";
            return mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
        }
    }
}