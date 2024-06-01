using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ACC.Data
{
    public class RptLevyRepository : IRptLevy
    {
        private AccGenericCommands mySqlGenericCommandsLFS;
        private readonly string tableName = "rpt_levy";
        private readonly string viewTableName = "view_rpt_levy";

        public RptLevyRepository(AccGenericCommands mySqlGenericCommandsLFS)
        {
            this.mySqlGenericCommandsLFS = mySqlGenericCommandsLFS;
        }

        public bool Delete(List<RptLevyModel> entityList)
        {
            using (var scope = new TransactionScope())
            {
                foreach (var entity in entityList)
                {
                    var parameters = new object[][] { new object[] { "@id", DbType.Int16, entity.Id }, };

                    string query = $"DELETE FROM {tableName} WHERE id = @id";
                    _ = mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
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
            return mySqlGenericCommandsLFS.Fill(query, new DataTable());
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, string> GetViewRecordById(int Id)
        {
            var recordDictionary = new Dictionary<string, string>();

            var parameters = new object[][] { new object[] { "@rpt_levy_id", DbType.Int32, Id } };
            string query = $"SELECT * FROM {viewTableName} WHERE rpt_levy_id = @rpt_levy_id";

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

        public DataTable GetViewRecordsBySearch(int rowLimit, string searchKey)
        {
            var parameters = new object[][]
            {
                new object[] { "@row_limit", DbType.Int32, rowLimit },
                new object[] { "@search_key", DbType.String, $"%{searchKey}%" },
            };

            string query = $"SELECT * FROM {viewTableName} WHERE (complete_arp_no LIKE @search_key OR taxpayers_name LIKE @search_key) ORDER BY taxpayers_name ASC LIMIT @row_limit";
            return mySqlGenericCommandsLFS.FillBySearch(query, new DataTable(), parameters);
        }

        public bool IdExist(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(RptLevyModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@real_properties_id", DbType.Int32, entity.RealPropertiesId },
                new object[] { "@date_issued", DbType.DateTime, entity.DateIssued },
                new object[] { "@created_by", DbType.Int32, entity.CreatedBy },
            };

            string query = $"INSERT INTO {tableName} (real_properties_id, date_issued, created_by) VALUES (@real_properties_id, @date_issued, @created_by)";
            return mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
        }

        public bool Update(RptLevyModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, entity.Id },
                new object[] { "@real_properties_id", DbType.Int32, entity.RealPropertiesId },
                new object[] { "@date_issued", DbType.DateTime, entity.DateIssued },
                new object[] { "@updated_by", DbType.Int32, entity.UpdatedBy },
            };

            string query = $"UPDATE {tableName} SET real_properties_id = @real_properties_id, date_issued = @date_issued, updated_by = @updated_by WHERE id = @id";
            return mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
        }

        public DataTable GetViewRecords(int rptId)
        {
            var parameters = new object[][]
            {
                new object[] { "@real_properties_id", DbType.Int32, rptId}
            };

            string query = $"SELECT * FROM {viewTableName} WHERE real_properties_id = @real_properties_id";
            return mySqlGenericCommandsLFS.FillBySearch(query, new DataTable(), parameters);
        }
    }
}