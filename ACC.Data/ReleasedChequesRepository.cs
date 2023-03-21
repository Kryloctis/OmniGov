using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace AccountingSystem
{
    internal class ReleasedChequesRepository : IReleasedCheques
    {
        private readonly IAccGenericCommands _dbGenericCommands;
        private readonly string tableName = "released_cheques";
        private readonly string viewTableName = "view_released_cheques";

        public ReleasedChequesRepository(IAccGenericCommands dbGenericCommands)
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
            throw new System.NotImplementedException();
        }

        public Dictionary<string, string> GetRecordByID(int Id)
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

        public DataTable GetViewRecords()
        {
            string query = $"SELECT * FROM {viewTableName}";

            var dtRCI = new DataTable();
            return _dbGenericCommands.Fill(query, dtRCI);
        }

        public DataTable GetViewRecords(int bankAccountID, int fundsID, string searchText)
        {
            var parameters = new object[][]
            {
                new object[] { "@bank_accounts_id", DbType.Int32, bankAccountID },
                new object[] { "@funds_id", DbType.Int32, fundsID },
                new object[] { "@search_text", DbType.String, $"%{searchText}%" }
            };
            
            string query = $"SELECT * FROM {viewTableName} WHERE bank_accounts_id = @bank_accounts_id AND funds_id = @funds_id AND (cheque_no LIKE  @search_text OR payee LIKE @search_text)"; 

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
            throw new System.NotImplementedException();
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
            throw new System.NotImplementedException();
        }
    }
}