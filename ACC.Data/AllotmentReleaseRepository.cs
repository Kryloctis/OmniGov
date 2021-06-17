using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Transactions;

namespace ACC.Data
{
    public class AllotmentReleaseRepository : IAllotmentReleaseRepository
    {

        private MySqlGenericCommands _mySqlGenericCommands;
        private readonly string viewTableName = "view_allotment_release";
        private readonly string tableName = "allotment_release";
        private readonly IAllotmentAccountRepository _allotmentAccountRepository;

        public AllotmentReleaseRepository(MySqlGenericCommands mySqlGenericCommands, IAllotmentAccountRepository allotmentAccountRepository)
        {
            _mySqlGenericCommands = mySqlGenericCommands;
            _allotmentAccountRepository = allotmentAccountRepository;
        }


        public bool Insert(AllotmentReleaseModel entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(AllotmentReleaseModel entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(List<AllotmentReleaseModel> entityList)
        {
            throw new NotImplementedException();
        }


        public DataTable GetRecordsByBudgetAppropriationID(int budgetAppropriationID)
        {
            throw new NotImplementedException();
        }

        public DataTable GetRecordsByBudgetAppropriationID(int budgetAppropriationID, string allotmentReleaseNum)
        {
            throw new NotImplementedException();
        }

        public decimal GetTotalAllotmentReleaseByDateYear(int fundID, int fppID, int? othersFPPID, int allotmentClassID, int accountID, DateTime dateIssued, short year)
        {
            throw new NotImplementedException();
        }

        public decimal GetTotalAllotmentReleaseByYear(int fundId, int fppId, int? othersFPPId, int allotmentClassId, int AccountId, short year)
        {
            throw new NotImplementedException();
        }


        public decimal GetViewTotalAllotmentReleaseByIdDateYear(int budgetAppropriationId, DateTime dateIssued, short year)
        {
            throw new NotImplementedException();
        }

        public bool allotmentReleaseExist(int budgetAppropriationId, string dateIssued)
        {
            throw new NotImplementedException();
        }

        public bool allotmentReleaseExist(int id, int budgetAppropriationId, string dateIssued)
        {
            throw new NotImplementedException();
        }

        public decimal GetTotalAllotmentReleaseByIds(int fundId, int allotmentClassId, int fppId)
        {
            throw new NotImplementedException();
        }

        public bool IdExist(int id)
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

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            throw new NotImplementedException();
        }

        public int CountRecords()
        {
            throw new NotImplementedException();
        }


        public int GetLastInsertedID()
        {
            try
            {
                string query = $"SELECT MAX(id) FROM {tableName}";
                return int.Parse(_mySqlGenericCommands.ExecuteScalar(query));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Insert(AllotmentReleaseModel entity, List<AllotmentAccountModel> listAllotmentAccount)
        {
            try
            {
                using (var scope = new TransactionScope())
                {
                    var parameters = new object[][]
                    {
                        new object[] { "@aro_no", DbType.String, entity.ARONumber},
                        new object[] { "@purpose", DbType.String, entity.Purpose},
                        new object[] { "@date_issued", DbType.Date, entity.DateIssued.Date}
                    };

                    string query = $"INSERT INTO {tableName} (aro_no, purpose, date_issued) VALUES (@aro_no, @purpose, @date_issued)";

                    _ = _mySqlGenericCommands.ExecuteNonQuery(query, parameters);

                    foreach (var allotmentAccount in listAllotmentAccount)
                    {
                        allotmentAccount.AllotmentReleaseID = GetLastInsertedID();
                        _ = _allotmentAccountRepository.Insert(allotmentAccount);
                    }

                    scope.Complete();
                    return true;
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
