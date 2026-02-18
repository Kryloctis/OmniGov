using OmniGov.Core.Interfaces.Services;
using System.Data;
using System.Transactions;
using Treasury.Domain.Entities;
using Treasury.Domain.Interfaces;

namespace Treasury.Data.Repositories
{
    internal class PaymentFeesChargesRepository : IPaymentFeesCharges
    {
        private readonly string tableName = "payment_fees_charges";
        private readonly IGenericCommands _genericCommands;

        public PaymentFeesChargesRepository(IGenericCommands genericCommands)
        {
            _genericCommands = genericCommands ?? throw new ArgumentNullException(nameof(genericCommands));
        }

        public bool Delete(List<PaymentFeesChargesModel> entityList)
        {
            using (var scope = new TransactionScope())
            {
                foreach (var model in entityList)
                {
                    var parameters = new object[][] { new object[] { "@id", DbType.Int32, model.Id } };
                    string query = $"DELETE FROM {tableName} WHERE id = @id";
                    _ = _genericCommands.ExecuteNonQuery(query, parameters);
                }

                scope.Complete();
                return true;
            }
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            throw new NotImplementedException();
        }

        public DataTable GetRecords()
        {
            string query = $"SELECT * FROM {tableName}";
            var dataTable = new DataTable();
            return _genericCommands.Fill(query, dataTable);
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            var parameters = new object[][]
            {
                new object[] { "@search_key", DbType.String, $"%{searchText}%" }
            };

            string query = $"SELECT * FROM {tableName} WHERE unit LIKE @search_key OR sub_total LIKE @search_key";
            var dataTable = new DataTable();
            return _genericCommands.FillBySearch(query, dataTable, parameters);
        }

        public bool IdExist(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(PaymentFeesChargesModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@payment_collections_id", DbType.Int32, entity.PaymentCollectionsId},
                new object[] { "@other_payment_rates_id", DbType.Int32, entity.OtherPaymentRatesId},
                new object[] { "@unit", DbType.Int32, entity.Unit},
                new object[] { "@sub_total", DbType.Decimal, entity.SubTotal }
            };

            string query = $"INSERT INTO {tableName} (payment_collections_id, other_payment_rates_id, unit, sub_total ) VALUES (@payment_collections_id, @other_payment_rates_id, @unit, @sub_total)";
            return _genericCommands.ExecuteNonQuery(query, parameters);
        }

        public bool InsertBulk(List<PaymentFeesChargesModel> entityList)
        {
            using (var scope = new TransactionScope())
            {
                foreach (var model in entityList)
                    _ = Insert(model);

                scope.Complete();
                return true;
            }
        }

        public bool Update(PaymentFeesChargesModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, entity.Id},
                new object[] { "@payment_collections_id", DbType.Int32, entity.PaymentCollectionsId},
                new object[] { "@other_payment_rates_id", DbType.Int32, entity.OtherPaymentRatesId},
                new object[] { "@unit", DbType.Int32, entity.Unit},
                new object[] { "@sub_total", DbType.Decimal, entity.SubTotal }
            };

            string query = $"UPDATE {tableName} SET payment_collections_id = @payment_collections_id, other_payment_rates_id = @other_payment_rates_id, unit = @unit, sub_total = @sub_total WHERE id = @id";
            return _genericCommands.ExecuteNonQuery(query, parameters);
        }
    }
}