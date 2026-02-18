using OmniGov.Core.Entities;
using OmniGov.Core.Interfaces.Repositories;
using OmniGov.Core.Interfaces.Services;
using System.Data;

namespace OmniGov.Core.Repositories
{
    public class PermissionsRepository : IPermissionsRepository
    {
        private readonly string tableName = "permissions";
        private IGenericCommands mySqlGenericCommands;

        public PermissionsRepository(IGenericCommands mySqlGenericCommands)
        {
            this.mySqlGenericCommands = mySqlGenericCommands;
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            var recordDictionary = new Dictionary<string, string>();

            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, Id},
            };

            string query = $"SELECT permission_name FROM {tableName} WHERE id = @id";

            DataTable dataTable = mySqlGenericCommands.ExecuteReader(query, parameters);

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
            string query = $"SELECT * FROM {tableName} ORDER BY permission_name";
            return mySqlGenericCommands.Fill(query, new DataTable());
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            var parameters = new object[][]
            {
                new object[] { "@search_txt", DbType.String, $"%{searchText}%"},
            };

            string query = $"SELECT * FROM {tableName} WHERE permission_name  LIKE @search_txt";
            return mySqlGenericCommands.Fill(query, new DataTable());
        }

        public bool Insert(PermissionsModel entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(PermissionsModel entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(List<PermissionsModel> entityList)
        {
            throw new NotImplementedException();
        }

        public bool IdExist(int id)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, id },
            };

            string query = $"SELECT id FROM {tableName} WHERE id = @id";
            string queryResult = mySqlGenericCommands.ExecuteScalar(query, parameters);

            return !string.IsNullOrEmpty(queryResult);
        }
    }
}
