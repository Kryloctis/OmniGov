using OmniGov.Core.Repositories;
using OmniGov.Core.Services;
using System.Data;
using Treasury.Domain.Entities;
using Treasury.Domain.Interfaces;

namespace Treasury.Data.Repositories
{
    internal class ReleasedChequesRepository : IReleasedCheques
    {
        private readonly GenericCommands _dbGenericCommands;
        private readonly string tableName = "released_cheques";
        private readonly string viewTableName = "view_released_cheques";

        public ReleasedChequesRepository(GenericCommands dbGenericCommands)
        {
            _dbGenericCommands = dbGenericCommands;
        }

        public int CountRecords()
        {
            try
            {
                string query = $"SELECT COUNT(*) FROM {tableName}";

                return int.Parse(_dbGenericCommands.ExecuteScalar(query));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Delete(List<ReleasedChequesModel> entityList)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            throw new NotImplementedException();
        }

        public DataTable GetRecords()
        {
            throw new NotImplementedException();
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            throw new NotImplementedException();
        }

        public DataTable GetViewRecords()
        {
            string query = $"SELECT * FROM {viewTableName}";

            var dtRCI = new DataTable();
            return _dbGenericCommands.Fill(query, dtRCI);
        }

        public DataTable GetViewRecords(int bankAccountID, int fundsID, string searchText, bool showReleasedOnly)
        {
            var parameters = new object[][]
            {
                new object[] { "@bank_accounts_id", DbType.Int32, bankAccountID },
                new object[] { "@funds_id", DbType.Int32, fundsID },
                new object[] { "@search_text", DbType.String, $"%{searchText}%" }
            };

            string showReleasedOnlyQuery = showReleasedOnly == true ? $"AND date_released IS NOT NULL" : $"";

            string query = $"SELECT * FROM {viewTableName} WHERE bank_accounts_id = @bank_accounts_id AND funds_id = @funds_id AND (cheque_no LIKE  @search_text OR payee LIKE @search_text) {showReleasedOnlyQuery}";

            var dtRCI = new DataTable();
            return _dbGenericCommands.FillBySearch(query, dtRCI, parameters);
        }

        public DataTable GetViewRecordsByBankAccountID(int bankAccountIDID)
        {
            var parameters = new object[][]
            {
                new object[] { "@bank_accouns_id", DbType.Int32, bankAccountIDID}
            };

            string query = $"SELECT * FROM {viewTableName} WHERE bank_accounts_id = @bank_accouns_id";
            return _dbGenericCommands.ExecuteReader(query, parameters);
        }

        public DataTable GetViewRecordsByBankAccountIDAndPeriodCoveredReleased(int bankAccountID, string periodCovered)
        {
            var parameters = new object[][]
            {
                new object[] { "@bank_accouns_id", DbType.Int32, bankAccountID},
                new object[] { "@date_released", DbType.DateTime, Convert.ToDateTime(periodCovered)}
            };

            string query = $"SELECT * FROM {viewTableName} WHERE bank_accounts_id = @bank_accouns_id AND date_released <= @date_released";
            return _dbGenericCommands.ExecuteReader(query, parameters);
        }

        public DataTable GetViewRecordsByBankAccountIDAndPeriodCoveredUnReleased(int bankAccountID, string periodCovered)
        {
            var parameters = new object[][]
            {
                new object[] { "@bank_accouns_id", DbType.Int32, bankAccountID},
                new object[] { "@cheque_date", DbType.DateTime, Convert.ToDateTime(periodCovered)}
            };

            string query = $"SELECT * FROM {viewTableName} WHERE bank_accounts_id = @bank_accouns_id AND date_released IS NULL AND cheque_date <= @cheque_date";
            return _dbGenericCommands.ExecuteReader(query, parameters);
        }

        public bool IdExist(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(ReleasedChequesModel entity)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@rci_id", DbType.Int32, entity.RCIID },
                    new object[] { "@date_released", DbType.String, entity.DateReleased.ToString("yyyy-MM-dd") },
                };

                string query = $"INSERT INTO {tableName} (rci_id, date_released) VALUES (@rci_id, @date_released)";
                return _dbGenericCommands.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool ReleasedCheque(int chequedID)
        {
            var parameters = new object[][]
            {
                new object[] { "@cheques_id", DbType.Int32, chequedID},
            };

            string query = $"UPDATE {tableName} SET released_cheques_id ";

            return _dbGenericCommands.ExecuteNonQuery(query, parameters);
        }

        public bool Update(ReleasedChequesModel entity)
        {
            throw new NotImplementedException();
        }
    }
}

