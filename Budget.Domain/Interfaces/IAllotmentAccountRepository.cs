using Budget.Domain.Models;
using OmniGov.Core.Interfaces.Repositories;

namespace Budget.Domain.Interfaces
{
    public interface IAllotmentAccountRepository : IRepository<AllotmentAccountModel>
    {
        bool DeleteByAllotmentReleaseId(int allotmentReleaseId);
    }
}