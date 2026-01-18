using ACC.Domain.Budget.Models;
using ACC.Domain.Interfaces;

namespace ACC.Domain.Budget.Interfaces
{
    public interface IAllotmentAccountRepository : IAccRepository<AllotmentAccountModel>
    {
        bool DeleteByAllotmentReleaseId(int allotmentReleaseId);
    }
}