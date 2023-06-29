using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Http.Headers;
using System.Text;
using System.Transactions;

namespace ACC.Data
{
    public class PreferencesRepository : IPreferences
    {
        private readonly string tableName = "Preferences";
        private AccGenericCommands mySqlGenericCommandsLFS;

        public PreferencesRepository(AccGenericCommands mySqlGenericCommandsLFS)
        {
            this.mySqlGenericCommandsLFS = mySqlGenericCommandsLFS;
        }

        public int CountRecords()
        {
            throw new NotImplementedException();
        }

        public bool Delete(List<PreferencesModel> entityList)
        {
            using (var scope = new TransactionScope())
            {
                foreach (var item in entityList)
                {
                    var parameters = new object[][]
                    {
                        new object[] { "@id", DbType.Int32, item.Id }
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
            throw new NotImplementedException();
        }

        public Dictionary<string, dynamic> GetDynamicRecordByID(int id)
        {
            var dictionary = new Dictionary<string, dynamic>();

            var parameters = new object[][] { new object[] { "@id", DbType.Int32, id } };
            string query = $"SELECT municipality, province, emblem FROM {tableName} WHERE id = @id";

            using (var reader = mySqlGenericCommandsLFS.ExecuteReader(query, parameters))
            {
                if (reader.Rows.Count < 1)
                    return dictionary;

                foreach (DataRow row in reader.Rows)
                {
                    dictionary.Add("municipality", row["municipality"].ToString());
                    dictionary.Add("province", row["province"].ToString());
                    dictionary.Add("emblem", row["emblem"]);
                }
                return dictionary;
            };
        }

        public DataTable GetRecords()
        {
            throw new NotImplementedException();
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            throw new NotImplementedException();
        }

        public bool IdExist(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(PreferencesModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@municipality", DbType.String, entity.Municipality},
                new object[] { "@province", DbType.String, entity.Province},
                new object[] { "@emblem", DbType.Object, entity.Emblem}
            };

            TruncateRecords();
            string query = $"INSERT INTO {tableName} (municipality, province, emblem) VALUES (@municipality, @province, @emblem)";
            return mySqlGenericCommandsLFS.ExecuteNonQuery(query, parameters);
        }

        public bool TruncateRecords()
        {
            string query = $"TRUNCATE {tableName}";
            return mySqlGenericCommandsLFS.ExecuteNonQuery(query);
        }

        public bool Update(PreferencesModel entity)
        {
            throw new NotImplementedException();
        }
    }
}