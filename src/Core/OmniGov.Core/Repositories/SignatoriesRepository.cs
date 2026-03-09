using OmniGov.Core.Entities;
using OmniGov.Core.Interfaces.Repositories;
using OmniGov.Core.Interfaces.Services;
using System.Data;
using System.Transactions;

namespace OmniGov.Core.Repositories
{
    public class SignatoriesRepository : ISignatories
    {
        private IGenericCommands _genericCommands;
        private readonly string tableName = "signatories";
        private readonly ISignatoriesHasReferences _signatoriesHasReferences;

        public SignatoriesRepository(IGenericCommands genericCommands, ISignatoriesHasReferences signatoriesHasReferences)
        {
            _genericCommands = genericCommands;
            _signatoriesHasReferences = signatoriesHasReferences;
        }

        public byte GetLastInsertedID()
        {
            string query = $"SELECT MAX(id) FROM {tableName}";
            return byte.Parse(_genericCommands.ExecuteScalar(query));
        }

        public bool Delete(List<SignatoriesModel> entityList)
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
                    _ = _genericCommands.ExecuteNonQuery(query, parameters);
                }

                scope.Complete();
                return true;
            }
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            var record = new Dictionary<string, string>();

            var parameters = new object[][]
            {
                    new object[] { "@id", DbType.Int32, Id},
            };

            string query = $"SELECT prefix, first_name, middle_initial, last_name, suffix, title FROM {tableName} WHERE id = @id";

            using (var reader = _genericCommands.ExecuteReader(query, parameters))
            {
                if (reader.Rows.Count < 1)
                    return record;

                record.Add("prefix", reader.Rows[0]["prefix"].ToString());
                record.Add("first_name", reader.Rows[0]["first_name"].ToString());
                record.Add("middle_initial", reader.Rows[0]["middle_initial"].ToString());
                record.Add("last_name", reader.Rows[0]["last_name"].ToString());
                record.Add("suffix", reader.Rows[0]["suffix"].ToString());
                record.Add("title", reader.Rows[0]["title"].ToString());
            }

            return record;
        }

        public DataTable GetRecords()
        {
            string query = $"SELECT id, prefix, first_name, middle_initial, last_name, suffix, title, created_at, updated_at FROM {tableName}";

            return _genericCommands.Fill(query, new DataTable());
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            throw new NotImplementedException();
        }

        public bool IdExist(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(SignatoriesModel entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(SignatoriesModel entity)
        {
            throw new NotImplementedException();
        }

        public bool Insert(SignatoriesModel signatoriesModel, List<SignatoriesHasReferencesModel> signatoriesHasReferencesModelList)
        {
            using (var scope = new TransactionScope())
            {
                var parameters = new object[][]
                 {
                    new object[] { "@prefix", DbType.String, signatoriesModel.Prefix},
                    new object[] { "@first_name", DbType.String, signatoriesModel.FirstName},
                    new object[] { "@middle_initial",DbType.String, signatoriesModel.MiddleInitial},
                    new object[] { "@last_name", DbType.String, signatoriesModel.LastName},
                    new object[] { "@suffix", DbType.String, signatoriesModel.Suffix},
                    new object[] { "@title", DbType.String, signatoriesModel.Title}
                 };

                string query = $"INSERT INTO {tableName} (prefix, first_name, middle_initial, last_name, suffix, title) VALUES (@prefix, @first_name, @middle_initial, @last_name, @suffix, @title)";

                _ = _genericCommands.ExecuteNonQuery(query, parameters);

                foreach (SignatoriesHasReferencesModel signatoriesHasReferencesModel in signatoriesHasReferencesModelList)
                {
                    signatoriesHasReferencesModel.SignatoriesId = GetLastInsertedID();
                    _signatoriesHasReferences.Insert(signatoriesHasReferencesModel);
                }

                scope.Complete();
                return true;
            }
        }

        public bool Update(SignatoriesModel signatoriesModel, List<SignatoriesHasReferencesModel> signatoriesHasReferencesModelList)
        {
            using (var scope = new TransactionScope())
            {
                var parameters = new object[][]
                {
                    new object[] { "@id", DbType.Int32, signatoriesModel.Id},
                    new object[] { "@prefix", DbType.String, signatoriesModel.Prefix},
                    new object[] { "@first_name", DbType.String, signatoriesModel.FirstName},
                    new object[] { "@middle_initial",DbType.String, signatoriesModel.MiddleInitial},
                    new object[] { "@last_name", DbType.String, signatoriesModel.LastName},
                    new object[] { "@suffix", DbType.String, signatoriesModel.Suffix},
                    new object[] { "@title", DbType.String, signatoriesModel.Title}
                };

                string query = $"UPDATE {tableName} SET prefix = @prefix, first_name = @first_name, middle_initial = @middle_initial, last_name = @last_name, suffix = @suffix, title = @title WHERE id = @id";

                _signatoriesHasReferences.DeleteBySignatoryId(signatoriesModel.Id);

                _ = _genericCommands.ExecuteNonQuery(query, parameters);

                foreach (SignatoriesHasReferencesModel signatoriesHasReferencesModel in signatoriesHasReferencesModelList)
                {
                    signatoriesHasReferencesModel.SignatoriesId = signatoriesModel.Id;
                    _signatoriesHasReferences.Insert(signatoriesHasReferencesModel);
                }

                scope.Complete();
                return true;
            }
        }
    }
}