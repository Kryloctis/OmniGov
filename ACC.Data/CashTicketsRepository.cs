using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;

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
            throw new System.NotImplementedException();
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            throw new System.NotImplementedException();
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            throw new System.NotImplementedException();
        }

        public bool Insert(CashTicketsModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@accountable_forms_id", DbType.Int32, entity.AccountableFormId},
                new object[] { "@quantity", DbType.Int32, entity.Quantity},
                new object[] { "@received_date", DbType.Date, entity.ReceivedDate},
                new object[] { "@remarks", DbType.String, entity.Remarks},
            };

            string query = $"INSERT INTO {tableName} (accountable_forms_id, quantity,  received_date, remarks) VALUES(@accountable_forms_id, @quantity,  @received_date, @remarks)";

            return mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
        }

        public bool Update(CashTicketsModel entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(List<CashTicketsModel> entityList)
        {
            throw new System.NotImplementedException();
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