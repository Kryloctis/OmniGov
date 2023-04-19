using ACC.Domain.Models;
using System.Collections.Generic;

namespace ACC.Domain.Interfaces
{
    public interface IDisbursingOfficerRepository : IAccRepository<DisbursingOfficerModel>
    {
        Dictionary<string, string> GetRecordByUserID(int Id);
    }
}