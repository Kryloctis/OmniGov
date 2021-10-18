using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Transactions;

namespace ACC.Data
{
    public class AmortizationScheduleRepository : IAmortizationScheduleRepository
    {
        readonly string tableName = "amortization_sched";
        private MySqlGenericCommands _mySqlGenericCommands;

        public AmortizationScheduleRepository(MySqlGenericCommands mySqlGenericCommands)
        {
            this._mySqlGenericCommands = mySqlGenericCommands;
        }

        public int CountRecords()
        {
            throw new NotImplementedException();
        }

        public bool dateExist(DateTime date)
        {
            try
            {

            }
            catch (Exception)
            {
                throw;
            }
            return false;
        }

        public bool Delete(List<AmortizationScheduleModel> entityList)
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
            throw new NotImplementedException();
        }

        public DataTable GetRecords()
        {
            throw new NotImplementedException();
        }

        public DataTable GetRecordsByAmortizationId(int amortizationId)
        {
            var dataTable = new DataTable();
            try
            {
                string query = $"SELECT id, amortization_id, date, principal_amount, interest_amount, grt_amount FROM {tableName} WHERE amortization_id = {amortizationId}";

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

        public bool Insert(AmortizationScheduleModel entity)
        {
            try
            {
                var parameters = new object[][] 
                {
                    new object[] { "@amortization_id", DbType.Int32, entity.AmortizationId},
                    new object[] { "@date", DbType.Date, entity.Date},
                    new object[] { "@principal_amount", DbType.Decimal, entity.PrincipalAmount},
                    new object[] { "@interest_amount", DbType.Decimal, entity.InterestAmount},
                    new object[] { "@grt_amount", DbType.Decimal, entity.GRTAmount}
                };

                string query = $"INSERT INTO {tableName} (amortization_id, date, principal_amount, interest_amount, grt_amount) VALUES (@amortization_id, @date, @principal_amount, @interest_amount, @grt_amount)";

                return _mySqlGenericCommands.ExecuteNonQuery(query, parameters);

            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Update(AmortizationScheduleModel entity)
        {
            try
            {
                var parameters = new object[][] 
                {
                    new object[] { "@id", DbType.Int32, entity.Id},
                    new object[] { "@amortization_id", DbType.Int32, entity.AmortizationId},
                    new object[] { "@date", DbType.Date, entity.Date},
                    new object[] { "@principal_amount", DbType.Decimal, entity.PrincipalAmount},
                    new object[] { "@interest_amount", DbType.Decimal, entity.InterestAmount},
                    new object[] { "@grt_amount", DbType.Decimal, entity.GRTAmount}
                };

                string query = $"UPDATE {tableName} SET amortization_id = @amortization_id, date = @date, principal_amount = @principal_amount, interest_amount = @interest_amount, grt_amount = @grt_amount WHERE id = @id ";

                return _mySqlGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
