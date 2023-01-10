using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.InteropServices;
using System.Text;
using System.Transactions;

namespace ACC.Data
{
    public class PaymentCollectionHasChequesRepository : IPaymentCollectionHasChequesRepository
    {
        private readonly string tableName = "payment_collection_has_cheques";
        private IChequesRepository _chequesRepository;
        private AccGenericCommands _mySqlGenericCommandsLFS;

        public PaymentCollectionHasChequesRepository(AccGenericCommands mySqlGenericCommandsLFS, IChequesRepository chequesRepository)
        {
            _mySqlGenericCommandsLFS = mySqlGenericCommandsLFS;
            _chequesRepository = chequesRepository;
        }

        public int CountRecords()
        {
            throw new NotImplementedException();
        }

        public bool Delete(List<PaymentCollectionHasChequesModel> entityList)
        {
            using (var scope = new TransactionScope())
            {
                foreach (PaymentCollectionHasChequesModel paymentCollectionHasChequesModel in entityList)
                {
                    var parameters = new object[][]
                    {
                        new object[] { "@payment_collection_id", DbType.Int32, paymentCollectionHasChequesModel.PaymentCollectionId}
                    };

                    string query = $"DELETE FROM {tableName} WHERE payment_collection_id = @payment_collection_id";
                    _ = _mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
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
            throw new NotImplementedException();
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            throw new NotImplementedException();
        }

        public bool IdExist(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(PaymentCollectionHasChequesModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "payment_collections_id", DbType.Int32, entity.PaymentCollectionId},
                new object[] { "cheques_id", DbType.Int32, entity.ChequesId}
            };

            string query = $"INSERT INTO {tableName} (payment_collections_id, cheques_id) VALUES (@payment_collections_id, @cheques_id)";
            return _mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
        }

        public bool InsertWithCheques(PaymentCollectionHasChequesModel entity)
        {
            using (var scope = new TransactionScope())
            {
                foreach (ChequesModel model in entity.ChequesModels)
                {
                    _ = _chequesRepository.Insert(model);
                    entity.ChequesId = _chequesRepository.GetLastInsertId();
                    Insert(entity);
                }

                scope.Complete();
                return true;
            }
        }

        public bool Update(PaymentCollectionHasChequesModel entity)
        {
            throw new NotImplementedException();
        }
    }
}