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
            throw new NotImplementedException();
        }
    }
}
