using ACC.Domain.Models;

namespace ACC.Domain.Interfaces
{
    public interface ICollectingOfficerRepository : IRepository<CollectingOfficerModel>
    {       
        bool FullNameExist(string firstname, string middleinitial, string lastname, int id);        
    }
}
