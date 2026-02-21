using OmniGov.Budget.Domain.Entities;
using OmniGov.Core.Interfaces.Repositories;

namespace OmniGov.Budget.Domain.Interfaces
{
    public interface IAllotmentAccountRepository : IRepository<AllotmentAccountModel>
    {
        bool DeleteByAllotmentReleaseId(int allotmentReleaseId);
    }
}
