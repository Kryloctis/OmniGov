using OmniGov.Core.Entities;
using OmniGov.Core.Interfaces.Services;
using OmniGov.Treasury.Domain.Entities;
using OmniGov.Treasury.Domain.Interfaces;
using System.Data;
using System.Transactions;

namespace OmniGov.Treasury.Data.Repositories
{
    public class BankDepositsRepository : IBankDepositsRepository
    {
        private readonly string tableName = "bank_deposits";
        private readonly string viewTableName = "view_bank_deposits";
        private readonly IRcdDeposits _rcdDeposits;
        private readonly IGenericCommands _genericCommands;

        public BankDepositsRepository(IGenericCommands genericCommands,
                                      IRcdDeposits rcdDeposits)
        {
            _genericCommands = genericCommands ?? throw new ArgumentNullException(nameof(genericCommands));
            _rcdDeposits = rcdDeposits ?? throw new ArgumentNullException(nameof(rcdDeposits));
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            var recordDictionary = new Dictionary<string, string>();

            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, Id},
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

        public DataTable GetRecords()
        {
            string query = $"SELECT * FROM {viewTableName}";
            return _genericCommands.Fill(query, new DataTable());
        }

        public bool Insert(BankDepositsModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@bank_accounts_id", DbType.Int32, entity.BankAccountsID},
                new object[] { "@funds_id", DbType.Int32, entity.FundId},
                new object[] { "@reference", DbType.String, entity.Reference},
                new object[] { "@date", DbType.Date, entity.Date},
                new object[] { "@amount", DbType.Decimal, entity.Amount},
                new object[] { "@created_by", DbType.Int32, entity.CreatedBy},
            };

            string query = $"INSERT INTO {tableName} (bank_accounts_id, funds_id, reference, date, amount, created_by) VALUES (@bank_accounts_id, @funds_id, @reference, @date, @amount, @created_by)";
            return _genericCommands.ExecuteNonQuery(query, parameters);
        }

        public bool Update(BankDepositsModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, entity.Id},
                new object[] { "@bank_accounts_id", DbType.Int32, entity.BankAccountsID},
                new object[] { "@funds_id", DbType.Int32, entity.FundId},
                new object[] { "@reference", DbType.String, entity.Reference},
                new object[] { "@date", DbType.Date, entity.Date},
                new object[] { "@amount", DbType.Decimal, entity.Amount},
                new object[] { "@updated_by", DbType.Int32, entity.UpdatedBy},
            };

            string query = $"UPDATE {tableName} SET bank_accounts_id = @bank_accounts_id,  funds_id = @funds_id, reference = @reference, date = @date, amount = @amount, updated_by = @updated_by WHERE id = @id";
            return _genericCommands.ExecuteNonQuery(query, parameters);
        }

        public bool Delete(List<BankDepositsModel> entityList)
        {
            using (var scope = new TransactionScope())
            {
                foreach (var entity in entityList)
                {
                    var parameters = new object[][] { new object[] { "@id", DbType.Int32, entity.Id }, };
                    string query = $"DELETE FROM {tableName} WHERE id = @id";
                    _ = _genericCommands.ExecuteNonQuery(query, parameters);
                }

                scope.Complete();
                return true;
            }
        }

        public int CountRecords()
        {
            throw new NotImplementedException();
        }

        public bool IdExist(int id)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, id },
            };

            string query = $"SELECT id FROM {tableName} WHERE id = @id";
            string queryResult = _genericCommands.ExecuteScalar(query, parameters);
            return string.IsNullOrEmpty(queryResult);
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            var parameters = new object[][]
            {
                new object[] { "@search_text", DbType.String, $"%{searchText}%"},
            };

            string query = $"SELECT * FROM {viewTableName} WHERE reference LIKE @search_text OR account_no LIKE @search_text OR bank_name LIKE @search_text  OR amount LIKE @search_text";

            return _genericCommands.FillBySearch(query, new DataTable(), parameters);
        }

        public DataTable GetRecordsByBankAndAccountID(int bankID, int bankAccountID)
        {
            var parameter = new object[][]
            {
                new object[] { "@banks_id", DbType.Int32, bankID},
                new object[] { "@bank_account_id", DbType.Int32, bankAccountID},
            };

            string query = $"SELECT id, banks_id, account_no, bank_name, reference, date, amount, created_at, updated_at FROM {viewTableName} WHERE banks_id = @banks_id AND id = @bank_account_id ";
            return _genericCommands.FillBySearch(query, new DataTable(), parameter);
        }

        public DataTable GetViewRcdRecord(DateTime date, UsersModel createdBy)
        {
            var parameters = new object[][]
            {
                new object[] { "@date", DbType.DateTime, date},
                new object[] { "@created_by", DbType.Int32, createdBy.Id},
            };
            string query = $"SELECT * FROM {viewTableName} WHERE created_by = @created_by AND DATE(date) < DATE(@date) AND id NOT IN (SELECT bank_deposits_id FROM {_rcdDeposits.GetTableName()}) ORDER BY date ASC";
            return _genericCommands.FillBySearch(query, new DataTable(), parameters);
        }

        public DataTable GetViewRcdRecord(RcdDepositsModel rcdDepositsModel)
        {
            var parameters = new object[][]
            {
                new object[] { "@rcd_id", DbType.Int32, rcdDepositsModel.RcdModel.Id},
            };
            string query = $"SELECT * FROM {viewTableName} WHERE id IN (SELECT bank_deposits_id FROM {_rcdDeposits.GetTableName()} WHERE rcd_id = @rcd_id) ORDER BY date ASC";
            return _genericCommands.FillBySearch(query, new DataTable(), parameters);
        }

        public DataTable GetViewRecordBySearch(string searchKey, DateTime date, int filterRow)
        {
            var parameters = new object[][]
            {
                new object[] { "@search_key", DbType.String, $"%{searchKey}%"},
                new object[] { "@date", DbType.DateTime, date},
                new object[] { "@filter_row", DbType.Int32, filterRow},
            };

            string query = $"SELECT * FROM {viewTableName} WHERE DATE(date) <= DATE(@date) AND (account_no LIKE @search_key OR bank_code LIKE @search_key OR bank_code LIKE @search_key OR reference LIKE @search_key) LIMIT @filter_row";
            return _genericCommands.FillBySearch(query, new DataTable(), parameters);
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
    }
}
