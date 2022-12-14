using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace ACC.Data
{
    internal class BeginningBalancesRepository : IBeginningBalancesRepository
    {
        private readonly IAccGenericCommands _dbGenericCommands;
        private readonly string tableName = "beginning_balances";
        private readonly string viewTableName = "view_beginning_balances";

        public BeginningBalancesRepository(IAccGenericCommands dbGenericCommands)
        {
            _dbGenericCommands = dbGenericCommands;
        }

        public int CountRecords()
        {
            throw new NotImplementedException();
        }

        public bool Delete(List<BeginningBalancesModel> entityList)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            throw new NotImplementedException();
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

        public DataTable GetRecordsBySearch(string searchText)
        {
            throw new NotImplementedException();
        }

        public decimal GetSumBalancesBy_FundId_GenLedgId_IsDebit_SubLedgId(byte fundsId, ushort generalLedgerId, short year, byte isDebit, ushort? subsidiaryLedgerId = null)
        {
            var parameters = new object[][]
            {
                new object[] { "@funds_id", DbType.Byte, fundsId},
                new object[] { "@general_ledger_accounts_id", DbType.UInt16, generalLedgerId},
                new object[] { "@year", DbType.Int16, year},
                new object[] { "@is_debit", DbType.Byte, isDebit},
                new object[] { "@subsidiary_ledger_accounts_id", DbType.UInt16, subsidiaryLedgerId}
            };

            string subsidiaryQuery = subsidiaryLedgerId == null ? string.Empty : $"AND subsidiary_ledger_accounts_id = @subsidiary_ledger_accounts_id ";

            string query = $"SELECT " +
                $"COALESCE(SUM(amount), 0) AS amount " +
                $"FROM {tableName} " +
                $"WHERE funds_id = @funds_id " +
                $"AND YEAR(date_entry) = @year " +
                $"AND general_ledger_accounts_id = @general_ledger_accounts_id " +
                $"{subsidiaryQuery}" +
                $"AND is_debit = @is_debit";
            decimal amount = Convert.ToDecimal(_dbGenericCommands.ExecuteScalar(query, parameters));
            return amount;
        }

        public Dictionary<string, string> GetRecordBy_FundId_GenLedgId_Year_SubLedgId(byte fundsId, ushort generalLedgerId, short year, ushort? subsidiaryLedgerId = null)
        {
            var record = new Dictionary<string, string>();

            var parameters = new object[][]
            {
                new object[] { "@funds_id", DbType.Byte, fundsId},
                new object[] { "@general_ledger_accounts_id", DbType.UInt16, generalLedgerId},
                new object[] { "@year", DbType.Int16, year},
                new object[] { "@subsidiary_ledger_accounts_id", DbType.UInt16, subsidiaryLedgerId},
            };
            string subsidiaryQuery = subsidiaryLedgerId == null ? string.Empty : $"AND subsidiary_ledger_accounts_id = @subsidiary_ledger_accounts_id ";

            string query = $"SELECT " +
                $"funds_id, " +
                $"id, " +
                $"subsidiary_ledger_accounts_id, " +
                $"is_debit, " +
                $"MAX(date_entry) AS date_entry, " +
                $"amount, " +
                $"created_at, " +
                $"updated_at " +
                $"FROM {tableName} " +
                $"WHERE funds_id = @funds_id " +
                $"AND general_ledger_accounts_id = @general_ledger_accounts_id " +
                $"AND YEAR(date_entry) = @year " +
                $"{subsidiaryQuery}";

            using (var reader = _dbGenericCommands.ExecuteReader(query, parameters))
            {
                if (reader.Rows.Count < 1)
                    return record;

                record.Add("funds_id", reader.Rows[0]["funds_id"].ToString());
                record.Add("id", reader.Rows[0]["id"].ToString());
                record.Add("subsidiary_ledger_accounts_id", reader.Rows[0]["subsidiary_ledger_accounts_id"].ToString());
                record.Add("is_debit", reader.Rows[0]["is_debit"].ToString());
                record.Add("date_entry", reader.Rows[0]["date_entry"].ToString());
                record.Add("amount", reader.Rows[0]["amount"].ToString());
                record.Add("created_at", reader.Rows[0]["created_at"].ToString());
                record.Add("updated_at", reader.Rows[0]["updated_at"].ToString());
            }

            return record;
        }

        public Dictionary<string, decimal> GetSumBeginningBalanceBy_FundId_AccGrpId_Date_SubLedgeId(byte fundsId, ushort accountGroupId, DateTime dateEntry, ushort? subsidiaryLedgerId = null)
        {
            var record = new Dictionary<string, decimal>();

            var parameters = new object[][]
            {
                new object[] { "@funds_id", DbType.Byte, fundsId},
                new object[] { "@account_group_id", DbType.UInt16, accountGroupId},
                new object[] { "@date_entry", DbType.Date, dateEntry.Date},
                new object[] { "@year", DbType.Int16, dateEntry.Date.Year},
                new object[] { "@subsidiary_ledger_accounts_id", DbType.UInt16, subsidiaryLedgerId}
            };

            string subsidiaryQuery = subsidiaryLedgerId == null ? string.Empty : $"AND subsidiary_ledger_accounts_id = @subsidiary_ledger_accounts_id ";

            string query = $"SELECT " +
                $"COALESCE(SUM(IF(is_debit = 1, amount, 0)), 0) AS beginning_balance_debit, " +
                $"COALESCE(SUM(IF(is_debit = 0, amount, 0)), 0) AS beginning_balance_credit " +
                $"FROM {viewTableName} " +
                $"WHERE funds_id = @funds_id " +
                $"AND date_entry <= @date_entry " +
                $"AND YEAR(date_entry) = @year " +
                $"AND account_group_id = @account_group_id " +
                $"{subsidiaryQuery}";

            using (var reader = _dbGenericCommands.ExecuteReader(query, parameters))
            {
                foreach (DataRow item in reader.Rows)
                {
                    record.Add("beginning_balance_debit", Convert.ToDecimal(item[0]));
                    record.Add("beginning_balance_credit", Convert.ToDecimal(item[1]));
                }
            }

            return record;
        }

        public Dictionary<string, decimal> GetSumBeginningBalanceBy_FundId_MajAccGrpId_Date_SubLedgeId(byte fundsId, ushort majAccountGroupId, DateTime dateEntry, ushort? subsidiaryLedgerId = null)
        {
            var record = new Dictionary<string, decimal>();

            var parameters = new object[][]
            {
                new object[] { "@funds_id", DbType.Byte, fundsId},
                new object[] { "@maj_acc_group_id", DbType.UInt16, majAccountGroupId},
                new object[] { "@date_entry", DbType.Date, dateEntry.Date},
                new object[] { "@year", DbType.Int16, dateEntry.Date.Year},
                new object[] { "@subsidiary_ledger_accounts_id", DbType.UInt16, subsidiaryLedgerId}
            };

            string subsidiaryQuery = subsidiaryLedgerId == null ? string.Empty : $"AND subsidiary_ledger_accounts_id = @subsidiary_ledger_accounts_id ";

            string query = $"SELECT " +
                $"COALESCE(SUM(IF(is_debit = 1, amount, 0)), 0) AS beginning_balance_debit, " +
                $"COALESCE(SUM(IF(is_debit = 0, amount, 0)), 0) AS beginning_balance_credit " +
                $"FROM {viewTableName} " +
                $"WHERE funds_id = @funds_id " +
                $"AND date_entry <= @date_entry " +
                $"AND YEAR(date_entry) = @year " +
                $"AND maj_acc_group_id = @maj_acc_group_id " +
                $"{subsidiaryQuery}";

            using (var reader = _dbGenericCommands.ExecuteReader(query, parameters))
            {
                foreach (DataRow item in reader.Rows)
                {
                    record.Add("beginning_balance_debit", Convert.ToDecimal(item[0]));
                    record.Add("beginning_balance_credit", Convert.ToDecimal(item[1]));
                }
            }

            return record;
        }

        public Dictionary<string, decimal> GetSumBeginningBalanceBy_FundId_SubMajAccGrpId_Date_SubLedgeId(byte fundsId, ushort subMajAccountGroupId, DateTime dateEntry, ushort? subsidiaryLedgerId = null)
        {
            var record = new Dictionary<string, decimal>();

            var parameters = new object[][]
            {
                new object[] { "@funds_id", DbType.Byte, fundsId},
                new object[] { "@sub_maj_acc_group_id", DbType.UInt16, subMajAccountGroupId},
                new object[] { "@date_entry", DbType.Date, dateEntry.Date},
                new object[] { "@year", DbType.Int16, dateEntry.Date.Year},
                new object[] { "@subsidiary_ledger_accounts_id", DbType.UInt16, subsidiaryLedgerId}
            };

            string subsidiaryQuery = subsidiaryLedgerId == null ? string.Empty : $"AND subsidiary_ledger_accounts_id = @subsidiary_ledger_accounts_id ";

            string query = $"SELECT " +
                $"COALESCE(SUM(IF(is_debit = 1, amount, 0)), 0) AS beginning_balance_debit, " +
                $"COALESCE(SUM(IF(is_debit = 0, amount, 0)), 0) AS beginning_balance_credit " +
                $"FROM {viewTableName} " +
                $"WHERE funds_id = @funds_id " +
                $"AND date_entry <= @date_entry " +
                $"AND YEAR(date_entry) = @year " +
                $"AND sub_maj_acc_group_id = @sub_maj_acc_group_id " +
                $"{subsidiaryQuery}";

            using (var reader = _dbGenericCommands.ExecuteReader(query, parameters))
            {
                foreach (DataRow item in reader.Rows)
                {
                    record.Add("beginning_balance_debit", Convert.ToDecimal(item[0]));
                    record.Add("beginning_balance_credit", Convert.ToDecimal(item[1]));
                }
            }

            return record;
        }

        public Dictionary<string, decimal> GetSumBalancesBy_FundId_GenLedgId_Date_SubLedgId(byte fundsId, ushort generalLedgerId, DateTime dateEntry, ushort? subsidiaryLedgerId = null)
        {
            var record = new Dictionary<string, decimal>();

            var parameters = new object[][]
            {
                new object[] { "@funds_id", DbType.Byte, fundsId},
                new object[] { "@general_ledger_accounts_id", DbType.UInt16, generalLedgerId},
                new object[] { "@date_entry", DbType.Date, dateEntry.Date},
                new object[] { "@year", DbType.Int16, dateEntry.Date.Year},
                new object[] { "@subsidiary_ledger_accounts_id", DbType.UInt16, subsidiaryLedgerId}
            };

            string subsidiaryQuery = subsidiaryLedgerId == null ? string.Empty : $"AND subsidiary_ledger_accounts_id = @subsidiary_ledger_accounts_id ";

            string query = $"SELECT " +
                $"COALESCE(SUM(IF(is_debit = 1, amount, 0)), 0) AS beginning_balance_debit, " +
                $"COALESCE(SUM(IF(is_debit = 0, amount, 0)), 0) AS beginning_balance_credit " +
                $"FROM {tableName} " +
                $"WHERE funds_id = @funds_id " +
                $"AND date_entry <= @date_entry " +
                $"AND YEAR(date_entry) = @year " +
                $"AND general_ledger_accounts_id = @general_ledger_accounts_id " +
                $"{subsidiaryQuery}";

            using (var reader = _dbGenericCommands.ExecuteReader(query, parameters))
            {
                foreach (DataRow item in reader.Rows)
                {
                    record.Add("beginning_balance_debit", Convert.ToDecimal(item[0]));
                    record.Add("beginning_balance_credit", Convert.ToDecimal(item[1]));
                }
            }

            return record;
        }

        public decimal GetSumBalanceBy_FundId_GenLedgId_Year_SubLedgId(byte fundsId, ushort generalLedgerId, short year, ushort? subsidiaryLedgerId = null)
        {
            var parameters = new object[][]
            {
                new object[] { "@funds_id", DbType.Byte, fundsId},
                new object[] { "@general_ledger_accounts_id", DbType.UInt16, generalLedgerId},
                new object[] { "@year", DbType.Int16, year},
                new object[] { "@subsidiary_ledger_accounts_id", DbType.UInt16, subsidiaryLedgerId},
            };

            string query = $"SELECT " +
                $"COALESCE(SUM(amount)) " +
                $"FROM {tableName} " +
                $"WHERE funds_id = @funds_id " +
                $"AND general_ledger_accounts_id = @general_ledger_accounts_id " +
                $"AND YEAR(date_entry) = @year " +
                $"AND subsidiary_ledger_accounts_id = @subsidiary_ledger_accounts_id " +
                $"GROUP BY general_ledger_accounts_id";

            string sumBalance = _dbGenericCommands.ExecuteScalar(query, parameters);
            if (!string.IsNullOrWhiteSpace(sumBalance))
                return Convert.ToDecimal(sumBalance);

            return 0;
        }

        public bool IdExist(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(BeginningBalancesModel entity)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@funds_id", DbType.Byte, entity.FundsId},
                    new object[] { "@general_ledger_accounts_id", DbType.Int16, entity.GeneralLedgerId},
                    new object[] { "@subsidiary_ledger_accounts_id", DbType.Int16, entity.SubsidiaryLedgerId},
                    new object[] { "@is_debit", DbType.Boolean, entity.IsDebit},
                    new object[] { "@date_entry", DbType.Date, entity.DateEntry},
                    new object[] { "@amount", DbType.Decimal, entity.Amount},
                };

                string query = $"INSERT INTO {tableName} (funds_id, general_ledger_accounts_id, subsidiary_ledger_accounts_id, is_debit, date_entry, amount) VALUES (@funds_id, @general_ledger_accounts_id, @subsidiary_ledger_accounts_id, @is_debit, @date_entry, @amount)";
                return _dbGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Update(BeginningBalancesModel entity)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@id", DbType.Int32, entity.Id},
                    new object[] { "@funds_id", DbType.Byte, entity.FundsId},
                    new object[] { "@general_ledger_accounts_id", DbType.Int16, entity.GeneralLedgerId},
                    new object[] { "@subsidiary_ledger_accounts_id", DbType.Int16, entity.SubsidiaryLedgerId},
                    new object[] { "@is_debit", DbType.Boolean, entity.IsDebit},
                    new object[] { "@date_entry", DbType.Date, entity.DateEntry},
                    new object[] { "@amount", DbType.Decimal, entity.Amount},
                };

                string query = $"UPDATE {tableName} SET funds_id = @funds_id, general_ledger_accounts_id = @general_ledger_accounts_id, subsidiary_ledger_accounts_id = @subsidiary_ledger_accounts_id, is_debit = @is_debit, date_entry = @date_entry, amount = @amount WHERE id = @id";
                return _dbGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool GeneralLedgerBalanceExist(byte fundsId, ushort generalLedgerId, short year)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@funds_id", DbType.Byte, fundsId},
                    new object[] { "@general_ledger_accounts_id", DbType.UInt16, generalLedgerId},
                    new object[] { "@year", DbType.Int16, year},
                };

                string query = $"SELECT id FROM {tableName} WHERE funds_id = @funds_id AND subsidiary_ledger_accounts_id IS NULL AND general_ledger_accounts_id = @general_ledger_accounts_id AND YEAR(date_entry) = @year";
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

        public bool SubsidiaryLedgerBalanceExist(byte fundsId, ushort generalLedgerId, short year, ushort subsidiaryLedgerId)
        {
            var parameters = new object[][]
            {
                new object[] { "@funds_id", DbType.Byte, fundsId},
                new object[] { "@general_ledger_accounts_id", DbType.UInt16, generalLedgerId},
                new object[] { "@subsidiary_ledger_accounts_id", DbType.UInt16, subsidiaryLedgerId},
                new object[] { "@year", DbType.Int16, year},
            };

            string query = $"SELECT id FROM {tableName} WHERE funds_id = @funds_id AND general_ledger_accounts_id = @general_ledger_accounts_id AND subsidiary_ledger_accounts_id = @subsidiary_ledger_accounts_id AND YEAR(date_entry) = @year";
            string queryResult = _dbGenericCommands.ExecuteScalar(query, parameters);

            // if query is not null, means found some record, so true
            if (!string.IsNullOrEmpty(queryResult)) return true;

            return false;
        }

        public bool DeleteById(int Id)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@id", DbType.Int32, Id}
                };
                string query = $"DELETE FROM {tableName} WHERE id = @id";
                return _dbGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (MySqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public decimal GetSumBalancesBy_FundId_Year_Availablility(int fundsId, short year, bool isDebit)
        {
            var parameters = new object[][]
            {
                new object[] { "@funds_id", DbType.Int32, fundsId},
                new object[] { "@year", DbType.Int16, year},
                new object[] { "@is_debit", DbType.Boolean, isDebit}
            };

            string query = $"SELECT COALESCE(SUM((amount)),0) AS amount FROM {tableName} WHERE funds_id = @funds_id AND YEAR(date_entry) = @year AND is_debit = @is_debit";

            return Convert.ToDecimal(_dbGenericCommands.ExecuteScalar(query, parameters));
        }
    }
}