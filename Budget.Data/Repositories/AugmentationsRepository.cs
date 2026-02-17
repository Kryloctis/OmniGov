using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using OmniGov.Core.Repositories;
using OmniGov.Core.Services;
using System.Data;

namespace ACC.Data
{
    public class AugmentationsRepository : IAugmentations
    {
        private readonly string tableName = "augmentations";
        private GenericCommands mySqlGenericCommands;

        public AugmentationsRepository(GenericCommands mySqlGenericCommands)
        {
            this.mySqlGenericCommands = mySqlGenericCommands;
        }

        public int CountRecords()
        {
            throw new NotImplementedException();
        }

        public bool Delete(List<AugmentationsModel> entityList)
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

        public bool Insert(AugmentationsModel entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(AugmentationsModel entity)
        {
            throw new NotImplementedException();
        }
    }
}

