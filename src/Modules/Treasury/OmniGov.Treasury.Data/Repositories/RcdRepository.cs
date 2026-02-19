using OmniGov.Core.Entities;
using OmniGov.Core.Interfaces.Services;
using System.Data;
using System.Transactions;
using Treasury.Domain.Entities;
using Treasury.Domain.Interfaces;

namespace Treasury.Data.Repositories
{
    public class RcdRepository : IRcdRepository
    {
        private readonly string tableName = "rcd";
        private readonly string viewTableName = "view_rcd";
        private readonly IGenericCommands _genericCommands;
        private readonly IRcdCollections _rcdCollections;
        private readonly IRcdDeposits _rcdDeposits;

        public RcdRepository(IGenericCommands genericCommands, IRcdCollections rcdCollections, IRcdDeposits rcdDeposits)

        {
            _genericCommands = genericCommands ?? throw new ArgumentNullException(nameof(genericCommands));
            _rcdCollections = rcdCollections ?? throw new ArgumentNullException(nameof(rcdCollections));
            _rcdDeposits = rcdDeposits ?? throw new ArgumentNullException(nameof(rcdDeposits));
        }

        public bool Delete(List<RcdModel> entityList)
        {
            using (var scope = new TransactionScope())
            {
                foreach (var entity in entityList)
                {
                    var parameters = new object[][] { new object[] { "@id", DbType.Int32, entity.Id } };
                    string query = $"DELETE FROM {tableName} WHERE id = @id";
                    _ = _rcdCollections.DeleteByRcdId(entity);
                    _ = _rcdDeposits.DeleteByRcdId(entity);
                    _ = _genericCommands.ExecuteNonQuery(query, parameters);
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

            DataTable dataTable = _genericCommands.ExecuteReader(query, parameters);

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
            return _genericCommands.Fill(query, new DataTable());
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            var parameters = new object[][] { new object[] { "@search_key", DbType.String, $"%{searchText}%" } };
            string query = $"SELECT * FROM {tableName} WHERE report_no LIKE @search_key";
            return _genericCommands.FillBySearch(query, new DataTable(), parameters);
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
            return _genericCommands.FillBySearch(query, new DataTable(), parameters);
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
            return _genericCommands.ExecuteNonQuery(query, parameters);
        }

        public bool reportNoExist(string reportNo)
        {
            var parameters = new object[][] { new object[] { "@report_no", DbType.String, reportNo } };
            string query = $"SELECT id FROM {tableName} WHERE report_no = @report_no";
            string result = _genericCommands.ExecuteScalar(query, parameters);
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
            string result = _genericCommands.ExecuteScalar(query, parameters);
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
            return _genericCommands.ExecuteNonQuery(query, parameters);
        }

        public bool InsertWithCollectionsDeposits(RcdModel rcdModel, List<RcdCollectionsModel> _rcdCollectionsModels, List<RcdDepositsModel> _rcdDepositsModels)
        {
            using (var scope = new TransactionScope())
            {
                _ = Insert(rcdModel);

                int lastInsertedId = GetLastInsertedId(rcdModel.CreatedBy);
                foreach (RcdCollectionsModel _rcdCollectionsModel in _rcdCollectionsModels)
                {
                    _rcdCollectionsModel.RcdModel = new RcdModel() { Id = lastInsertedId };
                    _ = _rcdCollections.Insert(_rcdCollectionsModel);
                }

                foreach (RcdDepositsModel _rcdDepositsModel in _rcdDepositsModels)
                {
                    _rcdDepositsModel.RcdModel = new RcdModel() { Id = lastInsertedId };
                    _ = _rcdDeposits.Insert(_rcdDepositsModel);
                }

                scope.Complete();
                return true;
            }
        }

        public bool UpdateWithCollectionsDeposits(RcdModel rcdModel, List<RcdCollectionsModel> _rcdCollectionsModels, List<RcdDepositsModel> _rcdDepositsModels)
        {
            using (var scope = new TransactionScope())
            {
                _ = Update(rcdModel);
                _ = _rcdCollections.DeleteByRcdId(rcdModel);
                _ = _rcdDeposits.DeleteByRcdId(rcdModel);

                foreach (RcdCollectionsModel _rcdCollectionsModel in _rcdCollectionsModels)
                {
                    _rcdCollectionsModel.RcdModel = new RcdModel() { Id = rcdModel.Id };
                    _ = _rcdCollections.Insert(_rcdCollectionsModel);
                }

                foreach (RcdDepositsModel _rcdDepositsModel in _rcdDepositsModels)
                {
                    _rcdDepositsModel.RcdModel = new RcdModel() { Id = rcdModel.Id };
                    _ = _rcdDeposits.Insert(_rcdDepositsModel);
                }

                scope.Complete();
                return true;
            }
        }

        public Dictionary<string, string> GetViewRecord(int id)
        {
            var recordDictionary = new Dictionary<string, string>();
            var parameters = new object[][] { new object[] { "@id", DbType.Int32, id } };
            string query = $"SELECT * FROM {viewTableName} WHERE id = @id";
            DataTable dataTable = _genericCommands.ExecuteReader(query, parameters);

            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];

                foreach (DataColumn column in dataTable.Columns)
                    recordDictionary[column.ColumnName] = row[column].ToString();

                return recordDictionary;
            }
            return recordDictionary;
        }

        public int GetLastInsertedId(UsersModel usersModel)
        {
            var parameters = new object[][] { new object[] { "@created_by", DbType.Int32, usersModel.Id } };
            string query = $"SELECT MAX(id) FROM {tableName} WHERE created_by = @created_by";
            return Convert.ToInt32(_genericCommands.ExecuteScalar(query, parameters));
        }
    }
}