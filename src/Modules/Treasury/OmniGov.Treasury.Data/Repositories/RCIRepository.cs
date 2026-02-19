using OmniGov.Core.Interfaces.Services;
using System.Data;
using System.Transactions;
using Treasury.Domain.Entities;
using Treasury.Domain.Interfaces;

namespace Treasury.Data.Repositories
{
    public class RciRepository : IRciRepository
    {
        private readonly string tableName = "rci";
        private readonly string tableRciObligations = "rci_obligations";
        private readonly string tableRciDeductions = "rci_deductions";

        private readonly string viewTableName = "view_rci";
        private readonly IGenericCommands _genericCommands;

        public RciRepository(IGenericCommands genericCommands)
        {
            _genericCommands = genericCommands ?? throw new ArgumentNullException(nameof(genericCommands));
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            throw new NotImplementedException();
        }

        public DataTable GetRecords()
        {
            string query = $"SELECT * FROM {viewTableName}";
            return _genericCommands.Fill(query, new DataTable());
        }

        public DataTable GetViewRecordsByBankAccountIdAndMonth(int bankAccountID, string month)
        {
            var parameters = new object[][]
            {
                new object[] { "@bank_accouns_id", DbType.Int32, bankAccountID},
                new object[] { "@month", DbType.String, month},
            };

            string query = $"SELECT * FROM {viewTableName} WHERE bank_accounts_id = @bank_accouns_id AND MONTH(cheque_date) = @month";
            return _genericCommands.ExecuteReader(query, parameters);
        }

        public bool Insert(RciModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@cheques_id", DbType.Int32, entity.ChequeID},
                new object[] { "@funds_id", DbType.Int32, entity.FundId},
                new object[] { "@function_program_project_id", DbType.Int32, entity.FunctionProgramProjectId},
                new object[] { "@dv_no", DbType.String, entity.DVNo},
                new object[] { "@payee", DbType.String, entity.Payee},
                new object[] { "@nature_of_payment", DbType.String, entity.NaturePayment},
            };

            string query = $"INSERT INTO {tableName} (cheques_id, funds_id, function_program_project_id, dv_no, payee, nature_of_payment) VALUES(@cheques_id, @funds_id, @function_program_project_id, @dv_no, @payee, @nature_of_payment)";

            return _genericCommands.ExecuteNonQuery(query, parameters);
        }

        public bool Update(RciModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, entity.Id},
                new object[] { "@funds_id", DbType.Int32, entity.FundId},
                new object[] { "@function_program_project_id", DbType.Int32, entity.FunctionProgramProjectId},
                new object[] { "@dv_no", DbType.String, entity.DVNo},
                new object[] { "@payee", DbType.String, entity.Payee},
                new object[] { "@nature_of_payment", DbType.String, entity.NaturePayment},
            };

            string query = $"UPDATE {tableName} SET funds_id = @funds_id, function_program_project_id = @function_program_project_id, dv_no = @dv_no, payee = @payee, nature_of_payment = @nature_of_payment WHERE id = @id";

            return _genericCommands.ExecuteNonQuery(query, parameters);
        }

        public bool Delete(List<RciModel> entityList)
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
                    _ = _genericCommands.ExecuteNonQuery(query, parameters);
                }

                scope.Complete();
                return true;
            }
        }

        public bool IdExist(int id)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int16, id },
            };

            string query = $"SELECT id FROM {tableName} WHERE id = @id";
            string queryResult = _genericCommands.ExecuteScalar(query, parameters);

            return !string.IsNullOrEmpty(queryResult);
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            var parameter = new object[][]
            {
                new object[] { "@searchText", DbType.String, $"%{searchText}%"}
            };

            string query = $"SELECT * FROM {viewTableName} WHERE payee LIKE @searchText OR bank_name LIKE @searchText  OR bank_account_no LIKE @searchText OR obligation_no LIKE @searchText";

            return _genericCommands.FillBySearch(query, new DataTable(), parameter);
        }

        public DataTable GetRecordsByBankAndAccountID(int bankID, int bankAccountsID)
        {
            var parameter = new object[][]
            {
                new object[] { "@bank_id", DbType.Int32, bankID },
                new object[] { "@bank_accounts_id", DbType.Int32, bankAccountsID }
            };

            string query = $"SELECT * FROM {viewTableName} WHERE bank_id = @bank_id AND bank_accounts_id = @bank_accounts_id";
            return _genericCommands.FillBySearch(query, new DataTable(), parameter);
        }

        public bool SaveRciDvObligations(int rciId, string obligationNo, DateTime dateEntry)
        {
            var parameters = new object[][]
            {
                new object[] { "@rciId", DbType.Int32, rciId},
                new object[] { "@obligationNo", DbType.String, obligationNo},
                new object[] { "@date_entry", DbType.DateTime, dateEntry},
            };

            string query = $"INSERT INTO {tableRciObligations} (rci_id, obligation_no, date_entry) VALUES(@rciId, @obligationNo, @date_entry)";
            return _genericCommands.ExecuteNonQuery(query, parameters);
        }

        public bool SaveRciDeductions(int rciId, string description, decimal amount)
        {
            var parameters = new object[][]
            {
                new object[] { "@rciId", DbType.Int32, rciId},
                new object[] { "@obligationNo", DbType.String, description},
                new object[] { "@amount", DbType.Decimal, amount},
            };

            string query = $"INSERT INTO {tableRciDeductions} (rci_id, description, amount) VALUES(@rciId, @obligationNo, @amount)";
            return _genericCommands.ExecuteNonQuery(query, parameters);
        }

        public int GetLastInsertId()
        {
            string query = $"SELECT MAX(id) FROM {tableName}";
            return Convert.ToInt32(_genericCommands.ExecuteScalar(query));
        }

        public DataTable GetViewRecords()
        {
            string query = $"SELECT * FROM {viewTableName}";
            return _genericCommands.Fill(query, new DataTable());
        }

        public DataTable GetViewRecordsBySearch(string searchText)
        {
            var parameters = new object[][]
            {
                new object[] { "@search_text", DbType.String, $"%{searchText}%"},
            };

            string query = $"SELECT * FROM {viewTableName} WHERE cheque_no LIKE @search_text OR bank_account_no LIKE @search_text OR bank_name LIKE @search_text OR dv_no LIKE @search_text OR obligation_no LIKE @search_text OR payee LIKE @search_text";

            return _genericCommands.FillBySearch(query, new DataTable(), parameters);
        }

        public Dictionary<string, string> GetViewRecordById(int Id)
        {
            var recordDictionary = new Dictionary<string, string>();

            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, Id},
            };

            string query = $"SELECT * FROM {viewTableName} WHERE id = @id";
            var dataTable = _genericCommands.ExecuteReader(query, parameters);
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