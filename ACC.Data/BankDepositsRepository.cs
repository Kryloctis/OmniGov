using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Transactions;

namespace ACC.Data
{
    public class BankDepositsRepository : IBankDepositsRepository
    {
        private readonly IAccGenericCommands _dbGenericCommands;
        private readonly string tableName = "bank_deposits";
        private readonly string tableName2 = "banks";
        private readonly string tableName3 = "users";

        private readonly string viewTableName = "view_bank_deposits";



        public BankDepositsRepository(IAccGenericCommands dbGenericCommands)
        {
            _dbGenericCommands = dbGenericCommands;
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            var record = new Dictionary<string, string>();

          
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, Id},
            };

            string query = $"SELECT * FROM {viewTableName} WHERE id = @id";

            using (var reader = _dbGenericCommands.ExecuteReader(query, parameters))
            {
                if (reader.Rows.Count < 1)
                    return record;

                record.Add("banks_id", reader.Rows[0]["banks_id"].ToString());
                record.Add("funds_id", reader.Rows[0]["funds_id"].ToString());
                record.Add("reference", reader.Rows[0]["reference"].ToString());
                record.Add("date", reader.Rows[0]["date"].ToString());
                record.Add("amount", reader.Rows[0]["amount"].ToString());
                record.Add("created_at", reader.Rows[0]["created_at"].ToString());
                record.Add("created_by", reader.Rows[0]["created_by"].ToString());
                record.Add("updated_at", reader.Rows[0]["updated_at"].ToString());
                record.Add("updated_by", reader.Rows[0]["updated_by"].ToString());
            }

            return record;
        }

        public DataTable GetRecords()
        {
            string query = $"SELECT * FROM {viewTableName}";

            var dtBanks = new DataTable();
            return _dbGenericCommands.Fill(query, dtBanks);
        }

        public bool Insert(BankDepositsModel entity)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@bank_accounts_id", DbType.Int32, entity.BankAccountsID},
                    new object[] { "@funds_id", DbType.Int32, entity.fundId},
                    new object[] { "@reference", DbType.String, entity.Reference},
                    new object[] { "@date", DbType.Date, entity.Date},
                    new object[] { "@amount", DbType.Decimal, entity.Amount},
                    new object[] { "@created_by", DbType.Int32, entity.CreatedBy},
                };

                string query = $"INSERT INTO {tableName} (bank_accounts_id, funds_id, reference, date, amount, created_by) VALUES (@bank_accounts_id, @funds_id, @reference, @date, @amount, @created_by)";
                return _dbGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Deposits(BankDepositsModel entity)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@banks_id", DbType.Int16, entity.BankID},
                    new object[] { "@reference", DbType.String, entity.Reference},
                    new object[] { "@date", DbType.Date, entity.Date},
                    new object[] { "@amount", DbType.Decimal, entity.Amount},
                    new object[] { "@created_by", DbType.Int16, entity.CreatedBy},
                    new object[] { "@funds_id", DbType.Int16, entity.fundId},
                };

                string query = $"INSERT INTO {tableName} " +
                               $"(banks_id, reference, date, amount, created_by, funds_id) " +
                               $"VALUES (@banks_id, @reference, @date, @amount, @created_by, @funds_id)";
                return _dbGenericCommands.ExecuteNonQueryId(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Update(BankDepositsModel entity)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@id", DbType.Int32, entity.Id},
                    new object[] { "@bank_accounts_id", DbType.Int32, entity.BankAccountsID},
                    new object[] { "@funds_id", DbType.Int32, entity.fundId},
                    new object[] { "@reference", DbType.String, entity.Reference},
                    new object[] { "@date", DbType.Date, entity.Date},
                    new object[] { "@amount", DbType.Decimal, entity.Amount},
                    new object[] { "@updated_by", DbType.Int32, entity.UpdatedBy},
                };

                string query = $"UPDATE {tableName} SET bank_accounts_id = @bank_accounts_id,  funds_id = @funds_id, reference = @reference, date = @date, amount = @amount, updated_by = @updated_by WHERE id = @id";
                return _dbGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Delete(List<BankDepositsModel> entityList)
        {
            using (var scope = new TransactionScope())
            {
                foreach (var entity in entityList)
                {
                    var parameters = new object[][]
                    {
                        new object[] { "@id", DbType.Int16, entity.Id},
                    };

                    string query = $"DELETE FROM {tableName} WHERE bank_accounts_id = @id";
                    _ = _dbGenericCommands.ExecuteNonQuery(query, parameters);
                }

                scope.Complete();
                return true;
            }

        }

        public int CountRecords()
        {
            try
            {
                string query = $"SELECT COUNT(*) FROM {tableName}";

                return int.Parse(_dbGenericCommands.ExecuteScalar(query));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool IdExist(int id)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@id", DbType.Int32, id },
                };

                string query = $"SELECT id FROM {tableName} WHERE id = @id";
                string queryResult = _dbGenericCommands.ExecuteScalar(query, parameters);

                // if query is not null, means found some record, so true
                if (!string.IsNullOrEmpty(queryResult)) return true;
            }
            catch (Exception)
            {
                throw;
            };

            return false;
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            var parameters = new object[][]
            {
                new object[] { "@search_text", DbType.String, $"%{searchText}%"},
            };


            string query = $"SELECT * FROM {viewTableName} WHERE reference LIKE @search_text OR account_no LIKE @search_text OR bank_name LIKE @search_text  OR amount LIKE @search_text";

            var dtBankDeposits = new DataTable();
            return _dbGenericCommands.FillBySearch(query, dtBankDeposits, parameters);
       
        }

        public DataTable GetRecordsByBankAndAccountID(int bankID, int bankAccountID)
        {
            var parameter = new object[][] {
                new object[] { "@banks_id", DbType.Int32, bankID},
                new object[] { "@bank_account_id", DbType.Int32, bankAccountID},
            };

            string query = $"SELECT id, banks_id, account_no, bank_name, reference, date, amount, created_at, updated_at FROM {viewTableName} WHERE banks_id = @banks_id AND id = @bank_account_id ";

            var dtBanks = new DataTable();
            return _dbGenericCommands.FillBySearch(query, dtBanks, parameter);
       
        }

        public DataTable GetBankDepositsSummary()
        {
            string query = $"SELECT banks_id, account_no, bank_name, SUM(amount) AS amount FROM view_bank_deposits";

            var dtBanksDeposit = new DataTable();
            return _dbGenericCommands.FillBySearch(query, dtBanksDeposit);
        }
    }
}