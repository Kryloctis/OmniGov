using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using ACC.Domain.Interfaces;
using ACC.Domain.Models;

namespace ACC.Data
{
    public class SubsidiaryLedgerAccountsRepository : ISubsidiaryLedgerAccountsRepository
    {
        private readonly IDbGenericCommands _dbGenericCommands;
        private readonly string tableName = "subsidiary_ledger_accounts";
        private readonly string viewTableName = "view_subsidiary_ledger_accounts";

        public SubsidiaryLedgerAccountsRepository(IDbGenericCommands dbGenericCommands)
        {
            _dbGenericCommands = dbGenericCommands;
        }

        public int CountRecords()
        {
            throw new NotImplementedException();
        }

        public bool Delete(List<SubsidiaryLedgerAccountsModel> entityList)
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
                    new object[] { "@id", DbType.UInt16, Id},
                };

                string query = $"SELECT funds_id, general_ledger_accounts_id, sub_code, sub_name, created_at, updated_at FROM {tableName} WHERE id = @id";

                using (var reader = _dbGenericCommands.ExecuteReader(query, parameters))
                {
                    if (reader.Rows.Count < 1)
                        return record;

                    record.Add("funds_id", reader.Rows[0][0].ToString());
                    record.Add("general_ledger_accounts_id", reader.Rows[0][1].ToString());
                    record.Add("sub_code", reader.Rows[0][2].ToString());
                    record.Add("sub_name", reader.Rows[0][3].ToString());
                    record.Add("created_at", reader.Rows[0][4].ToString());
                    record.Add("updated_at", reader.Rows[0][5].ToString());
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

        public DataTable GetRecordsByFundAndGeneralLedger(byte fundId, ushort generalLedgerId)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@funds_id", DbType.Byte, fundId},
                    new object[] { "@generalLedgerId", DbType.UInt16, generalLedgerId},
                };

                string query = $"SELECT * FROM {tableName} WHERe funds_id = @funds_id AND general_ledger_accounts_id = @generalLedgerId";

                var dtJournals = new DataTable();
                return _dbGenericCommands.ExecuteReader(query, parameters);
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

        public bool Insert(SubsidiaryLedgerAccountsModel entity)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@funds_id", DbType.Byte, entity.FundId},
                    new object[] { "@general_ledger_accounts_id", DbType.UInt16, entity.GeneralLedgerAccountsId},
                    new object[] { "@sub_code", DbType.String, entity.Code},
                    new object[] { "@sub_name", DbType.String, entity.Name},
                };

                string query = $"INSERT INTO {tableName} (funds_id, general_ledger_accounts_id, sub_code, sub_name) VALUES (@funds_id, @general_ledger_accounts_id, @sub_code, @sub_name)";
                return _dbGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Update(SubsidiaryLedgerAccountsModel entity)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@id", DbType.UInt16, entity.Id},
                    new object[] { "@funds_id", DbType.Byte, entity.FundId},
                    new object[] { "@general_ledger_accounts_id", DbType.UInt16, entity.GeneralLedgerAccountsId},
                    new object[] { "@sub_code", DbType.String, entity.Code},
                    new object[] { "@sub_name", DbType.String, entity.Name},
                };

                string query = $"UPDATE {tableName} SET funds_id = @funds_id, general_ledger_accounts_id = @general_ledger_accounts_id, sub_code = @sub_code, sub_name = @sub_name WHERE id = @id";

                return _dbGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
