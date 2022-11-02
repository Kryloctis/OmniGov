using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Transactions;

namespace ACC.Data
{
    public class GeneralPaymentsRepository : IGeneralPaymentsRepository
    {
        private AccGenericCommands mySqlGenericCommandsLFS;
        private string tableName = "general_payments";
        private string viewTableName = "view_general_payments";

        public GeneralPaymentsRepository(AccGenericCommands mySqlGenericCommandsLFS)
        {
            this.mySqlGenericCommandsLFS = mySqlGenericCommandsLFS;
        }

        public bool IdExist(int id)
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

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            throw new NotImplementedException();
        }

        public int CountRecords()
        {
            throw new NotImplementedException();
        }

        public bool Insert(GeneralPaymentsModel entity)
        {
            var parameter = new object[][] { 
                new object[]{"@payment_collections_id", DbType.Int32, entity.PaymentCollectionId},
                new object[]{"@general_ledger_accounts_id", DbType.Int16, entity.GeneralLedgerAccountsId},
                new object[]{"@quantity", DbType.Int32, entity.Quantity },
            };

            string query = $"INSERT INTO {tableName} VALUES (null, @payment_collections_id, @general_ledger_accounts_id, null, @quantity)";
            return mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameter);
        }

        public bool Update(GeneralPaymentsModel entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(List<GeneralPaymentsModel> entityList)
        {
            try
            {
                using (var scope = new TransactionScope())
                {
                    foreach (var entity in entityList)
                    {
                        var parameters = new object[][]
                        {
                            new object[] { "@id", DbType.Int32, entity.PaymentCollectionId},
                        };

                        string query = $"DELETE FROM {tableName} WHERE payment_collections_id = @id";
                        _ = mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
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

        public Dictionary<string, string> GetRecordsByPaymentCollectionsID(int paymentCollectionID)
        {
            try
            {
                var record = new Dictionary<string, string>();

                var parameter = new object[][] {
                    new object[]{"@payment_collections_id", DbType.Int32, paymentCollectionID}
                };

                string query = $"SELECT general_payments_id, payment_collections_id, general_ledger_accounts_id, general_ledger_accounts_code, general_ledger_name, quantity FROM {viewTableName}  WHERE payment_collections_id = @payment_collections_id";


                using (var reader = mySqlGenericCommandsLFS.ExecuteReader(query, parameter))
                {
                    if (reader.Rows.Count < 1)
                        return record;


                    foreach (DataRow item in reader.Rows)
                    {
                        record.Add("general_payments_id", item[0].ToString());
                        record.Add("payment_collections_id", item[1].ToString());
                        record.Add("general_ledger_accounts_id", item[2].ToString());
                        record.Add("general_ledger_accounts_code", item[3].ToString());
                        record.Add("general_ledger_name", item[4].ToString());
                        record.Add("quantity", item[5].ToString());
                    }

                }

                return record;

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
