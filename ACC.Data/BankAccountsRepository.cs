using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Contracts;
using System.Transactions;

namespace ACC.Data
{
    internal class BankAccountsRepository : IBankAccountsRepository
    {
        private readonly IAccGenericCommands _dbGenericCommands;
        private readonly string tableName = "bank_accounts";
        private readonly string viewTableName = "view_bank_accounts";
        private IBanksRepository _banksRepository;

        public BankAccountsRepository(IAccGenericCommands dbGenericCommands, IBanksRepository banksRepository)
        {
            _dbGenericCommands = dbGenericCommands;
            _banksRepository = banksRepository;
        }

        public bool bankAccountExist(string accountNo, string bankName)
        {
            var parameters = new object[][]
            {
                new object[] { "@account_no", DbType.String, accountNo.ToLower().Trim()},
                new object[] { "@bank_name", DbType.String, bankName.ToLower().Trim()}
            };

            string query = $"SELECT id FROM {viewTableName} WHERE LOWER(account_no) = @account_no AND LOWER(bank_name) = @bank_name";
            string result = _dbGenericCommands.ExecuteScalar(query, parameters);
            if (!string.IsNullOrEmpty(result))
                return true;
            return false;
        }

        public int CountRecords()
        {
            throw new NotImplementedException();
        }

        public bool Delete(List<BankAccountsModel> entityList)
        {
            using (var scope = new TransactionScope())
            {
                foreach (var entity in entityList)
                {
                    var parameters = new object[][] { new object[] { @"id", DbType.Int32, entity.ID } };

                    string query = $"DELETE FROM {tableName} WHERE id = @id";
                    _ = _dbGenericCommands.ExecuteNonQuery(query, parameters);
                }

                scope.Complete();
                return true;
            }
        }

        public Dictionary<string, string> GetViewRecordByAccountNoBankName(string accountNo, string bankName)
        {
            var record = new Dictionary<string, string>();

            var parameters = new object[][]
            {
                new object[] { "@account_no", DbType.String, accountNo.ToLower().Trim()},
                new object[] { "@bank_name", DbType.String, bankName.ToLower().Trim() }
            };

            string query = $"SELECT * FROM {viewTableName} WHERE LOWER(account_no) = @account_no AND LOWER(bank_name) = @bank_name";

            using (var reader = _dbGenericCommands.ExecuteReader(query, parameters))
            {
                if (reader.Rows.Count < 1)
                    return record;

                foreach (DataRow row in reader.Rows)
                {
                    record.Add("id", row["id"].ToString());
                    record.Add("account_no", row["account_no"].ToString());
                    record.Add("banks_id", row["banks_id"].ToString());
                    record.Add("bank_code", row["created_at"].ToString());
                    record.Add("bank_name", row["updated_at"].ToString());
                    record.Add("bank_branch", row["updated_at"].ToString());
                }
            }

            return record;
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            var record = new Dictionary<string, string>();

            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, Id},
            };

            string query = $"SELECT * FROM {tableName} WHERE id = @id";

            using (var reader = _dbGenericCommands.ExecuteReader(query, parameters))
            {
                if (reader.Rows.Count < 1)
                    return record;

                foreach (DataRow row in reader.Rows)
                {
                    record.Add("id", row["id"].ToString());
                    record.Add("banks_id", row["banks_id"].ToString());
                    record.Add("account_no", row["account_no"].ToString());
                    record.Add("created_at", row["created_at"].ToString());
                    record.Add("updated_at", row["updated_at"].ToString());
                }
            }

            return record;
        }

        public DataTable GetRecords()
        {
            string query = $"SELECT * FROM {tableName}";

            var dt = new DataTable();
            return _dbGenericCommands.Fill(query, dt);
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            var parameters = new object[][]
            {
                new object[]{"@searchText", DbType.String, $"%{searchText}%"},
            };

            string query = $"SELECT * FROM {tableName} WHERE account_no LIKE @searchText";

            var dt = new DataTable();
            return _dbGenericCommands.Fill(query, dt);
        }

        public DataTable GetViewRecords()
        {
            string query = $"SELECT * FROM {viewTableName}";

            var dataTable = new DataTable();
            return _dbGenericCommands.Fill(query, dataTable);
        }

        public DataTable GetViewRecordsBySearch(string searchKey)
        {
            var parameters = new object[][]
            {
                new object[]{"@searchText", DbType.String, $"%{searchKey}%"},
            };

            string query = $"SELECT * FROM {viewTableName} WHERE account_no LIKE @searchText OR bank_name LIKE @searchText";

            var dataTable = new DataTable();
            return _dbGenericCommands.FillBySearch(query, dataTable, parameters);
        }

        public bool IdExist(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(BankAccountsModel entity)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] {"@banks_id", DbType.String, entity.BankID},
                    new object[] {"@account_no", DbType.String, entity.AccountNumber},
                };

                string query = $"INSERT INTO {tableName} (banks_id, account_no) VALUES (@banks_id, @account_no)";
                return _dbGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Update(BankAccountsModel entity)
        {
            var parameters = new object[][] {
                new object[]{"@id", DbType.Int32, entity.ID},
                new object[]{"@banks_id", DbType.Int32, entity.BankID},
                new object[]{"@account_no", DbType.String, entity.AccountNumber},
            };

            string query = $"UPDATE {tableName} SET banks_id = @banks_id, account_no = @account_no WHERE id = @id";
            return _dbGenericCommands.ExecuteNonQuery(query, parameters);
        }

        public bool InsertWithBank(BankAccountsModel bankAccountsModel)
        {
            using (var scope = new TransactionScope())
            {
                string bankName = bankAccountsModel.banksModel.BankName;
                string bankBranch = bankAccountsModel.banksModel.BankBranch;
                bool bankExist = _banksRepository.BankExistByNameBranch(bankName, bankBranch);
                int bankId;
                if (!bankExist)
                {
                    _ = _banksRepository.Insert(bankAccountsModel.banksModel);
                    bankId = _banksRepository.GetLastInsertedId();
                }
                else
                    bankId = _banksRepository.GetIdByNameBranch(bankName, bankBranch);

                bankAccountsModel.BankID = bankId;
                _ = Insert(bankAccountsModel);

                scope.Complete();
                return true;
            }
        }

        public int GetLastInsertedId()
        {
            string query = $"SELECT MAX(id) FROM {tableName}";
            return Convert.ToInt32(_dbGenericCommands.ExecuteScalar(query));
        }

        public Dictionary<string, string> GetViewRecordById(int id)
        {
            var dict = new Dictionary<string, string>();

            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, id}
            };

            string query = $"SELECT account_no, banks_id, bank_code, bank_name, bank_branch FROM {viewTableName} WHERE id = @id";

            using (var reader = _dbGenericCommands.ExecuteReader(query, parameters))
            {
                if (reader.Rows.Count < 1)
                    return dict;

                foreach (DataRow row in reader.Rows)
                {
                    dict.Add("account_no", row["account_no"].ToString());
                    dict.Add("banks_id", row["banks_id"].ToString());
                    dict.Add("bank_code", row["bank_code"].ToString());
                    dict.Add("bank_name", row["bank_name"].ToString());
                    dict.Add("bank_branch", row["bank_branch"].ToString());
                }
                return dict;
            }
        }

        public DataTable GetBankAccountsByBankID(int bankID)
        {
            var parameters = new object[][]
            {
                new object[]{"@banks_id", DbType.String, bankID},
            };

            string query = $"SELECT * FROM {tableName} WHERE banks_id = @banks_id";

            var dataTable = new DataTable();
            return _dbGenericCommands.FillBySearch(query, dataTable, parameters);
        }
    }
}