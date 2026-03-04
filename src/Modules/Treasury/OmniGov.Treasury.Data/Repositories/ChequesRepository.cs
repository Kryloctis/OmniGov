using OmniGov.Core.Interfaces.Services;
using OmniGov.Treasury.Domain.Entities;
using OmniGov.Treasury.Domain.Interfaces;
using System.Data;
using System.Transactions;

namespace OmniGov.Treasury.Data.Repositories
{
    public class ChequesRepository : IChequesRepository
    {
        private readonly string tableName = "cheques";
        private readonly IGenericCommands _genericCommands;

        public ChequesRepository(IGenericCommands genericCommands)
        {
            _genericCommands = genericCommands ?? throw new ArgumentNullException(nameof(genericCommands));
        }

        public bool Delete(List<ChequesModel> entityList)
        {
            using (var scope = new TransactionScope())
            {
                foreach (ChequesModel chequesModel in entityList)
                {
                    var parameters = new object[][]
                    {
                        new object[] { "@id", DbType.Int32, chequesModel.Id}
                    };

                    string query = $"DELETE FROM {tableName} WHERE id = @id";
                    _ = _genericCommands.ExecuteNonQuery(query, parameters);
                }

                scope.Complete();
                return true;
            }
        }

        public int GetLastInsertId()
        {
            string query = $"SELECT MAX(id) FROM {tableName}";
            return Convert.ToInt32(_genericCommands.ExecuteScalar(query));
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            var dict = new Dictionary<string, string>();

            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, Id}
            };

            string query = $"SELECT id, bank_accounts_id, cheque_no, cheque_date, amount, created_at, updated_at FROM {tableName} WHERE id = @id";

            using (var reader = _genericCommands.ExecuteReader(query, parameters))
            {
                if (reader.Rows.Count < 1)
                    return dict;

                foreach (DataRow row in reader.Rows)
                {
                    dict.Add("bank_accounts_id", row["bank_accounts_id"].ToString());
                    dict.Add("cheque_no", row["cheque_no"].ToString());
                    dict.Add("cheque_date", row["cheque_date"].ToString());
                    dict.Add("amount", row["amount"].ToString());
                    dict.Add("created_at", row["created_at"].ToString());
                    dict.Add("updated_at", row["updated_at"].ToString());
                }
                return dict;
            }
        }

        public DataTable GetRecords()
        {
            string query = $"SELECT * FROM {tableName}";
            var dataTable = new DataTable();
            return _genericCommands.Fill(query, dataTable);
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            var parameters = new object[][]
            {
                new object[] { "@searchText", DbType.String, $"%{searchText}%"}
            };

            string query = $"SELECT * FROM {tableName} WHERE cheque_no LIKE @searchText";
            var dataTable = new DataTable();
            return _genericCommands.FillBySearch(query, dataTable, parameters);
        }

        public bool IdExist(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(ChequesModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@bank_accounts_id", DbType.Int32, entity.BankAccountsId },
                new object[] { "@cheque_no", DbType.String, entity.ChequeNo },
                new object[] { "@cheque_date", DbType.Date, entity.ChequeDate },
                new object[] { "@amount", DbType.Decimal, entity.Amount},
            };

            string query = $"INSERT INTO {tableName} (bank_accounts_id, cheque_no, cheque_date, amount) VALUES (@bank_accounts_id, @cheque_no, @cheque_date, @amount)";

            return _genericCommands.ExecuteNonQuery(query, parameters);
        }

        public bool Update(ChequesModel entity)
        {
            var parameters = new object[][]
           {
                new object[] { "@id", DbType.Int32, entity.Id },
                new object[] { "@bank_accounts_id", DbType.Int32, entity.BankAccountsId },
                new object[] { "@cheque_no", DbType.String, entity.ChequeNo },
                new object[] { "@cheque_date", DbType.Date, entity.ChequeDate },
                new object[] { "@amount", DbType.Decimal, entity.Amount},
           };

            string query = $"UPDATE {tableName} SET bank_accounts_id = @bank_accounts_id, cheque_no = @cheque_no, cheque_date = @cheque_date, amount = @amount WHERE id = @id";

            return _genericCommands.ExecuteNonQuery(query, parameters);
        }
    }
}
