using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ACC.Data
{
    public class GeneralPaymentsRepository : IGeneralPaymentsRepository
    {
        private MySqlGenericCommands mySqlGenericCommandsLFS;
        private string tableName = "general_payments";
        private string viewTableName = "view_general_payments";

        public GeneralPaymentsRepository(MySqlGenericCommands mySqlGenericCommandsLFS)
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
            throw new NotImplementedException();
        }
    }
}
