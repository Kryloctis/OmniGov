using Accounting.Domain.Entities;
using Accounting.Domain.Interfaces;
using OmniGov.Core.Repositories;
using OmniGov.Core.Services;
using System.Data;

namespace Accounting.Data.Repositories
{
    public class GeneralJournalRepository : IGeneralJournalRepository
    {
        private readonly string tableName = "general_journal";
        private readonly string viewTableName = "view_general_journal";
        private GenericCommands mySqlGenericCommands;

        public GeneralJournalRepository(GenericCommands mySqlGenericCommands)
        {
            this.mySqlGenericCommands = mySqlGenericCommands;
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
            var parameters = new object[][]
            {
                new object[] { "@jev_id", DbType.Int32, entity.JevId},
                new object[] { "@dv_no", DbType.String, entity.DVNo},
                new object[] { "@check_no", DbType.String, entity.CheckNo},
                new object[] { "@or_no", DbType.String, entity.ORNo},
            };

            string query = $"INSERT INTO {tableName} (jev_id, dv_no, check_no, or_no) VALUES (@jev_id, @dv_no, @check_no, @or_no);";
            return mySqlGenericCommands.ExecuteNonQuery(query, parameters);
        }

        public bool Update(GeneralJournalModel entity)
        {
            throw new NotImplementedException();
        }

        public bool JevIdExist(int jevId)
        {
            var parameters = new object[][]
            {
                new object[] { "@jev_id", DbType.Int32, jevId },
            };

            string query = $"SELECT id FROM {tableName} WHERE jev_id = @jev_id";

            // if query is not null, means found some record, so true
            return !string.IsNullOrEmpty(mySqlGenericCommands.ExecuteScalar(query, parameters));
        }

        public bool UpdateByJevId(GeneralJournalModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@jev_id", DbType.Int32, entity.JevId},
                new object[] { "@dv_no", DbType.String, entity.DVNo},
                new object[] { "@check_no", DbType.String, entity.CheckNo},
                new object[] { "@or_no", DbType.String, entity.ORNo},
            };

            string query = $"UPDATE {tableName} SET dv_no = @dv_no, check_no = @check_no, or_no = @or_no WHERE jev_id = @jev_id";
            return mySqlGenericCommands.ExecuteNonQuery(query, parameters);
        }

        public Dictionary<string, string> GetViewRecordByJevID(int jevId)
        {
            var recordDictionary = new Dictionary<string, string>();

            var parameters = new object[][]
            {
                new object[] { "@jev_id", DbType.Int32, jevId},
            };

            string query = $"SELECT funds_id, journals_id, jev_no, date_entry, ref_no, payee, explanation, is_approved, created_at, created_by, updated_at, updated_by, general_journal_id, dv_no, check_no, or_no FROM {viewTableName} WHERE jev_id = @jev_id";

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
            object[][] parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, jevId},
            };

            string query = $"DELETE FROM {tableName} WHERE jev_id = @id";
            return mySqlGenericCommands.ExecuteNonQuery(query, parameters);
        }
    }
}

