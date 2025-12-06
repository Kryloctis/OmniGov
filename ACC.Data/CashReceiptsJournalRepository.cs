using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace ACC.Data
{
    internal class CashReceiptsJournalRepository : ICashReceiptsJournalRepository
    {
        private const string tableName = "cash_receipts_journal";
        private const string viewTableName = "view_cash_receipts_journal";
        private AccGenericCommands mySqlGenericCommandsLFS;

        public CashReceiptsJournalRepository(AccGenericCommands mySqlGenericCommandsLFS)
        {
            this.mySqlGenericCommandsLFS = mySqlGenericCommandsLFS;
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
            return mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
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
            return mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
        }

        public Dictionary<string, string> GetViewRecordByJevID(int jevId)
        {
            var recordDictionary = new Dictionary<string, string>();

            var parameters = new object[][]
            {
                    new object[] { "@jev_id", DbType.Int32, jevId},
            };

            string query = $"SELECT id, collecting_officers_id, rcd_no, or_no, or_date, first_name, mid_initial, last_name, full_name, job_title FROM {viewTableName} WHERE jev_id = @jev_id";

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