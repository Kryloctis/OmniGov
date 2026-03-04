using OmniGov.Budget.Domain.Entities;
using OmniGov.Budget.Domain.Interfaces;
using OmniGov.Core.Interfaces.Services;
using System.Data;

namespace OmniGov.Budget.Data.Repositories
{
    public class AugmentationsRepository : IAugmentations
    {
        private readonly string tableName = "augmentations";
        private IGenericCommands _genericCommands;

        public AugmentationsRepository(IGenericCommands genericCommands)
        {
            _genericCommands = genericCommands;
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
