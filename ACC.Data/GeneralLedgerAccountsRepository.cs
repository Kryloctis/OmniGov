using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace ACC.Data
{
    public class GeneralLedgerAccountsRepository : IGeneralLedgerAccountsRepository
    {
        private readonly IDbGenericCommands _dbGenericCommands;
        private readonly string tableName = "general_ledger_accounts";
        private readonly string tableName2 = "account_group";
        private readonly string tableName3 = "major_account_group";
        private readonly string tableName4 = "sub_major_account_group";
        private readonly string viewTableName = "view_general_ledger_accounts";

        public GeneralLedgerAccountsRepository(IDbGenericCommands dbGenericCommands)
        {
            _dbGenericCommands = dbGenericCommands;
        }

        public Dictionary<string, string> GetViewRecordByID(ushort generalLedgerId)
        {
            var record = new Dictionary<string, string>();

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

            return record;
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            var record = new Dictionary<string, string>();

            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@general_ledger_accounts_id", DbType.UInt16, Id},
                };

                string query = $"SELECT sub_major_account_group_id, ledger_code, ledger_name, is_contra_account, created_at, updated_at FROM {tableName} WHERE id = @general_ledger_accounts_id";
                //, account_code
                using (var reader = _dbGenericCommands.ExecuteReader(query, parameters))
                {
                    if (reader.Rows.Count < 1)
                        return record;

                    record.Add("sub_major_account_group_id", reader.Rows[0]["sub_major_account_group_id"].ToString());
                    // record.Add("account_code", reader.Rows[0]["account_code"].ToString());
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
            string query = $"SELECT account_group_id, account_group_code, account_group_name, major_account_group_id, maj_acc_group_code, maj_acc_group_name, sub_maj_acc_group_code, sub_maj_acc_group_name, sub_major_account_group_id, general_ledger_accounts_id, account_code, ledger_code, ledger_name, is_contra_account, created_at, updated_at FROM {viewTableName}";

            var dtJournals = new DataTable();
            return _dbGenericCommands.Fill(query, dtJournals);
        }

        public DataTable GetViewRecordsBySearch(string searchText)
        {
            var parameters = new object[][]
            {
                new object[] { "@searchText", DbType.String, $"%{searchText}%" },
            };

            string query = $"SELECT general_ledger_accounts_id, account_code, ledger_name, sub_maj_acc_group_name, created_at, updated_at FROM {viewTableName} WHERE account_code LIKE @searchText OR REPLACE(account_code, '-', '') LIKE @searchText OR ledger_name LIKE @searchText";

            var dtGeneralLedgers = new DataTable();
            return _dbGenericCommands.FillBySearch(query, dtGeneralLedgers, parameters);
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

        public DataTable GetRecordsBySearch()
        {
            try
            {
                string query = $"SELECT {tableName}.id,CONCAT({tableName2}.account_group_code,'-',{tableName3}.maj_acc_group_code,'-',{tableName4}.sub_maj_acc_group_code,'-',{tableName}.ledger_code) AS account_code,{tableName}.ledger_name FROM {tableName} LEFT JOIN {tableName4} ON {tableName}.sub_major_account_group_id={tableName4}.id LEFT JOIN {tableName3} ON {tableName4}.major_account_group_id={tableName3}.id LEFT JOIN {tableName2} ON ({tableName3}.account_group_id={tableName2}.id AND {tableName2}.id='4') WHERE CONCAT({tableName2}.account_group_code,'-',{tableName3}.maj_acc_group_code,'-',{tableName4}.sub_maj_acc_group_code,'-',{tableName}.ledger_code) IS NOT NULL";
                var dtGeneralLedgers = new DataTable();
                return _dbGenericCommands.FillBySearch(query, dtGeneralLedgers);

            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetRecordsBySearch(string srchtxt)
        {
            try
            {
                string query = $"SELECT {tableName}.id,CONCAT({tableName2}.account_group_code,'-',{tableName3}.maj_acc_group_code,'-',{tableName4}.sub_maj_acc_group_code,'-',{tableName}.ledger_code) AS account_code,{tableName}.ledger_name FROM {tableName} LEFT JOIN {tableName4} ON {tableName}.sub_major_account_group_id={tableName4}.id LEFT JOIN {tableName3} ON {tableName4}.major_account_group_id={tableName3}.id LEFT JOIN {tableName2} ON ({tableName3}.account_group_id={tableName2}.id AND {tableName2}.id='4') WHERE CONCAT({tableName2}.account_group_code,'-',{tableName3}.maj_acc_group_code,'-',{tableName4}.sub_maj_acc_group_code,'-',{tableName}.ledger_code) IS NOT NULL AND (CONCAT({tableName2}.account_group_code,'-',{tableName3}.maj_acc_group_code,'-',{tableName4}.sub_maj_acc_group_code,'-',{tableName}.ledger_code) LIKE '%{srchtxt}%' OR ledger_name LIKE '%{srchtxt}%')";
                var dtGeneralLedgers = new DataTable();
                return _dbGenericCommands.FillBySearch(query, dtGeneralLedgers);

            }
            catch (Exception)
            {
                throw;
            }
        }


        public DataTable GetViewRecordsByMajorAccGroupName(string majAccGroupName)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@maj_acc_group_name", DbType.String, majAccGroupName},
                };


                string query = $"SELECT " +
                    $"general_ledger_accounts_id, " +
                    $"account_group_id, " +
                    $"account_group_code, " +
                    $"account_group_name, " +
                    $"major_account_group_id, " +
                    $"maj_acc_group_code, " +
                    $"maj_acc_group_name, " +
                    $"sub_maj_acc_group_code, " +
                    $"sub_maj_acc_group_name, " +
                    $"sub_major_account_group_id, " +
                    $"general_ledger_accounts_id, " +
                    $"account_code, " +
                    $"ledger_code, " +
                    $"ledger_name, " +
                    $"is_contra_account, " +
                    $"created_at, " +
                    $"updated_at " +
                    $"FROM {viewTableName} " +
                    $"WHERE " +
                    $"maj_acc_group_name = @maj_acc_group_name";

                var dataTable = new DataTable();
                return _dbGenericCommands.FillBySearch(query, dataTable, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetViewRecordsByMajorAccGroupNameSearch(string majAccGroupName, string searchText)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@maj_acc_group_name", DbType.String, majAccGroupName},
                    new object[] { "@searchText", DbType.String, $"%{searchText}%" }
                };


                string query = $"SELECT " +
                    $"general_ledger_accounts_id, " +
                    $"account_group_id, " +
                    $"account_group_code, " +
                    $"account_group_name, " +
                    $"major_account_group_id, " +
                    $"maj_acc_group_code, " +
                    $"maj_acc_group_name, " +
                    $"sub_maj_acc_group_code, " +
                    $"sub_maj_acc_group_name, " +
                    $"sub_major_account_group_id, " +
                    $"general_ledger_accounts_id, " +
                    $"account_code, " +
                    $"ledger_code, " +
                    $"ledger_name, " +
                    $"is_contra_account, " +
                    $"created_at, " +
                    $"updated_at " +
                    $"FROM {viewTableName} " +
                    $"WHERE " +
                    $"maj_acc_group_name = @maj_acc_group_name " +
                    $"AND (account_code LIKE @searchText OR REPLACE(account_code, '-', '') LIKE @searchText " +
                    $"OR ledger_name LIKE @searchText)";

                var dataTable = new DataTable();
                return _dbGenericCommands.FillBySearch(query, dataTable, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetViewRecordsByAccountGroupName(string accountGroupName)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@account_group_name", DbType.String, accountGroupName},
                };

                string query = $"SELECT " +
                    $"general_ledger_accounts_id, " +
                    $"account_group_id, " +
                    $"account_group_code, " +
                    $"account_group_name, " +
                    $"major_account_group_id, " +
                    $"maj_acc_group_code, " +
                    $"maj_acc_group_name, " +
                    $"sub_maj_acc_group_code, " +
                    $"sub_maj_acc_group_name, " +
                    $"sub_major_account_group_id, " +
                    $"general_ledger_accounts_id, " +
                    $"account_code, " +
                    $"ledger_code, " +
                    $"ledger_name, " +
                    $"is_contra_account, " +
                    $"created_at, " +
                    $"updated_at " +
                    $"FROM {viewTableName} " +
                    $"WHERE " +
                    $"account_group_name = @account_group_name ";

                var dataTable = new DataTable();
                return _dbGenericCommands.FillBySearch(query, dataTable, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetViewRecordsByAccountGroupNameSearch(string accountGroupName, string searchText)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@account_group_name", DbType.String, accountGroupName},
                    new object[] { "@searchText", DbType.String, $"%{searchText}%" }
                };

                string query = $"SELECT " +
                    $"general_ledger_accounts_id, " +
                    $"account_group_id, " +
                    $"account_group_code, " +
                    $"account_group_name, " +
                    $"major_account_group_id, " +
                    $"maj_acc_group_code, " +
                    $"maj_acc_group_name, " +
                    $"sub_maj_acc_group_code, " +
                    $"sub_maj_acc_group_name, " +
                    $"sub_major_account_group_id, " +
                    $"general_ledger_accounts_id, " +
                    $"account_code, " +
                    $"ledger_code, " +
                    $"ledger_name, " +
                    $"is_contra_account, " +
                    $"created_at, " +
                    $"updated_at " +
                    $"FROM {viewTableName} " +
                    $"WHERE " +
                    $"account_group_name = @account_group_name " +
                    $"AND (account_code LIKE @searchText OR REPLACE(account_code, '-', '') LIKE @searchText " +
                    $"OR ledger_name LIKE @searchText)";


                var dataTable = new DataTable();
                return _dbGenericCommands.FillBySearch(query, dataTable, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }


        //CHART OF ACCOUNTS
        public DataTable GetViewRecordsBy_AccountGroupId(int accountGroupId)
        {
            var parameters = new object[][]
            {
                new object[] { "@account_group_id", DbType.Int32, accountGroupId}
            };

            string query = $"SELECT general_ledger_accounts_id, account_code, ledger_name, created_at, updated_at FROM {viewTableName} WHERE account_group_id = @account_group_id";

            var dtJournals = new DataTable();
            return _dbGenericCommands.FillBySearch(query, dtJournals, parameters);
        }

        public DataTable GetViewRecordsBy_AccountGroupId_Search(int accountGroupId, string searchText)
        {
            var parameters = new object[][]
            {
                new object[] { "@account_group_id", DbType.Int32, accountGroupId},
                new object[] { "@searchText", DbType.String, $"%{searchText}%" }
            };

            string query = $"SELECT general_ledger_accounts_id, account_code, ledger_name, created_at, updated_at FROM {viewTableName} WHERE account_group_id = @account_group_id AND (account_code LIKE @searchText OR REPLACE(account_code, '-', '') LIKE @searchText OR ledger_name LIKE @searchText)";

            var dtGeneralLedgers = new DataTable();
            return _dbGenericCommands.FillBySearch(query, dtGeneralLedgers, parameters);
        }

        public DataTable GetViewRecordsBy_AccountGroupId_Search_Limited(int accountGroupId, string searchText, int limit)
        {
            var parameters = new object[][]
            {
                new object[] { "@account_group_id", DbType.Int32, accountGroupId},
                new object[] { "@searchText", DbType.String, $"%{searchText}%" },
                new object[] { "@limit", DbType.Int32, limit}
            };

            string query = $"SELECT general_ledger_accounts_id, account_code, ledger_name, created_at, updated_at FROM {viewTableName} WHERE account_group_id = @account_group_id AND (account_code LIKE @searchText OR REPLACE(account_code, '-', '') LIKE @searchText OR ledger_name LIKE @searchText) LIMIT @limit";

            var dtGeneralLedgers = new DataTable();
            return _dbGenericCommands.FillBySearch(query, dtGeneralLedgers, parameters);
        }

        public DataTable GetGeneralLedgerAccountsIncomeRecords(string searchText)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@searchText", DbType.String, $"%{searchText}%"}
                };

                string query = $"SELECT * FROM {viewTableName} WHERE account_group_code LIKE @searchText OR ledger_name LIKE @searchText AND account_group_code=4";

                var dtJournals = new DataTable();
                return _dbGenericCommands.FillBySearch(query, dtJournals, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetGeneralLedgerAccountsIncomeRecords()
        {
            try
            {
                string query = $"SELECT * FROM {viewTableName} WHERE account_group_code=4";

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
