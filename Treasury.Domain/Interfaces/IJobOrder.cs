using OmniGov.Core.Interfaces;
using Treasury.Domain.Entities;

namespace Treasury.Domain.Interfaces
{
    public interface IJobOrder : IRepository<JobOrderModel>
    {
        bool IsUserJobOrder(int userId);

        int GetJobOrderIdByUserId(int userId);

        Dictionary<string, string> GetRecordByUserID(int Id);
    }
}