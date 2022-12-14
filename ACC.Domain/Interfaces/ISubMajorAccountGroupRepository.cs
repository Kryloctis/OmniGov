using ACC.Domain.Models;
using System.Data;

namespace ACC.Domain.Interfaces
{
    public interface ISubMajorAccountGroupRepository : IAccRepository<SubMajorAccountGroupModel>
    {
        DataTable GetRecordsByMajorAccountId(short majorAccountId);

        DataTable GetViewRecordsByMajorAccountId(short majorAccountId);
    }
}