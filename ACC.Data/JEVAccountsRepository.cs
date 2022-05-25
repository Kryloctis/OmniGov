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
                    new object[] { "@fpp_id", DbType.String, entity.FPPId},
                    new object[] { "@general_ledger_accounts_id", DbType.UInt16, entity.GeneralLedgerId},
                    new object[] { "@subsidiary_ledger_accounts_id", DbType.UInt16, entity.SubsidiaryLedgerId},
                    new object[] { "@obligation_no", DbType.String, entity.ObligationNo},
                    new object[] { "@is_deposit", DbType.Boolean, entity.IsDeposit},
                    new object[] { "@is_debit", DbType.Boolean, entity.IsDebit},
                    new object[] { "@amount", DbType.Decimal, entity.Amount},
                };

                string query = $"INSERT INTO {tableName} (jev_id, function_program_project_id, general_ledger_accounts_id, subsidiary_ledger_accounts_id, obligation_no, is_deposit, is_debit, amount) VALUES (@jev_id, @fpp_id, @general_ledger_accounts_id, @subsidiary_ledger_accounts_id,  @obligation_no, @is_deposit, @is_debit, @amount);";

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

        public DataTable GetViewRecords()
        {
            try
            {
                string query = $"SELECT " +
                    $"id, " +
                    $"jev_id, " +
                    $"funds_id, " +
                    $"fund_code, " +
                    $"fund_name, " +
                    $"journals_id, " +
                    $"journal_name, " +
                    $"is_special, " +
                    $"jev_no, " +
                    $"full_jev_no, " +
                    $"date_entry, " +
                    $"explanation, " +
                    $"is_approved, " +
                    $"is_disapproved, " +
                    $"is_cancelled, " +
                    $"fpp_id, " +
                    $"fpp_code, " +
                    $"fpp_name, " +
                    $"general_ledger_accounts_id, " +
                    $"account_code, " +
                    $"general_ledger_accounts_code, " +
                    $"general_ledger_accounts_name, " +
                    $"general_ledger_accounts_is_contra_account, " +
                    $"sub_maj_acc_group_id, " +
                    $"sub_maj_acc_group_code, " +
                    $"sub_maj_acc_group_name, " +
                    $"maj_acc_group_id, " +
                    $"maj_acc_group_code, " +
                    $"maj_acc_group_name, " +
                    $"account_group_id, " +
                    $"account_group_code, " +
                    $"account_group_name, " +
                    $"subsidiary_ledger_accounts_id, " +
                    $"subsidiary_ledger_accounts_code, " +
                    $"subsidiary_ledger_accounts_name, " +
                    $"obligation_no, " +
                    $"is_deposit, " +
                    $"is_debit, " +
                    $"amount " +
                    $"FROM {viewTableName}";

                var datatable = new DataTable();
                return _dbGenericCommands.Fill(query, datatable);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable GetViewRecordsByLedgerAccounts()
        {
            string query = $"SELECT id, jev_id, funds_id, fund_code, fund_name, journals_id, journal_name, is_special, jev_no, full_jev_no, date_entry, explanation, is_approved, is_disapproved, is_cancelled, fpp_id, fpp_code, fpp_name, general_ledger_accounts_id, account_code, general_ledger_accounts_code, general_ledger_accounts_name, general_ledger_accounts_is_contra_account, sub_maj_acc_group_id, sub_maj_acc_group_code, sub_maj_acc_group_name, maj_acc_group_id, maj_acc_group_code, maj_acc_group_name, account_group_id, account_group_code, account_group_name, subsidiary_ledger_accounts_id, subsidiary_ledger_accounts_code, subsidiary_ledger_accounts_name, obligation_no, is_deposit, is_debit, amount FROM {viewTableName} GROUP BY general_ledger_accounts_id";

            var datatable = new DataTable();
            return _dbGenericCommands.Fill(query, datatable);
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
                    $"account_code, " +
                    $"obligation_no, " +
                    $"is_debit, " +
                    $"is_deposit, " +
                    $"fpp_name, " +
                    $"general_ledger_accounts_name, " +
                    $"subsidiary_ledger_accounts_code, " +
                    $"subsidiary_ledger_accounts_name, " +
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

        public DataTable GetViewRecordsByFundJournalDate(string fundName, string journalName, DateTime dateEntry)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@fund_name", DbType.String, fundName},
                    new object[] { "@journal_name", DbType.String, journalName},
                    new object[] { "@date_entry", DbType.Date, dateEntry }
                };

                string query = $"SELECT " +
                    $"jev_id, " +
                    $"date_entry, " +
                    $"jev_no, " +
                    $"full_jev_no, " +
                    $"explanation, " +
                    $"general_ledger_accounts_id," +
                    $"general_ledger_accounts_name, " +
                    $"account_code, " +
                    $"is_deposit, " +
                    $"is_debit, " +
                    $"amount " +
                    $"FROM {viewTableName} " +
                    $"WHERE is_approved = 1 " +
                    $"AND is_cancelled = 0 " +
                    $"AND is_disapproved = 0 " +
                    $"AND fund_name = @fund_name " +
                    $"AND journal_name = @journal_name " +
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


        //Where general ledger report gets data for display
        public DataTable GetViewRecords(int fundId, int generalLedgerId, short year)
        {
            var parameters = new object[][]
            {
                new object[] { "@funds_id", DbType.Int32, fundId},
                new object[] { "@general_ledger_accounts_id", DbType.Int32, generalLedgerId},
                new object[] { "@year", DbType.Int16, year},
            };

            string query = $"SELECT jev_id, date_entry, MONTHNAME(MAX(date_entry)) AS month_name, jev_no, full_jev_no, journal_name, explanation, general_ledger_accounts_name, account_code, is_deposit, is_debit, SUM(amount) AS amount FROM {viewTableName} WHERE is_approved = 1 AND is_cancelled = 0 AND is_disapproved = 0 AND funds_id = @funds_id AND general_ledger_accounts_id = @general_ledger_accounts_id AND YEAR(date_entry) = @year GROUP BY general_ledger_accounts_id, journals_id, MONTH(date_entry), is_debit ORDER BY MONTH(date_entry), journals_id";

            var dtGeneralLedgers = new DataTable();
            return _dbGenericCommands.FillBySearch(query, dtGeneralLedgers, parameters);
        }

        //Where subsidiary ledger report gets data for display
        public DataTable GetViewRecords(int fundId, int generalLedgerId, int subsidiaryLedgerId, short year)
        {
            var parameters = new object[][]
            {
                new object[] { "@funds_id", DbType.Int32, fundId},
                new object[] { "@general_ledger_accounts_id", DbType.Int32, generalLedgerId},
                new object[] { "@subsidiary_ledger_accounts_id",DbType.Int32, subsidiaryLedgerId},
                new object[] { "@year", DbType.Int16, year},
            };

            string query = $"SELECT jev_id, date_entry, jev_no, full_jev_no, journal_name, explanation, general_ledger_accounts_name, account_code, is_deposit, is_debit, SUM(amount) AS amount FROM {viewTableName} WHERE is_approved = 1 AND is_cancelled = 0 AND is_disapproved = 0 AND funds_id = @funds_id AND general_ledger_accounts_id = @general_ledger_accounts_id AND subsidiary_ledger_accounts_id = @subsidiary_ledger_accounts_id AND YEAR(date_entry) = @year GROUP BY general_ledger_accounts_id, journals_id, MONTH(date_entry), is_debit ORDER BY MONTH(date_entry), journals_id";

            var dtGeneralLedgers = new DataTable();
            return _dbGenericCommands.FillBySearch(query, dtGeneralLedgers, parameters);
        }


        //Where trial balances and financial statements report gets data for display
        public Dictionary<string, decimal> GetSumTransactionsByAccGrpId(int fundsId, int accountGroupId, DateTime date)
        {
            var record = new Dictionary<string, decimal>();

            var parameters = new object[][]
            {
                    new object[] { "@funds_id", DbType.Int32, fundsId},
                    new object[] { "@account_group_id", DbType.Int32, accountGroupId},
                    new object[] { "@date_entry", DbType.Date, date.Date},
                    new object[] { "@year", DbType.Int16, date.Date.Year},
            };

            string query = $"SELECT COALESCE(SUM(IF(is_debit = 1, amount, 0)),0) AS debit, COALESCE(SUM(IF(is_debit = 0, amount, 0)),0) AS credit FROM {viewTableName} WHERE funds_id = @funds_id AND is_approved = 1 AND is_cancelled = 0 AND is_disapproved = 0 AND account_group_id = @account_group_id AND date_entry <= @date_entry AND YEAR(date_entry) = @year ";

            using (var reader = _dbGenericCommands.ExecuteReader(query, parameters))
            {
                foreach (DataRow item in reader.Rows)
                {
                    record.Add("debit", Convert.ToDecimal(item[0]));
                    record.Add("credit", Convert.ToDecimal(item[1]));
                }
            }
            return record;
        }

        public Dictionary<string, decimal> GetSumTransactionsByMajAccGrpId(int fundId, int majAccGrpId, DateTime date)
        {
            var record = new Dictionary<string, decimal>();

            var parameters = new object[][]
            {
                new object[] { "@funds_id", DbType.Int32, fundId},
                new object[] { "@maj_acc_group_id", DbType.Int32, majAccGrpId},
                new object[] { "@date_entry", DbType.Date, date.Date},
                new object[] { "@year", DbType.Int16, date.Date.Year},
            };

            string query = $"SELECT COALESCE(SUM(IF(is_debit = 1, amount, 0)),0) AS debit, COALESCE(SUM(IF(is_debit = 0, amount, 0)),0) AS credit FROM {viewTableName} WHERE funds_id = @funds_id AND is_approved = 1 AND is_cancelled = 0 AND is_disapproved = 0 AND maj_acc_group_id = @maj_acc_group_id AND date_entry <= @date_entry AND YEAR(date_entry) = @year ";

            using (var reader = _dbGenericCommands.ExecuteReader(query, parameters))
            {
                foreach (DataRow item in reader.Rows)
                {
                    record.Add("debit", Convert.ToDecimal(item[0]));
                    record.Add("credit", Convert.ToDecimal(item[1]));
                }
            }
            return record;
        }

        public Dictionary<string, decimal> GetSumTransactionsBySubMajAccGrpId(int fundId, int SubMajAccGrpId, DateTime date)
        {
            var record = new Dictionary<string, decimal>();

            var parameters = new object[][]
            {
                new object[] { "@funds_id", DbType.Int32, fundId},
                new object[] { "@sub_maj_acc_group_id", DbType.Int32, SubMajAccGrpId},
                new object[] { "@date_entry", DbType.Date, date.Date},
                new object[] { "@year", DbType.Int16, date.Date.Year},
            };

            string query = $"SELECT COALESCE(SUM(IF(is_debit = 1, amount, 0)),0) AS debit, COALESCE(SUM(IF(is_debit = 0, amount, 0)),0) AS credit FROM {viewTableName} WHERE funds_id = @funds_id AND is_approved = 1 AND is_cancelled = 0 AND is_disapproved = 0 AND sub_maj_acc_group_id = @sub_maj_acc_group_id AND date_entry <= @date_entry AND YEAR(date_entry) = @year ";

            using (var reader = _dbGenericCommands.ExecuteReader(query, parameters))
            {
                foreach (DataRow item in reader.Rows)
                {
                    record.Add("debit", Convert.ToDecimal(item[0]));
                    record.Add("credit", Convert.ToDecimal(item[1]));
                }
            }
            return record;
        }

        public Dictionary<string, decimal> GetSumTransactionsByGenLedgerId(int fundsId, int generalLedgerId, DateTime date)
        {
            var record = new Dictionary<string, decimal>();

            var parameters = new object[][]
            {
                new object[] { "@funds_id", DbType.Int32, fundsId},
                new object[] { "@general_ledger_accounts_id", DbType.Int32, generalLedgerId},
                new object[] { "@date_entry", DbType.Date, date.Date},
                new object[] { "@year", DbType.Int16, date.Date.Year},
            };

            string query = $"SELECT COALESCE(SUM(IF(is_debit = 1, amount, 0)),0) AS debit, COALESCE(SUM(IF(is_debit = 0, amount, 0)),0) AS credit FROM {viewTableName} WHERE funds_id = @funds_id AND is_approved =1 AND is_cancelled = 0 AND is_disapproved = 0 AND general_ledger_accounts_id = @general_ledger_accounts_id AND date_entry <= @date_entry AND YEAR(date_entry) = @year ";

            using (var reader = _dbGenericCommands.ExecuteReader(query, parameters))
            {
                foreach (DataRow item in reader.Rows)
                {
                    record.Add("debit", Convert.ToDecimal(item[0]));
                    record.Add("credit", Convert.ToDecimal(item[1]));
                }
            }
            return record;
        }
    }
}
