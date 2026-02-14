using Budget.Domain.Models;
using OmniGov.Core.Interfaces;

namespace Budget.Domain.Interfaces
{
    public interface IAllotmentAccountRepository : IRepository<AllotmentAccountModel>
    {
        bool DeleteByAllotmentReleaseId(int allotmentReleaseId);
    }
}