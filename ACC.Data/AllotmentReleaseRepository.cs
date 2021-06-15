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

    
    }
}
