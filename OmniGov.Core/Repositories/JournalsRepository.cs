using OmniGov.Core.Entities;
using OmniGov.Core.Interfaces;
using System.Data;
using System.Transactions;

namespace OmniGov.Core.Repositories
{
    public class JournalsRepository : IJournalsRepository
    {
        private readonly string tableName = "journals";
        private GenericCommands mySqlGenericCommandsLFS;

        public JournalsRepository(GenericCommands mySqlGenericCommandsLFS)
        {
            this.mySqlGenericCommandsLFS = mySqlGenericCommandsLFS;
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            var recordDictionary = new Dictionary<string, string>();

            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, Id},
            };

            string query = $"SELECT journal_name, is_special, created_at, updated_at FROM {tableName} WHERE id = @id";

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

        public DataTable GetRecords()
        {
            string query = $"SELECT * FROM {tableName}";
            return mySqlGenericCommandsLFS.Fill(query, new DataTable());
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            throw new NotImplementedException();
        }

        public bool Insert(JournalsModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@journal_name", DbType.String, entity.JournalName},
                new object[] { "@is_special", DbType.Boolean, entity.IsSpecialJournal},
            };

            string query = $"INSERT INTO {tableName} (journal_name, is_special) VALUES (@journal_name, @is_special)";
            return mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
        }

        public bool Update(JournalsModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int16, entity.Id},
                new object[] { "@journal_name", DbType.String, entity.JournalName},
                new object[] { "@is_special", DbType.Boolean, entity.IsSpecialJournal},
            };

            string query = $"UPDATE {tableName} SET journal_name = @journal_name, is_special = @is_special WHERE id = @id";
            return mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
        }

        public bool Delete(List<JournalsModel> entityList)
        {
            using (var scope = new TransactionScope())
            {
                foreach (var entity in entityList)
                {
                    var parameters = new object[][]
                    {
                        new object[] { "@id", DbType.Int16, entity.Id},
                    };

                    string query = $"DELETE FROM {tableName} WHERE id = @id";
                    _ = mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
                }

                scope.Complete();
                return true;
            }
        }

        public bool IdExist(int id)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, id },
            };

            string query = $"SELECT id FROM {tableName} WHERE id = @id";

            // if query is not null, means found some record, so true
            return !string.IsNullOrEmpty(mySqlGenericCommandsLFS.ExecuteScalar(query, parameters));
        }

        public bool NameExist(string journalName)
        {
            var parameters = new object[][]
            {
                new object[] { "@journal_name", DbType.String, journalName },
            };

            string query = $"SELECT journal_name FROM {tableName} WHERE journal_name = @journal_name";

            // if query is not null, means found some record, so true
            return !string.IsNullOrEmpty(mySqlGenericCommandsLFS.ExecuteScalar(query, parameters));
        }

        public bool NameExist(string journalName, int journalId)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int16, journalId },
                new object[] { "@journal_name", DbType.String, journalName },
            };

            string query = $"SELECT journal_name FROM {tableName} WHERE id <> @id AND journal_name = @journal_name";

            // if query is not null, means found some record, so true
            return string.IsNullOrEmpty(mySqlGenericCommandsLFS.ExecuteScalar(query, parameters));
        }
    }
}