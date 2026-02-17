using Accounting.Domain.Entities;
using Accounting.Domain.Interfaces;
using OmniGov.Core.Repositories;
using OmniGov.Core.Services;
using System.Data;

namespace Accounting.Data.Repositories
{
    internal class CashReceiptsJournalRepository : ICashReceiptsJournalRepository
    {
        private const string tableName = "cash_receipts_journal";
        private const string viewTableName = "view_cash_receipts_journal";
        private GenericCommands mySqlGenericCommands;

        public CashReceiptsJournalRepository(GenericCommands mySqlGenericCommands)
        {
            this.mySqlGenericCommands = mySqlGenericCommands;
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
            var parameters = new object[][]
            {
                new object[] { "@jev_id", DbType.Int32, entity.JevId},
                new object[] { "@collecting_officers_id", DbType.Byte, entity.CollectingOfficerId},
                new object[] { "@rcd_no", DbType.String, entity.RCDNo},
                new object[] { "@or_no", DbType.String, entity.ORNo},
                new object[] { "@or_date", DbType.Date, entity.ORDate},
            };

            string query = $"INSERT INTO {tableName} (jev_id, collecting_officers_id, rcd_no, or_no, or_date) VALUES (@jev_id, @collecting_officers_id, @rcd_no, @or_no, @or_date)";
            return mySqlGenericCommands.ExecuteNonQuery(query, parameters);
        }

        public bool Update(CashReceiptsJournalModel entity)
        {
            throw new NotImplementedException();
        }

        public bool UpdateByJevId(CashReceiptsJournalModel entity)
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
            return mySqlGenericCommands.ExecuteNonQuery(query, parameters);
        }

        public Dictionary<string, string> GetViewRecordByJevID(int jevId)
        {
            var recordDictionary = new Dictionary<string, string>();

            var parameters = new object[][]
            {
                    new object[] { "@jev_id", DbType.Int32, jevId},
            };

            string query = $"SELECT id, collecting_officers_id, rcd_no, or_no, or_date, first_name, mid_initial, last_name, full_name, job_title FROM {viewTableName} WHERE jev_id = @jev_id";

            DataTable dataTable = mySqlGenericCommands.ExecuteReader(query, parameters);

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
            return mySqlGenericCommands.ExecuteNonQuery(query, parameters);
        }
    }
}

