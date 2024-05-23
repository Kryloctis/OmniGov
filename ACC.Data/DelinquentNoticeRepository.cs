using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using Org.BouncyCastle.Asn1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ACC.Data
{
    public class DelinquentNoticeRepository : IDelinquentNotice
    {
        private readonly string tableName = "delinquent_notice";
        private readonly string viewTableName = "view_delinquent_notice";

        private AccGenericCommands mySqlGenericCommandsLFS;

        public DelinquentNoticeRepository(AccGenericCommands mySqlGenericCommandsLFS)
        {
            this.mySqlGenericCommandsLFS = mySqlGenericCommandsLFS;
        }

        public bool Delete(List<DelinquentNoticeModel> entityList)
        {
            using (var scope = new TransactionScope())
            {
                foreach (var entity in entityList)
                {
                    var parameters = new object[][] { new object[] { "@id", DbType.Int32, entity.Id } };
                    string query = $"DELETE FROM {tableName} WHERE id = @id";
                    _ = mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
                }

                scope.Complete();
                return true;
            }
        }

        public Dictionary<string, string> GetViewRecordById(int Id)
        {
            var recordDictionary = new Dictionary<string, string>();

            var parameters = new object[][] { new object[] { "@delinquent_notice_id", DbType.Int32, Id } };
            string query = $"SELECT * FROM {viewTableName} WHERE delinquent_notice_id = @delinquent_notice_id";

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
            var parameters = new object[][]
            {
                new object[] { "@search_text", DbType.String, $"%{searchText}%"}
            };

            string query = $"SELECT * FROM {tableName} WHERE notice_type LIKE @search_text";
            return mySqlGenericCommandsLFS.FillBySearch(query, new DataTable(), parameters);
        }

        public DataTable GetViewRecordsBySearch(int rowLimit, string searchKey)
        {
            var parameters = new object[][]
            {
                new object[] { "@row_limit", DbType.Int32, rowLimit},
                new object[] { "@search_key", DbType.String, $"%{searchKey}%"},
            };

            string query = $"SELECT * FROM {viewTableName} WHERE (taxpayers_name LIKE @search_key OR complete_arp_no LIKE @search_key) ORDER BY taxpayers_name ASC LIMIT @row_limit ";
            return mySqlGenericCommandsLFS.FillBySearch(query, new DataTable(), parameters);
        }

        public bool IdExist(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(DelinquentNoticeModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@real_properties_id", DbType.Int32, entity.RealPropertiesId},
                new object[] { "@notice_type", DbType.String, entity.NoticeType},
                new object[] { "@notice_date", DbType.DateTime, entity.NoticeDate},
                new object[] { "@created_by", DbType.Int32, entity.CreatedBy},
            };

            string query = $"INSERT INTO {tableName} (real_properties_id, notice_type, notice_date, created_by) VALUES (@real_properties_id, @notice_type, @notice_date, @created_by)";
            return mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
        }

        public bool Update(DelinquentNoticeModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, entity.Id },
                new object[] { "@real_properties_id", DbType.Int32, entity.RealPropertiesId },
                new object[] { "@notice_type", DbType.String, entity.NoticeType },
                new object[] { "@notice_date", DbType.DateTime, entity.NoticeDate },
                new object[] { "@updated_by", DbType.Int32, entity.UpdatedBy},
            };

            string query = $"UPDATE {tableName} SET  real_properties_id = @real_properties_id, notice_type = @notice_type, notice_date = @notice_date, updated_by = @updated_by WHERE id = @id;";
            return mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
        }
    }
}