using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Transactions;

namespace ACC.Data
{
    public class RcdRepository : IRcd
    {
        private readonly string tableName = "rcd";
        private readonly string viewTableName = "view_rcd";
        private AccGenericCommands mySqlGenericCommandsLFS;
        private IRcdCollections rcdCollections;
        private IRcdDeposits rcdDeposits;

        public RcdRepository(AccGenericCommands mySqlGenericCommandsLFS, IRcdCollections rcdCollections, IRcdDeposits rcdDeposits)

        {
            this.mySqlGenericCommandsLFS = mySqlGenericCommandsLFS;
            this.rcdCollections = rcdCollections;
            this.rcdDeposits = rcdDeposits;
        }

        public int CountRecords()
        {
            throw new NotImplementedException();
        }

        public bool Delete(List<RcdModel> entityList)
        {
            using (var scope = new TransactionScope())
            {
                foreach (var entity in entityList)
                {
                    var parameters = new object[][] { new object[] { "@id", DbType.Int32, entity.Id } };
                    string query = $"DELETE FROM {tableName} WHERE id = @id";
                    _ = mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
                    _ = rcdCollections.DeleteByRcdId(entity);
                    _ = rcdDeposits.DeleteByRcdId(entity);
                }

                scope.Complete();
                return true;
            }
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

        public DataTable GetRecords()
        {
            string query = $"SELECT * FROM {tableName}";
            return mySqlGenericCommandsLFS.Fill(query, new DataTable());
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            var parameters = new object[][] { new object[] { "@search_key", DbType.String, $"%{searchText}%" } };
            string query = $"SELECT * FROM {tableName} WHERE report_no LIKE @search_key";
            return mySqlGenericCommandsLFS.FillBySearch(query, new DataTable(), parameters);
        }

        public DataTable GetViewRecords(string searchKey, DateTime date, int rowFilter)
        {
            var parameters = new object[][]
            {
                new object[] { "@search_key", DbType.String, $"%{searchKey}%"},
                new object[] { "@date", DbType.DateTime, date},
                new object[] { "@row_filter", DbType.Int32, rowFilter},
            };

            string query = $"SELECT * FROM {viewTableName} WHERE (report_no LIKE @search_key OR first_name LIKE @search_key OR last_name LIKE @search_key) AND (DATE(date) <= @date) LIMIT @row_filter";
            return mySqlGenericCommandsLFS.FillBySearch(query, new DataTable(), parameters);
        }

        public bool IdExist(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(RcdModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@funds_id", DbType.Object, entity.FundsModel == null? null : entity.FundsModel.Id},
                new object[] { "@report_no", DbType.String, entity.ReportNo},
                new object[] { "@date", DbType.DateTime, entity.Date},
                new object[] { "@created_by", DbType.Int32, entity.CreatedBy.Id}
            };

            string query = $"INSERT INTO {tableName} (funds_id, report_no, date, created_by) VALUES (@funds_id, @report_no, @date, @created_by)";
            return mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
        }

        public bool reportNoExist(string reportNo)
        {
            var parameters = new object[][] { new object[] { "@report_no", DbType.String, reportNo } };
            string query = $"SELECT id FROM {tableName} WHERE report_no = @report_no";
            string result = mySqlGenericCommandsLFS.ExecuteScalar(query, parameters);
            return !string.IsNullOrWhiteSpace(result);
        }

        public bool reportNoExist(string reportNo, int id)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, id},
                new object[] { "@report_no", DbType.String, reportNo }
            };

            string query = $"SELECT id FROM {tableName} WHERE report_no = @report_no AND id <> @id";
            string result = mySqlGenericCommandsLFS.ExecuteScalar(query, parameters);
            return !string.IsNullOrWhiteSpace(result);
        }

        public bool Update(RcdModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, entity.Id},
                new object[] { "@funds_id", DbType.Object, entity.FundsModel == null? null : entity.FundsModel.Id},
                new object[] { "@report_no", DbType.String, entity.ReportNo},
                new object[] { "@date", DbType.DateTime, entity.Date},
            };

            string query = $"UPDATE {tableName} SET  report_no = @report_no, funds_id = @funds_id, date = @date WHERE id = @id;";
            return mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
        }

        public bool InsertWithCollectionsDeposits(RcdModel rcdModel, List<RcdCollectionsModel> rcdCollectionsModels, List<RcdDepositsModel> rcdDepositsModels)
        {
            using (var scope = new TransactionScope())
            {
                _ = Insert(rcdModel);

                foreach (RcdCollectionsModel rcdCollectionsModel in rcdCollectionsModels)
                    _ = rcdCollections.Insert(rcdCollectionsModel);

                foreach (RcdDepositsModel rcdDepositsModel in rcdDepositsModels)
                    _ = rcdDeposits.Insert(rcdDepositsModel);

                scope.Complete();
                return true;
            }
        }

        public bool UpdateWithCollectionsDeposits(RcdModel rcdModel, List<RcdCollectionsModel> rcdCollectionsModels, List<RcdDepositsModel> rcdDepositsModels)
        {
            using (var scope = new TransactionScope())
            {
                _ = Update(rcdModel);
                _ = rcdCollections.DeleteByRcdId(rcdModel);
                _ = rcdDeposits.DeleteByRcdId(rcdModel);

                foreach (RcdCollectionsModel rcdCollectionsModel in rcdCollectionsModels)
                    _ = rcdCollections.Insert(rcdCollectionsModel);

                foreach (RcdDepositsModel rcdDepositsModel in rcdDepositsModels)
                    _ = rcdDeposits.Insert(rcdDepositsModel);

                scope.Complete();
                return true;
            }
        }

        public Dictionary<string, string> GetViewRecord(int id)
        {
            var recordDictionary = new Dictionary<string, string>();
            var parameters = new object[][] { new object[] { "@id", DbType.Int32, id } };
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
    }
}