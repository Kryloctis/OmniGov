using OmniGov.Core.Entities;
using System.Data;

namespace OmniGov.Core.Interfaces
{
    public interface ISubMajorAccountGroupRepository : IRepository<SubMajorAccountGroupModel>
    {
        DataTable GetRecordsByMajorAccountId(short majorAccountId);

        DataTable GetViewRecordsByMajorAccountId(short majorAccountId);
    }
}