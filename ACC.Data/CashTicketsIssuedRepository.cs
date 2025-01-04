using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System.Collections.Generic;
using System.Data;

namespace ACC.Data
{
    internal class CashTicketsIssuedRepository : ICashTicketsIssuedRepository
    {
        private readonly string tableName = "cash_tickets_issued";
        private readonly string viewTableName = "view_cash_tickets_issued";
        private AccGenericCommands mySqlGenericCommandsLFS;

        public CashTicketsIssuedRepository(AccGenericCommands mySqlGenericCommandsLFS)
        {
            this.mySqlGenericCommandsLFS = mySqlGenericCommandsLFS;
        }

        public bool Delete(List<CashTicketsIssuedModel> entityList)
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

        public bool IdExist(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool Insert(CashTicketsIssuedModel entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(CashTicketsIssuedModel entity)
        {
            throw new System.NotImplementedException();
        }
    }
}