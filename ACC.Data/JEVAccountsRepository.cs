using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;

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

        public bool DeleteByJevId(int jevId)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@id", DbType.Int32, jevId},
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

        public DataTable GetViewRecordsByJevId(int jevId)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@jev_id", DbType.Int32, jevId },
                };

                string query = $"SELECT " +
                    $"id, " +
                    $"fpp_id, " +
                    $"general_ledger_accounts_id, " +
                    $"subsidiary_ledger_accounts_id, " +
                    $"is_debit, " +
                    $"is_deposit, " +
                    $"fpp_name, " +
                    $"ledger_name, " +
                    $"account_code, " +
                    $"sub_name, " +
                    $"amount, " +
                    $"fpp_code " +
                    $"FROM {viewTableName} " +
                    $"WHERE jev_id = @jev_id";

                var dtGeneralLedgers = new DataTable();
                return _dbGenericCommands.FillBySearch(query, dtGeneralLedgers, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetViewRecordsByFundJournalDate(byte fundId, byte journalId, DateTime dateEntry)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@funds_id", DbType.Byte, fundId},
                    new object[] { "@journals_id", DbType.Byte, journalId},
                    new object[] { "@date_entry", DbType.Date, dateEntry }
                };

                string query = $"SELECT " +
                    $"jev_id, " +
                    $"date_entry, " +
                    $"jev_no, " +
                    $"full_jev_no, " +
                    $"explanation, " +
                    $"ledger_name, " +
                    $"account_code, " +
                    $"is_deposit, " +
                    $"is_debit, " +
                    $"amount " +
                    $"FROM {viewTableName} " +
                    $"WHERE " +
                    $"funds_id = @funds_id " +
                    $"AND journals_id = @journals_id " +
                    $"AND MONTH(date_entry) = MONTH(@date_entry) " +
                    $"AND YEAR(date_entry) = YEAR(@date_entry)";

                var dtGeneralLedgers = new DataTable();
                return _dbGenericCommands.FillBySearch(query, dtGeneralLedgers, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int CountByJevId(int jevId)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@jev_id", DbType.Int32, jevId},
                };

                string query = $"SELECT COUNT(*) FROM {tableName} WHERE jev_id = @jev_id";

                return int.Parse(_dbGenericCommands.ExecuteScalar(query, parameters));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetViewRecordsByFundAndGeneralLedger(byte fundId, ushort generalLedgerId, short year)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@funds_id", DbType.Byte, fundId},
                    new object[] { "@general_ledger_accounts_id", DbType.UInt16, generalLedgerId},
                    new object[] { "@year", DbType.Int16, year},
                };

                string query = $"SELECT " +
                    $"jev_id, date_entry, " +
                    $"MONTHNAME(date_entry) AS month_name, " +
                    $"jev_no, " +
                    $"full_jev_no, " +
                    $"journal_name, " +
                    $"explanation, " +
                    $"ledger_name, " +
                    $"account_code, " +
                    $"is_deposit, " +
                    $"is_debit, " +
                    $"SUM(amount) AS amount " +
                    $"FROM {viewTableName} " +
                    $"WHERE is_approved = 1 " +
                    $"AND funds_id = @funds_id " +
                    $"AND general_ledger_accounts_id = @general_ledger_accounts_id " +
                    $"AND YEAR(date_entry) = @year " +
                    $"GROUP BY " +
                    $"general_ledger_accounts_id, " +
                    $"journals_id, " +
                    $"MONTH(date_entry), " +
                    $"is_debit " +
                    $"ORDER BY " +
                    $"MONTH(date_entry), " +
                    $"journals_id";

                var dtGeneralLedgers = new DataTable();
                return _dbGenericCommands.FillBySearch(query, dtGeneralLedgers, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public decimal GetJEVSumByGeneralLedgerId(byte fundsId, ushort generalLedgerId, short year)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@funds_id", DbType.Byte, fundsId},
                    new object[] { "@general_ledger_accounts_id", DbType.UInt16, generalLedgerId},
                    new object[] { "@year", DbType.Int16, year},
                };

                string query = $"SELECT SUM(amount) FROM view_jev_accounts WHERE is_approved=1 AND funds_id = @funds_id AND general_ledger_accounts_id=@general_ledger_accounts_id AND YEAR(date_entry)=@year";

                string sumBalance = _dbGenericCommands.ExecuteScalar(query, parameters);
                if (!string.IsNullOrWhiteSpace(sumBalance))
                    return Convert.ToDecimal(sumBalance);

                return 0;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
