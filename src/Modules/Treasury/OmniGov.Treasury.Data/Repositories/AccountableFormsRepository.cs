using OmniGov.Core.Interfaces.Services;
using OmniGov.Treasury.Domain.Entities;
using OmniGov.Treasury.Domain.Interfaces;
using System.Data;
using System.Transactions;

namespace OmniGov.Treasury.Data.Repositories
{
    public class AccountableFormsRepository : IAccountableFormsRepository
    {
        private readonly string tableName = "accountable_forms";
        private readonly string viewTableName = "view_accountable_forms";
        private readonly IGenericCommands _genericCommands;

        public AccountableFormsRepository(IGenericCommands genericCommands)
        {
            _genericCommands = genericCommands ?? throw new ArgumentNullException(nameof(genericCommands));
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            var record = new Dictionary<string, string>();
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, Id},
            };

            string query = $"SELECT acc_form_no, acc_form_desc FROM {tableName} WHERE id = @id";

            using (var reader = _genericCommands.ExecuteReader(query, parameters))
            {
                if (reader.Rows.Count < 1)
                    return record;

                foreach (DataRow row in reader.Rows)
                {
                    record.Add("acc_form_no", row["acc_form_no"].ToString());
                    record.Add("acc_form_desc", row["acc_form_desc"].ToString());
                }
            }

            return record;
        }

        public DataTable GetRecords()
        {
            string query = $"SELECT * FROM {viewTableName}";

            var dataTable = new DataTable();
            return _genericCommands.Fill(query, dataTable);
        }

        public bool Insert(AccountableFormsModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@acc_form_no", DbType.String, entity.AccFormNo},
                new object[] { "@acc_form_desc", DbType.String, entity.AccFormDesc},
                new object[] { "@is_cash_ticket", DbType.Boolean, entity.IsCashTicket},
            };

            string query = $"INSERT INTO {tableName} (acc_form_no,acc_form_desc, is_cash_ticket) VALUES (@acc_form_no,@acc_form_desc, @is_cash_ticket)";
            return _genericCommands.ExecuteNonQuery(query, parameters);
        }

        public bool Update(AccountableFormsModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int16, entity.Id},
                new object[] { "@acc_form_no", DbType.String, entity.AccFormNo},
                new object[] { "@acc_form_desc", DbType.String, entity.AccFormDesc},
                new object[] { "@is_cash_ticket", DbType.Boolean, entity.IsCashTicket},
            };

            string query = $"UPDATE {tableName} SET acc_form_no = @acc_form_no, acc_form_desc = @acc_form_desc, is_cash_ticket = @is_cash_ticket WHERE id = @id";
            return _genericCommands.ExecuteNonQuery(query, parameters);
        }

        public bool Delete(List<AccountableFormsModel> entityList)
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

        public int CountRecords()
        {
            string query = $"SELECT COUNT(*) FROM {tableName}";

            return int.Parse(_genericCommands.ExecuteScalar(query));
        }

        public bool IdExist(int id)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, id },
            };

            string query = $"SELECT id FROM {tableName} WHERE id = @id";
            string queryResult = _genericCommands.ExecuteScalar(query, parameters);

            // if query is not null, means found some record, so true
            if (!string.IsNullOrEmpty(queryResult)) return true;
            return false;
        }

        public bool CodeExist(string accountCode)
        {
            var parameters = new object[][]
            {
                new object[] { "@acc_form_no", DbType.String, accountCode },
            };

            string query = $"SELECT acc_form_no FROM {tableName} WHERE acc_form_no = @acc_form_no";
            string queryResult = _genericCommands.ExecuteScalar(query, parameters);

            // if query is not null, means found some record, so true
            if (!string.IsNullOrEmpty(queryResult)) return true;

            return false;
        }

        public bool CodeExist(string accountCode, int accId)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int16, accId },
                new object[] { "@acc_form_no", DbType.String, accountCode },
            };

            string query = $"SELECT acc_form_no FROM {tableName} WHERE id <> @id AND acc_form_no = @acc_form_no";
            string queryResult = _genericCommands.ExecuteScalar(query, parameters);

            // if query is not null, means found some record, so true
            if (!string.IsNullOrEmpty(queryResult)) return true;

            return false;
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            var parameters = new object[][]
            {
                new object[] {"@search_text", DbType.String, $"%{searchText}%"}
            };

            string query = $"SELECT * FROM {viewTableName} WHERE acc_form_no  LIKE @search_text OR acc_form_desc  LIKE @search_text";

            var dataTable = new DataTable();
            return _genericCommands.FillBySearch(query, dataTable, parameters);
        }

        public DataTable GetCashTicketsAccountableForm()
        {
            string query = $"SELECT * FROM {viewTableName} WHERE is_cash_ticket = 1";

            var dataTable = new DataTable();
            return _genericCommands.Fill(query, dataTable);
        }

        public Dictionary<string, string> GetRecordByAccFormNo(string accFormNo)
        {
            var dict = new Dictionary<string, string>();

            var parameters = new object[][]
            {
                new object[] { "@acc_form_no", DbType.String, accFormNo}
            };

            string query = $"SELECT id, acc_form_no, acc_form_desc FROM {tableName} WHERE acc_form_no = @acc_form_no";

            using (var reader = _genericCommands.ExecuteReader(query, parameters))
            {
                if (reader.Rows.Count < 1)
                    return dict;

                foreach (DataRow row in reader.Rows)
                {
                    dict.Add("id", row["id"].ToString());
                    dict.Add("acc_form_no", row["acc_form_no"].ToString());
                    dict.Add("acc_form_desc", row["acc_form_desc"].ToString());
                }

                return dict;
            }
        }

        public DataTable GetRecordsByAccFormNo(string accFormNo)
        {
            var parameters = new object[][]
            {
                new object[] { "@acc_form_no", DbType.String, accFormNo }
            };

            string query = $"SELECT * FROM {tableName} WHERE acc_form_no = @acc_form_no";

            var dataTable = new DataTable();
            return _genericCommands.FillBySearch(query, dataTable, parameters);
        }
    }
}
