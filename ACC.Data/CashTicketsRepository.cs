using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Transactions;

namespace ACC.Data
{
    internal class CashTicketsRepository : ICashTicketsRepository
    {
        private readonly string tableName = "cash_tickets";
        private readonly string viewTableName = "view_cash_tickets";
        private AccGenericCommands mySqlGenericCommandsLFS;

        public CashTicketsRepository(AccGenericCommands mySqlGenericCommandsLFS)
        {
            this.mySqlGenericCommandsLFS = mySqlGenericCommandsLFS;
        }

        public bool IdExist(int id)
        {
            throw new System.NotImplementedException();
        }

        public DataTable GetRecords()
        {
            string query = $"SELECT * FROM {viewTableName}";
            return mySqlGenericCommandsLFS.Fill(query, new DataTable());
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            throw new System.NotImplementedException();
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            var recordDictionary = new Dictionary<string, string>();

            var parameters = new object[][] { new object[] { "@id", DbType.Int32, Id } };
            string query = $"SELECT * FROM {tableName} WHERE id = @id";

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

        public bool Insert(CashTicketsModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@description", DbType.String, entity.Description},
                new object[] { "@quantity", DbType.Int32, entity.Quantity},
                new object[] { "@received_date", DbType.Date, entity.ReceivedDate},
                new object[] { "@remarks", DbType.String, entity.Remarks},
            };

            string query = $"INSERT INTO {tableName} (description, quantity,  received_date, remarks) VALUES(@description, @quantity,  @received_date, @remarks)";

            return mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
        }

        public bool Update(CashTicketsModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, entity.Id},
                new object[] { "@description", DbType.Int32, entity.Description},
                new object[] { "@quantity", DbType.Int32, entity.Quantity},
                new object[] { "@received_date", DbType.Date, entity.ReceivedDate},
                new object[] { "@remarks", DbType.String, entity.Remarks},
            };

            string query = $"UPDATE {tableName} SET  description = @description, quantity = @quantity, received_date = @received_date, remarks = @remarks WHERE id = @id;";
            return mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
        }

        public bool Delete(List<CashTicketsModel> entityList)
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

        public DataTable GetRecordsByDateAndText(DateTime dateReceived, string txtSearch, int rowLimit)
        {
            var parameter = new object[][]
            {
                new object[]{"@received_date", DbType.Date, dateReceived.Date},
                new object[]{"@txt_search", DbType.String, $"%{txtSearch}%"},
                new object[]{"@row_limit", DbType.Int32, rowLimit},
            };

            string query = $"SELECT * FROM {viewTableName} WHERE DATE(received_date) <= @received_date AND (acc_form_desc LIKE @txt_search OR acc_form_no LIKE @txt_search) LIMIT @row_limit";

            return mySqlGenericCommandsLFS.FillBySearch(query, new DataTable(), parameter);
        }
    }
}