using ACC.Domain.Models;
using System.Collections.Generic;

namespace ACC.Domain.Interfaces
{
    public interface IDisbursingOfficerRepository : IAccRepository<DisbursingOfficerModel>
    {
        bool FullNameExist(string firstName, string middleInitial, string lastName, int id);
        Dictionary<string, string> GetRecordByUserID(int Id);
    }
}
