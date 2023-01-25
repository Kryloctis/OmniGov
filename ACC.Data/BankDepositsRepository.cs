using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Transactions;

namespace ACC.Data
{
    public class BankDepositsRepository : IBankDepositsRepository
    {
        private readonly IAccGenericCommands _dbGenericCommands;
        private readonly string tableName = "bank_deposits";
        private readonly string tableName2 = "banks";
        private readonly string tableName3 = "users";

        private readonly string viewTableName = "view_bank_deposits";



        public BankDepositsRepository(IAccGenericCommands dbGenericCommands)
        {
            _dbGenericCommands = dbGenericCommands;
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

                string query = $"SELECT * FROM {tableName} WHERE id = @id";

                using (var reader = _dbGenericCommands.ExecuteReader(query, parameters))
                {
                    if (reader.Rows.Count < 1)
                        return record;

                    record.Add("banks_id", reader.Rows[0]["banks_id"].ToString());
                    record.Add("funds_id", reader.Rows[0]["funds_id"].ToString());
                    record.Add("reference", reader.Rows[0]["reference"].ToString());
                    record.Add("date", reader.Rows[0]["date"].ToString());
                    record.Add("amount", reader.Rows[0]["amount"].ToString());
                    record.Add("created_at", reader.Rows[0]["created_at"].ToString());
                    record.Add("created_by", reader.Rows[0]["created_by"].ToString());
                    record.Add("updated_at", reader.Rows[0]["updated_at"].ToString());
                    record.Add("updated_by", reader.Rows[0]["updated_by"].ToString());
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
            string query = $"SELECT * FROM {viewTableName}";

            var dtBanks = new DataTable();
            return _dbGenericCommands.Fill(query, dtBanks);
        }

        public bool Insert(BankDepositsModel entity)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@banks_id", DbType.Int16, entity.bankId},
                    new object[] { "@reference", DbType.String, entity.Reference},
                    new object[] { "@date", DbType.Date, entity.Date},
                    new object[] { "@amount", DbType.Decimal, entity.Amount},
                    new object[] { "@created_by", DbType.Int16, entity.CreatedBy},
                    new object[] { "@funds_id", DbType.Int16, entity.fundId},
                };

                string query = $"INSERT INTO {tableName} (banks_id,reference,date,amount,created_by,funds_id) VALUES (@banks_id,@reference,@date,@amount,@created_by,@funds_id)";
                return _dbGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Deposits(BankDepositsModel entity)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@banks_id", DbType.Int16, entity.bankId},
                    new object[] { "@reference", DbType.String, entity.Reference},
                    new object[] { "@date", DbType.Date, entity.Date},
                    new object[] { "@amount", DbType.Decimal, entity.Amount},
                    new object[] { "@created_by", DbType.Int16, entity.CreatedBy},
                    new object[] { "@funds_id", DbType.Int16, entity.fundId},
                };

                string query = $"INSERT INTO {tableName} " +
                               $"(banks_id, reference, date, amount, created_by, funds_id) " +
                               $"VALUES (@banks_id, @reference, @date, @amount, @created_by, @funds_id)";
                return _dbGenericCommands.ExecuteNonQueryId(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Update(BankDepositsModel entity)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@id", DbType.Int16, entity.Id},
                    new object[] { "@banks_id", DbType.Int16, entity.bankId},
                    new object[] { "@reference", DbType.String, entity.Reference},
                    new object[] { "@date", DbType.Date, entity.Date},
                    new object[] { "@amount", DbType.Decimal, entity.Amount},
                    new object[] { "@updated_by", DbType.Int16, entity.UpdatedBy},
                    new object[] { "@funds_id", DbType.Int16, entity.fundId},
                };

                string query = $"UPDATE {tableName} SET banks_id=@banks_id,reference=@reference,date=@date,amount=@amount,updated_by=@updated_by,funds_id=@funds_id WHERE id = @id";
                return _dbGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Delete(List<BankDepositsModel> entityList)
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

        public int CountRecords()
        {
            try
            {
                string query = $"SELECT COUNT(*) FROM {tableName}";

                return int.Parse(_dbGenericCommands.ExecuteScalar(query));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool IdExist(int id)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@id", DbType.Int32, id },
                };

                string query = $"SELECT id FROM {tableName} WHERE id = @id";
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

        public DataTable GetRecordsBySearch(string searchText)
        {
            try
            {
                var srchtxt = searchText;

                string query = $"SELECT {tableName}.id,{tableName2}.account_no,{tableName2}.bank_name,{tableName}.reference,{tableName}.date,{tableName}.amount,{tableName}.created_at,{tableName}.updated_at,CONCAT(u1.last_name,', ',u1.first_name,' ',u1.mid_initial) AS createdby,CONCAT(u2.last_name,', ',u2.first_name,' ',u2.mid_initial) AS updatedby FROM {tableName} LEFT JOIN {tableName2} ON {tableName}.banks_id={tableName2}.id LEFT JOIN {tableName3} u1 ON {tableName}.created_by=u1.id LEFT JOIN {tableName3} u2 ON {tableName}.updated_by=u2.id WHERE {tableName}.reference LIKE '%{srchtxt}%' OR {tableName2}.account_no LIKE '%{srchtxt}%' OR {tableName2}.bank_name LIKE '%{srchtxt}%' OR {tableName}.amount LIKE '%{srchtxt}%'";

                var dtBanks = new DataTable();
                return _dbGenericCommands.Fill(query, dtBanks);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetRecordsBySearch(int id)
        {
            try
            {
                string query = $"SELECT " +
                    $"{tableName}.id, " +
                    $"{tableName2}.account_no, " +
                    $"{tableName2}.bank_name, " +
                    $"{tableName}.reference, " +
                    $"{tableName}.date, " +
                    $"{tableName}.amount, " +
                    $"{tableName}.created_at, " +
                    $"{tableName}.updated_at, " +
                    $"CONCAT(u1.last_name,', ',u1.first_name,' ',u1.mid_initial) AS createdby, " +
                    $"CONCAT(u2.last_name,', ',u2.first_name,' ',u2.mid_initial) AS updatedby " +
                    $"FROM {tableName} " +
                    $"LEFT JOIN {tableName2} " +
                    $"ON {tableName}.banks_id={tableName2}.id " +
                    $"LEFT JOIN {tableName3} u1 " +
                    $"ON {tableName}.created_by=u1.id " +
                    $"LEFT JOIN {tableName3} u2 " +
                    $"ON {tableName}.updated_by=u2.id " +
                    $"WHERE {tableName}.banks_id='{id}'";

                var dtBanks = new DataTable();
                return _dbGenericCommands.Fill(query, dtBanks);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetBankDepositsSummary()
        {
            string query = $"SELECT banks_id, account_no, bank_name, SUM(amount) AS amount FROM view_bank_deposits";

            var dtBanksDeposit = new DataTable();
            return _dbGenericCommands.FillBySearch(query, dtBanksDeposit);
        }
    }
}