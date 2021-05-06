using ACC.Domain.Models;

namespace ACC.Domain.Interfaces
{
    public interface IDisbursingOfficerRepository : IRepository<DisbursingOfficerModel>
    {
        bool FullNameExist(string firstName, string middleInitial, string lastName, int id);
    }
}
