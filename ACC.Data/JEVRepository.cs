using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Transactions;
using ACC.Domain.Interfaces;
using ACC.Domain.Models;

namespace ACC.Data
{
    public class JEVRepository : IJEVRepository
    {
        private readonly IDbGenericCommands _dbGenericCommands;
        private readonly IJEVAccountsRepository _jevAccountsRepository;
        private const string tableName = "jev";
        private const string viewTableName = "view_jev";

        public JEVRepository(IDbGenericCommands dbGenericCommands, IJEVAccountsRepository jevAccountsRepository)
        {
            _dbGenericCommands = dbGenericCommands;
            _jevAccountsRepository = jevAccountsRepository;
        }

        public int CountRecords()
        {
            throw new NotImplementedException();
        }

        public bool Delete(List<JEVModel> entityList)
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

        public bool IdExist(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(JEVModel entity, List<JEVAccountsModel> jevAccountsModelList)
        {
            try
            {
                using (var scope = new TransactionScope())
                {
                    var parameters = new object[][]
                    {
                        new object[] { "@funds_id", DbType.Byte, entity.FundsId },
                        new object[] { "@journals_id", DbType.Byte, entity.JournalsId },
                        new object[] { "@jev_no", DbType.String, entity.JEVNumber },
                        new object[] { "@date_entry", DbType.Date, entity.DateEntry },
                        new object[] { "@explanation", DbType.String, entity.Explanation },
                        new object[] { "@created_by", DbType.Byte, entity.CreatedBy },
                    };

                    string query = $"INSERT INTO {tableName} (funds_id, journals_id, jev_no, date_entry, explanation, created_by) VALUES (@funds_id, @journals_id, @jev_no, @date_entry, @explanation, @created_by);";

                    // save and get the last inserted id
                    _ = _dbGenericCommands.ExecuteNonQuery(query, parameters);

                    // loop jev accounts list then insert each using the latest Jev Id
                    foreach (var jevAccounts in jevAccountsModelList)
                    {
                        jevAccounts.JEVId = GetLastInsertedID();
                        _ = _jevAccountsRepository.Insert(jevAccounts);
                    }

                    scope.Complete();

                    return true;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Insert(JEVModel entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(JEVModel entity)
        {
            throw new NotImplementedException();
        }

        public int GetLastInsertedID()
        {
            try
            {
                string query = $"SELECT MAX(id) FROM {tableName}";
                return int.Parse(_dbGenericCommands.ExecuteScalar(query));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool JevNumberExist(string jevNo)
        {
            try
            {
                var parameters = new object[][]
                {
                    new object[] { "@jev_no", DbType.String, jevNo },
                };

                string query = $"SELECT id FROM {tableName} WHERE jev_no = @jev_no";
                string queryResult = _dbGenericCommands.ExecuteScalar(query, parameters);

                // if query is not null, means found some record, so true
                if (!string.IsNullOrEmpty(queryResult)) return true;
            }
            catch (Exception)
            {
                throw;
            };

            return false;
        }
    }
}
