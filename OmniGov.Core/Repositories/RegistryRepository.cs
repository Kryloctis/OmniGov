using OmniGov.Core.Entities;
using OmniGov.Core.Interfaces.Repositories;
using OmniGov.Core.Interfaces.Services;
using System.Data;
using System.Transactions;

using OmniGov.Core.Services;

namespace OmniGov.Core.Repositories
{
    public class RegistryRepository : IRegistry
    {
        private readonly string tableName = "registry";
        private IGenericCommands mySqlGenericCommands;

        public RegistryRepository(IGenericCommands mySqlGenericCommands)
        {
            this.mySqlGenericCommands = mySqlGenericCommands;
        }

        public bool Delete(List<RegistryModel> entityList)
        {
            using (var scope = new TransactionScope())
            {
                foreach (var entity in entityList)
                {
                    var parameters = new object[][] { new object[] { "@id", DbType.Int16, entity.Id }, };

                    string query = $"DELETE FROM {tableName} WHERE id = @id";
                    _ = mySqlGenericCommands.ExecuteNonQuery(query, parameters);
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
            string query = $"SELECT * FROM {tableName}";
            var dataTable = new DataTable();
            return mySqlGenericCommands.Fill(query, dataTable);
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            var parameters = new object[][]
            {
                new object[] {"@search_key", DbType.String, $"%{searchText}%"}
            };

            string query = $"SELECT * FROM {tableName} WHERE first_name LIKE @search_key OR last_name LIKE @search_key";
            var dataTable = new DataTable();
            return mySqlGenericCommands.FillBySearch(query, dataTable, parameters);
        }

        public DataTable GetRecordsBySearh_Limit(string searchKey, int limitCount)
        {
            var parameters = new object[][]
            {
                new object[] {"@search_key", DbType.String, $"%{searchKey}%"},
                new object[] {"@limit_count", DbType.Int32, limitCount}
            };

            string query = $"SELECT * FROM {tableName} WHERE first_name LIKE @search_key OR last_name LIKE @search_key LIMIT @limit_count";
            var dataTable = new DataTable();
            return mySqlGenericCommands.FillBySearch(query, dataTable, parameters);
        }

        public bool IdExist(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(RegistryModel entity)
        {
            var parameters = new object[][]
            {
                new object[] {"@first_name", DbType.String, entity.FirstName},
                new object[] {"@middle_name", DbType.String, entity.MiddleName},
                new object[] {"@last_name", DbType.String, entity.LastName},
                new object[] {"@sex", DbType.String, entity.Sex},
                new object[] {"@nationality", DbType.String, entity.Nationality},
                new object[] {"@birth_date", DbType.Date, entity.BirthDate},
                new object[] {"@municipality", DbType.String, entity.Municipality},
                new object[] {"@province", DbType.String, entity.Province},
                new object[] {"@country", DbType.String, entity.Country},
                new object[] {"@contact_info", DbType.String, entity.ContactInfo},
                new object[] {"@created_by", DbType.Int32, entity.CreatedBy},
            };

            string query = $"INSERT INTO {tableName} (first_name, middle_name, last_name, sex, nationality, birth_date, municipality, province, country, contact_info, created_by) VALUES (@first_name, @middle_name, @last_name, @sex, @nationality, @birth_date, @municipality, @province, @country, @contact_info, @created_by)";

            return mySqlGenericCommands.ExecuteNonQuery(query, parameters);
        }

        public bool Update(RegistryModel entity)
        {
            var parameters = new object[][]
            {
                new object[] {"@id", DbType.Int32, entity.Id},
                new object[] {"@first_name", DbType.String, entity.FirstName},
                new object[] {"@middle_name", DbType.String, entity.MiddleName},
                new object[] {"@last_name", DbType.String, entity.LastName},
                new object[] {"@sex", DbType.String, entity.Sex},
                new object[] {"@nationality", DbType.String, entity.Nationality},
                new object[] {"@birth_date", DbType.Date, entity.BirthDate},
                new object[] {"@municipality", DbType.String, entity.Municipality},
                new object[] {"@province", DbType.String, entity.Province},
                new object[] {"@country", DbType.String, entity.Country},
                new object[] {"@contact_info", DbType.String, entity.ContactInfo},
                new object[] {"@created_by", DbType.Int32, entity.CreatedBy},
                new object[] {"@updated_by", DbType.Int32, entity.UpdatedBy},
            };

            string query = $"UPDATE {tableName} SET first_name = @first_name, middle_name = @middle_name, last_name = @last_name, sex = @sex, nationality = @nationality, birth_date = @birth_date, municipality = @municipality, province = @province, country = @country, contact_info = @contact_info, updated_by = @updated_by WHERE id = @id";

            return mySqlGenericCommands.ExecuteNonQuery(query, parameters);
        }
    }
}
