using OmniGov.Accounting.Domain.Entities;
using OmniGov.Accounting.Domain.Interfaces;
using OmniGov.Core.Interfaces.Services;
using System.Data;
using System.Transactions;

namespace OmniGov.Accounting.Data.Repositories
{
    public class AmortizationScheduleRepository : IAmortizationScheduleRepository
    {
        private readonly string tableName = "amortization_sched";
        private readonly IGenericCommands _genericCommands;

        public AmortizationScheduleRepository(IGenericCommands genericCommands)
        {
            _genericCommands = genericCommands ?? throw new ArgumentNullException(nameof(genericCommands));
        }

        public bool Delete(List<AmortizationScheduleModel> entityList)
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
                    _ = _genericCommands.ExecuteNonQuery(query, parameters);
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

            string query = $"SELECT id, amortization_id, date, principal_amount, interest_amount, grt_amount FROM {tableName} WHERE id = @id";

            using (var reader = _genericCommands.ExecuteReader(query, parameters))
            {
                if (reader.Rows.Count < 1)
                    return record;

                foreach (DataRow item in reader.Rows)
                {
                    record.Add("id", item[0].ToString());
                    record.Add("amortization_id", item[1].ToString());
                    record.Add("date", item[2].ToString());
                    record.Add("principal_amount", item[3].ToString());
                    record.Add("interest_amount", item[4].ToString());
                    record.Add("grt_amount", item[5].ToString());
                }
            }

            return record;
        }

        public DataTable GetRecords()
        {
            throw new NotImplementedException();
        }

        public DataTable GetRecordsByAmortizationId(int amortizationId)
        {
            string query = $"SELECT id, amortization_id, date, principal_amount, interest_amount, grt_amount FROM {tableName} WHERE amortization_id = {amortizationId}";
            return _genericCommands.Fill(query, new DataTable());
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
            var parameters = new object[][]
            {
                new object[] { "@amortization_id", DbType.Int32, entity.AmortizationId},
                new object[] { "@date", DbType.Date, entity.Date},
                new object[] { "@principal_amount", DbType.Decimal, entity.PrincipalAmount},
                new object[] { "@interest_amount", DbType.Decimal, entity.InterestAmount},
                new object[] { "@grt_amount", DbType.Decimal, entity.GRTAmount}
            };

            string query = $"INSERT INTO {tableName} (amortization_id, date, principal_amount, interest_amount, grt_amount) VALUES (@amortization_id, @date, @principal_amount, @interest_amount, @grt_amount)";

            return _genericCommands.ExecuteNonQuery(query, parameters);
        }

        public bool Update(AmortizationScheduleModel entity)
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

            return _genericCommands.ExecuteNonQuery(query, parameters);
        }
    }
}