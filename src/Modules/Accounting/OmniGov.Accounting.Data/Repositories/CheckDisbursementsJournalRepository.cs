using OmniGov.Accounting.Domain.Entities;
using OmniGov.Accounting.Domain.Interfaces;
using OmniGov.Core.Interfaces.Services;
using System.Data;

namespace OmniGov.Accounting.Data.Repositories
{
    public class CheckDisbursementsJournalRepository : ICheckDisbursementsJournalRepository
    {
        private const string tableName = "check_disbursements_journal";
        private const string viewTableName = "view_check_disbursement_journal";
        private readonly IGenericCommands _genericCommands;

        public CheckDisbursementsJournalRepository(IGenericCommands genericCommands)
        {
            _genericCommands = genericCommands ?? throw new ArgumentNullException(nameof(genericCommands));
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
            var parameters = new object[][]
            {
                new object[] { "@jev_id", DbType.Int32, entity.JevId},
                new object[] { "@check_date", DbType.Date, entity.CheckDate},
                new object[] { "@check_no", DbType.String, entity.CheckNo},
                new object[] { "@dv_no", DbType.String, entity.DVNo},
                new object[] { "@rci_no", DbType.String, entity.RCINo},
            };

            string query = $"INSERT INTO {tableName} (jev_id, check_date, check_no, dv_no, rci_no) VALUES (@jev_id, @check_date, @check_no, @dv_no, @rci_no)";
            return _genericCommands.ExecuteNonQuery(query, parameters);
        }

        public bool Update(CheckDisbursementsJournalModel entity)
        {
            throw new NotImplementedException();
        }

        public bool UpdateByJevID(CheckDisbursementsJournalModel entity)
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
            return _genericCommands.ExecuteNonQuery(query, parameters);
        }

        public Dictionary<string, string> GetRecordByJevID(int jevId)
        {
            var recordDictionary = new Dictionary<string, string>();

            var parameters = new object[][]
            {
                new object[] { "@jev_id", DbType.Int32, jevId},
            };

            string query = $"SELECT id, payee, check_date, check_no, dv_no, rci_no FROM {viewTableName} WHERE jev_id = @jev_id";

            DataTable dataTable = _genericCommands.ExecuteReader(query, parameters);

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
            return _genericCommands.ExecuteNonQuery(query, parameters);
        }
    }
}