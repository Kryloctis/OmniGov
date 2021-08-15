using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Transactions;

namespace ACC.Data
{
    public class JournalsDefaultAccountsRepository : IJournalsDefaultAccountsRepository
    {

        private readonly string tableName = "journals_default_accounts";
        private readonly string viewTableName = "view_journals_default_accounts";
        private MySqlGenericCommands mySqlGenericCommands;

        public JournalsDefaultAccountsRepository(MySqlGenericCommands mySqlGenericCommands)
        {
            this.mySqlGenericCommands = mySqlGenericCommands;
        }

        public int CountRecords()
        {
            throw new NotImplementedException();
        }

        public bool Delete(List<JournalsDefaultAccountsModel> entityList)
        {
            try
            {
                using (var scope = new TransactionScope())
                {
                    foreach (var item in entityList)
                    {
                        var parameters = new object[][]
                        {
                            new object[] { "@journals_id", DbType.Int32, item.JournalId}
                        };

                        string query = $"DELETE FROM {tableName} WHERE journals_id = @journals_id";

                        _ = mySqlGenericCommands.ExecuteNonQuery(query, parameters);
                    }

                    scope.Complete();
                    return true;
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Delete(JournalsDefaultAccountsModel entity)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            throw new NotImplementedException();
        }

        public DataTable GetRecords()
        {
            throw new NotImplementedException();
        }

        public DataTable GetViewRecordsByJournalId(int journalId)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@journals_id", DbType.Int32, journalId}
                };
                string query = $"SELECT id, journals_id, general_ledger_accounts_id, account_code, general_ledger_accounts_code, general_ledger_accounts_name FROM  {viewTableName} WHERE journals_id = @journals_id";
                var dataTable = new DataTable();
                return mySqlGenericCommands.FillBySearch(query, dataTable, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            throw new NotImplementedException();
        }

        public bool IdExist(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(JournalsDefaultAccountsModel entity)
        {
            throw new NotImplementedException();
        }

        public bool Insert(List<JournalsDefaultAccountsModel> entityList)
        {
            try
            {
                using (var scope = new TransactionScope())
                {

                    Delete(entityList);
                    foreach (var item in entityList)
                    {
                        var parameters = new object[][]
                        {
                            new object[] { "@journals_id",DbType.Int32, item.JournalId},
                            new object[] { "@general_ledger_accounts_id",DbType.Int32, item.AccountId }
                        };

                        string query = $"INSERT INTO {tableName} (journals_id, general_ledger_accounts_id) VALUES (@journals_id, @general_ledger_accounts_id)";

                        _ = mySqlGenericCommands.ExecuteNonQuery(query, parameters);
                    }
                    scope.Complete();
                    return true;
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Update(JournalsDefaultAccountsModel entity)
        {
            throw new NotImplementedException();
        }

        public bool GeneralLedgerAccountExist(int journalId, int generalLedgerAccountId)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@journals_id",DbType.Int32, journalId},
                    new object[] { "@general_ledger_accounts_id", DbType.Int32, generalLedgerAccountId}
                };

                string query = $"SELECT id FROM {tableName} WHERE journals_id = @journals_id AND general_ledger_accounts_id = @general_ledger_accounts_id";
                string queryResult = mySqlGenericCommands.ExecuteScalar(query, parameters);

                // if query is not null, means found some record, so true
                if (!string.IsNullOrEmpty(queryResult)) return true;
            }
            catch (Exception)
            {
                throw;
            }
            return false;
        }
    }
}
