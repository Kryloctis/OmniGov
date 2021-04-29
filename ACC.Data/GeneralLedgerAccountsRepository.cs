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
            throw new NotImplementedException();
        }

        public Dictionary<string, string> GetViewRecordByID(ushort generalLedgerId)
        {
            var record = new Dictionary<string, string>();

            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@general_ledger_accounts_id", DbType.UInt16, generalLedgerId},
                };

                string query = $"SELECT sub_major_account_group_id, account_code, ledger_code, ledger_name, is_contra_account, created_at, updated_at FROM {viewTableName} WHERE general_ledger_accounts_id = @general_ledger_accounts_id";

                using (var reader = _dbGenericCommands.ExecuteReader(query, parameters))
                {
                    if (reader.Rows.Count < 1)
                        return record;

                    record.Add("sub_major_account_group_id", reader.Rows[0]["sub_major_account_group_id"].ToString());
                    record.Add("account_code", reader.Rows[0]["account_code"].ToString());
                    record.Add("ledger_code", reader.Rows[0]["ledger_code"].ToString());
                    record.Add("ledger_name", reader.Rows[0]["ledger_name"].ToString());
                    record.Add("is_contra_account", reader.Rows[0]["is_contra_account"].ToString());
                    record.Add("created_at", reader.Rows[0]["created_at"].ToString());
                    record.Add("updated_at", reader.Rows[0]["updated_at"].ToString());
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
                string query = $"SELECT * FROM {tableName}";

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
                string query = $"SELECT general_ledger_accounts_id, account_code, ledger_name, created_at, updated_at FROM {viewTableName}";

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

        #region Validations

        public bool NameExist(string txtName)
        {
            try
            {
                var parameters = new object[][]
               {
                    new object[] { "@ledger_name", DbType.String, txtName},
               };

                string query = $"SELECT id FROM {tableName} WHERE ledger_name = @ledger_name";
                string queryResult = _dbGenericCommands.ExecuteScalar(query, parameters);

                // if query is not null, means found some record, so true
                if (!string.IsNullOrEmpty(queryResult)) return true;

            }
            catch (Exception)
            {
                throw;
            }
            return false;
        }

        public bool NameExist(int id, string txtName)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@ledger_name", DbType.String, txtName},
                    new object[] { "@id", DbType.Int32, id }
                };

                string query = $"SELECT id FROM {tableName} WHERE id = @id AND ledger_name = @ledger_name";
                string queryResult = _dbGenericCommands.ExecuteScalar(query, parameters);

                // if query is not null, means found some record, so true
                if (!string.IsNullOrEmpty(queryResult)) return true;

            }
            catch (Exception)
            {
                throw;
            }
            return false;
        }

        #endregion Validations


        //Budget System
        public DataTable GetViewRecordsByMajAccGroupName(string majAccGroupName)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@maj_acc_group_name", DbType.String, majAccGroupName},

                };


                string query = $"SELECT account_group_id, account_group_code, account_group_name, major_account_group_id, maj_acc_group_code, maj_acc_group_name, sub_maj_acc_group_code, sub_maj_acc_group_name, sub_major_account_group_id, general_ledger_accounts_id, account_code, ledger_code, ledger_name, is_contra_account, created_at, updated_at FROM {viewTableName} WHERE maj_acc_group_name = @maj_acc_group_name";

                var dtJournals = new DataTable();
                return _dbGenericCommands.FillBySearch(query, dtJournals,parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetAllViewRecords()
        {
            try
            {
                string query = $"SELECT account_group_id, account_group_code, account_group_name, major_account_group_id, maj_acc_group_code, maj_acc_group_name, sub_maj_acc_group_code, sub_maj_acc_group_name, sub_major_account_group_id, general_ledger_accounts_id, account_code, ledger_code, ledger_name, is_contra_account, created_at, updated_at FROM {viewTableName}";

                var dtJournals = new DataTable();
                return _dbGenericCommands.Fill(query, dtJournals);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
