using OmniGov.Core.Repositories;
using System.Data;
using System.Transactions;
using Treasury.Domain.Entities;
using Treasury.Domain.Interfaces;

namespace Treasury.Data.Repositories
{
    internal class CashTicketsIssuedRepository : ICashTicketsIssuedRepository
    {
        private readonly string tableName = "cash_tickets_issued";
        private readonly string viewTableName = "view_cash_tickets_issued";
        private GenericCommands mySqlGenericCommandsLFS;

        public CashTicketsIssuedRepository(GenericCommands mySqlGenericCommandsLFS)
        {
            this.mySqlGenericCommandsLFS = mySqlGenericCommandsLFS;
        }

        public bool Delete(List<CashTicketsIssuedModel> entityList)
        {
            using (var scope = new TransactionScope())
            {
                foreach (var entity in entityList)
                {
                    var parameters = new object[][]
                    {
                        new object[] { "@id", DbType.Int32, entity.Id},
                    };

                    string query = $"DELETE FROM {tableName} WHERE id = @id";
                    _ = mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
                }

                scope.Complete();
                return true;
            }
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            var recordDictionary = new Dictionary<string, string>();

            var parameters = new object[][] { new object[] { "@id", DbType.Int32, Id } };
            string query = $"SELECT * FROM {viewTableName} WHERE id = @id";

            DataTable dataTable = mySqlGenericCommandsLFS.ExecuteReader(query, parameters);

            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];

                foreach (DataColumn column in dataTable.Columns)
                    recordDictionary[column.ColumnName] = row[column].ToString();

                return recordDictionary;
            }
            return recordDictionary;
        }

        public DataTable GetRecords()
        {
            throw new NotImplementedException();
        }

        public DataTable GetViewRecordsBySearch(DateTime dateIssued, string searchKey, int rowLimit)
        {
            var parameter = new object[][]
                {
                new object[]{"@date_issued", DbType.Date, dateIssued.Date},
                new object[]{"@txt_search", DbType.String, $"%{searchKey}%"},
                new object[]{"@row_limit", DbType.Int32, rowLimit},
                };

            string query = $"SELECT * FROM {viewTableName} WHERE DATE(date_issued) <= @date_issued AND (cash_tickets_desc LIKE @txt_search) LIMIT @row_limit";
            return mySqlGenericCommandsLFS.FillBySearch(query, new DataTable(), parameter);
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            throw new NotImplementedException();
        }

        public int GetIssuedCountByCashTcktId(int cashTicketId)
        {
            var parameter = new object[][]
            {
                new object[]{ "@cash_tickets_id", DbType.Int32, cashTicketId }
            };

            string query = $"SELECT COALESCE(SUM(quantity), 0) AS total_issued FROM {tableName} WHERE cash_tickets_id = @cash_tickets_id";
            return Convert.ToInt32(mySqlGenericCommandsLFS.ExecuteScalar(query, parameter));
        }

        public bool IdExist(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(CashTicketsIssuedModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@cash_tickets_id", DbType.Int32, entity.CashTicketId},
                new object[] { "@collecting_officers_id", DbType.Int32, entity.CollectorId},
                new object[] { "@job_orders_id", DbType.Int32, entity.JobOrderId},
                new object[] { "@date_issued", DbType.Date, entity.DateIssued},
                new object[] { "@quantity", DbType.Int32, entity.Quantity},
                new object[] { "@issued_by", DbType.Int32, entity.IssuedBy}
            };

            string query = $"INSERT INTO {tableName} (cash_tickets_id, collecting_officers_id, job_orders_id,  date_issued, quantity, issued_by) VALUES( @cash_tickets_id, @collecting_officers_id, @job_orders_id, @date_issued, @quantity, @issued_by)";

            return mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
        }

        public bool Update(CashTicketsIssuedModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, entity.Id},
                new object[] { "@cash_tickets_id", DbType.Int32, entity.CashTicketId},
                new object[] { "@collecting_officers_id", DbType.Int32, entity.CollectorId},
                new object[] { "@date_issued", DbType.Date, entity.DateIssued},
                new object[] { "@quantity", DbType.String, entity.Quantity},
            };

            string query = $"UPDATE {tableName} SET  cash_tickets_id = @cash_tickets_id, collecting_officers_id = @collecting_officers_id, date_issued = @date_issued, quantity = @quantity WHERE id = @id;";
            return mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
        }
    }
}