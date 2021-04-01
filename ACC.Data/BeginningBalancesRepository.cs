using System;
using System.Collections.Generic;
using System.Data;
using ACC.Domain.Interfaces;
using ACC.Domain.Models;

namespace ACC.Data
{
    class BeginningBalancesRepository : IBeginningBalancesRepository
    {
        private readonly IDbGenericCommands _dbGenericCommands;
        private readonly string tableName = "beginning_balances";
        private readonly string viewTableName = "view_beginning_balances";


        public BeginningBalancesRepository(IDbGenericCommands dbGenericCommands)
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
            var record = new Dictionary<string, string>();

            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@id", DbType.Int32, Id},
                };

                string query = $"SELECT  FROM {tableName} WHERE id = @id";

                using (var reader = _dbGenericCommands.ExecuteReader(query, parameters))
                {
                    if (reader.Rows.Count < 1)
                        return record;

                    record.Add("account_group_code", reader.Rows[0][0].ToString());
                    record.Add("account_group_name", reader.Rows[0][1].ToString());
                    record.Add("created_at", reader.Rows[0][2].ToString());
                    record.Add("updated_at", reader.Rows[0][3].ToString());
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

        public DataTable GetRecordsBySearch(string searchText)
        {
            throw new NotImplementedException();
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
                    new object[] { "@year", DbType.Int16, entity.Year},
                    new object[] { "@amount", DbType.Decimal, entity.Amount},
                };

                string query = $"INSERT INTO {tableName} (funds_id, general_ledger_accounts_id, subsidiary_ledger_accounts_id, year, amount) VALUES (@funds_id, @general_ledger_accounts_id, @subsidiary_ledger_accounts_id, @year, @amount)";
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
                    new object[] { "@year", DbType.Int16, entity.Year},
                    new object[] { "@amount", DbType.Decimal, entity.Amount},
                };

                string query = $"UPDATE {tableName} SET funds_id = @funds_id, general_ledger_accounts_id = @general_ledger_accounts_id, subsidiary_ledger_accounts_id = @subsidiary_ledger_accounts_id, year = @year, amount = @amount WHERE id = @id";
                return _dbGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
