using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using ACC.Domain.Interfaces;
using ACC.Domain.Models;

namespace ACC.Data
{
    public class GeneralLedgerAccountsRepository : IGeneralLedgerAccountsRepository
    {
        private readonly IDbGenericCommands _dbGenericCommands;
        private readonly string tableName = "general_ledger_accounts";
        private readonly string viewTableName = "view_general_ledger_accounts";

        public GeneralLedgerAccountsRepository(IDbGenericCommands dbGenericCommands)
        {
            _dbGenericCommands = dbGenericCommands;
        }        

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            var record = new Dictionary<string, string>();

            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@id", DbType.Int32, Id},
                };

                string query = $"SELECT sub_major_account_group_id, account_code, ledger_code, ledger_name, is_contra_account, created_at, updated_at FROM {viewTableName} WHERE general_ledger_accounts_id = @id";

                using (var reader = _dbGenericCommands.ExecuteReader(query, parameters))
                {
                    if (reader.Rows.Count < 1)
                        return record;

                    record.Add("sub_major_account_group_id", reader.Rows[0][0].ToString());
                    record.Add("ledger_code", reader.Rows[0][1].ToString());
                    record.Add("account_code", reader.Rows[0][2].ToString());
                    record.Add("ledger_name", reader.Rows[0][3].ToString());
                    record.Add("is_contra_account", reader.Rows[0][4].ToString());
                    record.Add("created_at", reader.Rows[0][5].ToString());
                    record.Add("updated_at", reader.Rows[0][6].ToString());
                }
            }
            catch (Exception)
            {
                throw;
            }

            return record;
        }

        public DataTable GetRecords()
        {
            try
            {
                string query = $"SELECT * FROM {tableName} LIMIT 5";

                var dtJournals = new DataTable();
                return _dbGenericCommands.Fill(query, dtJournals);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetViewRecords()
        {
            try
            {
                string query = $"SELECT general_ledger_accounts_id, account_code, ledger_name, sub_maj_acc_group_name, created_at, updated_at FROM {viewTableName}";

                var dtJournals = new DataTable();
                return _dbGenericCommands.Fill(query, dtJournals);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetViewRecordsBySearch(string searchText)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@searchText", DbType.String, $"%{searchText}%" },
                };

                string query = $"SELECT general_ledger_accounts_id, account_code, ledger_name, sub_maj_acc_group_name, created_at, updated_at FROM {viewTableName} WHERE account_code LIKE @searchText OR REPLACE(account_code, '-', '') LIKE @searchText OR ledger_name LIKE @searchText";

                var dtGeneralLedgers = new DataTable();
                return _dbGenericCommands.FillBySearch(query, dtGeneralLedgers, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Insert(GeneralLedgerAccountsModal entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(GeneralLedgerAccountsModal entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(List<GeneralLedgerAccountsModal> entityList)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            throw new NotImplementedException();
        }
    }
}
