using ACC.Domain.Models;

namespace ACC.Domain.Interfaces
{
    public interface IAllotmentAccountRepository : IAccRepository<AllotmentAccountModel>
    {
        bool DeleteByAllotmentReleaseId(int allotmentReleaseId);
    }
}