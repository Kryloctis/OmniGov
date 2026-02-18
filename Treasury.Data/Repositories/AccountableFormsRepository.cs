using OmniGov.Core.Repositories;
using OmniGov.Core.Services;
using System.Data;
using System.Transactions;
using Treasury.Domain.Entities;
using Treasury.Domain.Interfaces;

namespace Treasury.Data.Repositories
{
    public class AccountableFormsRepository : IAccountableFormsRepository
    {
        private readonly string tableName = "accountable_forms";
        private readonly string viewTableName = "view_accountable_forms";
        private GenericCommands mySqlGenericCommands;

        public AccountableFormsRepository(GenericCommands mySqlGenericCommands)
        {
            this.mySqlGenericCommands = mySqlGenericCommands;
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            var record = new Dictionary<string, string>();
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, Id},
            };

            string query = $"SELECT acc_form_no, acc_form_desc FROM {tableName} WHERE id = @id";

            using (var reader = mySqlGenericCommands.ExecuteReader(query, parameters))
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
            return mySqlGenericCommands.Fill(query, dataTable);
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
            return mySqlGenericCommands.ExecuteNonQuery(query, parameters);
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
            return mySqlGenericCommands.ExecuteNonQuery(query, parameters);
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
                    _ = mySqlGenericCommands.ExecuteNonQuery(query, parameters);
                }

                scope.Complete();
                return true;
            }
        }

        public int CountRecords()
        {
            string query = $"SELECT COUNT(*) FROM {tableName}";

            return int.Parse(mySqlGenericCommands.ExecuteScalar(query));
        }

        public bool IdExist(int id)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, id },
            };

            string query = $"SELECT id FROM {tableName} WHERE id = @id";
            string queryResult = mySqlGenericCommands.ExecuteScalar(query, parameters);

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
            string queryResult = mySqlGenericCommands.ExecuteScalar(query, parameters);

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
            string queryResult = mySqlGenericCommands.ExecuteScalar(query, parameters);

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
            return mySqlGenericCommands.FillBySearch(query, dataTable, parameters);
        }

        public DataTable GetCashTicketsAccountableForm()
        {
            string query = $"SELECT * FROM {viewTableName} WHERE is_cash_ticket = 1";

            var dataTable = new DataTable();
            return mySqlGenericCommands.Fill(query, dataTable);
        }

        public Dictionary<string, string> GetRecordByAccFormNo(string accFormNo)
        {
            var dict = new Dictionary<string, string>();

            var parameters = new object[][]
            {
                new object[] { "@acc_form_no", DbType.String, accFormNo}
            };

            string query = $"SELECT id, acc_form_no, acc_form_desc FROM {tableName} WHERE acc_form_no = @acc_form_no";

            using (var reader = mySqlGenericCommands.ExecuteReader(query, parameters))
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
            return mySqlGenericCommands.FillBySearch(query, dataTable, parameters);
        }
    }
}

