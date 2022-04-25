using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Transactions;

namespace ACC.Data
{
    public class SubsidiaryLedgerAccountsRepository : ISubsidiaryLedgerAccountsRepository
    {
        private readonly IDbGenericCommands _dbGenericCommands;
        private readonly string tableName = "subsidiary_ledger_accounts";

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
            try
            {
                using (var scope = new TransactionScope())
                {
                    foreach (var entity in entityList)
                    {
                        var parameters = new object[][]
                        {
                            new object[] { "@id", DbType.Int16, entity.Id},
                        };

                        string query = $"DELETE FROM {tableName} WHERE id = @id";
                        _ = _dbGenericCommands.ExecuteNonQuery(query, parameters);
                    }

                    scope.Complete();
                    return true;
                }
            }
            catch (Exception)
            {
                throw;
            }
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

                string query = $"SELECT funds_id, general_ledger_accounts_id, sub_code, sub_name, address, contact_person, contact, created_at, updated_at FROM {tableName} WHERE id = @id";

                using (var reader = _dbGenericCommands.ExecuteReader(query, parameters))
                {
                    if (reader.Rows.Count < 1)
                        return record;

                    record.Add("funds_id", reader.Rows[0]["funds_id"].ToString());
                    record.Add("general_ledger_accounts_id", reader.Rows[0]["general_ledger_accounts_id"].ToString());
                    record.Add("sub_code", reader.Rows[0]["sub_code"].ToString());
                    record.Add("sub_name", reader.Rows[0]["sub_name"].ToString());
                    record.Add("address", reader.Rows[0]["address"].ToString());
                    record.Add("contact_person", reader.Rows[0]["contact_person"].ToString());
                    record.Add("contact", reader.Rows[0]["contact"].ToString());
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

        public DataTable GetRecordsByReference(int Id)
        {
            try
            {
                string query = $"SELECT * FROM {tableName} WHERE general_ledger_accounts_id='{Id}'";

                var dtJournals = new DataTable();
                return _dbGenericCommands.Fill(query, dtJournals);
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
                string query = $"SELECT * FROM {tableName} WHERE sub_code LIKE '%{srchtxt}%' OR sub_code LIKE '%{srchtxt}%'";

                var dtJournals = new DataTable();
                return _dbGenericCommands.Fill(query, dtJournals);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetRecordsBySearchByReference(string srchtxt, int Id)
        {
            try
            {
                string query = $"SELECT * FROM {tableName} WHERE general_ledger_accounts_id='{Id}' AND sub_code LIKE '%{srchtxt}%' OR sub_code LIKE '%{srchtxt}%'";

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

                string query = $"SELECT * FROM {tableName} WHERE funds_id = @funds_id AND general_ledger_accounts_id = @generalLedgerId";

                var dtJournals = new DataTable();
                return _dbGenericCommands.ExecuteReader(query, parameters);
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
                    new object[] { "@address", DbType.String, entity.Address},
                    new object[] { "@contact_person", DbType.String, entity.ContactPerson},
                    new object[] { "@contact", DbType.String, entity.Contact}
                };

                string query = $"INSERT INTO {tableName} (funds_id, general_ledger_accounts_id, sub_code, sub_name, address, contact_person, contact) VALUES (@funds_id, @general_ledger_accounts_id, @sub_code, @sub_name, @address, @contact_person, @contact)";
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
                    new object[] { "@address", DbType.String, entity.Address},
                    new object[] { "@contact_person", DbType.String, entity.ContactPerson},
                    new object[] { "@contact", DbType.String, entity.Contact}
                };

                string query = $"UPDATE {tableName} SET funds_id = @funds_id, general_ledger_accounts_id = @general_ledger_accounts_id, sub_code = @sub_code, sub_name = @sub_name, address = @address, contact_person = @contact_person, contact = @contact WHERE id = @id";

                return _dbGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool HasSubsidiary(ushort generalLedgerId)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@general_ledger_accounts_id", DbType.UInt16, generalLedgerId },
                };

                string query = $"SELECT id FROM {tableName} WHERE general_ledger_accounts_id = @general_ledger_accounts_id";
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
    }
}
