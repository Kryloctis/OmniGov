using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Transactions;

namespace ACC.Data
{
    public class AmortizationRepository : IAmortizationRepository
    {
        private AccGenericCommands _mySqlGenericCommands;

        private readonly string tableName = "amortization";

        public AmortizationRepository(AccGenericCommands mySqlGenericCommands)
        {
            this._mySqlGenericCommands = mySqlGenericCommands;
        }

        public int CountRecords()
        {
            throw new NotImplementedException();
        }

        public bool Delete(List<AmortizationModel> entityList)
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
                        _ = _mySqlGenericCommands.ExecuteNonQuery(query, parameters);
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
                    new object[] { "@id", DbType.Int32, Id}
                };

                string query = $"SELECT id, bank_name, amortization_term, interest, amount_released FROM {tableName} WHERE id = @id";

                using (var reader = _mySqlGenericCommands.ExecuteReader(query, parameters))
                {
                    if (reader.Rows.Count < 1)
                        return record;

                    foreach (DataRow item in reader.Rows)
                    {
                        record.Add("id", item[0].ToString());
                        record.Add("bank_name", item[1].ToString());
                        record.Add("amortization_term", item[2].ToString());
                        record.Add("interest", item[3].ToString());
                        record.Add("amount_released", item[4].ToString());
                    }
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
            var dataTable = new DataTable();

            try
            {
                string query = $"SELECT id, bank_name, amortization_term, interest, amount_released FROM {tableName}";

                return _mySqlGenericCommands.Fill(query, dataTable);
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

        public bool Insert(AmortizationModel entity)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] {"@bank_name", DbType.String, entity.BankName},
                    new object[] {"@amortization_term", DbType.String, entity.AmortizationTerm},
                    new object[] {"@interest", DbType.Int32, entity.Interest},
                    new object[] {"@amount_released", DbType.Decimal, entity.AmountReleased},
                };

                string query = $"INSERT INTO {tableName} (bank_name, amortization_term, interest, amount_released) VALUES (@bank_name, @amortization_term, @interest, @amount_released)";

                return _mySqlGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Update(AmortizationModel entity)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@id", DbType.Int32, entity.Id},
                    new object[] {"@bank_name", DbType.String, entity.BankName},
                    new object[] {"@amortization_term", DbType.String, entity.AmortizationTerm},
                    new object[] {"@interest", DbType.Int32, entity.Interest},
                    new object[] {"@amount_released", DbType.Decimal, entity.AmountReleased},
                };

                string query = $"UPDATE {tableName} SET bank_name = @bank_name, amortization_term = @amortization_term, interest = @interest, amount_released = @amount_released WHERE id = @id ";

                return _mySqlGenericCommands.ExecuteNonQuery(query,parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
