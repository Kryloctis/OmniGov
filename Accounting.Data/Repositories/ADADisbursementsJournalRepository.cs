using Accounting.Domain.Entities;
using Accounting.Domain.Interfaces;
using OmniGov.Core.Interfaces.Services;
using System.Data;

namespace Accounting.Data.Repositories
{
    public class ADADisbursementsJournalRepository : IADADisbursementsJournalRepository
    {
        private const string tableName = "ada_disbursement_journal";
        private IGenericCommands genericCommands;

        public ADADisbursementsJournalRepository(IGenericCommands genericCommands)
        {
            this.genericCommands = genericCommands;
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
            var recordDictionary = new Dictionary<string, string>();

            var parameters = new object[][]
            {
                new object[] { "@jev_id", DbType.Int32, jevId},
            };

            string query = $"SELECT * FROM {tableName} WHERE jev_id = @jev_id";

            DataTable dataTable = genericCommands.ExecuteReader(query, parameters);

            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];

                foreach (DataColumn column in dataTable.Columns)
                    recordDictionary[column.ColumnName] = row[column].ToString();

                return recordDictionary;
            }
            return recordDictionary;
        }

        public bool IdExist(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(ADADisbursementsJournalModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@jev_id", DbType.Int32, entity.JevId},
                new object[] { "@ada_no", DbType.String, entity.AdaNo},
                new object[] { "@dv_no", DbType.String, entity.DvNo},
            };

            string query = $"INSERT INTO {tableName} (jev_id, ada_no, dv_no) VALUES (@jev_id, @ada_no, @dv_no)";
            return genericCommands.ExecuteNonQuery(query, parameters);
        }

        public bool Update(ADADisbursementsJournalModel entity)
        {
            throw new NotImplementedException();
        }

        public bool UpdateByJevId(ADADisbursementsJournalModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@jev_id", DbType.Int32, entity.JevId},
                new object[] { "@ada_no", DbType.String, entity.AdaNo},
                new object[] { "@dv_no", DbType.String, entity.DvNo},
            };

            string query = $"UPDATE {tableName} SET ada_no = @ada_no, dv_no = @dv_no WHERE jev_id = @jev_id";
            return genericCommands.ExecuteNonQuery(query, parameters);
        }

        public Dictionary<string, string> GetViewRecordByJevID(int jevId)
        {
            var recordDictionary = new Dictionary<string, string>();

            var parameters = new object[][]
            {
                new object[] { "@jev_id", DbType.Int32, jevId},
            };

            string query = $"SELECT * FROM {tableName} WHERE jev_id = @jev_id";

            DataTable dataTable = genericCommands.ExecuteReader(query, parameters);

            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];

                foreach (DataColumn column in dataTable.Columns)
                    recordDictionary[column.ColumnName] = row[column].ToString();

                return recordDictionary;
            }
            return recordDictionary;
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
                string queryResult = genericCommands.ExecuteScalar(query, parameters);

                // if query is not null, means found some record, so true
                if (!string.IsNullOrEmpty(queryResult)) return true;
            }
            catch (Exception)
            {
                throw;
            }
            ;

            return false;
        }

        public bool DeleteByJevId(int jevId)
        {
            var parameters = new object[][]
            {
                new object[] { "@jev_id", DbType.Int32, jevId}
            };

            string query = $"DELETE FROM {tableName} WHERE jev_id = @jev_id";
            return genericCommands.ExecuteNonQuery(query, parameters);
        }
    }
}