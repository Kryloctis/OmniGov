using ACC.Data;
using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System.Collections.Generic;
using System.Data;

namespace AccountingSystem
{
    internal class BurialPermitRepository : IBurialPermitRepository
    {
        private AccGenericCommands _mySqlGenericCommands;
        private readonly string tableName = "burial_permit";

        public BurialPermitRepository(AccGenericCommands mySqlGenericCommands)
        {
            _mySqlGenericCommands = mySqlGenericCommands;
        }

        public bool IdExist(int id)
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

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            throw new System.NotImplementedException();
        }

        public int CountRecords()
        {
            throw new System.NotImplementedException();
        }

        public bool Insert(BurialPermitModel entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(BurialPermitModel entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(List<BurialPermitModel> entityList)
        {
            throw new System.NotImplementedException();
        }

        public bool InsertWithPayment(PaymentCollectionHasChequesModel paymentCollectionHasChequesModel, PaymentCollectionsModel paymentCollectionsModel, BurialPermitModel burialPermitModel)
        {
            throw new System.NotImplementedException();
        }
    }
}