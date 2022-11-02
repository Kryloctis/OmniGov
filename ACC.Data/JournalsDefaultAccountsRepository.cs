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
        private AccGenericCommands mySqlGenericCommands;

        public JournalsDefaultAccountsRepository(AccGenericCommands mySqlGenericCommands)
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

        public bool DeleteByJournalIdAndFundAndIsDebit(int journalId, int fundId, bool isDebit)
        {
            var parameters = new dynamic[][]
            {
                new dynamic[] { "@journals_id", DbType.Int32, journalId},
                new dynamic[] { "@funds_id", DbType.Int32, fundId},
                new dynamic[] { "@is_debit", DbType.Boolean, isDebit}
            };


            string query = $"DELETE FROM {tableName} WHERE journals_id = @journals_id AND funds_id = @funds_id AND is_debit = @is_debit";
            return mySqlGenericCommands.ExecuteNonQuery(query, parameters);
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            throw new NotImplementedException();
        }

        public DataTable GetRecords()
        {
            throw new NotImplementedException();
        }

        public DataTable GetViewRecordsByJournalId(int journalId, int fundId, bool isDebit)
        {
            var parameters = new object[][]
            {
                new object[] { "@journals_id", DbType.Int32, journalId},
                new object[] { "@funds_id", DbType.Int32, fundId},
                new object[] { "@is_debit", DbType.Boolean, isDebit}
            };
            string query = $"SELECT * FROM  {viewTableName} WHERE journals_id = @journals_id AND funds_id = @funds_id AND is_debit = @is_debit";
            var dataTable = new DataTable();
            return mySqlGenericCommands.FillBySearch(query, dataTable, parameters);
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

        public bool Insert(int journalId, int fundId, bool isDebit, List<JournalsDefaultAccountsModel> entityList)
        {
            using (var scope = new TransactionScope())
            {

                DeleteByJournalIdAndFundAndIsDebit(journalId, fundId, isDebit);

                foreach (var item in entityList)
                {
                    var parameters = new object[][]
                    {
                        new object[] { "@journals_id",DbType.Int32, item.JournalId},
                        new object[] { "@funds_id", DbType.Int32, item.fundId},
                        new object[] { "@general_ledger_accounts_id",DbType.Int32, item.AccountId },
                        new object[] { "@is_debit", DbType.Boolean, item.IsDebit}
                    };

                    string query = $"INSERT INTO {tableName} (journals_id, funds_id, general_ledger_accounts_id, is_debit) VALUES (@journals_id, @funds_id, @general_ledger_accounts_id, @is_debit)";

                    _ = mySqlGenericCommands.ExecuteNonQuery(query, parameters);
                }
                scope.Complete();
                return true;
            };
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

        public bool GeneralLedgerAccountExist(int journalId, int generalLedgerAccountId, int fundId, bool isDebit)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@journals_id",DbType.Int32, journalId},
                    new object[] { "@general_ledger_accounts_id", DbType.Int32, generalLedgerAccountId},
                    new object[] { "@funds_id", DbType.Int32, fundId},
                    new object[] { "@is_debit", DbType.Boolean, isDebit}
                };

                string query = $"SELECT id FROM {tableName} WHERE journals_id = @journals_id AND general_ledger_accounts_id = @general_ledger_accounts_id AND funds_id = @funds_id AND is_debit = @is_debit";
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
