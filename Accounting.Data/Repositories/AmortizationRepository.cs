using Accounting.Domain.Entities;
using Accounting.Domain.Interfaces;
using OmniGov.Core.Repositories;
using System.Data;
using System.Transactions;

namespace Accounting.Data.Repositories
{
    public class AmortizationRepository : IAmortizationRepository
    {
        private GenericCommands _mySqlGenericCommands;

        private readonly string tableName = "amortization";

        public AmortizationRepository(GenericCommands mySqlGenericCommands)
        {
            _mySqlGenericCommands = mySqlGenericCommands;
        }

        public bool Delete(List<AmortizationModel> entityList)
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

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            var record = new Dictionary<string, string>();

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

            return record;
        }

        public DataTable GetRecords()
        {
            string query = $"SELECT id, bank_name, amortization_term, interest, amount_released FROM {tableName}";
            return _mySqlGenericCommands.Fill(query, new DataTable());
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

        public bool Update(AmortizationModel entity)
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

            return _mySqlGenericCommands.ExecuteNonQuery(query, parameters);
        }
    }
}