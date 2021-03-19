using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Transactions;
using ACC.Domain.Interfaces;
using ACC.Domain.Models;

namespace ACC.Data
{
    public class JEVAccountsRepository : IJEVAccountsRepository
    {
        private readonly IDbGenericCommands _dbGenericCommands;
        private const string tableName = "jev_accounts";
        private const string viewTableName = "view_jev_accounts";

        public JEVAccountsRepository(IDbGenericCommands dbGenericCommands)
        {
            _dbGenericCommands = dbGenericCommands;
        }

        public int CountRecords()
        {
            throw new NotImplementedException();
        }

        public bool DeleteByJevId(uint jevId)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@id", DbType.UInt32, jevId},
                };

                string query = $"DELETE FROM {tableName} WHERE jev_id = @id";
                return _dbGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Delete(List<JEVAccountsModel> entityList)
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

        public DataTable GetRecordsBySearch(string searchText)
        {
            throw new NotImplementedException();
        }

        public bool IdExist(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(JEVAccountsModel entity)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@jev_id", DbType.Int32, entity.JEVId},
                    new object[] { "@fpp_id", DbType.Int32, entity.FPPId},
                    new object[] { "@general_ledger_accounts_id", DbType.UInt16, entity.GeneralLedgerId},
                    new object[] { "@subsidiary_ledger_accounts_id", DbType.UInt16, entity.SubsidiaryLedgerId},
                    new object[] { "@is_deposit", DbType.Boolean, entity.IsDeposit},
                    new object[] { "@is_debit", DbType.Boolean, entity.IsDebit},
                    new object[] { "@amount", DbType.Decimal, entity.Amount},
                };

                string query = $"INSERT INTO {tableName} (jev_id, function_program_project_id, general_ledger_accounts_id, subsidiary_ledger_accounts_id, is_deposit, is_debit, amount) VALUES (@jev_id, @fpp_id, @general_ledger_accounts_id, @subsidiary_ledger_accounts_id, @is_deposit, @is_debit, @amount);";

                return _dbGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Update(JEVAccountsModel entity)
        {
            throw new NotImplementedException();
        }

        public DataTable GetRecordsByJevId(uint jevId)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@jev_id", DbType.Int32, jevId },
                };

                string query = $"SELECT id, fpp_id, general_ledger_accounts_id, subsidiary_ledger_accounts_id, is_debit, is_deposit, fpp_name, ledger_name, account_code, sub_name, amount FROM {viewTableName} WHERE jev_id = @jev_id";

                var dtGeneralLedgers = new DataTable();
                return _dbGenericCommands.FillBySearch(query, dtGeneralLedgers, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
