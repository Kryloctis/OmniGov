using OmniGov.Core.Interfaces.Services;
using System.Data;
using System.Transactions;
using Treasury.Domain.Entities;
using Treasury.Domain.Interfaces;

namespace Treasury.Data.Repositories
{
    internal class BankAccountsRepository : IBankAccountsRepository
    {
        private readonly string tableName = "bank_accounts";
        private readonly string viewTableName = "view_bank_accounts";
        private readonly IGenericCommands _genericCommands;

        public BankAccountsRepository(IGenericCommands genericCommands)
        {
            _genericCommands = genericCommands ?? throw new ArgumentNullException(nameof(genericCommands));
        }

        public bool Delete(List<BankAccountsModel> entityList)
        {
            using (var scope = new TransactionScope())
            {
                foreach (var entity in entityList)
                {
                    var parameters = new object[][] { new object[] { @"id", DbType.Int32, entity.Id } };

                    string query = $"DELETE FROM {tableName} WHERE id = @id";
                    _ = _genericCommands.ExecuteNonQuery(query, parameters);
                }

                scope.Complete();
                return true;
            }
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            var recordDictionary = new Dictionary<string, string>();

            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, Id},
            };

            string query = $"SELECT * FROM {tableName} WHERE id = @id";

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

        public DataTable GetRecords()
        {
            string query = $"SELECT * FROM {tableName}";
            return _genericCommands.Fill(query, new DataTable());
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            var parameters = new object[][]
            {
                new object[]{"@searchText", DbType.String, $"%{searchText}%"},
            };

            string query = $"SELECT * FROM {tableName} WHERE account_no LIKE @searchText";
            return _genericCommands.FillBySearch(query, new DataTable(), parameters);
        }

        public DataTable GetViewRecords()
        {
            string query = $"SELECT * FROM {viewTableName}";
            return _genericCommands.Fill(query, new DataTable());
        }

        public DataTable GetViewRecordsBySearch(int rowLimit, string searchKey)
        {
            var parameters = new object[][]
            {
                new object[] { "@row_limit", DbType.Int32, rowLimit },
                new object[] { "@searchText", DbType.String, $"%{searchKey}%" },
            };

            string query = $"SELECT * FROM {viewTableName} WHERE (account_no LIKE @searchText OR bank_name LIKE @searchText) LIMIT @row_limit";
            return _genericCommands.FillBySearch(query, new DataTable(), parameters);
        }

        public bool IdExist(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(BankAccountsModel entity)
        {
            var parameters = new object[][]
            {
                new object[] {"@banks_id", DbType.String, entity.BanksModel.Id},
                new object[] {"@account_no", DbType.String, entity.AccountNumber},
            };

            string query = $"INSERT INTO {tableName} (banks_id, account_no) VALUES (@banks_id, @account_no)";
            return _genericCommands.ExecuteNonQuery(query, parameters);
        }

        public bool Update(BankAccountsModel entity)
        {
            var parameters = new object[][]
            {
                new object[]{"@id", DbType.Int32, entity.Id},
                new object[]{"@banks_id", DbType.Int32, entity.BanksModel.Id},
                new object[]{"@account_no", DbType.String, entity.AccountNumber},
            };

            string query = $"UPDATE {tableName} SET banks_id = @banks_id, account_no = @account_no WHERE id = @id";
            return _genericCommands.ExecuteNonQuery(query, parameters);
        }

        public Dictionary<string, string> GetViewRecordById(int id)
        {
            var recordDictionary = new Dictionary<string, string>();

            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, id}
            };

            string query = $"SELECT * FROM {viewTableName} WHERE id = @id";
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

        public DataTable GetBankAccountsByBankID(int bankID)
        {
            var parameters = new object[][]
            {
                new object[]{"@banks_id", DbType.String, bankID},
            };

            string query = $"SELECT * FROM {tableName} WHERE banks_id = @banks_id";
            return _genericCommands.FillBySearch(query, new DataTable(), parameters);
        }
    }
}